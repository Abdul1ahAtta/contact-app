using NUnit.Framework;
using System.IO;

[TestFixture]
public class ContactManagerTests
{
    private ContactManager _contactManager;

    [SetUp]
    public void SetUp()
    {
        _contactManager = new ContactManager();
        if (File.Exists("contacts.json"))
        {
            File.Delete("contacts.json");
        }
    }

    [Test]
    public void CreateContact_ShouldAddContact()
    {
        // Arrange
        var initialCount = _contactManager.LoadContacts().Count;

        // Act
        _contactManager.CreateContact();

        // Assert
        var finalCount = _contactManager.LoadContacts().Count;
        Assert.AreEqual(initialCount + 1, finalCount);
    }

    [Test]
    public void ListContacts_ShouldReturnAllContacts()
    {
        // Arrange
        _contactManager.CreateContact();
        _contactManager.CreateContact();

        // Act
        var contacts = _contactManager.LoadContacts();

        // Assert
        Assert.IsTrue(contacts.Count >= 2);
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists("contacts.json"))
        {
            File.Delete("contacts.json");
        }
    }
}
