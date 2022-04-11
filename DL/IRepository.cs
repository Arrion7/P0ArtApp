using Models;

namespace DL;

public interface IRepository
{
    Customer CreateCustomer(Customer newCustomer);
    int LoginChecker(Customer login);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newPro);
    Product GetProduct(int id);
    List<Product> GetProducts(Store getInv);
    List<Store> GetStoreFronts();
    Order UpdateOrders(Order updateOrder);
}
