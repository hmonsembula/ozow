# ozow tech assessment
The solution aims to solve two problems

<br/>

ASP.NET Core following the principles of SOLID design.

### Dependency Injection
The application does not implement dependecy injection

###ConsoleApplication
Interactive user interface to simulate solutions

###QuestionOne
Sorting

###QuestionTwo
Conway's Game of Life simulation

###Tests
Unit tests to solution following a TDD approach

## Technologies
* .NET Core 3.1
* NUnit, FluentAssertions

## Solution Architecture
The appliction has three separate projects

1. Console Application (set as startup)
2. Question One library
3. Question Two library

###Question One Performance Efficiency
C# provides some of the most optimized sorting algorithms. For the purpose of this solution, I have opted to use two implementations:
1. Built in Array (Quick) sort which appears to be the most efficient for the use-case
2. Linq sorting

There are many ways to optimize sorting. Some factors to consider include:
- Computational complexity on data size.
- Memory usage
- Recursion
- Stability
