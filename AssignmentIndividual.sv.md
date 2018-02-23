# Brädspel, individuell

Uppgiften finns i två varianter, en for teams och denna för individuella. 

Uppgiften består av två delar, en programmeringsdel och en dokumentationsdel. 

Allt ni gör skall göras i dit GitHub repo (båda kod och dokumentation), som ligger på dig. Du skall använda en ["commit tidigt och ofta"](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategi, såklart bör du endast commita kod och dokumentation som kan kompileras.

# Programmering
I detta projekt ska du implementera ett brädspel, ni får själv välja vilket, men ett förslag är TicTacToe (tre på rad), och där finns litet kod förbred för detta (solution, projekter, CSS och HTML).

Spelet ska implanteras i ett tomt ASP.NET MVC projekt (som är gjort klar) och Razor i kombination med HTML ska användas till att presentera spelet, detta projekt är skapat och ligger som en del av BoardGame-solutionen. 
Kod ska ligga i mappen Src.

Det går bra om användarna själv ska uppdatera sidan (tycka F5) för att kunna följa med i spelet.

Spelet skall bara kunna köra på eran lokala dator (localhost), men ni får så klart gärna lägga ut det på en annan server.

## Grundtanken 
Spelet ska vara en webbsida vart man går in som spellera. Bara två spelera får vara inna på spelet på samma tid, är man nummer 3 som kommer in i spelet ska man få något meddelande om att spelet är fullt. 

Det ska vara möjligt att lämna spelet, så att andra kan komma in istället.

Det skall var tydigt att det är ens rund i spelet, om man uppdatera sidan.

## Spelmotor (GameEngine)
Spelmotorn styra alla regler i spelet och kollar t.ex. om en bricka får flyttas, om en spelar har vunnit, vilken spelar som är den nästa, etc.

Implementera spelmotorn i ett separat klass bibliotek, detta är klart och hetter gameengine.

En instans av spelmotorn innehåller staten av ett helt spel, det skall vara möjligt att initialisera spelet med en given state.

# Dokumentation
Dokumentation ska skrivas som Markdown i mappen DocsSrc, du väljer själv om du vill skriva på svenska eller engelska.

Skriv user stories (i mappen DocsSrc\userstories), och starta inte koda något innan du har skrivet någon user stories, men se hela tiden till att lägga till fler user stories.

Beskriv arkitekturen av din applikation (i mappen DocsSrc\architecture).

Om du använder någon externa källor (båda kod och annat) ange dom i dokumentationen.

# Individuell betygsättning
Det rekomenderas att göra ett simpelt spel som tic-tac-toe, där är gjort en grund för ett tic-tac-toe spel i src mappen, detta kan du i så fall bygga vidre på

En använder starter ett spel och en annan använder joiner spelet (oftest i en annan webbläsere), bara ett spel behöver att kunne köra i taget

## Absolut Minimum
* Använn Visual Studio solution BoardGame.sln som är placerat i mappen Src, som består av två projekt
  * ASP.NET Web Application (.NET Framework) - BoardGameWui
  * Class Library (.NET Framework) - GameEngine

* Koden kompilera och det går att köra projektet lokalt
* Ett grafiskt gränssnitt gjort med HTML och Razor, till att rita upp spelbräda och pjäser

## För G (Absolut minimum + minst 2 av dissa för G)

* 5 user stories skriven (på svenska eller engelska) i Markdown och i dokumentet *index.md* placerat i mappen *DocsSrc\userstories*, som besrkiver hur en spelere skulle spela spelet
* I projektet GameEngine projektet lägg all logik som rör spelet, även kast av tärning
* Ett dokument (på svenska eller engelska) som beskriver arkitekturen på projektet, speciellt intressant är hur spelmotor om man skulle önska att använda den i ett annat projekt och hur är koplingen emellan gränssnitt och backend, använn gärna diagrammer
* Ställa in URL routen så att startsidan till spelet är top level, typ så: http://localhost/

## För VG (G + minst 2 av dissa för VG)
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