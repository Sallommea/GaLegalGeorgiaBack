using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.Admin.Queries
{
    public sealed record Authorize(string Email, string Password) : IRequest<string>;
    
}
