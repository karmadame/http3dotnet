using benchmark.Abstractions;
using BenchmarkDotNet.Attributes;

namespace benchmark;

public class Http2VsHttp3BenchMark
{
    private readonly Http2ApiClient _httpClient1 = new();
    private readonly Http3ApiClient _httpClient2 = new();
    
    [Params(100, 500)]
    public int N;
    
    [Benchmark]
    public List<WeatherForecast>? Http2()
    {
        var result = _httpClient1.Get();
        result.Wait();  
        return result.Result?.ToList()!;   
    }
    
    
    [Benchmark]
    public List<WeatherForecast>? Http3()
    {
        var result = _httpClient2.Get();
        result.Wait();  
        return result.Result?.ToList()!;   
    }
}