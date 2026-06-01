namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public DateOnly DataWaznosci { get; set; }
    }
}
