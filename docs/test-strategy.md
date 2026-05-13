# Test Strategy

## Critical Scenarios

The most critical scenarios in the Fitness Tracker project are:

- Creating valid training sessions
- Preventing invalid training data
- Handling duplicate sessions
- Validating activities and distances
- Returning correct sessions for users

## Hardest Parts To Test

The hardest parts to test were:

- Domain validation rules
- Repository behavior
- Fault handling and invalid states

## Where Mocks Are Needed

Mocks can be useful for:

- Future database repositories
- External services
- File storage integrations

## Where Real Integration Is Needed

Real integration tests are required for:

- Repository operations
- Sequential operations
- Session retrieval logic

## Negative Scenarios

The following negative scenarios were tested:

- Null objects
- Empty collections
- Duplicate entities
- Invalid dates
- Negative values
- Invalid repetitions and sets