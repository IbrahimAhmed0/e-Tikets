using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_Tikets.Models
{
    public class Cienme
    {

        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
