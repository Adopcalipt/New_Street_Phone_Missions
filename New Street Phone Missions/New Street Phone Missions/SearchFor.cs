using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.Linq;


namespace New_Street_Phone_Missions
{

    public class SearchFor : Script
    {
        public static bool bMissingPed = false;

        public static PositionDirect FindMe = null;
        public static List<FindVeh> MakeCarz { get; set; }
        public static List<FindPed> MakeFrenz { get; set; }
        public static List<FindVeh> ComCarz { get; set; }

        public SearchFor()
        {
            MakeCarz = new List<FindVeh>();
            MakeFrenz = new List<FindPed>();
            ComCarz = new List<FindVeh>();

            Tick += OnTick;
            Interval = 1000;
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (ComCarz.Count > 0)
                GoGetStuff(1);
            else if (MakeCarz.Count > 0)
                GoGetStuff(2);
            else if (MakeFrenz.Count > 0)
                GoGetStuff(3);
        }
        public static void VehRelpace(PositionDirect MyPos, FindVeh MyVeh)
        {
            ObjectBuild.VehicleSpawn(MyVeh.VehModel, MyPos.Pos, MyPos.Dir, MyVeh.IsInvinc, MyVeh.Freeze, MyVeh.Routeto, MyVeh.Flasher, MyVeh.Mod, MyVeh.ExtraMod, MyVeh.BlipI, MyVeh.BlipS, MyVeh.VehTrack, MyVeh.ModShop);
        }
        public static void SearchVeh(float fMin, float fMax, string sVehModel, bool bIsInvinc, bool bFreeze, bool bRouteto, bool bFlasher, int iMod, int iExtraMod, int iBlip, string sBlip, int iVehTrack, bool bModShop, bool bDriver)
        {
            FindVeh MyFinda = new FindVeh
            {
                MinRadi = fMin,
                MaxRadi = fMax,
                VehModel = sVehModel,
                IsInvinc = bIsInvinc,
                Freeze = bFreeze,
                Routeto = bRouteto,
                Flasher = bFlasher,
                Mod = iMod,
                ExtraMod = iExtraMod,
                BlipI = iBlip,
                BlipS = sBlip,
                VehTrack = iVehTrack,
                ModShop = bModShop,
                Driver = bDriver
            };
            if (iVehTrack == 10 || iVehTrack == 11)
                ComCarz.Add(MyFinda);
            else
                MakeCarz.Add(MyFinda);
        }
        public static void PedRelpace(PositionDirect MyPos, FindPed MyPeds)
        {
            ObjectBuild.NPCSpawn(MyPeds.PedIs, MyPos.Pos, MyPos.Dir, MyPeds.Armor, MyPeds.Heal, MyPeds.Task, 0, null, MyPeds.Gun, MyPeds.BlipIs, MyPeds.BlipCol, MyPeds.Free, MyPeds.NameIs);
        }
        public static void SearchPed(float fMin, float fMax, string sPed, bool bArmor, int iHeal, int iTask, int iSeat, Vehicle vMyCar, int iGun, bool bBlip, int iBlipCol, int iFree, string sName)
        {
            FindPed MyFinda = new FindPed
            {
                MinRadi = fMin,
                MaxRadi = fMax,
                PedIs = sPed,
                Armor = bArmor,
                Heal = iHeal,
                Task = iTask,
                Gun = iGun,
                BlipIs = bBlip,
                BlipCol = iBlipCol,
                Free = iFree,
                NameIs = sName,
            };
            MakeFrenz.Add(MyFinda);
        }
        public static void UseAmbPed(Vector3 vZone, float fMax, int iCountEm, int iTask, string sName)
        {
            LoggerLight.LogThis("UseAmbPed, fMax == " + fMax + ", iCountEm == " + iCountEm + ", iTask == " + iTask + ", sName == " + sName);
            MissionData.iFindingTime = Game.GameTime + 1000;
            Ped[] MadPeds = World.GetNearbyPeds(vZone, fMax);
            if (iCountEm == -1)
                iCountEm = MadPeds.Count();
            for (int i = 0; i < MadPeds.Count(); i++)
            {
                if (ReturnStuff.PedExists(MadPeds, i) && iCountEm > 0)
                {
                    Ped MadP = MadPeds[i];
                    if (!MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP.Handle) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent)
                    {
                        if (iTask == 1)
                        {
                            MadP.IsPersistent = true;
                            MissionData.Npc_01 = MadP;
                            MadP.Task.ClearAllImmediately();
                            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, MadP.Handle, 0, true);
                            Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, MadP.Handle, true);
                            MissionData.PedList_01.Add(new Ped(MadP.Handle));
                        }
                        else if (iTask == 2)
                        {
                            MadP.Task.FleeFrom(Game.Player.Character);
                        }
                        else if (iTask == 3)
                        {
                            MadP.IsPersistent = true;
                            ObjectBuild.AttackThePlayer(MadP, true);
                            MissionData.PedList_01.Add(new Ped(MadP.Handle));
                            PedMultiTask MyMuilts = ObjectBuild.AddAMultiped();
                            MyMuilts.MyPed = MadP;
                            MissionData.MultiPed.Add(MyMuilts);
                        }
                        else if (iTask == 4)
                        {
                            MadP.IsPersistent = true;
                            ObjectBuild.BbBomb_BombAtractor(MadP);
                            MissionData.PedList_01.Add(new Ped(MadP.Handle));
                        }
                        iCountEm -= 1;
                    }
                }
                else
                    break;
            }
            if (iCountEm > 0)
            {
                bMissingPed = true;
                SearchPed(0.1f, 95.00f, "", false, 1, iTask, 0, null, 1, false, 1, iCountEm, sName);
            }
        }
        public static void GoGetStuff(int iVehPed)
        {
            if (iVehPed == 1)
            {
                if (FindMe == null)
                {
                    if (MissionData.iFindingTime < Game.GameTime)
                        FindMe = GetExtVehPos(ComCarz[0].MinRadi, ComCarz[0].MaxRadi);
                }
                else
                {
                    ComCarz[0].VehTrack = 10;
                    VehRelpace(FindMe, ComCarz[0]);
                    ComCarz.RemoveAt(0);
                    FindMe = null;
                }
            }
            else if (iVehPed == 2)
            {
                if (FindMe == null)
                {
                    if (MissionData.iFindingTime < Game.GameTime)
                        FindMe = GetVehPos(MakeCarz[0].MinRadi, MakeCarz[0].MaxRadi, MakeCarz[0].Driver);
                }
                else
                {
                    VehRelpace(FindMe, MakeCarz[0]);
                    MakeCarz.RemoveAt(0);
                    FindMe = null;
                }
            }
            else
            {
                if (bMissingPed)
                {
                    if (MissionData.iFindingTime < Game.GameTime)
                    {
                        UseAmbPed(Game.Player.Character.Position, MakeFrenz[0].MaxRadi, MakeFrenz[0].Free, MakeFrenz[0].Task, MakeFrenz[0].NameIs);
                        MakeFrenz.RemoveAt(0);
                        bMissingPed = false;
                    }
                }
                else
                {
                    if (FindMe == null)
                    {
                        if (MissionData.iFindingTime < Game.GameTime)
                            FindMe = GetPedPos(MakeFrenz[0].MinRadi, MakeFrenz[0].MaxRadi);
                    }
                    else
                    {
                        PedRelpace(FindMe, MakeFrenz[0]);
                        MakeFrenz.RemoveAt(0);
                        FindMe = null;
                    }
                }
            }
        }
        public static PositionDirect GetExtVehPos(float fMinRadi, float fMaxRadi)
        {
            MissionData.iFindingTime = Game.GameTime + 1000;
            Vector3 vArea = Game.Player.Character.Position;
            List<float> dist = new List<float>();
            List<Vehicle> driver = new List<Vehicle>();
            PositionDirect MyPosDir = null;
            Vehicle[] CarSpot = World.GetNearbyVehicles(vArea, fMaxRadi);

            if (ComCarz[0].VehTrack == 11)
            {
                for (int i = 0; i < CarSpot.Count(); i++)
                {
                    if (ReturnStuff.VehExists(CarSpot, i))
                    {
                        Vehicle Veh = CarSpot[i];

                        if (Veh.IsPersistent == false && Veh.Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && Veh.EngineRunning)
                        {
                            MyPosDir = new PositionDirect
                            {
                                Pos = Veh.Position,
                                Dir = Veh.Heading
                            };
                            Veh.Delete();
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < CarSpot.Count(); i++)
                {
                    if (ReturnStuff.VehExists(CarSpot, i))
                    {
                        Vehicle Veh = CarSpot[i];
                        if (Veh.IsPersistent == false && Veh.Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle)
                        {
                            dist.Add(Game.Player.Character.Position.DistanceTo(Veh.Position));
                            driver.Add(Veh);
                        }

                    }
                }
                int iNear = -1;
                float fDist = 999.99f;

                for (int i = 0; i < dist.Count(); i++)
                {
                    if (fDist > dist[i])
                    {
                        fDist = dist[i];
                        iNear = i;
                    }
                }
                if (iNear > -1)
                {
                    MyPosDir = new PositionDirect
                    {
                        Pos = driver[iNear].Position,
                        Dir = driver[iNear].Heading
                    };
                    driver[iNear].Delete();
                }
            }

            return MyPosDir;
        }
        public static PositionDirect GetVehPos(float fMinRadi, float fMaxRadi, bool bDriver)
        {
            MissionData.iFindingTime = Game.GameTime + 1000;
            Vector3 vArea = Game.Player.Character.Position;
            PositionDirect MyPosDir = null;
            Vehicle[] CarSpot = World.GetNearbyVehicles(vArea, fMaxRadi);
            for (int i = 0; i < CarSpot.Count(); i++)
            {
                if (ReturnStuff.VehExists(CarSpot, i))
                {
                    Vehicle Veh = CarSpot[i];
                    if (bDriver)
                    {
                        if (Veh.IsPersistent == false && Veh.Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && Veh.EngineRunning)
                        {
                            MyPosDir = new PositionDirect
                            {
                                Pos = Veh.Position,
                                Dir = Veh.Heading
                            };
                            Veh.Delete();
                            break;
                        }
                    }
                    else
                    {
                        if (Veh.IsPersistent == false && Veh.Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && !Veh.EngineRunning)
                        {
                            MyPosDir = new PositionDirect
                            {
                                Pos = Veh.Position,
                                Dir = Veh.Heading
                            };

                            Veh.Delete();
                            break;
                        }
                    }
                }
            }
            return MyPosDir;
        }
        public static PositionDirect GetPedPos(float fMinRadi, float fMaxRadi)
        {
            MissionData.iFindingTime = Game.GameTime + 1000;
            Vector3 vArea = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 15);
            PositionDirect MyPosDir = null;
            Ped[] MadPeds = World.GetNearbyPeds(vArea, fMaxRadi);
            for (int i = 0; i < MadPeds.Count(); i++)
            {
                if (ReturnStuff.PedExists(MadPeds, i))
                {
                    Ped MadP = MadPeds[i];

                    if (!MadP.IsOnScreen && !MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP.Handle) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent && MadP.Position.DistanceTo(Game.Player.Character.Position) > fMinRadi)
                    {
                        MyPosDir = new PositionDirect
                        {
                            Pos = MadP.Position,
                            Dir = MadP.Heading
                        };
                        MadP.Delete();
                        break;
                    }
                }
            }

            return MyPosDir;
        }
    }
}
