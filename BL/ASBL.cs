    using DL;
    using Models;

    namespace BL;

    public class Asbl : IAsbl
    {
        public Customer CreateCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

    public Product CreateProduct(CreateProduct newProduct1)
    {
        if (newProduct1 is null)
        {
            throw new ArgumentNullException(nameof(newProduct1));
        }

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


        public int LoginChecker(Customer login)
        {
            return _repo.LoginChecker(login);
        }


        public Product CreateProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

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
}

public class CreateProduct
{
}