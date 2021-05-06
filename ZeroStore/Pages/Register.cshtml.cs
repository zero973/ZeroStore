using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly ApplicationContext _context;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string AccType { get; set; }

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Nick { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public RegisterModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            ViewData["Message"] = null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            List<Account> accounts = _context.Accounts.Where(x => x.Login.ToUpper() == Login.ToUpper()).ToList();
            List<Developer> developers = _context.Developers.Where(x => x.Login.ToUpper() == Login.ToUpper()).ToList();
            if(accounts.Any() || developers.Any())
            {
                ViewData["Message"] = "User with same login already exists. Change login";
                return Page();
            }

            MemoryStream stream = new MemoryStream();
            UploadedImage.CopyTo(stream);
            
            if (AccType == "Разработчик")
            {
                if (ModelState.IsValid)
                {
                    _context.Developers.Add(new Developer(Login, Password, Nick, Email, stream.ToArray()));
                    await _context.SaveChangesAsync();
                    Developer developer = _context.Developers.Where(x => x.Login.ToUpper() == Login.ToUpper() && x.Password == Password).ToList()[0];
                    Response.Cookies.Append(Program.USER_TYPE, "1");
                    Response.Cookies.Append(Program.USER_ID, developer.Id + "");
                    return Redirect(Url.Page("DProfile", new { id = developer.Id }));
                }
            }
            else if (AccType == "Покупатель")
            {
                if (ModelState.IsValid)
                {
                    _context.Accounts.Add(new Account(Login, Password, Nick, Email, stream.ToArray()));
                    await _context.SaveChangesAsync();
                    Account account = _context.Accounts.Where(x => x.Login.ToUpper() == Login.ToUpper() && x.Password == Password).ToList()[0];
                    Response.Cookies.Append(Program.USER_TYPE, "0");
                    Response.Cookies.Append(Program.USER_ID, account.Id + "");
                    return Redirect(Url.Page("BProfile", new { id = account.Id }));
                }
            }
            return Page();
        }

    }
}
