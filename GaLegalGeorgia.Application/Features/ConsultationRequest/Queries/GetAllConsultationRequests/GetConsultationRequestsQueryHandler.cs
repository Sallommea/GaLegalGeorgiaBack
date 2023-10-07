
using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests
{
    public class GetConsultationRequestsQueryHandler : IRequestHandler<GetConsultationRequestsQuery,
        List<ConsultationRequestDto>>
    {
        private readonly IConsultationRequest _consultationRequestRepository;
        private readonly IMapper _mapper;

        public GetConsultationRequestsQueryHandler(IConsultationRequest consultationRequestRepository,
            IMapper mapper)
        {
            this._consultationRequestRepository = consultationRequestRepository;
            this._mapper = mapper;
        }
        public async Task<List<ConsultationRequestDto>> Handle(GetConsultationRequestsQuery request, CancellationToken cancellationToken)
        {
            var consultationRequests = await _consultationRequestRepository.GetAsync();
            var requests = _mapper.Map<List<ConsultationRequestDto>>(consultationRequests);

            return requests;
        }
    }


}
