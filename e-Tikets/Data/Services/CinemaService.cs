using e_Tikets.Data.Base;
using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public class CinemaService : EntityBaseReopostery<Cienma> , ICinemaService
    {

        //private readonly AppDbContext _appDbContext;
        public CinemaService(AppDbContext appDbContext) : base(appDbContext)
        {
        }


    }
}
