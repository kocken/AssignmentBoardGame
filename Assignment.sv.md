# Brädspel

Uppgiften skall lösas i teams på 3 till 4 studenter (eller alternativt ensamt uppgiften formulerat för teams, men där finns [andra krav](#betygsättning-vid-en-persons-grupp) om önskar att jobba ensamt).

Uppgiften består av två delar, en programmeringsdel och en dokumentationsdel. 

Allt ni gör skall göras i ert GitHub repo (båda kod och dokumentation), som ligger på ert Team. Ni skall använda en ["commit tidigt och ofta"](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategi, såklart bör ni endast commita kod och dokumentation som kan kompileras.

# Programmering
I detta projekt ska ni implementera ett brädspel, ni får själv välja vilket, men där finns ett Fia bräde (Ludo på engelska) i mappen Content som ni kan använda som grund (CSS och HTML). Den enklast uppgift är ett spel vart man turas om att spela.

Spelet ska implanteras i ett tomt ASP.NET MVC projekt (inte .NET Core) och Razor i kombination med HTML ska användas till att presentera spelet, detta projekt är skapat och ligger som en del av BoardGame-solutionen. 
Kod ska ligga i mappen Src, varje team har bara en kodbas!!

Det går bra om alla igångvarande spel bara lever i minnet på servern, så där är inget krav på att ni skall spara staten i databas eller på disk.

Det går också bra om användarna själv ska uppdatera sidan (tycka F5) för att kunna följa med i spelet.

Spelet skall bara kunna köra på eran lokal dator (localhost), men ni får så klart gärna lägga ut det på en annan server.


## Grundtanken 
Spelet ska vara en webbsida vart man går in som spellera.

När man som ny spellera kommer in på sidan ska man kunna välja att starta ett spel eller vara del va ett eksisterende spel, alla eksisterende öppna spel visas som en lista. 

Om man vill starta ett nytt spel ska man ange sin epost adress och hur många spelleror (min 2 och max 4 för Fia) som ska vara i spelet. Om man vill vara med i ett öppet spel ett i listan och anger sin epost adress och kommer sen in på spelet.

Om man redan är en del av ett spel hoppar automatisk in på spelet och ser därför aldrig första sidan.

När alla spelleror är inne i spelet (angivit med antalet av spellera) låsas spelet och det startar. Bäst är det om alla spelleror får en notfikation (eg. ett mail) om att spelet starter och första spelare får en epost om att det är hens rond. Det är kanske bra om man kan kliva ur ett spel som är låst.

En spelar starter sin rond med att klicka på en knap som rullar tärningen, och väljer efter detta brickan som hen önskar att flytta.

När en spelar avslutar sin rond, sickas en epost till den nästa så att hen kan gå in och flytta på sin bricka.

När en spellera vinner spelet ska alla spellera få ett mail om att spelet är slut och spelet tas bort så att det inte finns mer.

## Spelmotor (GameEngine)
Spelmotorn styra alla regler i spelet och kollar t.ex. om en bricka får flyttas, om en spelar har vunnit, den initiala uppställning av alla brickor på brädet, vilken spelar som är den nästa, hur en tärning ska bete sig, etc.

Implementera spelmotorn i ett separat klass bibliotek, implementationen skall följa SOLID principerna, så långt det går.

En instans av spelmotorn innehåller staten av ett helt spel, det skall vara möjligt att initialisera spelet med en given state.

Ett enhetstest (Unit Test) projekt skall skåpas, och logiken i spelet ska testas med enhetstestar.

# Dokumentation
Dokumentation ska skrivas som Markdown i mappen DocsSrc, ni väljer själv om ni vill skriva på svenska eller engelska.

Skriv user stories (i mappen DocsSrc\userstories), och starta inte koda något innan in har skrivet minst 3 user stories, men se hela tiden till att lägga till fler user stories.

Beskriv arkitekturen av eran applikation (i mappen DocsSrc\architecture).

Om ni använder någon externa källor (båda kod och annat) ange dom i dokumentationen.

# Betygsättning vid grupp-projekt (3-4 personer)
## För G
* En (och endast en) Visual Studio solution placerat i mappen Src
* 3 user stories skriven (på svenska eller engelska) i Markdown och placerat i mappen DocsSrc\userstories
* Solutionen ska beså av minst tre projekt:
  * ASP.NET Web Application (.NET Framework)
  * Class Library (.NET Framework)
  * Unit Test Project (.NET Framework)

* Koden kompilera och det går att köra projektet lokalt
* All logik som rör spelet, även kast av tärning, är placerat i spelmotorn, och där finns enhetstestar som validera om koden funkar
* Ett grafiskt gränssnitt gjort med HTML och Razor, eventuellt med stöd från Javascript för att göra gränssnittet mer interaktivt.
* Ett dokument (på svenska eller engelska) som beskriver arkitekturen på projektet, speciellt intressant är hur spelmotor om man skulle önska att använda den i ett annat projekt och hur är koplingen emellan gränssnitt och backend
* Som spellera ska gå att joina skåpa ett nytt spel
* Som spellera ska gå att joina ett eksisterende spel
* Spelet varje spelare måste befinna sig på olik webbläsare, så att det styrs med cookies vilket spel man är en del av 

## För VG (G + minst 3 för VG)
* Mail utskick för att informera spelarna, äntligen direkt via SMTP eller en tjänst som SendGrid
  * Spel start
  * Ny rond

* En automatisk dokumentation av spelmotorn (gameengine) i DocFx, genererat ur från källkoden
* En TOC.yml som innehåller alla userstories i mappen DocsSrc\userstories
* Spelmotorn är implementera med SOLID principerna
* Projektet är ”installerat” på en extern webbserver (eg. Azure), så det går att komma åt den
* GitHubs ”Code review”-funktion används regelbunden i gruppens projekt
* Dynamisk uppdatering av spelet, om en spelare i sin webbläsare flyttar på en bricka uppdateras skärmen på alla andra webbläsare 


# Betygsättning vid en persons-grupp
Det rekomenderas att göra ett simpelt spel som tic-tac-toe, där är gjort en grund för ett tic-tac-toe spel i src mappen, detta kan du i så fall bygga vidre på

En använder starter ett spel och en annan använder joiner spelet (oftest i en annan webbläsere), bara ett spel behöver att kunne köra i taget

## Absolut Minimum
* Använn Visual Studio solution BoardGame.sln som är placerat i mappen Src, som består av två projekt
  * ASP.NET Web Application (.NET Framework) - BoardGameWui
  * Class Library (.NET Framework) - GameEngine

* Koden kompilera och det går att köra projektet lokalt
* Ett grafiskt gränssnitt gjort med HTML och Razor, till att rita upp spelbräda och pjäser

## För G (Absolut minimum + minst 2 för G)

* 5 user stories skriven (på svenska eller engelska) i Markdown och i dokumentet *index.md* placerat i mappen *DocsSrc\userstories*, som besrkiver hur en spelere skulle spela spelet
* I projektet GameEngine projektet lägg all logik som rör spelet, även kast av tärning
* Ett dokument (på svenska eller engelska) som beskriver arkitekturen på projektet, speciellt intressant är hur spelmotor om man skulle önska att använda den i ett annat projekt och hur är koplingen emellan gränssnitt och backend, använn gärna diagrammer
* Ställa in URL routen så att startsidan till spelet är top level, typ så: http://localhost/


## För VG (G + minst 2 för VG)
Om man gör VG delar skall det på något sätt vara enkelt att se vilka, ett förslag är att skriva det i *index.md* i mappen DocSrc

* Enhetstest av spellogiken i GameEngine
* Javascript är använt i Viewen för att göra gränssnittet mer interaktivt.
* Stöd för flera spel på samma server
* Spelet varje spelare måste befinna sig på olik webbläsare, så att det styrs med cookies vilket spel man är en del av 
* Unit Test Project (.NET Framework)

* Mail utskick för att informera spelarna, äntligen direkt via SMTP eller en tjänst som SendGrid
 * Spel start
 * Ny rond

* Spelmotorn är implementera med SOLID principerna
* Projektet är ”installerat” på en extern webbserver (eg. Azure), så det går att komma åt den
* GitHubs ”Code review”-funktion används regelbunden i gruppens projekt
* Dynamisk uppdatering av spelet, om en spelare i sin webbläsare flyttar på en bricka uppdateras skärmen på alla andra webbläsare 