using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;

namespace MediatR_WebApplication.KitchenApp
{
    public class DishRepository: 
        IRetrieve<Guid, Dish>, 
        ICreate<Dish>,
        IUpdate<Dish>,
        IDelete<Guid>
    {
        private readonly List<Dish> _list = new();

        public Dish Retrieve(Guid key) => _list.SingleOrDefault(dish => dish.Id == key);

        public IEnumerable<Dish> RetrieveMany() => _list.ToImmutableArray();

        public void Create(Dish entity) => _list.Add(entity);

        public void Delete(Guid key) => _list.Remove(_list.SingleOrDefault(dish => dish.Id == key));

        public void Update(Dish entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
