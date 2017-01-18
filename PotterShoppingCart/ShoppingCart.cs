using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        /// <summary>
        /// 購物車計價總額
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public int SumTotal(IEnumerable<Product> products)
        {
            int result = 0;
            result = products.FirstOrDefault().qty * 100;
            return result;
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
