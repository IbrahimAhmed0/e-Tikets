using e_Tikets.Data.Base;
using e_Tikets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Tikets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }    

        public double Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //RelationShip
        public List<Actor_Movie> Actor_Movies { get; set; }

        //Ciema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cienma Cienme { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]

        public Producer Producer { get; set; }


    }
}
