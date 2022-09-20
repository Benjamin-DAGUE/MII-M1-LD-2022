using Blaztermind.Model;
using Microsoft.AspNetCore.Components;

namespace Blaztermind.Shared;

/// <summary>
///     Composant d'affichage d'une comparaison de combinaison avec la solution.
/// </summary>
public partial class CombinationComparer
{
    #region Properties

    /// <summary>
    ///     Obtient ou définit la combinaison sélectionnée.
    /// </summary>
    [Parameter]
    public Combination? SelectedCombination { get; set; }

    /// <summary>
    ///     Obtient ou définit la combinaison solution.
    /// </summary>
    [Parameter]
    public Combination? SolutionCombination { get; set; }

    /// <summary>
    ///     Obtient ou définit le résultat de la couleur 1.
    /// </summary>
    private bool? Color1Result { get; set; } = false;

    /// <summary>
    ///     Obtient ou définit le résultat de la couleur 2.
    /// </summary>
    private bool? Color2Result { get; set; } = false;

    /// <summary>
    ///     Obtient ou définit le résultat de la couleur 3.
    /// </summary>
    private bool? Color3Result { get; set; } = false;

    /// <summary>
    ///     Obtient ou définit le résultat de la couleur 4.
    /// </summary>
    private bool? Color4Result { get; set; } = false;

    /// <summary>
    ///     Obtient ou définit le résultat de la couleur 5.
    /// </summary>
    private bool? Color5Result { get; set; } = false;

    #endregion

    #region Methods

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        //Cette méthode est déclenchée à chaque fois qu'un paramètre change.

        if (SelectedCombination != null && SolutionCombination != null)
        {
            bool[] isColorUsed = new bool[5];

            //Par défaut, on marque toutes les couleurs comme fausses.
            for (int i = 0; i < 5; i++)
            {
                SetColorResultAtIndex(i, null);
            }

            //On cherche les couleurs qui sont exactement les mêmes.
            for (int i = 0; i < 5; i++)
            {
                CheckIsSameColor(ref isColorUsed, i);
            }

            //On recherche ensuite les couleurs mal positionnées.
            for (int i = 0; i < 5; i++)
            {
                //Pour les couleurs qui ne sont pas exactement les mêmes.
                if (isColorUsed[i] == false)
                {
                    SearchSameColor(ref isColorUsed, i);
                }
            }
        }
    }

    /// <summary>
    ///     Obtient le résultat de la couleur à l'index spécifié.
    /// </summary>
    /// <param name="index">Index pour lequel récupérer le résultat.</param>
    /// <returns>Vrai si la couleur correspond, false si elle est mal positionnée, null dans les autres cas.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Peut être déclenchée si l'index spécifié n'est pas entre 0 et 4.</exception>
    private bool? GetColorResultAtIndex(int index)
    {
        return index switch
        {
            0 => Color1Result,
            1 => Color2Result,
            2 => Color3Result,
            3 => Color4Result,
            4 => Color5Result,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    ///     Obtient la classe de coloration pour le résultat de la couleur à l'index spécifié.
    /// </summary>
    /// <param name="index">Index pour lequel récupérer la classe de coloration pour le résultat.</param>
    /// <returns>Classe de coloration à utiliser pour l'index spécifié.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Peut être déclenchée si l'index spécifié n'est pas entre 0 et 4.</exception>
    private string GetClassForColorResultAtIndex(int index)
    {
        return GetColorResultAtIndex(index) switch
        {
            true => "green",
            false => "red",
            null => "white"
        };
    }

    /// <summary>
    ///     Définit le résultat de la couleur à l'index spécifié.
    /// </summary>
    /// <param name="index">Index pour lequel définir le résultat.</param>
    /// <param name="result">Valeur du résultat.</param>
    private void SetColorResultAtIndex(int index, bool? result)
    {
        switch (index)
        {
            case 0:
                Color1Result = result;
                break;
            case 1:
                Color2Result = result;
                break;
            case 2:
                Color3Result = result;
                break;
            case 3:
                Color4Result = result;
                break;
            case 4:
                Color5Result = result;
                break;
            default:
                break;
        }
    }

    /// <summary>
    ///     Permet de vérifier si la couleur est bien positionné.
    /// </summary>
    /// <param name="isColorUsed">Tableau des couleurs déjà utilisé.</param>
    /// <param name="index">Index de la couleur à tester.</param>
    private void CheckIsSameColor(ref bool[] isColorUsed, int index)
    {
        if (SelectedCombination != null && SolutionCombination != null)
        {
            //Si la couleur correspond, on marque la position de la couleur comme utilisée.
            isColorUsed[index] = SelectedCombination[index] == SolutionCombination[index];

            //Si elle est utilisée, on marque alors le résultat de la couleur à vrai.
            if (isColorUsed[index])
            {
                SetColorResultAtIndex(index, true);
            }
        }
    }

    /// <summary>
    ///     Permet de rechercher une couleur similaire non utilisé.
    /// </summary>
    /// <param name="isColorUsed">Tableau des couleurs utilisés.</param>
    /// <param name="index">Index de la couleur à tester.</param>
    private void SearchSameColor(ref bool[] isColorUsed, int index)
    {
        if (SelectedCombination != null && SolutionCombination != null)
        {
            for (int i = 0; i < 5; i++)
            {
                //Si la position comparée n'est pas la même position
                // et si la couleur n'est pas utilisée
                // et si la couleur correspond
                if (index != i && isColorUsed[i] == false && SelectedCombination[index] == SolutionCombination[i])
                {
                    //On marque la position comme utilisée.
                    isColorUsed[i] = true;
                    //On marque le résultat à faux pour indiquer un mauvais placement.
                    SetColorResultAtIndex(index, false);
                }
            }
        }
    }

    #endregion
}
