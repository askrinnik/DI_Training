using System;

namespace MediatR_WebApplication.KitchenApp
{
    public class Dish
    {
        public Guid Id { get; }
        public string Name { get;}

        public Dish(string name): this(Guid.NewGuid(), name)
        {
        }

        public Dish(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
