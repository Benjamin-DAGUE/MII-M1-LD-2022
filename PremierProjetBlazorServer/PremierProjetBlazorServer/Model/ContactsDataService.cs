using System.Text.Json;

namespace PremierProjetBlazorServer.Model;

public class ContactsDataService
{
    #region Fields

    private string _FilePath;

    /// <summary>
    ///     Liste des contacts.
    /// </summary>
    private List<Contact> _Contacts = new List<Contact>();

    #endregion

    #region Constructors

    /// <summary>
    ///     Initialise une nouvelle instance de la classe <see cref="ContactsDataService"/>.
    /// </summary>
    public ContactsDataService(string filePath)
    {
        _FilePath = filePath;
        LoadContacts();

#if DEBUG

        if (_Contacts.Count == 0)
        {
            _Contacts.Add(new Contact()
            {
                Identifier = 1,
                FirstName = "Benjamin",
                LastName = "DAGUÉ",
                Birthdate = new DateTime(1987, 12, 24),
                Email = "benjamin.dague@etskirsch.fr"
            });
        }

#endif
    }

    #endregion

    #region Methods

    private List<Contact> LoadContacts()
    {
        List<Contact> results = new List<Contact>();

        try
        {
            results = JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText(_FilePath)) ?? results;
        }
        catch
        {

        }

        return results;
    }

    public void SaveChanges() => File.WriteAllText(_FilePath, JsonSerializer.Serialize(_Contacts));

    public List<Contact> GetAllContacts() => _Contacts;

    public Contact? GetContact(int identifier) =>
        _Contacts.FirstOrDefault(c => c.Identifier == identifier);

    public List<Contact> GetNextBirthdateContacts() => _Contacts; //TODO : Filtrer les trois prochains anniversaires.

    public void AddContact(Contact contact) => _Contacts.Add(contact);

    public void DeleteContact(Contact contact) => _Contacts.Remove(contact);

    #endregion

}
