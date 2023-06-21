using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }


        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        private List<Event> _notificacoes;

        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

        #region Comparações
        public override bool Equals(object obj)
        {
            var compareTO = obj as Entity;

            if (ReferenceEquals(this, compareTO)) return true;
            if (ReferenceEquals(null, compareTO)) return false;

            return Id.Equals(compareTO.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion 


    }
}
