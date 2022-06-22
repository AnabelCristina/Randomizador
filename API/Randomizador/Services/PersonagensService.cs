using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;

namespace Randomizador.Services
{
    public class PersonagensService
    {
        private static List<Personagem> listadePersonagens; // fake, só para aprendizado
        private static int proximoId = 1;
        //iniciar a lista de Personagens no construtor da classe
        public PersonagensService()
        {

            if (listadePersonagens == null)
            {
                listadePersonagens = new List<Personagem>();
                listadePersonagens.Add(new Personagem()
                {
                    IdPersonagem = proximoId++,
                    Nome = "Killjoy"
                });
                listadePersonagens.Add(new Personagem()
                {
                    IdPersonagem = proximoId++,
                    Nome = "Viper"
                });
                listadePersonagens.Add(new Personagem()
                {
                    IdPersonagem = proximoId++,
                    Nome = "Guts"
                });
                listadePersonagens.Add(new Personagem()
                {
                    IdPersonagem = proximoId++,
                    Nome = "Anabel"
                });
            }
        }

        public ServiceResponse<Personagem> CadastrarNovo(PersonagemCreateRequest model)
        {

            var novoPersonagem = new Personagem()
            {
                IdPersonagem = proximoId++,
                Nome = model.Nome,
            };

            listadePersonagens.Add(novoPersonagem);

            return new ServiceResponse<Personagem>(novoPersonagem);
        }

        public List<Personagem> ListarTodos()
        {
            return listadePersonagens;
        }

        public ServiceResponse<Personagem> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = listadePersonagens.Where(x => x.IdPersonagem == id).FirstOrDefault();
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
            var resultado = listadePersonagens.Where(x => x.Nome == nome).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Personagem>("Não encontrado!");
            else
                return new ServiceResponse<Personagem>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = listadePersonagens.Where(x => x.IdPersonagem == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            //tudo certo, só atualizar
            listadePersonagens.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }
    }
}

