using System;
using System.ComponentModel.DataAnnotations;

namespace Randomizador.Domain.DTO
{
    public class PersonagemCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        //int? e Required????
        //Sem isso este erro nunca vai acontecer.
        //Com um int normal, o valor padrão vai sempre ser 0
        //e nunca vamos saber se é o valor passado ou o padrão
    }
}
