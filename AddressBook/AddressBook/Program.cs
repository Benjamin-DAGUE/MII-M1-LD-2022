using System;
using System.Linq;
using System.Text.Json;

namespace AddressBook;

public class Program
{
    #region Fields

    /// <summary>
    ///		Carnet d'adresse.
    /// </summary>
    private static List<Contact> _Contacts = new List<Contact>();

    #endregion

    #region Methods

    /// <summary>
    ///     Point d'entrée du programme.
    /// </summary>
    public static void Main()
    {
#if DEBUG
        _Contacts = LoadFakeData();
#else
		_Contacts = LoadFromFile("data.json");
#endif

        bool exit = false;

        #region Main Menu

        do
        {
            Console.WriteLine("Bienvenue dans le carnet d'adresse .NET Console !");
            Console.WriteLine("1 : Parcourir le carnet");
            Console.WriteLine("2 : Ajouter une personne");
            Console.WriteLine("3 : Rechercher une personne");
            Console.WriteLine("0 : Quitter");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    exit = true;
                    break;
                case "1":
                    ReadContact(_Contacts);
                    break;
                case "2":
                    AddContact();
                    break;
                case "3":
                    Search();
                    break;
                default:
                    break;
            }

            Console.Clear();

        } while (exit == false);

        #endregion

#if RELEASE
        SaveToFile(_Contacts, "data.json");
#endif
    }

    #region Save/Load data

    /// <summary>
    ///     Charge les données du carnet depuis un fichier.
    /// </summary>
    /// <param name="filePath">Chemin du fichier à charger.</param>
    /// <returns>Liste des contacts présents dans le fichier.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static List<Contact> LoadFromFile(string filePath)
    {
        List<Contact> results = new List<Contact>();
        
        try
        {
            results = JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText(filePath)) ?? results;
        }
        catch (Exception ex)
        {

        }

        return results;
    }

    /// <summary>
    ///     Sauvegarde le carnet dans un fichier.
    /// </summary>
    /// <param name="contacts">Liste des contacts à sauvegarder.</param>
    /// <param name="filePath">Chemin du fichier.</param>
    /// <exception cref="NotImplementedException"></exception>
    public static void SaveToFile(List<Contact> contacts, string filePath) => 
        File.WriteAllText(filePath, JsonSerializer.Serialize(contacts));

#if DEBUG

    /// <summary>
    ///     Charge un faux carnet.
    /// </summary>
    /// <returns>Liste des contacts de test.</returns>
    public static List<Contact> LoadFakeData() => new List<Contact>()
    {
        new Contact() { FirstName = "Benjamin", LastName = "DAGUE", Birthdate = new DateTime(1987, 12, 24) },
        new Contact() { FirstName = "Jean", LastName = "DUPONT", Birthdate = new DateTime(1989, 7, 7) },
        new Contact() { FirstName = "Luc", LastName = "MARTIN", Birthdate = new DateTime(1967, 3, 15) }
    };

#endif

#endregion

    /// <summary>
    ///     Permet la lecture d'un carnet de contacts.
    /// </summary>
    /// <param name="contacts">Liste des contacts.</param>
    /// <param name="searchTerm">Terme recherché.</param>
    private static void ReadContact(List<Contact> contacts, string? searchTerm = null)
    {
        bool exit = false;
        int currentIndex = 0;

        do
        {
            Console.Clear();

            if (string.IsNullOrWhiteSpace(searchTerm) == false)
            {
                Console.WriteLine("Voici les résultats pour la recherche suivante :");
                Console.WriteLine(searchTerm);
            }

            if (contacts.Count == 0)
            {
                Console.WriteLine(searchTerm == null ? "Le carnet est vide" : "Aucun résultat");
                Console.WriteLine("Appuyez sur une touche pour retourner au menu principal...");
                Console.ReadKey();
                exit = true;
                break;
            }

            Contact contact = contacts[currentIndex];

            //Console.WriteLine($"Prénom : " + contact.FirstName);
            //Console.WriteLine(string.Format("Prénom : {0}", person.FirstName));
            Console.WriteLine($"Prénom : {contact.FirstName}");
            Console.WriteLine($"Nom : {contact.LastName}");
            Console.WriteLine($"Date de naissance : {contact.Birthdate:d}");
            Console.WriteLine($"EMail : {contact.EMailAddress}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 : Suivant");
            Console.WriteLine("2 : Précédent");
            Console.WriteLine("3 : Supprimer");
            Console.WriteLine("0 : Retour");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    //Retour au menu principal.
                    exit = true;
                    break;
                case "1":
                    //On va à la personne suivante ou au début du carnet si on est à la fin.
                    currentIndex = currentIndex + 1 == contacts.Count ? 0 : currentIndex + 1;
                    break;
                case "2":
                    //On va à la personne précédente ou à la fin du carnet si on est au début.
                    currentIndex = currentIndex - 1 < 0 ? contacts.Count - 1 : currentIndex - 1;
                    break;
                case "3":
                    //On supprime la personne de la liste en cours de lecture.
                    contacts.Remove(contact);
                    //On supprime du carnet également sur la liste en cours de lecture n'est pas le carnet (cas de la recherche).
                    if (searchTerm != null)
                    {
                        _Contacts.Remove(contact);
                    }
                    //On change l'index si on supprime la personne à la fin de la liste pour prendre la personne précédente.
                    currentIndex = currentIndex >= contacts.Count ? contacts.Count - 1 : currentIndex;
                    break;
                default:
                    break;
            }
        } while (exit == false);
    }

    /// <summary>
    ///     Permet l'ajout d'un contact dans le carnet.
    /// </summary>
    private static void AddContact()
    {
        Console.Clear();

        Contact contact = new Contact();

        Console.Write("Prénom : ");
        contact.FirstName = Console.ReadLine();

        Console.Write("Nom : ");
        contact.LastName = Console.ReadLine();

        Console.Write("Date de naissance : ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
        {
            contact.Birthdate = birthDate;
        }

        Console.Write("Email : ");
        contact.EMailAddress = Console.ReadLine();

        _Contacts.Add(contact);
    }

    /// <summary>
    ///     Permet de rechercher dans le carnet.
    /// </summary>
    private static void Search()
    {
        IEnumerable<Contact> query = _Contacts;
        string searchTherms = "";
        Console.Clear();
        
        Console.Write("Rechercher dans le prénom : ");
        string? search = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(search) == false)
        {
            string searchFirstName = search;
            query = query
                .Where((contact) => contact.FirstName?.ToLower()?.Contains(searchFirstName.ToLower()) == true);
            searchTherms += $"Prénom : {search}{Environment.NewLine}";
        }

        Console.Write("Rechercher dans le nom : ");
        search = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(search) == false)
        {
            string searchLastName = search;
            query = query
                .Where((contact) => contact.LastName?.ToLower()?.Contains(searchLastName.ToLower()) == true);
            searchTherms += $"Nom : {search}{Environment.NewLine}";
        }

        ReadContact(query.ToList(), searchTherms);
    }

#endregion
}