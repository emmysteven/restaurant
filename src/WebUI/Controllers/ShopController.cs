using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Application.UseCases.Shops.Commands.CreateShop;
using Restaurant.Application.UseCases.Shops.Commands.DeleteShop;
using Restaurant.Application.UseCases.Shops.Commands.UpdateShop;
using Restaurant.Application.UseCases.Shops.Queries.GetAllShops;
using Restaurant.Application.UseCases.Shops.Queries.GetShopById;

namespace Restaurant.WebUI.Controllers
{
    [Authorize]
    public class ShopController : BaseController
    {
        public ShopController(ILogger<ShopController> logger) : base(logger) { }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllShopsParameter filter)
        {
            var query = await Mediator.Send(new GetAllShopsQuery
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            });
            var shops = query.Data.Select(x => new GetAllShopsVm
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                State = x.State,
                Address = x.Address,
                Website = x.Website,
                PhoneNumber = x.PhoneNumber,
                LocalGovernmentArea = x.LocalGovernmentArea,
                ImagePath = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{x.ImagePath}"
            });
            query.Data = shops;
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = await Mediator.Send(new GetShopByIdQuery(id));
            return Ok(query);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateShopCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShopCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = await Mediator.Send(new GetShopByIdQuery(id));
            return Ok(await Mediator.Send(new DeleteShopCommand(query)));
        }
    }
}