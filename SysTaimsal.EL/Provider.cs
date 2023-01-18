﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public  partial class Provider
    { 
        [Key]
        public int IdProvider { get; set; }
      
        [Required(ErrorMessage ="Nombre es obligatorio")]
        [StringLength(40, ErrorMessage ="Maximo 40 caracteres")]
        [Display(Name = "Nombre de producto")]
        public string? NameProvider { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public virtual Machine? Machine { get; set; }
        [ForeignKey("IdReport")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
