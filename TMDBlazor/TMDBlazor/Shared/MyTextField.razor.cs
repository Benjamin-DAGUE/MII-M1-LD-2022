using Microsoft.AspNetCore.Components;

namespace TMDBlazor.Shared;

/// <summary>
///		Permet d'afficher un texte avec la prise en charge d'un mode nuit.
/// </summary>
public partial class MyTextField
{
	#region Properties

	/// <summary>
	///		Obtient ou définit le texte à afficher.
	/// </summary>
	[Parameter]
	public string? Text { get; set; }

	#endregion

}
