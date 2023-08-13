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
    private Dictionary<string, List<Person>> personsByCity = new Dictionary<string, List<Person>>();
    private Dictionary<string, List<Person>> personsByState = new Dictionary<string, List<Person>>();

    public void AddPerson(Person person)
    {
        AddToDictionary(personsByCity, person.City, person);
        AddToDictionary(personsByState, person.State, person);
    }

    private void AddToDictionary(Dictionary<string, List<Person>> dictionary, string key, Person person)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = new List<Person>();
        }
        dictionary[key].Add(person);
    }

    public List<Person> GetPersonsByCity(string city)
    {
        return personsByCity.ContainsKey(city) ? personsByCity[city] : new List<Person>();
    }

    public List<Person> GetPersonsByState(string state)
    {
        return personsByState.ContainsKey(state) ? personsByState[state] : new List<Person>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();

        addressBook.AddPerson(new Person { Name = "John", City = "New York", State = "New York" });
        addressBook.AddPerson(new Person { Name = "Alice", City = "Los Angeles", State = "California" });
        addressBook.AddPerson(new Person { Name = "Bob", City = "New York", State = "New York" });
        addressBook.AddPerson(new Person { Name = "Carol", City = "Los Angeles", State = "California" });

        string searchCity = "New York";
        List<Person> personsInCity = addressBook.GetPersonsByCity(searchCity);
        Console.WriteLine($"Persons in {searchCity}:");
        foreach (var person in personsInCity)
        {
            Console.WriteLine($"Name: {person.Name}, City: {person.City}, State: {person.State}");
        }

        string searchState = "California";
        List<Person> personsInState = addressBook.GetPersonsByState(searchState);
        Console.WriteLine($"Persons in {searchState}:");
        foreach (var person in personsInState)
        {
            Console.WriteLine($"Name: {person.Name}, City: {person.City}, State: {person.State}");
        }
    }
}
