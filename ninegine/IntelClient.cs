using System;
using System.Net.Http;

namespace NineshaftLightIntel.Engine
{
    public static class IntelClient
    {
        public static HttpClient Instance { get; }

        private static readonly string[] UserAgents = {
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.0 Safari/605.1.15"
        };

        private static readonly Random _random = new();

        static IntelClient()
        {
            Instance = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(15),
                MaxConnectionsPerServer = 10
            });
        }

        public static HttpRequestMessage CreateStealthRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            string randomAgent = UserAgents[_random.Next(UserAgents.Length)];
            request.Headers.Add("User-Agent", randomAgent);
            return request;
        }
    }
}
