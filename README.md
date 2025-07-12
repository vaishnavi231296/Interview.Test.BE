# Graduation Tracker

## Overview
This project implements a Graduation Tracker system designed to evaluate if students meet the requirements to graduate based on their courses and grades. The core logic calculates students’ average marks, credits earned, and assigns a standing (e.g., SumaCumLaude, MagnaCumLaude, Average, Remedial).

## Objectives
- Review and fix broken unit tests.
- Correct graduation logic for accurate credit and standing calculation.
- Improve code quality following clean code standards and SOLID principles.
- Expand test coverage to include edge cases such as missing courses and no courses.
- Organize code by moving all domain classes (`Student`, `Course`, `Diploma`, `Requirement`, `Repository`, etc.) into a dedicated `Model` folder for better maintainability and clarity.


## Features & Changes
- **Graduation Logic:**  
  Fixed the averaging and credit counting logic in the `HasGraduated` method.  
  Improved handling of missing or empty course scenarios.  

  Replaced `foreach` with `for` loops and used `break` to avoid duplicate credit counting.

- **Unit Testing:**  
  Consolidated test cases into a single comprehensive test method `TestEligibilityForAllStudents`.  
  Used tuples to manage expected outcomes for various student scenarios.  
  Covered edge cases including students with no courses and missing required courses.

## Test Coverage Summary
- Student 1: Passed - SumaCumLaude  
- Student 2: Passed - MagnaCumLaude  
- Student 3: Passed - Average  
- Student 4: Failed - Remedial  
- Student 5: Failed - Remedial (No courses)  
- Student 6: Failed - MagnaCumLaude (Missing required course)