using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatR_WebApplication.KitchenApp;

namespace MediatR_WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DishController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Dish>> Get()
        {
            var command = new GetAllDishesQuery();
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Dish> Get(string id)
        {
            var command = new GetDishQuery(id);
            return await _mediator.Send(command);
        }

        [HttpPost]
        public async Task Create(string name)
        {
            var command = new CreateDishCommand(name);
            await _mediator.Send(command);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task Update(string id, string name)
        {
            var command = new UpdateDishCommand(new Dish(Guid.Parse(id), name));
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(string id)
        {
            var command = new DeleteDishCommand(id);
            await _mediator.Send(command);
        }

    }
}
