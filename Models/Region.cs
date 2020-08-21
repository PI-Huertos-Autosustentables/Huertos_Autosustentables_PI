﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Huertos_Autosustentables_PI.Models
{
    public class Region
    {
        //Propiedades
        [Key]
        public int IdRegiones { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombre de la Región : ")]
        [Required(ErrorMessage = "Este campo es obligarorio")]
        public string NombreRegiones { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Características : ")]
        [Required(ErrorMessage = "Este campo es obligario")]
        public string CaracterisitcasRegiones { get; set; }

        //Clave Foranea
        [ForeignKey("Clima")]
        [DisplayName("Clima : ")]
        public int IdClima { get; set; }
        public Clima FK_ { get; set; }

        public virtual ICollection<Cultivo> Cultivos { get; set; }
    }
}
