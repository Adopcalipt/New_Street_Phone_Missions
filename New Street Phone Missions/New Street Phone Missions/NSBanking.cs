using GTA;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class NSBanking
    {
        private static readonly string sNSPMDatafile = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/NSPMData.NSPM";
        private static readonly string sNSPMAchiveArc = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/NSPMach.NSPM";
        private static int iFaster_01 = 0;
        private static int iFaster_02 = 0;
        private static int iFaster_03 = 0;

        public static void BankingApp()
        {
            if (DataStore.iCoinBats == 1)
                UiDisplay.ControlerUI("NSCoins = " + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMBank, true, true) + DataStore.MyLang.Context[30], 1);
            else if (DataStore.iCoinBats == 2)
                UiDisplay.ControlerUI("Low Risk" + " = " + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCLowRisk, true, true) + DataStore.MyLang.Context[30], 1);
            else if (DataStore.iCoinBats == 3)
                UiDisplay.ControlerUI("High Risk" + " = " + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCHighRisk, true, true) + DataStore.MyLang.Context[30], 1);
            else if (DataStore.iCoinBats == 4)
            {
                if (Function.Call<bool>(Hash._HAS_NAMED_SCALEFORM_MOVIE_LOADED, "ATM"))
                    UiDisplay.ControlerUI("NSCoins = " + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMBank, true, true) + DataStore.MyLang.Context[30], 1);
                else
                {
                    SaveBounsData();
                    DataStore.BankTransfer = false;
                    DataStore.iCoinBats = 0;
                }
            }
            else
                UiDisplay.ControlerUI("Yacht Price = " + ReturnStuff.ShowComs(DataStore.MySettings.YachtPrice, true, true) + DataStore.MyLang.Context[30], 1);

            if (Game.IsControlPressed(2, GTA.Control.Detonate))
            {
                if (DataStore.iCoinBats == 4)
                    NSCoinCount(false, 1);
                else
                    NSCoinCount(false, DataStore.iCoinBats);
            }
            else if (Game.IsControlPressed(2, GTA.Control.Context))
            {
                if (DataStore.iCoinBats == 4)
                    NSCoinCount(true, 1);
                else
                    NSCoinCount(true, DataStore.iCoinBats);
            }
            else if (Game.IsControlPressed(2, GTA.Control.Jump))
            {
                if (DataStore.iCoinBats != 4)
                {
                    DataStore.BankTransfer = false;
                    YourCoinPopUp(0, DataStore.iCoinBats, "");
                    DataStore.iCoinBats = 0;
                }
            }
            else
            {
                iFaster_01 = Game.GameTime + 4000;
                iFaster_02 = Game.GameTime + 15000;
                iFaster_03 = Game.GameTime + 25000;
            }
        }
        public static void NSCoinInvestments(bool bPlus, int iLow, int iHigh, string sEnder)
        {
            LoadDat();
            float fAdd = ReturnStuff.RandFlow((float)iLow, (float)iHigh);
            float fSum = 0.00f;
            if (bPlus)
            {
                if (DataStore.MyDatSet.iNSPMCHighRisk > 0)
                {
                    fSum = (float)DataStore.MyDatSet.iNSPMCHighRisk / 100.00f;
                    fSum *= fAdd;
                    YourCoinPopUp((int)fSum, 3, sEnder);
                }
                if (DataStore.MyDatSet.iNSPMCLowRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCLowRisk / 100;
                    fSum *= fAdd / 4.00f;
                    YourCoinPopUp((int)fSum, 2, sEnder);
                }
            }
            else
            {
                if (DataStore.MyDatSet.iNSPMCHighRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCHighRisk / 100;
                    fSum *= fAdd;
                    fSum *= -1;
                    YourCoinPopUp((int)fSum, 3, sEnder);
                }
                if (DataStore.MyDatSet.iNSPMCLowRisk > 0)
                {
                    fSum = DataStore.MyDatSet.iNSPMCLowRisk / 100;
                    fSum *= fAdd / 4;
                    fSum *= -1;
                    YourCoinPopUp((int)fSum, 2, sEnder);
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
        public static void YourCoinPopUp(int iAdd, int iAcc, string sEnder)
        {
            string sTing = "";
            long iBank = DataStore.MyDatSet.iNSPMBank;
            long iLow = DataStore.MyDatSet.iNSPMCLowRisk;
            long iHigh = DataStore.MyDatSet.iNSPMCHighRisk;

            if (iAcc == 1)
                iBank += iAdd;
            else if (iAcc == 2)
                iLow += iAdd;
            else if (iAcc == 3)
                iHigh += iAdd;

            if (iBank < 0)
                iBank = 0;
            else if (iLow < 0)
                iLow = 0;
            else if (iHigh < 0)
                iHigh = 0;
            else if (iBank > 2100000000)
                iBank = 1000000;
            else if (iLow > 2100000000)
                iLow = 1000000;
            else if (iHigh > 2100000000)
                iHigh = 1000000;

            DataStore.MyDatSet.iNSPMBank = (int)iBank;
            DataStore.MyDatSet.iNSPMCLowRisk = (int)iLow;
            DataStore.MyDatSet.iNSPMCHighRisk = (int)iHigh;

            if (iAdd > 0)
            {
                if (iAcc == 1)
                    sTing = DataStore.MyLang.Othertext[140] + "~n~+~b~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMBank, true, true);
                else if (iAcc == 2)
                    sTing = DataStore.MyLang.Othertext[141] + "~n~+~b~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCLowRisk, true, true);
                else if (iAcc == 3)
                    sTing = DataStore.MyLang.Othertext[142] + "~n~+~b~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCHighRisk, true, true);
            }
            else
            {
                if (iAcc == 1)
                    sTing = DataStore.MyLang.Othertext[143] + "~n~-~r~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMBank, true, true);
                else if (iAcc == 2)
                    sTing = DataStore.MyLang.Othertext[144] + "~n~--~r~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCLowRisk, true, true);
                else if (iAcc == 3)
                    sTing = DataStore.MyLang.Othertext[145] + "~n~--~r~ " + ReturnStuff.ShowComs(iAdd, true, true) + "~w~ " + sEnder + "~n~ " + DataStore.MyLang.Othertext[146] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCHighRisk, true, true);
            }

            if (iAcc == 1) 
                SaveBounsData();
            else if (iAcc == 2)
                SaveBounsData();
            else if (iAcc == 3)
                SaveBounsData();

            UI.Notify(sTing);
        }
        public static void SaveBounsData()
        {
            LoggerLight.LogThis("SaveDat");

            using (FileStream fs = File.Open(sNSPMDatafile, FileMode.Create))
            {

                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    w.Write(DataStore.MyDatSet.iOwnaYacht);            //0
                    w.Write(DataStore.MyDatSet.iGotPegsus);            //1
                    w.Write(DataStore.MyDatSet.iPegsSafeHeliTest);     //2
                    w.Write(DataStore.MyDatSet.iPegsWarHeliTest);      //3
                    w.Write(DataStore.MyDatSet.iPegsSafePlaneTest);    //4
                    w.Write(DataStore.MyDatSet.iPegsWarPlaneTest);     //5
                    w.Write(DataStore.MyDatSet.iPegsboatsTest);        //6
                    w.Write(DataStore.MyDatSet.iPegsimortasTest);      //7
                    w.Write(DataStore.MyDatSet.iMeddicTest);           //8
                    w.Write(DataStore.MyDatSet.iNSPMBank);             //9
                    w.Write(DataStore.MyDatSet.iNSPMCLowRisk);         //10
                    w.Write(DataStore.MyDatSet.iNSPMCHighRisk);        //11
                    w.Write(DataStore.MyDatSet.iWantedBribe);          //12
                    w.Write(DataStore.MyDatSet.iFubard);               //13
                    w.Write(DataStore.MyDatSet.iTrinket);              //14
                    w.Write(DataStore.MyDatSet.DAssZone01);
                    w.Write(DataStore.MyDatSet.DAssZone02);
                    w.Write(DataStore.MyDatSet.DAssZone03);
                    w.Write(DataStore.MyDatSet.DAssZone04);
                    w.Write(DataStore.MyDatSet.DAssZone05);
                    w.Write(DataStore.MyDatSet.DAssZone06);
                    w.Write(DataStore.MyDatSet.DAssZone07);
                }
            }
        }
        public static void SaveAchive()
        {
            LoggerLight.LogThis("SaveAchive");

            List<int> iData = new List<int>();

            using (FileStream fs = File.Open(sNSPMAchiveArc, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    w.Write(DataStore.MyAchivments.Trucking_MilesDriven);       //Total miles driven.
                    w.Write(DataStore.MyAchivments.Trucking_KeptYourLoad);      //NoDetaches
                    w.Write(DataStore.MyAchivments.Trucking_FarmYardHand);      //TracktorMish
                    w.Write(DataStore.MyAchivments.Trucking_PerfectParking);    //GetMax Parkin bounus
                    w.Write(DataStore.MyAchivments.Getaway_PickyDriver);    //No Damage
                    w.Write(DataStore.MyAchivments.Getaway_PennyLess);          //LostAll the money
                    w.Write(DataStore.MyAchivments.Getaway_FlighttoSaftey);     //the seceret mission
                    w.Write(DataStore.MyAchivments.Getaway_GoneInSixtySeconds); //done in under 5mins?
                    w.Write(DataStore.MyAchivments.Packages_PavelsPlacements);  //Area7
                    w.Write(DataStore.MyAchivments.Packages_PaperBoy);          //Area6
                    w.Write(DataStore.MyAchivments.Packages_ChickenRun);        //Area5
                    w.Write(DataStore.MyAchivments.Packages_LostinTheBin);      //Area4
                    w.Write(DataStore.MyAchivments.Packages_BigParma);          //Area3
                    w.Write(DataStore.MyAchivments.Packages_WeAimNottoLoseit);  //Area2
                    w.Write(DataStore.MyAchivments.Packages_CanYouSignHere);    //Area1
                    w.Write(DataStore.MyAchivments.Convicts_Goranga);           //Damage all prisoners
                    w.Write(DataStore.MyAchivments.Convicts_DigThatChantingThing);//listen to 3 mins of chanting
                    w.Write(DataStore.MyAchivments.Convicts_DontStopForCoffiee);//press horn in less than a second
                    w.Write(DataStore.MyAchivments.Fubar_FollowThatCar);        //maby add a follow option and multi drop also.
                    w.Write(DataStore.MyAchivments.Fubar_BigYellowTaxi);        //Taxi Attackes
                    w.Write(DataStore.MyAchivments.Fubar_AirportRun);           //Goto or from the airport
                    w.Write(DataStore.MyAchivments.Fubar_TapTheMats);           //Veh Damage
                    w.Write(DataStore.MyAchivments.Planes01_AllTheAngles);      //Gett High score.
                    w.Write(DataStore.MyAchivments.Planes02_ItsThePlayerBase);  //GetAttackedByPlayer
                    w.Write(DataStore.MyAchivments.Planes03_KeptItTogether);    //bert damage
                    w.Write(DataStore.MyAchivments.Planes04_AllYouNeedIsHommingMissiles);//Unlock hidden getawau mish
                    w.Write(DataStore.MyAchivments.Planes05_HeyFarmerFarmer);   //spair chems
                    w.Write(DataStore.MyAchivments.Planes06_LikeAndSubscribe);  //veh damage low
                    w.Write(DataStore.MyAchivments.Ambulance_WinSomeLoseSome);  //Fail due to neglegence
                    w.Write(DataStore.MyAchivments.Ambulance_OpenTheWindows);   //have a diarea patent sit next to you
                    w.Write(DataStore.MyAchivments.Ambulance_LsInLockdown);     //CovedOutBreak
                    w.Write(DataStore.MyAchivments.Ambulance_HomeVisits);       //Going to houses or traillrers-or thats a nice pad when visited playerhouses?or for arcade/nightcllub
                    w.Write(DataStore.MyAchivments.Ambulance_ReadTheBook);      //Correct diagnosis
                    w.Write(DataStore.MyAchivments.Follow_OutOfThisWorld);      //UfoEnd
                    w.Write(DataStore.MyAchivments.Follow_AndKaboom);           //blowupend
                    w.Write(DataStore.MyAchivments.Follow_InABlaseOfGlory);     //AmbushEnd
                    w.Write(DataStore.MyAchivments.Follow_OnePreviousOwner);    //takecarend
                    w.Write(DataStore.MyAchivments.Follow_WisperingGrass);      //copchaseEnd
                    w.Write(DataStore.MyAchivments.Follow_KightInShiningAuto);  //ProtectEnd
                    w.Write(DataStore.MyAchivments.Fire_FirePlace);             //HouseFires
                    w.Write(DataStore.MyAchivments.Fire_BurningRubber);         //car fire
                    w.Write(DataStore.MyAchivments.Fire_SaveThePussy);          //save cat
                    w.Write(DataStore.MyAchivments.Fire_TheFireStarter);        //Madman
                    w.Write(DataStore.MyAchivments.Fire_BinAndGone);            //wastebins
                    w.Write(DataStore.MyAchivments.Johnny_ItWasLikeThatWhenIGotIt);//VehDamage
                    w.Write(DataStore.MyAchivments.Johnny_ITawITawThePlayerCreapinUp);//SurviveplayerAttack
                    w.Write(DataStore.MyAchivments.Johnny_ThisOnesAkeeper);     //KeepplayersCar
                    w.Write(DataStore.MyAchivments.Johnny_AFewErrendsToRunirst);//take more than 5mins to deliver the car
                    w.Write(DataStore.MyAchivments.Racist_RidingThroughTheSnow);//Have a snow race
                    w.Write(DataStore.MyAchivments.Racist_WaterSports);         //do a boat race in the rain
                    w.Write(DataStore.MyAchivments.Racist_FullContact);         //Road race contact on with traffic
                    w.Write(DataStore.MyAchivments.Racist_ComeFlyWithMe);       //Win A flight race.
                    w.Write(DataStore.MyAchivments.Racist_CyclePath);           //knock a cyclest off there cycle
                    w.Write(DataStore.MyAchivments.Bbomb_SoThereItIs);          //find the bbomb in under 10sec
                    w.Write(DataStore.MyAchivments.Bbomb_OnlyTheDoors);         //find the bbomb with with 1 sec to spair
                    w.Write(DataStore.MyAchivments.Hitman_SurgicalPresion);     //Only kill the target
                    w.Write(DataStore.MyAchivments.Hitman_BringEveryBody);      //kill everyone
                    w.Write(DataStore.MyAchivments.Hitman_HoldMyBeer);          //Complete in under a minite
                    w.Write(DataStore.MyAchivments.Hitman_Hunter);              //use only mellee weapons
                    w.Write(DataStore.MyAchivments.Sniper_LieFlat);             //use prone postion to get the shot
                    w.Write(DataStore.MyAchivments.Sniper_DrivinMissDasy);      //shoot the target n a car.
                    w.Write(DataStore.MyAchivments.Sniper_FireAtWill);          //shoot the wrong guy
                    w.Write(DataStore.MyAchivments.MoneyMAn_DoubbleCross);      //Get van back from partner.
                    w.Write(DataStore.MyAchivments.MoneyMAn_AngreyMob);         //Excape the angery mob
                    w.Write(DataStore.MyAchivments.MoneyMAn_Tanks);             //Excape the tank.
                    w.Write(DataStore.MyAchivments.MoneyMAn_ThatsMine);         //Recover the security van before it blows up.
                    w.Write(DataStore.MyAchivments.MoneyMAn_WhileImHere);       //Buy SomeThing from the shop.
                    w.Write(DataStore.MyAchivments.Water01_AndThePointWas);     //Dunk know
                    w.Write(DataStore.MyAchivments.Water02_PricyPiracy);        //Alter the buy price of the yacht.
                    w.Write(DataStore.MyAchivments.Water03_PhishinTrip);        //Knock a fisherman into the drink.
                    w.Write(DataStore.MyAchivments.Water04_SingleUsePlastics);  //dunkknow
                    w.Write(DataStore.MyAchivments.Water05_DryDocking);         //Use the cargobob to deliver boat
                    w.Write(DataStore.MyAchivments.Water06_SubCub);             //Kill all the sailors
                    w.Write(DataStore.MyAchivments.ImportExport_GotToGetThemAll);//Collect All the Cars
                    w.Write(DataStore.MyAchivments.ImportExport_IJustWantYourCar);//dont kill any one
                    w.Write(DataStore.MyAchivments.ImportExport_GetAGoodPrice); //no damage
                    w.Write(DataStore.MyAchivments.ImportExport_AboveAndBeond); //cargobob
                    w.Write(DataStore.MyAchivments.DebtCollect_IjustWantTheCase);//no deaths
                    w.Write(DataStore.MyAchivments.DebtCollect_TheEnforcer);    //all melle kills
                    w.Write(DataStore.MyAchivments.BikerRaids_TheWheelsOnTheBus);//Deliver the bus to the clubhouse
                    w.Write(DataStore.MyAchivments.BikerRaids_ButItsNotABike);  //Deliver the slamvan to the clubhouse
                    w.Write(DataStore.MyAchivments.BikerRaids_DukeItOut);       //Kill 20+ Bikers
                    w.Write(DataStore.MyAchivments.CargoCollect_BigAndSmalll);  //Collect from all sizes of warehouse and bunker.
                    w.Write(DataStore.MyAchivments.CargoCollect_NoYouCantHaveItBack);//Dispatch you persuers
                    w.Write(DataStore.MyAchivments.CargoCollect_CollectAlTheGoods);//Get 1+ each pallet.
                    w.Write(DataStore.MyAchivments.DeepDown_SharkCards);        //Clear them in under 5mins
                    w.Write(DataStore.MyAchivments.DeepDown_DasBoot);           //Blow your self up.
                    w.Write(DataStore.MyAchivments.HappyShopper_SuperMarketSweep);//Do in under 5mins.
                    w.Write(DataStore.MyAchivments.HappyShopper_IJustWantedSprunk);//Buy a can of sprunk
                    w.Write(DataStore.MyAchivments.HappyShopper_IsABadHabit);   //SmashCiggeretsand alchole
                    w.Write(DataStore.MyAchivments.MoresMuted_PerfectParking);   //max parking set
                    w.Write(DataStore.MyAchivments.MoresMuted_NotAScratch);     //no damage
                    w.Write(DataStore.MyAchivments.Temp01_OwnGoal);             //score an own goal
                    w.Write(DataStore.MyAchivments.Temp02_Upsetter);            //dont serve a customer
                    w.Write(DataStore.MyAchivments.Temp03_NotADupe);            //max car sales
                    w.Write(DataStore.MyAchivments.Temp04_MilesOnTheClock);     //drive customes car around for a bit.
                    w.Write(DataStore.MyAchivments.Temp05_GettingAir);          //get over $5000 in air time
                    w.Write(DataStore.MyAchivments.Temp06_StopTheClock);        //Eliminater players in under 30sec
                    w.Write(DataStore.MyAchivments.ParaDisplay_HeyBuddy);       //Land parashoot next a player
                    w.Write(DataStore.MyAchivments.ParaDisplay_BuryTheHatchet); //Use the hachet
                    w.Write(DataStore.MyAchivments.ParaDisplay_AnyOneForGolf);  //Use the golf club
                    w.Write(DataStore.MyAchivments.ParaDisplay_HomeRun);        //Use the baseball bat
                    w.Write(DataStore.MyAchivments.ParaDisplay_KnifySpoony);    //Use the flick knife
                    w.Write(DataStore.MyAchivments.DeliverWho_The24HourSession);//deliver for 24 in game hours
                    w.Write(DataStore.MyAchivments.DeliverWho_OnYourBike);      //deliver on a bike
                    w.Write(DataStore.MyAchivments.DeliverWho_RideShare);       //deliver in a fubar taxi
                    w.Write(DataStore.MyAchivments.CayoThief_ImAPasafisit);       //
                    w.Write(DataStore.MyAchivments.CayoThief_YourGonaHaveToWalk);       //

                    w.Write(DataStore.MyAchivments.CargoTrackingWhSm);
                    w.Write(DataStore.MyAchivments.CargoTrackingWhMd);
                    w.Write(DataStore.MyAchivments.CargoTrackingWhLg);
                    w.Write(DataStore.MyAchivments.CargoTrackingWhBu);

                    w.Write(DataStore.MyAchivments.CargoTrackingPl01);
                    w.Write(DataStore.MyAchivments.CargoTrackingPl02);
                    w.Write(DataStore.MyAchivments.CargoTrackingPl03);
                    w.Write(DataStore.MyAchivments.CargoTrackingPl04);
                    w.Write(DataStore.MyAchivments.CargoTrackingPl05);
                    w.Write(DataStore.MyAchivments.CargoTrackingPl06);
                }
            }
        }
        public static DatFile LoadDat()
        {
            LoggerLight.LogThis("LoadDat");

            DatFile DamDat = new DatFile();

            if (File.Exists(sNSPMDatafile))
            {
                try
                {
                    using (FileStream fs = File.Open(sNSPMDatafile, FileMode.Open))
                    {
                        using (BinaryReader r = new BinaryReader(fs))
                        {
                            DamDat.iOwnaYacht = r.ReadInt32();            //0
                            DamDat.iGotPegsus = r.ReadInt32();            //1
                            DamDat.iPegsSafeHeliTest = r.ReadInt32();     //2
                            DamDat.iPegsWarHeliTest = r.ReadInt32();      //3
                            DamDat.iPegsSafePlaneTest = r.ReadInt32();    //4
                            DamDat.iPegsWarPlaneTest = r.ReadInt32();     //5
                            DamDat.iPegsboatsTest = r.ReadInt32();        //6
                            DamDat.iPegsimortasTest = r.ReadInt32();      //7
                            DamDat.iMeddicTest = r.ReadInt32();           //8
                            DamDat.iNSPMBank = r.ReadInt32();             //9
                            DamDat.iNSPMCLowRisk = r.ReadInt32();         //10
                            DamDat.iNSPMCHighRisk = r.ReadInt32();        //11
                            DamDat.iWantedBribe = r.ReadInt32();          //12
                            DamDat.iFubard = r.ReadInt32();               //13
                            DamDat.iTrinket = r.ReadInt32();              //14
                            DamDat.DAssZone01 = r.ReadInt32();
                            DamDat.DAssZone02 = r.ReadInt32();
                            DamDat.DAssZone03 = r.ReadInt32();
                            DamDat.DAssZone04 = r.ReadInt32();
                            DamDat.DAssZone05 = r.ReadInt32();
                            DamDat.DAssZone06 = r.ReadInt32();
                            DamDat.DAssZone07 = r.ReadInt32();
                        }
                    }
                }
                catch
                {
                    UI.Notify("~r~" + sNSPMDatafile + "Is broken please delete this file");
                }
            }
            
            return DamDat;
        }
        public static AchieveAbleGoals LoadGooals()
        {
            LoggerLight.LogThis("LoadGooals");

            AchieveAbleGoals DamDat = new AchieveAbleGoals();

            if (File.Exists(sNSPMAchiveArc))
            {
                try
                {
                    using (FileStream fs = File.Open(sNSPMAchiveArc, FileMode.Open))
                    {
                        using (BinaryReader r = new BinaryReader(fs))
                        {
                            DamDat.Trucking_MilesDriven = r.ReadInt32();       //Total miles driven.
                            DamDat.Trucking_KeptYourLoad = r.ReadInt32();      //NoDetaches
                            DamDat.Trucking_FarmYardHand = r.ReadInt32();      //TracktorMish
                            DamDat.Trucking_PerfectParking = r.ReadInt32();    //GetMax Parkin bounus
                            DamDat.Getaway_PickyDriver = r.ReadInt32();        //Change Vehicles
                            DamDat.Getaway_PennyLess = r.ReadInt32();          //LostAll the money
                            DamDat.Getaway_FlighttoSaftey = r.ReadInt32();     //the seceret mission
                            DamDat.Getaway_GoneInSixtySeconds = r.ReadInt32(); //done in under 5mins?
                            DamDat.Packages_PavelsPlacements = r.ReadInt32();  //Area7
                            DamDat.Packages_PaperBoy = r.ReadInt32();          //Area6
                            DamDat.Packages_ChickenRun = r.ReadInt32();        //Area5
                            DamDat.Packages_LostinTheBin = r.ReadInt32();      //Area4
                            DamDat.Packages_BigParma = r.ReadInt32();          //Area3
                            DamDat.Packages_WeAimNottoLoseit = r.ReadInt32();  //Area2
                            DamDat.Packages_CanYouSignHere = r.ReadInt32();    //Area1
                            DamDat.Convicts_Goranga = r.ReadInt32();           //Damage all prisoners
                            DamDat.Convicts_DigThatChantingThing = r.ReadInt32();//listen to 3 mins of chanting
                            DamDat.Convicts_DontStopForCoffiee = r.ReadInt32();//press horn in less than a second
                            DamDat.Fubar_FollowThatCar = r.ReadInt32();        //maby add a follow option and multi drop also.
                            DamDat.Fubar_BigYellowTaxi = r.ReadInt32();        //Taxi Attackes
                            DamDat.Fubar_AirportRun = r.ReadInt32();           //Goto or from the airport
                            DamDat.Fubar_TapTheMats = r.ReadInt32();           //Veh Damage
                            DamDat.Planes01_AllTheAngles = r.ReadInt32();      //Gett High score.
                            DamDat.Planes02_ItsThePlayerBase = r.ReadInt32();  //GetAttackedByPlayer
                            DamDat.Planes03_KeptItTogether = r.ReadInt32();    //bert damage
                            DamDat.Planes04_AllYouNeedIsHommingMissiles = r.ReadInt32();//Unlock hidden getawau mish
                            DamDat.Planes05_HeyFarmerFarmer = r.ReadInt32();   //spair chems
                            DamDat.Planes06_LikeAndSubscribe = r.ReadInt32();  //veh damage low
                            DamDat.Ambulance_WinSomeLoseSome = r.ReadInt32();  //Fail due to neglegence
                            DamDat.Ambulance_OpenTheWindows = r.ReadInt32();   //have a diarea patent sit next to you
                            DamDat.Ambulance_LsInLockdown = r.ReadInt32();     //CovedOutBreak
                            DamDat.Ambulance_HomeVisits = r.ReadInt32();       //Going to houses or traillrers-or thats a nice pad when visited playerhouses?or for arcade/nightcllub
                            DamDat.Ambulance_ReadTheBook = r.ReadInt32();      //Correct diagnosis
                            DamDat.Follow_OutOfThisWorld = r.ReadInt32();      //UfoEnd
                            DamDat.Follow_AndKaboom = r.ReadInt32();           //Blowupend
                            DamDat.Follow_InABlaseOfGlory = r.ReadInt32();     //AmbushEnd
                            DamDat.Follow_OnePreviousOwner = r.ReadInt32();    //takecarend
                            DamDat.Follow_WisperingGrass = r.ReadInt32();      //copchaseEnd
                            DamDat.Follow_KightInShiningAuto = r.ReadInt32();  //ProtectEnd
                            DamDat.Fire_FirePlace = r.ReadInt32();             //HouseFires
                            DamDat.Fire_BurningRubber = r.ReadInt32();         //car fire
                            DamDat.Fire_SaveThePussy = r.ReadInt32();          //save cat
                            DamDat.Fire_TheFireStarter = r.ReadInt32();        //Madman
                            DamDat.Fire_BinAndGone = r.ReadInt32();            //wastebins
                            DamDat.Johnny_ItWasLikeThatWhenIGotIt = r.ReadInt32();//VehDamage
                            DamDat.Johnny_ITawITawThePlayerCreapinUp = r.ReadInt32();//SurviveplayerAttack
                            DamDat.Johnny_ThisOnesAkeeper = r.ReadInt32();     //KeepplayersCar
                            DamDat.Johnny_AFewErrendsToRunirst = r.ReadInt32();//take more than 5mins to deliver the car
                            DamDat.Racist_RidingThroughTheSnow = r.ReadInt32();//Have a snow race
                            DamDat.Racist_WaterSports = r.ReadInt32();         //do a boat race in the rain
                            DamDat.Racist_FullContact = r.ReadInt32();         //Road race contact on with traffic
                            DamDat.Racist_ComeFlyWithMe = r.ReadInt32();       //Win A flight race.
                            DamDat.Racist_CyclePath = r.ReadInt32();           //knock a cyclest off there cycle
                            DamDat.Bbomb_SoThereItIs = r.ReadInt32();          //find the bbomb in under 10sec
                            DamDat.Bbomb_OnlyTheDoors = r.ReadInt32();         //find the bbomb with with 1 sec to spair
                            DamDat.Hitman_SurgicalPresion = r.ReadInt32();     //Only kill the target
                            DamDat.Hitman_BringEveryBody = r.ReadInt32();      //kill everyone
                            DamDat.Hitman_HoldMyBeer = r.ReadInt32();          //Complete in under a minite
                            DamDat.Hitman_Hunter = r.ReadInt32();              //use only mellee weapons
                            DamDat.Sniper_LieFlat = r.ReadInt32();             //use prone postion to get the shot
                            DamDat.Sniper_DrivinMissDasy = r.ReadInt32();      //shoot the target n a car.
                            DamDat.Sniper_FireAtWill = r.ReadInt32();          //shoot the wrong guy
                            DamDat.MoneyMAn_DoubbleCross = r.ReadInt32();      //Get van back from partner.
                            DamDat.MoneyMAn_AngreyMob = r.ReadInt32();         //Excape the angery mob
                            DamDat.MoneyMAn_Tanks = r.ReadInt32();             //Excape the tank.
                            DamDat.MoneyMAn_ThatsMine = r.ReadInt32();         //Recover the security van before it blows up.
                            DamDat.MoneyMAn_WhileImHere = r.ReadInt32();       //Buy SomeThing from the shop.
                            DamDat.Water01_AndThePointWas = r.ReadInt32();     //Dunk know
                            DamDat.Water02_PricyPiracy = r.ReadInt32();        //Alter the buy price of the yacht.
                            DamDat.Water03_PhishinTrip = r.ReadInt32();        //Knock a fisherman into the drink.
                            DamDat.Water04_SingleUsePlastics = r.ReadInt32();  //dunkknow
                            DamDat.Water05_DryDocking = r.ReadInt32();         //Use the cargobob to deliver boat
                            DamDat.Water06_SubCub = r.ReadInt32();             //Kill all the sailors
                            DamDat.ImportExport_GotToGetThemAll = r.ReadInt32();//Collect All the Cars
                            DamDat.ImportExport_IJustWantYourCar = r.ReadInt32();//dont kill any one
                            DamDat.ImportExport_GetAGoodPrice = r.ReadInt32(); //no damage
                            DamDat.ImportExport_AboveAndBeond = r.ReadInt32(); //cargobob
                            DamDat.DebtCollect_IjustWantTheCase = r.ReadInt32();//no deaths
                            DamDat.DebtCollect_TheEnforcer = r.ReadInt32();    //all melle kills
                            DamDat.BikerRaids_TheWheelsOnTheBus = r.ReadInt32();//Deliver the bus to the clubhouse
                            DamDat.BikerRaids_ButItsNotABike = r.ReadInt32();  //Deliver the slamvan to the clubhouse
                            DamDat.BikerRaids_DukeItOut = r.ReadInt32();       //Kill 20+ Bikers
                            DamDat.CargoCollect_BigAndSmalll = r.ReadInt32();  //Collect from all sizes of warehouse and bunker.
                            DamDat.CargoCollect_NoYouCantHaveItBack = r.ReadInt32();//Dispatch you persuers
                            DamDat.CargoCollect_CollectAlTheGoods = r.ReadInt32();//Get 1+ each pallet.
                            DamDat.DeepDown_SharkCards = r.ReadInt32();        //Clear them in under 5mins
                            DamDat.DeepDown_DasBoot = r.ReadInt32();           //Blow your self up.
                            DamDat.HappyShopper_SuperMarketSweep = r.ReadInt32();//Do in under 5mins.
                            DamDat.HappyShopper_IJustWantedSprunk = r.ReadInt32();//Buy a can of sprunk
                            DamDat.HappyShopper_IsABadHabit = r.ReadInt32();   //SmashCiggeretsand alchole
                            DamDat.MoresMuted_PerfectParking = r.ReadInt32();   //max parking set
                            DamDat.MoresMuted_NotAScratch = r.ReadInt32();     //no damage
                            DamDat.Temp01_OwnGoal = r.ReadInt32();             //score an own goal
                            DamDat.Temp02_Upsetter = r.ReadInt32();            //dont serve a customer
                            DamDat.Temp03_NotADupe = r.ReadInt32();            //max car sales
                            DamDat.Temp04_MilesOnTheClock = r.ReadInt32();     //drive customes car around for a bit.
                            DamDat.Temp05_GettingAir = r.ReadInt32();           //get over $5000 in air time
                            DamDat.Temp06_StopTheClock = r.ReadInt32();        //Eliminater players in under 30sec
                            DamDat.ParaDisplay_HeyBuddy = r.ReadInt32();       //Land parashoot next a player
                            DamDat.ParaDisplay_BuryTheHatchet = r.ReadInt32(); //Use the hachet
                            DamDat.ParaDisplay_AnyOneForGolf = r.ReadInt32();  //Use the golf club
                            DamDat.ParaDisplay_HomeRun = r.ReadInt32();        //Use the baseball bat
                            DamDat.ParaDisplay_KnifySpoony = r.ReadInt32();    //Use the flick knife
                            DamDat.DeliverWho_The24HourSession = r.ReadInt32();//deliver for 24 in game hours
                            DamDat.DeliverWho_OnYourBike = r.ReadInt32();      //deliver on a bike
                            DamDat.DeliverWho_RideShare = r.ReadInt32();       //deliver in a fubar taxi
                            DamDat.CayoThief_ImAPasafisit = r.ReadInt32();       //
                            DamDat.CayoThief_YourGonaHaveToWalk = r.ReadInt32();       //

                            DamDat.CargoTrackingWhSm = r.ReadInt32();
                            DamDat.CargoTrackingWhMd = r.ReadInt32();
                            DamDat.CargoTrackingWhLg = r.ReadInt32();
                            DamDat.CargoTrackingWhBu = r.ReadInt32();

                            DamDat.CargoTrackingPl01 = r.ReadInt32();
                            DamDat.CargoTrackingPl02 = r.ReadInt32();
                            DamDat.CargoTrackingPl03 = r.ReadInt32();
                            DamDat.CargoTrackingPl04 = r.ReadInt32();
                            DamDat.CargoTrackingPl05 = r.ReadInt32();
                            DamDat.CargoTrackingPl06 = r.ReadInt32();
                        }
                    }
                }
                catch
                {
                    UI.Notify("~r~" + sNSPMDatafile + "Is broken please delete this file");
                }
            }

            return DamDat;
        }
    }
}
