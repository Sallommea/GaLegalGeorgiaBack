using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.Admin.Queries
{
    internal sealed class AuthHandler : IRequestHandler<Auth, string>
    {
        private readonly IAuthRepository _authRepository;

        public AuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<string> Handle(Auth request, CancellationToken cancellationToken)
        {
            var validationResult = new AuthValidator().Validate(request);

            if (validationResult.IsValid != true)
            {
                throw new BadRequestException("Invalid Auth Request", validationResult);
            }

            var result = await _authRepository.Login(request);
            return result;
        }
    }
}
