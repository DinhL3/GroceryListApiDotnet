namespace GroceryListApiDotnet.Models
{
    public class GroceryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsPurchased { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}