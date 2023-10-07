using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea
{
    public class CreatePracticeAreaCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
    }
}
