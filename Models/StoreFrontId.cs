using System;
using System.Diagnostics;

namespace Models;

public class NewBaseType
{
    NewStruct.IsNullOrWhitespaceNewStruct1 ValidationException(StoreFrontId StoreFrontState)
    {
        if (StoreFrontId is null)
        {
            throw new ArgumentNullException(nameof(StoreFrontId));
        }

        if (string.IsNullOrEmpty(StoreFrontState))
        {
            throw new System.ArgumentException($"'{nameof(StoreFrontState)}' cannot be null or empty.", nameof(StoreFrontState));
        }
    }
}

public interface INewBaseType
{
    string StoreFrontCity { get; set; }

    string GetStoreFrontState();
    void SetStoreFrontState(string value);
    string ToString();
    string ToString();
    string ToString();
}


    public int StoreFrontZip = Convert.ToInt32("");

    public string StoreFrontCity
    {
        get => city;
        set
        {
            if (string.IsNullOrWhitespace(value))
                throw new ValidationException(message: "Field cannot be left empty");

            city = value.Trim();
        }
    }

    public string GetStoreFrontState()
    {
        return State;
    }

    public void SetStoreFrontState(string value)
    {

        if (string.IsNullOrWhitespace(value))



            throw new ValidationException(message: "Field cannot be left empty");

        State = value.Trim();
    }




    public override string ToString() => $"[{streetID}]: {street}";
    public override string ToString()
    {

        return $"[{cityID}]: {city}";

    }

    public override string ToString()
    {


    }

public class StoreFrontId : NewBaseType, ExtraData
{
    public StoreFrontId(string StoreFrontState)
    {
        this.SetStoreFrontState(StoreFrontState);
    

    
        if(zip = value.TrimNewStruct2);
    }

internal record struct NewStruct2(object Item1, object Item2)
{
    public static implicit operator (object, object)(NewStruct2 value)
    {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct2((object, object) value)
    {
        return new NewStruct2(value.Item1, value.Item2);
    }
}

internal record struct NewStruct1(value Art, int StoreFrontzip, string StoreFrontState)
{
    public static implicit operator (value, int StoreFrontzip, string StoreFrontState)(NewStruct1 value)
    {
        return (value.Item1, value.StoreFrontzip, value.StoreFrontState);
    }

    public static implicit operator NewStruct1((value, int StoreFrontzip, string StoreFrontState) value)
    {
        return new NewStruct1(value.Item1, value.StoreFrontzip, value.StoreFrontState);
    }
}

public override string ToString()
{
    return "[{zipID}]: {zip}";
}

}