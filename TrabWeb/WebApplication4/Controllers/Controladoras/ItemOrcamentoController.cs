﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Controllers.Services;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Controladoras
{
    [Route("[controller]")]
    public class ItemOrcamentoController : Controller
    {
        private readonly IItemOrcamentoService _itemOrcamentoService;
        private readonly IItemService _itemService;
        private readonly IOrcamentoService _orcamentoService;

        public ItemOrcamentoController(IItemOrcamentoService itemOrcamentoService)
        {
            _itemOrcamentoService = itemOrcamentoService;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemOrcamentoDTO> GetById([FromRoute] int id)
        {
            ItemOrcamentoDTO itemOrcamentoDTO = new ItemOrcamentoDTO();
            itemOrcamentoDTO = _itemOrcamentoService.GetById(id);
            itemOrcamentoDTO.Item = _itemService.GetById(itemOrcamentoDTO.ItemOrcamento.ItemId);
            itemOrcamentoDTO.Orcamento = _orcamentoService.GetById(itemOrcamentoDTO.ItemOrcamento.OrcamentoId);
            return itemOrcamentoDTO;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ItemOrcamento itemOrcamento)
        {
            _itemOrcamentoService.Add(itemOrcamento);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ItemOrcamento itemOrcamento)
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
    }
}