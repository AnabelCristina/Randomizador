using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;
using Randomizador.DAL;

namespace Randomizador.Services
{
    public class AcoesService
    {
        private readonly AppDbContext _dbContext;

        public AcoesService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<Acao> CadastrarNovo(AcaoCreateRequest model)
        {

            var novoAcao = new Acao()
            {
                acaoPersonagem = model.acaoPersonagem,
            };

            _dbContext.Add(novoAcao);
            _dbContext.SaveChanges();

            return new ServiceResponse<Acao>(novoAcao);
        }

        public List<Acao> ListarTodos()
        {
            return _dbContext.Acoes.ToList();
        }

        public ServiceResponse<Acao> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = _dbContext.Acoes.FirstOrDefault(x => x.IdAcao == id);
            if (resultado == null)
                return new ServiceResponse<Acao>("Não encontrado!");
            else
                return new ServiceResponse<Acao>(resultado);

        }

        public ServiceResponse<Acao> PesquisarPorNome(string Acao)
        {
            var resultado = _dbContext.Acoes.FirstOrDefault(x => x.acaoPersonagem == Acao);
            if (resultado == null)
                return new ServiceResponse<Acao>("Não encontrado!");
            else
                return new ServiceResponse<Acao>(resultado);
        }

        public ServiceResponse<Acao> GerarAcaoAleatorio()
        {
            var resultado = _dbContext.Acoes.OrderBy(x => Guid.NewGuid()).Take(1);

            if (resultado == null)
                return new ServiceResponse<Acao>("Não encontrado!");
            else
                return new ServiceResponse<Acao>(resultado);

        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = _dbContext.Acoes.FirstOrDefault(x => x.IdAcao == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            _dbContext.Acoes.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
    }
}

