using System;

/*Main program class that runs the application*/
class Program
{
    static void Main()
    {
        var contactManager = new ContactManager(); // Initialize ContactManager
        while (true)
        {
            // Display menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. List Contacts");
            Console.WriteLine("2. Create Contact");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    contactManager.ListContacts(); // List all contacts
                    break;
                case "2":
                    contactManager.CreateContact(); // Create a new contact
                    break;
                case "3":
                    return; // Exit the application
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
