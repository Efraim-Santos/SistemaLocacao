using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLocacao.Core.Model
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        //public EntityBase()
        //    => Id = new int();

        public virtual bool EhValido()
            => throw new NotImplementedException();
    }
}
