# Shaper Workbench Verbindungen erstellen

Sinn dieser Fräsvorlagen ist das Erstellen einer 90° Verbindung von Leisten,
die vorher auf eine Größe von 45mm Breite und 20mm Dicke gehobelt wurden.
Die Verbindung ist ähnlich einer Überblattung, nutzt aber eine einem Puzzle
ähnliche runde vorne sichtbare Struktur, die die beiden Teile zusammenhält.

Dieses Dokument enthält zahlreiche Überlegunen bis zur Durchführung der Fräsung
und wird sich im Laufe der Zeit verändern.

Ziel ist es, mit möglichst wenigen Operationen auf der Shaper Origin
möglichst viele Verbindungen in gleicher Zeit herstellen zu können.


## Ausrichtung/Vorbereitung Workbench

 * Workbench Tiefe so einstellen, dass Oberkante Leiste bündig mit Domino-Fläche ist
 * alle Leisten werden so eingeschoben, dass sie von rechts nach links zeigen
 * die Außenkante jeder Leiste ist immer zur Domino-Seite hin
 * Opferleiste an senkrechter Alu-Kante: 20mm
 * dünne Distanz-Leiste auf beiden Seiten der zu fräsenden Leiste: 20mm
 * Abstand Ablage von Kante: 60mm + Leistenbreite (bei 45: 105mm)
 * Notwendig: Spannvorrichtung für äußere Distanzleiste, damit Teile fest liegen

       |                       |
       |        Domino         |
       |                       |
       +-----------------------+
       ------------------------- ^ Opferleiste 20mm x 25mm
       ----------------+-------- ^ Distanzleiste 20mm x 10mm
       Leiste          | (nix)   <- zu fräsende Leiste 45mm x 20mm
       ----------------+--------
       ------------------------- ^ Distanzleiste 20mm x 10mm
       
       ------------------------- Ablage


## Alternative: Plate benutzen

 * oben an der Plate eine Leiste befestigen, damit Plate nicht kippt
 * an der Plate eine Leiste befestigen so dass die x-Achse markiert wird (oberhalb Anlage-Leiste)
 * dann kann die zu fräsende Leiste mit ihrer Unterseite auf die x-Achse gesetzt werden
 * Klemmung an Seite außerhalb Plate. Müsste halten ;-)
 * evtl. Markierungen auf Werkstück anbringen zum Plazieren der markierten Stelle auf x=0, y=0.
   - Ziel: keine Positionierung beim Import nötig, sondern maximal 180° Drehung.
   - bei Aussparung: Mitte der Aussparung (22,5mm vom Ende)
   - bei Lasche: 30mm vom Ende. Bezugspunkt

                           +-- y-achse
                           |
            |  Plate       |             |
            |              v             |
            |   +---------------------+  |
            |   |                     |  |
         ---.....----------+          |  |
            |              |          |  |      <-- Werkstück
         ---.....-------~~~~~~~-------....---   <-- x-Achse ~ = Opfer-Bereich
                                         |      <-- Leiste zur Anlage
         ---.....---------------------....---       schaut auf beiden Seiten
            |    +--------------------+  |          raus zum Fixieren
            |                            |          des Werkstücks
            +----------------------------+


## Fräsvorbereitung (vor jeder Fräsung)

 * Raster festlegen: 2 x auf Unterkante Leiste, 1 x rechts oder links
   Plate: nur beim ersten mal
 * Import Fräsmuster
   - ggf. drehen 90/180°
     Aussparung: 90° im Uhrzeiger-Sinn // TODO: gleich im Affinity Designer drehen, dann 0° :-)
   - Position Lasche (Stirnseitig zu fräsen)
     x=0, y=Leistenstärke/2 (22,5mm)
     Lasche links: drehen 180° // Alternativ: 2 SVG Dateien bereitstellen
     Lasche rechts: nicht drehen
   - Position Aussparung (vorne zu fräsen)
     Aussparung links: x=Leistenstärke/2 (22,5mm), y=0
     Aussparung rechts: x=-Leistenstärke/2 (-22,5mm), y=0
   Plate: bei geeigneter Befestigung und korrektem Bezugspunkt nur Import, Lasche links: 180°, sonst nix.
   
## Fräsen

 * Kontrolle: Außen/Innen/Tasche
 * TODO: brauchen wir irgendwo Versatz (Leimfuge)?
 * Tiefen: 5mm / 10mm in 2 Durchgängen bei Weichholz, 3,5mm Schritte bei Hartholz

Evtl. Lasche 2mm tiefer fräsen und dann mit Japan-Säge überschüssiges Holz
als Führung verwenden und absägen. Genauen Wert ausprobieren, evtl. nur 1mm!
Als Richtwert: Dicke des Sägeblattes inkl. Verschränkung messen.

## Serien-Fräsungen am Stück

 * Wie sicherstellen, dass Achsen immer noch gleich bleiben?
   - Dübel mit bekanntem Durchmesser als Stopper z.B. 10mm // einfacher zu rechnen als 8
     -> Kompensation bei einer von 3 Fräsungen notwendig, dafür immer gleicher Anschlag
   - Distanz-Stücke, die jeweils von einem linken und rechten Loch aus gehalten werden
     und an gleicher Stelle enden.
     -> dann Raster immer identisch, keine Kompensation notwendig
   - Plate einsetzen und mit dem Fadenkreuz positionieren
 * einmalig Achsenwechsel bei Lasche links notwendig.
   - Alternativ: Versatz beim Einspannen gegen Objekt fester Dicke kompensieren.
   - fällt bei Plate weg



## Graphiken und Bezugspunkt für Plate

* Bezugspunkt wird in Mitte des Fadenkreuzes gesetzt.

* Ausschnitt: Leiste mit vorher markierter 22,5mm Stelle auf x=0 stellen

                           <----- 45mm ---->
                                   <-22mm-->
      -------------------------------------+
                           :               |
                           :     _____     |
                           :    /     \    |
                           :   /       \   |
                           :   \       /   |
                           :    \     /    |
                           :    |     |    |
      --------------------------+  *  +----+
                                   ^        
                                   +--- Bezugspunkt


* Lasche: mit Schnittkante auf x=0 stellen oder mit Streichmaß-Markierung
  Alternative für gegenüberliegende Seite: Lasche um 180° drehen, gleiche Einstellung

                                <-- 30mm -->
      -------------------------------------+
                                :          |
                                :   +--+   |
                                ---/    \  |
                                         | | 
                                ---\    /  |
                                :   +--+   |
                                :          |
      --------------------------*----------+
                                ^
                                +--- Bezugspunkt: Streichmaß-Markierung


## Beschleunigung

 * Aussparung
   - auf Innen-Seite rechts und links 22,5mm markieren
   - Anlage auf 22,5mm Markierung
   - 5mm fräsen

 * Lasche
   - mit Streichmaß: 30mm rund um beide Enden markieren
   - Anlage auf 30mm Markierung
   - 6mm fräsen
   - mit Japansäge überzähliges Stück entfernen

 * weniger belastbar, aber ist nur Tür-Rahmen für Schrank :-)
