using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails
{
    public class GetPracticeAreaDetailsQueryHandler : IRequestHandler<GetPracticeAreasDetailsQuery, PracticeAreaDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public GetPracticeAreaDetailsQueryHandler(IMapper mapper, IPracticeAreaRepository practiceAreaRepository)
        {
            this._mapper = mapper;
            this._practiceAreaRepository = practiceAreaRepository;
        }

        public async Task<PracticeAreaDetailDto> Handle(GetPracticeAreasDetailsQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var practiceArea = await _practiceAreaRepository.GetByIdAsync(request.Id);
          
            // verify that record exists
            if (practiceArea == null)
                throw new NotFoundException(nameof(PracticeArea), request.Id);

        
            // var contentArray = practiceArea.Content.Split('$', StringSplitOptions.RemoveEmptyEntries);

            // convert data object to Dto object
            var data = _mapper.Map<PracticeAreaDetailDto>(practiceArea);

       //     data.Content = contentArray;
            //return DTO object
            return data;
        }
    }
}
