﻿using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Logging;
using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;


namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas
{
    public sealed class GetPracticeAreasQueryHandler : IRequestHandler<GetPracticeAreasQuery, List<PracticeAreaDto>>
    {
        private readonly IPracticeAreaRepository _practiceAreaRepository;
        private readonly IAppLogger<GetPracticeAreasQueryHandler> _logger;

        public GetPracticeAreasQueryHandler( 
            IPracticeAreaRepository practiceAreaRepository,
            IAppLogger<GetPracticeAreasQueryHandler> logger
            )
        {
            this._practiceAreaRepository = practiceAreaRepository;
            this._logger = logger;
        }

        public async Task<List<PracticeAreaDto>> Handle(GetPracticeAreasQuery request, CancellationToken cancellationToken)
        {
           
            var practiceAreas = await _practiceAreaRepository.GetAsync();
           
            var data = practiceAreas.Select(p => new PracticeAreaDto
            {
                Id = p.Id,
                Title = request.Language == Language.en ? p.TitleEn : p.Title
            }).ToList();

            return data;
        }
    }
}
