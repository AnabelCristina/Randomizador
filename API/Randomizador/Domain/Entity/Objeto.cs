using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Randomizador.Domain.Entity
{
    [Table("Objeto")]
    public class Objeto
    {
        [Key]
        public int IdObjeto { get; set; }

        [Required]
        [StringLength(255)]
        public string? objeto { get; set; }
    }
}
