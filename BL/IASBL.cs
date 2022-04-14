using Models;

namespace BL;

public interface IAsbl
{
    Customer CreateCustomer(Customer newCustomer);
    int LoginValid(Customer login);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newProduct);
    Product GetProducts(int id);
    List<Product> GetProducts()
    {
        return GetProducts(null);
    }

    List<Product> GetProducts(StoreFrontId? getProductStore);
    List<StoreFrontId> GetStoreFrontIds();
    Order UpdateOrders(Order updateOrder);
}