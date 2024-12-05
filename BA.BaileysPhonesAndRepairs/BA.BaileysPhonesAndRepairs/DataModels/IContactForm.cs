using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.BaileysPhonesAndRepairs.DataModels
{
    public interface IContactForm
    {
        string Name { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Page { get; set; }
        List<IFormFile> Attachments { get; set; }
    }
}
