namespace Blaztermind.Model;

/// <summary>
///     Représente une combinaison de couleurs.
/// </summary>
public class Combination
{
    #region Properties

    /// <summary>
    ///     Obtient la couleur à un index spécifié.
    /// </summary>
    /// <param name="index">Index pour lequel récupérer la couleur.</param>
    /// <returns>Couleur à l'index spécifié.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Déclenchée si l'index spécifié n'est pas compris entre 0 et 4.</exception>
    public GameColor this[int index]
    {
        get => index switch
        {
            0 => Color1,
            1 => Color2,
            2 => Color3,
            3 => Color4,
            4 => Color5,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    /// <summary>
    ///     Obtient ou définit la couleur 1.
    /// </summary>
    public GameColor Color1 { get; set; }

    /// <summary>
    ///     Obtient ou définit la couleur 2.
    /// </summary>
    public GameColor Color2 { get; set; }

    /// <summary>
    ///     Obtient ou définit la couleur 3.
    /// </summary>
    public GameColor Color3 { get; set; }

    /// <summary>
    ///     Obtient ou définit la couleur 4.
    /// </summary>
    public GameColor Color4 { get; set; }

    /// <summary>
    ///     Obtient ou définit la couleur 5.
    /// </summary>
    public GameColor Color5 { get; set; }

    #endregion

    #region Methods

    /// <summary>
    ///     Permet de vérifier si la combinaison est égale ou non.
    /// </summary>
    /// <param name="combination">Combinaison à comparer.</param>
    /// <returns>Vrai si les combinaisons sont identiques.</returns>
    public bool IsCombinationEquals(Combination combination)
    {
        bool result = false;

        for (int i = 0; i < 5; i++)
        {
            result = combination[i] == this[i];
            if (result == false)
            {
                break;
            }
        }

        return result;
    }

    #endregion
}
