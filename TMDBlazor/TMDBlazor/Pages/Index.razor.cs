using TMDbLib.Objects.Movies;

namespace TMDBlazor.Pages;

public partial class Index
{
    private List<Movie> Movies { get; set; }

    

    protected override async Task OnInitializedAsync()
    {
        List<Movie> movies = new List<Movie>();
        Movie movie = DataClient.GetMovieAsync(47964).Result;
        movies.Add(movie);
        movie = DataClient.GetMovieAsync(47965).Result;
        movies.Add(movie);

        Movies = movies;
    }
}
