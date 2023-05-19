using System.Net.Http.Json;

namespace Portfolio.ViewModels
{
    public class SpeakingViewModel : ISpeakingViewModel
    {
        public List<EducationEvent>? Conferences { get; set; }
        private HttpClient _httpClient;

        public SpeakingViewModel()
        {

        }
        public SpeakingViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<SpeakingModel?> GetSpeaking()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<SpeakingModel>("sample-data/speaking.json");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error getting speaking data");
                throw;
            }
            
        }

        public async Task GetConferences()
        {
            try
            {
                SpeakingModel? speaking = await GetSpeaking();
                this.Conferences = speaking?.EducationEvent;
                Console.WriteLine(speaking?.EducationEvent);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        public static implicit operator SpeakingViewModel(SpeakingModel? speaking)
        {
            return new SpeakingViewModel
            {
                Conferences = speaking?.EducationEvent
            };
        }

        public static implicit operator SpeakingModel(SpeakingViewModel speakingViewModel)
        {
            return new SpeakingModel
            {
                EducationEvent = speakingViewModel.Conferences
            };
        }
    }
}