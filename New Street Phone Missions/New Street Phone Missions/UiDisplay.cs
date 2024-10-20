using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace New_Street_Phone_Missions
{
    public class UiDisplay : Script
    {
        public static string sSubDisplay { get; set; }
        public static bool bSubDisplay { get; set; }

        public static SideBar GetBackInVeh { get; set; }

        public static List<SideBar> SideBars { get; set; }
        public static bool bUiDisplay { get; set; }

        public static MarkyMark MMDisplay01 { get; set; }
        public static bool bMMDisplay01 { get; set; }

        public static MarkyMark MMDisplay02 { get; set; }
        public static bool bMMDisplay02 { get; set; }

        public static Ped FolPed { get; set; }

        private static Vector3 JustHere { get; set; }

        public static List<ISeeYou> SpotedList { get; set; }

        private float fBob = 2.00f;
        private bool bBob = false;
        private int iBob = 0;
        private static int SpookTime = 0;
        private static int FlashTime = 0;
        private static bool BarFlash = false;

        public UiDisplay()
        {
            sSubDisplay = "";
            SideBars = new List<SideBar>();
            SpotedList = new List<ISeeYou>();
            bSubDisplay = false;
            bUiDisplay = false;
            bMMDisplay01 = false;
            bMMDisplay02 = false;
            GetBackInVeh = null;
            FolPed = null;
            Tick += OnTick;
            Interval = 1;
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (SpotedList.Count > 0)
                SpotDisplay();
            else if (bUiDisplay)
                BarDisplay();

            if (bMMDisplay01)
            {
                if (MMDisplay01 != null)
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
                else
                    bMMDisplay01 = false;
            }

            if (bMMDisplay02)
            {
                if (MMDisplay02 != null)
                    World.DrawMarker(MMDisplay02.MarkType, MMDisplay02.MarkPos, MMDisplay02.MarkDir, MMDisplay02.MarkRot, MMDisplay02.MarkScale, MMDisplay02.MarkCol);
                else
                    bMMDisplay02 = false;
            }

            if (bSubDisplay)
                StickySubTitle(sSubDisplay);

            if (GetBackInVeh != null)
                DrawBars(GetBackInVeh, SideBars.Count * 10);
        }
        private void StickySubTitle(string sTing)
        {
            Function.Call(Hash.SET_TEXT_FONT, 0);
            Function.Call(Hash.SET_TEXT_SCALE, 0.55f, 0.55f);
            Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);//white
            Function.Call(Hash.SET_TEXT_CENTRE, true); //
            Function.Call(Hash.SET_TEXT_DROPSHADOW, 4, 0, 0, 0, 255);//Dunknow--changed last 255 to 0
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
        private static int LoadShard(int iDuration, string mainTitle, string subTitle, int iColour)
        {
            int iShard = Function.Call<int>((Hash)0x11FE353CF9733E6F, "MIDSIZED_MESSAGE");

            Script.Wait(500);
            while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, iShard))
                Script.Wait(1);

            Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 8500, false);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iShard, "SHOW_SHARD_MIDSIZED_MESSAGE");
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call((Hash)0x6C188BE134E074AA, mainTitle);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call((Hash)0x6C188BE134E074AA, subTitle);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, iColour);// color 0,1=white 2=black 3=grey 6,7,8=red 9,10,11=blue 12,13,14=yellow 15,16,17=orange 18,19,20=green 21,22,23=purple 
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

            return iShard;
        }
        public static void BigMessFail(string mainTitle)
        {
            LoggerLight.LogThis("BigMessFai");

            int iBanner = LoadShard(8500, mainTitle, "", 8);

            int iWait = Game.GameTime + 8000;

            while (iWait > Game.GameTime)
            {
                Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, iBanner, 255, 255, 255, 255);
                Script.Wait(1);
            }

            unsafe
            {
                int SF = iBanner;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        public static void CountDownTime(string Numb, int Col, bool bTrafficOff)
        {
            LoggerLight.LogThis("CountDownTime");

            int iScale = Function.Call<int>((Hash)0x11FE353CF9733E6F, "COUNTDOWN");

            while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, iScale))
                Script.Wait(1);

            Function.Call(Hash._START_SCREEN_EFFECT, "SuccessNeutral", 4500, false);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, iScale, "SET_MESSAGE");
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.50f);
            Function.Call((Hash)0x6C188BE134E074AA, Numb);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, Col);// color 0,1=white 2=black 3=grey 6,7,8=red 9,10,11=blue 12,13,14=yellow 15,16,17=orange 18,19,20=green 21,22,23=purple 
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

            int iWait = Game.GameTime + 1000;
            Color CirC = Color.FromArgb(241, 247, 57); 
            var w = Convert.ToInt32(UIMenu.GetScreenResolutionMaintainRatio().Width / 2);
            var h = Convert.ToInt32(UIMenu.GetScreenResolutionMaintainRatio().Height / 2);
            if (Col == 20)
                CirC = Color.FromArgb(49, 235, 126);

            Sprite _fadeoutSprite = new Sprite("mpinventory", "in_world_circle", new Point(w - 125, h - 125), new Size(250, 250), 0f, CirC);

            while (iWait > Game.GameTime)
            {
                _fadeoutSprite.Draw();
                Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, iScale, 255, 255, 255, 255);

                if (bTrafficOff)
                    EntityClear.ClearTheWay(true, false);

                Script.Wait(1);
            }

            unsafe
            {
                int SF = iScale;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        public static void CountDownDisplay(bool bTrafficOff)
        {
            CountDownTime("3", 14, bTrafficOff);
            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
            CountDownTime("2", 14, bTrafficOff);
            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
            CountDownTime("1", 14, bTrafficOff);
            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
            CountDownTime("Go", 20, bTrafficOff);
            Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
        }
        public static void RaceStart(string mainTitle, Vehicle raceCar)
        {
            LoggerLight.LogThis("RaceStart");
            int iScale = LoadShard(0, "Race", mainTitle, 2);

            int iWait = Game.GameTime + 6000;

            while (iWait > Game.GameTime)
            {
                if (raceCar != null)
                    MissionData.cCams.Position = raceCar.Position + (raceCar.ForwardVector * 4.00f) + (raceCar.UpVector * 1.50f);

                Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, iScale, 255, 255, 255, 255);
                Script.Wait(1);
            }

            unsafe
            {
                int SF = iScale;
                Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &SF);
            }
        }
        public static void RaceTypeIcon(int iSprite)
        {
            SizeF screenSize = GetScreenResolution();
            int along = Convert.ToInt32(screenSize.Width / 48);
            int down = Convert.ToInt32(screenSize.Height / 9) + 5;
            Point safezone = new Point(along, down);

            if (iSprite == 1)
                AddSprite("mpcarhud", "transport_bike_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
            else if (iSprite == 2)
                AddSprite("mpcarhud", "transport_bicycle_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
            else if (iSprite == 3)
                AddSprite("mpcarhud", "transport_boat_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
            else if (iSprite == 4)
                AddSprite("mpcarhud", "transport_heli_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
            else if (iSprite == 5)
                AddSprite("mpcarhud", "transport_plane_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
            else
                AddSprite("mpcarhud", "transport_car_icon", safezone, new Size(32, 32), 0f, new RGBA(85));
        }
        public static void MissionStatus(AchList MyAchive)
        {
            SizeF res = GetScreenResolution();
            int middle = Convert.ToInt32(res.Width / 2);

            AddSprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(res.Width), 450 + (MyAchive.MyAch.Count * 40)), 0f, new RGBA(200, 255, 255, 255));
            AddText(MyAchive.Mission, new Point(middle, 230), 0.5f, new RGBA(255, 255, 255, 255), 0, 3);
            DrawBox(new Point(middle - 300, 290), new Size(600, 2), new RGBA(255, 255, 255, 255));
            for (int i = 0; i < MyAchive.MyAch.Count; i++)
            {
                AddText(MyAchive.MyAch[i].Name, new Point(middle - 230, 300 + (40 * i)), 0.35f, new RGBA(255, 255, 255, 255), 0, 1);
                AddText("  " + MyAchive.MyAch[i].Descrition, new Point(middle - 230, 320 + (40 * i)), 0.25f, new RGBA(255, 255, 255, 255), 0, 1);
                AddText(MyAchive.MyAch[i].Value, new Point(middle + 230, 300 + (40 * i)), 0.35f, new RGBA(255, 255, 255, 255), 0, 2);

                string spriteName = "shop_box_blank";
                if (MyAchive.MyAch[i].TickBox == 1)
                    spriteName = "shop_box_cross";
                AddSprite("commonmenu", spriteName, new Point(middle + 230, 290 + (40 * i)), new Size(48, 48), 0, new RGBA(255, 255, 255, 255));
            }
            DrawBox(new Point(middle - 300, 300 + (40 * MyAchive.MyAch.Count)), new Size(600, 2), new RGBA(255, 255, 255, 255));
            AddText("Completion", new Point(middle - 150, 320 + (40 * MyAchive.MyAch.Count)), 0.5f, new RGBA(71), 7, 2);
            AddText(MyAchive.Percent + "%", new Point(middle + 150, 320 + (40 * MyAchive.MyAch.Count)), 0.4f, new RGBA(255, 255, 255, 255), 0, 2);

            string medalSprite = "bronzemedal";
            if (MyAchive.Medal == 1)
                medalSprite = "goldmedal";
            else if (MyAchive.Medal == 2)
                medalSprite = "silvermedal";

            AddSprite("mpmissionend", medalSprite, new Point(middle + 150, 320 + (40 * MyAchive.MyAch.Count)), new Size(32, 32), 0f, new RGBA(71));
        }
        public static void MissionPassed(AchList MyAchive)
        {
            SizeF res = GetScreenResolution();
            int middle = Convert.ToInt32(res.Width / 2);
            int iWait = Game.GameTime + 8000;
            int iColour = 5;
            string mainTitle = "mission passed";
            if (MyAchive.Goranga)
            {
                iColour = 15;
                mainTitle = "GOURANGA!";
            }
            while (iWait > Game.GameTime)
            {
                AddSprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(res.Width), 450 + (MyAchive.MyAch.Count * 40)), 0f, new RGBA(200, 255, 255, 255));
                AddText(mainTitle, new Point(middle, 100), 2.5f, new RGBA(iColour), 7, 3);
                AddText(MyAchive.Mission, new Point(middle, 230), 0.5f, new RGBA(255,255,255,255), 0, 3);
                DrawBox(new Point(middle - 300, 290), new Size(600, 2), new RGBA(255,255,255,255));
                if (DataStore.MySettings.AchiveMents)
                {
                    for (int i = 0; i < MyAchive.MyAch.Count; i++)
                    {
                        AddText(MyAchive.MyAch[i].Name, new Point(middle - 230, 300 + (40 * i)), 0.35f, new RGBA(255, 255, 255, 255), 0, 1);
                        AddText("  " + MyAchive.MyAch[i].Descrition, new Point(middle - 230, 320 + (40 * i)), 0.25f, new RGBA(255, 255, 255, 255), 0, 1);
                        AddText(MyAchive.MyAch[i].Value, new Point(middle + 230, 300 + (40 * i)), 0.35f, new RGBA(255, 255, 255, 255), 0, 2);

                        if (MyAchive.MyAch[i].TickBox != 3)
                        {
                            string spriteName = "shop_box_blank";
                            if (MyAchive.MyAch[i].TickBox == 1)
                                spriteName = "shop_box_cross";
                            AddSprite("commonmenu", spriteName, new Point(middle + 230, 290 + (40 * i)), new Size(48, 48), 0, new RGBA(255, 255, 255, 255));
                        }
                    }
                    DrawBox(new Point(middle - 300, 300 + (40 * MyAchive.MyAch.Count)), new Size(600, 2), new RGBA(255, 255, 255, 255));
                    AddText("Completion", new Point(middle - 150, 320 + (40 * MyAchive.MyAch.Count)), 0.5f, new RGBA(71), 7, 2);
                    AddText(MyAchive.Percent + "%", new Point(middle + 150, 320 + (40 * MyAchive.MyAch.Count)), 0.4f, new RGBA(255, 255, 255, 255), 0, 2);

                    string medalSprite = "bronzemedal";
                    if (MyAchive.Medal == 1)
                        medalSprite = "goldmedal";
                    else if (MyAchive.Medal == 2)
                        medalSprite = "silvermedal";

                    AddSprite("mpmissionend", medalSprite, new Point(middle + 150, 320 + (40 * MyAchive.MyAch.Count)), new Size(32, 32), 0f, new RGBA(71));
                }

                Script.Wait(1);
            }
            NSBanking.YourCoinPopUp(MyAchive.Cash, 1, MyAchive.Mission);
        }
        private static SizeF GetScreenResolution()
        {
            int width = Game.ScreenResolution.Width;
            int height = Game.ScreenResolution.Height;
            float num = (float)width / (float)height;
            return new SizeF(1080f * num, 1080f);
        }
        private static Point GetSafeZone()
        {
            double num = Math.Round(Convert.ToDouble(Function.Call<float>(Hash._0xBAF107B6BB2C97F0, new InputArgument[0])), 2);
            num = num * 100.0 - 90.0;
            num = 10.0 - num;
            int width = Game.ScreenResolution.Width;
            int height = Game.ScreenResolution.Height;
            float num2 = (float)width / (float)height * 5.4f;
            return new Point((int)Math.Round(num * (double)num2), (int)Math.Round(num * 5.4000000953674316));
        }
        private static void SetFont(int iFont, bool dropShadow, bool outline)
        {
            //ChaletLondon = 0,
            //HouseScript = 1,
            //Monospace = 2,
            //ChaletComprimeCologne = 4,
            //Pricedown = 7
            Function.Call(Hash.SET_TEXT_FONT, iFont);
            if (dropShadow)
            {
                Function.Call(Hash._0x1CA3E9EAC9D93E5E);
            }

            if (outline)
            {
                Function.Call(Hash._0x2513DFB0FB8400FE);
            }
        }
        private static void AddSprite(string spriteLocation, string spriteName, Point position, Size size, float heading, RGBA myRGB)
        {
            if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, spriteLocation))
                Function.Call(Hash._0xDFA2EF8E04127DD5, spriteLocation, true);

            int iWidth = Game.ScreenResolution.Width;
            int iHeight = Game.ScreenResolution.Height;
            float num = (float)iWidth / (float)iHeight;
            float num2 = 1080f * num;
            float width = (float)size.Width / num2;
            float height = (float)size.Height / 1080f;
            float screenX = (float)position.X / num2 + width * 0.5f;
            float screenY = (float)position.Y / 1080f + height * 0.5f;
            Function.Call(Hash._0xE7FFAE5EBF23D890, spriteLocation, spriteName, screenX, screenY, width, height, heading, myRGB.R, myRGB.G, myRGB.B, myRGB.A);
        }
        private static void DrawBox(Point OnPoint, Size IsSizeint, RGBA color)
        {
            int width = Game.ScreenResolution.Width;
            int height = Game.ScreenResolution.Height;
            float num = (float)width / (float)height;
            float num2 = 1080f * num;
            float num3 = (float)IsSizeint.Width / num2;
            float num4 = (float)IsSizeint.Height / 1080f;
            float num5 = (float)OnPoint.X / num2 + num3 * 0.5f;
            float num6 = (float)OnPoint.Y / 1080f + num4 * 0.5f;

            Function.Call((Hash)0x3A618A217E5154F0, num5, num6, num3, num4, color.R, color.G, color.B, 255);
        }
        private static void AddText(string caption, Point position, float scale, RGBA myRGB, int font, int leftRightCenter)
        {
            int width = Game.ScreenResolution.Width;
            int height = Game.ScreenResolution.Height;
            float num = (float)width / (float)height;
            float num2 = 1080f * num;
            float num3 = (float)position.X / num2;
            float num4 = (float)position.Y / 1080f;
            Function.Call(Hash._0x66E0276CC5F6B9DA, font);
            Function.Call(Hash._0x07C837F9A01C34C9, 1f, scale);
            Function.Call(Hash._0xBE6B23FFA53FB442, myRGB.R, myRGB.G, myRGB.B, myRGB.A);
            if (leftRightCenter == 1)
                Function.Call(Hash.SET_TEXT_JUSTIFICATION, 1);
            else if (leftRightCenter == 2)
            {
                Function.Call(Hash._0x6B3C4650BC8BEE47, true);
                Function.Call(Hash._0x63145D9C883A1A70, 0, num3);
            }
            else
                Function.Call(Hash._0xC02F4DBFB51D988B, true);

            Function.Call(Hash._0x25FBB336DF1804CB, "jamyfafi");
            Function.Call(Hash._0x6C188BE134E074AA, caption);
            Function.Call(Hash._0xCD015E5BB0D96A57, num3, num4);
        }
        private static void BarDisplay()
        {
            for (int i = 0; i < SideBars.Count; i++)
                DrawBars(SideBars[i], i * 10);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 6);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 7);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 9);
        }
        private static void SpotDisplay()
        {
            for (int i = 0; i < SpotedList.Count; i++)
                DrawBars(SpotedList[i].YouSee, i * 10);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 6);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 7);
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, 9);
        }
        private static void DrawBars(SideBar mySide, int Spacing)
        {
            SizeF screenSize = GetScreenResolution();
            Point safezone = GetSafeZone();

            AddText(mySide.Name, new Point((int)screenSize.Width - safezone.X - 180, (int)screenSize.Height - safezone.Y - (30 + 4 * Spacing)), 0.3f, new RGBA(255, 255, 255, 255), 0, 2);
            Point MyPointIs = new Point((int)screenSize.Width - safezone.X - 298, (int)screenSize.Height - safezone.Y - (40 + 4 * Spacing));
            Size MySizeIs = new Size(300, 37);
            AddSprite("timerbars", "all_black_bg", MyPointIs, MySizeIs, 0f, new RGBA(180, 255, 255, 255));

            if (mySide.Scale)
            {
                Point PlaceHere = new Point((int)screenSize.Width - safezone.X - 160, (int)screenSize.Height - safezone.Y - (28 + 4 * Spacing));
                DrawBox(PlaceHere, new Size(150, 15), mySide.Backing);
                DrawBox(PlaceHere, new Size((int)(150f * mySide.Percent), 15), mySide.SlideBar);
            }
            else
            {
                if (mySide.Counter.Count == 0)
                    AddText(mySide.Data, new Point((int)screenSize.Width - safezone.X - 10, (int)screenSize.Height - safezone.Y - (42 + 4 * Spacing)), 0.5f, new RGBA(255,255,255,255), 0, 2);
                else
                {
                    AddText(mySide.Counter[0], new Point((int)screenSize.Width - safezone.X - 85, (int)screenSize.Height - safezone.Y - (42 + 4 * Spacing)), 0.5f, new RGBA(255, 255, 255, 255), 0, 2);
                    AddText(mySide.Counter[1], new Point((int)screenSize.Width - safezone.X - 45, (int)screenSize.Height - safezone.Y - (42 + 4 * Spacing)), 0.5f, new RGBA(255, 255, 255, 255), 0, 2);
                    AddText(mySide.Counter[2], new Point((int)screenSize.Width - safezone.X - 10, (int)screenSize.Height - safezone.Y - (42 + 4 * Spacing)), 0.5f, new RGBA(255, 255, 255, 255), 0, 2);
                }
            }
        }
        public static bool SpookBarz(Vehicle Target, int iBar, bool TooClose)
        {
            bool bSpooked = false;
            float fBarLine = World.GetDistance(Game.Player.Character.Position, Target.Position) / 100.00f;// Find the percent for Spookbar float 0.00 to 1.00
            fBarLine = 1.00f - fBarLine;
            if (fBarLine < 0.01f)
                fBarLine = 0.01f;

            if (ReturnStuff.AmINear(Target.Position, 125f))   // Distance tracking for Spookbar
            {
                if (fBarLine > 0.75f)  // test if too close to target
                {
                    if (TooClose)
                    {
                        if (SpookTime == 0)
                        {
                            SpookTime = Game.GameTime + 20000;
                            Target.CurrentBlip.IsFlashing = true;
                        }
                        else if (SpookTime < Game.GameTime)
                        {
                            Target.CurrentBlip.Remove();
                            NSPM.JobSeq = 101;
                        }
                        else if (FlashTime < Game.GameTime)  // too close fail.
                        {
                            FlashTime = Game.GameTime + 500;
                            if (BarFlash) // bar flash for distance warning. is a 1/2 sec toggle on off.
                            {
                                BarFlash = false;
                                SideBars[iBar].SlideBar = new RGBA(0);
                            }
                            else
                            {
                                BarFlash = true;
                                SideBars[iBar].SlideBar = new RGBA(1);
                            }
                        }
                    }
                }
                else if (SpookTime != 0)
                {
                    SpookTime = 0;      //timer for spook fail
                    FlashTime = 0;
                    BarFlash = false;
                    Target.CurrentBlip.IsFlashing = false;
                    SideBars[iBar].SlideBar = new RGBA(60);
                    SideBars[iBar].Backing = new RGBA(72);
                }
            }
            else       // if player is out side min distance
            {
                if (SpookTime == 0) // set timmer for distance fail
                {
                    Target.CurrentBlip.IsFlashing = true;
                    SpookTime = Game.GameTime + 20000;
                }
                else if (SpookTime < Game.GameTime) // fail if timmer runs out
                {
                    Target.CurrentBlip.Remove();
                    bSpooked = true;
                }
                else if (FlashTime < Game.GameTime)
                {
                    FlashTime = Game.GameTime + 500;
                    if (BarFlash) // bar flash for distance warning. is a 1/2 sec toggle on off.
                    {
                        BarFlash = false;
                        FlashTime = Game.GameTime + 500;
                        SideBars[iBar].Backing = new RGBA(0);
                    }
                    else
                    {
                        BarFlash = true;
                        SideBars[iBar].Backing = new RGBA(72);
                    }
                }
            }
            SideBars[iBar].Percent = fBarLine;

            return bSpooked;
        }
        public static float SpookBarzPed(Ped Target)
        {
            float fBarLine = World.GetDistance(Game.Player.Character.Position, Target.Position) / 100.00f;// Find the percent for Spookbar float 0.00 to 1.00
            fBarLine = 1.00f - fBarLine;
            if (fBarLine < 0.01f)
                fBarLine = 0.01f;

            if (ReturnStuff.AmINear(Target.Position, 125f))   // Distance tracking for Spookbar
            {
                if (SideBars[0].Percent > 0.85f)  // test if too close to target
                {

                    if (SpookTime == 0)
                    {
                        SpookTime = Game.GameTime + 20000;
                        Target.CurrentBlip.IsFlashing = true;
                    }
                    else if (SpookTime < Game.GameTime)
                    {
                        Target.CurrentBlip.Remove();
                        NSPM.JobSeq = 45;
                    }
                    else if (FlashTime < Game.GameTime)  // too close fail.
                    {
                        FlashTime = Game.GameTime + 500;
                        if (BarFlash) // bar flash for distance warning. is a 1/2 sec toggle on off.
                        {
                            BarFlash = false;
                            SideBars[0].SlideBar = new RGBA(0);
                        }
                        else
                        {
                            BarFlash = true;
                            SideBars[0].SlideBar = new RGBA(1);
                        }
                    }

                }
                else if (SpookTime != 0)
                {
                    SpookTime = 0;      //timer for spook fail
                    FlashTime = 0;
                    BarFlash = false;
                    Target.CurrentBlip.IsFlashing = false;
                    SideBars[0].SlideBar = new RGBA(60);
                    SideBars[0].Backing = new RGBA(72);
                }
            }
            else       // if player is out side min distance
            {
                if (SpookTime == 0) // set timmer for distance fail
                {
                    Target.CurrentBlip.IsFlashing = true;
                    SpookTime = Game.GameTime + 20000;
                }
                else if (SpookTime < Game.GameTime) // fail if timmer runs out
                {
                    Target.CurrentBlip.Remove();
                    NSPM.JobSeq = 45;
                }
                else if (FlashTime < Game.GameTime)
                {
                    FlashTime = Game.GameTime + 500;
                    if (BarFlash) // bar flash for distance warning. is a 1/2 sec toggle on off.
                    {
                        BarFlash = false;
                        FlashTime = Game.GameTime + 500;
                        SideBars[0].Backing = new RGBA(0);
                    }
                    else
                    {
                        BarFlash = true;
                        SideBars[0].Backing = new RGBA(72);
                    }
                }
            }
            return fBarLine;
        }
    }
}
