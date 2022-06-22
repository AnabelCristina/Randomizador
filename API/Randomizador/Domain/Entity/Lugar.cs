using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Randomizador.Domain.Entity
{
    [Table("Lugares")]
    public class Lugar
    {
        [Key]
        public int IdLugar { get; set; }

        [Required]
        [StringLength(255)]
        public string? lugarPersonagem { get; set; }
    }
}
