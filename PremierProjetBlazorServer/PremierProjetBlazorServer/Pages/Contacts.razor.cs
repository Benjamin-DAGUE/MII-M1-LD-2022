using PremierProjetBlazorServer.Model;

namespace PremierProjetBlazorServer.Pages;

public partial class Contacts
{
	#region Properties

	private List<Contact>? Items { get; set; }

	#endregion

	#region Methods

	protected override void OnInitialized()
	{
		base.OnInitialized();

        Items = ContactsDataService.GetAllContacts();
	}

	private void DeleteContact(Contact contact)
	{
		if (Items != null)
		{
			Items.Remove(contact);
			ContactsDataService.DeleteContact(contact);
			ContactsDataService.SaveChanges();
		}
    }

	#endregion
}
