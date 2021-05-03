using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class Purchase
    {

        public int Id { get; set; }
        public int IdGood { get; set; }
        public int IdAccount { get; set; }
        public bool IsDLC { get; set; }

        public Purchase(int id, int idGood, int idAccount, bool isDLC)
        {
            Id = id;
            IdGood = idGood;
            IdAccount = idAccount;
            IsDLC = isDLC;
        }

    }
}
