# FitnessTracker

## Опис проєкту

FitnessTracker — це консольний застосунок для відстеження фізичної активності, тренувань та прогресу користувача.

Проєкт реалізовується як підсумковий міні-проєкт для лабораторних робіт 34–37 та демонструє інтеграцію тем курсу ООП, SOLID, тестування, fault handling та багатошарової архітектури.

---

# Мета проєкту

Метою проєкту є створення системи для:

- створення тренувань;
- відстеження кардіо-активностей;
- відстеження силових вправ;
- перевірки коректності даних;
- демонстрації принципів ООП;
- подальшого розширення функціоналу.

---

# Структура проєкту

FitnessTrackerLab34/

```text
FitnessTrackerLab34/
├── src/
│   ├── FitnessTracker.Domain/
│   ├── FitnessTracker.Application/
│   ├── FitnessTracker.Infrastructure/
│   └── FitnessTracker.Console/
│
├── tests/
│   └── FitnessTracker.Tests/
│       ├── Unit/
│       ├── Integration/
│       └── Fixtures/
│
├── docs/
│   ├── vision.md
│   ├── backlog.md
│   ├── class-diagram.md
│   ├── sequence-diagram.md
│   ├── iteration-1.md
│   ├── iteration-2.md
│   ├── iteration-3.md
│   ├── test-strategy.md
│   └── test-matrix.md
│
├── TESTING.md
├── README.md
├── FitnessTracker.sln
└── .github/workflows/
```

# Архітектура

Проєкт побудований за принципом багатошарової архітектури:

- Domain Layer
- Application Layer
- Infrastructure Layer
- Console Layer

Кожен шар має окрему відповідальність та взаємодіє через контракти й інтерфейси.

---

# Інтеграція тем курсу

## Lab 34

У проєкті реалізовано:

- класи та інкапсуляцію;
- конструктори;
- абстракції та інтерфейси;
- поліморфізм;
- SOLID principles;
- багатошарову архітектуру;
- UML-діаграми;
- vertical slice;
- базові unit tests;
- GitHub Actions CI.

---

## Lab 35

На цій ітерації реалізовано:

- persistence layer через JSON-файли;
- JSON repository для збереження та завантаження тренувань;
- Factory Pattern для створення активностей;
- LINQ-запити (Sum, Where, OrderByDescending, GroupBy);
- додаткові use cases;
- розширену business logic;
- додаткові unit та integration тести;
- IDataStore<T> abstraction;
- аналітичний сервіс FitnessAnalyticsService;
- підготовку до fault handling та quality gate.

---

## Lab 36

На наступній ітерації планується:

- automated testing;
- integration tests;
- coverage reporting;
- quality gate;
- testing documentation;
- CI testing pipeline.

---

## Lab 37

На фінальній ітерації планується:

- USER_GUIDE;
- DEVELOPER_GUIDE;
- FINAL_REPORT;
- DEMO;
- release documentation;
- release hardening.

---

# Реалізовані сутності

У проєкті реалізовано:

- TrainingSession
- Activity
- CardioActivity
- StrengthActivity
- ActivityRecord
- Distance
- UserProfile

---

# Бізнес-логіка

У застосунку реалізовано:

- перевірку User ID;
- перевірку дат;
- validation rules;
- перевірку activities;
- перевірку repetitions та sets;
- перевірку ваги;
- distance validation.

---

# Use Cases

Реалізовані use cases:

1. Створення тренування
2. Додавання кардіо-активності
3. Додавання силової активності
4. Валідація даних тренування

---

# Vertical Slice

У проєкті реалізовано повний vertical slice:

Console

→ Application

→ Domain

→ Repository

→ Console Output

---

# Тестування

У проєкті реалізовано базові unit tests для:

- validation logic;
- business rules;
- invalid states;
- negative scenarios.

У майбутніх ітераціях планується додавання integration tests та coverage.

---

# Fault Handling

У проєкті реалізовано базову обробку:

- null values;
- invalid states;
- invalid numeric values;
- invalid collections;
- validation exceptions.

---

# CI та GitHub Actions

У проєкті налаштовано:

- restore;
- build;
- automated testing;
- CI workflow.

---

# Документація

У репозиторії присутні:

- README.md
- vision.md
- backlog.md
- class-diagram.md
- sequence-diagram.md
- iteration-1.md

Також підготовлено структуру для майбутніх ітерацій:

- iteration-2.md
- iteration-3.md
- TESTING.md
- test-strategy.md
- test-matrix.md

---

# Висновок

FitnessTracker демонструє інтеграцію основних тем курсу ООП у єдиний ітеративний проєкт із багатошаровою архітектурою та підготовкою до подальшого розширення.
