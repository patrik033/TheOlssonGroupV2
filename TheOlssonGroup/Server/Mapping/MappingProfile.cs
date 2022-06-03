using AutoMapper;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;



namespace TheOlssonGroup.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDtoRecord>()
                .ForCtorParam("GenreName",
                opt => opt.MapFrom(x => string.Join(' ', x.Genre.GenreName)));

            CreateMap<UserOrdersDto, UserOrder>().ReverseMap();

        }
    }
}
