using System.Net;
using System.Net.Http.Json;
using System.Net.Security;
using benchmark.Abstractions;

namespace benchmark;

public class Http2ApiClient
{
    private readonly HttpClient _client;
    
    public Http2ApiClient()
    {
        var handler = new SocketsHttpHandler
        {
            // ⚡ Se solicita HTTP/3 si el servidor lo soporta
            SslOptions = { ApplicationProtocols = [SslApplicationProtocol.Http2] },
            EnableMultipleHttp2Connections = true
        };
        _client = new HttpClient(handler)
        {
            DefaultRequestVersion = HttpVersion.Version20,
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher
        };
        _client.BaseAddress = new Uri("https://http3test.mvasquez.net:7080");
    }
    
    public async Task<IEnumerable<WeatherForecast?>?> Get()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<WeatherForecast?>>("/weatherforecast");
        return response;
    }
}