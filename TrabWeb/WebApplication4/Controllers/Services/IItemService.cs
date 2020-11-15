using System;
using System.Collections.Generic;
using WebApplication4.Controllers.Services.Dto;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Services
{
    public interface IItemService
    {
        Item GetById(int id);
        void Add(ItemDto itemDto);
        void Delete(int id);
        void Update(ItemDto itemDto, int id);
        List<Item> GetAll();
        List<Item> GetByPeriodo(DateTime dataInicial, DateTime dataFinal);
        List<Item> GetByTipo(char tipo);
    }
}
