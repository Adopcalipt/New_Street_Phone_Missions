using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class TruckBuild
    {
        public int Local { get; set; }

        public Vector3 FubarStop { get; set; }
        public Vector3 TruckinStart01 { get; set; }
        public float TruckinDir01 { get; set; }
        public Vector3 TruckinStart02 { get; set; }
        public float TruckinDir02 { get; set; }
        public List<Vector3> TruckinEnd { get; set; }
        public List<float> TruckinDir03 { get; set; }
        public string TruckinTrail { get; set; }
        public int VehVar { get; set; }
        public int LiveryExtra { get; set; }
        public int VehLivery { get; set; }
        public int AttachStuff { get; set; }

        public TruckBuild()
        {
            TruckinEnd = new List<Vector3>();
            TruckinDir03 = new List<float>();
        }
    }
}
