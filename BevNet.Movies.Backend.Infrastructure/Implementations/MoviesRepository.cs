using System;
using System.Net.Http;
using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Infrastructure.Contracts;
using BevNet.Movies.Backend.Infrastructure.Models;
using Newtonsoft.Json;

namespace BevNet.Movies.Backend.Infrastructure.Implementations
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly HttpClient httpClient;

        public MoviesRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<MoviesSearchResult> SearchMovies(string title, int page=1)
        {
            var resp = await httpClient.GetAsync($"?Title={title}&page={page}");
            var content = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MoviesSearchResult>(content);
        }

        public async Task<Movie> GetById(string id)
        {
            Movie movie = new Movie() { imdbID = id, Title = "Test", Year = 2023 };

            return movie;
        }
    }
}

