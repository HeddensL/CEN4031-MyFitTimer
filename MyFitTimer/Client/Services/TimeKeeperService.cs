using MyFitTimer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyFitTimer.Client.Services
{
    public class TimeKeeperService : ITimeKeeperService
    {
        private readonly HttpClient _httpClient;

        public TimeKeeperService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public List<TimeKeeper> Times { get; set; } = new List<TimeKeeper>();

        public async Task<List<TimeKeeper>> CreateTimeKeeper(TimeKeeper time)
        {
            var result = await _httpClient.PostAsJsonAsync<TimeKeeper>($"api/timekeeper", time);
            Times = await result.Content.ReadFromJsonAsync<List<TimeKeeper>>();
            OnChange.Invoke();
            return Times;
        }

        public async Task<List<TimeKeeper>> GetTimeKeepers()
        {
            Times = await _httpClient.GetFromJsonAsync<List<TimeKeeper>>("api/timekeeper");
            return Times;
        }

        public async Task<List<TimeKeeper>> DeleteTimeKeeper(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/timekeeper/{id}");
            Times = await result.Content.ReadFromJsonAsync<List<TimeKeeper>>();
            OnChange.Invoke();
            return Times;
        }
    }

    
}
