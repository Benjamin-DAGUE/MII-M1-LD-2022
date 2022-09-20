using Blaztermind.Model;

namespace Blaztermind.Pages;

/// <summary>
///     Page principal de l'application.
/// </summary>
public partial class Index
{
    #region Properties

    /// <summary>
    ///     Obtient ou définit la combinaison à trouver.
    /// </summary>
    private Combination RandomCombination { get; set; } = new Combination();

    /// <summary>
    ///     Obtient ou définit la liste des combinaisons de l'utilisateur.
    /// </summary>
    public List<Combination> Combinations { get; set; } = new List<Combination>();

    /// <summary>
    ///     Obtient ou définit si la triche est activée.
    /// </summary>
    private bool Cheat { get; set; }

    /// <summary>
    ///     Obtient ou définit le générateur de nombre aléatoire.
    /// </summary>
    private Random RndGen { get; set; } = new Random();

    #endregion

    #region Methods

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        base.OnInitialized();

#if DEBUG
        Cheat = true;
#endif 
        NewGame();
    }

    /// <summary>
    ///     Permet de démarrer une nouvelle partie.
    /// </summary>
    private void NewGame()
    {
        Combinations.Clear();
        RandomCombination.Color1 = (GameColor)RndGen.Next(0, 4);
        RandomCombination.Color2 = (GameColor)RndGen.Next(0, 4);
        RandomCombination.Color3 = (GameColor)RndGen.Next(0, 4);
        RandomCombination.Color4 = (GameColor)RndGen.Next(0, 4);
        RandomCombination.Color5 = (GameColor)RndGen.Next(0, 4);
        Snackbar.Add($"Let's GO !");
        InvokeAsync(StateHasChanged);
    }

    /// <summary>
    ///     Méthode délenchée lorsqu'une combinaison est validée par l'utilisateur.
    /// </summary>
    /// <param name="combination">Combinaison validée par l'utilisateur.</param>
    private void CombinationValidated(Combination combination)
    {
        //On ajoute la combinaison à l'historique des combinaisons saisies.
        Combinations.Add(combination);

        //Si les combinaisons sont les mêmes.
        if (combination.IsCombinationEquals(RandomCombination) == true)
        {
            Snackbar.Add($"Félicitation, vous avez trouvé la solution en {Combinations.Count} tentative(s) !", MudBlazor.Severity.Success, config =>
            {
                config.VisibleStateDuration = int.MaxValue;
                config.Action = "Recommencer";
                config.ActionColor = MudBlazor.Color.Primary;
                config.Onclick = snackbar =>
                {
                    NewGame();
                    return Task.CompletedTask;
                };
            });
            
            if (Cheat)
            {
                Snackbar.Add($"CHEATER", MudBlazor.Severity.Error);
            }
        }
    }

    #endregion
}
