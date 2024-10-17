using Newtonsoft.Json;
using Resources.Enums;
using Resources.Interfaces;
using Resources.Models;
namespace Resources.Services;

public class ProductService : IProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
    private List<Product> _productList = new List<Product>();
    private readonly FileService _fileService = new FileService(_filePath);
    public ResultStatus AddProduct(Product product)
    {
        try
        {
            if (string.IsNullOrEmpty(product.ProductName))
            {
                Console.WriteLine("You need to enter a product name");
                return ResultStatus.Failed;
            }
            if (_productList.Any(p => p.ProductName.ToLower() == product.ProductName.ToLower()))
            {
                Console.WriteLine("Product already exists in list");
                return ResultStatus.Exists;
            }
            if (string.IsNullOrEmpty(product.ProductCategory))
            {
                Console.WriteLine("You need to enter a product category");
                return ResultStatus.Failed;
            }
            if (string.IsNullOrEmpty(product.ProductPrice))
            {
                Console.WriteLine("You need to enter a product price");
                return ResultStatus.Failed;
            }
            else
            {
                _productList.Add(product);

                var json = JsonConvert.SerializeObject(_productList, Formatting.Indented);
                var result = _fileService.SaveToFile(json);
                if (result)
                    return ResultStatus.Success;
            }
            return ResultStatus.Failed;
        }
        catch
        {
            return ResultStatus.Failed;
        }
    }
    public IEnumerable<Product> GetAllProducts()
    {
        try
        {
            var content = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(content))
                _productList = JsonConvert.DeserializeObject<List<Product>>(content)!;
        }
        catch
        {
   
        }
        return _productList;
    }
    public ResultStatus DeleteProduct(Product product)
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
            {
                _productList = JsonConvert.DeserializeObject<List<Product>>(content)!;
            }
            if (string.IsNullOrEmpty(product.ProductId))
            {
                Console.WriteLine("You did not enter a product name");
                return ResultStatus.Failed;
            }
            var removeProduct = _productList.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (removeProduct == null)
            {
                Console.WriteLine("Product does not exist in list");
                return ResultStatus.Failed;
            }
            else
            {
                _productList.Remove(removeProduct);
                var json = JsonConvert.SerializeObject(_productList, Formatting.Indented);
                var result = _fileService.SaveToFile(json);
                Console.WriteLine("Product has been removed");
                return ResultStatus.Success;
            }  
        }          
        catch
        {
            return ResultStatus.Failed;
        }
    }
}
