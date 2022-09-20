using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PremierProjetBlazorServer.Model;

namespace PremierProjetBlazorServer.Pages;

public partial class ContactPage
{
    #region Fields

    [Parameter()]
    public int Identifier { get; set; }

    private Contact? Contact { get; set; }

    private bool IsAddContact { get; set; }

    #endregion

    #region Methods

    protected override void OnParametersSet()
    {
        if (Identifier != 0)
        {
            Contact = ContactsDataService.GetContact(Identifier);

            if (Contact == null)
            {
                NavMan.NavigateTo("/contacts");
            }
        }
        else
        {
            IsAddContact = true;
            Contact = new Contact();
        }
    }

    private void OnSaveButtonClicked(MouseEventArgs args)
    {
        if (Contact != null)
        {
            try
            {
                if (IsAddContact)
                {
                    ContactsDataService.AddContact(Contact);
                }
                ContactsDataService.SaveChanges();
                SnackbarService.Add($"Le contact a bien été {(IsAddContact ? "ajouté" : "enregistré")}.", MudBlazor.Severity.Success);
                IsAddContact = false;
                NavMan.NavigateTo($"/contacts/{Contact.Identifier}");
            }
            catch
            {
                SnackbarService.Add("Erreur lors de la sauvegarde.", MudBlazor.Severity.Error);
            }
        }
    }

    #endregion
}
