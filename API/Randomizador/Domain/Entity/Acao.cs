using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Randomizador.Domain.Entity
{
    [Table("Acao")]
    public class Acao
    {
        [Key]
        public int IdAcao { get; set; }

        [Required]
        [StringLength(255)]
        public string? acaoPersonagem { get; set; }
    }
}
