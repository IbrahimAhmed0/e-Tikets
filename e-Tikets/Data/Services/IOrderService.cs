using e_Tikets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
