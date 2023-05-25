using System;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class LoggerLight
    {
        private static string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/BeeLog" + DateTime.Now.ToLongDateString() + ".txt";

        public static void LogThis(string sLog)
        {
            if (DataStore.Logging)
            {
                using (StreamWriter tEx = File.AppendText(sBeeLogs))
                    tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");
            }
        }
    }
}
