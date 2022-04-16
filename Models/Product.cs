namespace Models;

public class Product
{
    internal readonly object ArtName;

    public string Name { get; set; } = "";
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Details { get; set; } = "";
    public int Quantity { get; set; } = 0;

}