using final_p0.Models;
using Models;

namespace BL;

public interface IAsbl
{
    Customer CreateCustomer(Customer newCustomer);
    int LoginChecker(Customer login);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newProdct);
    Product GetProduct(int id);
    List<Product> GetProducts()
    {
        return GetProducts(null);
    }

    List<Product> GetProducts(StoreFrontId getProductStore);
    List<StoreFront> GetStoreFronts();
    Order UpdateOrders(Order updateOrder);
}