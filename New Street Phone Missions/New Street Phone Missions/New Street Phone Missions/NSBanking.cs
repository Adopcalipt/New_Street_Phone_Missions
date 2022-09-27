using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.Native;

namespace New_Street_Phone_Missions
{
    public class NSBanking
    {
        private static readonly string sNSPMDatafile = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMData.NSPM";
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
                    SaveDat(9, DataStore.MyDatSet.iNSPMBank);
                    DataStore.bBankTransfer = false;
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
                    DataStore.bBankTransfer = false;
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
                SaveDat(9, DataStore.MyDatSet.iNSPMBank);
            else if (iAcc == 2)
                SaveDat(10, DataStore.MyDatSet.iNSPMCLowRisk);
            else if (iAcc == 3)
                SaveDat(11, DataStore.MyDatSet.iNSPMCHighRisk);

            UI.Notify(sTing);
        }
        public static void SaveDat(int iChanges, int iChange)
        {
            LoggerLight.LogThis("SaveDat, iChanges == " + iChanges + ",iChange == " + iChange);
            if (iChanges < 15)
            {
                List<int> iData = new List<int>();

                if (File.Exists(sNSPMDatafile))
                {
                    using (FileStream fs = File.Open(sNSPMDatafile, FileMode.Open))
                    {
                        try
                        {
                            using (BinaryReader r = new BinaryReader(fs))
                            {
                                iData.Add(r.ReadInt32());       //0
                                iData.Add(r.ReadInt32());       //1
                                iData.Add(r.ReadInt32());       //2
                                iData.Add(r.ReadInt32());       //3
                                iData.Add(r.ReadInt32());       //4
                                iData.Add(r.ReadInt32());       //5
                                iData.Add(r.ReadInt32());       //6
                                iData.Add(r.ReadInt32());       //7
                                iData.Add(r.ReadInt32());       //8
                                iData.Add(r.ReadInt32());       //9
                                iData.Add(r.ReadInt32());       //10
                                iData.Add(r.ReadInt32());       //11
                                iData.Add(r.ReadInt32());       //12
                                iData.Add(r.ReadInt32());       //13
                                iData.Add(r.ReadInt32());       //14
                            }
                        }
                        catch
                        {
                            UI.Notify("~r~" + sNSPMDatafile + "Is broken please delete this file");
                            for (int i = 0; i < 15; i++)
                                iData.Add(0);
                        }
                    }

                    if (iChanges != -1)
                        iData[iChanges] = iChange;

                    using (FileStream fs = File.Open(sNSPMDatafile, FileMode.Create))
                    {
                        using (BinaryWriter w = new BinaryWriter(fs))
                        {
                            for (int i = 0; i < iData.Count; i++)
                                w.Write(iData[i]);
                        }
                    }
                }
                else
                {
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
                        }
                    }
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
                        }
                    }
                }
                catch
                {
                    UI.Notify("~r~" + sNSPMDatafile + "Is broken please delete this file");

                    DamDat = new DatFile();
                }
            }
            
            return DamDat;
        }
    }
}
