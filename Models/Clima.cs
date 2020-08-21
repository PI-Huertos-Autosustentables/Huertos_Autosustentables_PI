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
    
    public class Clima
    {
        //Propiedades
        [Key]
        [DisplayName("Clima : ")]
        public int IdClima { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Nombre del Clima : ")]
        [Required(ErrorMessage = "Este campo es obligarorio")]
        public string NombreClima { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Caraterísticas : ")]
        [Required(ErrorMessage = "Este campo es obligarorio")]
        public string CaracteristicasClima { get; set; }

        //Relacion
        public virtual ICollection<Region> Regiones { get; set; }
    }
}
