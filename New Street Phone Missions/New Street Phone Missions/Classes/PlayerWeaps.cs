using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class PlayerWeaps
    {
        public string MyWeap { get; set; }
        public List<string> MyAttachList { get; set; }
        public int MyAmmo { get; set; }

        public PlayerWeaps()
        {
            MyAttachList = new List<string>();
        }
    }
}
