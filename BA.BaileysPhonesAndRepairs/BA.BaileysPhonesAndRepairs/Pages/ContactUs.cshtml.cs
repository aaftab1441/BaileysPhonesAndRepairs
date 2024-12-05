using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.BaileysPhonesAndRepairs.Adapters;
using BA.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using reCAPTCHA.AspNetCore;
using BA.BaileysPhonesAndRepairs.DataModels;

namespace BA.BaileysPhonesAndRepairs.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ISmtpService _smtpService;
        private readonly IRecaptchaService _recaptcha;

        [BindProperty]
        public ContactUsModel contactUsModel { get; set; }

        public ContactModel(IConfiguration config, ISmtpService stmpService, IRecaptchaService recaptcha)
        {
            _config = config;
            _smtpService = stmpService;
            _recaptcha = recaptcha;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                contactUsModel.Page = "Contact Us";
                contactUsModel.TemplateName = "Contact Us";
                RecaptchaResponse recaptcha = await _recaptcha.Validate(Request);
                if (!recaptcha.success)
                {
                    ModelState.AddModelError("Recaptcha", "There was an error validating the Recaptcha code.  Please try Again!");
                    return Page();
                }
                else
                {
                    ContactUsAdapter contactUs = new ContactUsAdapter(_config, _smtpService, contactUsModel);
                    await contactUs.CreateAndSendEmail();
                    return RedirectToPage("/ThankYou");
                }
            }
            else
            {
                return Page();
            }
        }
        public void OnGet()
        {

        }
    }
}