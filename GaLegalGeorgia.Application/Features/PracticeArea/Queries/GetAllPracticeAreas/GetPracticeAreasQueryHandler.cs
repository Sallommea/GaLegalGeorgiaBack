using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Logging;
using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas
{
    public class GetPracticeAreasQueryHandler : IRequestHandler<GetPracticeAreasQuery, List<PracticeAreaDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPracticeAreaRepository _practiceAreaRepository;
        private readonly IAppLogger<GetPracticeAreasQueryHandler> _logger;

        public GetPracticeAreasQueryHandler(IMapper mapper, 
            IPracticeAreaRepository practiceAreaRepository,
            IAppLogger<GetPracticeAreasQueryHandler> logger)
        {
            this._mapper = mapper;
            this._practiceAreaRepository = practiceAreaRepository;
            this._logger = logger;
        }
        public async Task<List<PracticeAreaDto>> Handle(GetPracticeAreasQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var practiceAreas = await _practiceAreaRepository.GetAsync();
            // convert data objects to dto objects
            var data =  _mapper.Map<List<PracticeAreaDto>>(practiceAreas);

            // return list of dto object
            _logger.LogInformation("Practice Areas were retrieved successfully");
            return data;
        }
    }
}
