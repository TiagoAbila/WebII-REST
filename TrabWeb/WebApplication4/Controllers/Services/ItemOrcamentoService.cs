using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
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

        public void Add(ItemOrcamento itemOrcamento)
        {
            _db.Orcamento_Item.Add(itemOrcamento);
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
            return _db.Orcamento_Item.ToList();
        }

        public ItemOrcamento GetById(int id)
        {
            return _db.Orcamento_Item.Find(id);
        }

        public void Update(ItemOrcamento itemOrcamento)
        {
            _db.Orcamento_Item.Update(itemOrcamento);
            _db.SaveChanges();
        }
    }
}
