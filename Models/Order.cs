namespace Models;

public abstract class Order : ExtraData
{
    private decimal _total = 0.00M;

    private readonly List _cartArt = new List();

    private int _CustomerId = 0;

    private int _StoreFrontId = 0;

    public DateTime DateCreated { get; set; }

    public void AddTotal(decimal addPrice)
    {
        _total += addPrice;
    }

    public decimal Total()
    {
        return _total;
    }

    public int CustomerId
    {
        get => _customerId;
        set
        {
            if (value
                <= 0)
                throw new ValidationException("Invalid customer ID.");
            _customerId = value;
        }
    }

    public global::System.Int32 GetStoreFrontId()
    {
        return GetStoreFrontId();
    }
    public void SetStoreFrontId(global::System.Int32 value)
    {
        if (value
            <= 0)
            throw new ValidationException("Invalid StoreFront ID.");
        _storeFrontId = value;
    }

    public void AddShopCartArt(Product addition)
    {
        _cartArt.Add(addition);
        AddTotal(addition.Price);
    }

    public List CartArt()
    {
        return _cartArt;
    }



}