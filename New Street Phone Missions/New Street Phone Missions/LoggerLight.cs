using System;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class LoggerLight
    {
        private static bool bLoad = true;
        private static string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/BeeLog.txt";

        public static void LogThis(string sLog)
        {
            if (DataStore.Logging)
            { 
                if (bLoad)
                {
                    using (StreamWriter tEx = File.CreateText(sBeeLogs))
                        tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");
                    bLoad = false;
                }
                else
                {
                    using (StreamWriter tEx = File.AppendText(sBeeLogs))
                        tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");
                }
            }
        }
    }
}
