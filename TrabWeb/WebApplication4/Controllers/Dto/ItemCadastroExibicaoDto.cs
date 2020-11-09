using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers.Dto
{
    public class ItemCadastroExibicaoDto
    {
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
        public double Custo { get; set; }
        public char Tipo { get; set; }
    }
}
