using AutoMapper;
using Azure;
using jobSpark.core.Bases;
using jobSpark.core.Features.Company.Queries.Dtos;
using jobSpark.core.Features.Company.Queries.Model;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.Service.Abstracts;
using jobSpark.Service.implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.Company.Queries.Handler
{
    public class CompanyQueryHandler : ResponseHandler,
                                       IRequestHandler<GetCompanytListQuery, Bases.Response<List<GetCompanyListDto>>>
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
    }
}
