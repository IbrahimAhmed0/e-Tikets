using e_Tikets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface ICinemaService
    {

            Task<IEnumerable<Cienme>> GetAllasyncCinema();
            Task<Cienme> GetByIdAsyncCinema(int id);
            Task AddAsyncCinema(Cienme cinema);
            Task<Cienme> UpdateAsyncCinema(int id, Cienme newCinema);
            Task DeleteAsyncCinema(int id);


    }
}
