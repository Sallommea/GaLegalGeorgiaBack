//using GaLegalGeorgia.Application.Contracts.Persistence;
//using GaLegalGeorgia.Application.Exceptions;
//using GaLegalGeorgia.Application.Features.Admin.Auth;
//using MediatR;

//namespace GaLegalGeorgia.Application.Features.Admin.Queries
//{
//    internal sealed class AuthHandler : IRequestHandler<Authorize, string>
//    {
//        private readonly IAuthRepository _authRepository;

//        public AuthHandler(IAuthRepository authRepository)
//        {
//            _authRepository = authRepository;
//        }
//        public async Task<string> Handle(Authorize request, CancellationToken cancellationToken)
//        {
//            var validationResult = new AuthValidator().Validate(request);

//            if (validationResult.IsValid != true)
//            {
//                throw new BadRequestException("Invalid Auth Request", validationResult);
//            }

//            var result = await _authRepository.Login(request);
//            return result;
//        }
//    }
//}
