﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Huertos_Autosustentables_PI.Models
{
    public class TipoCultivo
    {
        //Propiedades
        [Key]
        public int IdTipoCultivo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Tipo de Cultivo : ")]
        [Required(ErrorMessage = "Este campo es obligarorio")]
        public string NombreTipoCultivos { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Características : ")]
        public string CaracteristicasTipoCultivos { get; set; }

        //Relacion
        public virtual ICollection<Cultivo> Cultivos { get; set; }
    }
}