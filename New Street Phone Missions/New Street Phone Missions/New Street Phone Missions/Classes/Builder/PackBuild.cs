using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class PackBuild
    {
        public int Local { get; set; }
        public Vector3 FarstStart { get; set; }
        public Vector3 PackVehStart { get; set; }
        public float PackVehDir { get; set; }
        public string PackVehType { get; set; }
        public string PackDropType { get; set; }
        public int Livery { get; set; }
        public List<Vector3> PackDrops { get; set; }

        public PackBuild()
        {
            PackDrops = new List<Vector3>();
        }
    }
}
