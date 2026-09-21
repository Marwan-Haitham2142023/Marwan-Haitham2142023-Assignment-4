SIMULATION · Software House & Academy · simulationeg.com

# Academy Schedule Analyzer

**Student Name:** Marwan Haitham
**Cohort:** Group 3
**Assignment:** Assignment 4

## Project

[AcademyScheduleAnalyzer/](AcademyScheduleAnalyzer/)

A C# console application that analyzes academy session schedules.

## LeetCode

[LeetCode/README.md](LeetCode/README.md)

## LinkedIn

[LinkedIn/README.md](LinkedIn/README.md)

## Benchmark

[BENCHMARK.md](BENCHMARK.md)

BenchmarkDotNet comparison of `string` concatenation vs `StringBuilder`
(100 / 1,000 / 10,000 / 100,000 iterations, with memory allocation).

## How to Run

### Requirements
- .NET SDK (the version used in this project: .NET 10)

### Run the console application
```bash
cd AcademyScheduleAnalyzer/AcademyScheduleAnalyzer
dotnet run -c Release
```

### Notes
- Run in **Release** mode. It is required for accurate benchmark results.
- The BenchmarkDotNet run may take several minutes. Close other heavy programs while it runs.
- Benchmark output files are generated in `BenchmarkDotNet.Artifacts/results/`.