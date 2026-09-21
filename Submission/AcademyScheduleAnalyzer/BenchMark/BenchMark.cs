using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class StringBenchmarks
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    private const string Text = "Hello";

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < Iterations; i++)
        {
            result += Text;
        }
        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            sb.Append(Text);
        }
        return sb.ToString();
    }
}