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

        public static bool bFindCCarz = false;
        public static bool bFindCarz = false;
        public static bool bFindPedz = false;

        private static PositionDirect FindMe = null;

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
            if (ComCarz.Count > 0 && !bFindCCarz)
            {
                bFindCCarz = true;
                GoGetStuff(1, ComCarz[0]);
            }
            else if (MakeCarz.Count > 0 && !bFindCarz)
            {
                bFindCarz = true;
                GoGetStuff(2, MakeCarz[0]);
            }
            else if (MakeFrenz.Count > 0 && !bFindPedz)
            {
                bFindPedz = true;
                GoGetStuff(MakeFrenz[0]);
            }
        }
        private static void VehRelpace(PositionDirect MyPos, FindVeh MyVeh)
        {
            LoggerLight.LogThis("SearchFor_VehRelpace");
            ObjectBuild.VehicleSpawn(MyVeh.VehModel, MyPos.Pos, MyPos.Dir, MyVeh.IsInvinc, MyVeh.Freeze, MyVeh.Routeto, MyVeh.Flasher, MyVeh.Mod, MyVeh.ExtraMod, MyVeh.BlipI, MyVeh.BlipS, MyVeh.VehTrack, MyVeh.ModShop);
        }
        public static void SearchVeh(float fMin, float fMax, string sVehModel, bool bIsInvinc, bool bFreeze, bool bRouteto, bool bFlasher, int iMod, int iExtraMod, int iBlip, string sBlip, int iVehTrack, bool bModShop, bool bDriver)
        {
            LoggerLight.LogThis("SearchFor_SearchVeh sVehModel == " + sVehModel);
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
        private static void PedRelpace(PositionDirect MyPos, FindPed MyPeds)
        {
            LoggerLight.LogThis("SearchFor_PedRelpace");
            ObjectBuild.NPCSpawn(MyPeds.PedIs, MyPos.Pos, MyPos.Dir, MyPeds.Armor, MyPeds.Heal, MyPeds.Task, 0, null, MyPeds.Gun, MyPeds.BlipIs, MyPeds.BlipCol, MyPeds.Free, MyPeds.NameIs);
        }
        public static void SearchPed(float fMin, float fMax, string sPed, bool bArmor, int iHeal, int iTask, int iSeat, Vehicle vMyCar, int iGun, bool bBlip, int iBlipCol, int iFree, string sName)
        {
            LoggerLight.LogThis("SearchFor_SearchVeh sPed == " + sPed);
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
            List<Ped> MyPeds = new List<Ped>();

            for (int i = 0; i < MadPeds.Count(); i++)
                MyPeds.Add(new Ped(MadPeds[i].Handle));

            if (iCountEm == -1)
                iCountEm = MyPeds.Count;

            for (int i = 0; i < MyPeds.Count; i++)
            {
                try
                {
                    Ped MadP = MyPeds[i];
                    if (MadP.Exists())
                    {
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
                                MadP.Task.ClearAll();
                                MadP.Task.ReactAndFlee(Game.Player.Character);
                                MadP.AlwaysKeepTask = true;
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
                                TheMissions.BbBomb_BombAtractor(MadP);
                                MissionData.PedList_01.Add(new Ped(MadP.Handle));
                            }
                            iCountEm -= 1;
                        }

                    }
                }
                catch
                {
                    LoggerLight.LogThis("UseAmbPed, LostPed");
                }       
            }
           
            if (iCountEm > 0)
            {
                bMissingPed = true;
                SearchPed(0.1f, 95.00f, "", false, 1, iTask, 0, null, 1, false, 1, iCountEm, sName);
            }
        }
        private static void GoGetStuff(int iVehPed, FindVeh ThisFind)
        {
            if (iVehPed == 1)
            {
                if (FindMe == null)
                {
                    FindMe = GetExtVehPos(ThisFind.MinRadi, ThisFind.MaxRadi);
                    Script.Wait(1000);
                    GoGetStuff(iVehPed, ThisFind);
                }
                else
                {
                    ThisFind.VehTrack = 10;
                    VehRelpace(FindMe, ThisFind);
                    if (ComCarz.Count > 0)
                        ComCarz.RemoveAt(0);
                    bFindCCarz = false;
                    FindMe = null;
                }
            }
            else
            {
                if (FindMe == null)
                {
                    FindMe = GetVehPos(ThisFind.MinRadi, ThisFind.MaxRadi, ThisFind.Driver);
                    Script.Wait(1000);
                    GoGetStuff(iVehPed, ThisFind);
                }
                else
                {
                    VehRelpace(FindMe, ThisFind);
                    if (MakeCarz.Count > 0)
                        MakeCarz.RemoveAt(0);
                    bFindCarz = false;
                    FindMe = null;

                }
            }
        }
        private static void GoGetStuff(FindPed ThisFind)
        {
            if (bMissingPed)
            {
                UseAmbPed(Game.Player.Character.Position, ThisFind.MaxRadi, ThisFind.Free, ThisFind.Task, ThisFind.NameIs);
                if (MakeFrenz.Count > 0)
                    MakeFrenz.RemoveAt(0);
                bMissingPed = false;
                bFindPedz = false;
            }
            else
            {
                if (FindMe == null)
                {
                    FindMe = GetPedPos(ThisFind.MinRadi, ThisFind.MaxRadi);
                    Script.Wait(1000);
                    GoGetStuff(ThisFind);
                }
                else
                {
                    PedRelpace(FindMe, ThisFind);
                    if (MakeFrenz.Count > 0)
                        MakeFrenz.RemoveAt(0);
                    bFindPedz = false;
                    FindMe = null;
                }
            }
        }
        private static PositionDirect GetExtVehPos(float fMinRadi, float fMaxRadi)
        {
            Vector3 vArea = Game.Player.Character.Position;
            PositionDirect MyPosDir = null;
            Vehicle[] CarSpot = World.GetNearbyVehicles(vArea, fMaxRadi);
            List<Vehicle> CarSpotList = new List<Vehicle>();
            for (int i = 0; i < CarSpot.Count(); i++)
                CarSpotList.Add(new Vehicle(CarSpot[i].Handle));
            
            if (ComCarz[0].VehTrack == 11)
            {
                for (int i = 0; i < CarSpotList.Count; i++)
                {
                    try
                    {
                        Vehicle Veh = CarSpotList[i];
                        if (Veh.Exists())
                        {
                            if (Veh.IsPersistent == false && Veh.Position.DistanceTo(vArea) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && Veh.EngineRunning)
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
                    catch
                    {
                        LoggerLight.LogThis("GetExtVehPos, LostVeh");
                    }
                }
            }
            else
            {
                List<PositionDirect> GetNear = new List<PositionDirect>();
                List<float> dist = new List<float>();

                for (int i = 0; i < CarSpotList.Count; i++)
                {
                    try
                    {
                        Vehicle Veh = CarSpotList[i];
                        if (Veh.Exists())
                        {
                            if (Veh.IsPersistent == false && Veh.Position.DistanceTo(vArea) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle)
                            {
                                dist.Add(Game.Player.Character.Position.DistanceTo(Veh.Position));
                                MyPosDir = new PositionDirect
                                {
                                    Pos = Veh.Position,
                                    Dir = Veh.Heading
                                };
                                GetNear.Add(MyPosDir);
                            }
                        }
                    }
                    catch
                    {
                        LoggerLight.LogThis("GetExtVehPos, LostVeh2");
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
                    MyPosDir = GetNear[iNear];
                }
            }

            return MyPosDir;
        }
        private static PositionDirect GetVehPos(float fMinRadi, float fMaxRadi, bool bDriver)
        {
            Vector3 vArea = Game.Player.Character.Position;
            PositionDirect MyPosDir = null;
            Vehicle[] CarSpot = World.GetNearbyVehicles(vArea, fMaxRadi);
            List<Vehicle> CarSpotList = new List<Vehicle>();
            for (int i = 0; i < CarSpot.Count(); i++)
                CarSpotList.Add(new Vehicle(CarSpot[i].Handle));

            for (int i = 0; i < CarSpotList.Count; i++)
            {
                try
                {
                    Vehicle Veh = CarSpotList[i];
                    if (Veh.Exists())
                    {
                        if (bDriver)
                        {
                            if (Veh.IsPersistent == false && Veh.Position.DistanceTo(vArea) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && Veh.EngineRunning)
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
                            if (Veh.IsPersistent == false && Veh.Position.DistanceTo(vArea) > fMinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && !Veh.EngineRunning)
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
                catch
                {
                    LoggerLight.LogThis("GetVehPos, LostVeh");
                }

            }
            
            return MyPosDir;
        }
        private static PositionDirect GetPedPos(float fMinRadi, float fMaxRadi)
        {
            Vector3 vArea = Game.Player.Character.Position;
            PositionDirect MyPosDir = null;
            Ped[] MadPeds = World.GetNearbyPeds(vArea, fMaxRadi);
            List<Ped> MyPeds = new List<Ped>();

            for (int i = 0; i < MadPeds.Count(); i++)
                MyPeds.Add(new Ped(MadPeds[i].Handle));
            
            for (int i = 0; i < MyPeds.Count; i++)
            {
                try
                {
                    Ped MadP = MyPeds[i];
                    if (MadP.Exists())
                    {

                        if (!MadP.IsOnScreen && !MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP.Handle) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent && MadP.Position.DistanceTo(vArea) > fMinRadi)
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
                catch 
                {
                    LoggerLight.LogThis("GetVehPos, LostVeh");
                }

            }

            return MyPosDir;
        }
    }
}
