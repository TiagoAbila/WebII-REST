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
                DataFinalizacao = orcamentoDto.DataFinalizacao,
                DescontoOrcamento = orcamentoDto.DescontoOrcamento,
                CustoTotal = 0,
                DescontoItens = 0,
                LucroTotal = 0,
                ValorOrcamento = 0,
                ValorTotalItens = 0
            };

            _db.Orcamento.Add(orcamento);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var orcamento = _db.Orcamento.Find(id);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            _db.Orcamento.Remove(orcamento);
            _db.SaveChanges();
        }

        public List<Orcamento> GetAll()
        {
            return _db.Orcamento.ToList();
        }

        public Orcamento GetById(int id)
        {
            var orcamento = _db.Orcamento.Find(id);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            return orcamento;
        }

        public void Update(OrcamentoDto orcamentoDto, int id)
        {
            var orcamento = _db.Orcamento.Find(id);
            if (orcamento == default)
                throw new KeyNotFoundException("Orçamento não encontrado na base de dados.");

            orcamento.DataFinalizacao = orcamentoDto.DataFinalizacao;
            orcamento.DescontoOrcamento = orcamentoDto.DescontoOrcamento;

            _db.Orcamento.Update(orcamento);
            _db.SaveChanges();
        }

        public List<Orcamento> GetByPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _db.Orcamento.Where(i => i.DataCadastro >= dataInicial && i.DataCadastro <= dataFinal).ToList();
        }
    }
}
