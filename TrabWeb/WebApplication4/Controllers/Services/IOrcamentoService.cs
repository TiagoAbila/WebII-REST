using System.Collections.Generic;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IOrcamentoService
    {
        Orcamento GetById(int id);
        void Add(Orcamento orcamento);
        void Delete(int id);
        void Update(Orcamento orcamento);
        List<Orcamento> GetAll();
    }
}
