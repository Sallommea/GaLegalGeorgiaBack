using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using GaLegalGeorgia.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.Admin.Queries.getUser
{
    public class AdminQueryHandler : IRequestHandler<AdminQuery,AdminDto>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
           _adminRepository = adminRepository;
           _mapper = mapper;
        }
        public async Task<AdminDto> Handle(AdminQuery request, CancellationToken cancellationToken)
        {
        
            var admins = await _adminRepository.GetAsync();
            var first = admins.First();
            var admin = _mapper.Map<AdminDto>(first);
            return admin;

        }
    }
}
