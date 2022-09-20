using Blaztermind.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blaztermind.Shared;

/// <summary>
///		Composant de sélection d'une combinaison.
/// </summary>
public partial class CombinationPicker
{
	#region Properties

	/// <summary>
	///		Obtient ou définit la combinaison sélectionnée.
	/// </summary>
	[Parameter]
	public Combination SelectedCombination { get; set; } = new Combination();

	/// <summary>
	///		Obtient ou définit une méthode déclenchée lorsque la combinaison est validée.
	/// </summary>
	[Parameter]
    public EventCallback<Combination> CombinationValidated { get; set; }

	#endregion

	#region Methods

	/// <summary>
	///		Déclenchée lorsque le bouton de validation est cliqué.
	/// </summary>
	/// <param name="args"></param>
	private void OnValidatedClicked(MouseEventArgs args)
	{
        Combination c = SelectedCombination;
        CombinationValidated.InvokeAsync(c);
        SelectedCombination = new Combination();
    }

	#endregion
}
