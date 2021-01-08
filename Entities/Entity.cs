using System;

namespace efcore5_tpt.Entities
{
    public abstract class Entity
    {
        public Entity() { }

        public long Id { get; private set; }

        public DateTime DataCriacao
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        protected internal DateTime? dateCreated = null;

        public DateTime? DataUltimaAtualizacao { get; set; }
    }
}
