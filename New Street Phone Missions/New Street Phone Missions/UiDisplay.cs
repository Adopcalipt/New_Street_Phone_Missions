using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;


namespace New_Street_Phone_Missions
{
    public class UiDisplay : Script
    {
        public static TextTimerBar ttTextBar_01 { get; set; }
        public static TextTimerBar ttTextBar_02 { get; set; }
        public static TextTimerBar ttTextBar_03 { get; set; }
        public static TextTimerBar ttTextBar_04 { get; set; }
        public static BarTimerBar BtSlideBar { get; set; }

        public static string sSubDisplay { get; set; }
        public static bool bSubDisplay { get; set; }

        public static TimerBarPool MpUiDisplay { get; set; }
        public static bool bUiDisplay { get; set; }

        public static MarkyMark MMDisplay01 { get; set; }
        public static bool bMMDisplay01 { get; set; }

        public static MarkyMark MMDisplay02 { get; set; }
        public static bool bMMDisplay02 { get; set; }

        public static int iScale { get; set; }
        public static bool bDisplayUiBar { get; set; }

        public UiDisplay()
        {
            MpUiDisplay = new TimerBarPool();
            ttTextBar_01 = new TextTimerBar("", "");
            ttTextBar_02 = new TextTimerBar("", "");
            ttTextBar_03 = new TextTimerBar("", "");
            ttTextBar_04 = new TextTimerBar("", "");
            BtSlideBar = new BarTimerBar("");

            Tick += OnTick;
            //KeyDown += OnKeyDown;
            Interval = 1;
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (bMMDisplay01)
                World.DrawMarker(MMDisplay01.MarkType, MMDisplay01.MarkPos, MMDisplay01.MarkDir, MMDisplay01.MarkRot, MMDisplay01.MarkScale, MMDisplay01.MarkCol);

            if (bMMDisplay02)
                World.DrawMarker(MMDisplay02.MarkType, MMDisplay02.MarkPos, MMDisplay02.MarkDir, MMDisplay02.MarkRot, MMDisplay02.MarkScale, MMDisplay02.MarkCol);

            if (bSubDisplay)
                StickySubTitle(sSubDisplay);

            if (bUiDisplay)
                MpUiDisplay.Draw();

            if (bDisplayUiBar)
                Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, iScale, 255, 255, 255, 255);
        }
        private void StickySubTitle(string sTing)
        {
            Function.Call(Hash.SET_TEXT_FONT, 0);
            Function.Call(Hash.SET_TEXT_SCALE, 0.55f, 0.55f);
            Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);//white
            Function.Call(Hash.SET_TEXT_CENTRE, true); //
            Function.Call(Hash.SET_TEXT_DROPSHADOW, 4, 0, 0, 0, 0);//Dunknow--changed last 255 to 0
            Function.Call(Hash._SET_TEXT_ENTRY, "TWOSTRINGS");//
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sTing);
            Function.Call(Hash._DRAW_TEXT, 0.5f, 0.9f);

            //SET_TEXT_FONT
            //FontChaletLondon = 0,
            //FontHouseScript = 1,
            //FontMonospace = 2,
            //FontWingDings = 3,
            //FontChaletComprimeCologne = 4,
            //FontPricedown = 7
        }       
        public static bool ControlerUI(string sText, int iDuration)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sText);
            Function.Call(Hash._0x238FFE5C7B0498A6, false, false, false, iDuration);

            return true;
        }
        public static void BigMessLoad(bool bFail, string sMessyG, bool bAltEnd, int iCashOut)
        {
            LoggerLight.LogThis("BigMessLoad, bFail == " + bFail + ", bAltEnd == " + bAltEnd + ", iCashOut == " + iCashOut);

            int iScale = Function.Call<int>((Hash)0x11FE353CF9733E6F, "MIDSIZED_MESSAGE");
            Script.Wait(1500);
            while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, iScale))
                Script.Wait(1);

            if (bAltEnd)
            {
                if (MissionData.bGOURANGA)
                    BigMessTime("GOURANGA!", "", 15, false, iCashOut, iScale);
                else if (MissionData.bAmberAntz)
                    BigMessTime(DataStore.MyLang.Othertext[54], sMessyG, 6, true, iCashOut, iScale);

                MissionData.bGOURANGA = false;
                MissionData.bAmberAntz = false;
            }
            else
            {
                if (bFail)
                    BigMessTime(DataStore.MyLang.Othertext[55], sMessyG, 6, false, iCashOut, iScale);
                else
                    BigMessTime(DataStore.MyLang.Othertext[54], sMessyG, 12, true, iCashOut, iScale);
            }

            MissionData.iWait4Sec = Game.GameTime + 8000;

            while (MissionData.iWait4Sec > Game.GameTime)
            {
                Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, iScale, 255, 255, 255, 255);
                Script.Wait(1);
            }

            if (MissionData.bPacBouns)
            {
                ObjectHand.ControlSelect(5, false);
                MissionData.iWait4Sec = Game.GameTime + 7000;
            }

            unsafe
            {
                int SF = iScale;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        public static void BigMessTime(string MainTitle, string SubTitle, int iColour, bool bCash, int iCashOut,int iScale)
        {
            LoggerLight.LogThis("BigMessTime, bCash == " + bCash + ", iCashOut == " + iCashOut);

            Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 8500, false);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "SHOW_SHARD_MIDSIZED_MESSAGE");
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call((Hash)0x6C188BE134E074AA, MainTitle);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call((Hash)0x6C188BE134E074AA, SubTitle);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, iColour);// color 0,1=white 2=black 3=grey 6,7,8=red 9,10,11=blue 12,13,14=yellow 15,16,17=orange 18,19,20=green 21,22,23=purple 
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
            if (bCash)
                YourCoinPopUp(iCashOut, 1, "NSPM Pay");
        }
        public static void YourCoinPopUp(int iAdd, int iAcc, string sEnder)
        {
            string sTing = "";

            if (iAcc == 1)
                DataStore.MyDatSet.iNSPMBank += iAdd;
            else if (iAcc == 2)
                DataStore.MyDatSet.iNSPMCLowRisk += iAdd;
            else if (iAcc == 3)
                DataStore.MyDatSet.iNSPMCHighRisk += iAdd;

            if (DataStore.MyDatSet.iNSPMBank < 0)
                DataStore.MyDatSet.iNSPMBank = 0;
            else if (DataStore.MyDatSet.iNSPMCLowRisk < 0)
                DataStore.MyDatSet.iNSPMCLowRisk = 0;
            else if (DataStore.MyDatSet.iNSPMCHighRisk < 0)
                DataStore.MyDatSet.iNSPMCHighRisk = 0;
            else if (DataStore.MyDatSet.iNSPMBank > 2100000000)
                DataStore.MyDatSet.iNSPMBank = 2100000000;
            else if (DataStore.MyDatSet.iNSPMCLowRisk > 2100000000)
                DataStore.MyDatSet.iNSPMCLowRisk = 2100000000;
            else if (DataStore.MyDatSet.iNSPMCHighRisk > 2100000000)
                DataStore.MyDatSet.iNSPMCHighRisk = 2100000000;

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
                RWDatFile.SaveDat(9, DataStore.MyDatSet.iNSPMBank);
            else if (iAcc == 2)
                RWDatFile.SaveDat(10, DataStore.MyDatSet.iNSPMCLowRisk);
            else if (iAcc == 3)
                RWDatFile.SaveDat(11, DataStore.MyDatSet.iNSPMCHighRisk);

            UI.Notify(sTing);
        }
        public static void BaseHelpBar(List<int> iButtons, List<string> sInstuctions)
        {
            LoggerLight.LogThis("BaseHelpBar");

            iScale = Function.Call<int>((Hash)0x11FE353CF9733E6F, "instructional_buttons");

            while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, iScale))
                Script.Wait(1);

            Function.Call(Hash._CALL_SCALEFORM_MOVIE_FUNCTION_VOID, iScale, "CLEAR_ALL");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "TOGGLE_MOUSE_BUTTONS");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, 0);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

            Function.Call(Hash._CALL_SCALEFORM_MOVIE_FUNCTION_VOID, iScale, "CREATE_CONTAINER");

            int iAddOns = 0;

            List<string> MyButt = new List<string>();

            for (int i = 0; i < iButtons.Count; i++)
            {
                if (iButtons[i] == 25 || iButtons[i] == 37)
                {
                    Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "SET_DATA_SLOT");
                    Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, iAddOns);
                    Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, ")");
                    Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
                    iAddOns += 1;
                }
                string ThisKey = Function.Call<string>(Hash._0x0499D7B09FC9B407, 2, iButtons[i], 1);
                //MyButt.Add(ThisKey);

                Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "SET_DATA_SLOT");
                Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, iAddOns);
                Function.Call(Hash._0xE83A3E3557A56640, ThisKey);
                Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, sInstuctions[i]);
                Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
                iAddOns += 1;
            }

            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "DRAW_INSTRUCTIONAL_BUTTONS");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, -1);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

            bDisplayUiBar = true;

        }
        public static void CloseBaseHelpBar()
        {
            LoggerLight.LogThis("CloseBaseHelpBar");
            bDisplayUiBar = false;
            unsafe
            {
                int SF = iScale;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        public static void TheYellowCorona(Vector3 Vtech, float fRaid)
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
            MissionData.iCoronaList.Add(ThisCheck);
            ObjectHand.ReadWriteBlips(false, true, -1, ThisCheck, -1, -1, -1, -1);
        }
        public static void HelperBarBuiler(int iPart, bool bWipe)
        {
            LoggerLight.LogThis("HelperBarBuiler, Part == " + iPart + " ,bwipe == " + bWipe);

            if (bWipe)
                CloseBaseHelpBar();

            List<string> MyInstructions = new List<string>();

            List<int> MyButtons = new List<int>();

            MyInstructions.Add("+");
            MyInstructions.Add("( " + DataStore.MyLang.Othertext[92]);

            MyButtons.Add(25);
            MyButtons.Add(140);

            if (iPart == 10)
            {
                MyInstructions.Add("+");
                MyInstructions.Add(DataStore.MyLang.Othertext[94]);
                MyInstructions.Add("( " + DataStore.MyLang.Othertext[95]);

                MyButtons.Add(37);
                MyButtons.Add(21);
                MyButtons.Add(22);
            }
            else if (iPart == 11)
            {
                MyInstructions.Add("+");
                MyInstructions.Add(DataStore.MyLang.Othertext[96]);
                MyInstructions.Add("( " + DataStore.MyLang.Othertext[95]);

                MyButtons.Add(37);
                MyButtons.Add(21);
                MyButtons.Add(22);
            }
            else if (MissionData.iBuildMode == 1)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[97]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[98]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[99]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[100]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[101]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[102]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(27);
                    MyButtons.Add(173);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[103]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[104]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[105]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[106]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[107]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[108]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[109]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[102]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(34);
                    MyButtons.Add(35);
                    MyButtons.Add(32);
                    MyButtons.Add(33);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 3)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[110]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
                else if (iPart == 4)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[111]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[112]);

                    MyButtons.Add(37);
                    MyButtons.Add(23);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
                else if (iPart == 5)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[97]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[98]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[102]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(22);
                }
            }
            else if (MissionData.iBuildMode == 2)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[113]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[114]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[115]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[99]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[100]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                    MyButtons.Add(27);
                    MyButtons.Add(173);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[103]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[104]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[105]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[106]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[107]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[108]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[109]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[102]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(34);
                    MyButtons.Add(35);
                    MyButtons.Add(32);
                    MyButtons.Add(33);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 3)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[110]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
                else if (iPart == 4)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[111]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[112]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 5)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[113]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[114]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[115]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[102]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 6)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[116]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[117]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
            }
            else if (MissionData.iBuildMode == 3)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[118]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[117]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
            }
            else if (MissionData.iBuildMode == 4)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[119]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[120]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 3)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[121]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[117]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
            }
            else if (MissionData.iBuildMode == 5)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[122]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[117]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
            }
            else if (MissionData.iBuildMode == 6)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[123]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[124]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
            }
            else if (MissionData.iBuildMode == 7)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[113]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[114]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[115]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[125]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[126]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                    MyButtons.Add(27);
                    MyButtons.Add(173);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[110]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
            }
            else if (MissionData.iBuildMode == 8)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[113]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[114]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[127]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[128]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[125]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[126]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                    MyButtons.Add(27);
                    MyButtons.Add(173);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[113]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[114]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[115]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[128]);

                    MyButtons.Add(37);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                    MyButtons.Add(21);
                    MyButtons.Add(22);
                }
                else if (iPart == 3)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[129]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 4)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[130]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 5)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[131] + MissionData.iMissionVar_01);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 6)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[132]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[111]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
                else if (iPart == 7)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[128]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[125]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[126]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(47);
                    MyButtons.Add(51);
                }
            }
            else if (MissionData.iBuildMode == 9)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[133]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[134]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[111]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
            }
            else if (MissionData.iBuildMode == 10)
            {
                if (iPart == 1)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[135]);

                    MyButtons.Add(37);
                    MyButtons.Add(21);
                }
                else if (iPart == 2)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[136]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
                else if (iPart == 3)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[137]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[138]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
                else if (iPart == 4)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add(DataStore.MyLang.Othertext[137]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[139]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                    MyButtons.Add(23);
                }
                else if (iPart == 5)
                {
                    MyInstructions.Add("+");
                    MyInstructions.Add(DataStore.MyLang.Othertext[102]);
                    MyInstructions.Add("( " + DataStore.MyLang.Othertext[139]);

                    MyButtons.Add(37);
                    MyButtons.Add(22);
                    MyButtons.Add(21);
                }
            }
            BaseHelpBar(MyButtons, MyInstructions);
        }
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
                    RWDatFile.SaveDat(9, DataStore.MyDatSet.iNSPMBank);
                    DataStore.bBankTransfer = false;
                    DataStore.iCoinBats = 0;
                }
            }
            else
                UiDisplay.ControlerUI("Yacht Price = " + ReturnStuff.ShowComs(DataStore.MySettings.YachtPrice, true, true) + DataStore.MyLang.Context[30], 1);

            if (Game.IsControlPressed(2, GTA.Control.Detonate))
            {
                if (DataStore.iCoinBats == 4)
                    ObjectHand.NSCoinCount(false, 1);
                else
                    ObjectHand.NSCoinCount(false, DataStore.iCoinBats);
            }
            else if (Game.IsControlPressed(2, GTA.Control.Context))
            {
                if (DataStore.iCoinBats == 4)
                    ObjectHand.NSCoinCount(true, 1);
                else
                    ObjectHand.NSCoinCount(true, DataStore.iCoinBats);
            }
            else if (Game.IsControlPressed(2, GTA.Control.Jump))
            {
                if (DataStore.iCoinBats != 4)
                {
                    DataStore.bBankTransfer = false;
                    DataStore.iCoinBats = 0;
                }
            }
            else
            {
                ObjectHand.iFaster_01 = Game.GameTime + 4000;
                ObjectHand.iFaster_02 = Game.GameTime + 15000;
                ObjectHand.iFaster_03 = Game.GameTime + 25000;
            }
        }
        //private void OnKeyDown(object sender, KeyEventArgs e)
        //{
         //   if (e.KeyCode == Keys.K)
        //}
    }
}
