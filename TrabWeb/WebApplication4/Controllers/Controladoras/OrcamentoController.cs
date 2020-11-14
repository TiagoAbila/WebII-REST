using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Controladoras
{
    [Route("[controller]")]
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpGet("{id}")]
        public ActionResult<Orcamento> GetById([FromRoute] int id)
        {
            return _orcamentoService.GetById(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Orcamento orcamento)
        {
            _orcamentoService.Add(orcamento);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Orcamento orcamento)
        {
            _orcamentoService.Update(orcamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _orcamentoService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Orcamento>> GetAll()
        {
            return Ok(_orcamentoService.GetAll());
        }
    }
}