namespace WebApplication4.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Custo { get; set; }
        public decimal MargemLucro { get; set; }
        public char Tipo { get; set; }
    }
}
