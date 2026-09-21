```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9457/25H2/2025Update/HudsonValley2)
13th Gen Intel Core i7-13700H 2.40GHz, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.401
  [Host] : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3

InvocationCount=5  UnrollFactor=1  WarmupCount=3  

```
| Method                 | Iterations | Mean | Error |
|----------------------- |----------- |-----:|------:|
| &#39;String Concatenation&#39; | 100        |   NA |    NA |

Benchmarks with issues:
  StringBenchmarks.'String Concatenation': Job-XSOJOD(InvocationCount=5, UnrollFactor=1, WarmupCount=3) [Iterations=100]
