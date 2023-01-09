﻿using System;
using BevNet.Movies.Backend.CrossCutting;
using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Domain.Contracts;
using BevNet.Movies.Backend.Infrastructure.Contracts;
using BevNet.Movies.Backend.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BevNet.Movies.Backend.Domain.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IMemoryCache memoryCache;
        private readonly MemoryCacheEntryOptions cacheOptions;


        public MoviesService(IMoviesRepository moviesRepository, IMemoryCache memoryCache)
        {
            this.moviesRepository = moviesRepository;
            this.memoryCache = memoryCache;

            this.cacheOptions = new MemoryCacheEntryOptions();
            this.cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            this.cacheOptions.SetSlidingExpiration(TimeSpan.FromMinutes(5));
        }

        public async Task<MoviesSearchResult> GetMovies(string title="", int page=1)
        {
            MoviesSearchResult result = memoryCache.Get<MoviesSearchResult>($"{page}-{title.ToLowerInvariant()}");
            if (result == null) {
                result = await moviesRepository.SearchMovies(title, page);
                memoryCache.Set<MoviesSearchResult>($"{page}-{title.ToLowerInvariant()}", result, this.cacheOptions);
            }
            return result;
        }
    }
}

