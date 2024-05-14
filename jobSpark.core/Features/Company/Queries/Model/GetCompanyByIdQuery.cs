using jobSpark.core.Features.Company.Queries.Dtos;
using MediatR;

namespace jobSpark.core.Features.Company.Queries.Model
{
    public class GetCompanyByIdQuery : IRequest<Bases.Response<GetComapanyByIdDTO>>
    {
        public int Id { get; set; }
    }
}
