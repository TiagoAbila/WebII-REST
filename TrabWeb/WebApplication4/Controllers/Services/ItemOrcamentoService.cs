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

            var orcamento = _db.Orcamento.Find(itemOrcamento.OrcamentoId);
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
            return _db.Orcamento_Item.Find(id);
        }

        public void Update(ItemOrcamentoDto itemOrcamentoDto)
        {
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

            var orcamento = _db.Orcamento.Find(itemOrcamento.OrcamentoId);
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
            return _db.Orcamento_Item.Where(o => o.OrcamentoId == orcamentoId).ToList();
        }
    }
}
