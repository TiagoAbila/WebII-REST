using System;
using System.Collections.Generic;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IOrcamentoService
    {
        Orcamento GetById(int id);
        void Add(OrcamentoDto orcamento);
        void Delete(int id);
        void Update(OrcamentoDto orcamentoDto, int id);
        List<Orcamento> GetAll();
        List<Orcamento> GetByPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}
