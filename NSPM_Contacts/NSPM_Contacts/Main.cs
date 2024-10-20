using GTA;
using New_Street_Phone_Missions;

using System;

namespace NSPM_Contacts
{
    public class Main : Script
    {
        bool NewLoad = true;
        public Main()
        {
            Yacht.DipDar.Load();
            Tick += OnTick;
            Interval = 1;
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
            if (!Game.IsLoading)
            {
                if (DataStore.bHasLoaded)
                {
                    if (NewLoad)
                    {
                        if (DataStore.MyAssets.OwnaYacht)
                            Yacht.YouHaveAYacht();

                        Contacts.ContactLoadUp();
                        NewLoad = false;
                    }
                    else
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
        }
    }
}
