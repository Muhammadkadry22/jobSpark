using jobSpark.core.Bases;
using jobSpark.Domain.Entities;
using jobSpark.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.commands.Model
{
    public  class AddVacancyCommand : IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public DateTime OpenDate { get; set; }
        public EState State { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }    
    }
}
