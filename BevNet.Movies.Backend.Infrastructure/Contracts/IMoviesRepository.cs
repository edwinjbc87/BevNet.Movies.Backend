using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Infrastructure.Models;

namespace BevNet.Movies.Backend.Infrastructure.Contracts
{
    public interface IMoviesRepository
    {
        Task<MoviesSearchResult> SearchMovies(string title, int page = 1);
    }
}