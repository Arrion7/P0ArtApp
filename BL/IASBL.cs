using Models;

namespace BL;

public interface IAsbl
{
    Customer CreateCustomer(Customer newCustomer);
    int LoginChecker(Customer login);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newProduct, Product newProduct1);
    Product GetProduct(int id);
    List<Product> GetProducts()
    {
        return GetProducts(null);
    }

    List<Product> GetProducts(StoreFrontId? getProductStore);
    List<StoreFrontId> GetStoreFrontIds();
    Order UpdateOrders(Order updateOrder);
}