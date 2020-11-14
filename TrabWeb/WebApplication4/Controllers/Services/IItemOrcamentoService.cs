using System.Collections.Generic;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IItemOrcamentoService
    {
        ItemOrcamento GetById(int id);
        void Add(ItemOrcamentoDto itemOrcamento);
        void Delete(int id);
        void Update(ItemOrcamentoDto itemOrcamento);
        List<ItemOrcamento> GetAll();
    }
}
