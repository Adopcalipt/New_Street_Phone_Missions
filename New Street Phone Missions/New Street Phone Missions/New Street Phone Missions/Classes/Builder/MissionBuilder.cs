using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class MissionBuilder
    {
        public List<TruckBuild> TruckersXM { get; set; }
        public List<PackBuild> PackersXM { get; set; }
        public List<ConsBuild> ConsXM { get; set; }
        public List<FuberBuild> FubardXM { get; set; }
        public List<AmbBuild> AmbuXM { get; set; }
        public List<DeapBuild> SharksXM { get; set; }
        public List<JohnnyBuild> JohnsXM { get; set; }
        public List<RaceBuild> RaceXM { get; set; }
        public List<BombBuild> BombXM { get; set; }
        public List<HitBuild> HitXM { get; set; }

        public MissionBuilder()
        {
            TruckersXM = new List<TruckBuild>();
            PackersXM = new List<PackBuild>();
            ConsXM = new List<ConsBuild>();
            FubardXM = new List<FuberBuild>();
            AmbuXM = new List<AmbBuild>();
            SharksXM = new List<DeapBuild>();
            JohnsXM = new List<JohnnyBuild>();
            RaceXM = new List<RaceBuild>();
            BombXM = new List<BombBuild>();
            HitXM = new List<HitBuild>();
        }
    }
}
