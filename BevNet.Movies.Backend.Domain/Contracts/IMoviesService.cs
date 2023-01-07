using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Infrastructure.Models;

namespace BevNet.Movies.Backend.Domain.Contracts
{
    public interface IMoviesService
    {
        Task<MoviesSearchResult> GetMovies(string title="", int page=1);
        Task<Movie> GetMovieById(string id);
    }
}