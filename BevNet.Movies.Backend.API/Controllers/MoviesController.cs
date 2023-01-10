using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BevNet.Movies.Backend.CrossCutting.Entities;
using BevNet.Movies.Backend.Domain.Contracts;
using BevNet.Movies.Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BevNet.Movies.Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly ILogger<MoviesController> logger;

        public MoviesController(IMoviesService moviesService, ILogger<MoviesController> logger)
        {
            this.moviesService = moviesService;
            this.logger = logger;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<MoviesSearchResult>> Get(string title="", int page=1)
        {
            MoviesSearchResult result = null;
            try
            {
                result = await moviesService.GetMovies(title, page);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Hubo un error en el servicio.");
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

