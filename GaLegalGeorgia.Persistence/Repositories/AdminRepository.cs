using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Persistence.Repositories;
internal class AdminRepository : IAdminRepository
{
    public Task<AdminModels> GetAdmin()
    {
        throw new NotImplementedException();
    }
}
