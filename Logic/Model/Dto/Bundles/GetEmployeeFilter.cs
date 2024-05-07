using System.ComponentModel.DataAnnotations;

namespace logic.Model.Dto.Bundles;

public class GetEmployeeFilter
{
        [Required]
        public bool IsActivate { get; set; }
}