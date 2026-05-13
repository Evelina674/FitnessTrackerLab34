# FitnessTracker

FitnessTracker is a layered console application for tracking workout sessions, recording activity performance, and reviewing progress in a small fitness program.

## What works

- Layered architecture: `Domain`, `Application`, `Infrastructure`, `Console`, `Tests`
- One completed vertical slice: create workout session, save it in repository, and show session summary
- Domain model with activity hierarchy, value object, invariants, and training sessions
- Basic error handling and validation in constructors and services
- At least 5 unit tests covering domain rules and service behavior
- GitHub Actions workflow for `restore`, `build`, and `test`

## Getting started

```bash
cd "C:\Users\admin\Downloads\FitnessTrackerLab34"
dotnet build
dotnet test
cd src/FitnessTracker.Console
dotnet run
```

## Project layout

- `src/FitnessTracker.Domain` — domain entities, value objects, and repository contract
- `src/FitnessTracker.Application` — application service, commands, DTOs, and validation
- `src/FitnessTracker.Infrastructure` — in-memory repository implementation
- `src/FitnessTracker.Console` — console UI and use-case flow
- `tests/FitnessTracker.Tests` — unit tests for domain and application logic

## Iteration artifacts

- `docs/vision.md`
- `docs/backlog.md`
- `docs/class-diagram.md`
- `docs/sequence-diagram.md`
- `docs/iteration-1.md`
