using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;

namespace Randomizador.Services
{
    public class LugaresService
    {
        private static List<Lugar> listadeLugares; // fake, só para aprendizado
        private static int proximoId = 1;
        //iniciar a lista de Personagens no construtor da classe
        public LugaresService()
        {

            if (listadeLugares == null)
            {
                listadeLugares = new List<Lugar>();
                listadeLugares.Add(new Lugar()
                {
                    IdLugar = proximoId++,
                    lugarPersonagem = "Cristo Redentor"
                });
                listadeLugares.Add(new Lugar()
                {
                    IdLugar = proximoId++,
                    lugarPersonagem = "Avenida Paulista"
                });
                listadeLugares.Add(new Lugar()
                {
                    IdLugar = proximoId++,
                    lugarPersonagem = "Macchu Picchu"
                });
                listadeLugares.Add(new Lugar()
                {
                    IdLugar = proximoId++,
                    lugarPersonagem = "Seoul"
                });
            }
        }

        public ServiceResponse<Lugar> CadastrarNovo(LugarCreateRequest model)
        {

            var novoLugar = new Lugar()
            {
                IdLugar = proximoId++,
                lugarPersonagem = model.lugarPersonagem,
            };

            listadeLugares.Add(novoLugar);

            return new ServiceResponse<Lugar>(novoLugar);
        }

        public List<Lugar> ListarTodos()
        {
            return listadeLugares;
        }

        public ServiceResponse<Lugar> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = listadeLugares.Where(x => x.IdLugar == id).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Lugar>("Não encontrado!");
            else
                return new ServiceResponse<Lugar>(resultado);

        }

        public ServiceResponse<Lugar> PesquisarPorNome(string lugar)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = listadeLugares.Where(x => x.lugarPersonagem == lugar).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Lugar>("Não encontrado!");
            else
                return new ServiceResponse<Lugar>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = listadeLugares.Where(x => x.IdLugar == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            //tudo certo, só atualizar
            listadeLugares.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }
    }
}

