using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
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
        public ActionResult Add([FromBody] Item item)
        {
            _itemService.Add(item);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Item item)
        {
            _itemService.Update(item);
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
    }
}