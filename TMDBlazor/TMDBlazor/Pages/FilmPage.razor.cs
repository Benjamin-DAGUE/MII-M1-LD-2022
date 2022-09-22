using Microsoft.AspNetCore.Components;
using TMDbLib.Objects.Movies;

namespace TMDBlazor.Pages;

/// <summary>
///		Page d'un film.
/// </summary>
public partial class FilmPage
{
	#region Properties

	/// <summary>
	///		Obtient ou définit l'identifiant du film à afficher.
	/// </summary>
	[Parameter]
	public int Identifier { get; set; }

	/// <summary>
	///		Obtient ou définit le film.
	/// </summary>
	public Movie? Movie { get; set; }

	#endregion

	#region Methods

	/// <inheritdoc/>
	protected override async Task OnParametersSetAsync()
	{
        if (Identifier > 0)
        {
			//Lorsque l'identifiant est défini, on appel en async l'API pour récupérer le film correspondant.
            Movie = await DataClient.GetMovieAsync(Identifier);
        }
    }

	#endregion
}
