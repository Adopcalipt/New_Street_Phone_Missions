using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class XmlContacts
    {
        public List<string> ImpXCars { get; set; }
        public List<int> ImpXList { get; set; }
        public List<MyMk2Weaps> MyMk2Weaps { get; set; }
        public Vector3 FuMiss { get; set; }

        public XmlContacts()
        {
            MyMk2Weaps = new List<MyMk2Weaps>();
            ImpXCars = new List<string>();
            ImpXList = new List<int>();
        }
    }
}
