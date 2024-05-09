/* SvgMangler
   - loads a svg file from the first commandline argument 
   - adds namespace xmlns:shaper="http://www.shapertools.com/namespaces/shaper"
   - searches for shapes with an ID like "d-x.ymm" or "d-x.yin"
   - removes the "d-..." thing from ID
   - adds a shaper:cutDepth="..." attribute to the tags it finds replacing a previous value if present
   
   - renames the original file to .bak.svg (or .bak2, .bak3, ... if already backups are there)
   - saves the modified file as .svg

   requires a .NET SDK to be installed.   
   run like (if inside a Project folder)
   dotnet run --project ../SvgMangler /path/to/x.svg
*/

using System.Text.RegularExpressions;
using System.Xml;

const string shaperNs = "http://www.shapertools.com/namespaces/shaper";
const string shaperCutDepth = "shaper:cutDepth";
const string nsUri = "http://www.w3.org/2000/xmlns/";

if (!args.Any()) throw new ArgumentException(".svg file missing");
var xmlFilePath = args[0];
if (Path.GetExtension(xmlFilePath) != ".svg") throw new ArgumentException("not a .svg file");

var svgFile = LoadSvg(xmlFilePath);
var svgHasChanged = false;

EnrichWithCuttingInformation(svgFile);

if (svgHasChanged)
   SaveSvg(svgFile, xmlFilePath);
else
   Console.WriteLine("No changes made in svg file");

return;

XmlDocument LoadSvg(string filePath)
{
   Console.WriteLine("Loading svg");
   var svg = new XmlDocument();
   svg.Load(filePath);
   return svg;
}

void SaveSvg(XmlDocument svg, string filePath)
{
   for (var i = 1; ; i++)
   {
      var bakFile = filePath.Replace(".svg", i == 1 ? ".bak.svg" : $".bak-{i:0}.svg");
      if (File.Exists(bakFile)) continue;

      Console.WriteLine($"Creating backup {filePath} -> {bakFile}");
      File.Move(filePath, bakFile);
      break;
   }

   Console.WriteLine("Saving svg");
   svg.Save(filePath);
}

// iterate through all xml tags inside our SVG document
// and convert ID strings with depth information to cutDepth
void EnrichWithCuttingInformation(XmlDocument svg)
{
   void AddShaperAttributesIfExtractableFromId(XmlNode tag)
   {
      if (tag.ParentNode == tag.OwnerDocument || tag.LocalName.StartsWith('#')) return;

      var id = tag.Attributes?.GetNamedItem("id")?.Value;
      if (string.IsNullOrWhiteSpace(id)) return;
   
      var depthRegex = new Regex(@"\bd\s*[-:=]\s*(?<depth>\d+(?:[.]\d+)?\s*(?:mm|in))");
      var match = depthRegex.Match(id);
      if (match.Success)
      {
         var depth = match.Groups["depth"].Value.Replace(" ", "");

         var cutDepth = tag.Attributes[shaperCutDepth];
         if (cutDepth is null)
         {
            Console.WriteLine($"Appending cutDepth '{depth}' from id '{id}'");
            cutDepth = svg.CreateAttribute(shaperCutDepth, shaperNs);
            cutDepth.Value = depth;
            tag.Attributes.Append(cutDepth);
            svgHasChanged = true;
         }
         else if (cutDepth.Value != depth)
         {
            Console.WriteLine($"Updating cutDepth, '{cutDepth.Value}' -> '{depth}' from id '{id}'");
            cutDepth.Value = depth;
            svgHasChanged = true;
         }
      }
   }

   void Visit(XmlNode node)
   {
      AddShaperAttributesIfExtractableFromId(node);
      foreach (XmlNode child in node.ChildNodes)
         Visit(child);
   }

   var svgTag = svg.DocumentElement!;
   if (svgTag.Attributes["xmlns:shaper"] is null)
   {
      Console.WriteLine("Setting XML Namespace to allow shaper:tags");
      var shaperNsAttribute = svg.CreateAttribute("xmlns", "shaper", nsUri);
      shaperNsAttribute.Value = shaperNs;

      svgTag.Attributes.Append(shaperNsAttribute);
      svgHasChanged = true;
   }

   foreach (XmlNode node in svg.ChildNodes)
      Visit(node);
}
