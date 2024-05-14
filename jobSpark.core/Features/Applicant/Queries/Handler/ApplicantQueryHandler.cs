using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.Applicant.Queries.Dtos;
using jobSpark.core.Features.Applicant.Queries.Model;
using jobSpark.Service.Abstracts;
using MediatR;

namespace jobSpark.core.Features.Applicant.Queries.Handler
{
    public class ApplicantQueryHandler : ResponseHandler,
        IRequestHandler<GetApplicantByIdQuery, Bases.Response<GetApplicantByIdDto>>
    {
        private readonly IMapper mapper;
        private readonly IApplicantService applicantService;

        public ApplicantQueryHandler(IMapper mapper, IApplicantService applicantService)
        {
            this.mapper = mapper;
            this.applicantService = applicantService;
        }

        public async Task<Response<GetApplicantByIdDto>> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await applicantService.GetApplicantByIdAsync(request.Id);
            if (applicant == null) return NotFound<GetApplicantByIdDto>();
            var applicantMapper = mapper.Map<GetApplicantByIdDto>(applicant);
            var result = Success(applicantMapper);
            return result;
        }
    }


}
