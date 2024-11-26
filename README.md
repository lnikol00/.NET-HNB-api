# Korištenje REST-bazirane web usluge

RESTful web servis (ili REST-bazirani servis) je arhitektonski stil koji se koristi za dizajn mrežnih aplikacija koje komuniciraju s resursima putem weba koristeći standardne HTTP metode. REST znači REpresentational State Transfer i definira skup principa za kreiranje skalabilnih web servisa.

## Sadržaj
* [Zadatak](#zadatak)
* [Ključni koncepti RESTful servisa](#Ključni-koncepti-RESTful-servisa)
* [ASP.NET Core Web API kao RESTful backend](#ASP.NET-Core-Web-API-kao-RESTful-backend)
* [.NET MAUI aplikacija kao klijent za RESTful servise](#.NET-MAUI-aplikacija-kao-klijent-za-RESTful-servise)

## Zadatak

Ovaj primjer prikazuje .NET MAUI aplikaciju za dohvat u kojoj su podaci pohranjeni i dostupni putem REST-bazirane web usluge. Kod web usluge nalazi se u projektu HnbAPI. Zadatak aplikacije je dohvatitit s HNB Api-a tečajnu listu za period vremena od-do, te za navedeni period izračunati prosječnu vrijednost svih tečajnih listi po valuti.
* HNB API: https://api.hnb.hr/tecajn-eur/v3?datum-primjene-od=2024-01-25&datum-primjene-do=2024-01-26

## Ključni koncepti RESTful servisa

Resursi: U RESTful servisu resursi (npr. korisnici, proizvodi, postovi) su identificirani pomoću URI-ja (Uniform Resource Identifier). Svaki resurs je dostupan putem jedinstvenog URL-a.

HTTP metode: REST servisi koriste standardne HTTP metode za izvođenje operacija nad resursima:

* GET Dohvaća resurs ili popis resursa.
* POST: Kreira novi resurs.
* PUT ili PATCH: Ažurira postojeći resurs.
* DELETE: Briše resurs.

Bezdržavnost (Statelessness): REST servisi su bezdržavni, što znači da svaki zahtjev od klijenta prema serveru mora sadržavati sve potrebne informacije za razumijevanje i obradu zahtjeva. Server ne pohranjuje kontekst klijenta između zahtjeva.

Reprezentacija resursa: Server odgovara klijentu s reprezentacijom resursa, obično u formatima kao što su JSON ili XML.

HTTP status kodovi: RESTful servisi koriste standardne HTTP status kodove za označavanje rezultata operacija:

* 200 OK: Zahtjev je uspješno izvršen.
* 201 Created: Resurs je uspješno kreiran.
* 404 Not Found: Resurs nije pronađen.
* 400 Bad Request: Zahtjev je neispravan.
* 500 Internal Server Error: Dogodila se pogreška na serveru.

## ASP.NET Core Web API kao RESTful backend

U tvom slučaju, koristi se ASP.NET Core Web API kao backend za aplikaciju. ASP.NET Core Web API je okvir dizajniran za izgradnju RESTful servisa koji mogu komunicirati s različitim klijentima poput web preglednika, desktop aplikacija i mobilnih aplikacija.

* Rute (Routing): Web API definira rute koje mapiraju na specifične resurse. Ove rute obično slijede RESTful konvencije, npr.:
  *  ```http
        GET /api/currency
      ```
   
* Kontroleri (Controllers): U ASP.NET Core Web API-ju, kontroleri obrađuju dolazne HTTP zahtjeve. Svaki kontroler obično predstavlja resurs, a metode unutar kontrolera mapiraju se na različite HTTP metode (GET, POST, PUT, DELETE).

* Modeli (Models): Web API koristi modele (obično klase) za predstavljanje struktura podataka poput proizvoda, korisnika, itd. Ovi modeli se serijaliziraju u JSON (ili XML) prilikom slanja odgovora klijentu.

* Dependency Injection: ASP.NET Core pruža ugrađenu podršku za dependency injection, što pojednostavljuje upravljanje servisima poput pristupa bazi podataka, logiranja i drugih infrastrukturnih servisa.

```bash
  dotnet restore
  dotnet run 
```
Dakle, dotnet restore osigurava da su svi paketi dostupni, a dotnet run pokreće aplikaciju.    

## .NET MAUI aplikacija kao klijent za RESTful servise

.NET MAUI (Multi-platform App UI) projekt je frontend nativna mobilna aplikacija koja koristi REST za pristup podacima iz ASP.NET Core Web API-ja. .NET MAUI omogućava izradu aplikacija za više platformi (Android, iOS, macOS i Windows) koristeći jedan kod.

Evo kako .NET MAUI komunicira s ASP.NET Core Web API-jem koristeći REST:

* HTTP klijent: .NET MAUI aplikacija vjerojatno koristi klasu HttpClient za slanje HTTP zahtjeva prema ASP.NET Core Web API-ju. HttpClient se koristi za:

```csharp
 HttpResponseMessage response = await _client.GetAsync(uri);
 if (response.IsSuccessStatusCode)
    {
       string content = await response.Content.ReadAsStringAsync();
       items = JsonSerializer.Deserialize<List<ViewResultModel>>(content, _serializerOptions);
    }
    else
    {
        Debug.WriteLine($"Request failed with status code: {response.StatusCode}");
    }
```
* Asinkroni pozivi (Asynchronous Calls): Većina zahtjeva prema Web API-ju je asinkrona, koristeći async/await u C#. Ovo omogućava da UI ostane responzivan dok se mrežne operacije izvršavaju.

* Parsiranje JSON-a: Podaci koje API vraća obično su u JSON formatu. .NET MAUI koristi knjižnice poput Newtonsoft.Json ili System.Text.Json za parsiranje JSON-a u C# objekte.

* Višestruka platforma (Cross-Platform Capabilities): Uz .NET MAUI, isti kod može raditi na Androidu, iOS-u, macOS-u i Windowsu, što olakšava održavanje aplikacije. Kada komuniciraš s RESTful servisima, ista logika za HTTP zahtjeve može se koristiti na svim platformama.

```bash
  dotnet restore
  dotnet build
  dotnet run 
```

Dakle, dotnet build koristi se za buildanje aplikacije prije pokretanja
