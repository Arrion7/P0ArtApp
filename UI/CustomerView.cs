using Models;

namespace UI;

public class CustomerView
{
    private readonly IAsbl _bl;
    private Customer _Customer = new Customer();
    private ShopCart ShopCart = new ShopCart();
    private StoreFront currentStoreFront = new StoreFront();

    public CustomerView(IAsbl bl, Customer Customer)
    {
        _bl = bl;
        _Customer = Customer;
    }

    public void ArtHome()
    {
        List<StoreFront> StoreFronts = _bl.GetAllStoreFronts();

        Console.WriteLine("==================================================================");

        StoreFrontLocation:
        Console.WriteLine("Select a StoreFront to start shopping or View your order history"); 

        int i = 1;
        foreach (StoreFront StoreFront in StoreFronts)
        {
            Console.WriteLine($"[{i}] {StoreFront.Name} | { StoreFront.Address}");
            i++;
        }

        Console.WriteLine($"[{i}] View Order History");
        Console.WriteLine($"[x] Logout");

        string StoreFrontAnswer = Console.ReadLine().Trim();
        Console.WriteLine("==================================================================");

        if (StoreFrontAnswer == "1")
        {
            currentStoreFront = StoreFronts[1];
        }
        else if (StoreFrontAnswer == "2")
        {
            currentStoreFront = StoreFronts[2];
        
        }
        else if (StoreFrontAnswer.ToLower() == "x")
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid Input");
            goto StoreFrontLocation;
        }

        currentStoreFront = _bl.getStoreFrontInv(currentStoreFront);
        string result = Home();

        if (result == "3")
        {
            goto StoreFrontLocation;
        }
    }

    private string Home()
    {
        Options:
        Console.WriteLine("[1] Add product to ShopCart");
        Console.WriteLine("[2] View ShopCart");
        Console.WriteLine("[3] Checkout");
        Console.WriteLine("[4] Change StoreFront location.");
        Console.WriteLine("[x] Logout");

        string Option = Console.ReadLine().Trim().ToLower();
        Console.WriteLine("==================================================================");

        switch (Option)
        {
            case "1":
                AddProduct();
                Console.WriteLine("==================================================================");
                break;

            case "2":
                if (ShopCart.IsShopCartEmpty())
                {
                    Console.WriteLine("ShopCart is empty.");
                }
                
                else
                {
                    bool CheckingOut = GetCheckingOut();

                    if (CheckingOut)
                    {
                        return "x";
                    }
                }
                break;

            case "3":
                if (ShopCart.IsShopCartEmpty())
                {
                    return Option;
                }
                else
                {
                    DifferentSF:
                    Console.WriteLine("Are you sure you want to change to a different location? All products that are in your ShopCart will be emptied. [Y/N]");
                    string Cresponse = Console.ReadLine().Trim().ToUpper();

                    if (Cresponse == "Y")
                    {
                        ShopCart.EmptyShopCart();
                        Console.WriteLine("Your ShopCart is now empty.");
                        Console.WriteLine("==================================================================");

                        return Option;
                    }
                    else if (Cresponse == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        goto DifferentSF;
                    }
                }

            case "x":
                return Option;

            default:
                Console.WriteLine("Invalid Input");
                break;
        }
        goto Options;

        bool GetCheckingOut()
        {
            return Checkout();
        }
    }

    private void AddProduct()
    {
        ArtSupplyToAdd:
        StoreFrontInv();
        Console.WriteLine("==================================================================");

        Console.WriteLine("Which Art Supply would you like to add:");
        string Option = Console.ReadLine().Trim();
        int productId;

        //Explain 

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../Logs/ExceptionLogging.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try
        {
            productId = Convert.ToInt32(Option);
        }
        catch (Exception z)
        {
            Console.WriteLine($"Invalid Input");
            Log.Information($"Exception Caught: {z}");
            goto ArtSupplyToAdd;
        }
        finally
        {
            Log.CloseAndFlush();
        }

        if (productId > currentStoreFront.StoreFrontInv.Count || productId < 0)
        {
            Console.WriteLine("Invalid Input");
            goto ArtSupplyToAdd;
        }

        foreach (Product product in currentStoreFront.StoreFrontInv)
        {
            if (product.Id == productId)
            {
            QuantityArt:
                Console.WriteLine("How many would you like:");
                int qty;

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File("../Logs/ExceptionLogging.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                try
                {
                    qty = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception z)
                {
                    Console.WriteLine($"Invalid Input");
                    Log.Information($"Exception Caught: {z}");
                    goto QuantityArt;
                }
                finally
                {
                    Log.CloseAndFlush();
                }

                if (qty > product.Quantity)
                {
                    Console.WriteLine("[The current StoreFront does not have the requested quantity.");
                    goto QuantityArt;
                }

                Product ArtSupply = new Product();

                ArtSupply.Id = product.Id;
                ArtSupply.Name = product.Name;
                ArtSupply.Price = product.Price;
                ArtSupply.Details = product.Details;
                ArtSupply.Quantity = qty;

                for (int i = 0; i < currentStoreFront.StoreFrontInv.Count; i++)
                {
                    if (productId == currentStoreFront.StoreFrontInv[i].Id)
                    {
                        currentStoreFront.StoreFrontInv[i].Quantity -= qty;
                    }
                }

                ShopCart.AddArtSupply(ArtSupply);
            }
        }
    }

    Product product;

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../Logs/ExceptionLogging.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

                foreach (Product ArtSupply in currentStoreFront.StoreFrontInv)
    {
            if (ArtSupply.Name == product.Name)
            {
                ArtSupply.Quantity += product.Quantity;
            }
        }
    }

    private bool Checkout()
    {
        CheckoutOption:
        ShopCart.ShopCartContents();
        Console.WriteLine("==================================================================");

        Console.WriteLine("Are you ready to checkout? [Y/N]");
        string Option = Console.ReadLine().Trim().ToUpper();

        if (Option == "Y")
        {
            Console.WriteLine("One moment.");
            Order order = new Order();
            order.customer = _Customer;
            order.ShopCart = ShopCart;
            order.StoreFront = currentStoreFront;
            _bl.AddOrder(order);
            return true;
        }
        else if (Option == "N")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid Input");
            goto CheckoutOption;
        }
    }
    private void StoreFrontInv()
    {
        currentStoreFront.DisplayStoreFrontInv();
    }

    private void ViewOrderHistory()
    {
        List<OrderHistory> CustomerOrderHistory = _bl.GetOrderHistoryByCustomer(_Customer);

        if (CustomerOrderHistory.Count == 0)
        {
            Console.WriteLine("Order History is empty.");
            Console.WriteLine("==================================================================");
            return;
        }

        foreach (OrderHistory order in CustomerOrderHistory)
        {
            Console.WriteLine($"{order.StoreFront.Name} | {order.StoreFront.Address}:\n${order.ArtSupplyPrice} | {order.ProductName} | {order.ArtSupplyQty} QTY. | {order.DateOrdered}");
        }

        Console.WriteLine("==================================================================");
    }
}
