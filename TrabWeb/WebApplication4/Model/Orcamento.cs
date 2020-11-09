using System;

namespace WebApplication4.Model
{
    public class Orcamento
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public double ValorTotalItens { get; set; }
        public double DescontoItens { get; set; }
        public double DescontoOrcamento { get; set; }
        public double ValorOrcamento { get; set; }
        public double LucroTotal { get; set; }
        public double CustoTotal { get; set; }
    }
}
