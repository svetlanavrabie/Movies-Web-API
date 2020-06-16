
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

            CreateMap<MovieUpdateDto, Movie>()
                .ForMember(m => m.Id, m => m.Ignore())
                .ForMember(m => m.ReleaseDate, m => m.Ignore())
                .ForMember(m => m.DirectorId, m => m.Ignore())
                .ForMember(m => m.Director, m => m.Ignore());
        }
    }
}
