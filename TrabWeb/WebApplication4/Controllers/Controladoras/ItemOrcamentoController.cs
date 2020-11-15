using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Controladoras
{
    [Route("[controller]")]
    public class ItemOrcamentoController : Controller
    {
        private readonly IItemOrcamentoService _itemOrcamentoService;

        public ItemOrcamentoController(IItemOrcamentoService itemOrcamentoService)
        {
            _itemOrcamentoService = itemOrcamentoService;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemOrcamento> GetById([FromRoute] int id)
        {
            return _itemOrcamentoService.GetById(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ItemOrcamentoDto itemOrcamento)
        {
            _itemOrcamentoService.Add(itemOrcamento);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ItemOrcamentoDto itemOrcamento)
        {

            _itemOrcamentoService.Update(itemOrcamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _itemOrcamentoService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<ItemOrcamento>> GetAll()
        {
            return Ok(_itemOrcamentoService.GetAll());
        }

        [HttpGet("orcamento/{orcamentoId}")]
        public ActionResult<ItemOrcamento> GetByOrcamentoId([FromRoute] int orcamentoId)
        {
            return Ok(_itemOrcamentoService.GetByOrcamentoId(orcamentoId));
        }
    }
}
