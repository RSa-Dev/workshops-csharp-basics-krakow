using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class Cart
    {
        private ISet<CartItem> _items = new HashSet<CartItem>();
        public int UserId { get; set; }
        public IEnumerable<CartItem> Items => _items;

        public Cart(User user)
        {
            UserId = user.Id;
        }

        public void AddProduct(Product product, int quantity = 1)
        {
            CartItem cartItem = null;
            foreach(var item in _items)
            {
                if(item.ProductId == product.Id)
                {
                    cartItem = item;
                    break;
                }
            }
            if(cartItem == null)
            {
                _items.Add(new CartItem(product.Id, quantity, product.Price));
                return;
            }
            cartItem.IncreaseQuantity();
        }
    }
}