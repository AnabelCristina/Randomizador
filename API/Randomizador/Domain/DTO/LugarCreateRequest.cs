using System;
using System.ComponentModel.DataAnnotations;

namespace Randomizador.Domain.DTO
{
    public class LugarCreateRequest
    {

        [Required(AllowEmptyStrings = false)]
        public string lugarPersonagem { get; set; }
    }
}
