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

            while(products.Sum(x=>x.qty) > 0)
            {
                var DisSumPrice = 0;
                var DisQty = 0;              

                //消去法掃描每列-1組成套書
                foreach (var product in products)
                {
                    if (product.qty > 0)
                    {
                        product.qty--;//內容-1
                        DisSumPrice += product.setPrice;//金額加總
                        DisQty++;//計算套書數量+1
                    }
                }
                result += DisCount(DisSumPrice, DisQty);
            }

            return (int)result;
        }

        /// <summary>
        /// 計算套書折扣
        /// </summary>
        /// <param name="DisSumPrice">總金額</param>
        /// <param name="sumQty">數量</param>
        /// <returns></returns>
        private static double DisCount(double DisSumPrice, int sumQty)
        {
            double result = DisSumPrice;

            switch (sumQty)
            {
                case 1:
                    result = result * 1;
                    break;
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
