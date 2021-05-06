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

        public IActionResult OnGet()
        {
            if (Request.Cookies.ContainsKey(Program.USER_TYPE) && Request.Cookies.ContainsKey(Program.USER_ID))
            {
                if (Request.Cookies[Program.USER_TYPE] == "0")
                    return Redirect(Url.Page("BProfile", new { id = Convert.ToInt32(Request.Cookies[Program.USER_ID]) }));
                else if(Request.Cookies[Program.USER_TYPE] == "1")
                    return Redirect(Url.Page("DProfile", new { id = Convert.ToInt32(Request.Cookies[Program.USER_ID]) }));
            }
            return Page();
        }

        public IActionResult OnPost(string login, string password)
        {
            List<Account> accounts = _context.Accounts.Where(x => x.Login.ToUpper() == login.ToUpper() && x.Password == password).ToList();
            List<Developer> developers = _context.Developers.Where(x => x.Login.ToUpper() == login.ToUpper() && x.Password == password).ToList();
            if (accounts.Any())
            {
                Response.Cookies.Append(Program.USER_TYPE, "0");
                Response.Cookies.Append(Program.USER_ID, accounts[0].Id + "");
                return Redirect(Url.Page("BProfile", new { id = accounts[0].Id }));
            }
            else if (developers.Any())
            {
                Response.Cookies.Append(Program.USER_TYPE, "1");
                Response.Cookies.Append(Program.USER_ID, developers[0].Id + "");
                return Redirect(Url.Page("DProfile", new { id = developers[0].Id }));
            }
            else
                return NotFound();
        }


    }
}
