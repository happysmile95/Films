﻿using FilmsCatalog.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace FilmsCatalog.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}