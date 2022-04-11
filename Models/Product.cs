namespace Models;

public class Product : ExtraData
{
    private string _artName = "";

    private decimal _price = 0.00M;

    public string ArtName
    {
        get => _artName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Field cannot be left empty");
            }
            _artName = value.Trim();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
                throw new ValidationException("Price must be greater than 0.");

            _price = value;
        }
    }
}