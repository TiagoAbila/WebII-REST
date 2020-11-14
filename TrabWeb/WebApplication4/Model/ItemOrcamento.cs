namespace WebApplication4.Model
{
    public class ItemOrcamento
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int ItemId { get; set; }
        public double Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public double DescontoTotal { get; set; }
        public double LucroTotal { get; set; }
        public double CustoTotal { get; set; }
    }
}
