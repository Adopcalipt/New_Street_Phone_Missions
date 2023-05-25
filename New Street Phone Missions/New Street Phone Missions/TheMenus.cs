using GTA;
using NativeUI;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class TheMenus
    {
        public static MenuPool YtmenuPool = new MenuPool();
        private static RacingMenu MyRaceSet = null;
        private static bool SelectAll = false;
        private static readonly List<string> RaceClassList = new List<string>
        {
            DataStore.MyLang.ContactLang[31],
            DataStore.MyLang.ContactLang[32],
            DataStore.MyLang.ContactLang[36],
            DataStore.MyLang.ContactLang[34],
            DataStore.MyLang.ContactLang[33],
            DataStore.MyLang.ContactLang[39],
            DataStore.MyLang.ContactLang[37],
            DataStore.MyLang.ContactLang[38],
            DataStore.MyLang.ContactLang[35],
            DataStore.MyLang.ContactLang[77],
            DataStore.MyLang.ContactLang[76],
            DataStore.MyLang.ContactLang[78],
            DataStore.MyLang.ContactLang[79],
            DataStore.MyLang.ContactLang[80],
            DataStore.MyLang.ContactLang[81],
            DataStore.MyLang.ContactLang[82],
            DataStore.MyLang.ContactLang[83],
            DataStore.MyLang.ContactLang[84],
            DataStore.MyLang.ContactLang[85],
            DataStore.MyLang.ContactLang[86],
            DataStore.MyLang.ContactLang[87],
            DataStore.MyLang.ContactLang[52],
            DataStore.MyLang.ContactLang[53],
            DataStore.MyLang.ContactLang[50],
            DataStore.MyLang.ContactLang[51],
            DataStore.MyLang.ContactLang[54],
            DataStore.MyLang.ContactLang[88],
            DataStore.MyLang.ContactLang[90],
            DataStore.MyLang.ContactLang[91],
            DataStore.MyLang.ContactLang[92],
            DataStore.MyLang.ContactLang[93]
        };
        private static readonly List<string> RaceTimeList = new List<string>
        {
            DataStore.MyLang.Othertext[158],
            DataStore.MyLang.Othertext[159],
            DataStore.MyLang.Othertext[160],
            DataStore.MyLang.Othertext[161]
        };
        private static readonly List<string> RaceWeatherList = new List<string>
        {            
            "Clear",
            "Extrasunny",
            "Clouds",
            "Overcast",
            "Rain",
            "Clearing",
            "Thunder",
            "Smog",
            "Foggy",
            "Snow"
        };
        private static readonly List<string> BoolSwitch = new List<string>
        {
            DataStore.MyLang.Othertext[162],
            DataStore.MyLang.Othertext[163]
        };

        public static void SettingsMenu()
        {
            LoggerLight.LogThis("SettingsMenu");

            var mainMenu = new UIMenu("NSPM", DataStore.MyLang.Othertext[56]);

            YtmenuPool.Add(mainMenu);

            MissionSelectSet(mainMenu);
            SettingsSet(mainMenu);

            DataStore.OptionsMen = true;
            DataStore.MenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void AddCustomVehcis(UIMenu XMen)
        {
            //bool JustCustoms
            //if (JustCustoms)
            //{
            //    ReadWriteXML.SaveXmlCustom(DataStore.MyCustomVeh, DataStore.sNSPMAddonCarz);
            //    AddCustomVehcis(mainMenu);
            //}

            var SubHeadder = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.Othertext[57]);
            var Submenu_01 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[31]);
            var Submenu_02 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[32]);
            var Submenu_03 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[36]);
            var Submenu_04 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[34]);
            var Submenu_05 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[33]);
            var Submenu_06 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[39]);
            var Submenu_07 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[37]);
            var Submenu_08 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[38]);
            var Submenu_09 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[35]);
            var Submenu_10 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[76]);
            var Submenu_11 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[77]);
            var Submenu_12 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[78]);
            var Submenu_13 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[79]);
            var Submenu_14 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[80]);
            var Submenu_15 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[81]);
            var Submenu_16 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[82]);
            var Submenu_17 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[83]);
            var Submenu_18 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[84]);
            var Submenu_19 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[85]);
            var Submenu_20 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[86]);
            var Submenu_21 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[87]);
            var Submenu_22 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[52]);
            var Submenu_23 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[53]);
            var Submenu_24 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[50]);
            var Submenu_25 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[51]);
            var Submenu_26 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[54]);
            var Submenu_27 = YtmenuPool.AddSubMenu(SubHeadder, DataStore.MyLang.ContactLang[88]);

            XmlCustomVeh WCCustoms = new XmlCustomVeh();

            var AddX01 = new UIMenuItem(DataStore.MyLang.ContactLang[89]+ DataStore.MyLang.ContactLang[31], "");
            Submenu_01.AddItem(AddX01);
            var AddX02 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[32], "");
            Submenu_02.AddItem(AddX02);
            var AddX03 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[36], "");
            Submenu_03.AddItem(AddX03);
            var AddX04 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[34], "");
            Submenu_04.AddItem(AddX04);
            var AddX05 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[33], "");
            Submenu_05.AddItem(AddX05);
            var AddX06 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[39], "");
            Submenu_06.AddItem(AddX06);
            var AddX07 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[37], "");
            Submenu_07.AddItem(AddX07);
            var AddX08 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[38], "");
            Submenu_08.AddItem(AddX08);
            var AddX09 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[35], "");
            Submenu_09.AddItem(AddX09);
            var AddX10 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[76], "");
            Submenu_10.AddItem(AddX10);
            var AddX11 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[77], "");
            Submenu_11.AddItem(AddX11);
            var AddX12 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[78], "");
            Submenu_12.AddItem(AddX12);
            var AddX13 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[79], "");
            Submenu_13.AddItem(AddX13);
            var AddX14 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[80], "");
            Submenu_14.AddItem(AddX14);
            var AddX15 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[81], "");
            Submenu_15.AddItem(AddX15);
            var AddX16 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[82], "");
            Submenu_16.AddItem(AddX16);
            var AddX17 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[83], "");
            Submenu_17.AddItem(AddX17);
            var AddX18 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[84], "");
            Submenu_18.AddItem(AddX18);
            var AddX19 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[85], "");
            Submenu_19.AddItem(AddX19);
            var AddX20 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[86], "");
            Submenu_20.AddItem(AddX20);
            var AddX21 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[87], "");
            Submenu_21.AddItem(AddX21);
            var AddX22 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[52], "");
            Submenu_22.AddItem(AddX22);
            var AddX23 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[53], "");
            Submenu_23.AddItem(AddX23);
            var AddX24 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[50], "");
            Submenu_24.AddItem(AddX24);
            var AddX25 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[51], "");
            Submenu_25.AddItem(AddX25);
            var AddX26 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[54], "");
            Submenu_26.AddItem(AddX26);
            var AddX27 = new UIMenuItem(DataStore.MyLang.ContactLang[89] + DataStore.MyLang.ContactLang[88], "");
            Submenu_27.AddItem(AddX27);

            for (int i = 0;i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 1)
                    Submenu_01.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 2)
                    Submenu_02.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 3)
                    Submenu_03.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 4)
                    Submenu_04.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 5)
                    Submenu_05.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 6)
                    Submenu_06.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 7)
                    Submenu_07.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 8)
                    Submenu_08.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 9)
                    Submenu_09.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 10)
                    Submenu_10.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 11)
                    Submenu_11.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 12)
                    Submenu_12.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 13)
                    Submenu_13.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 14)
                    Submenu_14.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 15)
                    Submenu_15.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 16)
                    Submenu_16.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 17)
                    Submenu_17.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 18)
                    Submenu_18.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 19)
                    Submenu_19.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 20)
                    Submenu_20.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 21)
                    Submenu_21.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 22)
                    Submenu_22.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 23)
                    Submenu_23.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 24)
                    Submenu_24.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 25)
                    Submenu_25.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 26)
                    Submenu_26.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 27)
                    Submenu_27.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            Submenu_01.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX01)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(1, sName));
                        ReturnStuff.SuperList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_02.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX02)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(2, sName));
                        ReturnStuff.SportList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            }; 
            Submenu_03.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX03)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(3, sName));
                        ReturnStuff.CoupeList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_04.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX04)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(4, sName));
                        ReturnStuff.MuscleList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_05.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX05)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(5, sName));
                        ReturnStuff.SportClassList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_06.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX06)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(6, sName));
                        ReturnStuff.SedanList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_07.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX07)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(7, sName));
                        ReturnStuff.SUVList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_08.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX08)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(8, sName));
                        ReturnStuff.CompactList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_09.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX09)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(9, sName));
                        ReturnStuff.OffRoadList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_10.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX10)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(10, sName));
                        ReturnStuff.BennysVeh.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_11.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX11)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(11, sName));
                        ReturnStuff.MotorBikeList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_12.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX12)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(12, sName));
                        ReturnStuff.BusList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_13.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX13)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(13, sName));
                        ReturnStuff.IndustrialList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_14.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX14)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(14, sName));
                        ReturnStuff.TruckList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_15.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX15)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(15, sName));
                        ReturnStuff.ComercialList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_16.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX16)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(16, sName));
                        ReturnStuff.ArmoredList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_17.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX17)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(17, sName));
                        ReturnStuff.WeaponisedList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_18.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX18)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(18, sName));
                        ReturnStuff.ArenaWarsList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_19.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX19)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(19, sName));
                        ReturnStuff.OpenWheelList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_20.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX20)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(20, sName));
                        ReturnStuff.CartList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_21.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX21)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(21, sName));
                        ReturnStuff.CycleList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_22.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX22)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(22, sName));
                        ReturnStuff.PlaneComList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_23.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX23)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(23, sName));
                        ReturnStuff.PlaneFightList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_24.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX24)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(24, sName));
                        ReturnStuff.HeliComList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_25.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX25)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(25, sName));
                        ReturnStuff.HeliFightList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_26.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX26)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(26, sName));
                        ReturnStuff.BoatList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
            Submenu_27.OnItemSelect += (sender, item, index) =>
            {
                if (item == AddX27)
                {
                    string sName = Game.GetUserInput(255);
                    if (ReturnStuff.IsItARealVehicle(sName))
                    {
                        DataStore.MyCustomVeh.CustomCars.Add(new ImportExVeh(27, sName));
                        ReturnStuff.FloatersList.Add(sName);
                    }
                    else
                        UI.Notify("Invalid Vehicle ID");
                }
                else
                    RemoveThisVic(item.Text);

                YtmenuPool.CloseAllMenus();
                Script.Wait(3000);
                //SettingsMenu(true);
            };
        }
        private static void RemoveThisVic(string Vic)
        {
            int iAm = 0;
            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehicleS == Vic)
                {
                    iAm = DataStore.MyCustomVeh.CustomCars[i].VehList;
                    DataStore.MyCustomVeh.CustomCars.RemoveAt(i);
                    break;
                }
            }

            if (iAm == 1)
            {
                for (int i = 0; i < ReturnStuff.SuperList.Count; i++)
                {
                    if (ReturnStuff.SuperList[i] == Vic)
                    {
                        ReturnStuff.SuperList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 2)
            {
                for (int i = 0; i < ReturnStuff.SportList.Count; i++)
                {
                    if (ReturnStuff.SportList[i] == Vic)
                    {
                        ReturnStuff.SportList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 3)
            {
                for (int i = 0; i < ReturnStuff.CoupeList.Count; i++)
                {
                    if (ReturnStuff.CoupeList[i] == Vic)
                    {
                        ReturnStuff.CoupeList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 4)
            {
                for (int i = 0; i < ReturnStuff.MuscleList.Count; i++)
                {
                    if (ReturnStuff.MuscleList[i] == Vic)
                    {
                        ReturnStuff.MuscleList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 5)
            {
                for (int i = 0; i < ReturnStuff.SportClassList.Count; i++)
                {
                    if (ReturnStuff.SportClassList[i] == Vic)
                    {
                        ReturnStuff.SportClassList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 6)
            {
                for (int i = 0; i < ReturnStuff.SedanList.Count; i++)
                {
                    if (ReturnStuff.SedanList[i] == Vic)
                    {
                        ReturnStuff.SedanList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 7)
            {
                for (int i = 0; i < ReturnStuff.SUVList.Count; i++)
                {
                    if (ReturnStuff.SUVList[i] == Vic)
                    {
                        ReturnStuff.SUVList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 8)
            {
                for (int i = 0; i < ReturnStuff.CompactList.Count; i++)
                {
                    if (ReturnStuff.CompactList[i] == Vic)
                    {
                        ReturnStuff.CompactList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 9)
            {
                for (int i = 0; i < ReturnStuff.OffRoadList.Count; i++)
                {
                    if (ReturnStuff.OffRoadList[i] == Vic)
                    {
                        ReturnStuff.OffRoadList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 10)
            {
                for (int i = 0; i < ReturnStuff.BennysVeh.Count; i++)
                {
                    if (ReturnStuff.BennysVeh[i] == Vic)
                    {
                        ReturnStuff.BennysVeh.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 11)
            {
                for (int i = 0; i < ReturnStuff.MotorBikeList.Count; i++)
                {
                    if (ReturnStuff.MotorBikeList[i] == Vic)
                    {
                        ReturnStuff.MotorBikeList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 12)
            {
                for (int i = 0; i < ReturnStuff.BusList.Count; i++)
                {
                    if (ReturnStuff.BusList[i] == Vic)
                    {
                        ReturnStuff.BusList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 13)
            {
                for (int i = 0; i < ReturnStuff.IndustrialList.Count; i++)
                {
                    if (ReturnStuff.IndustrialList[i] == Vic)
                    {
                        ReturnStuff.IndustrialList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 14)
            {
                for (int i = 0; i < ReturnStuff.TruckList.Count; i++)
                {
                    if (ReturnStuff.TruckList[i] == Vic)
                    {
                        ReturnStuff.TruckList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 15)
            {
                for (int i = 0; i < ReturnStuff.ComercialList.Count; i++)
                {
                    if (ReturnStuff.ComercialList[i] == Vic)
                    {
                        ReturnStuff.ComercialList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 16)
            {
                for (int i = 0; i < ReturnStuff.ArmoredList.Count; i++)
                {
                    if (ReturnStuff.ArmoredList[i] == Vic)
                    {
                        ReturnStuff.ArmoredList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 17)
            {
                for (int i = 0; i < ReturnStuff.WeaponisedList.Count; i++)
                {
                    if (ReturnStuff.WeaponisedList[i] == Vic)
                    {
                        ReturnStuff.WeaponisedList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 18)
            {
                for (int i = 0; i < ReturnStuff.ArenaWarsList.Count; i++)
                {
                    if (ReturnStuff.ArenaWarsList[i] == Vic)
                    {
                        ReturnStuff.ArenaWarsList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 19)
            {
                for (int i = 0; i < ReturnStuff.OpenWheelList.Count; i++)
                {
                    if (ReturnStuff.OpenWheelList[i] == Vic)
                    {
                        ReturnStuff.OpenWheelList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 20)
            {
                for (int i = 0; i < ReturnStuff.CartList.Count; i++)
                {
                    if (ReturnStuff.CartList[i] == Vic)
                    {
                        ReturnStuff.CartList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 21)
            {
                for (int i = 0; i < ReturnStuff.CycleList.Count; i++)
                {
                    if (ReturnStuff.CycleList[i] == Vic)
                    {
                        ReturnStuff.CycleList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 22)
            {
                for (int i = 0; i < ReturnStuff.PlaneComList.Count; i++)
                {
                    if (ReturnStuff.PlaneComList[i] == Vic)
                    {
                        ReturnStuff.PlaneComList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 23)
            {
                for (int i = 0; i < ReturnStuff.PlaneFightList.Count; i++)
                {
                    if (ReturnStuff.PlaneFightList[i] == Vic)
                    {
                        ReturnStuff.PlaneFightList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 24)
            {
                for (int i = 0; i < ReturnStuff.HeliComList.Count; i++)
                {
                    if (ReturnStuff.HeliComList[i] == Vic)
                    {
                        ReturnStuff.HeliComList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 25)
            {
                for (int i = 0; i < ReturnStuff.HeliFightList.Count; i++)
                {
                    if (ReturnStuff.HeliFightList[i] == Vic)
                    {
                        ReturnStuff.HeliFightList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 26)
            {
                for (int i = 0; i < ReturnStuff.BoatList.Count; i++)
                {
                    if (ReturnStuff.BoatList[i] == Vic)
                    {
                        ReturnStuff.BoatList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (iAm == 27)
            {
                for (int i = 0; i < ReturnStuff.FloatersList.Count; i++)
                {
                    if (ReturnStuff.FloatersList[i] == Vic)
                    {
                        ReturnStuff.FloatersList.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private static void MissionSelectSet(UIMenu XMen)
        {
            var Selectmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.Othertext[66]);

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

            var Rand_14 = new UIMenuItem(DataStore.MyLang.Jobtext[91], "");
            if (DataStore.MySettings.Sniper)
                Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_15 = new UIMenuItem(DataStore.MyLang.Jobtext[13], "");
            if (DataStore.MySettings.Gruppe6)
                Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.Tick); 

            var Rand_16 = new UIMenuItem(DataStore.MyLang.Jobtext[14], "");
            if (DataStore.MySettings.Sailor)
                Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_17 = new UIMenuItem(DataStore.MyLang.Jobtext[15], "");
            if (DataStore.MySettings.ImportantEx)
                Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_18 = new UIMenuItem(DataStore.MyLang.Jobtext[16], "");
            if (DataStore.MySettings.DebtCollect)
                Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_19 = new UIMenuItem(DataStore.MyLang.Jobtext[17], "");
            if (DataStore.MySettings.MCBusiness)
                Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_20 = new UIMenuItem(DataStore.MyLang.Jobtext[18], "");
            if (DataStore.MySettings.BayLift)
                Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_21 = new UIMenuItem(DataStore.MyLang.Jobtext[19], "");
            if (DataStore.MySettings.Sharks)
                Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_22 = new UIMenuItem(DataStore.MyLang.Jobtext[20], "");
            if (DataStore.MySettings.HappyShopper)
                Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_23 = new UIMenuItem(DataStore.MyLang.Jobtext[21], "");
            if (DataStore.MySettings.MoresMute)
                Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_24 = new UIMenuItem(DataStore.MyLang.Jobtext[22], "");
            if (DataStore.MySettings.TempJob)
                Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_25 = new UIMenuItem(DataStore.MyLang.Jobtext[23], "");
            if (DataStore.MySettings.ParaDisplay)
                Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_26 = new UIMenuItem(DataStore.MyLang.Jobtext[24], "");
            if (DataStore.MySettings.Deliverwho)
                Rand_26.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_27 = new UIMenuItem(DataStore.MyLang.Jobtext[43], "");
            if (DataStore.MySettings.Thief)
                Rand_27.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_28 = new UIMenuItem(DataStore.MyLang.Jobtext[93], "");
            Rand_28.SetRightBadge(UIMenuItem.BadgeStyle.None);

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
            Selectmenu.AddItem(Rand_26);
            Selectmenu.AddItem(Rand_27);
            Selectmenu.AddItem(Rand_28);

            Selectmenu.OnMenuOpen += (sender) =>
            {
                DataStore.iDisplayAch = 1;
            };
         
            Selectmenu.OnIndexChange += (sender, index) =>
            {
                if (index == 0)
                    DataStore.iDisplayAch = 1;
                else if (index == 1)
                    DataStore.iDisplayAch = 2;
                else if (index == 2)
                    DataStore.iDisplayAch = 3;
                else if (index == 3)
                    DataStore.iDisplayAch = 4;
                else if (index == 4)
                    DataStore.iDisplayAch = 5;
                else if (index == 5)
                    DataStore.iDisplayAch = 6;
                else if (index == 6)
                    DataStore.iDisplayAch = 7;
                else if (index == 7)
                    DataStore.iDisplayAch = 8;
                else if (index == 8)
                    DataStore.iDisplayAch = 9;
                else if (index == 9)
                    DataStore.iDisplayAch = 10;
                else if (index == 10)
                    DataStore.iDisplayAch = 11;
                else if (index == 11)
                    DataStore.iDisplayAch = 12;
                else if (index == 12)
                    DataStore.iDisplayAch = 13;
                else if (index == 13)
                    DataStore.iDisplayAch = 14;
                else if (index == 14)
                    DataStore.iDisplayAch = 15;
                else if (index == 15)
                    DataStore.iDisplayAch = 16;
                else if (index == 16)
                    DataStore.iDisplayAch = 17;
                else if (index == 17)
                    DataStore.iDisplayAch = 18;
                else if (index == 18)
                    DataStore.iDisplayAch = 19;
                else if (index == 19)
                    DataStore.iDisplayAch = 20;
                else if (index == 20)
                    DataStore.iDisplayAch = 21;
                else if (index == 21)
                    DataStore.iDisplayAch = 22;
                else if (index == 22)
                    DataStore.iDisplayAch = 23;
                else if (index == 23)
                    DataStore.iDisplayAch = 24;
                else if (index == 24)
                    DataStore.iDisplayAch = 25;
                else if (index == 25)
                    DataStore.iDisplayAch = 26;
                else if (index == 26)
                    DataStore.iDisplayAch = 27;
                else
                    DataStore.iDisplayAch = 0;
            };

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
                    DataStore.MySettings.Sniper = !DataStore.MySettings.Sniper;
                    if (DataStore.MySettings.Sniper)
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_15)
                {
                    DataStore.MySettings.Gruppe6 = !DataStore.MySettings.Gruppe6;
                    if (DataStore.MySettings.Gruppe6)
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_16)
                {
                    DataStore.MySettings.Sailor = !DataStore.MySettings.Sailor;
                    if (DataStore.MySettings.Sailor)
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_17)
                {
                    DataStore.MySettings.ImportantEx = !DataStore.MySettings.ImportantEx;
                    if (DataStore.MySettings.ImportantEx)
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_18)
                {
                    DataStore.MySettings.DebtCollect = !DataStore.MySettings.DebtCollect;
                    if (DataStore.MySettings.DebtCollect)
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_19)
                {
                    DataStore.MySettings.MCBusiness = !DataStore.MySettings.MCBusiness;
                    if (DataStore.MySettings.MCBusiness)
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_20)
                {
                    DataStore.MySettings.BayLift = !DataStore.MySettings.BayLift;
                    if (DataStore.MySettings.BayLift)
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_21)
                {
                    DataStore.MySettings.Sharks = !DataStore.MySettings.Sharks;
                    if (DataStore.MySettings.Sharks)
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_22)
                {
                    DataStore.MySettings.HappyShopper = !DataStore.MySettings.HappyShopper;
                    if (DataStore.MySettings.HappyShopper)
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_23)
                {
                    DataStore.MySettings.MoresMute = !DataStore.MySettings.MoresMute;
                    if (DataStore.MySettings.MoresMute)
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_24)
                {
                    DataStore.MySettings.TempJob = !DataStore.MySettings.TempJob;
                    if (DataStore.MySettings.TempJob)
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_25)
                {
                    DataStore.MySettings.ParaDisplay = !DataStore.MySettings.ParaDisplay;
                    if (DataStore.MySettings.ParaDisplay)
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_26)
                {
                    DataStore.MySettings.Deliverwho = !DataStore.MySettings.Deliverwho;
                    if (DataStore.MySettings.Deliverwho)
                        Rand_26.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_26.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_27)
                {
                    DataStore.MySettings.Thief = !DataStore.MySettings.Thief;
                    if (DataStore.MySettings.Thief)
                        Rand_27.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_27.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == Rand_28)
                {
                    SelectAll = !SelectAll;
                    DataStore.MySettings.Truckin = SelectAll;
                    DataStore.MySettings.Getaway = SelectAll;
                    DataStore.MySettings.Packages = SelectAll;
                    DataStore.MySettings.Convicts = SelectAll;
                    DataStore.MySettings.FUber = SelectAll;
                    DataStore.MySettings.Pilot = SelectAll;
                    DataStore.MySettings.Amulance = SelectAll;
                    DataStore.MySettings.Follow = SelectAll;
                    DataStore.MySettings.LSFD = SelectAll;
                    DataStore.MySettings.Johnny = SelectAll;
                    DataStore.MySettings.Raceist = SelectAll;
                    DataStore.MySettings.BBBomb = SelectAll;
                    DataStore.MySettings.Sniper = SelectAll;
                    DataStore.MySettings.Gruppe6 = SelectAll;
                    DataStore.MySettings.Sailor = SelectAll;
                    DataStore.MySettings.ImportantEx = SelectAll;
                    DataStore.MySettings.DebtCollect = SelectAll;
                    DataStore.MySettings.MCBusiness = SelectAll;
                    DataStore.MySettings.BayLift = SelectAll;
                    DataStore.MySettings.Sharks = SelectAll;
                    DataStore.MySettings.HappyShopper = SelectAll;
                    DataStore.MySettings.MoresMute = SelectAll;
                    DataStore.MySettings.TempJob = SelectAll;
                    DataStore.MySettings.ParaDisplay = SelectAll;
                    DataStore.MySettings.Deliverwho = SelectAll;
                    DataStore.MySettings.Assassination = SelectAll;
                    DataStore.MySettings.Thief = SelectAll;

                    if (DataStore.MySettings.Truckin)
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Getaway)
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Packages)
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Convicts)
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.FUber)
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_05.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Pilot)
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_06.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Amulance)
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_07.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Follow)
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_08.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.LSFD)
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_09.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Johnny)
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_10.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Raceist)
                        Rand_11.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_11.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.BBBomb)
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_12.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Assassination)
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Sniper)
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_14.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Gruppe6)
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_15.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Sailor)
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_16.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.ImportantEx)
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_17.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.DebtCollect)
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_18.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.MCBusiness)
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_19.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.BayLift)
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_20.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Sharks)
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_21.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.HappyShopper)
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_22.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.MoresMute)
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_23.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.TempJob)
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_24.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.ParaDisplay)
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_25.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Deliverwho)
                        Rand_26.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_26.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettings.Thief)
                        Rand_27.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_27.SetRightBadge(UIMenuItem.BadgeStyle.None);

                }
                
                ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
            };

            Selectmenu.OnMenuClose += (sender) =>
            {
                DataStore.iDisplayAch = 0;
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
            if (DataStore.MySettings.AchiveMents)
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

            var Rand_13 = new UIMenuItem(DataStore.MyLang.Othertext[391], DataStore.MyLang.Othertext[392]);
            if (DataStore.MySettings.Debug)
                Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

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
            Selectmenu.AddItem(Rand_13);

            //AddCustomVehcis(Selectmenu);

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
                    DataStore.MySettings.AchiveMents = !DataStore.MySettings.AchiveMents;
                    if (DataStore.MySettings.AchiveMents)
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
                    DataStore.BankTransfer = true;
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
                    }
                }
                else if (item == Rand_13)
                {
                    DataStore.MySettings.Debug = !DataStore.MySettings.Debug;
                    if (DataStore.MySettings.Debug)
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_13.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                ReadWriteXML.SaveXmlSets(DataStore.MySettings, DataStore.sNSPMSet);
            };
        }
        public static void Ambulance_Menu(int iConditions, bool CovidInf, Ped VicTim)
        {
            LoggerLight.LogThis("Ambulance_Menu");

            string sWhatsTheProb = "";
            if (iConditions == 1)
            {
                int iRan = RandomX.FindRandom("Ambulance_Menu02", 1, 5);
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
            else if (iConditions == 2)
            {
                int iRan = RandomX.FindRandom("Ambulance_Menu03", 1, 5);
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
            else if (iConditions == 3)
            {
                int iRan = RandomX.FindRandom("Ambulance_Menu04", 1, 5);
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
            else if (iConditions == 4)
            {
                int iRan = RandomX.FindRandom("Ambulance_Menu05", 1, 5);
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
                int iRan = RandomX.FindRandom("Ambulance_Menu06", 1, 5);
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
            Ambulance_Diagnosis(mainMenu, VicTim, iConditions);
            YtmenuPool.RefreshIndex();
            DataStore.MenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void Ambulance_Diagnosis(UIMenu XMen, Ped VicTim, int Condition)
        {
            LoggerLight.LogThis("Ambulance_Diagnosis");

            int iAniTime = 7000;

            var Rand_01 = new UIMenuItem(DataStore.MyLang.Othertext[47], "");//Triage your patient
            var Rand_02 = new UIMenuItem(DataStore.MyLang.Othertext[48], "");//Inject your patient with hydroxychloroquine
            var Rand_03 = new UIMenuItem(DataStore.MyLang.Othertext[49], "");//Apply dressing to the burns
            var Rand_04 = new UIMenuItem(DataStore.MyLang.Othertext[50], "");//Give the patient an alcaselza suppository
            var Rand_05 = new UIMenuItem(DataStore.MyLang.Othertext[51], "");//Dismiss

            XMen.AddItem(Rand_01);
            XMen.AddItem(Rand_02);
            XMen.AddItem(Rand_03);
            XMen.AddItem(Rand_04);
            XMen.AddItem(Rand_05);

            //14--Half the time
            //15--Passed test off to hosp
            //16--Fake Ill no time
            //17--Death
            //18--OkWalksaway

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    if (Condition == 1)
                    {
                        NSPM.JobSeq = 15;
                        DataStore.CorectDiagnose = true;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 2)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 3)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 4)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_02)
                {
                    if (Condition == 1)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 2)
                    {
                        NSPM.JobSeq = 15;
                        DataStore.CorectDiagnose = true;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 3)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 4)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        NSPM.JobSeq = 18;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_03)
                {
                    if (Condition == 1)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 2)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 3)
                    {
                        NSPM.JobSeq = 15;
                        DataStore.CorectDiagnose = true;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 4)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_04)
                {
                    if (Condition == 1)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 2)
                    {
                        NSPM.JobSeq = 14;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 3)
                    {
                        NSPM.JobSeq = 14;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else if (Condition == 4)
                    {
                        NSPM.JobSeq = 15;
                        DataStore.CorectDiagnose = true;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                    else
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                        EntityBuild.PedScenario(Game.Player.Character, "CODE_HUMAN_MEDIC_TEND_TO_DEAD", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                    }
                }
                else if (item == Rand_05)
                {
                    if (Condition == 1)
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                    }
                    else if (Condition == 2)
                    {
                        if (NSPM.Ambulance_CovidOut())
                            NSPM.JobSeq = 17;
                        else
                            NSPM.JobSeq = 18;
                        NSPM.Ambulance_CovidSet();
                        Game.Player.Character.Task.TurnTo(VicTim);
                    }
                    else if (Condition == 3)
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                    }
                    else if (Condition == 4)
                    {
                        NSPM.JobSeq = 17;
                        Game.Player.Character.Task.TurnTo(VicTim);
                    }
                    else
                    {
                        NSPM.JobSeq = 18;
                        DataStore.CorectDiagnose = true;
                        Game.Player.Character.Task.TurnTo(VicTim);
                    }
                }
                
                NSPM.iWait4Sec = Game.GameTime + iAniTime;
                DataStore.MenuOpen = false;
                XMen.Visible = !XMen.Visible;
            };
        }
        public static void Racist_Menu()
        {
            LoggerLight.LogThis("Racist_Menu");

            var mainMenu = new UIMenu("Racisums", "");
            YtmenuPool.Add(mainMenu);
            Racist_SelectRace(mainMenu);
            YtmenuPool.RefreshIndex();
            DataStore.MenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void Racist_SelectRace(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectRace");

            List<int> Racisms = MissionData.FindRacists(NSPM.LocationX);
            if (Racisms.Count > 0)
            {
                int iSelect = Racisms[0];
                List<dynamic> RaceList = new List<dynamic>();

                for (int i = 0; i < Racisms.Count; i++)
                    RaceList.Add(MissionData.MyRacists[Racisms[i]].Name);

                DataStore.iRaceSym = MissionData.MyRacists[iSelect].Type;

                var ThisShizle = new UIMenuListItem("", RaceList, 0);
                XMen.AddItem(ThisShizle);

                XMen.OnListChange += (sender, item, index) =>
                {
                    if (item == ThisShizle)
                        iSelect = Racisms[index];

                    DataStore.iRaceSym = MissionData.MyRacists[iSelect].Type;
                };
                XMen.OnItemSelect += (sender, item, index) =>
                {
                    if (item == ThisShizle)
                    {
                        DataStore.iRaceSym = -1;
                        MyRaceSet = new RacingMenu(iSelect);
                        DataStore.MenuOpen = false;
                        XMen.Visible = !XMen.Visible;
                        Racist_Menu2();
                    }
                };
            }
            else
            {
                DataStore.iRaceSym = -1;
                DataStore.MenuOpen = false;
                XMen.Visible = !XMen.Visible;
            }
        }
        public static void Racist_Menu2()
        {
            LoggerLight.LogThis("Racist_Menu");

            var mainMenu = new UIMenu("Racisums", MissionData.MyRacists[MyRaceSet.Race].Name);
            YtmenuPool.Add(mainMenu);
            if (MissionData.MyRacists[MyRaceSet.Race].BaseLap.Track == MissionData.MyRacists[MyRaceSet.Race].Name)
            {
                Racist_SelectClass(mainMenu);
                Racist_SelectTime(mainMenu);
                Racist_SelectTraffic(mainMenu);
                if (MissionData.MyRacists[MyRaceSet.Race].Loop)
                    Racist_SelectLaps(mainMenu);
                Racist_SelectWeather(mainMenu);
                Racist_SelectSolo(mainMenu);
                Racist_SelectPasive(mainMenu);
                Racist_SelectAnimation(mainMenu);
                Racist_Launch(mainMenu);
                YtmenuPool.RefreshIndex();
                DataStore.MenuOpen = true;
                mainMenu.Visible = !mainMenu.Visible;
            }
            else
            {
                UI.Notify("A Base Lap is Required");
                MyRaceSet.VehClass = MissionData.MyRacists[MyRaceSet.Race].AvalableVeh[0];
                MyRaceSet.Anim = 0;
                MyRaceSet.Laps = 1;
                MyRaceSet.PasiveMode = false;
                MyRaceSet.Solo = true;
                MyRaceSet.Time = 12;
                MyRaceSet.Trafic = false;
                MyRaceSet.Weather = "Clear";
                MyRaceSet.BaseLap = true;
                DataStore.MenuOpen = false;
                mainMenu.Visible = false;
                NSPM.Raceist(MyRaceSet);
            }
        }
        private static void Racist_SelectClass(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectClass, MyRaceSet.Race == " + MyRaceSet.Race);

            List<int> Racisms = MissionData.MyRacists[MyRaceSet.Race].AvalableVeh;
            MyRaceSet.VehClass = Racisms[0];

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < Racisms.Count; i++)
                RaceList.Add(RaceClassList[Racisms[i] - 1]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[42], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                    MyRaceSet.VehClass = Racisms[index];
            };
        }
        private static void Racist_SelectTime(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectTime");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < RaceTimeList.Count; i++)
                RaceList.Add(RaceTimeList[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[41], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (index == 0)
                        MyRaceSet.Time = 6;
                    else if (index == 1)
                        MyRaceSet.Time = 12;
                    else if (index == 2)
                        MyRaceSet.Time = 18;
                    else 
                        MyRaceSet.Time = 21;
                }
            };
        }
        private static void Racist_SelectTraffic(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectTraffic");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < BoolSwitch.Count; i++)
                RaceList.Add(BoolSwitch[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[40], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (index == 0)
                        MyRaceSet.Trafic = false;
                    else
                        MyRaceSet.Trafic = true;
                }
            };
        }
        private static void Racist_SelectLaps(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectLaps");
            List<int> Racisms = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < Racisms.Count; i++)
                RaceList.Add(Racisms[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[39], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    MyRaceSet.Laps = RaceList[index];
                }
            };
        }
        private static void Racist_SelectWeather(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectWeather");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < RaceWeatherList.Count; i++)
                RaceList.Add(RaceWeatherList[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[38], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    MyRaceSet.Weather = RaceWeatherList[index];
                }
            };
        }
        private static void Racist_SelectSolo(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectSolo");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < BoolSwitch.Count; i++)
                RaceList.Add(BoolSwitch[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[6], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (index == 0)
                        MyRaceSet.Solo = false;
                    else
                        MyRaceSet.Solo = true;
                }
            };
        }
        private static void Racist_SelectPasive(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectPasive");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < BoolSwitch.Count; i++)
                RaceList.Add(BoolSwitch[i]);

            var ThisShizle = new UIMenuListItem(DataStore.MyLang.Context[37], RaceList, 0);

            XMen.AddItem(ThisShizle);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (index == 0)
                        MyRaceSet.PasiveMode = false;
                    else
                        MyRaceSet.PasiveMode = true;
                }
            };
        }
        private static void Racist_SelectAnimation(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_SelectAnimation");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < MissionData.MyRaceAnims.Count; i++)
                RaceList.Add(MissionData.MyRaceAnims[i].Name);

            var Bebop = new UIMenuListItem(DataStore.MyLang.Context[36], RaceList, 0);

            XMen.AddItem(Bebop);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == Bebop)
                {
                    MyRaceSet.Anim = index;
                    NSPM.Racist_RunAnimatior(MissionData.MyRaceAnims[index], Game.Player.Character, false);
                }
            };
        }
        private static void Racist_Launch(UIMenu XMen)
        {
            LoggerLight.LogThis("Racist_Launch");

            List<dynamic> RaceList = new List<dynamic>();

            for (int i = 0; i < BoolSwitch.Count; i++)
                RaceList.Add(BoolSwitch[i]);

            var ThisShizle = new UIMenuItem(DataStore.MyLang.Context[7]);

            XMen.AddItem(ThisShizle);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                DataStore.MenuOpen = false;
                XMen.Visible = !XMen.Visible;
                NSPM.Raceist(MyRaceSet);
            };
        }
    }
}
