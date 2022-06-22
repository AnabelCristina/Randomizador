using System;
using System.ComponentModel.DataAnnotations;

namespace Randomizador.Domain.DTO
{
    public class ObjetoCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string objeto { get; set; }

    }
}
