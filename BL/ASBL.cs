    using DL;
    using Models;

    namespace BL;

    public class Asbl : IAsbl
    {
        public Customer CreateCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }


    private Product CreateProduct(Func<Product, Product, Product> createProduct, Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProduct(StoreFrontId? GetProducttore)
        {
            throw new NotImplementedException();
        }

        public List<StoreFrontId> GetStoreFrontIds()
        {
            throw new NotImplementedException();
        }

        public List<StoreFrontId> GetStoreFronts()
        {
            throw new NotImplementedException();
        }

        public int LoginChecker(Customer login)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrders(Order updateOrder)
        {
            throw new NotImplementedException();
        }

        List<StoreFrontId> IAsbl.GetStoreFrontIds()
        {
            throw new NotImplementedException();
        }
    
        private readonly IRepository
   

    internal class _repo
    {
        internal static Product GetProduct(object id)
        {
            throw new NotImplementedException();
        }

        internal static int LoginChecker(Customer login)
        {
            throw new NotImplementedException();
        }

        internal static Order UpdateOrders(Order updateOrder)
    {
        throw new NotImplementedException();
    }
}

    public Order UpdateOrder(Order UpdateOrder)
        {
            return _repo.UpdateOrders(UpdateOrder);
        }

    public Product CreateProduct(Product newProduct, Product newProduct1)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(StoreFrontId? getProductStore)
    {
        throw new NotImplementedException();
    }
}

public class CreateProduct
{
}