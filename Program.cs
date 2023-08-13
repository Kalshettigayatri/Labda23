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

    public int GetNumberOfPersonsByCity(string city)
    {
        return personsByCity.ContainsKey(city) ? personsByCity[city].Count : 0;
    }

    public int GetNumberOfPersonsByState(string state)
    {
        return personsByState.ContainsKey(state) ? personsByState[state].Count : 0;
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
        int numberOfPersonsInCity = addressBook.GetNumberOfPersonsByCity(searchCity);
        Console.WriteLine($"Number of persons in {searchCity}: {numberOfPersonsInCity}");

        string searchState = "California";
        int numberOfPersonsInState = addressBook.GetNumberOfPersonsByState(searchState);
        Console.WriteLine($"Number of persons in {searchState}: {numberOfPersonsInState}");
    }
}
