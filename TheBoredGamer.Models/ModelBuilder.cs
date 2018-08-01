using System.Linq;
using AutoMapper;
using TheBoredGamer.Models.BoardGameGeek;

namespace TheBoredGamer.Models
{
    public class ModelBuilder
    {
        private readonly IMapper _mapper;

        public ModelBuilder()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, Game>()
                    .ForMember(dest => dest.BoardGameGeekId, opt => opt.MapFrom(src => int.Parse(src.Id)))
                    //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.FirstOrDefault(x => x.Type == "primary")))
                    ;
            });

            _mapper = config.CreateMapper();
        }

        public Game GetGameFromItem(Item item)
        {
            return _mapper.Map<Item, Game>(item);
        }
    }
}
