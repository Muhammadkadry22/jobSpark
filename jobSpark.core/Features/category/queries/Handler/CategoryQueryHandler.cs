using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.category.queries.Dtos;
using jobSpark.core.Features.category.queries.Model;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.category.queries.Handler
{
    public class CategoryQueryHandler : ResponseHandler,
                                        IRequestHandler<GetCategoryListQuery, Response<List<GetCategoryListDto>>>

    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        public CategoryQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
        public async Task<Response<List<GetCategoryListDto>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categorylist = await categoryService.GetCategoryListAsync();
            var categoryMapper = mapper.Map<List<GetCategoryListDto>>(categorylist);
            var result = Success(categoryMapper);
            return result;
        }

    }
}
