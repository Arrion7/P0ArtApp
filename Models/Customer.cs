using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models;

public interface ICustomer
{
    string FName { get; set; }
    string LName { get; set; }
    string cPass { get; set; }
    string Email { get; set; }
    List<object> OrderHistory { get; set; }
}

public class Customer : ExtraData
{
    private string _fname = "";

    private string _lname = "";
    private string _cPass = "";

    public string FName
    {
        get => _fname;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ValidationException("First name field cannot be left empty");

            _fname = value.Trim();
        }
    }
    public string LName
    {
        get => _lname;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Last name field cannot be left empty");

            _lname = value.Trim();
        }
    }
    public string cPass
    {
        get => _cPass;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Password cannot be left empty");

            _cPass = value.Trim();
        }
    }

    public string Email
    {
        get => Email;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Field cannot be left empty.");

            Email = value.Trim();
        }
    }

    public List<Order> OrderHistory { get => orderHistory; set => orderHistory = value; }
    public List<Order> OrderHistory1 { get => orderHistory; set => orderHistory = value; }

    public Customer(string email)
    {
        this.Email = email;
    }

    public Customer()
    {
        throw new NotImplementedException();
    }

    private List<Order> orderHistory = new List();

    public List<Order> GetOrderHistory()
    {
        return OrderHistory;
    }

    public void SetOrderHistory(List<Order> value)
    {
        OrderHistory = value;
    }
}


