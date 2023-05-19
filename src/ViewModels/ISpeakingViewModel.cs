namespace Portfolio.ViewModels
{
    public interface ISpeakingViewModel
    {
        public List<EducationEvent>? Conferences { get; set; }

        public Task GetConferences();

    }
}