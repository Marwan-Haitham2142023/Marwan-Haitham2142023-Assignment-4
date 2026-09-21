SIMULATION · Software House & Academy · simulationeg.com

# Academy Schedule Analyzer

**Student Name:** Marwan Haitham
**Cohort:** (write your cohort here)
**Assignment:** Assignment 4

## Project

[AcademyScheduleAnalyzer/](Submission/AcademyScheduleAnalyzer/)

A C# console application that analyzes academy session schedules.

## LeetCode

[LeetCode/README.md](Submission/LeetCode/)

## LinkedIn

[LinkedIn/README.md](Submission/Linkedin/)

## Benchmark

[BENCHMARK.md](Submission/)

BenchmarkDotNet comparison of `string` concatenation vs `StringBuilder`
(100 / 1,000 / 10,000 / 100,000 iterations, including memory allocations).

## How to Run

### Requirements
- .NET SDK (this project uses .NET 10)

### Run the console application

```bash
cd Submission/AcademyScheduleAnalyzer
dotnet run -c Release
```

### Notes
- Run in **Release** mode. It is required for accurate benchmark results.
- The BenchmarkDotNet run can take several minutes, so close other heavy programs while it runs.
- Benchmark output files are generated in `BenchmarkDotNet.Artifacts/results/`.
