namespace CarService.Models
{
    public class CarService
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public decimal Price { get; set; }
    }
}
