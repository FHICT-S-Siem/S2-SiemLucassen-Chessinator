# Chessinator
Chess tournament organiser in ASP.NET CORE

## Sprint 1
In de eerste sprint heb ik analyse documentatie gemaakt wat betrekking heeft tot:

Analyse
- Planning & iteraties
- Requirements
  - Functionele
  - Non-Functionele
- Use cases
  - Use case diagram
  - Use case omschrijving
- Schermontwerpen
- Conceptueel model

Algoritmiek
- Circustrein opzet

Ik ben van plan om dit web-based project te maken in ASP.Net Core MVC, Owen heeft mij aangreden om Blazor te gebruiken voor de frontend.
Het fijne aan Blazor lijkt me om interactieve web UI in C# te schrijven i.p.v. JavaScript, ook is het fijn om je bezig te houden met maar een programmeertaal.  
Dit is voor mij nog wel een leuke uitdaging omdat ik nog nooit met aan een web-based project heb gewerkt binnen C#. 

Mijn Repositories voor mijn project Chessinator en Algoritmische opdrachten 
zijn te vinden in de volgende git links:

https://github.com/SiemLuc/S2-SiemLucassen-Chessinator
https://github.com/SiemLuc/S2-SiemLucassen-Algoritmiek

## Sprint 2

In de tweede sprint heb ik vooral aan mijn ontwerp documentatie gewerkt en mijn analyse document aangepast wat betrekking heeft tot:

Analyse
- Conceptueel model verbeterd
- Testplan toegevoegd

Ontwerp
- Architectuur
  - Architectuurlagen
  - Architectuur diagram
- Klassendiagram
- Database ontwerp

Implementatie
- Opzet mappenstructuur met entiteit Tournament

Algoritmiek 
- Circustrein applicatie verbeterd

Met name zou ik nog graag op het Database ontwerp en Architectuur diagram feedback willen omdat ik hier nog niet helemaal tevreden over ben.

Ik heb een uitlegvideo over clean architecture aangeraden gekregen door mijn broer(die in een hoger semester zit), hieruit heb ik een beter idee gehaald over hoe de lagen in mijn project in werking gaan. 
Door me aan de principes te houden van clean architecture, heb ik al een voorsprong naar het maken van een SOLID project.
In mijn hoofdstuk over architectuur laat ik zien hoe de eerste flow loopt van mijn Tournament/User. 
In mijn implementatie map staat al een opzet van mijn mappenstructuur, waarin ik de flow vanuit mijn architectuurdiagram toepas in mijn project.
Ik heb een klassendiagram en database ontwerp gemaakt door te kijken naar de sensible default en te vragen naar feedback van docenten en teamleden.

Hiernaast ben ik samen met _Dirk_ en _Owen_ uit mijn groep verder aan de slag gegaan met het algoritmiekopdracht Circustrein. 
Ik moet nog een probleem oplossen waarbij ik eerst moet sorteren op de volgorde van de grootte van de dieren, als dit gelukt is kan ik mijn unit-testen afmaken en het voordragen. 

_De uitlegvideo: https://www.youtube.com/watch?v=_lwCVE_XgqI door Jason Taylor._ 

## Sprint 3

In de derde sprint heb ik vooral aan mijn implementatie, alogritmiek opdracht gewerkt en mijn ontwerpdocument aangepast wat betrekking heeft tot:

Ontwerp
- Architectuur
  - Architectuur diagram
- Database ontwerp

Implementatie - CLEAN Architecture toegepast
- CRUD Tournaments (Enitity Framework)
- Login back-end & Crypthography
- Automapper toegevoegd
- Database gecreëerd met migrations

Algoritmiek 
- Circustrein applicatie afgemaakt
- Circustrein unittests toegevoegd

Graag zou ik feedback willen op mijn algoritmiekopdracht en de bijhorende unittests, aangezien het een te druk schema was om het te laten nakijken maar ook hiervoor kunnen we een meeting plannen.

In het feedback gesprek kwam terug dat ik nog wat foutjes had in mijn database ontwerp waar ik een paar kraaienpoten verkeerd om had of entiteiten nog in meervoud had staan, dit is nu verwerkt in mijn ontwerp. Ook heb ik deze sprint in plaats van twee flows, maar een flow gebruikt in het architectuur diagram omdat het redundant bleek te zijn. 

Voor de implementatie ben ik begonnen met het schrijven van de backend voor de login met cryptografie, maar heb het nog niet op de UI geïmplementeerd omdat ik destijds nog niet voldoende afwist van de blazor UI. Hierna heb ik een template gevonden genaamd Blazor-CRUD, waarmee ik heel mijn tournament backend gemakkelijk op de UI kon presenteren. Ik heb voor het omzetten van entiteiten naar dto's Automapper gebruikt wat ik ook kreeg aangeraden in een van de lessen van Jason Taylor. Ik heb Entity Framework Code first gebruikt omdat ik zodanig mijn Properties met de juiste data constraints via een migration naar de database kan sturen. Ook is EF heel simpel te gebruiken voor het maken van CRUD commands.

Ik heb in het algoritmiek opdracht circustrein mijn laatste functie afgemaakt en unittesten hierop uitgevoerd. Ik ben nog niet zeker over de lange namen die ik voor de testen gebruikt heb.

## Sprint 4

In de vierde sprint heb ik vooral aan mijn implementatie gewerkt wat betrekking heeft tot:

Implementatie
- CRUD Groups & Players + Error afhandeling
- Custom authenticationstate & Sessionstorage toegevoegd
- Database aangepast (relaties toegevoegd)

Graag zou ik feedback willen op mijn implentatie van de CRUD in de frontend.

Ik ben deze sprint begonnen door session storage en custom authenticationstate toe te voegen waardor ik de UserID kan opslaan, zodat wanneer ik bijvoorbeeld de pagina herlaad met een ingelogde user, de user nog steeds gevalideerd is. 
Ook heb ik goed moeten nadenken hoe ik mijn players en groups moest toevoegen, omdat er vaak validatieschecks bij kwam kijken. Ik heb een aantal wijzigingen gemaakt in de database omdat er een paar relaties nog niet goed stonden. 
 
Nu ik mijn players en groups kan toevoegen kan ik in de volgende sprint me vol gaan focussen op het "Starten" van een tournament, waarin groepen verdeeld worden en de winnaar tegen een andere winnaar speelt. Ik zal wel rekening moeten houden met hoeveel tijd ik nodig heb om de andere tournament-types te implementeren.
