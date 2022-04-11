namespacee models;


public class Customer : ExtraData
{
    private string _fname = "";

    private string _lname = "";
    private string _cpass = "";

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
    public string CPass
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

    public Customer(string email)
    {
        this.Email = email;
    }

    public Customer()
    {
        throw new NotImplementedException();
    }


    public List<> OrderHistory { get; set; } = new List();
}


