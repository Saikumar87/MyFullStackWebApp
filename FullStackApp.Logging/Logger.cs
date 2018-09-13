using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FullStackApp.Logging
{       
    
    public class Logger
    {
        static string machineName;
        static Logger()
        {
            machineName = Environment.MachineName;
        }
        public static void LogtoOutputWindow(string Message)
        {
            //Trace.Listeners.Add(new TextWriterTraceListener("TextWriterOutput.log", "myListener"));
            Trace.WriteLine(Message, "MyApp");

        }

        public static Task Info(string message, string app, Guid activityid, object ctx)
        {
            return WriteEntry(new Log()
            {
                LogContext = ctx,
                ActivityId = activityid,
                Message = message,
                LogType = "Info",
                MachineName = machineName,
                MethodName = app,
                TimeStamp = DateTime.Now
            });

        }

        public static Task Warning(string message, string app, Guid activityid)
        {
            return WriteEntry(new Log()
            {
                ActivityId = activityid,
                Message = message,
                LogType="Warning",
                MethodName = app,
                TimeStamp = DateTime.Now
            });

        }
        public static Task Error(Exception e, string app, Guid activityid)
        {
            return WriteEntry(new Log()
            {
                ActivityId = activityid,
                CallStack = e.StackTrace,
                LogType = "Exception",
                Message = e.Message,
                MethodName = app,
                TimeStamp = DateTime.Now
            });

        }
        private static async Task WriteEntry(Log log)
        {
            string s = JsonConvert.SerializeObject(log);
            Trace.WriteLine(s);
            await Task.Run(()=>Trace.Flush());
        }

        public static void TrackEvent()
        {
            throw new NotImplementedException();
        }

        public static void TrackException()
        {
            throw new NotImplementedException();
        }
    }



    public class Log
    {
        public object LogContext { get; set; }
        public DateTime TimeStamp { get; set; }

        public string MachineName { get; set; }

        
        public string Message { get; set; }

        public string MethodName { get; set; }

        public string LogType { get; set; }

        public string CallStack { get; set; }

        public Guid ActivityId { get; set; }
    }

    public class LogEnvironment
    {

    }
}
