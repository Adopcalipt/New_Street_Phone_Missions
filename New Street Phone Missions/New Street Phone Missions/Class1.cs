using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class Main : Script
    {
        private bool bRingRing = false;
        private bool bDlCVehStartTest = true;

        private int iATMSlow = 0;
        private int iAppScaner = 0;
        private int iPhoneDelay = 0;
        
        private Prop PhoneHome = null;
        private Prop Trinket = null;
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
        public Prop BoxingClever()
        {
            Prop ThisPhone = null;
            List<Prop> PhoneList = new List<Prop>();
            Prop[] StreetPhone = World.GetNearbyProps(Game.Player.Character.Position, 50.00f);
            List<Prop> StreetList = new List<Prop>();
            for (int i = 0; i < StreetPhone.Count(); i++)
                StreetList.Add(new Prop(StreetPhone[i].Handle));

            for (int i = 0; i < StreetList.Count; i++)
            {
                try
                {
                    Prop ThisProp = StreetList[i];
                    if (ThisProp.Exists())
                    {
                        for (int ii = 0; ii < DataStore.sPhoneType.Count; ii++)
                        {
                            if (ThisProp.Model == Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sPhoneType[ii]))
                            {
                                bool bAddThis = true;
                                for (int iii = 0; iii < DataStore.vOldPhoneBoxList.Count; iii++)
                                {
                                    if (TheMissions.AreUNear(ThisProp.Position, DataStore.vOldPhoneBoxList[iii], 3f))
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
                catch
                {
                    LoggerLight.LogThis("BoxingClever lost a phonebox");
                }

            }

            for (int i = 0; i < PhoneList.Count; i++)
            {
                if (PhoneList[i].Health > 990)
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
            if (ThisPhone.Model == Function.Call<int>(Hash.GET_HASH_KEY, "prop_phonebox_02") || ThisPhone.Model == Function.Call<int>(Hash.GET_HASH_KEY, "p_phonebox_02_s"))
                DataStore.vPhoneCorona = ReturnStuff.AlterZHight(DataStore.vPhoneCorona, -1.00f);

            if (DataStore.MySettings.PhoneCone)
            {
                ObjectHand.AddTarget(DataStore.vPhoneCorona, false, true, 1.00f, false, 0, "Street Phone");
                UiDisplay.TheGreenCorona(DataStore.vPhoneCorona, 1.00f);
                ObjectHand.TaggetIcon(MissionData.Target_01, 817);
                MissionData.Target_01.Color = BlipColor.Green2;
                MissionData.Target_01.Scale = 0.80f;
            }
        }
        private void MissingApps()
        {
            iAppScaner = Game.GameTime + 1000;
            for (int i = 0; i < DataStore.AppMadness.Count; i++)
            {
                if (TheMissions.AmINear(DataStore.AppMadness[i], 40f))
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
        private void TrinketFound()
        {
            DataStore.MyDatSet.iTrinket = 99;
            Trinket.Delete();
            Trinket = null;
            UiDisplay.YourCoinPopUp(10000000, 1, "Trinket");
            UiDisplay.YourCoinPopUp(100000000, 2, "Trinket");
            UiDisplay.YourCoinPopUp(100000000, 3, "Trinket");
            RWDatFile.SaveDat(14, DataStore.MyDatSet.iTrinket);
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
                    TheMissions.BuildingTime();
                }
                else if (MissionData.bOnTheJob)
                {
                    if (MissionData.bJobLoaded)
                    {
                        TheMissions.MissionTime();
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
                                        ObjectHand.SafeCleaning(ObjectHand.iPhonedID, true, 5, false);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;
                                    ObjectHand.RemoveTargets();
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
                                        DLCTestVeh = ObjectBuild.VehicleSpawn("conada", Game.Player.Character.Position + (Game.Player.Character.UpVector * 25), 0.00f, false, false, false, false, 0, 0, 0, "", 0, false);
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
                                DataStore.iLookForPB++;
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
                                        DataStore.iLookForPB++;
                                    }
                                    else
                                        DataStore.iLookForPB = 1;
                                }
                            }
                            else if (DataStore.iLookForPB == 2)
                            {
                                if (TheMissions.AmINear(DataStore.vPhoneCorona, 200f) && PhoneHome.Health > 999)
                                {
                                    if (TheMissions.AmINear(DataStore.vPhoneCorona, 40f))
                                    {
                                        if (!bRingRing && DataStore.MySettings.PhoneAudio)
                                        {
                                            MissionData.iWait4Sec = Game.GameTime + 1000;
                                            bRingRing = true;
                                            ObjectHand.PlaySoundFrom("SCRIPT/ASSASSINATION_MULTI", "ASS_PAYPHONE_RING_master", "", PhoneHome.Position, true);
                                        }

                                        if (TheMissions.AmINear(PhoneHome.Position, 2f) && Game.Player.Character.IsOnFoot)
                                        {
                                            if (MissionData.iWait4Sec < Game.GameTime)
                                            {
                                                MissionData.fphdirect = PhoneHome.Heading + 90.00f;
                                                if (DataStore.MySettings.PhoneAnim)
                                                    PickUpThePhone();

                                                if (bRingRing)
                                                {
                                                    bRingRing = false;
                                                    ObjectHand.SafeCleaning(ObjectHand.iPhonedID, true, 5, false);
                                                    DataStore.Chatter.Play();
                                                }

                                                ObjectHand.RemoveTargets();

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
                                            ObjectHand.SafeCleaning(ObjectHand.iPhonedID, true, 5, false);
                                        }
                                    }
                                }
                                else
                                {
                                    if (bRingRing)
                                    {
                                        bRingRing = false;
                                        ObjectHand.SafeCleaning(ObjectHand.iPhonedID, true, 5, false);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;

                                    ObjectHand.RemoveTargets();
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

                if (DataStore.MyDatSet.iTrinket == 0)
                {
                    if (Trinket == null)
                    {
                        Trinket = ObjectBuild.BuildProp("ch_prop_ch_bag_02a", new Vector3(557.37f, 5561.55f, 752.27f), new Vector3(-10.99f, 19.99f, -13.95f), true, false);
                        MissionData.PropList_01.Remove(Trinket);
                    }
                    else
                    {
                        if (TheMissions.AmINear(Trinket.Position, 1.3f))
                            TrinketFound();
                    }
                }
            }
        }
    }
}