
namespace Models;
public class Order 
{
    public int Id { get; set; }
    public DateTime DateOrdered { get; set; }
    public Customer Customer = new Customer();
    public ShopCart ShopCart = new ShopCart();
    public StoreFront StoreFront = new StoreFront();
    
}