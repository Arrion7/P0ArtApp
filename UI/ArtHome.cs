using System.ComponentModel.DataAnnotations;
using BL;
using DL;
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

        }while (!exit);
    }

    public void Home()
    {
        Console.WriteLine("-------------------------------------------");
    }

    public void CreateAccount(IAsbl bl)
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

        Customer createdCustomer = _bl.CreateCustomer(newCustomer);
        if (createdCustomer != null)
            Console.WriteLine("New Customer Account created successfully!");

    }
    public void Login()
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

        int results = _bl.LoginValid(login);
        switch (results)
        {
            case 1:
                LoginInput1:
                Console.WriteLine("Account email does not exist.");
                Console.WriteLine("Would you like to try again? (Y/N)");
                LoginResponse = Console.ReadLine();

                if (LoginResponse != null && LoginResponse.Trim().ToUpper()[1] == 'Y')
                    goto EnterLogin;
                else if (LoginResponse.Trim().ToUpper()[1] == 'N')
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
                Customer LoginResponse2 = Console.ReadLine();

                if (LoginResponse2.Trim().ToUpper()[2] == 'Y')
                    goto EnterLogin;

                else if (LoginResponse2.Trim().ToUpper()[2] == 'N')
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
            Console.WriteLine($"Welcome {current.FName} to the Art Store");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1]: Shop");
            Console.WriteLine("[2]: View Shopping Cart");
            Console.WriteLine("[3]: View Order History");
            Console.WriteLine("[x]: Logout");

            string? input = Console.ReadLine();

            if (input != null)
                switch (input.Trim().ToUpper()[1])
                {
                    case '1':
                        shopProduct();
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
        }while((!customerLeave));
    }

    public void shopProduct(Customer currentCustomer, StoreFrontId custSelectStoreFront)
    {
  	  Order currentOrder = new Order();
        int count = 0;

        Home();
        Console.WriteLine("Which storefront would you like to shop at?");
	    StoreFrontId ShopProduct = custSelectStoreFront;

        Continue:
        Home();
        Console.WriteLine("Select the art supply you would like to buy.");
        Product shopProducts = SelectProducts(custSelectStoreFront);


        Home();

        ShopConfirmation:
        Console.WriteLine(value: $"Are you sure you would like to add {shopProducts.ArtName} at ${shopProducts.Price} to your cart (Y/N)");
        string? shopConfirm = Console.ReadLine();

        switch (shopconfirm.Trim().ToUpper()[0])
        {
            case 'Y':
                AddToShopCart(current, selectStoreFront, shopProduct, currentOrder, count);
                count++;
                break;
            case 'N':
                Console.WriteLine("Art supply was not added to cart");
                break;
            default:
                Console.WriteLine("Invalid input, Try again");
		    goto ShopConfirmation;
                return;
                
        }
	  
	  
	  if(count > 0)
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

    private Product SelectProducts(StoreFrontId custSelectStoreFront)
    {
        throw new NotImplementedException();
    }

    public void AddToShopCart(Customer currentCustomer, StoreFrontId custSelectStore, Product shopProduct, Order currentOrder, int count)
    {
        if (count == 0)
        {
            currentOrder.OrderCustomerId = currentCustomer.Id;
            currentOrder.GetStoreFrontId = custSelectStore.Id;
        }

        currentOrder.AddShopCartArt(shopProduct);


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
            Console.WriteLine("[1]: View Products");
            Console.WriteLine("[2]: Add Product");
            Console.WriteLine("[x]: Logout");

        	ManagerInput:
            string? mInput = Console.ReadLine();

            switch (mInput.Trim().ToUpper()[1])
            {
                case '1':
                    ViewProduct();
                    break;

                case '2':
                    AddProduct();
                    break;

		    case '3':
                    ReplenishProduct();
                    break;

                case 'X':
                    break;

                default:
                    Console.WriteLine("Input invalid. Please try again.");
                    goto ManagerInput;
            }
        }while(managerExits);

    }
    public StoreFrontId? SelectStoreFront()
    {
        Console.WriteLine("Here are all the StoreFronts by State: ");
        List<StoreFrontId> allStoreFronts = _bl.GetStoreFrontIds();

        if (allStoreFrontIds.Count == 0)
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
    public Product SelectProducts(StoreFront getProductsStoreFront)
    {
        Console.WriteLine($"Here are the art supplies for the {getProductsStore.Store} store:");
        List<Product> Products = _bl.GetProducts(getProductsStoreFront);

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

    private Product SelectProductss(Store getProductStore)
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
        StoreFrontId? viewStoreFront = SelectStoreFront();

        Console.WriteLine($"Below is your product for the Art storefront at the {Street, City, State}: ");
        List<Product> ArtSupply = _bl.GetArtSupply(viewStoreFront);
        if (ArtSupply.Count == 0)
        {
            Console.WriteLine("Sorry that storefront location has sold out in the art supply you selected.");
            return;
        }

        for (int i = 0; i < ArtSupply.Count; i++)
            Console.WriteLine(ArtSupply[i].ToString());

        Console.WriteLine("Please press one key to proceed.");
        string oneKey = Console.ReadLine();
    }

    public void AddProduct()
    {
        Home();

	  EnterProductDetails:
        Console.WriteLine("What is the art supply that you would like to add?");
        string? productName = Console.ReadLine();

        Console.WriteLine("What is the price of this art supply?");

        decimal? productPrice = Convert.ToLong(Console.ReadLine());

        Product newProduct = new Product();

        try
        {
            newProduct.ProductName = productName;
            newProduct.Price = productPrice.Value;
        }
        catch (ValidationException z)
        {
            Console.WriteLine(z.Message);
            goto EnterProductDetails;
        }

        Product createProduct = _bl.CreateProduct(newProduct);
        if (createProduct != null)

        Console.WriteLine("Art Supply created successfully");
    }


    public void ReplenishProduct()
    {
        Home();
        Console.WriteLine("Please choose a location to replenish the art supplies at.");
        StoreFrontId? ReplenishProduct = SelectStoreFront();

        Home();
        Product? ReplenishProduct = SelectInventory(ReplenishProduct);

        Console.WriteLine($"Please enter the new quantity of {ReplenishProduct.ArtName}");
        int newQuantity = Convert.ToInt32(Console.ReadLine());

        _bl.UpdateQuantity(newQuantity, ReplenishProduct);
    }

}
