using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class App
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Cost { get; set; }
        public string Link { get; set; }
        public string Preview { get; set; }
        public string Picture { get; set; }

        public App(int developerId, string name, string description, string genre, int cost, string link, string preview, string picture)
        {
            DeveloperId = developerId;
            Name = name;
            Description = description;
            Genre = genre;
            Cost = cost;
            Link = link;
            Preview = preview;
            Picture = picture;
        }

    }
}
