namespace AddressBook;

/// <summary>
///     Représente un contact dans le carnet d'adresse.
/// </summary>
public class Contact
{
    #region Properties
    
    /// <summary>
    ///     Obtient ou définit le prénom de la personne.
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    ///     Obtient ou définit le nom de la personne.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Obtient ou définit la date de naissance de la personne.
    /// </summary>
    public DateTime? Birthdate { get; set; }

    /// <summary>
    ///     Obtient ou définit l'adresse email de la personne.
    /// </summary>
    public string? EMailAddress { get; set; }

    #endregion
}
