using GTA;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class Crash4Cash
    {
        public List<Vehicle> VehX { get; set; }
        public List<int> VehXHealth { get; set; }
        public List<Ped> PedX { get; set; }
        public List<int> PedXHealth { get; set; }

        public Crash4Cash()
        {
            VehX = new List<Vehicle>();
            VehXHealth = new List<int>();
            PedX = new List<Ped>();
            PedXHealth = new List<int>();
        }
    }
}
