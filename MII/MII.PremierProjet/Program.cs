namespace MII.PremierProjet;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Contact contact = new Contact()
        {
            FirstName = "Benjamin",
            LastName = "DAGUÉ"
        };

        Console.WriteLine(contact.ToString());

    }
}