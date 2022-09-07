using e_Tikets.Models;
using System.Collections.Generic;

namespace e_Tikets.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Cienmas = new List<Cienma>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cienma> Cienmas { get; set; }
        public List<Actor> Actors { get; set; }

    }
}
