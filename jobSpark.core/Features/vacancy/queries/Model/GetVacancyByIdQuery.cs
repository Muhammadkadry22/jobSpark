using Azure;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using MediatR;


namespace jobSpark.core.Features.vacancy.queries.Model
{
    public class GetVacancyByIdQuery : IRequest<Bases.Response<GetVacancyByIdDto>>
    {
        public int Id {  get; set; }
    }
}
