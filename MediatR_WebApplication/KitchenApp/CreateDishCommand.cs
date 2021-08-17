using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.KitchenApp
{
    public record CreateDishCommand(string Name) : IRequest;

    public class CreateDishHandler : AsyncRequestHandler<CreateDishCommand>
    {
        private readonly ICreate<Dish> _repo;

        public CreateDishHandler(ICreate<Dish> repo) => _repo = repo;

        protected override Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var item = new Dish(request.Name);
            _repo.Create(item);
            return Task.CompletedTask;
        }
    }
}