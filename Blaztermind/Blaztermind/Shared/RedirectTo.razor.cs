using Microsoft.AspNetCore.Components;

namespace Blaztermind.Shared;

/// <summary>
///     Composant qui redirige l'utilisateur sur la page d'accueil dès qu'il est affiché.
///     Peut être utilisée par exemple dans App au niveau du NotFound.
/// </summary>
public partial class RedirectTo
{
    #region Methods

    [Parameter]
    public string Route { get; set; } = "/";

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavMan.NavigateTo(Route, true);
    }

    #endregion
}
