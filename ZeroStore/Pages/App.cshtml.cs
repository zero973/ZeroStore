using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class AppModel : PageModel
    {

        private readonly ApplicationContext _context;

        public MyApp _App { get; set; }
        public List<DLC> DLCs { get; set; }
        public List<string> Comments { get; set; }
        public Developer _Developer;

        public bool IsCanBuyGood, IsAppBought;

        public AppModel(ApplicationContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_context.Apps.Where(x => x.Id == id).Any())
                return NotFound();

            IsCanBuyGood = IsAppBought = false;
            _App = await _context.Apps.FindAsync(id);
            _Developer = _context.Developers.Where(x => x.Id == _App.DeveloperId).FirstOrDefault();
            DLCs = _context.DLCs.Where(x => x.IdApp == _App.Id).ToList();
            var comments = _context.Comments.Where(x => x.AppId == _App.Id).ToList();
            Comments = new List<string>();
            foreach (var c in comments)
            {
                string s = "";
                if(c.IsDeveloper)
                    s = $"{c.Id}. {_context.Accounts.Find(c.UserId).Nick} #разработчик {c.Date} Ответ на: {c.AnsweredTo} Текст: {c.Text}";
                else
                    s = $"{c.Id}. {_context.Accounts.Find(c.UserId).Nick} {c.Date} Текст: {c.Text}";
                Comments.Add(s);
            }

            if(Request.Cookies.ContainsKey(Program.USER_TYPE) && Request.Cookies.ContainsKey(Program.USER_ID))
                if(Request.Cookies[Program.USER_TYPE] == "0")
                    IsCanBuyGood = true;
            if (_context.Purchases.Any(x => x.IdGood == _App.Id && x.IsDLC == false && x.IdAccount == Convert.ToInt32(Request.Cookies[Program.USER_ID])))
                IsAppBought = true;
            return Page();
        }

        public IActionResult OnPost(int? good_id, int? type)
        {
            if(type == 0)
                return Redirect(Url.Page("BuyGood", new { good_id = good_id, type = 0 }));
            else
                return Redirect(Url.Page("BuyGood", new { good_id = good_id, type = 1 }));
        }

        public string GetImage(byte[] mass)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(mass)}";
        }

    }
}
