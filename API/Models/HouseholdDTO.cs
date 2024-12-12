using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class HouseholdDTO
    {
        [Required(ErrorMessage = "Family Name is required!")]
        public string family_Name { get; set; } = "";

        [Required(ErrorMessage = "Address is required!")]
        public string address { get; set; } = "";

        [Required(ErrorMessage = "Income is required!")]
        public int income { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string email { get; set; } = "";

        [Required(ErrorMessage = "Phone is required!")]
        public string phone { get; set; } = "";

        [Required(ErrorMessage = "House Type is required!")]
        public string house_Type { get; set; } = "";

        [Required(ErrorMessage = "Ownership is required!")]
        public string ownership { get; set; } = "";

        public byte[]? profile_Picture { get; set; }

        public DateTime? survey_Date { get; set; }

        public string survey_By { get; set; } = "";

        [Required(ErrorMessage = "Note is required!")]
        public string note { get; set; } = "";

        [Required(ErrorMessage = "Ethnicity is required!")]
        public string ethnicity { get; set; } = "";

        [Required(ErrorMessage = "Religion is required!")]
        public string religion { get; set; } = "";

        [Required(ErrorMessage = "Primary Language is required!")]
        public string primary_Language { get; set; } = "";

        [Required(ErrorMessage = "Secondary Language is required!")]
        public string secondary_Language { get; set; } = "";

        [Required(ErrorMessage = "Has Electricity is required!")]
        public string has_Electricity { get; set; } = "";

        [Required(ErrorMessage = "Has Water is required!")]
        public string has_Water { get; set; } = "";
    }
}
