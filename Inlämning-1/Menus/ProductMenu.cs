using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace Inlämning_1.Menus;

internal class ProductMenu
{
    private readonly ProductService _productService = new ProductService();
    public void CreateMenu()
    {
        Product product = new Product();

        Console.Clear();
        Console.WriteLine("Create new product\n");

        Console.Write("Enter Product Name: ");
        product.ProductName = Console.ReadLine() ?? "";

        Console.Write("Enter Product Price: ");
        product.ProductPrice = Console.ReadLine() ?? "";

        Console.Write("Enter Product category: ");
        product.ProductCategory = Console.ReadLine() ?? "";

        var result = _productService.AddProduct(product);

        switch (result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nProduct was added to list.");
                break;
            case ResultStatus.Exists:
                Console.WriteLine("\nProduct with the same name already exists.");
                break;
            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void ViewAllMenu()
    {
        var productList = _productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("Products");

        if (!productList.Any())
        {
            Console.WriteLine("\nNo products in list");
        }
        else
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"\nCategory: {product.ProductCategory}");
                Console.WriteLine($"Product: {product.ProductName}");
                Console.WriteLine($"Price: { product.ProductPrice}:-");
                Console.WriteLine($"Product Id: {product.ProductId}");
            }
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }
    public void ExitMenu()
    {
        Console.Write("Do you want to exit the menu? (y/n): ");
        var answer = Console.ReadLine();
        if (answer.ToLower() == "y")
        {
            Console.WriteLine("Application closed");
            Environment.Exit(0);
        }
    }
    public void DeleteMenu()
    {
        Console.Clear();
        var productList = _productService.GetAllProducts();
        var removeProduct = new Product();

        Console.WriteLine("Remove a product");

        if (!productList.Any())
        {
            Console.WriteLine("No products in list\n");
        }
        else
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"\nCategory: {product.ProductCategory}");
                Console.WriteLine($"Product: {product.ProductName}");
                Console.WriteLine($"Price: {product.ProductPrice}:-");
                Console.WriteLine($"Product Id: {product.ProductId}");
            }
        }
        Console.Write("\nEnter product name to remove: ");

        removeProduct.ProductId = Console.ReadLine()??"";

        var answer = _productService.DeleteProduct(removeProduct);

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }
}