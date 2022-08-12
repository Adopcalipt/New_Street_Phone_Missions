using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class ReturnStuff 
    {
        public static bool IsItARealVehicle(string sVehName)
        {
            LoggerLight.LogThis("IsItARealVehicle, == " + sVehName);
            bool bIsReal = false;

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehName);

            if (Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
                bIsReal = true;

            return bIsReal;
        }
        public static int WhatVehicleAreYou(string sVehName)
        {
            LoggerLight.LogThis("WhatVehicleAreYou, == " + sVehName);

            int iAm = Function.Call<int>(Hash.GET_VEHICLE_CLASS_FROM_NAME, Function.Call<int>(Hash.GET_HASH_KEY, sVehName));

            if (iAm == 16)
                iAm = 2;
            else if (iAm == 14)
                iAm = 3;
            else if (iAm == 15)
                iAm = 4;
            else
                iAm = 1;

            return iAm;
        }
        public static int SelectBuilderMish(int iMishcon)
        {
            int iGot = -2;
            int iBuild = 0;
            int iChoose = 0;
            if (iMishcon == 1)
                iBuild = MissionData.MyMissions.TruckersXM.Count() - 1;
            else if (iMishcon == 2)
                iBuild = MissionData.MyMissions.PackersXM.Count() - 1;
            else if (iMishcon == 3)
                iBuild = MissionData.MyMissions.ConsXM.Count() - 1;
            else if (iMishcon == 4)
                iBuild = MissionData.MyMissions.JohnsXM.Count() - 1;
            else if (iMishcon == 5)
                iBuild = MissionData.MyMissions.RaceXM.Count() - 1;
            else if (iMishcon == 6)
                iBuild = MissionData.MyMissions.BombXM.Count() - 1;
            else if (iMishcon == 7)
                iBuild = MissionData.MyMissions.HitXM.Count() - 1;
            else if (iMishcon == 8)
                iBuild = MissionData.MyMissions.SharksXM.Count() - 1;

            while (iGot == -2)
            {
                string sTypo = DataStore.MyLang.Context[0] + iChoose;
                UiDisplay.ControlerUI(sTypo, 1);
                Script.Wait(1);
                if (Game.IsControlJustPressed(2, GTA.Control.Sprint))
                    iGot = iChoose;
                else if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                {
                    if (iChoose > 0)
                        iChoose -= 1;
                }
                else if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                    if (iChoose < iBuild)
                        iChoose += 1;
                }
            }
            return iGot;
        }
        public static bool XmlHasChanged()
        {
            bool TheyChanged = false;

            if (File.Exists(DataStore.sNSPMSet))
            {
                XmlSetings TestSet = ReadWriteXML.LoadXmlSets(DataStore.sNSPMSet);

                if (DataStore.MySettings.Amulance != TestSet.Amulance)
                    TheyChanged = true;
                else if (DataStore.MySettings.Assassination != TestSet.Assassination)
                    TheyChanged = true;
                else if (DataStore.MySettings.BayLift != TestSet.BayLift)
                    TheyChanged = true;
                else if (DataStore.MySettings.BBBomb != TestSet.BBBomb)
                    TheyChanged = true;
                else if (DataStore.MySettings.Convicts != TestSet.Convicts)
                    TheyChanged = true;
                else if (DataStore.MySettings.DebtCollect != TestSet.DebtCollect)
                    TheyChanged = true;
                else if (DataStore.MySettings.Deliverwho != TestSet.Deliverwho)
                    TheyChanged = true;
                else if (DataStore.MySettings.Follow != TestSet.Follow)
                    TheyChanged = true;
                else if (DataStore.MySettings.FUber != TestSet.FUber)
                    TheyChanged = true;
                else if (DataStore.MySettings.Getaway != TestSet.Getaway)
                    TheyChanged = true;
                else if (DataStore.MySettings.Gruppe6 != TestSet.Gruppe6)
                    TheyChanged = true;
                else if (DataStore.MySettings.HappyShopper != TestSet.HappyShopper)
                    TheyChanged = true;
                else if (DataStore.MySettings.ImportantEx != TestSet.ImportantEx)
                    TheyChanged = true;
                else if (DataStore.MySettings.Johnny != TestSet.Johnny)
                    TheyChanged = true;
                else if (DataStore.MySettings.LSFD != TestSet.LSFD)
                    TheyChanged = true;
                else if (DataStore.MySettings.MCBusiness != TestSet.MCBusiness)
                    TheyChanged = true;
                else if (DataStore.MySettings.MoresMute != TestSet.MoresMute)
                    TheyChanged = true;
                else if (DataStore.MySettings.Packages != TestSet.Packages)
                    TheyChanged = true;
                else if (DataStore.MySettings.ParaDisplay != TestSet.ParaDisplay)
                    TheyChanged = true;
                else if (DataStore.MySettings.Pilot != TestSet.Pilot)
                    TheyChanged = true;
                else if (DataStore.MySettings.Raceist != TestSet.Raceist)
                    TheyChanged = true;
                else if (DataStore.MySettings.Sailor != TestSet.Sailor)
                    TheyChanged = true;
                else if (DataStore.MySettings.Sharks != TestSet.Sharks)
                    TheyChanged = true;
                else if (DataStore.MySettings.TempJob != TestSet.TempJob)
                    TheyChanged = true;
                else if (DataStore.MySettings.Truckin != TestSet.Truckin)
                    TheyChanged = true;

                DataStore.MySettings = TestSet;
            }

            return TheyChanged;
        }
        public static bool FindBuiltMissions(int iType)
        {
            LoggerLight.LogThis("FindBuiltMissions, Type == " + iType);

            bool bMishcons = false;
            ObjectHand.CleanMishlists();

            if (iType == 1)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.TruckersXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.TruckersXM[ii].Local)
                                {
                                    MissionData.MyMissions.TruckersXM.Add(Mb.TruckersXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Trucking
            else if (iType == 2)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.PackersXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.PackersXM[ii].Local)
                                {
                                    MissionData.MyMissions.PackersXM.Add(Mb.PackersXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Packages
            else if (iType == 3)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.ConsXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.ConsXM[ii].Local)
                                {
                                    MissionData.MyMissions.ConsXM.Add(Mb.ConsXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Convicts
            else if (iType == 4)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.FubardXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.FubardXM[ii].Local)
                                {
                                    MissionData.MyMissions.FubardXM.Add(Mb.FubardXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //FUber
            else if (iType == 5)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.AmbuXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.AmbuXM[ii].Local)
                                {
                                    MissionData.MyMissions.AmbuXM.Add(Mb.AmbuXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Ambulance
            else if (iType == 6)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.SharksXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.SharksXM[ii].Local)
                                {
                                    MissionData.MyMissions.SharksXM.Add(Mb.SharksXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Sharks
            else if (iType == 7)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.JohnsXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.JohnsXM[ii].Local)
                                {
                                    MissionData.MyMissions.JohnsXM.Add(Mb.JohnsXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Johnny
            else if (iType == 8)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.RaceXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.RaceXM[ii].Local)
                                {
                                    MissionData.MyMissions.RaceXM.Add(Mb.RaceXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //Raceist
            else if (iType == 9)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.BombXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.BombXM[ii].Local)
                                {
                                    MissionData.MyMissions.BombXM.Add(Mb.BombXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //BBBomb
            else if (iType == 10)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                    {
                        if (File.Exists(MyBulders[i]))
                        {
                            MissionBuilder Mb = ReadWriteXML.LoadXmMissions(MyBulders[i]);
                            for (int ii = 0; ii < Mb.HitXM.Count; ii++)
                            {
                                if (MissionData.iLocationX == Mb.HitXM[ii].Local)
                                {
                                    MissionData.MyMissions.HitXM.Add(Mb.HitXM[ii]);
                                    bMishcons = true;
                                }
                            }
                        }
                    }
                }
            }       //HitMan

            return bMishcons;
        }
        public static List<string> BuildMishLists(int itype)
        {
            LoggerLight.LogThis("BuildMishLists, itype == " + itype);

            List<string> MishString = new List<string>();

            if (itype == 1)
            {
                MishString.Add("SADLER"); //
                MishString.Add("BISON"); //
                MishString.Add("BISON2"); //<!-- McGill-Olsen Bison -->
                MishString.Add("BISON3"); //<!-- Mighty Bush Bison -->
                MishString.Add("BOBCATXL"); //
                MishString.Add("INSURGENT3"); //<!-- Insurgent Pick-Up Custom -->
                MishString.Add("TECHNICAL3"); //<!-- Technical Custom -->
            }
            else if (itype == 2)
            {
                MishString.Add("HAULER"); //
                MishString.Add("HAULER2"); //<!-- Hauler Custom -->
                MishString.Add("PACKER"); //
                MishString.Add("PHANTOM"); //
                MishString.Add("PHANTOM3"); //<!-- Phantom Custom -->
                MishString.Add("BARRACKS2"); //<!-- Barracks Semi -->
            }
            else if (itype == 3)
            {
                MishString.Add("Tractor2"); //
            }
            else if (itype == 4)
            {
                MishString.Add("TrailerSmall");
                MishString.Add("BoatTrailer");
                MishString.Add("BaleTrailer");
                MishString.Add("graintrailer");
                MishString.Add("armytanker");
                MishString.Add("Tanker");
                MishString.Add("armytrailer");
                MishString.Add("tr2");
                MishString.Add("TR4");
                MishString.Add("TrailerLogs");
                MishString.Add("trailers");
                MishString.Add("Trailers2");
                MishString.Add("Trailers3");
                MishString.Add("Trailers4");
                MishString.Add("tvtrailer");
            }
            else if (itype == 5)
            {
                MishString.Add("POUNDER");
                MishString.Add("BENSON");
                MishString.Add("Mule2");
                MishString.Add("Boxville2");
                MishString.Add("BURRITO");
                MishString.Add("PONY");
                MishString.Add("Rumpo2");
                MishString.Add("RUMPO3");
                MishString.Add("SPEEDO");
                MishString.Add("SlamVan2");
                MishString.Add("Cruiser");
            }
            else if (itype == 6)
            {
                MishString.Add("prop_rub_cage01b");
                MishString.Add("prop_sacktruck_02b");
                MishString.Add("hei_prop_heist_wooden_box");
                MishString.Add("prop_cs_cardbox_01");
                MishString.Add("prop_cardbordbox_03a");
                MishString.Add("prop_ball_box");
                MishString.Add("ng_proc_box_01a");
                MishString.Add("prop_box_ammo03a");
                MishString.Add("prop_tshirt_box_02");
                MishString.Add("ng_proc_binbag_01a");
                MishString.Add("prop_cliff_paper");
            }
            else if (itype == 7)
            {
                if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/"))
                {
                    string[] MyBulders = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/");
                    for (int i = 0; i < MyBulders.Count(); i++)
                        MishString.Add(MyBulders[i]);
                }
            }
            
            return MishString;
        }
        public static PackBuild Packages_KitBuild(PackBuild LocalMish, Vector3 Fub, Vector3 VehStart, float fDirect, string sVeh, string sPack, int Live)
        {
            LocalMish.FarstStart = Fub;
            LocalMish.PackVehStart = VehStart;
            LocalMish.PackVehDir = fDirect; ;
            LocalMish.PackVehType = sVeh;
            LocalMish.PackDropType = sPack;
            LocalMish.Livery = Live;

            return LocalMish;
        }
        public static List<Vector3> Packages_SortCayo(List<string> ObName, List<Vector3> ListToFix, Vector3 vStartPoint)
        {
            LoggerLight.LogThis("Packages_SortCayo ObName.Count == " + ObName.Count + ", ListToFix.Count == " + ListToFix.Count);

            MissionData.sCayoPacks.Clear();

            List<Vector3> ObPos = new List<Vector3>
            {
                new Vector3(5265.879f, -5427.419f, 141.0486f),
                new Vector3(5407.132f, -5716.747f, 37.52242f),
                new Vector3(5503.971f, -5366.125f, 22.51798f),
                new Vector3(5066.929f, -5497.295f, 47.59791f),
                new Vector3(4896.859f, -5349.224f, 10.32985f),
                new Vector3(5230.103f, -5062.415f, 13.97499f),
                new Vector3(4930.749f, -4873.889f, 6.68732f),
                new Vector3(5043.498f, -4608.462f, 3.196184f),
                new Vector3(4768.677f, -4385.518f, 14.03571f),
                new Vector3(4519.254f, -4673.16f, 13.40476f)
            };

            List<Vector3> NewVList = new List<Vector3>();
            List<Vector3> AddVList = new List<Vector3>();
            List<string> ObbVList = new List<string>();

            for (int i = 0; i < ObPos.Count; i++)
            {
                if (i == 0)
                {
                    for (int ii = 0; ii < ListToFix.Count; ii++)
                    {
                        if (ListToFix[ii].DistanceTo(ObPos[i]) < 10.00f)
                        {
                            AddVList.Add(ListToFix[ii]);
                            ObbVList.Add(ObName[ii]);
                        }
                    }
                }
                else
                {
                    for (int ii = 0; ii < ListToFix.Count; ii++)
                    {
                        if (ListToFix[ii].DistanceTo(ObPos[i]) < 250.00f)
                        {
                            AddVList.Add(ListToFix[ii]);
                            ObbVList.Add(ObName[ii]);
                        }
                    }
                }

                while (AddVList.Count > 0)
                {
                    if (AddVList.Count == 1)
                    {
                        ListToFix.Remove(AddVList[0]);
                        ObName.Remove(ObbVList[0]);
                        NewVList.Add(AddVList[0]);
                        MissionData.sCayoPacks.Add(ObbVList[0]);
                        AddVList.RemoveAt(0);
                        ObbVList.RemoveAt(0);
                    }
                    else
                    {
                        float fGetDist = 0.00f;
                        int iDrop = 0;

                        for (int iii = 0; iii < AddVList.Count; iii++)
                        {
                            if (AddVList[iii].DistanceTo(ObPos[i]) > fGetDist)
                            {
                                fGetDist = AddVList[iii].DistanceTo(vStartPoint);
                                iDrop = iii;
                            }
                        }
                        ListToFix.Remove(AddVList[iDrop]);
                        ObName.Remove(ObbVList[iDrop]);
                        NewVList.Add(AddVList[iDrop]);
                        MissionData.sCayoPacks.Add(ObbVList[iDrop]);
                        AddVList.RemoveAt(iDrop);
                        ObbVList.RemoveAt(iDrop);
                    }
                }
            }
            for (int i = 0; i < ListToFix.Count; i++)
            {
                NewVList.Add(ListToFix[i]);
                MissionData.sCayoPacks.Add(ObName[i]);
            }

            return NewVList;
        }
        public static int Fubar_Vectors(int Local, int iArea, bool bRandom, bool bUseCustom)
        {
            LoggerLight.LogThis("Fubar_Vectors, Local == " + Local + ", iArea == " + iArea + ", bRandom == " + bRandom);

            MissionData.VectorList_01.Clear();//park
            MissionData.VectorList_02.Clear();//ped


            if (Local == 1)
            {
                if (bRandom)
                    iArea = RandInt(1, 13);

                if (iArea == 1)//        "AIRP")
                {
                    MissionData.VectorList_02.Add(new Vector3(-1042.819f, -2746.101f, 21.3594f));
                    MissionData.VectorList_01.Add(new Vector3(-1033.355f, -2730.467f, 19.36782f));
                    MissionData.VectorList_02.Add(new Vector3(-880.0367f, -2175.426f, 9.809046f));
                    MissionData.VectorList_01.Add(new Vector3(-886.2841f, -2188.905f, 7.813149f));
                    MissionData.VectorList_02.Add(new Vector3(-702.2244f, -2275.315f, 13.45538f));
                    MissionData.VectorList_01.Add(new Vector3(-691.0641f, -2288.052f, 12.27384f));
                    MissionData.VectorList_02.Add(new Vector3(-675.5292f, -2398.912f, 16.1189f));
                    MissionData.VectorList_01.Add(new Vector3(-684.2182f, -2401.862f, 13.94477f));
                    MissionData.VectorList_02.Add(new Vector3(-894.1396f, -2401.645f, 14.02436f));
                    MissionData.VectorList_01.Add(new Vector3(-905.5909f, -2407.064f, 13.35347f));
                }
                else if (iArea == 2)//        "ELYSIAN")
                {
                    MissionData.VectorList_02.Add(new Vector3(-423.3445f, -2788.727f, 6.000384f));
                    MissionData.VectorList_01.Add(new Vector3(-419.82f, -2782.47f, 5.294005f));
                    MissionData.VectorList_02.Add(new Vector3(-301.2311f, -2611.85f, 17.10094f));
                    MissionData.VectorList_01.Add(new Vector3(-303.4613f, -2595.057f, 5.298008f));
                    MissionData.VectorList_02.Add(new Vector3(374.0266f, -2420f, 6.041661f));
                    MissionData.VectorList_01.Add(new Vector3(370.1503f, -2430.4f, 5.335281f));
                    MissionData.VectorList_02.Add(new Vector3(-259.8698f, -2678.943f, 6.355639f));
                    MissionData.VectorList_01.Add(new Vector3(-255.6797f, -2683.559f, 5.293688f));
                    MissionData.VectorList_02.Add(new Vector3(-328.3435f, -2700.521f, 7.549515f));
                    MissionData.VectorList_01.Add(new Vector3(-332.4807f, -2694.783f, 5.321131f));
                    MissionData.VectorList_02.Add(new Vector3(-332.4876f, -2792.459f, 5.00024f));
                    MissionData.VectorList_01.Add(new Vector3(-355.9153f, -2791.711f, 5.294162f));
                    MissionData.VectorList_02.Add(new Vector3(581.9357f, -2723.062f, 7.186927f));
                    MissionData.VectorList_01.Add(new Vector3(582.1222f, -2731.58f, 5.349043f));
                    MissionData.VectorList_02.Add(new Vector3(661.4727f, -2644.04f, 8.406054f));
                    MissionData.VectorList_01.Add(new Vector3(656.2927f, -2658.732f, 5.375378f));
                    MissionData.VectorList_02.Add(new Vector3(308.5914f, -2861.397f, 6.015434f));
                    MissionData.VectorList_01.Add(new Vector3(301.2867f, -2857.547f, 5.317563f));
                    MissionData.VectorList_02.Add(new Vector3(213.5255f, -3077.135f, 7.01534f));
                    MissionData.VectorList_01.Add(new Vector3(212.4372f, -3070.709f, 5.087289f));

                }
                else if (iArea == 3)//        "TERMINA")
                {
                    MissionData.VectorList_02.Add(new Vector3(1240.476f, -3179.404f, 7.104862f));
                    MissionData.VectorList_01.Add(new Vector3(1252.465f, -3172.607f, 5.094413f));
                    MissionData.VectorList_02.Add(new Vector3(1229.969f, -2912.093f, 9.319263f));
                    MissionData.VectorList_01.Add(new Vector3(1215.25f, -2916.509f, 5.159297f));
                    MissionData.VectorList_02.Add(new Vector3(1009.878f, -2893.166f, 11.26011f));
                    MissionData.VectorList_01.Add(new Vector3(1001.554f, -2909.409f, 5.193929f));
                    MissionData.VectorList_02.Add(new Vector3(813.5453f, -2982.219f, 6.020936f));
                    MissionData.VectorList_01.Add(new Vector3(827.9223f, -2976.194f, 5.198393f));
                    MissionData.VectorList_02.Add(new Vector3(1239.33f, -3002.832f, 9.319263f));
                    MissionData.VectorList_01.Add(new Vector3(1216.304f, -2994.296f, 5.358681f));
                    MissionData.VectorList_02.Add(new Vector3(1005.204f, -2891.085f, 11.26011f));
                    MissionData.VectorList_01.Add(new Vector3(1008.078f, -2909.402f, 5.393286f));
                }
                else if (iArea == 4)//        "CYPRE")
                {
                    MissionData.VectorList_02.Add(new Vector3(982.0045f, -1805.02f, 35.48458f));
                    MissionData.VectorList_01.Add(new Vector3(985.834f, -1793.137f, 30.51365f));
                    MissionData.VectorList_02.Add(new Vector3(906.4805f, -1932.75f, 30.62246f));
                    MissionData.VectorList_01.Add(new Vector3(902.3698f, -1935.763f, 29.90796f));
                    MissionData.VectorList_02.Add(new Vector3(938.6974f, -2127.271f, 30.50483f));
                    MissionData.VectorList_01.Add(new Vector3(932.3851f, -2126.394f, 29.60342f));
                    MissionData.VectorList_02.Add(new Vector3(902.7444f, -2273.203f, 32.54755f));
                    MissionData.VectorList_01.Add(new Vector3(910.3268f, -2272.678f, 29.83482f));
                    MissionData.VectorList_02.Add(new Vector3(990.9307f, -2431.029f, 31.24243f));
                    MissionData.VectorList_01.Add(new Vector3(984.599f, -2434.663f, 27.98843f));
                    MissionData.VectorList_02.Add(new Vector3(805.5872f, -2380.521f, 29.0977f));
                    MissionData.VectorList_01.Add(new Vector3(802.0189f, -2380.978f, 28.39072f));
                    MissionData.VectorList_02.Add(new Vector3(703.8163f, -2196.052f, 29.17698f));
                    MissionData.VectorList_01.Add(new Vector3(708.5906f, -2197.963f, 28.48933f));
                    MissionData.VectorList_02.Add(new Vector3(1018.954f, -2511.357f, 28.48421f));
                    MissionData.VectorList_01.Add(new Vector3(1011.88f, -2509.148f, 27.59706f));
                    MissionData.VectorList_02.Add(new Vector3(743.4415f, -1797.433f, 29.29167f));
                    MissionData.VectorList_01.Add(new Vector3(737.1614f, -1796.497f, 28.58462f));

                }
                else if (iArea == 5)//        "EBURO")
                {
                    MissionData.VectorList_02.Add(new Vector3(1258.926f, -1761.398f, 49.67699f));
                    MissionData.VectorList_01.Add(new Vector3(1252.724f, -1749.146f, 46.87161f));
                    MissionData.VectorList_02.Add(new Vector3(1250.658f, -1734.747f, 52.03196f));
                    MissionData.VectorList_01.Add(new Vector3(1261.994f, -1740.818f, 49.06741f));
                    MissionData.VectorList_02.Add(new Vector3(1295.26f, -1739.837f, 54.27173f));
                    MissionData.VectorList_01.Add(new Vector3(1298.471f, -1728.669f, 53.11452f));
                    MissionData.VectorList_02.Add(new Vector3(1289.748f, -1711.345f, 55.27933f));
                    MissionData.VectorList_01.Add(new Vector3(1303.558f, -1708.63f, 54.35196f));
                    MissionData.VectorList_02.Add(new Vector3(1314.942f, -1732.162f, 54.70008f));
                    MissionData.VectorList_01.Add(new Vector3(1316.505f, -1719.276f, 53.91096f));
                    MissionData.VectorList_02.Add(new Vector3(1316.928f, -1699.868f, 57.83794f));
                    MissionData.VectorList_01.Add(new Vector3(1325.958f, -1710.673f, 54.93906f));
                    MissionData.VectorList_02.Add(new Vector3(1365.561f, -1720.873f, 65.63401f));
                    MissionData.VectorList_01.Add(new Vector3(1361.208f, -1706.997f, 60.67844f));
                    MissionData.VectorList_02.Add(new Vector3(1355.67f, -1690.747f, 60.49119f));
                    MissionData.VectorList_01.Add(new Vector3(1360.257f, -1700.94f, 60.10064f));
                    MissionData.VectorList_02.Add(new Vector3(1342.94f, -1579.568f, 54.0538f));
                    MissionData.VectorList_01.Add(new Vector3(1353.538f, -1577.313f, 53.16742f));
                    MissionData.VectorList_02.Add(new Vector3(1411.792f, -1490.745f, 60.65726f));
                    MissionData.VectorList_01.Add(new Vector3(1414.42f, -1502.572f, 59.29406f));
                    MissionData.VectorList_02.Add(new Vector3(1382.07f, -1544.12f, 57.10718f));
                    MissionData.VectorList_01.Add(new Vector3(1378.299f, -1537.098f, 55.76317f));
                    MissionData.VectorList_02.Add(new Vector3(1379.234f, -1515.886f, 58.02826f));
                    MissionData.VectorList_01.Add(new Vector3(1372.943f, -1522.675f, 56.37854f));
                    MissionData.VectorList_02.Add(new Vector3(1360.438f, -1555.744f, 56.34147f));
                    MissionData.VectorList_01.Add(new Vector3(1357.027f, -1544.014f, 53.8348f));
                    MissionData.VectorList_02.Add(new Vector3(1337.987f, -1525.484f, 54.17774f));
                    MissionData.VectorList_01.Add(new Vector3(1340.507f, -1539.055f, 52.13292f));
                    MissionData.VectorList_02.Add(new Vector3(1315.645f, -1526.977f, 51.80762f));
                    MissionData.VectorList_01.Add(new Vector3(1320.099f, -1542.56f, 49.60325f));
                    MissionData.VectorList_02.Add(new Vector3(1326.927f, -1552.963f, 54.05164f));
                    MissionData.VectorList_01.Add(new Vector3(1317.267f, -1553.681f, 49.75652f));
                    MissionData.VectorList_02.Add(new Vector3(1286.392f, -1603.538f, 54.82489f));
                    MissionData.VectorList_01.Add(new Vector3(1280.522f, -1585.16f, 51.23847f));
                    MissionData.VectorList_02.Add(new Vector3(1230.891f, -1591.095f, 53.76609f));
                    MissionData.VectorList_01.Add(new Vector3(1241.029f, -1606.726f, 52.13516f));
                    MissionData.VectorList_02.Add(new Vector3(1244.871f, -1626.249f, 53.28225f));
                    MissionData.VectorList_01.Add(new Vector3(1237.989f, -1615.666f, 51.32797f));
                    MissionData.VectorList_02.Add(new Vector3(1206.614f, -1608.26f, 50.34828f));
                    MissionData.VectorList_01.Add(new Vector3(1219.272f, -1620.496f, 48.36689f));
                    MissionData.VectorList_02.Add(new Vector3(1214.302f, -1643.783f, 48.64599f));
                    MissionData.VectorList_01.Add(new Vector3(1207.69f, -1633.361f, 45.57808f));
                    MissionData.VectorList_02.Add(new Vector3(1193.243f, -1622.892f, 45.22145f));
                    MissionData.VectorList_01.Add(new Vector3(1194.241f, -1636.156f, 42.71461f));
                    MissionData.VectorList_02.Add(new Vector3(1193.184f, -1656.018f, 43.02645f));
                    MissionData.VectorList_01.Add(new Vector3(1187.123f, -1647.503f, 40.10266f));

                }
                else if (iArea == 6)//        "MURRI")
                {
                    MissionData.VectorList_02.Add(new Vector3(1155.98f, -1546.396f, 34.84367f));
                    MissionData.VectorList_01.Add(new Vector3(1154.955f, -1515.225f, 34.10002f));
                    MissionData.VectorList_02.Add(new Vector3(1192.315f, -1248.059f, 39.93959f));
                    MissionData.VectorList_01.Add(new Vector3(1200.000f, -1264.236f, 34.63448f));
                    MissionData.VectorList_02.Add(new Vector3(1165.555f, -1347.332f, 35.96715f));
                    MissionData.VectorList_01.Add(new Vector3(1172.089f, -1347.337f, 34.20704f));
                    MissionData.VectorList_02.Add(new Vector3(1098.399f, -1275.067f, 20.7339f));
                    MissionData.VectorList_01.Add(new Vector3(1097.589f, -1271.286f, 19.56124f));
                    MissionData.VectorList_02.Add(new Vector3(1139.061f, -961.2004f, 47.53792f));
                    MissionData.VectorList_01.Add(new Vector3(1141.401f, -955.7689f, 47.78555f));

                }
                else if (iArea == 7)//        "BANNING")+"STAD")
                {
                    MissionData.VectorList_02.Add(new Vector3(-130.1736f, -2240.337f, 7.989907f));
                    MissionData.VectorList_01.Add(new Vector3(-126.3377f, -2247.762f, 7.219027f));
                    MissionData.VectorList_02.Add(new Vector3(167.6787f, -2222.852f, 7.23611f));
                    MissionData.VectorList_01.Add(new Vector3(169.2989f, -2230.687f, 5.440534f));
                    MissionData.VectorList_02.Add(new Vector3(-179.5384f, -2129.996f, 22.82841f));
                    MissionData.VectorList_01.Add(new Vector3(-160.7402f, -2138.382f, 16.19898f));
                    MissionData.VectorList_02.Add(new Vector3(-305.949f, -2191.671f, 10.83942f));
                    MissionData.VectorList_01.Add(new Vector3(-295.472f, -2186.849f, 9.631311f));
                    MissionData.VectorList_02.Add(new Vector3(-238.3608f, -1899.795f, 27.82936f));
                    MissionData.VectorList_01.Add(new Vector3(-235.4618f, -1862.648f, 28.29552f));
                    MissionData.VectorList_02.Add(new Vector3(-248.779f, -2025.752f, 29.94605f));
                    MissionData.VectorList_01.Add(new Vector3(-228.6881f, -2048.887f, 27.02817f));
                    MissionData.VectorList_02.Add(new Vector3(-236.8143f, -1996.463f, 29.94605f));
                    MissionData.VectorList_01.Add(new Vector3(-206.9641f, -2002.085f, 27.02783f));
                }
                else if (iArea == 8)//        "RANCHO")
                {
                    MissionData.VectorList_02.Add(new Vector3(297.2595f, -2097.519f, 17.66359f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(295.5801f, -2093.154f, 17.66357f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(293.3682f, -2087.566f, 17.66357f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(293.0396f, -2086.144f, 17.66357f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(289.6334f, -2077.022f, 17.66078f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(287.9153f, -2072.455f, 17.66359f));
                    MissionData.VectorList_01.Add(new Vector3(281.283f, -2084.28f, 16.11637f));
                    MissionData.VectorList_02.Add(new Vector3(279.6186f, -2042.905f, 19.76756f));
                    MissionData.VectorList_01.Add(new Vector3(276.5648f, -2033.824f, 17.92848f));
                    MissionData.VectorList_02.Add(new Vector3(280.6062f, -2041.752f, 19.76755f));
                    MissionData.VectorList_01.Add(new Vector3(276.5648f, -2033.824f, 17.92848f));
                    MissionData.VectorList_02.Add(new Vector3(287.0049f, -2034.633f, 19.76756f));
                    MissionData.VectorList_01.Add(new Vector3(276.5648f, -2033.824f, 17.92848f));
                    MissionData.VectorList_02.Add(new Vector3(289.5717f, -2031.132f, 19.76725f));
                    MissionData.VectorList_01.Add(new Vector3(276.5648f, -2033.824f, 17.92848f));
                    MissionData.VectorList_02.Add(new Vector3(313.9517f, -2040.767f, 20.93602f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(317.11f, -2043.383f, 20.93639f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(325.714f, -2050.058f, 20.9364f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(334.11f, -2057.375f, 20.93613f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(342.4112f, -2064.538f, 20.93642f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(345.5887f, -2067.228f, 20.93641f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(357.6005f, -2073.108f, 21.74449f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(364.8902f, -2064.472f, 21.74449f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(371.1835f, -2057.155f, 21.7445f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(364.3695f, -2045.641f, 22.35371f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(360.5106f, -2042.656f, 22.3543f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(353.1429f, -2036.6f, 22.35431f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(351.7538f, -2035.112f, 22.35429f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(344.6013f, -2029.163f, 22.3543f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(343.1128f, -2028.159f, 22.35431f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(335.6897f, -2021.638f, 22.3543f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(332.3005f, -2018.967f, 22.35416f));
                    MissionData.VectorList_01.Add(new Vector3(333.4731f, -2039.357f, 20.45381f));
                    MissionData.VectorList_02.Add(new Vector3(331.4324f, -1981.701f, 24.16728f));
                    MissionData.VectorList_01.Add(new Vector3(320.3594f, -1981.213f, 22.35782f));
                    MissionData.VectorList_02.Add(new Vector3(334.114f, -1978.607f, 24.16728f));
                    MissionData.VectorList_01.Add(new Vector3(320.3594f, -1981.213f, 22.35782f));
                    MissionData.VectorList_02.Add(new Vector3(324.9895f, -1989.26f, 24.16728f));
                    MissionData.VectorList_01.Add(new Vector3(320.3594f, -1981.213f, 22.35782f));
                    MissionData.VectorList_02.Add(new Vector3(383.8976f, -1994.846f, 24.23498f));
                    MissionData.VectorList_01.Add(new Vector3(373.5545f, -1970.037f, 23.65805f));
                    MissionData.VectorList_02.Add(new Vector3(374.5296f, -1991.047f, 24.235f));
                    MissionData.VectorList_01.Add(new Vector3(373.5545f, -1970.037f, 23.65805f));
                    MissionData.VectorList_02.Add(new Vector3(364f, -1987.414f, 24.23451f));
                    MissionData.VectorList_01.Add(new Vector3(373.5545f, -1970.037f, 23.65805f));
                    MissionData.VectorList_02.Add(new Vector3(405.9168f, -1751.467f, 29.71029f));
                    MissionData.VectorList_01.Add(new Vector3(394.1053f, -1743.29f, 28.61055f));
                    MissionData.VectorList_02.Add(new Vector3(430.7849f, -1741f, 29.60396f));
                    MissionData.VectorList_01.Add(new Vector3(423.1591f, -1729.126f, 28.65469f));
                    MissionData.VectorList_02.Add(new Vector3(430.6302f, -1725.376f, 29.60146f));
                    MissionData.VectorList_01.Add(new Vector3(419.5047f, -1713.15f, 28.55581f));
                    MissionData.VectorList_02.Add(new Vector3(443.4339f, -1707.119f, 29.70905f));
                    MissionData.VectorList_01.Add(new Vector3(432.6241f, -1698.296f, 28.5797f));
                    MissionData.VectorList_02.Add(new Vector3(490.0269f, -1714.521f, 29.70519f));
                    MissionData.VectorList_01.Add(new Vector3(502.9299f, -1717.948f, 28.608f));
                    MissionData.VectorList_02.Add(new Vector3(479.9201f, -1736.504f, 29.15102f));
                    MissionData.VectorList_01.Add(new Vector3(477.463f, -1744.357f, 28.29779f));
                    MissionData.VectorList_02.Add(new Vector3(472.2731f, -1774.885f, 29.07085f));
                    MissionData.VectorList_01.Add(new Vector3(479.7751f, -1776.714f, 27.98321f));
                    MissionData.VectorList_02.Add(new Vector3(513.6623f, -1780.66f, 28.91397f));
                    MissionData.VectorList_01.Add(new Vector3(500.4468f, -1782.357f, 27.80231f));
                    MissionData.VectorList_02.Add(new Vector3(495.4278f, -1823.095f, 28.86971f));
                    MissionData.VectorList_01.Add(new Vector3(484.5051f, -1813.766f, 27.56089f));
                    MissionData.VectorList_02.Add(new Vector3(368.6719f, -1896.409f, 25.17853f));
                    MissionData.VectorList_01.Add(new Vector3(380.2398f, -1906.966f, 24.08315f));
                    MissionData.VectorList_02.Add(new Vector3(385.4476f, -1881.849f, 26.03137f));
                    MissionData.VectorList_01.Add(new Vector3(396.2569f, -1891.434f, 24.66819f));
                    MissionData.VectorList_02.Add(new Vector3(399.448f, -1864.953f, 26.71635f));
                    MissionData.VectorList_01.Add(new Vector3(411.071f, -1877.123f, 25.58627f));
                    MissionData.VectorList_02.Add(new Vector3(427.4836f, -1841.994f, 28.46345f));
                    MissionData.VectorList_01.Add(new Vector3(434.6688f, -1854.25f, 26.93241f));
                    MissionData.VectorList_02.Add(new Vector3(440.0391f, -1830.395f, 28.36186f));
                    MissionData.VectorList_01.Add(new Vector3(448.5591f, -1841.51f, 27.25047f));
                    MissionData.VectorList_02.Add(new Vector3(349.0762f, -1820.522f, 28.8941f));
                    MissionData.VectorList_01.Add(new Vector3(346.9402f, -1807.412f, 27.83603f));
                    MissionData.VectorList_02.Add(new Vector3(328.6295f, -1845.301f, 27.74807f));
                    MissionData.VectorList_01.Add(new Vector3(316.558f, -1835.695f, 26.40304f));
                    MissionData.VectorList_02.Add(new Vector3(269.8459f, -1916.823f, 26.18237f));
                    MissionData.VectorList_01.Add(new Vector3(258.692f, -1905.442f, 25.32743f));
                    MissionData.VectorList_02.Add(new Vector3(250.4847f, -1935.005f, 24.69927f));
                    MissionData.VectorList_01.Add(new Vector3(238.5349f, -1929.15f, 23.39324f));
                    MissionData.VectorList_02.Add(new Vector3(324.2186f, -1938.26f, 25.01898f));
                    MissionData.VectorList_01.Add(new Vector3(335.2216f, -1950.085f, 23.79116f));
                    MissionData.VectorList_02.Add(new Vector3(295.8637f, -1972.111f, 22.90082f));
                    MissionData.VectorList_01.Add(new Vector3(306.892f, -1983.827f, 21.45563f));
                    MissionData.VectorList_02.Add(new Vector3(280.3494f, -1993.836f, 20.8038f));
                    MissionData.VectorList_01.Add(new Vector3(292.5224f, -2000.789f, 19.75769f));
                    MissionData.VectorList_02.Add(new Vector3(256.7441f, -2023.586f, 19.26635f));
                    MissionData.VectorList_01.Add(new Vector3(268.5673f, -2030.575f, 17.92979f));

                }
                else if (iArea == 9)//        "DAVIS")
                {
                    MissionData.VectorList_02.Add(new Vector3(-50.39761f, -1783.597f, 28.30082f));
                    MissionData.VectorList_01.Add(new Vector3(-57.99997f, -1797.434f, 26.75445f));
                    MissionData.VectorList_02.Add(new Vector3(-20.35306f, -1858.548f, 25.40867f));
                    MissionData.VectorList_01.Add(new Vector3(-12.61712f, -1846.052f, 24.31055f));
                    MissionData.VectorList_02.Add(new Vector3(-10.39145f, -1883.942f, 24.14204f));
                    MissionData.VectorList_01.Add(new Vector3(1.918285f, -1876.412f, 23.1049f));
                    MissionData.VectorList_02.Add(new Vector3(5.216082f, -1884.246f, 23.69726f));
                    MissionData.VectorList_01.Add(new Vector3(16.6125f, -1871.542f, 22.67904f));
                    MissionData.VectorList_02.Add(new Vector3(45.92031f, -1864.545f, 23.27833f));
                    MissionData.VectorList_01.Add(new Vector3(31.95667f, -1873.358f, 22.1308f));
                    MissionData.VectorList_02.Add(new Vector3(23.177f, -1896.414f, 22.96589f));
                    MissionData.VectorList_01.Add(new Vector3(34.17988f, -1886.511f, 21.71531f));
                    MissionData.VectorList_02.Add(new Vector3(54.39722f, -1873.642f, 22.80583f));
                    MissionData.VectorList_01.Add(new Vector3(52.75089f, -1878.867f, 21.62855f));
                    MissionData.VectorList_02.Add(new Vector3(39.40047f, -1911.863f, 21.9535f));
                    MissionData.VectorList_01.Add(new Vector3(53.0804f, -1901.614f, 20.94305f));
                    MissionData.VectorList_02.Add(new Vector3(76.59599f, -1948.475f, 21.17416f));
                    MissionData.VectorList_01.Add(new Vector3(91.37643f, -1935.88f, 20.10258f));
                    MissionData.VectorList_02.Add(new Vector3(85.55811f, -1958.879f, 21.12167f));
                    MissionData.VectorList_01.Add(new Vector3(98.82529f, -1948.292f, 20.11119f));
                    MissionData.VectorList_02.Add(new Vector3(114.092f, -1961.006f, 21.33425f));
                    MissionData.VectorList_01.Add(new Vector3(107.2141f, -1949.395f, 20.13007f));
                    MissionData.VectorList_02.Add(new Vector3(100.4846f, -1912.679f, 21.40742f));
                    MissionData.VectorList_01.Add(new Vector3(93.13752f, -1924.911f, 20.08893f));
                    MissionData.VectorList_02.Add(new Vector3(104.29f, -1885.105f, 24.31878f));
                    MissionData.VectorList_01.Add(new Vector3(106.311f, -1878.515f, 23.34496f));
                    MissionData.VectorList_02.Add(new Vector3(130.2774f, -1853.328f, 25.23479f));
                    MissionData.VectorList_01.Add(new Vector3(124.8095f, -1868.742f, 23.66036f));
                    MissionData.VectorList_02.Add(new Vector3(128.0303f, -1896.44f, 23.6742f));
                    MissionData.VectorList_01.Add(new Vector3(137.0386f, -1882.512f, 22.94671f));
                    MissionData.VectorList_02.Add(new Vector3(171.1915f, -1871.533f, 24.40023f));
                    MissionData.VectorList_01.Add(new Vector3(162.018f, -1884.568f, 23.05028f));
                    MissionData.VectorList_02.Add(new Vector3(192.1942f, -1883.464f, 25.05676f));
                    MissionData.VectorList_01.Add(new Vector3(185.4829f, -1895.689f, 23.09596f));
                    MissionData.VectorList_02.Add(new Vector3(179.1025f, -1924.555f, 21.37102f));
                    MissionData.VectorList_01.Add(new Vector3(175.1854f, -1934.801f, 20.40962f));
                    MissionData.VectorList_02.Add(new Vector3(149.0806f, -1960.494f, 19.45883f));
                    MissionData.VectorList_01.Add(new Vector3(160.0891f, -1971.575f, 17.89874f));

                }
                else if (iArea == 10)//        "LOSPUER"){  (MyZone == "DELSOL")
                {
                    MissionData.VectorList_02.Add(new Vector3(-1040.85f, -1475.032f, 5.57517f));
                    MissionData.VectorList_01.Add(new Vector3(-1047.524f, -1466.829f, 4.423398f));
                    MissionData.VectorList_02.Add(new Vector3(-1038.237f, -1396.715f, 5.553193f));
                    MissionData.VectorList_01.Add(new Vector3(-1048.505f, -1398.825f, 4.83193f));
                    MissionData.VectorList_02.Add(new Vector3(-822.8834f, -1222.964f, 7.36541f));
                    MissionData.VectorList_01.Add(new Vector3(-828.3438f, -1216.498f, 6.34208f));
                    MissionData.VectorList_02.Add(new Vector3(-783.1737f, -1351.898f, 8.99978f));
                    MissionData.VectorList_01.Add(new Vector3(-783.9278f, -1333.898f, 4.407724f));
                    MissionData.VectorList_02.Add(new Vector3(-753.3792f, -1511.745f, 5.016343f));
                    MissionData.VectorList_01.Add(new Vector3(-753.189f, -1501.009f, 4.408158f));
                    MissionData.VectorList_02.Add(new Vector3(-499.4994f, -1714.084f, 19.89919f));
                    MissionData.VectorList_01.Add(new Vector3(-508.1526f, -1720.533f, 18.72518f));
                    MissionData.VectorList_02.Add(new Vector3(-621.099f, -1640.762f, 25.97497f));
                    MissionData.VectorList_01.Add(new Vector3(-625.2062f, -1645.418f, 25.23293f));

                }
                else if (iArea == 11)//        "CHAMH")
                {
                    MissionData.VectorList_02.Add(new Vector3(-212.6789f, -1669.577f, 34.4632f));
                    MissionData.VectorList_01.Add(new Vector3(-187.9321f, -1672.19f, 32.86395f));
                    MissionData.VectorList_02.Add(new Vector3(-213.5734f, -1608.434f, 34.86931f));
                    MissionData.VectorList_01.Add(new Vector3(-186.8391f, -1607.341f, 33.37147f));
                    MissionData.VectorList_02.Add(new Vector3(-170.9348f, -1538.064f, 35.1156f));
                    MissionData.VectorList_01.Add(new Vector3(-148.8884f, -1552.597f, 34.02704f));
                    MissionData.VectorList_02.Add(new Vector3(-117.0381f, -1477.216f, 33.8227f));
                    MissionData.VectorList_01.Add(new Vector3(-133.6183f, -1500.327f, 33.46594f));
                    MissionData.VectorList_02.Add(new Vector3(-158.1097f, -1680.082f, 33.83337f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-141.8925f, -1693.16f, 32.87245f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-147.9179f, -1688.423f, 32.87242f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-142.2503f, -1693.109f, 36.1673f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-147.5f, -1688.599f, 36.16715f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-158.2306f, -1679.633f, 36.96638f));
                    MissionData.VectorList_01.Add(new Vector3(-163.4962f, -1701.08f, 30.80787f));
                    MissionData.VectorList_02.Add(new Vector3(-116.7299f, -1660.611f, 32.56437f));
                    MissionData.VectorList_01.Add(new Vector3(-101.5155f, -1679.808f, 28.62062f));
                    MissionData.VectorList_02.Add(new Vector3(-80.86539f, -1612.877f, 31.48242f));
                    MissionData.VectorList_01.Add(new Vector3(-59.22719f, -1629.017f, 28.62579f));
                    MissionData.VectorList_02.Add(new Vector3(-138.0755f, -1590.171f, 34.24369f));
                    MissionData.VectorList_01.Add(new Vector3(-158.3103f, -1577.135f, 34.18251f));

                }
                else if (iArea == 12)//        "STRAW")
                {
                    MissionData.VectorList_02.Add(new Vector3(20.65767f, -1506.336f, 31.85014f));
                    MissionData.VectorList_01.Add(new Vector3(12.1674f, -1519.459f, 28.89222f));
                    MissionData.VectorList_02.Add(new Vector3(-295.9617f, -1342.609f, 31.31202f));
                    MissionData.VectorList_01.Add(new Vector3(-289.9343f, -1345.626f, 30.58545f));
                    MissionData.VectorList_02.Add(new Vector3(-121.1603f, -1290.486f, 29.3136f));
                    MissionData.VectorList_01.Add(new Vector3(-113.7367f, -1291.787f, 28.59361f));
                    MissionData.VectorList_02.Add(new Vector3(87.13698f, -1295.678f, 29.20869f));
                    MissionData.VectorList_01.Add(new Vector3(81.75984f, -1302.132f, 28.60637f));
                    MissionData.VectorList_02.Add(new Vector3(-32.69242f, -1446.294f, 31.89136f));
                    MissionData.VectorList_01.Add(new Vector3(-38.02354f, -1450.038f, 30.98904f));
                    MissionData.VectorList_02.Add(new Vector3(-64.27878f, -1449.677f, 32.52492f));
                    MissionData.VectorList_01.Add(new Vector3(-63.81673f, -1462.527f, 31.47367f));
                    MissionData.VectorList_02.Add(new Vector3(-83.0243f, -1399.693f, 29.32075f));
                    MissionData.VectorList_01.Add(new Vector3(-80.07758f, -1405.342f, 28.81458f));
                    MissionData.VectorList_02.Add(new Vector3(53.03144f, -1479.529f, 29.27781f));
                    MissionData.VectorList_01.Add(new Vector3(68.60536f, -1476.826f, 28.69232f));
                }
                else //        "LMESA")
                {
                    MissionData.VectorList_02.Add(new Vector3(792.9578f, -735.9182f, 27.56665f));
                    MissionData.VectorList_01.Add(new Vector3(781.3509f, -749.787f, 26.57809f));
                    MissionData.VectorList_02.Add(new Vector3(895.0829f, -896.4345f, 27.78768f));
                    MissionData.VectorList_01.Add(new Vector3(886.1035f, -903.9097f, 25.76367f));
                    MissionData.VectorList_02.Add(new Vector3(871.4327f, -1146.561f, 25.98947f));
                    MissionData.VectorList_01.Add(new Vector3(866.3556f, -1155.935f, 23.91385f));
                    MissionData.VectorList_02.Add(new Vector3(826.7053f, -1289.793f, 28.24066f));
                    MissionData.VectorList_01.Add(new Vector3(808.5062f, -1289.575f, 25.62454f));
                    MissionData.VectorList_02.Add(new Vector3(830.7275f, -1054.169f, 28.66163f));
                    MissionData.VectorList_01.Add(new Vector3(825.2499f, -1066.779f, 27.53641f));
                    MissionData.VectorList_02.Add(new Vector3(844.934f, -851.4561f, 26.54606f));
                    MissionData.VectorList_01.Add(new Vector3(828.899f, -839.3197f, 25.84308f));
                    MissionData.VectorList_02.Add(new Vector3(793.6158f, -735.8035f, 27.74888f));
                    MissionData.VectorList_01.Add(new Vector3(784.0593f, -737.003f, 27.11176f));
                }

            }
            else if (Local == 2)
            {
                if (bRandom)
                    iArea = RandInt(1, 17);

                if (iArea == 1)//        "SKID" 
                {
                    MissionData.VectorList_02.Add(new Vector3(354.2527f, -1028.431f, 29.33105f));
                    MissionData.VectorList_01.Add(new Vector3(357.0464f, -1036.737f, 28.64928f));
                    MissionData.VectorList_02.Add(new Vector3(433.7992f, -982.1172f, 30.70951f));
                    MissionData.VectorList_01.Add(new Vector3(402.9555f, -983.3735f, 28.84099f));
                    MissionData.VectorList_02.Add(new Vector3(396.8822f, -1169.79f, 29.29176f));
                    MissionData.VectorList_01.Add(new Vector3(397.0258f, -1158.473f, 28.7617f));
                    MissionData.VectorList_02.Add(new Vector3(417.872f, -767.4501f, 29.41702f));
                    MissionData.VectorList_01.Add(new Vector3(409.3581f, -768.8823f, 28.73415f));
                    MissionData.VectorList_02.Add(new Vector3(391.4617f, -930.6711f, 29.41866f));
                    MissionData.VectorList_01.Add(new Vector3(399.9209f, -926.3832f, 28.82933f));
                    MissionData.VectorList_02.Add(new Vector3(377.8676f, -999.1207f, 29.45313f));
                    MissionData.VectorList_01.Add(new Vector3(395.0699f, -1009.7f, 28.8324f));
                }
                else if (iArea == 2)//        "LEGSQU" 
                {
                    MissionData.VectorList_02.Add(new Vector3(177.0969f, -979.6016f, 29.99313f));
                    MissionData.VectorList_01.Add(new Vector3(168.3188f, -1010.917f, 28.80831f));
                    MissionData.VectorList_02.Add(new Vector3(104.949f, -932.8635f, 29.81259f));
                    MissionData.VectorList_01.Add(new Vector3(116.4733f, -936.0852f, 29.14896f));
                    MissionData.VectorList_02.Add(new Vector3(184.9182f, -887.6499f, 31.11672f));
                    MissionData.VectorList_01.Add(new Vector3(171.2225f, -871.0737f, 29.9788f));
                    MissionData.VectorList_02.Add(new Vector3(273.7766f, -833.3542f, 29.41132f));
                    MissionData.VectorList_01.Add(new Vector3(264.5758f, -838.8533f, 28.76188f));
                    MissionData.VectorList_02.Add(new Vector3(287.8855f, -919.9745f, 29.29419f));
                    MissionData.VectorList_01.Add(new Vector3(277.9113f, -922.6801f, 28.36518f));
                }
                else if (iArea == 3)//        "TEXTI"  
                {
                    MissionData.VectorList_02.Add(new Vector3(458.9576f, -853.5832f, 27.33997f));
                    MissionData.VectorList_01.Add(new Vector3(470.0547f, -829.0839f, 25.8446f));
                    MissionData.VectorList_02.Add(new Vector3(460.754f, -769.7076f, 27.3578f));
                    MissionData.VectorList_01.Add(new Vector3(455.3673f, -763.0317f, 26.82866f));
                    MissionData.VectorList_02.Add(new Vector3(394.7988f, -711.6652f, 29.28482f));
                    MissionData.VectorList_01.Add(new Vector3(401.2914f, -712.3533f, 28.64416f));
                    MissionData.VectorList_02.Add(new Vector3(418.4028f, -767.5741f, 29.42775f));
                    MissionData.VectorList_01.Add(new Vector3(410.084f, -769.1244f, 28.67112f));
                    MissionData.VectorList_02.Add(new Vector3(494.0114f, -571.1681f, 24.55081f));
                    MissionData.VectorList_01.Add(new Vector3(504.4706f, -581.2975f, 24.25294f));
                }
                else if (iArea == 4)//        "PBOX"   
                {
                    MissionData.VectorList_02.Add(new Vector3(-115.7897f, -603.7586f, 36.28072f));
                    MissionData.VectorList_01.Add(new Vector3(-106.2625f, -608.1697f, 35.52522f));
                    MissionData.VectorList_02.Add(new Vector3(-66.73456f, -801.8816f, 44.22729f));
                    MissionData.VectorList_01.Add(new Vector3(-51.92704f, -784.653f, 43.60859f));
                    MissionData.VectorList_02.Add(new Vector3(7.609715f, -706.3086f, 45.97303f));
                    MissionData.VectorList_01.Add(new Vector3(35.64244f, -715.6297f, 43.52236f));
                    MissionData.VectorList_02.Add(new Vector3(110.041f, -637.1196f, 44.24202f));
                    MissionData.VectorList_01.Add(new Vector3(96.78452f, -633.0899f, 43.6225f));
                    MissionData.VectorList_02.Add(new Vector3(92.1524f, -741.7303f, 45.75599f));
                    MissionData.VectorList_01.Add(new Vector3(58.26967f, -741.9115f, 43.56817f));
                    MissionData.VectorList_02.Add(new Vector3(-97.36321f, -1014.177f, 27.27522f));
                    MissionData.VectorList_01.Add(new Vector3(-97.16437f, -1020.443f, 26.74354f));
                    MissionData.VectorList_02.Add(new Vector3(-177.6473f, -1158.428f, 23.81366f));
                    MissionData.VectorList_01.Add(new Vector3(-176.7727f, -1149.438f, 22.50645f));
                    MissionData.VectorList_02.Add(new Vector3(-286.7964f, -1060.97f, 27.20541f));
                    MissionData.VectorList_01.Add(new Vector3(-277.104f, -1064.466f, 25.28302f));
                    MissionData.VectorList_02.Add(new Vector3(-210.6174f, -1021.075f, 30.1405f));
                    MissionData.VectorList_01.Add(new Vector3(-215.2424f, -1005.848f, 28.64495f));
                    MissionData.VectorList_02.Add(new Vector3(-232.0792f, -915.1109f, 32.31084f));
                    MissionData.VectorList_01.Add(new Vector3(-211.4211f, -921.6801f, 28.6483f));
                    MissionData.VectorList_02.Add(new Vector3(-185.1166f, -788.0728f, 30.45403f));
                    MissionData.VectorList_01.Add(new Vector3(-165.662f, -797.7302f, 31.10581f));
                    MissionData.VectorList_02.Add(new Vector3(102.106f, -818.2697f, 31.34554f));
                    MissionData.VectorList_01.Add(new Vector3(105.2083f, -807.3613f, 30.75293f));
                    MissionData.VectorList_02.Add(new Vector3(5.52696f, -984.9729f, 29.3564f));
                    MissionData.VectorList_01.Add(new Vector3(8.179337f, -971.4874f, 28.87354f));
                    MissionData.VectorList_02.Add(new Vector3(43.79702f, -998.0366f, 29.33619f));
                    MissionData.VectorList_01.Add(new Vector3(48.0556f, -993.5015f, 28.70993f));
                }
                else if (iArea == 5)//        "DTVINE"  
                {
                    MissionData.VectorList_02.Add(new Vector3(58.5491f, 224.3279f, 109.3446f));
                    MissionData.VectorList_01.Add(new Vector3(60.29726f, 236.8945f, 108.9385f));
                    MissionData.VectorList_02.Add(new Vector3(285.691f, 200.2816f, 104.3727f));
                    MissionData.VectorList_01.Add(new Vector3(291.9229f, 176.447f, 103.5972f));
                    MissionData.VectorList_02.Add(new Vector3(339.964f, 179.0237f, 103.0279f));
                    MissionData.VectorList_01.Add(new Vector3(333.5558f, 160.7843f, 102.7396f));
                    MissionData.VectorList_02.Add(new Vector3(299.9526f, 135.8692f, 104.1121f));
                    MissionData.VectorList_01.Add(new Vector3(304.2964f, 145.2028f, 103.1819f));
                    MissionData.VectorList_02.Add(new Vector3(220.6625f, 304.7425f, 105.5735f));
                    MissionData.VectorList_01.Add(new Vector3(232.6737f, 301.8434f, 105.0194f));
                    MissionData.VectorList_02.Add(new Vector3(80.90257f, 273.1755f, 110.2102f));
                    MissionData.VectorList_01.Add(new Vector3(80.73256f, 268.3891f, 109.1223f));
                    MissionData.VectorList_02.Add(new Vector3(225.0676f, 336.988f, 105.6021f));
                    MissionData.VectorList_01.Add(new Vector3(231.3641f, 346.6825f, 104.9356f));
                    MissionData.VectorList_02.Add(new Vector3(511.6814f, 228.5841f, 104.7448f));
                    MissionData.VectorList_01.Add(new Vector3(525.1632f, 253.7698f, 102.4465f));
                    MissionData.VectorList_02.Add(new Vector3(554.7083f, 150.9967f, 99.23253f));
                    MissionData.VectorList_01.Add(new Vector3(543.8952f, 150.5306f, 98.23286f));
                    MissionData.VectorList_02.Add(new Vector3(538.4095f, 101.4291f, 96.52667f));
                    MissionData.VectorList_01.Add(new Vector3(528.6589f, 105.3687f, 95.66783f));
                    MissionData.VectorList_02.Add(new Vector3(619.7996f, 18.79947f, 87.9332f));
                    MissionData.VectorList_01.Add(new Vector3(624.3416f, 30.71176f, 87.93405f));
                }
                else if (iArea == 6)//        "KOREAT" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-491.3341f, -705.1888f, 29.66495f));
                    MissionData.VectorList_01.Add(new Vector3(-492.4659f, -668.1738f, 32.25398f));
                    MissionData.VectorList_02.Add(new Vector3(-818.8256f, -575.5591f, 30.27625f));
                    MissionData.VectorList_01.Add(new Vector3(-805.1441f, -569.605f, 29.59624f));
                    MissionData.VectorList_02.Add(new Vector3(-1006.886f, -729.0814f, 21.52976f));
                    MissionData.VectorList_01.Add(new Vector3(-1012.787f, -720.1366f, 20.16511f));
                    MissionData.VectorList_02.Add(new Vector3(-796.8664f, -684.7003f, 29.54898f));
                    MissionData.VectorList_01.Add(new Vector3(-800.4079f, -667.2416f, 27.86353f));
                    MissionData.VectorList_02.Add(new Vector3(-668.2699f, -971.0567f, 22.34084f));
                    MissionData.VectorList_01.Add(new Vector3(-670.9226f, -961.2521f, 20.42223f));
                    MissionData.VectorList_02.Add(new Vector3(-667.4276f, -1105.683f, 14.68489f));
                    MissionData.VectorList_01.Add(new Vector3(-677.4309f, -1101.269f, 13.99504f));
                    MissionData.VectorList_02.Add(new Vector3(-699.7384f, -1032.83f, 16.10666f));
                    MissionData.VectorList_01.Add(new Vector3(-689.7061f, -1054.854f, 14.72245f));
                    MissionData.VectorList_02.Add(new Vector3(-759.088f, -1047.608f, 13.5029f));
                    MissionData.VectorList_01.Add(new Vector3(-744.5236f, -1048.969f, 11.68449f));
                    MissionData.VectorList_02.Add(new Vector3(-601.835f, -1127.903f, 22.32424f));
                    MissionData.VectorList_01.Add(new Vector3(-589.35f, -1129.539f, 21.64803f));
                    MissionData.VectorList_02.Add(new Vector3(-729.3005f, -879.8181f, 22.71092f));
                    MissionData.VectorList_01.Add(new Vector3(-740.5681f, -876.4502f, 21.08265f));
                    MissionData.VectorList_02.Add(new Vector3(-693.7856f, -810.1913f, 24.01492f));
                    MissionData.VectorList_01.Add(new Vector3(-691.8843f, -826.7587f, 23.26679f));
                    MissionData.VectorList_02.Add(new Vector3(-471.3071f, -865.2595f, 23.96403f));
                    MissionData.VectorList_01.Add(new Vector3(-472.2751f, -872.899f, 23.29834f));
                    MissionData.VectorList_02.Add(new Vector3(-598.7448f, -930.2391f, 23.86363f));
                    MissionData.VectorList_01.Add(new Vector3(-603.0508f, -953.1522f, 21.49878f));
                    MissionData.VectorList_02.Add(new Vector3(-546.7633f, -810.2938f, 30.7459f));
                    MissionData.VectorList_01.Add(new Vector3(-549.5628f, -827.8044f, 27.73886f));
                    MissionData.VectorList_02.Add(new Vector3(-580.7145f, -778.4678f, 25.01723f));
                    MissionData.VectorList_01.Add(new Vector3(-616.8736f, -778.3973f, 24.68242f));
                }
                else if (iArea == 7)//        "VCANA"   
                {
                    MissionData.VectorList_02.Add(new Vector3(-951.0064f, -905.6769f, 2.745484f));
                    MissionData.VectorList_01.Add(new Vector3(-948.0278f, -898.9374f, 1.633701f));
                    MissionData.VectorList_02.Add(new Vector3(-947.7943f, -927.8657f, 2.14531f));
                    MissionData.VectorList_01.Add(new Vector3(-938.8552f, -926.405f, 1.61489f));
                    MissionData.VectorList_02.Add(new Vector3(-927.522f, -949.3549f, 2.746102f));
                    MissionData.VectorList_01.Add(new Vector3(-920.4854f, -950.0219f, 1.63327f));
                    MissionData.VectorList_02.Add(new Vector3(-864.665f, -1101.799f, 6.447026f));
                    MissionData.VectorList_01.Add(new Vector3(-852.7875f, -1096.924f, 1.632867f));
                    MissionData.VectorList_02.Add(new Vector3(-1035.512f, -1227.947f, 6.346426f));
                    MissionData.VectorList_01.Add(new Vector3(-1039.014f, -1234.404f, 5.340991f));
                    MissionData.VectorList_02.Add(new Vector3(-1126.493f, -1172.118f, 2.357592f));
                    MissionData.VectorList_01.Add(new Vector3(-1132.724f, -1174f, 1.654989f));
                    MissionData.VectorList_02.Add(new Vector3(-1136.023f, -1153.578f, 2.744121f));
                    MissionData.VectorList_01.Add(new Vector3(-1144.977f, -1154.373f, 2.274264f));
                    MissionData.VectorList_02.Add(new Vector3(-1143.087f, -1144.126f, 2.853676f));
                    MissionData.VectorList_01.Add(new Vector3(-1148.846f, -1145.358f, 2.308584f));
                    MissionData.VectorList_02.Add(new Vector3(-1183.264f, -1064.341f, 2.150421f));
                    MissionData.VectorList_01.Add(new Vector3(-1188.896f, -1065.672f, 1.620275f));
                    MissionData.VectorList_02.Add(new Vector3(-1191.291f, -1054.983f, 2.150431f));
                    MissionData.VectorList_01.Add(new Vector3(-1197.972f, -1056.369f, 1.621082f));
                    MissionData.VectorList_02.Add(new Vector3(-1195.782f, -1036.116f, 2.167662f));
                    MissionData.VectorList_01.Add(new Vector3(-1205.348f, -1040.543f, 1.62129f));
                    MissionData.VectorList_02.Add(new Vector3(-1201.187f, -1032.25f, 2.150407f));
                    MissionData.VectorList_01.Add(new Vector3(-1206.196f, -1032.939f, 1.620837f));
                    MissionData.VectorList_02.Add(new Vector3(-1090.517f, -925.978f, 3.145119f));
                    MissionData.VectorList_01.Add(new Vector3(-1095.53f, -918.2084f, 2.423995f));
                    MissionData.VectorList_02.Add(new Vector3(-1031.229f, -902.9789f, 3.69277f));
                    MissionData.VectorList_01.Add(new Vector3(-1036.207f, -898.7838f, 3.906092f));
                    MissionData.VectorList_02.Add(new Vector3(-1022.78f, -896.4982f, 5.418818f));
                    MissionData.VectorList_01.Add(new Vector3(-1024.35f, -889.9529f, 5.115498f));
                    MissionData.VectorList_02.Add(new Vector3(-1116.821f, -895.3629f, 7.796868f));
                    MissionData.VectorList_01.Add(new Vector3(-1104.145f, -913.7859f, 2.350959f));
                    MissionData.VectorList_02.Add(new Vector3(-1151.271f, -913.3595f, 6.628776f));
                    MissionData.VectorList_01.Add(new Vector3(-1139.727f, -927.0404f, 2.08931f));
                    MissionData.VectorList_02.Add(new Vector3(-1179.832f, -929.8004f, 6.628771f));
                    MissionData.VectorList_01.Add(new Vector3(-1174.866f, -945.9295f, 2.647262f));
                    MissionData.VectorList_02.Add(new Vector3(-1075.694f, -1026.807f, 4.545152f));
                    MissionData.VectorList_01.Add(new Vector3(-1068.656f, -1021.217f, 1.508651f));
                    MissionData.VectorList_02.Add(new Vector3(-1108.508f, -1041.39f, 2.150356f));
                    MissionData.VectorList_01.Add(new Vector3(-1107.058f, -1048.322f, 1.620899f));
                    MissionData.VectorList_02.Add(new Vector3(-1122.273f, -1046.655f, 2.150357f));
                    MissionData.VectorList_01.Add(new Vector3(-1121.254f, -1052.749f, 1.621226f));
                    MissionData.VectorList_02.Add(new Vector3(-1127.787f, -1081.126f, 4.222689f));
                    MissionData.VectorList_01.Add(new Vector3(-1133.471f, -1071.877f, 1.57613f));
                    MissionData.VectorList_02.Add(new Vector3(-1114.697f, -1069.593f, 2.150359f));
                    MissionData.VectorList_01.Add(new Vector3(-1122.547f, -1065.817f, 1.533568f));
                    MissionData.VectorList_02.Add(new Vector3(-1068.539f, -1049.219f, 6.411661f));
                    MissionData.VectorList_01.Add(new Vector3(-1071.924f, -1038.167f, 1.585658f));
                    MissionData.VectorList_02.Add(new Vector3(-1022.088f, -1022.706f, 2.150359f));
                    MissionData.VectorList_01.Add(new Vector3(-1024.648f, -1013.672f, 1.609797f));
                    MissionData.VectorList_02.Add(new Vector3(-1008.787f, -1014.9f, 2.150308f));
                    MissionData.VectorList_01.Add(new Vector3(-1010.491f, -1007.871f, 1.620196f));
                    MissionData.VectorList_02.Add(new Vector3(-990.2632f, -975.8735f, 4.222694f));
                    MissionData.VectorList_01.Add(new Vector3(-984.612f, -983.4828f, 1.519559f));
                    MissionData.VectorList_02.Add(new Vector3(-1022.818f, -998.0176f, 2.150195f));
                    MissionData.VectorList_01.Add(new Vector3(-1014.343f, -1000.667f, 1.580476f));
                    MissionData.VectorList_02.Add(new Vector3(-1053.879f, -1006.539f, 2.150193f));
                    MissionData.VectorList_01.Add(new Vector3(-1049.045f, -1018.238f, 1.620131f));
                    MissionData.VectorList_02.Add(new Vector3(-1068.322f, -1163.15f, 2.745448f));
                    MissionData.VectorList_01.Add(new Vector3(-1071.766f, -1158.873f, 1.581696f));
                    MissionData.VectorList_02.Add(new Vector3(-1046.051f, -1159.626f, 2.158599f));
                    MissionData.VectorList_01.Add(new Vector3(-1047.434f, -1150.759f, 1.629194f));
                    MissionData.VectorList_02.Add(new Vector3(-1035.156f, -1129.51f, 2.158599f));
                    MissionData.VectorList_01.Add(new Vector3(-1035.165f, -1136.228f, 1.53474f));
                    MissionData.VectorList_02.Add(new Vector3(-1034.903f, -1147.1f, 2.158599f));
                    MissionData.VectorList_01.Add(new Vector3(-1042.317f, -1143.031f, 1.560673f));
                    MissionData.VectorList_02.Add(new Vector3(-1024.528f, -1139.903f, 2.745337f));
                    MissionData.VectorList_01.Add(new Vector3(-1025.213f, -1134.372f, 1.653199f));
                    MissionData.VectorList_02.Add(new Vector3(-942.9496f, -1075.458f, 2.745272f));
                    MissionData.VectorList_01.Add(new Vector3(-937.7101f, -1079.082f, 1.564626f));
                    MissionData.VectorList_02.Add(new Vector3(-952.4178f, -1077.698f, 2.671045f));
                    MissionData.VectorList_01.Add(new Vector3(-949.9753f, -1082.455f, 1.620425f));
                    MissionData.VectorList_02.Add(new Vector3(-948.5066f, -1107.555f, 2.171847f));
                    MissionData.VectorList_01.Add(new Vector3(-952.9219f, -1093.12f, 1.620167f));
                    MissionData.VectorList_02.Add(new Vector3(-960.0089f, -1109.859f, 2.150314f));
                    MissionData.VectorList_01.Add(new Vector3(-962.6642f, -1101.267f, 1.620263f));
                    MissionData.VectorList_02.Add(new Vector3(-976.8805f, -1092.348f, 4.22256f));
                    MissionData.VectorList_01.Add(new Vector3(-970.9733f, -1099.311f, 1.592695f));
                    MissionData.VectorList_02.Add(new Vector3(-991.6511f, -1103.455f, 2.150309f));
                    MissionData.VectorList_01.Add(new Vector3(-983.785f, -1106.11f, 1.490934f));
                    MissionData.VectorList_02.Add(new Vector3(-986.5675f, -1121.498f, 4.545396f));
                    MissionData.VectorList_01.Add(new Vector3(-993.0151f, -1115.217f, 1.615117f));
                }
                else if (iArea == 8)//        "VESP"   
                {
                    MissionData.VectorList_02.Add(new Vector3(-1247.026f, -1358.836f, 7.820425f));
                    MissionData.VectorList_01.Add(new Vector3(-1239.632f, -1355.699f, 3.180847f));
                    MissionData.VectorList_02.Add(new Vector3(-1272.103f, -1295.553f, 8.285895f));
                    MissionData.VectorList_01.Add(new Vector3(-1258.842f, -1302.896f, 3.152466f));
                    MissionData.VectorList_02.Add(new Vector3(-1237.916f, -1238.131f, 11.02771f));
                    MissionData.VectorList_01.Add(new Vector3(-1251.62f, -1239.837f, 5.372354f));
                    MissionData.VectorList_02.Add(new Vector3(-1271.541f, -1198.63f, 5.366247f));
                    MissionData.VectorList_01.Add(new Vector3(-1270.787f, -1213.683f, 4.082492f));
                    MissionData.VectorList_02.Add(new Vector3(-1300.529f, -1233.508f, 4.486339f));
                    MissionData.VectorList_01.Add(new Vector3(-1294.273f, -1232.306f, 3.760854f));
                    MissionData.VectorList_02.Add(new Vector3(-1286.419f, -1267.013f, 4.516672f));
                    MissionData.VectorList_01.Add(new Vector3(-1280.713f, -1274.322f, 3.15608f));
                }
                else if (iArea == 9)//        "BEACH"  
                {
                    MissionData.VectorList_02.Add(new Vector3(-1418.114f, -1021.361f, 4.927687f));
                    MissionData.VectorList_01.Add(new Vector3(-1397.046f, -1028.397f, 3.637372f));
                    MissionData.VectorList_02.Add(new Vector3(-1348.222f, -1081.693f, 6.938175f));
                    MissionData.VectorList_01.Add(new Vector3(-1329.58f, -1094.18f, 6.160664f));
                    MissionData.VectorList_02.Add(new Vector3(-1347.625f, -1214.454f, 5.944139f));
                    MissionData.VectorList_01.Add(new Vector3(-1349.045f, -1201.545f, 3.703147f));
                    MissionData.VectorList_02.Add(new Vector3(-1182.977f, -1773.753f, 3.908463f));
                    MissionData.VectorList_01.Add(new Vector3(-1175.066f, -1771.921f, 3.109406f));
                    MissionData.VectorList_02.Add(new Vector3(-1155.814f, -1574.51f, 8.345077f));
                    MissionData.VectorList_01.Add(new Vector3(-1149.69f, -1583.255f, 3.570674f));
                    MissionData.VectorList_02.Add(new Vector3(-1174.325f, -1598.715f, 4.373224f));
                    MissionData.VectorList_01.Add(new Vector3(-1155.435f, -1588.295f, 3.608639f));
                    MissionData.VectorList_02.Add(new Vector3(-1213.075f, -1531.63f, 4.283716f));
                    MissionData.VectorList_01.Add(new Vector3(-1192.247f, -1527.082f, 3.59797f));
                    MissionData.VectorList_02.Add(new Vector3(-1226.105f, -1439.336f, 4.336521f));
                    MissionData.VectorList_01.Add(new Vector3(-1207.356f, -1438.97f, 3.637824f));
                    MissionData.VectorList_02.Add(new Vector3(-1301.149f, -1387.367f, 4.482184f));
                    MissionData.VectorList_01.Add(new Vector3(-1285.8f, -1393.937f, 3.718754f));
                }
                else if (iArea == 10)//        "DELBE"   
                {
                    MissionData.VectorList_02.Add(new Vector3(-1666.039f, -978.4476f, 8.159396f));
                    MissionData.VectorList_01.Add(new Vector3(-1647.855f, -950.4069f, 7.125754f));
                    MissionData.VectorList_02.Add(new Vector3(-1519.308f, -893.8687f, 13.68465f));
                    MissionData.VectorList_01.Add(new Vector3(-1518.693f, -880.8948f, 9.37102f));
                    MissionData.VectorList_02.Add(new Vector3(-1605.442f, -1001.208f, 13.01739f));
                    MissionData.VectorList_01.Add(new Vector3(-1606.668f, -1012.511f, 12.27762f));
                    MissionData.VectorList_02.Add(new Vector3(-1558.287f, -968.8815f, 17.41216f));
                    MissionData.VectorList_01.Add(new Vector3(-1554.237f, -982.1717f, 12.2773f));
                    MissionData.VectorList_02.Add(new Vector3(-1608.203f, -1073.929f, 13.01849f));
                    MissionData.VectorList_01.Add(new Vector3(-1600.424f, -1043.029f, 12.28701f));
                }
                else if (iArea == 11)//        "DELPE" MyZone 0)//        "SanAnd"  
                {
                    MissionData.VectorList_02.Add(new Vector3(-1371.109f, -685.431f, 24.98824f));
                    MissionData.VectorList_01.Add(new Vector3(-1369.095f, -693.772f, 24.12055f));
                    MissionData.VectorList_02.Add(new Vector3(-1285.63f, -566.7027f, 31.7124f));
                    MissionData.VectorList_01.Add(new Vector3(-1276.193f, -555.6957f, 29.53902f));
                    MissionData.VectorList_02.Add(new Vector3(-1388.62f, -586.6864f, 30.21924f));
                    MissionData.VectorList_01.Add(new Vector3(-1393.777f, -581.3997f, 29.44041f));
                    MissionData.VectorList_02.Add(new Vector3(-1540.682f, -454.5637f, 40.51902f));
                    MissionData.VectorList_01.Add(new Vector3(-1533.505f, -441.2186f, 34.70186f));
                    MissionData.VectorList_02.Add(new Vector3(-1558.364f, -417.0175f, 38.09856f));
                    MissionData.VectorList_01.Add(new Vector3(-1568.341f, -421.9239f, 37.19434f));
                    MissionData.VectorList_02.Add(new Vector3(-1697.246f, -422.2608f, 46.02833f));
                    MissionData.VectorList_01.Add(new Vector3(-1710.424f, -411.8491f, 44.21511f));
                    MissionData.VectorList_02.Add(new Vector3(-1710.878f, -494.3299f, 41.61913f));
                    MissionData.VectorList_01.Add(new Vector3(-1715.123f, -502.8709f, 37.30872f));
                    MissionData.VectorList_02.Add(new Vector3(-1662.496f, -532.7106f, 36.02411f));
                    MissionData.VectorList_01.Add(new Vector3(-1667.62f, -542.1003f, 34.23432f));
                    MissionData.VectorList_02.Add(new Vector3(-1459.068f, -659.1591f, 33.38121f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.437f, -654.7037f, 28.76304f));
                    MissionData.VectorList_02.Add(new Vector3(-1456.073f, -648.6187f, 33.38124f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.565f, -654.2465f, 28.85791f));
                    MissionData.VectorList_02.Add(new Vector3(-1472.997f, -646.3132f, 33.3812f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.436f, -654.7052f, 28.76287f));
                    MissionData.VectorList_02.Add(new Vector3(-1481.831f, -652.4942f, 29.58295f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.436f, -654.7052f, 28.76331f));
                    MissionData.VectorList_02.Add(new Vector3(-1467.847f, -665.3153f, 29.58303f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.436f, -654.7053f, 28.76324f));
                    MissionData.VectorList_02.Add(new Vector3(-1453.239f, -653.4661f, 29.5829f));
                    MissionData.VectorList_01.Add(new Vector3(-1465.436f, -654.7053f, 28.76223f));
                    MissionData.VectorList_02.Add(new Vector3(-1356.744f, -791.3961f, 20.24218f));
                    MissionData.VectorList_01.Add(new Vector3(-1362.593f, -800.9634f, 18.49312f));
                    MissionData.VectorList_02.Add(new Vector3(-1279.467f, -876.9868f, 11.93032f));
                    MissionData.VectorList_01.Add(new Vector3(-1286.797f, -883.9025f, 10.54494f));
                    MissionData.VectorList_02.Add(new Vector3(-1329.545f, -938.4286f, 12.35571f));
                    MissionData.VectorList_01.Add(new Vector3(-1318.439f, -923.1606f, 10.46153f));
                }
                else if (iArea == 12)//        "MOVIE"    "MORN"     
                {
                    MissionData.VectorList_02.Add(new Vector3(-1460.172f, -168.6274f, 48.81977f));
                    MissionData.VectorList_01.Add(new Vector3(-1446.605f, -149.2165f, 48.38486f));
                    MissionData.VectorList_02.Add(new Vector3(-1369.502f, -169.7315f, 47.48642f));
                    MissionData.VectorList_01.Add(new Vector3(-1393.748f, -156.9173f, 46.6925f));
                    MissionData.VectorList_02.Add(new Vector3(-1423.839f, -215.8649f, 46.50041f));
                    MissionData.VectorList_01.Add(new Vector3(-1420.433f, -190.4328f, 46.38483f));
                    MissionData.VectorList_02.Add(new Vector3(-1376.746f, -285.9489f, 43.46873f));
                    MissionData.VectorList_01.Add(new Vector3(-1390.941f, -288.5725f, 42.58349f));
                    MissionData.VectorList_02.Add(new Vector3(-1472.6f, -329.9493f, 44.81713f));
                    MissionData.VectorList_01.Add(new Vector3(-1450.284f, -334.9542f, 43.68563f));
                    MissionData.VectorList_02.Add(new Vector3(-1532.739f, -275.296f, 49.71008f));
                    MissionData.VectorList_01.Add(new Vector3(-1524.951f, -279.0801f, 48.89013f));
                }
                else if (iArea == 13)//        "ROCKF"       "golf"  
                {
                    MissionData.VectorList_02.Add(new Vector3(-1354.29f, -140.058f, 49.57456f));
                    MissionData.VectorList_01.Add(new Vector3(-1357.142f, -147.6312f, 47.79842f));
                    MissionData.VectorList_02.Add(new Vector3(-1026.242f, 315.9842f, 66.88311f));
                    MissionData.VectorList_01.Add(new Vector3(-1041.429f, 321.4409f, 66.07804f));
                    MissionData.VectorList_02.Add(new Vector3(-1026.074f, 360.7628f, 71.36153f));
                    MissionData.VectorList_01.Add(new Vector3(-1015.007f, 358.0407f, 69.87968f));
                    MissionData.VectorList_02.Add(new Vector3(-892.2721f, 352.8219f, 85.47115f));
                    MissionData.VectorList_01.Add(new Vector3(-887.5854f, 369.4475f, 84.2992f));
                    MissionData.VectorList_02.Add(new Vector3(-875.8641f, 315.7621f, 84.15994f));
                    MissionData.VectorList_01.Add(new Vector3(-870.7113f, 302.4772f, 83.24094f));
                    MissionData.VectorList_02.Add(new Vector3(-819.4623f, 268.2599f, 86.38909f));
                    MissionData.VectorList_01.Add(new Vector3(-825.0667f, 272.9646f, 85.54727f));
                    MissionData.VectorList_02.Add(new Vector3(-948.934f, 320.3693f, 71.35191f));
                    MissionData.VectorList_01.Add(new Vector3(-947.6569f, 308.0075f, 70.40042f));
                    MissionData.VectorList_02.Add(new Vector3(-1037.066f, 207.9634f, 64.56448f));
                    MissionData.VectorList_01.Add(new Vector3(-1046.699f, 221.1928f, 63.02604f));
                    MissionData.VectorList_02.Add(new Vector3(-949.5158f, 196.6293f, 67.39026f));
                    MissionData.VectorList_01.Add(new Vector3(-953.416f, 187.3162f, 65.85413f));
                    MissionData.VectorList_02.Add(new Vector3(-916.7498f, 203.2301f, 69.43185f));
                    MissionData.VectorList_01.Add(new Vector3(-910.2756f, 188.7189f, 68.70294f));
                    MissionData.VectorList_02.Add(new Vector3(-993.275f, 162.2733f, 62.14541f));
                    MissionData.VectorList_01.Add(new Vector3(-989.3348f, 144.4876f, 59.88694f));
                    MissionData.VectorList_02.Add(new Vector3(-971.3362f, 122.028f, 57.04857f));
                    MissionData.VectorList_01.Add(new Vector3(-960.4633f, 111.0401f, 55.67738f));
                    MissionData.VectorList_02.Add(new Vector3(-923.2835f, 124.1776f, 55.53205f));
                    MissionData.VectorList_01.Add(new Vector3(-918.8908f, 110.3132f, 54.57633f));
                    MissionData.VectorList_02.Add(new Vector3(-934.5027f, 3.251942f, 47.74643f));
                    MissionData.VectorList_01.Add(new Vector3(-925.3032f, 10.76216f, 46.97826f));
                    MissionData.VectorList_02.Add(new Vector3(-896.5391f, -4.971326f, 43.79887f));
                    MissionData.VectorList_01.Add(new Vector3(-886.3248f, -9.607732f, 42.53655f));
                    MissionData.VectorList_02.Add(new Vector3(-841.3217f, -24.86731f, 40.39839f));
                    MissionData.VectorList_01.Add(new Vector3(-830.4749f, -33.85237f, 37.74441f));
                    MissionData.VectorList_02.Add(new Vector3(-766.9527f, -23.84942f, 41.08041f));
                    MissionData.VectorList_01.Add(new Vector3(-758.5886f, -36.68955f, 36.94484f));
                    MissionData.VectorList_02.Add(new Vector3(-247.7577f, -329.3505f, 27.60481f));
                    MissionData.VectorList_01.Add(new Vector3(-256.4178f, -337.0367f, 29.11594f));
                    MissionData.VectorList_02.Add(new Vector3(-481.2264f, -401.667f, 34.5466f));
                    MissionData.VectorList_01.Add(new Vector3(-483.3846f, -386.6872f, 33.41516f));
                    MissionData.VectorList_02.Add(new Vector3(-570.5855f, -395.0763f, 35.05656f));
                    MissionData.VectorList_01.Add(new Vector3(-572.5616f, -383.1132f, 34.1718f));
                    MissionData.VectorList_02.Add(new Vector3(-554.2025f, -329.9634f, 35.1568f));
                    MissionData.VectorList_01.Add(new Vector3(-547.9968f, -325.5482f, 34.29967f));
                    MissionData.VectorList_02.Add(new Vector3(-561.881f, -131.3118f, 38.43238f));
                    MissionData.VectorList_01.Add(new Vector3(-553.8245f, -147.4621f, 37.40226f));
                    MissionData.VectorList_02.Add(new Vector3(-730.188f, -130.8872f, 38.07042f));
                    MissionData.VectorList_01.Add(new Vector3(-738.5037f, -131.5499f, 36.61028f));
                    MissionData.VectorList_02.Add(new Vector3(-723.9586f, -280.9983f, 37.1396f));
                    MissionData.VectorList_01.Add(new Vector3(-729.4451f, -285.4275f, 36.20818f));
                    MissionData.VectorList_02.Add(new Vector3(-759.3776f, -209.7389f, 37.27201f));
                    MissionData.VectorList_01.Add(new Vector3(-767.3508f, -207.0348f, 36.53815f));
                    MissionData.VectorList_02.Add(new Vector3(-801.4948f, -177.8358f, 38.13674f));
                    MissionData.VectorList_01.Add(new Vector3(-792.1018f, -177.4919f, 36.5426f));
                    MissionData.VectorList_02.Add(new Vector3(-845.2264f, -123.8861f, 34.92541f));
                    MissionData.VectorList_01.Add(new Vector3(-841.033f, -139.4222f, 36.93386f));
                    MissionData.VectorList_02.Add(new Vector3(-814.8182f, -202.0733f, 37.48641f));
                    MissionData.VectorList_01.Add(new Vector3(-824.1635f, -202.3184f, 36.6447f));
                    MissionData.VectorList_02.Add(new Vector3(-1044.833f, -231.1025f, 39.01435f));
                    MissionData.VectorList_01.Add(new Vector3(-1051.043f, -216.2052f, 37.00772f));
                    MissionData.VectorList_02.Add(new Vector3(-733.4784f, -318.2313f, 36.5607f));
                    MissionData.VectorList_01.Add(new Vector3(-742.6403f, -325.5553f, 35.38481f));
                    MissionData.VectorList_02.Add(new Vector3(-769.0097f, -355.9413f, 37.33335f));
                    MissionData.VectorList_01.Add(new Vector3(-766.2805f, -343.241f, 35.31346f));
                    MissionData.VectorList_02.Add(new Vector3(-720.5628f, -411.4023f, 34.98101f));
                    MissionData.VectorList_01.Add(new Vector3(-732.4562f, -411.7837f, 34.55416f));
                    MissionData.VectorList_02.Add(new Vector3(-783.394f, -391.1441f, 37.33352f));
                    MissionData.VectorList_01.Add(new Vector3(-788.0407f, -402.7892f, 35.16359f));
                    MissionData.VectorList_02.Add(new Vector3(-1026.703f, -418.8185f, 39.61594f));
                    MissionData.VectorList_01.Add(new Vector3(-1048.815f, -391.3591f, 36.82092f));
                    MissionData.VectorList_02.Add(new Vector3(-1095.178f, -325.564f, 37.82364f));
                    MissionData.VectorList_01.Add(new Vector3(-1095.845f, -317.3362f, 36.92531f));
                    MissionData.VectorList_02.Add(new Vector3(-1164.338f, -348.5981f, 36.63751f));
                    MissionData.VectorList_01.Add(new Vector3(-1168.575f, -341.5084f, 36.32198f));
                    MissionData.VectorList_02.Add(new Vector3(-1232.031f, -143.9317f, 40.40824f));
                    MissionData.VectorList_01.Add(new Vector3(-1207.98f, -129.8569f, 40.29033f));

                    MissionData.VectorList_02.Add(new Vector3(-1189.34f, 292.0604f, 69.89325f));
                    MissionData.VectorList_01.Add(new Vector3(-1183.382f, 286.2881f, 68.78954f));
                    MissionData.VectorList_02.Add(new Vector3(-1146.913f, 381.85f, 71.31322f));
                    MissionData.VectorList_01.Add(new Vector3(-1131.19f, 382.7086f, 70.02845f));
                    MissionData.VectorList_02.Add(new Vector3(-1274.038f, 315.7936f, 65.51176f));
                    MissionData.VectorList_01.Add(new Vector3(-1286.176f, 295.006f, 64.15466f));
                    MissionData.VectorList_02.Add(new Vector3(-1366.692f, 56.64131f, 54.09836f));
                    MissionData.VectorList_01.Add(new Vector3(-1379.541f, 55.16712f, 52.9743f));
                }
                else if (iArea == 14)//        "BURTON"  
                {
                    MissionData.VectorList_02.Add(new Vector3(-137.9203f, -256.7903f, 43.59498f));
                    MissionData.VectorList_01.Add(new Vector3(-130.958f, -259.2365f, 42.49442f));
                    MissionData.VectorList_02.Add(new Vector3(-431.2309f, -24.3851f, 46.22859f));
                    MissionData.VectorList_01.Add(new Vector3(-424.1801f, -25.54552f, 45.52f));
                    MissionData.VectorList_02.Add(new Vector3(-490.0871f, 27.91375f, 46.29721f));
                    MissionData.VectorList_01.Add(new Vector3(-487.0178f, 21.20043f, 44.28422f));
                    MissionData.VectorList_02.Add(new Vector3(-509.5037f, -22.15906f, 45.60895f));
                    MissionData.VectorList_01.Add(new Vector3(-531.4308f, -24.39477f, 43.63002f));
                    MissionData.VectorList_02.Add(new Vector3(-433.5324f, -159.0408f, 37.82975f));
                    MissionData.VectorList_01.Add(new Vector3(-443.5297f, -167.6072f, 36.80051f));
                    MissionData.VectorList_02.Add(new Vector3(-310.7526f, -278.0241f, 31.71694f));
                    MissionData.VectorList_01.Add(new Vector3(-294.5354f, -278.9979f, 30.3766f));
                }
                else if (iArea == 15)//        "ALTA"
                {
                    MissionData.VectorList_02.Add(new Vector3(337.1231f, -224.7314f, 58.01926f));
                    MissionData.VectorList_01.Add(new Vector3(323.8887f, -216.8452f, 53.70169f));
                    MissionData.VectorList_02.Add(new Vector3(337.1165f, -224.7166f, 54.22176f));
                    MissionData.VectorList_01.Add(new Vector3(323.8885f, -216.8456f, 53.70388f));
                    MissionData.VectorList_02.Add(new Vector3(340.9855f, -214.898f, 54.22177f));
                    MissionData.VectorList_01.Add(new Vector3(323.8886f, -216.8452f, 53.70319f));
                    MissionData.VectorList_02.Add(new Vector3(311.2467f, -203.8005f, 58.01926f));
                    MissionData.VectorList_01.Add(new Vector3(323.8888f, -216.8456f, 53.70368f));
                    MissionData.VectorList_02.Add(new Vector3(310.719f, -217.6171f, 58.01925f));
                    MissionData.VectorList_01.Add(new Vector3(323.8882f, -216.8456f, 53.70445f));
                    MissionData.VectorList_02.Add(new Vector3(307.2587f, -216.3905f, 54.22177f));
                    MissionData.VectorList_01.Add(new Vector3(323.8895f, -216.8458f, 53.70464f));
                    MissionData.VectorList_02.Add(new Vector3(311.9126f, -204.0758f, 54.22183f));
                    MissionData.VectorList_01.Add(new Vector3(323.8886f, -216.8453f, 53.70185f));
                    MissionData.VectorList_02.Add(new Vector3(140.2924f, -286.6419f, 50.44962f));
                    MissionData.VectorList_01.Add(new Vector3(128.9395f, -307.2529f, 44.80704f));
                    MissionData.VectorList_02.Add(new Vector3(85.26392f, -268.0471f, 47.79923f));
                    MissionData.VectorList_01.Add(new Vector3(81.0944f, -291.2837f, 46.27134f));
                    MissionData.VectorList_02.Add(new Vector3(1.905731f, -240.8442f, 51.86057f));
                    MissionData.VectorList_01.Add(new Vector3(6.666971f, -263.2705f, 46.87637f));
                    MissionData.VectorList_02.Add(new Vector3(141.3129f, -379.8523f, 43.25697f));
                    MissionData.VectorList_01.Add(new Vector3(133.2358f, -376.0379f, 42.86023f));
                    MissionData.VectorList_02.Add(new Vector3(-52.99578f, -397.6029f, 38.12812f));
                    MissionData.VectorList_01.Add(new Vector3(-30.21463f, -405.3861f, 39.05763f));
                    MissionData.VectorList_02.Add(new Vector3(-30.1248f, -347.0221f, 46.32362f));
                    MissionData.VectorList_01.Add(new Vector3(-14.9734f, -356.9637f, 40.29393f));
                }
                else if (iArea == 16)//        "HAWICK"  
                {
                    MissionData.VectorList_02.Add(new Vector3(271.4294f, -208.6099f, 61.57072f));
                    MissionData.VectorList_01.Add(new Vector3(274.9666f, -187.8761f, 61.16962f));
                    MissionData.VectorList_02.Add(new Vector3(220.3426f, -92.2359f, 69.61214f));
                    MissionData.VectorList_01.Add(new Vector3(215.4621f, -65.28774f, 68.67736f));
                    MissionData.VectorList_02.Add(new Vector3(207.7987f, -190.7932f, 54.39412f));
                    MissionData.VectorList_01.Add(new Vector3(205.085f, -199.0758f, 53.51561f));
                    MissionData.VectorList_02.Add(new Vector3(26.37074f, -168.5097f, 55.57018f));
                    MissionData.VectorList_01.Add(new Vector3(24.60649f, -156.8087f, 55.36599f));
                    MissionData.VectorList_02.Add(new Vector3(-13.98569f, -110.5151f, 56.83979f));
                    MissionData.VectorList_01.Add(new Vector3(-15.4755f, -117.5756f, 56.37433f));
                }
                else //        "WVINE" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-479.2487f, 218.3924f, 83.69603f));
                    MissionData.VectorList_01.Add(new Vector3(-480.8465f, 224.3893f, 82.71607f));
                    MissionData.VectorList_02.Add(new Vector3(-569.7756f, 169.5958f, 66.56587f));
                    MissionData.VectorList_01.Add(new Vector3(-551.2469f, 168.4349f, 66.6234f));
                    MissionData.VectorList_02.Add(new Vector3(-511.6719f, 108.9022f, 63.79959f));
                    MissionData.VectorList_01.Add(new Vector3(-512.4089f, 123.2785f, 62.79382f));
                    MissionData.VectorList_02.Add(new Vector3(-392.7119f, 151.4118f, 65.52414f));
                    MissionData.VectorList_01.Add(new Vector3(-395.6694f, 132.4798f, 65.08716f));
                    MissionData.VectorList_02.Add(new Vector3(-208.1687f, 159.859f, 74.05302f));
                    MissionData.VectorList_01.Add(new Vector3(-220.4445f, 162.1267f, 72.90894f));
                    MissionData.VectorList_02.Add(new Vector3(-149.0777f, 121.9784f, 70.22536f));
                    MissionData.VectorList_01.Add(new Vector3(-164.8017f, 106.0881f, 69.87028f));
                    MissionData.VectorList_02.Add(new Vector3(-329.4156f, 97.45921f, 67.05153f));
                    MissionData.VectorList_01.Add(new Vector3(-321.8814f, 115.0459f, 66.84548f));
                    MissionData.VectorList_02.Add(new Vector3(-355.3001f, 94.91445f, 70.5202f));
                    MissionData.VectorList_01.Add(new Vector3(-346.1362f, 108.3023f, 66.27882f));
                    MissionData.VectorList_02.Add(new Vector3(-355.2776f, 15.46274f, 47.85473f));
                    MissionData.VectorList_01.Add(new Vector3(-356.3561f, 33.08219f, 47.41592f));
                    MissionData.VectorList_02.Add(new Vector3(-314.8544f, 83.60764f, 71.66293f));
                    MissionData.VectorList_01.Add(new Vector3(-315.9304f, 72.05852f, 65.04311f));
                    MissionData.VectorList_02.Add(new Vector3(-282.1409f, 12.98766f, 54.75249f));
                    MissionData.VectorList_01.Add(new Vector3(-269.334f, 27.04459f, 54.35106f));
                    MissionData.VectorList_02.Add(new Vector3(-219.1817f, -3.427589f, 52.36488f));
                    MissionData.VectorList_01.Add(new Vector3(-225.7999f, 4.687866f, 52.03117f));
                    MissionData.VectorList_02.Add(new Vector3(-161.3873f, -3.951782f, 62.46285f));
                    MissionData.VectorList_01.Add(new Vector3(-152.9026f, -1.673734f, 57.37193f));
                    MissionData.VectorList_02.Add(new Vector3(-117.107f, -37.25715f, 62.19587f));
                    MissionData.VectorList_01.Add(new Vector3(-129.4191f, -26.90284f, 57.75457f));
                    MissionData.VectorList_02.Add(new Vector3(-77.88377f, 7.237984f, 70.25868f));
                    MissionData.VectorList_01.Add(new Vector3(-71.19195f, -3.913839f, 69.62611f));
                    MissionData.VectorList_02.Add(new Vector3(-0.08573192f, -15.04306f, 71.10311f));
                    MissionData.VectorList_01.Add(new Vector3(0.01606551f, 5.507839f, 70.46945f));
                }
            }
            else if (Local == 3)
            {
                if (bRandom)
                    iArea = RandInt(1, 4);

                if (iArea == 1)//        "RICHM" && MyZone 0)//        "RGLEN" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-1878.568f, 214.5692f, 84.43929f));
                    MissionData.VectorList_01.Add(new Vector3(-1873.862f, 193.8993f, 83.7653f));
                    MissionData.VectorList_02.Add(new Vector3(-1892.024f, 235.6097f, 86.25183f));
                    MissionData.VectorList_01.Add(new Vector3(-1905.712f, 242.3712f, 85.72104f));
                    MissionData.VectorList_02.Add(new Vector3(-1921.954f, 308.4248f, 89.07661f));
                    MissionData.VectorList_01.Add(new Vector3(-1928.648f, 297.501f, 88.54451f));
                    MissionData.VectorList_02.Add(new Vector3(-1930.378f, 369.2367f, 93.78211f));
                    MissionData.VectorList_01.Add(new Vector3(-1938.424f, 360.773f, 93.05482f));
                    MissionData.VectorList_02.Add(new Vector3(-1941.7f, 386.0603f, 96.50709f));
                    MissionData.VectorList_01.Add(new Vector3(-1950.128f, 401.4925f, 95.74673f));
                    MissionData.VectorList_02.Add(new Vector3(-1943.1f, 449.7197f, 102.9281f));
                    MissionData.VectorList_01.Add(new Vector3(-1955.434f, 447.6809f, 100.4078f));
                    MissionData.VectorList_02.Add(new Vector3(-1939.811f, 534.4824f, 114.8257f));
                    MissionData.VectorList_01.Add(new Vector3(-1941.551f, 552.8403f, 114.2949f));
                    MissionData.VectorList_02.Add(new Vector3(-1929.164f, 595.4424f, 122.2849f));
                    MissionData.VectorList_01.Add(new Vector3(-1944.052f, 582.5765f, 118.1756f));
                    MissionData.VectorList_02.Add(new Vector3(-1897.366f, 642.0092f, 130.2086f));
                    MissionData.VectorList_01.Add(new Vector3(-1888.728f, 626.4341f, 129.4718f));
                    MissionData.VectorList_02.Add(new Vector3(-1967.342f, 649.6359f, 122.5363f));
                    MissionData.VectorList_01.Add(new Vector3(-1973.95f, 622.8629f, 121.8698f));
                    MissionData.VectorList_02.Add(new Vector3(-2000.012f, 613.8847f, 117.9034f));
                    MissionData.VectorList_01.Add(new Vector3(-1987.878f, 603.7962f, 117.3801f));
                    MissionData.VectorList_02.Add(new Vector3(-2024.877f, 478.917f, 107.1619f));
                    MissionData.VectorList_01.Add(new Vector3(-2011.932f, 484.1914f, 106.5138f));
                    MissionData.VectorList_02.Add(new Vector3(-2022.839f, 455.3822f, 105.753f));
                    MissionData.VectorList_01.Add(new Vector3(-2008.189f, 454.4774f, 102.1402f));
                    MissionData.VectorList_02.Add(new Vector3(-2011.445f, 350.2057f, 94.4791f));
                    MissionData.VectorList_01.Add(new Vector3(-2000.829f, 367.4298f, 93.97578f));
                    MissionData.VectorList_02.Add(new Vector3(-2009.404f, 289.1414f, 91.97834f));
                    MissionData.VectorList_01.Add(new Vector3(-1992.321f, 294.4626f, 91.25754f));
                    MissionData.VectorList_02.Add(new Vector3(-1970.168f, 246.2813f, 87.81215f));
                    MissionData.VectorList_01.Add(new Vector3(-1975.152f, 260.3556f, 86.71169f));
                    MissionData.VectorList_02.Add(new Vector3(-1960.694f, 212.0906f, 86.81219f));
                    MissionData.VectorList_01.Add(new Vector3(-1955.168f, 214.5622f, 85.54868f));
                    MissionData.VectorList_02.Add(new Vector3(-1931.561f, 162.9542f, 84.65261f));
                    MissionData.VectorList_01.Add(new Vector3(-1934.191f, 184.5886f, 84.06035f));
                    MissionData.VectorList_02.Add(new Vector3(-1906.881f, 141.3684f, 81.64087f));
                    MissionData.VectorList_01.Add(new Vector3(-1892.904f, 136.0754f, 80.95974f));
                }
                else if (iArea == 2)//        "PBLUFF" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-3023.749f, 80.59142f, 11.60812f));
                    MissionData.VectorList_01.Add(new Vector3(-3017.372f, 88.69462f, 11.07981f));
                    MissionData.VectorList_02.Add(new Vector3(-2189.858f, -399.3562f, 13.30098f));
                    MissionData.VectorList_01.Add(new Vector3(-2181.863f, -409.2686f, 12.5398f));
                    MissionData.VectorList_02.Add(new Vector3(-2073.705f, -126.1924f, 35.80942f));
                    MissionData.VectorList_01.Add(new Vector3(-2038.215f, -136.9038f, 26.9034f));
                    MissionData.VectorList_02.Add(new Vector3(-1857.052f, -348.5349f, 49.83775f));
                    MissionData.VectorList_01.Add(new Vector3(-1861.999f, -353.8299f, 48.71446f));
                    MissionData.VectorList_02.Add(new Vector3(-1684.828f, -292.6348f, 51.8908f));
                    MissionData.VectorList_01.Add(new Vector3(-1685.22f, -300.6436f, 51.28144f));
                    MissionData.VectorList_02.Add(new Vector3(-2295.177f, 363.814f, 174.6016f));
                    MissionData.VectorList_01.Add(new Vector3(-2296.555f, 376.1144f, 173.9368f));
                }
                else if (iArea == 3)//        "BHAMCA" && MyZone 0)//        "BANHAMC"  && MyZone 0)//        "CHU" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-3110.801f, 750.4182f, 24.70186f));
                    MissionData.VectorList_01.Add(new Vector3(-3097.423f, 743.9031f, 20.48927f));
                    MissionData.VectorList_02.Add(new Vector3(-3107.09f, 718.6204f, 20.633f));
                    MissionData.VectorList_01.Add(new Vector3(-3100.444f, 716.2214f, 19.83283f));
                    MissionData.VectorList_02.Add(new Vector3(-3086.756f, 664.8164f, 11.58845f));
                    MissionData.VectorList_01.Add(new Vector3(-3072.689f, 658.2528f, 10.44048f));
                    MissionData.VectorList_02.Add(new Vector3(-3036.034f, 574.8292f, 7.823583f));
                    MissionData.VectorList_01.Add(new Vector3(-3026.632f, 573.8799f, 7.016073f));
                    MissionData.VectorList_02.Add(new Vector3(-3036.793f, 558.8264f, 7.507683f));
                    MissionData.VectorList_01.Add(new Vector3(-3030.468f, 556.2008f, 6.872155f));
                    MissionData.VectorList_02.Add(new Vector3(-3039.289f, 492.8857f, 6.772714f));
                    MissionData.VectorList_01.Add(new Vector3(-3031.783f, 498.2742f, 6.175517f));
                    MissionData.VectorList_02.Add(new Vector3(-3047.145f, 485.2661f, 6.779647f));
                    MissionData.VectorList_01.Add(new Vector3(-3038.043f, 477.445f, 6.115459f));
                    MissionData.VectorList_02.Add(new Vector3(-3067.425f, 439.884f, 6.360351f));
                    MissionData.VectorList_01.Add(new Vector3(-3052.8f, 441.2135f, 5.709949f));
                    MissionData.VectorList_02.Add(new Vector3(-3088.146f, 391.8495f, 11.44504f));
                    MissionData.VectorList_01.Add(new Vector3(-3072.913f, 393.2456f, 6.335815f));
                    MissionData.VectorList_02.Add(new Vector3(-3091.191f, 378.8426f, 7.112263f));
                    MissionData.VectorList_01.Add(new Vector3(-3077.573f, 371.858f, 6.424158f));
                    MissionData.VectorList_02.Add(new Vector3(-3092.814f, 349.5691f, 7.532001f));
                    MissionData.VectorList_01.Add(new Vector3(-3088.889f, 341.8463f, 6.776845f));
                    MissionData.VectorList_02.Add(new Vector3(-3101.632f, 332.9786f, 7.493346f));
                    MissionData.VectorList_01.Add(new Vector3(-3089.019f, 324.63f, 6.851557f));
                    MissionData.VectorList_02.Add(new Vector3(-3106.015f, 313.4806f, 8.38104f));
                    MissionData.VectorList_01.Add(new Vector3(-3095.504f, 304.6574f, 7.801707f));
                    MissionData.VectorList_02.Add(new Vector3(-3109.53f, 301.7948f, 8.381039f));
                    MissionData.VectorList_01.Add(new Vector3(-3095.505f, 304.6575f, 7.800583f));
                    MissionData.VectorList_02.Add(new Vector3(-3111.452f, 296.164f, 8.972106f));
                    MissionData.VectorList_01.Add(new Vector3(-3100.482f, 289.2973f, 8.56084f));
                    MissionData.VectorList_02.Add(new Vector3(-3114.491f, 253.7804f, 12.492f));
                    MissionData.VectorList_01.Add(new Vector3(-3101.362f, 251.1279f, 11.42317f));
                    MissionData.VectorList_02.Add(new Vector3(-3095.399f, 217.7303f, 14.58094f));
                    MissionData.VectorList_01.Add(new Vector3(-3083.608f, 223.2508f, 13.3014f));
                    MissionData.VectorList_02.Add(new Vector3(-2972.425f, 599.5049f, 24.4398f));
                    MissionData.VectorList_01.Add(new Vector3(-2981.605f, 604.1546f, 19.10135f));
                    MissionData.VectorList_02.Add(new Vector3(-2971.332f, 635.1398f, 25.7979f));
                    MissionData.VectorList_01.Add(new Vector3(-2981.608f, 653.7446f, 24.52167f));
                    MissionData.VectorList_02.Add(new Vector3(-2991.647f, 677.6633f, 25.03615f));
                    MissionData.VectorList_01.Add(new Vector3(-3001.683f, 688.0192f, 24.008f));
                    MissionData.VectorList_02.Add(new Vector3(-2989.949f, 729.2177f, 28.49687f));
                    MissionData.VectorList_01.Add(new Vector3(-2995.868f, 721.2349f, 27.84494f));
                    MissionData.VectorList_02.Add(new Vector3(-3021.26f, 751.2949f, 27.5876f));
                    MissionData.VectorList_01.Add(new Vector3(-3017.81f, 738.942f, 27.08741f));
                    MissionData.VectorList_02.Add(new Vector3(-3226.107f, 911.2578f, 13.99327f));
                    MissionData.VectorList_01.Add(new Vector3(-3216.154f, 914.3242f, 13.51317f));
                    MissionData.VectorList_02.Add(new Vector3(-3238.567f, 923.0718f, 13.95989f));
                    MissionData.VectorList_01.Add(new Vector3(-3224.866f, 927.2133f, 13.43289f));
                    MissionData.VectorList_02.Add(new Vector3(-3238.777f, 929.2819f, 17.14999f));
                    MissionData.VectorList_01.Add(new Vector3(-3230.473f, 938.7974f, 13.24235f));
                    MissionData.VectorList_02.Add(new Vector3(-3237.766f, 952.3402f, 13.12962f));
                    MissionData.VectorList_01.Add(new Vector3(-3233.314f, 948.5009f, 12.81998f));
                    MissionData.VectorList_02.Add(new Vector3(-3251.234f, 1043.102f, 11.75771f));
                    MissionData.VectorList_01.Add(new Vector3(-3236.66f, 1037.344f, 11.17605f));
                    MissionData.VectorList_02.Add(new Vector3(-3245.689f, 1062.886f, 11.14619f));
                    MissionData.VectorList_01.Add(new Vector3(-3233.137f, 1057.34f, 10.66858f));
                    MissionData.VectorList_02.Add(new Vector3(-3235.27f, 1076.041f, 11.03331f));
                    MissionData.VectorList_01.Add(new Vector3(-3229.212f, 1071.461f, 10.40678f));
                    MissionData.VectorList_02.Add(new Vector3(-3231.806f, 1081.586f, 10.8089f));
                    MissionData.VectorList_01.Add(new Vector3(-3226.823f, 1086.945f, 10.19171f));
                    MissionData.VectorList_02.Add(new Vector3(-3228.666f, 1092.662f, 10.77182f));
                    MissionData.VectorList_01.Add(new Vector3(-3226.825f, 1086.943f, 10.17782f));
                    MissionData.VectorList_02.Add(new Vector3(-3224.834f, 1113.216f, 10.57764f));
                    MissionData.VectorList_01.Add(new Vector3(-3218.955f, 1105.772f, 9.89898f));
                    MissionData.VectorList_02.Add(new Vector3(-3213.26f, 1134.408f, 9.895407f));
                    MissionData.VectorList_01.Add(new Vector3(-3204.593f, 1136.673f, 9.370088f));
                    MissionData.VectorList_02.Add(new Vector3(-3210.196f, 1146.144f, 9.895408f));
                    MissionData.VectorList_01.Add(new Vector3(-3204.592f, 1136.674f, 9.367161f));
                    MissionData.VectorList_02.Add(new Vector3(-3199.891f, 1165.147f, 9.654341f));
                    MissionData.VectorList_01.Add(new Vector3(-3196.638f, 1160.642f, 9.050935f));
                    MissionData.VectorList_02.Add(new Vector3(-3205.993f, 1187.009f, 9.664687f));
                    MissionData.VectorList_01.Add(new Vector3(-3191.01f, 1181.408f, 8.82839f));
                    MissionData.VectorList_02.Add(new Vector3(-3194.872f, 1209.193f, 9.424752f));
                    MissionData.VectorList_01.Add(new Vector3(-3186.948f, 1201.075f, 8.994352f));
                    MissionData.VectorList_02.Add(new Vector3(-3194.43f, 1230.428f, 10.04832f));
                    MissionData.VectorList_01.Add(new Vector3(-3186.025f, 1226.601f, 9.543797f));
                    MissionData.VectorList_02.Add(new Vector3(-3190.776f, 1297.634f, 19.06739f));
                    MissionData.VectorList_01.Add(new Vector3(-3176.015f, 1294.986f, 13.88427f));
                    MissionData.VectorList_02.Add(new Vector3(-2794.065f, 1436.65f, 100.9284f));
                    MissionData.VectorList_01.Add(new Vector3(-2784.956f, 1431.801f, 100.3998f));
                }
                else //        "TONGVAH" && MyZone 0)//        "TONGVAV" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-1516.543f, 1505.643f, 115.0055f));
                    MissionData.VectorList_01.Add(new Vector3(-1502.462f, 1493.975f, 115.4031f));
                    MissionData.VectorList_02.Add(new Vector3(-1585.992f, 2110.469f, 65.85062f));
                    MissionData.VectorList_01.Add(new Vector3(-1579.633f, 2097.453f, 68.14568f));
                    MissionData.VectorList_02.Add(new Vector3(-1897.6f, 2058.515f, 140.9148f));
                    MissionData.VectorList_01.Add(new Vector3(-1889.138f, 2045.076f, 140.233f));
                    MissionData.VectorList_02.Add(new Vector3(-1743.845f, 2379.063f, 47.18592f));
                    MissionData.VectorList_01.Add(new Vector3(-1745.479f, 2391.582f, 42.8428f));
                    MissionData.VectorList_02.Add(new Vector3(-1717.544f, 1874.892f, 163.155f));
                    MissionData.VectorList_01.Add(new Vector3(-1713.895f, 1883.34f, 160.9319f));
                }
            }
            else if (Local == 4)
            {
                if (bRandom)
                    iArea = RandInt(1, 5);

                if (iArea == 1)//        "MIRR" 
                {
                    MissionData.VectorList_02.Add(new Vector3(1303.104f, -528.0761f, 71.46065f));
                    MissionData.VectorList_01.Add(new Vector3(1309.066f, -535.1337f, 70.73479f));
                    MissionData.VectorList_02.Add(new Vector3(1328.005f, -536.041f, 72.44083f));
                    MissionData.VectorList_01.Add(new Vector3(1317.968f, -538.2343f, 71.43388f));
                    MissionData.VectorList_02.Add(new Vector3(1348.163f, -547.7917f, 73.89162f));
                    MissionData.VectorList_01.Add(new Vector3(1353.236f, -555.9352f, 73.63641f));
                    MissionData.VectorList_02.Add(new Vector3(1372.689f, -555.9731f, 74.68577f));
                    MissionData.VectorList_01.Add(new Vector3(1362.776f, -557.3074f, 73.77276f));
                    MissionData.VectorList_02.Add(new Vector3(1388.346f, -569.6031f, 74.49653f));
                    MissionData.VectorList_01.Add(new Vector3(1388.113f, -578.3655f, 73.77274f));
                    MissionData.VectorList_02.Add(new Vector3(1385.853f, -593.0632f, 74.48546f));
                    MissionData.VectorList_01.Add(new Vector3(1378.244f, -597.2811f, 73.77341f));
                    MissionData.VectorList_02.Add(new Vector3(1367.295f, -606.2516f, 74.71093f));
                    MissionData.VectorList_01.Add(new Vector3(1359.627f, -600.3322f, 73.77345f));
                    MissionData.VectorList_02.Add(new Vector3(1342f, -597.175f, 74.7008f));
                    MissionData.VectorList_01.Add(new Vector3(1347.955f, -577.8033f, 73.62755f));
                    MissionData.VectorList_02.Add(new Vector3(1323.486f, -582.6028f, 73.24638f));
                    MissionData.VectorList_01.Add(new Vector3(1318.944f, -574.3151f, 72.35325f));
                    MissionData.VectorList_02.Add(new Vector3(1301.144f, -573.8477f, 71.73234f));
                    MissionData.VectorList_01.Add(new Vector3(1295.759f, -566.8878f, 70.58719f));
                    MissionData.VectorList_02.Add(new Vector3(1203.279f, -557.5997f, 69.40067f));
                    MissionData.VectorList_01.Add(new Vector3(1184.475f, -555.3583f, 63.85255f));
                    MissionData.VectorList_02.Add(new Vector3(1201.368f, -578.7299f, 69.13488f));
                    MissionData.VectorList_01.Add(new Vector3(1183.985f, -584.4063f, 63.49017f));
                    MissionData.VectorList_02.Add(new Vector3(1203.674f, -599.1799f, 68.06352f));
                    MissionData.VectorList_01.Add(new Vector3(1186.999f, -604.1857f, 63.22091f));
                    MissionData.VectorList_02.Add(new Vector3(1206.905f, -619.9584f, 66.43616f));
                    MissionData.VectorList_01.Add(new Vector3(1203.073f, -613.0959f, 65.27635f));
                    MissionData.VectorList_02.Add(new Vector3(1221.432f, -668.447f, 63.50019f));
                    MissionData.VectorList_01.Add(new Vector3(1215.585f, -665.6649f, 62.1657f));
                    MissionData.VectorList_02.Add(new Vector3(1222.634f, -696.9823f, 60.80664f));
                    MissionData.VectorList_01.Add(new Vector3(1222.546f, -704.6004f, 60.25977f));
                    MissionData.VectorList_02.Add(new Vector3(1228.98f, -725.4678f, 60.79766f));
                    MissionData.VectorList_01.Add(new Vector3(1223.973f, -728.1918f, 59.96362f));
                    MissionData.VectorList_02.Add(new Vector3(1265.76f, -703.2062f, 64.56302f));
                    MissionData.VectorList_01.Add(new Vector3(1276.88f, -709.9447f, 64.16968f));
                    MissionData.VectorList_02.Add(new Vector3(1271.215f, -683.229f, 66.03163f));
                    MissionData.VectorList_01.Add(new Vector3(1276.321f, -672.1403f, 65.55285f));
                    MissionData.VectorList_02.Add(new Vector3(1265.496f, -648.1833f, 67.92143f));
                    MissionData.VectorList_01.Add(new Vector3(1281.524f, -636.264f, 67.85822f));
                    MissionData.VectorList_02.Add(new Vector3(1243.872f, -634.2845f, 69.32861f));
                    MissionData.VectorList_01.Add(new Vector3(1258.799f, -622.2938f, 68.90398f));
                    MissionData.VectorList_02.Add(new Vector3(1233.232f, -593.3051f, 69.42253f));
                    MissionData.VectorList_01.Add(new Vector3(1244.551f, -585.997f, 68.82187f));
                    MissionData.VectorList_02.Add(new Vector3(1242.479f, -565.8297f, 69.65738f));
                    MissionData.VectorList_01.Add(new Vector3(1258.098f, -565.493f, 68.23525f));
                    MissionData.VectorList_02.Add(new Vector3(1239.262f, -513.1147f, 69.12914f));
                    MissionData.VectorList_01.Add(new Vector3(1248.86f, -522.4438f, 68.26224f));
                    MissionData.VectorList_02.Add(new Vector3(1251.532f, -494.2249f, 69.90682f));
                    MissionData.VectorList_01.Add(new Vector3(1261.78f, -493.555f, 68.59668f));
                    MissionData.VectorList_02.Add(new Vector3(1260.101f, -479.5116f, 70.18879f));
                    MissionData.VectorList_01.Add(new Vector3(1278.476f, -478.6996f, 68.22017f));
                    MissionData.VectorList_02.Add(new Vector3(1266.084f, -458.3353f, 70.51691f));
                    MissionData.VectorList_01.Add(new Vector3(1273.115f, -455.0135f, 68.57989f));
                    MissionData.VectorList_02.Add(new Vector3(1262.461f, -429.394f, 70.01487f));
                    MissionData.VectorList_01.Add(new Vector3(1275.764f, -424.0667f, 68.22583f));
                    MissionData.VectorList_02.Add(new Vector3(999.6509f, -602.5077f, 59.24988f));
                    MissionData.VectorList_01.Add(new Vector3(1007.827f, -589.7651f, 58.31434f));
                    MissionData.VectorList_02.Add(new Vector3(1010.405f, -572.106f, 60.59447f));
                    MissionData.VectorList_01.Add(new Vector3(1024.028f, -564.0795f, 58.89515f));
                    MissionData.VectorList_02.Add(new Vector3(976.5464f, -580.268f, 59.85033f));
                    MissionData.VectorList_01.Add(new Vector3(968.4319f, -570.5289f, 58.0456f));
                    MissionData.VectorList_02.Add(new Vector3(965.8971f, -609.0874f, 59.49282f));
                    MissionData.VectorList_01.Add(new Vector3(954.2767f, -596.7289f, 58.6325f));
                    MissionData.VectorList_02.Add(new Vector3(919.8752f, -569.8582f, 58.36637f));
                    MissionData.VectorList_01.Add(new Vector3(933.074f, -577.1251f, 56.91011f));
                    MissionData.VectorList_02.Add(new Vector3(965.7161f, -542.8255f, 59.35909f));
                    MissionData.VectorList_01.Add(new Vector3(973.2179f, -554.7656f, 58.32329f));
                    MissionData.VectorList_02.Add(new Vector3(988.0938f, -525.8449f, 60.69068f));
                    MissionData.VectorList_01.Add(new Vector3(989.012f, -543.071f, 58.85779f));
                    MissionData.VectorList_02.Add(new Vector3(1005.954f, -511.3791f, 60.83396f));
                    MissionData.VectorList_01.Add(new Vector3(1005.942f, -519.3906f, 59.9563f));
                    MissionData.VectorList_02.Add(new Vector3(1056.8f, -448.1799f, 66.25742f));
                    MissionData.VectorList_01.Add(new Vector3(1064.382f, -445.4654f, 65.09992f));
                    MissionData.VectorList_02.Add(new Vector3(1051.081f, -470.3268f, 64.29682f));
                    MissionData.VectorList_01.Add(new Vector3(1068.162f, -473.2799f, 63.43224f));
                    MissionData.VectorList_02.Add(new Vector3(1046.621f, -497.4203f, 64.07932f));
                    MissionData.VectorList_01.Add(new Vector3(1051.812f, -488.407f, 63.14861f));
                    MissionData.VectorList_02.Add(new Vector3(1089.776f, -484.1317f, 65.66021f));
                    MissionData.VectorList_01.Add(new Vector3(1077.637f, -482.2654f, 63.0863f));
                    MissionData.VectorList_02.Add(new Vector3(1097.907f, -464.9969f, 67.3194f));
                    MissionData.VectorList_01.Add(new Vector3(1080.9f, -462.766f, 64.13667f));
                    MissionData.VectorList_02.Add(new Vector3(1099.318f, -438.5551f, 67.7905f));
                    MissionData.VectorList_01.Add(new Vector3(1099.034f, -429.365f, 66.62222f));
                    MissionData.VectorList_02.Add(new Vector3(1100.173f, -411.3625f, 67.55515f));
                    MissionData.VectorList_01.Add(new Vector3(1090.41f, -417.8437f, 66.27037f));
                    MissionData.VectorList_02.Add(new Vector3(1121.068f, -396.8421f, 68.32484f));
                    MissionData.VectorList_01.Add(new Vector3(1103.595f, -399.2865f, 66.98724f));
                    MissionData.VectorList_02.Add(new Vector3(1014.722f, -469.2599f, 64.50301f));
                    MissionData.VectorList_01.Add(new Vector3(1013.713f, -452.9554f, 63.72364f));
                    MissionData.VectorList_02.Add(new Vector3(970.1812f, -502.0331f, 62.1409f));
                    MissionData.VectorList_01.Add(new Vector3(960.3265f, -501.11f, 60.9422f));
                    MissionData.VectorList_02.Add(new Vector3(946.805f, -518.6298f, 60.62551f));
                    MissionData.VectorList_01.Add(new Vector3(945.9794f, -509.9754f, 59.78003f));
                    MissionData.VectorList_02.Add(new Vector3(924.0212f, -525.62f, 59.78107f));
                    MissionData.VectorList_01.Add(new Vector3(922.7343f, -509.6968f, 58.43071f));
                    MissionData.VectorList_02.Add(new Vector3(892.7018f, -540.6726f, 58.50655f));
                    MissionData.VectorList_01.Add(new Vector3(886.5193f, -554.0729f, 57.34649f));
                    MissionData.VectorList_02.Add(new Vector3(979.9705f, -627.5128f, 59.23589f));
                    MissionData.VectorList_01.Add(new Vector3(974.6395f, -619.7267f, 58.43463f));
                    MissionData.VectorList_02.Add(new Vector3(989.3026f, -738.9448f, 57.46308f));
                    MissionData.VectorList_01.Add(new Vector3(1010.657f, -726.6682f, 57.08143f));
                    MissionData.VectorList_02.Add(new Vector3(979.4105f, -716.0731f, 58.22066f));
                    MissionData.VectorList_01.Add(new Vector3(982.3991f, -708.5142f, 57.17782f));
                    MissionData.VectorList_02.Add(new Vector3(970.9582f, -701.2431f, 58.48196f));
                    MissionData.VectorList_01.Add(new Vector3(972.29f, -686.0255f, 57.32935f));
                    MissionData.VectorList_02.Add(new Vector3(944.2244f, -678.2466f, 58.44977f));
                    MissionData.VectorList_01.Add(new Vector3(967.3783f, -656.6362f, 56.90245f));
                    MissionData.VectorList_02.Add(new Vector3(939.8877f, -663.1575f, 58.01383f));
                    MissionData.VectorList_01.Add(new Vector3(951.2182f, -653.0005f, 57.47144f));
                    MissionData.VectorList_02.Add(new Vector3(929.2795f, -639.2144f, 58.24234f));
                    MissionData.VectorList_01.Add(new Vector3(929.0761f, -626.1235f, 57.30887f));
                    MissionData.VectorList_02.Add(new Vector3(903.2495f, -615.7738f, 58.45334f));
                    MissionData.VectorList_01.Add(new Vector3(913.0081f, -620.7134f, 57.60374f));
                    MissionData.VectorList_02.Add(new Vector3(874.7638f, -607.1186f, 58.21776f));
                    MissionData.VectorList_01.Add(new Vector3(878.3079f, -592.7166f, 57.42387f));
                    MissionData.VectorList_02.Add(new Vector3(862.0755f, -582.3646f, 58.15649f));
                    MissionData.VectorList_01.Add(new Vector3(874.6371f, -586.4609f, 57.19283f));
                    MissionData.VectorList_02.Add(new Vector3(846.4515f, -551.504f, 57.70799f));
                    MissionData.VectorList_01.Add(new Vector3(851.7446f, -564.995f, 57.30214f));
                    MissionData.VectorList_02.Add(new Vector3(850.5616f, -532.464f, 57.92542f));
                    MissionData.VectorList_01.Add(new Vector3(865.4143f, -535.7256f, 56.76198f));
                    MissionData.VectorList_02.Add(new Vector3(861.998f, -509.8099f, 57.32896f));
                    MissionData.VectorList_01.Add(new Vector3(859.9089f, -522.9789f, 56.90236f));
                    MissionData.VectorList_02.Add(new Vector3(878.6312f, -498.1406f, 58.09062f));
                    MissionData.VectorList_01.Add(new Vector3(881.3627f, -513.0558f, 56.80643f));
                    MissionData.VectorList_02.Add(new Vector3(901.3936f, -472.5109f, 59.01522f));
                    MissionData.VectorList_01.Add(new Vector3(914.4992f, -490.2616f, 58.60363f));
                    MissionData.VectorList_02.Add(new Vector3(922.1134f, -478.2256f, 61.0836f));
                    MissionData.VectorList_01.Add(new Vector3(938.1192f, -489.2669f, 59.6607f));
                    MissionData.VectorList_02.Add(new Vector3(943.9189f, -463.2539f, 61.39602f));
                    MissionData.VectorList_01.Add(new Vector3(944.2679f, -471.275f, 60.84516f));
                    MissionData.VectorList_02.Add(new Vector3(961.065f, -458.4801f, 62.39756f));
                    MissionData.VectorList_01.Add(new Vector3(975.4355f, -452.9048f, 62.0961f));
                    MissionData.VectorList_02.Add(new Vector3(988.1276f, -433.536f, 63.89075f));
                    MissionData.VectorList_01.Add(new Vector3(998.2275f, -435.7723f, 63.65527f));
                    MissionData.VectorList_02.Add(new Vector3(1004.812f, -414.8121f, 64.94271f));
                    MissionData.VectorList_01.Add(new Vector3(1022.149f, -430.826f, 64.61664f));
                    MissionData.VectorList_02.Add(new Vector3(1029.585f, -409.1599f, 65.94939f));
                    MissionData.VectorList_01.Add(new Vector3(1025.356f, -423.0311f, 65.07549f));
                    MissionData.VectorList_02.Add(new Vector3(1060.76f, -378.5183f, 68.23116f));
                    MissionData.VectorList_01.Add(new Vector3(1058.172f, -388.1536f, 67.40376f));
                }
                else if (iArea == 2)//        "PALHIGH" || MyZone 0)//        "NOOSE" 
                {
                    MissionData.VectorList_02.Add(new Vector3(2520.735f, -414.4421f, 94.12382f));
                    MissionData.VectorList_01.Add(new Vector3(2531.759f, -404.8683f, 92.42744f));
                    MissionData.VectorList_02.Add(new Vector3(2515.324f, -357.0011f, 94.13097f));
                    MissionData.VectorList_01.Add(new Vector3(2533.931f, -360.9075f, 92.42843f));
                    MissionData.VectorList_02.Add(new Vector3(2459.782f, -383.9377f, 93.32551f));
                    MissionData.VectorList_01.Add(new Vector3(2451.829f, -383.2078f, 92.42839f));
                    MissionData.VectorList_02.Add(new Vector3(2825.373f, -648.0712f, 1.867333f));
                    MissionData.VectorList_01.Add(new Vector3(2824.316f, -667.1207f, 0.7700033f));
                    MissionData.VectorList_02.Add(new Vector3(1890.609f, -1019.087f, 78.56707f));
                    MissionData.VectorList_01.Add(new Vector3(1898.707f, -1020.049f, 78.33401f));
                }
                else if (iArea == 3)//        "TATAMO" || MyZone 0)//        "PALMPOW" || MyZone 0)//        "WINDF" 
                {
                    MissionData.VectorList_02.Add(new Vector3(2562.764f, 2591.259f, 38.08143f));
                    MissionData.VectorList_01.Add(new Vector3(2553.303f, 2616.184f, 37.38126f));
                    MissionData.VectorList_02.Add(new Vector3(2617.469f, 1690.186f, 27.59884f));
                    MissionData.VectorList_01.Add(new Vector3(2630.439f, 1650.774f, 25.7706f));
                    MissionData.VectorList_02.Add(new Vector3(2722.836f, 1510.59f, 24.5007f));
                    MissionData.VectorList_01.Add(new Vector3(2709.175f, 1521.067f, 23.93703f));
                    MissionData.VectorList_02.Add(new Vector3(2461.603f, 1575.208f, 33.11259f));
                    MissionData.VectorList_01.Add(new Vector3(2472.126f, 1583.449f, 32.15523f));
                    MissionData.VectorList_02.Add(new Vector3(1659.634f, -14.56253f, 169.9923f));
                    MissionData.VectorList_01.Add(new Vector3(1666.431f, -17.75419f, 173.2095f));
                    MissionData.VectorList_02.Add(new Vector3(1903.146f, 592.4578f, 178.3986f));
                    MissionData.VectorList_01.Add(new Vector3(1915.557f, 571.7368f, 174.9158f));
                    MissionData.VectorList_02.Add(new Vector3(2580.549f, 464.5234f, 108.6211f));
                    MissionData.VectorList_01.Add(new Vector3(2579.158f, 457.8897f, 107.8901f));
                }
                else if (iArea == 4)//        "HORS" || MyZone 0)//        "EAST_V"
                {
                    MissionData.VectorList_02.Add(new Vector3(705.1702f, -303.5435f, 59.24223f));
                    MissionData.VectorList_01.Add(new Vector3(704.0766f, -290.1624f, 58.62016f));
                    MissionData.VectorList_02.Add(new Vector3(977.1418f, -196.2304f, 74.84734f));
                    MissionData.VectorList_01.Add(new Vector3(961.8153f, -201.5031f, 72.54203f));
                    MissionData.VectorList_02.Add(new Vector3(894.9619f, -179.6218f, 74.70035f));
                    MissionData.VectorList_01.Add(new Vector3(909.2927f, -175.4855f, 73.63686f));
                    MissionData.VectorList_02.Add(new Vector3(981.9587f, -103.4368f, 74.84873f));
                    MissionData.VectorList_01.Add(new Vector3(979.7997f, -115.6234f, 73.57495f));
                    MissionData.VectorList_02.Add(new Vector3(952.8666f, -252.3892f, 67.98509f));
                    MissionData.VectorList_01.Add(new Vector3(946.447f, -255.0999f, 67.03085f));
                    MissionData.VectorList_02.Add(new Vector3(930.8372f, -245.196f, 69.00294f));
                    MissionData.VectorList_01.Add(new Vector3(924.669f, -254.4765f, 67.81981f));
                    MissionData.VectorList_02.Add(new Vector3(921.0618f, -238.4596f, 70.17359f));
                    MissionData.VectorList_01.Add(new Vector3(912.358f, -246.1808f, 68.61733f));
                    MissionData.VectorList_02.Add(new Vector3(880.0348f, -205.1522f, 71.97648f));
                    MissionData.VectorList_01.Add(new Vector3(872.5756f, -206.5369f, 70.22362f));
                    MissionData.VectorList_02.Add(new Vector3(840.3095f, -181.7112f, 74.18803f));
                    MissionData.VectorList_01.Add(new Vector3(840.9575f, -195.8371f, 72.03631f));
                    MissionData.VectorList_02.Add(new Vector3(808.4063f, -164.1897f, 75.74919f));
                    MissionData.VectorList_01.Add(new Vector3(803.6614f, -177.258f, 72.21603f));
                    MissionData.VectorList_02.Add(new Vector3(798.9208f, -159.3197f, 74.89246f));
                    MissionData.VectorList_01.Add(new Vector3(789.8212f, -171.2433f, 73.21214f));
                    MissionData.VectorList_02.Add(new Vector3(773.602f, -150.4751f, 75.61332f));
                    MissionData.VectorList_01.Add(new Vector3(768.3834f, -159.254f, 73.72443f));
                }
                else //        "CHIL" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-419.193f, 1146.05f, 325.8549f));
                    MissionData.VectorList_01.Add(new Vector3(-412.1227f, 1174.139f, 325.0765f));
                    MissionData.VectorList_02.Add(new Vector3(217.3246f, 1192.034f, 225.5947f));
                    MissionData.VectorList_01.Add(new Vector3(229.2496f, 1194.73f, 224.8951f));
                    MissionData.VectorList_02.Add(new Vector3(815.1804f, 543.0743f, 125.9202f));
                    MissionData.VectorList_01.Add(new Vector3(816.4588f, 561.2748f, 125.2159f));
                    MissionData.VectorList_02.Add(new Vector3(659.97f, 592.8452f, 129.0509f));
                    MissionData.VectorList_01.Add(new Vector3(645.7329f, 599.199f, 128.346f));
                    MissionData.VectorList_02.Add(new Vector3(-189.7077f, 977.7711f, 236.135f));
                    MissionData.VectorList_01.Add(new Vector3(-169.762f, 971.246f, 236.3166f));
                    MissionData.VectorList_02.Add(new Vector3(-144.6623f, 884.5777f, 233.5724f));
                    MissionData.VectorList_01.Add(new Vector3(-137.541f, 904.4686f, 235.2376f));
                    MissionData.VectorList_02.Add(new Vector3(-85.99014f, 834.6893f, 235.9201f));
                    MissionData.VectorList_01.Add(new Vector3(-106.22f, 833.5862f, 235.2054f));
                    MissionData.VectorList_02.Add(new Vector3(-46.26027f, 899.7635f, 231.5049f));
                    MissionData.VectorList_01.Add(new Vector3(-72.19061f, 896.1033f, 235.0206f));
                    MissionData.VectorList_02.Add(new Vector3(-104.0571f, 974.8898f, 235.7569f));
                    MissionData.VectorList_01.Add(new Vector3(-124.1415f, 990.1696f, 235.2449f));
                }
            }
            else if (Local == 5)
            {
                if (bRandom)
                    iArea = RandInt(1, 7);

                if (iArea == 1)//        "GREATC" || MyZone 0)//        "ZANCUDO" || MyZone 0)//        "SLAB" 
                {
                    MissionData.VectorList_02.Add(new Vector3(8.881083f, 3685.904f, 39.61732f));
                    MissionData.VectorList_01.Add(new Vector3(26.05397f, 3685.02f, 39.06121f));
                    MissionData.VectorList_02.Add(new Vector3(-462.365f, 2865.509f, 35.04441f));
                    MissionData.VectorList_01.Add(new Vector3(-449.1972f, 2861.065f, 35.08772f));
                    MissionData.VectorList_02.Add(new Vector3(-1105.215f, 2696.135f, 18.61517f));
                    MissionData.VectorList_01.Add(new Vector3(-1098.553f, 2690.11f, 19.06244f));
                    MissionData.VectorList_02.Add(new Vector3(-290.5939f, 2528.723f, 74.61299f));
                    MissionData.VectorList_01.Add(new Vector3(-283.2376f, 2542.211f, 74.01343f));
                    MissionData.VectorList_02.Add(new Vector3(-310.4129f, 2794.155f, 59.46859f));
                    MissionData.VectorList_01.Add(new Vector3(-317.8717f, 2748.369f, 66.60876f));
                }
                else if (iArea == 2)//        "DESRT" || MyZone 0)//        "HARMO" || MyZone 0)//        "RTRAK" || MyZone 0)//        "JAIL" 
                {
                    MissionData.VectorList_02.Add(new Vector3(1106.108f, 2652.767f, 38.14092f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1106.378f, 2648.518f, 38.14092f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1107.603f, 2641.913f, 38.14375f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1115.116f, 2641.803f, 38.14375f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1121.895f, 2641.998f, 38.14375f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1125.351f, 2641.756f, 38.14389f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1133.093f, 2641.903f, 38.1437f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1136.419f, 2641.913f, 38.1437f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1141.487f, 2642.028f, 38.1437f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1142.277f, 2643.694f, 38.1437f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1142.131f, 2651.322f, 38.14091f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(1142.421f, 2654.643f, 38.1504f));
                    MissionData.VectorList_01.Add(new Vector3(1137.087f, 2665.955f, 37.20128f));
                    MissionData.VectorList_02.Add(new Vector3(722.1896f, 2330.87f, 51.75035f));
                    MissionData.VectorList_01.Add(new Vector3(716.0236f, 2341.886f, 49.38189f));
                    MissionData.VectorList_02.Add(new Vector3(791.8693f, 2176.558f, 52.64839f));
                    MissionData.VectorList_01.Add(new Vector3(811.7886f, 2178.157f, 51.58363f));
                    MissionData.VectorList_02.Add(new Vector3(1535.814f, 2231.998f, 77.69906f));
                    MissionData.VectorList_01.Add(new Vector3(1524.794f, 2230.634f, 74.86063f));
                    MissionData.VectorList_02.Add(new Vector3(1392.468f, 2162.03f, 97.74464f));
                    MissionData.VectorList_01.Add(new Vector3(1402.862f, 2163.731f, 97.28335f));
                    MissionData.VectorList_02.Add(new Vector3(1586.27f, 2906.867f, 57.97039f));
                    MissionData.VectorList_01.Add(new Vector3(1587.733f, 2896.49f, 56.26361f));
                    MissionData.VectorList_02.Add(new Vector3(980.3115f, 2666.715f, 40.05014f));
                    MissionData.VectorList_01.Add(new Vector3(994.0294f, 2674.613f, 39.1761f));
                    MissionData.VectorList_02.Add(new Vector3(976.7388f, 2730.973f, 39.51086f));
                    MissionData.VectorList_01.Add(new Vector3(969.2026f, 2716.069f, 38.97165f));
                    MissionData.VectorList_02.Add(new Vector3(890.3466f, 2854.747f, 57.0004f));
                    MissionData.VectorList_01.Add(new Vector3(880.4413f, 2853.6f, 56.27011f));
                    MissionData.VectorList_02.Add(new Vector3(848.1699f, 2864.064f, 58.48573f));
                    MissionData.VectorList_01.Add(new Vector3(858.4886f, 2849.197f, 57.06968f));
                    MissionData.VectorList_02.Add(new Vector3(859.2158f, 2877.006f, 57.98265f));
                    MissionData.VectorList_01.Add(new Vector3(872.1891f, 2869.081f, 56.36434f));
                    MissionData.VectorList_02.Add(new Vector3(564.4514f, 2598.54f, 43.8341f));
                    MissionData.VectorList_01.Add(new Vector3(556.0435f, 2596.402f, 42.30201f));
                    MissionData.VectorList_02.Add(new Vector3(506.3685f, 2610.314f, 43.94688f));
                    MissionData.VectorList_01.Add(new Vector3(497.8611f, 2614.855f, 42.44781f));
                    MissionData.VectorList_02.Add(new Vector3(470.9477f, 2607.567f, 44.4772f));
                    MissionData.VectorList_01.Add(new Vector3(466.2688f, 2616.857f, 42.74304f));
                    MissionData.VectorList_02.Add(new Vector3(382.2904f, 2576.652f, 44.23201f));
                    MissionData.VectorList_01.Add(new Vector3(376.918f, 2575.872f, 43.00775f));
                    MissionData.VectorList_02.Add(new Vector3(366.9477f, 2571.536f, 44.49765f));
                    MissionData.VectorList_01.Add(new Vector3(355.9208f, 2574.071f, 43.0085f));
                    MissionData.VectorList_02.Add(new Vector3(348.3048f, 2565.5f, 43.51952f));
                    MissionData.VectorList_01.Add(new Vector3(342.304f, 2562.802f, 43.01845f));
                    MissionData.VectorList_02.Add(new Vector3(201.1159f, 2442.344f, 60.4483f));
                    MissionData.VectorList_01.Add(new Vector3(211.0188f, 2443.243f, 57.91403f));
                    MissionData.VectorList_02.Add(new Vector3(392.1702f, 2634.382f, 44.66927f));
                    MissionData.VectorList_01.Add(new Vector3(385.7183f, 2639.736f, 43.9827f));
                    MissionData.VectorList_02.Add(new Vector3(384.7893f, 2632.815f, 44.68297f));
                    MissionData.VectorList_01.Add(new Vector3(373.8996f, 2634.392f, 43.98769f));
                    MissionData.VectorList_02.Add(new Vector3(379.0063f, 2630.322f, 44.64661f));
                    MissionData.VectorList_01.Add(new Vector3(374.3689f, 2634.371f, 43.79418f));
                    MissionData.VectorList_02.Add(new Vector3(372.6312f, 2628.28f, 44.68018f));
                    MissionData.VectorList_01.Add(new Vector3(373.8996f, 2634.392f, 43.98738f));
                    MissionData.VectorList_02.Add(new Vector3(366.9004f, 2624.87f, 44.67241f));
                    MissionData.VectorList_01.Add(new Vector3(373.9002f, 2634.391f, 43.98606f));
                    MissionData.VectorList_02.Add(new Vector3(359.1547f, 2623.402f, 44.68687f));
                    MissionData.VectorList_01.Add(new Vector3(347.9727f, 2626.478f, 43.98643f));
                    MissionData.VectorList_02.Add(new Vector3(354.2147f, 2620.051f, 44.67242f));
                    MissionData.VectorList_01.Add(new Vector3(347.9726f, 2626.479f, 43.98935f));
                    MissionData.VectorList_02.Add(new Vector3(346.7339f, 2618.583f, 44.68309f));
                    MissionData.VectorList_01.Add(new Vector3(347.9692f, 2626.481f, 43.99496f));
                    MissionData.VectorList_02.Add(new Vector3(341.5994f, 2615.505f, 44.66917f));
                    MissionData.VectorList_01.Add(new Vector3(347.9725f, 2626.479f, 43.9882f));
                    MissionData.VectorList_02.Add(new Vector3(-35.57145f, 2871.392f, 59.59684f));
                    MissionData.VectorList_01.Add(new Vector3(-37.22775f, 2865.152f, 58.68879f));
                    MissionData.VectorList_02.Add(new Vector3(195.0032f, 3030.994f, 43.88666f));
                    MissionData.VectorList_01.Add(new Vector3(199.7019f, 3038.737f, 42.86736f));
                    MissionData.VectorList_02.Add(new Vector3(241.1663f, 3107.958f, 42.48717f));
                    MissionData.VectorList_01.Add(new Vector3(233.7224f, 3094.945f, 41.97177f));
                    MissionData.VectorList_02.Add(new Vector3(190.2618f, 3094.545f, 43.07414f));
                    MissionData.VectorList_01.Add(new Vector3(177.1561f, 3095.674f, 42.49979f));
                    MissionData.VectorList_02.Add(new Vector3(248.6368f, 3180.585f, 42.91877f));
                    MissionData.VectorList_01.Add(new Vector3(236.9269f, 3163.9f, 42.0658f));
                }
                else if (iArea == 3)//        "ZQ_UAR" 
                {
                    MissionData.VectorList_02.Add(new Vector3(2569.701f, 2719.698f, 42.90607f));
                    MissionData.VectorList_01.Add(new Vector3(2574.727f, 2716.069f, 41.63546f));
                    MissionData.VectorList_02.Add(new Vector3(2833.906f, 2806.462f, 57.40425f));
                    MissionData.VectorList_01.Add(new Vector3(2828.2f, 2796.574f, 56.86005f));
                    MissionData.VectorList_02.Add(new Vector3(2745.813f, 2787.738f, 35.57073f));
                    MissionData.VectorList_01.Add(new Vector3(2732.689f, 2780.434f, 35.11758f));
                    MissionData.VectorList_02.Add(new Vector3(2706.889f, 2776.905f, 37.87803f));
                    MissionData.VectorList_01.Add(new Vector3(2695.961f, 2773.133f, 37.06485f));
                    MissionData.VectorList_02.Add(new Vector3(2627.236f, 2935.35f, 40.42284f));
                    MissionData.VectorList_01.Add(new Vector3(2622.771f, 2910.397f, 35.8194f));
                    MissionData.VectorList_02.Add(new Vector3(2663.344f, 2891.49f, 36.90667f));
                    MissionData.VectorList_01.Add(new Vector3(2659.201f, 2899.723f, 35.50852f));
                    MissionData.VectorList_02.Add(new Vector3(2601.118f, 2803.863f, 33.82192f));
                    MissionData.VectorList_01.Add(new Vector3(2592.893f, 2797.829f, 33.27939f));

                }
                else if (iArea == 4)//        "SANDY" 
                {
                    MissionData.VectorList_02.Add(new Vector3(2389.463f, 3341.572f, 47.72219f));
                    MissionData.VectorList_01.Add(new Vector3(2396.545f, 3325.496f, 46.83057f));
                    MissionData.VectorList_02.Add(new Vector3(2392.829f, 3320.546f, 48.45065f));
                    MissionData.VectorList_01.Add(new Vector3(2396.545f, 3325.496f, 46.83057f));
                    MissionData.VectorList_02.Add(new Vector3(2489.863f, 3442.953f, 50.06467f));
                    MissionData.VectorList_01.Add(new Vector3(2477.348f, 3425.041f, 49.09996f));
                    MissionData.VectorList_02.Add(new Vector3(1385.014f, 3659.524f, 34.92771f));
                    MissionData.VectorList_01.Add(new Vector3(1385.874f, 3676.129f, 32.83449f));
                    MissionData.VectorList_02.Add(new Vector3(1406.574f, 3656.235f, 34.21167f));
                    MissionData.VectorList_01.Add(new Vector3(1397.748f, 3669.189f, 33.09452f));
                    MissionData.VectorList_02.Add(new Vector3(1536.855f, 3707.824f, 34.82714f));
                    MissionData.VectorList_01.Add(new Vector3(1521.929f, 3719.167f, 33.54586f));
                    MissionData.VectorList_02.Add(new Vector3(1827.154f, 3729.609f, 33.96196f));
                    MissionData.VectorList_01.Add(new Vector3(1831.226f, 3722.84f, 32.44462f));
                    MissionData.VectorList_02.Add(new Vector3(1851.281f, 3784.816f, 33.04296f));
                    MissionData.VectorList_01.Add(new Vector3(1847.915f, 3766.17f, 32.21405f));
                    MissionData.VectorList_02.Add(new Vector3(1900.309f, 3772.731f, 32.87964f));
                    MissionData.VectorList_01.Add(new Vector3(1906.825f, 3784.434f, 31.81898f));
                    MissionData.VectorList_02.Add(new Vector3(1880.978f, 3810.795f, 32.77878f));
                    MissionData.VectorList_01.Add(new Vector3(1892.596f, 3815.768f, 31.49548f));
                    MissionData.VectorList_02.Add(new Vector3(1777.051f, 3799.372f, 34.54548f));
                    MissionData.VectorList_01.Add(new Vector3(1769.489f, 3788.509f, 33.01802f));
                    MissionData.VectorList_02.Add(new Vector3(1639.738f, 3731.604f, 35.0671f));
                    MissionData.VectorList_01.Add(new Vector3(1648.793f, 3727.542f, 33.49438f));
                    MissionData.VectorList_02.Add(new Vector3(1661.924f, 3820.039f, 35.46976f));
                    MissionData.VectorList_01.Add(new Vector3(1666.821f, 3808.889f, 34.00944f));
                    MissionData.VectorList_02.Add(new Vector3(1691.653f, 3866.071f, 34.90841f));
                    MissionData.VectorList_01.Add(new Vector3(1682.875f, 3870.218f, 34.03076f));
                    MissionData.VectorList_02.Add(new Vector3(1837.934f, 3916.815f, 33.24038f));
                    MissionData.VectorList_01.Add(new Vector3(1837.688f, 3902.202f, 32.38109f));
                    MissionData.VectorList_02.Add(new Vector3(1832.167f, 3868.24f, 34.2976f));
                    MissionData.VectorList_01.Add(new Vector3(1822.602f, 3874.45f, 32.92525f));
                    MissionData.VectorList_02.Add(new Vector3(1858.24f, 3854.265f, 33.08321f));
                    MissionData.VectorList_01.Add(new Vector3(1864.39f, 3845.125f, 31.78188f));
                    MissionData.VectorList_02.Add(new Vector3(1902.802f, 3866.26f, 33.06639f));
                    MissionData.VectorList_01.Add(new Vector3(1908.797f, 3859.409f, 31.54244f));
                    MissionData.VectorList_02.Add(new Vector3(1894.084f, 3895.881f, 33.15143f));
                    MissionData.VectorList_01.Add(new Vector3(1884.966f, 3886.014f, 32.10987f));
                    MissionData.VectorList_02.Add(new Vector3(1916.24f, 3909.3f, 33.44159f));
                    MissionData.VectorList_01.Add(new Vector3(1929.137f, 3921.694f, 31.60845f));
                    MissionData.VectorList_02.Add(new Vector3(1936.745f, 3891.11f, 32.53016f));
                    MissionData.VectorList_01.Add(new Vector3(1937.799f, 3877.645f, 31.41957f));
                    MissionData.VectorList_02.Add(new Vector3(2179.24f, 3496.884f, 45.88393f));
                    MissionData.VectorList_01.Add(new Vector3(2171.346f, 3506.891f, 44.64259f));
                    MissionData.VectorList_02.Add(new Vector3(2163.232f, 3374.59f, 46.14158f));
                    MissionData.VectorList_01.Add(new Vector3(2169.843f, 3365.11f, 44.7066f));
                    MissionData.VectorList_02.Add(new Vector3(2200.855f, 3318.164f, 46.88804f));
                    MissionData.VectorList_01.Add(new Vector3(2214.03f, 3309.552f, 45.19223f));
                }
                else if (iArea == 5)//        "ALAMO" 
                {
                    MissionData.VectorList_02.Add(new Vector3(387.3527f, 3584.745f, 33.29222f));
                    MissionData.VectorList_01.Add(new Vector3(378.4148f, 3592.091f, 32.48848f));
                    MissionData.VectorList_02.Add(new Vector3(438.4768f, 3570.548f, 33.89853f));
                    MissionData.VectorList_01.Add(new Vector3(426.7444f, 3578.094f, 32.42588f));
                    MissionData.VectorList_02.Add(new Vector3(911.0425f, 3644.367f, 32.67706f));
                    MissionData.VectorList_01.Add(new Vector3(910.9032f, 3637.734f, 31.6573f));
                    MissionData.VectorList_02.Add(new Vector3(899.5674f, 3582.851f, 33.41278f));
                    MissionData.VectorList_01.Add(new Vector3(908.0741f, 3590.216f, 32.38536f));
                    MissionData.VectorList_02.Add(new Vector3(959.2548f, 3619.023f, 32.66993f));
                    MissionData.VectorList_01.Add(new Vector3(950.4551f, 3615.18f, 31.81508f));
                }
                else if (iArea == 6)//        "SANCHIA" || MyZone 0)//        "HUMLAB" 
                {
                    MissionData.VectorList_02.Add(new Vector3(3807.908f, 4478.596f, 6.365325f));
                    MissionData.VectorList_01.Add(new Vector3(3794.228f, 4467.279f, 4.846033f));
                    MissionData.VectorList_02.Add(new Vector3(3725.273f, 4525.252f, 22.46952f));
                    MissionData.VectorList_01.Add(new Vector3(3712.427f, 4519.564f, 20.82699f));
                    MissionData.VectorList_02.Add(new Vector3(3688.062f, 4562.869f, 25.18306f));
                    MissionData.VectorList_01.Add(new Vector3(3694.858f, 4557.306f, 24.63262f));
                    MissionData.VectorList_02.Add(new Vector3(2890.177f, 4391.291f, 50.33842f));
                    MissionData.VectorList_01.Add(new Vector3(2898.639f, 4387.975f, 49.53016f));
                    MissionData.VectorList_02.Add(new Vector3(2660.38f, 3291.893f, 55.82876f));
                    MissionData.VectorList_01.Add(new Vector3(2650.044f, 3282.463f, 54.71011f));
                    MissionData.VectorList_02.Add(new Vector3(2632.871f, 3258.812f, 55.46336f));
                    MissionData.VectorList_01.Add(new Vector3(2638.369f, 3265.512f, 54.72956f));
                }
                else //        "GRAPES" || MyZone 0)//        "GALFISH"
                {
                    MissionData.VectorList_02.Add(new Vector3(1338.701f, 4359.917f, 44.36738f));
                    MissionData.VectorList_01.Add(new Vector3(1345.047f, 4368.24f, 43.90841f));
                    MissionData.VectorList_02.Add(new Vector3(1366.181f, 4358.456f, 44.5f));
                    MissionData.VectorList_01.Add(new Vector3(1368.074f, 4367.771f, 43.932f));
                    MissionData.VectorList_02.Add(new Vector3(1374.121f, 4381.065f, 45.11992f));
                    MissionData.VectorList_01.Add(new Vector3(1367.757f, 4376.39f, 43.89225f));
                    MissionData.VectorList_02.Add(new Vector3(1429.394f, 4377.73f, 44.59793f));
                    MissionData.VectorList_01.Add(new Vector3(1423.805f, 4384.286f, 43.51751f));
                    MissionData.VectorList_02.Add(new Vector3(1663.095f, 4775.675f, 42.00761f));
                    MissionData.VectorList_01.Add(new Vector3(1670.112f, 4769.056f, 41.45914f));
                    MissionData.VectorList_02.Add(new Vector3(1659.559f, 4756.741f, 41.96615f));
                    MissionData.VectorList_01.Add(new Vector3(1670.749f, 4751.769f, 41.44023f));
                    MissionData.VectorList_02.Add(new Vector3(1675.876f, 4680.809f, 43.05522f));
                    MissionData.VectorList_01.Add(new Vector3(1686.044f, 4680.881f, 42.62078f));
                    MissionData.VectorList_02.Add(new Vector3(1718.966f, 4676.812f, 43.65579f));
                    MissionData.VectorList_01.Add(new Vector3(1711.55f, 4669.007f, 42.65202f));
                    MissionData.VectorList_02.Add(new Vector3(1674.403f, 4657.681f, 43.37113f));
                    MissionData.VectorList_01.Add(new Vector3(1681.119f, 4653.235f, 42.55849f));
                    MissionData.VectorList_02.Add(new Vector3(1724.62f, 4641.602f, 43.87546f));
                    MissionData.VectorList_01.Add(new Vector3(1723.476f, 4629.428f, 42.39647f));
                    MissionData.VectorList_02.Add(new Vector3(1966.87f, 4634.104f, 41.1016f));
                    MissionData.VectorList_01.Add(new Vector3(1963.076f, 4643.931f, 39.92876f));
                }
            }
            else
            {
                if (bRandom)
                    iArea = RandInt(1, 4);

                if (iArea == 1)//        "NCHU" || MyZone 0)//        "MTJOSE" || MyZone 0)//        "ARMYB"     "CANNY" || MyZone 0)//        "CCREAK"   "CMSW" ||  MyZone 0)//        "PALCOV" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-2192.83f, 4285.766f, 49.17549f));
                    MissionData.VectorList_01.Add(new Vector3(-2197.211f, 4268.291f, 48.03174f));
                    MissionData.VectorList_02.Add(new Vector3(-2230.192f, 3481.066f, 30.16892f));
                    MissionData.VectorList_01.Add(new Vector3(-2244.532f, 3473.812f, 29.93354f));

                    MissionData.VectorList_02.Add(new Vector3(-1555.876f, 4460.74f, 17.30642f));
                    MissionData.VectorList_01.Add(new Vector3(-1553.37f, 4480.744f, 19.11336f));
                    MissionData.VectorList_02.Add(new Vector3(-1072.359f, 4369.473f, 13.50683f));
                    MissionData.VectorList_01.Add(new Vector3(-1065.936f, 4376.642f, 11.79403f));
                    MissionData.VectorList_02.Add(new Vector3(-1350.143f, 4261.536f, 7.27169f));
                    MissionData.VectorList_01.Add(new Vector3(-1360.185f, 4297.027f, 1.867007f));

                    MissionData.VectorList_02.Add(new Vector3(-1042.253f, 4909.827f, 208.3053f));
                    MissionData.VectorList_01.Add(new Vector3(-1037.468f, 4916.057f, 206.3439f));
                    MissionData.VectorList_02.Add(new Vector3(-1490.407f, 4981.597f, 63.35542f));
                    MissionData.VectorList_01.Add(new Vector3(-1496.595f, 4981.688f, 62.52434f));
                    MissionData.VectorList_02.Add(new Vector3(-1567.983f, 5178.375f, 15.77355f));
                    MissionData.VectorList_01.Add(new Vector3(-1581.282f, 5165.406f, 19.15366f));
                }
                else if (iArea == 2)//        "MTCHIL" || MyZone 0)//        "PROCOB" || MyZone 0)//        "PALFOR" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-502.3836f, 5264.665f, 80.61025f));
                    MissionData.VectorList_01.Add(new Vector3(-512.0334f, 5258.259f, 80.2546f));
                    MissionData.VectorList_02.Add(new Vector3(-552.933f, 5348.917f, 74.74302f));
                    MissionData.VectorList_01.Add(new Vector3(-566.3308f, 5352.837f, 69.61542f));
                    MissionData.VectorList_02.Add(new Vector3(-709.4831f, 5769.405f, 17.5092f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-701.7791f, 5765.044f, 17.51088f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-698.0701f, 5763.163f, 17.51098f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-694.1993f, 5761.503f, 17.511f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-689.9605f, 5759.66f, 17.511f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-687.4717f, 5758.861f, 17.511f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-685.622f, 5762.833f, 17.511f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-682.1684f, 5770.896f, 17.51058f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-683.8336f, 5766.68f, 17.511f));
                    MissionData.VectorList_01.Add(new Vector3(-694.3478f, 5772.844f, 16.9762f));
                    MissionData.VectorList_02.Add(new Vector3(-749.814f, 5598.417f, 40.64638f));
                    MissionData.VectorList_01.Add(new Vector3(-772.4623f, 5583.537f, 33.13069f));
                    MissionData.VectorList_02.Add(new Vector3(-841.0642f, 5401.115f, 34.61522f));
                    MissionData.VectorList_01.Add(new Vector3(-838.1064f, 5410.326f, 34.10001f));
                }
                else if (iArea == 3)//        "PALETO" 
                {
                    MissionData.VectorList_02.Add(new Vector3(-371.8559f, 6335.212f, 29.84368f));
                    MissionData.VectorList_01.Add(new Vector3(-359.8704f, 6328.174f, 29.0792f));
                    MissionData.VectorList_02.Add(new Vector3(-272.5724f, 6400.933f, 31.50485f));
                    MissionData.VectorList_01.Add(new Vector3(-262.445f, 6402.843f, 30.19f));
                    MissionData.VectorList_02.Add(new Vector3(-246.0781f, 6414.225f, 31.4606f));
                    MissionData.VectorList_01.Add(new Vector3(-248.9544f, 6406.491f, 30.78173f));
                    MissionData.VectorList_02.Add(new Vector3(-230.1529f, 6445.155f, 31.19745f));
                    MissionData.VectorList_01.Add(new Vector3(-223.0589f, 6432.951f, 30.84467f));
                    MissionData.VectorList_02.Add(new Vector3(-130.6867f, 6551.887f, 29.87188f));
                    MissionData.VectorList_01.Add(new Vector3(-124.9483f, 6550.625f, 29.07267f));
                    MissionData.VectorList_02.Add(new Vector3(-41.50317f, 6637.042f, 31.08753f));
                    MissionData.VectorList_01.Add(new Vector3(-39.79873f, 6625.59f, 29.81621f));
                    MissionData.VectorList_02.Add(new Vector3(-9.389118f, 6654.011f, 31.50423f));
                    MissionData.VectorList_01.Add(new Vector3(-14.04558f, 6645.291f, 30.75609f));
                    MissionData.VectorList_02.Add(new Vector3(35.13187f, 6662.611f, 32.19038f));
                    MissionData.VectorList_01.Add(new Vector3(22.50064f, 6655.907f, 31.11742f));

                    MissionData.VectorList_02.Add(new Vector3(-453.2734f, 6337.072f, 13.09414f));
                    MissionData.VectorList_01.Add(new Vector3(-447.8893f, 6347.536f, 11.89663f));
                    MissionData.VectorList_02.Add(new Vector3(-480.8771f, 6266.04f, 13.6347f));
                    MissionData.VectorList_01.Add(new Vector3(-491.188f, 6263.797f, 11.58691f));
                    MissionData.VectorList_02.Add(new Vector3(-14.98113f, 6557.459f, 33.24044f));
                    MissionData.VectorList_01.Add(new Vector3(-6.39504f, 6559.146f, 31.26225f));
                    MissionData.VectorList_02.Add(new Vector3(11.70875f, 6578.31f, 33.0708f));
                    MissionData.VectorList_01.Add(new Vector3(18.09615f, 6580.185f, 31.61535f));
                    MissionData.VectorList_02.Add(new Vector3(25.71288f, 6602.099f, 32.47048f));
                    MissionData.VectorList_01.Add(new Vector3(41.19342f, 6605.401f, 31.70087f));
                    MissionData.VectorList_02.Add(new Vector3(1.700827f, 6612.539f, 32.07838f));
                    MissionData.VectorList_01.Add(new Vector3(-4.421872f, 6617.645f, 30.76105f));
                    MissionData.VectorList_02.Add(new Vector3(-26.80732f, 6597.684f, 31.86026f));
                    MissionData.VectorList_01.Add(new Vector3(-17.67091f, 6608.921f, 30.31045f));
                    MissionData.VectorList_02.Add(new Vector3(-33.86079f, 6571.095f, 31.47055f));
                    MissionData.VectorList_01.Add(new Vector3(-39.9745f, 6591.987f, 29.84397f));
                    MissionData.VectorList_02.Add(new Vector3(-105.4981f, 6528.586f, 30.16692f));
                    MissionData.VectorList_01.Add(new Vector3(-108.3041f, 6537.882f, 29.08501f));
                    MissionData.VectorList_02.Add(new Vector3(-180.695f, 6404.67f, 31.88605f));
                    MissionData.VectorList_01.Add(new Vector3(-190.6143f, 6415.651f, 31.17549f));
                    MissionData.VectorList_02.Add(new Vector3(-213.6821f, 6396.523f, 33.0851f));
                    MissionData.VectorList_01.Add(new Vector3(-207.1203f, 6407.241f, 31.05694f));
                    MissionData.VectorList_02.Add(new Vector3(-227.5194f, 6378.039f, 31.75923f));
                    MissionData.VectorList_01.Add(new Vector3(-223.1334f, 6385.887f, 30.87843f));
                    MissionData.VectorList_02.Add(new Vector3(-247.9305f, 6370.228f, 31.84764f));
                    MissionData.VectorList_01.Add(new Vector3(-256.1295f, 6362.513f, 30.77239f));
                    MissionData.VectorList_02.Add(new Vector3(-280.6378f, 6350.979f, 32.57881f));
                    MissionData.VectorList_01.Add(new Vector3(-272.5419f, 6360.252f, 31.20849f));
                    MissionData.VectorList_02.Add(new Vector3(-302.668f, 6327.436f, 32.88649f));
                    MissionData.VectorList_01.Add(new Vector3(-295.5428f, 6339.388f, 31.43028f));
                    MissionData.VectorList_02.Add(new Vector3(-316.6211f, 6294.715f, 32.48936f));
                    MissionData.VectorList_01.Add(new Vector3(-316.8424f, 6315.597f, 31.3995f));
                    MissionData.VectorList_02.Add(new Vector3(-374.4959f, 6190.917f, 31.72955f));
                    MissionData.VectorList_01.Add(new Vector3(-376.7037f, 6183.094f, 30.78619f));
                    MissionData.VectorList_02.Add(new Vector3(-367.3759f, 6213.406f, 31.84218f));
                    MissionData.VectorList_01.Add(new Vector3(-366.3954f, 6200.037f, 30.78314f));
                    MissionData.VectorList_02.Add(new Vector3(-347.6381f, 6225.237f, 31.8841f));
                    MissionData.VectorList_01.Add(new Vector3(-348.7925f, 6217.142f, 30.78026f));
                    MissionData.VectorList_02.Add(new Vector3(-371.1718f, 6267.241f, 31.87273f));
                    MissionData.VectorList_01.Add(new Vector3(-367.3638f, 6281.116f, 29.35941f));
                    MissionData.VectorList_02.Add(new Vector3(-379.793f, 6252.999f, 31.85118f));
                    MissionData.VectorList_01.Add(new Vector3(-383.5283f, 6268.838f, 29.99367f));
                    MissionData.VectorList_02.Add(new Vector3(-454.6533f, 6204.072f, 29.55285f));
                    MissionData.VectorList_01.Add(new Vector3(-437.5063f, 6204.955f, 28.87807f));
                    MissionData.VectorList_02.Add(new Vector3(-446.5808f, 6259.138f, 30.0415f));
                    MissionData.VectorList_01.Add(new Vector3(-431.2646f, 6264.82f, 29.62897f));
                    MissionData.VectorList_02.Add(new Vector3(-406.9542f, 6313.816f, 28.94232f));
                    MissionData.VectorList_01.Add(new Vector3(-394.35f, 6309.122f, 28.48195f));
                }
                else //        "BRADP" || MyZone 0)//        "MTGORDO" || MyZone 0)//        "ELGORL"
                {
                    MissionData.VectorList_02.Add(new Vector3(2017.828f, 6265.965f, 45.32155f));
                    MissionData.VectorList_01.Add(new Vector3(2002.664f, 6241.593f, 45.94011f));
                    MissionData.VectorList_02.Add(new Vector3(3380.229f, 5501.306f, 23.49531f));
                    MissionData.VectorList_01.Add(new Vector3(3357.473f, 5510.913f, 18.17108f));
                    MissionData.VectorList_02.Add(new Vector3(3346.712f, 5179.848f, 14.0603f));
                    MissionData.VectorList_01.Add(new Vector3(3327.778f, 5151.634f, 17.95325f));
                    MissionData.VectorList_02.Add(new Vector3(2935.547f, 5323.863f, 100.555f));
                    MissionData.VectorList_01.Add(new Vector3(2917.3f, 5312.813f, 95.62965f));
                }
            }

            if (bUseCustom)
            {
                if (FindBuiltMissions(4))
                {
                    List<Vector3> NewStops_01 = new List<Vector3>();
                    List<Vector3> NewStops_02 = new List<Vector3>();

                    for (int i = 0; i < MissionData.MyMissions.FubardXM.Count; i++)
                    {
                        NewStops_01.Add(MissionData.MyMissions.FubardXM[i].FUbarCar);
                        NewStops_02.Add(MissionData.MyMissions.FubardXM[i].FUbarPed);
                    }

                    if (NewStops_01.Count > 0)
                    {
                        for (int i = 0; i < NewStops_01.Count; i++)
                        {
                            MissionData.VectorList_01.Add(NewStops_01[i]);
                            MissionData.VectorList_02.Add(NewStops_02[i]);
                        }
                    }
                }
            }

            return iArea;
        }
        public static bool Fire_BurnOut()
        {
            LoggerLight.LogThis("Fire_BurnOut");

            bool bOver = false;

            if (MissionData.iMissionVar_02 < Game.GameTime)
                bOver = true;
            else
            {
                int iTimeLeft = Game.GameTime - MissionData.iMissionVar_02;
                iTimeLeft = iTimeLeft + 60000;
                float fSake = (int)iTimeLeft;
                float fTimeLeft = fSake / 60000.00f;

                float fCash = fTimeLeft * 1000.00f;
                double iRewRD = (float)fCash;
                MissionData.iCashBouns = 1000 - (int)Math.Floor(iRewRD);

                if (fTimeLeft > 0.90)
                    UiDisplay.BtSlideBar.ForegroundColor = Color.Red;
                else
                    UiDisplay.BtSlideBar.ForegroundColor = Color.Yellow;

                UiDisplay.BtSlideBar.Percentage = fTimeLeft;
                UiDisplay.ttTextBar_01.Text = "$ " + MissionData.iCashBouns + "";

                if (!UiDisplay.bUiDisplay)
                    UiDisplay.bUiDisplay = true;
            }
            return bOver;
        }
        public static bool Fire_IntheHall(Vector3 VFire)
        {
            LoggerLight.LogThis("Fire_IntheHall");

            bool Bfiredup = false;
            int iFirey = Function.Call<int>(Hash.GET_NUMBER_OF_FIRES_IN_RANGE, VFire.X, VFire.Y, VFire.Z, 5.00f);
            if (iFirey < 1)
                Bfiredup = true;

            return Bfiredup;
        }
        public static List<string> Racist_Carz(int iRace)
        {
            LoggerLight.LogThis("Racist_Carz, iRace == " + iRace);

            List<string> sVehicles = new List<string>();

            if (iRace == 1)
            {
                sVehicles.Add("FORMULA"); //<!-- PR4, should be Open Wheel class-->
                sVehicles.Add("FORMULA2"); //<!-- R88, should be Open Wheel class-->
                sVehicles.Add("OPENWHEEL1"); //
                sVehicles.Add("OPENWHEEL2"); //

                if (DataStore.MyCusVeh.MyCarz.Count > 0)
                {
                    for (int i = 0; i < DataStore.MyCusVeh.MyCarz.Count; i++)
                        sVehicles.Add(DataStore.MyCusVeh.MyCarz[i]);
                }
            }
            else if (iRace == 2)
            {
                sVehicles.Add("SEASHARK"); //
                sVehicles.Add("SEASHARK2"); //<!-- Lifeguard Seashark -->
                sVehicles.Add("SEASHARK3"); //<!-- Seashark yacht variant -->

                if (DataStore.MyCusVeh.MyBoatz.Count > 0)
                {
                    for (int i = 0; i < DataStore.MyCusVeh.MyBoatz.Count; i++)
                        sVehicles.Add(DataStore.MyCusVeh.MyBoatz[i]);
                }
            }
            else if (iRace == 3)
            {
                sVehicles = VehicleListX(1, 20, false);
            }
            else if (iRace == 4)
            {
                sVehicles.Add("BUZZARD2"); //<!-- Buzzard -->
                sVehicles.Add("HAVOK"); //
                sVehicles.Add("FROGGER"); //
                sVehicles.Add("SEASPARROW2"); //

                if (DataStore.MyCusVeh.MyChopperz.Count > 0)
                {
                    for (int i = 0; i < DataStore.MyCusVeh.MyChopperz.Count; i++)
                        sVehicles.Add(DataStore.MyCusVeh.MyChopperz[i]);
                }
            }
            else if (iRace == 5)
            {
                sVehicles = VehicleListX(1, 19, false);
            }
            else if (iRace == 6)
            {
                sVehicles = VehicleListX(2, 1, true);
            }
            else if (iRace == 7)
            {
                sVehicles.Add("SULTANRS");
                sVehicles.Add("COMET4");
                sVehicles.Add("TAMPA2");
                sVehicles.Add("GB200");
                sVehicles.Add("KURUMA");
                sVehicles.Add("TROPHYTRUCK2");
                sVehicles.Add("TROPHYTRUCK");
                sVehicles.Add("ISSI7");
                sVehicles.Add("SUGOI");
                sVehicles.Add("SULTAN2");
                sVehicles.Add("WINKY");
                sVehicles.Add("OUTLAW");
                sVehicles.Add("VAGRANT");

                if (DataStore.MyCusVeh.MyCarz.Count > 0)
                {
                    for (int i = 0; i < DataStore.MyCusVeh.MyCarz.Count; i++)
                        sVehicles.Add(DataStore.MyCusVeh.MyCarz[i]);
                }
            }

            return sVehicles;
        }
        public static int CheckPointPro(bool bEnd, List<Vector3> CheckList, int iCheckPoints)
        {
            ObjectHand.RemoveTargets();

            iCheckPoints += 1;
            int iCheck = iCheckPoints + 1;

            if (bEnd)
            {
                iCheck = 0;
                MissionData.vTarget_02 = MissionData.vTarget_01;
                MissionData.vTarget_01 = CheckList[iCheck];
                ObjectHand.RacingBlimps(true, MissionData.vTarget_01);
                ObjectHand.Racist_AddRaceCheckPoints(true, CheckList, iCheck);
            }
            else
            {
                if (iCheck == CheckList.Count)
                    iCheck = 0;
                else if (iCheckPoints == CheckList.Count)
                    iCheck = 1;

                if (iCheckPoints < CheckList.Count)
                {
                    MissionData.vTarget_02 = MissionData.vTarget_01;
                    MissionData.vTarget_01 = CheckList[iCheckPoints];
                    ObjectHand.RacingBlimps(true, MissionData.vTarget_01);
                    ObjectHand.RacingBlimps(false, CheckList[iCheck]);
                }
                else
                {
                    iCheckPoints = 0;
                    MissionData.vTarget_02 = MissionData.vTarget_01;
                    MissionData.vTarget_01 = CheckList[iCheckPoints];
                    ObjectHand.RacingBlimps(true, MissionData.vTarget_01);
                    ObjectHand.RacingBlimps(false, CheckList[iCheck]);
                }
                ObjectHand.Racist_AddRaceCheckPoints(false, CheckList, iCheckPoints);

                iCheck = iCheckPoints;
            }

            return iCheck;
        }
        public static bool Water05_CargoBobed(Vehicle MyVick)
        {
            bool bCargoAttached = false;
            if (Game.Player.Character.IsInVehicle())
            {
                if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, Game.Player.Character.CurrentVehicle.Handle, MyVick.Handle))
                    bCargoAttached = true;
            }
            return bCargoAttached;
        }
        public static bool BeenSpotted(Ped Guard, Ped Target, bool bAlive)
        {
            bool bSeeingYou = false;
            if (Guard.IsAlive)
            {
                Vector3 Vdir = (Target.Position - Guard.Position).Normalized;
                float fDirValue = Vector3.Dot(Vdir, Guard.ForwardVector);
                if (Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY, Guard.Handle, Target.Handle, 17))
                {
                    if (Guard.Position.DistanceTo(Target.Position) < 35.00f)
                    {
                        if (fDirValue > 0.25f)
                            bSeeingYou = true;
                    }
                }
                if (bAlive)
                {
                    if (Function.Call<bool>(Hash.CAN_PED_HEAR_PLAYER, Target.Handle, Guard.Handle))
                        bSeeingYou = true;
                    if (Guard.IsInCombatAgainst(Target))
                        bSeeingYou = true;
                }
                else
                {
                    if (bSeeingYou)
                        Guard.CurrentBlip.Color = BlipColor.Orange;
                }
            }
            return bSeeingYou;
        }
        public static string ImportsExpo_CarList(int iVechList)
        {
            LoggerLight.LogThis("ImportsExpo_CarList, iVechList == " + iVechList);

            List<string> sVehicles = new List<string>();

            string sThisVehicle = "";

            if (iVechList == 1)
            {
                sVehicles = VehicleListX(1, 1, false);

                int iCar = FindRandom(43, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }            //Super
            else if (iVechList == 2)
            {
                sVehicles = VehicleListX(3, 1, false);

                int iCar = FindRandom(44, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Coupe
            else if (iVechList == 3)
            {
                sVehicles = VehicleListX(2, 1, false);

                int iCar = FindRandom(45, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Sport
            else if (iVechList == 4)
            {
                sVehicles = VehicleListX(4, 1, false);

                int iCar = FindRandom(46, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Mussle
            else if (iVechList == 5)
            {
                sVehicles = VehicleListX(5, 1, false);

                int iCar = FindRandom(47, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //SportsClassic
            else if (iVechList == 6)
            {
                sVehicles = VehicleListX(9, 1, false);

                int iCar = FindRandom(48, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Compact
            else if (iVechList == 7)
            {
                sVehicles = VehicleListX(6, 1, false);

                int iCar = FindRandom(49, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Sedan
            else if (iVechList == 8)
            {
                sVehicles = VehicleListX(7, 1, false);

                int iCar = FindRandom(50, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Offroad
            else if (iVechList == 9)
            {
                sVehicles = VehicleListX(8, 1, false);

                int iCar = FindRandom(51, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //SUV
            else
            {
                sVehicles = VehicleListX(0, 1, false);

                int iCar = FindRandom(58, 0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }

            return sThisVehicle;
        }
        public static float HappyShopper_DAmmagedGoods()
        {
            float fDam = 0.00f;

            Entity[] ShopBop = World.GetNearbyEntities(MissionData.vTarget_01, 7.00f);

            for (int i = 0; i < ShopBop.Count(); i++)
            {
                if (Function.Call<bool>(Hash.IS_ENTITY_A_PED, ShopBop[i].Handle))
                {
                    if (ShopBop[i].IsDead)
                        MissionData.iMissionSeq = 45;
                }
                else if (Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_ANY_PED, ShopBop[i].Handle) && !MissionData.iList_01.Contains(ShopBop[i].Handle))
                {
                    MissionData.iList_01.Add(ShopBop[i].Handle);
                    MissionData.iMissionVar_01 += 1;
                }
            }

            if (MissionData.iMissionVar_01 > 13)
                fDam = 1.00f;
            else
                fDam = (float)MissionData.iMissionVar_01 / 13.00f;
            //put back to 15 if this dont make it easyer.
            return fDam;
        }
        public static float MoresMuted_DAmmagedGoods(Vehicle MyBMW)
        {
            LoggerLight.LogThis("MoresMuted_DAmmagedGoods");

            int iDamU = MissionData.iMissionVar_02 - MyBMW.Health;
            float fDam = 0.00f;

            if (iDamU > 100)
                fDam = 1.00f;
            else
            {
                fDam = (float)iDamU / 100;
            }

            LoggerLight.LogThis("fDam = " + fDam + ", iDamU == " + iDamU);
            return fDam;
        }
        public static bool TempAgency_01_BallTracking()
        {
            bool bBall = false;

            if (MissionData.Prop_01.Position.X > -1865.00f)
            {
                if (MissionData.Prop_01.Position.Y > 1088.00f && MissionData.Prop_01.Position.Y < 1110.00f)
                {
                    MissionData.iMissionVar_01 += 1;
                    MissionData.BeOnOff[0] = true;
                }

                bBall = true;
            }
            else if (MissionData.Prop_01.Position.X < -2106.00f)
            {
                if (MissionData.Prop_01.Position.Y > 1088.00f && MissionData.Prop_01.Position.Y < 1110.00f)
                {
                    MissionData.iMissionVar_03 += 1;
                    MissionData.BeOnOff[0] = true;
                }

                bBall = true;
            }
            else if (MissionData.Prop_01.Position.Y < 1035.00f)
                bBall = true;
            else if (MissionData.Prop_01.Position.Y > 1161.00f)
                bBall = true;

            return bBall;
        }
        public static int TempAgency_06_WhatsMyName(string sLabel)
        {
            int iAm = 0;

            if (sLabel == "ch_prop_toolbox_01a")
                iAm = 89;
            else if (sLabel == "prop_tool_wrench")
                iAm = 90;
            else if (sLabel == "ch_prop_ch_bag_02a")
                iAm = 91;
            else if (sLabel == "hei_prop_heist_box")
                iAm = 92;
            else if (sLabel == "ba_prop_battle_rsply_crate_02a")
                iAm = 92;
            else if (sLabel == "gr_prop_gr_rsply_crate01a")
                iAm = 92;
            else if (sLabel == "gr_prop_gr_rsply_crate03a")
                iAm = 92;
            else if (sLabel == "prop_drop_crate_01")
                iAm = 92;
            else if (sLabel == "prop_suitcase_03")
                iAm = 93;
            else if (sLabel == "sm_prop_smug_crate_s_hazard")
                iAm = 94;
            else if (sLabel == "v_med_barrel")
                iAm = 98;
            else if (sLabel == "xs_prop_arena_barrel_01a_sf")
                iAm = 99;
            else if (sLabel == "prop_barrel_02b")
                iAm = 100;
            else if (sLabel == "ba_prop_battle_control_console")
                iAm = 101;
            else if (sLabel == "v_med_testtubes")
                iAm = 102;
            else if (sLabel == "ba_prop_club_smoke_machine")
                iAm = 103;

            return iAm;
        }
        public static List<Vector3> FarToNear(List<Vector3> ListToFix, Vector3 vStartPoint)
        {
            LoggerLight.LogThis("FarToNear");

            List<Vector3> NewVList = new List<Vector3>();
            List<Vector3> VNearest = new List<Vector3>();
            Vector3 VFurthest = Vector3.Zero;

            float fGetDist = 0.00f;
            int iDrop = 0;
            bool bNear = false;

            for (int i = 0; i < ListToFix.Count; i++)
            {
                float fDist = ListToFix[i].DistanceTo(vStartPoint);

                if (fDist > fGetDist)
                {
                    fGetDist = fDist;
                    iDrop = i;
                }
            }
            NewVList.Add(ListToFix[iDrop]);
            ListToFix.RemoveAt(iDrop);

            for (int i = 0; i < ListToFix.Count; i++)
            {
                float fDist = ListToFix[i].DistanceTo(vStartPoint);

                if (fDist < fGetDist)
                {
                    fGetDist = fDist;
                    iDrop = i;
                }
            }
            VNearest.Add(ListToFix[iDrop]);
            ListToFix.RemoveAt(iDrop);

            while (ListToFix.Count > 0)
            {
                if (bNear)
                    VFurthest = VNearest[0];
                else
                    VFurthest = NewVList[0];
                fGetDist = 9999.00f;
                iDrop = 0;

                if (ListToFix.Count == 1)
                {
                    if (bNear)
                        VNearest.Add(ListToFix[0]);
                    else
                        NewVList.Add(ListToFix[0]);
                    ListToFix.RemoveAt(0);
                }
                else
                {
                    for (int i = 0; i < ListToFix.Count; i++)
                    {
                        float fDist = ListToFix[i].DistanceTo(VFurthest);

                        if (fDist < fGetDist)
                        {
                            fGetDist = fDist;
                            iDrop = i;
                        }
                    }
                    if (bNear)
                        VNearest.Add(ListToFix[iDrop]);
                    else
                        NewVList.Add(ListToFix[iDrop]);
                    ListToFix.RemoveAt(iDrop);
                }
                bNear = !bNear;
            }
            ListToFix = ListReverseVec3(VNearest);
            for (int i = 0; i < ListToFix.Count; i++)
                NewVList.Add(ListToFix[i]);

            return NewVList;
        }
        public static List<Vector3> ListReverseVec3(List<Vector3> VecList)
        {

            LoggerLight.LogThis("ListReverseVec3");

            List<Vector3> SortedList = new List<Vector3>();

            int iList = VecList.Count;

            while (iList > 0)
            {
                iList -= 1;
                SortedList.Add(VecList[iList]);
            }

            return SortedList;
        }
        public static List<string> ListReverseString(List<string> StrList)
        {

            LoggerLight.LogThis("ListReverseString");

            List<string> SortedList = new List<string>();

            int iList = StrList.Count;

            while (iList > 0)
            {
                iList -= 1;
                SortedList.Add(StrList[iList]);
            }

            return SortedList;
        }
        public static List<float> ListReversefloat(List<float> FlowList)
        {

            LoggerLight.LogThis("ListReversefloat");

            List<float> SortedList = new List<float>();

            int iList = FlowList.Count;

            while (iList > 0)
            {
                iList -= 1;
                SortedList.Add(FlowList[iList]);
            }

            return SortedList;
        }
        public static int VehDamage(Vehicle Vehic, int iMaxHealth, int iMaxValue, bool bShowPool, int iSeeWhatYouDidThere, bool bNeg)
        {
            int iAmDamagedBy = 0;

            float fVehCheck = Vehic.BodyHealth + Vehic.EngineHealth + Vehic.PetrolTankHealth;

            float fDeduct = (float)iMaxHealth - fVehCheck;

            int iPer = iMaxValue / iMaxHealth;

            if (bNeg)
            {
                int iDeduct = (int)fDeduct * iPer;
                iAmDamagedBy = iMaxValue - iDeduct;

                if (iSeeWhatYouDidThere < iAmDamagedBy)
                    iAmDamagedBy = iSeeWhatYouDidThere;
            }
            else
            {
                iAmDamagedBy = (int)fDeduct * iPer;

                if (iSeeWhatYouDidThere > iAmDamagedBy)
                    iAmDamagedBy = iSeeWhatYouDidThere;
            }

            if (bShowPool)
            {
                UiDisplay.ttTextBar_01.Text = "$ " + ShowComs(iAmDamagedBy, true, false) + "";

                if (!UiDisplay.bUiDisplay)
                    UiDisplay.bUiDisplay = true;
            }

            return iAmDamagedBy;
        }
        public static int MultiDamage(int iMaxValue, bool bShowPool, int iSeeWhatYouDidThere, bool bNeg, bool bJustVeh)
        {
            int iAmDamagedBy = 0;
            int iMaxHealth = 0;
            bool broke = false;

            for (int i = 0; i < MissionData.Crash4s.VehX.Count; i++)
            {
                float fVehCheck = MissionData.Crash4s.VehX[i].BodyHealth + MissionData.Crash4s.VehX[i].EngineHealth + MissionData.Crash4s.VehX[i].PetrolTankHealth;
                float fDeduct = (float)MissionData.Crash4s.VehXHealth[i] - fVehCheck;
                iAmDamagedBy += (int)fDeduct;
                iMaxHealth += MissionData.Crash4s.VehXHealth[i];
            }

            if (!bJustVeh)
            {
                for (int i = 0; i < MissionData.Crash4s.PedX.Count; i++)
                {
                    int iPedHeal = MissionData.Crash4s.PedX[i].Health;
                    int iDeduct = MissionData.Crash4s.PedXHealth[i] - iPedHeal;
                    iAmDamagedBy += iDeduct;
                    iMaxHealth += MissionData.Crash4s.PedXHealth[i];
                }
            }

            if (!broke)
            {
                int iPer = iMaxValue / iMaxHealth;
                iAmDamagedBy *= iPer;
            }

            if (bNeg)
            {
                iAmDamagedBy = iMaxValue - iAmDamagedBy;
                if (iSeeWhatYouDidThere < iAmDamagedBy)
                    iAmDamagedBy = iSeeWhatYouDidThere;
            }
            else
            {
                if (iSeeWhatYouDidThere > iAmDamagedBy)
                    iAmDamagedBy = iSeeWhatYouDidThere;
            }

            if (bShowPool)
            {
                UiDisplay.ttTextBar_01.Text = "$ " + ShowComs(iAmDamagedBy, true, false) + "";
                if (!UiDisplay.bUiDisplay)
                    UiDisplay.bUiDisplay = true;
            }

            return iAmDamagedBy;
        }
        public static string RandNPC(int iRando)
        {
            LoggerLight.LogThis("RandNPC, iRando == " + iRando);

            List<string> sPeds = new List<string>();

            string sPedds = "";

            if (iRando == 1)
            {
                sPeds.Add("a_m_m_og_boss_01");    //"OG Boss" />
                sPeds.Add("g_f_y_ballas_01");    //" Female" />
                sPeds.Add("g_m_y_ballaeast_01");    //"Ballas East Male" />
                sPeds.Add("g_m_y_ballaorig_01");    //"Ballas Original Male" />
                sPeds.Add("g_m_y_ballasout_01");    //"Ballas South Male" />
            }            //Ballas
            else if (iRando == 2)
            {
                sPeds.Add("mp_m_famdd_01");    //"Families DD Male" />
                sPeds.Add("g_f_y_families_01");    //"Families Female" />
                sPeds.Add("g_m_y_famca_01");    //"Families CA Male" />
                sPeds.Add("g_m_y_famdnf_01");    //"Families DNF Male" />
                sPeds.Add("g_m_y_famfor_01");    //"Families FOR Male" />
            }       //Families
            else if (iRando == 3)
            {
                sPeds.Add("g_f_importexport_01");    //"Import Export Female" />
                sPeds.Add("g_f_importexport_01");    //"Gang Female (Import-Export)" />
                sPeds.Add("g_m_importexport_01");    //"Gang Male (Import-Export)" />
            }       //Gang (Import-Export)
            else if (iRando == 4)
            {
                sPeds.Add("g_f_y_vagos_01");    //"Vagos Female" />
                sPeds.Add("g_f_y_lost_01");    //"The Lost MC Female" />
                sPeds.Add("g_m_y_lost_01");    //"The Lost MC Male" />
                sPeds.Add("g_m_y_lost_02");    //"The Lost MC Male 2" />
                sPeds.Add("g_m_y_lost_03");    //"The Lost MC Male 3" />
                sPeds.Add("a_m_m_mlcrisis_01");    //"Midlife Crisis Casino Bikers" />
                sPeds.Add("mp_m_exarmy_01");    //"Ex-Army Male" />
            }       //The Lost MC
            else if (iRando == 5)
            {
                sPeds.Add("g_m_m_korboss_01");    //"Korean Boss" />
                sPeds.Add("g_m_y_korlieut_01");    //"Korean Lieutenant" />
                sPeds.Add("g_m_y_korean_01");    //"Korean Young Male" />
                sPeds.Add("g_m_y_korean_02");    //"Korean Young Male 2" />
                sPeds.Add("a_m_m_ktown_01");    //"Korean Male" />
                sPeds.Add("a_m_o_ktown_01");    //"Korean Old Male" />
                sPeds.Add("a_m_y_ktown_01");    //"Korean Young Male" />
                sPeds.Add("a_m_y_ktown_02");    //"Korean Young Male 2" />
            }       //Korean
            else if (iRando == 6)
            {
                sPeds.Add("g_m_m_armboss_01");    //"Armenian Boss" />
                sPeds.Add("g_m_m_armgoon_01");    //"Armenian Goon" />
                sPeds.Add("g_m_y_armgoon_02");    //"Armenian Goon 2" />
                sPeds.Add("g_m_m_armlieut_01");    //"Armenian Lieutenant" />
            }       //Armenian
            else if (iRando == 7)
            {
                sPeds.Add("g_m_m_chiboss_01");    //"Chinese Boss" />
                sPeds.Add("g_m_m_chigoon_01");    //"Chinese Goon" />
                sPeds.Add("g_m_m_chigoon_02");    //"Chinese Goon 2" />
                sPeds.Add("g_m_m_chicold_01");    //"Chinese Goon Older" />
            }       //Chinese
            else if (iRando == 8)
            {
                sPeds.Add("g_m_m_mexboss_01");    //"Mexican Boss" />
                sPeds.Add("g_m_m_mexboss_02");    //"Mexican Boss 2" />
                sPeds.Add("g_m_y_mexgang_01");    //"Mexican Gang Member" />
                sPeds.Add("g_m_y_mexgoon_01");    //"Mexican Goon" />
                sPeds.Add("g_m_y_mexgoon_02");    //"Mexican Goon 2" />
                sPeds.Add("g_m_y_mexgoon_03");    //"Mexican Goon 3" />
                sPeds.Add("a_m_y_mexthug_01");    //"Mexican Thug" />
            }       //Mexican
            else if (iRando == 9)
            {
                sPeds.Add("g_m_y_pologoon_01");    //"Polynesian Goon" />
                sPeds.Add("g_m_y_pologoon_02");    //"Polynesian Goon 2" />
                sPeds.Add("a_m_m_polynesian_01");    //"Polynesian" />
                sPeds.Add("a_m_y_polynesian_01");    //"Polynesian Young" />
            }       //Polynesian
            else if (iRando == 10)
            {
                sPeds.Add("g_m_y_salvaboss_01");    //"Salvadoran Boss" />
                sPeds.Add("g_m_y_salvagoon_01");    //"Salvadoran Goon" />
                sPeds.Add("g_m_y_salvagoon_02");    //"Salvadoran Goon 2" />
                sPeds.Add("g_m_y_salvagoon_03");    //"Salvadoran Goon 3" />
            }       //Salvadoran
            else if (iRando == 11)
            {
                sPeds.Add("g_m_y_strpunk_01");    //"Street Punk" />
                sPeds.Add("g_m_y_strpunk_02");    //"Street Punk 2" />
            }       //Street Punk
            else if (iRando == 12)
            {
                sPeds.Add("a_f_m_beach_01");    //"Beach Female" />
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_f_m_bodybuild_01");    //"Bodybuilder Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_musclbeac_01");    //"Beach Muscle Male" />
                sPeds.Add("a_m_y_musclbeac_02");    //"Beach Muscle Male 2" />
                sPeds.Add("a_m_o_beach_01");    //"Beach Old Male" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
                sPeds.Add("a_m_m_malibu_01");    //"Malibu Male" />
                sPeds.Add("a_m_y_sunbathe_01");    //"Sunbather Male" />
                sPeds.Add("a_m_y_surfer_01");    //"Surfer" />
                sPeds.Add("a_m_y_yoga_01");    //"Yoga Male" />
                sPeds.Add("a_m_y_hippy_01");    //"Hippie Male" />
                sPeds.Add("a_f_y_hippie_01");    //"Hippie Female" />
                sPeds.Add("a_m_y_beachvesp_01");    //"Vespucci Beach Male" />
                sPeds.Add("a_m_y_beachvesp_02");    //"Vespucci Beach Male 2" />
                sPeds.Add("u_m_y_party_01");    //"Partygoer" />
            }       //Beach
            else if (iRando == 13)
            {
                sPeds.Add("a_f_m_bevhills_01");    //"Beverly Hills Female" />
                sPeds.Add("a_f_m_bevhills_02");    //"Beverly Hills Female 2" />
                sPeds.Add("a_f_y_bevhills_01");    //"Beverly Hills Young Female" />
                sPeds.Add("a_f_y_bevhills_02");    //"Beverly Hills Young Female 2" />
                sPeds.Add("a_f_y_bevhills_03");    //"Beverly Hills Young Female 3" />
                sPeds.Add("a_f_y_bevhills_04");    //"Beverly Hills Young Female 4" />
                sPeds.Add("a_f_m_downtown_01");    //"Downtown Female" />
                sPeds.Add("a_f_y_scdressy_01");    //"Dressy Female" />
                sPeds.Add("a_f_y_vinewood_01");    //"Vinewood Female" />
                sPeds.Add("a_f_y_vinewood_02");    //"Vinewood Female 2" />
                sPeds.Add("a_f_y_vinewood_03");    //"Vinewood Female 3" />
                sPeds.Add("a_f_y_vinewood_04");    //"Vinewood Female 4" />
                sPeds.Add("a_f_y_clubcust_01");    //"Club Customer Female 1" />
                sPeds.Add("a_f_y_clubcust_02");    //"Club Customer Female 2" />
                sPeds.Add("a_f_y_clubcust_03");    //"Club Customer Female 3" />
                sPeds.Add("u_f_y_hotposh_01");    //"Hot Posh Female" />
                sPeds.Add("g_m_m_casrn_01");    //"Casino Guests?" />
                sPeds.Add("a_m_m_bevhills_01");    //"Beverly Hills Male" />
                sPeds.Add("a_m_m_bevhills_02");    //"Beverly Hills Male 2" />
                sPeds.Add("a_m_y_bevhills_01");    //"Beverly Hills Young Male" />
                sPeds.Add("a_m_y_bevhills_02");    //"Beverly Hills Young Male 2" />
                sPeds.Add("a_m_y_downtown_01");    //"Downtown Male" />
                sPeds.Add("a_m_y_hipster_01");    //"Hipster Male" />
                sPeds.Add("a_m_y_hipster_02");    //"Hipster Male 2" />
                sPeds.Add("a_m_y_hipster_03");    //"Hipster Male 3" />
                sPeds.Add("a_m_m_tennis_01");    //"Tennis Player Male" />
                sPeds.Add("a_m_y_vindouche_01");    //"Vinewood Douche" />
                sPeds.Add("a_m_y_vinewood_01");    //"Vinewood Male" />
                sPeds.Add("a_m_y_vinewood_02");    //"Vinewood Male 2" />
                sPeds.Add("a_m_y_vinewood_03");    //"Vinewood Male 3" />
                sPeds.Add("a_m_y_vinewood_04");    //"Vinewood Male 4" />
                sPeds.Add("a_m_y_clubcust_01");    //"Club Customer Male 1" />
                sPeds.Add("a_m_y_clubcust_02");    //"Club Customer Male 2" />
                sPeds.Add("a_m_y_clubcust_03");    //"Club Customer Male 3" />
                sPeds.Add("a_f_y_gencaspat_01");    //"Casual Casino Guest" />
                sPeds.Add("a_f_y_smartcaspat_01");    //"Formel Casino Guest" />
                sPeds.Add("a_f_y_hipster_01");    //"Hipster Female" />
                sPeds.Add("a_f_y_hipster_02");    //"Hipster Female 2" />
                sPeds.Add("a_f_y_hipster_03");    //"Hipster Female 3" />
                sPeds.Add("a_f_y_hipster_04");    //"Hipster Female 4" />
                sPeds.Add("a_f_y_tennis_01");    //"Tennis Player Female" />
                sPeds.Add("a_f_y_femaleagent");    //"Female Agent" />
                sPeds.Add("a_f_y_genhot_01");    //"General Hot Young Female" />
                sPeds.Add("a_m_y_gencaspat_01");    //"Casual Casino Guests" />
                sPeds.Add("a_m_y_smartcaspat_01");    //"Formel Casino Guests" />
            }       //HiClassStreet
            else if (iRando == 14)
            {
                sPeds.Add("a_f_m_business_02");    //"Business Female 2" />
                sPeds.Add("a_f_y_business_01");    //"Business Young Female" />
                sPeds.Add("a_f_y_business_02");    //"Business Young Female 2" />
                sPeds.Add("a_f_y_business_03");    //"Business Young Female 3" />
                sPeds.Add("a_f_y_business_04");    //"Business Young Female 4" />
            }       //Suits Female
            else if (iRando == 15)
            {
                sPeds.Add("a_f_m_eastsa_01");    //"East SA Female" />
                sPeds.Add("a_f_m_eastsa_02");    //"East SA Female 2" />
                sPeds.Add("a_f_y_eastsa_01");    //"East SA Young Female" />
                sPeds.Add("a_f_y_eastsa_02");    //"East SA Young Female 2" />
                sPeds.Add("a_f_y_eastsa_03");    //"East SA Young Female 3" />
                sPeds.Add("a_m_m_eastsa_01");    //"East SA Male" />
                sPeds.Add("a_m_m_eastsa_02");    //"East SA Male 2" />
                sPeds.Add("a_m_y_eastsa_01");    //"East SA Young Male" />
                sPeds.Add("a_m_y_eastsa_02");    //"East SA Young Male 2" />
            }       //East SA
            else if (iRando == 16)
            {
                sPeds.Add("u_m_y_baygor");    //"Kifflom Guy" />
                sPeds.Add("a_m_y_epsilon_01");    //"Epsilon Male" />
                sPeds.Add("a_m_y_epsilon_02");    //"Epsilon Male 2" />
                sPeds.Add("a_f_y_epsilon_01");    //"Epsilon Female" />
            }       //Epsilon
            else if (iRando == 17)
            {
                sPeds.Add("a_f_m_fatbla_01");    //"Fat Black Female" />
                sPeds.Add("a_f_m_fatcult_01");    //"Fat Cult Female" />
                sPeds.Add("a_f_m_fatwhite_01");    //"Fat White Female" />
                sPeds.Add("a_m_m_genfat_01");    //"General Fat Male" />
                sPeds.Add("a_m_m_genfat_02");    //"General Fat Male 2" />
                sPeds.Add("a_m_m_fatlatin_01");    //"Fat Latino Male" />
            }       //Fatties
            else if (iRando == 18)
            {
                sPeds.Add("a_f_o_genstreet_01");    //"General Street Old Female" />
                sPeds.Add("a_m_o_genstreet_01");    //"General Street Old Male" />
                sPeds.Add("a_m_y_genstreet_01");    //"General Street Young Male" />
                sPeds.Add("a_m_y_genstreet_02");    //"General Street Young Male 2" />
                sPeds.Add("a_m_y_stbla_01");    //"Black Street Male" />
                sPeds.Add("a_m_y_stbla_02");    //"Black Street Male 2" />
                sPeds.Add("a_m_m_stlat_02");    //"Latino Street Male 2" />
                sPeds.Add("a_m_y_stlat_01");    //"Latino Street Young Male" />
                sPeds.Add("a_m_y_latino_01");    //"Latino Young Male" />
                sPeds.Add("a_m_m_afriamer_01");    //"African American Male" />
                sPeds.Add("a_m_y_stwhi_01");    //"White Street Male" />
                sPeds.Add("a_m_y_stwhi_02");    //"White Street Male 2" />
                sPeds.Add("a_m_y_ktown_01");    //"Korean Young Male" />
                sPeds.Add("a_m_y_ktown_02");    //"Korean Young Male 2" />
                sPeds.Add("a_m_m_polynesian_01");    //"Polynesian" />
                sPeds.Add("a_m_y_polynesian_01");    //"Polynesian Young" />
                sPeds.Add("a_m_m_eastsa_01");    //"East SA Male" />
                sPeds.Add("a_m_m_eastsa_02");    //"East SA Male 2" />
                sPeds.Add("a_f_m_ktown_01");    //"Korean Female" />
                sPeds.Add("a_f_m_ktown_02");    //"Korean Female 2" />
                sPeds.Add("a_f_o_ktown_01");    //"Korean Old Female" />
            }       //Street
            else if (iRando == 19)
            {
                sPeds.Add("a_m_y_hiker_01");    //"Hiker Male" />
                sPeds.Add("a_f_y_hiker_01");    //"Hiker Female" />
                sPeds.Add("a_m_y_runner_01");    //"Jogger Male" />
                sPeds.Add("a_m_y_runner_02");    //"Jogger Male 2" />
                sPeds.Add("a_f_y_fitness_01");    //"Fitness Female" />
                sPeds.Add("a_f_y_fitness_02");    //"Fitness Female 2" />
                sPeds.Add("a_f_y_runner_01");    //"Jogger Female" />
                sPeds.Add("a_f_y_yoga_01");    //"Yoga Female" />
            }       //Outdoors
            else if (iRando == 20)
            {
                sPeds.Add("a_m_m_skater_01");    //"Skater Male" />
                sPeds.Add("a_m_y_skater_01");    //"Skater Young Male" />
                sPeds.Add("a_m_y_skater_02");    //"Skater Young Male 2" />
                sPeds.Add("a_f_y_skater_01");    //"Skater Female" />
            }       //Skater
            else if (iRando == 21)
            {
                sPeds.Add("a_m_m_indian_01");    //"Indian Male" />
                sPeds.Add("a_m_y_indian_01");    //"Indian Young Male" />
                sPeds.Add("a_f_o_indian_01");    //"Indian Old Female" />
                sPeds.Add("a_f_y_indian_01");    //"Indian Young Female" />
            }       //indian
            else if (iRando == 22)
            {
                sPeds.Add("a_m_y_juggalo_01");    //"Juggalo Male" />
                sPeds.Add("a_f_y_juggalo_01");    //"Juggalo Female" />
            }       //Juggalo
            else if (iRando == 23)
            {
                sPeds.Add("a_m_y_methhead_01");    //"Meth Addict" />
                sPeds.Add("a_f_y_rurmeth_01");    //"Rural Meth Addict Female" />
                sPeds.Add("a_f_m_salton_01");    //"Salton Female" />
                sPeds.Add("a_f_o_salton_01");    //"Salton Old Female" />
                sPeds.Add("a_m_m_hillbilly_01");    //"Hillbilly Male" />
                sPeds.Add("a_m_m_hillbilly_02");    //"Hillbilly Male 2" />
                sPeds.Add("a_m_m_rurmeth_01");    //"Rural Meth Addict Male" />
                sPeds.Add("a_m_m_farmer_01");    //"Farmer" />
                sPeds.Add("a_m_m_salton_01");    //"Salton Male" />
                sPeds.Add("a_m_m_salton_02");    //"Salton Male 2" />
                sPeds.Add("a_m_m_salton_03");    //"Salton Male 3" />
                sPeds.Add("a_m_m_salton_04");    //"Salton Male 4" />
                sPeds.Add("a_m_o_salton_01");    //"Salton Old Male" />
                sPeds.Add("a_m_y_salton_01");    //"Salton Young Male" />
                sPeds.Add("a_m_m_mexcntry_01");    //"Mexican Rural" />

            }       //Rural
            else if (iRando == 24)
            {
                sPeds.Add("a_f_m_skidrow_01");    //"Skid Row Female" />
                sPeds.Add("a_m_m_skidrow_01");    //"Skid Row Male" />
                sPeds.Add("a_m_m_tramp_01");    //"Tramp Male" />
                sPeds.Add("a_m_o_tramp_01");    //"Tramp Old Male" />
                sPeds.Add("a_f_m_tramp_01");    //"Tramp Female" />
                sPeds.Add("a_f_m_trampbeac_01");    //"Beach Tramp Female" />
                sPeds.Add("a_m_m_trampbeac_01");    //"Beach Tramp Male" />
            }       //Tramp
            else if (iRando == 25)
            {
                sPeds.Add("a_f_m_soucent_01");    //"South Central Female" />
                sPeds.Add("a_f_m_soucent_02");    //"South Central Female 2" />
                sPeds.Add("a_f_m_soucentmc_01");    //"South Central MC Female" />
                sPeds.Add("a_f_o_soucent_01");    //"South Central Old Female" />
                sPeds.Add("a_f_o_soucent_02");    //"South Central Old Female 2" />
                sPeds.Add("a_f_y_soucent_01");    //"South Central Young Female" />
                sPeds.Add("a_f_y_soucent_02");    //"South Central Young Female 2" />
                sPeds.Add("a_f_y_soucent_03");    //"South Central Young Female 3" />
                sPeds.Add("a_m_m_socenlat_01");    //"South Central Latino Male" />
                sPeds.Add("a_m_m_soucent_01");    //"South Central Male" />
                sPeds.Add("a_m_m_soucent_02");    //"South Central Male 2" />
                sPeds.Add("a_m_m_soucent_03");    //"South Central Male 3" />
                sPeds.Add("a_m_m_soucent_04");    //"South Central Male 4" />
                sPeds.Add("a_m_o_soucent_01");    //"South Central Old Male" />
                sPeds.Add("a_m_o_soucent_02");    //"South Central Old Male 2" />
                sPeds.Add("a_m_o_soucent_03");    //"South Central Old Male 3" />
                sPeds.Add("a_m_y_soucent_01");    //"South Central Young Male" />
                sPeds.Add("a_m_y_soucent_02");    //"South Central Young Male 2" />
                sPeds.Add("a_m_y_soucent_03");    //"South Central Young Male 3" />
                sPeds.Add("a_m_y_soucent_04");    //"South Central Young Male 4" />
            }       //South Central
            else if (iRando == 26)
            {
                sPeds.Add("a_f_m_tourist_01");    //"Tourist Female" />
                sPeds.Add("a_f_y_tourist_01");    //"Tourist Young Female" />
                sPeds.Add("a_f_y_tourist_02");    //"Tourist Young Female 2" />
                sPeds.Add("a_m_m_tourist_01");    //"Tourist Male" />
            }       //Tourist 
            else if (iRando == 27)
            {
                sPeds.Add("a_m_m_paparazzi_01");    //"Paparazzi Male" />
                sPeds.Add("s_f_y_bartender_01");    //"Bartender" />
                sPeds.Add("cs_bankman");    //"Bank Manager" />
                sPeds.Add("mp_s_m_armoured_01");    //"Armoured Van Security Male" />
                sPeds.Add("mp_f_cardesign_01");    //"Office Garage Mechanic (Female)" />
                sPeds.Add("mp_g_m_pros_01");    //"Pros" />
                sPeds.Add("mp_m_securoguard_01");    //"Securoserve Guard (Male)" />
                sPeds.Add("mp_m_shopkeep_01");    //"Shopkeeper (Male)" />
                sPeds.Add("mp_f_bennymech_01");    //"Benny Mechanic (Female)" />
                sPeds.Add("s_f_y_airhostess_01");    //"Air Hostess" />
                sPeds.Add("s_f_m_fembarber");    //"Barber Female" />
                sPeds.Add("s_f_y_casino_01");    //"Casino Staff" />
                sPeds.Add("s_f_y_factory_01");    //"Factory Worker Female" />
                sPeds.Add("s_f_y_hooker_01");    //"Hooker" />
                sPeds.Add("s_f_y_hooker_02");    //"Hooker 2" />
                sPeds.Add("s_f_y_hooker_03");    //"Hooker 3" />
                sPeds.Add("s_f_y_scrubs_01");    //"Hospital Scrubs Female" />
                sPeds.Add("s_f_m_maid_01");    //"Maid" />
                sPeds.Add("s_f_y_migrant_01");    //"Migrant Female" />
                sPeds.Add("s_f_m_sweatshop_01");    //"Sweatshop Worker" />
                sPeds.Add("s_f_y_sweatshop_01");    //"Sweatshop Worker Young" />
                sPeds.Add("s_f_y_clubbar_01");    //"Club Bartender Female" />
                sPeds.Add("s_m_m_armoured_01");    //"Armoured Van Security" />
                sPeds.Add("s_m_m_armoured_02");    //"Armoured Van Security 2" />
                sPeds.Add("s_m_y_autopsy_01");    //"Autopsy Tech" />
                sPeds.Add("s_m_m_autoshop_01");    //"Autoshop Worker" />
                sPeds.Add("s_m_m_autoshop_02");    //"Autoshop Worker 2" />
                sPeds.Add("s_m_y_barman_01");    //"Barman" />
                sPeds.Add("s_m_m_cntrybar_01");    //"Bartender (Rural)" />
                sPeds.Add("s_m_m_bouncer_01");    //"Bouncer" />
                sPeds.Add("s_m_y_busboy_01");    //"Busboy" />
                sPeds.Add("s_m_y_casino_01");    //"Casino Staff" />
                sPeds.Add("s_m_y_chef_01");    //"Chef" />
                sPeds.Add("s_m_m_chemsec_01");    //"Chemical Plant Security" />
                sPeds.Add("s_m_m_ccrew_01");    //"Crew Member" />
                sPeds.Add("s_m_m_dockwork_01");    //"Dock Worker" />
                sPeds.Add("s_m_y_dockwork_01");    //"Dock Worker" />
                sPeds.Add("s_m_m_doctor_01");    //"Doctor" />
                sPeds.Add("s_m_y_doorman_01");    //"Doorman" />
                sPeds.Add("s_m_y_airworker");    //"Air Worker Male" />
                sPeds.Add("s_m_y_dwservice_01");    //"DW Airport Worker" />
                sPeds.Add("s_m_y_dwservice_02");    //"DW Airport Worker 2" />
                sPeds.Add("s_m_y_factory_01");    //"Factory Worker Male" />
                sPeds.Add("s_m_m_gaffer_01");    //"Gaffer" />
                sPeds.Add("s_m_y_garbage");    //"Garbage Worker" />
                sPeds.Add("s_m_m_gardener_01");    //"Gardener" />
                sPeds.Add("s_m_y_grip_01");    //"Grip" />
                sPeds.Add("s_m_m_hairdress_01");    //"Hairdresser Male" />
                sPeds.Add("s_m_m_janitor");    //"Janitor" />
                sPeds.Add("s_m_m_lifeinvad_01");    //"Life Invader Male" />
                sPeds.Add("s_m_m_linecook");    //"Line Cook" />
                sPeds.Add("s_m_m_lsmetro_01");    //"LS Metro Worker Male" />
                sPeds.Add("s_m_y_xmech_01");    //"Mechanic" />
                sPeds.Add("s_m_m_migrant_01");    //"Migrant Male" />
                sPeds.Add("s_m_y_pestcont_01");    //"Pest Control" />
                sPeds.Add("s_m_m_postal_01");    //"Postal Worker Male" />
                sPeds.Add("s_m_m_postal_02");    //"Postal Worker Male 2" />
                sPeds.Add("s_m_y_shop_mask");    //"Mask Salesman" />
                sPeds.Add("s_m_m_scientist_01");    //"Scientist" />
                sPeds.Add("s_m_m_security_01");    //"Security Guard" />
                sPeds.Add("s_m_m_strvend_01");    //"Street Vendor" />
                sPeds.Add("s_m_y_strvend_01");    //"Street Vendor Young" />
                sPeds.Add("s_m_m_gentransport");    //"Transport Worker Male" />
                sPeds.Add("s_m_m_trucker_01");    //"Trucker Male" />
                sPeds.Add("s_m_m_ups_01");    //"UPS Driver" />
                sPeds.Add("s_m_m_ups_02");    //"UPS Driver 2" />
                sPeds.Add("s_m_y_uscg_01");    //"US Coastguard" />
                sPeds.Add("s_m_y_valet_01");    //"Valet" />
                sPeds.Add("s_m_y_waiter_01");    //"Waiter" />
                sPeds.Add("s_m_y_winclean_01");    //"Window Cleaner" />
                sPeds.Add("s_m_y_clubbar_01");    //"Club Bartender Male" />
                sPeds.Add("s_m_y_waretech_01");    //"Warehouse Technician" />
                sPeds.Add("u_f_m_casinocash_01");    //"Casino Cashier" />
                sPeds.Add("u_f_m_casinoshop_01");    //"Casino shop owner" />
                sPeds.Add("u_m_m_bankman");    //"Bank Manager Male" />
                sPeds.Add("u_m_m_bikehire_01");    //"Bike Hire Guy" />
                sPeds.Add("u_m_y_burgerdrug_01");    //"Burger Drug Worker" />
                sPeds.Add("u_m_y_gunvend_01");    //"Gun Vendor" />
                sPeds.Add("u_m_m_jewelsec_01");    //"Jeweller Security" />
                sPeds.Add("u_m_y_paparazzi");    //"Paparazzi Young Male" />
                sPeds.Add("u_m_y_tattoo_01");    //"Tattoo Artist" />

            }       //Workers
            else if (iRando == 28)
            {
                sPeds.Add("a_m_y_dhill_01");    //"Downhill Cyclist" />
                sPeds.Add("a_m_y_jetski_01");    //"Jetskier" />
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
                sPeds.Add("a_m_y_roadcyc_01");    //"Road Cyclist" />
                sPeds.Add("u_m_y_cyclist_01");    //"Cyclist Male" />
                sPeds.Add("u_m_y_sbike");    //"Sports Biker" />
            }       //Sports
            else if (iRando == 29)
            {
                sPeds.Add("a_m_y_breakdance_01");    //"Breakdancer Male" />
                sPeds.Add("a_m_y_gay_01");    //"Gay Male" />
                sPeds.Add("a_m_y_gay_02");    //"Gay Male 2" />
                sPeds.Add("a_m_m_tranvest_01");    //"Transvestite Male" />
                sPeds.Add("a_m_m_tranvest_02");    //"Transvestite Male 2" />
                sPeds.Add("csb_bride");    //"Bride" />
                sPeds.Add("s_m_m_movalien_01");    //"Alien" />
                sPeds.Add("s_m_y_mime");    //"Mime Artist" />
                sPeds.Add("s_m_y_clown_01");    //"Clown" />
                sPeds.Add("s_m_o_busker_01");    //"Busker" />
                sPeds.Add("s_m_m_mariachi_01");    //"Mariachi" />
                sPeds.Add("s_m_m_movspace_01");    //"Movie Astronaut" />
                sPeds.Add("s_m_y_prisoner_01");    //"Prisoner" />
                sPeds.Add("s_m_y_prismuscl_01");    //"Prisoner (Muscular)" />
                sPeds.Add("s_m_y_robber_01");    //"Robber" />
                sPeds.Add("s_m_m_strperf_01");    //"Street Performer" />
                sPeds.Add("s_m_m_strpreach_01");    //"Street Preacher" />
                sPeds.Add("u_f_y_spyactress");    //"Spy Actress" />
                sPeds.Add("u_m_y_imporage");    //"Impotent Rage" />
                sPeds.Add("u_m_y_pogo_01");    //"Pogo the Monkey" />
                sPeds.Add("u_m_y_prisoner_01");    //"Prisoner" />
                sPeds.Add("u_m_y_rsranger_01");    //"Republican Space Ranger" />
                sPeds.Add("u_m_y_zombie_01");    //"Zombie" />
            }       //Novalty
            else if (iRando == 30)
            {
                sPeds.Add("a_m_m_hasjew_01");    //"Hasidic Jew Male" />
                sPeds.Add("a_m_y_hasjew_01");    //"Hasidic Jew Young Male" />
            }       //Hasidic
            else if (iRando == 31)
            {
                sPeds.Add("mp_m_fibsec_01");    //"FIB Security" />
                sPeds.Add("s_m_m_fiboffice_01");    //"FIB Office Worker" />
                sPeds.Add("s_m_m_fiboffice_02");    //"FIB Office Worker 2" />
                sPeds.Add("s_m_m_fibsec_01");    //"FIB Security" />
                sPeds.Add("s_m_m_highsec_01");    //"High Security" />
                sPeds.Add("s_m_m_highsec_02");    //"High Security 2" />
                sPeds.Add("s_m_m_ciasec_01");    //"IAA Security" />
                sPeds.Add("u_m_m_doa_01");    //"DOA Man" />
            }       //Fib
            else if (iRando == 32)
            {
                sPeds.Add("mp_f_helistaff_01");    //"Heli-Staff Female" />
                sPeds.Add("s_m_m_pilot_01");    //"Pilot" />
                sPeds.Add("s_m_y_pilot_01");    //"Pilot" />
                sPeds.Add("s_m_m_pilot_02");    //"Pilot 2" />
            }       //Pilots
            else if (iRando == 33)
            {
                //sPeds.Add("mp_m_avongoon");    //"Avon Goon" />
                sPeds.Add("mp_m_bogdangoon");    //"Bogdan Goon" />
                                                 //sPeds.Add("s_m_y_westsec_01");    //"Duggan Secruity" />
            }       //MP Goons
            else if (iRando == 34)
            {
                sPeds.Add("mp_f_stripperlite");    //"Stripper Lite (Female)" />
                sPeds.Add("s_f_y_stripper_01");    //"Stripper" />
                sPeds.Add("s_f_y_stripper_02");    //"Stripper 2" />
                sPeds.Add("s_f_y_stripperlite");    //"Stripper Lite" />
                sPeds.Add("u_f_y_danceburl_01");    //"Female Club Dancer (Burlesque)" />
                sPeds.Add("u_f_y_dancelthr_01");    //"Female Club Dancer (Leather)" />
                sPeds.Add("u_f_y_dancerave_01");    //"Female Club Dancer (Rave)" />
                sPeds.Add("u_m_y_danceburl_01");    //"Male Club Dancer (Burlesque)" />
                sPeds.Add("u_m_y_dancelthr_01");    //"Male Club Dancer (Leather)" />
                sPeds.Add("u_m_y_dancerave_01");    //"Male Club Dancer (Rave)" />
            }       //Dancers
            else if (iRando == 35)
            {
                sPeds.Add("mp_f_cocaine_01");    //"Biker Cocaine Female" />
                sPeds.Add("mp_m_cocaine_01");    //"Biker Cocaine Male" />
                sPeds.Add("mp_f_counterfeit_01");    //"Biker Counterfeit Female" />
                sPeds.Add("mp_m_counterfeit_01");    //"Biker Counterfeit Male" />
                sPeds.Add("mp_f_forgery_01");    //"Biker Forgery Female" />
                sPeds.Add("mp_m_forgery_01");    //"Biker Forgery Male" />
                sPeds.Add("mp_f_meth_01");    //"Biker Meth Female" />
                sPeds.Add("mp_m_meth_01");    //"Biker Meth Male" />
                sPeds.Add("mp_f_weed_01");    //"Biker Weed Female" />
                sPeds.Add("mp_m_weed_01");    //"Biker Weed Male" />
            }       //Biker Biz
            else if (iRando == 36)
            {

                sPeds.Add("s_m_y_ranger_01");    //"Ranger Male" />
                sPeds.Add("s_f_y_ranger_01");    //"Ranger Female" />
                sPeds.Add("s_m_y_sheriff_01");    //"Sheriff Male" />
                sPeds.Add("s_f_y_sheriff_01");    //"Sheriff Female" />
                sPeds.Add("s_m_y_hwaycop_01");    //"Highway Cop" />
                sPeds.Add("s_m_y_cop_01");    //"Cop Male" />
                sPeds.Add("s_f_y_cop_01");    //"Cop Female" />
            }       //Cops
            else if (iRando == 37)
            {
                sPeds.Add("a_c_chimp");    //"Chimp" />
            }       //Pogo the monkey--Dont use low lod
            else if (iRando == 38)
            {
                sPeds.Add("a_m_y_busicas_01");    //"Business Casual" />
                sPeds.Add("a_m_m_business_01");    //"Business Male" />
                sPeds.Add("a_m_y_business_01");    //"Business Young Male" />
                sPeds.Add("a_m_y_business_02");    //"Business Young Male 2" />
                sPeds.Add("a_m_y_business_03");    //"Business Young Male 3" />
                sPeds.Add("a_m_y_smartcaspat_01");    //"Formel Casino Guests" />
            }       //Suits Male
            else if (iRando == 39)
            {
                sPeds.Add("mp_m_g_vagfun_01");    //"Vagos Funeral" />
            }       //Vargos
            else if (iRando == 40)
            {
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
            }       //Racist - Cuttin corners F1
            else if (iRando == 41)
            {
                sPeds.Add("a_m_y_jetski_01");    //"Jetskier" />
            }       //Racist - Jet ski
            else if (iRando == 42)
            {
                sPeds.Add("a_m_y_cyclist_01");    //"Cyclist Male" />
                sPeds.Add("a_m_y_dhill_01");    //"Downhill Cyclist" />
                sPeds.Add("a_m_y_roadcyc_01");    //"Road Cyclist" />
            }       //Racist - Bike race
            else if (iRando == 43)
            {
                sPeds.Add("s_m_y_armymech_01");    //"Army Mechanic" />
                sPeds.Add("s_m_y_blackops_01");    //"Black Ops Soldier" />
                sPeds.Add("s_m_y_blackops_02");    //"Black Ops Soldier 2" />
                sPeds.Add("s_m_y_blackops_03");    //"Black Ops Soldier 3" />
                sPeds.Add("s_m_m_marine_01");    //"Marine" />
                sPeds.Add("s_m_m_marine_02");    //"Marine 2" />
                sPeds.Add("s_m_y_marine_01");    //"Marine Young" />
                sPeds.Add("s_m_y_marine_02");    //"Marine Young 2" />
                sPeds.Add("s_m_y_marine_03");    //"Marine Young 3" />
            }       //Racist - Havoc
            else if (iRando == 44)
            {
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
                sPeds.Add("g_f_y_vagos_01");    //"Vagos Female" />
                sPeds.Add("g_f_y_lost_01");    //"The Lost MC Female" />
                sPeds.Add("g_m_y_lost_01");    //"The Lost MC Male" />
                sPeds.Add("g_m_y_lost_02");    //"The Lost MC Male 2" />
                sPeds.Add("g_m_y_lost_03");    //"The Lost MC Male 3" />
                sPeds.Add("a_m_m_mlcrisis_01");    //"Midlife Crisis Casino Bikers" />
                sPeds.Add("mp_m_exarmy_01");    //"Ex-Army Male" />
            }       //Racist - Motobikes
            else if (iRando == 45)
            {
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
            }       //Racist - Yachts
            else if (iRando == 46)
            {
                sPeds.Add("a_m_m_golfer_01");    //"Golfer Male" />
                sPeds.Add("a_m_y_golfer_01");    //"Golfer Young Male" />
                sPeds.Add("a_f_y_golfer_01");    //"Golfer Young Female" />
            }       //golf
            else if (iRando == 47)
            {
                sPeds.Add("g_m_m_chemwork_01");    //"Chemical Plant Worker" />
                sPeds.Add("mp_f_meth_01");    //"Biker Meth Female" /> 
                sPeds.Add("mp_m_meth_01");    //"Biker Meth Male" />
            }       //industry workers
            else if (iRando == 48)
            {
                sPeds.Add("s_m_y_swat_01");    //"SWAT" />
                sPeds.Add("s_m_m_marine_01");    //"Marine" />
                sPeds.Add("s_m_m_marine_02");    //"Marine 2" />
                sPeds.Add("s_m_y_marine_01");    //"Marine Young" />
                sPeds.Add("s_m_y_marine_02");    //"Marine Young 2" />
                sPeds.Add("s_m_y_marine_03");    //"Marine Young 3" />
                sPeds.Add("s_m_y_blackops_01");    //"Black Ops Soldier" />
                sPeds.Add("s_m_y_blackops_02");    //"Black Ops Soldier 2" />
                sPeds.Add("s_m_y_blackops_03");    //"Black Ops Soldier 3" />
            }       //Black opps
            else if (iRando == 49)
            {
                sPeds.Add("s_f_y_baywatch_01");    //"Baywatch Female" />
                sPeds.Add("s_m_y_armymech_01");    //"Army Mechanic" />
                sPeds.Add("s_m_y_baywatch_01");    //"Baywatch Male" />
                sPeds.Add("csb_trafficwarden");    //"Traffic Warden" />
                sPeds.Add("s_m_y_fireman_01");    //"Fireman Male" />
                sPeds.Add("s_m_m_paramedic_01");    //"Paramedic" />
                sPeds.Add("s_m_m_prisguard_01");    //"Prison Guard" />
            }       //Random Services
            else if (iRando == 50)
            {
                sPeds.Add("a_m_m_mexlabor_01");    //"Mexican Labourer" />
                sPeds.Add("s_m_y_construct_01");    //"construction Worker" />
                sPeds.Add("s_m_y_construct_02");    //"construction Worker 2" />
                sPeds.Add("s_m_m_lathandy_01");    //"Latino Handyman Male" />
            }       //construction
            else if (iRando == 51)
            {
                sPeds.Add("a_f_m_beach_01");    //"Beach Female" />
                sPeds.Add("A_F_Y_Beach_02");
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
                sPeds.Add("a_m_m_malibu_01");    //"Malibu Male" />
                sPeds.Add("a_m_y_sunbathe_01");    //"Sunbather Male" />
                sPeds.Add("a_m_y_hippy_01");    //"Hippie Male" />
                sPeds.Add("a_f_y_hippie_01");    //"Hippie Female" />
                sPeds.Add("a_m_y_beachvesp_01");    //"Vespucci Beach Male" />
                sPeds.Add("a_m_y_beachvesp_02");    //"Vespucci Beach Male 2" />
                sPeds.Add("u_m_y_party_01");    //"Partygoer" />
            }       //YachtParty
            else if (iRando == 52)
            {
                sPeds.Add("G_M_M_CartelGuards_01");
                sPeds.Add("G_M_M_CartelGuards_02");

            }       //CayoMob
            else if (iRando == 53)
            {
                sPeds.Add("A_F_Y_CarClub_01");
                sPeds.Add("A_M_Y_CarClub_01");
                sPeds.Add("CSB_DrugDealer");
                sPeds.Add("S_F_M_RetailStaff_01");
                sPeds.Add("S_M_M_RaceOrg_01");

            }       //carmeat
            else if (iRando == 54)
            {
                sPeds.Add("a_f_y_clubcust_01");
                sPeds.Add("a_f_y_clubcust_02");
                sPeds.Add("a_f_y_clubcust_03");
                sPeds.Add("a_f_y_clubcust_04");
                sPeds.Add("a_m_y_clubcust_01");
                sPeds.Add("a_m_y_clubcust_02");
                sPeds.Add("a_m_y_clubcust_03");
                sPeds.Add("a_m_y_clubcust_04");
            }       //clubing
            else
            {
                sPeds.Add("a_m_m_tramp_01");    //"Tramp Male" />
            }


            if (sPeds.Count > 0)
            {
                if (sPeds.Count > 1)
                    sPedds = sPeds[RandInt(0, sPeds.Count - 1)];
                else
                    sPedds = sPeds[0];
            }
            else
                sPedds = "a_m_m_tramp_01";

            return sPedds;
        }
        public static int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        public static List<string> DanceList(bool bMale, int iSpeed)
        {
            LoggerLight.LogThis("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);

            List<string> sDancing = new List<string>();
            List<string> Dance = new List<string>(); List<string> DanceVar = new List<string>();

            if (bMale)
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^5");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^6");
                }

                if (Dance.Count > 0)
                {
                    int iRand = RandInt(0, Dance.Count - 1);
                    sDancing.Add(Dance[iRand]);
                    sDancing.Add(DanceVar[iRand]);
                }
                else
                {
                    sDancing.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity");
                    sDancing.Add("li_dance_facedj_17_v2_male^6");
                }
            }
            else
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^6");
                }

                if (Dance.Count > 0)
                {
                    int iRand = RandInt(0, Dance.Count - 1);
                    sDancing.Add(Dance[iRand]);
                    sDancing.Add(DanceVar[iRand]);
                }
                else
                {
                    sDancing.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity");
                    sDancing.Add("li_dance_facedj_17_v2_female^6");
                }
            }

            return sDancing;
        }
        public static int PedWalkies(Ped Peddy, List<Vector3> MyLister, int iLocalList)
        {
            LoggerLight.LogThis("PedWalkies");

            iLocalList += 1;
            if (iLocalList == MyLister.Count())
                iLocalList = 0;

            int iReturnInt = iLocalList;

            ObjectHand.WalkThisWay(Peddy, MyLister[iReturnInt], 1.00f);

            return iReturnInt;
        }
        public static bool PedRunToFoward(Ped Peddy, List<Vector3> MyLister, int iLocal, float fSpeed)
        {
            LoggerLight.LogThis("PedRunToFoward");

            bool bInUse = true;

            if (iLocal < MyLister.Count)
                ObjectHand.WalkThisWay(Peddy, MyLister[iLocal], fSpeed);
            else
                bInUse = false;

            return bInUse;
        }
        public static Blip PedBlimp(Ped pEdd, float fSize, bool bFlashin, bool bShowR, int iColour, string sName)
        {
            LoggerLight.LogThis("PedBlimp");
            Blip Blipy = null;

            if (pEdd.CurrentBlip.Exists())
                Blipy = pEdd.CurrentBlip;
            else
                Blipy = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, pEdd.Handle);

            if (fSize != 1.00f)
                Function.Call(Hash.SET_BLIP_SCALE, Blipy.Handle, fSize);

            if (iColour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, Blipy.Handle, iColour);

            if (bFlashin)
                Function.Call(Hash.SET_BLIP_FLASHES, Blipy.Handle, bFlashin);

            if (bShowR && DataStore.MySettings.ShowRoute)
                pEdd.CurrentBlip.ShowRoute = true;

            if (sName != "")
                ObjectHand.BlipNames(pEdd.CurrentBlip, sName);

            return Blipy;
        }
        public static Blip VehBlip(Vehicle Vhic, bool bFlashin, bool bShowR, int iColour, string sName)
        {
            LoggerLight.LogThis("VehBlip");
            Blip MyBlip = null;

            if (Vhic.CurrentBlip.Exists())
                MyBlip = Vhic.CurrentBlip;
            else
                MyBlip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, Vhic.Handle);

            Function.Call(Hash.SET_BLIP_SPRITE, MyBlip.Handle, OhMyBlip(Vhic));
            if (iColour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, MyBlip.Handle, iColour);

            if (bFlashin)
                Function.Call(Hash.SET_BLIP_FLASHES, MyBlip.Handle, true);

            if (bShowR && DataStore.MySettings.ShowRoute)
                Function.Call(Hash.SET_BLIP_ROUTE, MyBlip.Handle, bShowR);

            if (sName != "")
                ObjectHand.BlipNames(MyBlip, sName);

            return MyBlip;
        }
        public static int OhMyBlip(Vehicle Vhick)
        {
            LoggerLight.LogThis("OhMyBlip");
            int iVehHash = Vhick.Model.Hash;

            int iBeLip = 0;
            if (Vhick.ClassType == VehicleClass.Planes)
                iBeLip = 251;
            else if (Vhick.ClassType == VehicleClass.Helicopters)
                iBeLip = 43;
            else if (Vhick.ClassType == VehicleClass.Boats)
                iBeLip = 427;
            else if (Vhick.ClassType == VehicleClass.Commercial)
                iBeLip = 477;
            else if (Vhick.ClassType == VehicleClass.Motorcycles)
                iBeLip = 226;
            else if (Vhick.ClassType == VehicleClass.Sports)
                iBeLip = 523;
            else if (Vhick.ClassType == VehicleClass.Super)
                iBeLip = 523;
            else if (Vhick.ClassType == VehicleClass.Cycles)
                iBeLip = 376;
            else if (Vhick.ClassType == VehicleClass.Vans)
                iBeLip = 616;
            else
                iBeLip = 225;

            if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "CRUSADER"))
                iBeLip = 800;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SLAMVAN3"))
                iBeLip = 799;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "barracks2"))
                iBeLip = 477;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "STROMBERG"))
                iBeLip = 596;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SQUADDIE"))
                iBeLip = 757;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seasparrow2"))
                iBeLip = 753;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "WINKY"))
                iBeLip = 745;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ZHABA"))
                iBeLip = 737;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "OUTLAW"))
                iBeLip = 735;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "VAGRANT"))
                iBeLip = 736;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "STRIKEFORCE"))
                iBeLip = 640;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "OPPRESSOR2"))
                iBeLip = 639;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SCRAMJET"))
                iBeLip = 634;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seasparrow"))
                iBeLip = 612;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "APC"))
                iBeLip = 603;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "akula"))
                iBeLip = 602;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "volatol"))
                iBeLip = 600;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "KHANJALI"))
                iBeLip = 598;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DELUXO"))
                iBeLip = 596;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "bombushka"))
                iBeLip = 585;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seabreeze"))
                iBeLip = 584;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "STARLING"))
                iBeLip = 583;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ROGUE"))
                iBeLip = 582;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "PYRO"))
                iBeLip = 581;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "nokota"))
                iBeLip = 580;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "MOLOTOK"))
                iBeLip = 579;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "mogul"))
                iBeLip = 578;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "microlight"))
                iBeLip = 577;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "HUNTER"))
                iBeLip = 576;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "howard"))
                iBeLip = 575;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "havok"))
                iBeLip = 574;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tula"))
                iBeLip = 573;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "alphaz1"))
                iBeLip = 572;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DUNE3"))
                iBeLip = 561;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "HALFTRACK"))
                iBeLip = 560;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "OPPRESSOR"))
                iBeLip = 559;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "TECHNICAL2"))
                iBeLip = 534;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "voltic2"))
                iBeLip = 533;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "wastelander"))
                iBeLip = 532;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "RUINER2"))
                iBeLip = 530;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "PHANTOM2"))
                iBeLip = 528;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "RHINO"))
                iBeLip = 421;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "taxi"))
                iBeLip = 198;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "stretch"))
                iBeLip = 198;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "stockade"))
                iBeLip = 67;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "dune"))
                iBeLip = 147;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "pbus2"))
                iBeLip = 631;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "marquis"))
                iBeLip = 410;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "limo2"))
                iBeLip = 460;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ambulance"))
                iBeLip = 636;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "firetruk"))
                iBeLip = 635;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "bulldozer"))
                iBeLip = 529;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "forklift"))
                iBeLip = 568;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "mixer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tiptruck") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tiptruck2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "rubble") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "Dump"))
                iBeLip = 745;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "formula") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "formula2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "openwheel1") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "openwheel2"))
                iBeLip = 726;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "cargobob") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "cargobob2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "cargobob3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "cargobob4"))
                iBeLip = 481;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blazer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blazer2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blazer3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blazer4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blazer5"))
                iBeLip = 512;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "pbus") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "airbus") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "bus") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "coach"))
                iBeLip = 513;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trash") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trash2"))
                iBeLip = 318;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "submersible") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "submersible2"))
                iBeLip = 308;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "VALKYRIE2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "VALKYRIE"))
                iBeLip = 759;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DUNE4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DUNE5"))
                iBeLip = 531;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "besra") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "hydra") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "lazer"))
                iBeLip = 16;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blimp") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blimp2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "blimp3"))
                iBeLip = 401;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ZR380") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ZR3802") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ZR3803"))
                iBeLip = 669;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SLAMVAN4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SLAMVAN5") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SLAMVAN6"))
                iBeLip = 668;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SCARAB") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SCARAB2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "SCARAB3"))
                iBeLip = 667;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "MONSTER3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "MONSTER4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "MONSTER5"))
                iBeLip = 666;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ISSI4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ISSI5") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "ISSI6"))
                iBeLip = 665;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPERATOR") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPERATOR2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPERATOR3"))
                iBeLip = 664;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPALER2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPALER3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "IMPALER4"))
                iBeLip = 663;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DOMINATOR4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DOMINATOR5") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "DOMINATOR6"))
                iBeLip = 662;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "CERBERUS") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "CERBERUS2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "CERBERUS3"))
                iBeLip = 660;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUTUS") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUTUS2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUTUS3"))
                iBeLip = 659;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUISER") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUISER2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "BRUISER3"))
                iBeLip = 658;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seashark") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seashark2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "seashark3"))
                iBeLip = 471;
            else if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "armytanker") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "armytrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "armytrailer2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "baletrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "boattrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "freighttrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "graintrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tr2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tr3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tr4") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trflat") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tvtrailer") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tanker") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "tanker2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailerlarge") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailerlogs") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailersmall") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailers") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailers2") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailers3") || iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, "trailers4"))
                iBeLip = 479;
            //Sportsbike 522
            //sportscar 523
            //partybuss 631

            return iBeLip;
        }
        public static int MyCorona(Vector3 Vtech, float fRaid)
        {
            LoggerLight.LogThis("TheYellowCorona");

            Vector3 Vsp = new Vector3(0.00f, 0.00f, 0.00f);
            int type = 47;

            float posX1 = Vtech.X;
            float posY1 = Vtech.Y;
            float posZ1 = Vtech.Z;
            float posX2 = Vsp.X;
            float posY2 = Vsp.Y;
            float posZ2 = Vsp.Z;

            int red = 255;
            int green = 255;
            int blue = 0;
            int alpha = 255;
            int reserved = 180;

            int ThisCheck = Function.Call<int>(Hash.CREATE_CHECKPOINT, type, posX1, posY1, posZ1, posX2, posY2, posZ2, fRaid, red, green, blue, alpha, reserved);
            Function.Call(Hash.SET_CHECKPOINT_CYLINDER_HEIGHT, ThisCheck, fRaid / 2, fRaid / 2, fRaid);
            return ThisCheck;
        }
        public static List<string> VehicleListX(int iList, int iType, bool bAddCustom)
        {
            LoggerLight.LogThis("VehicleListX, iList == " + iList + ", iType == " + iType + ", bAddCustom == " + bAddCustom);

            List<string> sVehicles = new List<string>();

            if (iType == 1)
            {
                if (iList == 0)
                {
                    if (DataStore.MyCusVeh.MyCarz.Count > 0)
                        sVehicles = DataStore.MyCusVeh.MyCarz;
                    else
                        sVehicles.Add("BJXL");
                }            //Custom
                else if (iList == 1)
                {
                    sVehicles.Add("PFISTER811");//<!-- 811 -->
                    sVehicles.Add("ADDER");//
                    sVehicles.Add("AUTARCH");//
                    sVehicles.Add("BANSHEE2");//<!-- Banshee 900R -->
                    sVehicles.Add("BULLET");//
                    sVehicles.Add("CHAMPION");//
                    sVehicles.Add("CHEETAH");//
                    sVehicles.Add("CYCLONE");//
                    sVehicles.Add("DEVESTE");//
                    sVehicles.Add("EMERUS");//
                    sVehicles.Add("ENTITYXF");//
                    sVehicles.Add("ENTITY2");//<!-- Entity XXR -->
                    sVehicles.Add("SHEAVA");//<!-- ETR1 -->
                    sVehicles.Add("FMJ");//
                    sVehicles.Add("FURIA");//
                    sVehicles.Add("GP1");//
                    sVehicles.Add("IGNUS");//
                    sVehicles.Add("INFERNUS");//
                    sVehicles.Add("ITALIGTB");//
                    sVehicles.Add("ITALIGTB2");//<!-- Itali GTB Custom -->
                    sVehicles.Add("KRIEGER");//
                    sVehicles.Add("OSIRIS");//
                    sVehicles.Add("NERO");//
                    sVehicles.Add("NERO2");//<!-- Nero Custom -->
                    sVehicles.Add("PENETRATOR");//
                    sVehicles.Add("LE7B");//<!-- RE-7B -->
                    sVehicles.Add("REAPER");//
                    sVehicles.Add("VOLTIC2");//<!-- Rocket Voltic -->
                    sVehicles.Add("S80");//
                    sVehicles.Add("SC1");//
                    sVehicles.Add("SCRAMJET");//
                    sVehicles.Add("SULTANRS");//
                    sVehicles.Add("T20");//
                    sVehicles.Add("TAIPAN");//
                    sVehicles.Add("TEMPESTA");//
                    sVehicles.Add("TEZERACT");//
                    sVehicles.Add("THRAX");//
                    sVehicles.Add("TIGON");//
                    sVehicles.Add("TURISMOR");//
                    sVehicles.Add("TYRANT");//
                    sVehicles.Add("TYRUS");//
                    sVehicles.Add("VACCA");//
                    sVehicles.Add("VAGNER");//
                    sVehicles.Add("VIGILANTE");//
                    sVehicles.Add("VISIONE");//
                    sVehicles.Add("VOLTIC");//
                    sVehicles.Add("PROTOTIPO");//<!-- X80 Proto -->
                    sVehicles.Add("XA21");//
                    sVehicles.Add("ZENO");//
                    sVehicles.Add("ZENTORNO");//
                    sVehicles.Add("ZORRUSSO");//
                    sVehicles.Add("torero2");//
                    sVehicles.Add("lm87");//
                }       //Super
                else if (iList == 2)
                {
                    sVehicles.Add("DRAFTER");//<!-- 8F Drafter -->
                    sVehicles.Add("NINEF");//
                    sVehicles.Add("NINEF2");//<!-- 9F Cabrio -->
                    sVehicles.Add("ALPHA");//
                    sVehicles.Add("BANSHEE");//
                    sVehicles.Add("BESTIAGTS");//
                    sVehicles.Add("BLISTA2");//<!-- Blista Compact -->
                    sVehicles.Add("BUFFALO");//
                    sVehicles.Add("BUFFALO2");//<!-- Buffalo S -->
                    sVehicles.Add("CALICO");//<!-- Calico GTF -->
                    sVehicles.Add("CARBONIZZARE");//
                    sVehicles.Add("COMET2");//<!-- Comet -->
                    sVehicles.Add("COMET3");//<!-- Comet Retro Custom -->
                    sVehicles.Add("COMET6");//<!-- Comet S2 -->
                    sVehicles.Add("COMET7");//<!-- Comet S2 Cabrio -->
                    sVehicles.Add("COMET4");//<!-- Comet Safari -->
                    sVehicles.Add("COMET5");//<!-- Comet SR -->
                    sVehicles.Add("COQUETTE");//
                    sVehicles.Add("COQUETTE4");//<!-- Coquette D10 -->
                    sVehicles.Add("CYPHER");//
                    sVehicles.Add("TAMPA2");//<!-- Drift Tampa -->
                    sVehicles.Add("ELEGY");//<!-- Elegy Retro Custom -->
                    sVehicles.Add("ELEGY2");//<!-- Elegy RH8 -->
                    sVehicles.Add("EUROS");//
                    sVehicles.Add("FELTZER2");//<!-- Feltzer -->
                    sVehicles.Add("FLASHGT");//
                    sVehicles.Add("FUROREGT");//
                    sVehicles.Add("FUSILADE");//
                    sVehicles.Add("FUTO");//
                    sVehicles.Add("FUTO2");//<!-- Futo GTX -->
                    sVehicles.Add("GB200");//
                    sVehicles.Add("BLISTA3");//<!-- Go Go Monkey Blista -->
                    sVehicles.Add("GROWLER");//
                    sVehicles.Add("HOTRING");//
                    sVehicles.Add("IMORGON");//
                    sVehicles.Add("ISSI7");//<!-- Issi Sport -->
                    sVehicles.Add("ITALIGTO");//
                    sVehicles.Add("ITALIRSX");//
                    sVehicles.Add("JESTER");//
                    sVehicles.Add("JESTER2");//<!-- Jester (Racecar) -->
                    sVehicles.Add("JESTER3");//<!-- Jester Classic -->
                    sVehicles.Add("JESTER4");//<!-- Jester RR -->
                    sVehicles.Add("JUGULAR");//
                    sVehicles.Add("KHAMELION");//
                    sVehicles.Add("KOMODA");//
                    sVehicles.Add("KURUMA");//
                    sVehicles.Add("KURUMA2");//<!-- Kuruma (Armored) -->
                    sVehicles.Add("LOCUST");//
                    sVehicles.Add("LYNX");//
                    sVehicles.Add("MASSACRO");//
                    sVehicles.Add("MASSACRO2");//<!-- Massacro (Racecar) -->
                    sVehicles.Add("NEO");//
                    sVehicles.Add("NEON");//
                    sVehicles.Add("OMNIS");//
                    sVehicles.Add("PARAGON");//
                    sVehicles.Add("PARAGON2");//<!-- Paragon R (Armored) -->
                    sVehicles.Add("PARIAH");//
                    sVehicles.Add("PENUMBRA");//
                    sVehicles.Add("PENUMBRA2");//<!-- Penumbra FF -->
                    sVehicles.Add("RAIDEN");//
                    sVehicles.Add("RAPIDGT");//
                    sVehicles.Add("RAPIDGT2");//<!-- Rapid GT Cabrio -->
                    sVehicles.Add("RAPTOR");//
                    sVehicles.Add("REMUS");//
                    sVehicles.Add("REVOLTER");//
                    sVehicles.Add("RT3000");//
                    sVehicles.Add("RUSTON");//
                    sVehicles.Add("SCHAFTER4");//<!-- Schafter LWB -->
                    sVehicles.Add("SCHAFTER3");//<!-- Schafter V12 -->
                    sVehicles.Add("SCHLAGEN");//
                    sVehicles.Add("SCHWARZER");//
                    sVehicles.Add("SENTINEL3");//<!-- Sentinel Classic -->
                    sVehicles.Add("SEVEN70");//
                    sVehicles.Add("SPECTER");//
                    sVehicles.Add("SPECTER2");//<!-- Specter Custom -->
                    sVehicles.Add("BUFFALO3");//<!-- Sprunk Buffalo -->
                    sVehicles.Add("STREITER");//
                    sVehicles.Add("SUGOI");//
                    sVehicles.Add("SULTAN");//
                    sVehicles.Add("SULTAN2");//<!-- Sultan Classic -->
                    sVehicles.Add("SULTAN3");//<!-- Sultan RS Classic -->
                    sVehicles.Add("SURANO");//
                    sVehicles.Add("TROPOS");//
                    sVehicles.Add("VSTR");//<!-- V-STR -->
                    sVehicles.Add("VECTRE");//
                    sVehicles.Add("VERLIERER2");//
                    sVehicles.Add("ZR350");//
                    sVehicles.Add("corsita");//
                    sVehicles.Add("omnisegt");//
                    sVehicles.Add("sm722");//
                    sVehicles.Add("tenf");//
                    sVehicles.Add("tenf2");//
                    sVehicles.Add("sentinel4");//
                }       //Sports
                else if (iList == 3)
                {
                    sVehicles.Add("COGCABRIO");//
                    sVehicles.Add("EXEMPLAR");//
                    sVehicles.Add("F620");//
                    sVehicles.Add("FELON");//
                    sVehicles.Add("FELON2");//<!-- Felon GT -->
                    sVehicles.Add("JACKAL");//
                    sVehicles.Add("ORACLE");//
                    sVehicles.Add("ORACLE2");//<!-- Oracle XS -->
                    sVehicles.Add("PREVION");//
                    sVehicles.Add("SENTINEL2");//<!-- Sentinel -->
                    sVehicles.Add("SENTINEL");//<!-- Sentinel XS -->
                    sVehicles.Add("WINDSOR");//
                    sVehicles.Add("WINDSOR2");//<!-- Windsor Drop -->
                    sVehicles.Add("ZION");//
                    sVehicles.Add("ZION2");//<!-- Zion Cabrio -->
                    sVehicles.Add("kanjosj");//
                    sVehicles.Add("postlude");//
                }       //Coups
                else if (iList == 4)
                {
                    sVehicles.Add("DUKES3");//<!-- Beater Dukes -->
                    sVehicles.Add("BLADE");//
                    sVehicles.Add("BUCCANEER");//
                    sVehicles.Add("BUCCANEER2");//<!-- Buccaneer Custom -->
                    sVehicles.Add("BUFFALO4");//<!-- Buffalo STX -->
                    sVehicles.Add("STALION2");//<!-- Burger Shot Stallion -->
                    sVehicles.Add("CHINO");//
                    sVehicles.Add("CHINO2");//<!-- Chino Custom -->
                    sVehicles.Add("CLIQUE");//
                    sVehicles.Add("COQUETTE3");//<!-- Coquette BlackFin -->
                    sVehicles.Add("DEVIANT");//
                    sVehicles.Add("DOMINATOR");//
                    sVehicles.Add("DOMINATOR7");//<!-- Dominator ASP -->
                    sVehicles.Add("DOMINATOR8");//<!-- Dominator GTT -->
                    sVehicles.Add("DOMINATOR3");//<!-- Dominator GTX -->
                    sVehicles.Add("YOSEMITE2");//<!-- Drift Yosemite -->
                    sVehicles.Add("DUKES2");//<!-- Duke O'Death -->
                    sVehicles.Add("DUKES");//
                    sVehicles.Add("ELLIE");//
                    sVehicles.Add("FACTION");//
                    sVehicles.Add("FACTION2");//<!-- Faction Custom -->
                    sVehicles.Add("FACTION3");//<!-- Faction Custom Donk -->
                    sVehicles.Add("GAUNTLET");//
                    sVehicles.Add("GAUNTLET3");//<!-- Gauntlet Classic -->
                    sVehicles.Add("GAUNTLET5");//<!-- Gauntlet Classic Custom -->
                    sVehicles.Add("GAUNTLET4");//<!-- Gauntlet Hellfire -->
                    sVehicles.Add("HERMES");//
                    sVehicles.Add("HOTKNIFE");//
                    sVehicles.Add("HUSTLER");//
                    sVehicles.Add("IMPALER");//
                    sVehicles.Add("SLAMVAN2");//<!-- Lost Slamvan -->
                    sVehicles.Add("LURCHER");//
                    sVehicles.Add("MANANA2");//<!-- Manana Custom -->
                    sVehicles.Add("MOONBEAM");//
                    sVehicles.Add("MOONBEAM2");//<!-- Moonbeam Custom -->
                    sVehicles.Add("NIGHTSHADE");//
                    sVehicles.Add("PEYOTE2");//<!-- Peyote Gasser -->
                    sVehicles.Add("PHOENIX");//
                    sVehicles.Add("PICADOR");//
                    sVehicles.Add("DOMINATOR2");//<!-- Pisswasser Dominator -->
                    sVehicles.Add("RATLOADER");//
                    sVehicles.Add("RATLOADER2");//<!-- Rat-Truck -->
                    sVehicles.Add("GAUNTLET2");//<!-- Redwood Gauntlet -->
                    sVehicles.Add("RUINER");//
                    sVehicles.Add("RUINER2");//<!-- Ruiner 2000 -->
                    sVehicles.Add("SABREGT");//
                    sVehicles.Add("SABREGT2");//<!-- Sabre Turbo Custom -->
                    sVehicles.Add("SLAMVAN");//
                    sVehicles.Add("SLAMVAN3");//<!-- Slamvan Custom -->
                    sVehicles.Add("STALION");//
                    sVehicles.Add("TAMPA");//
                    sVehicles.Add("TULIP");//
                    sVehicles.Add("VAMOS");//
                    sVehicles.Add("VIGERO");//
                    sVehicles.Add("VIRGO");//
                    sVehicles.Add("VIRGO3");//<!-- Virgo Classic -->
                    sVehicles.Add("VIRGO2");//<!-- Virgo Classic Custom -->
                    sVehicles.Add("VOODOO");//
                    sVehicles.Add("VOODOO2");//<!-- Voodoo Custom -->
                    sVehicles.Add("TAMPA3");//<!-- Weaponized Tampa -->
                    sVehicles.Add("YOSEMITE");//
                    sVehicles.Add("greenwood");//
                    sVehicles.Add("ruiner4");//
                    sVehicles.Add("vigero2");//
                    sVehicles.Add("weevil2");//
                }       //Muscle
                else if (iList == 5)
                {
                    sVehicles.Add("Z190");//<!-- 190z -->
                    sVehicles.Add("ARDENT");//
                    sVehicles.Add("CASCO");//
                    sVehicles.Add("CHEBUREK");//
                    sVehicles.Add("CHEETAH2");//<!-- Cheetah Classic -->
                    sVehicles.Add("COQUETTE2");//<!-- Coquette Classic -->
                    sVehicles.Add("DELUXO");//
                    sVehicles.Add("DYNASTY");//
                    sVehicles.Add("FAGALOA");//
                    sVehicles.Add("BTYPE2");//<!-- FrÃ¤nken Stange -->
                    sVehicles.Add("GT500");//
                    sVehicles.Add("INFERNUS2");//<!-- Infernus Classic -->
                    sVehicles.Add("JB700");//
                    sVehicles.Add("JB7002");//<!-- JB 700W -->
                    sVehicles.Add("MAMBA");//
                    sVehicles.Add("MANANA");//
                    sVehicles.Add("MICHELLI");//
                    sVehicles.Add("MONROE");//
                    sVehicles.Add("NEBULA");//
                    sVehicles.Add("PEYOTE");//
                    sVehicles.Add("PEYOTE3");//<!-- Peyote Custom -->
                    sVehicles.Add("PIGALLE");//
                    sVehicles.Add("RAPIDGT3");//<!-- Rapid GT Classic -->
                    sVehicles.Add("RETINUE");//
                    sVehicles.Add("RETINUE2");//<!-- Retinue MkII -->
                    sVehicles.Add("BTYPE");//<!-- Roosevelt -->
                    sVehicles.Add("BTYPE3");//<!-- Roosevelt Valor -->
                    sVehicles.Add("SAVESTRA");//
                    sVehicles.Add("STINGER");//
                    sVehicles.Add("STINGERGT");//
                    sVehicles.Add("FELTZER3");//<!-- Stirling GT -->
                    sVehicles.Add("STROMBERG");//
                    sVehicles.Add("SWINGER");//
                    sVehicles.Add("TOREADOR");//
                    sVehicles.Add("TORERO");//
                    sVehicles.Add("TORNADO");//
                    sVehicles.Add("TORNADO2");//<!-- Tornado Cabrio -->
                    sVehicles.Add("TORNADO3");//<!-- Rusty Tornado -->
                    sVehicles.Add("TORNADO4");//<!-- Mariachi Tornado -->
                    sVehicles.Add("TORNADO5");//<!-- Tornado Custom -->
                    sVehicles.Add("TORNADO6");//<!-- Tornado Rat Rod -->
                    sVehicles.Add("TURISMO2");//<!-- Turismo Classic -->
                    sVehicles.Add("VISERIS");//
                    sVehicles.Add("ZTYPE");//
                    sVehicles.Add("ZION3");//<!-- Zion Classic -->
                }       //Sportsclassic
                else if (iList == 6)
                {
                    sVehicles.Add("ASEA");//
                    sVehicles.Add("ASEA2");//<!-- Asea North Yankton variant -->
                    sVehicles.Add("ASTEROPE");//
                    sVehicles.Add("CINQUEMILA");//
                    sVehicles.Add("COGNOSCENTI");//
                    sVehicles.Add("COGNOSCENTI2");//<!-- Cognoscenti (Armored) -->
                    sVehicles.Add("COG55");//<!-- Cognoscenti 55 -->
                    sVehicles.Add("COG552");//<!-- Cognoscenti 55 (Armored) -->
                    sVehicles.Add("DEITY");//
                    sVehicles.Add("EMPEROR");//
                    sVehicles.Add("EMPEROR2");//<!-- Emperor beater variant -->
                    sVehicles.Add("EMPEROR3");//<!-- Emperor North Yankton variant -->
                    sVehicles.Add("FUGITIVE");//
                    sVehicles.Add("GLENDALE");//
                    sVehicles.Add("GLENDALE2");//<!-- Glendale Custom -->
                    sVehicles.Add("INGOT");//
                    sVehicles.Add("INTRUDER");//
                    sVehicles.Add("PREMIER");//
                    sVehicles.Add("PRIMO");//
                    sVehicles.Add("PRIMO2");//<!-- Primo Custom -->
                    sVehicles.Add("REGINA");//
                    sVehicles.Add("ROMERO");//
                    sVehicles.Add("SCHAFTER2");//
                    sVehicles.Add("SCHAFTER6");//<!-- Schafter LWB (Armored) -->
                    sVehicles.Add("SCHAFTER5");//<!-- Schafter V12 (Armored) -->
                    sVehicles.Add("STAFFORD");//
                    sVehicles.Add("STANIER");//
                    sVehicles.Add("STRATUM");//
                    sVehicles.Add("SUPERD");//
                    sVehicles.Add("SURGE");//
                    sVehicles.Add("TAILGATER");//
                    sVehicles.Add("TAILGATER2");//<!-- Tailgater S -->
                    sVehicles.Add("WARRENER");//
                    sVehicles.Add("WARRENER2");//<!-- Warrener HKR -->
                    sVehicles.Add("WASHINGTON");//
                    sVehicles.Add("rhinehart");//
                }       //Sedan
                else if (iList == 7)
                {
                    sVehicles.Add("BIFTA");//
                    sVehicles.Add("BLAZER");//
                    sVehicles.Add("BLAZER5");//<!-- Blazer Aqua -->
                    sVehicles.Add("BLAZER2");//<!-- Blazer Lifeguard -->
                    sVehicles.Add("BODHI2");//
                    sVehicles.Add("BRAWLER");//
                    sVehicles.Add("CARACARA");//
                    sVehicles.Add("CARACARA2");//<!-- Caracara 4x4 -->
                    sVehicles.Add("TROPHYTRUCK2");//<!-- Desert Raid -->
                    sVehicles.Add("DUBSTA3");//<!-- Dubsta 6x6 -->
                    sVehicles.Add("DUNE");//
                    sVehicles.Add("DUNE3");//<!-- Dune FAV -->
                    sVehicles.Add("DLOADER");//
                    sVehicles.Add("EVERON");//
                    sVehicles.Add("FREECRAWLER");//
                    sVehicles.Add("HELLION");//
                    sVehicles.Add("BLAZER3");//<!-- Hot Rod Blazer -->
                    sVehicles.Add("BFINJECTION");//
                    sVehicles.Add("INSURGENT");//
                    sVehicles.Add("INSURGENT2");//<!-- Insurgent Pick-Up -->
                    sVehicles.Add("INSURGENT3");//<!-- Insurgent Pick-Up Custom -->
                    sVehicles.Add("KALAHARI");//
                    sVehicles.Add("KAMACHO");//
                    sVehicles.Add("MENACER");//
                    sVehicles.Add("MESA3");//<!-- Merryweather Mesa -->
                    sVehicles.Add("NIGHTSHARK");//
                    sVehicles.Add("OUTLAW");//
                    sVehicles.Add("PATRIOT3");//<!-- Patriot Mil-Spec -->
                    sVehicles.Add("DUNE4");//<!-- Ramp Buggy mission variant -->
                    sVehicles.Add("DUNE5");//<!-- Ramp Buggy -->
                    sVehicles.Add("RANCHERXL");//
                    sVehicles.Add("RANCHERXL2");//<!-- Rancher XL North Yankton variant -->
                    sVehicles.Add("REBEL2");//
                    sVehicles.Add("RIATA");//
                    sVehicles.Add("REBEL");//<!-- Rusty Rebel -->
                    sVehicles.Add("SANDKING2");//<!-- Sandking SWB -->
                    sVehicles.Add("SANDKING");//<!-- Sandking XL -->
                    sVehicles.Add("DUNE2");//<!-- Space Docker -->
                    sVehicles.Add("BLAZER4");//<!-- Street Blazer -->
                    sVehicles.Add("TECHNICAL");//
                    sVehicles.Add("TECHNICAL2");//<!-- Technical Aqua -->
                    sVehicles.Add("TECHNICAL3");//<!-- Technical Custom -->
                    sVehicles.Add("TROPHYTRUCK");//
                    sVehicles.Add("VAGRANT");//
                    sVehicles.Add("VERUS");//
                    sVehicles.Add("WINKY");//
                    sVehicles.Add("YOSEMITE3");//<!-- Yosemite Rancher -->
                    sVehicles.Add("ZHABA");//
                    sVehicles.Add("draugur");//
                }       //Offroad
                else if (iList == 8)
                {
                    sVehicles.Add("ASTRON");//
                    sVehicles.Add("BALLER");//
                    sVehicles.Add("BALLER2");//<!-- Baller 2nd gen variant -->
                    sVehicles.Add("BALLER3");//<!-- Baller LE -->
                    sVehicles.Add("BALLER5");//<!-- Baller LE (Armored) -->
                    sVehicles.Add("BALLER4");//<!-- Baller LE LWB -->
                    sVehicles.Add("BALLER6");//<!-- Baller LE LWB (Armored) -->
                    sVehicles.Add("BALLER7");//<!-- Baller ST -->
                    sVehicles.Add("BJXL");//
                    sVehicles.Add("CAVALCADE");//
                    sVehicles.Add("CAVALCADE2");//<!-- Cavalcade 2nd gen variant -->
                    sVehicles.Add("CONTENDER");//
                    sVehicles.Add("DUBSTA");//
                    sVehicles.Add("DUBSTA2");//<!-- Dubsta black variant -->
                    sVehicles.Add("FQ2");//
                    sVehicles.Add("GRANGER");//
                    sVehicles.Add("GRANGER2");//<!-- Granger 3600LX -->
                    sVehicles.Add("GRESLEY");//
                    sVehicles.Add("HABANERO");//
                    sVehicles.Add("HUNTLEY");//
                    sVehicles.Add("IWAGEN");//
                    sVehicles.Add("JUBILEE");//
                    sVehicles.Add("LANDSTALKER");//
                    sVehicles.Add("LANDSTALKER2");//<!-- Landstalker XL -->
                    sVehicles.Add("MESA");//
                    sVehicles.Add("MESA2");//<!-- Mesa North Yankton variant -->
                    sVehicles.Add("NOVAK");//
                    sVehicles.Add("PATRIOT");//
                    sVehicles.Add("PATRIOT2");//<!-- Patriot Stretch -->
                    sVehicles.Add("RADI");//
                    sVehicles.Add("REBLA");//
                    sVehicles.Add("ROCOTO");//
                    sVehicles.Add("SEMINOLE");//
                    sVehicles.Add("SEMINOLE2");//<!-- Seminole Frontier -->
                    sVehicles.Add("SERRANO");//
                    sVehicles.Add("SQUADDIE");//
                    sVehicles.Add("TOROS");//
                    sVehicles.Add("XLS");//
                    sVehicles.Add("XLS2");//<!-- XLS (Armored) -->
                }       //SUV
                else if (iList == 9)
                {
                    sVehicles.Add("ASBO");//
                    sVehicles.Add("BLISTA");//
                    sVehicles.Add("KANJO");//<!-- Blista Kanjo -->
                    sVehicles.Add("BRIOSO");//
                    sVehicles.Add("BRIOSO2");//<!-- Brioso 300 -->
                    sVehicles.Add("CLUB");//
                    sVehicles.Add("DILETTANTE");//
                    sVehicles.Add("DILETTANTE2");//<!-- Merryweather Dilettante -->
                    sVehicles.Add("ISSI2");//
                    sVehicles.Add("ISSI3");//<!-- Issi Classic -->
                    sVehicles.Add("PANTO");//
                    sVehicles.Add("PRAIRIE");//
                    sVehicles.Add("RHAPSODY");//
                    sVehicles.Add("WEEVIL");//
                    sVehicles.Add("brioso3");//
                }       //Compact
                else if (iList == 10)
                {
                    sVehicles.Add("FORMULA");//<!-- PR4, should be Open Wheel class -->
                    sVehicles.Add("FORMULA2");//<!-- R88, should be Open Wheel class -->
                    sVehicles.Add("OPENWHEEL1");//<!-- BR8, should be Open Wheel class -->
                    sVehicles.Add("OPENWHEEL2");//<!-- DR1, should be Open Wheel class -->
                }       //F1
                else if (iList == 11)
                {
                    sVehicles.Add("VETO");//<!-- Veto Classic -->
                    sVehicles.Add("VETO2");//<!-- Veto Modern -->
                }       //Cart
                else if (iList == 12)
                {
                    sVehicles.Add("BISON");//
                    sVehicles.Add("BISON2");//<!-- McGill-Olsen Bison -->
                    sVehicles.Add("BISON3");//<!-- Mighty Bush Bison -->
                    sVehicles.Add("CONTENDER");//
                    sVehicles.Add("DUBSTA3");//<!-- Dubsta 6x6 -->
                    sVehicles.Add("GUARDIAN");//
                    sVehicles.Add("PICADOR");//
                    sVehicles.Add("SADLER");//
                    sVehicles.Add("SADLER2");//<!-- Sadler North Yankton variant -->
                    sVehicles.Add("SLAMVAN");//
                    sVehicles.Add("SLAMVAN3");//<!-- Slamvan Custom -->
                    sVehicles.Add("YOSEMITE");//
                    sVehicles.Add("SADLER");//
                    sVehicles.Add("SADLER2");//<!-- Sadler North Yankton variant -->
                    sVehicles.Add("GUARDIAN");//
                }       //Pickups
                else if (iList == 13)
                {
                    sVehicles.Add("BOXVILLE5");//<!-- Armored Boxville -->
                    sVehicles.Add("BISON");//
                    sVehicles.Add("BISON2");//<!-- McGill-Olsen Bison -->
                    sVehicles.Add("BISON3");//<!-- Mighty Bush Bison -->
                    sVehicles.Add("BOBCATXL");//
                    sVehicles.Add("BOXVILLE");//<!-- LSDWP Boxville -->
                    sVehicles.Add("BOXVILLE2");//<!-- Go Postal Boxville -->
                    sVehicles.Add("BOXVILLE3");//<!-- Humane Labs Boxville -->
                    sVehicles.Add("BOXVILLE4");//<!-- PostOp Boxville -->
                    sVehicles.Add("BURRITO");//
                    sVehicles.Add("BURRITO2");//<!-- Burrito Bugstars variant -->
                    sVehicles.Add("BURRITO3");//<!-- Burrito civilian variant -->
                    sVehicles.Add("BURRITO4");//<!-- Burrito McGill-Olsen variant -->
                    sVehicles.Add("BURRITO5");//<!-- Burrito North Yankton variant -->
                    sVehicles.Add("CAMPER");//
                    sVehicles.Add("SPEEDO2");//<!-- Clown Van -->
                    sVehicles.Add("GBURRITO");//<!-- Gang Burrito Lost MC variant -->
                    sVehicles.Add("GBURRITO2");//<!-- Gang Burrito heist variant -->
                    sVehicles.Add("JOURNEY");//
                    sVehicles.Add("MINIVAN");//
                    sVehicles.Add("MINIVAN2");//<!-- Minivan Custom -->
                    sVehicles.Add("PARADISE");//
                    sVehicles.Add("PONY");//
                    sVehicles.Add("PONY2");//<!-- Pony Smoke on the Water variant -->
                    sVehicles.Add("RUMPO");//
                    sVehicles.Add("RUMPO2");//<!-- Rumpo Deludamol variant -->
                    sVehicles.Add("RUMPO3");//<!-- Rumpo Custom -->
                    sVehicles.Add("SPEEDO");//
                    sVehicles.Add("SPEEDO4");//<!-- Speedo Custom -->
                    sVehicles.Add("SURFER");//
                    sVehicles.Add("SURFER2");//<!-- Surfer beater variant -->
                    sVehicles.Add("TACO");//
                    sVehicles.Add("YOUGA");//
                    sVehicles.Add("YOUGA2");//<!-- Youga Classic -->
                    sVehicles.Add("YOUGA3");//<!-- Youga Classic 4x4 -->
                    sVehicles.Add("YOUGA4");//<!-- Youga Custom -->
                }       //Vans
                else if (iList == 14)
                {
                    sVehicles.Add("APC");//
                    sVehicles.Add("AMBULANCE");//
                    sVehicles.Add("BARRACKS");//
                    sVehicles.Add("BARRACKS2");//<!-- Barracks Semi -->
                    sVehicles.Add("BARRAGE");//
                    sVehicles.Add("CHERNOBOG");//
                    sVehicles.Add("CRUSADER");//
                    sVehicles.Add("FBI");//<!-- FIB Buffalo -->
                    sVehicles.Add("FBI2");//<!-- FIB Granger -->
                    sVehicles.Add("FIRETRUK");//
                    sVehicles.Add("HALFTRACK");//
                    sVehicles.Add("LGUARD");//
                    sVehicles.Add("PRANGER");//<!-- Park Ranger -->
                    sVehicles.Add("POLICEB");//<!-- Police Bike -->
                    sVehicles.Add("POLICE2");//<!-- Police Cruiser Buffalo -->
                    sVehicles.Add("POLICE");//<!-- Police Cruiser Stanier -->
                    sVehicles.Add("POLICE3");//<!-- Police Cruiser Interceptor -->
                    sVehicles.Add("POLICEOLD1");//<!-- Police Rancher -->
                    sVehicles.Add("RIOT");//<!-- Police Riot -->
                    sVehicles.Add("POLICEOLD2");//<!-- Police Roadcruiser -->
                    sVehicles.Add("POLICET");//<!-- Police Transporter -->
                    sVehicles.Add("PBUS");//<!-- Prison Bus -->
                    sVehicles.Add("RIOT2");//<!-- RCV -->
                    sVehicles.Add("RHINO");//
                    sVehicles.Add("SHERIFF");//<!-- Sheriff Cruiser -->
                    sVehicles.Add("SHERIFF2");//<!-- Sheriff SUV -->
                    sVehicles.Add("KHANJALI");//<!-- TM-02 Khanjali -->
                    sVehicles.Add("POLICE4");//<!-- Unmarked Cruiser -->
                    sVehicles.Add("VETIR");//
                }       //Emergancy
                else if (iList == 15)
                {
                    sVehicles.Add("AIRBUS");//
                    sVehicles.Add("BUS");//
                    sVehicles.Add("COACH");//<!-- Dashound -->
                    sVehicles.Add("PBUS2");//<!-- Festival Bus -->
                    sVehicles.Add("RENTALBUS");//<!-- Rental Shuttle Bus -->
                    sVehicles.Add("TOURBUS");//
                }       //Bus
                else if (iList == 16)
                {
                    sVehicles.Add("AIRTUG");//
                    sVehicles.Add("BRICKADE");//
                    sVehicles.Add("BULLDOZER");//
                    sVehicles.Add("CADDY");//<!-- Caddy golf variant -->
                    sVehicles.Add("CADDY2");//<!-- Caddy civilian variant -->
                    sVehicles.Add("CADDY3");//<!-- Caddy bunker variant -->
                    sVehicles.Add("RALLYTRUCK");//<!-- Dune -->
                    sVehicles.Add("DOCKTUG");//
                    sVehicles.Add("TRACTOR2");//<!-- Fieldmaster -->
                    sVehicles.Add("TRACTOR3");//<!-- Fieldmaster North Yankton variant -->
                    sVehicles.Add("FORKLIFT");//
                    sVehicles.Add("MOWER");//
                    sVehicles.Add("RIPLEY");//
                    sVehicles.Add("SCRAP");//
                    sVehicles.Add("SLAMTRUCK");//
                    sVehicles.Add("TAXI");//
                    sVehicles.Add("TOWTRUCK2");//<!-- Tow Truck Slamvan variant -->
                    sVehicles.Add("TOWTRUCK");//<!-- Towtruck Yankee variant -->
                    sVehicles.Add("TRACTOR");//
                    sVehicles.Add("TRASH");//
                    sVehicles.Add("TRASH2");//<!-- Trashmaster heist variant -->
                    sVehicles.Add("UTILLITRUCK");//<!-- Utility Truck cherry picker variant -->
                    sVehicles.Add("UTILLITRUCK2");//<!-- Utility Truck flatbed variant -->
                    sVehicles.Add("UTILLITRUCK3");//<!-- Utility Truck pick-up variant -->
                    sVehicles.Add("WASTLNDR");//
                    sVehicles.Add("CUTTER");//
                    sVehicles.Add("BENSON");//
                    sVehicles.Add("BIFF");//
                    sVehicles.Add("HANDLER");//<!-- Dock Handler -->
                    sVehicles.Add("DUMP");//
                    sVehicles.Add("FLATBED");//
                    sVehicles.Add("HAULER");//
                    sVehicles.Add("HAULER2");//<!-- Hauler Custom -->
                    sVehicles.Add("MIXER");//
                    sVehicles.Add("MIXER2");//<!-- Mixer 8-wheel variant -->
                    sVehicles.Add("MULE");//
                    sVehicles.Add("MULE2");//<!-- Mule ramp door variant -->
                    sVehicles.Add("MULE3");//<!-- Mule heist variant -->
                    sVehicles.Add("MULE5");//<!-- Mule Contract DLC variant -->
                    sVehicles.Add("MULE4");//<!-- Mule Custom -->
                    sVehicles.Add("PACKER");//
                    sVehicles.Add("PHANTOM");//
                    sVehicles.Add("PHANTOM3");//<!-- Phantom Custom -->
                    sVehicles.Add("PHANTOM2");//<!-- Phantom Wedge -->
                    sVehicles.Add("POUNDER");//
                    sVehicles.Add("POUNDER2");//<!-- Pounder Custom -->
                    sVehicles.Add("RUBBLE");//
                    sVehicles.Add("STOCKADE");//<!-- Securicar -->
                    sVehicles.Add("STOCKADE3");//<!-- Securicar North Yankton variant -->
                    sVehicles.Add("TERBYTE");//
                    sVehicles.Add("TIPTRUCK");//<!-- Tipper 4-wheel variant -->
                    sVehicles.Add("TIPTRUCK2");//<!-- Tipper 6-wheel variant -->
                }       //Utility
                else if (iList == 17)
                {
                    sVehicles.Add("STRETCH");//
                    sVehicles.Add("LIMO2");//<!-- Turreted Limo -->
                    sVehicles.Add("MONSTER");//<!-- Liberator -->
                    sVehicles.Add("MARSHALL");//
                }       //Oversized
                else if (iList == 18)
                {
                    sVehicles.Add("ZR3802");//<!-- Future Shock ZR380 -->
                    sVehicles.Add("ZR3803");//<!-- Nightmare ZR380 -->
                    sVehicles.Add("ZR380");//<!-- Apocalypse ZR380 -->
                    sVehicles.Add("DOMINATOR4");//<!-- Apocalypse Dominator -->
                    sVehicles.Add("DOMINATOR5");//<!-- Future Shock Dominator -->
                    sVehicles.Add("DOMINATOR6");//<!-- Nightmare Dominator -->
                    sVehicles.Add("IMPALER2");//<!-- Apocalypse Impaler -->
                    sVehicles.Add("IMPALER3");//<!-- Future Shock Impaler -->
                    sVehicles.Add("IMPALER4");//<!-- Nightmare Impaler -->
                    sVehicles.Add("IMPERATOR");//<!-- Apocalypse Imperator -->
                    sVehicles.Add("IMPERATOR2");//<!-- Future Shock Imperator -->
                    sVehicles.Add("IMPERATOR3");//<!-- Nightmare Imperator -->
                    sVehicles.Add("SLAMVAN4");//<!-- Apocalypse Slamvan -->
                    sVehicles.Add("SLAMVAN5");//<!-- Future Shock Slamvan -->
                    sVehicles.Add("SLAMVAN6");//<!-- Nightmare Slamvan -->                
                    sVehicles.Add("BRUISER2");//<!-- Future Shock Bruiser -->
                    sVehicles.Add("BRUISER");//<!-- Apocalypse Bruiser -->
                    sVehicles.Add("BRUISER3");//<!-- Nightmare Bruiser -->
                    sVehicles.Add("BRUTUS2");//<!-- Future Shock Brutus -->
                    sVehicles.Add("BRUTUS");//<!-- Apocalypse Brutus -->
                    sVehicles.Add("BRUTUS3");//<!-- Nightmare Brutus -->
                    sVehicles.Add("MONSTER4");//<!-- Future Shock Sasquatch -->
                    sVehicles.Add("MONSTER3");//<!-- Apocalypse Sasquatch -->
                    sVehicles.Add("MONSTER5");//<!-- Nightmare Sasquatch -->                
                    sVehicles.Add("ISSI4");//<!-- Apocalypse Issi -->
                    sVehicles.Add("ISSI5");//<!-- Future Shock Issi -->
                    sVehicles.Add("ISSI6");//<!-- Nightmare Issi -->               
                    sVehicles.Add("SCARAB");//<!-- Apocalypse Scarab -->
                    sVehicles.Add("SCARAB2");//<!-- Future Shock Scarab -->
                    sVehicles.Add("SCARAB3");//<!-- Nightmare Scarab -->      
                    sVehicles.Add("CERBERUS");//<!-- Apocalypse Cerberus -->
                    sVehicles.Add("CERBERUS2");//<!-- Future Shock Cerberus -->
                    sVehicles.Add("CERBERUS3");//<!-- Nightmare Cerberus -->
                    sVehicles.Add("DEATHBIKE");//<!-- Apocalypse Deathbike -->
                    sVehicles.Add("DEATHBIKE2");//<!-- Future Shock Deathbike -->
                    sVehicles.Add("DEATHBIKE3");//<!-- Nightmare Deathbike -->
                }       //Areawars
                else if (iList == 19)
                {
                    sVehicles.Add("AKUMA");//
                    sVehicles.Add("AVARUS");//
                    sVehicles.Add("BAGGER");//
                    sVehicles.Add("BATI");//
                    sVehicles.Add("BATI2");//<!-- Bati 801RR -->
                    sVehicles.Add("BF400");//
                    sVehicles.Add("CARBONRS");//
                    sVehicles.Add("CHIMERA");//
                    sVehicles.Add("CLIFFHANGER");//
                    sVehicles.Add("DAEMON");//<!-- Daemon Lost MC variant -->
                    sVehicles.Add("DAEMON2");//<!-- Daemon Bikers DLC variant -->
                    sVehicles.Add("DEFILER");//
                    sVehicles.Add("DIABLOUS");//
                    sVehicles.Add("DIABLOUS2");//<!-- Diabolus Custom -->
                    sVehicles.Add("DOUBLE");//
                    sVehicles.Add("ENDURO");//
                    sVehicles.Add("ESSKEY");//
                    sVehicles.Add("FAGGIO2");//
                    sVehicles.Add("FAGGIO3");//<!-- Faggio Mod -->
                    sVehicles.Add("FAGGIO");//<!-- Faggio Sport -->
                    sVehicles.Add("FCR");//
                    sVehicles.Add("FCR2");//<!-- FCR 1000 Custom -->
                    sVehicles.Add("GARGOYLE");//
                    sVehicles.Add("HAKUCHOU");//
                    sVehicles.Add("HAKUCHOU2");//<!-- Hakuchou Drag -->
                    sVehicles.Add("HEXER");//
                    sVehicles.Add("INNOVATION");//
                    sVehicles.Add("LECTRO");//
                    sVehicles.Add("MANCHEZ");//
                    sVehicles.Add("MANCHEZ2");//<!-- Manchez Scout -->
                    sVehicles.Add("NEMESIS");//
                    sVehicles.Add("NIGHTBLADE");//
                    sVehicles.Add("OPPRESSOR");//
                    sVehicles.Add("OPPRESSOR2");//<!-- Oppressor Mk II -->
                    sVehicles.Add("PCJ");//
                    sVehicles.Add("RROCKET");//<!-- Rampant Rocket -->
                    sVehicles.Add("RATBIKE");//
                    sVehicles.Add("REEVER");//
                    sVehicles.Add("RUFFIAN");//
                    sVehicles.Add("SANCHEZ");//<!-- Sanchez livery variant -->
                    sVehicles.Add("SANCHEZ2");//
                    sVehicles.Add("SANCTUS");//
                    sVehicles.Add("SHINOBI");//
                    sVehicles.Add("SHOTARO");//
                    sVehicles.Add("SOVEREIGN");//
                    sVehicles.Add("STRYDER");//
                    sVehicles.Add("THRUST");//
                    sVehicles.Add("VADER");//
                    sVehicles.Add("VINDICATOR");//
                    sVehicles.Add("VORTEX");//
                    sVehicles.Add("WOLFSBANE");//
                    sVehicles.Add("ZOMBIEA");//<!-- Zombie Bobber -->
                    sVehicles.Add("ZOMBIEB");//<!-- Zombie Chopper -->
                }       //Motorcycle

                if (bAddCustom)
                {
                    if (DataStore.MyCusVeh.MyCarz.Count > 0)
                    {
                        for (int i = 0; i < DataStore.MyCusVeh.MyCarz.Count; i++)
                            sVehicles.Add(DataStore.MyCusVeh.MyCarz[i]);
                    }
                }
            }            //car
            else if (iType == 2)
            {
                sVehicles.Add("BMX");//
                sVehicles.Add("CRUISER");//
                sVehicles.Add("TRIBIKE2");//<!-- Endurex Race Bike -->
                sVehicles.Add("FIXTER");//
                sVehicles.Add("SCORCHER");//
                sVehicles.Add("TRIBIKE3");//<!-- Tri-Cycles Race Bike -->
                sVehicles.Add("TRIBIKE");//<!-- Whippet Race Bike -->
            }       //Bicycle     
            else if (iType == 3)
            {
                if (iList == 0)
                {
                    if (DataStore.MyCusVeh.MyChopperz.Count > 0)
                        sVehicles = DataStore.MyCusVeh.MyChopperz;
                    else
                        sVehicles.Add("BUZZARD");
                }            //Custom
                else if (iList == 1)
                {
                    sVehicles.Add("BUZZARD2");//<!-- Buzzard -->
                    sVehicles.Add("CARGOBOB");//<!-- Military Cargobob -->
                    sVehicles.Add("CARGOBOB2");//<!-- Jetsam Cargobob -->
                    sVehicles.Add("CARGOBOB3");//<!-- Cargobob Trevor Philips Industries variant -->
                    sVehicles.Add("FROGGER");//
                    sVehicles.Add("FROGGER2");//<!-- Frogger Trevor Philips Industries variant -->
                    sVehicles.Add("MAVERICK");//
                    sVehicles.Add("POLMAV");//
                    sVehicles.Add("SKYLIFT");//
                    sVehicles.Add("SUPERVOLITO");//
                    sVehicles.Add("SUPERVOLITO2");//<!-- SuperVolito Carbon -->
                    sVehicles.Add("SWIFT");//
                    sVehicles.Add("SWIFT2");//<!-- Swift Deluxe -->
                    sVehicles.Add("VOLATUS");//
                    sVehicles.Add("conada");//
                }       //Helli
                else
                {
                    sVehicles.Add("AKULA");//
                    sVehicles.Add("ANNIHILATOR");//
                    sVehicles.Add("ANNIHILATOR2");//<!-- Annihilator Stealth -->
                    sVehicles.Add("BUZZARD");//<!-- Buzzard Attack Chopper -->
                    sVehicles.Add("HUNTER");//<!-- FH-1 Hunter -->
                    sVehicles.Add("HAVOK");//
                    sVehicles.Add("SAVAGE");//
                    sVehicles.Add("SEASPARROW");//
                    sVehicles.Add("SEASPARROW2");//<!-- Sparrow -->
                    sVehicles.Add("VALKYRIE");//
                    sVehicles.Add("VALKYRIE2");//<!-- Valkyrie MOD.0 -->
                }       //Helli

                if (bAddCustom)
                {
                    if (DataStore.MyCusVeh.MyChopperz.Count > 0)
                    {
                        for (int i = 0; i < DataStore.MyCusVeh.MyChopperz.Count; i++)
                            sVehicles.Add(DataStore.MyCusVeh.MyChopperz[i]);
                    }
                }
            }       //heli
            else if (iType == 4)
            {
                if (iList == 0)
                {
                    if (DataStore.MyCusVeh.MyBoatz.Count > 0)
                        sVehicles = DataStore.MyCusVeh.MyBoatz;
                    else
                        sVehicles.Add("JETMAX");
                }            //Custom
                else if (iList == 1)
                {
                    sVehicles.Add("AVISA");//<!-- Kraken Avisa -->
                    sVehicles.Add("DINGHY");//
                    sVehicles.Add("DINGHY2");//<!-- Dinghy 2-seater variant -->
                    sVehicles.Add("DINGHY3");//<!-- Dinghy heist variant -->
                    sVehicles.Add("DINGHY4");//<!-- Dinghy yacht variant -->
                    sVehicles.Add("DINGHY5");//<!-- Dinghy weaponized variant -->
                    sVehicles.Add("JETMAX");//
                    sVehicles.Add("LONGFIN");//<!-- Shitzu Longfin -->
                    sVehicles.Add("SUBMERSIBLE2");//<!-- Kraken -->
                    sVehicles.Add("MARQUIS");//
                    sVehicles.Add("PREDATOR");//
                    sVehicles.Add("PATROLBOAT");//<!-- Kurtz 31 Patrol Boat -->
                    sVehicles.Add("SEASHARK");//
                    sVehicles.Add("SEASHARK2");//<!-- Lifeguard Seashark -->
                    sVehicles.Add("SEASHARK3");//<!-- Seashark yacht variant -->
                    sVehicles.Add("SPEEDER");//
                    sVehicles.Add("SPEEDER2");//<!-- Speeder yacht variant -->
                    sVehicles.Add("SQUALO");//
                    sVehicles.Add("SUBMERSIBLE");//
                    sVehicles.Add("SUNTRAP");//
                    sVehicles.Add("TORO");//
                    sVehicles.Add("TORO2");//<!-- Toro yacht variant -->
                    sVehicles.Add("TROPIC");//
                    sVehicles.Add("TROPIC2");//<!-- Tropic yacht variant -->
                    sVehicles.Add("TUG");//
                }       //Boat
                else
                {
                    sVehicles.Add("APC");//
                    sVehicles.Add("BLAZER5");//<!-- Blazer Aqua -->
                    sVehicles.Add("TECHNICAL2");//<!-- Technical Aqua -->
                    sVehicles.Add("ZHABA");//
                    sVehicles.Add("STROMBERG");//
                    sVehicles.Add("TOREADOR");//
                }
                if (bAddCustom)
                {
                    if (DataStore.MyCusVeh.MyBoatz.Count > 0)
                    {
                        for (int i = 0; i < DataStore.MyCusVeh.MyBoatz.Count; i++)
                            sVehicles.Add(DataStore.MyCusVeh.MyBoatz[i]);
                    }
                }
            }       //sea
            else
            {
                if (iList == 0)
                {
                    if (DataStore.MyCusVeh.MyPlanez.Count > 0)
                        sVehicles = DataStore.MyCusVeh.MyPlanez;
                    else
                        sVehicles.Add("duster");
                }            //Custom
                else if (iList == 1)
                {
                    sVehicles.Add("BLIMP");//<!-- Atomic Blimp -->
                    sVehicles.Add("BESRA");//
                    sVehicles.Add("BLIMP3");//
                    sVehicles.Add("CARGOPLANE");//
                    sVehicles.Add("CUBAN800");//
                    sVehicles.Add("DODO");//
                    sVehicles.Add("DUSTER");//
                    sVehicles.Add("HYDRA");//
                    sVehicles.Add("JET");//
                    sVehicles.Add("LUXOR");//
                    sVehicles.Add("LUXOR2");//<!-- Luxor Deluxe -->
                    sVehicles.Add("STUNT");//<!-- Mallard -->
                    sVehicles.Add("MAMMATUS");//
                    sVehicles.Add("MILJET");//
                    sVehicles.Add("NIMBUS");//
                    sVehicles.Add("SHAMAL");//
                    sVehicles.Add("TITAN");//
                    sVehicles.Add("VELUM");//
                    sVehicles.Add("VELUM2");//<!-- Velum 5-Seater -->
                    sVehicles.Add("VESTRA");//
                    sVehicles.Add("BLIMP2");//<!-- Xero Blimp -->
                }            //Custom
                else if (iList == 2)
                {
                    sVehicles.Add("STRIKEFORCE");//<!-- B-11 Strikeforce -->                
                    sVehicles.Add("STARLING");//<!-- LF-22 Starling -->
                    sVehicles.Add("LAZER");//<!-- P-996 LAZER -->
                    sVehicles.Add("PYRO");//
                    sVehicles.Add("ROGUE");//
                    sVehicles.Add("MOLOTOK");//<!-- V-65 Molotok -->
                }       //Plane
                else
                {
                    sVehicles.Add("ALPHAZ1");//  
                    sVehicles.Add("AVENGER");//
                    sVehicles.Add("STRIKEFORCE");//<!-- B-11 Strikeforce -->
                    sVehicles.Add("HOWARD");//<!-- Howard NX-25 -->                    
                    sVehicles.Add("STARLING");//<!-- LF-22 Starling -->
                    sVehicles.Add("MOGUL");//
                    sVehicles.Add("NOKOTA");//<!-- P-45 Nokota -->
                    sVehicles.Add("LAZER");//<!-- P-996 LAZER -->
                    sVehicles.Add("PYRO");//
                    sVehicles.Add("BOMBUSHKA");//<!-- RM-10 Bombushka -->
                    sVehicles.Add("ROGUE");//
                    sVehicles.Add("ALKONOST");//<!-- RO-86 Alkonost -->
                    sVehicles.Add("SEABREEZE");//
                    sVehicles.Add("TULA");//
                    sVehicles.Add("MICROLIGHT");//<!-- Ultralight -->
                    sVehicles.Add("MOLOTOK");//<!-- V-65 Molotok -->
                    sVehicles.Add("VOLATOL");//
                }       //Plane

                if (bAddCustom)
                {
                    if (DataStore.MyCusVeh.MyPlanez.Count > 0)
                    {
                        for (int i = 0; i < DataStore.MyCusVeh.MyPlanez.Count; i++)
                            sVehicles.Add(DataStore.MyCusVeh.MyPlanez[i]);
                    }
                }
            }                       //Plane

            return sVehicles;
        }
        public static string RanVehListX(int iVechList, int iType, bool bAddCustom)
        {
            string sCar = "";

            if (iType == 5)
            {
                List<string> MyCarz = SetRandVeh(iVechList);
                sCar = MyCarz[RandInt(0, MyCarz.Count - 1)];
            }
            else
            {
                List<string> MyCarz = VehicleListX(iVechList, iType, bAddCustom);
                sCar = MyCarz[RandInt(0, MyCarz.Count - 1)];
            }

            return sCar;
        }
        public static List<string> SetRandVeh(int iVechList)
        {
            LoggerLight.LogThis("RandVeh, iVechList == " + iVechList);

            List<string> sVehicles = new List<string>();

            if (iVechList == 1)
            {
                sVehicles.Add("KURUMA2"); //<!-- Kuruma (Armored) -->
                sVehicles.Add("DUKES2"); //<!-- Duke O'Death -->
                sVehicles.Add("LIMO2"); //<!-- Turreted Limo -->
                sVehicles.Add("CARACARA"); //
                sVehicles.Add("DUNE3"); //<!-- Dune FAV -->
                sVehicles.Add("DUNE4"); //<!-- Ramp Buggy mission variant -->
                sVehicles.Add("DUNE5"); //<!-- Ramp Buggy -->
                sVehicles.Add("INSURGENT"); //
                sVehicles.Add("INSURGENT2"); //<!-- Insurgent Pick-Up -->
                sVehicles.Add("INSURGENT3"); //<!-- Insurgent Pick-Up Custom -->
                sVehicles.Add("MARSHALL"); //
                sVehicles.Add("MONSTER"); //<!-- Liberator -->
                sVehicles.Add("MENACER"); //
                sVehicles.Add("NIGHTSHARK"); //
                sVehicles.Add("TECHNICAL"); //
                sVehicles.Add("TECHNICAL2"); //<!-- Technical Aqua -->
                sVehicles.Add("TECHNICAL3"); //<!-- Technical Custom -->
                sVehicles.Add("GUARDIAN"); //
                sVehicles.Add("MULE4"); //<!-- Mule Custom -->
                sVehicles.Add("POUNDER2"); //<!-- Pounder Custom -->
                sVehicles.Add("SPEEDO4"); //<!-- Speedo Custom -->
                sVehicles.Add("PHANTOM2"); //<!-- Phantom Wedge -->
                sVehicles.Add("STOCKADE"); //<!-- Securicar -->
                sVehicles.Add("BOXVILLE5"); //<!-- Armored Boxville -->
                sVehicles.Add("TERBYTE"); //
                sVehicles.Add("BRICKADE"); //
                sVehicles.Add("APC"); //
                sVehicles.Add("BARRAGE"); //
                sVehicles.Add("CHERNOBOG"); //
                sVehicles.Add("HALFTRACK"); //
                sVehicles.Add("RIOT2"); //<!-- RCV -->
                sVehicles.Add("VIGILANTE"); //
                sVehicles.Add("TAMPA3"); //<!-- Weaponized Tampa -->
                sVehicles.Add("RUINER2"); //<!-- Ruiner 2000 -->
                sVehicles.Add("STROMBERG"); //
                sVehicles.Add("DELUXO"); //
                sVehicles.Add("SCRAMJET"); //
                sVehicles.Add("ZR380"); //<!-- Apocalypse ZR380 -->
                sVehicles.Add("ZR3802"); //<!-- Future Shock ZR380 -->
                sVehicles.Add("ZR3803"); //<!-- Nightmare ZR380 -->
                sVehicles.Add("DOMINATOR4"); //<!-- Apocalypse Dominator -->
                sVehicles.Add("IMPALER2"); //<!-- Apocalypse Impaler -->
                sVehicles.Add("IMPERATOR"); //<!-- Apocalypse Imperator -->
                sVehicles.Add("SLAMVAN4"); //<!-- Apocalypse Slamvan -->
                sVehicles.Add("DOMINATOR5"); //<!-- Future Shock Dominator -->
                sVehicles.Add("IMPALER3"); //<!-- Future Shock Impaler -->
                sVehicles.Add("IMPERATOR2"); //<!-- Future Shock Imperator -->
                sVehicles.Add("SLAMVAN5"); //<!-- Future Shock Slamvan -->
                sVehicles.Add("DOMINATOR6"); //<!-- Nightmare Dominator -->
                sVehicles.Add("IMPALER4"); //<!-- Nightmare Impaler -->
                sVehicles.Add("IMPERATOR3"); //<!-- Nightmare Imperator -->
                sVehicles.Add("SLAMVAN6"); //<!-- Nightmare Slamvan -->
                sVehicles.Add("CERBERUS"); //<!-- Apocalypse Cerberus -->
                sVehicles.Add("CERBERUS2"); //<!-- Future Shock Cerberus -->
                sVehicles.Add("CERBERUS3"); //<!-- Nightmare Cerberus -->
                sVehicles.Add("ISSI4"); //<!-- Apocalypse Issi -->
                sVehicles.Add("ISSI5"); //<!-- Future Shock Issi -->
                sVehicles.Add("ISSI6"); //<!-- Nightmare Issi -->
                sVehicles.Add("BRUISER"); //<!-- Apocalypse Bruiser -->
                sVehicles.Add("BRUTUS"); //<!-- Apocalypse Brutus -->
                sVehicles.Add("MONSTER3"); //<!-- Apocalypse Sasquatch -->
                sVehicles.Add("BRUISER2"); //<!-- Future Shock Bruiser -->
                sVehicles.Add("BRUTUS2"); //<!-- Future Shock Brutus -->
                sVehicles.Add("MONSTER4"); //<!-- Future Shock Sasquatch -->
                sVehicles.Add("BRUISER3"); //<!-- Nightmare Bruiser -->
                sVehicles.Add("BRUTUS3"); //<!-- Nightmare Brutus -->
                sVehicles.Add("MONSTER5"); //<!-- Nightmare Sasquatch -->
                sVehicles.Add("SCARAB"); //<!-- Apocalypse Scarab -->
                sVehicles.Add("SCARAB2"); //<!-- Future Shock Scarab -->
                sVehicles.Add("SCARAB3"); //<!-- Nightmare Scarab -->
                sVehicles.Add("RHINO"); //
                sVehicles.Add("KHANJALI"); //<!-- TM-02 Khanjali -->
                sVehicles.Add("BLIMP"); //<!-- Atomic Blimp -->
                sVehicles.Add("JET"); //
                sVehicles.Add("STRIKEFORCE"); //<!-- B-11 Strikeforce -->
                sVehicles.Add("HYDRA"); //
                sVehicles.Add("STARLING"); //<!-- LF-22 Starling -->
                sVehicles.Add("LAZER"); //<!-- P-996 LAZER -->
                sVehicles.Add("PYRO"); //
                sVehicles.Add("ROGUE"); //
                sVehicles.Add("MOLOTOK"); //<!-- V-65 Molotok -->
                sVehicles.Add("alkonost"); //ROsVeh.Add("86 Alkonost -Planes
                sVehicles.Add("AKULA"); //
                sVehicles.Add("ANNIHILATOR"); //
                sVehicles.Add("BUZZARD"); //<!-- Buzzard Attack Chopper -->
                sVehicles.Add("HUNTER"); //<!-- FH-1 Hunter -->
                sVehicles.Add("SAVAGE"); //
                sVehicles.Add("VALKYRIE"); //
                sVehicles.Add("VALKYRIE2"); //<!-- Valkyrie MOD.0 -->
            }       //JohnyBrokenStuff
            else if (iVechList == 2)
            {
                sVehicles.Add("LIMO2"); //<!-- Turreted Limo -->
                sVehicles.Add("KURUMA2"); //<!-- Kuruma (Armored) -->
                sVehicles.Add("PARAGON2"); //<!-- Paragon R (Armored) -->
                sVehicles.Add("COGNOSCENTI2");//<!-- Cognoscenti (Armored) -->
                sVehicles.Add("COG552");//<!-- Cognoscenti 55 (Armored) -->
                sVehicles.Add("SCHAFTER6");//<!-- Schafter LWB (Armored) -->
                sVehicles.Add("SCHAFTER5");//<!-- Schafter V12 (Armored) -->
                sVehicles.Add("INSURGENT");//
                sVehicles.Add("INSURGENT2");//<!-- Insurgent Pick-Up -->
                sVehicles.Add("INSURGENT3");//<!-- Insurgent Pick-Up Custom -->
                sVehicles.Add("BALLER5");//<!-- Baller LE (Armored) -->
                sVehicles.Add("BALLER6");//<!-- Baller LE LWB (Armored) -->
                sVehicles.Add("XLS2");//<!-- XLS (Armored) -->
            }       //Armored
            else if (iVechList == 3)
            {
                sVehicles.Add("RHINO"); //
                sVehicles.Add("KHANJALI"); //<!-- TM-02 Khanjali -->
            }       //Tanks
            else if (iVechList == 4)
            {
                sVehicles.Add("AVARUS"); //
                sVehicles.Add("CHIMERA"); //
                sVehicles.Add("DAEMON"); //<!-- Daemon Lost MC variant -->
                sVehicles.Add("DIABLOUS"); //
                sVehicles.Add("GARGOYLE"); //
                sVehicles.Add("HEXER"); //
                sVehicles.Add("NIGHTBLADE"); //
                sVehicles.Add("WOLFSBANE"); //
                sVehicles.Add("ZOMBIEB"); //<!-- Zombie Chopper -->
                sVehicles.Add("SANCTUS"); //
                sVehicles.Add("ZOMBIEA"); //<!-- Zombie Bobber -->
            }       //LostMc
            else
            {
                sVehicles.Add("BJXL"); //
            }

            if (sVehicles.Count == 0)
                sVehicles.Add("BJXL");

            return sVehicles;
        }
        public static List<int> MaxModsRandExtras(Vehicle Vehic)
        {
            LoggerLight.LogThis("MaxModsRandExtras");
            List<int> TheseMods = new List<int>();

            bool bMotoBike = Vehic.ClassType == VehicleClass.Motorcycles;

            for (int i = 0; i < 50; i++)
            {
                int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i);

                if (i == 11 || i == 12 || i == 13 || i == 15 || i == 16)
                {
                    iSpoilher -= 1;
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher, true);
                    TheseMods.Add(iSpoilher);
                }
                else if (i == 18 || i == 22)
                {
                    iSpoilher = -1;
                    TheseMods.Add(iSpoilher);
                }
                else if (i == 24)
                {
                    iSpoilher = Function.Call<int>(Hash.GET_VEHICLE_MOD, Vehic.Handle, 23);
                    if (bMotoBike)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher, true);
                        TheseMods.Add(iSpoilher);
                    }
                    else
                        TheseMods.Add(-1);
                }
                else
                {
                    if (iSpoilher != 0)
                        iSpoilher = RandInt(0, iSpoilher - 1);

                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, RandInt(0, iSpoilher - 1), true);
                    TheseMods.Add(iSpoilher);
                }
            }
            if (Vehic.ClassType != VehicleClass.Cycles || Vehic.ClassType != VehicleClass.Helicopters || Vehic.ClassType != VehicleClass.Boats || Vehic.ClassType != VehicleClass.Planes)
            {
                Vehic.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Vehic.ToggleMod(VehicleToggleMod.Turbo, true);
            }
            return TheseMods;
        }
        public static bool WhileButtonDown(int CButt)
        {
            ObjectHand.ButtonDisabler(CButt);

            bool bButt = Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);

            if (bButt)
            {
                while (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, 0, CButt))
                    Script.Wait(1);
            }

            return bButt;
        }
        public static bool ButtonDown(int CButt)
        {
            ObjectHand.ButtonDisabler(CButt);
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static bool ButtonDownNoDis(int CButt)
        {
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static int FindRandom(int iList, int iMin, int iMax)
        {
            LoggerLight.LogThis("FindRandom, iList == " + iList);

            int iReturn;

            for (int i = DataStore.MyRands.RandNums.Count() -1; i < iList + 1; i++)
            {
                RandomInt iBlank = new RandomInt();
                DataStore.MyRands.RandNums.Add(iBlank);
            }


            if (DataStore.MyRands.RandNums[iList].RandNums.Count == 0)
            {
                for (int i = iMin; i < iMax + 1; i++)
                    DataStore.MyRands.RandNums[iList].RandNums.Add(i);
            }
            else
            {
                for (int i = 0; i < DataStore.MyRands.RandNums[iList].RandNums.Count; i++)
                {
                    if (DataStore.MyRands.RandNums[iList].RandNums[i] > iMax)
                        DataStore.MyRands.RandNums[iList].RandNums.RemoveAt(i);
                    else if (DataStore.MyRands.RandNums[iList].RandNums[i] < iMin)
                        DataStore.MyRands.RandNums[iList].RandNums.RemoveAt(i);
                }
            }

            if (iMin == iMax)
                iReturn = iMin;
            else
            {
                int iRanNum = RandInt(0, DataStore.MyRands.RandNums[iList].RandNums.Count - 1);
                iReturn = DataStore.MyRands.RandNums[iList].RandNums[iRanNum];
                DataStore.MyRands.RandNums[iList].RandNums.RemoveAt(iRanNum);
            }

            LoggerLight.LogThis("FoundRandom, iList == " + iList + "iRandom Num == " + iReturn);
            return iReturn;
        }
        public static bool PickupBling(Prop pLop)
        {
            bool bPlop = false;
            if (Game.Player.Character.Position.DistanceTo(pLop.Position) < 1.60f)
            {
                MissionData.PropList_01.Remove(pLop);
                pLop.Delete();
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                bPlop = true;
            }
            return bPlop;
        }
        public static int RandInt(int minNumber, int maxNumber)
        {
            int YouRand = 0;
            if (minNumber == maxNumber)
                YouRand = minNumber;
            else
                YouRand = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, minNumber, maxNumber);
            return YouRand;
        }
        public static float RandFlow(float minNumber, float maxNumber)
        {
            return Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, minNumber, maxNumber);
        }
        public static bool BeInRange(float fRange, float fValue_01, float fValue_02)
        {
            bool bInRange = false;

            if (fValue_01 < fValue_02 + fRange)
            {
                if (fValue_01 > fValue_02 - fRange)
                    bInRange = true;
            }

            return bInRange;
        }
        public static bool BeInAngle(float fRange, float fValue_01, float fValue_02)
        {
            bool bInRange = false;

            if (fValue_01 < fRange)
            {
                if (fValue_02 > 360.00 - fRange)
                    bInRange = true;
            }
            else if (fValue_02 < fRange)
            {
                if (fValue_01 > 360.00 - fRange)
                    bInRange = true;
            }
            else if (fValue_01 < fValue_02 + fRange)
            {
                if (fValue_01 > fValue_02 - fRange)
                    bInRange = true;
            }

            return bInRange;
        }
        public static string ShowComs(int iNumber, bool bMoney, bool bHalfSecs)
        {
            string sThis = "";

            if (bMoney)
            {
                int iTrashed = iNumber;
                int imill = 0;
                int iThou = 0;
                int irest = 0;
                string sZero1 = "";
                string sZero2 = "";
                string sDone = "";
                if (iTrashed < 1000)
                {
                    irest = iTrashed;
                    sDone = "" + irest;
                }
                else if (iTrashed < 1000000)
                {
                    iThou = iTrashed / 1000;
                    irest = iTrashed - (iThou * 1000);
                    if (irest < 10)
                        sDone = "" + iThou + ",00" + irest;
                    else if (irest < 100)
                        sDone = "" + iThou + ",0" + irest;
                    else
                        sDone = "" + iThou + "," + irest;
                }
                else
                {

                    imill = iTrashed / 1000000;

                    iThou = iTrashed - (imill * 1000000);
                    iThou = iThou / 1000;

                    irest = iTrashed - (imill * 1000000);
                    irest = irest - (iThou * 1000);

                    if (iThou < 10)
                        sZero1 = "00";
                    else if (iThou < 100)
                        sZero1 = "0";
                    else
                        sZero1 = "";

                    if (irest < 10)
                        sZero2 = "00";
                    else if (irest < 100)
                        sZero2 = "0";
                    else
                        sZero2 = "";
                    sDone = "" + imill + "," + sZero1 + iThou + "," + sZero2 + irest;
                }

                sThis = sDone;
            }
            else
            {
                int iLapMin = iNumber;
                int iLapSec = iNumber;
                int iLapHse = iNumber;
                string Zero_01 = "";
                string Zero_02 = "";
                string Zero_03 = "";

                iLapMin = iNumber / 60000;
                if (iLapMin < 0)
                    iLapMin = 0;
                else
                {
                    iLapSec = iNumber - (iLapMin * 60000);
                    iLapHse = iNumber - (iLapMin * 60000);
                }
                iLapSec = iLapSec / 1000;
                if (iLapSec < 0)
                    iLapSec = 0;
                else
                    iLapHse = iLapHse - (iLapSec * 1000);
                iLapHse = iLapHse / 10;
                if (iLapHse < 0)
                    iLapHse = 0;

                if (iLapMin < 10)
                    Zero_01 = "0";
                else
                    Zero_01 = "";

                if (iLapSec < 10)
                    Zero_02 = "0";
                else
                    Zero_02 = "";

                if (iLapHse < 10)
                    Zero_03 = "0";
                else
                    Zero_03 = "";

                if (bHalfSecs)
                    sThis = "" + Zero_01 + iLapMin + ":" + Zero_02 + iLapSec + ":" + Zero_03 + iLapHse + "";
                else
                    sThis = "" + Zero_01 + "" + iLapMin + ":" + Zero_02 + "" + iLapSec + "";
            }

            return sThis;
        }
        public static string GetEntName(string MyEnt)
        {
            string VehName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, Function.Call<int>(Hash.GET_HASH_KEY, MyEnt));
            if (Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, VehName))
                VehName = Function.Call<string>(Hash._GET_LABEL_TEXT, VehName);
            else
                VehName = "";

            return VehName;
        }
        public static string GetEntNameHash(int iHash)
        {
            LoggerLight.LogThis("GetEntNameHash");
            string VehName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, iHash);
            if (Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, VehName))
                VehName = Function.Call<string>(Hash._GET_LABEL_TEXT, VehName);
            else
                VehName = "";

            return VehName;
        }
        public static bool BeRightOnTime(int iMin, int iMax)
        {
            bool bRight = false;
            int iTime = Function.Call<int>(Hash.GET_CLOCK_HOURS);

            if (iTime >= iMin)
            {
                if (iTime < iMax)
                    bRight = true;
            }

            return bRight;
        }
        public static int NSPMCoin(int iGet)
        {
            int iCash;
            int iStat = 0;
            if (Game.Player.Character.Model == PedHash.Franklin)
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP1_TOTAL_CASH");
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP2_TOTAL_CASH");
            else
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP0_TOTAL_CASH");

            unsafe
            {
                Function.Call<bool>(Hash.STAT_GET_INT, iStat, &iCash, -1);
            }


            if (iGet != 0)
            {
                iCash += iGet;
                Function.Call<bool>(Hash.STAT_SET_INT, iStat, iCash, true);
            }
            return iCash;
        }
        public static List<string> WeapsList()
        {
            List<string> sWeapList = new List<string>
            {
                "WEAPON_dagger",  //0x92A27487",
                "WEAPON_bat",  //0x958A4A8F",
                "WEAPON_bottle",  //0xF9E6AA4B",
                "WEAPON_crowbar",  //0x84BD7BFD",
                "WEAPON_unarmed",  //0xA2719263",
                "WEAPON_flashlight",  //0x8BB05FD7",
                "WEAPON_golfclub",  //0x440E4788",
                "WEAPON_hammer",  //0x4E875F73",
                "WEAPON_hatchet",  //0xF9DCBF2D",
                "WEAPON_knuckle",  //0xD8DF3C3C",
                "WEAPON_knife",  //0x99B507EA",
                "WEAPON_machete",  //0xDD5DF8D9",
                "WEAPON_switchblade",  //0xDFE37640",
                "WEAPON_nightstick",  //0x678B81B1",
                "WEAPON_wrench",  //0x19044EE0",
                "WEAPON_battleaxe",  //0xCD274149",
                "WEAPON_poolcue",  //0x94117305",
                "WEAPON_stone_hatchet",  //0x3813FC08"--17

                "WEAPON_pistol",  //0x1B06D571",
                "WEAPON_pistol_mk2",  //0xBFE256D4",---------19
                "WEAPON_combatpistol",  //0x5EF9FEC4",
                "WEAPON_appistol",  //0x22D8FE39",
                "WEAPON_pistol50",  //0x99AEEB3B",
                "WEAPON_snspistol",  //0xBFD21232",
                "WEAPON_snspistol_mk2",  //0x88374054",---24
                "WEAPON_heavypistol",  //0xD205520E",
                "WEAPON_vintagepistol",  //0x83839C4",
                "WEAPON_marksmanpistol",  //0xDC4DB296",
                "WEAPON_revolver",  //0xC1B3C3D1",
                "WEAPON_revolver_mk2",  //0xCB96392F",----29
                "WEAPON_doubleaction",  //0x97EA20B8",
                "WEAPON_ceramicpistol",  //0x2B5EF5EC",
                "WEAPON_navyrevolver",  //0x917F6C8C"
                "WEAPON_GADGETPISTOL",  //0xAF3696A1",
                "WEAPON_stungun",  //0x3656C8C1",
                "WEAPON_flaregun",  //0x47757124",
                "WEAPON_raypistol",  //0xAF3696A1",--36

                "WEAPON_microsmg",  //0x13532244",
                "WEAPON_smg",  //0x2BE6766B",
                "WEAPON_smg_mk2",  //0x78A97CD0",-----39
                "WEAPON_assaultsmg",  //0xEFE7E2DF",
                "WEAPON_combatpdw",  //0xA3D4D34",
                "WEAPON_machinepistol",  //0xDB1AA450",
                "WEAPON_minismg",  //0xBD248B55",
                "WEAPON_raycarbine",  //0x476BF155"--44

                "WEAPON_pumpshotgun",  //0x1D073A89",
                "WEAPON_pumpshotgun_mk2",  //0x555AF99A",-----------46
                "WEAPON_sawnoffshotgun",  //0x7846A318",
                "WEAPON_assaultshotgun",  //0xE284C527",
                "WEAPON_bullpupshotgun",  //0x9D61E50F",
                "WEAPON_musket",  //0xA89CB99E",
                "WEAPON_heavyshotgun",  //0x3AABBBAA",
                "WEAPON_dbshotgun",  //0xEF951FBB",
                "WEAPON_autoshotgun",  //0x12E82D3D"--53
                "WEAPON_COMBATSHOTGUN",  //0x5A96BA4--54

                "WEAPON_assaultrifle",  //0xBFEFFF6D",
                "WEAPON_assaultrifle_mk2",  //0x394F415C",-------56
                "WEAPON_carbinerifle",  //0x83BF0278",
                "WEAPON_carbinerifle_mk2",  //0xFAD1F1C9",------58
                "WEAPON_advancedrifle",  //0xAF113F99",
                "WEAPON_specialcarbine",  //0xC0A3098D",
                "WEAPON_specialcarbine_mk2",  //0x969C3D67",------61
                "WEAPON_bullpuprifle",  //0x7F229F94",
                "WEAPON_bullpuprifle_mk2",  //0x84D6FAFD",----63
                "WEAPON_compactrifle",  //0x624FE830"--64
                "WEAPON_MILITARYRIFLE",  //0x624FE830"--65

                "WEAPON_mg",  //0x9D07F764",
                "WEAPON_combatmg",  //0x7FD62962",
                "WEAPON_combatmg_mk2",  //0xDBBD7280",------68
                "WEAPON_gusenberg",  //0x61012683"--69

                "WEAPON_sniperrifle",  //0x5FC3C11",
                "WEAPON_heavysniper",  //0xC472FE2",
                "WEAPON_heavysniper_mk2",  //0xA914799",---72
                "WEAPON_marksmanrifle",  //0xC734385A",
                "WEAPON_marksmanrifle_mk2",  //0x6A6C02E0"--74

                "WEAPON_rpg",  //0xB1CA77B1",
                "WEAPON_grenadelauncher",  //0xA284510B",
                "WEAPON_grenadelauncher_smoke",  //0x4DD2DC56",
                "WEAPON_minigun",  //0x42BF8A85",
                "WEAPON_firework",  //0x7F7497E5",
                "WEAPON_railgun",  //0x6D544C99",
                "WEAPON_hominglauncher",  //0x63AB0442",
                "WEAPON_compactlauncher",  //0x781FE4A",
                "WEAPON_rayminigun",  //0xB62D1F67"--83

                "WEAPON_grenade",  //0x93E220BD",
                "WEAPON_bzgas",  //0xA0973D5E",
                "WEAPON_smokegrenade",  //0xFDBC8A50",
                "WEAPON_flare",  //0x497FACC3",
                "WEAPON_molotov",  //0x24B17070",
                "WEAPON_stickybomb",  //0x2C3731D9",
                "WEAPON_proxmine",  //0xAB564B93",
                "WEAPON_snowball",  //0x787F0BB",
                "WEAPON_pipebomb",  //0xBA45E8B8",
                "WEAPON_ball",  //0x23C9F95C"--93

                "WEAPON_petrolcan",  //0x34A67B97",
                "WEAPON_fireextinguisher",  //0x60EC506",
                "WEAPON_parachute",  //0xFBAB5776",
                "WEAPON_hazardcan",  //0xBA536372"--97

                "WEAPON_EMPLAUNCHER",  // 0xDB26713A--98

                "WEAPON_HEAVYRIFLE",  //0xC78D71B4 --99

                "WEAPON_FERTILIZERCAN",//100

                "WEAPON_STUNGUN_MP",//101

                "WEAPON_METALDETECTOR",

                "WEAPON_PRECISIONRIFLE", //| 0x6E7DDDEC

                "WEAPON_TACTICALRIFLE" //| 0xD1D5F52B
            };

            return sWeapList;
        }
        public static List<string> WeapAddonsList()
        {
            List<string> sAddsList = new List<string>
            {
                "COMPONENT_ADVANCEDRIFLE_CLIP_01",//0xFA8FA10F,
                "COMPONENT_ADVANCEDRIFLE_CLIP_02",//0x8EC1C979,
                "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE",//0x377CD377,
                "COMPONENT_APPISTOL_CLIP_01",//0x31C4B22A,
                "COMPONENT_APPISTOL_CLIP_02",//0x249A17D5,
                "COMPONENT_APPISTOL_VARMOD_LUXE",//0x9B76C72C,
                "COMPONENT_ASSAULTRIFLE_CLIP_01",//0xBE5EEA16,
                "COMPONENT_ASSAULTRIFLE_CLIP_02",//0xB1214F9B,
                "COMPONENT_ASSAULTRIFLE_CLIP_03",//0xDBF0A53D,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO",//0x911B24AF,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02",//0x37E5444B,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03",//0x538B7B97,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04",//0x25789F72,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05",//0xC5495F2D,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06",//0xCF8B73B1,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07",//0xA9BB2811,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08",//0xFC674D54,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09",//0x7C7FCD9B,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10",//0xA5C38392,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01",//0xB9B15DB0,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01",//0x8610343F,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02",//0xD12ACA6F,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING",//0xA7DD1E58,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ",//0x63E0A098,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY",//0xFB70D853,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER",//0xEF2C78C1,
                "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE",//0x4EAD7533,
                "COMPONENT_ASSAULTSHOTGUN_CLIP_01",//0x94E81BC7,
                "COMPONENT_ASSAULTSHOTGUN_CLIP_02",//0x86BD7F72,
                "COMPONENT_ASSAULTSMG_CLIP_01",//0x8D1307B0,
                "COMPONENT_ASSAULTSMG_CLIP_02",//0xBB46E417,
                "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER",//0x278C78AF,
                "COMPONENT_AT_AR_AFGRIP",//0xC164F53,
                "COMPONENT_AT_AR_AFGRIP_02",//0x9D65907A,
                "COMPONENT_AT_AR_BARREL_01",//0x43A49D26,
                "COMPONENT_AT_AR_BARREL_02",//0x5646C26A,
                "COMPONENT_AT_AR_FLSH",//0x7BC4CDDC,
                "COMPONENT_AT_AR_SUPP",//0x837445AA,
                "COMPONENT_AT_AR_SUPP_02",//0xA73D4664,
                "COMPONENT_AT_BP_BARREL_01",//0x659AC11B,
                "COMPONENT_AT_BP_BARREL_02",//0x3BF26DC7,
                "COMPONENT_AT_CR_BARREL_01",//0x833637FF,
                "COMPONENT_AT_CR_BARREL_02",//0x8B3C480B,
                "COMPONENT_AT_MG_BARREL_01",//0xC34EF234,
                "COMPONENT_AT_MG_BARREL_02",//0xB5E2575B,
                "COMPONENT_AT_MRFL_BARREL_01",//0x381B5D89,
                "COMPONENT_AT_MRFL_BARREL_02",//0x68373DDC,
                "COMPONENT_AT_MUZZLE_01",//0xB99402D4,
                "COMPONENT_AT_MUZZLE_02",//0xC867A07B,
                "COMPONENT_AT_MUZZLE_03",//0xDE11CBCF,
                "COMPONENT_AT_MUZZLE_04",//0xEC9068CC,
                "COMPONENT_AT_MUZZLE_05",//0x2E7957A,
                "COMPONENT_AT_MUZZLE_06",//0x347EF8AC,
                "COMPONENT_AT_MUZZLE_07",//0x4DB62ABE,
                "COMPONENT_AT_MUZZLE_08",//0x5F7DCE4D,
                "COMPONENT_AT_MUZZLE_09",//0x6927E1A1,
                "COMPONENT_AT_PI_COMP",//0x21E34793,
                "COMPONENT_AT_PI_COMP_02",//0xAA8283BF,
                "COMPONENT_AT_PI_COMP_03",//0x27077CCB,
                "COMPONENT_AT_PI_FLSH",//0x359B7AAE,
                "COMPONENT_AT_PI_FLSH_02",//0x43FD595B,
                "COMPONENT_AT_PI_FLSH_03",//0x4A4965F3,
                "COMPONENT_AT_PI_RAIL",//0x8ED4BB70,
                "COMPONENT_AT_PI_RAIL_02",//0x47DE9258,
                "COMPONENT_AT_PI_SUPP",//0xC304849A,
                "COMPONENT_AT_PI_SUPP_02",//0x65EA7EBB,
                "COMPONENT_AT_SB_BARREL_01",//0xD9103EE1,
                "COMPONENT_AT_SB_BARREL_02",//0xA564D78B,
                "COMPONENT_AT_SCOPE_LARGE",//0xD2443DDC,
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM",//0x1C221B1A,
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2",//0x5B1C713C,
                "COMPONENT_AT_SCOPE_LARGE_MK2",//0x82C10383,
                "COMPONENT_AT_SCOPE_MACRO",//0x9D2FBF29,
                "COMPONENT_AT_SCOPE_MACRO_02",//0x3CC6BA57,
                "COMPONENT_AT_SCOPE_MACRO_02_MK2",//0xC7ADD105,
                "COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2",//0xE502AB6B,
                "COMPONENT_AT_SCOPE_MACRO_MK2",//0x49B2945,
                "COMPONENT_AT_SCOPE_MAX",//0xBC54DA77,
                "COMPONENT_AT_SCOPE_MEDIUM",//0xA0D89C42,
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",//0xC66B6542,
                "COMPONENT_AT_SCOPE_NV",//0xB68010B0,
                "COMPONENT_AT_SCOPE_SMALL",//0xAA2C45B4,
                "COMPONENT_AT_SCOPE_SMALL_02",//0x3C00AFED,
                "COMPONENT_AT_SCOPE_SMALL_MK2",//0x3F3C8181,
                "COMPONENT_AT_SCOPE_SMALL_SMG_MK2",//0x3DECC7DA,
                "COMPONENT_AT_SCOPE_THERMAL",//0x2E43DA41,
                "COMPONENT_AT_SC_BARREL_01",//0xE73653A9,
                "COMPONENT_AT_SC_BARREL_02",//0xF97F783B,
                "COMPONENT_AT_SIGHTS",//0x420FD713,
                "COMPONENT_AT_SIGHTS_SMG",//0x9FDB5652,
                "COMPONENT_AT_SR_BARREL_01",//0x909630B7,
                "COMPONENT_AT_SR_BARREL_02",//0x108AB09E,
                "COMPONENT_AT_SR_SUPP",//0xE608B35E,
                "COMPONENT_AT_SR_SUPP_03",//0xAC42DF71,
                "COMPONENT_BULLPUPRIFLE_CLIP_01",//0xC5A12F80,
                "COMPONENT_BULLPUPRIFLE_CLIP_02",//0xB3688B0F,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO",//0xAE4055B7,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02",//0xB905ED6B,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03",//0xA6C448E8,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04",//0x9486246C,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05",//0x8A390FD2,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06",//0x2337FC5,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07",//0xEFFFDB5E,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08",//0xDDBDB6DA,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09",//0xCB631225,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10",//0xA87D541E,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01",//0xC5E9AE52,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_01",//0x18929DA,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02",//0xEFB00628,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING",//0xFAA7F5ED,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ",//0x43621710,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY",//0xA99CF95A,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER",//0x822060A9,
                "COMPONENT_BULLPUPRIFLE_VARMOD_LOW",//0xA857BC78,
                "COMPONENT_CARBINERIFLE_CLIP_01",//0x9FBE33EC,
                "COMPONENT_CARBINERIFLE_CLIP_02",//0x91109691,
                "COMPONENT_CARBINERIFLE_CLIP_03",//0xBA62E935,
                "COMPONENT_CARBINERIFLE_MK2_CAMO",//0x4BDD6F16,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_02",//0x406A7908,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_03",//0x2F3856A4,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_04",//0xE50C424D,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_05",//0xD37D1F2F,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_06",//0x86268483,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_07",//0xF420E076,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_08",//0xAAE14DF8,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_09",//0x9893A95D,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_10",//0x6B13CD3E,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01",//0xDA55CD3F,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_01",//0x4C7A391E,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_02",//0x5DD5DBD5,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING",//0x255D5D57,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ",//0x44032F11,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY",//0x3D25C2A7,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER",//0x1757F566,
                "COMPONENT_CARBINERIFLE_VARMOD_LUXE",//0xD89B9658,
                "COMPONENT_COMBATMG_CLIP_01",//0xE1FFB34A,
                "COMPONENT_COMBATMG_CLIP_02",//0xD6C59CD6,
                "COMPONENT_COMBATMG_MK2_CAMO",//0x4A768CB5,
                "COMPONENT_COMBATMG_MK2_CAMO_02",//0xCCE06BBD,
                "COMPONENT_COMBATMG_MK2_CAMO_03",//0xBE94CF26,
                "COMPONENT_COMBATMG_MK2_CAMO_04",//0x7609BE11,
                "COMPONENT_COMBATMG_MK2_CAMO_05",//0x48AF6351,
                "COMPONENT_COMBATMG_MK2_CAMO_06",//0x9186750A,
                "COMPONENT_COMBATMG_MK2_CAMO_07",//0x84555AA8,
                "COMPONENT_COMBATMG_MK2_CAMO_08",//0x1B4C088B,
                "COMPONENT_COMBATMG_MK2_CAMO_09",//0xE046DFC,
                "COMPONENT_COMBATMG_MK2_CAMO_10",//0x28B536E,
                "COMPONENT_COMBATMG_MK2_CAMO_IND_01",//0xD703C94D,
                "COMPONENT_COMBATMG_MK2_CLIP_01",//0x492B257C,
                "COMPONENT_COMBATMG_MK2_CLIP_02",//0x17DF42E9,
                "COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING",//0x29882423,
                "COMPONENT_COMBATMG_MK2_CLIP_FMJ",//0x57EF1CC8,
                "COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY",//0xC326BDBA,
                "COMPONENT_COMBATMG_MK2_CLIP_TRACER",//0xF6649745,
                "COMPONENT_COMBATMG_VARMOD_LOWRIDER",//0x92FECCDD,
                "COMPONENT_COMBATPDW_CLIP_01",//0x4317F19E,
                "COMPONENT_COMBATPDW_CLIP_02",//0x334A5203,
                "COMPONENT_COMBATPDW_CLIP_03",//0x6EB8C8DB,
                "COMPONENT_COMBATPISTOL_CLIP_01",//0x721B079,
                "COMPONENT_COMBATPISTOL_CLIP_02",//0xD67B4F2D,
                "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER",//0xC6654D72,
                "COMPONENT_COMPACTRIFLE_CLIP_01",//0x513F0A63,
                "COMPONENT_COMPACTRIFLE_CLIP_02",//0x59FF9BF8,
                "COMPONENT_COMPACTRIFLE_CLIP_03",//0xC607740E,
                "COMPONENT_GRENADELAUNCHER_CLIP_01",//0x11AE5C97,
                "COMPONENT_GUSENBERG_CLIP_01",//0x1CE5A6A5,
                "COMPONENT_GUSENBERG_CLIP_02",//0xEAC8C270,
                "COMPONENT_HEAVYPISTOL_CLIP_01",//0xD4A969A,
                "COMPONENT_HEAVYPISTOL_CLIP_02",//0x64F9C62B,
                "COMPONENT_HEAVYPISTOL_VARMOD_LUXE",//0x7A6A7B7B,
                "COMPONENT_HEAVYSHOTGUN_CLIP_01",//0x324F2D5F,
                "COMPONENT_HEAVYSHOTGUN_CLIP_02",//0x971CF6FD,
                "COMPONENT_HEAVYSHOTGUN_CLIP_03",//0x88C7DA53,
                "COMPONENT_HEAVYSNIPER_CLIP_01",//0x476F52F4,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO",//0xF8337D02,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_02",//0xC5BEDD65,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_03",//0xE9712475,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_04",//0x13AA78E7,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_05",//0x26591E50,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_06",//0x302731EC,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_07",//0xAC722A78,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_08",//0xBEA4CEDD,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_09",//0xCD776C82,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_10",//0xABC5ACC7,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01",//0x6C32D2EB,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_01",//0xFA1E1A28,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_02",//0x2CD8FF9D,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING",//0xF835D6D4,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE",//0x89EBDAA7,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ",//0x3BE948F6,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY",//0xEC0F617,
                "COMPONENT_KNUCKLE_VARMOD_BALLAS",//0xEED9FD63,
                "COMPONENT_KNUCKLE_VARMOD_BASE",//0xF3462F33,
                "COMPONENT_KNUCKLE_VARMOD_DIAMOND",//0x9761D9DC,
                "COMPONENT_KNUCKLE_VARMOD_DOLLAR",//0x50910C31,
                "COMPONENT_KNUCKLE_VARMOD_HATE",//0x7DECFE30,
                "COMPONENT_KNUCKLE_VARMOD_KING",//0xE28BABEF,
                "COMPONENT_KNUCKLE_VARMOD_LOVE",//0x3F4E8AA6,
                "COMPONENT_KNUCKLE_VARMOD_PIMP",//0xC613F685,
                "COMPONENT_KNUCKLE_VARMOD_PLAYER",//0x8B808BB,
                "COMPONENT_KNUCKLE_VARMOD_VAGOS",//0x7AF3F785,
                "COMPONENT_MACHINEPISTOL_CLIP_01",//0x476E85FF,
                "COMPONENT_MACHINEPISTOL_CLIP_02",//0xB92C6979,
                "COMPONENT_MACHINEPISTOL_CLIP_03",//0xA9E9CAF4,
                "COMPONENT_MARKSMANRIFLE_CLIP_01",//0xD83B4141,
                "COMPONENT_MARKSMANRIFLE_CLIP_02",//0xCCFD2AC5,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO",//0x9094FBA0,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02",//0x7320F4B2,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03",//0x60CF500F,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04",//0xFE668B3F,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05",//0xF3757559,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06",//0x193B40E8,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07",//0x107D2F6C,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08",//0xC4E91841,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09",//0x9BB1C5D3,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10",//0x3B61040B,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01",//0xB7A316DA,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_01",//0x94E12DCE,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_02",//0xE6CFD1AA,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING",//0xF46FD079,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ",//0xE14A9ED3,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY",//0x6DD7A86E,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER",//0xD77A22D2,
                "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE",//0x161E9241,
                "COMPONENT_MG_CLIP_01",//0xF434EF84,
                "COMPONENT_MG_CLIP_02",//0x82158B47,
                "COMPONENT_MG_VARMOD_LOWRIDER",//0xD6DABABE,
                "COMPONENT_MICROSMG_CLIP_01",//0xCB48AEF0,
                "COMPONENT_MICROSMG_CLIP_02",//0x10E6BA2B,
                "COMPONENT_MICROSMG_VARMOD_LUXE",//0x487AAE09,
                "COMPONENT_MINISMG_CLIP_01",//0x84C8B2D3,
                "COMPONENT_MINISMG_CLIP_02",//0x937ED0B7,
                "COMPONENT_PISTOL50_CLIP_01",//0x2297BE19,
                "COMPONENT_PISTOL50_CLIP_02",//0xD9D3AC92,
                "COMPONENT_PISTOL50_VARMOD_LUXE",//0x77B8AB2F,
                "COMPONENT_PISTOL_CLIP_01",//0xFED0FD71,
                "COMPONENT_PISTOL_CLIP_02",//0xED265A1C,
                "COMPONENT_PISTOL_MK2_CAMO",//0x5C6C749C,
                "COMPONENT_PISTOL_MK2_CAMO_02",//0x15F7A390,
                "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE",//0x1A1F1260,
                "COMPONENT_PISTOL_MK2_CAMO_03",//0x968E24DB,
                "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE",//0xE4E00B70,
                "COMPONENT_PISTOL_MK2_CAMO_04",//0x17BFA99,
                "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE",//0x2C298B2B,
                "COMPONENT_PISTOL_MK2_CAMO_05",//0xF2685C72,
                "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE",//0xDFB79725,
                "COMPONENT_PISTOL_MK2_CAMO_06",//0xDD2231E6,
                "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE",//0x6BD7228C,
                "COMPONENT_PISTOL_MK2_CAMO_07",//0xBB43EE76,
                "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE",//0x9DDBCF8C,
                "COMPONENT_PISTOL_MK2_CAMO_08",//0x4D901310,
                "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE",//0xB319A52C,
                "COMPONENT_PISTOL_MK2_CAMO_09",//0x5F31B653,
                "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE",//0xC6836E12,
                "COMPONENT_PISTOL_MK2_CAMO_10",//0x697E19A0,
                "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE",//0x43B1B173,
                "COMPONENT_PISTOL_MK2_CAMO_IND_01",//0x930CB951,
                "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE",//0x4ABDA3FA,
                "COMPONENT_PISTOL_MK2_CAMO_SLIDE",//0xB4FC92B0,
                "COMPONENT_PISTOL_MK2_CLIP_01",//0x94F42D62,
                "COMPONENT_PISTOL_MK2_CLIP_02",//0x5ED6C128,
                "COMPONENT_PISTOL_MK2_CLIP_FMJ",//0x4F37DF2A,
                "COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT",//0x85FEA109,
                "COMPONENT_PISTOL_MK2_CLIP_INCENDIARY",//0x2BBD7A3A,
                "COMPONENT_PISTOL_MK2_CLIP_TRACER",//0x25CAAEAF,
                "COMPONENT_PISTOL_VARMOD_LUXE",//0xD7391086,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO",//0xE3BD9E44,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02",//0x17148F9B,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03",//0x24D22B16,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04",//0xF2BEC6F0,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05",//0x85627D,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06",//0xDC2919C5,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07",//0xE184247B,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08",//0xD8EF9356,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09",//0xEF29BFCA,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10",//0x67AEB165,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01",//0x46411A1D,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01",//0xCD940141,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING",//0x4E65B425,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE",//0x3BE4465D,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT",//0xE9582927,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY",//0x9F8A1BF5,
                "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER",//0xA2D79DDB,
                "COMPONENT_REVOLVER_CLIP_01",//0xE9867CE3,
                "COMPONENT_REVOLVER_MK2_CAMO",//0xC03FED9F,
                "COMPONENT_REVOLVER_MK2_CAMO_02",//0xB5DE24,
                "COMPONENT_REVOLVER_MK2_CAMO_03",//0xA7FF1B8,
                "COMPONENT_REVOLVER_MK2_CAMO_04",//0xF2E24289,
                "COMPONENT_REVOLVER_MK2_CAMO_05",//0x11317F27,
                "COMPONENT_REVOLVER_MK2_CAMO_06",//0x17C30C42,
                "COMPONENT_REVOLVER_MK2_CAMO_07",//0x257927AE,
                "COMPONENT_REVOLVER_MK2_CAMO_08",//0x37304B1C,
                "COMPONENT_REVOLVER_MK2_CAMO_09",//0x48DAEE71,
                "COMPONENT_REVOLVER_MK2_CAMO_10",//0x20ED9B5B,
                "COMPONENT_REVOLVER_MK2_CAMO_IND_01",//0xD951E867,
                "COMPONENT_REVOLVER_MK2_CLIP_01",//0xBA23D8BE,
                "COMPONENT_REVOLVER_MK2_CLIP_FMJ",//0xDC8BA3F,
                "COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT",//0x10F42E8F,
                "COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY",//0xEFBF25,
                "COMPONENT_REVOLVER_MK2_CLIP_TRACER",//0xC6D8E476,
                "COMPONENT_REVOLVER_VARMOD_BOSS",//0x16EE3040,
                "COMPONENT_REVOLVER_VARMOD_GOON",//0x9493B80D,
                "COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE",//0x85A64DF9,
                "COMPONENT_SMG_CLIP_01",//0x26574997,
                "COMPONENT_SMG_CLIP_02",//0x350966FB,
                "COMPONENT_SMG_CLIP_03",//0x79C77076,
                "COMPONENT_SMG_MK2_CAMO",//0xC4979067,
                "COMPONENT_SMG_MK2_CAMO_02",//0x3815A945,
                "COMPONENT_SMG_MK2_CAMO_03",//0x4B4B4FB0,
                "COMPONENT_SMG_MK2_CAMO_04",//0xEC729200,
                "COMPONENT_SMG_MK2_CAMO_05",//0x48F64B22,
                "COMPONENT_SMG_MK2_CAMO_06",//0x35992468,
                "COMPONENT_SMG_MK2_CAMO_07",//0x24B782A5,
                "COMPONENT_SMG_MK2_CAMO_08",//0xA2E67F01,
                "COMPONENT_SMG_MK2_CAMO_09",//0x2218FD68,
                "COMPONENT_SMG_MK2_CAMO_10",//0x45C5C3C5,
                "COMPONENT_SMG_MK2_CAMO_IND_01",//0x399D558F,
                "COMPONENT_SMG_MK2_CLIP_01",//0x4C24806E,
                "COMPONENT_SMG_MK2_CLIP_02",//0xB9835B2E,
                "COMPONENT_SMG_MK2_CLIP_FMJ",//0xB5A715F,
                "COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT",//0x3A1BD6FA,
                "COMPONENT_SMG_MK2_CLIP_INCENDIARY",//0xD99222E5,
                "COMPONENT_SMG_MK2_CLIP_TRACER",//0x7FEA36EC,
                "COMPONENT_SMG_VARMOD_LUXE",//0x27872C90,
                "COMPONENT_SNIPERRIFLE_CLIP_01",//0x9BC64089,
                "COMPONENT_SNIPERRIFLE_VARMOD_LUXE",//0x4032B5E7,
                "COMPONENT_SNSPISTOL_CLIP_01",//0xF8802ED9,
                "COMPONENT_SNSPISTOL_CLIP_02",//0x7B0033B3,
                "COMPONENT_SNSPISTOL_MK2_CAMO",//0xF7BEEDD,
                "COMPONENT_SNSPISTOL_MK2_CAMO_02",//0x8A612EF6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE",//0x29366D21,
                "COMPONENT_SNSPISTOL_MK2_CAMO_03",//0x76FA8829,
                "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE",//0x3ADE514B,
                "COMPONENT_SNSPISTOL_MK2_CAMO_04",//0xA93C6CAC,
                "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE",//0xE64513E9,
                "COMPONENT_SNSPISTOL_MK2_CAMO_05",//0x9C905354,
                "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE",//0xCD7AEB9A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_06",//0x4DFA3621,
                "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE",//0xFA7B27A6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_07",//0x42E91FFF,
                "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE",//0xE285CA9A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_08",//0x54A8437D,
                "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE",//0x2B904B19,
                "COMPONENT_SNSPISTOL_MK2_CAMO_09",//0x68C2746,
                "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE",//0x22C24F9C,
                "COMPONENT_SNSPISTOL_MK2_CAMO_10",//0x2366E467,
                "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE",//0x8D0D5ECD,
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01",//0x441882E6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE",//0x1F07150A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE",//0xE7EE68EA,
                "COMPONENT_SNSPISTOL_MK2_CLIP_01",//0x1466CE6,
                "COMPONENT_SNSPISTOL_MK2_CLIP_02",//0xCE8C0772,
                "COMPONENT_SNSPISTOL_MK2_CLIP_FMJ",//0xC111EB26,
                "COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT",//0x8D107402,
                "COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY",//0xE6AD5F79,
                "COMPONENT_SNSPISTOL_MK2_CLIP_TRACER",//0x902DA26E,
                "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER",//0x8033ECAF,
                "COMPONENT_SPECIALCARBINE_CLIP_01",//0xC6C7E581,
                "COMPONENT_SPECIALCARBINE_CLIP_02",//0x7C8BD10E,
                "COMPONENT_SPECIALCARBINE_CLIP_03",//0x6B59AEAA,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO",//0xD40BB53B,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_02",//0x431B238B,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_03",//0x34CF86F4,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_04",//0xB4C306DD,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_05",//0xEE677A25,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_06",//0xDF90DC78,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_07",//0xA4C31EE,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_08",//0x89CFB0F7,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_09",//0x7B82145C,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_10",//0x899CAF75,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01",//0x5218C819,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_01",//0x16C69281,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_02",//0xDE1FA12C,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING",//0x51351635,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ",//0x503DEA90,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY",//0xDE011286,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER",//0x8765C68A,
                "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER",//0x730154F2,
                "COMPONENT_SWITCHBLADE_VARMOD_BASE",//0x9137A500,
                "COMPONENT_SWITCHBLADE_VARMOD_VAR1",//0x5B3E7DB6,
                "COMPONENT_SWITCHBLADE_VARMOD_VAR2",//0xE7939662,
                "COMPONENT_VINTAGEPISTOL_CLIP_01",//0x45A3B6BB,
                "COMPONENT_VINTAGEPISTOL_CLIP_02",//0x33BA12E8

                "COMPONENT_AT_AR_FLSH",//
                "COMPONENT_AT_AR_SUPP",//
                "COMPONENT_MILITARYRIFLE_CLIP_01",//
                "COMPONENT_MILITARYRIFLE_CLIP_02",//
                "COMPONENT_MILITARYRIFLE_SIGHT_01",//
                "COMPONENT_AT_SCOPE_SMALL",//
                "COMPONENT_AT_AR_FLSH",//
                "COMPONENT_AT_AR_SUPP",//

                "COMPONENT_HEAVYRIFLE_CLIP_01",// | 0x5AF49386
                "COMPONENT_HEAVYRIFLE_CLIP_02",//");// | 0x6CBF371B
                "COMPONENT_HEAVYRIFLE_SIGHT_01",// | 0xB3E1C452
                "COMPONENT_AT_SCOPE_MEDIUM",// | 0xA0D89C42
                "COMPONENT_AT_AR_FLSH",// | 0x7BC4CDDC
                "COMPONENT_AT_AR_SUPP",// | 0x837445AA
                "COMPONENT_AT_AR_AFGRIP",// | 0xC164F53
                "COMPONENT_HEAVYRIFLE_CAMO1",// | 0xEC9FECD9
                "COMPONENT_APPISTOL_VARMOD_SECURITY",//
                "COMPONENT_MICROSMG_VARMOD_SECURITY",//
                "COMPONENT_PUMPSHOTGUN_VARMOD_SECURITY",//

                "COMPONENT_AT_AR_FLSH_REH", //| 0x9DB1E023
                "COMPONENT_TACTICALRIFLE_CLIP_02", //| 0x8594554F
                "COMPONENT_AT_AR_SUPP_02", ///| 0xA73D4664
                "COMPONENT_AT_AR_AFGRIP" //| 0xC164F53
            };

            return sAddsList;
        }
        public static Vector3 AlterZHight(Vector3 MyVector, float fAddSub)
        {
            return new Vector3(MyVector.X, MyVector.Y, MyVector.Z + fAddSub);
        }
        public static Vector3 SetZHight(Vector3 MyVector, float fHeight)
        {
            return new Vector3(MyVector.X, MyVector.Y, fHeight);
        }
    }
}
