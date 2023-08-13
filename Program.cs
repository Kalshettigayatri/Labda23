using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

class AddressBook
{
    private List<Person> contacts = new List<Person>();

    public void AddPerson(Person person)
    {
        contacts.Add(person);
    }

    public List<Person> SearchPersonsByCity(string city)
    {
        return contacts.Where(person => person.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Person> SearchPersonsByState(string state)
    {
        return contacts.Where(person => person.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        AddressBook addressBook1 = new AddressBook();
        AddressBook addressBook2 = new AddressBook();

        // Adding persons to AddressBooks
        addressBook1.AddPerson(new Person { Name = "John", City = "New York", State = "New York" });
        addressBook1.AddPerson(new Person { Name = "Alice", City = "Los Angeles", State = "California" });
        addressBook2.AddPerson(new Person { Name = "Bob", City = "New York", State = "New York" });

        string searchCity = "New York";
        List<Person> personsInCity = addressBook1.SearchPersonsByCity(searchCity);
        Console.WriteLine($"Persons in {searchCity}:");
        foreach (var person in personsInCity)
        {
            Console.WriteLine($"Name: {person.Name}, City: {person.City}, State: {person.State}");
        }

        string searchState = "California";
        List<Person> personsInState = addressBook2.SearchPersonsByState(searchState);
        Console.WriteLine($"Persons in {searchState}:");
        foreach (var person in personsInState)
        {
            Console.WriteLine($"Name: {person.Name}, City: {person.City}, State: {person.State}");
        }
    }
}
