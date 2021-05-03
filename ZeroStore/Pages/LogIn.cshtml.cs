using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class LogInModel : PageModel
    {

        private readonly ApplicationContext _context;

        public LogInModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string login, string password)
        {
            List<Account> accounts = _context.Accounts.Where(x => x.Login.ToUpper() == login.ToUpper() && x.Password.ToUpper() == password.ToUpper()).ToList();
            List<Developer> developers = _context.Developers.Where(x => x.Login.ToUpper() == login.ToUpper() && x.Password.ToUpper() == password.ToUpper()).ToList();
            if (accounts.Any())
                return Redirect(Url.Page("BProfile", new { id = accounts[0].Id }));
            else if (developers.Any())
                return Redirect(Url.Page("DProfile", new { id = accounts[0].Id }));
            else
                return NotFound();
        }


    }
}
