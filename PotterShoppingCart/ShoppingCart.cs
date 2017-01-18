using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        private IDisCount _disCount;
        private IRule _rule;


        public ShoppingCart()
        {
            _disCount = new DisCount();
        }

        public ShoppingCart(IRule _rule)
        {
            _disCount = new DisCount(_rule);
        }

        /// <summary>
        /// 購物歌計算總金額
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public int SumTotal(IEnumerable<Product> products)
        {
            double result = 0;

            result = _disCount.Kind(products);

            return (int)result;
        }

        
    }

    public class Product
    {
        /// <summary>
        /// 書名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 系列別
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// 集數
        /// </summary>
        public string epiSode { get; set; }
        /// <summary>
        /// 價格
        /// </summary>
        public int setPrice { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int qty { get; set; }
    }
}
