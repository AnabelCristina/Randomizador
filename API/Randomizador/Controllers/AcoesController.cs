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
    public class AcoesController : ControllerBase
    {
        private readonly AcoesService AcoesService;

        public AcoesController(AcoesService AcoesService)
        {
            this.AcoesService = AcoesService;
        }

        [HttpGet]
        public IEnumerable<Acao> Get()
        {
            return AcoesService.ListarTodos();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = AcoesService.PesquisarPorId(id);

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
            var retorno = AcoesService.PesquisarPorNome(nomeParam);

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
        public IActionResult Post([FromBody] AcaoCreateRequest postModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retorno = AcoesService.CadastrarNovo(postModel);
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
            var retorno = AcoesService.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();

        }

        [HttpGet("IdAcoesAleatorio")]
        public IActionResult GetRandom() // nome do parametro deve ser o mesmo do {}
        {
            var retorno = AcoesService.GerarAcaoAleatorio();

            if (retorno.Sucesso)
            {
                return Ok(retorno.Resultado);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
    }
}
