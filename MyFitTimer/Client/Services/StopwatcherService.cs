using MyFitTimer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyFitTimer.Client.Services
{
    public class StopwatcherService : IStopwatcherService
    {
        public event Action OnChange;

        private readonly HttpClient _httpClient;
                
        public StopwatcherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Stopwatcher Latest { get; set; } = new Stopwatcher();
                
        public List<Stopwatcher> NewestTime { get; set; } = new List<Stopwatcher>();
        
        public async Task<Stopwatcher> LatestTime()
        {
            Latest = await _httpClient.GetFromJsonAsync<Stopwatcher>("api/stopwatcher");
            return Latest;
        }

        public async Task<List<Stopwatcher>> CreateStopwatcher(Stopwatcher newTime)
        {
            var result = await _httpClient.PostAsJsonAsync<Stopwatcher>($"api/stopwatcher", newTime);
            NewestTime = await result.Content.ReadFromJsonAsync<List<Stopwatcher>>();
            OnChange.Invoke();
            return NewestTime;
        }
    }
}

