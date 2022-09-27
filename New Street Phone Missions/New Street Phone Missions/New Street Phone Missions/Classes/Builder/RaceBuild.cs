using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class RaceBuild
    {
        public int Local { get; set; }
        public Vector3 FubStop { get; set; }
        public List<Vector3> RaceCars { get; set; }
        public List<float> RaceHead { get; set; }
        public List<Vector3> TheRace { get; set; }
        public int VehClass { get; set; }
        public List<string> AvalableVeh { get; set; }

        public RaceBuild()
        {
            RaceCars = new List<Vector3>();
            RaceHead = new List<float>();
            TheRace = new List<Vector3>();
            AvalableVeh = new List<string>();
        }
    }
}
