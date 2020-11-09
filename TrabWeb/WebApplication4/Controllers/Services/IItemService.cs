using System.Collections.Generic;
using WebApplication4.Controllers.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IItemService
    {
        ItemCadastroExibicaoDto GetById(int id);
        void Add(Item item);
        void Delete(int id);
        void Update(Item item);
        List<ItemCadastroExibicaoDto> GetAll(int id);
    }
}
