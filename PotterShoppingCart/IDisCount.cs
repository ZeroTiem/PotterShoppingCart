using System.Collections.Generic;

namespace PotterShoppingCart
{
    public interface IDisCount
    {
        double Kind(IEnumerable<Product> products);
    }
}