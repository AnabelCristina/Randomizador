using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;
using Randomizador.DAL;


namespace Randomizador.Services
{
    public class ObjetosService
    {
        private readonly AppDbContext _dbContext;

        public ObjetosService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<Objeto> CadastrarNovo(ObjetoCreateRequest model)
        {

            var novoObjeto = new Objeto()
            {
                objeto = model.objeto,
            };

            _dbContext.Add(novoObjeto);
            _dbContext.SaveChanges();

            return new ServiceResponse<Objeto>(novoObjeto);
        }

        public List<Objeto> ListarTodos()
        {
            return _dbContext.Objetos.ToList();
        }

        public ServiceResponse<Objeto> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = _dbContext.Objetos.FirstOrDefault(x => x.IdObjeto == id);
            if (resultado == null)
                return new ServiceResponse<Objeto>("Não encontrado!");
            else
                return new ServiceResponse<Objeto>(resultado);

        }

        public ServiceResponse<Objeto> PesquisarPorNome(string Objeto)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id Objeto);
            var resultado = _dbContext.Objetos.FirstOrDefault(x => x.objeto == Objeto);
            if (resultado == null)
                return new ServiceResponse<Objeto>("Não encontrado!");
            else
                return new ServiceResponse<Objeto>(resultado);
        }

        public ServiceResponse<Objeto> GerarObjetoAleatorio()
        {
            var resultado = _dbContext.Objetos.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<Objeto>("Não encontrado!");
            else
                return new ServiceResponse<Objeto>(resultado);

        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = _dbContext.Objetos.FirstOrDefault(x => x.IdObjeto == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            _dbContext.Objetos.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
    }
}

