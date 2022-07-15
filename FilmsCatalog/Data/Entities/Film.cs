using FilmsCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Producer { get; set; }
        public byte[] Image { get; set; }
        public string ImageName { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
