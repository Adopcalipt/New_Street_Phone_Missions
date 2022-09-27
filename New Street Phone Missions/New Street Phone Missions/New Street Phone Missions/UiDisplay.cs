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

        public static Ped FolPed { get; set; }

        private static Vector3 JustHere { get; set; }

        private float fBob = 2.00f;
        private bool bBob = false;
        private int iBob = 0;

        public UiDisplay()
        {
            MpUiDisplay = new TimerBarPool();
            ttTextBar_01 = new TextTimerBar("", "");
            ttTextBar_02 = new TextTimerBar("", "");
            ttTextBar_03 = new TextTimerBar("", "");
            ttTextBar_04 = new TextTimerBar("", "");
            BtSlideBar = new BarTimerBar("");
            FolPed = null;
            Tick += OnTick;
            //KeyDown += OnKeyDown;
            Interval = 1;
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (bMMDisplay01)
            {
                if (FolPed != null)
                {
                    if (FolPed.IsInVehicle())
                    {
                        if (iBob < Game.GameTime)
                        {
                            if (bBob)
                            {
                                if (fBob > 4.00)
                                    bBob = false;
                                fBob += 0.1f;
                            }
                            else
                            {
                                if (fBob < 2.00)
                                    bBob = true;
                                fBob -= 0.1f;
                            }
                            iBob = Game.GameTime + 100;
                        }
                        JustHere = ReturnStuff.AlterZHight(FolPed.Position, fBob);
                    }
                    else
                    {
                        if (iBob < Game.GameTime)
                        {
                            if (bBob)
                            {
                                if (fBob > 3.40)
                                    bBob = false;
                                fBob += 0.1f;
                            }
                            else
                            {
                                if (fBob < 1.20)
                                    bBob = true;
                                fBob -= 0.1f;
                            }
                            iBob = Game.GameTime + 100;
                        }
                        JustHere = ReturnStuff.AlterZHight(FolPed.Position, fBob);
                    }

                }
                else
                    JustHere = MMDisplay01.MarkPos;

                World.DrawMarker(MMDisplay01.MarkType, JustHere, MMDisplay01.MarkDir, MMDisplay01.MarkRot, MMDisplay01.MarkScale, MMDisplay01.MarkCol);
            }

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
                UiDisplay.ControlSelect(5, false);
                MissionData.iWait4Sec = Game.GameTime + 7000;
            }

            unsafe
            {
                int SF = iScale;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        private static void BigMessTime(string MainTitle, string SubTitle, int iColour, bool bCash, int iCashOut,int iScale)
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
                NSBanking.YourCoinPopUp(iCashOut, 1, "NSPM Pay");
        }
        private static void BaseHelpBar(List<int> iButtons, List<string> sInstuctions)
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
            int red = 255;
            int green = 255;
            int blue = 0;
            int alpha = 255;
            int reserved = 180;

            int ThisCheck = ObjectBuild.CheckerPoint(Vtech, Vsp, type, fRaid, red, green, blue, alpha, reserved);
            Function.Call(Hash.SET_CHECKPOINT_CYLINDER_HEIGHT, ThisCheck, fRaid / 2, fRaid / 2, fRaid);
            MissionData.iCoronaList.Add(ThisCheck);
        }
        public static void TheGreenCorona(Vector3 Vtech, float fRaid)
        {
            LoggerLight.LogThis("TheYellowCorona");

            Vector3 Vsp = new Vector3(0.00f, 0.00f, 0.00f);
            int type = 47;
            int red = 57;
            int green = 255;
            int blue = 20;
            int alpha = 255;
            int reserved = 180;

            int ThisCheck = ObjectBuild.CheckerPoint(Vtech, Vsp, type, fRaid, red, green, blue, alpha, reserved); 
            Function.Call(Hash.SET_CHECKPOINT_CYLINDER_HEIGHT, ThisCheck, fRaid / 2, fRaid / 2, fRaid);
            MissionData.iCoronaList.Add(ThisCheck);
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
        public static void ControlSelect(int iChoices, bool bPhoneAnim)
        {
            LoggerLight.LogThis("UiDisplay.ControlSelect, iChoices == " + iChoices);
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
                    ControlerUI(sDisplay, 1);

                if (iQuickPause < Game.GameTime)
                {
                    if (iChoices == 1)
                    {
                        if (sDisplay == "")
                            sDisplay = DataStore.MyLang.Context[1];

                        if (ReturnStuff.WhileButtonDown(21))
                        {
                            if (MissionData.iJobType == 11)
                            {
                                MissionData.iCurrentLap = 1;
                                iChoices = 2;
                                iQuickPause = Game.GameTime + 900;
                            }
                            else if (MissionData.iJobType == 13 || MissionData.iJobType == 104)
                            {
                                iChoices = 12;
                                sDisplay = DataStore.MyLang.Jobtext[12] + DataStore.MyLang.Context[33];
                                iQuickPause = Game.GameTime + 900;
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
                        if (MissionData.bSoloRace)
                            sDisplay = DataStore.MyLang.Context[5] + DataStore.MyLang.Context[6];
                        else
                            sDisplay = DataStore.MyLang.Context[5] + DataStore.MyLang.Context[7];

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

                            sDisplay = DataStore.MyLang.Context[2];

                            if (!bSubDisplay)
                            {
                                bSubDisplay = true;
                                sSubDisplay = DataStore.MyLang.Mistext[190];
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
                                ObjectClear.PostMess();
                            }
                        }
                    }       //Pacstandard
                    else if (iChoices == 6)
                    {
                        sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            ObjectClear.RemoveTargets();

                            for (int i = 0; i < MissionData.PedList_01.Count; i++)
                                ObjectLog.CleanUp(MissionData.PedList_01[i], false);

                            MissionData.PedList_01.Clear();
                            iChoices = 0;
                            MissionData.bMoreFubar = true;
                            MissionData.bJobLoaded = false;
                            DataStore.MyDatSet.iFubard += 1;
                            NSBanking.SaveDat(13, DataStore.MyDatSet.iFubard);
                            MissionData.iRepMisssion += 1;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            TheMissions.AreULocal();
                        }
                        else if (ReturnStuff.ButtonDown(22) || !(Game.Player.Character.IsInVehicle()))
                        {
                            MissionData.bMoreFubar = false;
                            iChoices = 0;
                            DataStore.MyDatSet.iFubard += 1;
                            NSBanking.SaveDat(13, DataStore.MyDatSet.iFubard);
                            MissionData.iRepMisssion += 1;
                            MissionData.iCashReward += MissionData.iCashBouns;
                            MissionData.iMissionSeq = 9;
                        }
                    }       //fubar
                    else if (iChoices == 7)
                    {
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
                        sDisplay = DataStore.MyLang.Context[2];

                        if (ReturnStuff.ButtonDown(21))
                        {

                            ObjectClear.ClearOutAllStuff();

                            for (int i = 0; i < MissionData.iFireList.Count; i++)
                                ObjectLog.CleanUp(-1, -1, MissionData.iFireList[i]);

                            MissionData.iFireList.Clear();
                            ObjectClear.RemoveTargets();
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
                                NSBanking.YourCoinPopUp(DataStore.MySettings.YachtPrice, 1, "Yacht Purchased");
                                DataStore.MyDatSet.iOwnaYacht = DataStore.iProcessForYacht;
                                DataStore.MyAssets.OwnaYacht = true;
                                DataStore.MySettings.YachtPrice = 0;
                                NSBanking.SaveDat(0, DataStore.iProcessForYacht);
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
                                    TheMissions.SlowFastTravel(Vpos, 165.84f);
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
                            DataStore.MyAssets.OwnaYacht = false;
                            DataStore.MyDatSet.iOwnaYacht = 0;
                            if (!MissionData.VehTrackin_01.IsDead)
                                ObjectBuild.WarptoAnyVeh(MissionData.VehTrackin_01, Game.Player.Character, 1);
                            else
                            {
                                Vector3 Vpos = new Vector3(-1848.826f, -1200.298f, 19.14339f);
                                TheMissions.SlowFastTravel(Vpos, 165.84f);
                            }
                            if (MissionData.bOldYacht)
                                TheMissions.Water02_AddHeistYacht(false);
                            ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
                        }
                    }      //Yacht
                    else if (iChoices == 11)
                    {
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
                            DressinRoom.PedDresser(Game.Player.Character, ReadWriteXML.LoadXmlClothDefault(DataStore.sDefaulted));
                            NSBanking.NSCoinInvestments(true, 5, 7, "Deliverwho");
                            TheMissions.GameOver(false, "", false, MissionData.iCashReward);
                        }
                    }       //Delliverwho
                    else if (iChoices == 12)
                    {
                        if (MissionData.bSnipers)
                            sDisplay = DataStore.MyLang.Jobtext[91] + DataStore.MyLang.Context[33];
                        else
                            sDisplay = DataStore.MyLang.Jobtext[12] + DataStore.MyLang.Context[33];

                        if (ReturnStuff.ButtonDown(21))
                        {
                            iChoices = 0;
                            MissionData.iJobType = 13;
                            TheMissions.PlayerPlays();
                        }
                        else if (ReturnStuff.ButtonDown(51))
                        {
                            MissionData.bSnipers = !MissionData.bSnipers;
                            iQuickPause = Game.GameTime + 500;
                        }
                    }      //sniper
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
                        bSubDisplay = false;
                        bSelecta = false;
                    }
                }
                Script.Wait(1);
            }
            LoggerLight.LogThis("UiDisplay.ControlSelect End, iChoices == " + iChoices);
        }
        public static void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        //private void OnKeyDown(object sender, KeyEventArgs e)
        //{
        //   if (e.KeyCode == Keys.K)
        //}
    }
}
