using System;
using BevNet.Movies.Backend.CrossCutting.Entities;

namespace BevNet.Movies.Backend.Infrastructure.Models
{
	public class MoviesSearchResult
	{
		public int page { get; set; }
		public int per_page { get; set; }
		public int total { get; set; }
		public int total_pages { get; set; }
		public IEnumerable<Movie> data { get; set; }

		public MoviesSearchResult()
		{
			data = new List<Movie>();
		}
	}
}

