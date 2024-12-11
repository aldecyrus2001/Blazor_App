using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AdministratorDTO
    {
        [Required(ErrorMessage = "Firstname is required!")]
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Lastname is required!")]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Strong Password is required!")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Job Position/Role is required!")]
        public string Role { get; set; } = "";

        [Phone]
        public string Phone { get; set; }= "";
        [Required(ErrorMessage = "Profile Image is required!")]
        public byte[]? Profile_Picture { get; set; }
        public DateTime? Last_Login { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public string Token { get; set; } = "";
        public string isDeleted { get; set; } = "";

    }
}
