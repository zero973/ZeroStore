using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZeroStore.Models;

namespace ZeroStore.Pages
{
    public class BProfileModel : PageModel
    {

        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ApplicationContext _context;

        public Account _Account;
        public string UserImage;
        public string FileName;

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

        public BProfileModel(IWebHostEnvironment environment, ApplicationContext db)
        {
            hostingEnvironment = environment;
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            _Account = await _context.Accounts.FindAsync(id);
            UserImage = _Account.Avatar;
            Id = (int)id;

            if (_Account == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _Account = await _context.Accounts.FindAsync(Id);
            _Account.Id = Id;
            if (!string.IsNullOrWhiteSpace(Login))
                _Account.Login = Login.ToUpper();
            if (!string.IsNullOrWhiteSpace(Password))
                _Account.Password = Password;
            if (!string.IsNullOrWhiteSpace(Nick))
                _Account.Nick = Nick;
            if (!string.IsNullOrWhiteSpace(Email))
                _Account.Email = Email;
            if(_Account.Avatar != Path.GetFileName(UploadedImage.FileName))
            {
                _Account.Avatar = GetUniqueName(UploadedImage.FileName);
                UploadedImage.CopyTo(new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "MyImages"), FileMode.Create));
            }
            UserImage = UploadedImage.FileName;

            _context.Attach(_Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!_context.Accounts.Any(e => e.Id == _Account.Id))
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

        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

    }
}
