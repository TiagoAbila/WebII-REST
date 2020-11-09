using System.Collections.Generic;
using WebApplication4.Controllers.Database;
using WebApplication4.Controllers.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    internal class ItemService : IItemService
    {
        private DatabaseContext _db;

        public ItemService(DatabaseContext db)
        {
            _db = db;
        }

        public void Add(Item item)
        {
            _db.Item.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.Item.Find(id);

            _db.Item.Remove(item);
            _db.SaveChanges();
        }

        public List<ItemCadastroExibicaoDto> GetAll(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetById(int id)
        {
            return "Funciona!" + id;
        }

        public void Update(Item item)
        {
            throw new System.NotImplementedException();
        }

        ItemCadastroExibicaoDto IItemService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
