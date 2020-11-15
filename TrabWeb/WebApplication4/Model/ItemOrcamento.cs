using System;

namespace WebApplication4.Model
{
    public class ItemOrcamento
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public int OrcamentoId { get; set; }
        public virtual Orcamento Orcamento { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal DescontoTotal { get; set; }
        public decimal LucroTotal { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
