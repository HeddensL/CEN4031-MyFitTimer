using MyFitTimer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyFitTimer.Client.Services
{
    public class StopwatchTrackerService : IStopwatchTrackerService
    {
        private readonly HttpClient _httpClient;

        public StopwatchTrackerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public event Action OnChange;

        public StopwatchTracker ElapsedTime { get; set;  } = new StopwatchTracker();

        public async Task<StopwatchTracker> GetElapsed()
        {
            ElapsedTime = await _httpClient.GetFromJsonAsync<StopwatchTracker>("api/stopwatchtracker/elapsed");
            OnChange.Invoke();
            return ElapsedTime;
        }

        public async Task<StopwatchTracker> Start()
        {
            await _httpClient.GetFromJsonAsync<StopwatchTracker>("api/stopwatchtracker");
            OnChange.Invoke();
            return ElapsedTime;
        }

        public async Task<StopwatchTracker> Stop()
        {
            await _httpClient.GetFromJsonAsync<StopwatchTracker>("api/stopwatchtracker/stop");
            OnChange.Invoke();
            return ElapsedTime;
        }
    }
}
