using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Manages operations related to contacts (create, list, save, load)
public class ContactManager
{
    private readonly string _filePath = "contacts.json"; // Path to save contacts
    private List<Contact> _contacts; // List to hold contacts in memory

    // Constructor that loads contacts from the file on startup
    public ContactManager()
    {
        _contacts = LoadContacts();
    }

    // Lists all contacts in the console
    public void ListContacts()
    {
        if (_contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
        }
        else
        {
            Console.WriteLine("Contact List:");
            foreach (var contact in _contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
    }

    // Creates a new contact and saves it to the list
    public void CreateContact()
    {
        Console.Write("Enter name: ");
        var name = Console.ReadLine();
        Console.Write("Enter phone number: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Enter email: ");
        var email = Console.ReadLine();

        var newContact = new Contact { Name = name, PhoneNumber = phoneNumber, Email = email };
        _contacts.Add(newContact);
        SaveContacts(); // Save contacts to file

        Console.WriteLine("Contact added successfully.");
    }

    // Saves the contact list to a JSON file
    private void SaveContacts()
    {
        var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    // Loads the contact list from the JSON file
    private List<Contact> LoadContacts()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Contact>();
        }

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
    }
}
