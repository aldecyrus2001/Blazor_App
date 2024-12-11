using System.ComponentModel.DataAnnotations;

namespace Census_APP.Models
{
    public class AdministratorDTO
    {
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string Role { get; set; } = "";

        public string Phone { get; set; } = "";
        public string Profile_Picture { get; set; } = "";
        public DateTime? Last_Login { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public string Token { get; set; } = "";
        public string isDeleted { get; set; } = "";
    }
}
