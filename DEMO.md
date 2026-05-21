# Demo Scenario

## Мета демонстрації

Показати основні можливості FitnessTracker за 3–5 хвилин.

---

## Крок 1. Запуск застосунку

Запустити:

```bash
dotnet run --project src/FitnessTracker.Console
```

Створити профіль користувача:

- Name: Test User
- Age: 25
- Weight: 80
- Height: 180

---

## Крок 2. Створення тренування

Обрати:

1. Add workout session

Створити cardio активність:

- Running
- Duration: 30 minutes
- Distance: 5 km

Переконатися, що сесія створена успішно.

---

## Крок 3. Перегляд статистики

Обрати:

2. Show session summary

Показати:

- кількість тренувань;
- загальну тривалість;
- кількість активностей.

---

## Крок 4. Аналітика

Обрати:

5. Show analytics

Показати:

- total duration;
- total activities;
- newest session;
- sessions by date.

---

## Крок 5. Збереження даних

Обрати:

3. Save sessions to JSON

Показати успішне збереження.

---

## Крок 6. Відновлення даних

Перезапустити програму.

Обрати:

4. Load sessions from JSON

Показати успішне відновлення.

---

## Крок 7. Негативний сценарій

Спробувати створити некоректну активність:

- negative distance;
- invalid sets;
- invalid repetitions.

Показати повідомлення про помилку.

---

## Крок 8. Архітектурне пояснення

Пояснити:

- Domain Layer;
- Application Layer;
- Infrastructure Layer;
- Console Layer;
- Repository Pattern;
- Factory Pattern.