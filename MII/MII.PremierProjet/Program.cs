using System.Data;

namespace MII.PremierProjet;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Contact contact = new Contact();

        Console.Write("Prénom : ");

        //FirstName déclare ne pas accepter les valeurs null.
        //il est alors nécessaire de tester la nullité de ReadLine()
        //car la méthode retourne un type string? qui accepte les valeurs null
        contact.FirstName = Console.ReadLine() ?? "";

        Console.Write("Nom : ");
        contact.LastName = Console.ReadLine();

        Console.WriteLine(contact.ToString());

        List<Contact> contacts = new List<Contact>();

        contacts.Add(contact);

        for (int i = 0; i < contacts.Count; i++)
        {
            Contact c = contacts[i];
        }

        foreach (Contact c in contacts)
        {

        }



    }

}