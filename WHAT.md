# FenixWeb och vägen framåt





## Inledning



Vi har under en tid funderat och diskuterat om hur vi lämpligast hanterar vidareutveckling av

FenixWeb, som är delvis byggt med ramverket Fable. Det finns också delar som är byggda med ramverket



KnockOut, som inte underhålls längre.



I Fable skriver vi F# som kompilerar till React(js), fördelen är framförallt att vi vinner

något som kallas typsäkerhet.



Nackdelen med Fable är bl.a. att det underhålls av en relativt liten samling människor. Det

är också krångligt och tidsödande att integrera med 3:e-parts-bibliotek.



Fable är långt i från vanligt i web-utvecklings-sammanhang och det kan vara svårt att få tag på

programmerare som "kan Fable" / "har lust att lära sig Fable".



Vi känner oss osäkra på Fables framtid och utifrån detta ville vi se en väg framåt.





#### Analys och undersökning



###### **För att komma vidare formulerades ett antal frågor och önskningar:**



1.) 	Eftersom Fable kompilerar till React(), undrade vi över om det skulle vara möjligt att köra standard 	React(typescript) och Fable i ett och samma projekt.

2.) 	Undersök möjligheten att använda något etablerart ramverk för "styling".



3.) 	Är det möjligt att uppgradera till senaste versionen av Fable och React?



4.) 	Är det möjligt att förenkla dev-byggprocessen med målet att bara kunna köra: "dotnet run" och få server,
client (med fable och react typescript - komponenter) att bygga?



5.) 	Är det möjligt att åstadkomma en smidig "dev loop" d.v.s kunna koda och se resultatet direkt, utan att

&#x09;vänta på re-build.



6.) 	Är det möjligt att hitta en begriplig, mer standardiserad projektstruktur i FenixWeb?

###### 

###### **För att få svar på våra frågor, beslöt vi att bygga en liten prototyp, där vi verifierade följande:**



1.)	Ja det är möjligt och med React(typescript) uppnår vi också typsäkerhet.
Not:
I prototypen testade vi med Fable-dialekten Feliz. Vi användr också en annan dialekt
i FenixWeb, som heter Fable.React. Den har vi inte testat, men det borde göras.



2.)	Vi valde att det etablerade ramverket daisyUI, som är ett css-Tailwind ramverk. Det finns en plugin som funkar
med Feliz och det kanske kan vara värdefullt. Ramverket innehåller en mängd standardkomponenter, vars tema
kan anpassas. Det finns också många färdiga teman.



3.)	Ja det är möjligt att uppgradera till senaste versionen. Vi stötte på problem med en bra, men dåligt underhållen
3:e parts komponent, som heter Feliz.Router. Den gick emellertid att justera.



4.)	Ja det är möjligt. Vi använde ett etablerat bygg-ramverk som heter FAKE.





5.)	Ja det är nästan möjligt. Vi har dock inte lyckats få till en "Hot Reload" om ändring sker i en React(typescript)

&#x09;komponent och den används i Fable. På något sätt måste vi få "dotnet watch" förstå att den beroende 	Fablekomponenten måste byggas om.



6.)	Ja, prototypen ger förslag till ett upplägg som är mer strukturerat och begripligt.



#### Slutsas



Vi tycker undersökningan indikerar att det är möjligt att hantera de olika ramverken Fable, KnockOut och

React(typescript) i en och samma kodbas. Det är förstås ingen optimal lösning, men det öppnar för möjligheten att

byta ut Fable, KnockOut mot React(typescript) över tid, på ett kontrollerat sätt.

**Viktigt!
Konverteringen till React(typescript) måste vara ett prioriterat arbete, annars riskerar vi att få leva med**

\*\*en blandmiljö som är besvärlig att underhålla.

Uppgifter som isåfall måste lösas:\*\*



1.)	Verifiera att en React(typescript)-komponent, kan användas i en Fable.React-komponent.
**Not: Detta är ett krav.**



2.) Justera befintlig projektstruktur i FenixWeb



3.)	Implementera byggverktyget FAKE i FenixWeb för både dev och Azure miljöer



4.) 	Försök att få till en "Hot Reload" om ändring sker i en React(typescript)
Not: Det vore väldigt fint att få till, men vi kanske kan leva en stund med att det inte fungerar,

&#x09;När allt är konverterat till React(typescript), kommer det att fungera per automatik.



**Notera:**

**Ovanstående uppgifter är inte triviala och kommer att kräva en hel del jobb.**









11:51 2026-08-07 /Klas

