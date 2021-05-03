using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationContext _context;

        public List<App> Apps { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationContext db)
        {
            _logger = logger;
            _context = db;
        }

        public void OnGet()
        {
            Apps = _context.Apps.AsNoTracking().ToList();
        }

        public void OnPost(string Search)
        {
            var a = Request.Form["SearchType"];
            if (Search == null)
                Search = string.Empty;
            if(a == "Название")
                Apps = _context.Apps.Where(x => x.Name.Contains(Search)).ToList();
            else
                Apps = _context.Apps.Where(x => x.Genre.Contains(Search)).ToList();
        }

    }
}
