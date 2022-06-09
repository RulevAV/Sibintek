﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibintek.Domain.Entities
{
    public class UserFile: BaseEntities
    {
        [Required]
        [Display(Name = "Хэш")]
        public string hash { get; set; }

        [Display(Name = "Файл")]
        public string file { get; set; }

        [Display(Name = "Отправитель")]
        public string sender { get; set; }
    }
}