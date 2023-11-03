using GaLegalGeorgia.Application.Features.Admin.Queries;

namespace GaLegalGeorgia.Application.Contracts.Persistence
{
    public interface IAuthRepository
    {
        Task<string> Login(Authorize request);
    }
}
