using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.KitchenApp
{
    public class GetAllDishesQuery: IRequest<IEnumerable<Dish>> {}

    public class GetAllDishesHandler : IRequestHandler<GetAllDishesQuery, IEnumerable<Dish>>
    {
        private readonly IRetrieve<Guid, Dish> _repo;

        public GetAllDishesHandler(IRetrieve<Guid, Dish> repo) => _repo = repo;

        public Task<IEnumerable<Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken) => Task.FromResult(_repo.RetrieveMany());
    }
}