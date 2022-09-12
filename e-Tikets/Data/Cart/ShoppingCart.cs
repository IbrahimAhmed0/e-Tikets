using e_Tikets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_Tikets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart( AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }




        public void AddItemToCart(Movie movie)
        {
            var shoppingcartItem = _context.ShoppingCartItems.FirstOrDefault(n =>
            n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if(shoppingcartItem == null)
            {
                shoppingcartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingcartItem);
            }
            else
            {
                shoppingcartItem.Amount++;
            }
            _context.SaveChanges();
        }


        public void RemoveItemToCart(Movie movie)
        {
            var shoppingcartItem = _context.ShoppingCartItems.FirstOrDefault(n =>
            n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingcartItem != null)
            {
                if (shoppingcartItem.Amount > 1)
                {
                    shoppingcartItem.Amount--;
                }
                else 
                {
                    _context.ShoppingCartItems.Remove(shoppingcartItem);
                }
            }
           
            _context.SaveChanges();
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n =>
            n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double getShoppingCartTotal() => _context.ShoppingCartItems.Where(n =>
        n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();
    }
}
