using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas
{
    public record GetPracticeAreasQuery : IRequest<List<PracticeAreaDto>>;
    
}
