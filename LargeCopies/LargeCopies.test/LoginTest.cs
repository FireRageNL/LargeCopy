using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargeCopies;
using LargeCopies.Models;

namespace LargeCopies.test
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestLoginCorrectUser()
        {
            Userdb db = new Userdb();
            LoginViewModel correctmodel = new LoginViewModel
            {
                Email = "noot@noot.noot",
                Password = "nootnootnoot"
            };
            Assert.AreEqual(41,db.LoginUser(correctmodel),"Userlogin failed!");

        }
        [TestMethod]
        public void TestLoginWrongEmail()
        {
            Userdb db = new Userdb();
            LoginViewModel wrongemailmodel = new LoginViewModel
            {
                Email = "Noot@noooooot.noot",
                Password = "nootnootnoot"
            };
            Assert.AreEqual(0, db.LoginUser(wrongemailmodel), "User logged in with fake email!");
        }
        [TestMethod]
        public void TestLoginWrongPassword()
        {
            Userdb db = new Userdb();
            LoginViewModel wrongpasswordmodel = new LoginViewModel
            {
                Email = "noot@noot.noot",
                Password = "noooooooooot"
            };
            Assert.AreEqual(0, db.LoginUser(wrongpasswordmodel), "User logged in with wrong password!");

        }

        [TestMethod]
        public void TestAdmin()
        {
            Userdb db = new Userdb();

            Assert.AreEqual(true,db.IsAdmin(25),"Admin user not returned as admin!");
        }

        [TestMethod]
        public void TestNotAdmin()
        {
            Userdb db = new Userdb();
            Assert.AreEqual(false, db.IsAdmin(41), "Non admin user returned as adminuser!");

        }
    }
}
