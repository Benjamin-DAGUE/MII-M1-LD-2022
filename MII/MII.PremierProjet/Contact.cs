namespace MII.PremierProjet;

/// <summary>
///     Représente un contact.
/// </summary>
internal class Contact : object
{
    #region Properties

    /// <summary>
    ///     Obtient ou définit le prénom du contact.
    /// </summary>
    public string FirstName { get; set; } = "";

    /// <summary>
    ///     Obtient ou définit le nom du contact.
    /// </summary>
    public string? LastName { get; set; }

    #region propfull
    //private string _FirstName;

    //public string FirstName
    //{
    //    get { return _FirstName; }
    //    set { _FirstName = value; }
    //}


    //private string _LastName;
    ////La syntaxe suivante utilise la notion de "bodied"
    //public string LastName
    //{
    //    get => _LastName;
    //    set => _LastName = value?.ToUpper(); 
    //}
    #endregion

    #endregion

    #region Constructors

    ////Il existe un constructeur par défaut sans argument.
    ////Ce constructeur n'est plus créé à partir du moment où un constructeur est défini.
    //public Contact(string lastName, string firstName = null)
    //{
    //    FirstName = firstName;
    //    //Constructeur
    //}
    #endregion

    #region Methods

    public override string ToString() => FirstName + " " + LastName;

    #endregion
}
