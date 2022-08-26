using e_Tikets.Data.Base;
using e_Tikets.Models;

namespace e_Tikets.Data.Services
{
    public class ProducerService : EntityBaseReopostery<Producer> , IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {

        }
    }
}
