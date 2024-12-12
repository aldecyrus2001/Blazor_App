using System.ComponentModel.DataAnnotations;

namespace Census_APP.Models
{
    public class HouseholdDTO
    {
        public string family_Name { get; set; } = "";

        public string address { get; set; } = "";

        public int income { get; set; }
        
        public string email { get; set; } = "";

        public string phone { get; set; } = "";

        public string house_Type { get; set; } = "";

        public string ownership { get; set; } = "";

        public string profile_Picture { get; set; } = "";

        public DateTime? survey_Date { get; set; }

        public string survey_By { get; set; } = "";

        public string note { get; set; } = "";

        public string ethnicity { get; set; } = "";

        public string religion { get; set; } = "";

        public string primary_Language { get; set; } = "";

        public string secondary_Language { get; set; } = "";

        public string has_Electricity { get; set; } = "";

        public string has_Water { get; set; } = "";
    }
}
