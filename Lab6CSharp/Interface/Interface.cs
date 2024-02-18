using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Interface;

interface Phone_Directory : IEnumerable<Phone_Directory>
{
    void DisplayInfo();
    bool MatchesSearch(string searchTerm);
}

class Person : Phone_Directory
{
    protected string name;
    protected string address;
    protected string phoneNumber;

    public Person(string name, string address, string phoneNumber)
    {
        this.name = name;
        this.address = address;
        this.phoneNumber = phoneNumber;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Person: {name}");
        Console.WriteLine($"address: {address}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
    }

    public bool MatchesSearch(string searchTerm)
    {
        return name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }

    public IEnumerator<Phone_Directory> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Organization : Phone_Directory
{
    protected string name;
    protected string address;
    protected string phoneNumber;
    protected string fax;
    protected string contactPerson;

    public Organization(
        string name,
        string address,
        string phoneNumber,
        string fax,
        string contactPerson
    )
    {
        this.name = name;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.fax = fax;
        this.contactPerson = contactPerson;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Organization: {name}");
        Console.WriteLine($"address: {address}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        Console.WriteLine($"Fax: {fax}");
        Console.WriteLine($"Contact Person: {contactPerson}");
    }

    public bool MatchesSearch(string searchTerm)
    {
        return name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }

    public IEnumerator<Phone_Directory> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Friend : Phone_Directory
{
    protected string name;
    protected string address;
    protected string phoneNumber;
    protected DateTime dateOfBirth;

    public Friend(string name, string address, string phoneNumber, DateTime dateOfBirth)
    {
        this.name = name;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.dateOfBirth = dateOfBirth;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Friend: {name}");
        Console.WriteLine($"address: {address}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        Console.WriteLine($"Date of Birth: {dateOfBirth.ToShortDateString()}");
    }

    public bool MatchesSearch(string searchTerm)
    {
        return name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }

    public IEnumerator<Phone_Directory> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    public static void Task()
    {
        Phone_Directory[] directory = new Phone_Directory[]
        {
            new Person("Doe", "123 Main St", "555-1234"),
            new Organization("ABC Inc.", "456 Oak St", "555-5678", "555-5679", "John Smith"),
            new Friend("Johnson", "789 Elm St", "555-4321", new DateTime(1990, 5, 20)),
            // Add more entries as needed
        };

        Console.WriteLine("Full Information:");
        DisplayDirectoryInfo(directory);

        Console.Write("Enter a name to search: ");
        string searchname = Console.ReadLine();

        Console.WriteLine("\nSearch Results:");
        SearchAndDisplay(directory, searchname);

        Console.WriteLine("\nForeach Statement:");
        UseForeach(directory);
    }

    static void DisplayDirectoryInfo(Phone_Directory[] directory)
    {
        foreach (var entry in directory)
        {
            entry.DisplayInfo();
            Console.WriteLine("------------------------------");
        }
    }

    static void SearchAndDisplay(Phone_Directory[] directory, string searchTerm)
    {
        var searchResults = directory.Where(entry => entry.MatchesSearch(searchTerm));

        UseForeach(searchResults);
    }

    static void UseForeach(IEnumerable<Phone_Directory> directory)
    {
        foreach (var entry in directory)
        {
            entry.DisplayInfo();
            Console.WriteLine("------------------------------");
        }
    }
}
