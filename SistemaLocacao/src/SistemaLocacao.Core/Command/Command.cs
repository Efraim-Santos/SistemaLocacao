using FluentValidation.Results;
using MediatR;

namespace SistemaLocacao.Core.Command
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
