    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace Models;

    public class Order : ExtraData
    {
        private decimal total = 0.00M;
        private List<Product> cartArt = new List<Product>();
        private int CustomerId = 0;
        private int StoreFrontId = 0;
        int numId; 


        public DateTime DateCreated {get; set;}

        public void AddTotal(decimal addPrice)
        {
            total += addPrice;
        }

        public decimal Total()
        {
            return total;
        }

        public int OrderCustomerId
        {
            get => OrderCustomerId;
            set
            {
                if (numId <= 0)
                    throw new ValidationException("Invalid customer ID.");

                OrderCustomerId = numId;
            }
        }

        public int OrderStoreFrontId
        {
        get => StoreFrontId;
        set
        {
            if(numId <= 0)
                throw new ValidationException("Invalid input.");

            StoreFrontId = numId;
        }
        }

        public void AddShopCartArt(Product addition)
        {
            cartArt.Add(addition);
            AddTotal(addition.Price);
        }

        public List<Product> CartArt ()
        {
            return cartArt;
        }
    }