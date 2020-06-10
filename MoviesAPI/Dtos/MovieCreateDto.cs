using System;

namespace MoviesAPI.Dtos
{
    public class MovieCreateDto
    {
        public Guid DirectorId { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
