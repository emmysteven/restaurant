using System;
using System.Collections.Generic;
using Restaurant.Domain.Common;

namespace Restaurant.Domain.ValueObjects;

public class Address : ValueObject
{
    public String Street { get; private set; }
    public String City { get; private set; }
    public String State { get; private set; }

    public Address() { }

    public Address(string street, string city, string state)
    {
        Street = street;
        City = city;
        State = state;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Street;
        yield return City;
        yield return State;
    }
}