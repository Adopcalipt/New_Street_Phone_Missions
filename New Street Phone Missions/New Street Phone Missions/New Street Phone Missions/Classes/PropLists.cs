using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class PropLists
    {
        public List<string> Prop { get; set; }
        public List<Vector3> Pos { get; set; }
        public List<Vector3> Rot { get; set; }

        public PropLists()
        {
            Prop = new List<string>();
            Pos = new List<Vector3>();
            Rot = new List<Vector3>();
        }
    }
}
