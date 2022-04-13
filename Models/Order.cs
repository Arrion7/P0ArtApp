using System.ComponentModel.DataAnnotations;

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
        get => _CustomerId;
        set
        {
            if (value
                <= 0)
                throw new ValidationException("Invalid customer ID.");
            _CustomerId = value;
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
        _StoreFrontId = value;
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