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
        private static int SeatRotata = 0;

        private static PositionDirect FindMe = null;

        private static readonly string FindVehFile = "" + Directory.GetCurrentDirectory() + "/FindVeh.txt";
        private static readonly string FindPedFile = "" + Directory.GetCurrentDirectory() + "/FindPed.txt";
        private static readonly string FindPropFile = "" + Directory.GetCurrentDirectory() + "/FindProp.txt";

        private static readonly string YourVehFile = "" + Directory.GetCurrentDirectory() + "/VehList.ini";
        private static readonly string YourPedFile = "" + Directory.GetCurrentDirectory() + "/PedList.ini";
        private static readonly string YourPropFile = "" + Directory.GetCurrentDirectory() + "/PropList.ini";

        public static FindVeh ExtCarz { get; set; }
        public static List<FindVeh> MakeCarz { get; set; }
        public static List<FindPed> MakeFrenz { get; set; }
        public static List<FindPed> StreetFrenz { get; set; }
        public static List<FindSeat> BackSeat { get; set; }

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
            "v_ilev_gb_vauldr",
            "hei_prop_heist_sec_door",
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
            "ch_prop_ch_gendoor_01",
            "prop_id2_11_gdoor",
            "v_ilev_carmod3door",
            "prop_com_ls_door_01"
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
        private static readonly List<string> ssDumpsters = new List<string>
        {
            "prop_dumpster_01a",
            "prop_dumpster_02b",
            "prop_boxpile_02d",
            "prop_rub_boxpile_04",
            "prop_rub_boxpile_06",
            "prop_rub_boxpile_08",
            "prop_rub_cardpile_01",
            "prop_rub_cardpile_03",
            "prop_bin_07b"
        };

        public SearchFor()
        {
            ExtCarz = null;
            MakeCarz = new List<FindVeh>();
            MakeFrenz = new List<FindPed>();
            StreetFrenz = new List<FindPed>();
            BackSeat = new List<FindSeat>();

            if (File.Exists(YourVehFile))
                File.Delete(YourVehFile);
            if (File.Exists(YourPedFile))
                File.Delete(YourPedFile);
            if (File.Exists(YourPropFile))
                File.Delete(YourPropFile);

            Tick += OnTick;
            Interval = 3000;
        }
        public static int StoI(string s)
        {
            int intOut;
            if (int.TryParse(s, out intOut))
            {
                // Conversion succeeded, 'number' contains the integer value
            }
            else
            {
                intOut = 0;
            }
            return intOut;
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (ExtCarz != null)
                GoGetCars(ExtCarz, true);

            if (MakeCarz.Count > 0)
                GoGetCars(MakeCarz[0], false);
            
            if (MakeFrenz.Count > 0)
                GoGetFrenz(MakeFrenz[0]);

            if (StreetFrenz.Count > 0)
                GetStreetFrenz(StreetFrenz[0]);

            if (BackSeat.Count > 0)
                GetInVehFrenz(BackSeat[SeatRotata]);
            else if (SeatRotata != 0)
                SeatRotata = 0;
        }
        private static void VehRelpace(PositionDirect MyPos, FindVeh MyVeh)
        {
            LoggerLight.LogThis("SearchFor_VehRelpace");
            EntityBuild.VehicleSpawn(MyVeh.VehModel, MyPos.Pos, MyPos.Dir);
        }
        private static void PedRelpace(PositionDirect MyPos, FindPed MyPeds)
        {
            LoggerLight.LogThis("SearchFor_PedRelpace");
            EntityBuild.NPCSpawn(MyPeds.ThisFeat, MyPos.Pos, MyPos.Dir);
        }
        private static void GoGetCars(FindVeh ThisFind, bool ext)
        {
            if (FindMe == null)
            {
                FindMe = GetVehPos(ThisFind, DataStore.OnCayoLand);
            }
            else
            {
                VehRelpace(FindMe, ThisFind);
                if (ext)
                    ExtCarz = null;
                else
                {
                    if (MakeCarz.Count > 0)
                        MakeCarz.RemoveAt(0);
                }

                FindMe = null;

            }
        }
        private static void GoGetFrenz(FindPed ThisFind)
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
        private static void GetStreetFrenz(FindPed ThisFind)
        {
            Vector3 vArea = Game.Player.Character.Position;
            List<Ped> MadPeds = GetLocalPeds(vArea, ThisFind.MaxRadi);

            for (int i = 0; i < MadPeds.Count; i++)
            {
                try
                {
                    if (ThisFind.Count > 0)
                    {
                        Ped MadP = MadPeds[i];
                        if (MadP.Exists())
                        {
                            if (!MadP.IsOnScreen && !MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP.Handle) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent && MadP.Position.DistanceTo(vArea) > ThisFind.MinRadi)
                            {
                                MadP.IsPersistent = true;
                                EntityBuild.NpcTasks(MadP, ThisFind.ThisFeat.Task);
                                MissionData.PedList_01.Add(new Ped(MadP.Handle));
                                ThisFind.Count--;
                            }
                        }
                    }
                    else
                        break;
                }
                catch
                {
                    LoggerLight.LogThis("GetStreetFrenz, LostPed");
                }
            }

            if (ThisFind.Count > 0 && !ThisFind.OnePass)
                StreetFrenz.Add(ThisFind);
        }
        private static void GetInVehFrenz(FindSeat ThisFind)
        {
            if (ThisFind.Stage == 1) 
            {
                EntityBuild.EnterAnyVeh(ThisFind.CarSeat, ThisFind.ThisPed, ThisFind.Seat, ThisFind.Run);
                ThisFind.Stage++;
                SeatRotata++;
                if (SeatRotata < BackSeat.Count)
                { }
                else
                    SeatRotata = 0;
            }
            else if (ThisFind.Stage == 2)
            {
                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, ThisFind.ThisPed.Handle, 160))
                {
                    EntityBuild.WarptoAnyVeh(ThisFind.CarSeat, ThisFind.ThisPed, ThisFind.Seat);
                    ThisFind.Stage++;
                }

                SeatRotata++;
                if (SeatRotata < BackSeat.Count)
                { }
                else
                    SeatRotata = 0;
            }
            else if (ThisFind.Stage == 3)
            {
                if (ThisFind.ThisPed.IsInVehicle())
                {
                    ThisFind.ThisPed.BlockPermanentEvents = false;
                    ThisFind.ThisPed.AlwaysKeepTask = false;
                    BackSeat.RemoveAt(SeatRotata);
                }

                SeatRotata++;
                if (SeatRotata < BackSeat.Count)
                { }
                else
                    SeatRotata = 0;
            }
        }
        private static PositionDirect GetVehPos(FindVeh myFind, bool bCayo)
        {
            PositionDirect MyPosDir = null;
            /*
            float fDist = 100000.0f;
            int iFound = 0;
            for (int i = 0; i < MissionData.VhPoint.Count; i++)
            {
                if (MissionData.VhPoint[i].V3.DistanceTo(myFind.Area) < fDist)
                {
                    fDist = MissionData.VhPoint[i].V3.DistanceTo(myFind.Area);
                    iFound = i;
                }
            }

            MyPosDir = new PositionDirect
            {
                Pos = MissionData.VhPoint[iFound].V3,
                Dir = MissionData.VhPoint[iFound].R
            };
            */

            if (bCayo)
            {
                float fDist = 100000.0f;
                int iFound = 0;
                for (int i = 0; i < MissionData.CayoVhPoint.Count; i++)
                {
                    if (MissionData.CayoVhPoint[i].V3.DistanceTo(myFind.Area) < fDist)
                    {
                        fDist = MissionData.CayoVhPoint[i].V3.DistanceTo(myFind.Area);
                        iFound = i;
                    }
                }

                MyPosDir = new PositionDirect
                {
                    Pos = MissionData.CayoVhPoint[iFound].V3,
                    Dir = MissionData.CayoVhPoint[iFound].R
                };
            }
            else
            {
                List<Vehicle> CarSpot = GetLocalVeh(myFind.Area, myFind.MaxRadi);

                if (myFind.Near)
                    CarSpot = ReturnStuff.FarToNear(CarSpot, myFind.Area);

                for (int i = 0; i < CarSpot.Count; i++)
                {
                    try
                    {
                        Vehicle Veh = CarSpot[i];
                        if (Veh.Exists())
                        {
                            if (myFind.Driver)
                            {
                                if (Veh.IsPersistent == false && Veh.Position.DistanceTo(myFind.Area) > myFind.MinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && Veh.EngineRunning)
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
                                if (Veh.IsPersistent == false && Veh.Position.DistanceTo(myFind.Area) > myFind.MinRadi && Veh.ClassType != VehicleClass.Boats && Veh.ClassType != VehicleClass.Cycles && Veh.ClassType != VehicleClass.Helicopters && Veh.ClassType != VehicleClass.Planes && Veh.ClassType != VehicleClass.Trains && Veh != Game.Player.Character.CurrentVehicle && !Veh.IsOnScreen && !Veh.EngineRunning)
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
            }
            return MyPosDir;
        }
        private static PositionDirect GetPedPos(float fMinRadi, float fMaxRadi)
        {
            /*

            PositionDirect MyPosDir = null;
            float fDist = 100000.0f;
            int iFound = 0;
            for (int i = 0; i < MissionData.SpPoint.Count; i++)
            {
                if (MissionData.SpPoint[i].V3.DistanceTo(vArea) < fDist && MissionData.SpPoint[i].V3.DistanceTo(vArea) > fMinRadi)
                {
                    fDist = MissionData.SpPoint[i].V3.DistanceTo(vArea);
                    iFound = i; 
                }
            }

            MyPosDir = new PositionDirect
            {
                Pos = MissionData.SpPoint[iFound].V3,
                Dir = MissionData.SpPoint[iFound].R
            };
            */
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
            //Prop[] StreetPhone = World.GetNearbyProps(Vpos, fDist);

            List<Prop> propList = GetAllProps(Vpos, fDist);
            List<Prop> propListout = new List<Prop>();

            for (int i = 0; i < propList.Count; i++)
            {
                if (propList[i].Exists())
                {
                    for (int j = 0; j < sObjets.Count; j++)
                    {
                        if (propList[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sObjets[j]))
                            propListout.Add(propList[i]);
                    }
                }
            }

            return propListout;
        }
        public static List<Prop> GetAllProps(Vector3 Vpos, float fDist)
        {
            Vpos = Game.Player.Character.Position;
            List<Prop> propList = new List<Prop>();
            EntityLog.CreateIni(FindPropFile, new List<string> { "blank" });
            int fiveSec = Game.GameTime + 5000;
            while (!File.Exists(YourPropFile))
            {
                if (fiveSec < Game.GameTime)
                    break;
                Script.Wait(500);
            }
            if (File.Exists(YourPropFile))
            {
                List<string> output = EntityLog.FileOutPut(YourPropFile);
                for (int i = 0; i < output.Count; i++)
                {
                    Prop obj = new Prop(StoI(output[i]));
                    if (obj.Exists())
                    {
                        if (obj.Position.DistanceTo(Vpos) < fDist)
                            propList.Add(obj);
                    }
                }
                File.Delete(YourPropFile);
            }
            LoggerLight.LogThis("propList.size() == "  + propList.Count);

            return propList;
        }
        public static List<Ped> GetLocalPeds(Vector3 Vpos, float fDist)
        {
            Vpos = Game.Player.Character.Position;
            List<Ped> pedList = new List<Ped>();
            EntityLog.CreateIni(FindPedFile, new List<string> { "blank" });
            int fiveSec = Game.GameTime + 5000;
            while (!File.Exists(YourPedFile))
            {
                if (fiveSec < Game.GameTime)
                    break;
                Script.Wait(500);
            }
            if (File.Exists(YourPedFile))
            {
                List<string> output = EntityLog.FileOutPut(YourPedFile);
                for (int i = 0; i < output.Count; i++)
                {
                    Ped obj = new Ped(StoI(output[i]));
                    if (obj.Exists())
                    {
                        if (obj.Position.DistanceTo(Vpos) < fDist)
                            pedList.Add(obj);
                    }
                }

                File.Delete(YourPedFile);
            }
            LoggerLight.LogThis("pedList.size() == " + pedList.Count);

            return pedList;
        }
        public static List<Entity> GetLocalEntity(Vector3 Vpos, float fDist)
        {
            List<Entity> entList = new List<Entity>();
            Entity[] entFind = World.GetNearbyEntities(Vpos, fDist);
            for (int i = 0; i < entFind.Count(); i++)
                entList.Add(entFind[i]);

            return entList;
        }
        public static List<Vehicle> GetLocalVeh(Vector3 Vpos, float fDist)
        {
            Vpos = Game.Player.Character.Position;
            List<Vehicle> vehList = new List<Vehicle>();
            EntityLog.CreateIni(FindVehFile, new List<string> { "blank" });
            int fiveSec = Game.GameTime + 5000;
            while (!File.Exists(YourVehFile))
            {
                if (fiveSec < Game.GameTime)
                    break;
                Script.Wait(500);
            }
            if (File.Exists(YourVehFile))
            {
                List<string> output = EntityLog.FileOutPut(YourVehFile);
                for (int i = 0; i < output.Count; i++)
                {
                    Vehicle obj = new Vehicle(StoI(output[i]));
                    if (obj.Exists())
                    {
                        if (obj.Position.DistanceTo(Vpos) < fDist)
                            vehList.Add(obj);
                    }
                }

                File.Delete(YourVehFile);
            }
            LoggerLight.LogThis("vehList.size() == " + vehList.Count);

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
                            if (!ReturnStuff.AreUNear(phone.Position, DataStore.vOldPhoneBoxList[ii], 3f) && phone.Health > 990)
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
                        if (thisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, "v_ilev_gb_vauldr"))
                            thisDoor.Delete();
                        else if (thisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, "hei_prop_heist_sec_door"))
                            thisDoor.Delete();
                        else
                        {
                            Function.Call(Hash.FREEZE_ENTITY_POSITION, thisDoor, false);                          
                            Function.Call(Hash.SET_STATE_OF_CLOSEST_DOOR_OF_TYPE, thisDoor.Model.Hash, thisDoor.Position.X, thisDoor.Position.Y, thisDoor.Position.Z, false, 0, 1);
                        }
                    }
                }
                catch
                {
                    LoggerLight.LogThis("OpenDoors  fail");
                }
            }
        }
        public static void OpenDoors(Vector4 VDoorPos, float fRadius)
        {
            LoggerLight.LogThis("OpenDoors");

            OpenDoors(VDoorPos.V3, fRadius);
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
                        Function.Call(Hash.FREEZE_ENTITY_POSITION, thisDoor, true);
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
        public static void SlowFastTravel(Vector3 VDest, float fHedd)
        {
            LoggerLight.LogThis("SlowFastTravel");

            Game.Player.Character.IsInvincible = true;
            Game.FadeScreenOut(500);
            Script.Wait(500);
            Function.Call(Hash.FREEZE_ENTITY_POSITION, Game.Player.Character, true);
            Game.Player.Character.Position = VDest;
            Game.Player.Character.Heading = fHedd;
            Script.Wait(1000);
            Function.Call(Hash.FREEZE_ENTITY_POSITION, Game.Player.Character, false);
            Game.FadeScreenIn(1000);
            Script.Wait(2000);
            Game.Player.Character.IsInvincible = false;
        }
        public static void SlowFastTravel(Vector4 VDest)
        {
            LoggerLight.LogThis("SlowFastTravelV4");
            SlowFastTravel(VDest.V3, VDest.R);
        }
        public static void SlowFastVehicleTravel(Vector3 VDest, float fHedd)
        {
            LoggerLight.LogThis("SlowFastTravel");
            if (Game.Player.Character.IsInVehicle())
            {
                if (fHedd == 0.00f)
                    fHedd = (int)RandomX.RandInt(0, 360);
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                Game.Player.Character.CurrentVehicle.Position = VDest;
                Game.Player.Character.CurrentVehicle.Heading = fHedd;
                Script.Wait(2000);
                Game.FadeScreenIn(1000);
            }
            else
            {
                if (fHedd == 0.00f)
                    fHedd = (int)RandomX.RandInt(0, 360);
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                Game.Player.Character.Position = VDest;
                Game.Player.Character.Heading = fHedd;
                Script.Wait(2000);
                Game.FadeScreenIn(1000);
            }
        }
        public static void SlowFastVehicleTravel(Vector4 VDest)
        {
            LoggerLight.LogThis("SlowFastTravelV4");
            SlowFastVehicleTravel(VDest.V3, VDest.R);
        }
        public static void ClubQUe(int lod)
        {
            Script.Wait(1000);

            List<Vector4> ClubQue = new List<Vector4>();

            if (lod == 300)
            {

            }//LSIA Nightclub
            else if (lod == 301)
            {

            }//Elysian Island Nightclub
            else if (lod == 302)
            {

            }//Cypress Flats Nightclub
            else if (lod == 303)
            {

            }//La Mesa Nightclub
            else if (lod == 304)
            {

            }//Stawberry Nightclub
            else if (lod == 305)
            {
                ClubQue.Add(new Vector4(345.7501f, -977.9116f, 28.37905f, 270.4436f));
                ClubQue.Add(new Vector4(345.9431f, -982.3931f, 28.36338f, 3.461613f));
                ClubQue.Add(new Vector4(345.8682f, -980.9756f, 28.36891f, 3.167192f));
                ClubQue.Add(new Vector4(345.8458f, -979.6537f, 28.37225f, 7.168578f));
                ClubQue.Add(new Vector4(345.897f, -976.9437f, 28.38092f, 234.9466f));
            }//Mission Row Nightclub
            else if (lod == 306)
            {
                ClubQue.Add(new Vector4(371.4525f, 253.1166f, 102.0098f, 341.0112f));
                ClubQue.Add(new Vector4(378.521f, 250.5499f, 102.0096f, 71.15887f));
                ClubQue.Add(new Vector4(376.7061f, 251.1696f, 102.0096f, 69.54118f));
                ClubQue.Add(new Vector4(374.183f, 252.1099f, 102.0096f, 69.55529f));
                ClubQue.Add(new Vector4(370.2097f, 253.97f, 102.0096f, 282.6834f));
            }//Downtown Vinewood Nightclub
            else if (lod == 307)
            {
                ClubQue.Add(new Vector4(4.677205f, 220.2921f, 106.7159f, 240.0815f));
                ClubQue.Add(new Vector4(7.061273f, 225.475f, 107.4876f, 138.3406f));
                ClubQue.Add(new Vector4(6.504213f, 224.0539f, 107.2854f, 157.16f));
                ClubQue.Add(new Vector4(6.1691f, 222.7032f, 107.0936f, 137.9715f));
                ClubQue.Add(new Vector4(5.043196f, 218.9231f, 106.5565f, 272.9461f));
            }//West Vinewood Nightclub
            else if (lod == 308)
            {
                ClubQue.Add(new Vector4(-1174.457f, -1153.458f, 4.658165f, 278.3068f));
                ClubQue.Add(new Vector4(-1175.295f, -1148.321f, 4.668828f, 186.327f));
                ClubQue.Add(new Vector4(-1175.162f, -1149.529f, 4.666319f, 186.2316f));
                ClubQue.Add(new Vector4(-1174.859f, -1151.743f, 4.661713f, 186.4143f));
                ClubQue.Add(new Vector4(-1171.938f, -1153.139f, 4.657416f, 18.46338f));
            }//Vespucci Canals Nightclub
            else if (lod == 309)
            {
                ClubQue.Add(new Vector4(-1285.273f, -652.0281f, 25.62972f, 38.44094f));
                ClubQue.Add(new Vector4(-1277.746f, -644.5825f, 25.73287f, 131.9127f));
                ClubQue.Add(new Vector4(-1279.317f, -645.4908f, 25.70546f, 119.8866f));
                ClubQue.Add(new Vector4(-1281.751f, -647.4449f, 25.65853f, 123.1041f));
                ClubQue.Add(new Vector4(-1287.868f, -651.7767f, 25.56246f, 359.7041f));
            }//Del Perro Nightclub
            
            List<Prop> MyProps = GetLocalProps(ClubQue[0].V3, 10.00f, ssDumpsters);

            for (int i = 0; i < MyProps.Count; i++)
            {
                try
                {
                    Prop ThisTrash = MyProps[i];
                    if (ThisTrash.Exists())
                    {
                        ThisTrash.Delete();
                        break;
                    }
                }
                catch
                {
                    LoggerLight.LogThis("TempAgency_02_ClubQUe, catch");
                }
            }
            for (int i = 1; i < ClubQue.Count - 1; i++)
                EntityBuild.NPCSpawn(new PedFeat(ReturnStuff.RandNPC(37)), ClubQue[i]);

            EntityBuild.NPCSpawn(new PedFeat("s_m_m_bouncer_01"), ClubQue[ClubQue.Count - 1]);
        }
    }
}
