using System;
using System.Collections.Generic;
using LargeCopies.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LargeCopies.test
{
    [TestClass]
    public class KledingTest
    {
        [TestMethod]
        public void KledingList()
        {
            Productdb db = new Productdb();
            List<ProductModel> kleding = new List<ProductModel>();
            kleding = db.FetchProducts("Kleding");
            Assert.AreEqual("Kleding",kleding[0].Themes,"Failed loading clothes list!");
        }

        [TestMethod]
        public void WrongCategoryString()
        {
            Productdb db = new Productdb();
            List<ProductModel> kleding = new List<ProductModel>();
            kleding = db.FetchProducts("Kledinffg");
            Assert.AreEqual(0, kleding.Count, "Non existent data loaded!");
        }

        [TestMethod]
        public void GetDetails()
        {
            Productdb db = new Productdb();
            ProductModel test = db.GetProductDetails(34);
            Assert.AreEqual("Rood",test.Color,"Details loading failed!");
        }
    }
}
