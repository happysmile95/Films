using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class FilmViewModel
    {
        public long FilmId { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Producer")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "UserId")]
        public string UserId { get; set; }
        public bool Disabled { get; set; }

        public byte[] Image { get; set; }
    }
}
