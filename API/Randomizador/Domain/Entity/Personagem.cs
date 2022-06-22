using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Randomizador.Domain.Entity
{
    [Table ("Personagens")]
    public class Personagem
    {
        [Key]
        public int IdPersonagem { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

    }
}
