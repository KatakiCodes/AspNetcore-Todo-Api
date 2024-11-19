using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoAspNetAPI.Dto.TargetDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Dto.StepDtos
{
    public class StepDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}