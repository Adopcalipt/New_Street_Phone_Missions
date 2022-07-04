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
    public class ObjectHand 
    {
        public static int iFaster_01 = 0;
        public static int iFaster_02 = 0;
        public static int iFaster_03 = 0;

        public static void ReadWriteBlips(bool bClearOut, bool bAdd, int iBlip, int iCorrona, int iPed, int iProp, int iVeh, int iSound)
        {
            LoggerLight.LogThis("ReadWriteBlips, bClearOut == " + bClearOut + ", bAdd ==" + bAdd + ", iBlip ==" + iBlip + ", iCorrona ==" + iCorrona + ", iPed ==" + iPed + ", iProp ==" + iProp + ", iVeh ==" + iVeh + ", iSound ==" + iSound);

            BlipStore BStore = new BlipStore();

            if (!File.Exists(DataStore.sNSPMBlips))
            {
                BStore.MyBlips = new List<int>();
                BStore.MyCorrona = new List<int>();
                BStore.MyPeds = new List<int>();
                BStore.MyProps = new List<int>();
                BStore.MyVehcs = new List<int>();
                BStore.MySound = -1;
                ReadWriteXML.SaveXmlBlip(BStore, DataStore.sNSPMBlips);
            }
            else
                BStore = ReadWriteXML.LoadXmlBlip(DataStore.sNSPMBlips);

            if (BStore != null)
            {
                if (bClearOut)
                {
                    for (int i = 0; i < BStore.MyBlips.Count; i++)
                        SafeCleaning(BStore.MyBlips[i], false, 0, false);
                    BStore.MyBlips.Clear();
                    for (int i = 0; i < BStore.MyCorrona.Count; i++)
                        SafeCleaning(BStore.MyCorrona[i], false, 1, false);
                    BStore.MyCorrona.Clear();
                    for (int i = 0; i < BStore.MyPeds.Count; i++)
                        SafeCleaning(BStore.MyPeds[i], false, 2, false);
                    BStore.MyPeds.Clear();
                    for (int i = 0; i < BStore.MyProps.Count; i++)
                        SafeCleaning(BStore.MyProps[i], false, 3, false);
                    BStore.MyProps.Clear();
                    for (int i = 0; i < BStore.MyVehcs.Count; i++)
                        SafeCleaning(BStore.MyVehcs[i], false, 4, false);
                    BStore.MyVehcs.Clear();
                    if (BStore.MySound != -1)
                        SafeCleaning(BStore.MySound, false, 5, false);
                    BStore.MySound = -1;
                }
                else
                {
                    if (bAdd)
                    {
                        if (iBlip != -1)
                        {
                            if (!BStore.MyBlips.Contains(iBlip))
                                BStore.MyBlips.Add(iBlip);
                        }
                        else if (iCorrona != -1)
                        {
                            if (!BStore.MyCorrona.Contains(iCorrona))
                                BStore.MyCorrona.Add(iCorrona);
                        }
                        else if (iPed != -1)
                        {
                            if (!BStore.MyPeds.Contains(iPed))
                                BStore.MyPeds.Add(iPed);
                        }
                        else if (iProp != -1)
                        {
                            if (!BStore.MyProps.Contains(iProp))
                                BStore.MyProps.Add(iProp);
                        }
                        else if (iVeh != -1)
                        {
                            if (!BStore.MyVehcs.Contains(iVeh))
                                BStore.MyVehcs.Add(iVeh);
                        }
                        else if (iSound != -1)
                        {
                            BStore.MySound = iSound;
                        }
                    }
                    else
                    {
                        if (iBlip != -1)
                        {
                            if (iBlip == -99)
                                BStore.MyBlips.Clear();
                            else
                            {
                                if (BStore.MyBlips.Contains(iBlip))
                                    BStore.MyBlips.Remove(iBlip);
                            }
                        }
                        if (iCorrona != -1)
                        {
                            if (iCorrona == -99)
                                BStore.MyCorrona.Clear();
                            else
                            {
                                if (BStore.MyCorrona.Contains(iCorrona))
                                    BStore.MyCorrona.Remove(iCorrona);

                            }
                        }
                        if (iPed != -1)
                        {
                            if (iPed == -99)
                                BStore.MyPeds.Clear();
                            else
                            {
                                if (BStore.MyPeds.Contains(iPed))
                                    BStore.MyPeds.Remove(iPed);
                            }
                        }
                        if (iProp != -1)
                        {
                            if (iProp == -99)
                                BStore.MyProps.Clear();
                            else
                            {
                                if (BStore.MyProps.Contains(iProp))
                                    BStore.MyProps.Remove(iProp);
                            }
                        }
                        if (iVeh != -1)
                        {
                            if (iVeh == -99)
                                BStore.MyVehcs.Clear();
                            else
                            {
                                if (BStore.MyVehcs.Contains(iVeh))
                                    BStore.MyVehcs.Remove(iVeh);
                            }
                        }
                        if (iSound == -1)
                        {
                            BStore.MySound = -1;
                        }
                    }
                }
            }
            else
            {
                BStore = new BlipStore();
                BStore.MyBlips = new List<int>();
                BStore.MyCorrona = new List<int>();
                BStore.MyPeds = new List<int>();
                BStore.MyProps = new List<int>();
                BStore.MyVehcs = new List<int>();
                BStore.MySound = -1;
            }
            ReadWriteXML.SaveXmlBlip(BStore, DataStore.sNSPMBlips);
        }
        public static void SafeCleaning(int ThisHandle, bool bInList, int iType, bool bDelete)
        {
            List<int> iList = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                if (iType == i)
                    iList.Add(ThisHandle);
                else
                    iList.Add(-1);
            }    

            if (bInList)
                ReadWriteBlips(false, false, iList[0], iList[1], iList[2], iList[3], iList[4], iList[5]);

            try
            {
                if (iType == 0)
                {
                    Blip ThisBlip = new Blip(ThisHandle);
                    if (ThisBlip.Exists())
                        ThisBlip.Remove();
                }
                else if (iType == 1)
                {
                    Function.Call(Hash.DELETE_CHECKPOINT, ThisHandle);
                }
                else if (iType == 2)
                {
                    Ped ThisPed = new Ped(ThisHandle);
                    if (ThisPed.Exists())
                    {
                        if (ThisPed.CurrentBlip.Exists())
                            ThisPed.CurrentBlip.Remove();

                        if (bDelete)
                            ThisPed.Delete();
                        else
                            ThisPed.MarkAsNoLongerNeeded();
                    }
                }
                else if (iType == 3)
                {
                    Prop ThisProp = new Prop(ThisHandle);
                    if (ThisProp.Exists())
                    {
                        if (ThisProp.IsAttached())
                            ThisProp.Detach();

                        if (bDelete)
                            ThisProp.Delete();
                        else
                            ThisProp.MarkAsNoLongerNeeded();
                    }
                }
                else if (iType == 4)
                {
                    Vehicle ThisVeh = new Vehicle(ThisHandle);
                    if (ThisVeh.Exists())
                    {
                        if (ThisVeh.CurrentBlip.Exists())
                            ThisVeh.CurrentBlip.Remove();

                        if (bDelete)
                            ThisVeh.Delete();
                        else
                            ThisVeh.MarkAsNoLongerNeeded();
                    }
                }
                else if (iType == 5)
                {
                    Function.Call(Hash.STOP_SOUND, ThisHandle);
                    Function.Call(Hash.RELEASE_SOUND_ID, ThisHandle);
                }
            }
            catch
            {

            }
        }
        public static void CleanUpBlips(List<int> MyList, bool bInList)
        {
            LoggerLight.LogThis("CleanFakeBlips count = " + MyList);

            for (int i = 0; i < MyList.Count; i++)
                SafeCleaning(MyList[i], bInList, 0, false);
        }
        public static void CleanUpCorrona(List<int> MyList, bool bInList)
        {
            LoggerLight.LogThis("CleanUpCheckPoints count = " + MyList);

            for (int i = 0; i < MyList.Count; i++)
                SafeCleaning(MyList[i], bInList, 1, false);
        }
        public static void CleanUpPeds(List<int> MyList, bool bInList, bool bDelete)
        {
            LoggerLight.LogThis("CleanUpPeds count = " + MyList);

            for (int i = 0; i < MyList.Count; i++)
                SafeCleaning(MyList[i], bInList, 2, bDelete);
        }
        public static void CleanUpProps(List<int> MyList, bool bInList, bool bDelete)
        {
            LoggerLight.LogThis("CleanUpProps");

            for (int i = 0; i < MyList.Count; i++)
                SafeCleaning(MyList[i], bInList, 3, bDelete);
        }
        public static void CleanUpVehicles(List<int> MyList, bool bInList, bool bDelete)
        {
            LoggerLight.LogThis("CleanUpVehicles");

            for (int i = 0; i < MyList.Count; i++)
                SafeCleaning(MyList[i], bInList, 4, bDelete);
        }
        public static void CleanUpFire(List<int> MyList)
        {
            LoggerLight.LogThis("CleanUpFire");

            for (int i = 0; i < MyList.Count; i++)
                Function.Call(Hash.REMOVE_SCRIPT_FIRE, MyList[i]);
        }
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
        public static List<int> ConvertToHandle(List<Blip> MyBlips, List<Ped> MyPeds, List<Prop> MyProps, List<Vehicle> MyVeh)
        {
            LoggerLight.LogThis("CleanTriggers");
            List<int> BigList = new List<int>();
            if (MyBlips != null)
            {
                for (int i = 0; i < MyBlips.Count; i++)
                    BigList.Add(MyBlips[i].Handle);
            }
            else if (MyPeds != null)
            {
                for (int i = 0; i < MyPeds.Count; i++)
                    BigList.Add(MyPeds[i].Handle);
            }
            else if (MyProps != null)
            {
                for (int i = 0; i < MyProps.Count; i++)
                    BigList.Add(MyProps[i].Handle);
            }
            else if (MyVeh != null)
            {
                for (int i = 0; i < MyVeh.Count; i++)
                    BigList.Add(MyVeh[i].Handle);
            }

            return BigList;
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
                SafeCleaning(MissionData.Target_01.Handle, true, 0, false);
                MissionData.Target_01 = null;
            }
            if (MissionData.Target_02 != null)
            {
                SafeCleaning(MissionData.Target_02.Handle, true, 0, false);
                MissionData.Target_02 = null;
            }
            if (MissionData.BackUpT != null)
            {
                SafeCleaning(MissionData.BackUpT.Handle, true, 0, false);
                MissionData.BackUpT = null;
            }

            CleanUpCorrona(MissionData.iCoronaList, true);
            MissionData.iCoronaList.Clear();
        }
        public static void Racist_AddRaceCheckPoints(bool bFinish, List<Vector3> CheckList, int iCheckPoints)
        {
            int type = 0;
            int ThisCheck = 0;
            if (bFinish)
            {
                type = 4;
                if (MissionData.bFloater)
                    type = 42;

                float posX1 = CheckList[iCheckPoints].X;
                float posY1 = CheckList[iCheckPoints].Y;
                float posZ1 = CheckList[iCheckPoints].Z - MissionData.fCoronaHight;
                float posX2 = CheckList[iCheckPoints + 1].X;
                float posY2 = CheckList[iCheckPoints + 1].Y;
                float posZ2 = CheckList[iCheckPoints + 1].Z - MissionData.fCoronaHight;

                int red = 255;
                int green = 255;
                int blue = 0;
                int alpha = 255;
                int reserved = 0;
                ThisCheck = Function.Call<int>(Hash.CREATE_CHECKPOINT, type, posX1, posY1, posZ1, posX2, posY2, posZ2, MissionData.fCorSize, red, green, blue, alpha, reserved);
                MissionData.iCoronaList.Add(ThisCheck);

                red = 0;
                green = 102;
                blue = 255;
                alpha = 255;
                Function.Call(Hash._SET_CHECKPOINT_ICON_RGBA, ThisCheck, red, green, blue, alpha);
                if (MissionData.bFloater == false)
                    Function.Call(Hash._0x4B5B4DA5D79F1943, ThisCheck, MissionData.fCoronaDirHt + 0.50f);
            }
            else
            {
                Vector3 vBefore = CheckList[iCheckPoints];

                Vector3 vAfter = CheckList[iCheckPoints];

                if (iCheckPoints == 0)
                    vBefore = CheckList[CheckList.Count - 1];
                else
                    vBefore = CheckList[iCheckPoints - 1];

                if (iCheckPoints == CheckList.Count - 1)
                    vAfter = CheckList[0];
                else
                    vAfter = CheckList[iCheckPoints + 1];

                float dxA = CheckList[iCheckPoints].X - vBefore.X;
                float dyA = CheckList[iCheckPoints].Y - vBefore.Y;

                float fHeadding1 = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dxA, dyA);

                float dxB = CheckList[iCheckPoints].X - vAfter.X;
                float dyB = CheckList[iCheckPoints].Y - vAfter.Y;

                float fHeadding2 = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dxB, dyB);

                float fHeaddin = fHeadding2 - fHeadding1;

                if (fHeaddin < 0)
                    fHeaddin = fHeaddin * -1;
                if (fHeaddin < 35 || fHeaddin > 325)
                {
                    if (MissionData.bFloater)
                        type = 14;
                    else
                        type = 2;
                }
                else if (fHeaddin < 110 || fHeaddin > 250)
                {
                    if (MissionData.bFloater)
                        type = 13;
                    else
                        type = 1;
                }
                else
                {
                    if (MissionData.bFloater)
                        type = 12;
                    else
                        type = 0;
                }
                float posX1 = CheckList[iCheckPoints].X;
                float posY1 = CheckList[iCheckPoints].Y;
                float posZ1 = CheckList[iCheckPoints].Z - MissionData.fCoronaHight;
                float posX2 = vAfter.X;
                float posY2 = vAfter.Y;
                float posZ2 = vAfter.Z - MissionData.fCoronaHight;

                int red = 255;
                int green = 255;
                int blue = 0;
                int alpha = 255;
                int reserved = 0;
                ThisCheck = Function.Call<int>(Hash.CREATE_CHECKPOINT, type, posX1, posY1, posZ1, posX2, posY2, posZ2, MissionData.fCorSize, red, green, blue, alpha, reserved);
                MissionData.iCoronaList.Add(ThisCheck);

                red = 0;
                green = 102;
                blue = 255;
                alpha = 255;
                Function.Call(Hash._SET_CHECKPOINT_ICON_RGBA, ThisCheck, red, green, blue, alpha);
                if (MissionData.bFloater == false)
                    Function.Call(Hash._0x4B5B4DA5D79F1943, ThisCheck, MissionData.fCoronaDirHt);
            }

            ObjectHand.ReadWriteBlips(false, true, -1, ThisCheck, -1, -1, -1, -1);
        }
        public static void RacingBlimps(bool bPrimary, Vector3 vPlace)
        {
            if (bPrimary)
            {
                MissionData.Target_01 = GTA.World.CreateBlip(vPlace);
                MissionData.Target_01.Color = BlipColor.Yellow;
                ObjectHand.ReadWriteBlips(false, true, MissionData.Target_01.Handle, -1, -1, -1, -1, -1);
            }
            else
            {
                MissionData.Target_02 = GTA.World.CreateBlip(vPlace);
                MissionData.Target_02.Color = BlipColor.Yellow;
                MissionData.Target_02.Scale = 0.50f;
                ObjectHand.ReadWriteBlips(false, true, MissionData.Target_02.Handle, -1, -1, -1, -1, -1);
            }
        }
        public static void WalkThisWay(Ped Peddy, Vector3 VSpot, float fSpeed)
        {
            Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, Peddy.Handle, VSpot.X, VSpot.Y, VSpot.Z, fSpeed, -1, 0.0f, false, 0.0f);
        }
        public static void BlipNames(Blip bLippy, string sTag)
        {
            LoggerLight.LogThis("BlipNames");

            Function.Call(Hash.BEGIN_TEXT_COMMAND_SET_BLIP_NAME, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, " " + sTag);
            Function.Call(Hash.END_TEXT_COMMAND_SET_BLIP_NAME, bLippy.Handle);
            Function.Call((Hash)0xF9113A30DE5C6670, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, " " + sTag);
            Function.Call((Hash)0xBC38B49BCB83BC9B, bLippy.Handle);
        }
        public static void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        public static void ClearOutAllStuff()
        {
            ObjectHand.CleanUpCorrona(MissionData.iCoronaList, true);
            ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
            ObjectHand.CleanUpProps(ObjectHand.ConvertToHandle(null, null, MissionData.PropList_01, null), true, true);
            ObjectHand.CleanUpVehicles(ObjectHand.ConvertToHandle(null, null, null, MissionData.VehicleList_01), true, false);
            MissionData.PedList_01.Clear();
            MissionData.PropList_01.Clear();
            MissionData.VehicleList_01.Clear();
            MissionData.iCoronaList.Clear();
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
                        MissionData.VehicleList_01.Remove(MissionData.MultiPed[i].MyVehicle);
                        ObjectHand.SafeCleaning(MissionData.MultiPed[i].MyVehicle.Handle, true, 4, false);
                    }
                    if (MissionData.MultiPed[i].MyPed != null)
                    {
                        MissionData.PedList_01.Remove(MissionData.MultiPed[i].MyPed);
                        if (MissionData.MultiPed[i].MyPed.Exists())
                        {
                            if (bDelete)
                                ObjectHand.SafeCleaning(MissionData.MultiPed[i].MyPed.Handle, true, 2, false);
                            else
                            {
                                MissionData.MultiPed[i].MyPed.Task.ClearAll();
                                MissionData.MultiPed[i].MyPed.Task.FleeFrom(Game.Player.Character);
                                MissionData.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                            }
                        }
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
                    if (ReturnStuff.PedListExists(MissionData.PedList_01, i))
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
                    if (ReturnStuff.PedListExists(MissionData.MishPed, i))
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
                    ObjectHand.ReadWriteBlips(false, false, -1, -1, MissionData.PedList_01[i].Handle, -1, -1, -1);
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
                    ReadWriteBlips(false, false, -1, -1, MissionData.MultiPed[i].MyPed.Handle, -1, -1, -1);
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
                            MissionData.MultiPed[i].MyBlip = ReturnStuff.VehBlip(MissionData.MultiPed[i].MyVehicle, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
                            MissionData.MultiPed[i].MySwitch_01 = true;
                        }
                    }
                    else
                    {
                        if (MissionData.MultiPed[i].MySwitch_01)
                        {
                            if (MissionData.MultiPed[i].MyBlip != null)
                                MissionData.MultiPed[i].MyBlip.Remove();
                            MissionData.MultiPed[i].MyBlip = ReturnStuff.PedBlimp(MissionData.MultiPed[i].MyPed, 0.75f, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
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
                            MissionData.MultiPed[i].MyBlip = ReturnStuff.PedBlimp(MissionData.MultiPed[i].MyPed, 0.75f, false, false, MissionData.MultiPed[i].MyTask_01, MissionData.MultiPed[i].MyName);
                            MissionData.MultiPed[i].MySwitch_01 = false;
                        }
                    }
                }
            }
        }
        public static void Groupies(bool bAdd)
        {
            if (bAdd)
            {
                DataStore.iPlayerGroup = Function.Call<int>(Hash.CREATE_GROUP);
                Function.Call(Hash.SET_PED_AS_GROUP_LEADER, Game.Player.Character.Handle, DataStore.iPlayerGroup);
            }
            else
            {
                Function.Call(Hash.REMOVE_GROUP, DataStore.iPlayerGroup);
            }
        }
        public static void AddDogFighters(int iFighter)
        {
            LoggerLight.LogThis("AddDogFighters, iFighter == " + iFighter);

            for (int i = 0; i < iFighter; i++)
            {
                Vector3 PlayerPozy = Game.Player.Character.Position.Around(1500.00f);
                PlayerPozy.Z = 1500.00f;
                float fRotate = Game.Player.Character.Heading;
                ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(2, 0, false), PlayerPozy, fRotate, false, false, false, false, 13, 0, 3, DataStore.MyLang.Maptext[20], 0, false);
            }
        }
        public static void AddTarget(Vector3 Vlocal, bool bRoute, bool bPrimary, float fRadius, bool bFlasher, int iCon, string sTag)
        {
            LoggerLight.LogThis("AddTarget");

            if (bPrimary)
            {
                if (MissionData.Target_01 == null)
                {
                    if (fRadius < 2.00f)
                    {
                        MissionData.Target_01 = GTA.World.CreateBlip(Vlocal);
                        MissionData.Target_01.IsFlashing = bFlasher;
                        if (bRoute && DataStore.MySettings.ShowRoute)
                            MissionData.Target_01.ShowRoute = true;
                        if (iCon != -1)
                            TaggetIcon(MissionData.Target_01, iCon);

                        if (sTag == "")
                            Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.Target_01.Handle, 8);
                        else
                            ObjectHand.BlipNames(MissionData.Target_01, sTag);
                        MissionData.Target_01.Color = BlipColor.Yellow6;
                    }
                    else
                    {
                        MissionData.BackUpT = GTA.World.CreateBlip(Vlocal);
                        MissionData.BackUpT.Color = BlipColor.Yellow;
                        if (iCon != -1)
                            TaggetIcon(MissionData.BackUpT, iCon);

                        MissionData.Target_01 = GTA.World.CreateBlip(Vlocal, fRadius);
                        MissionData.Target_01.Color = BlipColor.Yellow;
                        MissionData.Target_01.Alpha = 85;
                        MissionData.Target_01.IsFlashing = bFlasher;
                        if (bRoute && DataStore.MySettings.ShowRoute)
                            MissionData.BackUpT.ShowRoute = true;

                        if (sTag == "")
                            Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.BackUpT.Handle, 8);
                        else
                            ObjectHand.BlipNames(MissionData.BackUpT, sTag);
                    }
                    ObjectHand.ReadWriteBlips(false, true, MissionData.Target_01.Handle, -1, -1, -1, -1, -1);
                }
            }
            else
            {
                if (MissionData.Target_02 == null)
                {
                    if (fRadius < 2.00f)
                    {
                        MissionData.Target_02 = GTA.World.CreateBlip(Vlocal);
                        MissionData.Target_02.Color = BlipColor.Orange;
                        MissionData.Target_02.Scale = 0.5f;
                        MissionData.Target_02.IsFlashing = bFlasher;
                    }
                    else
                    {
                        MissionData.Target_02 = GTA.World.CreateBlip(Vlocal, fRadius);
                        MissionData.Target_02.Color = BlipColor.Orange;
                        MissionData.Target_02.Alpha = 85;
                        MissionData.Target_02.IsFlashing = bFlasher;
                    }

                    if (sTag == "")
                        Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.Target_02.Handle, 8);
                    else
                        ObjectHand.BlipNames(MissionData.Target_02, sTag);
                }
                ObjectHand.ReadWriteBlips(false, true, MissionData.Target_02.Handle, -1, -1, -1, -1, -1);
            }
        }
        public static void AppeyNess(Vector3 MyAppy)
        {
            LoggerLight.LogThis("AppeyNess, MyAppy == " + MyAppy);

            int iApt = Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, MyAppy.X, MyAppy.Y, MyAppy.Z);
            if (Function.Call<bool>(Hash.IS_VALID_INTERIOR, iApt))
            {
                if (!Function.Call<bool>(Hash.IS_INTERIOR_READY, iApt))
                {
                    Function.Call((Hash)0x2CA429C029CCF247, iApt);
                    Function.Call(Hash.SET_INTERIOR_ACTIVE, iApt, true);
                    Function.Call(Hash.DISABLE_INTERIOR, iApt, false);
                }
            }

        }
        public static void ControlSelect(int iChoices, bool bPhoneAnim)
        {
            LoggerLight.LogThis("ObjectHand.ControlSelect, iChoices == " + iChoices);
            bool bSelecta = true;
            int iQuickPause = Game.GameTime + 1000;
            string sDisplay = "";
            if (DataStore.bSubscribeNag)
            {
                DataStore.bSubscribeNag = false;
                UI.Notify(DataStore.MyLang.Othertext[157]);
            }
            while (bSelecta)
            {
                if (sDisplay != "")
                    UiDisplay.ControlerUI(sDisplay, 1);

                if (iQuickPause < Game.GameTime)
                {
                    if (iChoices == 1)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[1];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            if (MissionData.iJobType == 11)
                            {
                                MissionData.iCurrentLap = 1;
                                iQuickPause = Game.GameTime + 1000;
                                iChoices = 2;
                            }
                            else
                            {
                                iChoices = 0;
                                TheMissions.PlayerPlays();
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            iChoices = 0;
                            MissionData.bOnTheJob = false;
                            DataStore.bLookingForPB = true;
                        }
                        else if (ReturnStuff.ButtonDown(47))
                        {
                            iChoices = 0;
                            TheMenus.SettingsMenu(false);
                        }
                        else if (Game.Player.Character.Position.DistanceTo(DataStore.vPhoneCorona) > 2.50f)
                        {
                            iChoices = 0;
                            MissionData.bOnTheJob = false;
                            DataStore.bLookingForPB = true;
                        }
                    }       //PhoneAnswer
                    else if (iChoices == 2)
                    {
                        if (sDisplay == "")
                        {
                            if (MissionData.bSoloRace)
                                sDisplay = DataStore.MyLang.Context[5] + DataStore.MyLang.Context[6];
                            else
                                sDisplay = DataStore.MyLang.Context[5] + DataStore.MyLang.Context[7];
                        }

                        if (ReturnStuff.ButtonDown(21))
                        {
                            iQuickPause = Game.GameTime + 1000;
                            iChoices = 3;
                        }
                        else if (ReturnStuff.ButtonDown(47))
                        {
                            iQuickPause = Game.GameTime + 500;
                            MissionData.bSoloRace = !MissionData.bSoloRace;
                        }
                    }       //Racism
                    else if (iChoices == 3)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[3] + MissionData.iCurrentLap;

                        if (ReturnStuff.ButtonDown(21))
                        {
                            iChoices = 0;
                            if (DataStore.bOnCayoLand)
                                TheMissions.Raceist();
                            else
                                TheMissions.PlayerPlays();
                        }
                        else if (ReturnStuff.ButtonDown(47))
                        {
                            iQuickPause = Game.GameTime + 500;
                            if (MissionData.iCurrentLap > 1)
                                MissionData.iCurrentLap = MissionData.iCurrentLap - 1;
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            iQuickPause = Game.GameTime + 500;
                            if (MissionData.iCurrentLap < 10)
                                MissionData.iCurrentLap = MissionData.iCurrentLap + 1;
                        }
                    }       //Raceism2
                    else if (iChoices == 4)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[9];

                        TheMissions.TakeNote();
                        if (ReturnStuff.ButtonDown(47))
                        {
                            iChoices = 0;
                            TheMenus.SettingsMenu(false);
                        }
                        else if (Game.Player.Character.Position.DistanceTo(DataStore.vPhoneCorona) > 2.50f)
                        {
                            iChoices = 0;
                            MissionData.bOnTheJob = false;
                            DataStore.bLookingForPB = true;
                        }
                    }       //PhoneBox No Jobs Selected
                    else if (iChoices == 5)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {

                            if (sDisplay == "")
                                sDisplay = DataStore.MyLang.Context[2];

                            if (!UiDisplay.bSubDisplay)
                            {
                                UiDisplay.bSubDisplay = true;
                                UiDisplay.sSubDisplay = DataStore.MyLang.Mistext[190];
                            }

                            if (ReturnStuff.ButtonDown(21))
                            {
                                MissionData.bPacBouns = false;
                                iChoices = 0;
                                MissionData.iMissionSeq = 0;
                                MissionData.iLocationX = 99;
                                TheMissions.GetAwayDriver();
                            }
                            else if (ReturnStuff.ButtonDown(22))
                            {
                                MissionData.bPacBouns = false;
                                iChoices = 0;
                                ObjectHand.PostMess();
                            }
                        }
                    }       //Pacstandard
                    else if (iChoices == 6)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            iChoices = 0;
                            MissionData.bMoreFubar = true;
                            MissionData.bJobLoaded = false;
                            DataStore.MyDatSet.iFubard += 1;
                            RWDatFile.SaveDat(13, DataStore.MyDatSet.iFubard);
                            MissionData.iRepMisssion += 1;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            TheMissions.AreULocal();
                        }
                        else if (ReturnStuff.ButtonDown(22) || !(Game.Player.Character.IsInVehicle()))
                        {
                            MissionData.bMoreFubar = false;
                            iChoices = 0;
                            DataStore.MyDatSet.iFubard += 1;
                            RWDatFile.SaveDat(13, DataStore.MyDatSet.iFubard);
                            MissionData.iRepMisssion += 1;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            MissionData.iMissionSeq = 9;
                        }
                    }       //fubar
                    else if (iChoices == 7)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.iRepMisssion += 1;
                            iChoices = 0;
                            MissionData.iMissionSeq = 0;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            TheMissions.Ambulance();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.bAmberAntz = false;
                            iChoices = 0;
                            MissionData.iRepMisssion += 1;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            MissionData.iMissionSeq = 9;
                        }
                    }       //Ambullance
                    else if (iChoices == 8)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {

                            ObjectHand.ClearOutAllStuff();
                            ObjectHand.CleanUpFire(MissionData.iFireList);
                            MissionData.iFireList.Clear();
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionSeq = 0;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            MissionData.iRepMisssion += 1;
                            iChoices = 0;
                            TheMissions.FireDept();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.iMissionSeq = 40;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            MissionData.bReFire = false;
                            MissionData.iRepMisssion += 1;
                            iChoices = 0;
                        }
                    }       //Fire
                    else if (iChoices == 9)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[8];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.iMissionSeq = 7;
                            iChoices = 0;
                            DataStore.MySettings.StartOnYAcht = true;
                            ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.iMissionSeq = 7;
                            iChoices = 0;
                            DataStore.MySettings.StartOnYAcht = false;
                            ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                        }
                    }       //Yacht2
                    else if (iChoices == 10)
                    {
                        if (sDisplay == "")
                            sDisplay = ReturnStuff.ShowComs(DataStore.MySettings.YachtPrice, true, false) + DataStore.MyLang.Context[4];

                        if (DataStore.MySettings.YachtPrice < 0)
                            DataStore.MySettings.YachtPrice = 0;
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            if (DataStore.MyDatSet.iNSPMBank > DataStore.MySettings.YachtPrice)
                            {
                                iChoices = 9;
                                iQuickPause = Game.GameTime + 1000;
                                MissionData.iCashReward = 0;
                                DataStore.MySettings.YachtPrice *= -1;
                                UiDisplay.YourCoinPopUp(DataStore.MySettings.YachtPrice, 1, "Yacht Purchased");
                                DataStore.MyDatSet.iOwnaYacht = DataStore.iProcessForYacht;
                                DataStore.MyAssets.OwnaYacht = true;
                                DataStore.MySettings.YachtPrice = 0;
                                RWDatFile.SaveDat(0, DataStore.iProcessForYacht);
                                TheMissions.Water02_BoatLaunch();
                            }
                            else
                            {
                                UI.Notify("Funds not avalable");
                                iChoices = 0;
                                MissionData.iMissionSeq = 7;
                                MissionData.iCashReward = 20000;
                                DataStore.MyAssets.OwnaYacht = false;
                                DataStore.MyDatSet.iOwnaYacht = 0;
                                if (!MissionData.VehTrackin_01.IsDead)
                                    ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                                else
                                {
                                    Vector3 Vpos = new Vector3(-1848.826f, -1200.298f, 19.14339f);
                                    SlowFastTravel(Vpos, 165.84f);
                                }
                                if (MissionData.bOldYacht)
                                    TheMissions.Water02_AddHeistYacht(false);
                                ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            iChoices = 0;
                            MissionData.iMissionSeq = 7;
                            MissionData.iCashReward = 20000;
                            ///YachtStuff_TheBlip(false);
                            DataStore.MyAssets.OwnaYacht = false;
                            DataStore.MyDatSet.iOwnaYacht = 0;
                            if (!MissionData.VehTrackin_01.IsDead)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            else
                            {
                                Vector3 Vpos = new Vector3(-1848.826f, -1200.298f, 19.14339f);
                                SlowFastTravel(Vpos, 165.84f);
                            }
                            if (MissionData.bOldYacht)
                                TheMissions.Water02_AddHeistYacht(false);
                            ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                        }
                    }      //Yacht
                    else if (iChoices == 11)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.iMissionSeq = 0;
                            iChoices = 0;
                            MissionData.bDeliverWowRep = true;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            TheMissions.Deliverwho();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            iChoices = 0;
                            MissionData.bDeliverWowRep = false;
                            ObjectBuild.XmlPedDresser(Game.Player.Character, ReadWriteXML.LoadXmlClothDefault(DataStore.sDefaulted));
                            NSCoinInvestments(true, 5, 7, "Deliverwho");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                    }       //Delliverwho
                    else
                    {
                        if (bPhoneAnim)
                        {
                            if (MissionData.bPickUpHangUp)
                            {
                                ObjectBuild.ForceAnimOnceEnding(Game.Player.Character, "oddjobs@assassinate@multi@call", "ass_multi_target_call_p1", Game.Player.Character.Position, Game.Player.Character.Rotation, 0.88f);
                                Script.Wait(4000);
                                Game.Player.Character.Task.ClearAnimation("oddjobs@assassinate@multi@call", "ass_multi_target_call_p1");
                                MissionData.bPickUpHangUp = false;
                            }
                        }
                        UiDisplay.bSubDisplay = false;
                        bSelecta = false;
                    }
                }
                Script.Wait(1);
            }

            LoggerLight.LogThis("ObjectHand.ControlSelect End, iChoices == " + iChoices);
        }
        public static void DoorsNear(Vector3 VDoorPos, float fRadius, bool bLock)
        {
            LoggerLight.LogThis("DoorsNear");

            Prop[] Opensesme = World.GetNearbyProps(VDoorPos, fRadius);
            for (int i = 0; i < Opensesme.Count(); i++)
            {
                if (ReturnStuff.PropExists(Opensesme, i))
                {
                    Prop ThisDoor = Opensesme[i];
                    for (int ii = 0; ii < DataStore.sDoorList.Count; ii++)
                    {
                        if (Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sDoorList[ii]) == ThisDoor.Model.Hash)
                        {
                            if (bLock)
                            {
                                ShutThatDoor(ThisDoor.Position, DataStore.sDoorList[ii]);
                            }
                            else
                            {
                                ThisDoor.FreezePosition = false;
                                Function.Call(Hash.SET_STATE_OF_CLOSEST_DOOR_OF_TYPE, ThisDoor.Model.Hash, ThisDoor.Position.X, ThisDoor.Position.Y, ThisDoor.Position.Z, false, 0, 1);
                            }
                            break;
                        }
                    }
                }
            }
        }
        public static void FindTheTime(int iTime, int iOutput, string sLabel, bool bDrawPool)
        {
            if (iOutput == 1)
            {
                UiDisplay.ttTextBar_01.Text = ReturnStuff.ShowComs(iTime, false, true);
                int iLapBig = MissionData.iList_01[1] - Game.GameTime;
                iLapBig = iLapBig * -1;
                UiDisplay.ttTextBar_03.Text = ReturnStuff.ShowComs(iLapBig, false, true);
            }
            else if (iOutput == 2)
                UiDisplay.ttTextBar_03.Text = ReturnStuff.ShowComs(iTime, false, true);
            else if (iOutput == 3)
                UI.ShowSubtitle("" + sLabel + "~o~" + ReturnStuff.ShowComs(iTime, false, true) + "~w~.", 15000);
            else if (iOutput == 4)
                UI.ShowSubtitle("" + sLabel + "~o~" + ReturnStuff.ShowComs(iTime, false, false) + "~w~.", 15000);
            else if (iOutput == 5)
            {
                UI.ShowSubtitle("" + sLabel + "~o~" + ReturnStuff.ShowComs(iTime, false, true) + "~w~.", 15000);
                if (MissionData.bSoloRace)
                    TheMissions.GameOver(false, " " + ReturnStuff.ShowComs(iTime, false, true) + " ", false, MissionData.iCashReward);
                else
                    TheMissions.GameOver(false, "Pos : " + MissionData.iList_01[3] + "/4, ", false, MissionData.iCashReward);
            }
            else if (iOutput == 6)
            {
                int iDeduct = iTime / 250;
                MissionData.iCashBouns = MissionData.iCrash4Cash + iDeduct;
                if (MissionData.iCashBouns < 1)
                    MissionData.iCashBouns = 0;
                UiDisplay.ttTextBar_01.Text = "$" + MissionData.iCashBouns + "";
                UiDisplay.ttTextBar_02.Text = ReturnStuff.ShowComs(iTime, false, false);
            }
            else if (iOutput == 7)
                UiDisplay.ttTextBar_01.Text = ReturnStuff.ShowComs(iTime, false, false);
            else if (iOutput == 8)
            {
                //Redundant
                UiDisplay.ttTextBar_02.Text = ReturnStuff.ShowComs(iTime, false, false);
            }
            else if (iOutput == 9)
                UiDisplay.ttTextBar_02.Text = ReturnStuff.ShowComs(iTime, false, false);

            if (bDrawPool)
            {
                if (!UiDisplay.bUiDisplay)
                    UiDisplay.bUiDisplay = true;
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
        public static void GetWeaps(bool bRemoveAll)
        {
            LoggerLight.LogThis("GetWeaps");

            DataStore.PlayerWeapXList.Clear();
            List<string> sWeapList = ReturnStuff.WeapsList();
            List<string> sAddsList = ReturnStuff.WeapAddonsList();

            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < sWeapList.Count; i++)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]), false))
                {
                    PlayerWeaps IGotDis = new PlayerWeaps();

                    int iAmmos = 0;
                    IGotDis.MyWeap = sWeapList[i];

                    iAmmos = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]));
                    if (iAmmos < 1)
                        iAmmos = 1;
                    IGotDis.MyAmmo = iAmmos;

                    for (int ii = 0; ii < sAddsList.Count; ii++)
                    {
                        if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]), Function.Call<int>(Hash.GET_HASH_KEY, sAddsList[ii])))
                            IGotDis.MyAttachList.Add(sAddsList[ii]);
                    }
                    DataStore.PlayerWeapXList.Add(IGotDis);
                    ///if (i == 19 || i == 24 || i == 74 || i == 72 || i == 68 || i == 63 || i == 61 || i == 58 || i == 56 || i == 46 || i == 39 || i == 29)--Mk2Weapps
                }
            }
            if (bRemoveAll)
                Game.Player.Character.Weapons.RemoveAll();
        }
        public static void NSCoinInvestments(bool bPlus, int iLow, int iHigh, string sEnder)
        {
            RWDatFile.LoadDat();
            float fAdd = ReturnStuff.RandFlow((float)iLow, (float)iHigh);
            float fSum = 0.00f;
            if (bPlus)
            {
                if (DataStore.MyDatSet.iNSPMCHighRisk > 0)
                {
                    fSum = (float)DataStore.MyDatSet.iNSPMCHighRisk / 100.00f;
                    fSum *= fAdd;
                    UiDisplay.YourCoinPopUp((int)fSum, 3, sEnder);
                }
                if (DataStore.MyDatSet.iNSPMCLowRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCLowRisk / 100;
                    fSum *= fAdd / 4.00f;
                    UiDisplay.YourCoinPopUp((int)fSum, 2, sEnder);
                }
            }
            else
            {
                if (DataStore.MyDatSet.iNSPMCHighRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCHighRisk / 100;
                    fSum *= fAdd;
                    fSum *= -1;
                    UiDisplay.YourCoinPopUp((int)fSum, 3, sEnder);
                }
                if (DataStore.MyDatSet.iNSPMCLowRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCLowRisk / 100;
                    fSum *= fAdd / 4;
                    fSum *= -1;
                    UiDisplay.YourCoinPopUp((int)fSum, 2, sEnder);
                }
            }
        }
        public static void NSCoinCount(bool bAdd, int iAcc)
        {
            int iAmountTo = 1;

            if (bAdd)
            {
                if (iAcc == 1)
                {
                    if (ReturnStuff.NSPMCoin(0) > 0)
                    {
                        if (DataStore.MyDatSet.iNSPMBank < 2100000000)
                        {
                            if (iFaster_03 < Game.GameTime)
                            {
                                if (ReturnStuff.NSPMCoin(0) > 100000)
                                    iAmountTo = 100000;
                                else
                                    iFaster_03 = Game.GameTime + 2000;
                            }
                            else if (iFaster_02 < Game.GameTime)
                            {
                                if (ReturnStuff.NSPMCoin(0) > 10000)
                                    iAmountTo = 10000;
                                else
                                    iFaster_02 = Game.GameTime + 2000;
                            }
                            else if (iFaster_01 < Game.GameTime)
                            {
                                if (ReturnStuff.NSPMCoin(0) > 100)
                                    iAmountTo = 100;
                                else
                                    iFaster_01 = Game.GameTime + 2000;
                            }

                            DataStore.MyDatSet.iNSPMBank += iAmountTo;
                            ReturnStuff.NSPMCoin(iAmountTo * -1);
                        }
                    }
                }
                else if (iAcc == 2)
                {
                    if (DataStore.MyDatSet.iNSPMBank > 0)
                    {
                        if (DataStore.MyDatSet.iNSPMCLowRisk < 2100000000)
                        {
                            if (iFaster_03 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 100000)
                                    iAmountTo = 100000;
                                else
                                    iFaster_03 = Game.GameTime + 2000;
                            }
                            else if (iFaster_02 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 10000)
                                    iAmountTo = 10000;
                                else
                                    iFaster_02 = Game.GameTime + 2000;
                            }
                            else if (iFaster_01 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 100)
                                    iAmountTo = 100;
                                else
                                    iFaster_01 = Game.GameTime + 2000;
                            }

                            DataStore.MyDatSet.iNSPMCLowRisk += iAmountTo;
                            DataStore.MyDatSet.iNSPMBank -= iAmountTo;
                        }
                    }
                }
                else if (iAcc == 3)
                {
                    if (DataStore.MyDatSet.iNSPMBank > 0)
                    {
                        if (DataStore.MyDatSet.iNSPMCHighRisk < 2100000000)
                        {
                            if (iFaster_03 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 100000)
                                    iAmountTo = 100000;
                                else
                                    iFaster_03 = Game.GameTime + 2000;
                            }
                            else if (iFaster_02 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 10000)
                                    iAmountTo = 10000;
                                else
                                    iFaster_02 = Game.GameTime + 2000;
                            }
                            else if (iFaster_01 < Game.GameTime)
                            {
                                if (DataStore.MyDatSet.iNSPMBank > 100)
                                    iAmountTo = 100;
                                else
                                    iFaster_01 = Game.GameTime + 2000;
                            }

                            DataStore.MyDatSet.iNSPMCHighRisk += iAmountTo;
                            DataStore.MyDatSet.iNSPMBank -= iAmountTo;
                        }
                    }
                }
                else if (iAcc == 5)
                {
                    if (DataStore.MySettings.YachtPrice < 2100000000)
                    {
                        if (iFaster_03 < Game.GameTime)
                            DataStore.MySettings.YachtPrice += +100000;
                        else if (iFaster_02 < Game.GameTime)
                            DataStore.MySettings.YachtPrice += +10000;
                        else if (iFaster_01 < Game.GameTime)
                            DataStore.MySettings.YachtPrice += +100;
                        else
                            DataStore.MySettings.YachtPrice += +1;
                    }
                }
            }
            else
            {
                if (iAcc == 1)
                {
                    if (DataStore.MyDatSet.iNSPMBank > 0)
                    {
                        if (iFaster_03 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMBank > 100000)
                                iAmountTo = 100000;
                            else
                                iFaster_03 = Game.GameTime + 2000;
                        }
                        else if (iFaster_02 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMBank > 10000)
                                iAmountTo = 10000;
                            else
                                iFaster_02 = Game.GameTime + 2000;
                        }
                        else if (iFaster_01 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMBank > 100)
                                iAmountTo = 100;
                            else
                                iFaster_01 = Game.GameTime + 2000;
                        }

                        DataStore.MyDatSet.iNSPMBank -= iAmountTo;
                        ReturnStuff.NSPMCoin(iAmountTo);
                    }
                }
                else if (iAcc == 2)
                {
                    if (DataStore.MyDatSet.iNSPMCLowRisk > 0)
                    {
                        if (iFaster_03 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCLowRisk > 100000)
                                iAmountTo = 100000;
                            else
                                iFaster_03 = Game.GameTime + 2000;
                        }
                        else if (iFaster_02 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCLowRisk > 10000)
                                iAmountTo = 10000;
                            else
                                iFaster_02 = Game.GameTime + 2000;
                        }
                        else if (iFaster_01 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCLowRisk > 100)
                                iAmountTo = 100;
                            else
                                iFaster_01 = Game.GameTime + 2000;
                        }

                        DataStore.MyDatSet.iNSPMCLowRisk -= iAmountTo;
                        DataStore.MyDatSet.iNSPMBank += iAmountTo;
                    }
                }
                else if (iAcc == 3)
                {
                    if (DataStore.MyDatSet.iNSPMCHighRisk > 0)
                    {
                        if (iFaster_03 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCHighRisk > 100000)
                                iAmountTo = 100000;
                            else
                                iFaster_03 = Game.GameTime + 2000;
                        }
                        else if (iFaster_02 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCHighRisk > 10000)
                                iAmountTo = 10000;
                            else
                                iFaster_02 = Game.GameTime + 2000;
                        }
                        else if (iFaster_01 < Game.GameTime)
                        {
                            if (DataStore.MyDatSet.iNSPMCHighRisk > 100)
                                iAmountTo = 100;
                            else
                                iFaster_01 = Game.GameTime + 2000;
                        }

                        DataStore.MyDatSet.iNSPMCHighRisk -= iAmountTo;
                        DataStore.MyDatSet.iNSPMBank += iAmountTo;
                    }
                }
                else if (iAcc == 5)
                {
                    if (DataStore.MySettings.YachtPrice > 0)
                    {
                        if (iFaster_03 < Game.GameTime)
                        {
                            if (DataStore.MySettings.YachtPrice > 100000)
                                DataStore.MySettings.YachtPrice += -100000;
                            else
                                iFaster_03 = Game.GameTime + 2000;
                        }
                        else if (iFaster_02 < Game.GameTime)
                        {
                            if (DataStore.MySettings.YachtPrice > 10000)
                                DataStore.MySettings.YachtPrice += -10000;
                            else
                                iFaster_02 = Game.GameTime + 2000;
                        }
                        else if (iFaster_01 < Game.GameTime)
                        {
                            if (DataStore.MySettings.YachtPrice > 100)
                                DataStore.MySettings.YachtPrice += -100;
                            else
                                iFaster_01 = Game.GameTime + 2000;
                        }
                        else
                        {
                            if (DataStore.MySettings.YachtPrice > 0)
                                DataStore.MySettings.YachtPrice += -1;
                        }
                    }
                    else
                        DataStore.MySettings.YachtPrice = 0;

                }
            }
        }
        public static void SlowFastTravel(Vector3 VDest, float fHedd)
        {
            LoggerLight.LogThis("SlowFastTravel");

            if (fHedd == 0.00f)
                fHedd = (int)ReturnStuff.RandInt(0, 360);
            Game.FadeScreenOut(1000);
            Script.Wait(1000);
            Game.Player.Character.Position = VDest;
            Game.Player.Character.Heading = fHedd;
            Script.Wait(2000);
            Game.FadeScreenIn(1000);
        }
        public static void SlowFastVehicleTravel(Vector3 VDest, float fHedd)
        {
            LoggerLight.LogThis("SlowFastTravel");
            if (Game.Player.Character.IsInVehicle())
            {
                if (fHedd == 0.00f)
                    fHedd = (int)ReturnStuff.RandInt(0, 360);
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
                    fHedd = (int)ReturnStuff.RandInt(0, 360);
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                Game.Player.Character.Position = VDest;
                Game.Player.Character.Heading = fHedd;
                Script.Wait(2000);
                Game.FadeScreenIn(1000);
            }
        }
        public static void ShutThatDoor(Vector3 VDoorPos, String SDoorTag)
        {
            LoggerLight.LogThis("ShutThatDoor");

            Prop[] Opensesme = World.GetNearbyProps(VDoorPos, 6.00f);
            for (int i = 0; i < Opensesme.Count(); i++)
            {
                if (ReturnStuff.PropExists(Opensesme, i))
                {
                    Prop ThisDoor = Opensesme[i];
                    if (ThisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, SDoorTag))
                        ThisDoor.FreezePosition = true;
                }
            }
        }
        public static void PedSitHere(Ped Peddy, Prop Chair, int iChair)
        {
            LoggerLight.LogThis("PedSitHere, iChair == " + iChair);

            Vector3 vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.55f);

            Peddy.Position = vCharPos;
            Peddy.Heading = Chair.Heading - 180.00f;

            if (iChair == 1)
            {
                List<string> SitVArs = new List<string>
                {
                    "PROP_HUMAN_SEAT_CHAIR",
                    "PROP_HUMAN_SEAT_CHAIR_UPRIGHT"
                };

                ObjectBuild.PedScenario(Peddy, SitVArs[ReturnStuff.RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 2)
            {
                vCharPos += (Chair.ForwardVector * 0.30f);
                vCharPos.Z -= 0.10f;
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_SUNLOUNGER", vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 3)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_ARMCHAIR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 4)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_BAR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 5)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_COMPUTER", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 6)
            {
                List<string> SitVArs = new List<string>
                {
                    "PROP_HUMAN_SEAT_DECKCHAIR",
                    "PROP_HUMAN_SEAT_DECKCHAIR_DRINK"
                };

                ObjectBuild.PedScenario(Peddy, SitVArs[ReturnStuff.RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 7)
            {
                List<string> SitVArs = new List<string>
                {
                    "PROP_HUMAN_SEAT_BENCH",
                    "PROP_HUMAN_SEAT_BENCH_DRINK",
                    "PROP_HUMAN_SEAT_BENCH_DRINK_BEER",
                    "PROP_HUMAN_SEAT_BENCH_FOOD"
                };

                ObjectBuild.PedScenario(Peddy, SitVArs[ReturnStuff.RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 8)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.70f);

                List<string> SitVArs = new List<string>
                {
                    "PROP_HUMAN_SEAT_CHAIR",
                    "PROP_HUMAN_SEAT_CHAIR_UPRIGHT"
                };

                ObjectBuild.PedScenario(Peddy, SitVArs[ReturnStuff.RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 9)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.50f);

                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_CHAIR_UPRIGHT", vCharPos, Chair.Heading - 180.00f, true);
            }

            Peddy.AlwaysKeepTask = false;
        }
        public static void ReturnWeaps()
        {
            LoggerLight.LogThis("ReturnWeaps");

            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < DataStore.PlayerWeapXList.Count; i++)
            {
                int iAmmo = DataStore.PlayerWeapXList[i].MyAmmo;

                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.PlayerWeapXList[i].MyWeap), iAmmo, false, true);

                for (int ii = 0; ii < DataStore.PlayerWeapXList[i].MyAttachList.Count; ii++)
                {
                    if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.PlayerWeapXList[i].MyWeap), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.PlayerWeapXList[i].MyAttachList[ii])))
                        Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.PlayerWeapXList[i].MyWeap), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.PlayerWeapXList[i].MyAttachList[ii]));

                }
            }
            Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character.Handle, false, true, true, true);
        }
        public static void TaggetIcon(Blip bLip, int iCon)
        {
            Function.Call(Hash.SET_BLIP_SPRITE, bLip.Handle, iCon);
        }
    }
}
