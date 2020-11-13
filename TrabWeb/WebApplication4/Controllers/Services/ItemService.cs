using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
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

        public List<Item> GetAll()
        {
            return _db.Item.ToList();
        }

        public Item GetById(int id)
        {
            return _db.Item.Find(id);
        }

        public void Update(Item item)
        {
            _db.Item.Update(item);
            _db.SaveChanges();
        }
    }
}
