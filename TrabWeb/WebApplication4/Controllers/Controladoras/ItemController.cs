using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Controladoras
{
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

        [HttpPost("post")]
        public ActionResult Add([FromBody] Item item)
        {
            _itemService.Add(item);
            return Ok();
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] Item item)
        {
            _itemService.Update(item);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _itemService.Delete(id);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<List<Item>> GetAll()
        {
            return Ok(_itemService.GetAll());
        }
    }
}