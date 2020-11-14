using WebApplication4.Model;

namespace WebApplication4.Controllers.Services.Dto
{
    public class ItemOrcamentoDto
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal DescontoTotal { get; set; }
        public decimal LucroTotal { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
