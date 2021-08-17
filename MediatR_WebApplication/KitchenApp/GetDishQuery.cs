using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.KitchenApp
{
    public record GetDishQuery(string Id) : IRequest<Dish>;

    public class GetDishHandler : IRequestHandler<GetDishQuery, Dish>
    {
        private readonly IRetrieve<Guid, Dish> _repo;
        public GetDishHandler(IRetrieve<Guid, Dish> repo) => _repo = repo;
        public Task<Dish> Handle(GetDishQuery request, CancellationToken cancellationToken) => Task.FromResult(_repo.Retrieve(Guid.Parse(request.Id)));
    }
}
