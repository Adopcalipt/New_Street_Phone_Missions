using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class HitBuild
    {
        public int Local { get; set; }
        public Vector3 FUbstop { get; set; }
        public Vector3 Vstart { get; set; }
        public Vector3 Vboss { get; set; }
        public float BossDir { get; set; }
        public Vector3 Goon01 { get; set; }
        public float Goon01Dir { get; set; }
        public Vector3 Goon02 { get; set; }
        public float Goon02Dir { get; set; }
        public List<Vector3> Goon03 { get; set; }
        public List<Vector3> Goon04 { get; set; }
        public List<Vector3> Goon05 { get; set; }

        public HitBuild()
        {
            Goon03 = new List<Vector3>();
            Goon04 = new List<Vector3>();
            Goon05 = new List<Vector3>();
        }
    }
}
