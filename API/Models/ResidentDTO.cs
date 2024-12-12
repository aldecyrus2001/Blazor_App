using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ResidentDTO
    {
        public int HouseholdID { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        public string First_name { get; set; } = "";

        public string? Middle_name { get; set; } = "";

        [Required(ErrorMessage = "Last Name is required!")]
        public string Last_name { get; set; } = "";

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Relationship to Head is required!")]
        public string Relation_to_head { get; set; } = "";

        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; } = "";

        [Required(ErrorMessage = "Birth Date is required!")]
        public DateOnly Birth_date { get; set; }

        [Required(ErrorMessage = "Is Head Of Household is required!")]
        public string Is_head_of_household { get; set; } = "";

        public string Is_deleted { get; set; } = "";

        public DateOnly? Date_inserted { get; set; }

        //Health Data
        [Required(ErrorMessage = "Has Disabilities is required!")]
        public string Has_disability { get; set; } = "";

        public string? Pre_existing_condition { get; set; } = "";

        [Required(ErrorMessage = "Covid Vaccinated is required!")]
        public string Covid_vaccinated { get; set; } = "";

        //Education Data
        [Required(ErrorMessage = "Highes Attainment is required!")]
        public string Highest_level_completed { get; set; } = "";

        [Required(ErrorMessage = "School Name is required!")]
        public string School_name { get; set; } = "";

        //Employment data
        [Required(ErrorMessage = "Employment is required!")]
        public string Employment_status { get; set; } = "";

        public string? Job_title { get; set; } = "";

        [Required(ErrorMessage = "Monthly Income is required!")]
        public int Monthly_income { get; set; }
    }
}
