using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class BlipStore
    {
        public List<int> MyBlips { get; set; }
        public List<int> MyCorrona { get; set; }
        public List<int> MyPeds { get; set; }
        public List<int> MyProps { get; set; }
        public List<int> MyVehcs { get; set; }
        public int MySound { get; set; }
        public BlipStore()
        {
            MyBlips = new List<int>();
            MyCorrona = new List<int>();
            MyPeds = new List<int>();
            MyProps = new List<int>();
            MyVehcs = new List<int>();
        }
    }
}
