using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Category { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(2500)]
        public DateTime ReleaseDate { get; set; }

        public Guid DirectorId { get; set; }

        public Director Director { get; set; }
    }
}
