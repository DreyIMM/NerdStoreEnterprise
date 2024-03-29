﻿using FluentValidation.Results;
using MediatR;
using System;


namespace NSE.Core.Messages
{
    public abstract class Comand : Message, IRequest<ValidationResult>    
    {
        public DateTime Timestamp { get; set; }

        public ValidationResult ValidationResult { get; set; }

        protected Comand()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }

    }
}
