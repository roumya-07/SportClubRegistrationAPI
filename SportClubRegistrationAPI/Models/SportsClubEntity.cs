using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubRegistrationAPI.Models
{
    public class SportsClubEntity
    {
        public int registration_id { get; set; } = 0;
        public string applicant_name { get; set; } = null;
        public string email_id { get; set; } = null;
        public string mobile_no { get; set; } = null;
        public string gender { get; set; } = null;
        public string dob { get; set; } = null;
        public string image_path { get; set; } = null;
        public int club_id { get; set; } = 0;
        public string Club_name { get; set; } = null;
        public int sports_id { get; set; } = 0;
        public string sports_name { get; set; } = null;
    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public class MailRequest
    {
        public string email_id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}