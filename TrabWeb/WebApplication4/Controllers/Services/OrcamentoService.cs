using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
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

        public void Add(Orcamento orcamento)
        {
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

        public void Update(Orcamento orcamento)
        {
            _db.Orcamento.Update(orcamento);
            _db.SaveChanges();
        }
    }
}
