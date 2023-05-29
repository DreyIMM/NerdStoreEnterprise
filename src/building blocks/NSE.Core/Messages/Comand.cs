using FluentValidation.Results;
using System;


namespace NSE.Core.Messages
{
    public abstract class Comand : Message
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
