using System;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class LoggerLight 
    {
        public static string LogThis(string sLog)
        {
            string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/BeeLog.txt";

            using (StreamWriter tEx = File.AppendText(sBeeLogs))
                tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");

            return sLog;
        }
    }
}
