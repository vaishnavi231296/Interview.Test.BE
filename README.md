Graduation Tracker - Project Summary
Overview:
In this project, I was tasked with reviewing and fixing a graduation tracking system that had broken unit tests and logic issues. The goal was to clean up the code, ensure all tests pass, and follow best practices aligned with SOLID principles. This involved improving the core graduation logic and expanding test coverage to handle various student scenarios.

Changes Made:
1. HasGraduated() Logic
Fixed incorrect logic in averaging and credit counting
Handled missing/empty course scenarios
Used for loops with break to avoid duplicate credit counting
2. Unit Test Improvements
Created a single, clean test method: TestEligibilityForAllStudents()
Used tuples with expected results to test multiple students
Covered edge cases:
No courses
Missing required course

Test Coverage Summary:
Student 1: Passed, Standing - SumaCumLaude
Student 2: Passed, Standing - MagnaCumLaude
Student 3: Passed, Standing - Average
Student 4: Failed, Standing - Remedial
Student 5: Failed, Standing - Remedial (No courses)
Student 6: Failed, Standing - MagnaCumLaude (Missing required course)

There were no significant blockers during this task. If the code depended on real databases or services, I would use tools like Moq to create fake versions of those dependencies during testing, so I can focus on testing just my logic. Additionally, I ensured the code is clean, easy to understand, and follows SOLID principles, which makes it maintainable and scalable for future requirements.