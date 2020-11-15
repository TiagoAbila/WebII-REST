using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Controllers.Services.Dto;
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
        public ActionResult Add([FromBody] OrcamentoDto orcamentoDto)
        {
            _orcamentoService.Add(orcamentoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] OrcamentoDto orcamentoDto, [FromRoute] int id)
        {
            _orcamentoService.Update(orcamentoDto, id);
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

        [HttpGet("periodo")]
        public ActionResult<List<Orcamento>> GetByPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            return Ok(_orcamentoService.GetByPeriodo(dataInicial, dataFinal));
        }
    }
}