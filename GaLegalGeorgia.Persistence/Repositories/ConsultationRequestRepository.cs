using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;
using GaLegalGeorgia.Persistence.DatabaseContext;

namespace GaLegalGeorgia.Persistence.Repositories
{
    public class ConsultationRequestRepository : GenericRepository<ConsultationRequest>, IConsultationRequest
    {
        public ConsultationRequestRepository(GaLegalDatabaseContext context) : base(context)
        {
        }

        
    }
}
