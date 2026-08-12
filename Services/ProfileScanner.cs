using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NineshaftLightIntel.Engine;

namespace NineshaftLightIntel.Services
{
    public class ProfileScanner
    {
        private static readonly string[] Targets = {
            "https://github.com",
            "https://habr.com",
            "https://steamcommunity.com",
            "https://t.me",
            "https://vk.com",
            "https://reddit.com",
            "https://dzen.ru",
            "https://pypi.org",
            "https://docker.com",
            "https://leetcode.com"
        };

        private static readonly Random _random = new();

        public async Task ExecuteScanAsync(string nickname)
        {
            foreach (string baseTarget in Targets)
            {
                string url = $"{baseTarget}/{nickname}";

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));

                try
                {
                    var request = IntelClient.CreateStealthRequest(url);
                    var response = await IntelClient.Instance.SendAsync(request, cts.Token);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"[FOUND] {url}");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine($"[-] NOT FOUND: {url}");
                    }
                    else
                    {
                        Console.WriteLine($"[?] BLOCKED/CHANGED (Code: {(int)response.StatusCode}): {url}");
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"[TIMEOUT] Server slow response: {url}");
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"[ERROR] Connection failed: {url}");
                }

                int delay = _random.Next(1000, 2500);
                await Task.Delay(delay);
            }
        }
    }
}
