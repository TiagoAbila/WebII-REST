using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    internal class OrcamentoService : IOrcamentoService
    {
        private DatabaseContext _db;

        public OrcamentoService(DatabaseContext db)
        {
            _db = db;
        }

        public void Add(OrcamentoDto orcamentoDto)
        {
            var orcamento = new Orcamento
            {
                DataCadastro = DateTime.Now,
                CustoTotal = orcamentoDto.CustoTotal,
                DataFinalizacao = orcamentoDto.DataFinalizacao,
                DescontoItens = orcamentoDto.DescontoItens,
                DescontoOrcamento = orcamentoDto.DescontoOrcamento,
                LucroTotal = orcamentoDto.LucroTotal,
                ValorOrcamento = orcamentoDto.ValorOrcamento,
                ValorTotalItens = orcamentoDto.ValorTotalItens
            };

            _db.Orcamento.Add(orcamento);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var orcamento = _db.Orcamento.Find(id);

            _db.Orcamento.Remove(orcamento);
            _db.SaveChanges();
        }

        public List<Orcamento> GetAll()
        {
            return _db.Orcamento.ToList();
        }

        public Orcamento GetById(int id)
        {
            return _db.Orcamento.Find(id);
        }

        public void Update(OrcamentoDto orcamentoDto, int id)
        {
            var orcamento = _db.Orcamento.Find(id);

            orcamento.CustoTotal = orcamentoDto.CustoTotal;
            orcamento.DataFinalizacao = orcamentoDto.DataFinalizacao;
            orcamento.DescontoItens = orcamentoDto.DescontoItens;
            orcamento.DescontoOrcamento = orcamentoDto.DescontoOrcamento;
            orcamento.LucroTotal = orcamentoDto.LucroTotal;
            orcamento.ValorOrcamento = orcamentoDto.ValorOrcamento;
            orcamento.ValorTotalItens = orcamentoDto.ValorTotalItens;

            _db.Orcamento.Update(orcamento);
            _db.SaveChanges();
        }

        public List<Orcamento> GetByPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _db.Orcamento.Where(i => i.DataCadastro >= dataInicial && i.DataCadastro <= dataFinal).ToList();
        }
    }
}
