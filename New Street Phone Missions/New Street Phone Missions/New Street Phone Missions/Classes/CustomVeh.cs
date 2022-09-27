using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class CustomVeh
    {
        public List<string> MyCarz { get; set; }
        public List<string> MyPlanez { get; set; }
        public List<string> MyBoatz { get; set; }
        public List<string> MyChopperz { get; set; }

        public CustomVeh()
        {
            MyCarz = new List<string>();
            MyPlanez = new List<string>();
            MyBoatz = new List<string>();
            MyChopperz = new List<string>();
        }
    }
}
