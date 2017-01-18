using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
        private List<DisCountRule> _disCountRule;

        [TestInitialize]
        public void disCountRuleAdd()
        {
            _disCountRule = new List<DisCountRule> {
                new DisCountRule { name="哈利波特一集冊",kind="哈利波特",disQty=1,sale=1 },
                new DisCountRule { name="哈利波特二集冊",kind="哈利波特",disQty=2,sale=0.95 },
                new DisCountRule { name="哈利波特三集冊",kind="哈利波特",disQty=3,sale=0.9 },
                new DisCountRule { name="哈利波特四集冊",kind="哈利波特",disQty=4,sale=0.8 },
                new DisCountRule { name="哈利波特五集冊",kind="哈利波特",disQty=5,sale=0.75 },
                new DisCountRule { name="冰與火之歌三集冊",kind="冰與火之歌",disQty=3,sale=0.5 }
            };
        }

        [TestMethod()]
        public void 第一集買了一本其他都沒買價格應為100元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 }
            };

            //Arrange
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 100;
            var shoppingcart = new ShoppingCart(rule);
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
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 190;
            var shoppingcart = new ShoppingCart(rule);
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
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 270;
            var shoppingcart = new ShoppingCart(rule);
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
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 320;
            var shoppingcart = new ShoppingCart(rule);
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
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 375;
            var shoppingcart = new ShoppingCart(rule);
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void 一二集各買了一本第三集買了兩本每本金額100一二三集一套折扣9折剩下一本沒有折扣總金額為370元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=1 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=2 }
            };

            //Arrange
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 370;
            var shoppingcart = new ShoppingCart(rule);
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第一集買了一本第二三集各買了兩本每本價格100元一二三集為一套得到折扣9折二三集為一套得到折扣95折總金額為460元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=2 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=2 }
            };

            //Arrange
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 460;
            var shoppingcart = new ShoppingCart(rule);
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第一集買了一本第二三集各買了兩本每本價格100元一二三集為一套得到折扣9折二三集為一套得到折扣95折冰與火之歌一二三集各買一本折扣5折總金額為610元()
        {
            IEnumerable<Product> products = new List<Product>
            {
                new Product { name="哈利波特第一集",kind="哈利波特",epiSode="1",setPrice=100,qty=1 },
                new Product { name="哈利波特第二集",kind="哈利波特",epiSode="2",setPrice=100,qty=2 },
                new Product { name="哈利波特第三集",kind="哈利波特",epiSode="3",setPrice=100,qty=2 },
                new Product { name="冰與火之歌一集",kind="冰與火之歌",epiSode="1",setPrice=100,qty=1 },
                new Product { name="冰與火之歌二集",kind="冰與火之歌",epiSode="2",setPrice=100,qty=1 },
                new Product { name="冰與火之歌三集",kind="冰與火之歌",epiSode="3",setPrice=100,qty=1 }
            };

            //Arrange
            IRule rule = Substitute.For<IRule>();
            rule.GetKindRule().Returns(_disCountRule);
            var expected = 610;
            var shoppingcart = new ShoppingCart(rule);
            //Act
            var actual = shoppingcart.SumTotal(products);
            //Assert
            Assert.AreEqual(expected, actual);
        }







    }
}