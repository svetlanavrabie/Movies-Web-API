using System;

namespace MoviesAPI.Dtos
{
    public class MovieUpdateDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
