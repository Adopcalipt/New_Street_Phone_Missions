using GTA;
using New_Street_Phone_Missions;
using New_Street_Phone_Missions.Classes;

using System;

namespace NSPM_Contacts
{
    public class Main : Script
    {
        public Main()
        {
            while (!DataStore.bHasLoaded)
                Script.Wait(10);

            Yacht.DipDar.Load();
            Tick += OnTick;
            Interval = 1;
            if (DataStore.MyAssets.OwnaYacht)
                Yacht.YouHaveAYacht();

            Contacts.ContactLoadUp();
        }
        public static void LogThis(string sLog)
        {
            if (DataStore.Logging)
            {
                LoggerLight.LogThis("ContactLog_" + sLog);
            }
        }
        private void OnTick(object sender, EventArgs e)
        {
            Contacts.Contacting();

            if (!DataStore.OnTheJob)
            {
                if (DataStore.MyAssets.OwnaYacht)
                    Yacht.Yachting();
            }
            else
            {
                if (Yacht.YachtBlip != null)
                    Yacht.YachtStuff_TheBlip(false);
            }
        }
    }
}
