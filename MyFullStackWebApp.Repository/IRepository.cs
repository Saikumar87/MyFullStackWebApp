using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MyFullStackWebApp.Business.Entities;
using MyFullStackWebApp.DataStore.Operations;

namespace MyFullStackWebApp.Repository
{
    public interface IRepository<T>:IStoreOperations<T> where T: class
    {
       
    }

    public class UserProfileRepository : IRepository<UserProfile>
    {
        public bool DeleteFromStore(UserProfile obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> ReadFromStore()
        {
            return new List<UserProfile>
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
        }

        public bool InsertInStore(UserProfile obj)
        {
            throw new NotImplementedException();
        }

       

        public bool UpdateInStore(UserProfile obj)
        {
            throw new NotImplementedException();
        }
    }

    public class UserLoginRepository : IRepository<UserLogin>
    {
        static List<UserLogin> _userloginlist;

        public bool DeleteFromStore(UserLogin obj)
        {
            throw new NotImplementedException();
        }

      

        public bool InsertInStore(UserLogin obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLogin> ReadFromStore()
        {
            string defaultPassword = "Qazwsx@321";
            if (_userloginlist == null)
            {
                _userloginlist = new List<UserLogin>();
                for(int i =0;i < 10; i++)
                {
                    var passwordhash= Helper.GeneratePasswordHash(defaultPassword, out byte[] salt);
                    _userloginlist.Add(
                        new UserLogin()
                        {
                            UserLoginID = i,
                            EmailAddress = "abc" + i.ToString() + "@abc.com",
                            CreatedBy = "anon",
                            CreatedOn = DateTime.Now.AddDays(-1),
                            ModifiedBy = "anon",
                            ModifiedOn = DateTime.Now,
                            PasswordHash = passwordhash,
                            SecurityStamp = Convert.ToBase64String(salt),
                            ValidFrom = DateTime.Now,
                            ValidTo = DateTime.Now.AddDays(30)
                        });
                }
                return _userloginlist;
            }
            else
                return _userloginlist;
        }

        public bool UpdateInStore(UserLogin obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Helper
    {
       public static string GeneratePasswordHash(string password, out byte[] salt)
        {
            try
            {
                //Generate random salt using RNGCryotoServiceProvider
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                //Add password and salt over x iteration and 
                var crypto = new Rfc2898DeriveBytes(password, salt, 1000);
                var result = crypto.GetBytes(20);

                return Convert.ToBase64String(result);
            }
            catch(CryptographicException e)
            {
                throw e;
            }
            
        }

        public static bool isValidPassword(string password,string saltString, string PasswordHash)
        {
            try
            {
                //Generate byte array salt from Base64String salt
                var salt = Convert.FromBase64String(saltString);

                //Add password and salt over x iteration and 
                var crypto = new Rfc2898DeriveBytes(password, salt, 1000);
                var result = crypto.GetBytes(20);

                if (Convert.ToBase64String(result).Equals(PasswordHash))
                     return true;
                else
                    return false;
            }
            catch(CryptographicException e)
            {
                throw e;
            }

        }

    }




 

}
