using jobSpark.core.Bases;
using jobSpark.core.Features.Applicant.Queries.Dtos;
using MediatR;

namespace jobSpark.core.Features.Applicant.Queries.Model
{
    public class GetApplicantByIdQuery : IRequest<Response<GetApplicantByIdDto>>
    {
        public int Id { get; set; }
    }
}
