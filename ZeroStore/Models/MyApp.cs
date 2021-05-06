using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroStore.Models
{
    public class MyApp: IGood
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Cost { get; set; }
        public string Link { get; set; }
        public byte[] Preview { get; set; }
        public byte[] Picture { get; set; }

        public MyApp(int developerId, string name, string description, string genre, int cost, string link, string preview, string picture)
        {
            DeveloperId = developerId;
            Name = name;
            Description = description;
            Genre = genre;
            Cost = cost;
            Link = link;
            Preview = ToByteArray(new System.Drawing.Bitmap(preview));
            Picture = ToByteArray(new System.Drawing.Bitmap(picture));
        }

        public MyApp(int developerId, string name, string description, string genre, int cost, string link, byte[] preview, byte[] picture)
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

        private static byte[] ToByteArray(System.Drawing.Image img)
        {
            if (img == null)
                return new byte[0];
            using (var ms = new System.IO.MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

    }
}
