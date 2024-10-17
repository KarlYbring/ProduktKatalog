namespace Inlämning_1.Menus;

public class Menu
{
    private readonly ProductMenu _productMenu = new ProductMenu();

    public void MainMenu()
    {
        Console.Clear();

        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. List All Products");
        Console.WriteLine("3. Remove Product");
        Console.WriteLine("0. Exit Application");

        Console.Write("\nEnter your choice: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _productMenu.CreateMenu();
                break;
            case "2":
                _productMenu.ViewAllMenu();
                break;
            case "3":
                _productMenu.DeleteMenu();
                break;
            case "0":
               _productMenu.ExitMenu();
                break;
            default:
                Console.WriteLine("You need to enter an option");
                Console.ReadKey();
                break;
        }
    }
}
