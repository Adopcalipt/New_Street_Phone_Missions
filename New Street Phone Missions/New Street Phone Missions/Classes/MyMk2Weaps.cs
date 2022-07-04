using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class MyMk2Weaps
    {
        public int MyPlayer { get; set; }
        public string Mk2Weap { get; set; }
        public List<string> Mk2Addon { get; set; }
        public int MyAmmos { get; set; }

        public MyMk2Weaps()
        {
            Mk2Addon = new List<string>();
        }
    }
}
