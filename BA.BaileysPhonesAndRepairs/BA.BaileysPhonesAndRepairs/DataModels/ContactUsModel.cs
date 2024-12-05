using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.BaileysPhonesAndRepairs.Adapters;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BA.BaileysPhonesAndRepairs.DataModels
{
    public class ContactUsModel : IContactForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Referral { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Comments { get; set; }
        public string Page { get; set; }
        public string TemplateName { get; set; }
    }
}
