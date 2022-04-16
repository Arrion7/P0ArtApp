using System.ComponentModel.DataAnnotations;
    using Models;
    

    public class StoreFront 
    {
        private string Street = "";
        private string City = "";
        private string State = "";
        private int Zip = "";

    private string address = $"{Street} + {City} + {State} +{Zip1}";

    public StoreFront(string address)
    {
        Address2 = address;
    }

    public StoreFront()
    {
    }

    public readonly object Name;
    private readonly IEnumerable<Product> StoreFrontInv;

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
            get => Zip1;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ValidationException("Field cannot be left empty");
                
                Zip1 = value.Trim();
            }
        }

    public string Address1 { get => Address2; set => Address2 = value; }
    public string Address2 { get => Address; set => Address = value; }
    public string Address3 { get => Address; set => Address = value; }
    public int Zip1 { get => Zip2; set => Zip2 = value; }
    public int Zip2 { get => Zip; set => Zip = value; }
    public string Address { get => address; set => address = value; }
    public string Address4 { get => address; set => address = value; }

    public void DisplayStoreFrontInv()
        {
            int i = 1;
            foreach(Product product in StoreFrontInv)
            {
                Console.WriteLine($"{i} {product.ArtName} | S{product.Price} | {product.Quantity} QTY.{product.Details}");
            }              
        }
    }

