using System;
namespace BevNet.Movies.Backend.CrossCutting.Entities
{
	public class Movie
    {
        public string Title { get; set; }
		public string imdbID { get; set; }
		public int Year { get; set; }

        public Movie()
		{
		}
	}
}

