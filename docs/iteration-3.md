# Звіт по Iteration 3

## Виконана робота

Під час Iteration 3 проєкт було покращено за рахунок:

- unit tests;
- integration tests;
- fault handling;
- coverage support;
- testing documentation;
- quality gate.

---

# Тестування

У проєкті реалізовано:

- 20 Unit Tests
- 8 Integration Tests
- 28 Total Tests

---

# Coverage

Для збору coverage використовується coverlet.

Coverage перевіряється через:

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

Поточний результат:

- Domain coverage: 60%
- Infrastructure coverage: 100%

---

# Fault Handling

У проєкті реалізовано обробку:

- неправильних User ID;
- неправильних дат;
- порожніх колекцій;
- duplicate sessions;
- від’ємних значень;
- неправильних repetitions та sets;
- null-значень.

---

# Integration Tests

Було реалізовано integration tests для перевірки:

- додавання тренувань;
- отримання сесії за ID;
- отримання тренувань користувача;
- duplicate session validation;
- repository logic;
- sequential operations;
- null handling;
- retrieval logic.

---

# Архітектурні покращення

Було виконано:

- покращення validation logic;
- покращення repository validation;
- покращення testability;
- separation of concerns;
- підготовку до future extensions.

---

# Усунуті проблеми (Code Smells)

Було усунуто:

- зайві залежності;
- дублювання validation logic;
- неконтрольоване створення некоректних об’єктів;
- слабку fault handling logic.

---

# Ризики перед Lab 37

На даному етапі залишаються:

- відсутність file persistence;
- відсутність database layer;
- обмежений console UI;
- відсутність authentication system;
- недостатнє покриття Application layer.

---

# Підготовка до Lab 37

Проєкт підготовлений для:

- release hardening;
- додаткової документації;
- DEMO preparation;
- FINAL_REPORT;
- USER_GUIDE;
- DEVELOPER_GUIDE.

---

# Висновок

Iteration 3 значно покращила стабільність, тестованість та якість проєкту через automated testing, integration tests, validation rules та quality gate.