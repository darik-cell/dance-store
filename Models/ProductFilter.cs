namespace ProductApp.Models
{
    public class ProductFilter
    {
        // Фильтр по полу – ожидается, например, "Женский" или "Мужской"
        public string? Gender { get; set; }

        // Фильтр по типам одежды (может быть несколько)
        public List<string>? Types { get; set; }

        // Фильтр по цветам (может быть несколько)
        public List<string>? Colors { get; set; }

        // Фильтр по цене
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}
