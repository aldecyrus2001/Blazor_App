namespace Census_APP.Models
{
    public class Household
    {
        public int HouseholdID { get; set; }
        public string Family_Name { get; set; }
        public string Address { get; set; }
        public int Income { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string House_Type { get; set; }
        public string Ownership { get; set; }
        public string Profile_Picture { get; set; }
        public DateTime Survey_Date { get; set; }
        public string Survey_By { get; set; }
        public string Note { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }
        public string Primary_Language { get; set; }
        public string Secondary_Language { get; set; }
        public string Has_Electricity { get; set; }
        public string Has_Water { get; set; }
    }
}
