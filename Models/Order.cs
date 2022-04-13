    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace Models;

    public class Order : ExtraData
    {
        private decimal total = 0.00M;
        private List<Product> cartArt = new List<Product>();
        private int CustomerId = 0;
        private int StoreFrontId = 0;


        public DateTime DateCreated {get; set;}

        public void AddTotal(decimal addPrice)
        {
            total += addPrice;
        }

        public decimal Total()
        {
            return total;
        }

        public int CustomerId
        {
            get => CustomerId;
            set
            {
                if (numId <= 0)
                    throw new ValidationException("Invalid customer ID.");

                CustomerId = numId;
            }
        }

        Public int StoreFrontId
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