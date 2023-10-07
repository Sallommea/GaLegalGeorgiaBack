using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests
{
    public class GetConsultationRequestsQuery : IRequest<List<ConsultationRequestDto>>
    {
    }
}
