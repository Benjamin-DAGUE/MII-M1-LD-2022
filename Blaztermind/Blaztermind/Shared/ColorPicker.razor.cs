using Blaztermind.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blaztermind.Shared;

/// <summary>
///		Composant de sélection d'une couleur dans une combinaison.
/// </summary>
public partial class ColorPicker
{
	#region Properties

	/// <summary>
	///		Obtient ou définit la couleur sélectionnée.
	/// </summary>
	[Parameter]
	public GameColor SelectedColor { get; set; } = GameColor.White;

	/// <summary>
	///		Obtient ou définit un événement qui est déclenchée lorsque la couleur sélectionnée change.
	/// </summary>
	[Parameter]
	public EventCallback<GameColor> SelectedColorChanged { get; set; }

    #endregion

    #region Methods

    /// <summary>
    ///		Changement vers la couleur suivante.
    /// </summary>
    /// <param name="args"></param>
    private void SelectNextColor(MouseEventArgs args)
	{
        SelectedColor = SelectedColor == GameColor.Blue ? GameColor.White : (GameColor)((int)SelectedColor + 1);
        SelectedColorChanged.InvokeAsync(SelectedColor);
    }

	/// <summary>
	///		Changement vers la couleur précédente.
	/// </summary>
	/// <param name="args"></param>
    private void SelectPreviousColor(MouseEventArgs args)
    {
        SelectedColor = SelectedColor == GameColor.White ? GameColor.Blue : (GameColor)((int)SelectedColor - 1);
        SelectedColorChanged.InvokeAsync(SelectedColor);
    }

    #endregion

}
