using System.ComponentModel.DataAnnotations;

namespace Census_APP.Models
{
    public class ResidentDTO
    {
        public int HouseholdID { get; set; }
        public string First_name { get; set; } = "";
        public string? Middle_name { get; set; } = "";
        public string Last_name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Relation_to_head { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateOnly Birth_date { get; set; }
        public string Is_head_of_household { get; set; } = "";
        public string Is_deleted { get; set; } = "";
        public DateOnly Date_inserted { get; set; }

        //Health Data
        public string Has_disability { get; set; } = "";
        public string? Pre_existing_condition { get; set; } = "";
        public string Covid_vaccinated { get; set; } = "";

        //Education Data
        public string Highest_level_completed { get; set; } = "";
        public string School_name { get; set; } = "";

        //Employment data
        public string Employment_status { get; set; } = "";
        public string? Job_title { get; set; } = "";
        public int Monthly_income { get; set; }
    }
}
