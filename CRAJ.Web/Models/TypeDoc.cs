﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class TypeDoc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }

    }
}
