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

        [TestMethod()]
        public void 第一集買了一本第二集也買了一本價格應為100元買2本得到折扣95折總金額為190元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=1 }
            };

            //Arrange
            var expected = 190;
            var shoppingcart = new ShoppingCart();
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二三集各買了一本每本價格100元得到折扣9折總金額為270元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=1 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=1 }
            };

            //Arrange
            var expected = 270;
            var shoppingcart = new ShoppingCart();
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二三四集各買了一本每本價格應為100得到折扣8折總金額為320元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=1 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=1 },
                new Product { name="哈利波特第四集",kind="哈利波特",epiSode="4",setPrice=100,qty=1 }
            };

            //Arrange
            var expected = 320;
            var shoppingcart = new ShoppingCart();
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一次買了整套一二三四五集各買了一本每本100元得到折扣75折總金額為375元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=1 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=1 },
                new Product { name="哈利波特第四集",kind="哈利波特",epiSode="4",setPrice=100,qty=1 },
                new Product { name="哈利波特第五集",kind="哈利波特",epiSode="5",setPrice=100,qty=1 }
            };

            //Arrange
            var expected = 375;
            var shoppingcart = new ShoppingCart();
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        

        
    }
}