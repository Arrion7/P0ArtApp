    using System.ComponentModel.DataAnnotations;
    using Models;

    public class StoreFrontId : ExtraData
    {
        private string Street = "";
        private string City = "";
        private string State = "";
        private string Zip = "";
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


        public override string ToString()
        {
            return $"[{StreetId}]: {Street} ";
            return $"[{CityId}]: {City} ";
            return $"[{StateId}]: {State} ";
            return $@"[{{ZipId}}]: {{Zip}} ";
        }
    }