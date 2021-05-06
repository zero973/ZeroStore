using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public interface IGood
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

    }
}
