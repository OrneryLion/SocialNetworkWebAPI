namespace SocialNetworkWebAPI.Models
    {
    public class User
        {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string PhoneNo { get; set; } = String.Empty;
        public string UserType { get; set; }= String.Empty;
        public int IsActive { get; set; }
        public int IsApproved { get; set; }


        }
    }
