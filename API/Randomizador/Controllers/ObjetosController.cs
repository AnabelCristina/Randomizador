using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Randomizador.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;

namespace Randomizador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetosController : ControllerBase
    {
        private readonly ObjetosService ObjetosService;

        public ObjetosController(ObjetosService ObjetosService)
        {
            this.ObjetosService = ObjetosService;
        }

        [HttpGet]
        public IEnumerable<Objeto> Get()
        {
            return ObjetosService.ListarTodos();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = ObjetosService.PesquisarPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
        [HttpGet("nome/{nomeParam}")]
        public IActionResult GetByNome(string nomeParam) // nome do parametro deve ser o mesmo do {}
        {
            var retorno = ObjetosService.PesquisarPorNome(nomeParam);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpPost]
        // FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
        public IActionResult Post([FromBody] ObjetoCreateRequest postModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retorno = ObjetosService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                else
                    return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        // FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
        public IActionResult Delete(int id)
        {
            //Validação modelo de entrada
            var retorno = ObjetosService.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();

        }

        [HttpGet("IdObjetosAleatorio")]
        public IActionResult GetRandom() // nome do parametro deve ser o mesmo do {}
        {
            var retorno = ObjetosService.GerarObjetoAleatorio();

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
    }
}
