using AutoMapper;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails;
using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.MappingProfiles
{
    public class ContentResolver : IValueResolver<PracticeArea, PracticeAreaDetailDto, ICollection<string>>
    {
        public ICollection<string> Resolve(PracticeArea source, PracticeAreaDetailDto destination, ICollection<string> destMember, ResolutionContext context)
        {
            try
            {
                return source.Content.Split('$');
            }
            catch
            {
                return default;
            }

        }
    }
    public class PracticeAreaProfile : Profile
    {
        public PracticeAreaProfile()
        {
            CreateMap<PracticeAreaDto, PracticeArea>().ReverseMap();
            CreateMap<PracticeArea, PracticeArea>().ReverseMap();
            CreateMap<CreatePracticeAreaCommand, PracticeArea>();
            CreateMap<UpdatePracticeAreaCommand, PracticeArea>();
            CreateMap<PracticeArea, PracticeAreaDetailDto>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom<ContentResolver>());
        }
    }
}
