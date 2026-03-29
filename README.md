# EquipmentRental – System wypo¿yczalni sprzêtu

## Opis
Aplikacja konsolowa w C# obs³uguj¹ca uczelnian¹ wypo¿yczalniê sprzêtu.  

---

## Funkcjonalnoœci
- dodawanie u¿ytkowników (Student, Employee)
- dodawanie sprzêtu (Laptop, Projector, Camera)
- wypo¿yczanie i zwroty
- kontrola dostêpnoœci
- naliczanie kar za opóŸnienia
- raporty (sprzêt, wypo¿yczenia, podsumowanie)

---

## Architektura
- **Models** – model domeny (Equipment, User, Rental)
- **Services** – logika biznesowa (RentalService, EquipmentService, ReportService, PenaltyPolicy)
- **Program.cs** – UI (scenariusz demonstracyjny)

---

## Decyzje projektowe
- dziedziczenie dla typów sprzêtu i u¿ytkowników
- logika biznesowa wydzielona do serwisów
- naliczanie kar w osobnej klasie (PenaltyPolicy)
- zastosowanie wyj¹tków domenowych
- zastosowanie interfejsów dla serwisów

---

## Kohezja i Coupling
- ka¿da klasa ma jedn¹ odpowiedzialnoœæ (np. RentalService – wypo¿yczenia)
- serwisy komunikuj¹ siê przez interfejsy
- brak logiki biznesowej w UI

---

## Regu³y biznesowe
- Student: max 2 wypo¿yczenia  
- Employee: max 5 wypo¿yczeñ  
- brak wypo¿yczenia niedostêpnego sprzêtu  
- kara za opóŸnienie  

---

## Scenariusz
Program demonstruje:
- poprawne i b³êdne operacje
- zwroty (terminowe i spóŸnione)
- raport koñcowy systemu

---

## Git
U¿yto branchy:
- `feature/domain-exceptions`
- `feature/service-interfaces`  
Scalone do `main`.

---

## Uruchomienie
```bash
dotnet run --project src/EquipmentRental