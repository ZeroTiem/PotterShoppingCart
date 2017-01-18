using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        public int SumTotal(IEnumerable<Product> products)
        {
            int result = 0;
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
        
        public int qty { get; set; }
    }
}
