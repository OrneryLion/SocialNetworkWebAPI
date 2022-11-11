namespace SocialNetworkWebAPI.Models
    {
    public class Response
        {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = String.Empty;
        public List<User>? listUser { get; set; }
        public User? User { get; set; }
        public List<Article>? listArticle { get; set; }
        public List<News>? listNews { get; set; }
        public List<Events>? listEvents { get; set; }
        public List<Staff>? listStaff { get; set; }

        }
    }
