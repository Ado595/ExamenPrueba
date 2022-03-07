using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPrueba.Models
{
    public partial class Empleado_Habilidad
    {
        [Key]
        public int IdHabilidad { get; set; }
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreHabilidad { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Empleado_Habilidad))]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}