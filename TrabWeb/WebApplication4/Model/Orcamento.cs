using System;

namespace WebApplication4.Model
{
    public class Orcamento
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public decimal ValorTotalItens { get; set; }
        public decimal DescontoItens { get; set; }
        public decimal DescontoOrcamento { get; set; }
        public decimal ValorOrcamento { get; set; }
        public decimal LucroTotal { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
