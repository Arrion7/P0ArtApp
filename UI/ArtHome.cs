using BL;
using Models;

namespace UI;

public class ArtHome
{
    private readonly IAsbl _bl;

    public ArtHome(IAsbl bl)
    {
        _bl = bl;
    }

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

    private void CreateAccount()
    {
        throw new NotImplementedException();
    }

    public void Home()
    {
        Console.WriteLine("-------------------------------------------");
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


        var newCustomer = new Customer();

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

        Customer createdCustomer = _bl.CreateCustomer(newCustomer);
        if (createdCustomer != null)
            Console.WriteLine("New Customer Account created successfully!");

    }
    private void Login()
    {
        Home();

    EnterLogin:
        Console.WriteLine("Please enter your email");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? cPass = Console.ReadLine();



        var login = new Customer();

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
        int results = _bl.LoginChecker(login);
        string? responseLogin1;
        switch (results)
        {
            case 1:
            LoginInput1:
                Console.WriteLine("Account email does not exist.");
                Console.WriteLine("Would you like to try again? (Y/N)");
                responseLogin1 = Console.ReadLine();

                if (responseLogin1 != null && responseLogin1.Trim().ToUpper()[1] == 'Y')
                    goto EnterLogin;
                else if (responseLogin1.Trim().ToUpper()[1] == 'N')
                    break;
                else
                {
                    Console.WriteLine("Input not recognized");
                    goto LoginInput1;
                }
            case 2:
            LoginInput2:
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Try again? (Y/N)");
                var responseLogin2 = Console.ReadLine();

                if (responseLogin2.Trim().ToUpper()[2] == 'Y')
                    goto EnterLogin;

                else if (responseLogin2.Trim().ToUpper()[2] == 'N')
                    break;

                else
                {
                    Console.WriteLine("Input incorrect");
                    goto LoginInput2;
                }
            case 3:
                Console.WriteLine("Login successful!");
                CustomerMenu(login);
                break;

        }
    }
    public void CustomerMenu(Customer current)
    {
        bool customerLeave = false;
        do
        {
        CustomerResponse:
            Home();
            Console.WriteLine($"Welcome {current.FName} to the Art storefront");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1]: Shop");
            Console.WriteLine("[2]: View Shopping Cart");
            Console.WriteLine("[3]: View order history");
            Console.WriteLine("[x]: Logout");

            string? input = Console.ReadLine();

            if (input != null)
                switch (input.Trim().ToUpper()[0])
                {
                    case '1':
                        ShopArt();
                        break;
                    case '2':
                        ViewShopCart();
                        break;
                    case '3':
                        ViewOrderHistory();
                        break;
                    case 'x':
                        customerLeave = true;
                        break;
                    default:
                        Console.WriteLine("Invalid. Please try again.");
                        goto CustomerResponse;
                }
        } while ((!customerLeave));
    }

    private void ViewOrderHistory()
    {
        throw new NotImplementedException();
    }

    private void ShopArt()
    {
        throw new NotImplementedException();
    }

    private void ViewShopCart()
    {
        throw new NotImplementedException();
    }

    public void ShopArt(Customer current)
    {
        Order currentOrder = new Order();
        int count = 0;

        Home();
        Console.WriteLine("Which storefront would you like to shop at?");
        custSelectStore = SelectStore();

    Continue:
        Home();
        Console.WriteLine("Select the are supply.");
        Product shopProduct = SelectProduct(custSelectStore);

        Home();

    shopConfirmation:
        Console.WriteLine($"Are you should you would like to add {shopProduct.ArtName} at ${shopProduct.Price} to your cart (Y/N)");
        string shopconfirm = Console.ReadLine();

        switch (shopconfirm.Trim().ToUpper()[0])
        {
            case 'Y':
                AddToShopCart(current, custSelectStore, shopProduct, currentOrder, count);
                count++;
                break;
            case 'N':
                Console.WriteLine("Art Product not added to cart");
                break;
            default:
                Console.WriteLine("Invalid input, Try again");
                goto shopConfirmation;
                return;
        }

        if (count > 0)
        {
            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("[1]: Continue shopping?");
            Console.WriteLine("[2]: Checkout");
            Console.WriteLine("[x]: Cancel");

            string? cartAnswer = Console.ReadLine();

            switch (cartAnswer.Trim().ToUpper()[0])
            {
                case '1':
                    goto Continue;
                case '2':
                    Checkout(currentOrder);
                    break;
                case 'X':
                    break;
            }
        }

    }


    public void AddToShopCart(Customer currentCustomer, StoreFrontId custSelectStore, Product shopProduct, Order currentOrder, int count)
 
    {
        if (count == 0)
        {
            currentOrder.CustomerID = current.Id;
            currentOrder.StoreID = custSelectStore.Id;
        }

        currentOrder.AddShopCartarts(shopProduct);


    }
    public void Checkout(Order currentOrder)
    {
        currentOrder.DateCreated = DateTime.Now;
        if (_bl.UpdateOrders(currentOrder) == null) ;
        Console.WriteLine("You have successfully placed your order. Thank you for shopping with us!");
    }



    public void Manager()
    {
        bool managerExits = false;
        do
        {
            Home();
            Console.WriteLine("Welcome to Manager Menu");
            Console.WriteLine("[2]: View Products");
            Console.WriteLine("[3]: Add Product");
            Console.WriteLine("[x]: Logout");

        ManagerInput:
            string? mInput = Console.ReadLine();

            switch (mInput.Trim().ToUpper()[0])
            {
                case '1':
                    ViewProduct();
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
        } while (managerExits);

    }
    public StoreFrontId? SelectStoreFront()
    {
        Console.WriteLine("Here are all the storefronts by State: ");
        List<StoreFrontId> allStoreFronts = _bl.GetStoreFrontIds();

        if (allStoreFronts.Count == 0)
            return null;

        SelectInput:
        for (int i = 0; i < allStoreFronts.Count; i++)
            Console.WriteLine(allStoreFronts[i].ToString());

        int select;

        if (Int32.TryParse(Console.ReadLine(), out select) && ((select - 1) >= 0 && (select - 1) < allStoreFronts.Count))
            return allStoreFronts[select - 1];
        else
        {
            Console.WriteLine("Invalid input, Try again");
            goto SelectInput;
        }
    }
    public Product SelectProduct(StoreFront getProductStore)
    {
        Console.WriteLine($"Here is the Products for the {getProductStore.StoreLocation} store:");
        List<Product> Products = _bl.GetProducts(getProductStore);

        if (Products.Count == 0)
            return null;

        ProductInput:
        for (int i = 0; i < Products.Count; i++)
            Console.WriteLine($"[{i}]: {Products[i].artName}");

        int ProductSelect;

        if (Int32.TryParse(Console.ReadLine(), out ProductSelect) && ((ProductSelect) >= 0 && (ProductSelectSelect) < Products.Count))
            return Products[ProductSelect];
        else
        {
            Console.WriteLine("Invalid input, Try again");
            goto Input;
        }

    }

    private Product SelectProducts(Store getProductStore)
    {
        Console.WriteLine($"Here is the Products for the {getProductStore.StoreLocation} store:");
        List<Product> Products = _bl.GetProducts(getProductStore);

        if (Products.Count == 0)
            return null;

        ProductInput:
        for (int i = 0; i < Products.Count; i++)
            Console.WriteLine($"[{i}]: {Products[i].artName}");

        int ProductSelect = Select;

        if (Int32.TryParse(Console.ReadLine(), out ProductSelect) && ((ProductSelect) >= 0 && (ProductSelect) < Products.Count))
            return Products[ProductSelect];
        else
        {
            Console.WriteLine("Invalid input, Try again");
            goto ProductInput;
        }
    }


    public void ViewProduct()
    {
        Console.WriteLine("Which storefront location would you like  to view?");
        StoreFront? viewStoreFront = SelectStoreFront();

        Console.WriteLine($"Below is your Products for the Art storefront at the {viewStoreFrontLocation}: ");
        List<Product> pList = _bl.GetPList(viewStoreFront);
        if (pList.Count == 0)
        {
            Console.WriteLine("Sorry that storefront location has sold out.");
            return;
        }

        for (int i = 0; i < pList.Count; i++)
            Console.WriteLine(pList[i].ToString());

        Console.WriteLine("Please press one key to proceed.");
        string oneKey = Console.ReadLine();
    }

    public void AddProduct()
    {
        Home();
    

        Console.WriteLine("What is the art supply that you would like to add?");
        string? _ProductName = Console.ReadLine();



    Console.WriteLine("What is the price of this art?");

        double? _ProductPrice = Convert.ToDouble(Console.ReadLine());

        Product _newProduct = new Product();

        try

        {
            string? ProductName = _ProductName;

            _newProduct.ProductName = _ProductName;
            _newProduct.Price = _ProductPrice.Value;
        }
        catch (ValidationException z)
        {
            Console.WriteLine(z.Message);

            goto EnterProductDetails;
        }

        Product createProduct = _bl.CreateProduct(newProduct);
        if (createProduct != null)

        Console.WriteLine("Product created successfully");
    }
    

}
