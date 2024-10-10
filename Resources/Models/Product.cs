namespace Resources.Models;

public class Product
{
   public string ProductName { get; set; } = null!;
   public string ProductPrice { get; set; } = null!;
   public string ProductId { get; set; } = Guid.NewGuid().ToString();
   public string ProductCategory { get; set; } = null!;
}
