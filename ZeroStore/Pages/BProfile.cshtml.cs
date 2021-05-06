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

        private readonly ApplicationContext _context;

        public Account _Account;
        public string UserImage;

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

        public BProfileModel(ApplicationContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            _Account = await _context.Accounts.FindAsync(id);
            if(_Account == null)
                return NotFound();

            IsCanChangeData = false;
            UserImage = GetImage(_Account.Avatar);
            Id = (int)id;

            if (Request.Cookies.ContainsKey(Program.USER_TYPE) && Request.Cookies.ContainsKey(Program.USER_ID))
                if(Request.Cookies[Program.USER_TYPE] == "0" && Request.Cookies[Program.USER_ID] == id+"")
                    IsCanChangeData = true;

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
            using(var stream = new MemoryStream())
            {
                UploadedImage.CopyTo(stream);
                _Account.Avatar = stream.ToArray();
            }

            UserImage = GetImage(_Account.Avatar);

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

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Account account = await _context.Accounts.FindAsync(id);
            if(account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }

            Response.Cookies.Delete(Program.USER_TYPE);
            Response.Cookies.Delete(Program.USER_ID);

            return Redirect(Url.Page("Index"));
        }

        private string GetImage(byte[] mass)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(mass)}";
        }

    }
}