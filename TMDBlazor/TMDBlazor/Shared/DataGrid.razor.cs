using Microsoft.AspNetCore.Components;

namespace TMDBlazor.Shared;

/// <summary>
///     Représente une liste d'élément.
/// </summary>
/// <typeparam name="T">Type d'élément à représenter.</typeparam>
public partial class DataGrid<T>
{
    /// <summary>
    ///     Obtient ou définit la liste d'élément.
    /// </summary>
    [Parameter]
    public List<T> Items { get; set; } = new List<T>();

    /// <summary>
    ///     Obtient ou définit le nom de la propriété à appeler sur <see cref="T"/>
    ///     pour obtenir la représentation textuelle de l'élément.
    /// </summary>
    [Parameter]
    public string? DisplayMemberPath { get; set; }

    /// <summary>
    ///     Obtient ou définit une référence vers une méthodes qui prend en paramètre
    ///     une instance de <see cref="T"/> et retourne la représentation textuelle de l'élément.
    /// </summary>
    [Parameter]
    public Func<T, string>? DisplaySelector { get; set; }

    /// <summary>
    ///     Obtient ou définit un template pour représenter un élément de type <see cref="T"/>.
    /// </summary>
    [Parameter]
    public RenderFragment<T>? ItemTemplate { get; set; }

    /// <summary>
    ///     Obtient ou définit l'élément sélectionné.
    /// </summary>
    [Parameter]
    public T? SelectedItem { get; set; }

    /// <summary>
    ///     Evénement déclenché lorsqu'un élément sélectionné change.
    /// </summary>
    [Parameter]
    public EventCallback<T> SelectedItemChanged { get; set; }
}
