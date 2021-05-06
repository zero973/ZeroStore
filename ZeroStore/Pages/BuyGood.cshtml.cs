using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class BuyGoodModel : PageModel
    {

        private readonly ApplicationContext _context;

        public IGood Good;
        public string GoodImage;
        public int GoodType;

        public BuyGoodModel(ApplicationContext db)
        {
            _context = db;
        }

        public IActionResult OnGet(int good_id, int type)
        {
            bool isDlc = type == 0 ? false : true;
            if(_context.Purchases.Any(x => x.IdGood == good_id && x.IsDLC == isDlc && x.IdAccount == Convert.ToInt32(Request.Cookies[Program.USER_ID])))
                return RedirectToPage("App", new { id = good_id });
            LoadData(good_id, type);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int good_id, int type)
        {
            if (type == 0)
                _context.Purchases.Add(new Purchase(good_id, Convert.ToInt32(Request.Cookies[Program.USER_ID]), false));
            else
                _context.Purchases.Add(new Purchase(good_id, Convert.ToInt32(Request.Cookies[Program.USER_ID]), true));

            if (ModelState.IsValid)
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

        private void LoadData(int good_id, int type)
        {
            if (type == 0)
            {
                MyApp app = _context.Apps.Where(x => x.Id == good_id).FirstOrDefault();
                Good = app;
                GoodType = 0;
                GoodImage = GetImage(app.Picture);
            }
            else
            {
                Good = _context.DLCs.Where(x => x.Id == good_id).FirstOrDefault();
                GoodType = 1;
                MemoryStream stream = new MemoryStream();
                Image img = new Bitmap(Path.Combine("wwwroot", "MyImages", "no_image.png"));
                img.Save(stream, img.RawFormat);
                GoodImage = GetImage(stream.ToArray());
            }
        }

        public string GetImage(byte[] mass)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(mass)}";
        }

    }
}
