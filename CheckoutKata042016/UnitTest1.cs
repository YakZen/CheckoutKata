using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata042016
{
    [TestClass]
    public class UnitTest1 : IDisplay
    {
        private List<Sku> _skuList;
        private int _totalFromCheckout;

        [TestInitialize]
        public void SetupOrSometing()
        {
            _skuList = new List<Sku>();
            _skuList.Add(new Sku(code: "A", itemPrice: 50));
            _skuList.Add(new Sku(code: "B", itemPrice: 30));
            _skuList.Add(new Sku(code: "C", itemPrice: 60));
            _skuList.Add(new Sku(code: "D", itemPrice: 99));
        }

        [TestMethod]
        public void When_No_Items_Are_Scanned_total_is_Zero()
        {
            var checkout = new Checkout(_skuList);
            checkout.ShowTotalOn(this);
            Assert.AreEqual(0, _totalFromCheckout);
        }

        [TestMethod]
        public void When_1_A_is_Scanned_total_is_50()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("A");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(50, _totalFromCheckout);

        }

        [TestMethod]
        public void When_2_As_are_Scanned_total_is_100()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(100, _totalFromCheckout);

        }

        [TestMethod]
        public void When_3_As_are_Scanned_total_is_120()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(120, _totalFromCheckout);

        }

        [TestMethod]
        public void When_1_B_is_Scanned_total_is_30()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("B");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(30, _totalFromCheckout);

        }

        [TestMethod]
        public void When_2_B_is_Scanned_total_is_45()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(45, _totalFromCheckout);

        }


        [TestMethod]
        public void When_4_B_is_Scanned_total_is_90()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(90, _totalFromCheckout);

        }

        [TestMethod]
        public void When_1_A_and_2_B_Is_Scanned_Total_is_95()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("B");
            checkout.Scan("A");       
            checkout.Scan("B");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(95, _totalFromCheckout);
        }
         [TestMethod]
        public void When_1_A_and_6_B_Is_Scanned_Total_is_185()
        {
            var checkout = new Checkout(_skuList);
            checkout.Scan("B");
            checkout.Scan("B");               
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.ShowTotalOn(this);
            Assert.AreEqual(185, _totalFromCheckout);
        }

        public void show(int total)
        {
            _totalFromCheckout = total;
        }
    }

    public class Sku
    {
        public Sku(string code, int itemPrice)
        {
            this.Code = code;
            this.ItemPrice = itemPrice;
        }

        public string Code { get; set; }

        public int ItemPrice { get; set; }
    }
}

