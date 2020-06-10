
using AutoMapper;
using MoviesAPI.Dtos;
using MoviesAPI.Entities;

namespace MoviesAPI.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MovieDto>().ForMember(dest => dest.Director,
                opt => opt.MapFrom(src => $"{src.Director.FirstName} {src.Director.LastName}"));

            CreateMap<MovieCreateDto, Movie>();
        }
    }
}
