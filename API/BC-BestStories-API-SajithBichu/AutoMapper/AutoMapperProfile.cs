using AutoMapper;

namespace BC_BestStories_API_SajithBichu
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BestStoriesModel, BestStoriesDTOModel>()
                .ForMember(dest=>dest.postedBy, opt => opt.MapFrom(src=> src.by))
                .ForMember(dest => dest.time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(src.time)).DateTime.ToString()))
                .ForMember(dest => dest.commentCount, opt => opt.MapFrom(src => src.descendants));
        }
    }
}
