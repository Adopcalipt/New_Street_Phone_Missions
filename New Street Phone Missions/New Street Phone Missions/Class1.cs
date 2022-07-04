using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class Main : Script
    {
        private bool bLogFiles = true;

        private bool bRingRing = false;
        private bool bDlCVehStartTest = true;

        private int iATMSlow = 0;
        private int iPhonedID = 0;
        private int iClearing = 0; 
        private int iAppScaner = 0;

        private int iPhoneDelay = 0;

        private float fKeepMoving = 0.00f;


        private Blip PhoneBlip = null;

        private Prop PhoneHome = null;

        private Vehicle DLCTestVeh = null;
       
        private List<Prop> CayoPhones = new List<Prop>();

        public Main()
        {
            DataStore.DataStoreLoad();
            Tick += OnTick;
            Interval = 1;
        }
        private void TheCayoConnection(bool bLoadCayo)
        {
            LoggerLight.LogThis("TheCayoConnection");

            if (bLoadCayo)
            {
                CayoPhones.Clear();
                List<Vector3> CayPos = new List<Vector3>();
                List<Vector3> CayRot = new List<Vector3>();

                CayPos.Add(new Vector3(4969.19336f, -5600.90381f, 23.20f)); CayRot.Add(new Vector3(0.00f, 0.00f, -31.9523754f));
                CayPos.Add(new Vector3(5099.08643f, -5719.28613f, 16.00f)); CayRot.Add(new Vector3(0.00f, 0.00f, -124.599854f));
                CayPos.Add(new Vector3(5368.04688f, -5434.42529f, 48.70f)); CayRot.Add(new Vector3(0.00f, 0.00f, 145.241089f));
                CayPos.Add(new Vector3(4892.95898f, -5453.17578f, 30.40f)); CayRot.Add(new Vector3(0.00f, 0.00f, -2.67467785f));
                CayPos.Add(new Vector3(4914.79004f, -5294.33057f, 7.90f)); CayRot.Add(new Vector3(3.00f, -1.00f, -88.7225647f));
                CayPos.Add(new Vector3(5117.92285f, -5189.38135f, 2.10f)); CayRot.Add(new Vector3(0.00f, 0.00f, -90.0995636f));
                CayPos.Add(new Vector3(5152.40479f, -5058.93018f, 3.80f)); CayRot.Add(new Vector3(0.00f, 0.00f, 87.5917511f));
                CayPos.Add(new Vector3(5142.36719f, -4952.96729f, 14.00f)); CayRot.Add(new Vector3(0.00f, 0.00f, 49.3263206f));
                CayPos.Add(new Vector3(5028.74512f, -4635.70703f, 4.70f)); CayRot.Add(new Vector3(0.00f, 0.00f, -101.267654f));
                CayPos.Add(new Vector3(4872.50977f, -4482.87988f, 9.80f)); CayRot.Add(new Vector3(0.00f, 0.00f, 88.2257385f));
                CayPos.Add(new Vector3(4492.33105f, -4522.10205f, 4.10f)); CayRot.Add(new Vector3(0.00f, 0.00f, 109.983139f));
                CayPos.Add(new Vector3(4365.35645f, -4579.11377f, 4.00f)); CayRot.Add(new Vector3(0.00f, 0.00f, -69.9810333f));
                CayPos.Add(new Vector3(5177.31738f, -4651.67627f, 2.20f)); CayRot.Add(new Vector3(0.00f, 0.00f, 167.547989f));
                CayPos.Add(new Vector3(5264.31201f, -5420.22607f, 65.50f)); CayRot.Add(new Vector3(0.00f, 0.00f, 55.1944542f));
                CayPos.Add(new Vector3(5132.79688f, -5527.75342f, 53.70f)); CayRot.Add(new Vector3(0.00f, 0.00f, 119.800873f));
                CayPos.Add(new Vector3(5032.13135f, -5759.62793f, 15.30f)); CayRot.Add(new Vector3(0.00f, 0.00f, 138.167618f));
                CayPos.Add(new Vector3(5038.44678f, -5120.1416f, 5.50f)); CayRot.Add(new Vector3(0.00f, 0.00f, -178.255859f));

                for (int i = 0; i < CayPos.Count; i++)
                {
                    Prop Bpox = ObjectBuild.BuildProp("p_phonebox_02_s", CayPos[i], CayRot[i], true, true);
                    if (Bpox != null)
                        CayoPhones.Add(new Prop(Bpox.Handle));
                }
                MissionData.PropList_01.Clear();
                DataStore.bOnCayoLand = true;
            }
            else
            {
                for (int i = 0; i < CayoPhones.Count; i++)
                    CayoPhones[i].Delete();
                CayoPhones.Clear();

                DataStore.bOnCayoLand = false;
            }
        }
        private void KeepMoving(Ped Peddy, Vector3 Vtarg, int iWait4)
        {
            MissionData.iWait4Sec = Game.GameTime + iWait4;
            if (ReturnStuff.BeInRange(0.75f, fKeepMoving, Peddy.Position.DistanceTo(Vtarg)))
            {
                Peddy.Task.ClearAll();
                Peddy.Position += Peddy.ForwardVector * 2.50f;
                ObjectHand.WalkThisWay(Peddy, Vtarg, 2.00f);
            }
            else
                fKeepMoving = Peddy.Position.DistanceTo(Vtarg);
        }
        private void StopHere(Vehicle Vic)
        {
            LoggerLight.LogThis("StopHere");

            while (Vic.IsInAir)
                Script.Wait(10);
            Vic.FreezePosition = true;
            Script.Wait(1000);
            Vic.FreezePosition = false;
        }
        private void GateIsNear(Vector3 VGatePos, float fRadius, bool bPropX)
        {
            LoggerLight.LogThis("GateIsNear, bPropX == " + bPropX);

            Prop[] Opensesme = World.GetNearbyProps(VGatePos, fRadius);
            for (int i = 0; i < Opensesme.Count(); i++)
            {
                if (ReturnStuff.PropExists(Opensesme, i))
                {
                    Prop ThisDoor = Opensesme[i];
                    for (int ii = 0; ii < DataStore.sGateList.Count; ii++)
                    {
                        if (ThisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, "prop_facgate_04_r") || ThisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, "prop_facgate_04_l") || ThisDoor.Model == Function.Call<int>(Hash.GET_HASH_KEY, "prop_fnclink_06gate2"))
                            ThisDoor.Delete();
                        else if (Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sGateList[ii]) == ThisDoor.Model)
                        {
                            Function.Call(Hash._DOOR_CONTROL, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sGateList[ii]), ThisDoor.Position.X, ThisDoor.Position.Y, ThisDoor.Position.Z, false, 0.00f, 50.00f, 0.00f);
                            if (bPropX)
                                MissionData.Prop_01 = ThisDoor;
                        }
                    }
                }
            }
        }
        private void MoveThatCar(Vector3 VPos)
        {
            LoggerLight.LogThis("MoveThatCar");

            Vehicle[] Carsy = World.GetNearbyVehicles(VPos, 10.00f);

            for (int i = 0; i < Carsy.Count(); i++)
            {
                if (ReturnStuff.VehExists(Carsy, i))
                {
                    Vehicle VehicleX = Carsy[i];
                    if (!VehicleX.IsPersistent)
                    {
                        if (VehicleX.ClassType == VehicleClass.Utility)
                            VehicleX.Delete();
                        else
                        {
                            Ped Pedx = VehicleX.CreateRandomPedOnSeat(VehicleSeat.Driver);
                            Pedx.MarkAsNoLongerNeeded();
                        }
                    }
                }
            }
        }
        private void FlyToRightHere(Ped Pedd, Vehicle vHeli, Vector3 vHeliDest, float fSpeed, float fheader)
        {
            LoggerLight.LogThis("FlyToRightHere");

            float HeliDesX = vHeliDest.X;
            float HeliDesY = vHeliDest.Y;
            float HeliDesZ = vHeliDest.Z;
            float HeliSpeed = fSpeed;
            float HeliDirect = fheader;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        private void StayInVehicle(Ped Peddy, bool bPlayer)
        {
            LoggerLight.LogThis("StayInVehicle, bPlayer == " + bPlayer);

            if (bPlayer)
                MissionData.bDontPull = true;

            Peddy.CanBeDraggedOutOfVehicle = false;
        }
        private void MultiBlimbs(Vector3 Vblips, int Bsp, bool bClean, string sName)
        {
            LoggerLight.LogThis("FakeBlimbs");

            if (bClean)
            {
                for (int i = 0; i < MissionData.BlipList_01.Count; i++)
                    ObjectHand.SafeCleaning(MissionData.BlipList_01[i].Handle, true, 1, true);

                MissionData.BlipList_01.Clear();
            }
            Blip Blippy = World.CreateBlip(Vblips);
            if (Bsp != -1)
                ObjectHand.TaggetIcon(Blippy, Bsp);

            if (sName == "")
                Function.Call(Hash.SET_BLIP_DISPLAY, Blippy.Handle, 8);
            else
                ObjectHand.BlipNames(Blippy, sName);

            Blippy.IsFlashing = true;
            MissionData.BlipList_01.Add(new Blip(Blippy.Handle));
            ObjectHand.ReadWriteBlips(false, true, Blippy.Handle, -1, -1, -1, -1, -1);
        }
        private void DogFighterTracking()
        {
            MissionData.iWait4Sec = Game.GameTime + 1000;
            for (int i = 0; i < MissionData.MultiPed.Count; i++)
            {
                if (!MissionData.MultiPed[i].MyPed.IsInVehicle() || MissionData.MultiPed[i].MyPed.IsDead || MissionData.MultiPed[i].MyVehicle.IsDead || MissionData.MultiPed[i].MyVehicle.IsOnFire)
                {
                    if (MissionData.MultiPed[i].MyBlip.Exists())
                        MissionData.MultiPed[i].MyBlip.Remove();
                    MissionData.MultiPed[i].MyVehicle.Explode();
                    MissionData.VehicleList_01.Remove(MissionData.MultiPed[i].MyVehicle);
                    MissionData.MultiPed[i].MyVehicle.MarkAsNoLongerNeeded();
                    MissionData.PedList_01.Remove(MissionData.MultiPed[i].MyPed);
                    MissionData.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                    MissionData.MultiPed.RemoveAt(i);
                    MissionData.iUltPed01 += 1;
                    ObjectHand.AddDogFighters(1);
                }
            }
        }
        private void ClearTheWay(bool bExtra)
        {
            Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
            Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

            Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
            Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

            Entity[] Entz = World.GetAllEntities();
            if (iClearing < Game.GameTime && bExtra)
            {
                iClearing = Game.GameTime + 1000;
                for (int i = 0; i < Entz.Count(); i++)
                {
                    Entity Ent = Entz[i];
                    if (ReturnStuff.EntityExists(Entz, i))
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_A_PED, Ent.Handle) && Ent.IsPersistent == false)
                            Ent.Delete();
                        if (Function.Call<bool>(Hash.IS_ENTITY_A_VEHICLE, Ent.Handle) && Ent.IsPersistent == false)
                            Ent.Delete();
                    }
                }
            }

        }
        private void YourFired(float fX, float fY, float fZ)
        {
            LoggerLight.LogThis("YourFired");

            MultiBlimbs(new Vector3(fX, fY, fZ), 436, true, DataStore.MyLang.Maptext[116]);
            int UFire = Function.Call<int>(Hash.START_SCRIPT_FIRE, fX, fY, fZ, 15, false);
            MissionData.iFireList.Add(UFire);
        }
        public Prop BoxingClever()
        {
            Prop ThisPhone = null;
            List<Prop> PhoneList = new List<Prop>();
            Prop[] StreetPhone = World.GetNearbyProps(Game.Player.Character.Position, 50.00f);
            for (int i = 0; i < StreetPhone.Count(); i++)
            {
                if (ReturnStuff.PropExists(StreetPhone, i))
                {
                    for (int ii = 0; ii < DataStore.sPhoneType.Count; ii++)
                    {
                        if (StreetPhone[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sPhoneType[ii]))
                        {
                            bool bAddThis = true;
                            for (int iii = 0; iii < DataStore.vOldPhoneBoxList.Count; iii++)
                            {
                                if (StreetPhone[i].Position.DistanceTo(DataStore.vOldPhoneBoxList[iii]) < 3.00f)
                                {
                                    bAddThis = false;
                                    break;
                                }
                            }
                            if (bAddThis)
                                PhoneList.Add(new Prop(StreetPhone[i].Handle));
                        }
                    }
                }
            }
            for (int i = 0; i < PhoneList.Count; i++)
            {
                if (PhoneList[i].Health > 850)
                {
                    PhoneList[i].IsPersistent = true;
                    ThisPhone = PhoneList[i];
                    break;
                }
            }
            return ThisPhone;
        }
        private void AnswerYourPhone(Prop ThisPhone)
        {
            LoggerLight.LogThis("AnswerYourPhone");

            DataStore.vPhoneCorona = ThisPhone.Position - (ThisPhone.ForwardVector * 1);
            float fHigh = World.GetGroundHeight(DataStore.vPhoneCorona);
            if (ReturnStuff.BeInRange(1.5f, fHigh, ThisPhone.Position.Z))
                DataStore.vPhoneCorona = ReturnStuff.SetZHight(DataStore.vPhoneCorona, fHigh);
            else
                DataStore.vPhoneCorona = ReturnStuff.AlterZHight(DataStore.vPhoneCorona,- 0.5f);
            if (DataStore.MySettings.PhoneCone)
            {
                PhoneBlip = GTA.World.CreateBlip(DataStore.vPhoneCorona);
                ObjectHand.TaggetIcon(PhoneBlip, 817);
                PhoneBlip.Color = BlipColor.Green2;
                PhoneBlip.Scale = 0.80f;
                ObjectHand.ReadWriteBlips(false, true, PhoneBlip.Handle, -1, -1, -1, -1, -1);
            }
        }
        private void PlayerWarpToWaypoint(Vector3 YoWayz, bool bVehicle)
        {
            Game.Player.Character.FreezePosition = true;
            Vector3 vWarpTo = YoWayz;
            int iWarpLoops = 10;
            Game.FadeScreenOut(1000);
            Script.Wait(1000);
            if (bVehicle)
            {
                if (Game.Player.Character.IsInVehicle())
                    Game.Player.Character.CurrentVehicle.Position = vWarpTo;
                else
                    Game.Player.Character.Position = vWarpTo;
            }
            else
                Game.Player.Character.Position = vWarpTo;
            Script.Wait(2000);
            vWarpTo.Z = World.GetGroundHeight(new Vector2(vWarpTo.X, vWarpTo.Y));
            if (bVehicle)
            {
                if (Game.Player.Character.IsInVehicle())
                    Game.Player.Character.CurrentVehicle.Position = vWarpTo;
                else
                    Game.Player.Character.Position = vWarpTo;
            }
            else
                Game.Player.Character.Position = vWarpTo;
            Game.FadeScreenIn(1000);
            Game.Player.Character.FreezePosition = false;
            Script.Wait(1000);
            while (Game.Player.Character.IsInAir || Game.Player.Character.Position.Z < World.GetGroundHeight(new Vector2(Game.Player.Character.Position.X, Game.Player.Character.Position.Y)))
            {
                Script.Wait(100);
                iWarpLoops -= 1;
                if (iWarpLoops > 1)
                    PlayerWarpToWaypoint(YoWayz, bVehicle);
            }

        }
        private void ZancudaClosed()
        {
            LoggerLight.LogThis("ZancudaClosed");

            Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
            while (!Function.Ca﻿ll<bool>(Hash.HAS_SCRIPT_LOADED, "restrictedareas"))
                Script.Wait(1);
            Function.Call﻿(Hash.START_NEW_SCRIPT﻿, "restrictedareas", 1424);
            Fun﻿ction.Call(Hash.SET_SCRIPT_AS_NO_LONGER_NEEDED, "restrictedareas");
        }
        private void PlaySoundFrom(string sAudioBank, string sSound, string sSoundSet, Vector3 Vposy, bool bPhone)
        {
            LoggerLight.LogThis("PlaySoundFrom, bPhone == " + bPhone);

            while (!Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, sAudioBank, false))
                Script.Wait(1);
            iPhonedID = Function.Call<int>(Hash.GET_SOUND_ID);
            if (bPhone)
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, iPhonedID, sSound, Vposy.X, Vposy.Y, Vposy.Z, 0, 0, 50, 0);
            else
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, iPhonedID, sSound, Vposy.X, Vposy.Y, Vposy.Z, sSoundSet, 0, 0, 0);

            ObjectHand.ReadWriteBlips(false, true, -1, -1, -1, -1, -1, iPhonedID);
        }
        private void LaunchTest()
        {
            DataStore.bBuildMode = false;
            Game.Player.IsInvincible = false;
            Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_FAR_DRAW_VEHICLES, true);
            Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, false);

            UiDisplay.CloseBaseHelpBar();

            ObjectHand.ClearOutAllStuff();

            MissionData.VectorList_01.Clear();
            MissionData.fList_01.Clear();

            MissionData.bTestRun = true;
        }
        private void ExitBuilders()
        {
            UiDisplay.CloseBaseHelpBar();
            ObjectHand.ClearOutAllStuff();
            ObjectHand.PostMess();

            MissionData.MyMissions.TruckersXM.Clear();
            MissionData.MyMissions.ConsXM.Clear();
            MissionData.MyMissions.PackersXM.Clear();
            MissionData.MyMissions.FubardXM.Clear();
            MissionData.MyMissions.AmbuXM.Clear();
            MissionData.MyMissions.JohnsXM.Clear();
            MissionData.MyMissions.RaceXM.Clear();
            MissionData.MyMissions.BombXM.Clear();
            MissionData.MyMissions.HitXM.Clear();
            MissionData.MyMissions.SharksXM.Clear();

            DataStore.bBuildMode = false;
            MissionData.iBuildMode = 99;
        }
        private void QuickSub(string sTing)
        {
            UI.Notify(sTing);
        }
        private void SetTheTime(int Hours, int Minites, int Seconds)
        {
            Function.Call(Hash.SET_CLOCK_TIME, Hours, Minites, Seconds);
        }
        private void MissingApps()
        {
            iAppScaner = Game.GameTime + 1000;
            for (int i = 0; i < DataStore.AppMadness.Count; i++)
            {
                if (Game.Player.Character.Position.DistanceTo(DataStore.AppMadness[i]) < 40.00f)
                {
                    ObjectHand.AppeyNess(DataStore.AppMadness[i]);
                    DataStore.AppMadness.RemoveAt(i);
                }
            }
        }
        private void InteriorRadar(int interior, Vector3 Vos)
        {
            Function.Call(Hash.SET_RADAR_AS_INTERIOR_THIS_FRAME, interior, Vos.X, Vos.Y, 0, 0);
        }
        private void PickUpThePhone()
        {
            float fThisWay = MissionData.fphdirect - 88.00f;
            int iTFuckedUp = Game.GameTime + 12000;
            Game.Player.Character.FreezePosition = true;
            Script.Wait(500);
            Game.Player.Character.FreezePosition = false;
            ObjectHand.WalkThisWay(Game.Player.Character, DataStore.vPhoneCorona, 1.00f);
            Script.Wait(2500);
            Game.Player.Character.Task.AchieveHeading(fThisWay, -1);
            while (!ReturnStuff.BeInAngle(2.50f, fThisWay, Game.Player.Character.Heading) && Game.GameTime < iTFuckedUp)
            {
                Game.Player.Character.Task.AchieveHeading(fThisWay, -1);
                Script.Wait(1000);
            }
            ObjectBuild.ForceAnimOnce(Game.Player.Character, "oddjobs@assassinate@multi@call", "ass_multi_target_call_p1", Game.Player.Character.Position, Game.Player.Character.Rotation);
            Script.Wait(4000);
            MissionData.bPickUpHangUp = true;
        }
        private void MissionTime()
        {
            if (Function.Call<bool>(Hash.IS_PLAYER_DEAD) || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED) || Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
                MissionData.iMissionSeq = 45;

            if (MissionData.iJobType == 1)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    MissionData.iMishText = 0;

                    if (MissionData.iMissionVar_01 > 0)
                        TheMissions.Trucking_Attachments(MissionData.iMissionVar_01);

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);

                    MissionData.iMissionVar_01 = 0;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 2;
                        TheMissions.Trucking_CashNCrash();
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                        MissionData.iMishText = 2;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 35.00f)
                    {
                        MissionData.iMishText = 1;

                        if (MissionData.BeOff[0])
                        {
                            if (!MissionData.VehTrackin_01.IsOnAllWheels)
                            {
                                ObjectBuild.StayOnGround(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01.Heading = MissionData.fMission_02;
                            }
                            ObjectBuild.StayOnGround(MissionData.VehTrackin_02);
                            MissionData.VehTrackin_02.Heading = MissionData.fMission_01;
                            MissionData.BeOff[0] = false;
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, Game.Player.Character.Position) < 5.00f && MissionData.BeOnOff[4])
                        {
                            UiDisplay.ControlerUI("~INPUT_DETONATE~ " + ReturnStuff.GetEntName(MissionData.sList_01[MissionData.iMissionVar_01]) + " ~INPUT_CONTEXT~", 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (MissionData.iMissionVar_01 > 0)
                                    MissionData.iMissionVar_01 -= 1;
                                else
                                    MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;
                                float fHeader = MissionData.VehTrackin_01.Heading;
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.VehTrackin_01.Delete();
                                ObjectBuild.VehicleSpawn(MissionData.sList_01[MissionData.iMissionVar_01], MissionData.vTarget_02, fHeader, false, false, true, false, 0, 0, 66, DataStore.MyLang.Maptext[1], 1, MissionData.BeOnOff[5]);
                            }
                            else if (Game.IsControlJustPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iMissionVar_01 + 1 < MissionData.sList_01.Count)
                                    MissionData.iMissionVar_01 += 1;
                                else
                                    MissionData.iMissionVar_01 = 0;
                                float fHeader = MissionData.VehTrackin_01.Heading;
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.VehTrackin_01.Delete();
                                ObjectBuild.VehicleSpawn(MissionData.sList_01[MissionData.iMissionVar_01], MissionData.vTarget_02, fHeader, false, false, true, false, 0, 0, 66, DataStore.MyLang.Maptext[22], 1, MissionData.BeOnOff[5]);
                            }
                        }
                    }
                    else
                        MissionData.iMishText = 0;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = false;
                                MissionData.iMishText = 2;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                            }
                            if (!MissionData.VehTrackin_02.IsOnAllWheels && MissionData.iTime_01[0] < Game.GameTime)
                                TheMissions.Trucking_LostTrail();
                            else if (MissionData.VehTrackin_02.IsAttached())
                            {
                                MissionData.iMissionSeq = 3;
                                MissionData.BeOnOff[2] = true;
                                MissionData.BeOnOff[1] = true;
                                MissionData.VehTrackin_02.FreezePosition = false;
                                MissionData.VehTrackin_02.CurrentBlip.Remove();
                                MissionData.VehTrackin_02.Repair();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 479, DataStore.MyLang.Maptext[39]);
                                MissionData.vLanLoc = MissionData.vTarget_01;
                                MissionData.iMishText = 3;
                            }
                        }
                        else
                        {
                            if (!MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = true;
                                ObjectHand.RemoveTargets();
                                MissionData.iMishText = 1;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[1]);
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.BeOnOff[3] && World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_02.Position) < 90.0f)
                    {
                        if (MissionData.VehTrackin_03.HasCollision)
                            MissionData.VehTrackin_03.HasCollision = false;

                        MoveThatCar(MissionData.vTarget_01);
                        ObjectBuild.GhostVehicle(MissionData.VehTrackin_03, MissionData.vTarget_01, MissionData.fMission_03);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 10.00f);
                        MissionData.BeOnOff[3] = false;
                    }

                    MissionData.iCashReward = ReturnStuff.MultiDamage(MissionData.iCrash4Cash, true, MissionData.iCashReward, true, true);

                    if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead || MissionData.iCashReward < 0)
                            MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_02.Position) < 10.00f)
                    {
                        if (MissionData.VehTrackin_03.HasCollision)
                            MissionData.VehTrackin_03.HasCollision = false;
                        else if (Game.Player.Character.IsInVehicle() && MissionData.VehTrackin_02.IsAttached())
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[14], 1);
                        else
                        {
                            float fParking = MissionData.VehTrackin_02.Position.DistanceTo(MissionData.VehTrackin_03.Position) * 5;
                            fParking = fParking + MissionData.VehTrackin_02.Rotation.DistanceTo(MissionData.VehTrackin_03.Rotation) * 10;
                            int iPkBouns = (int)fParking;
                            MissionData.iCashBouns = 1000 - iPkBouns;
                            if (MissionData.iCashBouns < 0)
                                MissionData.iCashBouns = 0;
                            MissionData.VehTrackin_01.EngineRunning = false;
                            ObjectHand.RemoveTargets();
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = -1;
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = false;
                                MissionData.vLanLoc = MissionData.vTarget_01;
                                MissionData.iMishText = 3;
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 479, DataStore.MyLang.Maptext[39]);
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                            }
                        }
                        else
                        {
                            if (!MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = true;
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 1;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 3, DataStore.MyLang.Maptext[1]);
                            }
                        }

                        if (MissionData.BeOnOff[2])
                        {
                            if (!MissionData.VehTrackin_02.IsAttached())
                            {
                                MissionData.BeOnOff[2] = false;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_02, true, true, 3, DataStore.MyLang.Maptext[2]);
                                MissionData.iTime_01[1] = Game.GameTime + 45000;
                                UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_02);
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 2;
                            }
                        }
                        else
                        {
                            if (!MissionData.VehTrackin_02.IsOnAllWheels && MissionData.iTime_01[0] < Game.GameTime)
                                TheMissions.Trucking_LostTrail();
                            else if (MissionData.VehTrackin_02.IsAttached())
                            {
                                MissionData.BeOnOff[2] = true;
                                MissionData.vLanLoc = MissionData.vTarget_01;
                                MissionData.iMishText = 3;
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 479, DataStore.MyLang.Maptext[39]);
                                MissionData.VehTrackin_02.CurrentBlip.Remove();
                                UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
                            }
                            else if (MissionData.iTime_01[1] > Game.GameTime)
                            {
                                int iTimeLeft = MissionData.iTime_01[1] - Game.GameTime;
                                ObjectHand.FindTheTime(iTimeLeft, 9, "", true);
                            }
                            else
                                MissionData.iMissionSeq = 45;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    MissionData.VehTrackin_03.Delete();
                    MissionData.VehicleList_01.Remove(MissionData.VehTrackin_03);
                    MissionData.VehTrackin_01.FreezePosition = true;
                    Script.Wait(1000);
                    ObjectBuild.GetOutofVeh(Game.Player.Character, 1);
                    MissionData.VehTrackin_01.FreezePosition = false;
                    MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Locked;
                    MissionData.iCashReward += MissionData.iCashBouns;

                    if (!MissionData.bTestRun)
                        ObjectHand.NSCoinInvestments(true, 4, 6, "Big G Goods Shares");
                    if (MissionData.iCashBouns > 0)
                        TheMissions.GameOver(false, "Parking Bouns: $" + MissionData.iCashBouns + ", ", false, MissionData.iCashReward);
                    else
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (!MissionData.bTestRun)
                        ObjectHand.NSCoinInvestments(false, 5, 7, "Big G Goods Shares");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }        //Truckin
            else if (MissionData.iJobType == 2)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    Function.Call((Hash)0xDC0F817884CDD856, 2, false);
                    Function.Call((Hash)0xDC0F817884CDD856, 4, true);
                    Function.Call((Hash)0xDC0F817884CDD856, 8, true);
                    Function.Call((Hash)0xDC0F817884CDD856, 12, false);

                    UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.VerticalCylinder, MarkPos = MissionData.vTarget_01, MarkDir = Vector3.Zero, MarkRot = Vector3.Zero, MarkScale = new Vector3(5.0f, 5.0f, 5.0f), MarkCol = Color.Yellow };

                    StayInVehicle(Game.Player.Character, true);
                    MissionData.iWait4Sec = Game.GameTime + 5000;
                    MissionData.BeOnOff[4] = false;

                    MissionData.iMishText = 4;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle())
                    {
                        if (MissionData.BeOnOff[6])
                        {
                            if (!Game.Player.Character.IsInVehicle())
                            {
                                MissionData.BeOnOff[6] = false;
                                ObjectHand.RemoveTargets();
                                MissionData.VehTrackin_05.IsPersistent = false;
                                UiDisplay.bMMDisplay01 = false;
                                MissionData.BeOff[0] = true;
                                MissionData.iMishText = 4;
                            }
                            else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 75.00f)
                            {
                                if (MissionData.BeOff[0])
                                {
                                    MissionData.iMishText = 5;
                                    MissionData.BeOff[0] = false;
                                }

                                if (MissionData.BeOnOff[3])
                                {
                                    MoveThatCar(MissionData.vTarget_01);
                                    MissionData.BeOnOff[3] = false;
                                }
                                if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 3.0f)
                                {
                                    if (MissionData.VehTrackin_05.IsStopped)
                                    {
                                        MissionData.iMissionSeq = 2;
                                        MissionData.BeOnOff[5] = true;

                                        UiDisplay.bMMDisplay01 = false;
                                        PlaySoundFrom("Alarms", "Burglar_Bell", "Generic_Alarms", MissionData.vTarget_03, false);
                                        ObjectHand.DoorsNear(MissionData.vTarget_03, 5.00f, false);
                                        MissionData.iMishText = -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (MissionData.BeOnOff[0] || Game.Player.Character.CurrentVehicle.ClassType != VehicleClass.Helicopters)
                            {
                                if (Game.Player.Character.CurrentVehicle.IsSeatFree(VehicleSeat.LeftRear))
                                {
                                    MissionData.VehTrackin_05 = Game.Player.Character.CurrentVehicle;

                                    UiDisplay.bMMDisplay01 = true;
                                    MissionData.BeOnOff[6] = true;
                                    MissionData.VehTrackin_05.IsPersistent = true;
                                    ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 207, DataStore.MyLang.Maptext[40]);
                                    MissionData.iMishText = 6;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MissionData.BeOnOff[6])
                        {
                            MissionData.BeOnOff[6] = false;
                            MissionData.VehTrackin_05.IsPersistent = false;
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 4;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (!MissionData.BeOnOff[1])
                    {
                        if (MissionData.VehTrackin_05.IsInvincible)
                        {
                            MissionData.BeOnOff[1] = true;
                            TheMissions.Getaway_CarSwap(MissionData.VehTrackin_05);
                        }
                        else
                        {
                            MissionData.iMissionSeq = 3;
                            ObjectHand.RemoveTargets();
                            World.AddExplosion(MissionData.vTarget_03, ExplosionType.Flare, 1.0f, 0.0f);
                            Vehicle PlVeh = Game.Player.Character.CurrentVehicle;
                            MissionData.iWait4Sec = Game.GameTime + 15000;
                            PlVeh.EngineRunning = false;
                            PlVeh.IsExplosionProof = false;
                            PlVeh.IsOnlyDamagedByPlayer = false;
                            PlVeh.IsFireProof = false;
                            MissionData.VehicleList_01.Add(new Vehicle(PlVeh.Handle));
                            TheMissions.Getaway_FearInBank();
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead || MissionData.VehTrackin_05.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_05) && MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_05) && MissionData.Npc_03.IsInVehicle(MissionData.VehTrackin_05))
                    {
                        MissionData.iMissionSeq = 4;

                        TheMissions.Getaway_RobDaBank();
                        MissionData.iMishText = 7;
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (!MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_05))
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_05, MissionData.Npc_01, 2);
                        if (!MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_05))
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_05, MissionData.Npc_02, 3);
                        if (!MissionData.Npc_03.IsInVehicle(MissionData.VehTrackin_05))
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_05, MissionData.Npc_03, 4);
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead || MissionData.VehTrackin_05.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[5])
                    {
                        if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) > 80.0f)
                        {
                            MissionData.BeOnOff[5] = false;
                            ObjectHand.SafeCleaning(iPhonedID, true, 5, true);
                        }
                        else if (Game.Player.WantedLevel < 3)
                            Game.Player.WantedLevel = 5;
                    }
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.WantedLevel > 0)
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.iMishText = 7;
                            ObjectHand.RemoveTargets();
                        }
                        else if (!Game.Player.Character.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, Game.Player.Character.Position) < 3.0f)
                        {
                            MissionData.iMissionSeq = 5;
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_05.IsDriveable = false;
                            MissionData.BeOnOff[7] = false;
                            ObjectBuild.ArmsRegulator(Game.Player.Character, 6);
                            StopHere(MissionData.VehTrackin_05);
                            MissionData.iMishText = 9;
                        }
                    }
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_05))
                    {
                        if (Game.Player.WantedLevel == 0)
                        {
                            UiDisplay.TheYellowCorona(MissionData.vTarget_02, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 440, DataStore.MyLang.Maptext[41]);
                            MissionData.BeOnOff[4] = true;
                            MissionData.iMishText = 8;
                        }
                    }
                    else
                        MissionData.iMissionSeq = 45;

                    if (MissionData.BeOnOff[7])
                    {
                        MissionData.iCashReward = ReturnStuff.MultiDamage(MissionData.iMissionVar_03, true, MissionData.iCashReward, true, false);

                        if (MissionData.BeOnOff[2])
                            MissionData.BeOnOff[2] = false;
                        else
                        {
                            if (MissionData.iCashReward != MissionData.iCashBouns)
                            {
                                MissionData.iCashBouns = MissionData.iCashReward;
                                MissionData.BeOnOff[8] = true;
                                if (MissionData.iTime_01[0] == 0)
                                    MissionData.iTime_01[0] = Game.GameTime + 500;
                            }
                        }

                        if (MissionData.BeOnOff[8])
                        {
                            if (MissionData.BeOnOff[9])
                            {
                                if (Game.GameTime > MissionData.iTime_01[0])
                                {
                                    if (MissionData.iFireList.Count > 0)
                                    {
                                        Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, MissionData.iFireList[MissionData.iFireList.Count - 1], true);
                                        MissionData.iFireList.RemoveAt(MissionData.iFireList.Count - 1);
                                    }
                                    else
                                    {
                                        MissionData.iTime_01[0] = 0;
                                        MissionData.BeOnOff[9] = false;
                                        MissionData.BeOnOff[8] = false;
                                    }
                                }
                            }
                            else
                            {
                                if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_xs_celebration"))
                                {
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_xs_celebration");
                                    int iPart = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_xs_money_rain", MissionData.VehTrackin_05.Handle, 0.40f, 0.40f, 0.50f, 0.00f, 0.00f, 0.00f, 1.00f, false, true, false);
                                    Function.Call(Hash.SET_PARTICLE_FX_LOOPED_ALPHA, iPart, 1.00f);
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_xs_celebration");
                                    int iPart1 = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_xs_money_rain", MissionData.VehTrackin_05.Handle, -0.40f, -0.40f, 0.50f, 0.00f, 0.00f, 0.00f, 1.00f, false, true, false);
                                    Function.Call(Hash.SET_PARTICLE_FX_LOOPED_ALPHA, iPart1, 1.00f);
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_xs_celebration");
                                    int iPart2 = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_xs_money_rain", MissionData.VehTrackin_05.Handle, 0.40f, -0.40f, 0.50f, 0.00f, 0.00f, 0.00f, 1.00f, false, true, false);
                                    Function.Call(Hash.SET_PARTICLE_FX_LOOPED_ALPHA, iPart2, 1.00f);

                                    MissionData.iFireList.Add(iPart);
                                    MissionData.iFireList.Add(iPart1);
                                    MissionData.iFireList.Add(iPart2);
                                    MissionData.BeOnOff[9] = true;
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_xs_celebration");
                                }
                            }
                        }

                        if (MissionData.iCashReward < 0)
                            MissionData.iMissionSeq = 45;
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.VehicleList_01.Count > 1)
                    {
                        MissionData.iMissionSeq = 6;
                        ObjectHand.RemoveTargets();
                        UiDisplay.bUiDisplay = false;
                        ObjectBuild.GetOutofVeh(Game.Player.Character, 1);
                        MissionData.VehTrackin_05.FreezePosition = false;
                        MissionData.VehTrackin_01.IsInvincible = false;
                        MissionData.VehTrackin_01.FreezePosition = false;
                        ReturnStuff.VehBlip(MissionData.VehTrackin_05, true, false, 1, DataStore.MyLang.Maptext[14]);
                        ObjectHand.Groupies(false);
                        ObjectBuild.GetOutofVeh(MissionData.Npc_01, 1);
                        ObjectBuild.GetOutofVeh(MissionData.Npc_02, 1);
                        ObjectBuild.GetOutofVeh(MissionData.Npc_03, 1);
                        MissionData.iWait4Sec = Game.GameTime + 500;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 7;
                        ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_01, 0, 2.00f);
                        ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_02, 1, 2.00f);
                        ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_03, 2, 2.00f);
                        MissionData.iWait4Sec = Game.GameTime + 10000;
                    }
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 10;
                        if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_01) == false)
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_01, 1);
                        if (MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_01) == false)
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_02, 2);
                        if (MissionData.Npc_03.IsInVehicle(MissionData.VehTrackin_01) == false)
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_03, 3);
                    }
                    else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_01) && MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_01) && MissionData.Npc_03.IsInVehicle(MissionData.VehTrackin_01))
                        MissionData.iMissionSeq = 10;
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_01) && MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_01) && MissionData.Npc_03.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        if (MissionData.BeOnOff[10])
                        {
                            MissionData.BeOnOff[10] = false;
                            Function.Call(Hash.TASK_PLANE_MISSION﻿, MissionData.Npc_01, MissionData.VehTrackin_01, 0, 0, -2352.11f, 2274.94f, 500.0f, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                        }
                        else if (MissionData.VehTrackin_05.IsOnFire || MissionData.VehTrackin_05.IsDead)
                        {
                            MissionData.iCashReward = MissionData.iCashReward / 4;
                            MissionData.VehTrackin_05.Explode();
                            Function.Call((Hash)0xDC0F817884CDD856, 2, true);
                            Function.Call((Hash)0xDC0F817884CDD856, 12, true);
                            MissionData.sMissionVar_01 = "empty";
                            MissionData.sMissionVar_02 = "empty";
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                            MissionData.iMishText = -1;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.Groupies(false);
                    Function.Call((Hash)0xDC0F817884CDD856, 2, true);
                    Function.Call((Hash)0xDC0F817884CDD856, 12, true);

                    if (MissionData.BeOnOff[9])
                        TheMissions.Getaway_StopLoss();
                    if (MissionData.BeOnOff[5])
                    {
                        MissionData.BeOnOff[5] = false;
                        ObjectHand.SafeCleaning(iPhonedID, true, 5, true);
                    }
                    MissionData.sMissionVar_01 = "empty";
                    MissionData.sMissionVar_02 = "empty";
                    TheMissions.GameOver(true, "", false, 0);
                }
            }        //GetAwayDriver
            else if (MissionData.iJobType == 3)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (MissionData.VehicleList_01.Count > 0)
                    {
                        MissionData.iMissionSeq = 1;
                        MissionData.BeOnOff[2] = true;

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                        MissionData.iMishText = 10;

                        if (MissionData.BeOnOff[3])
                            TheMissions.Packages_LiveExport();
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 2;
                        MissionData.BeOnOff[2] = true;
                        MissionData.BeOnOff[4] = false;
                        MissionData.iMissionVar_02 = MissionData.VectorList_01.Count - 1;
                        MissionData.iMissionVar_03 = MissionData.VectorList_01.Count;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_02];
                        MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                        MissionData.iMishText = 13;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 35.00f)
                    {
                        if (MissionData.iLocationX == 6)
                            MissionData.iMishText = 11;
                        else
                            MissionData.iMishText = 12;

                        if (!MissionData.VehTrackin_01.IsOnAllWheels)
                        {
                            MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                            MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                        }
                    }
                    else
                        MissionData.iMishText = 10;

                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 95.00f && MissionData.BeOnOff[4])
                    {
                        if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 2.00f && Game.Player.Character.IsOnFoot && ReturnStuff.BeInRange(Game.Player.Character.Position.Z, MissionData.vTarget_01.Z, 0.50f))
                        {
                            MissionData.iMissionSeq = 3;
                            if (!MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = true;
                                UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_02);
                                MissionData.iTime_01[1] = Game.GameTime + MissionData.iTime_01[0];
                            }
                            MissionData.iWait4Sec = Game.GameTime + 2000;
                            Game.Player.Character.Task.PlayAnimation("anim@mp_fireworks", "place_firework_3_box", 8.00f, 3000, true, 1.00f);
                            MissionData.BeOnOff[2] = true;
                            MissionData.iTime_01[2] = MissionData.iTime_01[1] - Game.GameTime;
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else if (MissionData.BeOnOff[2])
                    {
                        if (MissionData.iLocationX == 6)
                            MissionData.iMishText = 11;
                        else
                            MissionData.iMishText = 12;

                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[2] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.BeOnOff[4] = true;
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 478, DataStore.MyLang.Maptext[42]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                            MissionData.iMishText = 13;
                        }
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle() && !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01) && MissionData.Target_01 != null)
                        {
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[3]);
                            MissionData.iMishText = 12;
                            MissionData.BeOnOff[2] = true;
                        }
                    }
                    if (MissionData.BeOnOff[0])
                    {
                        if (MissionData.iTime_01[1] > Game.GameTime)
                        {
                            int iNumber = 0;
                            iNumber = MissionData.iMissionVar_02 + 1;
                            UiDisplay.ttTextBar_01.Text = "" + iNumber + "/" + MissionData.iMissionVar_03 + "";

                            int iTotal = MissionData.iTime_01[1] - Game.GameTime;
                            ObjectHand.FindTheTime(iTotal, 9, "", true);
                        }
                        else
                        {
                            MissionData.iMissionSeq = 4;
                            if (Game.Player.Character.IsInVehicle())
                            {
                                ObjectHand.RemoveTargets();
                                MissionData.BeOnOff[2] = true;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 46, DataStore.MyLang.Maptext[3]);
                            }

                            if (!UiDisplay.bUiDisplay)
                                UiDisplay.bUiDisplay = true;
                        }
                    }
                    else
                    {
                        int iNumber = MissionData.iMissionVar_02 + 1;
                        UiDisplay.ttTextBar_01.Text = "" + iNumber + "/" + MissionData.iMissionVar_03 + "";

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (MissionData.BeOnOff[3])
                        {
                            ObjectBuild.NPCSpawn("a_c_hen", MissionData.vTarget_01, 0.00f, false, 150, 0, 0, null, 0, false, 0, 0, "");

                            MissionData.PedList_01[0].Delete();
                            MissionData.PedList_01.RemoveAt(0);
                        }
                        else
                        {
                            if (DataStore.bOnCayoLand)
                                MissionData.sMissionVar_01 = MissionData.sCayoPacks[MissionData.iMissionVar_02];

                            ObjectBuild.BuildProp(MissionData.sMissionVar_01, MissionData.vTarget_01, Vector3.Zero, false, false);
                        }
                        ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[3]);
                        if (MissionData.iMissionVar_02 > 0)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.iTime_01[1] += 25000;
                            MissionData.BeOnOff[4] = false;
                            MissionData.iMissionVar_02 -= 1;
                            MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_02];
                            MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                        }
                        else
                        {
                            MissionData.iTime_01[1] += 45000;
                            MissionData.BeOnOff[1] = true;
                            MissionData.iMissionSeq = 4;
                        }

                        if (MissionData.iLocationX == 6)
                            MissionData.iMishText = 11;
                        else
                            MissionData.iMishText = 12;
                    }
                    else
                    {
                        UiDisplay.ttTextBar_01.Text = "" + MissionData.iMissionVar_02 + "/" + MissionData.iMissionVar_03 + "";

                        int iTotal = MissionData.iTime_01[2];
                        ObjectHand.FindTheTime(iTotal, 9, "", true);
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_05, MissionData.VehTrackin_01.Position) < MissionData.fCorSize)
                    {
                        ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                        MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Locked;
                        ObjectHand.RemoveTargets();
                        MissionData.iMishText = -1;
                        MissionData.iMissionSeq = 5;
                    }
                    else if (MissionData.BeOnOff[1] && World.GetDistance(MissionData.vTarget_05, Game.Player.Character.Position) < 60.00f)
                    {
                        MoveThatCar(MissionData.vTarget_05);
                        MissionData.BeOnOff[1] = false;
                    }
                    else if (MissionData.BeOnOff[2])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[2] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_05, true, true, 1.00f, false, 474, DataStore.MyLang.Maptext[43]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_05, MissionData.fCorSize);
                            MissionData.iMishText = 14;
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.BeOnOff[2] = true;
                            if (MissionData.iLocationX == 6)
                                MissionData.iMishText = 11;
                            else
                                MissionData.iMishText = 12;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[3]);
                        }
                    }

                    if (MissionData.iTime_01[1] > Game.GameTime)
                    {
                        UiDisplay.ttTextBar_01.Text = "" + MissionData.iMissionVar_02 + "/" + MissionData.iMissionVar_03 + "";

                        int iTotal = MissionData.iTime_01[1] - Game.GameTime;
                        ObjectHand.FindTheTime(iTotal, 9, "", true);
                    }
                    else
                    {
                        ObjectHand.FindTheTime(0, 9, "", true);
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    int iBounus = 0;
                    if (MissionData.iTime_01[1] > Game.GameTime)
                    {
                        iBounus = ReturnStuff.RandInt(1000, 1100) * MissionData.iMissionVar_03;
                        World.AddExplosion(MissionData.vTarget_05, ExplosionType.FireWork, 1.00f, 1.00f, true, false);
                    }

                    MissionData.iCashReward = MissionData.iMissionVar_03 * MissionData.iParcelCost + iBounus;

                    if (!MissionData.bTestRun)
                    {
                        int iHigh = 2;
                        int iLow = 1;
                        bool blose = false;
                        if (iBounus > 0)
                        {
                            iHigh = 5;
                            iLow = 3;
                            blose = true;
                        }
                        if (DataStore.bOnCayoLand)
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "Madrass Inc");
                        else if (MissionData.iLocationX == 1)
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "Post OP Shares");
                        else if (MissionData.iLocationX == 2)
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "GoPostal Shares");
                        else if (MissionData.iLocationX == 3)
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "Pop's Pills Shares");
                        else if (MissionData.iLocationX == 4)
                            ObjectHand.NSCoinInvestments(blose, iLow, iHigh, "Dollar Pills Shares");
                        else if (MissionData.iLocationX == 5)
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "Sunset Bleach Shares");
                        else
                            ObjectHand.NSCoinInvestments(true, iLow, iHigh, "Weazel Shares");
                    }
                    MissionData.iMissionVar_02 = MissionData.iMissionVar_03 - MissionData.iMissionVar_02;
                    TheMissions.GameOver(false, "" + DataStore.MyLang.Mistext[191] + "" + MissionData.iMissionVar_02 + "/" + MissionData.iMissionVar_03 + ", ", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (!MissionData.bTestRun)
                    {
                        if (MissionData.iLocationX == 1)
                            ObjectHand.NSCoinInvestments(false, 4, 6, "Post OP Shares");
                        else if (MissionData.iLocationX == 2)
                            ObjectHand.NSCoinInvestments(false, 5, 7, "GoPostal Shares");
                        else if (MissionData.iLocationX == 3)
                            ObjectHand.NSCoinInvestments(false, 3, 8, "Pop's Pills Shares");
                        else if (MissionData.iLocationX == 4)
                            ObjectHand.NSCoinInvestments(true, 7, 12, "Dollar Pills Shares");
                        else if (MissionData.iLocationX == 5)
                            ObjectHand.NSCoinInvestments(false, 5, 7, "Sunset Bleach Shares");
                        else
                            ObjectHand.NSCoinInvestments(false, 3, 5, "Weazel Shares");
                    }
                    TheMissions.GameOver(true, "", false, 0);
                }
            }        //Packages
            else if (MissionData.iJobType == 4)
            {
                if (MissionData.BeOnOff[0])
                {
                    Game.Player.WantedLevel = 0;
                    Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, false);
                    Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_prison");
                    Function.Call(Hash.STOP_ALARM, "PRISON_ALARMS", 0);
                    Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_GENERAL", 0);
                    Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_WARNING", 0);

                    TheMissions.CopKillerz();
                }

                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    StayInVehicle(Game.Player.Character, true);

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);

                    MissionData.iMishText = 51;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.VehTrackin_01.IsDead || Game.Player.WantedLevel > 0)
                        MissionData.iMissionSeq = 45;
                    else
                    {
                        if (MissionData.Target_01 == null)
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 188, DataStore.MyLang.Maptext[44]);
                                MissionData.vLanLoc = MissionData.vTarget_01;
                                MissionData.iMishText = 16;
                            }
                            else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 55.00f)
                            {
                                if (!MissionData.VehTrackin_01.IsOnAllWheels && MissionData.BeOff[0])
                                {
                                    MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                                    MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                                    MissionData.BeOff[0] = false;
                                }
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 15;
                            }
                            else
                            {
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 51;
                            }
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[4]);
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 15;
                            }
                            else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 90.0f)
                            {
                                MissionData.iMissionSeq = 2;
                                TheMissions.Convicts_DumpCons();
                                ObjectHand.RemoveTargets();
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    MissionData.iMissionSeq = 3;
                    ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[4]);
                    MissionData.vTarget_02 = new Vector3(1848.24f, 2608.52f, 44.59f);
                    MissionData.vTarget_03 = new Vector3(1823.44f, 2607.87f, 44.58f);
                    MissionData.vTarget_04 = new Vector3(1690.85f, 2601.41f, 44.56f);
                    MissionData.vTarget_05 = new Vector3(1846.57f, 2585.8f, 44.67f);//267.83
                    MissionData.vLanLoc = MissionData.vTarget_01;
                    MissionData.iMishText = 16;
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead || Game.Player.WantedLevel > 0)
                        MissionData.iMissionSeq = 45;
                    else
                    {
                        if (MissionData.BeOnOff[1])
                        {
                            if (World.GetDistance(MissionData.Npc_01.Position, Game.Player.Character.Position) > 40.0f)
                            {
                                MissionData.BeOnOff[1] = false;
                                DataStore.Hare.Stop();
                            }
                        }
                        else
                        {
                            if (World.GetDistance(MissionData.Npc_01.Position, Game.Player.Character.Position) < 30.0f)
                            {
                                MissionData.BeOnOff[1] = true;
                                DataStore.Hare.PlayLooping();
                            }
                        }

                        if (MissionData.VehTrackin_01.CurrentBlip.Exists())
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.vLanLoc = MissionData.vTarget_01;
                                MissionData.iMishText = 16;
                            }
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[4]);
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 15;
                            }
                            else if (Game.IsControlJustPressed(2, GTA.Control.VehicleHorn))
                            {
                                MissionData.iMissionSeq = 4;
                                MissionData.iTime_01[0] = Game.GameTime;
                                MissionData.BeOnOff[1] = false;
                                DataStore.Hare.Stop();
                                TheMissions.Convicts_KrishaToBus();
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 17;
                            }
                            else
                            {
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[15], 1);
                            }
                        }
                    }
                    TheMissions.Convicts_WalkLoop();
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle() || Game.Player.WantedLevel > 0)
                    {
                        Game.FadeScreenIn(100);
                        MissionData.iMissionSeq = 45;
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.BeOnOff[1])
                    {
                        if (Game.IsControlJustPressed(0, GTA.Control.VehicleHorn))
                        {
                            MissionData.BeOnOff[1] = false;
                            DataStore.Hare.Stop();
                            MissionData.iWait4Sec = Game.GameTime + 8000;
                        }
                    }
                    else
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.BeOnOff[1] = true;
                            DataStore.Hare.PlayLooping();
                        }
                    }

                    if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Target_01 == null)
                    {
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 526, DataStore.MyLang.Maptext[35]);
                    }
                    else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 3.0f)
                    {
                        MissionData.iMissionSeq = 6;
                        StopHere(MissionData.VehTrackin_01);
                        ObjectHand.RemoveTargets();

                        if (MissionData.BeOnOff[1])
                        {
                            MissionData.BeOnOff[1] = false;
                            DataStore.Hare.Stop();
                        }

                        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
                        MissionData.BeOnOff[0] = true;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    MissionData.iMissionSeq = 7;
                    GateIsNear(MissionData.vTarget_02, 20.0f, true);
                    ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 526, DataStore.MyLang.Maptext[35]);
                    UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                    MissionData.iWait4Sec = Game.GameTime + 12000;
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    if (Function.Call<bool>(Hash.IS_DOOR_CLOSED, MissionData.Prop_01.GetHashCode()))
                        Function.Call(Hash._DOOR_CONTROL, Function.Call<int>(Hash.GET_HASH_KEY, "prop_gate_prison_01"), MissionData.Prop_01.Position.X, MissionData.Prop_01.Position.Y, MissionData.Prop_01.Position.Z, false, 0.0f, 50.0f, 0.0f);

                    if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_03, MissionData.VehTrackin_01.Position) < 3.0f)
                    {
                        StopHere(MissionData.VehTrackin_01);
                        MissionData.iMissionSeq = 8;
                        ObjectHand.RemoveTargets();
                    }
                }
                else if (MissionData.iMissionSeq == 8)
                {
                    MissionData.iMissionSeq = 9;
                    GateIsNear(MissionData.vTarget_03, 20.0f, true);
                    ObjectHand.AddTarget(MissionData.vTarget_04, true, true, 1.00f, false, 526, DataStore.MyLang.Maptext[35]);
                    UiDisplay.TheYellowCorona(MissionData.vTarget_04, 5.00f);
                    MissionData.iWait4Sec = Game.GameTime + 12000;
                }
                else if (MissionData.iMissionSeq == 9)
                {
                    if (Function.Call<bool>(Hash.IS_DOOR_CLOSED, MissionData.Prop_01.GetHashCode()))
                        Function.Call(Hash._DOOR_CONTROL, Function.Call<int>(Hash.GET_HASH_KEY, "prop_gate_prison_01"), MissionData.Prop_01.Position.X, MissionData.Prop_01.Position.Y, MissionData.Prop_01.Position.Z, false, 0.0f, 50.0f, 0.0f);

                    if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_04, Game.Player.Character.Position) < 3.0f)
                    {
                        StopHere(MissionData.VehTrackin_01);
                        MissionData.iMissionSeq = 10;
                        ObjectHand.RemoveTargets();
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    ObjectHand.SlowFastTravel(MissionData.vTarget_05, 267.83f);
                    MissionData.iCashReward = (MissionData.iTime_01[0] - Game.GameTime) / 100 * -1;
                    if (MissionData.iCashReward > 10000)
                        MissionData.iCashReward = ReturnStuff.RandInt(9950, 9999);

                    DataStore.MyDatSet.iWantedBribe += 1;
                    RWDatFile.SaveDat(12, DataStore.MyDatSet.iWantedBribe);
                    Game.Player.IgnoredByPolice = false;
                    Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, true);
                    Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
                    Script.Wait(100);
                    if (Function.Ca﻿ll<bool>(Hash.HAS_SCRIPT_LOADED, "restrictedareas"))
                    {
                        Function.Call﻿(Hash.START_NEW_SCRIPT﻿, "restrictedareas", 1424);
                        Fun﻿ction.Call(Hash.SET_SCRIPT_AS_NO_LONGER_NEEDED, "restrictedareas");
                    }

                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 25)
                {
                    MissionData.iMissionSeq = 99;
                    MissionData.bGOURANGA = true;
                    MissionData.iCashReward = (MissionData.iTime_01[0] - Game.GameTime) / 10 * -1;
                    if (MissionData.iCashReward > 5000)
                        MissionData.iCashReward = ReturnStuff.RandInt(4950, 4999);
                    TheMissions.GameOver(false, "", true, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (MissionData.BeOnOff[1])
                        DataStore.Hare.Stop();

                    if (MissionData.BeOnOff[0])
                    {
                        MissionData.BeOff[2] = false;
                        ObjectHand.SlowFastTravel(MissionData.vTarget_05, 267.83f);
                        Game.Player.WantedLevel = 0;
                        Game.Player.IgnoredByPolice = false;
                        Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, true);
                        ZancudaClosed();
                        Script.Wait(100);
                    }
                    TheMissions.GameOver(true, "", false, 0);
                }
            }        //Convicts
            else if (MissionData.iJobType == 5)
            {
                if (MissionData.iMissionSeq == 0)
                {

                    MissionData.iMissionSeq = 1;
                    MissionData.iList_01[0] = 0;
                    MissionData.iList_01[1] = 0;
                    StayInVehicle(Game.Player.Character, true);
                    if (!MissionData.VehicleList_01.Contains(MissionData.VehTrackin_01))
                        MissionData.VehicleList_01.Add(new Vehicle(MissionData.VehTrackin_01.Handle));
                    MissionData.BeOnOff[0] = true;
                    if (MissionData.bTestRun)
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.VehicleList_01.Count > 0)
                    {
                        MissionData.iMissionSeq = 2;
                        MissionData.BeOnOff[1] = true;
                        MissionData.iMishText = 18;
                        if (!MissionData.bTestRun)
                            TheMissions.Fubar_AngreyTaxi();
                    }
                    else
                        MissionData.iMissionSeq = 45;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.iTracking < Game.GameTime)
                        ObjectHand.MultiPedTracker();

                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[1] && World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 90.0f)
                    {
                        MoveThatCar(MissionData.vTarget_02);
                        MissionData.BeOnOff[1] = false;
                    }
                    else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 4.0f)
                    {
                        MissionData.vLanLoc = Vector3.Zero;
                        MissionData.iMishText = 20;

                        if (Game.Player.IsPressingHorn)
                        {
                            MissionData.iMishText = -1;
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMissionSeq = 3;
                            ObjectHand.RemoveTargets();
                            Game.Player.WantedLevel = 0;
                            MissionData.BeOnOff[2] = false;
                            ObjectHand.CleanMultiPed(false, false);
                            MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(1000, 4000);
                        }
                        else
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[16], 1);
                        }
                    }
                    else
                    {
                        if (MissionData.BeOnOff[0])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[0] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                UiDisplay.TheYellowCorona(MissionData.vTarget_02, 5.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 480, DataStore.MyLang.Maptext[45]);
                                MissionData.vLanLoc = MissionData.vTarget_02;
                                MissionData.iMishText = 19;
                            }
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[0] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[16]);
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = 18;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        TheMissions.Fubar_CarShare();

                        MissionData.iMissionSeq = 4;
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.iList_01[3] == 1)
                    {
                        if (MissionData.Npc_01 != null)
                            MissionData.iMissionSeq = 5;
                    }
                    else if (MissionData.iList_01[3] == 2)
                    {
                        if (MissionData.Npc_02 != null)
                            MissionData.iMissionSeq = 5;
                    }
                    else
                    {
                        if (MissionData.Npc_03 != null)
                            MissionData.iMissionSeq = 5;
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || Game.Player.IsAiming || Game.Player.WantedLevel > 0)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iList_01[3] == 1)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInVehicle())
                        {
                            MissionData.vLanLoc = MissionData.vTarget_03;
                            MissionData.iMishText = 22;
                            MissionData.iMissionSeq = 6;
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.BeOnOff[1] = true;
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 164, DataStore.MyLang.Maptext[46]);
                        }
                        else if (Function.Call<bool>(Hash.IS_HORN_ACTIVE, MissionData.VehTrackin_01) && MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 2000;
                            MissionData.iList_01[4] += 1;
                            if (!MissionData.Npc_01.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_01, 1, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_01, 1);
                            }
                        }
                    }
                    else if (MissionData.iList_01[3] == 2)
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 43;
                        else if (MissionData.Npc_01.IsInVehicle() && MissionData.Npc_02.IsInVehicle())
                        {
                            MissionData.vLanLoc = MissionData.vTarget_03;
                            MissionData.iMishText = 21;
                            MissionData.iMissionSeq = 6;
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Npc_02.CurrentBlip.Remove();
                            MissionData.BeOnOff[1] = true;
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 164, DataStore.MyLang.Maptext[46]);
                        }
                        else if (Function.Call<bool>(Hash.IS_HORN_ACTIVE, MissionData.VehTrackin_01) && MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 2000;
                            MissionData.iList_01[4] += 1;
                            if (!MissionData.Npc_01.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_01, 1, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_01, 1);
                            }
                            else if (!MissionData.Npc_02.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_02, 2, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_02, 2);
                            }
                        }
                    }
                    else
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.Npc_03.IsDead)
                            MissionData.iMissionSeq = 43;
                        else if (MissionData.Npc_01.IsInVehicle() && MissionData.Npc_02.IsInVehicle() && MissionData.Npc_03.IsInVehicle())
                        {
                            MissionData.vLanLoc = MissionData.vTarget_03;
                            MissionData.iMishText = 21;
                            MissionData.iMissionSeq = 6;
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Npc_02.CurrentBlip.Remove();
                            MissionData.Npc_03.CurrentBlip.Remove();
                            MissionData.BeOnOff[1] = true;
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 164, DataStore.MyLang.Maptext[46]);
                        }
                        else if (Function.Call<bool>(Hash.IS_HORN_ACTIVE, MissionData.VehTrackin_01) && MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 2000;
                            MissionData.iList_01[4] += 1;
                            if (!MissionData.Npc_01.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_01, 1, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_01, 1);
                            }
                            else if (!MissionData.Npc_02.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_02, 2, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_02, 2);
                            }
                            else if (!MissionData.Npc_03.IsInVehicle())
                            {
                                if (MissionData.iList_01[4] < 3)
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_03, 3, 2.00f);
                                else
                                    ObjectBuild.WarptoPlayerVeh(MissionData.Npc_03, 3);
                            }
                        }
                    }

                    if (MissionData.iFuClock < Game.GameTime)
                        TheMissions.Fubar_Math(true);

                    if (!UiDisplay.bUiDisplay)
                        UiDisplay.bUiDisplay = true;
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || !Game.Player.Character.IsInVehicle() || Game.Player.IsAiming && Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed || Game.Player.WantedLevel > 0)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[1])
                    {
                        if (World.GetDistance(MissionData.vTarget_03, MissionData.VehTrackin_01.Position) < 90.0f)
                        {
                            MoveThatCar(MissionData.vTarget_03);
                            MissionData.BeOnOff[1] = false;
                        }
                    }
                    else if (World.GetDistance(MissionData.vTarget_03, MissionData.VehTrackin_01.Position) < 4.00f)
                    {
                        if (MissionData.VehTrackin_01.IsStopped)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            MissionData.iMishText = -1;
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMissionSeq = 7;
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else
                    {
                        if (MissionData.BeOnOff[3])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.BeOnOff[3] = false;
                                int iStation = ReturnStuff.RandInt(0, 20);
                                if (iStation == 17)
                                    iStation = 255;
                                Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, iStation);
                            }
                        }
                        else
                        {
                            if (!MissionData.VehTrackin_01.IsSeatFree(VehicleSeat.RightFront))
                            {
                                MissionData.BeOnOff[3] = true;
                                MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(8000, 25000);
                            }
                        }
                    }

                    if (MissionData.iFuClock < Game.GameTime)
                        TheMissions.Fubar_Math(true);

                    if (!UiDisplay.bUiDisplay)
                        UiDisplay.bUiDisplay = true;
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.IsInVehicle())
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 4000;
                            ObjectBuild.GetOutofVeh(MissionData.Npc_01, 0);
                            if (MissionData.iList_01[3] == 2)
                            {
                                ObjectBuild.GetOutofVeh(MissionData.Npc_02, 0);
                            }
                            else if (MissionData.iList_01[3] == 3)
                            {
                                ObjectBuild.GetOutofVeh(MissionData.Npc_02, 0);
                                ObjectBuild.GetOutofVeh(MissionData.Npc_03, 0);
                            }
                        }
                    }
                    else
                    {
                        MissionData.iMissionSeq = 8;
                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                    }

                    if (!UiDisplay.bUiDisplay)
                        UiDisplay.bUiDisplay = true;
                }
                else if (MissionData.iMissionSeq == 8)
                {
                    if (MissionData.bTestRun)
                    {
                        if (MissionData.iTestKit < MissionData.MyMissions.FubardXM.Count)
                        {
                            MissionData.iMissionSeq = 0;
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            MissionData.bMoreFubar = true;
                            MissionData.bJobLoaded = false;
                            TheMissions.FUber();
                        }
                        else
                            MissionData.iMissionSeq = 9;
                    }
                    else
                        ObjectHand.ControlSelect(6, false);
                }
                else if (MissionData.iMissionSeq == 9)
                {
                    MissionData.iCashReward = MissionData.iCashBouns + (MissionData.iRepMisssion * 10);
                    if (!MissionData.bTestRun)
                    {
                        if (MissionData.iRepMisssion < 25)
                        {
                            if (MissionData.iRepMisssion > 4)
                                ObjectHand.NSCoinInvestments(true, MissionData.iRepMisssion - 2, MissionData.iRepMisssion, "Fubar Inc");
                            else
                                ObjectHand.NSCoinInvestments(true, 0, 1, "Fubar Inc");
                        }
                        else
                            ObjectHand.NSCoinInvestments(true, 27, 28, "Fubar Inc");
                    }

                    TheMissions.GameOver(false, "" + DataStore.MyLang.Mistext[192] + "" + (MissionData.iRepMisssion * 10) + ", ", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (!MissionData.bTestRun)
                        ObjectHand.NSCoinInvestments(false, 5, 7, "Fubar Shares");
                    ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 2, true);
                    ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 3, true);
                    ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 4, true);
                    TheMissions.GameOver(true, "", false, 0);
                }
            }        //Fubar
            else if (MissionData.iJobType == 6)
            {
                if (MissionData.iLocationX == 1)
                {
                    if (MissionData.BeOnOff[0])
                    {
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, -4.815f, 1.0f, 0.5f, 0, 0, 0, 0.75f - 0.2, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, MissionData.fList_01[0], MissionData.fList_01[1], MissionData.fList_01[2]);
                        }
                        else
                        {
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        }
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, 4.815f, 1.0f, 0.5f, 0, 0, 0, 0.75f - 0.2, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, MissionData.fList_01[0], MissionData.fList_01[1], MissionData.fList_01[2]);
                        }
                        else
                        {
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        }
                    }
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 1;
                            MissionData.iCashBouns = 0;
                            MissionData.iMissionVar_01 = MissionData.VectorList_01.Count;
                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 23;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            TheMissions.Pilot01_ChecksNBalance(false);
                            MissionData.iMishText = 25;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 55.00f)
                        {
                            if (MissionData.VehTrackin_01.FreezePosition)
                                MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.iMishText = 24;
                        }
                        else
                            MissionData.iMishText = 23;
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 20.0f)
                        {
                            MissionData.iMissionSeq = 3;
                            TheMissions.Pilot01_ChecksNBalance(false);
                            MissionData.BeOnOff[0] = true;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.vTarget_02.DistanceTo(MissionData.VehTrackin_01.Position) < 15.00f)
                        {
                            MissionData.iMishText = -1;
                            MissionData.iCashReward += 100;

                            if (MissionData.iList_01[1] == 37)
                            {
                                if (MissionData.VehTrackin_01.Rotation.Y > -55.00f && MissionData.VehTrackin_01.Rotation.Y < 55.00f)
                                {
                                    MissionData.iCashReward += 1000;
                                    MissionData.iCashBouns += 1;
                                    Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 1500, false);
                                }
                            }
                            else if (MissionData.iList_01[1] == 38)
                            {
                                if (MissionData.VehTrackin_01.Rotation.Y > -130.00f && MissionData.VehTrackin_01.Rotation.Y < -60.00f)
                                {
                                    MissionData.iCashReward += 1000;
                                    MissionData.iCashBouns += 1;
                                    Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 1500, false);
                                }
                            }
                            else if (MissionData.iList_01[1] == 40)
                            {
                                if (MissionData.VehTrackin_01.Rotation.Y > 155.00f || MissionData.VehTrackin_01.Rotation.Y < -155.00f)
                                {
                                    MissionData.iCashReward += 1000;
                                    MissionData.iCashBouns += 1;
                                    Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 1500, false);
                                }
                            }

                            if (MissionData.iMissionVar_01 > 1)
                                TheMissions.Pilot01_ChecksNBalance(false);
                            else
                            {
                                MissionData.iMissionSeq = 4;
                                TheMissions.Pilot01_ChecksNBalance(true);
                            }
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                        }
                        if (MissionData.iList_01[2] != 0)
                        {
                            int iRaceT = MissionData.iList_01[2] - Game.GameTime;
                            iRaceT *= -1;
                            ObjectHand.FindTheTime(iRaceT, 2, "", true);
                        }
                        if (MissionData.iTime_01[0] < Game.GameTime)
                        {
                            MissionData.iTime_01[0] = Game.GameTime + 10000;
                            if (MissionData.iList_01[0] == 1)
                            {
                                MissionData.fList_01[0] = 255.00f;
                                MissionData.fList_01[1] = 0.00f;
                                MissionData.fList_01[2] = 0.00f;
                            }
                            else if (MissionData.iList_01[0] == 2)
                            {
                                MissionData.fList_01[0] = 255.00f;
                                MissionData.fList_01[1] = 255.00f;
                                MissionData.fList_01[2] = 255.00f;
                            }
                            else
                            {
                                MissionData.fList_01[0] = 0.00f;
                                MissionData.fList_01[1] = 0.00f;
                                MissionData.fList_01[2] = 220.00f;
                                MissionData.iList_01[0] = 0;
                            }
                            MissionData.iList_01[0] += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 15.00f)
                        {
                            MissionData.iCashReward += 100;

                            MissionData.iMissionSeq = 5;
                            ObjectHand.CleanUpCorrona(MissionData.iCoronaList, true);
                            MissionData.iCoronaList.Clear();
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                        }

                        int iRaceT = MissionData.iList_01[2] - Game.GameTime;
                        ObjectHand.FindTheTime(iRaceT *= -1, 2, "", true);

                        if (MissionData.iTime_01[0] < Game.GameTime)
                        {
                            MissionData.iTime_01[0] = Game.GameTime + 10000;
                            if (MissionData.iList_01[0] == 1)
                            {
                                MissionData.fList_01[0] = 255.00f;
                                MissionData.fList_01[1] = 0.00f;
                                MissionData.fList_01[2] = 0.00f;
                            }
                            else if (MissionData.iList_01[0] == 2)
                            {
                                MissionData.fList_01[0] = 255.00f;
                                MissionData.fList_01[1] = 255.00f;
                                MissionData.fList_01[2] = 255.00f;
                            }
                            else
                            {
                                MissionData.fList_01[0] = 0.00f;
                                MissionData.fList_01[1] = 0.00f;
                                MissionData.fList_01[2] = 220.00f;
                                MissionData.iList_01[0] = 0;
                            }
                            MissionData.iList_01[0] += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iList_01[2] -= Game.GameTime;
                        MissionData.iList_01[2] *= -1;
                        MissionData.bSoloRace = true;
                        DataStore.MyDatSet.iPegsSafePlaneTest = DataStore.iPegsSafePlane;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(4, DataStore.MyDatSet.iPegsSafePlaneTest);
                        ObjectHand.NSCoinInvestments(true, 2, 2 + MissionData.iCashBouns, "Red Nut Energy Drinks Shares");
                        ObjectHand.FindTheTime(MissionData.iList_01[2], 5, DataStore.MyLang.Mistext[193], false);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 4, 7, "Red Nut Energy Drinks Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }            // red nut air race
                else if (MissionData.iLocationX == 2)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[47]);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                        StayInVehicle(Game.Player.Character, true);
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);

                        MissionData.iMishText = 26;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }

                        if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 2.0f)
                        {
                            MissionData.iMissionSeq = 2;
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.VehTrackin_01.FreezePosition = false;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[5]);
                            MissionData.iMissionSeq = 3;

                            MissionData.iMishText = 27;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -1.00f);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_02, 10.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, 280, DataStore.MyLang.Maptext[48]);
                            MissionData.vLanLoc = MissionData.vTarget_02;
                            MissionData.iMishText = 28;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[5]);
                                MissionData.iMishText = 27;
                            }
                        }
                        else if (World.GetDistance(MissionData.vTarget_02, Game.Player.Character.Position) < 5.00f)
                        {
                            if (!MissionData.VehTrackin_01.IsInAir)
                            {
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.iMishText = -1;
                                MissionData.iMissionSeq = 5;
                                MissionData.Npc_01 = ObjectBuild.NPCSpawn("", MissionData.vTarget_03, 0.00f, false, 160, 0, 0, null, 2, true, 18, 1, DataStore.MyLang.Maptext[48]);
                                ObjectHand.RemoveTargets();
                                StopHere(MissionData.VehTrackin_01);
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                UiDisplay.TheYellowCorona(MissionData.vTarget_02, 10.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, 280, DataStore.MyLang.Maptext[48]);
                                MissionData.iMishText = 28;
                            }
                        }

                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.PedList_01.Count > 0)
                        {
                            int iRanPsyco = ReturnStuff.RandInt(0, 100);
                            if (iRanPsyco > 95)
                            {
                                MissionData.iMissionSeq = 40;
                                ObjectBuild.ArmsRegulator(MissionData.Npc_01, 3);
                                ObjectBuild.AttackThePlayer(MissionData.Npc_01, true);
                                MissionData.iWait4Sec = Game.GameTime + 25000;

                                MissionData.iMishText = 30;
                            }
                            else
                            {
                                MissionData.iMissionSeq = 6;
                                ObjectBuild.EnterPlayerVeh(MissionData.Npc_01, 3, 1.50f);
                            }
                            MissionData.iWait4Sec = Game.GameTime + 12000;
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01) || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInHeli)
                        {
                            MissionData.iMissionSeq = 7;
                            MissionData.vTarget_04 = ReturnStuff.AlterZHight(MissionData.vTarget_04, -1.00f);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_04, 10.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_04, false, true, 1.00f, false, 475, DataStore.MyLang.Maptext[49]);

                            MissionData.iMishText = 29;
                        }
                        else
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_01, 3);
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01) || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_04, Game.Player.Character.Position) < 5.0f)
                        {
                            MissionData.VehTrackin_01.EngineRunning = false;
                            if (MissionData.VehTrackin_01.IsInAir == false)
                            {
                                MissionData.iMishText = -1;
                                StopHere(MissionData.VehTrackin_01);
                                ObjectHand.RemoveTargets();
                                MissionData.iMissionSeq = 8;
                                ObjectBuild.GetOutofVeh(MissionData.Npc_01, 0);
                                ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_05, 1.00f);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_04, Game.Player.Character.Position) > 95.0f || World.GetDistance(MissionData.vTarget_05, MissionData.Npc_01.Position) < 2.0f)
                        {
                            MissionData.iCashReward = 5000;
                            DataStore.MyDatSet.iPegsSafeHeliTest = DataStore.iPegsSafeHeli;
                            DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                            RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                            RWDatFile.SaveDat(2, DataStore.MyDatSet.iPegsSafeHeliTest);
                            ObjectHand.NSCoinInvestments(true, 2, 5, "SecuroServ Shares");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                    }
                    else if (MissionData.iMissionSeq == 40)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_01.IsDriveable == false)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iCashReward = 5000;

                            MissionData.iMishText = -1;
                            DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            ObjectHand.CleanUpVehicles(ObjectHand.ConvertToHandle(null, null, null, MissionData.VehicleList_01), true, false);
                            MissionData.PedList_01.Clear();
                            MissionData.VehicleList_01.Clear();

                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 2, 7, "SecuroServ Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       // deliver ceo
                else if (MissionData.iLocationX == 3)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else
                        {
                            MissionData.iMissionSeq = 1;
                            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);

                            MissionData.iMishText = 31;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (World.GetDistance(MissionData.VehTrackin_01.Position, Game.Player.Character.Position) < 55.00f)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.iCashReward = 150000;
                            float fVicDam = MissionData.VehTrackin_01.BodyHealth + MissionData.VehTrackin_01.EngineHealth + MissionData.VehTrackin_01.PetrolTankHealth;
                            MissionData.iCrash4Cash = (int)fVicDam;

                            MissionData.iMishText = 32;
                        }
                        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 3;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_03, false, true, 1.00f, false, -1, DataStore.MyLang.Maptext[50]);

                            MissionData.iMishText = 33;
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, Game.Player.Character.Position) < 55.00f)
                            MissionData.iMishText = 32;
                        else
                            MissionData.iMishText = 31;
                        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) > 2100.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.iTime_01[0] = Game.GameTime + 150000;
                            ObjectHand.RemoveTargets();
                            Game.Player.WantedLevel = 4;
                            MissionData.BeOnOff[0] = false;
                            ZancudaClosed();
                            ObjectHand.AddDogFighters(5);

                            MissionData.iMishText = 34;
                        }
                        else
                            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iTime_01[0] > Game.GameTime)
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                                DogFighterTracking();
                        }
                        else
                        {
                            UiDisplay.TheYellowCorona(MissionData.vTarget_04, 10.00f);
                            Game.Player.WantedLevel = 2;
                            ObjectHand.CleanMultiPed(false, false);
                            MissionData.iMissionSeq = 5;

                            MissionData.iMishText = 7;
                        }

                        if (MissionData.iCrash4Cash > 0)
                            MissionData.iCashReward = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iCrash4Cash, 150000, true, MissionData.iCashReward, true);

                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.WantedLevel < 1)
                        {
                            MissionData.iMissionSeq = 6;
                            ObjectHand.AddTarget(MissionData.vTarget_04, false, true, 1.00f, false, 569, DataStore.MyLang.Maptext[51]);

                            MissionData.iMishText = 36;
                        }
                        else if (MissionData.iCrash4Cash > 0)
                            MissionData.iCashReward = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iCrash4Cash, 150000, true, MissionData.iCashReward, true);

                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        if (World.GetDistance(MissionData.vTarget_04, MissionData.VehTrackin_01.Position) < 5.0f)
                        {
                            StopHere(MissionData.VehTrackin_01);
                            MissionData.iMissionSeq = 7;
                            MissionData.iMishText = -1;
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_01.Position = new Vector3(2134.79f, 4781.249f, 40.41209f);
                            MissionData.VehTrackin_01.Heading = 28.53162f;
                            MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Locked;
                            Vector3 Vx = new Vector3(2159.819f, 4789.745f, 40.73829f);
                            ObjectHand.SlowFastTravel(Vx, 106.2993f);
                        }
                        else if (MissionData.iCrash4Cash > 0)
                            MissionData.iCashReward = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iCrash4Cash, 150000, true, MissionData.iCashReward, true);

                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        DataStore.MyDatSet.iPegsWarPlaneTest = DataStore.iPegsWarPlane;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(5, DataStore.MyDatSet.iPegsWarPlaneTest);
                        ObjectHand.NSCoinInvestments(false, 12, 24, "Warstock Shares");
                        TheMissions.GameOver(false, DataStore.MyLang.Mistext[194] + MissionData.iUltPed01 + ", ", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        if (MissionData.BeOnOff[0])
                        {
                            MissionData.BeOnOff[0] = false;
                            ZancudaClosed();
                        }
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       // steal brrrrrrt
                else if (MissionData.iLocationX == 4)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[52]);

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);

                        MissionData.iMishText = 36;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 2.0f)
                        {
                            MissionData.iMissionSeq = 2;
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        MissionData.iMissionSeq = 3;
                        ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[52]);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_02, 1.00f);
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (World.GetDistance(MissionData.vTarget_02, Game.Player.Character.Position) < 2.0f && MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 4;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[5]);
                            MissionData.VehTrackin_01.FreezePosition = false;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 5;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                        }
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(Game.Player.Character.Position) < 15.00f)
                            MissionData.iMishText = 37;
                        else
                            MissionData.iMishText = 36;
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMissionSeq = 6;
                        ObjectHand.AddTarget(MissionData.vTarget_04, false, true, 1.00f, false, 481, DataStore.MyLang.Maptext[38]);
                        MissionData.iMishText = 38;
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_04, Game.Player.Character.Position) < 400.00f)
                        {
                            MissionData.iMissionSeq = 7;
                            ObjectHand.RemoveTargets();
                            ObjectBuild.VehicleSpawn("Cargobob2", MissionData.vTarget_04, 90.0f, false, false, true, true, 6, 0, 3, DataStore.MyLang.Maptext[20], 2, false);
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01 != null)
                        {
                            if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_02))
                            {
                                MissionData.iMissionSeq = 8;
                                MissionData.BeOnOff[0] = false;
                                MissionData.iMissionVar_01 = MissionData.VectorList_01.Count;
                                ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_04, 200.00f, 0.00f);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (Game.Player.Character.Position.Z < MissionData.VehTrackin_02.Position.Z)
                            MissionData.iMishText = 39;
                        else
                            MissionData.iMishText = 40;

                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_02.IsDead || MissionData.VehTrackin_03.IsDead)
                        {
                            MissionData.VehTrackin_02.Explode();
                            MissionData.VehTrackin_03.Explode();
                            MissionData.iCashReward = 500;
                            MissionData.iMishText = -1;
                            MissionData.iMissionSeq = 99;
                            DataStore.MyDatSet.iPegsWarHeliTest = DataStore.iPegsWarHeli;
                            DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                            RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                            RWDatFile.SaveDat(3, DataStore.MyDatSet.iPegsWarHeliTest);
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                        else if (!MissionData.VehTrackin_03.IsAttachedTo(MissionData.VehTrackin_02))
                            MissionData.VehTrackin_03.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_03.Handle, new Vector3(0.00f, 0.00f, -3.00f), new Vector3(0.00f, -15.00f, 0.00f));
                        else if (World.GetDistance(MissionData.vTarget_04, MissionData.Npc_01.Position) < 30.00f)
                        {
                            if (MissionData.iMissionVar_01 < 1)
                            {
                                MissionData.iMissionSeq = 44;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                            }
                            else
                            {
                                MissionData.iMissionVar_01 -= 1;
                                MissionData.vTarget_04 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                                ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_04, 200.00f, 0.00f);
                            }
                        }
                        else if (MissionData.BeOnOff[0])
                        {
                            if (World.GetDistance(MissionData.vTarget_05, MissionData.Npc_01.Position) < 20.00f)
                            {
                                ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_04, 150.00f, 0.00f);
                                MissionData.BeOnOff[0] = false;
                            }
                        }
                        else if (MissionData.Npc_01.Position.Z < MissionData.vTarget_04.Z - 50.0f && MissionData.iMissionVar_01 > 2)
                        {
                            MissionData.BeOnOff[0] = true;
                            MissionData.vTarget_05 = MissionData.Npc_01.Position;
                            MissionData.vTarget_05 = ReturnStuff.AlterZHight(MissionData.vTarget_05, 150.00f);
                            ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_05, 150.00f, 0.00f);
                        }
                    }
                    else if (MissionData.iMissionSeq == 44)
                    {
                        MissionData.iMishText = -1;
                        MissionData.VehTrackin_02.Position = new Vector3(6000.01f, -2500.01f, 1500.01f);
                        MissionData.VehTrackin_03.Position = new Vector3(6000.01f, -2500.01f, 1500.01f);
                        MissionData.bPacBouns = true;
                        TheMissions.GameOver(true, "", true, 0);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       // ceo imp/exp
                else if (MissionData.iLocationX == 5)
                {
                    if (MissionData.BeOnOff[0])
                    {
                        if (MissionData.iTime_01[0] > Game.GameTime)
                        {
                            int iPost = MissionData.iTime_01[0] - Game.GameTime;
                            iPost = iPost / 10;
                            UiDisplay.ttTextBar_01.Text = " " + iPost + "Lbs ";
                        }
                        else
                        {
                            MissionData.BeOnOff[0] = false;
                            MissionData.iMissionSeq = 45;
                        }

                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, -3.94f, -0.8f, -0.55f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");

                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, 3.94f, -0.8f, -0.55f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, -2.815f, -0.8f, -0.6f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, 2.815f, -0.8f, -0.6f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, -1.687f, -0.8f, -0.65f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, 1.687f, -0.8f, -0.65f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, -0.562f, -0.8f, -0.7f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_carsteal4"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_carsteal4");
                            Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_carsteal4_wheel_burnout", MissionData.VehTrackin_01, 0.562f, -0.8f, -0.7f, 0, 0, 0, 0.30f, 0, 1, 0);
                            Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, 220.0f, 220.0f, 220.0f);
                        }
                        else
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_carsteal4");
                    }
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 1;

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 41;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 55.0f)
                        {
                            MissionData.VehTrackin_01.FreezePosition = false;
                            int iPos = MissionData.iTime_01[0] / 10;
                            UiDisplay.ttTextBar_01.Text = " " + iPos + " Lbs ";
                            MissionData.BeOnOff[2] = true;
                            MissionData.iMissionSeq = 2;
                            MissionData.iMishText = 42;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 3;
                            UiDisplay.bUiDisplay = true;
                            Vector3 VplayFace = new Vector3(0.0f, 0.0f, Game.Player.Character.Heading);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.VerticleCircle, MarkPos = MissionData.vTarget_02, MarkDir = Vector3.Zero, MarkRot = VplayFace, MarkScale = new Vector3(20.0f, 20.0f, 20.0f), MarkCol = Color.Yellow };
                            UiDisplay.bMMDisplay01 = true;

                            MissionData.BeOnOff[1] = true;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[36]);
                            MissionData.iMissionVar_01 = MissionData.VectorList_01.Count;
                            MissionData.iMishText = 43;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 55.0f)
                            MissionData.iMishText = 42;
                        else
                            MissionData.iMishText = 41;
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        Vector3 VplayFace = new Vector3(0.0f, 0.0f, Game.Player.Character.Heading);
                        UiDisplay.MMDisplay01.MarkRot = VplayFace;

                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 15.0f)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                            ObjectHand.RemoveTargets();
                            MissionData.vTarget_02 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                            ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, -1, DataStore.MyLang.Maptext[36]);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.VerticleCircle, MarkPos = MissionData.vTarget_02, MarkDir = Vector3.Zero, MarkRot = VplayFace, MarkScale = new Vector3(20.0f, 20.0f, 20.0f), MarkCol = Color.Yellow };

                            int mark2 = MissionData.iMissionVar_01 - 1;
                            MissionData.vTarget_05 = MissionData.VectorList_01[mark2];
                            ObjectHand.AddTarget(MissionData.vTarget_05, false, false, 1.00f, false, -1, DataStore.MyLang.Maptext[36]);
                            UiDisplay.MMDisplay02 = new MarkyMark { MarkType = MarkerType.VerticleCircle, MarkPos = MissionData.vTarget_05, MarkDir = Vector3.Zero, MarkRot = VplayFace, MarkScale = new Vector3(20.0f, 20.0f, 20.0f), MarkCol = Color.Orange };
                            UiDisplay.bMMDisplay02 = true;

                            MissionData.BeOnOff[1] = false;
                            MissionData.BeOnOff[0] = false;

                            MissionData.iMishText = 44;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        Vector3 VplayFace = new Vector3(0.0f, 0.0f, Game.Player.Character.Heading);
                        UiDisplay.MMDisplay01.MarkRot = VplayFace;
                        UiDisplay.MMDisplay02.MarkRot = VplayFace;

                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 15.0f)
                        {
                            if (MissionData.iMissionVar_01 < 1)
                                MissionData.iMissionSeq = 5;
                            else
                            {
                                MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                                ObjectHand.RemoveTargets();

                                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                                MissionData.vTarget_02 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                                ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, -1, DataStore.MyLang.Maptext[36]);


                                if (MissionData.BeOnOff[1])
                                {
                                    UiDisplay.bMMDisplay01 = true;
                                    MissionData.BeOnOff[1] = false;
                                    MissionData.BeOnOff[0] = false;
                                    MissionData.iTime_01[0] -= Game.GameTime;
                                    int mark2 = MissionData.iMissionVar_01 - 1;
                                    if (MissionData.iMissionVar_01 > 0)
                                    {
                                        MissionData.vTarget_05 = MissionData.VectorList_01[mark2];
                                        ObjectHand.AddTarget(MissionData.vTarget_05, false, false, 1.00f, false, -1, DataStore.MyLang.Maptext[36]); 
                                    }

                                    if (MissionData.BeOnOff[2])
                                    {
                                        SearchFor.SearchVeh(35.00f, 150.00f, "TECHNICAL", false, false, false, false, 8, 1, 1, DataStore.MyLang.Maptext[20], 0, true, true);
                                        MissionData.BeOnOff[2] = false;
                                    }
                                    UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.VerticleCircle, MarkPos = MissionData.vTarget_02, MarkDir = Vector3.Zero, MarkRot = VplayFace, MarkScale = new Vector3(20.0f, 20.0f, 20.0f), MarkCol = Color.Yellow };
                                    UiDisplay.MMDisplay02 = new MarkyMark { MarkType = MarkerType.VerticleCircle, MarkPos = MissionData.vTarget_05, MarkDir = Vector3.Zero, MarkRot = VplayFace, MarkScale = new Vector3(20.0f, 20.0f, 20.0f), MarkCol = Color.Orange };
                                }
                                else
                                {
                                    UiDisplay.bMMDisplay01 = false;
                                    MissionData.iTime_01[0] = Game.GameTime + MissionData.iTime_01[0];
                                    MissionData.BeOnOff[1] = true;
                                    MissionData.BeOnOff[0] = true;
                                }
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMishText = -1;
                        int iPost = MissionData.iTime_01[0] - Game.GameTime;
                        iPost = iPost / 10;
                        MissionData.iCashReward = 10000 + iPost;
                        DataStore.MyDatSet.iPegsSafePlaneTest = DataStore.iPegsSafePlane;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(4, DataStore.MyDatSet.iPegsSafePlaneTest);
                        ObjectHand.NSCoinInvestments(true, 4, 9, "Monsantos Shares");
                        TheMissions.GameOver(false, "" + DataStore.MyLang.Mistext[195] + "" + iPost + " " + DataStore.MyLang.Mistext[196] + ", ", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        MissionData.iMissionSeq = 99;
                        ObjectHand.NSCoinInvestments(false, 7, 12, "Monsantos Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       // crop duster
                else
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 1;
                            StayInVehicle(Game.Player.Character, true);

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 45;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 65.0f)
                        {
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.iMissionSeq = 2;
                            MissionData.iMishText = 46;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = -1;
                            int iRando = ReturnStuff.RandInt(13, 14);
                            MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(iRando), MissionData.vTarget_02, 121.00f, false, 120, 6, 0, null, 0, true, 18, 0, DataStore.MyLang.Maptext[104]);
                            MissionData.Npc_02 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(iRando), MissionData.vTarget_02, 121.00f, false, 120, 7, 0, null, 0, true, 18, 0, DataStore.MyLang.Maptext[104]);
                            MissionData.iMissionSeq = 3;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 65.0f)
                            MissionData.iMishText = 46;
                        else
                            MissionData.iMishText = 45;
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.Npc_02 != null)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.iWait4Sec = Game.GameTime + 20000;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle() || MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInVehicle() && MissionData.Npc_02.IsInVehicle())
                        {
                            MissionData.iMissionSeq = 5;
                            MissionData.iMissionVar_01 = MissionData.VectorList_01.Count - 1;
                            MissionData.vTarget_03 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                            MissionData.vTarget_03 = ReturnStuff.AlterZHight(MissionData.vTarget_03, -1.00f);
                            MissionData.iMissionVar_03 = 0;
                            UiDisplay.ttTextBar_01.Text = "0/4";
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 10.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, false, true, 1.00f, false, 184, DataStore.MyLang.Maptext[53]);
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Npc_02.CurrentBlip.Remove();
                            MissionData.iMishText = 47;
                        }
                        else
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                if (!MissionData.Npc_01.IsInVehicle() || !MissionData.Npc_02.IsInVehicle())
                                {
                                    ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_01, 3);
                                    ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_02, 4);
                                }
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (!Game.Player.Character.IsInVehicle() || MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_03, MissionData.VehTrackin_01.Position) < 100.00f)
                        {
                            MissionData.iMishText = 48;

                            if (World.GetDistance(MissionData.vTarget_03, MissionData.VehTrackin_01.Position) < 10.00f)
                            {
                                if (!MissionData.VehTrackin_01.IsInAir)
                                {
                                    MissionData.iMissionSeq = 6;
                                    MissionData.VehTrackin_01.EngineRunning = false;
                                    MissionData.VehTrackin_01.IsDriveable = false;
                                    TheMissions.Pilot06_TakeAPhoto(MissionData.Npc_01);
                                    TheMissions.Pilot06_TakeAPhoto(MissionData.Npc_02);
                                    MissionData.BeOnOff[0] = true;
                                    MissionData.iWait4Sec = Game.GameTime + 7000;
                                    ObjectHand.RemoveTargets();
                                    MissionData.iMishText = 49;
                                }
                            }
                        }
                        else
                            MissionData.iMishText = 47;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle() || MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            if (MissionData.BeOnOff[0])
                            {
                                MissionData.BeOnOff[0] = false;
                                MissionData.Npc_01.Task.ClearAll();
                                MissionData.Npc_01.Task.PlayAnimation("cellphone@self", "selfie", 8.00f, 3000, true, 1.00f);
                                MissionData.Npc_01.BlockPermanentEvents = true;

                                MissionData.Npc_02.Task.ClearAll();
                                MissionData.Npc_02.Task.PlayAnimation("cellphone@self", "selfie", 8.00f, 3000, true, 1.00f);
                                MissionData.Npc_02.BlockPermanentEvents = true;

                                MissionData.iWait4Sec = Game.GameTime + 3000;
                            }
                            else
                            {
                                if (!MissionData.Npc_01.IsInVehicle())
                                {
                                    MissionData.iWait4Sec = Game.GameTime + 4000;
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_01, 2, 1.00f);
                                }
                                if (!MissionData.Npc_02.IsInVehicle())
                                {
                                    MissionData.iWait4Sec = Game.GameTime + 4000;
                                    ObjectBuild.EnterPlayerVeh(MissionData.Npc_02, 3, 1.00f);
                                }
                            }
                        }
                        else if (MissionData.Npc_01.IsInVehicle() && MissionData.Npc_02.IsInVehicle())
                        {
                            MissionData.VehTrackin_01.EngineRunning = true;
                            MissionData.VehTrackin_01.IsDriveable = true;
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Npc_02.CurrentBlip.Remove();
                            if (MissionData.iMissionVar_01 < 1)
                            {
                                ObjectHand.RemoveTargets();
                                UiDisplay.ttTextBar_01.Text = "4/4";
                                MissionData.iMissionSeq = 7;
                            }
                            else
                            {
                                MissionData.iMishText = 47;
                                MissionData.iMissionSeq = 5;
                                MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                                MissionData.vTarget_03 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                                MissionData.vTarget_03 = ReturnStuff.AlterZHight(MissionData.vTarget_03, -2.00f);
                                MissionData.iMissionVar_03 = MissionData.iMissionVar_03 + 1;
                                UiDisplay.ttTextBar_01.Text = "" + MissionData.iMissionVar_03 + "/4";
                                UiDisplay.TheYellowCorona(MissionData.vTarget_03, 10.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_03, false, true, 1.00f, false, 184, DataStore.MyLang.Maptext[53]);
                            }
                        }

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -2.00f);
                        ObjectHand.AddTarget(MissionData.vTarget_01, false, true, 1.00f, false, 360, DataStore.MyLang.Maptext[54]);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 10.00f);

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                        MissionData.iMishText = 50;
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || !Game.Player.Character.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 100.00f)
                        {
                            MissionData.iMishText = 48;
                            if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 5.0f)
                            {
                                if (!MissionData.VehTrackin_01.IsInAir)
                                {
                                    MissionData.iMishText = -1;
                                    MissionData.iMissionSeq = 9;
                                    MissionData.VehTrackin_01.EngineRunning = false;
                                    MissionData.VehTrackin_01.IsDriveable = false;
                                    ObjectHand.RemoveTargets();
                                    MissionData.iWait4Sec = MissionData.iWait4Sec + 2000;
                                    TheMissions.Pilot06_GoBacktoOff(MissionData.Npc_01);
                                    TheMissions.Pilot06_GoBacktoOff(MissionData.Npc_02);
                                }
                            }
                        }
                        else
                            MissionData.iMishText = 50;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.GameTime > MissionData.iWait4Sec)
                        {
                            MissionData.iMissionSeq = 10;
                            MissionData.iWait4Sec = Game.GameTime + 12000;
                            MissionData.VehTrackin_01.EngineRunning = true;
                            MissionData.VehTrackin_01.IsDriveable = true;
                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.Position.DistanceTo(MissionData.vTarget_02) < 6.00f || Game.GameTime > MissionData.iWait4Sec)
                        {
                            MissionData.Npc_01.Position = MissionData.vTarget_03;
                            MissionData.Npc_02.Position = MissionData.vTarget_03;
                            MissionData.iCashReward = ReturnStuff.RandInt(7000, 9000);
                            DataStore.MyDatSet.iPegsSafeHeliTest = DataStore.iPegsSafeHeli;
                            DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                            RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                            RWDatFile.SaveDat(2, DataStore.MyDatSet.iPegsSafeHeliTest);
                            ObjectHand.NSCoinInvestments(true, 7, 9, "Higgins Shares");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 5, 11, "Higgins Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }                            // heil tours
            }        //Pilot
            else if (MissionData.iJobType == 7)
            {
                if (Game.Player.WantedLevel > 0)
                    Game.Player.WantedLevel = 0;

                if (MissionData.BeOnOff[0])
                {
                    if (MissionData.BeOnOff[1])
                    {
                        if (MissionData.iTime_01[0] > Game.GameTime)
                        {

                            int iTotal = MissionData.iTime_01[0] - Game.GameTime;
                            ObjectHand.FindTheTime(iTotal, 6, "", true);
                        }
                        else
                        {
                            MissionData.BeOnOff[1] = false;
                            UiDisplay.bUiDisplay = false;
                            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
                            MissionData.iMissionSeq = 17;
                        }
                    }
                    if (MissionData.sList_01.Count > 0)
                    {
                        if (MissionData.BeOnOff[2])
                        {
                            if (MissionData.iTime_01[1] < Game.GameTime)
                            {
                                MissionData.iTime_01[1] = Game.GameTime + ReturnStuff.RandInt(50, 700);
                                if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, MissionData.sList_01[0]))
                                {
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, MissionData.sList_01[0]);
                                    Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, MissionData.sList_01[1], MissionData.Npc_01.Handle, 0.0f, 0.15f, 0.75f, 0.0f, 0.0f, 90.0f, 1.0f, false, false, false);
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, MissionData.sList_01[0]);
                                }
                                if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, MissionData.sList_01[2]))
                                {
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, MissionData.sList_01[2]);
                                    Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, MissionData.sList_01[3], MissionData.Npc_01.Handle, 0.0f, 0.15f, 0.75f, 0.0f, 0.0f, 90.0f, ReturnStuff.RandFlow(0.01f, 0.5f), false, false, false);
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, MissionData.sList_01[2]);
                                }
                            }
                        }
                        else
                        {
                            if (MissionData.iTime_01[1] < Game.GameTime)
                            {
                                MissionData.iTime_01[1] = Game.GameTime + ReturnStuff.RandInt(50, 700);
                                if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, MissionData.sList_01[4]))
                                {
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, MissionData.sList_01[4]);
                                    Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, MissionData.sList_01[5], MissionData.Npc_01.Handle, 0.3f, -0.3f, -0.4f, 180.0f, 270.0f, 90.0f, 1.0f, true, true, true);
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, MissionData.sList_01[4]);
                                }
                                if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, MissionData.sList_01[2]))
                                {
                                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, MissionData.sList_01[2]);
                                    Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, MissionData.sList_01[3], MissionData.Npc_01.Handle, 0.0f, 0.15f, 0.75f, 0.0f, 0.0f, 90.0f, ReturnStuff.RandFlow(0.01f, 0.5f), false, false, false);
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, MissionData.sList_01[2]);
                                }
                            }
                        }
                    }
                }

                if (MissionData.iMissionSeq == 0)
                {
                    if (MissionData.VehicleList_01.Count > 0)
                    {
                        MissionData.iMissionSeq = 1;
                        StayInVehicle(Game.Player.Character, true);
                        if (!MissionData.bAmberAntz)
                        {
                            if (DataStore.MySettings.FastTraveltoStart || MissionData.bTestRun)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 52;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 2;
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 153, DataStore.MyLang.Maptext[37]);
                        MissionData.BeOnOff[4] = false;
                        if (MissionData.VehTrackin_01.CurrentBlip.Exists())
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                        MissionData.vLanLoc = MissionData.vTarget_01;
                        MissionData.iMishText = 53;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 55.00f)
                    {
                        MissionData.iMishText = 57;
                        if (!MissionData.bAmberAntz)
                        {
                            if (!MissionData.VehTrackin_01.IsOnAllWheels)
                            {
                                MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                                MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                            }
                        }
                    }
                    else
                    {
                        if (!MissionData.bAmberAntz)
                            MissionData.iMishText = 52;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.vLanLoc = MissionData.vTarget_01;
                            MissionData.iMishText = 53;
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 153, DataStore.MyLang.Maptext[37]);
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = 55;
                        }
                    }
                    else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 95.0f)
                    {
                        MissionData.iMissionSeq = 3;
                        MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), MissionData.vTarget_01, 0.00f, false, 160, 17, 0, null, 0, false, 0, 0, "");
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 57;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.iMishText = 53;
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 153, DataStore.MyLang.Maptext[37]);
                            MissionData.vLanLoc = MissionData.vTarget_01;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = 55;
                        }
                    }
                    else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 50.00f)
                    {
                        MissionData.iMissionSeq = 4;
                        ObjectHand.RemoveTargets();
                        MissionData.BeOnOff[2] = false;
                        MissionData.BeOnOff[0] = true;
                        MissionData.Npc_01.Task.PlayAnimation("combat@damage@writhe", "writhe_loop", 8.0f, -1, true, 1.0f);
                        MissionData.Npc_01.AlwaysKeepTask = true;
                        MissionData.Npc_01.BlockPermanentEvents = true;
                        MissionData.Npc_01.ApplyDamage(50);
                        ReturnStuff.PedBlimp(MissionData.Npc_01, 0.75f, false, true, 53, DataStore.MyLang.Maptext[37]);

                        UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.Npc_01.Position.X, MissionData.Npc_01.Position.Y, MissionData.Npc_01.Position.Z + 1.00f), MarkDir = Vector3.Zero , MarkRot = new Vector3(0.00f, 180.00f, MissionData.Npc_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.AntiqueWhite };
                        UiDisplay.bMMDisplay01 = true;
                        MissionData.iMishText = 54;
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            MissionData.iMishText = 52;
                            MissionData.vLanLoc = Vector3.Zero;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                            MissionData.iMishText = 57;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                        }
                        else if (World.GetDistance(Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 1), MissionData.Npc_01.Position) < 0.75f)
                        {
                            MissionData.iMissionSeq = 25;
                            Game.Player.CanControlCharacter = false;
                            UiDisplay.bMMDisplay01 = false;
                            TheMenus.Ambulance_Menu();
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 55;
                            MissionData.Npc_01.FreezePosition = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.IsInVehicle())
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 6;
                            TheMissions.Ambulance_StartLine();
                            if (MissionData.BeOnOff[6])
                                MissionData.iMishText = 58;
                            else
                                MissionData.iMishText = 56;
                        }
                    }
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = -1;
                        }
                    }
                    else
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[17], 1);

                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            MissionData.iMishText = 57;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                        }
                        else if (Function.Call<bool>(Hash.IS_HORN_ACTIVE, MissionData.VehTrackin_01))
                        {
                            ObjectBuild.WarptoPlayerVeh(MissionData.Npc_01, 2);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[3] && World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 75.00f)
                    {
                        MoveThatCar(MissionData.vTarget_02);
                        MissionData.BeOnOff[3] = false;
                    }
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            if (MissionData.BeOnOff[6])
                                MissionData.iMishText = 58;
                            else
                                MissionData.iMishText = 56;
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                            MissionData.iMishText = 57;
                        }
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 5.50f)
                        {
                            if (MissionData.VehTrackin_01.IsStopped)
                            {
                                MissionData.iMissionSeq = 7;
                                ObjectHand.RemoveTargets();
                                MissionData.iMishText = -1;
                                MissionData.BeOnOff[1] = false;
                                UiDisplay.bUiDisplay = false;
                                UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
                                ObjectBuild.GetOutofVeh(MissionData.Npc_01, 0);
                                ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_03, 1.00f);
                                MissionData.iWait4Sec = Game.GameTime + 3000;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                        }
                    }

                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (MissionData.Npc_01.IsInVehicle())
                        {
                            MissionData.iWait4Sec = Game.GameTime + 2500;
                            ObjectBuild.GetOutofVeh(MissionData.Npc_01, 0);
                            Script.Wait(1000);
                            ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_03, 1.00f);
                            MissionData.iMishText = -1;
                        }
                        else
                        {
                            MissionData.iMissionSeq = 8;
                            ObjectHand.RemoveTargets();
                            MissionData.iWait4Sec = Game.GameTime + 11000;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 8)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 66, DataStore.MyLang.Maptext[7]);
                        }
                    }

                    if (World.GetDistance(MissionData.Npc_01.Position, MissionData.vTarget_03) < 2.0f || MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (MissionData.bTestRun)
                        {
                            MissionData.iMissionSeq = 0;
                            MissionData.BeOnOff[0] = false;
                            MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                            MissionData.bAmberAntz = true;
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            if (MissionData.iTestKit < MissionData.MyMissions.AmbuXM.Count())
                                TheMissions.Ambulance();
                            else
                                TheMissions.GameOver(false, "" + MissionData.iRepMisssion + "" + DataStore.MyLang.Mistext[197] + ", ", false, MissionData.iCashReward);

                        }
                        else
                        {
                            MissionData.iMissionSeq = 99;
                            MissionData.BeOnOff[0] = false;
                            MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            MissionData.bAmberAntz = true;
                            ObjectHand.ControlSelect(7, false);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 9)
                {
                    MissionData.bCovidInf = false;

                    if (!MissionData.bTestRun)
                    {
                        if (MissionData.iRepMisssion < 25)
                        {
                            if (MissionData.iRepMisssion > 4)
                                ObjectHand.NSCoinInvestments(true, MissionData.iRepMisssion - 2, MissionData.iRepMisssion, "Humane Labs");
                            else
                                ObjectHand.NSCoinInvestments(true, 0, 1, "Humane Labs");
                        }
                        else
                            ObjectHand.NSCoinInvestments(true, 27, 28, "Humane Labs");
                    }

                    DataStore.MyDatSet.iMeddicTest = DataStore.iMeddicc;
                    RWDatFile.SaveDat(8, DataStore.MyDatSet.iMeddicTest);
                    TheMissions.GameOver(false, "" + MissionData.iRepMisssion + "" + DataStore.MyLang.Mistext[197] + ", ", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 15)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 5;
                        Game.Player.CanControlCharacter = true;
                        Game.Player.Character.Task.ClearAll();
                        MissionData.Npc_01.Task.ClearAnimation("combat@damage@writhe", "writhe_loop");
                        MissionData.Npc_01.FreezePosition = false;
                        ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_01, 2, 2.00f);
                        MissionData.iList_01[0] = 0;
                        MissionData.Npc_01.CurrentBlip.Remove();

                        MissionData.iMishText = 57;
                    }
                }
                else if (MissionData.iMissionSeq == 16)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 5;
                        Game.Player.CanControlCharacter = true;
                        Game.Player.Character.Task.ClearAll();
                        MissionData.Npc_01.Task.ClearAnimation("combat@damage@writhe", "writhe_loop");
                        MissionData.Npc_01.FreezePosition = false;
                        ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_01, 2, 2.00f);
                        MissionData.iList_01[0] = 0;
                        MissionData.Npc_01.CurrentBlip.Remove();

                        MissionData.iMishText = 57;
                    }
                }
                else if (MissionData.iMissionSeq == 17)
                {
                    Game.Player.CanControlCharacter = true;
                    Game.Player.Character.Task.ClearAll();
                    MissionData.Npc_01.Health = 0;
                    MissionData.Npc_01.FreezePosition = false;
                    if (MissionData.Npc_01.CurrentBlip.Exists())
                        MissionData.Npc_01.CurrentBlip.Remove();
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (MissionData.bTestRun)
                        {
                            MissionData.iMissionSeq = 0;
                            MissionData.BeOnOff[0] = false;
                            MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                            MissionData.bAmberAntz = true;
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            if (MissionData.iTestKit < MissionData.MyMissions.AmbuXM.Count())
                                TheMissions.Ambulance();
                            else
                                TheMissions.GameOver(false, "" + MissionData.iRepMisssion + "" + DataStore.MyLang.Mistext[197] + ", ", false, MissionData.iCashReward);

                        }
                        else
                        {
                            MissionData.iMissionSeq = 99;
                            MissionData.BeOnOff[0] = false;
                            //MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                            ObjectHand.RemoveTargets();
                            ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                            MissionData.PedList_01.Clear();
                            MissionData.bAmberAntz = true;
                            ObjectHand.ControlSelect(7, false);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 18)
                {
                    Game.Player.CanControlCharacter = true;
                    Game.Player.Character.Task.ClearAll();
                    MissionData.Npc_01.Task.ClearAnimation("combat@damage@writhe", "writhe_loop");
                    MissionData.Npc_01.FreezePosition = false;
                    if (MissionData.bTestRun)
                    {
                        MissionData.iMissionSeq = 0;
                        MissionData.BeOnOff[0] = false;
                        MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                        MissionData.bAmberAntz = true;
                        ObjectHand.RemoveTargets();
                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                        if (MissionData.iTestKit < MissionData.MyMissions.AmbuXM.Count())
                            TheMissions.Ambulance();
                        else
                            TheMissions.GameOver(false, "" + MissionData.iRepMisssion + "" + DataStore.MyLang.Mistext[197] + ", ", false, MissionData.iCashReward);

                    }
                    else
                    {
                        MissionData.iMissionSeq = 99;
                        MissionData.BeOnOff[0] = false;
                        //MissionData.Npc_01.Position = new Vector3(0f, 0f, 150f);
                        ObjectHand.RemoveTargets();
                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                        MissionData.bAmberAntz = true;
                        ObjectHand.ControlSelect(7, false);
                    }
                }
                else if (MissionData.iMissionSeq == 25)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    MissionData.bCovidInf = false;
                    TheMissions.GameOver(true, "" + MissionData.iRepMisssion + "" + DataStore.MyLang.Mistext[197] + ", ", MissionData.bAmberAntz, MissionData.iCashReward);
                }
            }        //Amulance
            else if (MissionData.iJobType == 8)
            {
                if (MissionData.BeOnOff[3])
                {
                    if (MissionData.BeOnOff[4])                  //Test if vehicle has rolled over with 2 sec timmer to give time to get back on wheels.
                    {
                        if (Game.GameTime > MissionData.iTime_01[0])
                        {
                            if (!MissionData.VehTrackin_01.IsOnAllWheels)
                                MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.VehTrackin_01.Rotation.Z);
                            MissionData.BeOnOff[4] = false;
                        }
                    }
                    else
                    {
                        if (!MissionData.VehTrackin_01.IsOnAllWheels)
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.iTime_01[0] = Game.GameTime + 2000;
                        }
                    }

                    if (MissionData.BeOnOff[0])     // The distance bar that pops up for distance to target
                    {
                        float fDist = MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01);
                        int iFind = (int)fDist;
                        UiDisplay.ttTextBar_01.Text = " " + iFind + " ";
                    }

                    if (World.GetDistance(Game.Player.Character.Position, MissionData.Npc_01.Position) < 125.00f)   // Distance tracking for Spookbar
                    {
                        if (MissionData.iTime_01[1] != 0)
                        {
                            MissionData.iTime_01[1] = 0;      //timer for spook fail
                            MissionData.VehTrackin_01.CurrentBlip.IsFlashing = false;
                        }
                        MissionData.fMission_02 = World.GetDistance(Game.Player.Character.Position, MissionData.Npc_01.Position) / 100.00f;// Find the percent for Spookbar float 0.00 to 1.00
                        MissionData.fMission_02 = 1.00f - MissionData.fMission_02;
                        if (MissionData.fMission_02 < 0.01f)
                            MissionData.fMission_02 = 0.01f;
                        UiDisplay.BtSlideBar.BackgroundColor = Color.Black;
                    }
                    else       // if player is out side min distance
                    {
                        MissionData.fMission_02 = 0.00f;
                        if (MissionData.iTime_01[1] == 0) // set timmer for distance fail
                        {
                            MissionData.VehTrackin_01.CurrentBlip.IsFlashing = true;
                            MissionData.iTime_01[1] = Game.GameTime + 15000;
                        }
                        else if (MissionData.iTime_01[1] < Game.GameTime) // fail if timmer runs out
                            MissionData.iMissionSeq = 45;
                        if (MissionData.BeOnOff[5]) // bar flash for distance warning. is a 1/2 sec toggle on off.
                        {
                            if (MissionData.iTime_01[2] < Game.GameTime)
                            {
                                MissionData.BeOnOff[5] = false;
                                MissionData.iTime_01[2] = Game.GameTime + 500;
                                UiDisplay.BtSlideBar.BackgroundColor = Color.White;
                            }
                        }
                        else
                        {
                            if (MissionData.iTime_01[2] < Game.GameTime)
                            {
                                MissionData.BeOnOff[5] = true;
                                MissionData.iTime_01[2] = Game.GameTime + 500;
                                UiDisplay.BtSlideBar.BackgroundColor = Color.Black;
                            }
                        }
                    }

                    if (MissionData.fMission_02 > 0.75f)  // test if too close to target
                    {
                        if (!MissionData.BeOnOff[7])
                        {
                            if (MissionData.iTime_01[3] == 0)  // set timmer for too close fail
                            {
                                MissionData.iTime_01[3] = Game.GameTime + 15000;
                                MissionData.VehTrackin_01.CurrentBlip.IsFlashing = true;
                            }
                            else if (MissionData.iTime_01[3] < Game.GameTime)  // too close fail.
                                MissionData.iMissionSeq = 45;

                            if (MissionData.BeOnOff[5]) // bar flash for distance warning. is a 1/2 sec toggle on off.
                            {
                                if (MissionData.iTime_01[4] < Game.GameTime)
                                {
                                    MissionData.BeOnOff[5] = false;
                                    MissionData.iTime_01[4] = Game.GameTime + 500;
                                    UiDisplay.BtSlideBar.ForegroundColor = Color.White;
                                }
                            }
                            else
                            {
                                if (MissionData.iTime_01[4] < Game.GameTime)
                                {
                                    MissionData.BeOnOff[5] = true;
                                    MissionData.iTime_01[4] = Game.GameTime + 500;
                                    UiDisplay.BtSlideBar.ForegroundColor = Color.Red;
                                }
                            }
                        }
                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_02;   // set the native ui Bar to the current distance percent.

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;      //draw the spookbar to screen.
                    }
                    else    //draw the spookbar to screen where the player is at the correct distance.
                    {
                        if (MissionData.iTime_01[3] != 0)
                        {
                            MissionData.iTime_01[3] = 0;
                            MissionData.VehTrackin_01.CurrentBlip.IsFlashing = false;
                        }
                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_02;
                        UiDisplay.BtSlideBar.ForegroundColor = Color.Yellow;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                }

                if (MissionData.iMissionSeq == 0)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vGetaway) < 125.00f)
                    {
                        if (World.GetNextPositionOnStreet(MissionData.vGetaway).DistanceTo(MissionData.vGetaway) > 150.00f)
                            TheMissions.Follow_ButTherArntAny();
                        else
                        {
                            MissionData.iMissionSeq = 1;
                            MissionData.iWait4Sec = Game.GameTime + 10000;
                            SearchFor.SearchVeh(35.00f, 250.00f, ReturnStuff.RanVehListX(6, 1, true), false, false, false, false, 3, 8, 3, DataStore.MyLang.Maptext[14], 1, true, true);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.VehTrackin_01 != null)
                    {
                        MissionData.vLanLoc = Vector3.Zero;
                        MissionData.iMishText = 60;
                        MissionData.iMissionSeq = 2;
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 0;
                        TheMissions.Follow_ButTherArntAny();
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (World.GetDistance(Game.Player.Character.Position, MissionData.VehTrackin_01.Position) < 125.00f)
                    {
                        MissionData.iMissionSeq = 3;
                        TheMissions.Follow_SpiningAround(MissionData.VehTrackin_01);
                        MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), MissionData.VehTrackin_01.Position, MissionData.VehTrackin_01.Heading, false, 180, 0, 1, MissionData.VehTrackin_01, 2, false, 0, 0, "");
                        //MyBob.MyBlip.IsFlashing = false;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    MissionData.iMissionSeq = 4;
                    MissionData.iTime_01[5] = Game.GameTime;
                    MissionData.BeOnOff[3] = true;
                    MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                    float fSpeed = 20.00f;
                    ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);

                    UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.CadetBlue };
                    UiDisplay.bMMDisplay01 = true;
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (!MissionData.VehTrackin_01.IsOnAllWheels)
                        TheMissions.Follow_SpiningAround(MissionData.VehTrackin_01);
                    else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 75.00f)
                    {
                        MissionData.iMissionSeq = 5;
                        MissionData.vGetaway = MissionData.VectorList_02[0];
                        MissionData.Npc_02 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), MissionData.vGetaway, MissionData.fMission_01, false, 180, 0, 0, null, 2, false, 0, 0, "");
                        float fSpeed = 15.00f;
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                        MissionData.VehTrackin_01.SoundHorn(1000);
                        MoveThatCar(MissionData.vTarget_01);
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime && MissionData.VehTrackin_01.IsStopped)
                    {
                        MissionData.iWait4Sec = Game.GameTime + 6000;
                        GateIsNear(MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.ForwardVector * 3), 10.00f, false);
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                    if (MissionData.Npc_01.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 5.00)
                    {
                        MissionData.iMissionSeq = 6;
                        MissionData.iList_01[0] = 0;
                        MissionData.VehTrackin_01.FreezePosition = true;
                        ObjectHand.DoorsNear(MissionData.Npc_02.Position, 8.00f, false);
                        MissionData.iWait4Sec = Game.GameTime + 2000;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                    if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_02.IsInVehicle())
                    {
                        MissionData.VehTrackin_01.FreezePosition = false;
                        MissionData.BeOnOff[6] = true;
                        MissionData.iWait4Sec = Game.GameTime + 12000;
                        MissionData.iMissionSeq = 7;
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iWait4Sec = Game.GameTime + 2000;
                        MissionData.iList_01[0] += 1;
                        if (!MissionData.Npc_02.IsInVehicle())
                        {
                            if (MissionData.iList_01[0] < 10)
                            {
                                if (MissionData.BeOnOff[1])
                                    ObjectHand.DoorsNear(MissionData.Npc_02.Position, 8.00f, false);
                                else
                                    ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_02, 1, 1.20f);
                                MissionData.BeOnOff[1] = !MissionData.BeOnOff[1];
                            }
                            else
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, MissionData.Npc_02, 2);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 40)
                {
                    MissionData.iTime_01[5] -= Game.GameTime;
                    MissionData.iTime_01[5] = MissionData.iTime_01[5] / 1000;
                    MissionData.iTime_01[5] *= -1;
                    MissionData.iCashReward += (MissionData.iTime_01[5] * 10);
                    Game.Player.WantedLevel = 0;
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.GameOver(true, "", false, 0);
                }
                else if (MissionData.iMissionVar_01 == 1)
                {
                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.BeOnOff[9] = true;
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_02 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        float fSpeed = 20.00f;
                        ObjectBuild.Follow_AddToMuilti(MissionData.Npc_01, DataStore.MyLang.Maptext[14], MissionData.VehTrackin_01.CurrentBlip, MissionData.VehTrackin_01);
                        ObjectBuild.Follow_AddToMuilti(MissionData.Npc_02, "", null, null);
                        UiDisplay.MMDisplay01.MarkCol = Color.PaleVioletRed;
                        ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead && MissionData.Npc_02.IsDead)
                        {
                            MissionData.Npc_01.Health = 0;
                            MissionData.Npc_02.Health = 0;
                            ObjectHand.NSCoinInvestments(false, 5, 11, "Total Bankers Shares");
                            MissionData.iMissionSeq = 40;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 75.00f && MissionData.BeOnOff[9])
                        {
                            MissionData.BeOnOff[9] = false;
                            float fSpeed = 15.00f;
                            ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 5.00f)
                        {
                            MissionData.iMissionSeq = 9;
                            ObjectBuild.GetOutofVeh(MissionData.Npc_01, 1);
                            ObjectBuild.GetOutofVeh(MissionData.Npc_02, 1);
                            ReturnStuff.PedBlimp(MissionData.Npc_01, 0.75f, false, false, 1, "");
                            ReturnStuff.PedBlimp(MissionData.Npc_02, 0.75f, false, false, 1, "");
                            ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_02, 2.00f);
                            ObjectHand.WalkThisWay(MissionData.Npc_02, MissionData.vTarget_02, 2.00f);
                        }
                        else if (MissionData.BeOnOff[6])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime || MissionData.vTarget_01.DistanceTo(MissionData.VehTrackin_01.Position) < 30.00f)
                            {
                                MissionData.BeOnOff[6] = false;
                                MissionData.BeOnOff[7] = true;
                                MissionData.BeOnOff[0] = true;
                                UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                                Game.Player.WantedLevel = 4;
                                MissionData.MultiPed[0].MyTask_01 = 1;
                                float fSpeed = 45.00f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 1, DataStore.MyLang.Maptext[20]);

                                MissionData.iMishText = 61;
                            }
                        }
                        else if (Game.Player.WantedLevel < 4)
                            Game.Player.WantedLevel = 4;
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        if (MissionData.Npc_01.IsDead && MissionData.Npc_02.IsDead)
                        {
                            MissionData.iCashReward = 10000;
                            MissionData.Npc_01.Health = 0;
                            MissionData.Npc_02.Health = 0;
                            ObjectHand.NSCoinInvestments(false, 5, 15, "Total Bankers Shares");
                            MissionData.iMissionSeq = 40;
                        }
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.Npc_01.Position) < 3.0f || World.GetDistance(MissionData.vTarget_02, MissionData.Npc_02.Position) < 3.0f)
                        {
                            MissionData.iMissionSeq = 45;
                            MissionData.Npc_01.Position = new Vector3(0f, 0f, 1500f);
                            MissionData.Npc_02.Position = new Vector3(0f, 0f, 1500f);
                        }
                        else
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.MultiPedTracker();
                        }
                    }
                }       // Take out the two npc's route to polic station.
                else if (MissionData.iMissionVar_01 == 2)
                {
                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        float fSpeed = 20.00f;
                        UiDisplay.MMDisplay01.MarkCol = Color.LightSteelBlue;
                        ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 5.00f)
                        {
                            MissionData.iMissionSeq = 9;
                            MissionData.BeOnOff[3] = false;
                            UiDisplay.bMMDisplay01 = false;
                            World.AddExplosion(MissionData.VehTrackin_01.Position, ExplosionType.PlaneRocket, 2.00f, 1.00f);
                            MissionData.VehTrackin_01.Explode();
                        }
                        else if (MissionData.BeOnOff[8])
                        {
                            if (MissionData.VehTrackin_01.Position.Z > 101.01f)
                            {
                                MissionData.BeOnOff[8] = false;
                                float fSpeed = 15.0f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            }
                        }
                        if (MissionData.BeOnOff[6])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.BeOnOff[6] = false;
                                MissionData.BeOnOff[7] = true;
                                MissionData.BeOnOff[0] = true;
                                MissionData.iTracking = Game.GameTime + 1000;
                                UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                                SearchFor.SearchVeh(35.00f, 125.00f, "SCHAFTER3", false, false, false, false, 8, 9, 1, DataStore.MyLang.Maptext[20], 0, true, true);
                                SearchFor.SearchVeh(35.00f, 125.00f, "LIMO2", false, false, false, false, 8, 9, 1, DataStore.MyLang.Maptext[20], 0, true, true);
                                MissionData.Npc_01.RelationshipGroup = DataStore.GP_BNPCs;
                                MissionData.Npc_02.RelationshipGroup = DataStore.GP_BNPCs;

                                float fSpeed = 25.00f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            }
                        }
                        else
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.MultiPedTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        MissionData.iMissionSeq = 40;
                        ObjectHand.NSCoinInvestments(true, 5, 12, "Penris Shares");
                        MissionData.BeOnOff[7] = false;
                        MissionData.iCashReward = 8000;
                    }
                }       // Follow to end then arial atack the car.
                else if (MissionData.iMissionVar_01 == 3)
                {
                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.BeOnOff[9] = true;
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        UiDisplay.MMDisplay01.MarkCol = Color.LightCoral;
                        float fSpeed = 20.00f;
                        ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 50.0f)
                        {
                            MissionData.iMissionSeq = 9;
                            MissionData.BeOnOff[3] = false;
                            TheMissions.Follow_AmbushPlayer();
                            UiDisplay.MpUiDisplay.Remove(UiDisplay.BtSlideBar);
                            UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_02);
                            UiDisplay.ttTextBar_02.Text = "" + MissionData.MultiPed.Count + "/" + MissionData.iAmbushCount + "";
                            float fSpeed = 15.00f;
                            ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            MissionData.iWait4Sec = Game.GameTime + 1500;
                            MissionData.iMishText = 62;
                            TheMissions.Follow_DefToOff();
                            UiDisplay.bMMDisplay01 = false;
                        }
                        else if (MissionData.BeOnOff[6])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.BeOnOff[6] = false;
                                float fSpeed = 45.00f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            }
                        }
                        else if (MissionData.BeOnOff[8])
                        {
                            if (MissionData.VehTrackin_01.Position.Z > 101.01f)
                            {
                                MissionData.BeOnOff[8] = false;
                                float fSpeed = 15.0f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;

                        if (MissionData.iTracking < Game.GameTime)
                        {
                            ObjectHand.MultiPedTracker();
                            UiDisplay.ttTextBar_02.Text = "" + MissionData.MultiPed.Count + "/" + MissionData.iAmbushCount + "";
                        }
                        else if (MissionData.MultiPed.Count == 0)
                        {
                            MissionData.iCashReward = MissionData.iAmbushCount * 1520;
                            ObjectHand.NSCoinInvestments(true, 8, 13, "Bobcat Security Shares");
                            MissionData.iMissionSeq = 40;
                        }
                    }
                }       // Abush player at end point
                else if (MissionData.iMissionVar_01 == 4)
                {
                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        ObjectHand.RemoveTargets();
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_03 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_02 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        UiDisplay.MMDisplay01.MarkCol = Color.MediumTurquoise;
                        float fSpeed = 20.00f;
                        int iDrive = 1073742653;
                        MissionData.Npc_01.Task.CruiseWithVehicle(MissionData.VehTrackin_01, fSpeed, iDrive);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[6])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.iMissionSeq = 9;
                                MissionData.BeOnOff[6] = false;
                                MissionData.BeOnOff[7] = true;

                                if (MissionData.VehTrackin_01.ClassType == VehicleClass.Compacts)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(5000, 6000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.Sedans)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(7000, 8000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.Coupes)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(15000, 21000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.Muscle)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(21000, 50000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.OffRoad)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(21000, 45000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.SUVs)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(22000, 48000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.Sports)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(55000, 85000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.SportsClassics)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(120000, 90000);
                                else if (MissionData.VehTrackin_01.ClassType == VehicleClass.Super)
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(140000, 100000);
                                else
                                    MissionData.iList_01[1] = ReturnStuff.RandInt(8000, 9000);

                                MissionData.fVehicleDamage = MissionData.VehTrackin_01.BodyHealth + MissionData.VehTrackin_01.EngineHealth + MissionData.VehTrackin_01.PetrolTankHealth;
                                MissionData.iList_01[2] = (int)MissionData.fVehicleDamage;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 11, DataStore.MyLang.Maptext[14]);

                                MissionData.iMishText = 63;
                            }
                        }
                        else if (MissionData.BeOnOff[8])
                        {
                            if (MissionData.VehTrackin_01.Position.Z > 101.01f)
                            {
                                MissionData.BeOnOff[8] = false;
                                float fSpeed = 15.00f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 10;
                            MissionData.BeOnOff[3] = false;
                            MissionData.BeOnOff[10] = true;
                            MissionData.BeOnOff[6] = false;
                            UiDisplay.bMMDisplay01 = false;
                            UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                            UiDisplay.MpUiDisplay.Remove(UiDisplay.BtSlideBar);
                            UiDisplay.ttTextBar_01.Label = "" + DataStore.MyLang.Othertext[10] + "";
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            UiDisplay.TheYellowCorona(MissionData.vTarget_02, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 524, DataStore.MyLang.Maptext[42]);

                            MissionData.iMishText = 64;

                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 5.00f)
                            {
                                MissionData.iCashReward = MissionData.iList_01[1] - MissionData.iList_01[3];
                                MissionData.iMissionSeq = 11;
                            }
                            else if (MissionData.BeOnOff[6])
                            {
                                if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 45.00f)
                                {
                                    MissionData.BeOnOff[6] = false;
                                    MoveThatCar(MissionData.vTarget_02);
                                }
                            }
                        }
                        else
                        {
                            MissionData.iMissionSeq = 9;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[14]);
                            ObjectHand.RemoveTargets();
                        }

                        if (MissionData.BeOnOff[10])
                        {
                            if (MissionData.iList_01[2] > 0 && MissionData.iList_01[1] > 0)
                                MissionData.iList_01[3] = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iList_01[2], MissionData.iList_01[1], true, MissionData.iList_01[3], false);
                        }

                    }
                    else if (MissionData.iMissionSeq == 11)
                    {
                        ObjectHand.NSCoinInvestments(false, 3, 9, "Augury Insurance Shares");
                        ObjectHand.SlowFastTravel(MissionData.vTarget_03, MissionData.fMission_01);
                        TheMissions.Follow_CArSaleSeatChecker();
                        MissionData.VehTrackin_01.Position = new Vector3(516.63f, -4391.54f, 0.01f);
                        MissionData.iMissionSeq = 40;
                    }
                }       // Have player steal and deliver a vehcle at end point
                else if (MissionData.iMissionVar_01 == 5)
                {
                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;

                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        MissionData.iMissionVar_03 = MissionData.iMissionVar_03 - 1;
                        MissionData.vTarget_02 = MissionData.VectorList_01[MissionData.iMissionVar_03];
                        ObjectBuild.VehicleSpawn("Frogger2", MissionData.vTarget_02, 0.00f, true, true, false, false, 5, 1, 0, "", 2, false);
                        UiDisplay.MMDisplay01.MarkCol = Color.AntiqueWhite;
                        MissionData.Npc_01.RelationshipGroup = DataStore.GP_ANPCs;
                        MissionData.Npc_02.RelationshipGroup = DataStore.GP_ANPCs;
                        float fSpeed = 20.00f;
                        ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                        {
                            MissionData.Npc_01.Health = 0;
                            MissionData.Npc_02.Health = 0;
                            MissionData.iMissionSeq = 45;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 55.0f)
                            MissionData.iMissionSeq = 9;

                        if (MissionData.BeOnOff[6])
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.BeOnOff[6] = false;
                                MissionData.BeOnOff[7] = true;
                                MissionData.BeOnOff[0] = true;
                                MissionData.iTracking = Game.GameTime + 1000;
                                UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                                SearchFor.SearchVeh(35.00f, 125.00f, "KURUMA2", false, false, false, false, 8, 9, 1, DataStore.MyLang.Maptext[20], 0, true, true);
                                SearchFor.SearchVeh(35.00f, 125.00f, "KURUMA2", false, false, false, false, 8, 9, 1, DataStore.MyLang.Maptext[20], 0, true, true);
                                float fSpeed = 45.00f;
                                ObjectBuild.DriveToDest(MissionData.VehTrackin_01, MissionData.vTarget_01, MissionData.Npc_01, fSpeed, MissionData.iCanDrive);

                                MissionData.iMishText = 65;
                            }
                        }
                        else
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.MultiPedTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 5.00f)
                        {
                            MissionData.iMissionSeq = 10;
                            MissionData.iTime_01[6] = Game.GameTime + 20000;
                            UiDisplay.bMMDisplay01 = false;
                            MissionData.VehTrackin_02.FreezePosition = false;
                            MissionData.Npc_03 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(32), MissionData.VehTrackin_02.Position, MissionData.VehTrackin_02.Heading, false, 180, 7, 1, MissionData.VehTrackin_02, 0, false, 0, 0, "");
                            TheMissions.Follow_RunToHeli();
                        }
                        else
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.MultiPedTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_02) && MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_02))
                            MissionData.iMissionSeq = 11;
                        else if (MissionData.iTime_01[6] < Game.GameTime)
                        {
                            MissionData.iMissionSeq = 11;
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_02, MissionData.Npc_01, 3);
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_02, MissionData.Npc_02, 4);
                        }
                        else
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.MultiPedTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 11)
                    {
                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_02) && MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_02))
                        {
                            MissionData.iMissionSeq = 40;
                            MissionData.BeOnOff[3] = false;
                            ObjectHand.NSCoinInvestments(true, 8, 12, "Eugenics Incorporated Shares");
                            MissionData.iCashReward = 20000;
                        }
                    }
                }       // Have player protect two in car against two attacking cars--heli fly away
                else if (MissionData.iMissionVar_01 == 6)
                {
                    if (MissionData.iMissionSeq == 7)
                    {
                        MissionData.iMissionSeq = 8;
                        MissionData.iWait4Sec = Game.GameTime + 12000;
                        UiDisplay.MMDisplay01.MarkCol = Color.LimeGreen;
                        float fSpeed = 20.00f;
                        MissionData.Npc_01.Task.CruiseWithVehicle(MissionData.VehTrackin_01, fSpeed, 262972);
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iMissionSeq = 9;
                            MissionData.BeOnOff[11] = true;
                            MissionData.BeOnOff[6] = false;
                            Vector3 V3Ufo = MissionData.VehTrackin_01.Position;
                            V3Ufo.Z += 500.00f;
                            MissionData.Prop_01 = ObjectBuild.BuildProp("p_spinning_anus_s", V3Ufo, Vector3.Zero, true, true);
                            MissionData.Prop_02 = ObjectBuild.BuildProp("ba_prop_battle_lights_fx_righ", V3Ufo, Vector3.Zero, true, true);
                            if (MissionData.Prop_01 != null && MissionData.Prop_02 != null)
                                MissionData.Prop_02.AttachTo(MissionData.Prop_01, MissionData.Prop_01.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 0.00f), new Vector3(0.00f, 60.00f, 30.00f));
                            MissionData.iWait4Sec = Game.GameTime + 500;
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                        UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);

                        if (MissionData.Npc_01.IsDead || MissionData.Npc_02.IsDead || MissionData.VehTrackin_01.HasBeenDamagedBy(Game.Player.Character) || !MissionData.Npc_01.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        if (MissionData.Prop_01.Position.Z > MissionData.VehTrackin_01.Position.Z + 15.00f && MissionData.BeOnOff[11])
                        {
                            MissionData.Prop_01.Position = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.Prop_01.Position.Z - 0.50f);
                            MissionData.Prop_01.Rotation = new Vector3(3.00f, 5.00f, MissionData.Prop_01.Rotation.Z + 1.5f);
                        }
                        else
                        {
                            if (MissionData.BeOnOff[11])
                            {
                                MissionData.BeOnOff[11] = false;
                                MissionData.iWait4Sec = Game.GameTime + 6000;
                            }
                            else if (MissionData.iWait4Sec < Game.GameTime)
                            {
                                MissionData.iMissionSeq = 10;
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.EngineRunning = false;
                                MissionData.VehTrackin_01.FreezePosition = true;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                UiDisplay.bMMDisplay01 = false;
                                MissionData.fMission_01 = MissionData.VehTrackin_01.Position.Z;
                                MissionData.iMishText = 66;
                            }
                            else
                            {
                                MissionData.Prop_01.Position = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 15.00f);
                                MissionData.Prop_01.Rotation = new Vector3(3.00f, 5.00f, MissionData.Prop_01.Rotation.Z + 1.5f);
                            }

                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        if (MissionData.fMission_01 < 750.00f)
                        {
                            MissionData.fMission_01 = MissionData.fMission_01 + 0.50f;
                            MissionData.VehTrackin_01.Position = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.fMission_01);
                            MissionData.Prop_01.Position = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 15.00f);
                            MissionData.Prop_01.Rotation = new Vector3(3.00f, 2.00f, MissionData.Prop_01.Rotation.Z + 1.5f);
                        }
                        else
                        {
                            ObjectHand.NSCoinInvestments(true, 9, 12, "Pißwasser Shares");
                            MissionData.iCashReward = 10000;
                            MissionData.iMissionSeq = 40;
                        }
                    }
                }       // Alan abuction...
            }        //Follow
            else if (MissionData.iJobType == 9)
            {
                if (Game.Player.WantedLevel > 0)
                    Game.Player.WantedLevel = 0;

                if (MissionData.BeOnOff[2])
                    Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");

                if (MissionData.iMissionSeq == 0)
                {
                    if (MissionData.bReFire)
                        ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                    else
                    {
                        MissionData.VehTrackin_01 = World.CreateVehicle(VehicleHash.FireTruck, MissionData.vGetaway, MissionData.fGetDir);
                        ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                    }
                    MissionData.iMissionSeq = 1;
                    MissionData.BeOnOff[3] = true;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 3;
                        MissionData.BeOnOff[3] = false;
                        MissionData.VehTrackin_01.CurrentBlip.Remove();

                        if (MissionData.iMissionVar_01 == 1 || MissionData.iMissionVar_01 == 5)
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 65.00f, false, 66, DataStore.MyLang.Maptext[26]);
                        else if (MissionData.iMissionVar_01 == 4)
                        { }
                        else
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 436, DataStore.MyLang.Maptext[42]);

                        MissionData.vLanLoc = MissionData.vTarget_01;
                        if (MissionData.iMissionVar_01 == 1)
                            MissionData.iMishText = 68;
                        else if (MissionData.iMissionVar_01 == 2)
                            MissionData.iMishText = 69;
                        else if (MissionData.iMissionVar_01 == 3)
                            MissionData.iMishText = 70;
                        else if (MissionData.iMissionVar_01 == 4)
                            MissionData.iMishText = 71;
                        else
                            MissionData.iMishText = 72;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 55.00f)
                    {
                        MissionData.iMishText = 189;
                        if (!MissionData.bReFire)
                        {
                            if (!MissionData.VehTrackin_01.IsOnAllWheels)
                            {
                                MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                                MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                            }
                        }
                    }
                    else
                    {
                        if (!MissionData.bReFire)
                            MissionData.iMishText = 67;
                    }
                }
                else if (MissionData.iMissionSeq == 25)
                {
                    MissionData.bReFire = true;
                    ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                    MissionData.BlipList_01.Clear();
                    MissionData.iMissionSeq = 99;
                    ObjectHand.ControlSelect(8, false);
                }
                else if (MissionData.iMissionSeq == 40)
                {
                    if (MissionData.iRepMisssion < 25)
                    {
                        if (MissionData.iRepMisssion > 4)
                            ObjectHand.NSCoinInvestments(true, MissionData.iRepMisssion - 2, MissionData.iRepMisssion, "Mors Mutual Shares");
                        else
                            ObjectHand.NSCoinInvestments(true, 0, 1, "Mors Mutual Shares");
                    }
                    else
                        ObjectHand.NSCoinInvestments(true, 27, 28, "Mors Mutual Shares");
                    if (MissionData.BeOnOff[3])
                    {
                        MissionData.BeOnOff[3] = false;
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                    }
                    if (MissionData.BeOnOff[1])
                    {
                        MissionData.BeOnOff[2] = false;
                        ZancudaClosed();
                    }
                    MissionData.VehTrackin_01.MarkAsNoLongerNeeded();
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (MissionData.BeOnOff[4])
                    {
                        MissionData.BeOnOff[4] = false;
                        MissionData.Npc_01.Detach();
                    }
                    if (MissionData.BeOnOff[1])
                    {
                        MissionData.BeOnOff[2] = false;
                        MissionData.BeOnOff[1] = false;
                        ZancudaClosed();
                    }
                    if (MissionData.BeOnOff[3])
                    {
                        MissionData.BeOnOff[3] = false;
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                    }
                    MissionData.VehTrackin_01.MarkAsNoLongerNeeded();
                    TheMissions.GameOver(true, "", false, 0);
                }
                else if (MissionData.iMissionVar_01 == 1)
                {
                    if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[3])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 65.00f, false, 66, DataStore.MyLang.Maptext[26]);
                                MissionData.iMishText = 68;
                            }
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 55.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            ObjectHand.RemoveTargets();
                            int iRanCar = ReturnStuff.RandInt(1, 16);
                            MissionData.VehTrackin_02 = null;
                            int iVe = ReturnStuff.RandInt(1, 13);
                            SearchFor.SearchVeh(35.00f, 125.00f, ReturnStuff.RanVehListX(iVe, 1, true), false, false, false, false, 0, 0, 3, "", 2, true, false);
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                MissionData.iMishText = 189;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_02 != null)
                        {
                            MissionData.iMissionSeq = 5;
                            MissionData.iMissionVar_02 = Game.GameTime + 60000;
                            YourFired(MissionData.VehTrackin_02.Position.X, MissionData.VehTrackin_02.Position.Y, MissionData.VehTrackin_02.Position.Z + 1.00f);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.VehTrackin_02.Position.X, MissionData.VehTrackin_02.Position.Y, MissionData.VehTrackin_02.Position.Z + 2.00f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_02.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Red };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, 4.00f);
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 73;
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead || ReturnStuff.Fire_BurnOut() || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 45;
                            MissionData.VehTrackin_02.Explode();
                            UiDisplay.bMMDisplay01 = false;
                            if (UiDisplay.bUiDisplay)
                                UiDisplay.bUiDisplay = false;
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.VehTrackin_02.Position) < 30.00f)
                        {
                            if (MissionData.iFireList.Count() > 0)
                            {
                                if (ReturnStuff.Fire_IntheHall(MissionData.VehTrackin_02.Position))
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.iMissionSeq = 6;
                                    MissionData.BeOff[1] = false;
                                    UiDisplay.bMMDisplay01 = false;

                                    if (UiDisplay.bUiDisplay)
                                        UiDisplay.bUiDisplay = false;
                                }
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[18], 1);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        MissionData.iMissionSeq = 25;
                    }
                }       // Put out vehicle fire
                else if (MissionData.iMissionVar_01 == 2)
                {
                    if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[3])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 436, DataStore.MyLang.Maptext[42]);
                                MissionData.iMishText = 69;
                            }
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 55.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.iMissionVar_02 = Game.GameTime + 60000;
                            ObjectHand.RemoveTargets();
                            YourFired(MissionData.vTarget_01.X, MissionData.vTarget_01.Y, MissionData.vTarget_01.Z - 1.00f);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = MissionData.vTarget_01, MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, 0.00f), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Red };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 73;
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                MissionData.iMishText = 189;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || ReturnStuff.Fire_BurnOut() || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 45;

                            UiDisplay.bMMDisplay01 = false;
                            if (UiDisplay.bUiDisplay)
                                UiDisplay.bUiDisplay = false;
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 30.00)
                        {
                            if (MissionData.iFireList.Count > 0)
                            {
                                if (ReturnStuff.Fire_IntheHall(MissionData.vTarget_01))
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.iMissionSeq = 5;
                                    UiDisplay.bMMDisplay01 = false;

                                    if (UiDisplay.bUiDisplay)
                                        UiDisplay.bUiDisplay = false;
                                }
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[18], 1);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMissionSeq = 25;
                    }
                }       // Put out house fire
                else if (MissionData.iMissionVar_01 == 3)
                {
                    if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[3])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 436, DataStore.MyLang.Maptext[42]);
                                MissionData.iMishText = 70;
                            }
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 55.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                            ObjectHand.RemoveTargets();
                            YourFired(MissionData.vTarget_01.X, MissionData.vTarget_01.Y, MissionData.vTarget_01.Z + 1.00f);
                            int iBinit = MissionData.sList_01.Count - 1;
                            int iRanBin = ReturnStuff.RandInt(0, iBinit);
                            MissionData.iMissionVar_02 = Game.GameTime + 60000;
                            ObjectBuild.BuildProp(MissionData.sList_01[iRanBin], MissionData.vTarget_01, Vector3.Zero, true, true);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = MissionData.vTarget_01, MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, 0.00f), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Red };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, 3.00f);
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 73;
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                MissionData.iMishText = 189;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead || ReturnStuff.Fire_BurnOut())
                        {
                            MissionData.iMissionSeq = 45;
                            UiDisplay.bMMDisplay01 = false;

                            if (UiDisplay.bUiDisplay)
                                UiDisplay.bUiDisplay = false;
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 30.00)
                        {
                            if (MissionData.iFireList.Count > 0)
                            {
                                if (ReturnStuff.Fire_IntheHall(MissionData.vTarget_01))
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.iMissionSeq = 5;
                                    UiDisplay.bMMDisplay01 = false;

                                    if (UiDisplay.bUiDisplay)
                                        UiDisplay.bUiDisplay = false;
                                }
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[18], 1);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMissionSeq = 25;
                    }
                }       // Put out bin fire
                else if (MissionData.iMissionVar_01 == 4)
                {
                    if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(Game.Player.Character.Position, MissionData.vTarget_01) < 155.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.iMissionVar_02 = 0;
                        }
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 442, DataStore.MyLang.Maptext[107]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                                MissionData.iMishText = 71;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                MissionData.iMishText = 189;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(Game.Player.Character.Position, MissionData.vTarget_01) < 3.00f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 < MissionData.VectorList_03.Count - 1)
                            {
                                MissionData.vTarget_01 = MissionData.VectorList_03[MissionData.iMissionVar_02];
                                MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 442, DataStore.MyLang.Maptext[107]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                            }
                            else
                            {
                                MissionData.iMissionSeq = 5;
                                MissionData.vTarget_01 = MissionData.VectorList_03[MissionData.iMissionVar_02];
                                MissionData.vLanLoc = Vector3.Zero;
                                MissionData.Npc_01 = ObjectBuild.NPCSpawn("a_c_cat_01", MissionData.vTarget_01, 0.00f, false, 180, 12, 0, null, 0, true, 18, 0, DataStore.MyLang.Maptext[107]);
                                MissionData.Npc_01.IsInvincible = true;

                                UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.Npc_01.Position.X, MissionData.Npc_01.Position.Y, MissionData.Npc_01.Position.Z + 1.00f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.Npc_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.AntiqueWhite };
                                UiDisplay.bMMDisplay01 = true;
                                MissionData.iMishText = 74;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (Game.Player.Character.Position.Z < MissionData.Npc_01.Position.Z)
                            MissionData.iMishText = 74;
                        else
                            MissionData.iMishText = 75;

                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        {
                            UiDisplay.bMMDisplay01 = false;
                            MissionData.iMissionSeq = 45;
                        }
                        else if (World.GetDistance(Game.Player.Character.Position, MissionData.Npc_01.Position) < 1.10f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq = 6;
                            MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -1.00f);
                            MissionData.Npc_01.HasCollision = false;
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, MissionData.Npc_01.Handle, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_PED_BONE_INDEX, Game.Player.Character.Handle, 31086), 0.27f, -0.00f, 0.17f, 0.00f, 0.00f, 0.00f, false, false, false, false, 2, true);
                            //MissionData.Npc_01.AttachTo(Game.Player.Character, Game.Player.Character.GetBoneIndex("SKEL_ROOT"), new Vector3(0.00f, 0.00f, 1.00f), new Vector3(0.00f, 0.00f, 0.00f));
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Npc_02 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), MissionData.vTarget_03, 0.01f, false, 190, 13, 0, null, 0, false, 0, 0, "");
                            UiDisplay.bMMDisplay01 = false;
                            MissionData.BeOnOff[4] = true;
                            MissionData.iMishText = 76;
                        }
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.BeOnOff[3])
                            {
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                            }
                        }
                        else
                        {
                            if (!MissionData.BeOnOff[3])
                            {
                                MissionData.BeOnOff[3] = true;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.vTarget_02, MissionData.VehTrackin_01.Position) < 5.00f)
                        {
                            if (Game.Player.Character.IsInVehicle())
                                MissionData.iMishText = 78;
                            else
                            {
                                MissionData.iMissionSeq = 7;
                                ReturnStuff.PedBlimp(MissionData.Npc_02, 0.75f, true, true, 53, DataStore.MyLang.Maptext[55]);
                                ObjectHand.RemoveTargets();
                                MissionData.iMishText = 77;
                            }
                        }
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.BeOnOff[3])
                            {
                                MissionData.BeOnOff[3] = false;
                                UiDisplay.TheYellowCorona(MissionData.vTarget_02, 10.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 442, DataStore.MyLang.Maptext[55]);
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.iMishText = 77;
                            }
                        }
                        else
                        {
                            MissionData.iMishText = 76;

                            if (!MissionData.BeOnOff[3])
                            {
                                MissionData.BeOnOff[3] = true;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                ObjectHand.RemoveTargets();
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[4])
                        {
                            if (MissionData.vTarget_03.DistanceTo(Game.Player.Character.Position) < 8.50f || MissionData.Npc_02.Position.DistanceTo(MissionData.vTarget_03) > 3.00f)
                            {
                                MissionData.BeOnOff[4] = false;
                                MissionData.Npc_01.Detach();
                                MissionData.Npc_01.Position = (Game.Player.Character.Position) + (Game.Player.Character.ForwardVector * 2.00f);
                                MissionData.iWait4Sec = Game.GameTime + 3500;
                                ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.Npc_02.Position, 2.00f);
                                MissionData.iMishText = -1;
                            }
                        }
                        else
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                                MissionData.iMissionSeq = 8;
                        }
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        MissionData.iMissionSeq = 25;
                        MissionData.iCashBouns = ReturnStuff.RandInt(10, 100);
                    }
                }       // Save cat from high place--Add go here cones to make bit easyer to find the cat...
                else if (MissionData.iMissionVar_01 == 5)
                {
                    if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[3])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 65.00f, false, 66, DataStore.MyLang.Maptext[26]);
                                MissionData.iMishText = 72;
                            }
                        }
                        else if (World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) < 55.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            ObjectHand.RemoveTargets();
                            int iRanCar = ReturnStuff.RandInt(1, 9);
                            MissionData.VehTrackin_02 = null;
                            int iVe = ReturnStuff.RandInt(1, 13);
                            SearchFor.SearchVeh(35.00f, 125.00f, ReturnStuff.RanVehListX(iVe, 1, true), false, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[20], 2, true, true);
                        }
                        else
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[3] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, true, 66, DataStore.MyLang.Maptext[8]);
                                MissionData.iMishText = 189;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_02 != null)
                        {
                            MissionData.iMissionSeq = 5;
                            MissionData.VehTrackin_02.IsFireProof = false;
                            MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), MissionData.VehTrackin_02.Position, MissionData.VehTrackin_02.Heading, false, 130, 2, 1, MissionData.VehTrackin_02, 6, false, 0, 0, "");
                            MissionData.VehTrackin_02.RollDownWindows();
                            MissionData.iTime_01[0] = Game.GameTime + ReturnStuff.RandInt(15000, 25000);
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.BeOff[1])
                        {
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 79;
                            MissionData.BeOff[1] = false;
                        }

                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsDead)
                        {
                            MissionData.iMissionSeq = 6;
                            MissionData.iCashBouns = 1000;
                            MissionData.VehTrackin_02.Explode();
                        }
                        if (MissionData.iTime_01[0] < Game.GameTime)
                        {
                            MissionData.iMissionSeq = 6;
                            MissionData.iCashBouns = 50;
                            MissionData.VehTrackin_02.Explode();
                        }
                        else if (MissionData.iWait4Sec < Game.GameTime)
                            TheMissions.Fire_ShootRanPed();
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        MissionData.iMissionSeq = 25;
                        MissionData.iMishText = -1;
                    }
                }       // Chase driver throwing molitovs
            }        //Fire
            else if (MissionData.iJobType == 10)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;

                    float fVehCheck = MissionData.VehTrackin_01.BodyHealth + MissionData.VehTrackin_01.EngineHealth + MissionData.VehTrackin_01.PetrolTankHealth;
                    MissionData.iMissionVar_04 = (int)fVehCheck;

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                    MissionData.vLanLoc = MissionData.vGetaway;
                    MissionData.iMishText = 80;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(Game.Player.Character.Position) < 50.00f)
                    {
                        MissionData.vLanLoc = Vector3.Zero;
                        MissionData.iMishText = 81;

                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.vLanLoc = MissionData.vTarget_01;
                            MissionData.iMishText = 82;
                            MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 50.00f, false, 488, DataStore.MyLang.Maptext[42]);

                        }
                        else if (!MissionData.VehTrackin_01.IsOnAllWheels)
                        {
                            MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                            MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                        }
                    }
                    else
                    {
                        MissionData.vLanLoc = MissionData.vGetaway;
                        MissionData.iMishText = 80;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        if (!MissionData.BeOnOff[1])
                        {
                            MissionData.BeOnOff[1] = true;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 66, DataStore.MyLang.Maptext[9]);
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 81;
                        }
                    }
                    else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 90.0f)
                    {
                        MissionData.iMissionSeq = 3;
                        TheMissions.Johnny_PlayerAntics();
                        if (MissionData.BeOnOff[0])
                        {
                            MoveThatCar(MissionData.vTarget_01);
                            MissionData.BeOnOff[0] = false;
                        }
                    }
                    else
                    {
                        if (MissionData.BeOnOff[1])
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.vLanLoc = MissionData.vTarget_01;
                            MissionData.iMishText = 82;
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 50.00f, false, 488, DataStore.MyLang.Maptext[42]);
                            MissionData.BeOnOff[1] = false;
                        }

                        if (MissionData.iMissionVar_04 > 0 && MissionData.iCashBouns > 0)
                            MissionData.iCashReward = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iMissionVar_04, MissionData.iCashBouns, true, MissionData.iCashReward, false);
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        if (!MissionData.BeOnOff[1])
                        {
                            MissionData.BeOnOff[1] = true;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 66, DataStore.MyLang.Maptext[9]);
                            MissionData.vLanLoc = Vector3.Zero;
                            MissionData.iMishText = 81;
                        }
                    }
                    else if (World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 30.0f)
                    {
                        MissionData.BeOnOff[1] = true;
                        MissionData.iMissionSeq = 4;
                        MissionData.vLanLoc = Vector3.Zero;
                        MissionData.iMishText = 83;
                    }
                    else
                    {
                        if (MissionData.BeOnOff[1])
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.vLanLoc = MissionData.vTarget_01;
                            MissionData.iMishText = 82;
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 50.00f, false, -1, DataStore.MyLang.Maptext[42]);
                            MissionData.BeOnOff[1] = false;
                        }
                        if (MissionData.iMissionVar_04 > 0 && MissionData.iCashBouns > 0)
                            MissionData.iCashReward = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iMissionVar_04, MissionData.iCashBouns, true, MissionData.iCashReward, false);
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    MissionData.iMissionSeq = 5;
                    UiDisplay.bUiDisplay = false;
                    MissionData.iCashReward += 200;
                    MissionData.VehTrackin_01.Repair();
                    UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_01);
                    UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_02);
                    ObjectHand.AddTarget(MissionData.vTarget_01, false, false, 50.00f, false, -1, DataStore.MyLang.Maptext[56]);
                    MissionData.iWait4Sec = Game.GameTime + 30000;
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        if (World.GetDistance(Game.Player.Character.Position, MissionData.vTarget_01) < 50.00f || World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) > 48.00f)
                            MissionData.iMissionSeq = 7;
                        else
                            MissionData.iMissionSeq = 6;

                        MissionData.iMishText = -1;
                    }
                    if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        if (MissionData.BeOnOff[1])
                        {
                            MissionData.BeOnOff[1] = false;
                            ObjectHand.CleanUpCorrona(MissionData.iCoronaList, true);
                            MissionData.iCoronaList.Clear();
                        }
                        if (World.GetDistance(Game.Player.Character.Position, MissionData.vTarget_01) > 50.00f && World.GetDistance(MissionData.vTarget_01, MissionData.VehTrackin_01.Position) < 48.00f)
                            MissionData.iMissionSeq = 6;
                    }
                    ObjectHand.FindTheTime(MissionData.iWait4Sec - Game.GameTime, 9, "", true);
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.iCashReward > 20000)
                        ObjectHand.NSCoinInvestments(false, 5, 7, "Mors Mutual Shares");

                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    MissionData.bPlayerAtt = true;
                    MissionData.iMissionSeq = 45;
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //Johnny
            else if (MissionData.iJobType == 11)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    ObjectBuild.VehicleSpawn(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[0], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[0], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceHead[0], false, MissionData.BeOnOff[0], false, false, 21, 1, 66, "", 1, true);
                    MissionData.iMissionSeq = 1;
                    MultiBlimbs(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[3], 309, true, DataStore.MyLang.Maptext[117]);
                    Vector3 Marky = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[3];
                    UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.UpsideDownCone, MarkPos = Marky, MarkDir = Vector3.Zero, MarkRot = Vector3.Zero, MarkScale = new Vector3(5.50f, 5.50f, 5.50f), MarkCol = Color.Yellow };

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);

                    MissionData.iMishText = 84;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }

                    if (!Game.Player.Character.IsInVehicle())
                    {
                        MissionData.iMishText = 84;
                        if (World.GetDistance(MissionData.VehTrackin_01.Position, Game.Player.Character.Position) < 5.00f)
                        {

                            UiDisplay.ControlerUI("~INPUT_DETONATE~ " + ReturnStuff.GetEntName(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[MissionData.iList_01[4]]) + " ~INPUT_CONTEXT~", 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (MissionData.iList_01[4] > 0)
                                    MissionData.iList_01[4] -= 1;
                                else
                                    MissionData.iList_01[4] = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh.Count - 1;

                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01.Delete();
                                ObjectBuild.VehicleSpawn(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[MissionData.iList_01[4]], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[0], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceHead[0], false, false, false, false, 21, 1, 0, "", 1, true);
                                MissionData.sMissionVar_01 = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[MissionData.iList_01[4]];
                            }
                            else if (Game.IsControlJustPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iList_01[4] + 1 < MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh.Count)
                                    MissionData.iList_01[4] += 1;
                                else
                                    MissionData.iList_01[4] = 0;

                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01.Delete();
                                ObjectBuild.VehicleSpawn(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[MissionData.iList_01[4]], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[0], MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceHead[0], false, false, false, false, 21, 1, 0, "", 1, true);
                                MissionData.sMissionVar_01 = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].AvalableVeh[MissionData.iList_01[4]];
                            }
                        }
                    }
                    else if (World.GetDistance(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[3], Game.Player.Character.Position) < 2.50f)
                    {
                        UiDisplay.bMMDisplay01 = false;
                        MissionData.iMissionSeq = 2;
                        ObjectHand.RemoveTargets();
                        Game.Player.Character.CurrentVehicle.FreezePosition = true;
                        TheMissions.Racist_StartLine();
                        MissionData.vTarget_01 = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace[0];
                        MissionData.VehTrackin_01 = Game.Player.Character.CurrentVehicle;
                    }
                    else if (World.GetDistance(MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[3], Game.Player.Character.Position) < 90.0f)
                    {
                        Vector3 Marky = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].RaceCars[3];
                        if (!UiDisplay.bMMDisplay01)
                            UiDisplay.bMMDisplay01 = true;

                        //if (Game.Player.Character.CurrentVehicle.ClassType == MissionData.VehTrackin_01.ClassType || MissionData.bSoloRace || DataStore.bOnCayoLand)
                        //   MissionData.iMishText = 85;
                        //else
                        //   MissionData.iMishText = 86;

                        ClearTheWay(false);
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {

                    MissionData.iMissionSeq = 3;
                    MissionData.iMishText = -1;
                    TheMissions.Racist_CountDown(MissionData.vTarget_01, !MissionData.bSoloRace);

                    if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                    {
                        MissionData.VehTrackin_01.IsDriveable = true;
                        Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_01, false);
                    }
                    else
                        MissionData.VehTrackin_01.FreezePosition = false;

                    if (!MissionData.bSoloRace)
                    {
                        if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                        {
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_02, false);
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_03, false);
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_04, false);
                        }

                        MissionData.VehTrackin_02.FreezePosition = false;
                        MissionData.VehTrackin_03.FreezePosition = false;
                        MissionData.VehTrackin_04.FreezePosition = false;
                    }

                    MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace.Count - 1);

                    MissionData.vTarget_02 = MissionData.vTarget_01;
                    ClearTheWay(true);
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (!Game.Player.Character.IsInVehicle() || ReturnStuff.ButtonDown(75))
                        TheMissions.Racist_BackOnTrack(Game.Player.Character, MissionData.VehTrackin_01, MissionData.vTarget_02, MissionData.fMission_01, true, true);
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < MissionData.fCorSize + 5.00f)
                    {
                        MissionData.iMissionSeq = 4;
                        MissionData.iCurrentLap -= 1;
                        MissionData.iList_01[1] = Game.GameTime;//worldtime
                        MissionData.iList_01[2] = Game.GameTime;//currenttime
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[31], 5000);
                        int iOnLap = MissionData.iTotalLap - MissionData.iCurrentLap;
                        BigMessageThread.MessageInstance.ShowSimpleShard("LAP " + iOnLap + "/" + MissionData.iTotalLap + "", "", 5000);
                        MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                        MissionData.fMission_01 = MissionData.VehTrackin_01.Heading;
                    }
                    TheMissions.Racist_PosTime(false);

                    ClearTheWay(true);
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (!Game.Player.Character.IsInVehicle() || ReturnStuff.ButtonDown(75))
                        TheMissions.Racist_BackOnTrack(Game.Player.Character, MissionData.VehTrackin_01, MissionData.vTarget_02, MissionData.fMission_01, true, true);
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < MissionData.fCorSize + 5.00f)
                    {
                        if (MissionData.iList_01[6] == MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace.Count - 1)
                        {
                            if (MissionData.iCurrentLap == 0)
                                MissionData.iList_01[6] = ReturnStuff.CheckPointPro(true, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            else
                                MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            MissionData.iList_01[3] += 1;
                        }
                        else if (MissionData.iList_01[6] == 0)
                        {
                            MissionData.iCurrentLap -= 1;
                            int iLapX = MissionData.iList_01[2] - Game.GameTime;
                            MissionData.iDeliverList.Add(iLapX);
                            MissionData.iList_01[2] = Game.GameTime;

                            if (MissionData.iCurrentLap < 0)
                                MissionData.iMissionSeq = 5;
                            else
                            {
                                int iOnLap = MissionData.iTotalLap - MissionData.iCurrentLap;
                                BigMessageThread.MessageInstance.ShowSimpleShard("LAP " + iOnLap + "/" + MissionData.iTotalLap + "", "", 5000);
                                MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            }
                        }
                        else
                            MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                    }

                    TheMissions.Racist_PosTime(true);

                    ClearTheWay(true);
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    MissionData.iMissionSeq = 99;
                    TheMissions.RaceEnd(false);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    MissionData.iMissionSeq = 99;
                    if (MissionData.bIsVehPers)
                        MissionData.VehTrackin_01.IsPersistent = false;
                    TheMissions.RaceEnd(true);
                }
            }       //Racist
            else if (MissionData.iJobType == 12)
            {//bbomb find the bomb before timer runs out
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    MissionData.vTarget_05 = MissionData.vTarget_01.Around(25.00f);
                    MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, 1.00f);
                    ObjectHand.AddTarget(MissionData.vTarget_05, true, true, 60.00f, true, 486, DataStore.MyLang.Maptext[26]);
                    MissionData.iWait4Sec = Game.GameTime + 1000;
                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(World.GetNextPositionOnStreet(MissionData.vFuMiss), 0.00f);
                    MissionData.vLanLoc = MissionData.vTarget_05;
                    MissionData.iMishText = 87;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 155.00f)
                    {
                        MissionData.iMissionSeq = 2;
                        ObjectHand.RemoveTargets();
                        MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                        MissionData.Prop_01 = ObjectBuild.BuildProp("ex_prop_adv_case_sm_flash", MissionData.vTarget_01, new Vector3(0.00f, 0.00f, MissionData.fMission_01 - 0.4f), false, false);
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 3;
                        ObjectHand.AddTarget(MissionData.vTarget_05, true, false, 60.00f, true, -1, DataStore.MyLang.Maptext[26]);
                        int iNoPed = ReturnStuff.RandInt(1, 4);
                        SearchFor.UseAmbPed(World.GetNextPositionOnSidewalk(MissionData.vTarget_05), 60.00f, iNoPed, 4, "");
                        MissionData.iTime_01[0] = Game.GameTime + 120000;
                        MissionData.vLanLoc = Vector3.Zero;
                        MissionData.iMishText = 88;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.iTime_01[0] > Game.GameTime)
                    {
                        if (ReturnStuff.PickupBling(MissionData.Prop_01))
                        {
                            MissionData.iMissionSeq = 4;
                            UiDisplay.bUiDisplay = false;
                            ObjectHand.RemoveTargets();
                            ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 305, DataStore.MyLang.Maptext[57]);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.vTarget_02.X, MissionData.vTarget_02.Y, MissionData.vTarget_02.Z + 0.5f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, 0.00f), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Yellow };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.vFuMiss = MissionData.vTarget_03;
                            MissionData.iMishText = 89;
                            TheMissions.BbBomb_BombSquad();
                        }
                        ObjectHand.FindTheTime(MissionData.iTime_01[0] - Game.GameTime, 9, "", true);
                    }
                    else
                    {
                        MissionData.iMissionSeq = 45;
                        World.AddExplosion(MissionData.vTarget_01, ExplosionType.PetrolPump, 10.00f, 10.00f, true, false);
                        MissionData.Prop_01.Position = Vector3.Zero;
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_02) < 2.00f)
                    {
                        MissionData.iMishText = -1;
                        UiDisplay.bMMDisplay01 = false;
                        MissionData.iMissionSeq = 5;
                        MissionData.Prop_01 = null;
                        ObjectHand.RemoveTargets();
                        MissionData.iWait4Sec = Game.GameTime + 2000;
                        Game.Player.Character.Task.PlayAnimation("anim@mp_fireworks", "place_firework_3_box", 8.00f, 3000, true, 1.00f);
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 6;
                        MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -1.05f);
                        ObjectBuild.BuildProp("ex_prop_adv_case_sm_flash", MissionData.vTarget_02, Vector3.Zero, false, true);
                        ObjectBuild.ScaredBy(MissionData.vTarget_02);
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.bTestRun)
                    {
                        MissionData.iMissionSeq = 99;
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else
                    {
                        MissionData.iCashReward = ReturnStuff.RandInt(4000, 5000);
                        ObjectHand.NSCoinInvestments(true, 7, 9, "Mors Mutual Shares");
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (!MissionData.bTestRun)
                        ObjectHand.NSCoinInvestments(false, 7, 11, "Mors Mutual Shares");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //bBomb
            else if (MissionData.iJobType == 13)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                    ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 458, DataStore.MyLang.Maptext[42]);

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);

                    MissionData.iMishText = 90;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    if (MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 10.50f)
                        {
                            MissionData.BeOnOff[0] = false;
                            ObjectHand.DoorsNear(MissionData.vTarget_01, 6.00f, false);
                        }
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 2.50f)
                    {
                        if (!Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq = 99;
                            ObjectBuild.GunningIt(Game.Player.Character, 11);
                            ObjectHand.RemoveTargets();
                            TheMissions.HitMan_SecurtyDetail(MissionData.sMissionVar_01, MissionData.VectorList_01, MissionData.fList_01);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.PedList_01.Count > 4)
                    {
                        MissionData.iMissionSeq = 3;

                        if (MissionData.fList_01.Count > 0)
                            ObjectBuild.PedScenario(MissionData.Npc_01, "WORLD_HUMAN_AA_SMOKE", MissionData.Npc_01.Position, MissionData.fList_01[MissionData.fList_01.Count - 1], false);
                        else
                            ObjectBuild.PedScenario(MissionData.Npc_01, "WORLD_HUMAN_AA_SMOKE", MissionData.Npc_01.Position, 0.00f, false);

                        MissionData.Npc_01.CurrentBlip.Color = BlipColor.Purple;
                        MissionData.PedList_01[1].Task.Wait(-1);
                        MissionData.PedList_01[2].Task.Wait(-1);

                        MissionData.PedList_01[3].Position = MissionData.VectorList_02[0];
                        MissionData.iList_01[0] = ReturnStuff.PedWalkies(MissionData.PedList_01[3], MissionData.VectorList_02, 0);
                        MissionData.PedList_01[4].Position = MissionData.VectorList_03[0];
                        MissionData.iList_01[1] = ReturnStuff.PedWalkies(MissionData.PedList_01[4], MissionData.VectorList_03, 0);
                        MissionData.PedList_01[5].Position = MissionData.VectorList_04[0];
                        MissionData.iList_01[2] = ReturnStuff.PedWalkies(MissionData.PedList_01[5], MissionData.VectorList_04, 0);


                        UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.Npc_01.Position.X, MissionData.Npc_01.Position.Y, MissionData.Npc_01.Position.Z + 1.00f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.Npc_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Purple };
                        UiDisplay.bMMDisplay01 = true;

                        MissionData.iWait4Sec = Game.GameTime + 1000;
                        MissionData.BeOnOff[1] = true;

                        MissionData.iMishText = 91;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.iWait4Sec < Game.GameTime && MissionData.BeOnOff[1])
                    {
                        MissionData.iWait4Sec = Game.GameTime + 1000;
                        MissionData.BeOnOff[1] = false;
                        TheMissions.Hitman_ManualAI();
                    }
                    else if (MissionData.Npc_01.IsDead)
                    {
                        if (MissionData.Npc_01.WasKilledByStealth)
                        {
                            MissionData.iCashReward = ReturnStuff.RandInt(50000, 55000);

                            if (DataStore.bOnCayoLand)
                                DataStore.MySettings.AssZone07 += 1;
                            else if (MissionData.iLocationX == 1)
                                DataStore.MySettings.AssZone01 += 1;
                            else if (MissionData.iLocationX == 2)
                                DataStore.MySettings.AssZone02 += 1;
                            else if (MissionData.iLocationX == 3)
                                DataStore.MySettings.AssZone03 += 1;
                            else if (MissionData.iLocationX == 4)
                                DataStore.MySettings.AssZone04 += 1;
                            else if (MissionData.iLocationX == 5)
                                DataStore.MySettings.AssZone05 += 1;
                            else
                                DataStore.MySettings.AssZone06 += 1;

                            ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                            ObjectHand.NSCoinInvestments(true, 7, 12, "LCN Shares");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                        else
                        {
                            MissionData.iMissionSeq = 45;
                        }
                        UiDisplay.bMMDisplay01 = false;
                    }
                    else if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;
                    else if (MissionData.Npc_01.Position.DistanceTo(Game.Player.Character.Position) < 10.00f)
                    {
                        if (Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Game.Player.Character.Handle))
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[19], 1);
                        else
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[20], 1);
                    }
                }
                else if (MissionData.iMissionSeq == 40)
                {
                    MissionData.iMishText = -1;
                    UiDisplay.bMMDisplay01 = false;
                    MissionData.iMissionSeq = 41;
                    MissionData.iWait4Sec = Game.GameTime + 25000;
                }
                else if (MissionData.iMissionSeq == 41)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                        MissionData.iMissionSeq = 45;
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.Hitman_RemoveVisionCones();
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //Hitman
            else if (MissionData.iJobType == 14)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (MissionData.PedList_01.Count > 0)
                    {
                        MissionData.iMissionSeq = 1;
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);

                        MissionData.iMishText = 92;
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }

                    if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 2;
                        MissionData.BeOnOff[4] = false;
                        MissionData.BeOnOff[5] = true;
                        MissionData.iMissionVar_03 = 0;
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                        Game.Player.Character.CanBeDraggedOutOfVehicle = true;
                        MissionData.iMissionVar_01 = MissionData.VectorList_01.Count - 1;
                        MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                        MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 408, DataStore.MyLang.Maptext[58]);
                        MissionData.iMishText = 93;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 35.00F)
                    {
                        MissionData.iMishText = 94;

                        if (!MissionData.VehTrackin_01.IsOnAllWheels)
                        {
                            MissionData.VehTrackin_01.Position = MissionData.vGetaway;
                            MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                        }
                    }
                    else
                        MissionData.iMishText = 92;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 2.50f)
                    {
                        MissionData.iMishText = 95;
                        if (!Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq = 3;
                            MissionData.iMissionVar_01 -= 1;
                            MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else if (MissionData.Target_01 == null)
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 408, DataStore.MyLang.Maptext[58]);
                            MissionData.iMishText = 93;
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle())
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 94;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[1]);
                        }
                        else if (MissionData.BeOnOff[5])
                        {
                            if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 65.00f)
                            {
                                MoveThatCar(MissionData.vTarget_01);
                                MissionData.BeOnOff[5] = false;
                            }
                        }
                        else if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    MissionData.iMissionSeq = 4;
                    MissionData.iMissionVar_01 -= 1;
                    Vector3 Vme = MissionData.VectorList_01[MissionData.iMissionVar_01];
                    Vme.Z = Vme.Z - 1.00f;
                    MissionData.Prop_01 = ObjectBuild.BuildProp("hei_prop_hei_security_case", Vme, Vector3.Zero, true, false);
                    MissionData.BeOnOff[0] = true;
                    ObjectHand.AddTarget(Vme, false, true, 1.00f, false, 408, DataStore.MyLang.Maptext[69]);
                    MissionData.iMishText = 96;
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (ReturnStuff.PickupBling(MissionData.Prop_01))
                    {
                        MissionData.iMissionSeq = 5;
                        MissionData.iGotYourVan = 0;
                        MissionData.Prop_01 = null;
                        MissionData.BeOnOff[4] = true;
                        MissionData.BeOnOff[0] = false;
                        ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 3, DataStore.MyLang.Maptext[1]);
                        float fup = MissionData.vTarget_01.DistanceTo(MissionData.vTarget_03);
                        MissionData.iCashReward = (int)fup;
                        MissionData.iCashReward = MissionData.iCashReward * 2;
                        ObjectHand.RemoveTargets();
                        MissionData.iMishText = 94;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 3.00f)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            ObjectHand.DoorsNear(MissionData.vTarget_01, 8.00f, false);
                        }
                    }

                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;

                    if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iMissionSeq = 6;
                        MissionData.BeOnOff[4] = false;
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                        UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                        ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 768, DataStore.MyLang.Maptext[59]);
                        MissionData.iMissionVar_02 = Game.GameTime + ReturnStuff.RandInt(15000, 25000);
                        MissionData.iMishText = 97;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;

                    if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iMissionVar_02 < Game.GameTime)
                    {
                        MissionData.iMissionSeq = 7;
                        MissionData.BeOnOff[5] = true;
                        TheMissions.MoneyMan_Attacks();
                    }
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[4] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 768, DataStore.MyLang.Maptext[59]);
                            MissionData.iMishText = 97;
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle())
                        {
                            MissionData.BeOnOff[4] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[1]);
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 94;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 7)
                {
                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;

                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_03) < 65.00f && MissionData.BeOnOff[5])
                    {
                        MoveThatCar(MissionData.vTarget_03);
                        MissionData.BeOnOff[5] = false;
                    }
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_03) < 2.50f)
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMishText = -1;
                            StopHere(MissionData.VehTrackin_01);
                            MissionData.iMissionSeq = 8;
                            ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fphdirect);
                            MissionData.VehTrackin_01.FreezePosition = true;
                            MissionData.VehTrackin_01.Position = new Vector3(0.00f, 0.00f, 110.00f);
                            ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 2, false);
                            ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 3, false);
                            ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 4, false);
                        }

                    }
                    else if (MissionData.BeOnOff[4])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            UiDisplay.bUiDisplay = false;
                            MissionData.BeOnOff[4] = false;
                            MissionData.BeOnOff[5] = true;
                            MissionData.BeOnOff[3] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 768, DataStore.MyLang.Maptext[59]);
                            MissionData.iMishText = 97;
                        }
                        else if (MissionData.BeOnOff[3])
                        {
                            if (Game.GameTime < MissionData.iGotYourVan)
                                ObjectHand.FindTheTime(MissionData.iGotYourVan - Game.GameTime, 7, "", true);
                            else
                                MissionData.VehTrackin_01.Explode();
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle())
                        {
                            MissionData.BeOnOff[4] = true;
                            MissionData.iGotYourVan = 0;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, true, 66, DataStore.MyLang.Maptext[1]);
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 94;
                        }
                    }
                    if (MissionData.iWait4Sec < Game.GameTime && MissionData.BeOnOff[1])
                        TheMissions.MoneyMan_GetJack();

                }
                else if (MissionData.iMissionSeq == 8)
                {
                    ObjectHand.NSCoinInvestments(true, 5, 9, "Gruppe Sechs Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.NSCoinInvestments(false, 6, 10, "Gruppe Sechs Shares");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //MoneyMan
            else if (MissionData.iJobType == 15)
            {
                if (MissionData.iLocationX == 1)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.VehicleList_01.Count > 3)
                        {
                            MissionData.iMissionSeq = 1;
                            TheMissions.Water01_BargeCars(MissionData.VehTrackin_01, MissionData.PropList_01[0], 1);
                            TheMissions.Water01_BargeCars(MissionData.VehTrackin_02, MissionData.PropList_01[0], 3);
                            TheMissions.Water01_BargeCars(MissionData.VehTrackin_03, MissionData.PropList_01[0], 2);
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 356, DataStore.MyLang.Maptext[60]);

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_05, Game.Player.Character, 1);

                            MissionData.iMishText = 98;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (DataStore.bNotPause)
                        {
                            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                            DataStore.bNotPause = false;
                        }
                        else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 45.0f)
                        {
                            MissionData.iMissionSeq = 2;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_05, true, true, 66, DataStore.MyLang.Maptext[10]);
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 99;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_05.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_05))
                        {
                            MissionData.iMissionSeq = 3;
                            MissionData.VehTrackin_05.CurrentBlip.Remove();
                            Function.Call(Hash._SET_VEHICLE_ENGINE_POWER_MULTIPLIER, MissionData.VehTrackin_05, 100.00f);
                            ObjectHand.AddTarget(MissionData.Prop_03.Position, false, true, 1.00f, false, 68, DataStore.MyLang.Maptext[38]);
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.UpsideDownCone, MarkPos = new Vector3(MissionData.Prop_03.Position.X, MissionData.Prop_03.Position.Y, MissionData.Prop_03.Position.Z + 2.00f), MarkDir = Vector3.Zero, MarkRot = Vector3.Zero, MarkScale = new Vector3(1.00f, 1.00f, 1.00f), MarkCol = Color.Beige };
                            UiDisplay.bMMDisplay01 = true;

                            MissionData.iMishText = 100;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_05.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.Prop_02.Position, MissionData.Prop_03.Position) < 60.00f)
                        {
                            MissionData.iMishText = 101;
                            if (World.GetDistance(MissionData.Prop_02.Position, MissionData.Prop_03.Position) < 3.00f)
                            {
                                MissionData.iMissionSeq = 4;
                                ObjectHand.RemoveTargets();
                                UiDisplay.bMMDisplay01 = false;
                                Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehicleList_01[1], false);
                                TheMissions.Water01_BargeTow(MissionData.VehicleList_01[1], MissionData.VehTrackin_05);
                                MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -4.00f);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_02, 30.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, -1, DataStore.MyLang.Maptext[42]);
                                MissionData.iMishText = 102;
                            }
                        }
                        else
                            MissionData.iMishText = 100;
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_05.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (World.GetDistance(MissionData.VehicleList_01[0].Position, MissionData.vTarget_02) < 25.00f)
                        {
                            MissionData.iMissionSeq = 5;
                            ObjectHand.RemoveTargets();
                            Game.FadeScreenOut(1000);
                            Script.Wait(1000);
                            MissionData.VehicleList_01[1].Detach();
                            MissionData.VehTrackin_05.Position = MissionData.vTarget_03;
                            MissionData.VehTrackin_05.Heading = MissionData.fphdirect;
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 1);
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_05, true);
                            MissionData.VehTrackin_05.LockStatus = VehicleLockStatus.LockedForPlayer;
                            TheMissions.Water01_RentoMob();
                            MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(10000, 15000);
                            Game.FadeScreenIn(1000);
                            MissionData.iMishText = -1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (Game.GameTime < MissionData.iWait4Sec)
                        {
                            MissionData.iMissionSeq = 6;
                            MissionData.iMissionVar_02 = Game.GameTime + ReturnStuff.RandInt(10000, 15000);
                            MissionData.iMishText = 103;

                            ObjectBuild.VehicleSpawn("Cargobob2", MissionData.vTarget_04, 0.00f, false, true, false, false, 12, 0, 0, "", 4, false);
                            MissionData.BeOnOff[3] = true;
                        }
                        else if (MissionData.iTracking < Game.GameTime)
                            TheMissions.Water01_JetSkiTrackin();
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;

                        if (MissionData.VehTrackin_03.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[1])
                        {
                            if (MissionData.VehTrackin_04.IsDead)
                                MissionData.iMissionSeq = 8;
                            else if (MissionData.VehTrackin_03.Position.DistanceTo(MissionData.VehTrackin_04.Position) < 10.00f)
                            {
                                MissionData.iMissionSeq = 7;
                                MissionData.VehTrackin_03.Detach();
                                Function.Call(Hash._0x7BEB0C7A235F6F3B, MissionData.VehTrackin_04, 0);
                                Script.Wait(1200);
                                Vector3 V3Me = Function.Call<Vector3>(Hash._0xCBDB9B923CACC92D, MissionData.VehTrackin_04);
                                MissionData.VehTrackin_03.AttachTo(MissionData.VehTrackin_04, MissionData.VehTrackin_03.Handle, new Vector3(0.0f, 0.0f, -3.0f), new Vector3(0.0f, -15.0f, 0.0f));
                                ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_04, 120.00f, 5.00f);
                            }
                            else
                            {
                                if (MissionData.BeOff[1] && MissionData.VehTrackin_03.Position.DistanceTo(MissionData.VehTrackin_04.Position) < 45.00f)
                                {
                                    MissionData.iMishText = 104;
                                    MissionData.BeOff[1] = false;
                                }
                                if (MissionData.iTracking < Game.GameTime)
                                    TheMissions.Water01_JetSkiTrackin();
                            }
                            TheMissions.Water01_BargeFloat();
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;
                        if (MissionData.VehTrackin_03.IsDead || MissionData.VehicleList_01[0].Position.DistanceTo(MissionData.VehTrackin_04.Position) > 200.00f || MissionData.VehTrackin_04.IsDead)
                            MissionData.iMissionSeq = 40;
                        else if (MissionData.VehTrackin_04.Position.Z < 200.00f && !MissionData.BeOnOff[2])
                        {
                            MissionData.BeOnOff[2] = true;
                            Vector3 V3Fly = MissionData.VehTrackin_04.Position;
                            V3Fly.Z = V3Fly.Z + 200.00f;
                            ObjectBuild.FlyAway(MissionData.Npc_01, V3Fly, 75.00f, 5.00f);
                        }
                        else if (MissionData.VehTrackin_04.Position.Z > 200.00f && MissionData.BeOnOff[2])
                        {
                            MissionData.BeOnOff[2] = false;
                            ObjectBuild.FlyAway(MissionData.Npc_01, MissionData.vTarget_04, 75.00f, 5.00f);
                        }
                        TheMissions.Water01_BargeFloat();
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        Game.FadeScreenOut(1000);
                        Script.Wait(1000);

                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                        TheMissions.Water01_HaveACar();
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        MissionData.iCashReward = ReturnStuff.RandInt(10000, 12000);
                        DataStore.MyDatSet.iPegsboatsTest = DataStore.iPegsboats;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(6, DataStore.MyDatSet.iPegsboatsTest);
                        ObjectHand.NSCoinInvestments(true, 5, 9, "Legendary Motorsport Shares");
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 40)
                    {
                        TheMissions.Water01_BlowShitUp();
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 7, 9, "Legendary Motorsport Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       //Tug Barge
                else if (MissionData.iLocationX == 2)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;
                        MultiBlimbs(MissionData.vTarget_02, 612, false, DataStore.MyLang.Maptext[118]);
                        MultiBlimbs(MissionData.vTarget_03, 427, false, DataStore.MyLang.Maptext[119]);
                        MultiBlimbs(MissionData.vTarget_04, 534, false, DataStore.MyLang.Maptext[120]);
                        MissionData.iMishText = 105;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.vTarget_02.DistanceTo(Game.Player.Character.Position) < 75.00)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.iMissionVar_01 = 1;
                            ObjectBuild.VehicleSpawn("SeaSparrow", MissionData.vTarget_02, MissionData.fList_01[0], false, false, false, true, 2, 9, 66, DataStore.MyLang.Maptext[5], 1, false);
                        }
                        else if (MissionData.vTarget_03.DistanceTo(Game.Player.Character.Position) < 75.00)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.iMissionVar_01 = 2;
                            ObjectBuild.VehicleSpawn("Jetmax", MissionData.vTarget_03, MissionData.fList_01[1], false, false, false, true, 0, 0, 66, DataStore.MyLang.Maptext[17], 1, true);
                        }
                        else if (MissionData.vTarget_04.DistanceTo(Game.Player.Character.Position) < 75.00)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.iMissionVar_01 = 3;
                            ObjectBuild.VehicleSpawn("Technical2", MissionData.vTarget_04, MissionData.fList_01[2], false, false, false, true, 0, 0, 66, DataStore.MyLang.Maptext[23], 1, true);
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 3;
                            ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                            MissionData.BlipList_01.Clear();
                            if (MissionData.iMissionVar_01 == 1)        //SeaSparrow
                                MissionData.iMishText = 106;
                            else if (MissionData.iMissionVar_01 == 2)   //Jetmax
                                MissionData.iMishText = 107;
                            else
                                MissionData.iMishText = 108;            //Technical2
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_01, false, true, 1.00f, false, 310, DataStore.MyLang.Maptext[78]);
                            MissionData.iMishText = 109;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, false, true, 1.00f, false, 310, DataStore.MyLang.Maptext[78]);
                                MissionData.iMishText = 109;
                            }
                            else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 99.00f)
                            {
                                MissionData.iMissionSeq = 5;
                                ObjectHand.RemoveTargets();
                                TheMissions.Water02_YachtAttack();
                                MissionData.iWait4Sec = Game.GameTime + 1000;
                                MissionData.iMishText = 110;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 66, "");
                                if (MissionData.iMissionVar_01 == 1)        //SeaSparrow
                                    MissionData.iMishText = 106;
                                else if (MissionData.iMissionVar_01 == 2)   //Jetmax
                                    MissionData.iMishText = 107;
                                else
                                    MissionData.iMishText = 108;            //Technical2
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;
                        UiDisplay.ttTextBar_01.Text = "" + MissionData.PedList_01.Count + "/20";

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                        if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                        else
                            MissionData.iMissionSeq = 6;
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (DataStore.MyAssets.OwnaYacht)
                        {
                            MissionData.iCashReward = 20000;
                            MissionData.iMissionSeq = 7;
                            RWDatFile.SaveDat(0, DataStore.iProcessForYacht);
                            TheMissions.Water02_BoatLaunch();
                        }
                        else
                        {
                            Vector3 Vpos = new Vector3(-1848.826f, -1200.298f, 19.14339f);
                            if (MissionData.bOldYacht || !DataStore.MySettings.PreLoadOnline || !File.Exists(DataStore.sNSPMYacht))
                            {
                                ObjectHand.SlowFastTravel(Vpos, 165.84f);
                                TheMissions.Water02_AddHeistYacht(false);
                                MissionData.iCashReward = 20000;
                                MissionData.iMissionSeq = 7;
                            }
                            else
                            {
                                MissionData.iMissionSeq = 99;
                                ObjectHand.ControlSelect(10, false);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                        MissionData.BlipList_01.Clear();

                        if (MissionData.bOldYacht)
                            TheMissions.Water02_AddHeistYacht(false);
                        else if (DataStore.MyAssets.OwnaYacht)
                            RWDatFile.SaveDat(0, DataStore.MyDatSet.iOwnaYacht);

                        TheMissions.GameOver(true, "", false, 0);
                    }
                }  //Defend yacht
                else if (MissionData.iLocationX == 3)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.PedList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 1;

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 111;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 2;
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_01, false);
                            MissionData.iMissionVar_01 = MissionData.iDeliverList.Count - 1;
                            MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iDeliverList[MissionData.iMissionVar_01]];
                            ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(23), MissionData.VectorList_02[MissionData.iDeliverList[MissionData.iMissionVar_01]], MissionData.fList_01[MissionData.iDeliverList[MissionData.iMissionVar_01]], false, 130, 21, 0, null, 1, false, 0, 0, "");
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            UiDisplay.BtSlideBar.BackgroundColor = Color.Black;
                            UiDisplay.BtSlideBar.ForegroundColor = Color.Purple;
                            UiDisplay.BtSlideBar.Percentage = 0.01f;
                            ObjectHand.AddTarget(MissionData.vTarget_01, false, false, 45.00f, true, 459, DataStore.MyLang.Maptext[26]);
                        }
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 25.00f)
                            MissionData.iMishText = 112;
                        else
                            MissionData.iMishText = 111;
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.BeOnOff[1])
                            MissionData.iMishText = 113;
                        else
                            MissionData.iMishText = 114;

                        if (MissionData.BeOnOff[0])
                        {
                            if (MissionData.VehTrackin_01.IsInWater)
                                MissionData.BeOnOff[0] = false;
                            else
                            {
                                if (MissionData.iWait4Sec < Game.GameTime)
                                {
                                    MissionData.iWait4Sec = Game.GameTime + 15000;
                                    MissionData.iMissionSeq = 15;
                                }
                            }
                        }
                        else
                        {
                            if (!MissionData.VehTrackin_01.IsInWater)
                            {
                                MissionData.iWait4Sec = Game.GameTime + 5000;
                                MissionData.BeOnOff[0] = true;
                            }
                        }
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 45.00f)
                        {
                            float fdist = World.GetDistance(MissionData.VehTrackin_01.Position, MissionData.vTarget_01) / 45.00f;
                            fdist = 1.00f - fdist;
                            if (fdist < 0.01f)
                                fdist = 0.01f;
                            UiDisplay.BtSlideBar.Percentage = fdist;
                            if (fdist > 0.90f)
                            {
                                if (MissionData.BeOnOff[1])
                                {
                                    int iTotal = MissionData.iWait4Sec - Game.GameTime;
                                    ObjectHand.FindTheTime(iTotal, 9, "", false);
                                    if (MissionData.iWait4Sec < Game.GameTime)
                                    {
                                        if (MissionData.iMissionVar_01 > 0)
                                        {
                                            ObjectHand.RemoveTargets();
                                            MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                                            MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iDeliverList[MissionData.iMissionVar_01]];
                                            ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(23), MissionData.VectorList_02[MissionData.iDeliverList[MissionData.iMissionVar_01]], MissionData.fList_01[MissionData.iDeliverList[MissionData.iMissionVar_01]], false, 130, 21, 0, null, 0, false, 0, 0, "");
                                            UiDisplay.BtSlideBar.Percentage = 0.01f;
                                            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
                                            ObjectHand.AddTarget(MissionData.vTarget_01, false, false, 45.00f, true, 459, DataStore.MyLang.Maptext[26]);
                                            UiDisplay.BtSlideBar.ForegroundColor = Color.Purple;
                                            MissionData.BeOnOff[1] = false;
                                        }
                                        else
                                        {
                                            ObjectHand.RemoveTargets();
                                            MissionData.iMissionSeq = 3;
                                            MissionData.BeOnOff[1] = false;
                                            ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, 371, DataStore.MyLang.Maptext[60]);
                                            UiDisplay.TheYellowCorona(MissionData.vTarget_02, 5.00f);

                                            MissionData.iMishText = 115;
                                        }
                                    }
                                }
                                else
                                {
                                    MissionData.iWait4Sec = Game.GameTime + 5000;
                                    UiDisplay.BtSlideBar.ForegroundColor = Color.Green;
                                    UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_02);
                                    MissionData.BeOnOff[1] = true;
                                }
                            }
                            else
                            {
                                UiDisplay.BtSlideBar.ForegroundColor = Color.Purple;
                                UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_02);
                                MissionData.BeOnOff[1] = false;
                            }
                        }
                        else
                        {
                            if (MissionData.VehTrackin_01.Position.Z + 5 < MissionData.vTarget_01.Z)
                                MissionData.iMissionSeq = 45;
                        }

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.BeOnOff[0])
                        {
                            if (MissionData.VehTrackin_01.IsInWater)
                                MissionData.BeOnOff[0] = false;
                            else
                            {
                                if (MissionData.iWait4Sec < Game.GameTime)
                                {
                                    MissionData.iWait4Sec = Game.GameTime + 15000;
                                    MissionData.iMissionSeq = 16;
                                }
                            }
                        }
                        else
                        {
                            if (!MissionData.VehTrackin_01.IsInWater)
                            {
                                MissionData.iWait4Sec = Game.GameTime + 5000;
                                MissionData.BeOnOff[0] = true;
                            }
                        }

                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_02) < 3.50f)
                        {
                            MissionData.iMissionSeq = 4;
                            ObjectHand.RemoveTargets();
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        MissionData.iMissionSeq = 10;
                        StopHere(MissionData.VehTrackin_01);
                        Vector3 Vpos = new Vector3(-2081.897f, 2609.123f, 3.083975f);
                        ObjectHand.SlowFastTravel(Vpos, 89.72623f);
                        ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 2, false);
                        ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 3, false);
                        ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 4, false);
                        ObjectHand.NSCoinInvestments(true, 7, 12, "White Water Activity Center Shares");
                        MissionData.VehTrackin_01.Position = MissionData.VectorList_01[0];
                        Vector3 Ding01 = new Vector3(-2091.959f, 2613.7197f, 0.2088f);
                        Vector3 Ding02 = new Vector3(-2096.607f, 2612.9768f, 0.2088f);
                        Vector3 Ding03 = new Vector3(-2102.579f, 2612.5708f, 0.2088f);
                        Vector3 Ding04 = new Vector3(-2107.394f, 2611.4148f, 0.2088f);
                        ObjectBuild.VehicleSpawn("DINGHY", Ding01, 15.13f, false, false, false, false, 9, 10, 0, "", 0, false);
                        ObjectBuild.VehicleSpawn("DINGHY2", Ding02, 15.13f, false, false, false, false, 9, 11, 0, "", 0, false);
                        ObjectBuild.VehicleSpawn("DINGHY3", Ding03, 15.13f, false, false, false, false, 9, 12, 0, "", 0, false);
                        ObjectBuild.VehicleSpawn("DINGHY4", Ding04, 15.13f, false, false, false, false, 9, 13, 0, "", 0, false);
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        DataStore.MyDatSet.iPegsboatsTest = DataStore.iPegsboats;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(6, DataStore.MyDatSet.iPegsboatsTest);
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 15)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead || MissionData.iWait4Sec < Game.GameTime)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.IsInWater)
                            MissionData.iMissionSeq = 2;
                    }
                    else if (MissionData.iMissionSeq == 16)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.Npc_01.IsDead || MissionData.iWait4Sec < Game.GameTime)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.IsInWater)
                            MissionData.iMissionSeq = 3;
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 9, 14, "White Water Activity Center Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }  //Phishing
                else if (MissionData.iLocationX == 4)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            MissionData.iMissionSeq = 1;

                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 116;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 99;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iList_01[1] = -1;
                            TheMissions.Water04_AddTheRubbish();
                            MissionData.iMishText = 118;
                        }
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 55.00f)
                            MissionData.iMishText = 117;
                        else
                            MissionData.iMishText = 116;
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iList_01[0] > Game.GameTime && MissionData.iMissionVar_01 > 0)
                        {
                            ObjectHand.FindTheTime(MissionData.iList_01[0] - Game.GameTime, 9, "", true);
                            if (MissionData.iList_01[1] > 0)
                            {
                                MissionData.iList_01[1] -= 1;
                                if (MissionData.PropList_01[MissionData.iList_01[1]].Exists())
                                {
                                    if (!MissionData.PropList_01[MissionData.iList_01[1]].IsPersistent)
                                    {
                                        MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                                        MissionData.PropList_01[MissionData.iList_01[1]].Delete();
                                        MissionData.PropList_01.Remove(MissionData.PropList_01[MissionData.iList_01[1]]);
                                    }

                                }
                                else
                                {
                                    MissionData.iMissionVar_01 = MissionData.iMissionVar_01 - 1;
                                    MissionData.PropList_01[MissionData.iList_01[1]].Delete();
                                    MissionData.PropList_01.Remove(MissionData.PropList_01[MissionData.iList_01[1]]);
                                    UiDisplay.ttTextBar_01.Text = "" + MissionData.iMissionVar_01 + "/50";
                                }
                            }
                            else
                                MissionData.iList_01[1] = MissionData.PropList_01.Count;
                        }
                        else
                        {
                            MissionData.iMissionSeq = 3;
                            TheMissions.Water04_RemoveRubbish();
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.BeOnOff[0])
                        {
                            if (MissionData.iMissionVar_01 == 0)
                            {
                                MissionData.iMissionSeq = 99;
                                MissionData.iCashReward = ReturnStuff.RandInt(5000, 9000);
                                DataStore.MyDatSet.iPegsimortasTest = DataStore.iPegsimortas;
                                DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                                RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                                RWDatFile.SaveDat(7, DataStore.MyDatSet.iPegsimortasTest);
                                ObjectHand.NSCoinInvestments(true, 9, 21, "DockTease Shares");
                                TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                            }
                            else
                                MissionData.iMissionSeq = 45;
                        }
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }  //Rubish collection
                else if (MissionData.iLocationX == 5)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;

                        Vector3 vBt_01 = new Vector3(1306.057f, 4219.996f, 29.88048f);
                        float fBT_01 = 171.1544f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_01, fBT_01, false, false, false, false, 9, 0, 0, "", 0, false);
                        Vector3 vBt_02 = new Vector3(1297.212f, 4211.022f, 30.71615f);
                        float fBT_02 = 261.1423f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_02, fBT_02, false, false, false, false, 9, 0, 0, "", 0, false);
                        Vector3 vBt_03 = new Vector3(1302.542f, 4266.792f, 30.43473f);
                        float fBT_03 = 167.3074f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_03, fBT_03, false, false, false, false, 9, 0, 0, "", 0, false);
                        Vector3 vBt_04 = new Vector3(1295.325f, 4239.063f, 30.45684f);
                        float fBT_04 = 167.0434f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_04, fBT_04, false, false, false, false, 9, 0, 0, "", 0, false);
                        Vector3 vBt_05 = new Vector3(1344.052f, 4224.578f, 30.24381f);
                        float fBT_05 = 167.3387f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_05, fBT_05, false, false, false, false, 9, 0, 0, "", 0, false);
                        Vector3 vBt_06 = new Vector3(1318.892f, 4235.62f, 29.95362f);
                        float fBT_06 = 256.2925f;
                        ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(1, 4, true), vBt_06, fBT_06, false, false, false, false, 9, 0, 0, "", 0, false);

                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 371, DataStore.MyLang.Maptext[61]);

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                        MissionData.iMishText = 119;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 55.00f)
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.BeOnOff[0] = false;
                            MissionData.iWait4Sec = 0;
                            ObjectHand.RemoveTargets();
                            TheMissions.Water05_BlipTheBoats();
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.iMishText = 120;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            TheMissions.Water05_InYourBoat();
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 5.00f)
                        {
                            MissionData.iMissionSeq = 4;
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                                Function.Call(Hash.DETACH_VEHICLE_FROM_ANY_CARGOBOB, MissionData.VehTrackin_01);
                            else
                            {
                                StopHere(MissionData.VehTrackin_01);
                                ObjectHand.SlowFastTravel(MissionData.vTarget_02, 89.72623f);
                                ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 2, false);
                                ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 3, false);
                                ObjectBuild.FreeSeat(MissionData.VehTrackin_01, 4, false);
                            }
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_01, true);
                        }
                        else
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01) || ReturnStuff.Water05_CargoBobed(MissionData.VehTrackin_01))
                            {
                                if (MissionData.Target_01 == null)
                                {
                                    MissionData.VehTrackin_01.CurrentBlip.Remove();
                                    ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 356, DataStore.MyLang.Maptext[0]);
                                    UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                                    MissionData.iMishText = 121;
                                    MissionData.BeOnOff[0] = false;
                                }
                            }
                            else
                            {
                                if (MissionData.Target_01 != null)
                                {
                                    ObjectHand.RemoveTargets();
                                    ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[0]);
                                    MissionData.iMishText = 112;
                                }
                            }

                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        MissionData.iCashReward = (MissionData.iList_01[0] - Game.GameTime) / 10 * -1;
                        DataStore.MyDatSet.iPegsboatsTest = DataStore.iPegsboats;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(6, DataStore.MyDatSet.iPegsboatsTest);
                        ObjectHand.NSCoinInvestments(true, 9, 14, "DockTease Shares");
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.NSCoinInvestments(false, 1, 4, "DockTease Shares");
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }  //Boat delivery
                else
                {
                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            if (DataStore.MySettings.FastTraveltoStart)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.iMishText = 122;
                            World.TransitionToWeather(Weather.Clear, 1.00f);
                            Function.Call(Hash._0xC54A08C85AE4D410, 1.50f);

                            MissionData.iMissionSeq = 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[42]);
                            MissionData.iMishText = 123;
                            MissionData.iMissionSeq = 2;
                        }
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 35.00f)
                            MissionData.iMishText = 124;
                        else
                            MissionData.iMishText = 122;
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 15.00f || MissionData.VehTrackin_01.IsInWater)
                        {
                            MissionData.iMishText = 125;
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[21], 1);
                            ObjectHand.RemoveTargets();
                            ObjectHand.AddTarget(MissionData.vTarget_05, false, true, 1.00f, false, 760, DataStore.MyLang.Maptext[13]);
                            MissionData.iMissionSeq = 3;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_05) < 95.00f)
                        {
                            TheMissions.Water06_SubCam();
                            ObjectHand.RemoveTargets();
                            MissionData.iMishText = 126;
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_02.Position) < 25.00f && Game.Player.Character.Position.Z < MissionData.Npc_02.Position.Z + 1.00f)
                        {
                            if (MissionData.Npc_02.IsDead)
                            {
                                MissionData.iMissionSeq = 45;
                                ObjectHand.SlowFastTravel(MissionData.vTarget_04, 0.00f);
                            }
                            else if (Game.Player.IsTargetting(MissionData.Npc_02))
                            {
                                if (MissionData.iMissionVar_01 < Game.GameTime)
                                {
                                    MissionData.iMishText = 126;
                                    ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(33), MissionData.VectorList_01[3], MissionData.fList_01[3], false, 180, 20, 0, null, 8, true, 1, 0, "");//offence
                                    ObjectHand.AddTarget(MissionData.vTarget_02, false, true, 1.00f, false, 606, DataStore.MyLang.Maptext[42]);
                                    MissionData.Npc_02.CurrentBlip.Remove();
                                    MissionData.iMissionSeq = 5;
                                }

                            }
                            else
                                MissionData.iMissionVar_01 = Game.GameTime + 4000;

                            if (MissionData.BeOff[0])
                            {
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[22], 5000);

                                MissionData.iMishText = 127;
                                MissionData.BeOff[0] = false;
                            }
                        }
                        else
                            MissionData.iMishText = 126;

                        if (MissionData.iTracking < Game.GameTime)
                            ObjectHand.SimpleTracker();
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMishText = 126;
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_02) < 5.00f && Game.Player.Character.Position.Z > MissionData.vTarget_02.Z)
                        {
                            MissionData.iMishText = 129;
                            UiDisplay.TheYellowCorona(MissionData.vTarget_02, 1.00f);
                            MissionData.iMissionSeq = 6;
                        }
                        else if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_02) < 1.50f)
                        {
                            if (MissionData.iMissionVar_01 < Game.GameTime)
                            {
                                ObjectHand.RemoveTargets();
                                ObjectHand.CleanPedBlips(1);
                                ObjectBuild.ForceAnim(Game.Player.Character, "anim@gangops@submarine@controlroom@commandconsole@", "intro", MissionData.vTarget_02, new Vector3(0.00f, 0.00f, 271.2907f));
                                Script.Wait(2500);
                                Game.Player.Character.Task.ClearAllImmediately();

                                MissionData.iMishText = 130;

                                Vector3 Posy = new Vector3(513.6042f, 4836.958f, -62.6013f);
                                Vector3 Rota = new Vector3(0.00f, 90.00f, 180.00f);

                                ObjectBuild.BuildProp("hei_prop_hst_usb_drive", Posy, Rota, true, false);

                                MissionData.Npc_01 = ObjectBuild.NPCSpawn("csb_bogdan", MissionData.VectorList_01[4], MissionData.fList_01[4], false, 180, 20, 0, null, 8, true, 1, 0, DataStore.MyLang.Maptext[115]);//offence
                                MissionData.iMissionSeq = 7;
                            }
                        }
                        else
                            MissionData.iMissionVar_01 = Game.GameTime + 2000;

                        if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.Npc_01.IsDead)
                        {
                            ObjectHand.AddTarget(MissionData.vTarget_03, false, true, 1.00f, false, 515, DataStore.MyLang.Maptext[42]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 1.00f);
                            MissionData.iMishText = 131;
                            MissionData.iMissionSeq = 8;
                        }
                        if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_03) < 1.50f)
                        {
                            ObjectHand.SlowFastTravel(MissionData.vTarget_04, 308.3964f);
                            MissionData.iMissionSeq = 10;
                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        MissionData.iCashReward = 500000;
                        Function.Call(Hash._0xC54A08C85AE4D410, 0.00f);
                        DataStore.MyDatSet.iPegsboatsTest = DataStore.iPegsboats;
                        DataStore.MyDatSet.iGotPegsus = DataStore.iProcessForPegs;
                        RWDatFile.SaveDat(1, DataStore.MyDatSet.iGotPegsus);
                        RWDatFile.SaveDat(6, DataStore.MyDatSet.iPegsboatsTest);
                        TheMissions.LoadInteriors(6, false);
                        ObjectHand.NSCoinInvestments(false, 15, 21, "Merryweather Security");
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        MissionData.iMissionSeq = 99;
                        TheMissions.LoadInteriors(6, false);
                        Function.Call(Hash._0xC54A08C85AE4D410, 0.00f);
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }                       //Sub fun.
            }       //Watermess
            else if (MissionData.iJobType == 16)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(20000, 40000);
                    MissionData.fMission_01 = ReturnStuff.RandFlow(500.00f, 1000.00f);
                    MissionData.VehTrackin_01 = null;
                    MissionData.iCashBouns = 0;
                    MissionData.vTarget_01 = Game.Player.Character.Position;
                    UiDisplay.MpUiDisplay.Add(UiDisplay.BtSlideBar);
                    if (MissionData.iList_01[0] != 0)
                        Game.FadeScreenIn(1000);
                    if (MissionData.iList_01[0] != 3)
                        MissionData.iMishText = 132;
                    ObjectHand.CleanMultiPed(false, true);
                    MissionData.iMissionSeq = 1;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.iList_01[0] < 3)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime && Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) > MissionData.fMission_01 && World.GetNextPositionOnStreet(Game.Player.Character.Position).DistanceTo(Game.Player.Character.Position) < 95.00f)
                        {
                            MissionData.iMissionSeq = 2;
                            UiDisplay.bUiDisplay = false;
                            UiDisplay.MpUiDisplay.Remove(UiDisplay.BtSlideBar);
                            int iGroup = 0;
                            if (DataStore.MyCusVeh.MyCarz.Count > 0)
                                iGroup = ReturnStuff.FindRandom(59, 1, 10);
                            else
                                iGroup = ReturnStuff.FindRandom(60, 1, 9);
                            string sMyCar = ReturnStuff.ImportsExpo_CarList(iGroup);
                            MissionData.iList_02.Add(iGroup);
                            MissionData.sList_01.Add(sMyCar);

                            if (ReturnStuff.FindRandom(88, 1, 10) < 5)
                                SearchFor.SearchVeh(35.00f, 125.00f, sMyCar, false, false, true, true, 0, 0, 3, DataStore.MyLang.Maptext[14], 1, true, false);
                            else
                                SearchFor.SearchVeh(35.00f, 125.00f, sMyCar, false, false, true, true, 25, 0, 11, DataStore.MyLang.Maptext[14], 1, true, true);

                            MissionData.iCrash4Cash = 10000;
                            MissionData.iMishText = -1;
                        }
                        else
                        {
                            float fdist = World.GetDistance(Game.Player.Character.Position, MissionData.vTarget_01) / MissionData.fMission_01;
                            if (fdist > 1.00f)
                                fdist = 1.00f;
                            UiDisplay.BtSlideBar.Percentage = fdist;

                            if (!UiDisplay.bUiDisplay)
                                UiDisplay.bUiDisplay = true;
                        }
                    }
                    else
                        MissionData.iMissionSeq = 10;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01 != null)
                    {
                        if (!UiDisplay.bMMDisplay01)
                        {
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading), MarkScale = new Vector3(1.00f, 1.00f, 1.00f), MarkCol = Color.CadetBlue };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.iMishText = 133;
                        }
                        else
                        {
                            UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 2.00f);
                            UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading);
                        }
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            TheMissions.ImportsExpo_Targit();
                            MissionData.BeOnOff[0] = false;
                            UiDisplay.bMMDisplay01 = false;
                            MissionData.fVehicleDamage = MissionData.VehTrackin_01.BodyHealth + MissionData.VehTrackin_01.EngineHealth + MissionData.VehTrackin_01.PetrolTankHealth;
                            MissionData.iList_01[2] = (int)MissionData.fVehicleDamage;
                            UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                            MissionData.iMishText = 134;
                            MissionData.iTracking = Game.GameTime + ReturnStuff.RandInt(7000, 14000);
                            MissionData.iMissionSeq = 3;
                        }
                        else
                        {
                            if (Game.Player.Character.IsInVehicle())
                            {
                                Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                                if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                                {
                                    if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                    {
                                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                                        TheMissions.ImportsExpo_Targit();
                                        MissionData.BeOnOff[0] = false;
                                        UiDisplay.bMMDisplay01 = false;
                                        MissionData.fVehicleDamage = MissionData.VehTrackin_01.BodyHealth + MissionData.VehTrackin_01.EngineHealth + MissionData.VehTrackin_01.PetrolTankHealth;
                                        MissionData.iList_01[2] = (int)MissionData.fVehicleDamage;
                                        UiDisplay.MpUiDisplay.Add(UiDisplay.ttTextBar_01);
                                        MissionData.iMishText = 135;
                                        MissionData.iTracking = Game.GameTime + ReturnStuff.RandInt(7000, 14000);
                                        MissionData.iMissionSeq = 4;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VectorList_01[0]) < 90.00f)
                    {
                        TheMissions.ImportsExpo_MoveYourBoat();
                        MissionData.iMissionSeq = 5;
                    }
                    else if (!MissionData.BeOnOff[0])
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[3]);
                            MissionData.BeOnOff[0] = true;
                        }
                        if (MissionData.iList_01[2] > 0 && MissionData.iCrash4Cash > 0)
                            MissionData.iCashBouns = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iList_01[2], MissionData.iCrash4Cash, true, MissionData.iCashBouns, false);

                        MissionData.iMishText = 134;
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            TheMissions.ImportsExpo_Targit();
                            MissionData.BeOnOff[0] = false;
                        }
                        else if (Game.Player.Character.IsInVehicle())
                        {
                            Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                            if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                            {
                                if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.VehTrackin_01.CurrentBlip.Remove();
                                    TheMissions.ImportsExpo_Targit();
                                    MissionData.BeOnOff[0] = false;
                                    MissionData.iMishText = 135;

                                    MissionData.iMissionSeq = 4;
                                }
                            }
                        }

                        MissionData.iMishText = 81;
                    }

                    if (MissionData.iTracking < Game.GameTime)
                        TheMissions.ImportsExpo_Gangz();
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VectorList_01[0]) < 90.00f)
                    {
                        TheMissions.ImportsExpo_MoveYourBoat();
                        MissionData.iMissionSeq = 5;
                    }
                    else if (!MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                            if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                            {
                                if (!Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                {
                                    ObjectHand.RemoveTargets();
                                    ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[3]);
                                    MissionData.BeOnOff[0] = true;
                                }
                            }
                        }
                        if (MissionData.iList_01[2] > 0 && MissionData.iCrash4Cash > 0)
                            MissionData.iCashBouns = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iList_01[2], MissionData.iCrash4Cash, true, MissionData.iCashBouns, false);


                        MissionData.iMishText = 134;
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            TheMissions.ImportsExpo_Targit();
                            MissionData.BeOnOff[0] = false;
                            MissionData.iMissionSeq = 3;
                        }
                        else if (Game.Player.Character.IsInVehicle())
                        {
                            Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                            if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                            {
                                if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                {
                                    MissionData.VehTrackin_01.CurrentBlip.Remove();
                                    TheMissions.ImportsExpo_Targit();
                                    MissionData.BeOnOff[0] = false;
                                }
                            }
                            MissionData.iMishText = 133;
                        }
                    }
                    if (MissionData.iTracking < Game.GameTime)
                        TheMissions.ImportsExpo_Gangz();
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VectorList_01[0]) < 10.00f && MissionData.VehTrackin_01.IsStopped)
                    {
                        MissionData.iMishText = -1;
                        Game.FadeScreenOut(1000);
                        ObjectHand.RemoveTargets();
                        UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_01);
                        MissionData.iCashReward += MissionData.iCrash4Cash - MissionData.iCashBouns;
                        MissionData.iList_01[0] += 1;
                        MissionData.VehTrackin_01.FreezePosition = true;
                        TheMissions.Water01_BargeCars(MissionData.VehTrackin_01, MissionData.PropList_01[0], MissionData.iList_01[0]);
                        if (MissionData.BeOnOff[0])
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.BeOnOff[0] = false;
                        }
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 0);
                            Script.Wait(1000);
                            ObjectHand.SlowFastTravel(MissionData.VectorList_02[0], MissionData.fList_01[0]);
                            Vehicle Vtick = World.CreateVehicle(VehicleHash.Kuruma2, MissionData.VectorList_02[1], MissionData.fList_01[1]);
                            Vtick.MarkAsNoLongerNeeded();
                            MissionData.iMissionSeq = 0;
                        }
                        else
                        {
                            Script.Wait(1000);
                            MissionData.iMissionSeq = 0;
                        }
                    }
                    else if (!MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                            if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                            {
                                if (!Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                {
                                    ObjectHand.RemoveTargets();
                                    ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 4, DataStore.MyLang.Maptext[3]);
                                    MissionData.BeOnOff[0] = true;
                                }
                            }
                            else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[3]);
                                MissionData.BeOnOff[0] = true;
                            }
                        }

                        MissionData.iMishText = 134;//-----may be ellse where

                        if (MissionData.iList_01[2] > 0 && MissionData.iCrash4Cash > 0)
                            MissionData.iCashBouns = ReturnStuff.VehDamage(MissionData.VehTrackin_01, MissionData.iList_01[2], MissionData.iCrash4Cash, true, MissionData.iCashBouns, false);
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Vehicle PlayVeh = Game.Player.Character.CurrentVehicle;
                            if (PlayVeh.Model == VehicleHash.Cargobob || PlayVeh.Model == VehicleHash.Cargobob2 || PlayVeh.Model == VehicleHash.Cargobob3 || PlayVeh.Model == VehicleHash.Cargobob4)
                            {
                                if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, PlayVeh, MissionData.VehTrackin_01))
                                {
                                    MissionData.VehTrackin_01.CurrentBlip.Remove();
                                    TheMissions.ImportsExpo_Targit();
                                    MissionData.BeOnOff[0] = false;
                                }
                            }
                            else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                TheMissions.ImportsExpo_Targit();
                                MissionData.BeOnOff[0] = false;
                            }
                            MissionData.iMishText = 136;//-----may be ellse where
                        }
                    }

                    if (MissionData.iTracking < Game.GameTime)
                        TheMissions.ImportsExpo_Gangz();
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    for (int i = 0; i < MissionData.sList_01.Count; i++)
                    {
                        if (!MissionData.sImpExpVeh.Contains(MissionData.sList_01[i]))
                        {
                            MissionData.iImpExpList.Add(MissionData.iList_02[i]);
                            MissionData.sImpExpVeh.Add(MissionData.sList_01[i]);
                        }
                    }
                    ObjectHand.WriteContacts(true);
                    ObjectHand.NSCoinInvestments(false, 2, 5, "Augury Insurance Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //ImpExp
            else if (MissionData.iJobType == 17)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    Vector3 VT = MissionData.VectorList_01[0];
                    VT.Z -= 1.00f;
                    ObjectHand.AddTarget(VT, true, true, 1.00f, false, 408, DataStore.MyLang.Maptext[62]);
                    UiDisplay.TheYellowCorona(VT, 1.00f);
                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], 0.00f);
                    MissionData.iMishText = 137;
                    MissionData.iMissionSeq = 1;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[0]) < 1.00f && !Game.Player.Character.IsInVehicle())
                    {
                        MissionData.fMission_01 = Game.Player.Character.Heading + 180.00f;
                        ObjectHand.RemoveTargets();
                        TheMissions.DebtCollect_LoadHood();
                        Vector3 Vme = MissionData.VectorList_01[1];
                        Vme.Z -= 1.00f;
                        MissionData.Prop_01 = ObjectBuild.BuildProp("hei_prop_hei_security_case", Vme, Vector3.Zero, true, false);
                        ObjectHand.AddTarget(Vme, false, true, 1.00f, false, 408, DataStore.MyLang.Maptext[63]);
                        MissionData.iMishText = 138;
                        ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.VectorList_01.Count - 1], MissionData.fGetDir);
                        ObjectHand.DoorsNear(MissionData.VectorList_01[MissionData.VectorList_01.Count - 1], 30.00f, false);
                        MissionData.iMissionSeq = 2;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (ReturnStuff.PickupBling(MissionData.Prop_01))
                    {
                        Vector3 VT = MissionData.VectorList_01[MissionData.VectorList_01.Count - 1];
                        VT.Z -= 1.00f;
                        ObjectHand.RemoveTargets();
                        ObjectHand.AddTarget(VT, false, true, 1.00f, false, 515, DataStore.MyLang.Maptext[64]);
                        UiDisplay.TheYellowCorona(VT, 1.00f);
                        MissionData.iMishText = 139;
                        MissionData.iMissionSeq = 3;
                    }
                    else
                    {
                        if (Game.Player.Character.IsFalling)
                        {
                            if (Game.Player.Character.Position.Z + 4 < MissionData.Pick_01.Position.Z)
                            {
                                Vector3 FallThrough = new Vector3(MissionData.VectorList_01[MissionData.VectorList_01.Count - 1].X, MissionData.VectorList_01[MissionData.VectorList_01.Count - 1].Y, MissionData.VectorList_01[MissionData.VectorList_01.Count - 1].Z + 0.5f);
                                Game.Player.Character.Position = FallThrough;
                            }
                        }
                    }

                    if (MissionData.PedList_01.Count > 0)
                    {
                        if (MissionData.iTracking < Game.GameTime)
                            ObjectHand.SimpleTracker();
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[MissionData.VectorList_01.Count - 1]) < 1.00f)
                    {
                        ObjectHand.RemoveTargets();
                        Vector3 VUp = MissionData.VectorList_01[0];
                        MissionData.fMission_01 = Game.Player.Character.Heading;
                        ObjectHand.SlowFastTravel(VUp, MissionData.fMission_01);
                        MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.05f);
                        MissionData.vFuMiss = MissionData.vTarget_03;
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 108, DataStore.MyLang.Maptext[40]);
                        UiDisplay.TheYellowCorona(MissionData.vTarget_01, 1.00f);
                        ObjectHand.CleanPedBlips(1);
                        MissionData.Prop_01 = null;
                        MissionData.iMissionSeq = 4;
                    }
                    else
                    {
                        if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 2.00f && Game.Player.Character.IsOnFoot && Game.Player.Character.Position.Z > MissionData.vTarget_01.Z - 0.50f)
                    {
                        MissionData.iMissionSeq = 5;
                        MissionData.iMishText = -1;
                        MissionData.iWait4Sec = Game.GameTime + 2000;
                        Game.Player.Character.Task.PlayAnimation("anim@mp_fireworks", "place_firework_3_box", 8.00f, 3000, true, 1.00f);
                        ObjectHand.CleanUpCorrona(MissionData.iCoronaList, true);
                        MissionData.iCoronaList.Clear();
                        ObjectHand.RemoveTargets();
                    }
                    else if (World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 55.00f)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            ObjectHand.DoorsNear(Game.Player.Character.Position, 10.00f, false);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        ObjectBuild.BuildProp("hei_prop_hei_security_case", MissionData.vTarget_01, Vector3.Zero, true, false);
                        MissionData.iMissionSeq = 10;
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    if (MissionData.BeOnOff[1])
                    {
                        MissionData.BeOnOff[1] = false;
                        TheMissions.LoadInMissionIPLs(10, false, true);
                    }
                    ObjectHand.NSCoinInvestments(true, 12, 16, "Maze Bank Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.NSCoinInvestments(false, 12, 16, "Maze Bank Shares");
                    if (MissionData.BeOnOff[1])
                    {
                        MissionData.BeOnOff[1] = false;
                        TheMissions.LoadInMissionIPLs(10, false, true);
                    }

                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //DebtCollect
            else if (MissionData.iJobType == 18)
            {
                if (MissionData.iMissionSeq == 10)
                {
                    TheMissions.BikerRaids_UnloadInt(MissionData.iMissionVar_02);
                    if (!MissionData.BeOnOff[4])
                        ObjectHand.NSCoinInvestments(false, 7, 9, "Windsor Real Estate Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 44)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], 0.00f);
                        MissionData.iMissionSeq = 45;
                    }
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.BikerRaids_UnloadInt(MissionData.iMissionVar_02);
                    TheMissions.GameOver(true, "", false, 0);
                }
                else if (MissionData.iMissionVar_01 == 1)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionVar_03 = 4;
                        Vector3 Vehs = MissionData.VectorList_02[0];
                        Vehs.Z -= 0.70f;
                        ObjectBuild.VehicleSpawn("PBUS2", Vehs, MissionData.fGetDir, false, false, false, false, 3, 2, 0, "", 1, false);
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], 0.00f);
                        MissionData.iMishText = 140;
                        MissionData.iMissionSeq = 1;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            if (MissionData.VehTrackin_01.IsDead)
                                MissionData.iMissionSeq = 45;
                            else if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[0]) < 1.50f && !Game.Player.Character.IsInVehicle())
                            {
                                MissionData.fList_01.Add(Game.Player.Character.Heading + 180.00f);
                                ObjectHand.RemoveTargets();
                                Vector3 VT = MissionData.VectorList_03[MissionData.VectorList_03.Count - 1];
                                VT.Z -= 1.00f;
                                UiDisplay.TheYellowCorona(VT, 1.00f);
                                ObjectHand.SlowFastTravel(MissionData.VectorList_03[MissionData.VectorList_03.Count - 1], MissionData.fMission_01);
                                TheMissions.BikerRaids_LoadHood();
                                MissionData.iMissionSeq = 2;
                                MissionData.iMishText = 141;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.MishPed.Count > 0)
                        {
                            if (MissionData.iWait4Sec < Game.GameTime)
                                TheMissions.BikerRaids_KeepWalkin();

                            UiDisplay.ControlerUI(DataStore.MyLang.Context[23], 1);
                        }
                        else
                        {
                            MissionData.iMishText = 142;
                            MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Unlocked;
                            MissionData.iMissionSeq = 3;
                        }

                        ObjectHand.SimpleTracker();
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_03[MissionData.VectorList_03.Count - 1]) < 1.50f)
                        {
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], MissionData.fList_01[0]);
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[4]);
                            MissionData.VehTrackin_01.FreezePosition = false;
                            Function.Call(Hash._SET_VEHICLE_ENGINE_POWER_MULTIPLIER, MissionData.VehTrackin_01, 100.00f);
                            float fDist = MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01);
                            int iFind = (int)fDist;
                            MissionData.iCashReward += iFind;
                            MissionData.BeOnOff[1] = true;
                            MissionData.BeOnOff[2] = true;
                            MissionData.iMishText = 143;
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[1])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = false;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                Vector3 Vme = MissionData.vTarget_01;
                                Vme.Z -= 1.00f;
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 492, DataStore.MyLang.Maptext[65]);
                                UiDisplay.TheYellowCorona(Vme, 5.00f);
                                MissionData.iMishText = 144;
                            }
                        }
                        else
                        {
                            if (MissionData.BeOnOff[2] && World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 60.00f)
                            {
                                MoveThatCar(MissionData.vTarget_01);
                                MissionData.BeOnOff[2] = false;
                            }
                            else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 5.00f)
                            {
                                MissionData.iWait4Sec = Game.GameTime + 1000;
                                MissionData.iMishText = -1;
                                MissionData.iMissionSeq = 5;
                            }
                            else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[4]);
                                MissionData.iMishText = 143;
                            }

                            if (MissionData.iTracking < Game.GameTime)
                                TheMissions.BikerRaids_LostMCAtt();
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.VehTrackin_01.FreezePosition = true;
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 0);
                            MissionData.iCashReward += MissionData.iUltPed01 * 250;
                            MissionData.iCashReward += 5000;
                            MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Locked;
                            if (MissionData.iCashReward < 25000)
                                MissionData.BeOnOff[4] = true;
                            MissionData.iMissionSeq = 10;
                        }
                    }
                }       //kidnap workers
                else if (MissionData.iMissionVar_01 == 2)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], 0.00f);
                        MissionData.iMishText = 140;
                        MissionData.iMissionSeq = 1;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[0]) < 1.50f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.fList_01.Add(Game.Player.Character.Heading + 180.00f);
                            ObjectHand.RemoveTargets();
                            Vector3 VT = MissionData.VectorList_03[MissionData.VectorList_03.Count - 1];
                            VT.Z -= 1.00f;
                            UiDisplay.TheYellowCorona(VT, 1.00f);
                            ObjectHand.SlowFastTravel(MissionData.VectorList_03[MissionData.VectorList_03.Count - 1], MissionData.fMission_01);
                            TheMissions.BikerRaids_LoadHood();
                            MissionData.iMissionSeq = 2;
                            MissionData.iMishText = 145;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.PedList_01.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                ObjectHand.SimpleTracker();
                        }
                        else
                        {
                            MissionData.iMishText = 142;
                            MissionData.iMissionSeq = 3;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_03[MissionData.VectorList_03.Count - 1]) < 1.50f)
                        {
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], MissionData.fList_01[0]);
                            MissionData.iTime_01[1] = Game.GameTime + 90000;
                            MissionData.iMishText = 145;
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.iTime_01[1] > Game.GameTime)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                                TheMissions.BikerRaids_LostMCAtt();
                        }
                        else
                        {
                            MissionData.iMishText = -1;
                            MissionData.iMissionSeq = 10;
                            MissionData.iCashReward += MissionData.iUltPed01 * 250;
                            if (MissionData.iCashReward < 25000)
                                MissionData.BeOnOff[4] = true;
                        }
                    }
                }        //Raid
                else if (MissionData.iMissionVar_01 == 3)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        Vector3 Vehs = MissionData.VectorList_02[0];
                        Vehs.Z -= 0.70f;
                        ObjectBuild.VehicleSpawn("SLAMVAN2", Vehs, MissionData.fGetDir, false, false, false, false, 3, 2, 0, "", 1, true);
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], 0.00f);
                        MissionData.iMishText = 140;
                        MissionData.iMissionSeq = 1;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (MissionData.VehicleList_01.Count > 0)
                        {
                            if (MissionData.VehTrackin_01.IsDead)
                                MissionData.iMissionSeq = 45;
                            else if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[0]) < 1.50f && !Game.Player.Character.IsInVehicle())
                            {
                                MissionData.fList_01.Add(Game.Player.Character.Heading + 180.00f);
                                ObjectHand.RemoveTargets();
                                Vector3 VT = MissionData.VectorList_03[MissionData.VectorList_03.Count - 1];
                                VT.Z -= 1.00f;
                                MissionData.BeOnOff[3] = false;
                                ObjectHand.SlowFastTravel(VT, MissionData.fMission_01);
                                TheMissions.BikerRaids_LoadHood();
                                MissionData.iMissionSeq = 2;
                                MissionData.iMishText = 146;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.Npc_01.IsDead)
                        {
                            MissionData.Npc_01.CurrentBlip.Remove();
                            MissionData.Prop_01 = ObjectBuild.BuildProp("p_car_keys_01", MissionData.Npc_01.Position, Vector3.Zero, false, false);
                            ObjectHand.AddTarget(MissionData.Npc_01.Position, false, true, 1.00f, false, 811, DataStore.MyLang.Maptext[66]);
                            MissionData.BeOnOff[0] = true;
                            MissionData.iMissionSeq = 3;
                            MissionData.iMishText = 147;
                        }

                        if (MissionData.MishPed.Count > 0)
                        {
                            if (!MissionData.BeOnOff[3])
                            {
                                int iCount = MissionData.MishPed.Count;
                                while (iCount > 0)
                                {
                                    iCount = iCount - 1;
                                    MissionData.MishPed[iCount].Task.Cower(-1);
                                }
                                MissionData.BeOnOff[3] = true;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (ReturnStuff.PickupBling(MissionData.Prop_01))
                        {
                            MissionData.BeOnOff[0] = false;
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Unlocked;
                            MissionData.VehTrackin_01.IsBulletProof = true;
                            MissionData.iMishText = 142;
                            Vector3 VT = MissionData.VectorList_03[MissionData.VectorList_03.Count - 1];
                            VT.Z -= 1.00f;
                            UiDisplay.TheYellowCorona(VT, 1.00f);
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_03[MissionData.VectorList_03.Count - 1]) < 1.50f)
                        {
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[11]);
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.BeOnOff[1] = true;
                            MissionData.BeOnOff[2] = true;
                            MissionData.BeOnOff[3] = false;
                            float fDist = MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01);
                            int iFind = (int)fDist;
                            MissionData.iCashReward += iFind;
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[0], MissionData.fList_01[0]);
                            MissionData.iMishText = 148;
                            MissionData.iMissionSeq = 5;
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.BeOnOff[1])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = false;
                                if (!MissionData.BeOnOff[3])
                                    MissionData.iWait4Sec = Game.GameTime + 7000;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.vTarget_01 = ReturnStuff.AlterZHight(MissionData.vTarget_01, -1.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 492, DataStore.MyLang.Maptext[65]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                                MissionData.BeOnOff[3] = true;
                                MissionData.iMishText = 149;
                            }
                        }
                        else
                        {
                            if (MissionData.BeOnOff[2] && World.GetDistance(MissionData.vTarget_01, Game.Player.Character.Position) < 60.00f)
                            {
                                MoveThatCar(MissionData.vTarget_01);
                                MissionData.BeOnOff[2] = false;
                            }
                            else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 5.00f)
                            {
                                MissionData.iWait4Sec = Game.GameTime + 1000;
                                MissionData.iMissionSeq = 6;
                            }
                            else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = true;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[11]);
                                MissionData.iMishText = 148;
                            }

                            if (MissionData.iTracking < Game.GameTime)
                                TheMissions.BikerRaids_LostMCAtt();
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.VehTrackin_01.FreezePosition = true;
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 0);
                            MissionData.VehTrackin_01.LockStatus = VehicleLockStatus.Locked;
                            MissionData.iCashReward += MissionData.iUltPed01 * 250;
                            MissionData.iCashReward += 5000;
                            if (MissionData.iCashReward < 25000)
                                MissionData.BeOnOff[4] = true;
                            MissionData.iMissionSeq = 10;
                        }
                    }
                }      //steal goods--
            }       //BikerRaids
            else if (MissionData.iJobType == 19)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                    MissionData.iMishText = 150;
                    MissionData.iMissionSeq = 1;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.50f && !Game.Player.Character.IsInVehicle())
                    {
                        Game.FadeScreenOut(100);
                        if (MissionData.iMissionVar_01 == 6)
                        {
                            MissionData.vTarget_06 = new Vector3(998.753f, -3110.82f, -39.534f);
                            MissionData.fCoronaHight = -9.22f;
                            Vehicle VNot = ObjectBuild.VehicleSpawn("Forklift", MissionData.vTarget_06, MissionData.fCoronaHight, true, false, false, false, 0, 0, 4, DataStore.MyLang.Maptext[12], 1, false);
                            VNot.CurrentBlip.Color = BlipColor.Blue;
                            ObjectBuild.VehicleSpawn("SANDKING2", MissionData.VectorList_04[MissionData.iMissionVar_03], MissionData.fList_02[MissionData.iMissionVar_03], false, false, false, false, 26, 0, 0, "", 2, true);

                            MissionData.iCashReward += 1000;
                        }
                        else if (MissionData.iMissionVar_01 == 7)
                        {
                            MissionData.vTarget_06 = new Vector3(1051.23f, -3098.5f, -38.99994f);//new Vector3(1070.3669f, -3106.485f, -39.5371f);
                            MissionData.fCoronaHight = -0.39f;
                            Vehicle VNot = ObjectBuild.VehicleSpawn("Forklift", MissionData.vTarget_06, MissionData.fCoronaHight, true, false, false, false, 0, 0, 4, DataStore.MyLang.Maptext[12], 1, false);
                            VNot.CurrentBlip.Color = BlipColor.Blue;
                            ObjectBuild.VehicleSpawn("SANDKING2", MissionData.VectorList_04[MissionData.iMissionVar_03], MissionData.fList_02[MissionData.iMissionVar_03], false, false, false, false, 26, 0, 0, "", 2, true);

                            MissionData.iCashReward += 750;
                        }
                        else if (MissionData.iMissionVar_01 == 8)
                        {
                            MissionData.vTarget_06 = new Vector3(1090.853f, -3099.615f, -38.99996f);//new Vector3(1091.359f, -3102.17f, -39.534f);
                            MissionData.fCoronaHight = 88.638f;
                            Vehicle VNot = ObjectBuild.VehicleSpawn("Forklift", MissionData.vTarget_06, MissionData.fCoronaHight, true, false, false, false, 0, 0, 4, DataStore.MyLang.Maptext[12], 1, false);
                            VNot.CurrentBlip.Color = BlipColor.Blue;
                            ObjectBuild.VehicleSpawn("SANDKING2", MissionData.VectorList_04[MissionData.iMissionVar_03], MissionData.fList_02[MissionData.iMissionVar_03], false, false, false, false, 26, 0, 0, "", 2, true);
                            MissionData.iCashReward += 500;
                        }
                        else
                        {
                            MissionData.vTarget_06 = new Vector3(872.73f, -3247.447f, -98.837f);
                            MissionData.fCoronaHight = 5.446f;
                            Vehicle VNot = ObjectBuild.VehicleSpawn("Forklift", MissionData.vTarget_06, MissionData.fCoronaHight, true, false, false, false, 0, 0, 4, DataStore.MyLang.Maptext[12], 1, false);
                            VNot.CurrentBlip.Color = BlipColor.Blue; 
                            Vector3 VePoz = new Vector3(837.8329f, -3237.161f, -98.91f);
                            float fit = 76.10f;
                            ObjectBuild.VehicleSpawn("SANDKING2", VePoz, fit, false, false, false, false, 26, 0, 0, "", 2, true);

                            VePoz = new Vector3(867.67688f, -3247.6582f, -98.906f);
                            fit = 0.337f;
                            ObjectBuild.VehicleSpawn("Caddy3", VePoz, fit, false, false, false, false, 0, 0, 0, "", 0, false);

                            VePoz = new Vector3(869.85f, -3247.40f, -98.8944f);
                            fit = -0.528f;
                            ObjectBuild.VehicleSpawn("Caddy2", VePoz, fit, false, false, false, false, 0, 0, 0, "", 0, false);

                            MissionData.iCashReward += 5000;
                        }
                        MissionData.BeOnOff[1] = true;
                        MissionData.BeOnOff[0] = false;
                        ObjectHand.RemoveTargets();
                        ObjectHand.SlowFastTravel(MissionData.VectorList_02[MissionData.VectorList_02.Count - 1], MissionData.fMission_01);
                        TheMissions.CargoCollect_LoadHood();
                        MissionData.iMissionSeq = 2;
                        MissionData.iMishText = 151;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehicleList_01.Count > 1)
                    {
                        if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.iTracking < Game.GameTime)
                            ObjectHand.SimpleTracker();

                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;

                        if (MissionData.BeOnOff[1])
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = false;
                                UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.Prop_01.Position.X, MissionData.Prop_01.Position.Y, MissionData.Prop_01.Position.Z + 1.25f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.Prop_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.CadetBlue };
                                UiDisplay.bMMDisplay01 = true;
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.iMishText = MissionData.iList_01[0];
                            }
                        }
                        else
                        {
                            Vector3 Forks = MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.ForwardVector * 2);
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.BeOnOff[1] = true;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[12]);
                                MissionData.iMishText = 151;
                            }
                            else if (Forks.DistanceTo(MissionData.Prop_01.Position) < 1.30f)
                            {
                                UiDisplay.bMMDisplay01 = false;
                                MissionData.Prop_01.FreezePosition = false;
                                MissionData.Prop_01.AttachTo(MissionData.VehTrackin_01, Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, MissionData.VehTrackin_01.Handle, "forks_attach"), new Vector3(0.00f, 0.00f, 0.10f), new Vector3(0.00f, 0.00f, 90.00f));
                                if (MissionData.iMissionVar_01 != 9)
                                {
                                    MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -1.00f);
                                    UiDisplay.TheYellowCorona(MissionData.vTarget_02, 5.00f);
                                    MissionData.iMissionSeq = 3;
                                }
                                else
                                {
                                    ReturnStuff.VehBlip(MissionData.VehTrackin_02, true, false, 3, DataStore.MyLang.Maptext[1]);
                                    MissionData.BeOnOff[2] = true;
                                    MissionData.iMissionSeq = 4;
                                }
                                MissionData.iMishText = 158;
                            }

                            UiDisplay.ControlerUI(DataStore.MyLang.Context[24], 1);
                            if (Game.IsControlPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iWait4Sec < Game.GameTime && !MissionData.BeOnOff[0])
                                {
                                    MissionData.BeOnOff[0] = true;
                                    TheMissions.ResetTruck(MissionData.VehTrackin_01, MissionData.vTarget_06, MissionData.fCoronaHight);
                                }
                            }
                            else
                                MissionData.iWait4Sec = Game.GameTime + 1500;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iTracking < Game.GameTime)
                        ObjectHand.SimpleTracker();

                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;

                    if (MissionData.BeOnOff[1])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[1] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = MissionData.iList_01[0];
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[1] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[12]);
                            MissionData.iMishText = 151;
                        }
                        else
                        {
                            if (MissionData.Prop_01.Position.DistanceTo(MissionData.vTarget_02) < 2.00f)
                            {
                                Game.FadeScreenOut(1000);
                                Script.Wait(1000);
                                MissionData.vTarget_06 = MissionData.VectorList_03[MissionData.iMissionVar_03];
                                MissionData.fCoronaHight = MissionData.fList_01[MissionData.iMissionVar_03];
                                MissionData.VehTrackin_01.Position = MissionData.vTarget_06;
                                MissionData.VehTrackin_01.Heading = MissionData.fCoronaHight;
                                ObjectHand.CleanPedBlips(1);
                                ReturnStuff.VehBlip(MissionData.VehTrackin_02, true, false, 3, DataStore.MyLang.Maptext[1]);
                                MissionData.BeOnOff[2] = true;
                                Game.FadeScreenIn(1000);
                                MissionData.iMissionSeq = 4;
                                MissionData.iMishText = MissionData.iList_01[0];
                            }
                            else
                            {
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[24], 1);
                                if (Game.IsControlPressed(2, GTA.Control.Context))
                                {
                                    if (MissionData.iWait4Sec < Game.GameTime && !MissionData.BeOnOff[0])
                                    {
                                        MissionData.BeOnOff[0] = true;
                                        TheMissions.ResetTruck(MissionData.VehTrackin_01, MissionData.vTarget_06, MissionData.fCoronaHight);
                                    }
                                }
                                else
                                    MissionData.iWait4Sec = Game.GameTime + 1500;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.VehTrackin_01.IsDead || MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iTracking < Game.GameTime)
                        ObjectHand.SimpleTracker();

                    if (MissionData.BeOnOff[1])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[1] = false;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = MissionData.iList_01[0];
                        }
                    }
                    else
                    {
                        Vector3 Bed = MissionData.VehTrackin_02.Position - (MissionData.VehTrackin_01.ForwardVector * 2.24f);
                        Bed.Z += 0.80f;
                        if (MissionData.Prop_01.Position.DistanceTo(Bed) < 0.80f)
                        {
                            MissionData.Prop_01.Detach();
                            MissionData.Prop_01.AttachTo(MissionData.VehTrackin_02, Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, MissionData.VehTrackin_01.Handle, "chassis"), new Vector3(0.00f, -2.25f, 0.85f), new Vector3(0.00f, 0.00f, 90.00f));
                            MissionData.iMishText = 164;
                            if (MissionData.iMissionVar_01 == 9)
                                MissionData.iMissionSeq = 5;
                            else
                            {
                                MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(20000, 60000);
                                MissionData.BeOnOff[3] = true;
                                MissionData.BeOnOff[4] = true;
                                MissionData.BeOnOff[5] = false;
                                MissionData.iMissionSeq = 6;
                            }
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[1] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[12]);
                            MissionData.iMishText = 151;
                        }
                        else
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[24], 1);
                            if (Game.IsControlPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iWait4Sec < Game.GameTime && !MissionData.BeOnOff[0])
                                {
                                    MissionData.BeOnOff[0] = true;
                                    TheMissions.ResetTruck(MissionData.VehTrackin_01, MissionData.vTarget_06, MissionData.fCoronaHight);
                                }
                            }
                            else
                                MissionData.iWait4Sec = Game.GameTime + 1500;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_02))
                    {
                        Game.FadeScreenOut(1000);
                        Script.Wait(1000);
                        MissionData.VehTrackin_02.Position = MissionData.VectorList_03[MissionData.iMissionVar_03];
                        MissionData.VehTrackin_02.Heading = MissionData.fList_01[MissionData.iMissionVar_03];
                        ObjectHand.CleanPedBlips(1);
                        MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(20000, 60000);
                        MissionData.BeOnOff[3] = true;
                        MissionData.BeOnOff[5] = false;
                        MissionData.BeOnOff[4] = true;
                        MissionData.iMissionSeq = 6;
                        Game.FadeScreenIn(1000);
                        MissionData.iMishText = 151;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.BeOnOff[3])
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.BeOnOff[3] = false;
                            TheMissions.CargoCollect_Suprise();
                            MissionData.iTracking = Game.GameTime + 1000;
                        }
                    }
                    else
                    {
                        if (MissionData.iMissionVar_03 < 5 && MissionData.MultiPed.Count > 0)
                        {
                            if (MissionData.iTracking < Game.GameTime)
                            {
                                if (Game.Player.WantedLevel > 0)
                                    Game.Player.WantedLevel = 0;

                                ObjectHand.MultiPedTracker();
                            }
                        }
                    }

                    if (MissionData.VehTrackin_02.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[2])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_02))
                        {
                            MissionData.BeOnOff[2] = false;
                            MissionData.VehTrackin_02.CloseDoor(VehicleDoor.Trunk, true);
                            MissionData.VehTrackin_02.CurrentBlip.Remove();
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 10.00f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 478, DataStore.MyLang.Maptext[39]);
                            MissionData.iMishText = MissionData.iList_01[2];
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_02))
                        {
                            MissionData.BeOnOff[2] = true;
                            ReturnStuff.VehBlip(MissionData.VehTrackin_02, true, false, 3, DataStore.MyLang.Maptext[1]);

                            ObjectHand.RemoveTargets();
                        }
                        else
                        {
                            if (MissionData.BeOnOff[4] && World.GetDistance(MissionData.vTarget_03, Game.Player.Character.Position) < 60.00f)
                            {
                                MoveThatCar(MissionData.vTarget_03);
                                MissionData.BeOnOff[4] = false;
                            }
                            else if (MissionData.VehTrackin_02.Position.DistanceTo(MissionData.vTarget_03) < 5.00f)
                            {
                                ObjectHand.RemoveTargets();
                                ObjectBuild.GetOutofVeh(Game.Player.Character, 0);
                                MissionData.iMissionSeq = 10;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    ObjectHand.NSCoinInvestments(true, 7, 11, "SecuroServ Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.NSCoinInvestments(false, 8, 13, "SecuroServ Shares");
                    TheMissions.CargoCollect_UnloadInt(MissionData.iMissionVar_01);
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //BayLift
            else if (MissionData.iJobType == 20)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                    MissionData.iMishText = 125;
                    MissionData.iMissionSeq = 1;

                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 75.00f, false, -1, DataStore.MyLang.Maptext[26]);
                        MissionData.VehTrackin_01.CurrentBlip.Remove();
                        MissionData.BeOnOff[0] = false;
                        MissionData.iMissionSeq = 2;
                        MissionData.iMishText = 90;
                    }
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 35.00f)
                        MissionData.iMishText = 171;
                    else
                        MissionData.iMishText = 125;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 75.00f, false, -1, DataStore.MyLang.Maptext[26]);
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = 90;
                            MissionData.BeOnOff[0] = false;
                        }
                    }
                    else
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.BeOnOff[0] = true;
                            ObjectHand.RemoveTargets();
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 66, DataStore.MyLang.Maptext[13]);
                            MissionData.iMishText = 171;
                        }
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 85.00f)
                        {
                            TheMissions.DeepDown_Addfish();
                            MissionData.BeOnOff[1] = false;
                            MissionData.iMissionSeq = 3;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead || !Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.PedList_01.Count > 0)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            TheMissions.DeepDown_SwimtoBarrel();
                        }
                    }
                    else
                        MissionData.iMissionSeq = 10;

                    if (!MissionData.BeOnOff[1])
                    {
                        if (MissionData.PropList_01.Count > 0)
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[25], 1);

                            if (Game.IsControlPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iMissionVar_01 < Game.GameTime)
                                {
                                    Vector3 vMe = MissionData.PropList_01[0].Position;
                                    MissionData.PropList_01[0].Delete();
                                    MissionData.PropList_01.RemoveAt(0);
                                    World.AddExplosion(vMe, ExplosionType.StickyBomb, 10.00f, 5.00f, true, false);
                                    Script.Wait(ReturnStuff.RandInt(75, 300));
                                    World.AddExplosion(vMe, ExplosionType.StickyBomb, 10.00f, 5.00f, true, false);
                                    Script.Wait(ReturnStuff.RandInt(75, 300));
                                    World.AddExplosion(vMe, ExplosionType.StickyBomb, 10.00f, 5.00f, true, false);
                                }
                            }
                            else
                                MissionData.iMissionVar_01 = Game.GameTime + 500;

                            MissionData.iMishText = 172;
                        }
                        else
                        {
                            if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 85.00f)
                            {
                                UiDisplay.ControlerUI(DataStore.MyLang.Context[26], 1);

                                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                                {
                                    MissionData.BeOnOff[1] = true;
                                    TheMissions.DeepDown_DropBomb();
                                }

                                MissionData.iMishText = 173;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    ObjectHand.NSCoinInvestments(true, 8, 13, "Vespucci Surfing Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    if (!MissionData.bTestRun)
                        ObjectHand.NSCoinInvestments(false, 9, 15, "Vespucci Surfing Shares");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //Sharks
            else if (MissionData.iJobType == 26)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                    MissionData.iMishText = 179;
                    ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 52, DataStore.MyLang.Maptext[58]);
                    MissionData.iMissionSeq = 1;

                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 3.50f)
                    {
                        MissionData.iMissionVar_01 = 0;
                        ObjectBuild.ArmNpcWeapon("WEAPON_bat", Game.Player.Character);
                        ObjectHand.RemoveTargets();
                        MissionData.iMissionSeq = 2;

                        MissionData.iMishText = 180;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (!Function.Call<bool>(Hash.IS_PED_ARMED, Game.Player.Character, 6) || Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 20.00f)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;

                        float fPer = ReturnStuff.HappyShopper_DAmmagedGoods();
                        UiDisplay.BtSlideBar.Percentage = fPer;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;       //draw the spookbar to screen.

                        if (fPer > 0.99f)
                            MissionData.iMissionSeq = 3;
                    }
                    else
                        MissionData.iMissionSeq = 45;
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    MissionData.iCashReward = ReturnStuff.RandInt(5000, 7000);
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    Game.Player.WantedLevel = 4;
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //HappyShopper
            else if (MissionData.iJobType == 27)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    if (MissionData.VehicleList_01.Count > 0)
                    {
                        MissionData.iMissionSeq += 1;
                        MissionData.iMissionVar_02 = MissionData.VehTrackin_01.Health;
                        MissionData.iList_01 = ReturnStuff.MaxModsRandExtras(MissionData.VehTrackin_01);
                        MissionData.VehTrackin_01.CurrentBlip.Color = BlipColor.Blue;
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        MissionData.iMishText = 181;
                    }
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(Game.Player.Character.Position) < 50.00f)
                    {
                        MissionData.iMishText = 81;
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 380, DataStore.MyLang.Maptext[67]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                            MissionData.iMishText = 182;
                        }
                    }
                    else
                        MissionData.iMishText = 181;
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;

                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else
                    {
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 2.50f)
                        {
                            ObjectHand.RemoveTargets();
                            Game.FadeScreenOut(1000);
                            Script.Wait(1000);
                            DataStore.Drilar.Play();
                            Script.Wait(1000);
                            MissionData.VehTrackin_01.Heading = MissionData.fMission_01;
                            MissionData.VehTrackin_01.Repair();
                            MissionData.fMission_01 = MissionData.VehTrackin_01.BodyHealth;
                            ObjectHand.AddTarget(MissionData.vGetaway, true, true, 1.00f, false, 225, DataStore.MyLang.Maptext[68]);
                            UiDisplay.TheYellowCorona(MissionData.vGetaway, 5.00f);
                            Game.FadeScreenIn(1000);
                            MissionData.iMishText = 183;
                            MissionData.iMissionSeq += 1;
                        }
                        else if (MissionData.Target_01 == null)
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 1.00f, false, 380, DataStore.MyLang.Maptext[67]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_01, 5.00f);
                                MissionData.iMishText = 182;
                            }
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[14]);
                                MissionData.iMishText = 81;
                            }
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.VehTrackin_01.IsDead || !MissionData.VehTrackin_01.IsDriveable)
                        MissionData.iMissionSeq = 45;

                    if (MissionData.VehTrackin_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else
                    {
                        UiDisplay.BtSlideBar.Percentage = ReturnStuff.MoresMuted_DAmmagedGoods(MissionData.VehTrackin_01);

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;       //draw the spookbar to screen.
                        if (MissionData.BeOnOff[0] && MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vGetaway) < 95.50f)
                        {
                            MissionData.BeOnOff[0] = false;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vGetaway, MissionData.fGetDir, false, false, true, false, 0, 0, 0, "", 2, false);
                            ObjectBuild.GhostVehicle(MissionData.VehTrackin_02, MissionData.vGetaway, MissionData.fGetDir);
                        }
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vGetaway) < 1.50f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionSeq += 1;
                        }
                        else if (MissionData.Target_01 == null)
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vGetaway, true, true, 1.00f, false, 225, DataStore.MyLang.Maptext[67]);
                                UiDisplay.TheYellowCorona(MissionData.vGetaway, 5.00f);
                                MissionData.iMishText = 183;
                            }
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, DataStore.MyLang.Maptext[14]);
                                MissionData.iMishText = 81;
                            }
                        }
                        else if (ReturnStuff.MoresMuted_DAmmagedGoods(MissionData.VehTrackin_01) > 0.90f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_01.Explode();
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        MissionData.iWait4Sec = Game.GameTime + 10000;
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VehTrackin_02.Position) < 0.5f && ReturnStuff.BeInAngle(5.00f, MissionData.VehTrackin_01.Heading, MissionData.VehTrackin_02.Heading))
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.iMishText = 184;
                        }
                        else
                            MissionData.iMissionSeq = 45;
                        MissionData.VehTrackin_02.Position = Vector3.Zero;
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(12), MissionData.VectorList_01[MissionData.iMissionVar_01], MissionData.fList_01[MissionData.iMissionVar_01], false, 250, 23, 0, null, 0, true, 0, 0, DataStore.MyLang.Maptext[105]);
                        MissionData.iMissionSeq += 1;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    if (MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (ReturnStuff.BeenSpotted(MissionData.Npc_01, Game.Player.Character, true))
                    {
                        ObjectBuild.AttackThePlayer(MissionData.Npc_01, true);
                        MissionData.iMissionSeq = 45;
                    }
                    if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        TheMissions.Hitman_RemoveVisionCones();
                        MissionData.VehTrackin_01.Explode();
                        MissionData.iCashReward = ReturnStuff.RandInt(10000, 20000);
                        MissionData.iMissionSeq = 10;
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    TheMissions.Hitman_RemoveVisionCones();
                    ObjectHand.NSCoinInvestments(false, 5, 7, "Mors Mutual Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.NSCoinInvestments(true, 5, 7, "Mors Mutual Shares");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //MoresMute
            else if (MissionData.iJobType == 28)
            {
                if (MissionData.iLocationX == 1)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        MissionData.iMishText = 185;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            ObjectHand.RemoveTargets();
                            Game.FadeScreenOut(1000);
                            TheMissions.LoadInMissionIPLs(11, true, false);
                            TheMissions.TempAgency_01_LoadInShit();
                            ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fMission_01);
                            MissionData.iMishText = 186;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                            {
                                MissionData.Prop_01 = ObjectBuild.BuildProp("stt_prop_stunt_soccer_ball", MissionData.vTarget_02, new Vector3(0.00f, 0.00f, 0.00f), false, false);
                                MissionData.iMissionVar_01 = 0;
                                MissionData.iMissionVar_03 = 0;
                                MissionData.iMishText = -1;
                                TheMissions.TempAgency_01_AddGoal();
                                TheMissions.TempAgency_01_FormationNGate();
                                MissionData.iMissionVar_04 = Game.GameTime + 280000;
                                MissionData.iMissionSeq += 1;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (!Game.Player.Character.IsInVehicle())
                            MissionData.iMissionSeq = 45;
                        else
                        {
                            if (ReturnStuff.TempAgency_01_BallTracking())
                                TheMissions.TempAgency_01_Formation();
                            else
                            {
                                if (MissionData.iMissionVar_04 < Game.GameTime)
                                    MissionData.iMissionSeq += 1;
                                ObjectHand.FindTheTime(MissionData.iMissionVar_04 - Game.GameTime, 2, "", true);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        MissionData.iMissionSeq += 1;
                        if (MissionData.BeOnOff[1])
                        {
                            if (MissionData.iMissionVar_01 > MissionData.iMissionVar_03)
                                TheMissions.TempAgency_01_ExitWithCar(false);
                            else
                                TheMissions.TempAgency_01_ExitWithCar(true);
                        }
                        else
                        {
                            if (MissionData.iMissionVar_01 < MissionData.iMissionVar_03)
                                TheMissions.TempAgency_01_ExitWithCar(false);
                            else
                                TheMissions.TempAgency_01_ExitWithCar(true);
                        }
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                        TheMissions.LoadInMissionIPLs(11, false, false);
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       //CarBall
                else if (MissionData.iLocationX == 2)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);

                        MissionData.iMishText = 198;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 75.5f)
                        {
                            TheMissions.TempAgency_02_ClubQUe();
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;

                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            Game.FadeScreenOut(1000);
                            ObjectHand.RemoveTargets();
                            if (!TheMissions.bYouGotAClub)
                                TheMissions.LoadInteriors(1, true);
                            TheMissions.TempAgency_02_FillClub();
                            ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fMission_01);
                            MissionData.iMissionSeq += 1;
                            SetTheTime(20, 0, 0);
                            MissionData.iMishText = 199;
                            ObjectHand.AddTarget(MissionData.VectorList_02[MissionData.iMissionVar_01], true, true, 1.00f, false, 93, DataStore.MyLang.Maptext[70]);
                            UiDisplay.TheYellowCorona(MissionData.VectorList_02[MissionData.iMissionVar_01], 1.00f);
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.iKeepDance < Game.GameTime)
                            TheMissions.TempAgency_02_RunForTHeHills();

                        if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;

                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_02[MissionData.iMissionVar_01]) < 1.75f)
                        {
                            MissionData.iMissionVar_01 += 1;
                            ObjectHand.RemoveTargets();
                            if (MissionData.iMissionVar_01 < MissionData.VectorList_02.Count)
                            {
                                UiDisplay.TheYellowCorona(MissionData.VectorList_02[MissionData.iMissionVar_01], 1.00f);
                                ObjectHand.AddTarget(MissionData.VectorList_02[MissionData.iMissionVar_01], true, true, 1.00f, false, 93, DataStore.MyLang.Maptext[70]);
                            }
                            else
                            {
                                MissionData.VectorList_02.Clear();
                                UiDisplay.ttTextBar_01.Text = "$" + MissionData.iCashReward;
                                MissionData.BeOnOff[0] = true;
                                TheMissions.TempAgency_02_BarStools();
                                MissionData.iMissionVar_01 = 0;
                                MissionData.iMishText = 200;
                                MissionData.iMissionSeq += 1;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (MissionData.iKeepDance < Game.GameTime)
                            TheMissions.TempAgency_02_RunForTHeHills();

                        if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;

                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_03;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.iKeepDance < Game.GameTime)
                            TheMissions.TempAgency_02_RunForTHeHills();

                        if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;

                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_03) < 1.5f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.BeOnOff[0] = true;
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMishText = 200;
                            DataStore.CashTil.Play();
                            TheMissions.TempAgency_02_AddRubish();
                            MissionData.iCashReward += ReturnStuff.RandInt(1, 10);
                            UiDisplay.ttTextBar_01.Text = "$" + MissionData.iCashReward;

                            if (ReturnStuff.BeRightOnTime(1, 2))
                                MissionData.iMissionSeq = 6;
                            else
                                MissionData.iMissionSeq -= 1;
                        }

                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_03;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        TheMissions.TempAgency_02_CleanOutClub();
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, MissionData.fList_01[0]);
                        TheMissions.LoadInteriors(1, false);
                        TheMissions.LoadInMissionIPLs(MissionData.iList_01[0], false, false);
                        MissionData.iCashReward += 150;
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        TheMissions.TempAgency_02_CleanOutClub();
                        if (!TheMissions.bYouGotAClub)
                            TheMissions.LoadInteriors(1, false);
                        TheMissions.LoadInMissionIPLs(MissionData.iList_01[0], false, false);
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, MissionData.fList_01[0]);
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       //Knight Club
                else if (MissionData.iLocationX == 3)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;
                        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);

                        MissionData.iMishText = 202;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");

                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 150.5f)
                        {
                            if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.5f && !Game.Player.Character.IsInVehicle())
                            {
                                Game.FadeScreenOut(1000);
                                ObjectHand.RemoveTargets();
                                TheMissions.LoadInMissionIPLs(17, true, false);
                                TheMissions.LoadInteriors(2, true);
                                ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fMission_01);
                                TheMissions.TempAgency_03_HangerDupes();
                                MissionData.BeOnOff[0] = false;
                                MissionData.BeOnOff[2] = true;
                                MissionData.iMissionSeq += 1;
                            }
                            MissionData.iMishText = 203;
                        }
                        else
                            MissionData.iMishText = 202;

                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        TheMissions.TempAgency_03_TrackDump();
                        if (MissionData.VehTrackin_02.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_02))
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[28], 1);

                            if (MissionData.BeOnOff[1])
                            {
                                MissionData.iMishText = 205;
                                MissionData.BeOnOff[1] = false;
                                MissionData.VehTrackin_02.CurrentBlip.Remove();
                            }
                            else if (Game.IsControlPressed(2, GTA.Control.Context))
                            {
                                if (MissionData.iWait4Sec < Game.GameTime)
                                {
                                    MissionData.BeOnOff[0] = true;
                                    TheMissions.ResetTruck(MissionData.VehTrackin_02, MissionData.vTarget_03, MissionData.fMission_02);
                                }
                            }
                            else
                                MissionData.iWait4Sec = Game.GameTime + 1000;
                        }
                        else
                        {
                            if (!MissionData.BeOnOff[1])
                            {
                                MissionData.iMishText = 204;
                                MissionData.BeOnOff[1] = true;
                                ReturnStuff.VehBlip(MissionData.VehTrackin_02, false, false, 3, DataStore.MyLang.Maptext[77]);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        MissionData.iMissionSeq = 4;
                        MissionData.BeOnOff[2] = false;
                        TheMissions.TempAgency_03_TruckOff();
                        Game.Player.WantedLevel = 0;
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (Game.Player.WantedLevel > 0)
                            Game.Player.WantedLevel = 0;
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 == null)
                            {
                                ObjectHand.AddTarget(MissionData.VectorList_02[3], true, true, 1.00f, false, 774, DataStore.MyLang.Maptext[42]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_02[3], 15.00f);
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                MissionData.iMishText = 207;
                            }
                            if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VectorList_02[3]) < 5.00f)
                            {
                                ObjectBuild.GetOutofVeh(Game.Player.Character, 1);
                                TheMissions.TempAgency_03_DupeCount();
                                MissionData.iMissionSeq = 5;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 != null)
                            {
                                MissionData.iMishText = 206;
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[76]);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        ZancudaClosed();
                        TheMissions.LoadInteriors(2, false);
                        TheMissions.LoadInMissionIPLs(17, false, false);
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        if (MissionData.BeOnOff[2])
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, MissionData.fMission_01);
                        ZancudaClosed();
                        TheMissions.LoadInteriors(2, false);
                        TheMissions.LoadInMissionIPLs(17, false, false);
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       //Shovell Dupes
                else if (MissionData.iLocationX == 4)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1; 

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                        MissionData.iMishText = 208;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            ObjectHand.RemoveTargets();
                            TheMissions.LoadInMissionIPLs(20, true, false);
                            TheMissions.LoadInteriors(3, true);
                            ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fMission_01);

                            ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 110, DataStore.MyLang.Maptext[82]);
                            UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            MissionData.iMishText = 209;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (MissionData.iUltPed01 > 1)
                        {
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 180.8543f);
                            MissionData.iMissionSeq = 45;
                        }
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[MissionData.iMissionVar_01]) < 1.5f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 == 1)
                            {
                                TheMissions.TempAgency_04_CasWeaponSkit();
                                MissionData.iMishText = 210;
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 73, DataStore.MyLang.Maptext[81]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            }
                            else if (MissionData.iMissionVar_01 == 2)
                            {
                                DressinRoom.WardrobeScan(1);
                                MissionData.iMishText = 211;
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            }
                            else if (MissionData.iMissionVar_01 == 3)
                            {
                                DataStore.LiftDoor.Play();
                                ObjectHand.RemoveTargets();
                                ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.iMissionVar_01], 180.8543f);
                                MissionData.iMissionVar_01 = MissionData.VectorList_01.Count - 2;
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                                UiDisplay.ttTextBar_01.Text = "$";
                                SetTheTime(16, 0, 0);
                                MissionData.iMissionSeq += 1;
                            }
                        }

                        if (MissionData.iMissionVar_01 > 1 && MissionData.iMissionVar_01 == 1)
                            ObjectHand.SimpleTracker();
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[MissionData.iMissionVar_01]) < 1.5f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionVar_01 += 1;
                            DataStore.LiftDoor.Play();
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.iMissionVar_01], 180.8543f);
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 604, DataStore.MyLang.Maptext[84]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 1.00f);
                            MissionData.iMishText = 212;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_03) < 1.50f)
                        {
                            if (ReturnStuff.BeRightOnTime(14, 21) && !MissionData.BeOnOff[0])
                            {
                                if (MissionData.BeOnOff[1])
                                {
                                    MissionData.BeOnOff[1] = false;
                                    ObjectHand.SimpleTracker();
                                }
                                MissionData.iWait4Sec = Game.GameTime + ReturnStuff.RandInt(800, 4500);
                                MissionData.iMissionSeq += 1;
                            }
                            else
                            {
                                if (MissionData.MishPed.Count > 0)
                                {
                                    MissionData.BeOnOff[0] = true;
                                    UiDisplay.bUiDisplay = true;
                                    ObjectHand.RemoveTargets();
                                    int iVehPed = ReturnStuff.RandInt(0, MissionData.MishPed.Count - 1);
                                    MissionData.Npc_01 = MissionData.MishPed[iVehPed];
                                    MissionData.VehTrackin_01 = MissionData.VehicleList_01[iVehPed];
                                    MissionData.Npc_01.Position = MissionData.VectorList_01[MissionData.VectorList_01.Count - 1];
                                    ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_08, 1.00f);
                                    MissionData.iMissionSeq = 10;
                                }
                                else
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.VectorList_01 = ReturnStuff.ListReverseVec3(MissionData.VectorList_01);
                                    MissionData.iMissionVar_01 = 0;
                                    ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                                    UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                                    MissionData.Npc_01 = ObjectBuild.NPCSpawn("s_m_y_valet_01", MissionData.VectorList_01[MissionData.iMissionVar_01], 0.00f, false, 150, 0, 0, null, 0, false, 0, 0, "");
                                    ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_08, 1.00f);
                                    MissionData.iMishText = 231;
                                    MissionData.iMissionSeq = 20;
                                }
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (MissionData.iWait4Sec < Game.GameTime)
                        {
                            int iVe = ReturnStuff.RandInt(1, 5);
                            ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(iVe, 1, true), new Vector3(849.81f, -81.44f, 80.49f), 54.77f, false, false, false, false, 19, 0, 0, "", 1, true);
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_04) < 1.75f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.Npc_01.Task.ClearAll();
                            ObjectBuild.GetOutofVeh(MissionData.Npc_01, 1);
                            ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[15]);
                            ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.VectorList_01[MissionData.VectorList_01.Count - 1], 1.00f);
                            MissionData.iMishText = 213;
                            MissionData.iMissionSeq += 1;
                        }
                        else if (MissionData.VehTrackin_01.IsDamaged)
                        {
                            MissionData.PedList_01.Remove(MissionData.Npc_01);
                            MissionData.MishPed.Remove(MissionData.Npc_01);
                            MissionData.Npc_01.MarkAsNoLongerNeeded();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.MarkAsNoLongerNeeded();
                            MissionData.iMissionSeq -= 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.Position.DistanceTo(MissionData.VectorList_01[MissionData.VectorList_01.Count - 1]) < 1.50f)
                        {
                            MissionData.Npc_01.Task.ClearAll();
                            MissionData.Npc_01.Position = MissionData.vTarget_02;                        
                        }
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.VehTrackin_01.CurrentBlip.Remove();
                            ObjectHand.AddTarget(MissionData.vTarget_05, true, true, 1.00f, false, 524, DataStore.MyLang.Maptext[85]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_05, 5.00f);
                            MissionData.iMishText = 214;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_05) < 2.50f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_01.Position = MissionData.vTarget_06;
                            MissionData.VehTrackin_01.Heading = 266.8939f;
                            MissionData.Npc_01.Task.ClearAll();
                            MissionData.Npc_01.Position = MissionData.vTarget_02;
                            MissionData.iMissionSeq += 1;
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[15]);
                                MissionData.iMishText = 81;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_05, true, true, 1.00f, false, 524, DataStore.MyLang.Maptext[85]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_05, 5.00f);
                                MissionData.iMishText = 214;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionVar_01 = MissionData.VectorList_01.Count - 2;
                            ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                            UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            MissionData.iMishText = 215;
                            MissionData.iMissionSeq = 3;
                        }
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.Position.DistanceTo(MissionData.vTarget_08) < 2.00f)
                        {
                            ObjectHand.RemoveTargets();
                            ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_09, 1.00f);
                            MissionData.iMissionVar_01 = MissionData.VectorList_01.Count - 1;
                            ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                            UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            MissionData.iMishText = 216;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 11)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[MissionData.iMissionVar_01]) < 1.5f)
                        {
                            DataStore.LiftDoor.Play();
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionVar_01 -= 1;
                            ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.iMissionVar_01], 180.8543f);
                            MissionData.iMishText = 213;
                            UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = new Vector3(MissionData.VehTrackin_01.Position.X, MissionData.VehTrackin_01.Position.Y, MissionData.VehTrackin_01.Position.Z + 1.35f), MarkDir = Vector3.Zero, MarkRot = new Vector3(0.00f, 180.00f, MissionData.VehTrackin_01.Heading), MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.CadetBlue };
                            UiDisplay.bMMDisplay01 = true;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 12)
                    {
                        if (MissionData.VehTrackin_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            ObjectHand.AddTarget(MissionData.vTarget_07, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[64]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_07, 5.00f);
                            UiDisplay.bMMDisplay01 = false;
                            MissionData.iMishText = 217;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 13)
                    {
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_07) < 2.50f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.VehTrackin_01.Position = MissionData.vTarget_05;
                            MissionData.VehTrackin_01.Heading = 148.7573f;
                            ObjectHand.AddTarget(MissionData.vTarget_04, true, true, 1.00f, false, -1, DataStore.MyLang.Maptext[75]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_04, 5.00f);
                            MissionData.iMissionSeq += 1;
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[15]);
                                MissionData.iMishText = 81;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_07, true, true, 1.00f, false, 280, DataStore.MyLang.Maptext[75]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_07, 5.00f);
                                MissionData.iMishText = 217;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 14)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_04) < 2.50f && MissionData.VehTrackin_01.IsStopped)
                        {
                            ObjectHand.RemoveTargets();
                            ObjectHand.AddTarget(MissionData.vTarget_03, true, true, 1.00f, false, 604, DataStore.MyLang.Maptext[84]);
                            UiDisplay.TheYellowCorona(MissionData.vTarget_03, 1.00f);
                            Game.Player.Character.Task.LeaveVehicle();
                            MissionData.iMishText = 212;
                            if (MissionData.VehTrackin_01.Health < 850)
                                ObjectBuild.AttackThePlayer(MissionData.Npc_01, false);
                            else
                                MissionData.iCashReward += ReturnStuff.RandInt(10, 100);
                            UiDisplay.ttTextBar_01.Text = "$" + ReturnStuff.ShowComs(MissionData.iCashReward, true, false);
                            Script.Wait(2000);
                            MissionData.Npc_01.Task.ClearAll();
                            ObjectBuild.EnterAnyVeh(MissionData.VehTrackin_01, MissionData.Npc_01, 0, 1.00f);
                            MissionData.iMissionSeq += 1;
                        }
                        else if (!Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            if (MissionData.Target_01 != null)
                            {
                                ObjectHand.RemoveTargets();
                                ReturnStuff.VehBlip(MissionData.VehTrackin_01, false, false, 3, DataStore.MyLang.Maptext[15]);
                                MissionData.iMishText = 81;
                            }
                        }
                        else
                        {
                            if (MissionData.Target_01 == null)
                            {
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                                ObjectHand.AddTarget(MissionData.vTarget_06, true, true, 1.00f, false, 280, DataStore.MyLang.Maptext[75]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_06, 5.00f);
                                MissionData.iMishText = 212;
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 15)
                    {
                        if (MissionData.Npc_01.IsDead)
                            MissionData.iMissionSeq = 45;
                        else if (MissionData.Npc_01.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.MishPed.Remove(MissionData.Npc_01);
                            MissionData.PedList_01.Remove(MissionData.Npc_01);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.MarkAsNoLongerNeeded();
                            MissionData.Npc_01.MarkAsNoLongerNeeded();
                            MissionData.iMissionSeq = 4;
                        }
                    }
                    else if (MissionData.iMissionSeq == 20)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VectorList_01[MissionData.iMissionVar_01]) < 1.5f)
                        {
                            ObjectHand.RemoveTargets();
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 == 1)
                            {
                                DataStore.LiftDoor.Play();
                                ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.iMissionVar_01], 180.8543f);
                                MissionData.iMissionVar_01 += 1;
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                            }
                            else if (MissionData.iMissionVar_01 == 3)
                            {
                                DataStore.LiftDoor.Play();
                                ObjectHand.SlowFastTravel(MissionData.VectorList_01[MissionData.iMissionVar_01], 180.8543f);
                                MissionData.iMissionVar_01 += 1;
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 73, DataStore.MyLang.Maptext[81]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                                TheMissions.TempAgency_04_CasDoors();
                            }
                            else if (MissionData.iMissionVar_01 == 5)
                            {
                                ObjectBuild.XmlPedDresser(Game.Player.Character, ReadWriteXML.LoadXmlClothDefault(DataStore.sDefaulted));
                                ObjectHand.AddTarget(MissionData.VectorList_01[MissionData.iMissionVar_01], true, true, 1.00f, false, 110, DataStore.MyLang.Maptext[82]);
                                UiDisplay.TheYellowCorona(MissionData.VectorList_01[MissionData.iMissionVar_01], 1.00f);
                                MissionData.iMishText = 232;
                            }
                            else
                            {
                                ObjectHand.ReturnWeaps();
                                ObjectHand.CleanUpProps(ObjectHand.ConvertToHandle(null, null, MissionData.PropList_01, null), true, true);
                                MissionData.PropList_01.Clear();
                                MissionData.vTarget_02 = ReturnStuff.AlterZHight(MissionData.vTarget_02, -1.00f);
                                ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 485, DataStore.MyLang.Maptext[83]);
                                UiDisplay.TheYellowCorona(MissionData.vTarget_02, 1.00f);
                                MissionData.iMishText = 233;
                                MissionData.iMissionSeq += 1;
                            }
                        }
                        else if (MissionData.iMissionVar_01 == 0 && MissionData.BeOff[0])
                        {
                            if (MissionData.Npc_01.Position.DistanceTo(MissionData.vTarget_08) < 1.75f)
                            {
                                MissionData.BeOff[0] = false;
                                ObjectHand.WalkThisWay(MissionData.Npc_01, MissionData.vTarget_04, 1.00f);
                            }
                        }
                    }
                    else if (MissionData.iMissionSeq == 21)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_02) < 1.5f)
                        {
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 180.8543f);
                            ObjectHand.NSCoinInvestments(true, 6, 10, "Diamond Resort");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }

                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        ObjectBuild.XmlPedDresser(Game.Player.Character, ReadWriteXML.LoadXmlClothDefault(DataStore.sDefaulted));
                        TheMissions.LoadInteriors(3, false);
                        TheMissions.LoadInMissionIPLs(18, false, false);
                        ObjectHand.NSCoinInvestments(false, 9, 15, "Diamond Resort");
                        TheMissions.GameOver(true, "", false, 0);
                        ObjectHand.ReturnWeaps();
                    }
                }       //Cas Valey
                else if (MissionData.iLocationX == 5)
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;

                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_09, 0.00f);

                        MissionData.bTestRun = false;
                        ObjectHand.RemoveTargets();
                        UiDisplay.TheYellowCorona(MissionData.vTarget_09, 1.00f);
                        ObjectHand.AddTarget(MissionData.vTarget_09, true, true, 1.00f, false, 590, DataStore.MyLang.Maptext[86]);

                        MissionData.iMishText = 237;
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_09) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMishText = -1;
                            ObjectHand.RemoveTargets();
                            TheMissions.LoadInteriors(4, true);
                            ObjectHand.SlowFastTravel(MissionData.vTarget_10, MissionData.fMission_01);
                            ObjectBuild.VehicleSpawn("BMX", MissionData.vTarget_05, 10.00f, false, true, false, false, 0, 0, 0, "", 1, false);
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            MissionData.vTarget_01 = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace[0];
                            MissionData.iCashBouns = 0;
                            MissionData.fCorSize = 5.00f;
                            MissionData.fCheckDist = 4.50f;
                            MissionData.fCoronaDirHt = 4.75f;
                            MissionData.fCoronaHight = -2.00f;
                            MissionData.iRacingStyle = 262144;
                            UiDisplay.MpUiDisplay.Remove(UiDisplay.ttTextBar_03);
                            TheMissions.TempAgency_05_AddBlocks();
                            UiDisplay.ttTextBar_02.Label = DataStore.MyLang.Othertext[154];
                            UiDisplay.ttTextBar_02.Text = "$ 0";
                            MissionData.bSoloRace = false;
                            TheMissions.Racist_StartLine();
                            MissionData.iMissionSeq += 1;
                            MissionData.BeOnOff[0] = true;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.iMishText = -1;
                            TheMissions.Racist_CountDown(MissionData.vTarget_01, true);
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.VehTrackin_02.FreezePosition = false;
                            MissionData.VehTrackin_03.FreezePosition = false;
                            MissionData.VehTrackin_04.FreezePosition = false;
                            for (int i = 0; i < MissionData.MultiPed.Count(); i++)
                            {
                                MissionData.MultiPed[i].MyTask_01 = MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace.Count - 1;
                            }

                            MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace.Count - 1);

                            MissionData.vTarget_02 = MissionData.vTarget_01;
                        }
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < MissionData.fCorSize)
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.BeOff[2] = false;
                            MissionData.iCurrentLap -= 1;
                            MissionData.iList_01[1] = Game.GameTime;//worldtime
                            MissionData.iList_01[2] = Game.GameTime;//currenttime
                            int iOnLap = MissionData.iTotalLap - MissionData.iCurrentLap;
                            TheMissions.TempAgency_05_RemoveDoors();
                            MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            MissionData.fMission_01 = MissionData.VehTrackin_01.Heading;
                        }
                        TheMissions.Racist_PosTime(true);
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (!Game.Player.Character.IsInVehicle() || ReturnStuff.ButtonDown(75))
                            TheMissions.Racist_BackOnTrack(Game.Player.Character, MissionData.VehTrackin_01, MissionData.vTarget_02, MissionData.fMission_01, true, true);
                        else if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < MissionData.fCorSize)
                        {
                            if (MissionData.iList_01[6] == MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace.Count - 1)
                            {
                                TheMissions.TempAgency_05_RemoveDoors();
                                if (MissionData.iCurrentLap == 0)
                                    MissionData.iList_01[6] = ReturnStuff.CheckPointPro(true, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                                else
                                    MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            }
                            else if (MissionData.iList_01[6] == 0)
                            {
                                MissionData.iList_01[3] += 1;
                                MissionData.iCurrentLap -= 1;
                                int iLapX = MissionData.iList_01[2] - Game.GameTime;
                                MissionData.iDeliverList.Add(iLapX);
                                MissionData.iList_01[2] = Game.GameTime;

                                if (MissionData.iCurrentLap < 0)
                                    MissionData.iMissionSeq = 5;
                                else
                                {
                                    int iOnLap = MissionData.iTotalLap - MissionData.iCurrentLap;
                                    BigMessageThread.MessageInstance.ShowSimpleShard("LAP " + iOnLap + "/" + MissionData.iTotalLap + "", "", 5000);
                                    MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                                }
                            }
                            else
                                MissionData.iList_01[6] = ReturnStuff.CheckPointPro(false, MissionData.MyMissions.RaceXM[MissionData.iMissionVar_01].TheRace, MissionData.iList_01[6]);
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                        }
                        else if (!MissionData.VehTrackin_01.IsOnAllWheels && Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iCashReward += 1;
                            UiDisplay.ttTextBar_02.Text = "$" + ReturnStuff.ShowComs(MissionData.iCashReward, true, false);
                        }
                        TheMissions.Racist_PosTime(true);
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        MissionData.iMissionSeq = 99;
                        TheMissions.LoadInteriors(4, false);
                        TheMissions.LoadInMissionIPLs(19, false, false);
                        ObjectHand.SlowFastVehicleTravel(MissionData.vTarget_09, MissionData.fMission_01);
                        TheMissions.RaceEnd(false);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        TheMissions.LoadInteriors(4, false);
                        TheMissions.LoadInMissionIPLs(19, false, false);
                        ObjectHand.SlowFastTravel(MissionData.vTarget_09, MissionData.fMission_01);
                        TheMissions.RaceEnd(true);
                    }
                }       //Bmx Facility
                else
                {
                    if (MissionData.iMissionSeq == 0)
                    {
                        MissionData.iMissionSeq = 1;
                        MissionData.iUltPed01 = 0;
                        MissionData.iMishText = 219;
                        if (DataStore.MySettings.FastTraveltoStart)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                    }
                    else if (MissionData.iMissionSeq == 1)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.95f && !Game.Player.Character.IsInVehicle())
                        {
                            ObjectHand.RemoveTargets();
                            ObjectHand.SlowFastTravel(MissionData.vTarget_02, MissionData.fMission_01);
                            TheMissions.TempAgency_06_AddVehs();
                            ReturnStuff.PedBlimp(MissionData.Npc_01, 0.75f, false, false, 3, DataStore.MyLang.Maptext[95]);
                            MissionData.iMishText = 220;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else if (MissionData.iMissionSeq == 2)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_01.Position) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.Npc_01.CurrentBlip.Remove();
                            TheMissions.TempAgency_06_GoFetch(1);
                            MissionData.iMishText = 224;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 3)
                    {
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_03) < 5.00f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            ObjectHand.RemoveTargets();
                            Game.Player.Character.Task.LeaveVehicle();
                            MissionData.Npc_01.CurrentBlip.Remove();
                            ReturnStuff.PedBlimp(MissionData.Npc_02, 0.75f, false, false, 3, DataStore.MyLang.Maptext[97]);
                            if (MissionData.VehTrackin_01.CurrentBlip.Exists())
                                MissionData.VehTrackin_01.CurrentBlip.Remove();
                            MissionData.iMishText = 221;
                        }
                        else
                        {
                            if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01) || MissionData.VehTrackin_01.IsAttached())
                            {
                                if (MissionData.VehTrackin_01.CurrentBlip.Exists())
                                {
                                    MissionData.VehTrackin_01.CurrentBlip.Remove();
                                    ReturnStuff.PedBlimp(MissionData.Npc_01, 0.75f, false, true, 66, DataStore.MyLang.Maptext[95]);
                                    UiDisplay.TheYellowCorona(MissionData.vTarget_03, 5.00f);
                                    MissionData.iMishText = 225;
                                }
                            }
                            else
                            {
                                if (MissionData.Npc_01.CurrentBlip.Exists())
                                {
                                    ObjectHand.RemoveTargets();
                                    MissionData.Npc_01.CurrentBlip.Remove();
                                    ReturnStuff.VehBlip(MissionData.VehTrackin_01, true, false, 3, MissionData.sMissionVar_01);
                                    MissionData.iMishText = 224;
                                }
                            }

                            if (MissionData.iUltPed01 == 0)
                                ObjectHand.SimpleTracker();
                            else
                                MissionData.iMissionSeq = 45;
                        }
                    }
                    else if (MissionData.iMissionSeq == 4)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_02.Position) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.Npc_02.CurrentBlip.Remove();
                            TheMissions.TempAgency_06_GoFetch(2);
                            MissionData.iMishText = 224;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 5)
                    {
                        if (ReturnStuff.PickupBling(MissionData.Prop_01))
                        {
                            MissionData.iMissionSeq += 1;
                            ObjectHand.RemoveTargets();
                            MissionData.Prop_01 = null;
                            ReturnStuff.PedBlimp(MissionData.Npc_02, 0.75f, false, false, 3, DataStore.MyLang.Maptext[96]);
                            MissionData.iMishText = 226;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 6)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_02.Position) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.Npc_02.CurrentBlip.Remove();
                            ReturnStuff.PedBlimp(MissionData.Npc_03, 0.75f, false, false, 3, DataStore.MyLang.Maptext[97]);
                            MissionData.iMishText = 222;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 7)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_03.Position) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.Npc_03.CurrentBlip.Remove();
                            TheMissions.TempAgency_06_GoFetch(3);
                            MissionData.iMishText = 224;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 8)
                    {
                        if (ReturnStuff.PickupBling(MissionData.Prop_02))
                        {
                            MissionData.iMissionSeq += 1;
                            ObjectHand.RemoveTargets();
                            MissionData.Prop_02 = null;
                            ReturnStuff.PedBlimp(MissionData.Npc_03, 0.75f, false, false, 66, DataStore.MyLang.Maptext[97]);
                            MissionData.iMishText = 227;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 9)
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_03.Position) < 1.5f && !Game.Player.Character.IsInVehicle())
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.Npc_03.CurrentBlip.Remove();
                            TheMissions.TempAgency_06_PlayerAttacks();
                            MissionData.iMishText = 228;
                        }
                        else if (MissionData.iUltPed01 == 0)
                            ObjectHand.SimpleTracker();
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iMissionSeq == 10)
                    {
                        TheMissions.TempAgency_06_PlayerBrains();
                        if (MissionData.MultiPed.Count == 0)
                            MissionData.iMissionSeq += 1;
                    }
                    else if (MissionData.iMissionSeq == 11)
                    {
                        MissionData.iCashReward = 50000;
                        DataStore.MyLang.Mistext[224] = MissionData.sMissionVar_02;
                        TheMissions.LoadInMissionIPLs(19, false, false);
                        ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                        TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                    }
                    else if (MissionData.iMissionSeq == 45)
                    {
                        if (MissionData.iMissionSeq > 1)
                            ObjectHand.SlowFastTravel(MissionData.vTarget_01, 0.00f);
                        DataStore.MyLang.Mistext[224] = MissionData.sMissionVar_02;
                        TheMissions.LoadInMissionIPLs(19, false, false);
                        TheMissions.GameOver(true, "", false, 0);
                    }
                }       //PPaleto Labs
            }       //TempAgency
            else if (MissionData.iJobType == 29)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    Game.FadeScreenOut(1000);
                    Script.Wait(1001);
                    TheMissions.Parra_Load();
                    MissionData.VehTrackin_01.FreezePosition = false;
                    Game.FadeScreenIn(1000);
                    Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 0);
                    Function.Call(Hash.SET_PED_POPULATION_BUDGET, 0);
                    Function.Call(Hash.SET_FAR_DRAW_VEHICLES, false);

                    MissionData.iTime_01.Add(Game.GameTime + 5000);//timer0

                    MissionData.iMissionSeq += 1;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.iTime_01[0] < Game.GameTime)
                    {
                        Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, MissionData.VehTrackin_01.Handle, 5, false, false);
                        ObjectHand.AddTarget(MissionData.vTarget_01, false, true, MissionData.fCorSize, false, 550, DataStore.MyLang.Maptext[122]);
                        MissionData.iTime_01[0] = Game.GameTime + 500;
                        MissionData.iMissionSeq += 1;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 1750.00f)
                    {
                        MissionData.iMissionSeq += 1;
                        MissionData.iMishText = 234;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[29], 1);

                    if (Game.IsControlPressed(2, GTA.Control.Context))
                    {
                        if (MissionData.iTime_01[0] < Game.GameTime)
                        {
                            MissionData.VehTrackin_01.HasCollision = false;
                            Game.Player.Character.Task.ClearAnimation("amb@code_human_in_bus_passenger_idles@male@sit@base", "base");
                            Game.Player.Character.Detach();
                            Game.Player.Character.FreezePosition = false;
                            MissionData.iTime_01[0] = Game.GameTime + 5000;
                            MissionData.iMishText = 235;
                            MissionData.iMissionSeq += 1;
                        }
                    }
                    else
                        MissionData.iTime_01[0] = Game.GameTime + 500;

                    if (MissionData.iWait4Sec < Game.GameTime)
                        TheMissions.Parra_Jump(true);
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.iTime_01[0] < Game.GameTime)
                    {
                        if (Function.Call<int>(Hash.GET_PED_PARACHUTE_STATE, Game.Player.Character.Handle) == -1)
                        {
                            MissionData.iMissionSeq += 1;
                            MissionData.BeOnOff[1] = true;
                            MissionData.iTime_01.Add(Game.GameTime + MissionData.iMissionVar_01);
                        }
                    }

                    ClearTheWay(true);

                    TheMissions.Parra_Jump(false);
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    if (MissionData.fCorSize > 51)
                    {
                        if (MissionData.iTime_01[1] < Game.GameTime)
                        {
                            if (MissionData.iMissionVar_01 > 5001)
                                MissionData.iMissionVar_01 -= 5000;

                            if (MissionData.fCorSize < 1000)
                            {
                                ObjectHand.RemoveTargets();
                                MissionData.iTime_01[1] = Game.GameTime + MissionData.iMissionVar_01;

                                if (MissionData.iMissionVar_01 < 4999)
                                    MissionData.iMissionVar_01 = 5000;

                                MissionData.fCorSize -= 50;
                                if (MissionData.fCorSize < 50)
                                    MissionData.fCorSize = 50;
                                ObjectHand.AddTarget(MissionData.vTarget_01, false, true, MissionData.fCorSize, false, 550, DataStore.MyLang.Maptext[122]);
                            }
                            else
                            {
                                ObjectHand.RemoveTargets();
                                MissionData.iTime_01[1] = Game.GameTime + MissionData.iMissionVar_01;
                                if (MissionData.iMissionVar_01 > 9999)
                                    MissionData.iMissionVar_01 -= 7500;
                                MissionData.fCorSize -= 500;
                                ObjectHand.AddTarget(MissionData.vTarget_01, false, true, MissionData.fCorSize, false, 550, DataStore.MyLang.Maptext[122]);
                            }
                        }
                        UiDisplay.ttTextBar_01.Text = ReturnStuff.ShowComs(MissionData.iTime_01[1] - Game.GameTime, false, false);
                    }
                    else
                        UiDisplay.ttTextBar_01.Text = "--:--";

                    if (MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < MissionData.fCorSize)
                        {
                            MissionData.BeOnOff[0] = false;
                            ObjectHand.RemoveTargets();
                            ObjectHand.AddTarget(MissionData.vTarget_01, false, true, MissionData.fCorSize, false, 550, DataStore.MyLang.Maptext[122]);
                            MissionData.iMishText = 235;
                        }
                        else if (MissionData.iTime_01[0] < Game.GameTime)
                            MissionData.iMissionSeq = 45;
                    }
                    else
                    {
                        if (!MissionData.BeOnOff[0])
                        {
                            if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) > MissionData.fCorSize)
                            {
                                MissionData.BeOnOff[0] = true;
                                ObjectHand.RemoveTargets();
                                ObjectHand.AddTarget(MissionData.vTarget_01, false, true, MissionData.fCorSize, true, 550, DataStore.MyLang.Maptext[122]);
                                MissionData.iTime_01[0] = Game.GameTime + 10000;
                                MissionData.iMishText = 236;
                            }
                        }
                    }

                    if (MissionData.BeOnOff[1])
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            MissionData.BeOnOff[1] = false;
                            MissionData.BeOnOff[2] = true;
                            ObjectBuild.ArmsRegulator(Game.Player.Character, 5);
                        }
                    }
                    else if (MissionData.BeOnOff[2])
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 35.00f)
                        {
                            MissionData.BeOnOff[2] = false;
                            TheMissions.Parra_CarLocks();
                        }
                    }

                    ClearTheWay(true);

                    TheMissions.Parra_Jump(false);

                    if (!UiDisplay.bUiDisplay)
                        UiDisplay.bUiDisplay = true;

                    if (Game.Player.WantedLevel > 0)
                        Game.Player.WantedLevel = 0;
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    TheMissions.Parra_RemoveShit();
                    ObjectHand.NSCoinInvestments(true, 12, 22, "Epic Shares");
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.GameOver(true, "", false, 0);
                    Game.Player.Character.FreezePosition = false;
                    TheMissions.Parra_RemoveShit();
                }
            }       //ParaDisplay
            else if (MissionData.iJobType == 30)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq += 1;

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);

                    MissionData.iMishText = 229;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_01) < 1.5f)
                    {
                        ObjectHand.RemoveTargets();
                        Game.FadeScreenOut(1000);
                        Script.Wait(1000);

                        if (!MissionData.bDeliverWowRep)
                            DressinRoom.WardrobeScan(2);

                        MissionData.vFuMiss = MissionData.vTarget_03;
                        Game.Player.Character.Heading += 180.00f;
                        Game.FadeScreenIn(1000);
                        ObjectHand.AddTarget(MissionData.vTarget_02, true, true, 1.00f, false, 480, DataStore.MyLang.Maptext[75]);
                        MissionData.iMishText = 230;
                        MissionData.iMissionSeq += 1;
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (Game.Player.Character.Position.DistanceTo(MissionData.vTarget_02) < 75.5f)
                    {
                        MissionData.Npc_01 = ObjectBuild.NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 54)), MissionData.vTarget_02, ReturnStuff.RandInt(0, 359), false, 150, 13, 0, null, 0, false, 0, 0, "");
                        MissionData.iMissionSeq += 1;
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.Npc_01.IsDead || MissionData.Npc_01.IsFleeing)
                        MissionData.iMissionSeq = 45;
                    else if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_01.Position) < 1.50f)
                    {
                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                        MissionData.iMissionSeq += 1;
                        ObjectHand.RemoveTargets();
                        MissionData.iMishText = -1;
                        ObjectHand.ControlSelect(11, false);
                    }
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    MissionData.bDeliverWowRep = false;
                    ObjectBuild.XmlPedDresser(Game.Player.Character, ReadWriteXML.LoadXmlClothDefault(DataStore.sDefaulted));
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //dELIVERWHO
            else if (MissionData.iJobType == 101)
            {
                MissionData.iJobType = 3;
            }       //CayoPackages--Directed to MissionData.iJobType == 3
            else if (MissionData.iJobType == 102)
            {
                if (MissionData.BeOnOff[0])
                {
                    if (World.GetDistance(Game.Player.Character.Position, MissionData.Npc_01.Position) < 60.00f)   // Distance tracking for Spookbar
                    {
                        if (MissionData.iTime_01[1] != 0)
                            MissionData.iTime_01[1] = 0;      //timer for spook fail
                        MissionData.fMission_02 = World.GetDistance(Game.Player.Character.Position, MissionData.Npc_01.Position) / 100.00f;// Find the percent for Spookbar float 0.00 to 1.00
                        MissionData.fMission_02 = 1.00f - MissionData.fMission_02;
                        if (MissionData.fMission_02 < 0.01f)
                            MissionData.fMission_02 = 0.01f;
                        UiDisplay.BtSlideBar.BackgroundColor = Color.Black;
                    }
                    else       // if player is out side min distance
                    {
                        MissionData.fMission_02 = 0.00f;
                        if (MissionData.iTime_01[1] == 0) // set timmer for distance fail
                            MissionData.iTime_01[1] = Game.GameTime + 6000;
                        else if (MissionData.iTime_01[1] < Game.GameTime) // fail if timmer runs out
                            MissionData.iMissionSeq = 45;
                        if (MissionData.BeOnOff[1]) // bar flash for distance warning. is a 1/2 sec toggle on off.
                        {
                            if (MissionData.iTime_01[2] < Game.GameTime)
                            {
                                MissionData.BeOnOff[1] = false;
                                MissionData.iTime_01[2] = Game.GameTime + 500;
                                UiDisplay.BtSlideBar.BackgroundColor = Color.White;
                            }
                        }
                        else
                        {
                            if (MissionData.iTime_01[2] < Game.GameTime)
                            {
                                MissionData.BeOnOff[1] = true;
                                MissionData.iTime_01[2] = Game.GameTime + 500;
                                UiDisplay.BtSlideBar.BackgroundColor = Color.Black;
                            }
                        }
                    }

                    if (MissionData.fMission_02 > 0.95f)  // test if too close to target
                    {
                        if (!MissionData.BeOnOff[2])
                        {
                            if (MissionData.iTime_01[3] == 0)  // set timmer for too close fail
                                MissionData.iTime_01[3] = Game.GameTime + 6000;
                            else if (MissionData.iTime_01[3] < Game.GameTime)  // too close fail.
                                MissionData.iMissionSeq = 45;

                            if (MissionData.BeOnOff[1]) // bar flash for distance warning. is a 1/2 sec toggle on off.
                            {
                                if (MissionData.iTime_01[4] < Game.GameTime)
                                {
                                    MissionData.BeOnOff[1] = false;
                                    MissionData.iTime_01[4] = Game.GameTime + 500;
                                    UiDisplay.BtSlideBar.ForegroundColor = Color.White;
                                }
                            }
                            else
                            {
                                if (MissionData.iTime_01[4] < Game.GameTime)
                                {
                                    MissionData.BeOnOff[1] = true;
                                    MissionData.iTime_01[4] = Game.GameTime + 500;
                                    UiDisplay.BtSlideBar.ForegroundColor = Color.Red;
                                }
                            }
                        }
                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_02;   // set the native ui Bar to the current distance percent.

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;       //draw the spookbar to screen.
                    }
                    else    //draw the spookbar to screen where the player is at the correct distance.
                    {
                        if (MissionData.iTime_01[3] != 0)
                            MissionData.iTime_01[3] = 0;
                        UiDisplay.BtSlideBar.Percentage = MissionData.fMission_02;
                        UiDisplay.BtSlideBar.ForegroundColor = Color.Yellow;

                        if (!UiDisplay.bUiDisplay)
                            UiDisplay.bUiDisplay = true;
                    }
                }

                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;
                    MissionData.BeOnOff[3] = true;
                    MissionData.iMissionVar_01 = 0;
                    MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                    ObjectHand.AddTarget(MissionData.vTarget_01, true, true, 75.00f, false, 66, DataStore.MyLang.Maptext[26]);
                    MissionData.Npc_01 = ObjectBuild.NPCSpawn("", MissionData.vTarget_01, 0.00f, false, 150, 17, 0, null, 0, false, 0, 1, "");

                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.vTarget_02, 0.00f);
                    MissionData.iMishText = 174;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.Position.DistanceTo(MissionData.vTarget_01) < 2.50f)
                    {
                        MissionData.iMissionVar_01 += 1;
                        if (ReturnStuff.PedRunToFoward(MissionData.Npc_01, MissionData.VectorList_01, MissionData.iMissionVar_01))
                            MissionData.vTarget_01 = MissionData.VectorList_01[MissionData.iMissionVar_01];
                        else
                        {
                            if (!MissionData.BeOnOff[0])
                                MissionData.iMissionSeq = 45;
                            else
                            {
                                MissionData.iMissionSeq = 2;
                                MissionData.iMissionVar_01 = 0;
                                ReturnStuff.PedRunToFoward(MissionData.Npc_01, MissionData.VectorList_02, MissionData.iMissionVar_01);
                                MissionData.vTarget_01 = MissionData.VectorList_02[MissionData.iMissionVar_01];
                            }
                        }
                    }
                    else if (!MissionData.BeOnOff[0])
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.Npc_01.Position) < 55.00f)
                        {
                            MissionData.BeOnOff[0] = true;
                            if (MissionData.BeOnOff[3])
                                ObjectHand.RemoveTargets();
                            ObjectBuild.Hitman_AddVisionCones(MissionData.Npc_01);
                            MissionData.iMishText = 175;
                        }
                        else if (MissionData.BeOnOff[3])
                        {
                            if (MissionData.Npc_01.Position.DistanceTo(MissionData.VectorList_01[0]) > 75.00f)
                            {
                                MissionData.BeOnOff[3] = false;
                                ObjectHand.RemoveTargets();
                            }
                        }
                    }
                    else if (ReturnStuff.BeenSpotted(MissionData.Npc_01, Game.Player.Character, true))
                        MissionData.iMissionSeq = 45;
                    if (MissionData.iWait4Sec < Game.GameTime)
                        KeepMoving(MissionData.Npc_01, MissionData.vTarget_01, 2500);
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_01.Position.DistanceTo(MissionData.vTarget_01) < 2.50f)
                    {
                        MissionData.iMissionVar_01 += 1;
                        if (ReturnStuff.PedRunToFoward(MissionData.Npc_01, MissionData.VectorList_02, MissionData.iMissionVar_01))
                            MissionData.vTarget_01 = MissionData.VectorList_02[MissionData.iMissionVar_01];
                        else
                        {
                            MissionData.BeOnOff[0] = false;
                            ObjectBuild.PedScenario(MissionData.Npc_01, "WORLD_HUMAN_MOBILE_FILM_SHOCKING", MissionData.Npc_01.Position, MissionData.fMission_01, false);
                            MissionData.iWait4Sec = Game.GameTime + 15000;
                            MissionData.iMissionSeq = 3;
                        }
                    }
                    else if (ReturnStuff.BeenSpotted(MissionData.Npc_01, Game.Player.Character, true))
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iWait4Sec < Game.GameTime)
                        KeepMoving(MissionData.Npc_01, MissionData.vTarget_01, 2500);
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    if (MissionData.Npc_01.IsDead)
                    {
                        if (MissionData.Npc_01.WasKilledByStealth)
                            MissionData.iMissionSeq = 4;
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.Npc_01.Task.FleeFrom(Game.Player.Character);
                        MissionData.iMissionSeq = 45;
                    }
                    if (Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Game.Player.Character.Handle))
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[19], 1);
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[20], 1);
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    MissionData.Npc_01.CanRagdoll = false;
                    TheMissions.Hitman_RemoveVisionCones();
                    ObjectHand.SlowFastTravel(MissionData.VectorList_03[0], MissionData.fList_01[0]);
                    MissionData.Npc_01.CanRagdoll = true;
                    MissionData.Npc_01.Position = MissionData.vTarget_05;
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    TheMissions.Hitman_RemoveVisionCones();
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //CayoFollow
            else if (MissionData.iJobType == 103)
            {
                MissionData.iJobType = 11;
            }       //CayoRace--Directed to MissionData.iJobType == 11
            else if (MissionData.iJobType == 104)
            {
                MissionData.iJobType = 13;
            }       //Assassination--Directed to MissionData.iJobType == 13
            else if (MissionData.iJobType == 105)
            {
                if (MissionData.iMissionSeq == 0)
                {
                    MissionData.iMissionSeq = 1;

                    if (DataStore.bNotPause)
                    {
                        Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
                        DataStore.bNotPause = false;
                    }

                    if (DataStore.MySettings.FastTraveltoStart)
                        ObjectHand.SlowFastTravel(MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.RightVector * 3.00f), 0.00f);
                    MissionData.iMishText = 26;
                }
                else if (MissionData.iMissionSeq == 1)
                {
                    if (MissionData.Npc_01.IsDead)
                        MissionData.iMissionSeq = 45;
                    else if (!Game.Player.Character.IsInVehicle())
                    {
                        if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 60.00f)
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.Context[27], 1);
                            MissionData.iMishText = 27;
                            if (Game.Player.Character.Position.DistanceTo(MissionData.VehTrackin_01.Position) < 10.00f && Game.IsControlPressed(2, GTA.Control.VehicleExit))
                            {
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 3);
                                if (MissionData.iMissionVar_02 == 1)
                                    ObjectBuild.VehicleSpawn("DINGHY", new Vector3(4957.126f, -5163.97f, 0.5030198f), 69.74284f, true, false, false, false, 9, 0, 0, "", 2, false);
                                else if (MissionData.iMissionVar_02 == 2)
                                    ObjectBuild.VehicleSpawn("DINGHY", new Vector3(5090.056f, -4638.275f, 0.1183856f), 248.4615f, true, false, false, false, 9, 0, 0, "", 2, false);
                                else
                                    ObjectBuild.VehicleSpawn("VELUM", new Vector3(4479.589f, -4496.729f, 5.124825f), 110.8173f, true, true, false, false, 0, 0, 0, "", 2, false);
                                MissionData.iMissionVar_02 = 0;
                            }
                        }
                        else
                            MissionData.iMishText = 26;
                    }
                    else
                    {
                        if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                        {
                            MissionData.iMissionSeq = 2;
                            MissionData.VehTrackin_01.FreezePosition = false;
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 = 0;
                            ObjectHand.AddTarget(MissionData.VehTrackin_02.Position, false, false, 75.00f, false, 66, DataStore.MyLang.Maptext[26]);
                            FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, MissionData.vTarget_01, 45.00f, MissionData.fphdirect);
                            MissionData.iMishText = -1;
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 2)
                {
                    if (MissionData.Npc_01.IsDead || !Game.Player.Character.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.vTarget_01) < 5.00f)
                    {
                        MissionData.iMissionSeq = 3;
                        FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, MissionData.VectorList_01[MissionData.iMissionVar_01], 85.00f, MissionData.fList_01[MissionData.iMissionVar_01]);
                        MissionData.Npc_02 = ObjectBuild.NPCSpawn("", MissionData.VectorList_02[MissionData.iMissionVar_02], 0.00f, false, 500, 17, 0, null, 4, false, 0, 1, "");
                        MissionData.iMissionVar_02 += 1;
                        MissionData.Npc_02.RelationshipGroup = DataStore.GP_BNPCs;
                        ReturnStuff.PedRunToFoward(MissionData.Npc_02, MissionData.VectorList_02, MissionData.iMissionVar_02);

                        UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.ChevronUpx1, MarkPos = Vector3.Zero, MarkDir = Vector3.Zero, MarkRot = Vector3.Zero, MarkScale = new Vector3(0.50f, 0.50f, 0.50f), MarkCol = Color.Red };
                        UiDisplay.bMMDisplay01 = true;

                        MissionData.vTarget_03 = MissionData.VectorList_02[MissionData.iMissionVar_02];
                        MissionData.iMishText = MissionData.iList_01[0];
                    }
                }
                else if (MissionData.iMissionSeq == 3)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.Npc_02.Position.X, MissionData.Npc_02.Position.Y, MissionData.Npc_02.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, MissionData.Npc_02.Heading, 0.00f);

                    if (MissionData.Npc_01.IsDead || !Game.Player.Character.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_02.IsDead)
                        MissionData.iMissionSeq = 10;
                    else if (MissionData.Npc_02.Position.DistanceTo(MissionData.vTarget_03) < 3.00f)
                    {
                        MissionData.iMissionVar_02 += 1;
                        if (ReturnStuff.PedRunToFoward(MissionData.Npc_02, MissionData.VectorList_02, MissionData.iMissionVar_02))
                            MissionData.vTarget_03 = MissionData.VectorList_02[MissionData.iMissionVar_02];
                        else
                        {
                            MissionData.iMissionSeq = 4;
                            MissionData.Npc_02.Task.ClearAll();
                            MissionData.VehTrackin_02.FreezePosition = false;
                            MissionData.VehTrackin_02.IsInvincible = false;
                            ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_02, MissionData.Npc_02, 1);
                            Script.Wait(500);
                        }
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                        KeepMoving(MissionData.Npc_02, MissionData.vTarget_03, 2500);

                    if (MissionData.iMissionVar_01 + 1 < MissionData.VectorList_01.Count)
                    {
                        if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.VectorList_01[MissionData.iMissionVar_01]) < 10.00f)
                        {
                            MissionData.iMissionVar_01 += 1;
                            FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, MissionData.VectorList_01[MissionData.iMissionVar_01], 65.00f, MissionData.fList_01[MissionData.iMissionVar_01]);
                        }
                    }
                    else
                    {
                        if (MissionData.iTime_01[0] < Game.GameTime)
                        {
                            MissionData.iTime_01[0] = Game.GameTime + 1000;

                            Vector3 VHereIsh = MissionData.Npc_02.Position - (MissionData.Npc_02.ForwardVector * 25.00f) + (MissionData.Npc_02.RightVector * 25.00f);
                            VHereIsh.Z += 35.00f;
                            FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, VHereIsh, 45.00f, MissionData.Npc_02.Heading);
                        }
                    }
                }
                else if (MissionData.iMissionSeq == 4)
                {
                    if (MissionData.Npc_01.IsDead || !Game.Player.Character.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_02.IsDead)
                        MissionData.iMissionSeq = 10;
                    else if (MissionData.Npc_02.IsInVehicle(MissionData.VehTrackin_02))
                    {
                        if (MissionData.bPedCanFly)
                        {
                            MissionData.iMissionSeq = 6;
                            UiDisplay.MMDisplay01.MarkRot = new Vector3(1.50f, 1.50f, 1.50f);
                            ObjectBuild.ImOnAPlane(MissionData.Npc_02, MissionData.VehTrackin_02, MissionData.vTarget_02);
                            MissionData.iWait4Sec = Game.GameTime + 4000;
                        }
                        else
                        {
                            MissionData.iMissionVar_02 = 0;
                            MissionData.iMissionVar_03 = 0;
                            MissionData.iMissionSeq = 5;
                            MissionData.iWait4Sec = Game.GameTime + 1000;
                            Vector3 VHereIsh = MissionData.VehTrackin_02.Position - (MissionData.VehTrackin_02.ForwardVector * 45) + (MissionData.VehTrackin_02.RightVector * 45);
                            VHereIsh.Z += 35.00f;
                            FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, VHereIsh, 10.00f, MissionData.VehTrackin_02.Heading - 90.00f);
                            Function.Call(Hash.SET_BOAT_ANCHOR, MissionData.VehTrackin_02.Handle, false);
                            ObjectBuild.ShowBoating(MissionData.Npc_02, MissionData.VectorList_03[MissionData.iMissionVar_02], MissionData.VehTrackin_02, 35.00f, 786469);
                        }
                        MissionData.VehTrackin_02.IsInvincible = false;
                    }
                }
                else if (MissionData.iMissionSeq == 5)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_02.Position.X, MissionData.VehTrackin_02.Position.Y, MissionData.VehTrackin_02.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, MissionData.VehTrackin_02.Heading, 0.00f);

                    if (MissionData.Npc_01.IsDead || !Game.Player.Character.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_02.IsDead)
                        MissionData.iMissionSeq = 10;
                    else if (MissionData.VehTrackin_02.Position.DistanceTo(MissionData.VectorList_03[MissionData.iMissionVar_02]) < 3.00f)
                    {
                        MissionData.iMissionVar_02 += 1;
                        if (MissionData.iMissionVar_02 + 1 < MissionData.VectorList_03.Count)
                            ObjectBuild.ShowBoating(MissionData.Npc_02, MissionData.VectorList_03[MissionData.iMissionVar_02], MissionData.VehTrackin_02, 40.00f, 786469);
                        else
                            MissionData.iMissionSeq = 45;
                    }
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iWait4Sec = Game.GameTime + 1000;

                        Vector3 VHereIsh = MissionData.VehTrackin_02.Position - (MissionData.VehTrackin_02.ForwardVector * 25.00f) + (MissionData.VehTrackin_02.RightVector * 25.00f);
                        VHereIsh.Z += 25.00f;
                        FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, VHereIsh, 10.00f, MissionData.VehTrackin_02.Heading);

                        if (MissionData.iMissionVar_03 > 10)
                        {
                            MissionData.iMissionVar_03 = 0;
                            MissionData.VehTrackin_02.Position = MissionData.VectorList_03[MissionData.iMissionVar_02];
                            MissionData.VehTrackin_02.Heading = MissionData.fList_02[MissionData.iMissionVar_02];
                        }
                        else
                        {
                            if (MissionData.VehTrackin_02.Position.DistanceTo(MissionData.vGetaway) < 2.00f)
                            {
                                MissionData.iMissionVar_03 += 1;
                                MissionData.VehTrackin_02.Position = MissionData.VehTrackin_02.Position + (MissionData.VehTrackin_02.ForwardVector * 2.50f);
                                MissionData.VehTrackin_02.Heading = MissionData.fList_02[MissionData.iMissionVar_02];
                                ObjectBuild.ShowBoating(MissionData.Npc_02, MissionData.VectorList_03[MissionData.iMissionVar_02], MissionData.VehTrackin_02, 40.00f, 786469);
                            }
                        }

                        MissionData.vGetaway = MissionData.VehTrackin_02.Position;
                    }
                }
                else if (MissionData.iMissionSeq == 6)
                {
                    UiDisplay.MMDisplay01.MarkPos = new Vector3(MissionData.VehTrackin_02.Position.X, MissionData.VehTrackin_02.Position.Y, MissionData.VehTrackin_02.Position.Z + 2.00f);
                    UiDisplay.MMDisplay01.MarkRot = new Vector3(0.00f, MissionData.VehTrackin_02.Heading, 0.00f);

                    if (MissionData.Npc_01.IsDead || !Game.Player.Character.IsInVehicle())
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.Npc_02.IsDead)
                        MissionData.iMissionSeq = 10;
                    else if (MissionData.VehTrackin_02.Position.DistanceTo(MissionData.VectorList_02[0]) > 700.00f)
                        MissionData.iMissionSeq = 45;
                    else if (MissionData.iWait4Sec < Game.GameTime)
                    {
                        MissionData.iWait4Sec = Game.GameTime + 10000;
                        Vector3 VHereIsh = MissionData.VehTrackin_02.Position - (MissionData.VehTrackin_02.ForwardVector * 45) + (MissionData.VehTrackin_02.RightVector * 45);
                        VHereIsh.Z += 10.00f;
                        FlyToRightHere(MissionData.Npc_01, MissionData.VehTrackin_01, VHereIsh, 40.00f, MissionData.VehTrackin_02.Heading - 90.00f);
                    }
                }
                else if (MissionData.iMissionSeq == 10)
                {
                    MissionData.VehTrackin_01.IsInvincible = false;
                    ObjectHand.SlowFastTravel(new Vector3(4905.202f, -4939.065f, 3.352461f), 201.3084f);
                    ObjectHand.NSCoinInvestments(false, 4, 9, "Vangelico");
                    MissionData.iCashReward = ReturnStuff.RandInt(50000, 100000);
                    TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                }
                else if (MissionData.iMissionSeq == 45)
                {
                    ObjectHand.SlowFastTravel(new Vector3(4594.872f, -4880.987f, 18.10277f), 6.152281f);
                    MissionData.VehTrackin_01.IsInvincible = false;
                    ObjectHand.NSCoinInvestments(true, 1, 3, "Vangelico");
                    TheMissions.GameOver(true, "", false, 0);
                }
            }       //ThifeAntiHeist
            else if (MissionData.iJobType == 106)
            {
                MissionData.iJobType = 29;
            }       //pero ppparra to MissionData.iJobType == 29

            if (MissionData.iMishText == -1)
            {
                if (UiDisplay.bSubDisplay)
                    UiDisplay.bSubDisplay = false;
            }
            else
            {
                if (!UiDisplay.bSubDisplay)
                    UiDisplay.bSubDisplay = true;

                if (MissionData.iMishAltT != MissionData.iMishText)
                {
                    if (MissionData.vLanLoc != Vector3.Zero)
                    {
                        if (DataStore.MySettings.Subtitles)
                            UiDisplay.sSubDisplay = DataStore.MyLang.Mistext[MissionData.iMishText] + "~y~" + World.GetStreetName(MissionData.vLanLoc) + "~w~.";
                        else
                            QuickSub(DataStore.MyLang.Mistext[MissionData.iMishText] + "~y~" + World.GetStreetName(MissionData.vLanLoc) + "~w~.");
                    }
                    else
                    {
                        if (DataStore.MySettings.Subtitles)
                            UiDisplay.sSubDisplay = DataStore.MyLang.Mistext[MissionData.iMishText];
                        else if (MissionData.iMishAltT != MissionData.iMishText)
                            QuickSub(DataStore.MyLang.Mistext[MissionData.iMishText]);
                    }
                    MissionData.iMishAltT = MissionData.iMishText;
                }
            }
        }
        private void BuildingTime()
        {
            if (ReturnStuff.ButtonDown(25))
            {
                if (ReturnStuff.ButtonDown(140))
                    ExitBuilders();
            }

            if (MissionData.iBuildMode == 1)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        TruckBuild Trucky = new TruckBuild();
                        MissionData.MyMissions.TruckersXM.Add(Trucky);

                        MissionData.fList_01.Clear();
                        MissionData.VectorList_01.Clear();
                        MissionData.sList_01.Clear();
                        MissionData.BeOnOff.Clear();
                        MissionData.BeOnOff.Add(false);
                        MissionData.sList_01 = ReturnStuff.BuildMishLists(4);
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);
                        MissionData.sMissionVar_01 = MissionData.sList_01[0];
                        MissionData.MyMissions.TruckersXM[0].LiveryExtra = 0;
                        MissionData.MyMissions.TruckersXM[0].VehLivery = 0;
                        ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.MyMissions.TruckersXM[0].VehVar -= 1;
                            if (MissionData.MyMissions.TruckersXM[0].VehVar < 0)
                                MissionData.MyMissions.TruckersXM[0].VehVar = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.MyMissions.TruckersXM[0].VehVar];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.MyMissions.TruckersXM[0].LiveryExtra = 0;
                            MissionData.MyMissions.TruckersXM[0].VehLivery = 0;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.MyMissions.TruckersXM[0].VehVar += 1;
                            if (MissionData.MyMissions.TruckersXM[0].VehVar > MissionData.sList_01.Count - 1)
                                MissionData.MyMissions.TruckersXM[0].VehVar = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.MyMissions.TruckersXM[0].VehVar];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.MyMissions.TruckersXM[0].LiveryExtra = 0;
                            MissionData.MyMissions.TruckersXM[0].VehLivery = 0;
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            if (MissionData.MyMissions.TruckersXM[0].VehVar == 0)
                            {
                                MissionData.MyMissions.TruckersXM[0].LiveryExtra = 1;
                                MissionData.MyMissions.TruckersXM[0].VehLivery = 2;

                                ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 1, 2, false);
                            }
                            else
                            {
                                int iCounter = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, MissionData.VehTrackin_01.Handle);
                                if (iCounter != -1)
                                {
                                    MissionData.MyMissions.TruckersXM[0].LiveryExtra = 5;
                                    if (MissionData.MyMissions.TruckersXM[0].VehLivery < iCounter)
                                        MissionData.MyMissions.TruckersXM[0].VehLivery += 1;
                                    else
                                        MissionData.MyMissions.TruckersXM[0].VehLivery = 0;
                                    ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 5, MissionData.MyMissions.TruckersXM[0].VehLivery, false);
                                }
                                else
                                    MissionData.MyMissions.TruckersXM[0].LiveryExtra = 0;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {
                            if (MissionData.MyMissions.TruckersXM[0].VehVar == 0)
                            {
                                MissionData.MyMissions.TruckersXM[0].LiveryExtra = 1;
                                MissionData.MyMissions.TruckersXM[0].VehLivery = 1;

                                ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 1, 1, false);
                            }
                            else
                            {
                                int iCounter = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, MissionData.VehTrackin_01.Handle);
                                if (iCounter != -1)
                                {
                                    MissionData.MyMissions.TruckersXM[0].LiveryExtra = 5;
                                    if (MissionData.MyMissions.TruckersXM[0].VehLivery > 0)
                                        MissionData.MyMissions.TruckersXM[0].VehLivery -= 1;
                                    else
                                        MissionData.MyMissions.TruckersXM[0].VehLivery = iCounter;
                                    ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 5, MissionData.MyMissions.TruckersXM[0].VehLivery, false);
                                }
                                else
                                    MissionData.MyMissions.TruckersXM[0].LiveryExtra = 0;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            if (MissionData.MyMissions.TruckersXM[0].VehVar == 0)
                                MissionData.fphdirect = 5.00f;
                            else if (MissionData.MyMissions.TruckersXM[0].VehVar == 1 || MissionData.MyMissions.TruckersXM[0].VehVar == 3)
                                MissionData.fphdirect = 4.00f;
                            else if (MissionData.MyMissions.TruckersXM[0].VehVar == 2)
                                MissionData.fphdirect = 3.50f;
                            else if (MissionData.MyMissions.TruckersXM[0].VehVar == 7 || MissionData.MyMissions.TruckersXM[0].VehVar == 8)
                                MissionData.fphdirect = 4.00f;
                            else
                                MissionData.fphdirect = 2.50f;
                            MissionData.MyMissions.TruckersXM[0].TruckinTrail = MissionData.sMissionVar_01;
                            UiDisplay.HelperBarBuiler(2, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            UiDisplay.CloseBaseHelpBar();
                            DataStore.iBuildingUp -= 1;
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (Game.Player.Character.FreezePosition)
                        Game.Player.Character.FreezePosition = false;

                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01.Clear();
                            DataStore.iBuildingUp += 1;
                            if (MissionData.MyMissions.TruckersXM[0].VehVar == 0 || MissionData.MyMissions.TruckersXM[0].VehVar == 1)
                                MissionData.sList_01 = ReturnStuff.BuildMishLists(1);
                            else if (MissionData.MyMissions.TruckersXM[0].VehVar == 2 || MissionData.MyMissions.TruckersXM[0].VehVar == 3)
                                MissionData.sList_01 = ReturnStuff.BuildMishLists(3);
                            else
                                MissionData.sList_01 = ReturnStuff.BuildMishLists(2);
                            MissionData.VehTrackin_01.FreezePosition = true;
                            MissionData.MyMissions.TruckersXM[0].TruckinStart01 = MissionData.vGetaway;
                            MissionData.MyMissions.TruckersXM[0].TruckinDir01 = MissionData.fGetDir;
                            TheMissions.WhereAreYou();
                            MissionData.MyMissions.TruckersXM[0].Local = MissionData.iLocationX;
                            MissionData.MyMissions.TruckersXM[0].FubarStop = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                            ObjectBuild.VehicleSpawn(MissionData.sList_01[0], Game.Player.Character.Position, Game.Player.Character.Heading, true, false, false, false, 18, 0, 1, DataStore.MyLang.Maptext[22], 2, false);
                            UiDisplay.HelperBarBuiler(3, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(1, true);
                        }
                        else
                        {
                            if (ReturnStuff.ButtonDown(47))
                                MissionData.fGetDir -= 1.00f;
                            else if (ReturnStuff.ButtonDown(51))
                                MissionData.fGetDir += 1.00f;
                            else if (ReturnStuff.ButtonDown(34))
                                MissionData.vGetaway = MissionData.VehTrackin_01.Position - (MissionData.VehTrackin_01.RightVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(35))
                                MissionData.vGetaway = MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.RightVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(32))
                                MissionData.vGetaway = MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.ForwardVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(33))
                                MissionData.vGetaway = MissionData.VehTrackin_01.Position - (MissionData.VehTrackin_01.ForwardVector * 0.10f);
                            else if (MissionData.VehTrackin_01.Position.DistanceTo(Game.Player.Character.Position) > 75.00f)
                                MissionData.vGetaway = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);

                            if (!Game.Player.Character.FreezePosition)
                                Game.Player.Character.FreezePosition = true;

                            float fGround = World.GetGroundHeight(new Vector2(MissionData.vGetaway.X, MissionData.vGetaway.Y));
                            MissionData.VehTrackin_01.Position = new Vector3(MissionData.vGetaway.X, MissionData.vGetaway.Y, fGround + MissionData.fphdirect);
                            MissionData.VehTrackin_01.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                        }
                    }
                    else
                    {
                        MissionData.fGetDir = MissionData.VehTrackin_01.Heading;
                        MissionData.vGetaway = MissionData.VehTrackin_01.Position;
                    }

                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            DataStore.iBuildingUp += 1;
                            MissionData.MyMissions.TruckersXM[0].TruckinStart02 = MissionData.VehTrackin_02.Position;
                            MissionData.MyMissions.TruckersXM[0].TruckinDir02 = MissionData.VehTrackin_02.Heading;
                            UiDisplay.CloseBaseHelpBar();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(4);
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_02);
                            MissionData.VehTrackin_02.Delete();
                            MissionData.VehTrackin_01.FreezePosition = false;
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(2, true);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[11], 1);
                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);

                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);
                        ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 3, false);
                        DataStore.iBuildingUp += 1;
                        UiDisplay.HelperBarBuiler(2, false);
                    }
                    else if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.BeOnOff[0])
                            {
                                UiDisplay.HelperBarBuiler(4, false);
                                DataStore.iBuildingUp = 6;
                            }
                            else
                            {
                                UiDisplay.HelperBarBuiler(3, false);
                                DataStore.iBuildingUp -= 1;
                            }
                        }
                    }

                }
                else if (DataStore.iBuildingUp == 5)
                {
                    if (Game.Player.Character.FreezePosition)
                        Game.Player.Character.FreezePosition = false;

                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.VehTrackin_03.FreezePosition = true;
                            MissionData.fList_01.Add(MissionData.fGetDir);
                            MissionData.VectorList_01.Add(MissionData.vGetaway);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_03);
                            MissionData.VehTrackin_03.Delete();
                            Game.Player.Character.FreezePosition = false;
                            DataStore.iBuildingUp += 1;
                            UiDisplay.HelperBarBuiler(4, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.VehTrackin_03.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_03);
                            Game.Player.Character.FreezePosition = false;
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.CloseBaseHelpBar();
                        }
                        else
                        {
                            if (ReturnStuff.ButtonDown(47))
                                MissionData.fGetDir -= 1.00f;
                            else if (ReturnStuff.ButtonDown(51))
                                MissionData.fGetDir += 1.00f;
                            else if (ReturnStuff.ButtonDown(34))
                                MissionData.vGetaway = MissionData.VehTrackin_03.Position - (MissionData.VehTrackin_03.RightVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(35))
                                MissionData.vGetaway = MissionData.VehTrackin_03.Position + (MissionData.VehTrackin_03.RightVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(32))
                                MissionData.vGetaway = MissionData.VehTrackin_03.Position + (MissionData.VehTrackin_03.ForwardVector * 0.10f);
                            else if (ReturnStuff.ButtonDown(33))
                                MissionData.vGetaway = MissionData.VehTrackin_03.Position - (MissionData.VehTrackin_03.ForwardVector * 0.10f);
                            else if (MissionData.VehTrackin_03.Position.DistanceTo(Game.Player.Character.Position) > 75.00f)
                                MissionData.vGetaway = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);

                            if (!Game.Player.Character.FreezePosition)
                                Game.Player.Character.FreezePosition = true;

                            float fGround = World.GetGroundHeight(new Vector2(MissionData.vGetaway.X, MissionData.vGetaway.Y));
                            MissionData.VehTrackin_03.Position = new Vector3(MissionData.vGetaway.X, MissionData.vGetaway.Y, fGround + MissionData.fphdirect);
                            MissionData.VehTrackin_03.Rotation = new Vector3(0.00f, 0.00f, MissionData.fGetDir);
                        }
                    }
                    else
                    {
                        MissionData.fGetDir = MissionData.VehTrackin_03.Heading;
                        MissionData.vGetaway = MissionData.VehTrackin_03.Position;
                    }
                }
                else if (DataStore.iBuildingUp == 6)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.BeOnOff[0] = true;
                            DataStore.iBuildingUp = 4;
                            UiDisplay.CloseBaseHelpBar();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.VectorList_01.RemoveAt(MissionData.VectorList_01.Count - 1);
                            MissionData.fList_01.RemoveAt(MissionData.fList_01.Count - 1);
                            MissionData.BeOnOff[0] = true;
                            DataStore.iBuildingUp = 4;
                            UiDisplay.CloseBaseHelpBar();
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            DataStore.iBuildingUp += 1;
                            MissionData.MyMissions.TruckersXM[0].TruckinDir03 = new List<float>(MissionData.fList_01);
                            MissionData.MyMissions.TruckersXM[0].TruckinEnd = new List<Vector3>(MissionData.VectorList_01);
                            LaunchTest();
                            TheMissions.Truckin();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 7)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.TruckersXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 7;
                            LaunchTest();
                            TheMissions.Truckin();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.TruckersXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }            //Trucking
            else if (MissionData.iBuildMode == 2)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        MissionData.MyMissions.PackersXM.Clear();
                        PackBuild Packy = new PackBuild();
                        MissionData.MyMissions.PackersXM.Add(Packy);

                        MissionData.sList_01.Clear();
                        MissionData.sList_01 = ReturnStuff.BuildMishLists(5);
                        MissionData.iMissionVar_01 = 0;
                        MissionData.fMission_01 = 0.00f;
                        MissionData.VectorList_01.Clear();
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.sMissionVar_01 = MissionData.sList_01[0];
                        MissionData.MyMissions.PackersXM[0].Livery = -1;
                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);
                        ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 10);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.MyMissions.PackersXM[0].Livery = -1;
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 17, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            int iCounter = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, MissionData.VehTrackin_01.Handle);
                            if (iCounter != -1)
                            {
                                if (MissionData.MyMissions.PackersXM[0].Livery < iCounter)
                                    MissionData.MyMissions.PackersXM[0].Livery += 1;
                                else
                                    MissionData.MyMissions.PackersXM[0].Livery = -1;
                                ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 5, MissionData.MyMissions.PackersXM[0].Livery, false);
                            }
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {
                            int iCounter = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, MissionData.VehTrackin_01.Handle);
                            if (iCounter != -1)
                            {
                                if (MissionData.MyMissions.PackersXM[0].Livery > 0)
                                    MissionData.MyMissions.PackersXM[0].Livery -= 1;
                                else
                                    MissionData.MyMissions.PackersXM[0].Livery = iCounter;
                                ObjectBuild.VehicleMods(MissionData.VehTrackin_01, 5, MissionData.MyMissions.PackersXM[0].Livery, false);
                            }
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            UiDisplay.HelperBarBuiler(3, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            UiDisplay.CloseBaseHelpBar();
                            DataStore.iBuildingUp -= 1;
                            MissionData.MyMissions.PackersXM[0].Livery = -1;
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.MyMissions.PackersXM[0].PackVehType = MissionData.sMissionVar_01;

                            MissionData.sList_01 = ReturnStuff.BuildMishLists(6);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            if (MissionData.iMissionVar_01 == 0)
                                MissionData.fMission_01 = 1.00f;
                            else if (MissionData.iMissionVar_01 == 1)
                                MissionData.fMission_01 = 1.00f;
                            else if (MissionData.iMissionVar_01 == 2)
                                MissionData.fMission_01 = 0.80f;
                            else if (MissionData.iMissionVar_01 == 3)
                                MissionData.fMission_01 = 0.70f;
                            else if (MissionData.iMissionVar_01 == 4)
                                MissionData.fMission_01 = 1.00f;
                            else if (MissionData.iMissionVar_01 == 5)
                                MissionData.fMission_01 = 0.5f;
                            else
                                MissionData.fMission_01 = 1.00f;
                            MissionData.MyMissions.PackersXM[0].PackDropType = MissionData.sMissionVar_01;
                            MissionData.iMissionVar_01 = 0;

                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            DataStore.iBuildingUp += 1;
                            TheMissions.WhereAreYou();
                            MissionData.MyMissions.PackersXM[0].Local = MissionData.iLocationX;
                            MissionData.MyMissions.PackersXM[0].FarstStart = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                            MissionData.MyMissions.PackersXM[0].PackVehStart = MissionData.VehTrackin_01.Position;
                            MissionData.MyMissions.PackersXM[0].PackVehDir = MissionData.VehTrackin_01.Heading;

                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.Delete();
                            MissionData.Prop_01 = ObjectBuild.BuildProp(MissionData.sMissionVar_01, MissionData.vTarget_01, Vector3.Zero, false, false);
                            MissionData.Prop_01.HasCollision = false;
                            UiDisplay.HelperBarBuiler(6, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.Delete();
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(5);
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(1, false);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 2.50f);
                    MissionData.Prop_01.Position = MissionData.vTarget_01;
                    Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, MissionData.Prop_01.Handle);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.VectorList_01.Count == 0)
                            {
                                DataStore.iBuildingUp -= 2;
                                MissionData.Prop_01.Delete();
                                MissionData.PropList_01.Remove(MissionData.Prop_01);
                                MissionData.sList_01 = ReturnStuff.BuildMishLists(5);
                                UiDisplay.HelperBarBuiler(1, true);
                                MissionData.VectorList_01.Clear();
                                ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                                MissionData.BlipList_01.Clear();
                            }
                            else
                            {
                                MissionData.VectorList_01.RemoveAt(MissionData.VectorList_01.Count - 1);
                                MissionData.PropList_01[MissionData.PropList_01.Count - 1].Delete();
                                MissionData.PropList_01.RemoveAt(MissionData.PropList_01.Count - 1);
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            Prop pMark = ObjectBuild.BuildProp(MissionData.sMissionVar_01, MissionData.vTarget_01, Vector3.Zero, true, false);
                            MultiBlimbs(MissionData.vTarget_01, 432, false, "");
                            Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, pMark.Handle);
                            Vector3 VBoxer = new Vector3(pMark.Position.X, pMark.Position.Y, pMark.Position.Z + MissionData.fMission_01);
                            MissionData.VectorList_01.Add(VBoxer);
                            UI.Notify("Drop No == " + MissionData.VectorList_01.Count);
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 0)
                            {
                                DataStore.iBuildingUp += 1;
                                MissionData.MyMissions.PackersXM[0].PackDrops = new List<Vector3>(MissionData.VectorList_01);
                                ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                                MissionData.BlipList_01.Clear();
                                MissionData.Prop_01.Delete();
                                MissionData.PropList_01.Remove(MissionData.Prop_01);
                                LaunchTest();
                                TheMissions.Packages();
                                ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                            }
                            else
                                UI.Notify("No Drops");
                        }
                    }
                    else if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.PackersXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 4;
                            LaunchTest();
                            TheMissions.Packages();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.PackersXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //Packages
            else if (MissionData.iBuildMode == 3)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);
                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        ConsBuild Conny = new ConsBuild();
                        MissionData.MyMissions.ConsXM.Add(Conny);

                        MissionData.VectorList_01.Clear();
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.VectorList_01.Count > 0)
                            {
                                MissionData.VectorList_01.RemoveAt(MissionData.VectorList_01.Count - 1);
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                            else
                            {
                                DataStore.iBuildingUp -= 1;
                                ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                                MissionData.BlipList_01.Clear();
                                UiDisplay.CloseBaseHelpBar();
                                MissionData.VectorList_01.Clear();
                            }
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            MultiBlimbs(Game.Player.Character.Position, 432, false, "");
                            MissionData.VectorList_01.Add(Game.Player.Character.Position);
                            UI.Notify("Stop No == " + MissionData.VectorList_01.Count);
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 1)
                            {
                                TheMissions.WhereAreYou();
                                DataStore.iBuildingUp += 1;
                                MissionData.MyMissions.ConsXM[0].ConMarch = new List<Vector3>(MissionData.VectorList_01);
                                MissionData.MyMissions.ConsXM[0].Local = MissionData.iLocationX;
                                LaunchTest();
                                TheMissions.Convicts();
                                ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                            }
                            else
                                UI.Notify("No Drops");
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.iBuildMode = 99;
                            MissionData.MyMissions.ConsXM.Clear();
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 2;
                            LaunchTest();
                            TheMissions.Convicts();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.iBuildMode = 99;
                            MissionData.MyMissions.ConsXM.Clear();
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //Convicts
            else if (MissionData.iBuildMode == 4)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    ObjectBuild.VehicleSpawn("Dilettante", World.GetNextPositionOnStreet(Game.Player.Character.Position), 90.00f, true, false, false, true, 2, 11, 1, DataStore.MyLang.Maptext[22], 1, true);
                    ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                    UiDisplay.HelperBarBuiler(1, false);
                    DataStore.iBuildingUp += 1;
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                MissionData.vTarget_01 = MissionData.VehTrackin_01.Position;
                                MultiBlimbs(MissionData.vTarget_01, 432, false, "");
                                ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                                UiDisplay.HelperBarBuiler(2, true);
                                DataStore.iBuildingUp += 1;
                            }
                        }
                        else if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                            PlayerWarpToWaypoint(World.GetWaypointPosition(), true);

                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[12], 1);
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (!Game.Player.Character.IsInVehicle())
                    {
                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                TheMissions.WhereAreYou();
                                FuberBuild Fubyar = new FuberBuild
                                {
                                    Local = MissionData.iLocationX,
                                    FUbarCar = MissionData.vTarget_01,
                                    FUbarPed = Game.Player.Character.Position
                                };
                                MissionData.MyMissions.FubardXM.Add(Fubyar);
                                MultiBlimbs(MissionData.vTarget_01, 432, false, "");
                                UiDisplay.HelperBarBuiler(3, true);
                                DataStore.iBuildingUp += 1;
                            }
                        }
                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[13], 1);
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp = 1;
                            UiDisplay.HelperBarBuiler(1, true);
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.iTestKit = 0;
                            DataStore.iBuildingUp += 1;
                            LaunchTest();
                            TheMissions.FUber();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.FubardXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            MissionData.bMoreFubar = false;
                            DataStore.iBuildingUp = 4;
                            MissionData.iTestKit = 0;
                            LaunchTest();
                            TheMissions.FUber();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.FubardXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //FUber
            else if (MissionData.iBuildMode == 5)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    DataStore.iBuildingUp += 1;
                    UiDisplay.HelperBarBuiler(1, false);
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            TheMissions.WhereAreYou();
                            AmbBuild Ambuly = new AmbBuild
                            {
                                Local = MissionData.iLocationX,
                                AmbPed = Game.Player.Character.Position
                            };
                            MultiBlimbs(Game.Player.Character.Position, 432, false, "");
                            MissionData.MyMissions.AmbuXM.Add(Ambuly);
                            UI.Notify("Stop No == " + MissionData.MyMissions.AmbuXM.Count);
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.MyMissions.AmbuXM.Count > 0)
                            {
                                DataStore.iBuildingUp += 1;
                                MissionData.iTestKit = 0;
                                LaunchTest();
                                TheMissions.Ambulance();
                            }
                            else
                                UI.Notify("No Drops");
                        }
                    }
                    else if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.AmbuXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }

                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 2;
                            MissionData.iTestKit = 0;
                            LaunchTest();
                            TheMissions.Ambulance();
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.iBuildMode = 99;
                            MissionData.MyMissions.AmbuXM.Clear();
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //Ambulance
            else if (MissionData.iBuildMode == 6)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        MissionData.MyMissions.SharksXM.Clear();
                        DeapBuild Deepy = new DeapBuild();
                        MissionData.MyMissions.SharksXM.Add(Deepy);
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    if (Game.Player.Character.IsInWater)
                    {
                        ObjectBuild.VehicleSpawn("SUBMERSIBLE2", Game.Player.Character.Position, 90.00f, true, false, false, false, 18, 0, 1, DataStore.MyLang.Maptext[22], 1, false);
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                    else
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                        if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                            PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                        if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                            PlayerWarpToWaypoint(World.GetWaypointPosition(), true);

                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                TheMissions.WhereAreYou();
                                MissionData.MyMissions.SharksXM[0].StartPoint = MissionData.VehTrackin_01.Position;
                                MissionData.MyMissions.SharksXM[0].Local = MissionData.iLocationX;
                                MultiBlimbs(MissionData.VehTrackin_01.Position, 432, false, "");
                                UiDisplay.HelperBarBuiler(2, false);
                                DataStore.iBuildingUp += 1;
                            }
                        }
                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[12], 1);
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                        if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                            PlayerWarpToWaypoint(World.GetWaypointPosition(), true);

                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                TheMissions.WhereAreYou();
                                MissionData.MyMissions.SharksXM[0].SubSpawn = MissionData.VehTrackin_01.Position;
                                MissionData.MyMissions.SharksXM[0].SubHead = MissionData.VehTrackin_01.Heading;
                                MissionData.MyMissions.SharksXM[0].FubStop = World.GetNextPositionOnStreet(MissionData.VehTrackin_01.Position);
                                ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                                MissionData.VehTrackin_01.Delete();
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                DataStore.iBuildingUp += 1;

                                LaunchTest();
                                TheMissions.DeepDown();
                                ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                            }
                        }
                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[12], 1);
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.SharksXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 4;
                            LaunchTest();
                            TheMissions.DeepDown();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.SharksXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //Sharks
            else if (MissionData.iBuildMode == 7)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        MissionData.iMissionVar_01 = 0;
                        MissionData.iMissionVar_02 = 0;
                        MissionData.sList_01.Clear();
                        MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, 1, false);
                        MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];

                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);

                        ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);

                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 > 13 && MissionData.iMissionVar_02 < 18)
                                MissionData.iMissionVar_02 = 18;
                            else if (MissionData.iMissionVar_02 > 19)
                                MissionData.iMissionVar_02 = 0;
                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, 1, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 -= 1;
                            if (MissionData.iMissionVar_02 > 13 && MissionData.iMissionVar_02 < 18)
                                MissionData.iMissionVar_02 = 13;
                            else if (MissionData.iMissionVar_02 < 0)
                                MissionData.iMissionVar_02 = 19;
                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, 1, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            UiDisplay.HelperBarBuiler(2, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            UiDisplay.CloseBaseHelpBar();
                            DataStore.iBuildingUp -= 1;
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            TheMissions.WhereAreYou();
                            JohnnyBuild John = new JohnnyBuild
                            {
                                JohnnyCar = MissionData.sMissionVar_01,
                                JohnnyStart = MissionData.VehTrackin_01.Position,
                                JohnnyHeads = MissionData.VehTrackin_01.Heading,
                                FubarStop = World.GetNextPositionOnStreet(MissionData.VehTrackin_01.Position),
                                Local = MissionData.iLocationX
                            };
                            MissionData.MyMissions.JohnsXM.Add(John);
                            MultiBlimbs(MissionData.VehTrackin_01.Position, 432, false, "");
                            DataStore.iBuildingUp += 1;
                            UiDisplay.HelperBarBuiler(2, true);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.Delete();
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(1, false);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                if (MissionData.VehTrackin_01.Position.DistanceTo(MissionData.MyMissions.JohnsXM[0].JohnnyStart) < 50.00f)
                                    UI.Notify(DataStore.MyLang.Othertext[147]);
                                else
                                {
                                    MissionData.MyMissions.JohnsXM[0].JohnnyPark = MissionData.VehTrackin_01.Position;
                                    ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                                    MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                    MissionData.VehTrackin_01.Delete();
                                    DataStore.iBuildingUp += 1;
                                    LaunchTest();
                                    TheMissions.HeresJohnny();
                                    ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                                }
                            }
                            else if (ReturnStuff.ButtonDown(22))
                            {
                                DataStore.iBuildingUp -= 1;
                                UiDisplay.HelperBarBuiler(2, false);
                                ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                                MissionData.BlipList_01.Clear();
                            }
                        }
                        else if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                            PlayerWarpToWaypoint(World.GetWaypointPosition(), true);
                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[12], 1);
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.JohnsXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 4;
                            LaunchTest();
                            TheMissions.HeresJohnny();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.JohnsXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //Johnny
            else if (MissionData.iBuildMode == 8)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        MissionData.iMissionVar_01 = 0;
                        MissionData.iMissionVar_02 = 0;
                        MissionData.iMissionVar_03 = 1;
                        MissionData.sMissionVar_01 = "~r~Land Vehicles";

                        MissionData.VectorList_01.Clear();
                        MissionData.fList_01.Clear();

                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);

                        UiDisplay.HelperBarBuiler(7, false);

                        UiDisplay.bSubDisplay = true;
                        UiDisplay.sSubDisplay = MissionData.sMissionVar_01;

                        DataStore.iBuildingUp = 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_03 -= 1;
                            if (MissionData.iMissionVar_03 < 1)
                                MissionData.iMissionVar_03 = 4;

                            if (MissionData.iMissionVar_03 == 1)
                                MissionData.sMissionVar_01 = "~r~Land Vehicles";
                            else if (MissionData.iMissionVar_03 == 2)
                                MissionData.sMissionVar_01 = "~g~Bicycle";
                            else if (MissionData.iMissionVar_03 == 3)
                                MissionData.sMissionVar_01 = "~y~Heli";
                            else if (MissionData.iMissionVar_03 == 4)
                                MissionData.sMissionVar_01 = "~b~Boats";
                            UiDisplay.bSubDisplay = false;
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_03 += 1;
                            if (MissionData.iMissionVar_03 > 4)
                                MissionData.iMissionVar_03 = 0;

                            if (MissionData.iMissionVar_03 == 1)
                                MissionData.sMissionVar_01 = "~r~Land Vehicles";
                            else if (MissionData.iMissionVar_03 == 2)
                                MissionData.sMissionVar_01 = "~g~Bicycle";
                            else if (MissionData.iMissionVar_03 == 3)
                                MissionData.sMissionVar_01 = "~y~Heli";
                            else if (MissionData.iMissionVar_03 == 4)
                                MissionData.sMissionVar_01 = "~b~Boats";
                            UiDisplay.bSubDisplay = false;
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                            MissionData.sList_01.Clear();
                            MissionData.sList_02.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);

                            if (MissionData.iMissionVar_03 == 1)
                                DataStore.iBuildingUp = 101;
                            else if (MissionData.iMissionVar_03 == 2)
                                DataStore.iBuildingUp = 102;
                            else if (MissionData.iMissionVar_03 == 3)
                                DataStore.iBuildingUp = 103;
                            else
                                DataStore.iBuildingUp = 104;

                            UiDisplay.HelperBarBuiler(1, true);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.iMissionVar_01 += 1;
                            MissionData.VectorList_01.Add(MissionData.VehTrackin_01.Position);
                            MissionData.fList_01.Add(MissionData.VehTrackin_01.Heading);
                            if (MissionData.iMissionVar_01 == 1)
                            {
                                TheMissions.WhereAreYou();
                                MissionData.vTarget_01 = World.GetNextPositionOnStreet(MissionData.VehTrackin_01.Position);
                                UiDisplay.HelperBarBuiler(4, true);
                            }
                            else if (MissionData.iMissionVar_01 < 5)
                            {
                                float fSpace = 4.00f;
                                if (MissionData.iMissionVar_03 == 3)
                                    fSpace = 9.50f;
                                UiDisplay.HelperBarBuiler(5, true);
                                MissionData.VehTrackin_01.Position = MissionData.VehTrackin_01.Position + (MissionData.VehTrackin_01.RightVector * fSpace);
                            }
                            else
                            {
                                UiDisplay.MMDisplay01 = new MarkyMark { MarkType = MarkerType.VerticalCylinder, MarkPos = MissionData.vTarget_02, MarkDir = Vector3.Zero, MarkRot = Vector3.Zero, MarkScale = new Vector3(10.00f, 10.00f, 2.00f), MarkCol = Color.Yellow };
                                if (MissionData.iMissionVar_03 == 3)
                                    UiDisplay.MMDisplay01.MarkType = MarkerType.VerticleCircle;
                                UiDisplay.bMMDisplay01 = true;
                                UiDisplay.HelperBarBuiler(6, true);
                                MissionData.VectorList_02.Clear();
                                DataStore.iBuildingUp += 1;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            ObjectBuild.GetOutofVeh(Game.Player.Character, 2);
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01.Delete();
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(1, false);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (Game.Player.Character.IsInVehicle(MissionData.VehTrackin_01))
                    {
                        UiDisplay.MMDisplay01.MarkPos = Game.Player.Character.Position;

                        if (ReturnStuff.ButtonDown(37))
                        {
                            if (ReturnStuff.ButtonDown(21))
                            {
                                MissionData.VectorList_02.Add(MissionData.vTarget_02);
                                MultiBlimbs(MissionData.vTarget_02, 432, false, "");
                            }
                            else if (ReturnStuff.ButtonDown(23))
                            {
                                if (MissionData.VectorList_02.Count > 2)
                                {
                                    RaceBuild Racey = new RaceBuild
                                    {
                                        Local = MissionData.iLocationX,
                                        FubStop = MissionData.vTarget_01,
                                        RaceCars = new List<Vector3>(MissionData.VectorList_01),
                                        RaceHead = new List<float>(MissionData.fList_01),
                                        TheRace = new List<Vector3>(MissionData.VectorList_02),
                                        VehClass = MissionData.iMissionVar_03,
                                        AvalableVeh = new List<string>(MissionData.sList_02)
                                    };

                                    MissionData.MyMissions.RaceXM.Add(Racey);
                                    UiDisplay.bMMDisplay01 = false;
                                    DataStore.iBuildingUp += 1;
                                    MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                    MissionData.VehTrackin_01.Delete();
                                    MissionData.iJobType = 11;
                                    LaunchTest();
                                    TheMissions.Raceist();
                                    ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                                }
                                else
                                    UI.Notify("No Drops");
                            }
                        }
                    }
                    else
                        UiDisplay.ControlerUI(DataStore.MyLang.Context[12], 1);
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.RaceXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 4;
                            MissionData.iJobType = 11;
                            LaunchTest();
                            TheMissions.Raceist();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.RaceXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 101)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 > 19)
                                MissionData.iMissionVar_02 = 0;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {

                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 -= 1;
                            if (MissionData.iMissionVar_02 < 0)
                                MissionData.iMissionVar_02 = 19;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            if (!MissionData.sList_02.Contains(MissionData.sMissionVar_01))
                                MissionData.sList_02.Add(MissionData.sMissionVar_01);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.sList_02.Count > 0)
                            {
                                DataStore.iBuildingUp = 2;
                                MissionData.iMissionVar_01 = 0;
                                MissionData.VectorList_01.Clear();
                                MissionData.fList_01.Clear();
                                MissionData.VehTrackin_01.Delete();
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01 = null;
                                ObjectBuild.VehicleSpawn(MissionData.sList_02[0], MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                                UiDisplay.HelperBarBuiler(3, true);
                            }
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 102)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 > 1)
                                MissionData.iMissionVar_02 = 0;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {

                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 -= 1;
                            if (MissionData.iMissionVar_02 < 0)
                                MissionData.iMissionVar_02 = 1;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            if (!MissionData.sList_02.Contains(MissionData.sMissionVar_01))
                                MissionData.sList_02.Add(MissionData.sMissionVar_01);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.sList_02.Count > 0)
                            {
                                DataStore.iBuildingUp = 2;
                                MissionData.iMissionVar_01 = 0;
                                MissionData.VectorList_01.Clear();
                                MissionData.fList_01.Clear();
                                MissionData.VehTrackin_01.Delete();
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01 = null;
                                ObjectBuild.VehicleSpawn(MissionData.sList_02[0], MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                                UiDisplay.HelperBarBuiler(3, true);
                            }
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 103)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 > 3)
                                MissionData.iMissionVar_02 = 0;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {

                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 -= 1;
                            if (MissionData.iMissionVar_02 < 0)
                                MissionData.iMissionVar_02 = 3;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            if (!MissionData.sList_02.Contains(MissionData.sMissionVar_01))
                                MissionData.sList_02.Add(MissionData.sMissionVar_01);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.sList_02.Count > 0)
                            {
                                DataStore.iBuildingUp = 2;
                                MissionData.iMissionVar_01 = 0;
                                MissionData.VectorList_01.Clear();
                                MissionData.fList_01.Clear();
                                MissionData.VehTrackin_01.Delete();
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01 = null;
                                ObjectBuild.VehicleSpawn(MissionData.sList_02[0], MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                                UiDisplay.HelperBarBuiler(3, true);
                            }
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 104)
                {
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(47))
                        {
                            MissionData.iMissionVar_01 -= 1;
                            if (MissionData.iMissionVar_01 < 0)
                                MissionData.iMissionVar_01 = MissionData.sList_01.Count - 1;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.iMissionVar_01 += 1;
                            if (MissionData.iMissionVar_01 > MissionData.sList_01.Count - 1)
                                MissionData.iMissionVar_01 = 0;

                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(27))
                        {
                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 += 1;
                            if (MissionData.iMissionVar_02 > 2)
                                MissionData.iMissionVar_02 = 0;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(173))
                        {

                            MissionData.iMissionVar_01 = 0;
                            MissionData.iMissionVar_02 -= 1;
                            if (MissionData.iMissionVar_02 < 0)
                                MissionData.iMissionVar_02 = 2;

                            MissionData.sList_01.Clear();
                            MissionData.sList_01 = ReturnStuff.VehicleListX(MissionData.iMissionVar_02, MissionData.iMissionVar_03, false);
                            MissionData.sMissionVar_01 = MissionData.sList_01[MissionData.iMissionVar_01];
                            MissionData.VehTrackin_01.Delete();
                            MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                            MissionData.VehTrackin_01 = null;
                            ObjectBuild.VehicleSpawn(MissionData.sMissionVar_01, MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            if (!MissionData.sList_02.Contains(MissionData.sMissionVar_01))
                                MissionData.sList_02.Add(MissionData.sMissionVar_01);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.sList_02.Count > 0)
                            {
                                DataStore.iBuildingUp = 2;
                                MissionData.iMissionVar_01 = 0;
                                MissionData.VectorList_01.Clear();
                                MissionData.fList_01.Clear();
                                MissionData.VehTrackin_01.Delete();
                                MissionData.VehicleList_01.Remove(MissionData.VehTrackin_01);
                                MissionData.VehTrackin_01 = null;
                                ObjectBuild.VehicleSpawn(MissionData.sList_02[0], MissionData.vTarget_01, 90.00f, true, false, false, false, 0, 0, 1, DataStore.MyLang.Maptext[22], 1, true);
                                ObjectBuild.VehicleWarp(MissionData.VehTrackin_01, Game.Player.Character, 1);
                                UiDisplay.HelperBarBuiler(3, true);
                            }
                        }
                    }
                }
            }       //Raceist
            else if (MissionData.iBuildMode == 9)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);

                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.VectorList_01.Clear();
                        MissionData.VectorList_02.Clear();
                        MissionData.iList_01.Clear();
                        MissionData.fList_01.Clear();
                        MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 5);
                        MissionData.Prop_01 = ObjectBuild.BuildProp("ex_prop_adv_case_sm_flash", MissionData.vTarget_01, Vector3.Zero, false, false);
                        MissionData.Prop_01.HasCollision = false;
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);
                    MissionData.vTarget_01 = Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 2.50f);
                    MissionData.Prop_01.Position = MissionData.vTarget_01;
                    Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, MissionData.Prop_01.Handle);
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            if (MissionData.PropList_01.Count > 1)
                            {
                                MissionData.PropList_01[MissionData.PropList_01.Count - 1].Delete();
                                MissionData.PropList_01.Remove(MissionData.PropList_01[MissionData.PropList_01.Count - 1]);
                                MissionData.VectorList_01.RemoveAt(MissionData.VectorList_01.Count - 1);
                                MissionData.VectorList_02.RemoveAt(MissionData.VectorList_02.Count - 1);
                                MissionData.iList_01.RemoveAt(MissionData.iList_01.Count - 1);
                                MissionData.fList_01.RemoveAt(MissionData.fList_01.Count - 1);
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            TheMissions.WhereAreYou();
                            MissionData.VectorList_02.Add(World.GetNextPositionOnStreet(MissionData.vTarget_01));
                            MissionData.iList_01.Add(MissionData.iLocationX);
                            MissionData.fList_01.Add(MissionData.Prop_01.Heading);
                            Prop bPop = ObjectBuild.BuildProp("ex_prop_adv_case_sm_flash", MissionData.vTarget_01, Vector3.Zero, true, false);
                            MultiBlimbs(MissionData.vTarget_01, 432, false, "");
                            Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, bPop.Handle);
                            MissionData.VectorList_01.Add(bPop.Position);
                            UI.Notify("Drop No == " + MissionData.VectorList_01.Count);
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 0)
                            {
                                for (int i = 0; i < MissionData.VectorList_01.Count(); i++)
                                {
                                    BombBuild Bombastic = new BombBuild
                                    {
                                        Local = MissionData.iList_01[i],
                                        Bomb = MissionData.VectorList_01[i],
                                        Fubstop = MissionData.VectorList_02[i],
                                        Fheader = MissionData.fList_01[i]
                                    };
                                    MissionData.MyMissions.BombXM.Add(Bombastic);
                                }
                                DataStore.iBuildingUp += 1;
                                MissionData.VectorList_01.Clear();
                                MissionData.VectorList_02.Clear();
                                MissionData.iList_01.Clear();
                                MissionData.iTestKit = 0;
                                LaunchTest();
                                TheMissions.BBBomb();
                                ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                            }
                            else
                                UI.Notify("No Drops");
                        }
                    }
                    else if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);

                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.BombXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 2;
                            MissionData.iTestKit = 0;
                            LaunchTest();
                            TheMissions.BBBomb();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.BombXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }       //BBBomb
            else if (MissionData.iBuildMode == 10)
            {
                if (DataStore.iBuildingUp == 0)
                {
                    UiDisplay.ControlerUI(DataStore.MyLang.Context[10], 1);
                    if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                    {
                        HitBuild BigHit = new HitBuild();
                        MissionData.MyMissions.HitXM.Add(BigHit);
                        PlayerWarpToWaypoint(World.GetWaypointPosition(), false);
                        MissionData.VectorList_01.Clear();
                        UiDisplay.HelperBarBuiler(1, false);
                        DataStore.iBuildingUp += 1;
                    }
                }
                else if (DataStore.iBuildingUp == 1)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            MissionData.MyMissions.HitXM[0].Vboss = Game.Player.Character.Position;
                            MissionData.MyMissions.HitXM[0].BossDir = Game.Player.Character.Heading;
                            MultiBlimbs(Game.Player.Character.Position, 303, false, "");
                            UiDisplay.HelperBarBuiler(2, true);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 2)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            ObjectHand.CleanUpBlips(ObjectHand.ConvertToHandle(MissionData.BlipList_01, null, null, null), true);
                            MissionData.BlipList_01.Clear();
                            UiDisplay.HelperBarBuiler(1, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            MissionData.MyMissions.HitXM[0].Goon01 = Game.Player.Character.Position;
                            MissionData.MyMissions.HitXM[0].Goon01Dir = Game.Player.Character.Heading;
                            MultiBlimbs(Game.Player.Character.Position, 432, false, "");
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 3)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                            MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp += 1;
                            MissionData.MyMissions.HitXM[0].Goon02 = Game.Player.Character.Position;
                            MissionData.MyMissions.HitXM[0].Goon02Dir = Game.Player.Character.Heading;
                            MultiBlimbs(Game.Player.Character.Position, 432, false, "");
                            UiDisplay.HelperBarBuiler(3, true);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 4)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            UiDisplay.HelperBarBuiler(2, true);
                            for (int i = 0; i < MissionData.VectorList_01.Count; i++)
                            {
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                            MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                            MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            MissionData.VectorList_01.Clear();
                            DataStore.iBuildingUp -= 1;
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.VectorList_01.Add(Game.Player.Character.Position);
                            UI.Notify("Stop No == " + MissionData.VectorList_01.Count);
                            MultiBlimbs(Game.Player.Character.Position, 535, false, "");
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 1)
                            {
                                DataStore.iBuildingUp += 1;
                                MissionData.MyMissions.HitXM[0].Goon03 = new List<Vector3>(MissionData.VectorList_01);
                                MissionData.VectorList_01.Clear();
                            }
                            else
                                UI.Notify("No Stops");
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 5)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            for (int i = 0; i < MissionData.VectorList_01.Count; i++)
                            {
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                            MissionData.VectorList_01.Clear();
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.VectorList_01.Add(Game.Player.Character.Position);
                            UI.Notify("Stop No == " + MissionData.VectorList_01.Count);
                            MultiBlimbs(Game.Player.Character.Position, 536, false, "");
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 1)
                            {
                                DataStore.iBuildingUp += 1;
                                MissionData.MyMissions.HitXM[0].Goon04 = new List<Vector3>(MissionData.VectorList_01);
                                MissionData.VectorList_01.Clear();
                                UiDisplay.HelperBarBuiler(4, true);
                            }
                            else
                                UI.Notify("No Stops");
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 6)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(3, true);
                            for (int i = 0; i < MissionData.VectorList_01.Count; i++)
                            {
                                MissionData.BlipList_01[MissionData.BlipList_01.Count - 1].Remove();
                                MissionData.BlipList_01.RemoveAt(MissionData.BlipList_01.Count - 1);
                            }
                            MissionData.VectorList_01.Clear();
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.VectorList_01.Add(Game.Player.Character.Position);
                            UI.Notify("Stop No == " + MissionData.VectorList_01.Count);
                            MultiBlimbs(Game.Player.Character.Position, 537, false, "");
                        }
                        else if (ReturnStuff.ButtonDown(23))
                        {
                            if (MissionData.VectorList_01.Count > 1)
                            {
                                DataStore.iBuildingUp += 1;
                                MissionData.MyMissions.HitXM[0].Goon05 = new List<Vector3>(MissionData.VectorList_01);
                                MissionData.VectorList_01.Clear();
                                UiDisplay.HelperBarBuiler(5, true);
                            }
                            else
                                UI.Notify("No Stops");
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 7)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(22))
                        {
                            DataStore.iBuildingUp -= 1;
                            UiDisplay.HelperBarBuiler(4, true);
                        }
                        else if (ReturnStuff.ButtonDown(21))
                        {
                            DataStore.iBuildingUp = 9;
                            TheMissions.WhereAreYou();
                            MissionData.MyMissions.HitXM[0].Local = MissionData.iLocationX;
                            MissionData.MyMissions.HitXM[0].Vstart = Game.Player.Character.Position;
                            MissionData.MyMissions.HitXM[0].FUbstop = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                            ObjectHand.PostMess();
                            LaunchTest();
                            TheMissions.HitMan();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 9)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            MissionData.sList_01 = ReturnStuff.BuildMishLists(7);
                            if (MissionData.sList_01.Count > 0)
                            {
                                DataStore.iBuildingUp = 10;
                                TheMenus.BackToBuildMenu(1);
                            }
                            else
                            {
                                string sFileName = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                                TheMissions.BuildMissions(MissionData.iBuildMode, sFileName);
                                ObjectHand.PostMess();
                                MissionData.iBuildMode = 99;
                            }
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.HitXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
                else if (DataStore.iBuildingUp == 8)
                {
                    if (ReturnStuff.ButtonDown(37))
                    {
                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectHand.PostMess();
                            DataStore.iBuildingUp = 9;
                            LaunchTest();
                            TheMissions.HitMan();
                            ObjectHand.SlowFastTravel(MissionData.vFuMiss, 0.00f);
                        }
                        else if (ReturnStuff.ButtonDown(22))
                        {
                            MissionData.MyMissions.HitXM.Clear();
                            MissionData.iBuildMode = 99;
                            ObjectHand.PostMess();
                        }
                    }
                }
            }      //HitMan
            else
            {
                Game.Player.IsInvincible = false;
                DataStore.iBuildingUp = 0;
                MissionData.iBuildMode = 0;
                DataStore.bBuildMode = false;
                TheMenus.BackToBuildMenu(0);
            }

            ClearTheWay(false);
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (DataStore.bHasLoaded)
            {
                if (DataStore.bMenuOpen)
                {
                    if (TheMenus.YtmenuPool.IsAnyMenuOpen())
                        TheMenus.YtmenuPool.ProcessMenus();
                    else
                    {
                        Game.Player.Character.FreezePosition = false;
                        Function.Call(Hash.DISPLAY_RADAR, true);
                        DataStore.bMenuOpen = false;
                        if (!DataStore.bBuildMode)
                        {
                            DataStore.bLookingForPB = true;
                            Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
                            Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
                            Function.Call(Hash.SET_FAR_DRAW_VEHICLES, true);
                            Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, false);
                        }
                        else
                        {
                            Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 0);
                            Function.Call(Hash.SET_PED_POPULATION_BUDGET, 0);
                            Function.Call(Hash.SET_FAR_DRAW_VEHICLES, false);
                            Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, true);
                        }

                        if (DataStore.bOptionsMen)
                        {
                            DataStore.bOptionsMen = false;
                            MissionData.bOnTheJob = false;
                            DataStore.bLookingForPB = true;
                        }

                        if (DataStore.bOnlineStuffLoaded && !DataStore.MySettings.PreLoadOnline)
                            DataStore.LoadOnlineIps(false);
                        else if (DataStore.MySettings.PreLoadOnline && !DataStore.bOnlineStuffLoaded)
                            DataStore.LoadOnlineIps(true);
                    }
                }
                else if (DataStore.bBuildMode)
                {
                    BuildingTime();
                }
                else if (MissionData.bOnTheJob)
                {
                    if (MissionData.bJobLoaded)
                    {
                        MissionTime();
                    }
                }
                else
                {
                    if (DataStore.bBankTransfer)
                    {
                        UiDisplay.BankingApp();
                    }
                    else if (iATMSlow < Game.GameTime)
                    {
                        if (Function.Call<bool>(Hash._HAS_NAMED_SCALEFORM_MOVIE_LOADED, "ATM"))
                        {
                            if (DataStore.iLookForPB != 0)
                            {
                                if (DataStore.iLookForPB == 2)
                                {
                                    if (bRingRing)
                                    {
                                        bRingRing = false;
                                        ObjectHand.SafeCleaning(iPhonedID, true, 5, false);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;
                                    if (PhoneBlip != null)
                                    {
                                        ObjectHand.SafeCleaning(PhoneBlip.Handle, true, 0, false);
                                        PhoneBlip = null;
                                    }
                                }
                                DataStore.iLookForPB = 0;
                            }
                            else
                            {
                                RWDatFile.LoadDat();
                                DataStore.iCoinBats = 4;
                                DataStore.bBankTransfer = true;
                            }
                        }
                        else
                            iATMSlow = Game.GameTime + 2500;
                    }
                    else
                    {
                        if (DataStore.bLookingForPB)
                        {
                            if (bDlCVehStartTest)
                            {
                                if (!Game.IsLoading)
                                {
                                    if (DLCTestVeh == null)
                                    {
                                        Script.Wait(1000);
                                        DLCTestVeh = ObjectBuild.VehicleSpawn("OPENWHEEL1", Game.Player.Character.Position + (Game.Player.Character.UpVector * 25), 0.00f, false, false, false, false, 0, 0, 0, "", 0, false);
                                        if (DLCTestVeh.Exists())
                                        {
                                            DLCTestVeh.HasCollision = false;
                                            DLCTestVeh.IsVisible = false;
                                        }
                                        MissionData.VehicleList_01.Clear();
                                        iPhoneDelay = Game.GameTime + 20000;
                                    }
                                    else if (DLCTestVeh.Exists())
                                    {
                                        DLCTestVeh.Position = Game.Player.Character.Position + (Game.Player.Character.UpVector * 25);

                                        if (iPhoneDelay < Game.GameTime)
                                        {
                                            bDlCVehStartTest = false;
                                            DLCTestVeh.IsPersistent = false;
                                            DLCTestVeh.Delete();
                                            DataStore.bTrainM = true;
                                        }
                                    }
                                    else
                                        bDlCVehStartTest = false;
                                }
                            }
                            else if (DataStore.iLookForPB == 0)
                            {
                                iPhoneDelay = Game.GameTime + DataStore.MySettings.SPDelayTime;
                                DataStore.iLookForPB = 1;
                            }
                            else if (DataStore.iLookForPB == 1)
                            {
                                if (iPhoneDelay < Game.GameTime)
                                {
                                    if (DataStore.bOnCayoLand)
                                    {
                                        if (Game.Player.Character.Position.Y > -3370.00f)
                                            TheCayoConnection(false);
                                    }
                                    else
                                    {
                                        if (Game.Player.Character.Position.Y < -3370.00f)
                                            TheCayoConnection(true);
                                    }

                                    PhoneHome = BoxingClever();

                                    if (PhoneHome != null)
                                    {
                                        AnswerYourPhone(PhoneHome);
                                        DataStore.iLookForPB = 2;
                                    }
                                    else
                                        DataStore.iLookForPB = 1;
                                }
                            }
                            else if (DataStore.iLookForPB == 2)
                            {
                                if (World.GetDistance(Game.Player.Character.Position, DataStore.vPhoneCorona) < 200.00f && PhoneHome.Health > 999)
                                {
                                    if (World.GetDistance(Game.Player.Character.Position, DataStore.vPhoneCorona) < 40.00f)
                                    {
                                        if (!bRingRing && DataStore.MySettings.PhoneAudio)
                                        {
                                            MissionData.iWait4Sec = Game.GameTime + 1000;
                                            bRingRing = true;
                                            PlaySoundFrom("SCRIPT/ASSASSINATION_MULTI", "ASS_PAYPHONE_RING_master", "", PhoneHome.Position, true);
                                        }
                                        if (DataStore.MySettings.PhoneCone)
                                            World.DrawMarker(MarkerType.VerticalCylinder, DataStore.vPhoneCorona, Vector3.Zero, Vector3.Zero, new Vector3(1.00f, 1.00f, 1.00f), color: Color.Green);

                                        if (World.GetDistance(Game.Player.Character.Position, DataStore.vPhoneCorona) < 2.00f && Game.Player.Character.IsOnFoot)
                                        {
                                            if (MissionData.iWait4Sec < Game.GameTime)
                                            {
                                                MissionData.fphdirect = PhoneHome.Heading + 90.00f;
                                                if (DataStore.MySettings.PhoneAnim)
                                                    PickUpThePhone();

                                                if (bRingRing)
                                                {
                                                    bRingRing = false;
                                                    ObjectHand.SafeCleaning(iPhonedID, true, 5, false);
                                                    DataStore.Chatter.Play();
                                                }

                                                if (PhoneBlip != null)
                                                {
                                                    ObjectHand.SafeCleaning(PhoneBlip.Handle, true, 0, false);
                                                    PhoneBlip = null;
                                                }

                                                if (!DataStore.bOnCayoLand)
                                                    PhoneHome.IsPersistent = false;

                                                PhoneHome = null;
                                                DataStore.iLookForPB = 0;
                                                DataStore.bLookingForPB = false;
                                                TheMissions.AreULocal();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (bRingRing)
                                        {
                                            bRingRing = false;
                                            ObjectHand.SafeCleaning(iPhonedID, true, 5, false);
                                        }
                                    }
                                }
                                else
                                {
                                    if (bRingRing)
                                    {
                                        bRingRing = false;
                                        ObjectHand.SafeCleaning(iPhonedID, true, 5, false);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;
                                    if (PhoneBlip != null)
                                    {
                                        ObjectHand.SafeCleaning(PhoneBlip.Handle, true, 0, false);
                                        PhoneBlip = null;
                                    }
                                    DataStore.iLookForPB = 0;
                                }
                            }
                        }
                    }

                    if (DataStore.MySettings.MenyooAppFixer)
                    {
                        if (Game.GameTime < iAppScaner)
                            MissingApps();
                    }
                }
            }
        }
    }
}