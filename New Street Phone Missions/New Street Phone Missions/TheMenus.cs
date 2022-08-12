using GTA;
using NativeUI;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class TheMenus
    {
        public static MenuPool YtmenuPool = new MenuPool();

        public static void SettingsMenu(bool JustCustoms)
        {
            LoggerLight.LogThis("SettingsMenu");

            var mainMenu = new UIMenu("NSPM", DataStore.MyLang.Othertext[56]);

            YtmenuPool.Add(mainMenu);
            if (JustCustoms)
            {
                AddCustomVehcis(mainMenu);
            }
            else
            {
                MissionSelectSet(mainMenu);
                SettingsSet(mainMenu);
                if (DataStore.bTrainM)
                    MishconBuild(mainMenu);
            }

            DataStore.bOptionsMen = true;
            DataStore.bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void AddCustomVehcis(UIMenu XMen)
        {
            var SubHeadder = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.Othertext[57]);
            var Submenu_01 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.Othertext[58]);
            var Submenu_02 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.Othertext[59]);
            var Submenu_03 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.Othertext[60]);
            var Submenu_04 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.Othertext[61]);

            List<string> sub_01 = new List<string>();
            List<string> sub_02 = new List<string>();
            List<string> sub_03 = new List<string>();
            List<string> sub_04 = new List<string>();

            var AddCar = new UIMenuItem(DataStore.MyLang.Othertext[62], "");
            Submenu_01.AddItem(AddCar);

            var AddPlanz = new UIMenuItem(DataStore.MyLang.Othertext[63], "");
            Submenu_02.AddItem(AddPlanz);

            var AddBoatz = new UIMenuItem(DataStore.MyLang.Othertext[64], "");
            Submenu_03.AddItem(AddBoatz);

            var AddHeli = new UIMenuItem(DataStore.MyLang.Othertext[65], "");
            Submenu_04.AddItem(AddHeli);

            for (int i = 0; i < DataStore.MyCusVeh.MyCarz.Count; i++)
            {
                int iAmVeh = ReturnStuff.WhatVehicleAreYou(DataStore.MyCusVeh.MyCarz[i]);

                if (iAmVeh == 0)
                    DataStore.MyCusVeh.MyCarz.RemoveAt(i);
                else if (iAmVeh == 1)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyCarz[i]), "Remove from list");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(DataStore.MyCusVeh.MyCarz[i]);
                }
                else if (iAmVeh == 2)
                {
                    DataStore.MyCusVeh.MyPlanez.Add(DataStore.MyCusVeh.MyCarz[i]);
                    DataStore.MyCusVeh.MyCarz.RemoveAt(i);
                }
                else if (iAmVeh == 3)
                {
                    DataStore.MyCusVeh.MyBoatz.Add(DataStore.MyCusVeh.MyCarz[i]);
                    DataStore.MyCusVeh.MyCarz.RemoveAt(i);
                }
                else if (iAmVeh == 4)
                {
                    DataStore.MyCusVeh.MyChopperz.Add(DataStore.MyCusVeh.MyCarz[i]);
                    DataStore.MyCusVeh.MyCarz.RemoveAt(i);
                }
            }

            for (int i = 0; i < DataStore.MyCusVeh.MyPlanez.Count; i++)
            {
                int iAmVeh = ReturnStuff.WhatVehicleAreYou(DataStore.MyCusVeh.MyPlanez[i]);

                if (iAmVeh == 0)
                    DataStore.MyCusVeh.MyPlanez.RemoveAt(i);
                else if (iAmVeh == 1)
                {
                    DataStore.MyCusVeh.MyCarz.Add(DataStore.MyCusVeh.MyPlanez[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyPlanez[i]), "Remove from list");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(DataStore.MyCusVeh.MyPlanez[i]);
                    DataStore.MyCusVeh.MyPlanez.RemoveAt(i);
                }
                else if (iAmVeh == 2)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyPlanez[i]), "Remove from list");
                    Submenu_02.AddItem(item_);
                    sub_02.Add(DataStore.MyCusVeh.MyPlanez[i]);
                }
                else if (iAmVeh == 3)
                {
                    DataStore.MyCusVeh.MyBoatz.Add(DataStore.MyCusVeh.MyPlanez[i]);
                    DataStore.MyCusVeh.MyPlanez.RemoveAt(i);
                }
                else if (iAmVeh == 4)
                {
                    DataStore.MyCusVeh.MyChopperz.Add(DataStore.MyCusVeh.MyPlanez[i]);
                    DataStore.MyCusVeh.MyPlanez.RemoveAt(i);
                }
            }

            for (int i = 0; i < DataStore.MyCusVeh.MyBoatz.Count; i++)
            {
                int iAmVeh = ReturnStuff.WhatVehicleAreYou(DataStore.MyCusVeh.MyBoatz[i]);

                if (iAmVeh == 0)
                    DataStore.MyCusVeh.MyBoatz.RemoveAt(i);
                else if (iAmVeh == 1)
                {
                    DataStore.MyCusVeh.MyCarz.Add(DataStore.MyCusVeh.MyBoatz[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyBoatz[i]), "Remove from list");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(DataStore.MyCusVeh.MyBoatz[i]);

                    DataStore.MyCusVeh.MyBoatz.RemoveAt(i);
                }
                else if (iAmVeh == 2)
                {
                    DataStore.MyCusVeh.MyPlanez.Add(DataStore.MyCusVeh.MyBoatz[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyBoatz[i]), "Remove from list");
                    Submenu_02.AddItem(item_);
                    sub_02.Add(DataStore.MyCusVeh.MyBoatz[i]);

                    DataStore.MyCusVeh.MyBoatz.RemoveAt(i);
                }
                else if (iAmVeh == 3)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyBoatz[i]), "Remove from list");
                    Submenu_03.AddItem(item_);
                    sub_03.Add(DataStore.MyCusVeh.MyBoatz[i]);
                }
                else if (iAmVeh == 4)
                {
                    DataStore.MyCusVeh.MyChopperz.Add(DataStore.MyCusVeh.MyBoatz[i]);
                    DataStore.MyCusVeh.MyBoatz.RemoveAt(i);
                }
            }

            for (int i = 0; i < DataStore.MyCusVeh.MyChopperz.Count; i++)
            {
                int iAmVeh = ReturnStuff.WhatVehicleAreYou(DataStore.MyCusVeh.MyChopperz[i]);

                if (iAmVeh == 0)
                    DataStore.MyCusVeh.MyChopperz.RemoveAt(i);
                else if (iAmVeh == 1)
                {
                    DataStore.MyCusVeh.MyCarz.Add(DataStore.MyCusVeh.MyChopperz[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyChopperz[i]), "Remove from list");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(DataStore.MyCusVeh.MyChopperz[i]);

                    DataStore.MyCusVeh.MyChopperz.RemoveAt(i);
                }
                else if (iAmVeh == 2)
                {
                    DataStore.MyCusVeh.MyPlanez.Add(DataStore.MyCusVeh.MyChopperz[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyChopperz[i]), "Remove from list");
                    Submenu_02.AddItem(item_);
                    sub_02.Add(DataStore.MyCusVeh.MyChopperz[i]);

                    DataStore.MyCusVeh.MyChopperz.RemoveAt(i);
                }
                else if (iAmVeh == 3)
                {
                    DataStore.MyCusVeh.MyBoatz.Add(DataStore.MyCusVeh.MyChopperz[i]);
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyChopperz[i]), "Remove from list");
                    Submenu_03.AddItem(item_);
                    sub_03.Add(DataStore.MyCusVeh.MyChopperz[i]);

                    DataStore.MyCusVeh.MyChopperz.RemoveAt(i);
                }
                else if (iAmVeh == 4)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyCusVeh.MyChopperz[i]), "Remove from list");
                    Submenu_04.AddItem(item_);
                    sub_04.Add(DataStore.MyCusVeh.MyChopperz[i]);
                }
            }

            Submenu_01.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddCar)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                        DataStore.MyCusVeh.MyCarz.Add(sName);
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                {
                    DataStore.MyCusVeh.MyCarz.Remove(sub_01[index - 1]);
                }
                AddNewCustoms();
                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                SettingsMenu(true);
            };

            Submenu_02.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddPlanz)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                        DataStore.MyCusVeh.MyPlanez.Add(sName);
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                {
                    DataStore.MyCusVeh.MyPlanez.Remove(sub_02[index - 1]);
                }
                AddNewCustoms();
                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                SettingsMenu(true);
            };

            Submenu_03.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddBoatz)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                        DataStore.MyCusVeh.MyBoatz.Add(sName);
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                {
                    DataStore.MyCusVeh.MyBoatz.Remove(sub_03[index - 1]);
                }
                AddNewCustoms();
                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                SettingsMenu(true);
            };

            Submenu_04.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddHeli)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                        DataStore.MyCusVeh.MyChopperz.Add(sName);
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                {
                    DataStore.MyCusVeh.MyChopperz.Remove(sub_04[index - 1]);
                }
                AddNewCustoms();
                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                SettingsMenu(true);
            };
        }
        private static void MissionSelectSet(UIMenu XMen)
        {
            var Selectmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.Othertext[66]);

            for (int i = 0; i < 1; i++) ;
            var Rand_01 = new UIMenuItem(DataStore.MyLang.Jobtext[0], "");
            if (DataStore.MySettings.Truckin)
                Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_02 = new UIMenuItem(DataStore.MyLang.Jobtext[1], "");
            if (DataStore.MySettings.Getaway)
                Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_03 = new UIMenuItem(DataStore.MyLang.Jobtext[2], "");
            if (DataStore.MySettings.Packages)
                Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_04 = new UIMenuItem(DataStore.MyLang.Jobtext[3], "");
            if (DataStore.MySettings.Convicts)
                Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_05 = new UIMenuItem(DataStore.MyLang.Jobtext[4], "");
            if (DataStore.MySettings.FUber)
                Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_06 = new UIMenuItem(DataStore.MyLang.Jobtext[5], "");
            if (DataStore.MySettings.Pilot)
                Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_07 = new UIMenuItem(DataStore.MyLang.Jobtext[6], "");
            if (DataStore.MySettings.Amulance)
                Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_08 = new UIMenuItem(DataStore.MyLang.Jobtext[7], "");
            if (DataStore.MySettings.Follow)
                Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_09 = new UIMenuItem(DataStore.MyLang.Jobtext[8], "");
            if (DataStore.MySettings.LSFD)
                Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_10 = new UIMenuItem(DataStore.MyLang.Jobtext[9], "");
            if (DataStore.MySettings.Johnny)
                Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_11 = new UIMenuItem(DataStore.MyLang.Jobtext[10], "");
            if (DataStore.MySettings.Raceist)
                Rand_11.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_12 = new UIMenuItem(DataStore.MyLang.Jobtext[11], "");
            if (DataStore.MySettings.BBBomb)
                Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_13 = new UIMenuItem(DataStore.MyLang.Jobtext[12], "");
            if (DataStore.MySettings.Assassination)
                Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_14 = new UIMenuItem(DataStore.MyLang.Jobtext[13], "");
            if (DataStore.MySettings.Gruppe6)
                Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_15 = new UIMenuItem(DataStore.MyLang.Jobtext[14], "");
            if (DataStore.MySettings.Sailor)
                Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_16 = new UIMenuItem(DataStore.MyLang.Jobtext[15], "");
            if (DataStore.MySettings.ImportantEx)
                Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_17 = new UIMenuItem(DataStore.MyLang.Jobtext[16], "");
            if (DataStore.MySettings.DebtCollect)
                Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_18 = new UIMenuItem(DataStore.MyLang.Jobtext[17], "");
            if (DataStore.MySettings.MCBusiness)
                Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_19 = new UIMenuItem(DataStore.MyLang.Jobtext[18], "");
            if (DataStore.MySettings.BayLift)
                Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_20 = new UIMenuItem(DataStore.MyLang.Jobtext[19], "");
            if (DataStore.MySettings.Sharks)
                Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_21 = new UIMenuItem(DataStore.MyLang.Jobtext[20], "");
            if (DataStore.MySettings.HappyShopper)
                Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_22 = new UIMenuItem(DataStore.MyLang.Jobtext[21], "");
            if (DataStore.MySettings.MoresMute)
                Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_23 = new UIMenuItem(DataStore.MyLang.Jobtext[22], "");
            if (DataStore.MySettings.TempJob)
                Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_24 = new UIMenuItem(DataStore.MyLang.Jobtext[23], "");
            if (DataStore.MySettings.ParaDisplay)
                Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_25 = new UIMenuItem(DataStore.MyLang.Jobtext[24], "");
            if (DataStore.MySettings.Deliverwho)
                Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            Selectmenu.AddItem(Rand_01);
            Selectmenu.AddItem(Rand_02);
            Selectmenu.AddItem(Rand_03);
            Selectmenu.AddItem(Rand_04);
            Selectmenu.AddItem(Rand_05);
            Selectmenu.AddItem(Rand_06);
            Selectmenu.AddItem(Rand_07);
            Selectmenu.AddItem(Rand_08);
            Selectmenu.AddItem(Rand_09);
            Selectmenu.AddItem(Rand_10);
            Selectmenu.AddItem(Rand_11);
            Selectmenu.AddItem(Rand_12);
            Selectmenu.AddItem(Rand_13);
            Selectmenu.AddItem(Rand_14);
            Selectmenu.AddItem(Rand_15);
            Selectmenu.AddItem(Rand_16);
            Selectmenu.AddItem(Rand_17);
            Selectmenu.AddItem(Rand_18);
            Selectmenu.AddItem(Rand_19);
            Selectmenu.AddItem(Rand_20);
            Selectmenu.AddItem(Rand_21);
            Selectmenu.AddItem(Rand_22);
            Selectmenu.AddItem(Rand_23);
            Selectmenu.AddItem(Rand_24);
            Selectmenu.AddItem(Rand_25);

            Selectmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    DataStore.MySettings.Truckin = !DataStore.MySettings.Truckin;
                    if (DataStore.MySettings.Truckin)
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_02)
                {
                    DataStore.MySettings.Getaway = !DataStore.MySettings.Getaway;
                    if (DataStore.MySettings.Getaway)
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_03)
                {
                    DataStore.MySettings.Packages = !DataStore.MySettings.Packages;
                    if (DataStore.MySettings.Packages)
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_04)
                {
                    DataStore.MySettings.Convicts = !DataStore.MySettings.Convicts;
                    if (DataStore.MySettings.Convicts)
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_05)
                {
                    DataStore.MySettings.FUber = !DataStore.MySettings.FUber;
                    if (DataStore.MySettings.FUber)
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_06)
                {
                    DataStore.MySettings.Pilot = !DataStore.MySettings.Pilot;
                    if (DataStore.MySettings.Pilot)
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_07)
                {
                    DataStore.MySettings.Amulance = !DataStore.MySettings.Amulance;
                    if (DataStore.MySettings.Amulance)
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_08)
                {
                    DataStore.MySettings.Follow = !DataStore.MySettings.Follow;
                    if (DataStore.MySettings.Follow)
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_09)
                {
                    DataStore.MySettings.LSFD = !DataStore.MySettings.LSFD;
                    if (DataStore.MySettings.LSFD)
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_10)
                {
                    DataStore.MySettings.Johnny = !DataStore.MySettings.Johnny;
                    if (DataStore.MySettings.Johnny)
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_11)
                {
                    DataStore.MySettings.Raceist = !DataStore.MySettings.Raceist;
                    if (DataStore.MySettings.Raceist)
                        Rand_11.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_11.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_12)
                {
                    DataStore.MySettings.BBBomb = !DataStore.MySettings.BBBomb;
                    if (DataStore.MySettings.BBBomb)
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_13)
                {
                    DataStore.MySettings.Assassination = !DataStore.MySettings.Assassination;
                    if (DataStore.MySettings.Assassination)
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_14)
                {
                    DataStore.MySettings.Gruppe6 = !DataStore.MySettings.Gruppe6;
                    if (DataStore.MySettings.Gruppe6)
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_15)
                {
                    DataStore.MySettings.Sailor = !DataStore.MySettings.Sailor;
                    if (DataStore.MySettings.Sailor)
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_16)
                {
                    DataStore.MySettings.ImportantEx = !DataStore.MySettings.ImportantEx;
                    if (DataStore.MySettings.ImportantEx)
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_17)
                {
                    DataStore.MySettings.DebtCollect = !DataStore.MySettings.DebtCollect;
                    if (DataStore.MySettings.DebtCollect)
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_18)
                {
                    DataStore.MySettings.MCBusiness = !DataStore.MySettings.MCBusiness;
                    if (DataStore.MySettings.MCBusiness)
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_19)
                {
                    DataStore.MySettings.BayLift = !DataStore.MySettings.BayLift;
                    if (DataStore.MySettings.BayLift)
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_20)
                {
                    DataStore.MySettings.Sharks = !DataStore.MySettings.Sharks;
                    if (DataStore.MySettings.Sharks)
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_21)
                {
                    DataStore.MySettings.HappyShopper = !DataStore.MySettings.HappyShopper;
                    if (DataStore.MySettings.HappyShopper)
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_22)
                {
                    DataStore.MySettings.MoresMute = !DataStore.MySettings.MoresMute;
                    if (DataStore.MySettings.MoresMute)
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_23)
                {
                    DataStore.MySettings.TempJob = !DataStore.MySettings.TempJob;
                    if (DataStore.MySettings.TempJob)
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_24)
                {
                    DataStore.MySettings.ParaDisplay = !DataStore.MySettings.ParaDisplay;
                    if (DataStore.MySettings.ParaDisplay)
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_25)
                {
                    DataStore.MySettings.Deliverwho = !DataStore.MySettings.Deliverwho;
                    if (DataStore.MySettings.Deliverwho)
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);

                MissionData.iMissionList.Clear();
            };
        }
        private static void SettingsSet(UIMenu XMen)
        {
            var Selectmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.Othertext[67]);

            var Rand_01 = new UIMenuItem(DataStore.MyLang.Othertext[68], DataStore.MyLang.Othertext[69]);
            if (DataStore.MySettings.ShowRoute)
                Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_02 = new UIMenuItem(DataStore.MyLang.Othertext[70], DataStore.MyLang.Othertext[71]);
            if (DataStore.MySettings.Subtitles)
                Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_03 = new UIMenuItem(DataStore.MyLang.Othertext[72], DataStore.MyLang.Othertext[73]);
            if (DataStore.MySettings.PhoneCone)
                Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_04 = new UIMenuItem(DataStore.MyLang.Othertext[74], DataStore.MyLang.Othertext[75]);
            if (DataStore.MySettings.EnemyStrength)
                Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_05 = new UIMenuItem(DataStore.MyLang.Othertext[76], DataStore.MyLang.Othertext[77]);
            if (DataStore.MySettings.FastTraveltoStart)
                Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_06 = new UIMenuItem(DataStore.MyLang.Othertext[78], DataStore.MyLang.Othertext[79]);
            if (DataStore.MySettings.PhoneAudio)
                Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_07 = new UIMenuItem(DataStore.MyLang.Othertext[80], DataStore.MyLang.Othertext[81]);//Remove this phone...

            var Rand_08 = new UIMenuItem(DataStore.MyLang.Othertext[82], DataStore.MyLang.Othertext[83]);
            if (DataStore.MySettings.BulderOnly)
                Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_09 = new UIMenuItem(DataStore.MyLang.Othertext[84], DataStore.MyLang.Othertext[85]);
            if (DataStore.MySettings.PhoneAnim)
                Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_10 = new UIMenuItem(DataStore.MyLang.Othertext[86], DataStore.MyLang.Othertext[87]);
            if (DataStore.MySettings.StartOnYAcht)
                Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_11 = new UIMenuItem(DataStore.MyLang.Othertext[88], DataStore.MyLang.Othertext[89]);//setyachtpprice

            var Rand_12 = new UIMenuItem(DataStore.MyLang.Othertext[90], DataStore.MyLang.Othertext[91]);
            if (DataStore.MySettings.PreLoadOnline)
                Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            Selectmenu.AddItem(Rand_01);
            Selectmenu.AddItem(Rand_02);
            Selectmenu.AddItem(Rand_03);
            Selectmenu.AddItem(Rand_04);
            Selectmenu.AddItem(Rand_05);
            Selectmenu.AddItem(Rand_06);
            Selectmenu.AddItem(Rand_07);
            Selectmenu.AddItem(Rand_08);
            Selectmenu.AddItem(Rand_09);

            if (DataStore.MyAssets.OwnaYacht)
                Selectmenu.AddItem(Rand_10);
            else
                Selectmenu.AddItem(Rand_11);

            Selectmenu.AddItem(Rand_12);

            AddCustomVehcis(Selectmenu);

            Selectmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    DataStore.MySettings.ShowRoute = !DataStore.MySettings.ShowRoute;
                    if (DataStore.MySettings.ShowRoute)
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_02)
                {
                    DataStore.MySettings.Subtitles = !DataStore.MySettings.Subtitles;
                    if (DataStore.MySettings.Subtitles)
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_03)
                {
                    DataStore.MySettings.PhoneCone = !DataStore.MySettings.PhoneCone;
                    if (DataStore.MySettings.PhoneCone)
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                    {
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        DataStore.MySettings.PhoneAudio = true;
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    }

                }
                else if (item == Rand_04)
                {
                    DataStore.MySettings.EnemyStrength = !DataStore.MySettings.EnemyStrength;
                    if (DataStore.MySettings.EnemyStrength)
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_05)
                {
                    DataStore.MySettings.FastTraveltoStart = !DataStore.MySettings.FastTraveltoStart;
                    if (DataStore.MySettings.FastTraveltoStart)
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_06)
                {
                    DataStore.MySettings.PhoneAudio = !DataStore.MySettings.PhoneAudio;
                    if (DataStore.MySettings.PhoneAudio)
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                    {
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        DataStore.MySettings.PhoneCone = true;
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    }
                }
                else if (item == Rand_07)
                {
                    if (Rand_07.RightBadge != UIMenuItem.BadgeStyle.Tick)
                    {
                        DataStore.MySettings.PhoneBlock.Add(DataStore.vPhoneCorona);
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    }
                }
                else if (item == Rand_08)
                {
                    DataStore.MySettings.BulderOnly = !DataStore.MySettings.BulderOnly;
                    if (DataStore.MySettings.BulderOnly)
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_09)
                {
                    DataStore.MySettings.PhoneAnim = !DataStore.MySettings.PhoneAnim;
                    if (DataStore.MySettings.PhoneAnim)
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_10)
                {
                    DataStore.MySettings.StartOnYAcht = !DataStore.MySettings.StartOnYAcht;

                    if (DataStore.MySettings.StartOnYAcht)
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_11)
                {
                    DataStore.bBankTransfer = true;
                    DataStore.iCoinBats = 5;
                    YtmenuPool.CloseAllMenus();
                }
                else if (item == Rand_12)
                {
                    DataStore.MySettings.PreLoadOnline = !DataStore.MySettings.PreLoadOnline;
                    if (DataStore.MySettings.PreLoadOnline)
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                    {
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        DataStore.MySettings.StartOnYAcht = false;
                        DataStore.MyDatSet.iOwnaYacht = 0;
                        DataStore.MyAssets.OwnaYacht = false;
                        RWDatFile.SaveDat(0, 0);
                    }
                }
                ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
            };
        }
        public static void BackToBuildMenu(int iFileList)
        {
            LoggerLight.LogThis("BackToBuildMenu");

            var mainMenu = new UIMenu(DataStore.MyLang.Othertext[92], DataStore.MyLang.Othertext[93]);
            YtmenuPool.Add(mainMenu);
            if (iFileList == 1)
                MishXMlListed(mainMenu);
            else
                MishconBuild(mainMenu);
            DataStore.bOptionsMen = true;
            DataStore.bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void MishconBuild(UIMenu XMen)
        {
            LoggerLight.LogThis("MishconBuild");

            var Buildmenu = YtmenuPool.AddSubMenu(XMen, "Build Menu");

            var Rand_01 = new UIMenuItem("Trucking", "Build a truck mission");

            var Rand_02 = new UIMenuItem("Packages", "Build a packages mission");

            var Rand_03 = new UIMenuItem("Convicts", "Build a convicts mission");

            var Rand_04 = new UIMenuItem("Fubar", "Build a fubar mission");

            var Rand_05 = new UIMenuItem("Ambulance", "Build a ambulance mission");

            var Rand_07 = new UIMenuItem("Johnny", "Build a Johnny mission");

            var Rand_08 = new UIMenuItem("Raceist", "Build a race");

            var Rand_09 = new UIMenuItem("BBBomb", "Build a BBBomb mission");

            var Rand_10 = new UIMenuItem("Hitman", "Build a assassination mission");

            var Rand_06 = new UIMenuItem("Sharks", "Build a sharks mission");

            Buildmenu.AddItem(Rand_01);
            Buildmenu.AddItem(Rand_02);
            Buildmenu.AddItem(Rand_03);
            Buildmenu.AddItem(Rand_04);
            Buildmenu.AddItem(Rand_05);
            Buildmenu.AddItem(Rand_07);
            Buildmenu.AddItem(Rand_08);
            Buildmenu.AddItem(Rand_09);
            Buildmenu.AddItem(Rand_10);
            Buildmenu.AddItem(Rand_06);

            Buildmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                    MissionData.iBuildMode = 1;
                else if (item == Rand_02)
                    MissionData.iBuildMode = 2;
                else if (item == Rand_03)
                    MissionData.iBuildMode = 3;
                else if (item == Rand_04)
                    MissionData.iBuildMode = 4;
                else if (item == Rand_05)
                    MissionData.iBuildMode = 5;
                else if (item == Rand_06)
                    MissionData.iBuildMode = 6;
                else if (item == Rand_07)
                    MissionData.iBuildMode = 7;
                else if (item == Rand_08)
                    MissionData.iBuildMode = 8;
                else if (item == Rand_09)
                    MissionData.iBuildMode = 9;
                else if (item == Rand_10)
                    MissionData.iBuildMode = 10;
                DataStore.bBuildMode = true;
                Game.Player.IsInvincible = true;
                DataStore.iBuildingUp = 0;
                ObjectHand.CleanMishlists();
                YtmenuPool.CloseAllMenus();
            };
        }
        private static void MishXMlListed(UIMenu XMen)
        {
            LoggerLight.LogThis("MishXMlListed");

            string sOuter = MissionData.sList_01[0];

            List<dynamic> xFiles = new List<dynamic>();

            for (int i = 0; i < MissionData.sList_01.Count; i++)
            {
                string sting = MissionData.sList_01[i];
                int iNum = sting.LastIndexOf("/") + 1;
                xFiles.Add(sting.Substring(iNum));
            }
            xFiles.Add("Create New File");
            MissionData.sList_01.Add("Create New File");

            var ThisShizle = new UIMenuListItem("MissionXML", xFiles, 0);
            XMen.AddItem(ThisShizle);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    sOuter = MissionData.sList_01[index];
                }
            };
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (sOuter == "Create New File")
                    sOuter = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Builder/" + Game.GetUserInput(255) + ".XML";
                TheMissions.BuildMissions(MissionData.iBuildMode, sOuter);
                ObjectHand.PostMess();
                MissionData.iBuildMode = 99;
                YtmenuPool.CloseAllMenus();
            };
        }
        private static void AddNewCustoms()
        {
            CustomVeh Carzz = new CustomVeh
            {
                MyCarz = DataStore.MyCusVeh.MyCarz,
                MyPlanez = DataStore.MyCusVeh.MyPlanez,
                MyBoatz = DataStore.MyCusVeh.MyBoatz,
                MyChopperz = DataStore.MyCusVeh.MyChopperz
            };
            ReadWriteXML.SaveXmlCustom(Carzz, DataStore.sNSPMAddonCarz);
        }
        public static void Ambulance_Menu()
        {
            LoggerLight.LogThis("Ambulance_Menu");

            string sWhatsTheProb = "";
            if (MissionData.bCovidInf)
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[23];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + " .. " + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[25] + DataStore.MyLang.Othertext[24];
            }
            else if (MissionData.iList_01[1] == 1)
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[26];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[27];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[28];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[29];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[30];
            }       //Injury
            else if (MissionData.iList_01[1] == 2)
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[23];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24] + " .. " + DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[24];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[24] + DataStore.MyLang.Othertext[25] + DataStore.MyLang.Othertext[24];
            }       //Covid
            else if (MissionData.iList_01[1] == 3)
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[31];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[32];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[33];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[34];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[35];
            }       //Burns
            else if (MissionData.iList_01[1] == 4)
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[36];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[37];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[38];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[39];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[40];
            }       //Vomit/Diarea
            else
            {
                int iRan = ReturnStuff.RandInt(1, 5);
                if (iRan == 1)
                    sWhatsTheProb = DataStore.MyLang.Othertext[41];
                else if (iRan == 2)
                    sWhatsTheProb = DataStore.MyLang.Othertext[42];
                else if (iRan == 3)
                    sWhatsTheProb = DataStore.MyLang.Othertext[43];
                else if (iRan == 4)
                    sWhatsTheProb = DataStore.MyLang.Othertext[44];
                else
                    sWhatsTheProb = DataStore.MyLang.Othertext[45];
            }                             //Fake 

            var mainMenu = new UIMenu(DataStore.MyLang.Othertext[46], sWhatsTheProb)
            {
                ControlDisablingEnabled = true
            };
            mainMenu.SetMenuWidthOffset(100);
            YtmenuPool.Add(mainMenu);
            Ambulance_Diagnosis(mainMenu);
            YtmenuPool.RefreshIndex();
            DataStore.bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void Ambulance_Diagnosis(UIMenu XMen)
        {
            LoggerLight.LogThis("Ambulance_Diagnosis");

            int iAniTime = 7000;

            var Rand_01 = new UIMenuItem(DataStore.MyLang.Othertext[47], "");

            var Rand_02 = new UIMenuItem(DataStore.MyLang.Othertext[48], "");

            var Rand_03 = new UIMenuItem(DataStore.MyLang.Othertext[49], "");

            var Rand_04 = new UIMenuItem(DataStore.MyLang.Othertext[50], "");

            var Rand_05 = new UIMenuItem(DataStore.MyLang.Othertext[51], "");

            XMen.AddItem(Rand_01);
            XMen.AddItem(Rand_02);
            XMen.AddItem(Rand_03);
            XMen.AddItem(Rand_04);
            XMen.AddItem(Rand_05);

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    if (MissionData.iList_01[1] == 1)
                    {
                        MissionData.iCrash4Cash = ReturnStuff.RandInt(50, 100);
                        MissionData.iMissionSeq = 15;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 2)
                    {
                        MissionData.bCovidInf = true;
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 15;
                        MissionData.iWait4Sec = Game.GameTime + iAniTime;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 3)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 4)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_02)
                {
                    if (MissionData.iList_01[1] == 1)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 2)
                    {
                        MissionData.iCrash4Cash = ReturnStuff.RandInt(50, 100);
                        MissionData.iMissionSeq = 15;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 3)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 4)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_03)
                {
                    if (MissionData.iList_01[1] == 1)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 2)
                    {
                        MissionData.bCovidInf = true;
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 3)
                    {
                        MissionData.iCrash4Cash = ReturnStuff.RandInt(50, 100);
                        MissionData.iMissionSeq = 15;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 4)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_04)
                {
                    if (MissionData.iList_01[1] == 1)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 2)
                    {
                        MissionData.BeOnOff[6] = true;
                        MissionData.bCovidInf = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 3)
                    {
                        MissionData.BeOnOff[7] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (MissionData.iList_01[1] == 4)
                    {
                        MissionData.iCrash4Cash = ReturnStuff.RandInt(50, 100);
                        MissionData.iMissionSeq = 15;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        MissionData.BeOnOff[6] = true;
                        MissionData.iMissionSeq = 16;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                        ObjectBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_05)
                {
                    if (MissionData.iList_01[1] == 1)
                    {
                        MissionData.iMissionSeq = 17;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                    }
                    else if (MissionData.iList_01[1] == 2)
                    {
                        MissionData.bCovidInf = true;
                        MissionData.iMissionSeq = 18;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                    }
                    else if (MissionData.iList_01[1] == 3)
                    {
                        MissionData.iMissionSeq = 17;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                    }
                    else if (MissionData.iList_01[1] == 4)
                    {
                        MissionData.iMissionSeq = 17;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                    }
                    else
                    {
                        MissionData.iCrash4Cash = ReturnStuff.RandInt(50, 100);
                        MissionData.iMissionSeq = 18;
                        Game.Player.Character.Task.TurnTo(MissionData.Npc_01);
                    }
                }
                MissionData.iWait4Sec = Game.GameTime + iAniTime;
                DataStore.bMenuOpen = false;
                XMen.Visible = !XMen.Visible;
            };
        }
    }
}
