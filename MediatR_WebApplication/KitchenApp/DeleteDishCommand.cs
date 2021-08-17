using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.KitchenApp
{
    public record DeleteDishCommand(string Id) : IRequest;

    public class DeleteDishHandler : AsyncRequestHandler<DeleteDishCommand>
    {
        private readonly IDelete<Guid> _repo;

        public DeleteDishHandler(IDelete<Guid> repo) => _repo = repo;

        protected override Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            _repo.Delete(Guid.Parse(request.Id));
            return Task.CompletedTask;
        }
    }
}