# Test Matrix

| Use Case | Test Type | Covered By |
|---|---|---|
| Create training session | Unit | TrainingSessionTests |
| Validate empty user id | Unit | TrainingSessionTests |
| Validate invalid date | Unit | TrainingSessionTests |
| Validate empty activities | Unit | TrainingSessionTests |
| Create activity record | Unit | ActivityRecordTests |
| Validate null activity | Unit | ActivityRecordTests |
| Validate distance | Unit | DistanceTests |
| Validate cardio activity | Unit | CardioActivityTests |
| Validate strength activity | Unit | StrengthActivityTests |
| Add session to repository | Integration | FitnessTrackerIntegrationTests |
| Get session by id | Integration | FitnessTrackerIntegrationTests |
| Prevent duplicate session | Integration | FitnessTrackerIntegrationTests |
| Get sessions by user | Integration | FitnessTrackerIntegrationTests |
| Handle unknown session id | Integration | FitnessTrackerIntegrationTests |
| Handle empty repository | Integration | FitnessTrackerIntegrationTests |
| Sequential repository operations | Integration | FitnessTrackerIntegrationTests |

## Summary

The test matrix confirms that the main use cases, validation rules, and repository scenarios are covered by automated tests.