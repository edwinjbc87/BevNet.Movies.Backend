using System;
using BevNet.Movies.Backend.CrossCutting;
using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Domain.Contracts;
using BevNet.Movies.Backend.Infrastructure.Contracts;
using BevNet.Movies.Backend.Infrastructure.Models;

namespace BevNet.Movies.Backend.Domain.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;


        public MoviesService(IMoviesRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public async Task<MoviesSearchResult> GetMovies(string title="", int page=1)
        {
            return await moviesRepository.SearchMovies(title, page);
        }

        public async Task<Movie> GetMovieById(string id)
        {
            return await moviesRepository.GetById(id);
        }
    }
}

