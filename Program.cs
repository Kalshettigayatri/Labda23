using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Person otherPerson = (Person)obj;
        return Name.Equals(otherPerson.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Name.ToLower().GetHashCode();
    }
}

class AddressBook
{
    private List<Person> contacts = new List<Person>();

    public void AddPerson(Person person)
    {
        if (!contacts.Contains(person))
        {
            contacts.Add(person);
            Console.WriteLine($"Added {person.Name} to the address book.");
        }
        else
        {
            Console.WriteLine($"{person.Name} is already in the address book.");
        }
    }

    public Person SearchPersonByName(string name)
    {
        return contacts.Find(person => person.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();

        Person person1 = new Person { Name = "John", PhoneNumber = "123-456-7890" };
        Person person2 = new Person { Name = "Alice", PhoneNumber = "987-654-3210" };
        Person person3 = new Person { Name = "John", PhoneNumber = "555-123-4567" }; // Duplicate

        addressBook.AddPerson(person1);
        addressBook.AddPerson(person2);
        addressBook.AddPerson(person3);

        Person searchResult = addressBook.SearchPersonByName("john");
        if (searchResult != null)
        {
            Console.WriteLine($"Found {searchResult.Name} in the address book.");
        }
        else
        {
            Console.WriteLine("Person not found in the address book.");
        }
    }
}
