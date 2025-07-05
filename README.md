# 🏢 CleanConference – System Rezerwacji Sal Konferencyjnych

Projekt Web API do zarządzania rezerwacjami sal konferencyjnych. Zbudowany w oparciu o **Clean Architecture**, z użyciem **CQRS**, wzorca **Repository**, **Policy Pattern** oraz wielu nowoczesnych narzędzi i bibliotek.

---

## 🚀 Funkcjonalności

- ✅ Rejestracja i logowanie użytkowników (JWT)
- ✅ Potwierdzanie stworzonego użytkownika
- ✅ Obsługa ról: `User` / `Admin`
- ✅ CRUD sal konferencyjnych (dla admina)
- ✅ Tworzenie rezerwacji z walidacją konfliktów
- ✅ Lista rezerwacji zalogowanego użytkownika
- ✅ Anulowanie rezerwacji
- ✅ Seedowanie danych przy starcie aplikacji
- ✅ Logowanie przychodzących zapytań i błędów
- ✅ Globalna obsługa błędów

---

## 🧠 Technologie i biblioteki

| Kategoria              | Użyta technologia                      |
|------------------------|----------------------------------------|
| Architektura           | Clean Architecture, CQRS               |
| ORM                    | Entity Framework Core                  |
| Walidacja              | FluentValidation                       |
| Komunikacja            | MediatR                                |
| Autoryzacja            | JWT Bearer Auth + Role-based Policy    |
| Logowanie              | NLog                                   |
| API Docs               | Swagger (Swashbuckle)                  |

---

## 🧱 Architektura

/Confy
│
├── API/ # ASP.NET Core Web API (Controllers)
├── Application/ # CQRS (Handlers, Commands, Queries, DTOs)
├── Domain/ # Encje, Enumy, logika domenowa
├── Infrastructure/ # EF Core, JWT, logowanie, repozytoria, seed
└── Tests/ # Testy jednostkowe i integracyjne (następny update)

## 🧪 Seedowane dane

Przy pierwszym uruchomieniu aplikacja automatycznie tworzy:

- 👤 Użytkownika admina
- 🏢 Przykładowe sale konferencyjne
- 📅 Testowe rezerwacje