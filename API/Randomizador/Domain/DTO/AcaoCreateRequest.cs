using System;
using System.ComponentModel.DataAnnotations;

namespace Randomizador.Domain.DTO
{
    public class AcaoCreateRequest
    {

        [Required(AllowEmptyStrings = false)]
        public string acaoPersonagem { get; set; }
    }
}
