using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.KitchenApp
{
    public record UpdateDishCommand(Dish Dish) : IRequest;

    public class UpdateDishHandler : AsyncRequestHandler<UpdateDishCommand>
    {
        private readonly IUpdate<Dish> _repo;

        public UpdateDishHandler(IUpdate<Dish> repo) => _repo = repo;

        protected override Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            _repo.Update(request.Dish);
            return Task.CompletedTask;
        }
    }
}