using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.Controllers.Database;
using WebApplication4.Controllers.Services.Dto;
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

        public void Add(ItemDto itemDto)
        {
            var item = new Item
            {
                DataCadastro = DateTime.Now,
                Custo = itemDto.Custo,
                Descricao = itemDto.Descricao,
                MargemLucro = itemDto.MargemLucro,
                Tipo = itemDto.Tipo,
                ValorUnitario = itemDto.ValorUnitario
            };

            _db.Item.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.Item.Find(id);
            if (item == default)
                throw new KeyNotFoundException("Item não encontrado na base de dados.");

            _db.Item.Remove(item);
            _db.SaveChanges();
        }

        public List<Item> GetAll()
        {
            return _db.Item.ToList();
        }

        public Item GetById(int id)
        {
            var item = _db.Item.Find(id);
            if (item == default)
                throw new KeyNotFoundException("Item não encontrado na base de dados.");

            return item;
        }

        public void Update(ItemDto itemDto, int id)
        {
            var item = _db.Item.Find(id);
            if (item == default)
                throw new KeyNotFoundException("Item não encontrado na base de dados.");

            item.Descricao = itemDto.Descricao;
            item.Custo = itemDto.Custo;
            item.MargemLucro = itemDto.MargemLucro;
            item.Tipo = itemDto.Tipo;
            item.ValorUnitario = itemDto.ValorUnitario;

            _db.Item.Update(item);
            _db.SaveChanges();
        }

        public List<Item> GetByPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _db.Item.Where(i => i.DataCadastro >= dataInicial && i.DataCadastro <= dataFinal).ToList();
        }

        public List<Item> GetByTipo(char tipo)
        {
            return _db.Item.Where(i => i.Tipo == tipo).ToList();
        }
    }
}
