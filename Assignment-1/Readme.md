# Student Results Processing System

A menu-based C# console application for entering student details, recording course scores, and generating a results report with grades and pass/fail status.

## Features

- Enter results for any number of students (no fixed limit — type `exit` as the name, or answer `N` when asked to add another, to stop)
- Collects full name, student ID, programme, level, and scores for 5 courses:
  - Programming with C#
  - Database Systems
  - Computer Networks
  - Web Development
  - Mathematics for Computing
- Validates that every score is between 0 and 100, re-prompting on invalid input
- Calculates total score, average score, grade (A–F), and academic status (Passed/Failed) per student
- Displays a full report for all students entered
- Shows a class summary: best student, lowest-average student, and class average

## Grading System

| Average Score | Grade |
|----------------|-------|
| 80 – 100       | A     |
| 70 – 79        | B     |
| 60 – 69        | C     |
| 50 – 59        | D     |
| Below 50       | F     |

| Average Score   | Status |
|------------------|--------|
| 50 and above     | Passed |
| Below 50         | Failed |

## How to Run

```
dotnet run
```

## Menu

```
===== STUDENT RESULTS PROCESSING SYSTEM =====
1. Enter Student Results
2. View Student Report
3. Exit
```

## Project Structure

- `Program.cs` — menu loop, input handling, and report/summary display
- `Student.cs` — `Student` class holding student data and result calculations
