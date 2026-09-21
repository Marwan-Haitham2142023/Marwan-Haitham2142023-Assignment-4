# Benchmark Report: String Concatenation vs StringBuilder

## Environment
- BenchmarkDotNet v0.15.8
- Windows 11 (10.0.26200.9457, 25H2)
- 13th Gen Intel Core i7-13700H 2.40GHz, 1 CPU, 20 logical and 14 physical cores
- .NET SDK 10.0.401, .NET 10.0.12, X64 RyuJIT x86-64-v3
- Configuration: Release, `[MemoryDiagnoser]`, `[Params(100, 1000, 10000, 100000)]`

## Results (measured on my own machine)

| Method                     | Iterations | Mean                | Error             | StdDev            | Allocated      |
|--------------------------- |-----------:|--------------------:|------------------:|------------------:|---------------:|
| StringConcatenation        | 100        |         2,145.9 ns  |         35.82 ns  |         31.75 ns  |       51.73 KB |
| StringBuilderConcatenation | 100        |           203.2 ns  |          2.15 ns  |          2.39 ns  |        2.42 KB |
| StringConcatenation        | 1000       |       167,175.6 ns  |      2,819.62 ns  |      2,499.52 ns  |     4912.08 KB |
| StringBuilderConcatenation | 1000       |         1,707.3 ns  |         65.30 ns  |        192.55 ns  |       26.49 KB |
| StringConcatenation        | 10000      |    24,019,982.3 ns  |    245,448.18 ns  |    229,592.38 ns  |   488588.38 KB |
| StringBuilderConcatenation | 10000      |        43,390.2 ns  |        838.96 ns  |        823.97 ns  |      208.56 KB |
| StringConcatenation        | 100000     | 5,284,773,204.7 ns  | 96,944,441.34 ns  | 224,683,500.99 ns |  48835689.09 KB|
| StringBuilderConcatenation | 100000     |       432,208.1 ns  |      7,904.63 ns  |      6,600.73 ns  |     1966.48 KB |

## Analysis

### 1. Which approach was faster with 100 iterations?
`StringBuilderConcatenation` was faster: about 203 ns versus about 2,146 ns for
`StringConcatenation`, roughly 10x faster. Even at a small size StringBuilder won,
because the loop appends the same text many times.

### 2. Which approach was faster with 100,000 iterations?
`StringBuilderConcatenation` was faster by a huge margin: about 0.43 ms versus
about 5.28 seconds for string concatenation, roughly 12,000x faster.

### 3. Which approach allocated more memory?
`StringConcatenation` allocated far more at every size. At 100,000 iterations it
allocated about 48.8 GB (48,835,689 KB) versus about 1.9 MB (1,966 KB) for
StringBuilder. It also triggered Gen0, Gen1 and Gen2 garbage collections, while
StringBuilder mostly stayed in Gen0/Gen1.

### 4. What happened to string concatenation performance as the loop size increased?
It degraded much faster than the loop size grew. Going from 100 to 1,000
iterations (10x more work) increased the time about 78x, and going from 1,000 to
10,000 increased it about 144x. This is roughly quadratic growth, O(n²). The
StringBuilder time grew almost linearly with the number of iterations.

### 5. Why does repeated string concatenation create additional allocations?
Strings in .NET are immutable. Every `result += text` creates a brand-new string
large enough for the old content plus the new text, then copies everything into
it. The old string becomes garbage. After N iterations the program has allocated
N strings of growing length and copied about N²/2 characters in total. Large
strings (over ~85 KB) also go to the Large Object Heap, which explains the Gen2
collections seen at 10,000 and 100,000 iterations.

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?
StringBuilder is mutable and keeps an internal buffer (chunks of characters). New
text is written into the existing buffer, and it only grows occasionally, so
there is no full copy on every append. Only one final string is created when
`ToString()` is called. This gives roughly linear time and far fewer allocations.

### 7. Is StringBuilder always better than normal string operations?
No. For a small, fixed number of concatenations (for example `a + b + c`), the
compiler turns the expression into a single `string.Concat` call, which is
simpler, more readable and often faster, because creating a StringBuilder object
and its buffer has its own cost. StringBuilder is a good choice when appending
inside a loop or when the number of pieces is large or unknown. In our own
results, StringBuilder's advantage was clear, but that is because the test is
exactly the loop-append scenario.

## Conclusion
For repeated appends in a loop, StringBuilder is faster and uses far
less memory, and the gap grows with the number of iterations. For a few simple
concatenations, plain string operations are perfectly fine.