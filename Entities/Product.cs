namespace ProductApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Care { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        public double Length { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
