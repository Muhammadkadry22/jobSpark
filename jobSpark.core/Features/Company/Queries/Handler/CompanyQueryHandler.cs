using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.Company.Queries.Dtos;
using jobSpark.core.Features.Company.Queries.Model;
using jobSpark.Service.Abstracts;
using MediatR;

namespace jobSpark.core.Features.Company.Queries.Handler
{
    public class CompanyQueryHandler : ResponseHandler,
                                       IRequestHandler<GetCompanytListQuery, Bases.Response<List<GetCompanyListDto>>>,
                                       IRequestHandler<GetCompanyByIdQuery, Response<GetComapanyByIdDTO>>
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public CompanyQueryHandler(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }

        public async Task<Bases.Response<List<GetCompanyListDto>>> Handle(GetCompanytListQuery request, CancellationToken cancellationToken)
        {

            var CompanyList = await companyService.GetCompanyListAsync();
            var CompanyMapper = mapper.Map<List<GetCompanyListDto>>(CompanyList);
            var result = Success(CompanyMapper);
            return result;
        }

        public async Task<Response<GetComapanyByIdDTO>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await companyService.GetCompanyByIdAsync(request.Id);
            if (company == null) return NotFound<GetComapanyByIdDTO>();
            var companyMapper = mapper.Map<GetComapanyByIdDTO>(company);
            var result = Success(companyMapper);
            return result;
        }
    }
}
