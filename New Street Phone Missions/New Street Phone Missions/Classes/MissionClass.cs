using GTA;
using GTA.Math;
using GTA.Native;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class Trucking
    {
        public int YourTruck { get; set; }
        public int DeTatchTime { get; set; }
        public int DeTatchAm { get; set; }
        public int ParkinBonus { get; set; }
        public int CashPaid { get; set; }
        public int CashTotal { get; set; }
        public float Distace { get; set; }
        public bool Attached { get; set; }
        public bool AttachedLablel { get; set; }
        public bool WheelCheck { get; set; }
        public bool Car { get; set; }
        public bool Tractor { get; set; }
        public bool Army { get; set; }
        public Vehicle Truck { get; set; }
        public Vehicle Trail { get; set; }
        public Vehicle Trail2 { get; set; }
        public Vehicle Proper { get; set; }
        public List<Prop> MullProps { get; set; }

        public Truckers Start { get; set; }
        public Truckers Finish { get; set; }

        public Trucking(int area)
        {
            YourTruck = 0;
            DeTatchTime = 0;
            DeTatchAm = 0;
            ParkinBonus = 0;
            CashPaid = 0;
            CashTotal = 0;
            Distace = 0f;

            Attached = false;
            AttachedLablel = false;
            WheelCheck = true;
            Car = false;
            Tractor = false;
            Army = false;
            Proper = null;
            MullProps = new List<Prop>();

            Start = MissionData.FindTruckers(area, -1);

            if (Start.Type == 12)
                Finish = new Truckers(6, 12, "trailerlogs", new Vector3(-574.304f, 5259.440f, 69.960f), new Vector4(-602.699f, 5290.511f, 70.601f, -136.343f), new Vector4(-578.637f, 5325.932f, 72.091f, 158.663f), new Vector4(-565.373f, 5325.919f, 73.584f, 68.530f));
            else
                Finish = MissionData.FindTruckers(area, Start.Type);

            if (Start.Type < 3)
            {
                Truck = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.TowingList[0], 1, 66, true, DataStore.MyLang.Maptext[1]), Start.TruckStop);
                Car = true;
            }
            else if (Start.Type == 3 || Start.Type == 4)
            {
                Truck = EntityBuild.VehicleSpawn(new VehMods("TRACTOR2", 1, 66, true, DataStore.MyLang.Maptext[1]), Start.TruckStop);
                Tractor = true;
            }
            else
                Truck = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.TruckList[0], 1, 66, true, DataStore.MyLang.Maptext[1]), Start.TruckStop);

            Trail = EntityBuild.VehicleSpawn(new VehMods(Start.Trailer), Start.TrailStop);
            Trail2 = EntityBuild.VehicleSpawn(new VehMods(Start.Trailer), Finish.TrailStop);
        }
    }
    public class GetDriver
    {
        public int Time01 { get; set; }
        public int LoseCops { get; set; }
        public int CashTotal { get; set; }
        public int CashLoss { get; set; }
        public int CashEarning { get; set; }
        public int DropShip { get; set; }
        public int ModShopInt { get; set; }
        public int AlarmId { get; set; }
        public bool ModShops { get; set; }
        public bool AlowAir { get; set; }
        public bool PickyDriver { get; set; }
        public bool MoveYourV { get; set; }
        public bool BankAlarm { get; set; }
        public bool SeaterIs4 { get; set; }
        public bool LostDollas { get; set; }
        public bool PedCanFly { get; set; }

        public Ped Robber01 { get; set; }
        public Ped Robber02 { get; set; }
        public Ped Robber03 { get; set; }
        public Getaways MyBank { get; set; }
        public GetawaysEnd MyEnd { get; set; }
        public Vehicle GetAwayVeh { get; set; }
        public Vehicle EndVeh { get; set; }

        public string YourPedMod { get; set; }
        public int OufitMask01 { get; set; }
        public int OufitMask02 { get; set; }

        public List<int> Pennys { get; set; }
        public List<Vector3> ModShopsEnt { get; }
        public List<Vector3> ModShopsEx { get; }

        public GetDriver(Getaways myBank, GetawaysEnd myEnd)
        {
            Time01 = 0;
            CashTotal = 0;
            CashLoss = 0;
            DropShip = 0;
            LoseCops = 0;
            ModShopInt = 0;
            AlarmId = -1;
            ModShops = true;
            AlowAir = false;
            MoveYourV = true;
            PickyDriver = false;
            BankAlarm = false;
            SeaterIs4 = false;
            LostDollas = false;
            PedCanFly = myEnd.Fly;
            Robber01 = null;
            Robber02 = null;
            Robber03 = null;
            MyBank = myBank;
            MyEnd = myEnd;
            Pennys = new List<int>();
            ModShopsEnt = new List<Vector3>
            {
                new Vector3(-1142.929f, -1988.197f, 12.5912f),
                new Vector3(718.0781f, -1088.233f, 21.78904f),
                new Vector3(-359.2726f, -133.6207f, 38.17022f),
                new Vector3(1182.802f, 2650.197f, 37.25154f),
                new Vector3(112.1744f, 6614.023f, 31.302f)
            };
            ModShopsEx = new List<Vector3>
            {
                new Vector3(-1149.228f, -1994.9f, 12.60751f),
                new Vector3(730.2877f, -1088.394f, 21.59595f),
                new Vector3(-348.1726f, -137.1676f, 38.43731f),
                new Vector3(1182.611f, 2639.019f, 37.2223f),
                new Vector3(104.2167f, 6622.179f, 31.25587f)
            };
            YourPedMod = ReturnStuff.WhatpedType();
            if (YourPedMod == "FreeFemale" || YourPedMod == "FreeMale")
            {
                OufitMask01 = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, 1);
                OufitMask02 = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character.Handle, 1);
            }
            else
            {
                OufitMask01 = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, 0);
                OufitMask02 = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character.Handle, 0);
            }
        }
    }
    public class Packaging
    {
        public int Timer01 { get; set; }
        public int Timer02 { get; set; }
        public int Timer03 { get; set; }
        public int PackCount { get; set; }
        public int PackDeliv { get; set; }
        public int ParcelCost { get; set; }
        public int TotalDist { get; set; }
        public int TotalEarnings { get; set; }
        public bool LiveExport { get; set; }
        public bool FirstPack { get; set; }
        public bool MoveYourV { get; set; }
        public bool UseAll { get; set; }

        public string Pacel { get; set; }

        public float CoronaSize { get; set; }
        public Vector3 CurrentPack { get; set; }

        public PrePack MyPacks { get;}

        public Vehicle DeliverVeh { get; set; }

        public List<Vector3> Packlist { get; set; }
        public List<string> Typelist { get; set; }

        private List<Vector3> DeliverOrder(PrePack MyDrops, int iDropIt)
        {
            LoggerLight.LogThis("Packages_DeliverThis, iDropIt == " + iDropIt);

            List<int> DropSelect = new List<int>();
            List<Vector3> DropBox = new List<Vector3>();

            int iRanRange = MyDrops.PackDrops.Count - 1;
            while (iDropIt > 0)
            {
                int iRan = RandomX.RandInt(0, iRanRange);
                if (DropSelect.Count == 0)
                {
                    DropSelect.Add(iRan);
                    DropBox.Add(MyDrops.PackDrops[iRan]);
                    iDropIt = iDropIt - 1;
                }
                else
                {
                    if (!DropSelect.Contains(iRan))
                    {
                        DropSelect.Add(iRan);
                        DropBox.Add(MyDrops.PackDrops[iRan]);
                        iDropIt = iDropIt - 1;
                    }
                }
            }

            Vector3 Far;
            Vector3 Near;
            DropSelect.Clear();
            int ThisOne = 0;
            int ThatOne = 0;
            float fDis = 0f;

            for (int i = 0; i < DropBox.Count; i++)
            {
                Far = DropBox[i];
                for (int ii = 0; ii < DropBox.Count; ii++)
                {
                    if (ii != i)
                    {
                        if (DropBox[ii].DistanceTo(Far) > fDis)
                        {
                            ThisOne = ii;
                            fDis = DropBox[ii].DistanceTo(Far);
                        }
                    }
                }
                DropSelect.Add(ThisOne);
            }
            ThisOne = 0;
            fDis = 0f;
            for (int i = 0; i < DropSelect.Count; i++)
            {
                Far = DropBox[i];
                Near = DropBox[DropSelect[i]];
                if (Far.DistanceTo(Near) > fDis)
                {
                    ThisOne = i;
                    ThatOne = DropSelect[i];
                }
            }
            Far = DropBox[ThisOne];
            Near = DropBox[ThatOne];

            return ReturnStuff.FarToNear(DropBox, Near);
        }

        public Packaging(bool CayoPacks, List<Vector3> packList, List<string> typeList)
        {
            MyPacks = new PrePack(7, true, false, new Vector3(4491.126f, -4535.222f, 4.357188f), new Vector4(4491.126f, -4511.222f, 4.357188f, 289.3603f), "WINKY", "h4_prop_h4_bag_hook_01a", -1, -1, -1, packList, typeList);
            Timer01 = 240000;
            Timer02 = 0;
            Timer03 = 0;
            PackCount = packList.Count;
            PackDeliv = 0;
            ParcelCost = 10;
            TotalDist = 0;
            TotalEarnings = 0;
            LiveExport = false;
            FirstPack = true;
            MoveYourV = true;
            UseAll = true;
            Pacel = "h4_prop_h4_bag_hook_01a";
            CoronaSize = 5.0f;
            DeliverVeh = EntityBuild.VehicleSpawn(new VehMods("WINKY", 0, 66, true, DataStore.MyLang.Maptext[3], false, true, ReturnStuff.FunPlates()), new Vector4(4491.126f, -4511.222f, 4.357188f, 289.3603f));
            Packlist = packList;
            Typelist = typeList;
            CurrentPack = packList[0];
        }
        public Packaging(int area)
        {
            MyPacks = MissionData.FindPack(area);

            PackCount = MyPacks.PackDrops.Count - 1;
            if (MyPacks.PackDropType == "None")
                PackCount = 6;
            else if (MyPacks.PackDrops.Count > 12 && !MyPacks.DeliverAll)
                PackCount = RandomX.RandInt(6, 12);

            Packlist = DeliverOrder(MyPacks, PackCount);

            if (MyPacks.PackVehName == "Mule2" || MyPacks.PackVehName == "Scrap")
            {
                List<int> Extras = new List<int>();
                Extras.Add(MyPacks.Livery);
                DeliverVeh = EntityBuild.VehicleSpawn(new VehMods(MyPacks.PackVehName, 0, 66, true, DataStore.MyLang.Maptext[3], false, ReturnStuff.VehMod(-10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, MyPacks.Paint1, MyPacks.Paint2), Extras, ReturnStuff.FunPlates()), MyPacks.PackVeh);
            }
            else
                DeliverVeh = EntityBuild.VehicleSpawn(new VehMods(MyPacks.PackVehName, 0, 66, true, DataStore.MyLang.Maptext[3], false, true, MyPacks.Paint1, MyPacks.Paint2, MyPacks.Livery, ReturnStuff.FunPlates()), MyPacks.PackVeh);

            LiveExport = MyPacks.LiveExports;
            Pacel = MyPacks.PackDropType;

            Timer02 = 0;
            Timer03 = 0;
            PackDeliv = 0;
            ParcelCost = 0;
            TotalEarnings = 0;

            FirstPack = true;
            MoveYourV = true;
            UseAll = false;
            CoronaSize = 5.0f;
            CurrentPack = Packlist[0];
            Typelist = new List<string>();

            float fTotalDist = Packlist[Packlist.Count - 1].DistanceTo(MyPacks.FuStop);
            float fRoadDist = World.CalculateTravelDistance(Packlist[Packlist.Count - 1], MyPacks.FuStop);

            for (int i = Packlist.Count - 1; i > 0; i--)
            {
                float fDist = Packlist[i].DistanceTo(Packlist[i - 1]);
                fTotalDist += fDist;
            }
            TotalDist = (int)fTotalDist;
            Timer01 = TotalDist * 75;
            fTotalDist *= 2;
            if (fTotalDist < fRoadDist)
                Timer01 *= 2;

        }
    }
    public class ConFetch
    {
        public int Patrol { get; set; }
        public int GoragaTime { get; set; }
        public int CashPayment { get; set; }
        public int TotalTime { get; set; }
        public int TotalChants { get; set; }
        public int NoCoffee { get; set; }
        public int ChantsListen { get; set; }
        public bool WheelCheck { get; set; }
        public bool PrisonAlarm { get; set; }
        public bool HarryChant { get; set; }
        public bool AddOutfit { get; set; }
        public Ped HeadHarry { get; set; }
        public Prop PrisGate { get; set; }
        public Vehicle Bus { get; set; }
        public List<Vector3> PrisonStops { get; set; }
        public Vector3 PrisonStop01 { get; set; }
        public Vector3 PrisonStop02 { get; set; }
        public Vector3 PrisonStop03 { get; set; }
        public Vector3 PrisonStop04 { get; set; }
        public Vector3 PrisonGate01 { get; set; }
        public Vector3 PrisonGate02 { get; set; }
        public Vector4 PrisonEnd { get; set; }

        public ConsOnParade Parade { get; set; }

        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; set; }

        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = new ClothBank("Prison", false, false, true, new ClothX("FrankPris", new List<int> { 0, 1, 0, 18, 6, 0, 6, 0, 0, 0, 0, 3 }, new List<int> { 0, 0, 0, 10, 7, 0, 2, 0, 0, 0, 0, 15 }, new List<int> { }, new List<int> { }));
            else if (sName == "Michael")
                Uniform = new ClothBank("Prison", false, false, true, new ClothX("MickPris", new List<int> { 0, 1, 0, 23, 0, 0, 0, 0, 0, 0, 0, 5 }, new List<int> { 0, 0, 0, 7, 3, 0, 2, 0, 0, 0, 0, 8 }, new List<int> { }, new List<int> { }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("Prison", false, false, true, new ClothX("TrevPris", new List<int> { 0, 1, 0, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeFemale")
                Uniform = new ClothBank("Prison", false, true, false, new ClothX("FFPris", new List<int> { 0, 0, 0, 0, 30, 0, 24, 0, 15, 9, 0, 27 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeMale")
                Uniform = new ClothBank("Prison", false, true, true, new ClothX("FMPris", new List<int> { 0, 0, 0, 11, 31, 0, 24, 0, 15, 4, 0, 26 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { }, new List<int> { }));
            else
                Uniform = null;

            return Uniform;
        }

        public ConFetch(ConsOnParade parade)
        {
            Patrol = 0;
            GoragaTime = 0;
            WheelCheck = true;
            PrisonAlarm = false;
            HarryChant = false;
            AddOutfit = false;
            Bus = null;
            Parade = parade;
            TotalChants = 0;
            ChantsListen = 0;
            PrisonStop01 = new Vector3(1902.072f, 2609.531f, 44.997f);
            PrisonStop02 = new Vector3(1849.796f, 2608.281f, 44.884f);
            PrisonStop03 = new Vector3(1823.499f, 2608.393f, 44.848f);
            PrisonStop04 = new Vector3(1690.85f, 2601.41f, 44.56f);
            PrisonGate01 = new Vector3(1844.998f, 2604.812f, 44.640f);
            PrisonGate02 = new Vector3(1818.543f, 2604.812f, 44.611f);
            PrisonEnd = new Vector4(1846.57f, 2585.8f, 44.67f, 267.83f);

            Oufit = new ClothBank(Game.Player.Character);
            Uniform = UniformCheck(Oufit.Name);
        }
    }
    public class FubarCars
    {
        public int TotalPay { get; set; }
        public int FuMeter { get; set; }
        public int FuFare { get; set; }
        public int Passengers { get; set; }
        public int RepMish { get; set; }
        public int SlideBarPos { get; set; }
        public int HornBlasts { get; set; }
        public bool Attacks { get; set; }
        public bool Radio { get; set; }
        public bool MoveIt { get; set; }
        public bool AirprtRun { get; set; }
        public bool FollowThatCar { get; set; }
        public bool NewDriver { get; set; }
        public Vector3 SpTarg { get; set; }
        public Vector3 PlayerPos { get; set; }
        public Vehicle FubVeh { get; set; }
        public FubarVectors Start { get; set; }
        public FubarVectors End { get; set; }
        public Ped Passenger01 { get; set; }
        public Ped Passenger02 { get; set; }
        public Ped Passenger03 { get; set; }
        public Vehicle ThatCar { get; set; }
        public Ped ThatDriver { get; set; }
        public Ped StartDriver { get; set; }

        public FubarCars(int totalPay, int repMish, Vehicle fubesVeh)
        {
            if (fubesVeh != null)
                NewDriver = false;
            else
                NewDriver = true;

            TotalPay = totalPay;
            FuMeter = 0;
            FuFare = 5;
            Passengers = 0;
            RepMish = repMish;
            SlideBarPos = 0;
            HornBlasts = 0;
            Attacks = false;
            Radio = false;
            MoveIt = true;
            FollowThatCar = false;
            SpTarg = Vector3.Zero;
            PlayerPos = Vector3.Zero;
            FubVeh = fubesVeh;
            Start = null;
            End = null;
            Passenger01 = null;
            Passenger02 = null;
            Passenger03 = null;
            ThatCar = null;
            ThatDriver = null;
            StartDriver = null;
        }
    }
    public class DeliverBert
    {
        public int CashPay { get; set; }
        public int TimeLeft { get; set; }
        public int BullsEyes { get; set; }
        public bool InFort { get; set; }
        public Vector3 Target01 { get; set; }
        public Vector3 Target02 { get; set; }
        public Vector3 Target03 { get; set; }
        public Vector4 BertPark { get; set; }
        public Vector4 EndPoint01 { get; set; }
        public Vehicle Bert { get; set; }

        public DeliverBert()
        {
            CashPay = 150000;
            TimeLeft = 0;
            BullsEyes = 0;
            InFort = true;
            Target01 = new Vector3(-1576.321f, 2786.125f, 15.9334f);
            Target02 = new Vector3(1713.36f, 3253.13f, 40.07f);
            Target03 = new Vector3(2127.9f, 4806.1f, 40.19f);
            BertPark = new Vector4(-2477.7f, 3258.43f, 31.77f, 160.00f);
            EndPoint01 = new Vector4(2159.819f, 4789.745f, 40.73829f, 106.2993f);
            Bert = null;
        }
    }
    public class CeoImpExp
    {
        public int Patrol { get; set; }
        public float DistanceB4 { get; set; }
        public float DistanceReq { get; set; }
        public bool GoHigh { get; set; }
        public List<Vector3> FlyBy { get; set; }
        public List<Vector3> Stairs { get; set; }
        public Vector3 Targ01 { get; set; }
        public Vector3 Targ02 { get; set; }
        public Vector3 Higher { get; set; }
        public Vector4 HeliPos { get; set; }
        public Ped Pilot { get; set; }
        public Vehicle Heli { get; set; }
        public Vehicle Carg { get; set; }
        public Vehicle Car { get; set; }

        public CeoImpExp()
        {
            Patrol = 0;
            DistanceB4 = 0f;
            DistanceReq = 0f;
            GoHigh = false;
            Stairs = new List<Vector3> { new Vector3(2543.80f, -334.29f, 93.10f), new Vector3(2539.93f, -330.10f, 96.70f) };
            Higher = Vector3.Zero;
            HeliPos = new Vector4(2510.70f, -342.00f, 117.13f, 90.00f);
            Heli = null;
            Carg = null;
            Car = null;
            int iRandomDrops = RandomX.FindRandom("Pilot401", 1, 3);

            if (iRandomDrops == 1)
            {
                string Bargey = "prop_ind_barge_01_cr";
                Vector3 posy = new Vector3(3670.565f, 2609.00f, 0.10f);
                Vector3 Rota = new Vector3(0.00f, 0.00f, 98.40f);
                EntityBuild.BuildProp(Bargey, posy, Rota, true, true);

                posy = new Vector3(3637.07f, 2528.74f, 0.10f);
                Rota = new Vector3(0.00f, 0.00f, -169.60f);
                EntityBuild.BuildProp(Bargey, posy, Rota, true, true);

                Targ01 = new Vector3(3611.642f, 2528.678f, 512.2806f);
                Targ02 = new Vector3(-505.2578f, -2193.864f, 31.27496f);
                FlyBy = new List<Vector3> { Targ02, new Vector3(-253.8699f, -1835.442f, 227.2719f), new Vector3(431.698f, -806.3925f, 306.9451f), new Vector3(995.6508f, -0.3318772f, 394.4747f), new Vector3(1359.407f, 494.0837f, 442.5105f), new Vector3(1822.196f, 1146.567f, 460.0574f), new Vector3(2197.234f, 1622.248f, 445.9396f), new Vector3(2713.421f, 2018.943f, 465.5262f), new Vector3(2995.679f, 2217.538f, 515.8416f) };
            }
            else if (iRandomDrops == 2)
            {
                string sBargey = "prop_ind_barge_01_cr";
                Vector3 posy = new Vector3(-3300.00f, 2437.00f, 0.10f);
                Vector3 Rota = new Vector3(0.00f, 0.00f, -90.40f);
                EntityBuild.BuildProp(sBargey, posy, Rota, true, true);

                posy = new Vector3(-3296.00f, 2407.21f, 1.00f);
                Rota = new Vector3(0.00f, 0.00f, 178.50f);
                EntityBuild.BuildProp(sBargey, posy, Rota, true, true);

                Targ01 = new Vector3(-3300.00f, 2437.00f, 521.408f);
                Targ02 = new Vector3(1764.635f, -1650.477f, 124.0762f);
                FlyBy = new List<Vector3> { Targ02, new Vector3(1665.258f, -1532.604f, 204.2363f), new Vector3(1495.177f, -1398.264f, 187.2499f), new Vector3(315.7495f, -336.6328f, 259.5117f), new Vector3(-304.0422f, 172.7121f, 319.8065f), new Vector3(-949.6682f, 701.1384f, 383.1638f), new Vector3(-1403.295f, 1085.122f, 403.0447f), new Vector3(-1913.291f, 1420.218f, 433.8033f), new Vector3(-2504.913f, 1880.594f, 490.6801f) };
            }
            else
            {
                string sBargey = "prop_ind_barge_01_cr";
                Vector3 posy = new Vector3(-2333.73f, 5065.85f, 0.10f);
                Vector3 Rota = new Vector3(0.00f, 0.00f, -90.40f);
                EntityBuild.BuildProp(sBargey, posy, Rota, true, true);

                posy = new Vector3(-2306.34f, 5148.768f, 0.10f);
                Rota = new Vector3(0.00f, 0.00f, 178.50f);
                EntityBuild.BuildProp(sBargey, posy, Rota, true, true);

                Targ01 = new Vector3(-2335.00f, 5127.00f, 529.949f);
                Targ02 = new Vector3(1203.487f, -1269.62f, 49.9391f);
                FlyBy = new List<Vector3> { Targ02, new Vector3(1098.566f, -1081.197f, 206.9486f), new Vector3(901.7145f, -528.7383f, 230.9604f), new Vector3(526.3968f, 256.4404f, 297.1049f), new Vector3(268.4175f, 854.5297f, 335.7408f), new Vector3(-4.271536f, 1384.082f, 377.8856f), new Vector3(-224.9484f, 1741.988f, 393.4701f), new Vector3(-685.1597f, 2187.614f, 379.6081f), new Vector3(-1282.026f, 2777.223f, 380.9995f), new Vector3(-1706.212f, 3642.564f, 397.6057f), new Vector3(-2061.499f, 4527.216f, 495.0395f) };
            }
        }
    }
    public class CropDusting
    {
        public int MuckLeft { get; set; }
        public int CurrentTarg { get; set; }
        public bool Spray { get; set; }
        public bool EcoWar { get; set; }
        public List<Vector3> StartPos { get; set; }
        public List<Vector3> StartRot { get; set; }
        public List<Vector3> EndPos { get; set; }
        public List<Vector3> EndRot { get; set; }
        public Vector3 FlyUp { get; set; }
        public Vector3 FlyUpRot { get; set; }
        public Vector4 PlaneStart { get; set; }
        public Vehicle Plane { get; set; }
        public BlipForm BlipStart { get; set; }
        public BlipForm BlipEnd { get; set; }

        public CropDusting()
        {
            CurrentTarg = 0;
            Spray = false;
            EcoWar = true;
            CurrentTarg = 0;
            FlyUp = new Vector3(1833.0f, 4667.55f, 65.0f);
            FlyUpRot = new Vector3(0f, 0f, 116f);
            PlaneStart = new Vector4(2130.47f, 4812.37f, 40.22f, 117.50f);
            Plane = EntityBuild.VehicleSpawn(new VehMods("Duster", 0, 66, true, DataStore.MyLang.Maptext[6]), PlaneStart);
            BlipStart = new BlipForm(FlyUp);
            BlipStart.Colour = 5;
            BlipStart.NameTag = DataStore.MyLang.Maptext[36];
            BlipEnd = new BlipForm(FlyUp);
            BlipEnd.Colour = 14;
            BlipEnd.NameTag = DataStore.MyLang.Maptext[36];

            int iRandomDrops = RandomX.FindRandom("Pilot501", 1, 6);
            LoggerLight.LogThis("Pilot501, iRandomDrops == " + iRandomDrops);

            if (iRandomDrops == 1)
            {
                MuckLeft = 17000;
                StartPos = new List<Vector3> { new Vector3(1836.857f, 4792.003f, 54.107f), new Vector3(2090.101f, 4935.004f, 52.463f), new Vector3(1857.534f, 4762.872f, 56.013f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -43.012f), new Vector3(0.666f, -1.266f, 134.382f), new Vector3(0.666f, -1.266f, -47.019f) };
                EndPos = new List<Vector3> { new Vector3(1945.719f, 4909.024f, 61.390f), new Vector3(1890.473f, 4743.527f, 55.533f), new Vector3(2061.847f, 4961.715f, 52.610f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -45.006f), new Vector3(0.666f, -1.266f, 133.108f), new Vector3(0.666f, -1.266f, -44.717f) };
            }
            else if (iRandomDrops == 2)
            {
                MuckLeft = 15000;
                StartPos = new List<Vector3> { new Vector3(2093.886f, 5211.945f, 69.548f), new Vector3(2350.424f, 5088.414f, 63.324f), new Vector3(2151.515f, 5219.998f, 73.511f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -142.974f), new Vector3(0.666f, -1.266f, 46.414f), new Vector3(0.666f, 3.734f, -140.867f) };
                EndPos = new List<Vector3> { new Vector3(2271.262f, 5025.586f, 57.892f), new Vector3(2279.597f, 5159.357f, 71.642f), new Vector3(2300.785f, 5045.833f, 61.735f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -137.152f), new Vector3(0.666f, -1.266f, 45.757f), new Vector3(0.666f, 0.734f, -134.632f) };
            }
            else if (iRandomDrops == 3)
            {
                MuckLeft = 14000;
                StartPos = new List<Vector3> { new Vector3(2458.095f, 4643.126f, 48.923f), new Vector3(2472.084f, 4873.173f, 53.888f), new Vector3(2872.177f, 4540.979f, 65.857f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 45.429f), new Vector3(0.666f, -1.266f, -137.956f), new Vector3(0.666f, -0.266f, 12.650f) };
                EndPos = new List<Vector3> { new Vector3(2317.012f, 4765.431f, 50.957f), new Vector3(2679.038f, 4673.367f, 60.983f), new Vector3(2842.322f, 4679.817f, 57.777f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 55.524f), new Vector3(0.666f, -1.266f, -120.979f), new Vector3(0.666f, 0.734f, 14.548f) };
            }
            else if (iRandomDrops == 4)
            {
                MuckLeft = 19500;
                StartPos = new List<Vector3> { new Vector3(2508.185f, 4315.346f, 52.760f), new Vector3(2693.059f, 4566.074f, 61.967f), new Vector3(2488.606f, 4469.289f, 54.285f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -42.240f), new Vector3(-1.334f, 0.734f, 133.961f), new Vector3(0.666f, -0.266f, -49.055f) };
                EndPos = new List<Vector3> { new Vector3(2692.552f, 4508.127f, 69.700f), new Vector3(2475.044f, 4344.526f, 53.075f), new Vector3(2651.592f, 4633.721f, 51.175f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, -41.984f), new Vector3(0.666f, -1.266f, 132.628f), new Vector3(-3.334f, -1.266f, -45.500f) };
            }
            else if (iRandomDrops == 5)
            {
                MuckLeft = 17000;
                StartPos = new List<Vector3> { new Vector3(764.107f, 6466.126f, 51.939f), new Vector3(394.741f, 6473.461f, 42.819f), new Vector3(144.498f, 6505.035f, 47.830f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 83.054f), new Vector3(-1.334f, 0.734f, 89.853f), new Vector3(0.666f, -0.266f, -85.531f) };
                EndPos = new List<Vector3> { new Vector3(457.598f, 6492.778f, 49.332f), new Vector3(212.665f, 6452.445f, 48.034f), new Vector3(393.875f, 6518.031f, 50.243f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 88.530f), new Vector3(0.666f, -1.266f, 97.463f), new Vector3(-3.334f, -1.266f, -92.015f) };
            }
            else
            {
                MuckLeft = 27000;
                StartPos = new List<Vector3> { new Vector3(-1566.834f, 2186.634f, 91.458f), new Vector3(-1911.472f, 2239.790f, 104.249f), new Vector3(-1701.324f, 1903.868f, 166.029f), new Vector3(-2008.307f, 1894.075f, 219.071f) };
                StartRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 43.497f), new Vector3(-1.334f, 0.734f, -107.417f), new Vector3(0.666f, -0.266f, 29.475f), new Vector3(-3.334f, -1.266f, -87.934f) };
                EndPos = new List<Vector3> { new Vector3(-1786.040f, 2370.058f, 70.047f), new Vector3(-1669.660f, 2185.879f, 126.103f), new Vector3(-1920.891f, 2148.492f, 143.253f), new Vector3(-1677.932f, 2031.796f, 132.350f) };
                EndRot = new List<Vector3> { new Vector3(0.666f, 0.734f, 52.604f), new Vector3(0.666f, -1.266f, -99.441f), new Vector3(-3.334f, -1.266f, 50.378f), new Vector3(-3.334f, -1.266f, -66.247f) };
            }
        }
    }
    public class HiggsTours
    {
        public int FlyToo { get; set; }
        public bool TakePhotos { get; set; }
        public bool GetinHeli { get; set; }
        public Vector4 HeliPark { get; set; }
        public Vector4 HeliDoor { get; set; }
        public Vehicle HiggsHeli { get; set; }
        public Ped Pass01 { get; set; }
        public Ped Pass02 { get; set; }
        public List<Vector3> FlightPath { get; set; }

        public HiggsTours()
        {
            FlyToo = 0;
            TakePhotos = false;
            GetinHeli = false;
            HeliPark = new Vector4(-279.598f, 6130.19f, 31.28f, 262.7f);
            HeliDoor = new Vector4(-267.95f, 6141f, 31.53f, 121f);
            HiggsHeli = null;
            Pass01 = null;
            Pass02 = null;
            FlightPath = new List<Vector3>();
        }
    }
    public class LsHealthTrust
    {
        public int Zone { get; set; }
        public int Timer { get; set; }
        public int TimeVFx { get; set; }
        public int Condition { get; set; }
        public int HospPay { get; set; }
        public int TotalPay { get; set; }
        public int PatientsSeen { get; set; }
        public int Fatalitys { get; set; }
        public int CorectDiagnosis { get; set; }
        public bool InTheClub { get; set; }
        public bool Covid { get; set; }
        public bool TimerOn { get; set; }
        public bool PatentOn { get; set; }
        public bool Fakeill { get; set; }
        public bool HalfTime { get; set; }
        public bool ClearWay { get; set; }
        public bool UniformOn { get; set; }

        public string Hospital01 { get; }
        public string Hospital02 { get; }

        public Vector4 AmbPark01 { get; }
        public FubarVectors FubStuff { get; }

        public Vector3 FuStop { get; }

        public Vector3 AnE { get; }
        public Vector3 AnEWalk { get; }

        public List<Vector4> IntDoors { get; set; }

        public Ped VicTim { get; set; }
        public Vehicle Ambuantz { get; set; }
        public List<string> PatentVFx { get; set; }

        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; set; }

        private readonly List<int> FubPick = new List<int> { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11 };
        private readonly List<Vector3> HospDrop = new List<Vector3>
        {
            new Vector3(294.7004f, -1438.589f, 29.57073f),
            new Vector3(364.243f, -591.9498f, 28.45424f),
            new Vector3(-491.9989f, -338.0699f, 34.13896f),
            new Vector3(1156.427f, -1514.197f, 34.4624f),
            new Vector3(1812.815f, 3685.532f, 33.99445f),
            new Vector3(-230.7089f, 6311.587f, 31.08541f)
        };
        private readonly List<Vector3> HospWalk = new List<Vector3>
        {
            new Vector3(293.375f, -1447.216f, 28.96661f),
            new Vector3(360.33f, -585.2116f, 27.82215f),
            new Vector3(-498.5107f, -335.5233f, 33.50176f),
            new Vector3(1150.835f, -1529.658f, 34.37185f),
            new Vector3(1815.922f, 3679.053f, 33.27645f),
            new Vector3(-243.843f, 6325.763f, 31.42619f)
        };
        private readonly List<Vector4> HospTrust = new List<Vector4>
        {
            new Vector4(328.9428f, -1472.228f, 29.51733f, 231.2519f),
            new Vector4(341.4239f, -560.3026f, 28.51324f, 337.9559f),
            new Vector4(-419.0133f, -333.0517f, 32.87f, 352.5294f),
            new Vector4(1116.722f, -1502.635f, 34.46165f, 268.4588f),
            new Vector4(1827.306f, 3693.122f, 33.993f, 299.4382f),
            new Vector4(-267.2005f, 6337.363f, 32.18432f, 88.0215f)
        };
        private readonly List<string> HospNamez = new List<string>
        {
            "Central Los Santos Medical Center",
            "Pillbox Hill Medical Center",
            "Mount Zonah Medical Center",
            "St. Fiacre Hospital",
            "Sandy Shores Medical Center",
            "The Bay Care Center"
        };
        private readonly List<ClothBank> FreeFOut = new List<ClothBank>
        {
            new ClothBank("Medic", false, true, false, new ClothX("FFMed", new List<int> { 0, 0, 0, 105, 99, 0, 52, 96, 3, 0, 65, 257 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 121 }, new List<int> { 1 })),
            new ClothBank("Medic", false, true, false, new ClothX("FFMed", new List<int> { 0, 0, 0, 105, 99, 0, 52, 96, 3, 0, 65, 257 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 121 }, new List<int> { 0 })),
            new ClothBank("Medic", false, true, false, new ClothX("FFMed", new List<int> { 0, 0, 0, 109, 99, 0, 52, 97, 3, 0, 66, 258 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 121 }, new List<int> { 1 })),
            new ClothBank("Medic", false, true, false, new ClothX("FFMed", new List<int> { 0, 0, 0, 109, 99, 0, 52, 97, 3, 0, 66, 258 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 121 }, new List<int> { 0 }))

        };
        private readonly List<ClothBank> FreeMOut = new List<ClothBank>
        {
          new ClothBank("Medic", false, true, true, new ClothX("FMMed", new List<int> { 0, 0, 0, 90, 96, 0, 51, 126, 15, 0, 57, 249 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 122 }, new List<int> { 1 })),
          new ClothBank("Medic", false, true, true, new ClothX("FMMed", new List<int> { 0, 0, 0, 90, 96, 0, 51, 126, 15, 0, 57, 249 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 122 }, new List<int> { 0 })),
          new ClothBank("Medic", false, true, true, new ClothX("FMMed", new List<int> { 0, 0, 0, 85, 96, 0, 51, 127, 15, 0, 58, 250 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 }, new List<int> { 122 }, new List<int> { 0 })),
          new ClothBank("Medic", false, true, true, new ClothX("FMMed", new List<int> { 0, 0, 0, 85, 96, 0, 51, 127, 15, 0, 58, 250 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 }, new List<int> { 122 }, new List<int> { 0 }))
        };

        public LsHealthTrust(int zone, bool covid, Vehicle ambuantz, int patientsSeen, int fatalitys, int totalPay, int corectDiagnosis, bool uniformOn, ClothBank oufit)
        {
            Zone = zone;
            if (zone == 1)
            {
                FuStop = new Vector3(349.6006f, -1487.052f, 28.75062f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            else if (zone == 2)
            {
                FuStop = new Vector3(366.1713f, -540.9857f, 28.22815f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            else if (zone == 3)
            {
                FuStop = new Vector3(-415.4373f, -300.6146f, 34.15752f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            else if (zone == 4)
            {
                FuStop = new Vector3(1143.186f, -1490.784f, 34.17999f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            else if (zone == 5)
            {
                FuStop = new Vector3(1824.192f, 3701.154f, 33.23653f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            else
            {
                FuStop = new Vector3(-222.471f, 6318.833f, 30.83202f);
                Hospital01 = HospNamez[zone - 1];
                AmbPark01 = HospTrust[zone - 1];
            }
            Timer = 0;
            TimeVFx = 0;
            HospPay = 0;
            TotalPay = totalPay;
            PatientsSeen = patientsSeen;
            Fatalitys = fatalitys;
            CorectDiagnosis = corectDiagnosis;
            Covid = covid;
            if (Covid)
                Condition = 2;
            else
                Condition = RandomX.FindRandom("LsHealthTrust01", 1, 5);
            InTheClub = false;
            TimerOn = false;
            PatentOn = false;
            Fakeill = false;
            HalfTime = false;
            ClearWay = true;
            UniformOn = uniformOn;

            FubStuff = MissionData.PickUpApartmentBlocks(zone, RandomX.FindRandomList("LsHealthTrust02", FubPick), true);
            int iHos = FindNearHosp(FubStuff.PedHere);
            PatentVFx = Fluids(Condition);
            Hospital02 = HospNamez[iHos];
            AnE = ReturnStuff.AlterZHight(HospDrop[iHos], -1f);
            AnEWalk = HospWalk[iHos];
            VicTim = null;
            Ambuantz = ambuantz;
            IntDoors = ReturnStuff.IndoorPed(FubStuff.PedNum);
            if (FubStuff.PedNum > 299 && FubStuff.PedNum < 310)
                InTheClub = true;
            Oufit = oufit;
            Uniform = UniformCheck(Oufit.Name);
        }
        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = null;
            else if (sName == "Michael")
                Uniform = null;
            else if (sName == "Trevor")
                Uniform = null;
            else if (sName == "FreeFemale")
                Uniform = FreeFOut[RandomX.FindRandom("MedicUf", 0, FreeFOut.Count - 1)];
            else if (sName == "FreeMale")
                Uniform = FreeMOut[RandomX.FindRandom("MedicUm", 0, FreeMOut.Count - 1)];
            else
                Uniform = null;

            return Uniform;
        }
        private int FindNearHosp(Vector4 Nearest)
        {
            int iBeNear = 0;
            float fNear = 9999f;
            for (int i = 0; i < HospDrop.Count; i++)
            {
                float f = HospDrop[i].DistanceTo(Nearest.V3);
                if (f < fNear)
                {
                    iBeNear = i;
                    fNear = f;
                }
            }
            return iBeNear;
        }
        private List<string> Fluids(int iMessy)
        {
            List<string> fluids = new List<string>();

            if (iMessy == 1)
            {
                fluids.Add("scr_solomon3");
                fluids.Add("scr_trev4_747_blood_splash");
                fluids.Add("cut_trevor1");
                fluids.Add("cs_trev1_blood_pool");
                fluids.Add("core");
                fluids.Add("ped_foot_decal_blood");
            }
            else if (iMessy == 3)
            {
                fluids.Add("cut_chinese1");
                fluids.Add("cs_cig_exhale_mouth");
                fluids.Add("cut_chinese1");
                fluids.Add("cs_cig_smoke");
                fluids.Add("core");
                fluids.Add("ent_amb_smoke_factory_white");
            }
            else if (iMessy == 4)
            {
                fluids.Add("scr_reburials");
                fluids.Add("scr_burial_dirt");
                fluids.Add("scr_player_timetable_scene");
                fluids.Add("scr_pts_vomit_water");
                fluids.Add("core");
                fluids.Add("ent_amb_fly_swarm");
            }

            return fluids;
        }
    }
    public class FollowOn
    {
        public int Ending { get; set; }
        public int RollTime { get; set; }
        public int SpookTime { get; set; }
        public int FlashTime { get; set; }
        public int DriveStyle { get; set; }
        public int Attackers { get; set; }
        public int YourReward { get; set; }
        public int TrigeredWar { get; set; }
        public int DoorIsJammed { get; set; }
        public float SpookBar { get; set; }
        public bool Rollover { get; set; }
        public bool DistanceBar { get; set; }
        public bool CountDown { get; set; }
        public bool BarFlash { get; set; }
        public bool NearTrig { get; set; }
        public bool ExitVeh { get; set; }

        public Ped Driver { get; set; }
        public Ped Passenger { get; set; }
        public Ped Pilot { get; set; }
        public Vehicle TargetCar { get; set; }
        public Vehicle Heli { get; set; }
        public Prop Ufo01 { get; set; }
        public Prop Ufo02 { get; set; }
        public Vector3 Starting { get; set; }
        public List<Vector4> ShopFits { get; set; }
        public List<Vector3> Endings { get; set; }
        public FubarVectors ShopsNTings { get; set; }

        public FollowOn(int zone, int ending)
        {
            Ending = ending;
            RollTime = 0;
            TrigeredWar = 0;
            Rollover = false;
            DistanceBar = false;
            CountDown = false;
            BarFlash = false;
            FlashTime = 0;
            NearTrig = true;
            DriveStyle = 1073742652;
            ExitVeh = true;
            Attackers = 0;
            DoorIsJammed = 10;

            Driver = null;
            Passenger = null;
            Pilot = null;
            TargetCar = null;
            Heli = null;
            Ufo01 = null;
            Ufo02 = null;

            Endings = new List<Vector3>();

            YourReward = RandomX.RandInt(15000, 20000);

            if (zone == 1)
            {
                if (Ending == 1)//npc travel to althoraties--fib/etc
                {
                    Endings.Add(new Vector3(368.7477f, -1568.24f, 29.28557f));//--car stop
                    Endings.Add(new Vector3(360.5464f, -1584.165f, 29.29195f));//--runto
                }            //Take out the two npc's route the npcs--find safe house for each zone.MissionData.iMissionVar_01 = 1
                else if (Ending == 2)//npc travel to blow up spot
                {
                    int iRanEnd = RandomX.FindRandom("Follow03", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(-437.6096f, -1704.746f, 18.94966f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(-731.9896f, -2560.919f, 13.93453f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(783.9597f, -2929.598f, 5.800724f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(-297.8011f, -2713.138f, 6.000298f));
                    else
                        Endings.Add(new Vector3(-187.9903f, -1301.621f, 31.29597f));

                }       //Follow to end then arial atack the car at end point.MissionData.iMissionVar_01 = 2
                else if (Ending == 3)//ambush player
                {
                    int iRanEnd = RandomX.FindRandom("Follow04", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(999.9817f, -1920.401f, 31.15648f));//ppark
                        Endings.Add(new Vector3(1001.085f, -1909.005f, 31.15184f));
                        Endings.Add(new Vector3(994.9072f, -1912.883f, 31.26537f));
                        Endings.Add(new Vector3(992.6656f, -1927.637f, 31.37469f));
                        Endings.Add(new Vector3(986.9272f, -1912.884f, 44.3928f));
                        Endings.Add(new Vector3(988.7305f, -1931.894f, 35.67595f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(518.8981f, -2176.097f, 5.986739f));
                        Endings.Add(new Vector3(499.2652f, -2186.613f, 5.918274f));
                        Endings.Add(new Vector3(505.548f, -2182.211f, 5.918272f));
                        Endings.Add(new Vector3(489.1669f, -2181.408f, 5.918271f));
                        Endings.Add(new Vector3(504.2027f, -2186.368f, 15.84594f));
                        Endings.Add(new Vector3(495.166f, -2209.891f, 13.77124f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(178.7863f, -2191.397f, 6.461947f));
                        Endings.Add(new Vector3(195.5753f, -2200.76f, 6.971621f));
                        Endings.Add(new Vector3(166.6884f, -2212.949f, 13.38672f));
                        Endings.Add(new Vector3(170.4102f, -2223.821f, 6.171021f));
                        Endings.Add(new Vector3(190.8489f, -2228.267f, 6.971613f));
                        Endings.Add(new Vector3(187.6916f, -2223.212f, 5.951487f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(566.9637f, -1762.366f, 29.16897f));
                        Endings.Add(new Vector3(560.9583f, -1775.292f, 33.48081f));
                        Endings.Add(new Vector3(550.8151f, -1770.878f, 33.44263f));
                        Endings.Add(new Vector3(558.4484f, -1754.193f, 33.44262f));
                        Endings.Add(new Vector3(564.6301f, -1751.053f, 29.13364f));
                        Endings.Add(new Vector3(560.729f, -1773.462f, 29.35441f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(-7.208877f, -1413.107f, 29.2934f));
                        Endings.Add(new Vector3(-22.82854f, -1404.624f, 34.38335f));
                        Endings.Add(new Vector3(-23.93618f, -1412.194f, 34.68041f));
                        Endings.Add(new Vector3(1.394263f, -1389.828f, 29.2782f));
                        Endings.Add(new Vector3(1.070474f, -1403.703f, 29.27443f));
                        Endings.Add(new Vector3(2.682583f, -1404.013f, 29.26933f));
                    }
                }       //abush player at end point.MissionData.iMissionVar_01 = 3
                else if (Ending == 4)//sell the car
                {
                    Endings.Add(new Vector3(1175.856f, -3103.262f, 5.028f));
                    Endings.Add(new Vector3(1204.6427f, -3105.188f, 4.3991f));
                }       //have player steal and deliver a vehcle. find delivery point for each zone.MissionData.iMissionVar_01 = 4
                else if (Ending == 5)// car goes to heli safe zone thing.
                {
                    Endings.Add(new Vector3(-507.5099f, -1805.486f, 22.12456f)); //park
                    Endings.Add(new Vector3(-488.9879f, -1822.73f, 22.68803f));   //Heli spot	
                }       //have player protect two in car against two attacking cars--Find diffren safe zone for each zone.MissionData.iMissionVar_01 = 5
            }
            else if (zone == 2)
            {
                if (Ending == 1)
                {
                    Endings.Add(new Vector3(399.3774f, -986.9354f, 29.44869f));
                    Endings.Add(new Vector3(437.1844f, -979.4984f, 30.68965f));
                }       //npc travel to althoraties--fib/etc
                else if (Ending == 2)
                {
                    int iRanEnd = RandomX.FindRandom("Follow06", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(-334.265f, 281.4496f, 85.88953f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(-1638.555f, -940.7467f, 8.241022f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(-1006.756f, -1447.235f, 5.060962f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(-1397.114f, -454.8477f, 34.4823f));
                    else
                        Endings.Add(new Vector3(-742.7625f, -417.0015f, 35.6169f));
                }       //npc travel to blow up spot
                else if (Ending == 3)
                {
                    int iRanEnd = RandomX.FindRandom("Follow07", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(-1095.166f, -1048.611f, 2.097954f));
                        Endings.Add(new Vector3(-1088.248f, -1051.938f, 2.150358f));
                        Endings.Add(new Vector3(-1105.37f, -1049.744f, 2.150359f));
                        Endings.Add(new Vector3(-1104.333f, -1049.026f, 5.044804f));
                        Endings.Add(new Vector3(-1097.88f, -1055.868f, 5.906272f));
                        Endings.Add(new Vector3(-1088.965f, -1039.217f, 6.064651f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(-546.322f, -912.1973f, 23.8616f));
                        Endings.Add(new Vector3(-562.0908f, -921.0626f, 23.88543f));
                        Endings.Add(new Vector3(-538.3651f, -917.299f, 23.89709f));
                        Endings.Add(new Vector3(-547.5863f, -892.2472f, 24.84605f));
                        Endings.Add(new Vector3(-542.9849f, -884.8491f, 31.73257f));
                        Endings.Add(new Vector3(-538.382f, -889.9354f, 24.89949f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(127.1478f, -417.8031f, 41.06045f));
                        Endings.Add(new Vector3(109.1673f, -423.071f, 41.239f));
                        Endings.Add(new Vector3(108.3138f, -407.2803f, 41.25582f));
                        Endings.Add(new Vector3(108.0605f, -378.3236f, 41.97163f));
                        Endings.Add(new Vector3(126.8437f, -377.7885f, 43.27381f));
                        Endings.Add(new Vector3(130.3139f, -383.3231f, 43.26054f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(147.377f, 166.0188f, 104.7779f));
                        Endings.Add(new Vector3(154.9706f, 154.0587f, 104.9061f));
                        Endings.Add(new Vector3(162.1019f, 176.9631f, 105.243f));
                        Endings.Add(new Vector3(141.708f, 182.2189f, 105.8098f));
                        Endings.Add(new Vector3(131.0512f, 167.7933f, 116.3581f));
                        Endings.Add(new Vector3(141.4742f, 145.2975f, 111.9212f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(-940.6849f, 170.739f, 65.96121f));
                        Endings.Add(new Vector3(-938.7119f, 162.0593f, 66.01954f));
                        Endings.Add(new Vector3(-912.5547f, 147.9795f, 65.97608f));
                        Endings.Add(new Vector3(-910.8264f, 154.2417f, 66.22157f));
                        Endings.Add(new Vector3(-924.3877f, 159.7605f, 66.10933f));
                        Endings.Add(new Vector3(-921.3107f, 158.472f, 68.99623f));
                    }
                }       //ambush player
                else if (Ending == 4)
                {
                    Endings.Add(new Vector3(-28.76398f, -1085.738f, 26.56468f));
                    Endings.Add(new Vector3(-13.47234f, -1082.492f, 25.67207f));
                }       //sell the car
                else if (Ending == 5)
                {
                    Endings.Add(new Vector3(-152.6864f, -404.7901f, 33.60013f));
                    Endings.Add(new Vector3(-119.3288f, -420.7425f, 35.39782f));
                }       // car goes to heli safe zone thing.
            }
            else if (zone == 3)
            {
                if (Ending == 1)//npc travel to althoraties--fib/etc
                {
                    Endings.Add(new Vector3(-1109.039f, -794.2333f, 18.33924f));
                    Endings.Add(new Vector3(-1093.32f, -809.6802f, 19.28031f));
                }
                else if (Ending == 2)//npc travel to blow up spot
                {
                    int iRanEnd = RandomX.FindRandom("Follow09", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(-2448.326f, 1036.779f, 193.808f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(-2180.827f, -384.4297f, 13.29917f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(-1565.196f, 2133.469f, 58.82378f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(-3143.656f, 1088.802f, 20.6891f));
                    else
                        Endings.Add(new Vector3(-2540.062f, 2326.436f, 33.0599f));
                }
                else if (Ending == 3)//ambush player
                {
                    int iRanEnd = RandomX.FindRandom("Follow10", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(-1796.778f, 397.7882f, 112.7916f));
                        Endings.Add(new Vector3(-1782.929f, 410.398f, 113.6532f));
                        Endings.Add(new Vector3(-1791.528f, 409.8369f, 116.3199f));
                        Endings.Add(new Vector3(-1809.038f, 406.3819f, 116.6612f));
                        Endings.Add(new Vector3(-1799.797f, 407.9914f, 128.3046f));
                        Endings.Add(new Vector3(-1791.327f, 394.5776f, 112.7763f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(-2327.282f, 322.3922f, 169.4671f));
                        Endings.Add(new Vector3(-2312.927f, 321.4928f, 169.602f));
                        Endings.Add(new Vector3(-2313.265f, 298.0243f, 169.5464f));
                        Endings.Add(new Vector3(-2319.861f, 334.3047f, 170.5178f));
                        Endings.Add(new Vector3(-2312.086f, 305.1798f, 179.607f));
                        Endings.Add(new Vector3(-2340.359f, 296.6316f, 169.4595f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(-2982.051f, 76.00368f, 11.6085f));
                        Endings.Add(new Vector3(-2977.018f, 60.22567f, 11.6085f));
                        Endings.Add(new Vector3(-2954.509f, 52.38929f, 11.59945f));
                        Endings.Add(new Vector3(-2953.001f, 59.25411f, 11.60851f));
                        Endings.Add(new Vector3(-2962.1f, 73.566f, 11.39132f));
                        Endings.Add(new Vector3(-2963.097f, 68.94784f, 14.38126f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(-3229.874f, 968.2119f, 13.05142f));
                        Endings.Add(new Vector3(-3242.474f, 967.5328f, 12.73059f));
                        Endings.Add(new Vector3(-3259.683f, 964.0539f, 8.832897f));
                        Endings.Add(new Vector3(-3271.515f, 967.7222f, 8.347102f));
                        Endings.Add(new Vector3(-3258.459f, 984.5842f, 12.60574f));
                        Endings.Add(new Vector3(-3245.38f, 991.4319f, 12.48159f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(-1892.585f, 2010.624f, 141.5176f));
                        Endings.Add(new Vector3(-1897.584f, 1998.673f, 141.8182f));
                        Endings.Add(new Vector3(-1905.724f, 2001.19f, 141.9668f));
                        Endings.Add(new Vector3(-1927.914f, 2037.321f, 140.8323f));
                        Endings.Add(new Vector3(-1922.19f, 2060.148f, 140.8172f));
                        Endings.Add(new Vector3(-1898.592f, 2055.945f, 140.9048f));
                    }
                }
                else if (Ending == 4)//sell the car
                {
                    Endings.Add(new Vector3(-1121.609f, 2679.994f, 18.52382f));
                    Endings.Add(new Vector3(-1131.881f, 2697.187f, 17.80042f));
                }
                else if (Ending == 5)// car goes to heli safe zone thing.
                {
                    Endings.Add(new Vector3(-2968.396f, 2119.992f, 41.1056f));
                    Endings.Add(new Vector3(-2954.219f, 2167.244f, 40.16458f));
                }
            }
            else if (zone == 4)
            {
                if (Ending == 1)//npc travel to althoraties--fib/etc
                {
                    Endings.Add(new Vector3(806.112f, -1290.233f, 26.31686f));
                    Endings.Add(new Vector3(826.7388f, -1290.302f, 28.24066f));
                }
                else if (Ending == 2)//npc travel to blow up spot
                {
                    int iRanEnd = RandomX.FindRandom("Follow12", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(935.2122f, -83.58275f, 78.76408f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(1104.164f, 249.2428f, 80.85561f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(671.1092f, 648.402f, 128.9111f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(2309.403f, 2279.771f, 73.23333f));
                    else
                        Endings.Add(new Vector3(2727.764f, 2774.285f, 36.03881f));
                }
                else if (Ending == 3)//ambush player
                {
                    int iRanEnd = RandomX.FindRandom("Follow13", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(1132.976f, 56.15483f, 80.75537f));
                        Endings.Add(new Vector3(1120.14f, 61.66368f, 80.89004f));
                        Endings.Add(new Vector3(1125.868f, 70.92912f, 80.89034f));
                        Endings.Add(new Vector3(1151.357f, 92.24008f, 80.89155f));
                        Endings.Add(new Vector3(1101.867f, 54.02056f, 80.89005f));
                        Endings.Add(new Vector3(1113.616f, 72.5975f, 87.02773f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(970.7892f, -125.2417f, 74.34914f));
                        Endings.Add(new Vector3(974.8963f, -111.7808f, 74.35313f));
                        Endings.Add(new Vector3(988.2374f, -109.9435f, 74.12803f));
                        Endings.Add(new Vector3(991.446f, -100.4519f, 74.8488f));
                        Endings.Add(new Vector3(956.3654f, -123.6031f, 74.35312f));
                        Endings.Add(new Vector3(974.5671f, -107.188f, 81.76088f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(721.8716f, -296.8841f, 57.69057f));
                        Endings.Add(new Vector3(711.4915f, -300.5362f, 59.24805f));
                        Endings.Add(new Vector3(700.7048f, -301.98f, 59.23987f));
                        Endings.Add(new Vector3(703.8536f, -281.6f, 59.26522f));
                        Endings.Add(new Vector3(727.7678f, -292.3137f, 58.00923f));
                        Endings.Add(new Vector3(713.2146f, -312.7502f, 59.24846f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(1372.32f, -734.7248f, 67.23288f));
                        Endings.Add(new Vector3(1361.71f, -709.7031f, 67.23582f));
                        Endings.Add(new Vector3(1399.561f, -724.4568f, 66.77952f));
                        Endings.Add(new Vector3(1413.052f, -731.3032f, 70.1745f));
                        Endings.Add(new Vector3(1397.187f, -768.004f, 66.38944f));
                        Endings.Add(new Vector3(1387.56f, -784.6812f, 67.45612f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(1110.336f, -993.0563f, 44.89901f));
                        Endings.Add(new Vector3(1119.854f, -993.5611f, 45.96796f));
                        Endings.Add(new Vector3(1117.989f, -986.8531f, 46.28912f));
                        Endings.Add(new Vector3(1134.686f, -998.8827f, 45.2311f));
                        Endings.Add(new Vector3(1122.096f, -1004.225f, 44.9124f));
                        Endings.Add(new Vector3(1121.665f, -982.1707f, 50.16116f));
                    }
                }
                else if (Ending == 4)//sell the car
                {
                    Endings.Add(new Vector3(1130.572f, -775.5194f, 57.60971f));
                    Endings.Add(new Vector3(1120.84f, -785.0795f, 56.72751f));
                }
                else if (Ending == 5)// car goes to heli safe zone thing.
                {
                    Endings.Add(new Vector3(1113.32f, -857.6119f, 52.59922f));
                    Endings.Add(new Vector3(1100.2f, -883.7745f, 48.78764f));
                }
            }
            else if (zone == 5)
            {
                if (Ending == 1)//npc travel to althoraties--fib/etc
                {
                    Endings.Add(new Vector3(1865.972f, 3673.243f, 33.81769f));
                    Endings.Add(new Vector3(1856.081f, 3682.657f, 34.26738f));
                }
                else if (Ending == 2)//npc travel to blow up spot
                {
                    int iRanEnd = RandomX.FindRandom("Follow15", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(993.9924f, 4459.065f, 50.84431f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(507.2259f, 2928.93f, 41.11082f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(2059.712f, 3441.879f, 43.93653f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(3316.489f, 5145.824f, 18.27135f));
                    else
                        Endings.Add(new Vector3(2206.677f, 5613.411f, 53.99067f));
                }
                else if (Ending == 3)//ambush player
                {
                    int iRanEnd = RandomX.FindRandom("Follow16", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(1162.55f, 2118.602f, 55.50236f));
                        Endings.Add(new Vector3(1145.781f, 2138.901f, 55.31335f));
                        Endings.Add(new Vector3(1132.276f, 2115.311f, 55.64929f));
                        Endings.Add(new Vector3(1138.825f, 2110.769f, 55.79499f));
                        Endings.Add(new Vector3(1132.42f, 2086.453f, 55.66651f));
                        Endings.Add(new Vector3(1140.626f, 2092.484f, 55.79499f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(746.8138f, 2566.769f, 75.7371f));
                        Endings.Add(new Vector3(751.4865f, 2576.349f, 75.06314f));
                        Endings.Add(new Vector3(740.7289f, 2578.318f, 75.37512f));
                        Endings.Add(new Vector3(734.9993f, 2573.219f, 75.23927f));
                        Endings.Add(new Vector3(731.895f, 2556.755f, 76.59199f));
                        Endings.Add(new Vector3(747.9869f, 2555.193f, 77.09096f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(872.0957f, 2851.215f, 56.98059f));
                        Endings.Add(new Vector3(889.0432f, 2855.271f, 56.99014f));
                        Endings.Add(new Vector3(885.4002f, 2868.84f, 60.93551f));
                        Endings.Add(new Vector3(858.9968f, 2875.684f, 57.97002f));
                        Endings.Add(new Vector3(855.4788f, 2858.9f, 61.54012f));
                        Endings.Add(new Vector3(927.4607f, 2862.66f, 60.27645f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(1336.888f, 4333.842f, 37.7962f));
                        Endings.Add(new Vector3(1340.808f, 4320.314f, 37.92033f));
                        Endings.Add(new Vector3(1330.844f, 4350.892f, 42.74566f));
                        Endings.Add(new Vector3(1304.364f, 4340.681f, 41.30951f));
                        Endings.Add(new Vector3(1316.906f, 4317.886f, 38.12531f));
                        Endings.Add(new Vector3(1371.585f, 4307.547f, 38.05542f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(1907.447f, 4930.734f, 48.96051f));
                        Endings.Add(new Vector3(1902.961f, 4923.515f, 54.81795f));
                        Endings.Add(new Vector3(1901.497f, 4923.965f, 48.81419f));
                        Endings.Add(new Vector3(1904.64f, 4909.392f, 48.67026f));
                        Endings.Add(new Vector3(1904.704f, 4895.77f, 47.85513f));
                        Endings.Add(new Vector3(1890.28f, 4910.186f, 47.69906f));
                    }
                }
                else if (Ending == 4)//sell the car
                {
                    Endings.Add(new Vector3(266.1903f, 2599.558f, 44.74001f));
                    Endings.Add(new Vector3(258.5934f, 2577.703f, 43.62426f));
                }
                else if (Ending == 5)// car goes to heli safe zone thing.
                {
                    Endings.Add(new Vector3(1018.097f, 3621.509f, 32.06242f));
                    Endings.Add(new Vector3(1029.049f, 3584.657f, 31.52591f));
                }
            }
            else
            {
                if (Ending == 1)//npc travel to althoraties--fib/etc
                {
                    Endings.Add(new Vector3(-438.5785f, 6038.645f, 31.34055f));
                    Endings.Add(new Vector3(-441.4881f, 6017.921f, 31.60883f));
                }
                else if (Ending == 2)//npc travel to blow up spot
                {
                    int iRanEnd = RandomX.FindRandom("Follow18", 1, 5);
                    if (iRanEnd == 1)
                        Endings.Add(new Vector3(-1574.518f, 5148.307f, 20.0155f));
                    else if (iRanEnd == 2)
                        Endings.Add(new Vector3(-1521.731f, 4695.483f, 40.41826f));
                    else if (iRanEnd == 3)
                        Endings.Add(new Vector3(-564.2634f, 5442.018f, 61.33559f));
                    else if (iRanEnd == 4)
                        Endings.Add(new Vector3(-771.8398f, 5578.952f, 33.4857f));
                    else
                        Endings.Add(new Vector3(284.3079f, 6491.744f, 30.03781f));
                }
                else if (Ending == 3)//ambush player
                {
                    int iRanEnd = RandomX.FindRandom("Follow19", 1, 5);
                    if (iRanEnd == 1)
                    {
                        Endings.Add(new Vector3(1608.19f, 6456.522f, 25.15147f));
                        Endings.Add(new Vector3(1595.558f, 6452.34f, 25.31714f));
                        Endings.Add(new Vector3(1596.255f, 6461.465f, 25.31714f));
                        Endings.Add(new Vector3(1593.232f, 6455.085f, 29.23091f));
                        Endings.Add(new Vector3(1611.12f, 6439.375f, 25.82788f));
                        Endings.Add(new Vector3(1589.352f, 6449.095f, 25.31188f));
                    }
                    else if (iRanEnd == 2)
                    {
                        Endings.Add(new Vector3(131.7365f, 6611.09f, 31.84107f));
                        Endings.Add(new Vector3(122.2695f, 6626.602f, 31.93658f));
                        Endings.Add(new Vector3(128.7741f, 6633.726f, 31.84549f));
                        Endings.Add(new Vector3(140.2328f, 6648.245f, 31.52373f));
                        Endings.Add(new Vector3(154.7405f, 6642.103f, 31.62709f));
                        Endings.Add(new Vector3(112.6884f, 6622.044f, 37.5347f));
                    }
                    else if (iRanEnd == 3)
                    {
                        Endings.Add(new Vector3(259.4006f, 6776.433f, 15.60203f));
                        Endings.Add(new Vector3(279.5892f, 6783.483f, 15.69628f));
                        Endings.Add(new Vector3(285.2438f, 6779.965f, 15.69704f));
                        Endings.Add(new Vector3(285.3155f, 6792.567f, 15.69563f));
                        Endings.Add(new Vector3(280.7389f, 6800.118f, 15.69504f));
                        Endings.Add(new Vector3(279.0629f, 6788.62f, 19.68348f));
                    }
                    else if (iRanEnd == 4)
                    {
                        Endings.Add(new Vector3(136.1396f, 6365.358f, 31.36571f));
                        Endings.Add(new Vector3(138.2013f, 6378.191f, 31.38666f));
                        Endings.Add(new Vector3(144.5252f, 6364.814f, 31.51988f));
                        Endings.Add(new Vector3(127.3478f, 6354.405f, 31.35966f));
                        Endings.Add(new Vector3(114.0336f, 6373.326f, 31.36982f));
                        Endings.Add(new Vector3(150.7847f, 6374.298f, 44.07656f));
                    }
                    else
                    {
                        Endings.Add(new Vector3(-464.5281f, 6016.288f, 31.34054f));
                        Endings.Add(new Vector3(-453.9404f, 6007.555f, 31.48982f));
                        Endings.Add(new Vector3(-446.3437f, 5985.445f, 31.48335f));
                        Endings.Add(new Vector3(-443.8065f, 5993.523f, 31.34058f));
                        Endings.Add(new Vector3(-450.636f, 6011.614f, 40.28408f));
                        Endings.Add(new Vector3(-458.8586f, 6035.223f, 31.32827f));
                    }
                }
                else if (Ending == 4)//sell the car
                {
                    Endings.Add(new Vector3(122.8424f, 6628.6421f, 30.92f));
                    Endings.Add(new Vector3(101.88f, 6634.28f, 30.43f));
                }
                else if (Ending == 5)// car goes to heli safe zone thing.
                {
                    Endings.Add(new Vector3(-546.8909f, 6179.143f, 6.584301f));
                    Endings.Add(new Vector3(-563.5784f, 6176.025f, 6.705557f));
                }
            }

            ShopsNTings = MissionData.AppartmentBlocks(zone, 3, -1, -1, false);
            Starting = ShopsNTings.ParkHere.V3;
            ShopFits = ReturnStuff.IndoorPed(ShopsNTings.PedNum);
        }
    }
    public class FireStarter
    {
        public int FireArea { get; set; }
        public int FireType { get; set; }
        public int FireTime { get; set; }
        public int RepMish { get; set; }
        public int TotalPay { get; set; }
        public int BurninMoney { get; set; }
        public int FireFailed { get; set; }
        public bool InFort { get; set; }
        public bool CatHat { get; set; }
        public bool UniformOn { get; set; }
        public string FDname { get; set; }
        public Vector3 FuStops { get; set; }
        public Vector4 TruckPark { get; set; }
        public List<Vector4> Firery { get; set; }
        public Vector4 FireLocal { get; set; }
        public Ped FirePed { get; set; }
        public Ped FirePed2 { get; set; }
        public Vehicle FireTruck { get; set; }
        public Vehicle TestVehk { get; set; }
        public BlipForm TkBlip = new BlipForm(5, DataStore.MyLang.Maptext[8]); 
        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; set; }

        private readonly List<ClothBank> FreeFOut = new List<ClothBank>
        {
            new ClothBank("Fire", false, true, false, new ClothX("FFFire", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 136 }, new List<int> { 0 })),
            new ClothBank("Fire", false, true, false, new ClothX("FFFire", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 137 }, new List<int> { 0 })),
            new ClothBank("Fire", false, true, false, new ClothX("FFFire", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 137 }, new List<int> { 0 })),
            new ClothBank("Fire", false, true, false, new ClothX("FFFire", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 136 }, new List<int> { 0 }))

        };
        private readonly List<ClothBank> FreeMOut = new List<ClothBank>
        {
          new ClothBank("Fire", false, true, true, new ClothX("FMFire", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 137 }, new List<int> { 0 })),
          new ClothBank("Fire", false, true, true, new ClothX("FMFire", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 138 }, new List<int> { 0 })),
          new ClothBank("Fire", false, true, true, new ClothX("FMFire", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 138 }, new List<int> { 0 })),
          new ClothBank("Fire", false, true, true, new ClothX("FMFire", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 137 }, new List<int> { 0 })),
        };

        public FireStarter(int local, Vehicle fireTruck, int repmish, int currentPay, int fireFailed, bool uniformOn, ClothBank outfit)
        {
            FireArea = local;
            FireType = RandomX.FindRandom("FireDept01", 1, 5);
            FireTime = 0;
            RepMish = repmish;
            TotalPay += currentPay;
            BurninMoney = 0;
            FireFailed = fireFailed;
            if (local == 3)
                InFort = true;
            else
                InFort = false;
            CatHat = false;
            UniformOn = uniformOn;
            FDname = MyFDname(local);
            FuStops = Fusstops(local);
            TruckPark = Trucker(local);
            Firery = MissionData.FindingFires(local, FireType);
            FireLocal = Firery[0];
            TestVehk = null;
            FirePed = null;
            FirePed2 = null;
            FireTruck = fireTruck;
            Oufit = outfit;
            Uniform = UniformCheck(Oufit.Name);
        }
        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = new ClothBank("Fire", false, false, true, new ClothX("FrankFire", new List<int> { 0, 2, 4, 10, 10, 1, 5, 0, 8, -1, 0, -1 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 7 }, new List<int> { 0 }));
            else if (sName == "Michael")
                Uniform = new ClothBank("Fire", false, false, true, new ClothX("MickFire", new List<int> { 0, 0, 0, 1, 1, 1, 17, 0, 21, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0 }, new List<int> { 0 }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("Fire", false, false, true, new ClothX("TrevFire", new List<int> { 0, 0, 0, 1, 1, 1, 1, 0, 15, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0 }, new List<int> { 0 }));
            else if (sName == "FreeFemale")
                Uniform = FreeFOut[RandomX.FindRandom("FireUf", 0, FreeFOut.Count - 1)];
            else if (sName == "FreeMale")
                Uniform = FreeMOut[RandomX.FindRandom("FireUm", 0, FreeMOut.Count - 1)];
            else
                Uniform = null;

            return Uniform;
        }
        private string MyFDname(int local)
        {
            string sName = "";

            if (local == 1)
                sName = "Davis Fire Station ";
            else if (local == 2)
                sName = "Rockford Hills Fire Station";
            else if (local == 3)//fort access
                sName = "Fort Zancudo Fire Station";
            else if (local == 4)
                sName = "El Burro Heights Fire Station";
            else if (local == 5)
                sName = "Sandy Shores Fire Station";
            else
                sName = "Paleto Bay Fire Station";

            return sName;
        }
        private Vector3 Fusstops(int local)
        {
            Vector3 FuReturn;

            if (local == 1)
                FuReturn = new Vector3(212.9583f, -1625.14f, 28.66316f);
            else if (local == 2)
                FuReturn = new Vector3(-610.9536f, -61.93935f, 41.14728f);
            else if (local == 3)//fort access
                FuReturn = new Vector3(-2079.348f, 2842.614f, 32.30162f);
            else if (local == 4)
                FuReturn = new Vector3(1182.863f, -1446.108f, 34.32778f);
            else if (local == 5)
                FuReturn = new Vector3(1714.219f, 3587.345f, 34.92292f);
            else
                FuReturn = new Vector3(-397.2693f, 6133.777f, 31.00628f);

            return FuReturn;
        }
        private Vector4 Trucker(int local)
        {
            Vector4 Truckin;

            if (local == 1)
                Truckin = new Vector4(216.1825f, -1639.169f, 29.6262f, 320.04f);
            else if (local == 2)
                Truckin = new Vector4(-632.3837f, -71.35f, 40.5971f, 355.0277f);
            else if (local == 3)//fort access
                Truckin = new Vector4(-2107.329f, 2844.5947f, 32.8784f, 28.8017f);
            else if (local == 4)
                Truckin = new Vector4(1196.7448f, -1457.824f, 34.9314f, 357.4331f);
            else if (local == 5)
                Truckin = new Vector4(1698.2177f, 3585.0623f, 35.64f, -150.19f);
            else
                Truckin = new Vector4(-376.7517f, 6128.0347f, 31.4968f, 44.8131f);

            return Truckin;
        }
    }
    public class JohnDeer
    {
        public int Earnings { get; set; }
        public int EndTimes { get; set; }
        public int ReturnTime { get; set; }
        public bool WheelCheck { get; set; }
        public bool KeepTheCar { get; set; }
        public Ped YoPlayer { get; set; }
        public Vehicle PlayVeh { get; set; }
        public FubarVectors Start { get; set; }
        public FubarVectors End { get; set; }
        public List<Vector4> VehSpot { get; }

        public JohnDeer(int local)
        {
            Earnings = 100;
            EndTimes = 0;
            ReturnTime = 0;
            WheelCheck = true;
            KeepTheCar = false;
            YoPlayer = null;
            Start = MissionData.AppartmentBlocks(local, 9, -1, -1, true);
            bool Found = true;
            while (Found)
            {
                if (Start.PedNum == 52 || Start.PedNum == 53 || Start.PedNum == 54 || Start.PedNum == 97 || Start.PedNum == 98)
                    Found = false;
                else
                    Start = MissionData.AppartmentBlocks(local, 9, -1, -1, true);
                Script.Wait(1);
            }
            End = MissionData.AppartmentBlocks(local, RandomX.RandInt(1, 8), -1, -1, true);
            PlayVeh = null;
            VehSpot = ReturnStuff.IndoorPed(Start.PedNum);
        }
    }
    public class DaBomb
    {
        public int BlowTime { get; set; }
        public int Payment { get; set; }
        public Prop MyBomb { get; set; }
        public Vector3 FubStop { get; }
        public Vector3 BlipCenter { get; }
        public Vector4 BombThis { get; }
        public List<Vector3> PoilceDrop { get; }
        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; set; }

        private readonly List<Vector3> PigPark = new List<Vector3>
        {
            new Vector3(432.0016f, -982.2522f, 29.71071f),
            new Vector3(826.6686f, -1290.105f, 27.24086f),
            new Vector3(360.6976f, -1583.997f, 28.29205f),
            new Vector3(639.3252f, 1.446257f, 81.78688f),
            new Vector3(-560.6122f, -133.5047f, 37.08427f),
            new Vector3(-1631.851f, -1014.673f, 12.11931f),
            new Vector3(-1093.045f, -809.5769f, 18.27813f),
            new Vector3(-1313.826f, -1527.571f, 3.41676f),
            new Vector3(1855.559f, 3682.646f, 33.26752f),
            new Vector3(-442.1248f, 6017.591f, 30.67277f),
            new Vector3(4972.874f, -5598.701f, 22.69814f)
        };
        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = new ClothBank("Heavy", false, false, true, new ClothX("FrankHeavy", new List<int> { 0, 1, 0, 18, 6, 0, 6, 0, 0, 0, 0, 3 }, new List<int> { 0, 0, 0, 10, 7, 0, 2, 0, 0, 0, 0, 15 }, new List<int> { }, new List<int> { }));
            else if (sName == "Michael")
                Uniform = new ClothBank("Heavy", false, false, true, new ClothX("MickHeavy", new List<int> { 0, 1, 0, 23, 0, 0, 0, 0, 0, 0, 0, 5 }, new List<int> { 0, 0, 0, 7, 3, 0, 2, 0, 0, 0, 0, 8 }, new List<int> { }, new List<int> { }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("Heavy", false, false, true, new ClothX("TrevHeavy", new List<int> { 0, 1, 0, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeFemale")
                Uniform = new ClothBank("Heavy", false, true, false, new ClothX("FFHeavy", new List<int> { 0, 104, 0, 36, 86, 0, 34, 0, 105, 0, 0, 188 }, new List<int> { 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 38 }, new List<int> { 0 }));
            else if (sName == "FreeMale")
                Uniform = new ClothBank("Heavy", false, true, true, new ClothX("FMHeavy", new List<int> { 0, 104, 0, 42, 84, 0, 33, 0, 97, 0, 0, 186 }, new List<int> { 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 39 }, new List<int> { 0 }));
            else
                Uniform = null;

            return Uniform;
        }

        public DaBomb(int local)
        {
            BlowTime = 0;
            Payment = 0;
            MyBomb = null;
            BombSquad Bomber = MissionData.SortOutBs(local);

            FubStop = Bomber.FuPark;
            BombThis = Bomber.BombLoc[RandomX.FindRandom("DaBomb01", 0, Bomber.BombLoc.Count - 1)];
            BombThis = BombThis.DropZ(-0.25f);
            Vector3 Voff = new Vector3(BombThis.X, BombThis.Y, BombThis.Z);
            BlipCenter = Voff.Around(35f);
            PoilceDrop = FindCopShop(BlipCenter);
            Oufit = new ClothBank(Game.Player.Character);
            Uniform = UniformCheck(Oufit.Name);
        }
        private List<Vector3> FindCopShop(Vector3 Bomb)
        {
            List<Vector3> PigStation = new List<Vector3>();
            int iStation = 0;
            float fAr = 9999f;
            for (int i = 0; i < PigPark.Count; i++)
            {
                if (PigPark[i].DistanceTo(Bomb) < fAr)
                {
                    iStation = i;
                    fAr = PigPark[i].DistanceTo(Bomb);
                }
            }

            if (iStation == 0)
            {
                //MissioRow
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(422.6159f, -958.9047f, 28.73893f));
                PigStation.Add(new Vector3(424.9822f, -975.7164f, 30.70994f));
                PigStation.Add(new Vector3(430.0728f, -975.2698f, 30.71041f));
                PigStation.Add(new Vector3(431.8297f, -976.2233f, 30.7107f));
            }
            else if (iStation == 1)
            {
                //La Mesa
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(808.1988f, -1292.15f, 25.71989f));
                PigStation.Add(new Vector3(818.5182f, -1286.459f, 26.29823f));
                PigStation.Add(new Vector3(817.4276f, -1291.899f, 26.28673f));
                PigStation.Add(new Vector3(818.553f, -1294.349f, 26.28424f));
            }
            else if (iStation == 2)
            {
                //Davis
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(369.5829f, -1569.948f, 28.73894f));
                PigStation.Add(new Vector3(361.3124f, -1577.367f, 29.29205f));
                PigStation.Add(new Vector3(357.6923f, -1583.221f, 29.29205f));
                PigStation.Add(new Vector3(356.771f, -1584.818f, 29.29205f));
            }
            else if (iStation == 3)
            {
                //Vinewood
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(666.3584f, -13.99784f, 83.09074f));
                PigStation.Add(new Vector3(644.7836f, 5.072305f, 82.78687f));
                PigStation.Add(new Vector3(639.6327f, -5.474602f, 82.78826f));
                PigStation.Add(new Vector3(640.5361f, -4.35584f, 82.7886f));
            }
            else if (iStation == 4)
            {
                //Rockford
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(-547.814f, -144.8625f, 37.73637f));
                PigStation.Add(new Vector3(-564.3727f, -136.9801f, 38.13983f));
                PigStation.Add(new Vector3(-555.5646f, -134.1428f, 38.21357f));
                PigStation.Add(new Vector3(-555.6986f, -132.275f, 38.13365f));
            }
            else if (iStation == 5)
            {
                //DelPerro
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(-1628.884f, -1000.764f, 12.5358f));
                PigStation.Add(new Vector3(-1633.709f, -1009.621f, 13.07926f));
                PigStation.Add(new Vector3(-1626.259f, -1014.065f, 13.14364f));
                PigStation.Add(new Vector3(-1627.825f, -1015.812f, 13.14277f));
            }
            else if (iStation == 6)
            {
                //Vespucci
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(-1103.157f, -796.7576f, 17.90961f));
                PigStation.Add(new Vector3(-1086.839f, -803.2225f, 19.25974f));
                PigStation.Add(new Vector3(-1099.912f, -812.1174f, 19.31997f));
                PigStation.Add(new Vector3(-1101.959f, -811.5011f, 19.31709f));
            }
            else if (iStation == 7)
            {
                //Vespucci Beach
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(-1206.207f, -1442.319f, 3.878422f));
                PigStation.Add(new Vector3(-1310.293f, -1536.93f, 4.313596f));
                PigStation.Add(new Vector3(-1306.709f, -1526.721f, 4.358545f));
                PigStation.Add(new Vector3(-1308.001f, -1524.764f, 4.389328f));
            }
            else if (iStation == 8)
            {
                //Sandy
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(1860.758f, 3673.69f, 33.27175f));
                PigStation.Add(new Vector3(1855.079f, 3678.924f, 33.80996f));
                PigStation.Add(new Vector3(1860.517f, 3681.536f, 33.76942f));
                PigStation.Add(new Vector3(1859.754f, 3679.984f, 33.7042f));
            }
            else if (iStation == 9)
            {
                //paleto
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(-440.5876f, 6037.623f, 30.83302f));
                PigStation.Add(new Vector3(-442.0172f, 6022.679f, 31.49011f));
                PigStation.Add(new Vector3(-435.961f, 6021.011f, 31.49011f));
                PigStation.Add(new Vector3(-437.0332f, 6019.181f, 31.49011f));
            }
            else
            {
                //Cayo
                PigStation.Add(PigPark[iStation]);
                PigStation.Add(new Vector3(4972.874f, -5598.701f, 22.69814f));
                PigStation.Add(new Vector3(4971.818f, -5602.536f, 22.72403f));
                PigStation.Add(new Vector3(4974.157f, -5601.767f, 22.75018f));
                PigStation.Add(new Vector3(4965.757f, -5605.453f, 22.63304f));
            }

            return PigStation;
        }
    }
    public class SmashHits
    {
        public int MyZone { get; }
        public int EndTimes { get; set; }
        public int GuardDuty { get; set; }
        public int MurderRate { get; set; }
        public int TimeTaken { get; set; }
        public int Payment { get; set; }
        public bool CayoDoors { get; set; }
        public Ped Boss { get; set; }
        public GreatestHits MyHits { get; }

        public SmashHits(int local)
        {
            MyZone = local;
            EndTimes = 0;
            GuardDuty = 0;
            MurderRate = 0;
            TimeTaken = 0;
            Payment = RandomX.RandInt(30000, 45000);
            CayoDoors = false;
            Boss = null;

            if (local == 1)
            {
                if (DataStore.MyDatSet.DAssZone01 < 5)
                    MyHits = MissionData.HitList01[DataStore.MyDatSet.DAssZone01 - 1];
                else
                    MyHits = MissionData.HitList01[RandomX.RandInt(0, MissionData.HitList01.Count - 1)];
            }
            else if (local == 2)
            {
                if (DataStore.MyDatSet.DAssZone02 < 5)
                    MyHits = MissionData.HitList02[DataStore.MyDatSet.DAssZone02 - 1];
                else
                    MyHits = MissionData.HitList02[RandomX.RandInt(0, MissionData.HitList02.Count - 1)];
            }
            else if (local == 3)
            {
                if (DataStore.MyDatSet.DAssZone03 < 5)
                    MyHits = MissionData.HitList03[DataStore.MyDatSet.DAssZone03 - 1];
                else
                    MyHits = MissionData.HitList03[RandomX.RandInt(0, MissionData.HitList03.Count - 1)];
            }
            else if (local == 4)
            {
                if (DataStore.MyDatSet.DAssZone04 < 5)
                    MyHits = MissionData.HitList04[DataStore.MyDatSet.DAssZone04 - 1];
                else
                    MyHits = MissionData.HitList04[RandomX.RandInt(0, MissionData.HitList04.Count - 1)];
            }
            else if (local == 5)
            {
                if (DataStore.MyDatSet.DAssZone05 < 5)
                    MyHits = MissionData.HitList05[DataStore.MyDatSet.DAssZone05 - 1];
                else
                    MyHits = MissionData.HitList05[RandomX.RandInt(0, MissionData.HitList05.Count - 1)];
            }
            else if (local == 6)
            {
                if (DataStore.MyDatSet.DAssZone06 < 5)
                    MyHits = MissionData.HitList06[DataStore.MyDatSet.DAssZone06 - 1];
                else
                    MyHits = MissionData.HitList06[RandomX.RandInt(0, MissionData.HitList06.Count - 1)];
            }
            else if (local == 7)
            {
                if (DataStore.MyDatSet.DAssZone07 < 5)
                    MyHits = MissionData.HitList07[DataStore.MyDatSet.DAssZone07 - 1];
                else
                    MyHits = MissionData.HitList07[RandomX.RandInt(0, MissionData.HitList07.Count - 1)];

                CayoDoors = true;
            }
            else if (local == 8)
            {

            }
            else if (local == 9)
            {

            }
        }
    }
    public class TakinSnip
    {
        public int GoTo { get; set; }
        public int BossGoTo { get; set; }
        public int GetPaid { get; set; }
        public bool GoProne { get; set; }
        public bool HitSome { get; set; }
        public Ped Driver { get; set; }
        public Ped TargetPed { get; set; }
        public Ped Follow1 { get; set; }
        public Ped Follow2 { get; set; }
        public Vehicle ExitVic { get; set; }
        public Vehicle Vic { get; set; }
        public SnipSnip MySnips { get; set; }
        public Prop Ufo1 { get; set; }
        public Prop Ufo2 { get; set; }

        public TakinSnip(int iArea)
        {
            GoTo = 0;
            BossGoTo = 0;
            GoProne = false;
            HitSome = false;
            Driver = null;
            TargetPed = null;
            Follow1 = null;
            Follow2 = null;
            ExitVic = null;
            Vic = null;
            MySnips = MissionData.Snippy(iArea);
            Ufo1 = null;
            Ufo2 = null;
            GetPaid = RandomX.RandInt(30000, 45000);
        }
    }
    public class Securicore
    {
        public int YourFate { get; set; }
        public int iSuprise { get; set; }
        public int SpendMyMoney { get; set; }
        public int CashPay { get; set; }
        public bool MoneySpent { get; set; }
        public bool WheelCheck { get; set; }
        public bool AttackTrack { get; set; }
        public bool AttackAir { get; set; }
        public bool GotYourVan { get; set; }
        public bool LostYourVan { get; set; }
        public Vector3 FuStops { get; }
        public Vector4 TruckStart { get; }
        public Vector4 StandHere { get; }
        public Ped Buddy { get; set; }
        public Prop SuitCase { get; set; }
        public Vehicle Truck { get; set; }
        public FubarVectors Shops { get; }
        public List<Vector4> IntheShops { get; set; }
        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; set; }

        private readonly List<ClothBank> FreeFOut = new List<ClothBank>
        {
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 9, 6, 0, 52, 0, 189, 6, 85, 330 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { 143 }, new List<int> { 0 })),
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 9, 6, 0, 52, 0, 189, 6, 85, 329 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 125, 11 }, new List<int> { 0, 0 })),
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 3, 6, 0, 52, 0, 189, 6, 80, 327 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 143 }, new List<int> { 0 })),
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 3, 6, 0, 52, 0, 189, 6, 80, 328 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 125, 11 }, new List<int> { 0, 0 })),
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 3, 6, 0, 52, 0, 189, 6, 80, 327 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { 125 }, new List<int> { 0 })),
            new ClothBank("Securo", false, true, false, new ClothX("FFSecuro", new List<int> { 21, 0, 0, 9, 6, 0, 52, 0, 189, 6, 85, 330 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 141, 11 }, new List<int> { 0, 0 }))
        };
        private readonly List<ClothBank> FreeMOut = new List<ClothBank>
        {
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 11, 10, 0, 51, 0, 153, 7, 76, 319 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { 144 }, new List<int> { 0 })),
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 11, 10, 0, 51, 0, 153, 7, 76, 318 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 126, 5 }, new List<int> { 0, 0 })),
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 1, 10, 0, 51, 0, 153, 7, 71, 316 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 144 }, new List<int> { 0 })),
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 1, 10, 0, 51, 0, 153, 7, 71, 317 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 126, 5 }, new List<int> { 0, 0 })),
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 1, 10, 0, 51, 0, 153, 7, 71, 316 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2 }, new List<int> { 126 }, new List<int> { 0 })),
          new ClothBank("Securo", false, true, true, new ClothX("FMSecuro", new List<int> { 0, 0, 0, 11, 10, 0, 51, 0, 153, 7, 71, 316 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, new List<int> { 142, 8 }, new List<int> { 0, 0 }))
        };

        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("FrankValay", new List<int> { 0, -1, 4, 1, 1, 0, 1, 0, 14, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 19 }, new List<int> { 1 }));
            else if (sName == "Michael")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("MickValay", new List<int> { 0, 0, 0, 11, 10, 0, 17, 0, 8, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 5 }, new List<int> { 0 }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("TrevValay", new List<int> { 0, 0, 0, 8, 8, 0, 15, 0, 7, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 6 }, new List<int> { 0 }));
            else if (sName == "FreeFemale")
                Uniform = FreeFOut[RandomX.FindRandom("SecuoCoreUf", 0, FreeFOut.Count - 1)];
            else if (sName == "FreeMale")
                Uniform = FreeMOut[RandomX.FindRandom("SecuoCoreUm", 0, FreeMOut.Count - 1)];
            else
                Uniform = null;

            return Uniform;
        }

        public Securicore(int zone)
        {
            YourFate = 0;
            iSuprise = 0;
            CashPay = 100;
            SpendMyMoney = 0;
            MoneySpent = false;
            AttackTrack = false;
            AttackAir = false;
            WheelCheck = true;
            GotYourVan = false;
            LostYourVan = false;

            if (zone == 1)
            {
                FuStops = new Vector3(968.2625f, -1575.904f, 30.10956f);
                TruckStart = new Vector4(934.419f, -1578.40f, 29.94f, 88.32f);
                StandHere = new Vector4(961.1391f, -1586.041f, 30.38947f, 297.1811f);
            }
            else if (zone == 2)
            {
                FuStops = new Vector3(-405.35f, -63.32f, 44.1f);
                TruckStart = new Vector4(-360.54f, -78.33f, 45.27f, 160.8f);
                StandHere = new Vector4(-348.6f, -46.84f, 54.5f, -12.5f);
            }
            else if (zone == 3)
            {
                FuStops = new Vector3(-1357.154f, -686.0685f, 24.80783f);
                TruckStart = new Vector4(-1379.842f, -651.2659f, 28.15535f, 305.7188f);
                StandHere = new Vector4(-1399.386f, -657.6003f, 28.67339f, 307.8122f);
            }
            else if (zone == 4)
            {
                FuStops = new Vector3(1125.113f, -1261.781f, 20.09493f);
                TruckStart = new Vector4(1099.12f, -1270.16f, 19.795f, -51.03f);
                StandHere = new Vector4(1098.566f, -1274.972f, 20.74246f, 312.774f);
            }
            else if (zone == 5)
            {
                FuStops = new Vector3(2483.111f, 4082.512f, 37.41102f);
                TruckStart = new Vector4(2470.4231f, 4079.9763f, 37.00f, -112.445f);
                StandHere = new Vector4(2476.441f, 4087.215f, 38.11901f, 242.7f);
            }
            else
            {
                FuStops = new Vector3(-10.03841f, 6391.624f, 30.78662f);
                TruckStart = new Vector4(-32.27702f, 6420.57f, 30.94404f, 225.2031f);
                StandHere = new Vector4(-38.61729f, 6420.182f, 31.49045f, 231.998f);
            }
            SuitCase = null;
            Buddy = null;
            Truck = null;

            Shops = MissionData.AppartmentBlocks(zone, 3, -1, -1, true);
            IntheShops = ReturnStuff.IndoorPed(Shops.PedNum);
            Oufit = new ClothBank(Game.Player.Character);
            Uniform = UniformCheck(Oufit.Name);
        }
    }
    public class ArgyBargy
    {
        public Prop BargeMv { get; }
        public Prop Barge01 { get; }
        public Prop Barge02 { get; }

        public Prop Mark01 { get; set; }
        public Prop Mark02 { get; set; }

        public int KillCount { get; set; }
        public float EndDir { get; }
        public Vector3 FlyMeTo { get; }
        public Vector3 EndPos { get; }
        public Vector3 PortExit { get; }
        public Vector4 EndTug { get; }
        public Vector4 BobStart { get; }

        public Vehicle Tuger { get; }
        public Vehicle Car01 { get; }
        public Vehicle Car02 { get; }
        public Vehicle Car03 { get; }
        public Vehicle FloatBoat { get; }

        public Ped Pilot { get; set; }
        public Vehicle CargoB { get; set; }

        public List<Vector3> Friends { get; }
        public List<Vector3> Foes { get; }

        public ArgyBargy()
        {
            KillCount = -8;
            Tuger = EntityBuild.VehicleSpawn(new VehMods("TUG", 0, 5, true, DataStore.MyLang.Maptext[60]), new Vector4(-297.986f, -2508.42f, 0.28f, 51.99f));
            Function.Call(Hash.SET_BOAT_ANCHOR, Tuger.Handle, true);

            BargeMv = EntityBuild.BuildProp("prop_ind_barge_01_cr", new Vector4(-467.467f, -2421.15f, -0.86f, 140.04f), true, true);
            FloatBoat = EntityBuild.VehicleSpawn(new VehMods("SPEEDER", 0, -1, false, "", false), new Vector4(-467.467f, -2421.15f, -4.36f, 140.04f));
            FloatBoat.IsInvincible = true;
            FloatBoat.IsVisible = false;
            Function.Call(Hash.SET_BOAT_ANCHOR, FloatBoat.Handle, true);
            BargeMv.AttachTo(FloatBoat, FloatBoat.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 0.00f), new Vector3(0.00f, 0.00f, -180.00f));
            Function.Call(Hash.FREEZE_ENTITY_POSITION, BargeMv, false);
            Function.Call(Hash.FREEZE_ENTITY_POSITION, FloatBoat, false);

            Mark01 = EntityBuild.BuildProp("zprop_bin_01a_old", new Vector4(-467.467f, -2421.15f, -4.36f, 140.04f), false, true);
            Mark01.AttachTo(Tuger, 0, new Vector3(0.00f, -16.90f, 1.20f), new Vector3(0.00f, 0.00f, 90.00f));

            Mark02 = EntityBuild.BuildProp("prop_mp_base_marker", new Vector4(-467.467f, -2421.15f, -4.36f, 140.04f), false, true);
            Mark02.AttachTo(BargeMv, 0, new Vector3(0.07f, -16.80f, 0.95f), new Vector3(0.00f, 0.00f, 90.00f));

            //MissionData.vTarget_01 = new Vector3(-296.9974f, -2498.0f, 6.01f);
            PortExit = new Vector3(-532.22f, -3142.22f, 0.879541f);

            Car01 = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.AddRandomVeh(1), 0, true), new Vector4(-451.83f, -2427.72f, 5.32f, 48.22f));
            Car02 = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.AddRandomVeh(1), 0, true), new Vector4(-449.83f, -2425.72f, 5.32f, 48.22f));
            Car03 = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.AddRandomVeh(1), 0, true), new Vector4(-447.83f, -2423.72f, 5.32f, 48.22f));


            Vector4 vBargiePos01;
            Vector4 vBargiePos02;

            int iRandomDrops = RandomX.RandInt(1, 3);

            if (iRandomDrops == 1)
            {
                vBargiePos01 = new Vector4(3620.21f, 2629.51f, -1.525f, 72.51f);
                vBargiePos02 = new Vector4(3622.987f, 2586.88f, -1.525f, 147.35f);

                Friends = new List<Vector3>
                {
                    new Vector3(3649.372f, 2617.402f, 6.63372f),
                    new Vector3(3651.506f, 2614.691f, 6.633721f),
                    new Vector3(3627.223f, 2626.364f, 4.244568f),
                    new Vector3(3609.775f, 2630.035f, 4.244568f),
                    new Vector3(3628.146f, 2593.23f, 4.20523f),
                    new Vector3(3618.583f, 2578.76f, 4.20523f)
                };

                Foes = new List<Vector3>
                {
                    new Vector3(3420.099f, 2491.043f, 0.6345347f),
                    new Vector3(3405.634f, 2612.699f, 1.414109f),
                    new Vector3(3440.099f, 2712.043f, 1.188157f),
                    new Vector3(3549.929f, 2779.896f, 0.5909276f),
                    new Vector3(3675.02f, 2745.809f, -0.9453772f),
                    new Vector3(3710.018f, 2479.11f, -0.08554739f)
                };

                EndPos = new Vector3(3652.68f, 2617.99f, 1.53f);
                EndDir = -48.99f;

                BobStart = new Vector4(2391.884f, 2606.851f, 714.0196f, 0f);

                //MissionData.vTarget_05 = new Vector3(3461.911f, 2592.899f, 17.56484f);

                //MissionData.fMission_02 = 129.3113f;

                FlyMeTo = new Vector3(3638.695f, 2534.938f, 45.00f);
            }       //Area4
            else if (iRandomDrops == 2)
            {
                vBargiePos01 = new Vector4(-3488.987f, 2567.464f, -1.525f, 0.00f);
                vBargiePos02 = new Vector4(-3461.614f, 2537.045f, -1.525f, -90.782f);

                Friends = new List<Vector3>
                {
                    new Vector3(-3504.892f, 2538.714f, 6.43768f),
                    new Vector3(-3503.309f, 2542.615f, 6.43768f),
                    new Vector3(-3468.269f, 2540.936f, 4.196299f),
                    new Vector3(-3455.491f, 2536.626f, 4.196299f),
                    new Vector3(-3490.959f, 2562.74f, 4.259959f),
                    new Vector3(-3488.732f, 2575.614f, 4.259959f)
                };

                Foes = new List<Vector3>
                {
                    new Vector3(-3361.782f, 2576.428f, 1.018636f),
                    new Vector3(-3429.236f, 2465.523f, -1.819907f),
                    new Vector3(-3388.378f, 2353.15f, 1.727046f),
                    new Vector3(-3304.568f, 2320.081f, 1.053782f),
                    new Vector3(-3198.47f, 2395.765f, 1.087626f),
                    new Vector3(-3210.874f, 2537.606f, 1.138748f)
                };

                EndPos = new Vector3(-3506.61f, 2541.75f, 1.335f);
                EndDir = 59.99f;

                BobStart = new Vector4(-1986.925f, 2386.277f, 798.9652f, 0f);

                //MissionData.vTarget_05 = new Vector3(-2777.655f, 2702.865f, 2.265981f);

                //MissionData.fMission_02 = 151.1022f;

                FlyMeTo = new Vector3(-3296.078f, 2434.163f, 45.00f);
            }       //Area 3
            else
            {
                vBargiePos01 = new Vector4(-2294.5625f, 5076.313f, -1.525f, -114.632f);
                vBargiePos02 = new Vector4(-2291.265f, 5114.785f, -1.525f, -58.89f);

                Friends = new List<Vector3>
                {
                    new Vector3(-2325.56f, 5103.03f, 6.935183f),
                    new Vector3(-2329.237f, 5101.743f, 6.938537f),
                    new Vector3(-2300.375f, 5081.123f, 4.247458f),
                    new Vector3(-2287.496f, 5075.647f, 4.247458f),
                    new Vector3(-2285.91f, 5119.862f, 4.249745f),
                    new Vector3(-2296.667f, 5112.091f, 4.249745f)
                };

                Foes = new List<Vector3>
                {
                    new Vector3(-2366.315f, 5316.938f, 0.4459411f),
                    new Vector3(-2505.177f, 5118.204f, -1.392775f),
                    new Vector3(-2460.614f, 4977.973f, 2.337129f),
                    new Vector3(-2294.666f, 4919.8f, 2.374352f),
                    new Vector3(-2082.271f, 5040.844f, 0.138085f),
                    new Vector3(-1997.227f, 5188.623f, 1.223455f),
                    new Vector3(-1985.521f, 5297.569f, 1.387197f),
                    new Vector3(-2097.74f, 5386.565f, 0.2941358f)
                };


                EndPos = new Vector3(-2329.28882f, 5105.92432f, 1.836f);//tug space
                EndDir = 27.899807f;

                BobStart = new Vector4(-1021.073f, 4403.199f, 716.9043f, 0f);

                //MissionData.vTarget_05 = new Vector3(-2168.488f, 5191.466f, 45.00f);

                //MissionData.fMission_02 = 222.6737f;

                FlyMeTo = new Vector3(-2338.36f, 5068.45f, 15.797754f);
            }       //Area 6

            Barge01 = EntityBuild.BuildProp("prop_ind_barge_01_cr", vBargiePos01, true, true);
            Barge02 = EntityBuild.BuildProp("prop_ind_barge_01_cr", vBargiePos02, true, true);
        }
    }
    public class YachtParty
    {
        public int iThisVeh { get; set; }
        public int iThisVeh2 { get; set; }
        public Vehicle YtTrans { get; set; }
        public Vector3 YachtBlip { get; }
        public Vector4 VehLoc01 { get; }
        public Vector4 VehLoc02 { get; }
        public Vector4 VehLoc03 { get; }
        public List<Vector3> Fubs { get; }

        public YachtParty()
        {
            iThisVeh = 0;
            iThisVeh2 = 0;
            YtTrans = null;

            YachtBlip = new Vector3(-2062.635f, -1025.35f, 14.89584f); //yahht blip
            VehLoc01 = new Vector4(-792.833f, -1501.074f, 1.868256f, 124.9655f);    // Seasparrow
            VehLoc02 = new Vector4(-1003.107f, -1060.22f, -0.7159257f, 117.8598f);  // Speedboat
            VehLoc03 = new Vector4(-1125.589f, -1609.41f, 3.980671f, 308.9667f);    // technical

            Fubs = new List<Vector3>
            {
                new Vector3(-759.5714f, -1488.978f, 4.493412f),
                new Vector3(-1021.038f, -1087.49f, 1.444673f),
                new Vector3(-1132.264f, -1583.583f, 3.785678f)
            };
        }
    }
    public class PhishingTrip
    {
        public int OnPoint { get; set; }
        public int OnTime { get; set; }
        public int Watertime { get; set; }
        public bool OutofWater { get; set; }
        public bool OnTarget { get; set; }
        public Vector3 VEnd { get; }
        public Vehicle Boat { get; }
        public Ped BoatHand { get; }
        public List<PhishingSpot> Fishers { get; }

        public PhishingTrip()
        {
            OnPoint = 0;
            OnTime = 0;
            Watertime = 0;
            OutofWater = false;
            OnTarget = false;
            VEnd = new Vector3(-2078.157f, 2600.188f, -0.09435405f);
            Boat = EntityBuild.VehicleSpawn(new VehMods("Tropic", 15, 5, true, DataStore.MyLang.Maptext[17]), new Vector4(-1522.54f, 1504.275f, 109.20f, 347.7118f));
            BoatHand = EntityBuild.NPCSpawn(new PedFeat("s_m_m_scientist_01", false, 130, 8, 2, Boat, 0, false, 0, ""), Boat.Position, Boat.Heading);
            Fishers = MissionData.FindPhisherMen();
        }
    }
    public class ShipShape
    {
        public int iTimes { get; set; }
        public Vehicle YourBoat { get; set; }
        public Vector3 VStart { get; }
        public FubarVectors Dock { get; }

        public ShipShape()
        {
            iTimes = 0;
            VStart = new Vector3(1313.976f, 4318.277f, 38.14502f);
            Dock = MissionData.BoatDelivery[RandomX.FindRandom("ShipShapeDock", 0, MissionData.BoatDelivery.Count - 1)];
            Dock.ParkHere = new Vector4(Dock.ParkHere.X, Dock.ParkHere.Y, Dock.ParkHere.Z - 1f, Dock.ParkHere.R);
        }
    }
    public class SubWay
    {
        public bool AddCliff { get; set; }
        public int iTarget { get; set; }
        public int TimeTaken { get; set; }
        public Ped BogDan { get; set; }
        public Ped Target { get; set; }
        public Vehicle SubVeh { get; }
        public List<Vector3> SubPlace { get; }
        public List<Vector4> SubSection { get; }

        public SubWay()
        {
            AddCliff = false;
            iTarget = 0;
            TimeTaken = 0;
            BogDan = null;
            Target = null;
            SubVeh = EntityBuild.VehicleSpawn(new VehMods("STROMBERG", 0, 66, true, DataStore.MyLang.Maptext[19], false, true, "Sub"), new Vector3(-323.972f, 6093.478f, 30.71f), -134.72f);
            SubPlace = new List<Vector3>
            {
                new Vector3(-865.0032f, 5869.187f, -0.7135592f),
                new Vector3(512.4218f, 4836.779f, -63.58794f),
                new Vector3(514.3708f, 4844f, -63.58934f),
                new Vector3(-1415.453f, 6009.928f, -15.73509f),
                new Vector3(-1465.418f, 5970.25f, -8.544f)
            };
            SubSection = new List<Vector4>
            {
                new Vector4(-1485.873f, 5874.927f, -23.60273f,338.469f),
                new Vector4(-1452.883f, 5891.918f, -26.59448f,40.32843f),
                new Vector4(-1470.491f, 5931.848f, -34.98941f,351.9011f)
            };
        }
    }
    public class ImpExpMi
    {
        public int Zone { get; set; }
        public int NoCars { get; set; }
        public int VehCash { get; set; }
        public int GangDel { get; set; }
        public int Payments { get; set; }
        public float Distance { get; set; }
        public bool MoveSub { get; set; }
        public bool FadeIn { get; set; }
        public bool Murder { get; set; }
        public bool CleanRun { get; set; }
        public Vector3 FromHere { get; set; }
        public Vector3 Destination { get; set; }
        public Vehicle VehX { get; set; }
        public Ped Driver { get; set; }
        public Prop Bargie { get; }
        public List<Vector3> CarBarge01 { get; set; }
        public List<Vector4> CarBarge02 { get; set; }
        public List<ImportExVeh> VehList { get; set; }
        public List<int> PayOut { get; set; }

        public ImpExpMi(int zone)
        {
            Zone = 0;
            NoCars = 0;
            VehCash = 0;
            GangDel = 0;
            Payments = 0;
            Distance = 0.00f;
            MoveSub = true;
            FadeIn = false;
            Murder = false;
            CleanRun = false;
            FromHere = Vector3.Zero;
            VehX = null;
            Driver = null;
            CarBarge01 = new List<Vector3>();
            CarBarge02 = new List<Vector4>();
            VehList = new List<ImportExVeh>();
            PayOut = new List<int>();

            Vector3 PVec_01 = Vector3.Zero;
            Vector3 PRot_01 = Vector3.Zero;

            Vector3 PVec_02 = Vector3.Zero;
            Vector3 PRot_02 = Vector3.Zero;

            if (zone == 1)
            {
                Destination = new Vector3(-471.7313f, -2423.815f, 3.063863f);
                CarBarge01.Add(new Vector3(-440.5895f, -2451.739f, 5.476831f));
                CarBarge01.Add(new Vector3(-271.6974f, -2615.334f, 5.519654f));

                CarBarge02.Add(new Vector4(-448.7739f, -2418.878f, 6.00079f, 150.2767f));
                CarBarge02.Add(new Vector4(-449.0481f, -2428.503f, 6.261684f, 229.8575f));

                PVec_01 = new Vector3(-467.467f, -2421.15f, -0.86f);
                PRot_01 = new Vector3(0.00f, 0.00f, -40.04f);

                PVec_02 = new Vector3(-460.349274f, -2434.24951f, 4.00978384f);
                PRot_02 = new Vector3(6.59998989f, 0.00f, 49.2614975f);
            }
            else if (zone == 2)
            {
                Destination = new Vector3(-2155.33f, -528.2202f, 2.691958f);
                CarBarge01.Add(new Vector3(-2107.276f, -485.45f, 4.257054f));
                CarBarge01.Add(new Vector3(-2064.365f, -411.8389f, 10.8162f));

                CarBarge02.Add(new Vector4(-2137.034f, -487.0437f, 2.997781f, 248.9881f));
                CarBarge02.Add(new Vector4(-2130.624f, -489.7626f, 2.564268f, 329.4985f));

                PVec_01 = new Vector3(-2151.424f, -523.7899f, -2.06f);
                PRot_01 = new Vector3(0.00f, 0.00f, -46.224f);

                PVec_02 = new Vector3(-2139.552f, -508.325f, 1.06558251f);
                PRot_02 = new Vector3(15.3000126f, 0.00f, 137.25f);
            }
            else if (zone == 3)
            {
                Destination = new Vector3(-3298.518f, 1270.644f, 1.726939f);
                CarBarge01.Add(new Vector3(-3220.54f, 1255.031f, 2.906645f));
                CarBarge01.Add(new Vector3(-3013.054f, 1207.983f, 16.53849f));

                CarBarge02.Add(new Vector4(-3256.225f, 1260.652f, 2.412136f, 255.7132f));
                CarBarge02.Add(new Vector4(-3253.803f, 1253.441f, 2.655439f, 22.71264f));

                PVec_01 = new Vector3(-3290.715f, 1271.307f, -2.56f);
                PRot_01 = new Vector3(0.00f, 0.00f, -103.5014f);

                PVec_02 = new Vector3(-3271.32544f, 1268.72021f, 0.56715298f);
                PRot_02 = new Vector3(15.3000135f, 0.00f, 77.8570786f);
            }
            else if (zone == 4)
            {
                Destination = new Vector3(2872.187f, -625.9441f, 2.311935f);
                CarBarge01.Add(new Vector3(2807.857f, -655.1345f, 1.71902f));
                CarBarge01.Add(new Vector3(2738.233f, -688.6348f, 10.93631f));

                CarBarge02.Add(new Vector4(2835.066f, -633.0577f, 1.845662f, 135.2393f));
                CarBarge02.Add(new Vector4(2825.964f, -643.6343f, 1.232047f, 109.0696f));

                PVec_01 = new Vector3(2867.1411f, -629.7086f, -2.06f);
                PRot_01 = new Vector3(0.00f, 0.00f, 106.6414f);

                PVec_02 = new Vector3(2849.26367f, -637.624939f, 0.94101167f);
                PRot_02 = new Vector3(15.3000135f, 0.00f, -70.9093094f);
            }
            else if (zone == 5)
            {
                Destination = new Vector3(3895.991f, 4465.392f, 1.885381f);
                CarBarge01.Add(new Vector3(3827.638f, 4464.061f, 2.2999f));
                CarBarge01.Add(new Vector3(3771.6f, 4463.569f, 6.473855f));

                CarBarge02.Add(new Vector4(3817.498f, 4456.074f, 3.678974f, 56.81924f));
                CarBarge02.Add(new Vector4(3807.958f, 4466.089f, 3.956213f, 97.24484f));

                PVec_01 = new Vector3(3891.6228f, 4466.2192f, -2.86f);
                PRot_01 = new Vector3(0.00f, 0.00f, 90.0789f);

                PVec_02 = new Vector3(3871.53296f, 4463.60156f, 1.43711805f);
                PRot_02 = new Vector3(5.8000083f, 0.00f, -89.8046951f);
            }
            else
            {
                Destination = new Vector3(-1838.067f, 4866.93f, 2.02f);
                CarBarge01.Add(new Vector3(-1829.18787f, 4812.896f, 2.887918f));
                CarBarge01.Add(new Vector3(-1745.28223f, 4665.32227f, 18.1445694f));

                CarBarge02.Add(new Vector4(-1824.44f, 4818.69f, 2.8897f, 159.27f));//Ped
                CarBarge02.Add(new Vector4(-1829.18787f, 4812.896f, 2.887918f, 136.00f));//Vehicle

                PVec_01 = new Vector3(-1836.00244f, 4862.52637f, -1.411000878f);
                PRot_01 = new Vector3(0.00f, 0.00f, -156.65f);

                PVec_02 = new Vector3(-1826.45215f, 4845.18213f, 1.51857018f);
                PRot_02 = new Vector3(14.3000679f, 0.00f, 23.1414642f);
            }

            Bargie = EntityBuild.BuildProp("prop_ind_barge_01_cr", PVec_01, PRot_01, true, true);
            EntityBuild.BuildProp("imp_prop_impexp_bblock_lrg1", PVec_02, PRot_02, true, true);
        }
    }
    public class Wonga
    {
        public bool OpenDoors { get; set; }
        public int YourFee { get; set; }
        public Prop TheCase { get; set; }
        public FubarVectors MyFlat { get; }
        public FubarVectors MyBank { get; }
        public List<Vector4> Foes { get; }
        public List<Vector4> Banks { get; }

        public Wonga(int iArea)
        {
            OpenDoors = true;
            YourFee = 1000;
            TheCase = null;
            MyFlat = MissionData.AppartmentBlocks(iArea, RandomX.FindRandom("WongaApps", 7, 9), -1, -1, true);
            MyBank = MissionData.AppartmentBlocks(iArea, 3, 0, -1, true);
            Foes = ReturnStuff.IndoorPed(MyFlat.PedNum);
            Banks = ReturnStuff.IndoorPed(MyBank.PedNum);
        }
    }
    public class LostMc
    {
        public bool MoveVeh { get; set; }
        public int Task { get; }
        public int Seat { get; set; }
        public int Icon { get; set; }
        public int McAttacks { get; set; }
        public int McTimmer { get; set; }
        public int CashPay { get; set; }
        public FubarVectors Buissness { get; set; }
        public List<Vector4> InBis { get; set; }
        public List<Ped> Walkers { get; set; }
        public Prop MyKeys { get; set; }
        public Ped Guard { get; set; }
        public Vehicle ExVeh { get; set; }
        public FubarVectors ClubHouse { get; set; }

        public LostMc(int iArea)
        {
            MoveVeh = true;
            Task = RandomX.FindRandom("LostMc01", 1, 3);
            Seat = 4;
            McAttacks = 0;
            McTimmer = 0;
            Buissness = MissionData.AppartmentBlocks(iArea, 1, -1, -1, true);
            InBis = ReturnStuff.IndoorPed(Buissness.PedNum);

            if (Buissness.PedNum == 100)
                Icon = 498;//Forg
            else if (Buissness.PedNum == 101)
                Icon = 497;//Coke
            else if (Buissness.PedNum == 102)
                Icon = 496;//Weed
            else if (Buissness.PedNum == 103)
                Icon = 500;//Cash
            else if (Buissness.PedNum == 104)
                Icon = 499;//Meth

            Walkers = new List<Ped>();
            MyKeys = null;
            ExVeh = null;
            Guard = null;
            ClubHouse = MissionData.ClubHouses[RandomX.FindRandom("LostMc02", 0, MissionData.ClubHouses.Count - 1)];
            while (ClubHouse.Zone == iArea)
            {
                ClubHouse = MissionData.ClubHouses[RandomX.FindRandom("LostMc02", 0, MissionData.ClubHouses.Count - 1)];
                Script.Wait(1);
            }
        }
    }
    public class CargoLift
    {
        public int iSuprise { get; }
        public int iTem { get; }
        public int CashPay { get; set; }
        public int Instruct01 { get; set; }
        public int Instruct02 { get; set; }
        public int Instruct03 { get; set; }
        public bool MoveVeh { get; set; }
        public string sItem { get; set; }
        public string sItemName { get; set; }
        public Prop BluePallet { get; set; }
        public Vehicle Truck { get; set; }
        public Vehicle ForkLift { get; set; }

        public FubarVectors Buissness { get; }
        public FubarVectors DropOff { get; }
        public List<int> Pallets { get; }
        public List<Vector4> Enemys { get; }
        public Vector4 ForkIt { get; set; }

        private readonly List<string> Crates = new List<string>
        {
            "ex_prop_crate_freel",
            "ex_prop_crate_minig",
            "ex_prop_crate_oegg",
            "ex_prop_crate_shide",
            "ex_prop_crate_watch",
            "ex_prop_crate_xldiam"
        };
        private readonly List<string> CratesName = new List<string>
        {
            "Movie Reel",
            "Golden Minigun",
            "Fabershay Egg",
            "Yeti Hide",
            "Golden Watch",
            "Dimond"
        };
        private List<int> PalletsLocals(int lod)
        {
            List<int> ReturnPallet;

            if (lod == 1)
            {
                ReturnPallet = new List<int> { 1, 2, 3, 4, 5 };
            }//small ware
            else if (lod == 2)
            {
                ReturnPallet = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            }//mid ware
            else if (lod == 3)
            {
                ReturnPallet = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            }//lg ware
            else
            {
                ReturnPallet = new List<int> { 0, 1, 2, 3, 4, 5 };
            }//bunker

            return ReturnPallet;
        }
        public CargoLift(int iArea)
        {
            iSuprise = RandomX.FindRandom("CargoSup01", 1, 5);
            iTem = RandomX.FindRandom("CargoSup02", 0, Crates.Count - 1);
            CashPay = 0;
            sItem = Crates[iTem];
            sItemName = CratesName[iTem];
            if (iTem == 0)
            {
                Instruct01 = 155;
                Instruct02 = 161;
                Instruct03 = 168;
            }
            else if (iTem == 1)
            {
                Instruct01 = 154;
                Instruct02 = 160;
                Instruct03 = 167;
            }
            else if (iTem == 2)
            {
                Instruct01 = 152;
                Instruct02 = 158;
                Instruct03 = 165;
            }
            else if (iTem == 3)
            {
                Instruct01 = 153;
                Instruct02 = 159;
                Instruct03 = 166;
            }
            else if (iTem == 4)
            {
                Instruct01 = 156;
                Instruct02 = 162;
                Instruct03 = 169;
            }
            else 
            {
                Instruct01 = 157;
                Instruct02 = 163;
                Instruct03 = 170;
            }
            
            BluePallet = null;
            Truck = null;
            ForkLift = null;

            int Area2 = RandomX.RandInt(1, 6); 
            while (iArea == Area2)
                Area2 = RandomX.RandInt(1, 6);

            Buissness = MissionData.AppartmentBlocks(iArea, 2, -1, -1, true);
            while (Buissness.PedNum == 5)
                Buissness = MissionData.AppartmentBlocks(iArea, 2, -1, -1, true);
            DropOff = MissionData.AppartmentBlocks(Area2, 8, -1, -1, true);
            Pallets = PalletsLocals(Buissness.PedNum);
            Enemys = ReturnStuff.IndoorPed(Buissness.PedNum);

            if (Buissness.PedNum == 1)
                ForkIt = new Vector4(1096.736f, -3102.306f, -39.536f, 90f);
            else if (Buissness.PedNum == 2)
                ForkIt = new Vector4(1050.150f, -3106.273f, -39.537f, -90f);
            else if (Buissness.PedNum == 3)
                ForkIt = new Vector4(996.850f, -3110.364f, -39.536f, -90f);
            else
                ForkIt = new Vector4(883.176f, -3238.595f, -98.818f, 178.857f);

            MoveVeh = true;
        }
    }
    public class SharkTank
    {
        public bool BombsAway { get; set; }
        public int SubSelect { get; set; }
        public int DropTime { get; set; }
        public int TotalTime { get; set; }
        public int CashPay { get; set; }
        public Vehicle Sub { get; set; }
        public LoanSharks Sharky { get; }

        public SharkTank(int iArea)
        {
            BombsAway = false;
            SubSelect = 0;
            DropTime = 0;
            TotalTime = 0;
            Sharky = MissionData.FindSharks(iArea);
            Sub = null;
        }
    }
    public class MiniMart
    {
        public int iTimes { get; set; }
        public int iDamage { get; set; }

        public List<int> iSBroke { get; set; }
        public FubarVectors Buissness { get; }
        public List<Vector4> Indoors { get; }
        public SideBar ShopBar { get; set; }
        public MiniMart(int area)
        {
            iTimes = 0;
            iDamage = 0;
            iSBroke = new List<int>();
            int iBis = 0;
            if (area == 1)
                iBis = RandomX.FindRandomList("MMart01", new List<int> { 3, 4 });
            else if (area == 2)
                iBis = RandomX.FindRandomList("MMart02", new List<int> { 6, 13, 14, 19 });
            else if (area == 3)
                iBis = RandomX.FindRandomList("MMart03", new List<int> { 6, 7, 8, 9 });
            else if (area == 4)
                iBis = RandomX.FindRandomList("MMart04", new List<int> { 1, 3, 5 });
            else if (area == 5)
                iBis = RandomX.FindRandomList("MMart05", new List<int> { 1, 2, 3, 4, 5, 9 });
            else
                iBis = 1;

            Buissness = MissionData.AppartmentBlocks(area, 3, iBis, -1, true);
            Indoors = ReturnStuff.IndoorPed(Buissness.PedNum);
            ShopBar = new SideBar(DataStore.MyLang.Othertext[148], "", 0f, true);
            ShopBar.SlideBar = new RGBA(1);
        }
    }
    public class MoreThan
    {
        public bool AddGhost { get; set; }
        public bool BarFlash { get; set; }
        public int BarFlashWait { get; set; }
        public int BlowTime { get; set; }
        public float VehHurt { get; set; }
        public float ParkingFine { get; set; }
        public Vector4 ChopNPop { get; }
        public FubarVectors ParkNRide { get; }
        public Vector3 FubStop { get; }
        public Vehicle MyWhip { get; }
        public Vehicle GhostWhip { get; set; }
        public Ped Stiff { get; set; }

        private readonly List<Vector4> ChopShop = new List<Vector4>
        {
            new Vector4(-440.3831f, -2177.316f, 9.24302f, 0.00f),
            new Vector4(135.4072f, -1050.72f, 27.34729f, 162.00f),
            new Vector4(-1132.258f, 2697.845f, 17.99048f, 144.75f),
            new Vector4(1139.909f, -792.7662f, 56.78955f, 90.00f),
            new Vector4(2350.803f, 3133.545f, 47.39877f,78.00f),
            new Vector4(-62.00491f, 6443.913f, 30.68172f,43.50f)
        };

        public MoreThan(int local)
        {
            AddGhost = true;
            BarFlash = false;
            BarFlashWait = 0;
            BlowTime = 0;
            VehHurt = 0f;
            ChopNPop = ChopShop[local - 1];
            ParkNRide = MissionData.AppartmentBlocks(local, 8, -1, -1, true);
            FubStop = World.GetNextPositionOnStreet(ParkNRide.ParkHere.V3);
            MyWhip = EntityBuild.VehicleSpawn(new VehMods(ReturnStuff.AddRandomVeh(RandomX.FindRandom("Mores01", 1, 10)), 0, 5, true, DataStore.MyLang.Maptext[14], false, true, ReturnStuff.FunPlates()), ParkNRide.ParkHere);
            GhostWhip = null;
            Stiff = null;
        }
    }
    public class CarBall
    {
        public bool bReds { get; set; }
        public bool Goal { get; set; }
        public int iReds { get; set; }
        public int iBlues { get; set; }
        public int iClock { get; set; }
        public Prop Football { get; set; }
        public Vector3 FuStop { get; }
        public Vector3 KickOff { get; }
        public Vector3 ExEntrance { get; }
        public Vector3 InEntrance { get; }
        public Vector4 Exit { get; }
        public Vehicle Prize { get; set; }
        public List<Vector4> Formation { get; }
        public List<Vector4> CarPool { get; set; }

        public CarBall()
        {
            bReds = false;
            Goal = true;
            iReds = 0;
            iBlues = 0;
            iClock = 0;
            Football = null;
            FuStop = new Vector3(800.1396f, -1774.456f, 29.34297f);
            KickOff = new Vector3(-1981.921f, 1099.328f, 26.46269f);
            ExEntrance = new Vector3(787.7271f, -1770.375f, 28.29461f);
            InEntrance = new Vector3(-2212.344f, 1073.025f, 29.77212f);
            Exit = new Vector4(784.5073f, -1868.115f, 29.2216f, 251.9097f);
            Prize = null;
            Formation = new List<Vector4>
            {
                new Vector4(-1998.645f, 1097.889f, 24.86589f, 269.5195f),
                new Vector4(-2001.027f, 1102.583f, 24.86389f, 269.5195f),
                new Vector4(-2001.151f, 1091.858f, 24.86417f, 271.7703f),
                new Vector4(-2007.956f, 1088.784f, 24.86602f, 271.7376f),
                new Vector4(-2008.376f, 1115.527f, 24.86123f, 266.8758f),
                new Vector4(-1969.02f, 1098.757f, 24.86595f, 90.43178f),
                new Vector4(-1964.685f, 1092.816f, 24.86395f, 90.43178f),
                new Vector4(-1963.999f, 1104.846f, 24.86103f, 90.43177f),
                new Vector4(-1955.946f, 1106.741f, 24.86423f, 90.43176f),
                new Vector4(-1956.167f, 1089.103f, 24.86414f, 90.43172f)
            };
            CarPool = new List<Vector4>
            {
                new Vector4(-2177.811f, 1087.438f, 28.18942f, 269.915f),
                new Vector4(-2177.133f, 1094.691f, 28.19033f, 269.5286f),
                new Vector4(-2177.756f, 1107.449f, 28.186f, 90.48133f),
                new Vector4(-2177.749f, 1117.644f, 28.18346f, 270.4045f),
                new Vector4(-2178.158f, 1124.109f, 28.183f, 270.1498f),
                new Vector4(-2177.197f, 1137.583f, 28.18233f, 88.53631f),
                new Vector4(-2160.691f, 1154.501f, 28.18356f, 179.0026f),
                new Vector4(-2144.921f, 1145.939f, 28.18462f, 267.3809f),
                new Vector4(-2145.376f, 1139.874f, 28.18336f, 88.67729f),
                new Vector4(-2144.958f, 1136.682f, 28.18353f, 89.13258f),
                new Vector4(-2145.425f, 1133.542f, 28.1842f, 88.60604f),
                new Vector4(-2145.74f, 1093.254f, 28.18992f, 86.601f),
                new Vector4(-2145.605f, 1083.198f, 28.19049f, 270.0027f),
                new Vector4(-2158.845f, 1083.501f, 28.19156f, 268.9763f),
                new Vector4(-2158.744f, 1086.845f, 28.19164f, 269.565f),
                new Vector4(-2158.829f, 1094.491f, 28.19087f, 269.0538f),
                new Vector4(-2158.365f, 1097.776f, 28.19056f, 270.9919f),
                new Vector4(-2165.167f, 1097.727f, 28.19054f, 89.75224f),
                new Vector4(-2164.7f, 1094.402f, 28.19084f, 92.01196f),
                new Vector4(-2164.979f, 1086.673f, 28.1919f, 89.58455f),
                new Vector4(-2165.531f, 1083.449f, 28.19239f, 88.94128f),
                new Vector4(-2158.714f, 1115.803f, 28.18392f, 268.1812f),
                new Vector4(-2164.125f, 1116.272f, 28.18392f, 88.08123f),
                new Vector4(-2164.26f, 1126.021f, 28.18344f, 91.12691f),
                new Vector4(-2159.291f, 1126.071f, 28.18359f, 270.1757f),
                new Vector4(-2186.163f, 1093.162f, 29.77102f, 274.0882f),
                new Vector4(-2185.962f, 1116.167f, 29.77088f, 89.21154f),
                new Vector4(-2203.729f, 1125.39f, 29.77118f, 271.6154f)
            };
        }

    }
    public class Cales
    {
        public int Walkin { get; set; }
        public int CashPay { get; set; }
        public bool GetDrink { get; set; }
        public bool AtTheBar { get; set; }
        public float BarHate { get; set; }

        public FubarVectors ClubX { get; }
        public Vector3 Till { get; }
        public Vector4 EnterClub { get; }
        public List<Ped> Brusers { get; set; }
        public List<Vector3> WalkTo { get; }
        public List<Vector4> ClubQ { get; }
        public List<Vector4> BarstandPed { get; }
        public List<Vector3> BarstandPlay { get; }
        public List<int> BarFaults { get; set; }

        public Cales()
        {
            Walkin = 0;
            CashPay = 0;
            GetDrink = false;
            AtTheBar = false;
            BarHate = 0f;

            ClubX = MissionData.AppartmentBlocks(2, 5, RandomX.FindRandom("TempL02", 35, 39), -1, true);
            Till = new Vector3(-1582.72f, -3014.096f, -77.00f);
            EnterClub = new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f);
            Brusers = new List<Ped>();
            WalkTo = new List<Vector3>
            {
                new Vector3(-1585.062f, -3005.696f, -77.00f),
                new Vector3(-1582.686f, -3008.728f, -77.00f),
                new Vector3(-1583.689f, -3012.495f, -77.00f)
            };
            ClubQ = ReturnStuff.IndoorPed(ClubX.PedNum);
            BarstandPed = new List<Vector4>
            {
                new Vector4(-1585.6615f, -3008.5205f, -77.00f, 200.00f),
                new Vector4(-1586.86743f, -3011.75391f, -77.00f, 285.00f),
                new Vector4(-1586.82129f, -3014.02803f, -77.00f, 285.00f),
                new Vector4(-1585.55945f, -3016.66675f, -77.00f, 315f)
            };
            BarstandPlay = new List<Vector3>
            {
                new Vector3(-1584.3479f, -3009.96948f, -77.00f),
                new Vector3(-1584.96326f, -3011.84546f, -77.00f),
                new Vector3(-1584.89465f, -3014.04219f, -77.00f),
                new Vector3(-1584.31482f, -3015.27197f, -77.00f)
            };
            BarFaults = new List<int> { 0,1,2,3 };
        }
    }
    public class Dupes
    {
        public bool InBuild { get; set; }
        public int FilledDump { get; set; }
        public int CashPay { get; set; }

        public Vector3 Fubar { get; }
        public Vector3 Target01 { get; }
        public Vector4 Target02 { get; }
        public Vector4 Target03 { get; }

        public Vehicle Dozer { get; set; }
        public Vehicle CurrentDump { get; set; }
        public List<Vehicle> Dumps { get; set; }
        public List<Vector3> Vlist01 { get; }
        public List<Vector3> Vlist02 { get; }

        public Dupes()
        {
            InBuild = false;
            FilledDump = 0;
            CashPay = 0;
            Fubar = new Vector3(-2063.984f, 3191.224f, 32.81033f);
            Target01 = new Vector3(-2013.86096f, 3218.96973f, 52.1987915f);
            Target02 = new Vector4(-1300.317f, -2989.907f, -33.072f, 177.2672f);
            Target03 = new Vector4(-1308.34302f, -2992.78857f, -48.9497147f, -89.7529602f);
            Dumps = new List<Vehicle>();
            Vlist01 = new List<Vector3>
            {
                new Vector3(-1490.6792f, 2702.30664f, 18.014452f),
                new Vector3(-1516.29944f, 2724.75562f, 18.0269489f),
                new Vector3(-1530.4884f, 2737.34253f, 18.0259171f),
                new Vector3(-1503.85864f, 2713.92212f, 18.0179501f)
            };
            Vlist02 = new List<Vector3>
            {
                new Vector3(189.6861f, 2819.862f, 40.78401f),
                new Vector3(190.8403f, 2837.878f, 40.83955f),
                new Vector3(196.4462f, 2855.003f, 41.085f),
                new Vector3(202.5097f, 2874.981f, 40.98077f)
            };
        }
    }
    public class Dimond
    {
        public bool MoveCorpse { get; set; }
        public bool ShiftStart { get; set; }
        public int IWalks { get; set; }
        public float DistanceFrom { get; set; }
        public int CashPay { get; set; }
        public Ped Driver { get; set; }
        public Vehicle Car { get; set; }
        public Vector3 Fubs { get; }
        public Vector3 ExtDoor { get; }
        public Vector4 IntDoor { get; }
        public Vector4 Podium { get; }
        public Vector3 DriverWalkto { get; }
        public Vector3 DriverWalkto2 { get; }
        public Vector3 ParkHere { get; }
        public Vector3 OffRamp { get; }
        public Vector4 ExGarage { get; }
        public Vector4 InGarage { get; }
        public List<Ped> Drivers { get; set; }
        public List<Vector3> WalkTo { get; set; }
        public ClothBank Outfit { get; }
        public ClothBank Uniform { get; }

        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform; 
            if (sName == "Franklin")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("FrankValay", new List<int> { 0, 0, -10, 18, 6, 0, 6, 0, 0, 0, 0, 3 }, new List<int> { 0, 0, 0, 10, 7, 0, 2, 0, 0, 0, 0, 15 }, new List<int> { }, new List<int> { }));
            else if (sName == "Michael")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("MickValay", new List<int> { 0, 0, -10, 23, 0, 0, 0, 0, 0, 0, 0, 5 }, new List<int> { 0, 0, 0, 7, 3, 0, 2, 0, 0, 0, 0, 8 }, new List<int> { }, new List<int> { }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("Valay", false, false, true, new ClothX("TrevValay", new List<int> { 0, 0, -10, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeFemale")
                Uniform = new ClothBank("Valay", false, true, false, new ClothX("FreeFemaleValay", new List<int> { 0, 0, -10, 9, 133, 0, 101, 0, 193, 0, 0, 303 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeMale")
                Uniform = new ClothBank("Valay", false, true, true, new ClothX("FreeMaleValay", new List<int> { 0, 0, -10, 11, 126, 0, 97, 0, 157, 0, 0, 290 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else
                Uniform = null;

            return Uniform;
        }

        public Dimond()
        {
            MoveCorpse = true;
            ShiftStart = true;
            IWalks = 0;
            DistanceFrom = 0f;
            CashPay = 0;
            Driver = null;
            Fubs = new Vector3(972.0197f, 1.485185f, 81.04102f);
            ExtDoor = new Vector3(977.4801f, 16.66478f, 79.99027f);
            IntDoor = new Vector4(2549.292f, -269.0374f, -58.72298f, 149.0205f);
            Podium = new Vector4(927.10f, 52.47f, 80.09f, 53.27f);
            DriverWalkto = new Vector3(926.87f, 45.28f, 81.10f);
            DriverWalkto2 = new Vector3(922.86f, 47.84f, 81.10f);
            ParkHere = new Vector3(919.32f, 53.66f, 79.90f);//60fRadi
            ExGarage = new Vector4(934.57f, -1.20f, 77.75f, 148.7573f);
            InGarage = new Vector4(1339.46f, 183.83f, -48.88f, 266.8939f);
            OffRamp = new Vector3(1339.779f, 190.8532f, -48.40091f); 
            EntityBuild.BuildProp("vw_prop_vw_valet_01a", new Vector3(926.022339f, 53.1337013f, 80.0960464f), new Vector3(0.00f, 0.00f, 56.3316803f), true, false);
            Drivers = new List<Ped>();
            WalkTo = new List<Vector3>
            {
                new Vector3(2546.965f, -275.5642f, -59.72301f),
                new Vector3(2531.238f, -301.6779f, -59.72301f),
                new Vector3(2517.586f, -263.2542f, -59.7164f),
                new Vector3(1379.966f, 259.5016f, -49.99368f),
                new Vector3(1379.977f, 178.0438f, -49.99321f),
                new Vector3(935.7204f, 46.89984f, 80.09576f)
            };
            Outfit = new ClothBank(Game.Player.Character);
            Uniform = UniformCheck(Outfit.Name);
        }
    }
    public class Silo
    {
        public int iCount { get; set; }
        public int MyLod { get; set; }
        public int AchTime { get; set; }
        public bool FailedTarget { get; set; }
        public string ItemName { get; set; }
        public string DisplayName { get; set; }
        public Vector4 BAckDoor { get; }
        public Vector3 Fubs { get; }
        public Vector3 ExDoor { get; }
        public Vector4 InDoor { get; }
        public Vector3 TruckEnd { get; }
        public Vehicle Truck { get; set; }
        public Prop Pop01 { get; set; }
        public Prop Pop02 { get; set; }
        public Ped Gaffer { get; set; }
        public Ped Tech { get; set; }
        public Ped Sci { get; set; }
        public List<Vector3> Vlist01 { get; }
        public List<Vector3> Vlist02 { get; }
        public List<Vector3> Vlist03 { get; }

        public Silo()
        {
            iCount = 0;
            MyLod = 253;
            AchTime = 0;
            FailedTarget = false;
            ItemName = "";
            DisplayName = DataStore.MyLang.Mistext[224];
            Fubs = new Vector3(-356.3851f, 4817.959f, 142.884f);
            ExDoor = new Vector3(-354.5753f, 4825.253f, 143.2983f);
            InDoor = new Vector4(1259.798f, 4813.462f, -40.1302f, 344.0048f);
            TruckEnd = new Vector3(618.0434f, 5975.604f, -158.6149f);
            BAckDoor = new Vector4(598.7726f, 5556.833f, 719.1628f, 284.7071f);
            Vlist01 = new List<Vector3>
            {
                new Vector3(583.1594f, 5950.698f, -157.8608f),
                new Vector3(561.7137f, 5946.754f, -158.0875f),
                new Vector3(525.4651f, 5914.496f, -158.0743f),
                new Vector3(506.1479f, 5930.793f, -158.2723f),
                new Vector3(471.1572f, 5942.663f, -158.2724f)
            };
            Vlist02 = new List<Vector3>
            {
                new Vector3(451.5411f, 5934.055f, -158.2725f),
                new Vector3(435.8286f, 5896.741f, -158.1377f),
                new Vector3(404.3304f, 5911.654f, -158.1404f),
                new Vector3(385.5074f, 5919.386f, -158.1323f),
                new Vector3(318.8944f, 5912.807f, -158.2419f),
                new Vector3(292.2531f, 5910.451f, -158.744f),
                new Vector3(247.2675f, 5951.258f, -159.4836f),
                new Vector3(241.526f, 6011.808f, -159.4314f),
                new Vector3(249.2736f, 6093.571f, -159.4274f)
            };
            Vlist03 = new List<Vector3>
            {
                new Vector3(435.5199f, 5952.862f, -158.272f),
                new Vector3(415.0114f, 5941.154f, -158.272f),
                new Vector3(376.1922f, 5944.769f, -158.2718f),
                new Vector3(344.732f, 5947.076f, -158.2718f),
                new Vector3(311.6838f, 5969.031f, -158.2795f),
                new Vector3(315.4673f, 6004.23f, -158.8825f),
                new Vector3(283.5168f, 6026.202f, -159.148f),
                new Vector3(238.6745f, 6048.443f, -159.4266f),
                new Vector3(249.362f, 6093.539f, -159.4273f)
            };
        }
    }
    public class ParaNoid
    {
        public bool OutCorrona { get; set; }
        public bool CarWeap { get; set; }
        public bool OutCar { get; set; }
        public bool NearPlayer { get; set; }
        public bool Hatchet { get; set; }
        public bool Golf { get; set; }
        public bool BBall { get; set; }
        public bool Knife { get; set; }
        public int Set01 { get; set; }
        public int PlaneTime { get; set; }
        public int MissionTime { get; set; }
        public int CashPay { get; set; }
        public float BlipArea { get; set; }
        public Vector4 Starting { get; }
        public Vector3 DropPoint { get; }
        public float Speed { get; }
        public List<Vector3> WeapsPick { get; }
        public Vehicle Plane { get; }
        public Ped Pilot { get; }
        public List<Vector4> AWVeh { get; }

        public ParaNoid(int iArea)
        {
            OutCorrona = false;
            CarWeap = true;
            OutCar = true;
            NearPlayer = false;
            Hatchet = false;
            Golf = false;
            BBall = false;
            Knife = false;
            Set01 = 45000;
            CashPay = 10000;
            BlipArea = 2000f;
            if (iArea == 1)
            {
                Speed = 150.00f;
                Starting = new Vector4(1699.023f, -3577.555f, 1018.34636f, 34.15989f);
                DropPoint = new Vector3(108.2113f, -1941.377f, 20.80372f);
                WeapsPick = new List<Vector3> { new Vector3(78.14943f, -1947.699f, 21.17414f), new Vector3(85.30692f, -1958.906f, 21.1217f), new Vector3(111.7987f, -1959.725f, 20.90635f), new Vector3(130.37f, -1939.236f, 20.62193f), new Vector3(125.1701f, -1929.549f, 21.38252f), new Vector3(110.7112f, -1921.619f, 20.83934f), new Vector3(99.49545f, -1913.781f, 21.02738f), new Vector3(74.56801f, -1937.954f, 21.00955f) };
                AWVeh = MissionData.ParaVeh01;
            }
            else if (iArea == 2)
            {
                Speed = 150.00f;
                Starting = new Vector4(-2661.153f, -1634.276f, 1012.495f, 292.9644f);
                DropPoint = new Vector3(-509.8384f, -264.9922f, 35.5558f);
                WeapsPick = new List<Vector3> { new Vector3(-508.8449f, -245.3427f, 36.16624f), new Vector3(-527.0029f, -256.3004f, 36.16623f), new Vector3(-519.2386f, -248.7684f, 36.27728f), new Vector3(-524.0146f, -240.2447f, 36.07898f), new Vector3(-526.8874f, -221.3588f, 38.70853f), new Vector3(-538.8707f, -228.8061f, 38.72643f), new Vector3(-547.4329f, -219.6783f, 37.51975f), new Vector3(-530.3271f, -209.8037f, 37.52062f) };
                AWVeh = MissionData.ParaVeh02;
            }
            else if (iArea == 3)
            {
                Speed = 250.00f;
                Starting = new Vector4(-3738.292f, 2733.368f, 1028.42558f, 223.4233f);
                DropPoint = new Vector3(-1892.363f, 2019.61f, 140.806f);
                WeapsPick = new List<Vector3> { new Vector3(-1889.045f, 2000.307f, 141.9783f), new Vector3(-1908.31f, 1997.688f, 142.0989f), new Vector3(-1910.906f, 2022.19f, 140.8345f), new Vector3(-1923.563f, 2030.954f, 140.7387f), new Vector3(-1925.242f, 2047.531f, 140.8321f), new Vector3(-1931.795f, 2062.081f, 140.839f), new Vector3(-1889.49f, 2050.174f, 140.9855f), new Vector3(-1891.58f, 2039.388f, 140.8805f) };
                AWVeh = MissionData.ParaVeh03;
            }
            else if (iArea == 4)
            {
                Speed = 350.00f;
                Starting = new Vector4(2771.21f, 1022.148f, 1057.28427f, 115.942f);
                DropPoint = new Vector3(1173.156f, -640.7235f, 62.5041f);
                WeapsPick = new List<Vector3> { new Vector3(1144.993f, -634.9371f, 56.79569f), new Vector3(1146.292f, -649.1385f, 56.80311f), new Vector3(1144.897f, -664.7214f, 57.08257f), new Vector3(1134.253f, -665.8447f, 57.08257f), new Vector3(1113.844f, -649.0207f, 57.74995f), new Vector3(1109.608f, -632.2032f, 56.81606f), new Vector3(1165.73f, -640.44f, 62.27423f), new Vector3(1166.636f, -644.357f, 62.14673f) };
                AWVeh = MissionData.ParaVeh04;
            }
            else if (iArea == 5)
            {
                Speed = 400.00f;
                Starting = new Vector4(2439.888f, 4419.493f, 1025.7415f, 124.8518f);
                DropPoint = new Vector3(872.162f, 2852.799f, 56.98187f);
                WeapsPick = new List<Vector3> { new Vector3(847.4106f, 2863.256f, 58.48529f), new Vector3(889.1376f, 2855.058f, 57.0004f), new Vector3(891.0823f, 2875.32f, 56.27547f), new Vector3(860.6051f, 2876.518f, 57.98239f), new Vector3(866.5287f, 2838.802f, 58.054f), new Vector3(842.7958f, 2844.654f, 58.77506f), new Vector3(882.1851f, 2863.635f, 56.59078f), new Vector3(871.5983f, 2877.702f, 56.85495f) };
                AWVeh = MissionData.ParaVeh05;
            }
            else if (iArea == 6)
            {
                Speed = 150.00f;
                Starting = new Vector4(125.0108f, 7804.23f, 1022.20254f, 180.6979f);
                DropPoint = new Vector3(-591.01f, 5287.489f, 70.21441f);
                WeapsPick = new List<Vector3> { new Vector3(-589.8073f, 5320f, 70.51969f), new Vector3(-587.0214f, 5328.494f, 70.6096f), new Vector3(-569.1222f, 5321.714f, 70.18068f), new Vector3(-575.8088f, 5279.454f, 71.62724f), new Vector3(-564.2249f, 5270.697f, 70.42567f) };
                AWVeh = MissionData.ParaVeh06;
            }
            else if (iArea == 7)
            {
                Speed = 150.00f;
                Starting = new Vector4(4106.358f, -2904.234f, 1015.284f, 186.5306f);
                DropPoint = new Vector3(4995.699f, -5183.38f, 2.493078f);
                WeapsPick = new List<Vector3> { new Vector3(5000.246f, -5163.39f, 3.701138f), new Vector3(5001.257f, -5165.43f, 3.701141f), new Vector3(5003.046f, -5191.527f, 2.515878f), new Vector3(4979.662f, -5200.131f, 2.501703f), new Vector3(4970.88f, -5171.287f, 2.258204f), new Vector3(4959.281f, -5157.375f, 2.438913f), new Vector3(4977.195f, -5144.679f, 2.531023f), new Vector3(4994.537f, -5154.646f, 2.626558f) };
                AWVeh = MissionData.ParaVeh07;
            }
            Plane = EntityBuild.VehicleSpawn(new VehMods("BOMBUSHKA", 19, true), Starting);

            Pilot = EntityBuild.NPCSpawn(new PedFeat(ReturnStuff.RandNPC(32), false, 190, 8, 1, Plane, 0, false, 0, ""), Vector3.Zero, 0.00f);
            Vector3 vTag = DropPoint;
            vTag.Z = 1005.00f;
            EntityBuild.FlyPlane(Pilot, Plane, vTag, null);
        }
    }
    public class FubarEats
    {
        public int Earnings { get; set; }
        public int TimeTaken { get; set; }
        public bool Uniform { get; set; }
        public bool Bike { get; set; }
        public bool Fuoobd { get; set; }
        public FubarVectors Start { get; }
        public FubarVectors End { get; }
        public Vector3 FubsStop { get; set; }
        public ClothBank Wear { get; }
        public Ped MyDel { get; set; }

        public FubarEats(int iArea, int earnings, int timeTaken, bool uniform, bool bike, bool fuoobd)
        {
            Bike = bike;
            Fuoobd = fuoobd;
            Earnings += earnings;
            Uniform = uniform;
            if (timeTaken == 0)
                TimeTaken = Game.GameTime;
            else
                TimeTaken = timeTaken;
            Start = MissionData.AppartmentBlocks(iArea, 4, -1, -1, true);
            End = MissionData.AppartmentBlocks(iArea, RandomX.FindRandom("FubarEatsRt", 6, 9), -1, -1, true);
            Wear = new ClothBank(Game.Player.Character);
        }
    }
    public class CayoFollow
    {
        public int iPlace { get; set; }
        public Vector3 RunHere { get; set; }
        public List<Vector3> MyStart { get; }
        public List<Vector3> MyEnd { get; }
        public float EndHead { get; }
        public Vector3 HangingTree01 { get; }
        public Vector4 HangingTree02 { get; }
        public Ped TargetPed { get; set; }
        public float SnDist { get; set; }
        public int SneakTime { get; set; }
        public int FlashTime { get; set; }
        public int KnowTime { get; set; }
        public int SomeTime { get; set; }
        public bool Sneaky { get; set; }
        public bool FlashWarn { get; set; }
        public bool TheyKnowU { get; set; }
        public bool DoOnce { get; set; }

        public CayoFollow(int myStart, int myEnd)
        {
            iPlace = 1;
            if (myStart == 1)
                MyStart = MissionData.CayoFolStart01;
            else if (myStart == 2)
                MyStart = MissionData.CayoFolStart02;
            else
                MyStart = MissionData.CayoFolStart03;

            if (myEnd == 1)
            {
                MyEnd = MissionData.CayoFolEnd01;
                EndHead = 133.7113f;
            }
            else if (myEnd == 2)
            {
                MyEnd = MissionData.CayoFolEnd02;
                EndHead = 249.0917f;
            }
            else if (myEnd == 3)
            {
                MyEnd = MissionData.CayoFolEnd03;
                EndHead = 342.8236f;
            }
            else if (myEnd == 4)
            {
                MyEnd = MissionData.CayoFolEnd04;
                EndHead = 214.1936f;
            }
            else
            {
                MyEnd = MissionData.CayoFolEnd05;
                EndHead = 295.8683f;
            }

            HangingTree01 = new Vector3(5110.793f, -5404.554f, 23.40375f);
            HangingTree02 = new Vector4(5115.762f, -5404.809f, 21.81437f, 66.24686f);

            TargetPed = null;
            SnDist = 0f;
            SneakTime = 0;
            FlashTime = 0;
            KnowTime = 0;
            SomeTime = 0;
            Sneaky = false;
            FlashWarn = false;
            TheyKnowU = false;
            DoOnce = true;

            RunHere = MyStart[1];
        }
    }
    public class CayoHeist
    {
        public int MyStart { get; set; }
        public bool FlyingPed { get; }
        public bool DontShoot { get; set; }
        public string PedLoc { get; }
        public int TimerX { get; set; }
        public int iGone { get; }
        public Vector3 TargX { get; set; }
        public Vector3 FlyingDes { get; }
        public Vector4 TakeOff { get; }
        public List<Vector4> HeliPath { get; }
        public int iHeliPath { get; set; }
        public List<Vector3> ThiefPath { get; }
        public int iThiefPath { get; set; }
        public RacingLines ThiefBoat { get; }
        public Vehicle Chopper { get; }
        public Vehicle ExcapeVeh { get; set; }
        public Ped Juan { get; }
        public Ped Pilot { get; }
        public Ped Thief { get; set; }
    
        public CayoHeist(int myStart)
        {
            TakeOff = new Vector4(4887.682f, -5747.711f, 116.7361f, 331.936f);
            FlyingPed = false;
            DontShoot = true;
            iHeliPath = 0;
            iThiefPath = 0;
            HeliPath = new List<Vector4>();
            ThiefPath = new List<Vector3>();

            if (myStart == 1)
            {
                MyStart = myStart;
                HeliPath.Add(new Vector4(5083.081f, -5429.721f, 91.19279f, 327.6324f));
                HeliPath.Add(new Vector4(5111.587f, -5172.778f, 82.07673f, 39.21318f));
                HeliPath.Add(new Vector4(5020.269f, -5066.57f, 58.27757f, 78.82922f));
                HeliPath.Add(new Vector4(4878.171f, -5074.571f, 44.4136f, 149.9168f));

                ThiefPath.Add(new Vector3(4977.092f, -5234.123f, 5.362415f));
                ThiefPath.Add(new Vector3(4954.453f, -5214.639f, 2.526253f));
                ThiefPath.Add(new Vector3(4981.531f, -5194.562f, 2.431887f));
                ThiefPath.Add(new Vector3(4985.519f, -5177.848f, 2.494078f));
                ThiefPath.Add(new Vector3(4968.461f, -5169.152f, 1.989646f));

                ThiefBoat = new RacingLines("TB1", 2, MissionData.ThifeBoatMain[0].Pos);
                ThiefBoat.RaceLine = MissionData.ThifeBoatMain;

                PedLoc = DataStore.MyLang.Othertext[20];
                iGone = 176;
            }
            else if (myStart == 2)
            {
                MyStart = myStart;
                HeliPath.Add(new Vector4(5133.882f, -4887.601f, 92.11411f, 317.4302f));
                HeliPath.Add(new Vector4(5259.402f, -4663.197f, 84.42941f, 28.20848f));
                HeliPath.Add(new Vector4(5126.226f, -4516.298f, 58.03263f, 103.8986f));
                HeliPath.Add(new Vector4(4972.652f, -4673.413f, 45.36294f, 212.9373f));

                ThiefPath.Add(new Vector3(5040.295f, -4701.252f, 7.407453f));
                ThiefPath.Add(new Vector3(5061.636f, -4641.003f, 2.585966f));
                ThiefPath.Add(new Vector3(5065.153f, -4629.664f, 2.471225f));
                ThiefPath.Add(new Vector3(5080.699f, -4634.967f, 1.898226f));

                ThiefBoat = new RacingLines("TB2", 2, MissionData.ThifeBoatNorth[0].Pos);
                ThiefBoat.RaceLine = MissionData.ThifeBoatNorth;

                PedLoc = DataStore.MyLang.Othertext[21];
                iGone = 177;
            }
            else
            {
                MyStart = myStart;
                HeliPath.Add(new Vector4(4566.874f, -5000.102f, 77.30904f, 12.97973f));

                ThiefPath.Add(new Vector3(4614.354f, -4531.724f, 12.35623f));
                ThiefPath.Add(new Vector3(4582.088f, -4511.286f, 10.25273f));
                ThiefPath.Add(new Vector3(4543.866f, -4505.861f, 4.452652f));
                ThiefPath.Add(new Vector3(4485.055f, -4498.207f, 4.189588f));

                FlyingDes = new Vector3(2702.896f, -5152.048f, 410.2933f);
                FlyingPed = true;
                PedLoc = DataStore.MyLang.Othertext[22];
                iGone = 178;
            }

            Chopper = EntityBuild.VehicleSpawn(new VehMods("VALKYRIE", 0, 5, true, DataStore.MyLang.Maptext[5], true), new Vector3(4889.581f, -5738.292f, 25.7357f), 339.405f);
            Pilot = EntityBuild.NPCSpawn(new PedFeat(ReturnStuff.RandNPC(43), false, 140, 13, 1, Chopper, 0, false, 0, ""), Chopper.Position, 0.00f);
            Juan = EntityBuild.NPCSpawn(new PedFeat("ig_juanstrickler", false, 140, 13, 4, Chopper, 0, false, 0, ""), Chopper.Position, 0.00f);
        }
    }
    public class LifeGuards
    {
        public int Zone { get; set; }
        public int RescueTime { get; set; }
        public Ped Victim { get; set; }
        public Vector4 GuardStation { get; set; }
        public Vector3 VicLocal { get; set; }
        public Vehicle LGVeh { get; set; }
        public Vehicle VicsVeh { get; set; }

        public ClothBank Oufit { get; }
        public ClothBank Uniform { get; }

        private ClothBank UniformCheck(string sName)
        {
            ClothBank Uniform;
            if (sName == "Franklin")
                Uniform = new ClothBank("LifeGuard", false, false, true, new ClothX("FrankLife", new List<int> { 0, 1, 0, 18, 6, 0, 6, 0, 0, 0, 0, 3 }, new List<int> { 0, 0, 0, 10, 7, 0, 2, 0, 0, 0, 0, 15 }, new List<int> { }, new List<int> { }));
            else if (sName == "Michael")
                Uniform = new ClothBank("LifeGuard", false, false, true, new ClothX("MickLife", new List<int> { 0, 1, 0, 23, 0, 0, 0, 0, 0, 0, 0, 5 }, new List<int> { 0, 0, 0, 7, 3, 0, 2, 0, 0, 0, 0, 8 }, new List<int> { }, new List<int> { }));
            else if (sName == "Trevor")
                Uniform = new ClothBank("LifeGuard", false, false, true, new ClothX("TrevLife", new List<int> { 0, 1, 0, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeFemale")
                Uniform = new ClothBank("LifeGuard", false, true, false, new ClothX("FFLife", new List<int> { 0, 1, 0, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else if (sName == "FreeMale")
                Uniform = new ClothBank("LifeGuard", false, true, true, new ClothX("FMLife", new List<int> { 0, 1, 0, 26, 21, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { }, new List<int> { }));
            else
                Uniform = null;

            return Uniform;
        }
        public LifeGuards(int zone)
        {
            Zone = zone;
            RescueTime = 0;
            Victim = null;
            GuardStation = new Vector4();
            VicLocal = new Vector3();
            LGVeh = null;
            VicsVeh = null;

            Oufit = new ClothBank(Game.Player.Character);
            Uniform = UniformCheck(Oufit.Name);
        }
    }
}
