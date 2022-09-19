using System.Text;

namespace CoursDelegate;

public class Program
{
    //Predicate est un délégué, c'est un type qui va permettre de stocker
    // une référence vers une méthode avec la signature suivante :
    //   La méthode retourne un booléen et prend un paramètre un entier.
    public delegate bool Predicate(int x);

    public static void Main()
    {
        #region delegate

        int[] ints = { 1, 2, 3 };

        //Exemple d'utilisation d'un délégué
        Predicate p = IsEven; //On stock dans p une référence vers la méthode IsEven
        p.Invoke(ints[1]);    //On invoque/appel la méthode stockée dans p

        //Func et Action sont des délégués générique.
        //Func retourne une valeur alors que Action retourne rien (void)

        //Ici, Func<int, bool> créé un délégué avec la signature suivante :
        //   La méthode retourne un booléen et prend un paramètre un entier.
        Func<int, bool>? filterMethod = null;

        //On peut alors affecter la référence à l'adresse d'une méthode existante
        filterMethod = IsEven;
        //Ou créer une méthode anonyme.
        filterMethod = x => x % 2 == 0;


        IEnumerable<int>? results = null;

        // on peut ensuite passer cette référence à une autre méthode en paramètre
        results = ints.Where(filterMethod);
        //Ou créer une méthode anonyme pour la passer à Where directement.
        results = ints.Where(x => x % 2 == 0);

        //Le code ci-dessous démontre que l'utilisation d'une méthode anonyme
        //permet d'accéder à une variable qui est dans la portée englobante

        //On récupère une valeur demandée à l'utilisateur
        int maxNumber = int.Parse(Console.ReadLine());

        //On veut les nombres entiers dont la valeur est suppérieur à la valeur saisie
        results = ints.Where(i => i > maxNumber);

        //IEnumerable<int> est une requête qui sera exécutée uniquement lorsqu'un foreach
        //sera appelé sur la requête.
        //ToList() peut également être utilisé, puisque ToList fait un foreach en interne.
        foreach (int item in results)
        {
            Console.WriteLine(item);
        }

        #endregion

        //Ici, la classe Worker est un exemple d'utilisation de delegate pour
        //créer des méthodes de rappels
        Worker worker = new Worker();
        
        worker.DoWork();

        worker.DoWork(() =>
        {
            Console.WriteLine("Working...");
        },
        () =>
        {
            Console.WriteLine("Work ended");
        });

        //WorkerEvent démontre une implémentation à l'aide d'un événement.
        //Un événement est une liste de delegate qui va avoir 0 ou plusieurs abonnés.
        WorkerEvent workerEvent = new WorkerEvent();
        
        //On ajoute avec += une référence vers la méthode dans la liste des delegate
        //-= peut être utilisé pour désabonné une méthode.
        workerEvent.Started += WorkerEvent_Started; 
        workerEvent.DoWork();

        Console.ReadLine();
        Console.WriteLine("Program ended");
    }

    private static void WorkerEvent_Started(object? sender, EventArgs e)
    {
        Console.WriteLine("Working...");
    }

    //La méthode ci-dessous présente l'implémentation interne de la méthode Where.
    //La méthode Where utilise un yield return dans le foreach
    //yield return permet de créer une méthode qui retourne plusieurs valeurs.
    //A chaque valeur retournée, l'appel exécutera le code appelant puis reviendra dans le foreach pour passer à l'exécution suivante. 
    //public static IEnumerable<int> Where(this IEnumerable<int> list,
    //    Func<int, bool> filter)
    //{
    //    foreach (int item in list)
    //    {
    //        if (filter(item))
    //        {
    //            yield return item;
    //        }
    //    }
    //}

    public static bool IsEven(int x) => x % 2 == 0;
}