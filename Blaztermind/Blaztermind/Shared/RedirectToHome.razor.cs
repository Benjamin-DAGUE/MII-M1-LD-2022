namespace Blaztermind.Shared;

/// <summary>
///     Composant qui redirige l'utilisateur sur la page d'accueil dès qu'il est affiché.
///     Peut être utilisée par exemple dans App au niveau du NotFound.
/// </summary>
public partial class RedirectToHome
{
    #region Methods

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavMan.NavigateTo("/", true);
    }

    #endregion
}
