using Microsoft.AspNetCore.Components;
using PremierProjetBlazorServer.Model;

namespace PremierProjetBlazorServer.Pages;

public partial class ContactCard
{
	#region Properties

	[Parameter]
	public Contact? Contact { get; set; }

	#endregion

}
