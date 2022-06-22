using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;
using Randomizador.DAL;

namespace Randomizador.Services
{
    public class LugaresService
    {
        private readonly AppDbContext _dbContext;

        public LugaresService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<Lugar> CadastrarNovo(LugarCreateRequest model)
        {

            var novoLugar = new Lugar()
            {
                lugarPersonagem = model.lugarPersonagem,
            };

            _dbContext.Add(novoLugar);
            _dbContext.SaveChanges();

            return new ServiceResponse<Lugar>(novoLugar);
        }

        public List<Lugar> ListarTodos()
        {
            return _dbContext.Lugares.ToList();
        }

        public ServiceResponse<Lugar> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = _dbContext.Lugares.FirstOrDefault(x => x.IdLugar == id);
            if (resultado == null)
                return new ServiceResponse<Lugar>("Não encontrado!");
            else
                return new ServiceResponse<Lugar>(resultado);

        }

        public ServiceResponse<Lugar> PesquisarPorNome(string lugar)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id lugar);
            var resultado = _dbContext.Lugares.FirstOrDefault(x => x.lugarPersonagem == lugar);
            if (resultado == null)
                return new ServiceResponse<Lugar>("Não encontrado!");
            else
                return new ServiceResponse<Lugar>(resultado);
        }

        public ServiceResponse<Lugar> GerarLugarAleatorio()
        {
            var resultado = _dbContext.Lugares.OrderBy(x => Guid.NewGuid()).Take(1);

            if (resultado == null)
                return new ServiceResponse<Lugar>("Não encontrado!");
            else
                return new ServiceResponse<Lugar>(resultado);

        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = _dbContext.Lugares.FirstOrDefault(x => x.IdLugar == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            _dbContext.Lugares.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
    }
}

