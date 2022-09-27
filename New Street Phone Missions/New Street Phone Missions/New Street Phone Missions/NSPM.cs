using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class Main : Script
    {
        private bool bRingRing = false;
        private bool bDlCVehStartTest = true;

        private int iATMSlow = 0;
        private int iAppScaner = 0;
        private int iPhoneDelay = 0;

        private Prop Trinket = null;
        private Vehicle DLCTestVeh = null;
        private Prop PhoneHome = null;

        private List<Prop> CayoPhones = new List<Prop>();
        private readonly List<Vector4> CayoPhoneV4 = new List<Vector4>
        {
            new Vector4(4969.19336f, -5600.90381f, 23.20f, -31.9523754f),
            new Vector4(5099.08643f, -5719.28613f, 16.00f, -124.599854f),
            new Vector4(5368.04688f, -5434.42529f, 48.70f, 145.241089f),
            new Vector4(4892.95898f, -5453.17578f, 30.40f, -2.67467785f),
            new Vector4(4914.79004f, -5294.33057f, 7.90f, -88.7225647f),
            new Vector4(5117.92285f, -5189.38135f, 2.10f, -90.0995636f),
            new Vector4(5152.40479f, -5058.93018f, 3.80f, 87.5917511f),
            new Vector4(5142.36719f, -4952.96729f, 14.00f, 49.3263206f),
            new Vector4(5028.74512f, -4635.70703f, 4.70f, -101.267654f),
            new Vector4(4872.50977f, -4482.87988f, 9.80f, 88.2257385f),
            new Vector4(4492.33105f, -4522.10205f, 4.10f, 109.983139f),
            new Vector4(4365.35645f, -4579.11377f, 4.00f, -69.9810333f),
            new Vector4(5177.31738f, -4651.67627f, 2.20f, 167.547989f),
            new Vector4(5264.31201f, -5420.22607f, 65.50f, 55.1944542f),
            new Vector4(5132.79688f, -5527.75342f, 53.70f, 119.800873f),
            new Vector4(5032.13135f, -5759.62793f, 15.30f, 138.167618f),
            new Vector4(5038.44678f, -5120.1416f, 5.50f, -178.255859f)
        };
        private static List<Vector3> AppMadness = new List<Vector3>
        {
            new Vector3(346.5659f, -1012.851f, -99.19622f),
            new Vector3(260.5322f, -999.1339f, -99.0087f),//"Low End Apartment"),
            new Vector3(343.8500f, -999.0800f, -99.1977f),//"Mid Range Apartment"),
            new Vector3(-262.46f, -951.89f, 75.83f),//"3 Alta Street Apt 10"),
            new Vector3(-280.74f, -961.50f, 91.11f),//"3 Alta Street Apt 57"),
            new Vector3(-895.85f, -433.90f, 94.06f),//"Weazel Plaza Apt 26"),
            new Vector3(-909.054f, -441.466f, 120.205f),//"Weazel Plaza Apt 70"),
            new Vector3(-884.301f, -454.515f, 125.132f),//"Weazel Plaza Apt 101"),
            new Vector3(-897.197f, -369.246f, 84.0779f),//"Richard Majestic Apt 4"),
            new Vector3(-932.29f, -385.88f, 108.03f),//"Richard Majestic Apt 51"),
            new Vector3(-575.305f, 42.3233f, 92.2236f),//"Tinsel Towers Apt 29"),
            new Vector3(-617.609f, 63.024f, 106.624f),//"Tinsel Towers Apt 45"),
            new Vector3(-795.04f, 342.37f, 206.22f),//"Eclipse Towers Apt 5"),
            new Vector3(-759.79f, 315.71f, 175.40f),//"Eclipse Towers Apt 9"),
            new Vector3(-797.095f, 335.069f, 158.599f),//"Eclipse Towers Apt 31"),
            new Vector3(-752.605f, 320.821f, 221.855f),//"Eclipse Towers Apt 40"),
            new Vector3(-37.41f, -582.82f, 88.71f),//"4 Integrity Way Apt 30"),
            new Vector3(-10.58f, -581.26f, 98.83f),//"4 Integrity Way Apt 35"),
            new Vector3(-1477.14f, -538.75f, 55.5264f),//"Del Perro Heights Apt 7"),
            new Vector3(-1474.17f, -528.124f, 68.1541f),//"Del Perro Heights Apt 20"),
            new Vector3(-14.7964f, -581.709f, 79.4307f),//"4 Integrity Way Apt 28"),
            new Vector3(-1468.14f, -541.815f, 73.4442f),//"Del Perro Heights Apt 4"),
            new Vector3(-915.811f, -379.432f, 113.675f),//"Richard Majestic Apt 2"),
            new Vector3(-614.86f, 40.6783f, 97.6001f),//"Tinsel Towers Apt 42"),
            new Vector3(-773.407f, 341.766f, 211.397f),//"Eclipse Towers Apt 3"),
            new Vector3(-172.983f, 494.033f, 137.654f),//"3655 Wild Oats Drive"),
            new Vector3(340.941f, 437.18f, 149.39f),//"2044 North Conker Avenue"),
            new Vector3(373.023f, 416.105f, 145.701f),//"2045 North Conker Avenue"),
            new Vector3(-676.127f, 588.612f, 145.17f),//"2862 Hillcrest Avenue"),
            new Vector3(-763.107f, 615.906f, 144.14f),//"2868 Hillcrest Avenue"),
            new Vector3(-857.798f, 682.563f, 152.653f),//"2874 Hillcrest Avenue"),
            new Vector3(120.5f, 549.952f, 184.097f),//"3677 Whispymound Drive"),
            new Vector3(-1288.0f, 440.748f, 97.6946f)//"2113 Mad Wayne Thunder"),
        };

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
                for (int i = 0; i < CayoPhoneV4.Count; i++)
                {
                    Vector3 vPos = new Vector3(CayoPhoneV4[i].X, CayoPhoneV4[i].Y, CayoPhoneV4[i].Z);
                    Vector3 vRot = new Vector3(0.00f, 0.00f, CayoPhoneV4[i].R);

                    Prop Bpox = ObjectBuild.BuildProp("p_phonebox_02_s", vPos, vRot, true, true);
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
        private void MissingApps()
        {
            iAppScaner = Game.GameTime + 1000;
            for (int i = 0; i < AppMadness.Count; i++)
            {
                if (TheMissions.AmINear(AppMadness[i], 40f))
                {
                    ObjectBuild.AppeyNess(AppMadness[i]);
                    AppMadness.RemoveAt(i);
                }
            }
        }
        private static void PickUpThePhone()
        {
            float fThisWay = MissionData.fphdirect - 88.00f;
            int iTFuckedUp = Game.GameTime + 12000;
            Game.Player.Character.FreezePosition = true;
            Script.Wait(500);
            Game.Player.Character.FreezePosition = false;
            TheMissions.WalkThisWay(Game.Player.Character, DataStore.vPhoneCorona, 1.00f);
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
        private static void AnswerYourPhone(Prop ThisPhone)
        {
            LoggerLight.LogThis("AnswerYourPhone");

            DataStore.vPhoneCorona = ThisPhone.Position - (ThisPhone.ForwardVector * 1);
            if (ThisPhone.Model == Function.Call<int>(Hash.GET_HASH_KEY, "prop_phonebox_02") || ThisPhone.Model == Function.Call<int>(Hash.GET_HASH_KEY, "p_phonebox_02_s"))
                DataStore.vPhoneCorona = ReturnStuff.AlterZHight(DataStore.vPhoneCorona, -1.00f);

            if (DataStore.MySettings.PhoneCone)
            {
                ObjectBuild.AddTarget(DataStore.vPhoneCorona, false, true, 1.00f, false, 0, "Street Phone");
                UiDisplay.TheGreenCorona(DataStore.vPhoneCorona, 1.00f);
                ObjectBuild.TaggetIcon(MissionData.Target_01, 817);
                MissionData.Target_01.Color = BlipColor.Green2;
                MissionData.Target_01.Scale = 0.80f;
            }
        }
        private void TrinketFound()
        {
            DataStore.MyDatSet.iTrinket = 99;
            Trinket.Delete();
            Trinket = null;
            NSBanking.YourCoinPopUp(10000000, 1, "Trinket");
            NSBanking.YourCoinPopUp(100000000, 2, "Trinket");
            NSBanking.YourCoinPopUp(100000000, 3, "Trinket");
            NSBanking.SaveDat(14, DataStore.MyDatSet.iTrinket);
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
                        NSBanking.BankingApp();
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
                                        ObjectLog.CleanUp(-1, DataStore.iSoundId, -1);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;
                                    ObjectClear.RemoveTargets();
                                }
                                DataStore.iLookForPB = 0;
                            }
                            else
                            {
                                NSBanking.LoadDat();
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
                                        DLCTestVeh = ObjectBuild.VehicleSpawn("FORMULA2", Game.Player.Character.Position + (Game.Player.Character.UpVector * 25), 0.00f, false, false, false, false, 0, 0, 0, "", 0, false);
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

                                    PhoneHome = SearchFor.BoxingClever();

                                    if (PhoneHome != null)
                                    {
                                        AnswerYourPhone(PhoneHome);
                                        DataStore.iLookForPB++;
                                    }
                                    else
                                        iPhoneDelay = Game.GameTime + DataStore.MySettings.SPDelayTime;
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
                                            ObjectBuild.PlaySoundFrom("SCRIPT/ASSASSINATION_MULTI", "ASS_PAYPHONE_RING_master", "", PhoneHome.Position, true);
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
                                                    ObjectLog.CleanUp(-1, DataStore.iSoundId, -1);
                                                    DataStore.Chatter.Play();
                                                }

                                                ObjectClear.RemoveTargets();

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
                                            ObjectLog.CleanUp(-1, DataStore.iSoundId, -1);
                                        }
                                    }
                                }
                                else
                                {
                                    if (bRingRing)
                                    {
                                        bRingRing = false;
                                        ObjectLog.CleanUp(-1, DataStore.iSoundId, -1);
                                    }
                                    if (!DataStore.bOnCayoLand)
                                        PhoneHome.IsPersistent = false;
                                    PhoneHome = null;

                                    ObjectClear.RemoveTargets();
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