using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
namespace Models;

public interface INewBaseType
{
    string StoreFrontCity { get; set; }

    string GetStoreFrontState();
    void SetStoreFrontState(string value);
}

public class StoreFrontId : ExtraData
{
    public StoreFrontId(string StoreFrontState)
    {
        this.SetStoreFrontState(StoreFrontState);
    }

    private void SetStoreFrontState(string storeFrontState)
    {
        throw new NotImplementedException();
    }

    internal record struct NewStruct2(object Item1, object Item2, object StoreFrontCity)
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

internal record struct NewStruct1(value Art, int StoreFrontzip, string StoreFrontState, object StoreFrontCity)
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