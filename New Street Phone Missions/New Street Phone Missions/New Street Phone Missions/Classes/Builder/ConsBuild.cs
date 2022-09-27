using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class ConsBuild
    {
        public int Local { get; set; }
        public List<Vector3> ConMarch { get; set; }

        public ConsBuild()
        {
            ConMarch = new List<Vector3>();
        }
    }
}
