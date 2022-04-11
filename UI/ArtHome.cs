using System.ComponentModel.DataAnnotations;
using BL;
using Models;

namespace UI;

public class ArtHome
{

    /*
        static void Main() {}
    */

    private readonly IAsbl _bl;

    public ArtHome(IAsbl bl)
    {
        _bl = bl;
    }

    public void ArtStoreHome(IAsbl b1)
    {
        b1 = b1;
    }
    //Dependency injection
    public void Start()
    {
        bool exit = false;
        do
        {
            Home();
            Console.WriteLine("Welcome to The Art Shop!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Create an Account");
            Console.WriteLine("[2] Login into existing account");

        CInput:
            string? input = Console.ReadLine();

            switch (input.Trim().ToUpper())
            {
                case "1":
                    CreateAccount();
                    break;

                case "2":
                    Login();
                    break;
                case "11937":
                    Manager();
                    break;
                case "X":
                    Console.WriteLine("Goodbye");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    goto CInput;
            }

        } while (!exit);
    }

    public void Home()
    {
        Console.WriteLine("\n-------------------------------------------\n");
    }

    private void CreateAccount()
    {
        CreateAccount(_bl);
    }

    private void CreateAccount(IAsbl bl)
    {
        Home();

        Console.WriteLine("Welcome!");

    EnterCustomer:
        Console.WriteLine("Please begin creating your account by entering your first name: ");
        string? fname = Console.ReadLine();

        Console.WriteLine("Please enter your last name: ");
        string? lname = Console.ReadLine();

        Console.WriteLine("Please enter your email address: ");
        string? email = Console.ReadLine();

        Console.WriteLine("Please enter your password");
        string? cPass = Console.ReadLine();


        Customer newCustomer = new Customer();

        try
        {
            newCustomer.FName = fname;
            newCustomer.LName = lname;
            newCustomer.Email = email;
            newCustomer.CPass = cPass;
        }
        catch (ValidationException z)
        {
            Console.WriteLine(z.Message);
            goto EnterCustomer;
        }

        Customer createdCustomer = bl.CreateCustomer(newCustomer);
        if (createdCustomer != null)
            Console.WriteLine("\nNew Customer Account created successfully!");

    }
    private void Login()
    {
        Home();

    EnterLogin:
        Console.WriteLine("Please enter your email");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? cPass = Console.ReadLine();



        Customer login = new Customer();

        try
        {
            login.Email = email;
            login.CPass = cPass;
        }
        catch (ValidationException z)
        {
            Console.WriteLine(z.Message);
            goto EnterLogin;
        }
        int results = _b1.LoginChecker(login);
        switch (results)
        {
            case 0:
            InputLogin0:
                Console.WriteLine("Account email does not exist");
                Console.WriteLine("Try again? (Y/N)");
                string? responseLogin0 = Console.ReadLine();
                if (responseLogin0.Trim().ToUpper()[0] == 'Y')
                    goto EnterLogin;
                else if (responseLogin0.Trim().ToUpper()[0] == 'N')
                    break;
                else
                {
                    Console.WriteLine("Input not recognized");
                    goto InputLogin0;
                }
            case 1:
            InputLogin1:
                Console.WriteLine("Password is incorrect");
                Console.WriteLine("Try again? (Y/N)");
                string? responseLogin1 = Console.ReadLine();
                if (responseLogin1.Trim().ToUpper()[0] == 'Y')
                    goto EnterLogin;
                else if (responseLogin1.Trim().ToUpper()[0] == 'N')
                    break;
                else
                {
                    Console.WriteLine("Input not recognized");
                    goto InputLogin1;
                }
            case 2:
                Console.WriteLine("Login successful!");
                CustomerMenu(login);
                break;

        }
    }
    public void CustomerMenu(Customer current)
    {
    CustomerResponse:
        Home();
        Console.WriteLine($"Welcome {current.FName} to the Art Store");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1]: Shop");
        Console.WriteLine("[2]: View Shopping Cart");
        Console.WriteLine("[3]: View order history");
        Console.WriteLine("[x]: Logout");

        string? input = Console.ReadLine();

        switch (input.Trim().ToUpper()[0])
        {
            case '1':
                break;
            case '2':
                break;
            case '3':
                break;
            case 'x':
                break;
            default:
                Console.WriteLine("Invalid Please try again.");
                goto CustomerResponse;

        }
    }
    public void Manager()
    {
        Home();
        Console.WriteLine("Welcome to Manager Menu");
        Console.WriteLine("[1]: Replenish Stocks");
        Console.WriteLine("[2]: View Inventory");
        Console.WriteLine("[3]: Add Product");
        Console.WriteLine("[x]: Logout");

    ManagerInput:
        string? mInput = Console.ReadLine();

        switch (mInput.Trim().ToUpper()[0])
        {
            case '1':
                ViewProd();
                break;

            case '2':
                AddProduct();
                break;

            case 'X':
                break;

            default:
                Console.WriteLine("Input invalid. Please try again.");
                goto ManagerInput;
        }

    }

    public void ViewProd()
    {
        Console.WriteLine("Below is your inventory for the Art Store. ");
        List prodList = _bl.
    }
    public void AddProduct()
    {
        Home();

    EnterProductDetails:
        Console.WriteLine("What is the art supply that you would like to add?");
        string? prodName = Console.ReadLine();

        Console.WriteLine("What is the price of this item?");
        double? prodPrice = Convert.ToDouble(Console.ReadLine());

        Product newProd = new Product();

        try
        {
            string? prodname = prodName;
            newProd.ProdName = prodName;
            newProd.Price = prodPrice.Value;
        }
        catch (ValidationException z)
        {
            Console.WriteLine(z.Message);
            goto EnterProductDetails;
        }

        Product createProduct = _bl.CreateProduct(newProd);
        if (createProduct != null)
            Console.WriteLine("\nProduct created successfully");

    }






}