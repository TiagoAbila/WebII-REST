using System;

namespace WebApplication4.Controllers.Services.Dto
{
    public class OrcamentoDto
    {
        public DateTime DataFinalizacao { get; set; }
        public decimal ValorTotalItens { get; set; }
        public decimal DescontoItens { get; set; }
        public decimal DescontoOrcamento { get; set; }
        public decimal ValorOrcamento { get; set; }
        public decimal LucroTotal { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
