using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    [TestClass()]
    public class DisCountTests
    {
        [TestMethod()]
        public void KindTest()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=2 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=2 }
            };

            //Arrange
            var expected = 460;
            var disCount = new DisCount();
            //Act
            var actual = disCount.Kind(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}