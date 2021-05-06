using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class Purchase
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdGood { get; set; }
        public int IdAccount { get; set; }
        public bool IsDLC { get; set; }

        public Purchase(int idGood, int idAccount, bool isDLC)
        {
            IdGood = idGood;
            IdAccount = idAccount;
            IsDLC = isDLC;
        }

    }
}
