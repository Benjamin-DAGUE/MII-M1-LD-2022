namespace PremierProjetBlazorServer.Model;

/// <summary>
///     Représente un contact.
/// </summary>
public class Contact
{
    /// <summary>
    ///     Obtient ou définit l'identifiant du contact.
    /// </summary>
    public int Identifier { get; set; }

    /// <summary>
    ///     Obtient ou définit le prénom du contact.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Obtient ou définit le nom du contact.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Obtient ou déifnit la date de naissance du contact.
    /// </summary>
    public DateTime? Birthdate { get; set; }

    /// <summary>
    ///     Obtient ou définit l'adresse email du contact.
    /// </summary>
    public string? Email { get; set; }
}
