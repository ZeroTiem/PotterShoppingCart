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
            double result = 0;
            int sumQty = 0;

            sumQty = products.Sum(x => x.qty);
            result = sumQty * 100;

            result = DisCount(result, sumQty);

            return (int)result;
        }

        private static double DisCount(double result, int sumQty)
        {
            switch (sumQty)
            {
                case 2:
                    result = result * 0.95;
                    break;
                case 3:
                    result = result * 0.9;
                    break;
                case 4:
                    result = result * 0.8;
                    break;
                case 5:
                    result = result * 0.75;
                    break;
            }

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
