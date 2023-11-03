using GaLegalGeorgia.Application.Features.Admin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Contracts.Persistence
{
    public interface IAuthRepository
    {
        Task<string> Login(Auth request);
    }
}
