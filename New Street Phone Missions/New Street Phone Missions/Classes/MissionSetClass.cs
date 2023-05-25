using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class Truckers
    {
        public int Area { get; set; }
        public int Type { get; set; }
        public string Trailer { get; set; }
        public Vector3 FuStop { get; set; }
        public Vector4 TruckStop { get; set; }
        public Vector4 TrailStop { get; set; }
        public Vector4 ExitDoor { get; set; }

        public Truckers()
        {
            Area = 0;
            Type = 0;
            Trailer = "";
            FuStop = new Vector3();
            TruckStop = new Vector4();
            TrailStop = new Vector4();
            ExitDoor = new Vector4();
        }
        public Truckers(int zone, int type, string trailer, Vector3 fubarStop, Vector4 truckStop, Vector4 trailerStop, Vector4 pedStop)
        {
            Area = zone;
            Type = type;
            Trailer = trailer;
            FuStop = fubarStop;
            TruckStop = truckStop;
            TrailStop = trailerStop;
            ExitDoor = pedStop;
        }
    }
    public class PhishingSpot
    {
        public Vector3 Spot { get; set; }
        public Vector4 Phish { get; set; }

        public PhishingSpot(Vector3 spot, Vector4 phish)
        {
            Spot = spot;
            Phish = phish;
        }
    }
    public class LoanSharks
    {
        public int Zone { get; set; }
        public Vector3 FuPark { get; set; }
        public Vector4 SubPark { get; set; }
        public Vector3 Target { get; set; }

        public LoanSharks()
        {
            Zone = 0;
            FuPark = new Vector3();
            SubPark = new Vector4();
            Target = new Vector3();
        }
        public LoanSharks(int zone, Vector3 fuPark, Vector4 subPark, Vector3 target)
        {
            Zone = zone;
            FuPark = fuPark;
            SubPark = subPark;
            Target = target;
        }
    }
    public class GreatestHits
    {
        public int MobStars { get; }
        public Vector3 FubarStop { get; }
        public Vector3 StartPoint { get; }
        public Vector4 Boss { get; }
        public Vector4 Goon1 { get; }
        public Vector4 Goon2 { get; }
        public List<Vector3> GoonPath1 { get; }
        public List<Vector3> GoonPath2 { get; }
        public List<Vector3> GoonPath3 { get; }
        public List<PropLists> SomeProp { get; }

        public GreatestHits(int mobStars, Vector3 fuPark, Vector3 startPoint, Vector4 boss, Vector4 goon1, Vector4 goon2, List<Vector3> goonPath1, List<Vector3> goonPath2, List<Vector3> goonPath3, List<PropLists> someProp)
        {
            MobStars = mobStars;
            FubarStop = fuPark;
            StartPoint = startPoint;
            Boss = boss;
            Goon1 = goon1;
            Goon2 = goon2;
            GoonPath1 = goonPath1;
            GoonPath2 = goonPath2;
            GoonPath3 = goonPath3;
            SomeProp = someProp;
        }
    }
    public class PrePack
    {
        public int Zone { get; set; }
        public bool DeliverAll { get; set; }
        public bool LiveExports { get; set; }
        public Vector3 FuStop { get; set; }
        public Vector4 PackVeh { get; set; }
        public string PackVehName { get; set; }
        public string PackDropType { get; set; }
        public int Paint1 { get; set; }
        public int Paint2 { get; set; }
        public int Livery { get; set; }
        public List<Vector3> PackDrops { get; set; }
        public List<string> PackType { get; set; }

        public PrePack(int zone, bool deliverAll, bool liveExports, Vector3 fuStop, Vector4 packVeh, string packVehName, string packDropType, int paint1, int paint2, int livery, List<Vector3> packDrops, List<string> packType)
        {
            Zone = zone;
            DeliverAll = deliverAll;
            LiveExports = liveExports;
            FuStop = fuStop;
            PackVeh = packVeh;
            PackVehName = packVehName;
            PackDropType = packDropType;
            Paint1 = paint1;
            Paint2 = paint2;
            Livery = livery;
            PackDrops = packDrops;
            PackType = packType;
        }
    }
    public class SnipSnip
    {
        public Vector3 FuPark { get; }
        public bool OnBike { get; }
        public bool FlyChopper { get; }
        public bool Booater { get; }
        public bool Convertables { get; }
        public bool FollowClose { get; }
        public bool TheUfo { get; }
        public float VehSpeed { get; set; }
        public string ThisVeh { get; }
        public string SpairVeh { get; }
        public Vector4 VehiclePark { get; }
        public Vector4 GunCase { get; }
        public Vector3 VantagePoint { get; }
        public Vector3 DriveToo { get; }
        public List<string> Players { get; }
        public List<Vector3> GoHere { get; }
        public List<Vector3> TargPath { get; }

        public SnipSnip(Vector3 fuPark, bool onBike, bool flyChopper, bool booater, bool convertables, bool followClose, bool theUfo, float vehSpeed, string thisVeh, string spairVeh, Vector4 vehiclePark, Vector4 gunCase, Vector3 vantagePoint, Vector3 driveToo, List<string> players, List<Vector3> goHere, List<Vector3> targPath)
        {
            FuPark = fuPark;
            OnBike = onBike;
            FlyChopper = flyChopper;
            Booater = booater;
            Convertables = convertables;
            FollowClose = followClose;
            TheUfo = theUfo;
            VehSpeed = vehSpeed;
            ThisVeh = thisVeh;
            SpairVeh = spairVeh;
            VehiclePark = vehiclePark;
            GunCase = gunCase;
            VantagePoint = vantagePoint;
            DriveToo = driveToo;
            Players = players;
            GoHere = goHere;
            TargPath = targPath;
        }
    }
    public class BombSquad
    {
        public int Zone { get; set; }
        public Vector3 FuPark { get; set; }
        public List<Vector4> BombLoc { get; set; }

        public BombSquad()
        {
            Zone = 0;
            FuPark = new Vector3();
            BombLoc = new List<Vector4>();
        }
        public BombSquad(int zone, Vector3 fuPark, List<Vector4> bombLoc)
        {
            Zone = zone;
            FuPark = fuPark;
            BombLoc = bombLoc;
        }
    }
    public class GetawaysEnd
    {
        public Vector3 Target01 { get; set; }

        public string EndVeh { get; set; }
        public Vector4 EndVehPos { get; set; }
        public bool Fly { get; set; }

        public GetawaysEnd(Vector3 target01, string endVeh, Vector4 endVehPos, bool fly)
        {
            Target01 = target01;
            EndVeh = endVeh;
            EndVehPos = endVehPos;
            Fly = fly;
        }
    }
    public class Getaways
    {
        public int Zone { get; set; }

        public Vector3 Ped01 { get; set; }
        public Vector3 Ped02 { get; set; }
        public Vector3 Ped03 { get; set; }
        public Vector3 Robbers { get; set; }


        public Vector3 Target01 { get; set; }
        public Vector3 Target02 { get; set; }

        public Getaways(int zone, Vector3 ped01, Vector3 ped02, Vector3 ped03, Vector3 robbers, Vector3 target01, Vector3 target02)
        {
            Zone = zone;
            Ped01 = ped01;
            Ped02 = ped02;
            Ped03 = ped03;
            Robbers = robbers;
            Target01 = target01;
            Target02 = target02;
        }
    }
    public class FubarVectors
    {
        public int Zone { get; set; }
        public Vector4 ParkHere { get; set; }
        public Vector4 PedHere { get; set; }
        public string Name { get; set; }
        public int PedNum { get; set; }

        public FubarVectors()
        {
            Zone = 0;
            ParkHere = new Vector4();
            PedHere = new Vector4();
            Name = "";
            PedNum = 0;
        }
        public FubarVectors(int zone, Vector4 park, Vector4 ped, string name, int pedNum)
        {
            Zone = zone;
            ParkHere = park;
            PedHere = ped;
            Name = name;
            PedNum = pedNum;
        }
        public FubarVectors(int zone, Vector3 park, Vector4 ped, string name, int pedNum)
        {
            Zone = zone;
            ParkHere = new Vector4(park.X, park.Y, park.Z, 0f);
            PedHere = ped;
            Name = name;
            PedNum = pedNum;
        }
    }
    public class ConsOnParade
    {
        public int Zone { get; set; }
        public Vector3 FuPark { get; set; }
        public Vector4 BusPark { get; set; }
        public List<Vector3> ConMarch { get; set; }

        public ConsOnParade(int zone, Vector3 fuPark, Vector4 busPark, List<Vector3> conMarch)
        {
            Zone = zone;
            FuPark = fuPark;
            BusPark = busPark;
            ConMarch = conMarch;
        }
    }

}
