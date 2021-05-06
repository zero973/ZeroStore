using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class DProfileModel : PageModel
    {

        private readonly ApplicationContext _context;

        public Developer _Developer;
        public string UserImage;
        public List<MyApp> Apps;

        public bool IsCanChangeData;

        [BindProperty]
        public int Id { get; set; }

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

        public DProfileModel(ApplicationContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            _Developer = await _context.Developers.FindAsync(id);
            if (_Developer == null)
                return NotFound();

            IsCanChangeData = false;
            UserImage = GetImage(_Developer.Avatar);
            Id = (int)id;
            Apps = _context.Apps.Where(x => x.DeveloperId == id).ToList();

            if (Request.Cookies.ContainsKey(Program.USER_TYPE) && Request.Cookies.ContainsKey(Program.USER_ID))
                if (Request.Cookies[Program.USER_TYPE] == "1" && Request.Cookies[Program.USER_ID] == id + "")
                    IsCanChangeData = true;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Apps = _context.Apps.Where(x => x.DeveloperId == Id).ToList();
            _Developer = await _context.Developers.FindAsync(Id);
            _Developer.Id = Id;
            if (!string.IsNullOrWhiteSpace(Login))
                _Developer.Login = Login.ToUpper();
            if (!string.IsNullOrWhiteSpace(Password))
                _Developer.Password = Password;
            if (!string.IsNullOrWhiteSpace(Nick))
                _Developer.Nick = Nick;
            if (!string.IsNullOrWhiteSpace(Email))
                _Developer.Email = Email;
            using (var stream = new MemoryStream())
            {
                UploadedImage.CopyTo(stream);
                _Developer.Avatar = stream.ToArray();
            }

            UserImage = GetImage(_Developer.Avatar);

            _context.Attach(_Developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!_context.Accounts.Any(e => e.Id == _Developer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Developer developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }

            Response.Cookies.Delete(Program.USER_TYPE);
            Response.Cookies.Delete(Program.USER_ID);

            return Redirect(Url.Page("Index"));
        }

        public string GetImage(byte[] mass)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(mass)}";
        }

    }
}
