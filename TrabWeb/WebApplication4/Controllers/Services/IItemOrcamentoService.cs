using System.Collections.Generic;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IItemOrcamentoService
    {
        ItemOrcamento GetById(int id);
        void Add(ItemOrcamento itemOrcamento);
        void Delete(int id);
        void Update(ItemOrcamento itemOrcamento);
        List<ItemOrcamento> GetAll();
    }
}
