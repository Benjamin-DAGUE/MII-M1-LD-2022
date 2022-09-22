using Microsoft.AspNetCore.Components;

namespace TMDBlazor.Shared;

//Par défaut, un composant hérite de ComponentBase.
//Ici, on créé un composant de base qui contient un paramètre nommé DarkMode.
//Par exemple, MyTextField est un composant enfant de MyBaseComponent qui exploite DarkMode
public partial class MyBaseComponent : ComponentBase
{
	#region Properties

	/// <summary>
	///		Obtient ou définit si le mode nuit est actif ou non.
	/// </summary>
	[Parameter]
	public bool DarkMode { get; set; }

	#endregion
}
