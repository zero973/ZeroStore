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

        private readonly ILogger<AppModel> _logger;
        private readonly ApplicationContext _context;

        public App _App { get; set; }
        public List<DLC> DLCs { get; set; }
        public List<string> Comments { get; set; }
        public string DeveloperName;

        public AppModel(ILogger<AppModel> logger, ApplicationContext db)
        {
            _logger = logger;
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            _App = await _context.Apps.FindAsync(id);
            DeveloperName = _context.Developers.Find(_App.DeveloperId).Nick;
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

            if (_App == null)
                return NotFound();

            return Page();
        }
    }
}
