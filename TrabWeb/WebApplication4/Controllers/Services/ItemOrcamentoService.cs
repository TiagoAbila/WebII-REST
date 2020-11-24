using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    internal class ItemOrcamentoService : IItemOrcamentoService
    {
        private DatabaseContext _db;

        public ItemOrcamentoService(DatabaseContext db)
        {
            _db = db;
        }

        public void Add(ItemOrcamentoDto itemOrcamentoDto)
        {
            var orcamento = _db.Orcamento.Find(itemOrcamentoDto.OrcamentoId);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            var item = _db.Item.Find(itemOrcamentoDto.ItemId);
            if (item == default)
                throw new KeyNotFoundException("Item não encontrado na base de dados.");

            var itemOrcamento = new ItemOrcamento {
                DataCadastro = DateTime.Now,
                ItemId = itemOrcamentoDto.ItemId,
                OrcamentoId = itemOrcamentoDto.OrcamentoId,
                CustoTotal = itemOrcamentoDto.CustoTotal,
                DescontoTotal = itemOrcamentoDto.DescontoTotal,
                LucroTotal = itemOrcamentoDto.LucroTotal,
                Quantidade = itemOrcamentoDto.Quantidade,
                ValorTotal = itemOrcamentoDto.ValorTotal
            };
            _db.Orcamento_Item.Add(itemOrcamento);
            _db.SaveChanges();

            orcamento.DescontoItens = orcamento.DescontoItens + itemOrcamento.DescontoTotal;
            orcamento.ValorTotalItens = orcamento.ValorTotalItens + itemOrcamento.ValorTotal;
            orcamento.CustoTotal = orcamento.CustoTotal + itemOrcamento.CustoTotal;
            orcamento.ValorOrcamento = orcamento.ValorTotalItens - orcamento.DescontoItens - orcamento.DescontoOrcamento;
            orcamento.LucroTotal = orcamento.ValorOrcamento - orcamento.CustoTotal;
            _db.Orcamento.Update(orcamento);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemOrcamento = _db.Orcamento_Item.Find(id);
            if (itemOrcamento == default)
                throw new KeyNotFoundException("Item de Orçamento não encontrado na base de dados.");

            _db.Orcamento_Item.Remove(itemOrcamento);
            _db.SaveChanges();
        }

        public List<ItemOrcamento> GetAll()
        {
            return _db.Orcamento_Item
                .Include(i => i.Item)
                .Include(i => i.Orcamento)
                .ToList();
        }

        public ItemOrcamento GetById(int id)
        {
            var itemOrcamento = _db.Orcamento_Item.Find(id);
            if (itemOrcamento == default)
                throw new KeyNotFoundException("Item de Orçamento não encontrado na base de dados.");

            return itemOrcamento;
        }

        public void Update(ItemOrcamentoDto itemOrcamentoDto)
        {
            var orcamento = _db.Orcamento.Find(itemOrcamentoDto.OrcamentoId);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            var item = _db.Item.Find(itemOrcamentoDto.ItemId);
            if (item == default)
                throw new KeyNotFoundException("Item não encontrado na base de dados.");

            var itemOrcamento = new ItemOrcamento
            {
                ItemId = itemOrcamentoDto.ItemId,
                OrcamentoId = itemOrcamentoDto.OrcamentoId,
                CustoTotal = itemOrcamentoDto.CustoTotal,
                DescontoTotal = itemOrcamentoDto.DescontoTotal,
                LucroTotal = itemOrcamentoDto.LucroTotal,
                Quantidade = itemOrcamentoDto.Quantidade,
                ValorTotal = itemOrcamentoDto.ValorTotal
            };
            _db.Orcamento_Item.Update(itemOrcamento);
            _db.SaveChanges();

            orcamento.DescontoItens = orcamento.DescontoItens + itemOrcamento.DescontoTotal;
            orcamento.ValorTotalItens = orcamento.ValorTotalItens + itemOrcamento.ValorTotal;
            orcamento.CustoTotal = orcamento.CustoTotal + itemOrcamento.CustoTotal;
            orcamento.ValorOrcamento = orcamento.ValorTotalItens - orcamento.DescontoItens - orcamento.DescontoOrcamento;
            orcamento.LucroTotal = orcamento.ValorOrcamento - orcamento.CustoTotal;
            _db.Orcamento.Update(orcamento);
            _db.SaveChanges();
        }

        public List<ItemOrcamento> GetByOrcamentoId(int orcamentoId)
        {
            var orcamento = _db.Orcamento.Find(orcamentoId);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            return _db.Orcamento_Item.Where(o => o.OrcamentoId == orcamentoId).ToList();
        }
    }
}
