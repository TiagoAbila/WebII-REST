using Microsoft.AspNetCore.Mvc;
using WebApplication4.Controllers.Dto;
using WebApplication4.Controllers.Services;

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
        public ActionResult<ItemCadastroExibicaoDto> GetById([FromRoute] int id)
        {
            return _itemService.GetById(id);
        }
    }
}