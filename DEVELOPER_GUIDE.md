# Developer Guide

## Архітектура проєкту

Проєкт побудований за багатошаровою архітектурою:

- FitnessTracker.Domain
- FitnessTracker.Application
- FitnessTracker.Infrastructure
- FitnessTracker.Console

---

## Domain Layer

Містить бізнес-сутності:

- TrainingSession
- Activity
- CardioActivity
- StrengthActivity
- ActivityRecord
- Distance
- UserProfile

Domain не залежить від інших шарів.

---

## Application Layer

Містить бізнес-логіку:

- FitnessTrackerService
- FitnessAnalyticsService
- ActivityFactory

Application використовує Domain та інтерфейси репозиторіїв.

---

## Infrastructure Layer

Містить роботу з даними:

- InMemoryFitnessSessionRepository
- JsonFitnessSessionRepository
- JsonTrainingSessionStore
- IDataStore<T>

Infrastructure реалізує контракти Application Layer.

---

## Console Layer

Відповідає за взаємодію з користувачем через консольне меню.

---

## Використані патерни

### Repository Pattern

Використовується для роботи зі сховищем тренувань.

### Factory Pattern

Використовується для створення CardioActivity та StrengthActivity.

---

## SOLID

У проєкті використовуються:

- Single Responsibility Principle
- Open/Closed Principle
- Dependency Inversion Principle

---

## Запуск проєкту

```bash
dotnet run --project src/FitnessTracker.Console
```

---

## Запуск тестів

```bash
dotnet test
```

---

## Запуск coverage

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

## Розширення проєкту

Для додавання нового типу активності потрібно:

1. Створити новий клас у Domain.
2. Наслідуватися від Activity.
3. Додати створення в ActivityFactory.
4. Додати unit tests.