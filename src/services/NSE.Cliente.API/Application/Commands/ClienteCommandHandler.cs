﻿using FluentValidation.Results;
using MediatR;
using NSE.Cliente.API.Models;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>

    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Clientes(message.Id, message.Nome, message.Email, message.Cpf);

            //validacoes de negocio

            //Persistir no banco
            if (true) //Já existe um cliente com o CPF informado
            {
                AdicionarErro("Esse CPF já está sendo utilizado");
                return ValidationResult;                    
            }

            return message.ValidationResult;

        }
    }
}
