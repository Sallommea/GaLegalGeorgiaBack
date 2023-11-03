using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;
using GaLegalGeorgia.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GaLegalGeorgia.Persistence.Repositories;
internal class AdminRepository : IAdminRepository
{
    private readonly GaLegalDatabaseContext _context;

    public AdminRepository(GaLegalDatabaseContext context)
    {
        _context = context;
    }
    public async Task<AdminModel> GetAdmin()
    {
        var result = await _context.Admins.FirstOrDefaultAsync();
        return result!;
    }
}
