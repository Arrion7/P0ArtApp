using Microsoft.Data.SqlClient;
using Models;

namespace DL;
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Creates Customer
    /// </summary>
    /// <param name="customerAdd"></param>
    /// <returns></returns>

    public Customer CreateCustomer(Customer customerAdd)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO Customers(cName, Cpassword) OUTPUT INSERTED.Id VALUES(@cName, @Cpassword)", connection);

        cmd.Parameters.AddWithValue("@cName", customerAdd.cName);
        cmd.Parameters.AddWithValue("@Cpassword", customerAdd.Cpassword);

        try
        {
            customerAdd.Id = (int)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        connection.Close();

        return customerAdd;

    }
    
    public void CreateOrder(Order order)
    {
        DateTime currentDate = DateTime.Now;
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO Orders(StoreFrontId, CustomerId, TotalPrice, DateOrdered) OUTPUT INSERTED.Id VALUES (@StoreFrontId, @customerId, @totalprice, @dateOrdered)", connection);

        cmd.Parameters.AddWithValue("@StoreFrontId", order.StoreFront.Id);
        cmd.Parameters.AddWithValue("@customerId", order.customer.Id);
        cmd.Parameters.AddWithValue("@totalprice", order.ShopCart.GetTotalPrice());
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

    public void CreateShopCart(Order order)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
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
            string cName = reader.GetString(1);
            string Cpassword = reader.GetString(2);

            Customer Customer = new Customer
            {
                Id = id,
                cName = cName,
                Cpassword = Cpassword,
            };
            Customers.Add(Customer);
        }

        reader.Close();
        connection.Close();

        return Customers;

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

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    public void UpdateStoreFrontInv(Order order)
    {
        
    }

}