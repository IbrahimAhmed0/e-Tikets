using e_Tikets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_Tikets.Models
{
    public class Cienma : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Picture")]
        [Required(ErrorMessage = "Cinema Picture is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
