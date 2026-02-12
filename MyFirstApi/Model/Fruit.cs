namespace FruitApi.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Color { get; set; }
        public decimal Price { get; set; }
    }
}
