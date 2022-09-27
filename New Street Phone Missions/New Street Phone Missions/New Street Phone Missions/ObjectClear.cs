using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class ObjectClear
    {
        private static int iClearing = 0;

        public static void CleanCams()
        {
            LoggerLight.LogThis("CleanCams");

            if (MissionData.cCams != null)
            {
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 0, 1, 0, 0, 0);
                MissionData.cCams.Destroy();
                Function.Call(Hash.DISPLAY_RADAR, true);
                MissionData.cCams = null;
            }
        }
        public static void CleanTriggers()
        {
            LoggerLight.LogThis("CleanTriggers");

            for (int i = 0; i < MissionData.BeOff.Count; i++)
                MissionData.BeOff[i] = true;
        }
        public static void CleanMishlists()
        {
            LoggerLight.LogThis("CleanMishlists");

            MissionData.MyMissions.TruckersXM.Clear();
            MissionData.MyMissions.PackersXM.Clear();
            MissionData.MyMissions.ConsXM.Clear();
            MissionData.MyMissions.FubardXM.Clear();
            MissionData.MyMissions.AmbuXM.Clear();
            MissionData.MyMissions.SharksXM.Clear();
            MissionData.MyMissions.JohnsXM.Clear();
            MissionData.MyMissions.RaceXM.Clear();
            MissionData.MyMissions.BombXM.Clear();
            MissionData.MyMissions.HitXM.Clear();
        }
        public static void RemoveTargets()
        {
            LoggerLight.LogThis("RemoveTargets");

            if (MissionData.Target_01 != null)
            {
                ObjectLog.CleanUp(MissionData.Target_01);
                MissionData.Target_01 = null;
            }
            if (MissionData.Target_02 != null)
            {
                ObjectLog.CleanUp(MissionData.Target_02);
                MissionData.Target_02 = null;
            }
            if (MissionData.BackUpT != null)
            {
                ObjectLog.CleanUp(MissionData.BackUpT);
                MissionData.BackUpT = null;
            }

            for (int i = 0; i < MissionData.iCoronaList.Count; i++)
                ObjectLog.CleanUp(MissionData.iCoronaList[i], -1, -1);

            MissionData.iCoronaList.Clear();
        }
        public static void ClearOutAllStuff()
        {
            for (int i = 0; i < MissionData.iCoronaList.Count; i++)
                ObjectLog.CleanUp(MissionData.iCoronaList[i], -1, -1);

            for (int i = 0; i < MissionData.PedList_01.Count; i++)
                ObjectLog.CleanUp(MissionData.PedList_01[i], false);

            for (int i = 0; i < MissionData.PropList_01.Count; i++)
                ObjectLog.CleanUp(MissionData.PropList_01[i], false);

            for (int i = 0; i < MissionData.VehicleList_01.Count; i++)
                ObjectLog.CleanUp(MissionData.VehicleList_01[i], false);

            for (int i = 0; i < MissionData.BlipList_01.Count; i++)
                ObjectLog.CleanUp(MissionData.BlipList_01[i]);

            MissionData.iCoronaList.Clear();
            MissionData.PedList_01.Clear();
            MissionData.PropList_01.Clear();
            MissionData.VehicleList_01.Clear();
            MissionData.BlipList_01.Clear();
        }
        public static void CleanMultiPed(bool bJustBlip, bool bDelete)
        {
            LoggerLight.LogThis("CleanMultiPed");

            for (int i = 0; i < MissionData.MultiPed.Count; i++)
            {
                if (MissionData.MultiPed[i].MyBlip != null)
                    MissionData.MultiPed[i].MyBlip.Remove();

                if (!bJustBlip)
                {
                    if (MissionData.MultiPed[i].MyVehicle != null)
                    {
                        ObjectLog.CleanUp(MissionData.MultiPed[i].MyVehicle, false);
                        MissionData.VehicleList_01.Remove(MissionData.MultiPed[i].MyVehicle);
                    }
                    if (MissionData.MultiPed[i].MyPed != null)
                    {
                        if (MissionData.MultiPed[i].MyPed.Exists())
                        {
                            if (bDelete)
                                ObjectLog.CleanUp(MissionData.MultiPed[i].MyPed, true);
                            else
                            {
                                MissionData.MultiPed[i].MyPed.Task.ClearAll();
                                MissionData.MultiPed[i].MyPed.Task.FleeFrom(Game.Player.Character);
                                MissionData.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                            }
                        }
                        MissionData.PedList_01.Remove(MissionData.MultiPed[i].MyPed);
                    }
                }
            }
            MissionData.MultiPed.Clear();
        }
        public static void CleanPedBlips(int iPed)
        {
            LoggerLight.LogThis("CleanPedBlips");
            MissionData.iTracking = Game.GameTime + 1000;
            if (iPed == 1)
            {
                for (int i = 0; i < MissionData.PedList_01.Count; i++)
                {
                    if (MissionData.PedList_01[i].Exists())
                    {
                        if (MissionData.PedList_01[i].CurrentBlip.Exists())
                            MissionData.PedList_01[i].CurrentBlip.Remove();
                    }
                }
            }
            else
            {
                for (int i = 0; i < MissionData.MishPed.Count; i++)
                {
                    if (MissionData.MishPed[i].Exists())
                    {
                        if (MissionData.MishPed[i].CurrentBlip.Exists())
                            MissionData.MishPed[i].CurrentBlip.Remove();
                    }
                }
            }
        }
        public static void SimpleTracker()
        {
            MissionData.iTracking = Game.GameTime + 1000;

            for (int i = 0; i < MissionData.PedList_01.Count; i++)
            {
                if (MissionData.PedList_01[i].IsDead)
                {
                    if (MissionData.PedList_01[i].CurrentBlip.Exists())
                        MissionData.PedList_01[i].CurrentBlip.Remove();
                    MissionData.PedList_01[i].MarkAsNoLongerNeeded();
                    MissionData.PedList_01.RemoveAt(i);
                    MissionData.iUltPed01 += 1;
                }
            }
        }
        public static void MultiPedTracker()
        {
            MissionData.iTracking = Game.GameTime + 1000;

            for (int i = 0; i < MissionData.MultiPed.Count; i++)
            {
                if (MissionData.MultiPed[i].MyPed == null)
                {
                    if (MissionData.MultiPed[i].MyBlip != null)
                        MissionData.MultiPed[i].MyBlip.Remove();
                    MissionData.MultiPed.RemoveAt(i);
                }
                else if (MissionData.MultiPed[i].MyPed.IsDead)
                {
                    if (MissionData.MultiPed[i].MyBlip != null)
                        MissionData.MultiPed[i].MyBlip.Remove();

                    MissionData.PedList_01.Remove(MissionData.MultiPed[i].MyPed);
                    MissionData.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                    MissionData.MultiPed.RemoveAt(i);
                    MissionData.iUltPed01 += 1;
                }
                else if (MissionData.MultiPed[i].MyVehicle != null)
                {
                    if (MissionData.MultiPed[i].MyPed.IsInVehicle(MissionData.MultiPed[i].MyVehicle))
                    {
                        if (!MissionData.MultiPed[i].MySwitch_01)
                        {
                            if (MissionData.MultiPed[i].MyBlip != null)
                                MissionData.MultiPed[i].MyBlip.Remove();
                            MissionData.MultiPed[i].MyBlip = ObjectBuild.VehBlip(MissionData.MultiPed[i].MyVehicle, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
                            MissionData.MultiPed[i].MySwitch_01 = true;
                        }
                    }
                    else
                    {
                        if (MissionData.MultiPed[i].MySwitch_01)
                        {
                            if (MissionData.MultiPed[i].MyBlip != null)
                                MissionData.MultiPed[i].MyBlip.Remove();
                            MissionData.MultiPed[i].MyBlip = ObjectBuild.PedBlimp(MissionData.MultiPed[i].MyPed, 0.75f, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
                            MissionData.MultiPed[i].MySwitch_01 = false;
                        }
                    }
                }
                else
                {
                    if (MissionData.MultiPed[i].MyPed.IsInVehicle())
                    {
                        if (!MissionData.MultiPed[i].MySwitch_01)
                        {
                            if (MissionData.MultiPed[i].MyBlip != null)
                                MissionData.MultiPed[i].MyBlip.Remove();
                            MissionData.MultiPed[i].MySwitch_01 = true;
                        }
                    }
                    else
                    {
                        if (MissionData.MultiPed[i].MySwitch_01)
                        {
                            if (MissionData.MultiPed[i].MyBlip != null)
                                MissionData.MultiPed[i].MyBlip.Remove();
                            MissionData.MultiPed[i].MyBlip = ObjectBuild.PedBlimp(MissionData.MultiPed[i].MyPed, 0.75f, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
                            MissionData.MultiPed[i].MySwitch_01 = false;
                        }
                    }
                }
            }
        }
        public static void PostMess()
        {
            LoggerLight.LogThis("ObjectHand.PostMess");

            MissionData.iMissionSeq = 0;
            MissionData.iMissionVar_01 = 0;
            MissionData.iMissionVar_02 = 0;
            MissionData.iMissionVar_03 = 0;
            MissionData.iMissionVar_04 = 0;
            MissionData.iMishText = -1;
            MissionData.iMishAltT = -1;
            MissionData.iRepMisssion = 0;
            DataStore.iLookForPB = 0;
            MissionData.iCashBouns = 0;
            MissionData.iCashReward = 0;
            MissionData.iCrash4Cash = 0;
            MissionData.iCurrentLap = 1;
            MissionData.iLocationX = 0;
            MissionData.iJobType = 0;

            MissionData.VehTrackin_01 = null;
            MissionData.VehTrackin_02 = null;
            MissionData.VehTrackin_03 = null;
            MissionData.VehTrackin_04 = null;
            MissionData.VehTrackin_05 = null;

            MissionData.Prop_01 = null;
            MissionData.Prop_02 = null;
            MissionData.Prop_03 = null;

            MissionData.Npc_01 = null;
            MissionData.Npc_02 = null;
            MissionData.Npc_03 = null;

            MissionData.Pick_01 = null;

            MissionData.vFuMiss = Vector3.Zero;
            MissionData.vLanLoc = Vector3.Zero;

            UiDisplay.MpUiDisplay.Remove(UiDisplay.BtSlideBar);
            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_01);
            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_03);
            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_04);

            MissionData.bMoreFubar = false;
            MissionData.bReFire = false;

            MissionData.bOnTheJob = false;
            DataStore.bLookingForPB = true;

            Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_FAR_DRAW_VEHICLES, true);

            CleanTriggers();
            WriteContacts(false);

            if (MissionData.bDontPull)
                Game.Player.Character.CanBeDraggedOutOfVehicle = true;

            ObjectLog.CleanAss();
        }
        public static void WriteContacts(bool bUpdateCArz)
        {
            LoggerLight.LogThis("WriteContacts, == " + bUpdateCArz);
            if (File.Exists(DataStore.sNSPMCont))
            {
                if (bUpdateCArz)
                {
                    XmlContacts XSets = ReadWriteXML.LoadXmlCont(DataStore.sNSPMCont);
                    XSets.ImpXCars = MissionData.sImpExpVeh;
                    XSets.ImpXList = MissionData.iImpExpList;
                    ReadWriteXML.SaveXmlCont(XSets, DataStore.sNSPMCont);
                }
                else
                {
                    XmlContacts XSets = ReadWriteXML.LoadXmlCont(DataStore.sNSPMCont);
                    XSets.FuMiss = MissionData.vFuMiss;
                    ReadWriteXML.SaveXmlCont(XSets, DataStore.sNSPMCont);
                }
            }
            else
                UpppDateIMPEXList();
        }
        public static void UpppDateIMPEXList()
        {
            if (File.Exists(DataStore.sNSPMCont))
            {
                XmlContacts XSets = ReadWriteXML.LoadXmlCont(DataStore.sNSPMCont);
                MissionData.sImpExpVeh = XSets.ImpXCars;
                MissionData.iImpExpList = XSets.ImpXList;
            }
            else
            {
                for (int i = 0; i < DataStore.Mk2WeapsMain.Count; i++)
                    DataStore.Mk2WeapsMain[i].MyPlayer = 1;

                XmlContacts XSets = new XmlContacts
                {
                    ImpXCars = MissionData.sImpExpVeh,
                    ImpXList = MissionData.iImpExpList,
                    MyMk2Weaps = DataStore.Mk2WeapsMain
                };
                ReadWriteXML.SaveXmlCont(XSets, DataStore.sNSPMCont);
            }
        }
        public static void ClearTheWay(bool bExtra)
        {
            Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
            Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

            Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
            Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

            Entity[] Entz = World.GetAllEntities();

            List<Entity> Elist = new List<Entity>();

            iClearing = Game.GameTime + 1000;
            for (int i = 0; i < Entz.Count(); i++)
                Elist.Add(Entz[i]);
            for (int i = 0; i < Elist.Count; i++)
            {
                try
                {
                    Entity Ent = Elist[i];
                    if (Ent.Exists())
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_A_PED, Ent.Handle) && Ent.IsPersistent == false)
                            Ent.Delete();
                        if (Function.Call<bool>(Hash.IS_ENTITY_A_VEHICLE, Ent.Handle) && Ent.IsPersistent == false)
                            Ent.Delete();
                    }
                }
                catch
                {
                    LoggerLight.LogThis("ClearTheWay -- LostData");
                }
            }
        }
    }
}
