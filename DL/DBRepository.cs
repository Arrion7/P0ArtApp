using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace DL;
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStore, object currentStoreFront)
    {

        List<Product> StoreFrontInv = new List<Product>();

        DataSet StoreFrontInvSet = new DataSet();

        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT StoreFront, ProductId, Product.Name as ProductName, Details, Price, Quantity FROM StoreFrontInv JOIN Product ON (Product.Id = ProductId) JOIN StoreFront ON (StoreFront.Id = StoreFront) WHERE StoreFront = @id;", connection);
        SqlParameter sqlParameter = cmd.Parameters.AddWithValue("@id", currentStoreFront.Id);

        SqlDataAdapter StoreFrontInvAdapter = new SqlDataAdapter(cmd);

        StoreFrontInvAdapter.Fill(StoreFrontInvSet, "StoreFrontInvTable");
        DataTable? StoreFrontInvTable = StoreFrontInvSet.Tables["StoreFrontInvTable"];
        if (StoreFrontInvTable != null && StoreFrontInvTable.Rows.Count > 0)
        {
            foreach (DataRow row in StoreFrontInvTable.Rows)
            {
                Product product = new Product();

                product.Id = (int)row["ProductId"];
                product.Name = (string)row["ProductName"];
                product.Details = (string)row["Details"];
                product.Price = (decimal)row["Price"];
                product.Quantity = (int)row["Quantity"];

                StoreFrontInv.Add(product);
            }
        }
        currentStoreFront.StoreFrontInv = StoreFrontInv;

        return (StoreFront)currentStoreFront;
    }

    public List<Customer> GetAllCustomers()
    {

        List<Customer> Customers = new List<Customer>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string CustomerName = reader.GetString(1);
            string CPassword = reader.GetString(2);

            Customer Customer = new Customer
            {
                Id = id,
                CustomerFname = Customerfname;
                CustomerLname = Customerlname;
                CustomerEmail = Customeremail;
                CustomerStreet = Customerstreet;
                CustomerCity = Customercity;
                CustomerState = Customerstate;
                CustomerZip = Customerzip;
                CPassword = Cpassword;
        };
        Customers.Add(Customer);
    }

    public Customer CreateCustomer(Customer newCustomer)
    {
        throw new NotImplementedException();
    }

    public int LoginValid(Customer login)
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Product CreateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(StoreFront getProduct)
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetStoreFrontFronts()
    {
        throw new NotImplementedException();
    }

    public Order UpdateOrders(Order updateOrder)
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetStoreFronts()
    {
        throw new NotImplementedException();
    }

        public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            throw new NotImplementedException();
        }

        public List<OrderHistory> GetOrderHistoryC(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void CreateShopCart(Order order)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateStoreFrontInv(Order order)
        {
            throw new NotImplementedException();
        }

        reader.Close();
        connection.Close();

        return Customers;
    }

    public List<StoreFront> GetAllStoresFronts()
    {
    List<StoreFront> StoreFronts = new List<StoreFront>();

    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM StoreFront", connection);
    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        string address = reader.GetString(2);

        Store store = new Store
        {
            Id = id,
            Name = name,
            Address = address
        };

        StoreFronts.Add(StoreFront);
    }

    reader.Close();
    connection.Close();

    return StoreFronts;
    }


    public List<OrderHistory>? GetOrderHistoryC Customer)
    {
        List<OrderHistory> OrderHistoryC = new List<OrderHistory>();
        List<StoreFront> StoreFront = GetAllStoreFronts();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT StoreFront, Orders.Id, CustomerId, DateOrdered, Quantity, Product.Name, Product.Price, TotalPrice Orders JOIN Cart ON (Cart.OrderId = Orders.Id) JOIN StoreFront ON (StoreFront.Id = Orders.StoreFront) JOIN Product ON (Product.Id = Cart.ProductId) WHERE CustomerId = @CustomerId ORDER BY StoreFront;", connection);
        cmd.Parameters.AddWithValue("@CustomerId", Customer.Id);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            
    int id = reader.GetInt32(0);
    int storeId = reader.GetInt32(1);
    DateTime date = reader.GetDateTime(3);
    int ProductQty = reader.GetInt32(4);
    string ProductName = reader.GetString(5);
    decimal ProductPrice = reader.Getdecimal(6);
    decimal totalPrice = reader.Getdecimal(7);

    OrderHistory order = new OrderHistory
    {
    OrderId = id,
    ProductName = ProductName,
    StoreFront = StoreFront,
    TotalPrice = totalPrice,
    ProductPrice = ProductPrice,
    ProductQty = ProductQty,
    DateOrdered = date,
    };

            foreach (StoreFront StoreFront in StoreFront)
            {
                if (StoreFront.Id == StoreFront)
                {
                    Order.StoreFront = StoreFront;
                    break;
                }
            }

            CustomerOrderHistory.Add(order);
        }
        connection.Close();

    return CustomerOrderHistory;

    public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
    {
    List<OrderHistory> OrderHistorySF = new List<OrderHistory>();
    List<Customer> Customers = GetAllCustomers();

    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("SELECT Orders.Id, CustomerId, DateOrdered, Quantity, Product.Name, TotalCost, StoreFront, Price FROM Orders JOIN Cart ON (Cart.OrderId = Orders.Id) JOIN StoreFront ON (StoreFront.Id = Orders.StoreFront) JOIN Product ON (Product.Id = Cart.ProductId) WHERE StoreFront = @storeId ORDER BY StoreFront;", connection);
    cmd.Parameters.AddWithValue("@sStoreFront", _StoreFront.Id);

    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        int id = reader.GetInt32(0);
        int CustomerId = reader.GetInt32(1);
        DateTime date = reader.GetDateTime(2);
        int ProductQty = reader.GetInt32(3);
        string ProductName = reader.GetString(4);
        decimal totalCost = reader.Getdecimal(5);
        int StoreFront = reader.GetInt32(6);
        decimal ProductPrice = reader.Getdecimal(7);

        OrderHistory order = new OrderHistory
        {
            OrderId = id,
            ProductName = ProductName,
            StoreFront = StoreFront,
            TotalCost = totalCost,
            ProductQty = ProductQty,
            DateOrdered = date,
            ProductPrice = ProductPrice
        };

        foreach (Customer Customer in Customers)
        {
            if (CustomerId == Customer.Id)
            {
                order.Customer = Customer;
                break;
            }
        }
        OrderHistorySF.Add(order);
    }

    reader.Close();
    connection.Close();

    return OrderHistorySF;
    }

    public Customer CreateCustomer(Customer CustomerToAdd)
    {
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO Customers(CustomerName, Cpassword) OUTPUT INSERTED.Id VALUES(@Customername, @Cpassword)", connection);

    cmd.Parameters.AddWithValue("@Customername", CustomerToAdd.CustomerName);
    cmd.Parameters.AddWithValue("@Cpassword", CustomerToAdd.Cpassword);

    try
    {
        CustomerToAdd.Id = (int)cmd.ExecuteScalar();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    connection.Close();

    return CustomerToAdd;
    }

    public void CreateOrder(Order order)
    {
    DateTime currentDate = DateTime.Now;
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO Orders(StoreFront, CustomerId, TotalPrice, DateOrdered) OUTPUT INSERTED.Id VALUES (@StoreFront, @CustomerId, @totalPrice, @dateOrdered)", connection);

    cmd.Parameters.AddWithValue("@StoreFront", order.StoreFront.Id);
    cmd.Parameters.AddWithValue("@CustomerId", order.Customer.Id);
    cmd.Parameters.AddWithValue("@totalPrice", order.cart.GetTotalPrice());
    cmd.Parameters.AddWithValue("@dateOrdered", currentDate);

    try
    {
        order.Id = (int)cmd.ExecuteScalar();
    }
    catch (Exception z)
    {
        Console.WriteLine(z.Message);
    }

    connection.Close();
    CreateShopCart(order);
    }

    void CreateShopCart(Order order)
    {
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    SqlCommand cmd;

    foreach (Product product in order.ShopCart.AllProducts())
    {
        cmd = new SqlCommand("INSERT INTO Cart (ProductId, Quantity, OrderId) OUTPUT INSERTED.Id VALUES (@productId, @quantity, @orderId)", connection);
        cmd.Parameters.AddWithValue("@productId", product.Id);
        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
        cmd.Parameters.AddWithValue("@orderId", order.Id);

        int id = (int)cmd.ExecuteScalar();
    }

    connection.Close();

    UpdateStoreFrontInv(order);

    void AddProduct(Product product)
    {
    // Add new product to database
    }

    void UpdateStoreFrontInv(Order order)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd;

    foreach (Product product in order.StoreFront.StoreFrontInv)
    {
        cmd = new SqlCommand("UPDATE StoreFrontInv SET Quantity = @quantity OUTPUT INSERTED.Id WHERE ProductId = @productId AND StoreFront = @StoreFront", connection);
        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
        cmd.Parameters.AddWithValue("@productId", product.Id);
        cmd.Parameters.AddWithValue("@storeFront", order.StoreFront.Id);

        int id = (int)cmd.ExecuteScalar();
    }

    connection.Close();
    }
}
