using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_Tikets.Models
{
    public class Actor
    {

        [Key]
        public int Id { get; set; }
        public string FullName { get; set;}

        public string profilePictureURL { get; set;}

        public string Bio { get; set; }

        //Relationship

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
