﻿using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizador.Services.Base
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T objeto)
        {
            Sucesso = true;
            Mensagem = string.Empty;
            ObjetoRetorno = objeto;
        }

        public ServiceResponse(string mensagemDeErro)
        {
            Sucesso = false;
            Mensagem = mensagemDeErro;
            ObjetoRetorno = default;
        }

        public ServiceResponse(IQueryable<Acao> resultado)
        {
            Sucesso = true;
            Mensagem = String.Empty;
            Resultado = resultado;
        }

        public ServiceResponse(IQueryable<Lugar> resultado)
        {
            Sucesso = true;
            Mensagem = String.Empty;
            ResultadoL = resultado;
        }

        public ServiceResponse(IQueryable<Personagem> resultado)
        {
            Sucesso = true;
            Mensagem = String.Empty;
            ResultadoP = resultado;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public T ObjetoRetorno { get; private set; }
        public IQueryable<Acao> Resultado { get; }
        public IQueryable<Personagem> ResultadoP { get; }
        public IQueryable<Lugar> ResultadoL { get; }
    }
}