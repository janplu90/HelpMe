using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpMe.Domain.Abstract;
using Moq;
using HelpMe.Domain.Entities;
using System.Collections.Generic;

namespace HelpMe.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CheckIfUserExist()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            string login = "nonexisting";
            Assert.IsFalse(mock.Object.CheckIfUserExists(login));
        }

        //[TestMethod]
        //public void CheckPassword()
        //{
        //    Mock<IUserRepository> mock = new Mock<IUserRepository>();
        //    mock.Setup(u => u.Users).Returns(new User[]
        //    {
        //        new User { UserID = 99999, Login = "testowylogin", Password="0000", Name="TestoweImie", Surname="TestoweNazwisko", Age=100, Country="Poland", City="TestoweMiasto", AboutMe = "TestoweAboutMe" }
        //    });
        //    string login = mock.Object.
        //    string password = mock.Object.getUser(99999).Password;
        //    Assert.IsTrue(mock.Object.CheckPassword(login, password));
        //}
    }
}
