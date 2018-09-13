using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;  
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFullStackWebApp.Business.Entities;
using MyFullStackWebApp.Repository;

namespace UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        UserLoginRepository ul= new UserLoginRepository();
        public void Test_UserProfileRepo()
        {
            UserProfileRepository u = new UserProfileRepository();
            var x= u.ReadFromStore();
            Assert.IsNotNull(x);
        }

        [TestMethod]
        public void Test_UserLoginRepo()
        {           
            var x = ul.ReadFromStore();
            Assert.IsNotNull(x);
        }

        [TestMethod]
        public void ValidateUserLogin()
        {
            string username = "abc0@abc.com";
            List<UserLogin> ullist = (List<UserLogin>)ul.ReadFromStore();
            var selecteduserlogin = ullist.Where(x => x.EmailAddress == username).FirstOrDefault();
            Assert.IsTrue(Helper.isValidPassword("Qazwsx@321", selecteduserlogin.SecurityStamp, selecteduserlogin.PasswordHash));
            
        }



    }
}
