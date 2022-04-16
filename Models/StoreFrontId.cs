    using System.ComponentModel.DataAnnotations;
    using Models;

    public class StoreFront 
    {
        private string Street = "";
        private string City = "";
        private string State = "";
        private string Zip = "";
    public readonly object Name;

    public string StoreFrontStreet
        {
            get => Street;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ValidationException("Field cannot be left empty");
                
                Street = value.Trim();
            }
        }
        public string StoreFrontCity
        {
            get => City;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ValidationException("Field cannot be left empty");
                
                City = value.Trim();
            }
        }
        public string StoreFrontState
        {
            get => State;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ValidationException("Field cannot be left empty");
                
                State = value.Trim();
            }
        }

        public String StoreFrontZip
        {
            get => Zip;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ValidationException("Field cannot be left empty");
                
                Zip = value.Trim();
            }
        }


        public DisplayStoreFrontInv()
        {
            int i = 1;
            foreach(Product product in StoreFrontInv)
            {
                Console.WriteLine($"{i} {product.ArtName} | S{product.Price} | {product.Quantity} QTY.{product.Details}");
            }              
        }
    }

