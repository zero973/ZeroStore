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
    public class PrivacyModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;
        private readonly ApplicationContext _context;

        public List<Developer> Developers { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, ApplicationContext db)
        {
            _logger = logger;
            _context = db;
        }

        public void OnGet()
        {
            Developers = _context.Developers.AsNoTracking().ToList();
        }

        public string GetImage(byte[] mass)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(mass)}";
        }

        public int GetCountOfApps(int dev_id)
        {
            return _context.Apps.Count(x => x.DeveloperId == dev_id);
        }

    }
}
