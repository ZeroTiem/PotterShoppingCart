using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod()]
        public void 第一集買了一本其他都沒買價格應為100元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 }
            };

            //Arrange
            var expected = 100;
            var shoppingcart = new ShoppingCart();
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}