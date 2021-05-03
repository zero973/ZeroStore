using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class Developer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public Developer(string login, string password, string nick, string email, string avatar)
        {
            Login = login;
            Password = password;
            Nick = nick;
            Email = email;
            Avatar = avatar;
        }

        public Developer(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
            Nick = login;
            Avatar = null;
        }

    }
}
