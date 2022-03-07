using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPrueba.Models
{
    public partial class Area
    {
        public Area()
        {
            Empleado = new HashSet<Empleado>();
        }

        [Key]
        public int IdArea { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(2000)]
        public string Descripcion { get; set; }

        [InverseProperty("IdAreaNavigation")]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}