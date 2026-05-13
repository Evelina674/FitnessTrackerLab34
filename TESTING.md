# TESTING

## Test Types

The project contains:

- Unit Tests
- Integration Tests
- Fault Handling Tests

## Total Tests

- 20 Unit Tests
- 8 Integration Tests
- 28 Total Tests

## Tested Components

### Domain

- TrainingSession
- ActivityRecord
- Distance
- CardioActivity
- StrengthActivity

### Infrastructure

- InMemoryFitnessSessionRepository

## Negative Scenarios Tested

- Empty values
- Null references
- Duplicate sessions
- Invalid sets and repetitions
- Negative weight
- Invalid distance
- Unknown session IDs

## Coverage

Coverage is collected using coverlet.

Run tests with coverage:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover