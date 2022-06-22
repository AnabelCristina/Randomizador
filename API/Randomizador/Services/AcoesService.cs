using Randomizador.Domain.DTO;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Randomizador.Services.Base;

namespace Randomizador.Services
{
    public class AcoesService
    {
        private static List<Acao> listadeAcoes; // fake, só para aprendizado
        private static int proximoId = 1;
        //iniciar a lista de Personagens no construtor da classe
        public AcoesService()
        {

            if (listadeAcoes == null)
            {
                listadeAcoes = new List<Acao>();
                listadeAcoes.Add(new Acao()
                {
                    IdAcao = proximoId++,
                    acaoPersonagem = "cozinhando"
                });
                listadeAcoes.Add(new Acao()
                {
                    IdAcao = proximoId++,
                    acaoPersonagem = "correndo"
                });
                listadeAcoes.Add(new Acao()
                {
                    IdAcao = proximoId++,
                    acaoPersonagem = "comendo"
                });
                listadeAcoes.Add(new Acao()
                {
                    IdAcao = proximoId++,
                    acaoPersonagem = "desenhando"
                });
            }
        }

        public ServiceResponse<Acao> CadastrarNovo(AcaoCreateRequest model)
        {

            var novoAcao = new Acao()
            {
                IdAcao = proximoId++,
                acaoPersonagem = model.acaoPersonagem,
            };

            listadeAcoes.Add(novoAcao);

            return new ServiceResponse<Acao>(novoAcao);
        }

        public List<Acao> ListarTodos()
        {
            return listadeAcoes;
        }

        public ServiceResponse<Acao> PesquisarPorId(int id)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = listadeAcoes.Where(x => x.IdAcao == id).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Acao>("Não encontrado!");
            else
                return new ServiceResponse<Acao>(resultado);

        }

        public ServiceResponse<Acao> PesquisarPorNome(string Acao)
        {
            // Lambda Expression / Expressões lambda
            // Operação em conjunto de dados
            // select top 1 * from personagens x where x.IdPersonagem == id 
            var resultado = listadeAcoes.Where(x => x.acaoPersonagem == Acao).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Acao>("Não encontrado!");
            else
                return new ServiceResponse<Acao>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            // select top 1 * from albuns x where x.IdAlbum == id 
            var resultado = listadeAcoes.Where(x => x.IdAcao == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            //tudo certo, só atualizar
            listadeAcoes.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }
    }
}

