using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart
{
    public class DisCount : IDisCount
    {
        public IRule _rule;

        public DisCount()
        {
            this._rule = new Rule();
        }

        public DisCount(IRule rule)
        {
            this._rule = rule;
        }

        /// <summary>
        /// 套書計價
        /// </summary>
        /// <param name="products"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public double Kind(IEnumerable<Product> products)
        {
            double result = 0;

            //取得同類別
            var grouKinds = products.GroupBy(x => x.kind);
            foreach (var grouKind in grouKinds)
            {
                var kind = grouKind.Key;
                var productGroups = products.Where(x => x.kind == kind);

                while (productGroups.Sum(x => x.qty) > 0)
                {
                    result = groupSumTatal(result, kind, productGroups);
                }
            }
            return result;
        }

        private double groupSumTatal(double result, string kind, IEnumerable<Product> productGroups)
        {
            var sumPrice = 0;
            var disQty = 0;
            //消去法掃描每列-1組成套書
            foreach (var productGroup in productGroups)
            {
                if (productGroup.qty > 0)
                {
                    productGroup.qty--;//內容-1
                    sumPrice += productGroup.setPrice;//金額加總
                    disQty++;//計算套書數量+1
                }
            }
            result += SaleOff(sumPrice, disQty, kind);
            return result;
        }

        /// <summary>
        /// 計算套書折扣
        /// </summary>
        /// <param name="DisSumPrice">總金額</param>
        /// <param name="sumQty">數量</param>
        /// <returns></returns>
        public double SaleOff(double DisSumPrice, int sumQty, string Kind)
        {
            double result = DisSumPrice;

            var getRule = _rule.GetKindRule();
            var rule = getRule.Where(x => x.disQty == sumQty && x.kind == Kind);

            if (rule != null && rule.Count() > 0)
            {
                result = DisSumPrice * rule.FirstOrDefault().sale;
            }

            return result;
        }



    }

    public class Rule : IRule
    {
        /// <summary>
        /// 取得規則設定
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DisCountRule> GetKindRule()
        {
            var GetRule = new List<DisCountRule>();
            return GetRule;
        }
    }

    public interface IRule
    {
        IEnumerable<DisCountRule> GetKindRule();
    }


    public class DisCountRule
    {
        public string name { get; set; }
        public string kind { get; set; }
        public int disQty { get; set; }
        public double sale { get; set; }
    }


}
