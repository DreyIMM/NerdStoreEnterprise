﻿using NSE.Core.DomainObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSE.Cliente.API.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; private set; }

        //EF Relation
        public Clientes Cliente { get; private set; }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }

}
