using System.Net.Http.Json;

namespace Portfolio.ViewModels
{
    public class ResumeViewModel : IResumeViewModel
    {
        public string? Name { get; set; }
        public string? About { get; set; }
        public List<ExperienceModel>? Experiences { get; set; }
        public List<EducationModel>? Educations { get; set; }
        public List<VolunteerModel>? Volunteers { get; set; }
        public List<SkillModel>? Skills { get; set; }
        public List<CertificationModel>? Certifications { get; set; }
        public List<CommunityModel>? Communities { get; set; }
        public List<AwardModel>? Awards { get; set; }
        public List<PatentModel>? Patents { get; set; }
        public List<ArticleModel>? Articles { get; set; }
        public List<ConferenceModel>? Conferences { get; set; }
        public List<MentorshipModel>? Mentorships { get; set; }
        public List<ProjectModel>? Projects { get; set; }
        public List<ProjectModel> Highlights { get; set; }
        public KeyWords keyWords { get; set; } = new KeyWords();
        public List<ProjectModel> FilterProjects(string selectedDomain, string selectedTechStack, string condition)
        {
            List<ProjectModel> filteredProjects = new List<ProjectModel>();

            foreach (var projectModel in Projects ?? new List<ProjectModel>())
            {
                List<string> keyWords = projectModel?.KeyWords?.Split(',').ToList() ?? new List<string>();
                keyWords = keyWords.Select(keyWord => keyWord.TrimStart()).ToList();

                bool matchesDomain = string.IsNullOrEmpty(selectedDomain) || keyWords.Contains(selectedDomain);
                bool matchesTechStack = string.IsNullOrEmpty(selectedTechStack) || keyWords.Contains(selectedTechStack);

                if ((condition == "or" && (matchesDomain || matchesTechStack))
                    || (condition == "and" && matchesDomain && matchesTechStack))
                {
                    filteredProjects.Add(projectModel ?? new ProjectModel());
                }
            }

            return filteredProjects;
        }

        private HttpClient _httpClient;

        public ResumeViewModel()
        {

        }
        public ResumeViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<ResumeModel?> GetResume()
        {
            return await _httpClient.GetFromJsonAsync<ResumeModel>("sample-data/resume.json");
        }
        public async Task GetBackground()
        {
            ResumeModel? resume = await GetResume();
            LoadBackground(resume);
        }
        public async Task GetSkills()
        {
            ResumeModel? resume = await GetResume();
            LoadSkills(resume);
        }

        public async Task GetAccomplishments()
        {
            ResumeModel? resume = await GetResume();
            LoadAccomplishments(resume);
        }

        public async Task GetProjects()
        {
            ResumeModel? resume = await GetResume();
            LoadProjects(resume);
        }

        public async Task<ProjectModel?> GetProject(string projectName)
        {
            ResumeModel? resume = await GetResume();
            LoadProjects(resume);
            foreach (var project in resume?.Projects ?? new List<ProjectModel>())
            {
                if (project.Title == projectName)
                {
                    Console.WriteLine("Project found");
                    return project;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Project not found");
            return null;
        }

        public void GetHighlights()
        {
            this.Highlights = new List<ProjectModel>
            {
                new ProjectModel
                {
                    Title = "Microsoft MVP Award 2023-2024",
                    Description = "Recognized as a Microsoft Most Valuable Professional (MVP) for outstanding contributions to the community in the AI category.",
                    RepoUrl = "",
                    Url = "https://www.linkedin.com/feed/update/urn:li:activity:7171882438745387009/",
                    ImageURL = "https://raw.githubusercontent.com/OscarSantosMu/portfolio/main/src/wwwroot/img/posts/1st-time-mvp.png",
                    KeyWords = "Award",
                    Priority = 1
                },
                new ProjectModel
                {
                    Title = "Artificial Intelligence and the Cloud",
                    Description = "Delivered a keynote highlighting the dynamic synergy between Artificial Intelligence and Cloud computing, drawing a sizable audience of over 800 attendees.",
                    RepoUrl = "",
                    Url = "https://codigofacilito.com/fin-de-semana-cloud",
                    ImageURL = "https://codigofacilito.com/assets/codys/programando-circle-83a5c0c48b92a40090f4d46f1b28b026630dd9ee8e51769cf223e53ca3eb32cb.png",
                    KeyWords = "Public Speaking",
                    Priority = 2
                },
                new ProjectModel
                {
                    Title = "HackMTY",
                    Description = "Hackathon Winner (best use of Google Cloud) in the largest student hackathon in Mexico.",
                    RepoUrl = "https://github.com/OscarSantosMu/GitSoft-Engine",
                    Url = "https://www.linkedin.com/posts/oscarsantosmu_hackmty-googlecloud-gitsoftengine-activity-7113248466633400322-5tnv?utm_source=share&utm_medium=member_desktop",
                    ImageURL = "https://raw.githubusercontent.com/OscarSantosMu/portfolio/main/src/wwwroot/img/me/hacks/hackmty.jpeg",
                    KeyWords = "Hackathon",
                    Priority = 3
                },
                new ProjectModel
                {
                    Title = "PyCon Colombia 2021",
                    Description = "Presented at PyCon Colombia 2021, a prestigious conference of the Python programming language.",
                    RepoUrl = "https://oscarsantosmu.github.io/Building_your_First_IoT_Application_with_Flask_and_MicroPython/",
                    Url = "https://2021.pycon.co/ponencias/8/",
                    ImageURL = "https://raw.githubusercontent.com/OscarSantosMu/portfolio/main/src/wwwroot/img/me/flyers/pycon21.jpg",
                    KeyWords = "Public Speaking",
                    Priority = 4
                },
                new ProjectModel
                {
                    Title = "Globant AI Code Fest 2023",
                    Description = "Hackathon Winner (greatest impact on society) among 300 participants across 4 cities in Latin America.",
                    RepoUrl = "",
                    Url = "https://www.linkedin.com/feed/update/urn:li:activity:7098433732776206336/",
                    ImageURL = "https://communications.globant.com/public/code-fest-ai/dist-esp/f61b9288bb8b1f16a393.jpg",
                    KeyWords = "Hackathon",
                    Priority = 5
                },
                new ProjectModel
                {
                    Title = "Converse with your data using your own ChatGPT with Azure OpenAI Service",
                    Description = "Wrote an article with over 2.5 thousand views on C# Corner.",
                    RepoUrl = "",
                    Url = "https://www.c-sharpcorner.com/article/converse-with-your-data-using-your-own-chatgpt-with-azure-openai-service/",
                    ImageURL = "https://www.c-sharpcorner.com/Jobs/UploadFile/UserData/prvn_131971/logo/ccornerlogo.jpg",
                    KeyWords = "Article",
                    Priority = 6
                },
                // Add more ProjectModel objects as needed
            };
        }

        private void LoadBackground(ResumeViewModel? resumeViewModel)
        {
            this.Name = resumeViewModel?.Name;
            this.About = resumeViewModel?.About;
            this.Experiences = resumeViewModel?.Experiences;
            this.Educations = resumeViewModel?.Educations;
            this.Volunteers = resumeViewModel?.Volunteers;
            this.Communities = resumeViewModel?.Communities;

        }

        private void LoadSkills(ResumeViewModel? resumeViewModel)
        {
            this.Name = resumeViewModel?.Name;
            this.About = resumeViewModel?.About;
            this.Skills = resumeViewModel?.Skills;
            this.Certifications = resumeViewModel?.Certifications;

        }

        private void LoadAccomplishments(ResumeViewModel? resumeViewModel)
        {
            this.Name = resumeViewModel?.Name;
            this.About = resumeViewModel?.About;
            this.Awards = resumeViewModel?.Awards;
            this.Patents = resumeViewModel?.Patents;
            this.Articles = resumeViewModel?.Articles;
            this.Conferences = resumeViewModel?.Conferences;
            this.Mentorships = resumeViewModel?.Mentorships;
        }

        private void LoadProjects(ResumeViewModel? resumeViewModel)
        {
            this.Name = resumeViewModel?.Name;
            this.About = resumeViewModel?.About;
            this.Projects = resumeViewModel?.Projects;
        }

        public static implicit operator ResumeViewModel(ResumeModel? resume)
        {
            return new ResumeViewModel
            {
                Name = resume?.Name,
                About = resume?.About,
                Experiences = resume?.Experiences,
                Educations = resume?.Educations,
                Volunteers = resume?.Volunteers,
                Skills = resume?.Skills,
                Certifications = resume?.Certifications,
                Communities = resume?.Communities,
                Awards = resume?.Awards,
                Patents = resume?.Patents,
                Articles = resume?.Articles,
                Conferences = resume?.Conferences,
                Mentorships = resume?.Mentorships,
                Projects = resume?.Projects
            };
        }

        public static implicit operator ResumeModel(ResumeViewModel resumeViewModel)
        {
            return new ResumeModel
            {
                Name = resumeViewModel.Name,
                About = resumeViewModel.About,
                Experiences = resumeViewModel.Experiences,
                Educations = resumeViewModel.Educations,
                Volunteers = resumeViewModel.Volunteers,
                Skills = resumeViewModel.Skills,
                Certifications = resumeViewModel.Certifications,
                Communities = resumeViewModel.Communities,
                Awards = resumeViewModel.Awards,
                Patents = resumeViewModel.Patents,
                Articles = resumeViewModel.Articles,
                Conferences = resumeViewModel.Conferences,
                Mentorships = resumeViewModel.Mentorships,
                Projects = resumeViewModel.Projects
            };
        }
    }
}