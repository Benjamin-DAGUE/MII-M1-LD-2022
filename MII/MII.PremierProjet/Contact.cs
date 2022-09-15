namespace MII.PremierProjet;

internal class Contact : object
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

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

    #region Constructors

    ////Il existe un constructeur par défaut sans argument.
    ////Ce constructeur n'est plus créé à partir du moment où un constructeur est défini.
    //public Contact(string lastName, string firstName = null)
    //{
    //    FirstName = firstName;
    //    //Constructeur
    //}
    #endregion

    public override string ToString() => FirstName + " " + LastName;
}
