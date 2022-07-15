using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class FilmsPageViewModel
    {
        public bool Enabled { get; set; } = false;
        public IEnumerable<FilmViewModel> Films { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
