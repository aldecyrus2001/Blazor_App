using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Index ("email", IsUnique =true)]
    public class Administrator
    {
        public int adminID { get; set; }
        public string firstname { get; set; } = "";
        public string? middlename { get; set; } = "";
        public string lastname { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "";
        public string phone { get; set; } = "";
        public byte[]? profile_picture { get; set; }
        public DateTime? last_login { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? token { get; set; } = "";
        public string isDeleted { get; set; } = "";
    }
}
