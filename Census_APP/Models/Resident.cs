namespace Census_APP.Models
{
    public class Resident
    {
        public int residentID { get; set; }
        public int householdID { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string relation_to_head { get; set; }
        public string gender { get; set; }
        public DateOnly birth_date { get; set; }
        public string is_head_of_household { get; set; }
        public string is_deleted { get; set; }
        public DateOnly date_inserted { get; set; }

        //Health Data
        public string has_disability { get; set; }
        public string pre_existing_condition { get; set; }
        public string covid_vaccinated { get; set; }

        //Education Data
        public string highest_level_completed { get; set; }
        public string school_name { get; set; }

        //Employment data
        public string employment_status { get; set; }
        public string job_title { get; set; }
        public int monthly_income { get; set; }
    }
}
