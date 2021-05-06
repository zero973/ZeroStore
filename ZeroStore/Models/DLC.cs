using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class DLC: IGood
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdApp { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public DLC(int idApp, string name, int cost)
        {
            IdApp = idApp;
            Name = name;
            Cost = cost;
        }

    }
}
