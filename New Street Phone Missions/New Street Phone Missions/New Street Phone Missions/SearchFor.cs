using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.IO;
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
        public static bool bFindPropz = false;

        private static PositionDirect FindMe = null;

        public static List<FindVeh> MakeCarz { get; set; }
        public static List<FindPed> MakeFrenz { get; set; }
        public static List<FindVeh> ComCarz { get; set; }

        private static readonly List<string> ssPhoneType = new List<string>
        {
            "p_phonebox_02_s",
            "prop_phonebox_04",
            "prop_phonebox_03",
            "prop_phonebox_02",
            "prop_phonebox_01c",
            "prop_phonebox_01b",
            "prop_phonebox_01a",
            "p_phonebox_01b_s"
        };
        private static readonly List<string> ssDoorList = new List<string>
        {
            "prop_ld_bankdoors_02",
            "v_ilev_247door",
            "v_ilev_247door_r",
            "v_ilev_bank4door01",
            "v_ilev_bank4door02",
            "v_ilev_bl_doorsl_l",
            "v_ilev_bl_doorsl_r",
            "v_ilev_bs_door",
            "v_ilev_ch_glassdoor",
            "v_ilev_clothmiddoor",
            "v_ilev_cor_darkdoor",
            "v_ilev_cor_darkdoor",
            "v_ilev_cor_doorglassa",
            "v_ilev_cor_doorglassb",
            "v_ilev_cs_door01",
            "v_ilev_cs_door01_r",
            "v_ilev_csr_door_l",
            "v_ilev_csr_door_r",
            "v_ilev_csr_door_r",
            "v_ilev_gasdoor",
            "v_ilev_gasdoor_r",
            "v_ilev_gc_door03",
            "v_ilev_gc_door04",
            "v_ilev_genbankdoor1",
            "v_ilev_genbankdoor2",
            "v_ilev_hd_door_l",
            "v_ilev_hd_door_r",
            "v_ilev_ml_door1",
            "v_ilev_ph_door002",
            "v_ilev_ph_door01",
            "v_ilev_po_door",
            "v_ilev_ra_door1_l",
            "v_ilev_ra_door1_r",
            "v_ilev_stad_fdoor",
            "v_ilev_ta_door",
            "v_ilev_ss_door5_r",
            "v_corp_hicksdoor",
            "prop_strip_door_01",
            "hei_v_ilev_bk_gate_pris",
            "h4_prop_h4_gate_l_03a",
            "h4_prop_h4_gate_r_03a",
            "prop_strip_door_01",
            "sm_14_mp_door_l",
            "prop_map_door_01",
            "prop_sm1_11_doorl",
            "prop_control_rm_door_01",
            "xm_prop_cannon_room_door_02",
            "xm_prop_facility_door_01",
            "apa_p_mp_door_01",
            "apa_p_mp_door_02",
            "apa_p_mp_door_03",
            "apa_p_mp_door_04",
            "apa_p_mp_door_06",
            "apa_p_mp_door_07",
            "apa_p_mp_door_apart_door",
            "apa_p_mp_door_apart_door_black",
            "apa_p_mp_door_apartfrt_door",
            "apa_p_mp_door_apartfrt_door_black",
            "apa_p_mp_door_mpa",
            "apa_p_mp_door_mpa2_frnt",
            "apa_p_mp_door_stilt_door",
            "apa_p_mp_door_stilt_doorfrnt",
            "apa_p_mp_h_showerdoor_s",
            "bkr_prop_biker_door_entry",
            "ex_p_mp_door_apart_door",
            "ex_p_mp_door_apart_door_black",
            "ex_p_mp_door_apart_door_black_s",
            "ex_p_mp_door_apart_door_s",
            "ex_p_mp_door_apart_doorbrown01",
            "ex_p_mp_door_apart_doorbrown_s",
            "ex_p_mp_door_apart_doorwhite01",
            "ex_p_mp_door_apart_doorwhite01_s",
            "prop_magenta_door",
            "prop_sc1_12_door",
            "v_ilev_deviantfrontdoor",
            "ch_prop_casino_door_01a",
            "ch_prop_ch_service_door_02c",
            "ch_prop_ch_service_door_02b",
            "ch_prop_ch_service_door_02a",
            "ch_prop_casino_door_01b",
            "ch_prop_casino_door_01c",
            "ch_prop_ch_gendoor_01"
        };
        private static readonly List<string> ssGateList = new List<string>
        {
            "prop_gate_prison_01",
            "prop_gate_docks_ld",
            "prop_facgate_01",
            "prop_facgate_01b",
            "prop_fnclink_06gate2",
            "prop_facgate_04_l",
            "prop_facgate_04_r"
        };

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
            {
                GoGetComs(ComCarz[0]);
            }
            
            if (MakeCarz.Count > 0 && !bFindCarz)
            {
                GoGetCars(MakeCarz[0]);
            }
            
            if (MakeFrenz.Count > 0 && !bFindPedz)
            {
                GoGetFrenz(MakeFrenz[0]);
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
            LoggerLight.LogThis("SearchFor_SearchPed sPed == " + sPed);
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
                NameIs = sName               
            };
            MakeFrenz.Add(MyFinda);
        }
        public static void UseAmbPed(Vector3 vZone, float fMax, int iCountEm, int iTask, string sName)
        {
            LoggerLight.LogThis("UseAmbPed, fMax == " + fMax + ", iCountEm == " + iCountEm + ", iTask == " + iTask + ", sName == " + sName);
            MissionData.iFindingTime = Game.GameTime + 1000;
            List<Ped> MadPeds = GetLocalPeds(vZone, fMax);

            if (iCountEm == -1)
                iCountEm = MadPeds.Count;

            for (int i = 0; i < MadPeds.Count; i++)
            {
                try
                {
                    Ped MadP = MadPeds[i];
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
                            iCountEm --;
                        }
                    }

                    if (iCountEm < 1)
                        break;
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
        private static void GoGetComs(FindVeh ThisFind)
        {
            if (FindMe == null)
            {
                FindMe = GetExtVehPos(ThisFind.MinRadi, ThisFind.MaxRadi);
            }
            else
            {
                ThisFind.VehTrack = 10;
                VehRelpace(FindMe, ThisFind);
                if (ComCarz.Count > 0)
                    ComCarz.RemoveAt(0);
                FindMe = null;
            }
        }
        private static void GoGetCars(FindVeh ThisFind)
        {
            if (FindMe == null)
            {
                FindMe = GetVehPos(ThisFind.MinRadi, ThisFind.MaxRadi, ThisFind.Driver);
            }
            else
            {
                VehRelpace(FindMe, ThisFind);
                if (MakeCarz.Count > 0)
                    MakeCarz.RemoveAt(0);
                FindMe = null;

            }
        }
        private static void GoGetFrenz(FindPed ThisFind)
        {
            if (bMissingPed)
            {
                UseAmbPed(Game.Player.Character.Position, ThisFind.MaxRadi, ThisFind.Free, ThisFind.Task, ThisFind.NameIs);
                if (MakeFrenz.Count > 0)
                    MakeFrenz.RemoveAt(0);
                bMissingPed = false;
            }
            else
            {
                if (FindMe == null)
                {
                    FindMe = GetPedPos(ThisFind.MinRadi, ThisFind.MaxRadi);
                }
                else
                {
                    PedRelpace(FindMe, ThisFind);
                    if (MakeFrenz.Count > 0)
                        MakeFrenz.RemoveAt(0);
                    FindMe = null;
                }
            }
        }
        private static PositionDirect GetExtVehPos(float fMinRadi, float fMaxRadi)
        {
            Vector3 vArea = Game.Player.Character.Position;
            PositionDirect MyPosDir = null;
            List<Vehicle> CarSpot = GetLocalVeh(vArea, fMaxRadi);

            if (ComCarz[0].VehTrack == 11)
            {
                for (int i = 0; i < CarSpot.Count; i++)
                {
                    try
                    {
                        Vehicle Veh = CarSpot[i];
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

                for (int i = 0; i < CarSpot.Count; i++)
                {
                    try
                    {
                        Vehicle Veh = CarSpot[i];
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

                for (int i = 0; i < dist.Count; i++)
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
            List<Vehicle> CarSpot = GetLocalVeh(vArea, fMaxRadi);

            for (int i = 0; i < CarSpot.Count; i++)
            {
                try
                {
                    Vehicle Veh = CarSpot[i];
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
            List<Ped> MadPeds = GetLocalPeds(vArea, fMaxRadi);

            for (int i = 0; i < MadPeds.Count; i++)
            {
                try
                {
                    Ped MadP = MadPeds[i];
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
        public static List<Prop> GetLocalProps(Vector3 Vpos, float fDist, List<string> sObjets)
        {
            List<Prop> propList = new List<Prop>();
            Prop[] StreetPhone = World.GetNearbyProps(Vpos, fDist);
            for (int i = 0; i < StreetPhone.Count(); i++)
            {
                for (int ii = 0; ii < sObjets.Count; ii++)
                {
                    if (StreetPhone[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sObjets[ii]))
                        propList.Add(new Prop(StreetPhone[i].Handle));
                }
            }

            return propList;
        }
        public static List<Prop> GetAllProps(Vector3 Vpos, float fDist)
        {
            List<Prop> propList = new List<Prop>();
            Prop[] StreetPhone = World.GetNearbyProps(Vpos, fDist);
            for (int i = 0; i < StreetPhone.Count(); i++)
            {
                propList.Add(new Prop(StreetPhone[i].Handle));
            }

            return propList;
        }
        public static List<Ped> GetLocalPeds(Vector3 Vpos, float fDist)
        {
            List<Ped> pedList = new List<Ped>();
            Ped[] pedFind = World.GetNearbyPeds(Vpos, fDist);
            for (int i = 0; i < pedFind.Count(); i++)
                pedList.Add(new Ped(pedFind[i].Handle));
            //foreach (Ped ped in pedFind)
            //    pedList.Add(new Ped(ped.Handle));

            return pedList;
        }
        public static List<Vehicle> GetLocalVeh(Vector3 Vpos, float fDist)
        {
            List<Vehicle> vehList = new List<Vehicle>();
            Vehicle[] vehFind = World.GetNearbyVehicles(Vpos, fDist);
            for (int i = 0; i < vehFind.Count(); i++)
                vehList.Add(new Vehicle(vehFind[i].Handle));
            //foreach (Vehicle veh in vehFind)
            //    vehList.Add(new Vehicle(veh.Handle));

            return vehList;
        }
        public static Prop BoxingClever()
        {
            Prop thisPhone = null;
            List<Prop> StreetPhone = GetLocalProps(Game.Player.Character.Position, 25.00f, ssPhoneType);
            for (int i = 0; i < StreetPhone.Count; i++)
            {
                try
                {
                    Prop phone = StreetPhone[i];
                    if (phone.Exists())
                    {
                        for (int ii = 0; ii < DataStore.vOldPhoneBoxList.Count; ii++)
                        {
                            if (!TheMissions.AreUNear(phone.Position, DataStore.vOldPhoneBoxList[ii], 3f) && phone.Health > 990)
                            {
                                phone.IsPersistent = true;
                                thisPhone = phone;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    LoggerLight.LogThis("BoxingClever lost a phonebox");
                }
            }
            return thisPhone;
        }
        public static Prop OpenThatGate(Vector3 VGatePos, float fRadius)
        {
            LoggerLight.LogThis("GateIsNear");

            List<Prop> MyProps = GetLocalProps(VGatePos, fRadius, ssGateList);
            Prop pGate = null;
            float fDist = fRadius + 5f;

            for (int i = 0; i < MyProps.Count; i++)
            {
                try
                {
                    Prop thisDoor = MyProps[i];
                    if (thisDoor.Exists())
                    {
                        if (thisDoor.Position.DistanceTo(VGatePos) < fDist)
                        {
                            fDist = thisDoor.Position.DistanceTo(VGatePos);
                            pGate = thisDoor;
                        }
                    }
                }
                catch
                {
                    LoggerLight.LogThis("GateIsNear, dataloss");
                }
            }

            return pGate;
        }
        public static void OpenDoors(Vector3 VDoorPos, float fRadius)
        {
            LoggerLight.LogThis("OpenDoors");

            List<Prop> openD = GetLocalProps(VDoorPos, fRadius, ssDoorList);

            for (int i = 0; i < openD.Count; i++)
            {
                try
                {
                    Prop thisDoor = openD[i];
                    if (thisDoor.Exists())
                    {
                        thisDoor.FreezePosition = false;
                        Function.Call(Hash.SET_STATE_OF_CLOSEST_DOOR_OF_TYPE, thisDoor.Model.Hash, thisDoor.Position.X, thisDoor.Position.Y, thisDoor.Position.Z, false, 0, 1);
                    }
                }
                catch
                {
                    LoggerLight.LogThis("OpenDoors  fail");
                }

            }
        }
        public static void ShutDoors(Vector3 VDoorPos, float fRadius)
        {
            LoggerLight.LogThis("ShutDoors");

            List<Prop> openD = GetLocalProps(VDoorPos, fRadius, ssDoorList);

            for (int i = 0; i < openD.Count; i++)
            {
                try
                {
                    Prop thisDoor = openD[i];
                    if (thisDoor.Exists())
                        thisDoor.FreezePosition = true;
                }
                catch
                {
                    LoggerLight.LogThis("OpenDoors  fail");
                }
            }
        }
        public static void RemoveDoors(Vector3 VDoorPos, float fRadius)
        {
            LoggerLight.LogThis("RemoveDoors");

            List<Prop> openD = GetLocalProps(VDoorPos, fRadius, ssDoorList);

            for (int i = 0; i < openD.Count; i++)
            {
                try
                {
                    Prop thisDoor = openD[i];
                    if (thisDoor.Exists())
                        thisDoor.Delete();
                }
                catch
                {
                    LoggerLight.LogThis("OpenDoors  fail");
                }
            }
        }
    }
}
