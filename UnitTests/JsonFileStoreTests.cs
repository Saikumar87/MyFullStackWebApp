using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullStackApp.JsonFileStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFullStackWebApp.Business.Entities;

namespace UnitTests
{
    [TestClass]
    public class JsonFileStoreTests
    {
        [TestMethod]
        public async Task InsertIntoFileAsync()
        {
            IFileStoreOperations<UserProfile> filestoreOps = new FileStoreOperations<UserProfile>(@"C:\Users\v-saikum\source\repos\MyFullStackWebApp\UnitTests\bin\Debug\JsonFile.json");
            List<UserProfile> list= new List<UserProfile>
            {
                new UserProfile()
                {
                    UserProfileId=1, CreatedBy="anon", CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedBy="anon", ModifiedOn=DateTime.Now, EmailAddress="abc@abc.com",
                    UserName="ABC  ABC"
                },

                new UserProfile()
                {
                    UserProfileId=2, CreatedBy="anon", CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedBy="anon", ModifiedOn=DateTime.Now, EmailAddress="def@def.com",
                    UserName="DEF  DEF"
                },
                 new UserProfile()
                {
                    UserProfileId=3, CreatedBy="anon", CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedBy="anon", ModifiedOn=DateTime.Now, EmailAddress="ghi@ghi.com",
                    UserName="GHI  GHI"
                },
                  new UserProfile()
                {
                    UserProfileId=4, CreatedBy="anon", CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedBy="anon", ModifiedOn=DateTime.Now, EmailAddress="jkl@jkl.com",
                    UserName="JKL  JKL"
                }
            };


            var t1 = filestoreOps.InsertInStore(list[0]);
            var t2 = filestoreOps.InsertInStore(list[1]);
            var t3 = filestoreOps.InsertInStore(list[2]);
            var t4 = filestoreOps.InsertInStore(list[3]);

            await Task.WhenAll( t1, t2, t3, t4);


          
         
        }
    }
}
