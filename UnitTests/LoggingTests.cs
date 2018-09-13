using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FullStackApp.Logging;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace UnitTests
{
    [TestClass]
    public class LoggingTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            string methodName = method.Name;
            string className = method.ReflectedType.Name;
            string machineName = Environment.MachineName;
            string osUser = Environment.UserName;
          

            string fullMethodName = className + "." + methodName;
            for (int i = 1; i < 3; i++)
            {

                Task.Run(() =>
                {
                    var Activityid = Guid.NewGuid();
                    Context ctx = Thread.CurrentContext;
                    try
                    {
                        Logger.Info("Hello World", fullMethodName, Activityid,ctx);
                        Logger.Warning("Hello World- Warning", fullMethodName, Activityid);
                        int a1 = 0;
                        a1 = i % 3;
                         int a = 19 / a1;
                        Assert.IsTrue(true);

                    }
                    catch (Exception e)
                    {
                        Logger.Error(e, fullMethodName, Activityid);
                       // Assert.IsFalse(true, "Error in Try Block of Test Method 1", Activityid);
                    }
                }).Wait();
            }
               
            
        }
    }


    [TestClass]
    public class Log4NetLoggingTests
    {
        private static readonly log4net.ILog log
      = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [TestMethod]
        public void TestMethod1()
        {
           

            log.Info("Application is working");

        }
    }
}
