using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Controladoras
{
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetById([FromRoute] int id)
        {
            return _itemService.GetById(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ItemDto itemDto)
        {
            _itemService.Add(itemDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ItemDto itemDto, [FromRoute] int id)
        {
            _itemService.Update(itemDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _itemService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Item>> GetAll()
        {
            return Ok(_itemService.GetAll());
        }

        [HttpGet("periodo")]
        public ActionResult<List<Item>> GetByPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            return Ok(_itemService.GetByPeriodo(dataInicial, dataFinal));
        }

        [HttpGet("tipo")]
        public ActionResult<List<Item>> GetByTipo([FromQuery] char tipo)
        {
            return Ok(_itemService.GetByTipo(tipo));
        }
    }
}