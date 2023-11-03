using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas
{
    public enum Language
    {
        en,
        ge,
     
    }

    public sealed record GetPracticeAreasQuery(Language Language) : IRequest<List<PracticeAreaDto>>;


}

