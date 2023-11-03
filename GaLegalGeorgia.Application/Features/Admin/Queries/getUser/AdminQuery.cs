using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.Admin.Queries.getUser
{
    public record AdminQuery(int Id) : IRequest<AdminDto>;
}
