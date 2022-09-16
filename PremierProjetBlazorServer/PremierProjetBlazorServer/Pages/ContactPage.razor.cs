using Microsoft.AspNetCore.Components;
using PremierProjetBlazorServer.Model;

namespace PremierProjetBlazorServer.Pages;

public partial class ContactPage
{
    #region Fields

    [Parameter()]
    public int Identifier { get; set; }

    public Contact? Contact { get; set;}

    #endregion

    #region Methods

    protected override void OnParametersSet()
    {
        Contact = ContactsDataService.GetContact(Identifier);

        if (Contact == null)
        {
            NavMan.NavigateTo("/contacts");
        }
    }

    #endregion

}
