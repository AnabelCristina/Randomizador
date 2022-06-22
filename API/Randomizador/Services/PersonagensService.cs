using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;
using Randomizador.DAL;

namespace Randomizador.Services
{
    public class PersonagensService
    {
        private readonly AppDbContext _dbContext;

        public PersonagensService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<Personagem> CadastrarNovo(PersonagemCreateRequest model)
        {

            var novoPersonagem = new Personagem()
            {
                Nome = model.Nome,
            };

            _dbContext.Add(novoPersonagem);
            _dbContext.SaveChanges();

            return new ServiceResponse<Personagem>(novoPersonagem);
        }

        public List<Personagem> ListarTodos()
        {
            return _dbContext.Personagens.ToList();
        }

        public ServiceResponse<Personagem> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = _dbContext.Personagens.FirstOrDefault(x => x.IdPersonagem == id);
            if (resultado == null)
                return new ServiceResponse<Personagem>("Não encontrado!");
            else
                return new ServiceResponse<Personagem>(resultado);

        }

        public ServiceResponse<Personagem> GerarPersonagemAleatorio()
        {
            var resultado = _dbContext.Personagens.OrderBy(x => Guid.NewGuid()).Take(1);

            if (resultado == null)
                return new ServiceResponse<Personagem>("Não encontrado!");
            else
                return new ServiceResponse<Personagem>(resultado);

        }

        public ServiceResponse<Personagem> PesquisarPorNome(string nome)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = _dbContext.Personagens.FirstOrDefault(x => x.Nome == nome);
            if (resultado == null)
                return new ServiceResponse<Personagem>("Não encontrado!");
            else
                return new ServiceResponse<Personagem>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = _dbContext.Personagens.FirstOrDefault(x => x.IdPersonagem == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            _dbContext.Personagens.Remove(resultado);
            _dbContext.SaveChanges(); ;

            return new ServiceResponse<bool>(true);
        }
    }
}

