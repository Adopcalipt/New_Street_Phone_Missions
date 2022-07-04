using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using New_Street_Phone_Missions.Classes;
using New_Street_Phone_Missions;
using System.Xml.Serialization;
using NativeUI;
using iFruitAddon2;
using GTA;
using GTA.Native;
using GTA.Math;

namespace NSPM_Contacts
{
    public class Contacts : Script
    {
        private bool bLogFiles = true;
        private bool bTrainM = true;
        private bool bStopDriving = false;
        private bool bMenuOpen = false;
        private bool bImports = false;
        private bool bWeapSwap = false;
        private bool bMeeddicc = false;
        private bool bWepMenuX = false;
        private bool bWeaponMan = false;
        private bool bFubarRide = false;
        private bool bFooWayPot = false;
        private bool bIFrutiyAdd = false;
        private bool bFuToMishTarg = false;
        private bool bFubFails = false;
        private bool bFunctionTime = false;

        private int iFunctionTime = 0;
        private int iFubCarzz = 0;
        private int iFubard = 0;
        private int iJustBribed = 0;
        private int iFuClock = 0;
        private int iFuFees = 0;
        private int iWait4Sec = 0;
        private int iService = 0;

        private readonly string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/ContactLog.txt";
        private readonly string sNSPMCont = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMContact.Xml";
        private readonly string sNSPMDatafile = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMData.NSPM";
        private readonly string sNSPMLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language";
        private string sLastVeh = "";

        private Vector3 vTarget_01 = Vector3.Zero;
        private Vector3 vTarget_02 = Vector3.Zero;
        private Vector3 vTarget_03 = Vector3.Zero;
        private Vector3 vTarget_04 = Vector3.Zero;
        private Vector3 vFuDest = Vector3.Zero;
        private Vector3 vFuFees = Vector3.Zero;

        private Vehicle FubarCarX = null;
        private Ped FUbarDrv = null;

        private List<string> sImpExpVeh = new List<string>();
        private List<string> sTrainerOnly = new List<string>();
        private List<string> sCustomCarz = new List<string>();
        private List<string> sCustomPlanez = new List<string>();
        private List<string> sCustomBoatsz = new List<string>();
        private List<string> sCustomChopperz = new List<string>();

        private List<int> iImpExpList = new List<int>();
        private List<bool> BeeEnabled;

        private CustomiFruit iFruit = new CustomiFruit();

        private List<MyMk2Weaps> Mk2WeapsMain = new List<MyMk2Weaps>();

        private TimerBarPool VTBTimerPool = new TimerBarPool();
        private TextTimerBar FuBar = new TextTimerBar("", "");

        private MenuPool YtmenuPool = new MenuPool();

        public Contacts()
        {
            if (File.Exists(sBeeLogs))
                File.Delete(sBeeLogs);

            while (!DataStore.bHasLoaded)
                Script.Wait(10);

            LogThis("Contacts Loaded == " + DataStore.bHasLoaded);

            BeeEnabled = BeenEnabled();

            OnLoadUp();

            Tick += OnTick;
            Interval = 1;
        }
        public List<bool> BeenEnabled()
        {
            List<bool> list = new List<bool>();

            for (int i = 0; i < 5; i++)
                list.Add(false);

            return list;
        }
        private void ShutThatPhone(int iFunct)
        {
            LogThis("ShutThatPhone iFunct == " + iFunct);

            iFruit.Close();
            while (Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, Game.Player.Character))
                Script.Wait(1);

            Script.Wait(1000);

            if (bIFrutiyAdd || FubarCarX != null || SearchFor.ComCarz.Count > 0)
            {
                bFubFails = true;
                Fubar_Clean();
            }


            if (iFunct == 1)
            {
                NSPMCoinAccount();
            }
            else if (iFunct == 2)
            {
                if (!Game.Player.Character.IsInVehicle())
                {
                    iService = 1;
                    sLastVeh = "Dilettante";
                    if (bFubFails)
                        SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Fubar", 10, false, true);
                    else
                        SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Fubar", 11, false, true);
                    bFubFails = false;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[0]);
            }
            else if (iFunct == 3)
            {
                if (!Game.Player.Character.IsInVehicle())
                    ImportsMenu();
                else
                    UI.Notify(DataStore.MyLang.ContactLang[464]);
            }
            else if (iFunct == 4)
            {
                if (!Game.Player.Character.IsInVehicle())
                {
                    if (DataStore.MyDatSet.iNSPMBank > 500)
                    {
                        UiDisplay.YourCoinPopUp(-500, 1, DataStore.MyLang.ContactLang[42]); 
                        iService = 2;
                        sLastVeh = "ambulance";
                        SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 2, "Medic", 11, false, true);
                    }
                    else
                        UI.Notify(DataStore.MyLang.ContactLang[41]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[3]);
            }
            else if (iFunct == 5)
            {
                var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[43], DataStore.MyLang.ContactLang[44]);
                YtmenuPool.Add(mainMenu);
                MkWepsOpt(mainMenu);
                YtmenuPool.RefreshIndex();
                bMenuOpen = true;
                mainMenu.Visible = !mainMenu.Visible;
            }
            else if (iFunct == 6)
            {
                if (!Game.Player.Character.IsInVehicle())
                    PeggsMenu();
                else
                    UI.Notify(DataStore.MyLang.ContactLang[1]);
            }
            else if (iFunct == 7)
            {
                if (iJustBribed < Game.GameTime)
                {
                    if (Game.Player.WantedLevel <= 3)
                    {
                        if (DataStore.MyDatSet.iNSPMBank > 499)
                        {
                            Game.Player.WantedLevel = 0;
                            UiDisplay.YourCoinPopUp(-500, 1, DataStore.MyLang.ContactLang[62]);
                            iJustBribed = Game.GameTime + 240000;
                        }
                        else
                            UI.Notify(DataStore.MyLang.ContactLang[41]);
                    }
                    else
                        UI.Notify(DataStore.MyLang.ContactLang[61]);
                }
                else
                {
                    int iTime = iJustBribed - Game.GameTime;
                    UI.Notify(DataStore.MyLang.ContactLang[60] + ReturnStuff.ShowComs(iTime, false, false));
                }
            }
            else if (iFunct == 8)
            {
                if (MissionData.bOnTheJob)
                    UI.Notify("On a Mission");
                else
                    GoSettiingsMenu();
            }

            bIFrutiyAdd = true;
            AddMissingCont();
        }
        private void GoSettiingsMenu()
        {
            TheMenus.SettingsMenu(false);
        }
        private void AddMissingCont()
        {
            LogThis("AddMissingCont");

            if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, Game.Player.Character))
            {
                if (!BeeEnabled[0])
                {
                    if (DataStore.MyAssets.Fubard)
                        Fruits(1);

                    BeeEnabled[0] = true;
                }
                if (!BeeEnabled[1])
                {
                    if (DataStore.MyAssets.PegsimortasTest)
                        Fruits(2);
                    BeeEnabled[1] = true;
                }
                if (!BeeEnabled[2])
                {
                    if (DataStore.MyAssets.GotPegsus)
                        Fruits(4);
                    BeeEnabled[2] = true;
                }
                if (!BeeEnabled[3])
                {
                    if (DataStore.MyAssets.WantedBribe)
                        Fruits(5);
                    BeeEnabled[3] = true;
                }
                if (!BeeEnabled[4])
                {
                    if (DataStore.MyAssets.MeddicTest)
                        Fruits(6);
                    BeeEnabled[4] = true;
                }
            }
        }
        private void LogThis(string sLog)
        {
            if (bLogFiles)
            {
                using (StreamWriter tEx = File.AppendText(sBeeLogs))
                    tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");
            }
        }
        public void SaveXmlContacts(XmlContacts config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public XmlContacts LoadXmlContacts(string fileName)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (XmlContacts)xml.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                return NewCont();
            }
        }
        public XmlContacts NewCont()
        {
            XmlContacts ThisCont = new XmlContacts
            {
                FuMiss = Vector3.Zero,
                ImpXCars = new List<string>(),
                ImpXList = new List<int>(),
                MyMk2Weaps = new List<MyMk2Weaps>()
            };
            return ThisCont;
    }
        private void ReadContacts()
        {
            LogThis("ReadContacts");

            if (File.Exists(sNSPMCont))
            {
                XmlContacts XSets = LoadXmlContacts(sNSPMCont);
                Mk2WeapsMain = XSets.MyMk2Weaps;

                sImpExpVeh = XSets.ImpXCars;
                iImpExpList = XSets.ImpXList;

                if (sImpExpVeh.Count != iImpExpList.Count)
                {
                    sImpExpVeh.Clear();
                    iImpExpList.Clear();
                    sImpExpVeh.Add(ImportsExpo_CarList(1));
                    iImpExpList.Add(1);
                    sImpExpVeh.Add(ImportsExpo_CarList(2));
                    iImpExpList.Add(2);
                    sImpExpVeh.Add(ImportsExpo_CarList(3));
                    iImpExpList.Add(3);
                    sImpExpVeh.Add(ImportsExpo_CarList(4));
                    iImpExpList.Add(4);
                    sImpExpVeh.Add(ImportsExpo_CarList(5));
                    iImpExpList.Add(5);
                    sImpExpVeh.Add(ImportsExpo_CarList(6));
                    iImpExpList.Add(6);
                    sImpExpVeh.Add(ImportsExpo_CarList(7));
                    iImpExpList.Add(7);
                    sImpExpVeh.Add(ImportsExpo_CarList(8));
                    iImpExpList.Add(8);
                    sImpExpVeh.Add(ImportsExpo_CarList(9));
                    iImpExpList.Add(9);
                }

                XSets.ImpXCars = sImpExpVeh;
                XSets.ImpXList = iImpExpList;
                XSets.FuMiss = Vector3.Zero;
                SaveXmlContacts(XSets, sNSPMCont);
            }
        }
        private void WriteContacts()
        {
            LogThis("WriteContacts");

            if (File.Exists(sNSPMCont))
            {
                XmlContacts XSets = LoadXmlContacts(sNSPMCont);
                XSets.MyMk2Weaps = Mk2WeapsMain;
                SaveXmlContacts(XSets, sNSPMCont);
            }
            else
            {
                XmlContacts XSets = new XmlContacts
                {
                    MyMk2Weaps = Mk2WeapsMain
                };
                SaveXmlContacts(XSets, sNSPMCont);
            }
        }
        private void AddMissWeaps(List<MyMk2Weaps> DemWeaps, bool bOldTest)
        {
            LogThis("AddMissWeaps");

            try
            {
                if (DemWeaps != null)
                {
                    if (bOldTest)
                    {
                        bWeapSwap = false;
                        int iPed = MyChar();
                        for (int i = 0; i < Mk2WeapsMain.Count; i++)
                            Mk2WeapsMain[i].MyPlayer = iPed;
                        AddMissWeaps(Mk2WeapsMain, false);
                    }
                    else
                    {
                        int iThisChar = MyChar();
                        for (int i = 0; i < Mk2WeapsMain.Count; i++)
                        {
                            if (iThisChar == Mk2WeapsMain[i].MyPlayer)
                            {
                                Function.Call(Hash.GIVE_WEAPON_TO_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, Mk2WeapsMain[i].Mk2Weap), 9999, false, true);
                                for (int ii = 0; ii < Mk2WeapsMain[i].Mk2Addon.Count; ii++)
                                    Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, Mk2WeapsMain[i].Mk2Weap), Function.Call<int>(Hash.GET_HASH_KEY, Mk2WeapsMain[i].Mk2Addon[ii]));

                                Mk2WeapsMain[i].MyAmmos = MaxAmmo(Mk2WeapsMain[i].Mk2Weap, Game.Player.Character);

                                FillMyAmmo(Mk2WeapsMain[i].Mk2Weap, Mk2WeapsMain[i].MyAmmos);

                                if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, Mk2WeapsMain[i].Mk2Weap)) < MaxAmmo(Mk2WeapsMain[i].Mk2Weap, Game.Player.Character))
                                {
                                    Script.Wait(500);
                                    FillMyAmmo(Mk2WeapsMain[i].Mk2Weap, Mk2WeapsMain[i].MyAmmos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // An unexpected error occured.
            }
        }
        private void AddNPC(string sModel, Vector3 vPos, float fHeads, Vehicle vHick, int iService)
        {
            LogThis("AddNPC, sModel == " + sModel + ", iService == " + iService);

            FUbarDrv = null;

            FUbarDrv = ObjectBuild.NPCSpawn(sModel, vPos, fHeads, false, 140, 0, 1, vHick, 0, false, 0, 0, "");

            if (FUbarDrv.Exists())
            {
                FUbarDrv.Accuracy = 45;
                FUbarDrv.MaxHealth = 250;
                FUbarDrv.Health = 250;
                if (vHick != null)
                    WarptoAnyVeh(vHick, FUbarDrv, 1);

                FUbarDrv.Task.ClearAll();
                FUbarDrv.BlockPermanentEvents = true;
                vFuDest = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                FUbarDrv.Task.DriveTo(vHick, vFuDest, 3.00f, 35.00f, 536871355);
                FUbarDrv.CanBeDraggedOutOfVehicle = false;

                if (iService == 1)
                {
                    bFubarRide = true;
                    bMeeddicc = false;
                    bWeaponMan = false;
                }
                else if (iService == 2)
                {
                    bMeeddicc = true;
                    bFubarRide = false;
                    bWeaponMan = false;
                }
                else if (iService == 3)
                {
                    bWeaponMan = true;
                    bFubarRide = false;
                    bMeeddicc = false;
                }

                iFubCarzz = 0;
            }
        }
        public bool VehExists(Vehicle[] Vlist, int iPos)
        {
            bool bExist = false;

            if (iPos < Vlist.Count())
            {
                unsafe
                {
                    if (Vlist[iPos].Exists())
                        bExist = true;
                }
            }

            return bExist;
        }
        public bool IsItARealVehicle(string sVehName)
        {
            bool bIsReal = false;

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehName);
            if (Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
                bIsReal = true;

            return bIsReal;
        }
        private void WarptoAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            LogThis("WarptoAnyVeh, iSeat == " + iSeat);

            bool bFader = false;
            if (Peddy == Game.Player.Character)
            {
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                bFader = true;
            }

            while (!Peddy.IsInVehicle(Vhic))
            {
                if (Peddy.IsInVehicle())
                    Peddy.Task.LeaveVehicle();

                VehicleWarp(Vhic, Peddy, iSeat);
                Script.Wait(100);
            }

            if (bFader)
            {
                Script.Wait(500);
                Game.FadeScreenIn(1000);
            }
        }
        private void VehicleWarp(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            Function.Call(Hash.SET_PED_INTO_VEHICLE, Peddy, Vhic, iSeat - 2);
        }
        private void ControlerUI(string sText, int iDuration)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sText);
            Function.Call(Hash._0x238FFE5C7B0498A6, false, false, false, iDuration);
        }
        public bool ButtonDown(int CButt)
        {
            ButtonDisabler(CButt);
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        private void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        private void Fubar_Carzz(bool bMissionTarget)
        {
            LogThis("Fubar_Carzz, bMissionTarget == " + bMissionTarget);

            int iFifty = 10;
            if (bMissionTarget)
            {
                if (MissionData.vFuMiss != Vector3.Zero)
                {
                    Game.FadeScreenOut(1000);
                    Script.Wait(1000);
                    FubarCarX.Position = MissionData.vFuMiss;
                    Game.Player.Character.Task.LeaveVehicle();
                    Fubar_Math(false);
                    iFuFees *= -1;
                    UiDisplay.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[14]);                   
                    iFuFees = 0;
                    Game.FadeScreenIn(1000);
                    MissionData.vFuMiss = Vector3.Zero;
                    Fubar_Clean();
                }
            }
            else
            {
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                FubarCarX.FreezePosition = true;
                vFuDest.Z = World.GetGroundHeight(MissionData.vFuMiss);
                FubarCarX.Position = vFuDest;
                Script.Wait(1000);
                FubarCarX.FreezePosition = false;
                FubarCarX.Position = World.GetNextPositionOnStreet(vFuDest);
                while (World.GetStreetName(FubarCarX.Position) != World.GetStreetName(vFuDest) && iFifty > 0)
                {
                    Script.Wait(100);
                    iFifty -= 1;
                    FubarCarX.Position = World.GetNextPositionOnStreet(vFuDest);
                }
                if (iFifty < 1)
                    FubarCarX.Position = vFuDest;
                Game.Player.Character.Task.LeaveVehicle();
                Fubar_Math(false);
                iFuFees *= -1;
                UiDisplay.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[14]);
                iFuFees = 0;
                Game.FadeScreenIn(1000);
                Fubar_Clean();
            }
        }
        private void Fubar_Clean()
        {
            LogThis("Fubar_Clean");

            SearchFor.ComCarz.Clear();
            if (FubarCarX != null)
            {
                FubarCarX.CloseDoor(VehicleDoor.BackLeftDoor, false);
                FubarCarX.CloseDoor(VehicleDoor.BackRightDoor, false);

                if (FubarCarX.CurrentBlip.Exists())
                    FubarCarX.CurrentBlip.Remove();

                ObjectHand.ReadWriteBlips(false, false, -1, -1, -1, -1, FubarCarX.Handle, -1);
                MissionData.VehicleList_01.Remove(FubarCarX);
            }
            else if (DataStore.SharedVeh != null)
            {
                if (DataStore.SharedVeh.CurrentBlip.Exists())
                    DataStore.SharedVeh.CurrentBlip.Remove();

                ObjectHand.ReadWriteBlips(false, false, -1, -1, -1, -1, DataStore.SharedVeh.Handle, -1);
                MissionData.VehicleList_01.Remove(DataStore.SharedVeh);
            }
            if (FUbarDrv != null)
            {
                ObjectHand.ReadWriteBlips(false, false, -1, -1, FUbarDrv.Handle, -1, -1, -1);
                MissionData.PedList_01.Remove(FUbarDrv);
                FUbarDrv.MarkAsNoLongerNeeded();
            }
            VTBTimerPool.Remove(FuBar);
            iFubCarzz = 0;
            bWepMenuX = false;
            bFubarRide = false;
            bIFrutiyAdd = false;
            bFuToMishTarg = false;
            bWeaponMan = false;
            bMeeddicc = false;
            bImports = false;
            FubarCarX = null;
            FUbarDrv = null;
        }
        private void Fubar_Math(bool bTextBar)
        {
            iFuClock = Game.GameTime + 5000;
            if (iFubard > 99)
                iFuFees = 0;
            else
            {
                float fFIndFee = vFuFees.DistanceTo(FubarCarX.Position) / 50;
                int iCost = (int)fFIndFee + 5;
                if (iCost > iFuFees)
                    iFuFees = iCost;
            }

            if (bTextBar)
                FuBar.Text = DataStore.MyLang.ContactLang[15] + iFuFees;
        }
        private void Fruits(int iAdd)
        {
            LogThis("Fruits, iAdd == " + iAdd);

            if (iAdd == 0)
            {
                iFruit.CenterButtonColor = System.Drawing.Color.Orange;
                iFruit.LeftButtonColor = System.Drawing.Color.LimeGreen;
                iFruit.RightButtonColor = System.Drawing.Color.Purple;
                iFruit.CenterButtonIcon = SoftKeyIcon.Fire;
                iFruit.LeftButtonIcon = SoftKeyIcon.Police;
                iFruit.RightButtonIcon = SoftKeyIcon.Call;

                iFruitContact NSPMCoins = new iFruitContact(DataStore.MyLang.ContactLang[16]);
                NSPMCoins.Answered += NSPMCoinAnswered;             // Linking the Answered event with our function
                NSPMCoins.DialTimeout = 4000;                       // Delay before answering
                NSPMCoins.Active = true;                            // true = the contact is available and will answer the phone
                NSPMCoins.Icon = ContactIcon.MazeBank;              // Contact's icon
                iFruit.Contacts.Add(NSPMCoins);                     // Add the contact to the phone
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~"+ DataStore.MyLang.ContactLang[16]);
            }
            else if (iAdd == 1)
            {
                iFruitContact FubarCarz = new iFruitContact(DataStore.MyLang.ContactLang[18]);
                FubarCarz.Answered += FubarsAnswered;
                FubarCarz.DialTimeout = 4000;
                FubarCarz.Active = true;
                FubarCarz.Icon = ContactIcon.Property_TaxiLot;
                iFruit.Contacts.Add(FubarCarz);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~"+ DataStore.MyLang.ContactLang[18]);
            }
            else if (iAdd == 2)
            {
                iFruitContact ImportantCarz = new iFruitContact(DataStore.MyLang.ContactLang[19]);
                ImportantCarz.Answered += ImportsAnswered;
                ImportantCarz.DialTimeout = 4000;
                ImportantCarz.Active = true;
                ImportantCarz.Icon = ContactIcon.LegendaryMotorsport;
                iFruit.Contacts.Add(ImportantCarz);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~"+ DataStore.MyLang.ContactLang[19]);
            }
            else if (iAdd == 3)
            {
                iFruitContact GunDelivery = new iFruitContact(DataStore.MyLang.ContactLang[20]);
                GunDelivery.Answered += WeapsAnswered;
                GunDelivery.DialTimeout = 4000;
                GunDelivery.Active = true;
                GunDelivery.Icon = ContactIcon.Ammunation;
                iFruit.Contacts.Add(GunDelivery);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[20]);
            }
            else if (iAdd == 4)
            {
                iFruitContact Peggasis = new iFruitContact(DataStore.MyLang.ContactLang[21]);
                Peggasis.Answered += PeggsAnswered;
                Peggasis.DialTimeout = 4000;
                Peggasis.Active = true;
                Peggasis.Icon = ContactIcon.Pegasus;
                iFruit.Contacts.Add(Peggasis);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~"+ DataStore.MyLang.ContactLang[21]);
            }
            else if (iAdd == 5)
            {
                iFruitContact Bribes = new iFruitContact(DataStore.MyLang.ContactLang[22]);
                Bribes.Answered += BribesAnswered;
                Bribes.DialTimeout = 4000;
                Bribes.Active = true;
                Bribes.Icon = ContactIcon.MP_FibContact;
                iFruit.Contacts.Add(Bribes);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[22]);
            }
            else if (iAdd == 6)
            {
                iFruitContact Medic = new iFruitContact(DataStore.MyLang.ContactLang[23]);
                Medic.Answered += MedicAnswered;
                Medic.DialTimeout = 4000;
                Medic.Active = true;
                Medic.Icon = ContactIcon.Emergency;
                iFruit.Contacts.Add(Medic);
                UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~"+ DataStore.MyLang.ContactLang[23]);
            }
            else if (iAdd == 7)
            {
                iFruitContact MySets = new iFruitContact(DataStore.MyLang.Othertext[67]);
                MySets.Answered += SettingsAnswered;
                MySets.DialTimeout = 4000;
                MySets.Active = true;
                MySets.Icon = ContactIcon.Skull;
                iFruit.Contacts.Add(MySets);
            }
        }
        private void NSPMCoinAnswered(iFruitContact contact)
        {
            LogThis("NSPMCoinAnswered");
            bFunctionTime = true;
            iFunctionTime = 1;
        }
        private void NSPMCoinAccount()
        {
            LogThis("NSPMCoinAccount");

            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[15], DataStore.MyLang.ContactLang[15] + DataStore.MyLang.ContactLang[24]);
            YtmenuPool.Add(mainMenu);
            NSPMCurrentAcc(mainMenu);
            NSPMLowRiskAcc(mainMenu);
            NSPMHighRiskAcc(mainMenu);
            YtmenuPool.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void NSPMCurrentAcc(UIMenu XMen)
        {
            LogThis("NSPMCurrentAcc");
            var CurrentAccmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[25] + DataStore.MyLang.ContactLang[24]);

            var item_01 = new UIMenuItem(DataStore.MyLang.ContactLang[26], "");
            CurrentAccmenu.AddItem(item_01);

            var item_02 = new UIMenuItem(DataStore.MyLang.ContactLang[27], "");
            CurrentAccmenu.AddItem(item_02);

            var item_03 = new UIMenuItem(DataStore.MyLang.ContactLang[28], "");
            CurrentAccmenu.AddItem(item_03);

            CurrentAccmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == item_01)
                {
                    UI.Notify(DataStore.MyLang.ContactLang[29] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMBank, true, true));
                    YtmenuPool.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.bBankTransfer = true;
                    DataStore.iCoinBats = 1;
                    YtmenuPool.CloseAllMenus();
                }
                else
                    YtmenuPool.CloseAllMenus();
            };
        }
        private void NSPMLowRiskAcc(UIMenu XMen)
        {
            LogThis("NSPMLowRiskAcc");
            var LowAccmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[70]);

            var item_01 = new UIMenuItem(DataStore.MyLang.ContactLang[26], "");
            LowAccmenu.AddItem(item_01);

            var item_02 = new UIMenuItem(DataStore.MyLang.ContactLang[27], "");
            LowAccmenu.AddItem(item_02);

            var item_03 = new UIMenuItem(DataStore.MyLang.ContactLang[28], "");
            LowAccmenu.AddItem(item_03);

            LowAccmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == item_01)
                {
                    UI.Notify(DataStore.MyLang.ContactLang[29] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCLowRisk, true, true));
                    YtmenuPool.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.bBankTransfer = true;
                    DataStore.iCoinBats = 2;
                    YtmenuPool.CloseAllMenus();
                }
                else
                    YtmenuPool.CloseAllMenus();
            };
        }
        private void NSPMHighRiskAcc(UIMenu XMen)
        {
            LogThis("NSPMHighRiskAcc");
            var HighAccmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[71]);

            var item_01 = new UIMenuItem(DataStore.MyLang.ContactLang[26], "");
            HighAccmenu.AddItem(item_01);

            var item_02 = new UIMenuItem(DataStore.MyLang.ContactLang[27], "");
            HighAccmenu.AddItem(item_02);

            var item_03 = new UIMenuItem(DataStore.MyLang.ContactLang[28], "");
            HighAccmenu.AddItem(item_03);

            HighAccmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == item_01)
                {
                    UI.Notify(DataStore.MyLang.ContactLang[29] + ReturnStuff.ShowComs(DataStore.MyDatSet.iNSPMCHighRisk, true, true));
                    YtmenuPool.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.bBankTransfer = true;
                    DataStore.iCoinBats = 3;
                    YtmenuPool.CloseAllMenus();
                }
                else
                    YtmenuPool.CloseAllMenus();
            };
        }
        private void FubarsAnswered(iFruitContact contact)
        {
            LogThis("FubarsAnswered");
            bFunctionTime = true;
            iFunctionTime = 2;
        }
        private void ImportsAnswered(iFruitContact contact)
        {
            LogThis("ImportsAnswered");
            bFunctionTime = true;
            iFunctionTime = 3;
        }
        private void ImportsMenu()
        {
            LogThis("ImportsMenu");
            
            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[19], DataStore.MyLang.ContactLang[30]);
            YtmenuPool.Add(mainMenu);
            ImportExList(mainMenu);
            YtmenuPool.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void ImportExList(UIMenu XMen)
        {
            var Submenu_01 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[31]);
            var Submenu_03 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[32]);
            var Submenu_05 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[33]);
            var Submenu_04 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[34]);
            var Submenu_08 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[35]);
            var Submenu_02 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[36]);
            var Submenu_09 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[37]);
            var Submenu_06 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[38]);
            var Submenu_07 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[39]);
            var Submenu_10 = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[40]);

            List<string> sub_01 = new List<string>();
            List<string> sub_02 = new List<string>();
            List<string> sub_03 = new List<string>();
            List<string> sub_04 = new List<string>();
            List<string> sub_05 = new List<string>();
            List<string> sub_06 = new List<string>();
            List<string> sub_07 = new List<string>();
            List<string> sub_08 = new List<string>();
            List<string> sub_09 = new List<string>();
            List<string> sub_10 = new List<string>();

            if (!bTrainM)
            {
                for (int i = 0; i < sImpExpVeh.Count; i++)
                {
                    if (sTrainerOnly.Contains(sImpExpVeh[i]))
                    {
                        sImpExpVeh.RemoveAt(i);
                        iImpExpList.RemoveAt(i);
                    }
                }
            }

            for (int i = 0; i < sImpExpVeh.Count; i++)
            {
                if (iImpExpList[i] == 1)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(sImpExpVeh[i]);
                }                     //Super
                else if (iImpExpList[i] == 2)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_02.AddItem(item_);
                    sub_02.Add(sImpExpVeh[i]);
                }                //Coupe
                else if (iImpExpList[i] == 3)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_03.AddItem(item_);
                    sub_03.Add(sImpExpVeh[i]);
                }                //Sports
                else if (iImpExpList[i] == 4)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_04.AddItem(item_);
                    sub_04.Add(sImpExpVeh[i]);
                }                //Mussle
                else if (iImpExpList[i] == 5)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_05.AddItem(item_);
                    sub_05.Add(sImpExpVeh[i]);
                }                //SportsClassic
                else if (iImpExpList[i] == 6)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_06.AddItem(item_);
                    sub_06.Add(sImpExpVeh[i]);
                }                //Compact
                else if (iImpExpList[i] == 7)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_07.AddItem(item_);
                    sub_07.Add(sImpExpVeh[i]);
                }                //Sedan
                else if (iImpExpList[i] == 8)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_08.AddItem(item_);
                    sub_08.Add(sImpExpVeh[i]);
                }                //Offroad/
                else if (iImpExpList[i] == 9)
                {
                    var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                    Submenu_09.AddItem(item_);
                    sub_09.Add(sImpExpVeh[i]);
                }                //SUV
                else
                {
                    if (IsItARealVehicle(sImpExpVeh[i]))
                    {
                        var item_ = new UIMenuItem(GetEntName(sImpExpVeh[i]), "");
                        Submenu_10.AddItem(item_);
                        sub_10.Add(sImpExpVeh[i]);
                    }
                    else
                    {
                        sImpExpVeh.RemoveAt(i);
                        iImpExpList.RemoveAt(i);
                    }
                }
            }

            Submenu_01.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_01[index]; 
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_01[index], false, 4, OhMyBlip(sub_01[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_02.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_02[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0 , 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_02[index], false, 4, OhMyBlip(sub_02[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_03.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_03[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_03[index], false, 4, OhMyBlip(sub_03[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_04.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_04[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_04[index], false, 4, OhMyBlip(sub_04[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_05.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_05[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_05[index], false, 4, OhMyBlip(sub_05[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_06.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_06[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_06[index], false, 4, OhMyBlip(sub_06[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_07.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_07[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_07[index], false, 4, OhMyBlip(sub_07[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_08.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_08[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_08[index], false, 4, OhMyBlip(sub_08[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_09.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_09[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_09[index], false, 4, OhMyBlip(sub_09[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
            Submenu_10.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_10[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Import", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sub_10[index], false, 4, OhMyBlip(sub_10[index], 225), true, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        public string ImportsExpo_CarList(int iVechList)
        {
            LogThis("ImportsExpo_CarList, iVechList == " + iVechList);

            List<string> sVehicles = new List<string>();

            string sThisVehicle = "";

            if (iVechList == 1)
            {
                sVehicles.Add("PFISTER811");
                sVehicles.Add("ADDER");
                sVehicles.Add("AUTARCH");
                sVehicles.Add("BANSHEE2");
                sVehicles.Add("BULLET");
                sVehicles.Add("CHEETAH");
                sVehicles.Add("CYCLONE");
                sVehicles.Add("ENTITYXF");
                sVehicles.Add("ENTITY2");
                sVehicles.Add("SHEAVA");
                sVehicles.Add("FMJ");
                sVehicles.Add("GP1");
                sVehicles.Add("INFERNUS");
                sVehicles.Add("ITALIGTB");
                sVehicles.Add("ITALIGTB2");
                sVehicles.Add("OSIRIS");
                sVehicles.Add("NERO");
                sVehicles.Add("NERO2");
                sVehicles.Add("PENETRATOR");
                sVehicles.Add("LE7B");
                sVehicles.Add("REAPER");
                sVehicles.Add("VOLTIC2");
                sVehicles.Add("SC1");
                sVehicles.Add("SULTANRS");
                sVehicles.Add("T20");
                sVehicles.Add("TAIPAN");
                sVehicles.Add("TEMPESTA");
                sVehicles.Add("TEZERACT");
                sVehicles.Add("TURISMOR");
                sVehicles.Add("TYRANT");
                sVehicles.Add("TYRUS");
                sVehicles.Add("VACCA");
                sVehicles.Add("VAGNER");
                sVehicles.Add("VISIONE");
                sVehicles.Add("VOLTIC");
                sVehicles.Add("PROTOTIPO");
                sVehicles.Add("XA21");
                sVehicles.Add("ZENTORNO");
                if (bTrainM)
                {
                    sVehicles.Add("DEVESTE");
                    sVehicles.Add("EMERUS");
                    sVehicles.Add("FURIA");
                    sVehicles.Add("KRIEGER");
                    sVehicles.Add("THRAX");
                    sVehicles.Add("ZORRUSSO");
                    sVehicles.Add("TIGON");
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }            //Super
            else if (iVechList == 2)
            {
                sVehicles.Add("COGCABRIO"); //
                sVehicles.Add("EXEMPLAR"); //
                sVehicles.Add("F620"); //
                sVehicles.Add("FELON"); //
                sVehicles.Add("FELON2"); //<!-- Felon GT -->
                sVehicles.Add("JACKAL"); //
                sVehicles.Add("ORACLE"); //
                sVehicles.Add("ORACLE2"); //<!-- Oracle XS -->
                sVehicles.Add("SENTINEL2"); //<!-- Sentinel -->
                sVehicles.Add("SENTINEL"); //<!-- Sentinel XS -->
                sVehicles.Add("WINDSOR"); //
                sVehicles.Add("WINDSOR2"); //<!-- Windsor Drop -->
                sVehicles.Add("ZION"); //
                sVehicles.Add("ZION2"); //<!-- Zion Cabrio -->

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Coupe
            else if (iVechList == 3)
            {
                sVehicles.Add("NINEF"); //
                sVehicles.Add("NINEF2"); //<!-- 9F Cabrio -->
                sVehicles.Add("ALPHA"); //
                sVehicles.Add("BANSHEE"); //
                sVehicles.Add("BESTIAGTS"); //
                sVehicles.Add("BLISTA2"); //<!-- Blista Compact -->
                sVehicles.Add("BUFFALO"); //
                sVehicles.Add("BUFFALO2"); //<!-- Buffalo S -->
                sVehicles.Add("CARBONIZZARE"); //
                sVehicles.Add("COMET2"); //<!-- Comet -->
                sVehicles.Add("COMET3"); //<!-- Comet Retro Custom -->
                sVehicles.Add("COMET4"); //<!-- Comet Safari -->
                sVehicles.Add("COMET5"); //<!-- Comet SR -->
                sVehicles.Add("COQUETTE"); //
                sVehicles.Add("TAMPA2"); //<!-- Drift Tampa -->
                sVehicles.Add("ELEGY"); //<!-- Elegy Retro Custom -->
                sVehicles.Add("ELEGY2"); //<!-- Elegy RH8 -->
                sVehicles.Add("FELTZER2"); //<!-- Feltzer -->
                sVehicles.Add("FLASHGT"); //
                sVehicles.Add("FUROREGT"); //
                sVehicles.Add("FUSILADE"); //
                sVehicles.Add("FUTO"); //
                sVehicles.Add("GB200"); //
                sVehicles.Add("BLISTA3"); //<!-- Go Go Monkey Blista -->
                sVehicles.Add("HOTRING"); //
                sVehicles.Add("JESTER"); //
                sVehicles.Add("JESTER2"); //<!-- Jester (Racecar) -->
                sVehicles.Add("JESTER3"); //<!-- Jester Classic -->
                sVehicles.Add("KHAMELION"); //
                sVehicles.Add("KURUMA"); //
                sVehicles.Add("LYNX"); //
                sVehicles.Add("MASSACRO"); //
                sVehicles.Add("MASSACRO2"); //<!-- Massacro (Racecar) -->
                sVehicles.Add("NEON"); //
                sVehicles.Add("OMNIS"); //
                sVehicles.Add("PARIAH"); //
                sVehicles.Add("PENUMBRA"); //
                sVehicles.Add("RAIDEN"); //
                sVehicles.Add("RAPIDGT"); //
                sVehicles.Add("RAPIDGT2"); //<!-- Rapid GT Cabrio -->
                sVehicles.Add("RAPTOR"); //
                sVehicles.Add("REVOLTER"); //
                sVehicles.Add("RUSTON"); //
                sVehicles.Add("SCHAFTER4"); //<!-- Schafter LWB -->
                sVehicles.Add("SCHAFTER3"); //<!-- Schafter V12 -->
                sVehicles.Add("SCHWARZER"); //
                sVehicles.Add("SENTINEL3"); //<!-- Sentinel Classic -->
                sVehicles.Add("SEVEN70"); //
                sVehicles.Add("SPECTER"); //
                sVehicles.Add("SPECTER2"); //<!-- Specter Custom -->
                sVehicles.Add("BUFFALO3"); //<!-- Sprunk Buffalo -->
                sVehicles.Add("STREITER"); //
                sVehicles.Add("SULTAN"); //
                sVehicles.Add("SURANO"); //
                sVehicles.Add("TROPOS"); //
                sVehicles.Add("VERLIERER2"); //
                if (bTrainM)
                {
                    sVehicles.Add("DRAFTER"); //<!-- 8F Drafter -->
                    sVehicles.Add("IMORGON"); //
                    sVehicles.Add("ISSI7"); //<!-- Issi Sport -->
                    sVehicles.Add("ITALIGTO"); //
                    sVehicles.Add("JUGULAR"); //
                    sVehicles.Add("KOMODA"); //
                    sVehicles.Add("LOCUST"); //
                    sVehicles.Add("NEO"); //
                    sVehicles.Add("PARAGON"); //
                    sVehicles.Add("PARAGON2"); //<!-- Paragon R (Armored) -->
                    sVehicles.Add("SCHLAGEN"); //
                    sVehicles.Add("SUGOI"); //
                    sVehicles.Add("SULTAN2"); //<!-- Sultan Classic -->
                    sVehicles.Add("VSTR"); //<!-- V-STR -->
                    sVehicles.Add("COQUETTE4"); //<!-- Coquette D10  -->
                    sVehicles.Add("PENUMBRA2"); //<!-- Penumbra FF   -->
                    sVehicles.Add("ITALIRSX"); //><!-- Grotti Itali RSX -->Spports
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Sport
            else if (iVechList == 4)
            {
                sVehicles.Add("BLADE"); //
                sVehicles.Add("BUCCANEER"); //
                sVehicles.Add("BUCCANEER2"); //<!-- Buccaneer Custom -->
                sVehicles.Add("STALION2"); //<!-- Burger Shot Stallion -->
                sVehicles.Add("CHINO"); //
                sVehicles.Add("CHINO2"); //<!-- Chino Custom -->
                sVehicles.Add("COQUETTE3"); //<!-- Coquette BlackFin -->
                sVehicles.Add("DOMINATOR"); //
                sVehicles.Add("DOMINATOR3"); //<!-- Dominator GTX -->
                sVehicles.Add("YOSEMITE2"); //<!-- Drift Yosemite -->
                sVehicles.Add("DUKES"); //
                sVehicles.Add("ELLIE"); //
                sVehicles.Add("FACTION"); //
                sVehicles.Add("FACTION2"); //<!-- Faction Custom -->
                sVehicles.Add("FACTION3"); //<!-- Faction Custom Donk -->
                sVehicles.Add("GAUNTLET"); //
                sVehicles.Add("HERMES"); //
                sVehicles.Add("HOTKNIFE"); //
                sVehicles.Add("HUSTLER"); //
                sVehicles.Add("SLAMVAN2"); //<!-- Lost Slamvan -->
                sVehicles.Add("LURCHER"); //
                sVehicles.Add("MOONBEAM"); //
                sVehicles.Add("MOONBEAM2"); //<!-- Moonbeam Custom -->
                sVehicles.Add("NIGHTSHADE"); //
                sVehicles.Add("PHOENIX"); //
                sVehicles.Add("PICADOR"); //
                sVehicles.Add("DOMINATOR2"); //<!-- Pisswasser Dominator -->
                sVehicles.Add("RATLOADER"); //
                sVehicles.Add("RATLOADER2"); //<!-- Rat-Truck -->
                sVehicles.Add("GAUNTLET2"); //<!-- Redwood Gauntlet -->
                sVehicles.Add("RUINER"); //
                sVehicles.Add("SABREGT"); //
                sVehicles.Add("SABREGT2"); //<!-- Sabre Turbo Custom -->
                sVehicles.Add("SLAMVAN"); //
                sVehicles.Add("SLAMVAN3"); //<!-- Slamvan Custom -->
                sVehicles.Add("STALION"); //
                sVehicles.Add("TAMPA"); //
                sVehicles.Add("VIGERO"); //
                sVehicles.Add("VIRGO"); //
                sVehicles.Add("VIRGO3"); //<!-- Virgo Classic -->
                sVehicles.Add("VIRGO2"); //<!-- Virgo Classic Custom -->
                sVehicles.Add("VOODOO"); //
                sVehicles.Add("VOODOO2"); //<!-- Voodoo Custom -->
                sVehicles.Add("YOSEMITE"); //
                if (bTrainM)
                {
                    sVehicles.Add("CLIQUE"); //
                    sVehicles.Add("DEVIANT"); //
                    sVehicles.Add("GAUNTLET3"); //<!-- Gauntlet Classic -->
                    sVehicles.Add("GAUNTLET4"); //<!-- Gauntlet Hellfire -->
                    sVehicles.Add("PEYOTE2"); //<!-- Peyote Gasser -->
                    sVehicles.Add("IMPALER"); //
                    sVehicles.Add("TULIP"); //
                    sVehicles.Add("VAMOS"); //
                    sVehicles.Add("DUKES3"); //
                    sVehicles.Add("GAUNTLET5"); //
                    sVehicles.Add("MANANA2"); //
                    sVehicles.Add("PEYOTE3"); //
                    sVehicles.Add("GLENDALE2"); //
                    sVehicles.Add("YOSEMITE3"); //
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Mussle
            else if (iVechList == 5)
            {
                sVehicles.Add("Z190"); //<!-- 190z -->
                sVehicles.Add("ARDENT"); //
                sVehicles.Add("CASCO"); //
                sVehicles.Add("CHEBUREK"); //
                sVehicles.Add("CHEETAH2"); //<!-- Cheetah Classic -->
                sVehicles.Add("COQUETTE2"); //<!-- Coquette Classic -->
                sVehicles.Add("FAGALOA"); //
                sVehicles.Add("BTYPE2"); //<!-- FrÃ¤nken Stange -->
                sVehicles.Add("GT500"); //
                sVehicles.Add("INFERNUS2"); //<!-- Infernus Classic -->
                sVehicles.Add("JB700"); //
                sVehicles.Add("MAMBA"); //
                sVehicles.Add("MANANA"); //
                sVehicles.Add("MICHELLI"); //
                sVehicles.Add("MONROE"); //
                sVehicles.Add("PEYOTE"); //
                sVehicles.Add("PIGALLE"); //
                sVehicles.Add("RAPIDGT3"); //<!-- Rapid GT Classic -->
                sVehicles.Add("RETINUE"); //
                sVehicles.Add("BTYPE"); //<!-- Roosevelt -->
                sVehicles.Add("BTYPE3"); //<!-- Roosevelt Valor -->
                sVehicles.Add("SAVESTRA"); //
                sVehicles.Add("STINGER"); //
                sVehicles.Add("STINGERGT"); //
                sVehicles.Add("FELTZER3"); //<!-- Stirling GT -->
                sVehicles.Add("SWINGER"); //
                sVehicles.Add("TORERO"); //
                sVehicles.Add("TORNADO"); //
                sVehicles.Add("TORNADO2"); //<!-- Tornado Cabrio -->
                sVehicles.Add("TORNADO3"); //<!-- Rusty Tornado -->
                sVehicles.Add("TORNADO4"); //<!-- Mariachi Tornado -->
                sVehicles.Add("TORNADO5"); //<!-- Tornado Custom -->
                sVehicles.Add("TORNADO6"); //<!-- Tornado Rat Rod -->
                sVehicles.Add("TURISMO2"); //<!-- Turismo Classic -->
                sVehicles.Add("VISERIS"); //
                sVehicles.Add("ZTYPE"); //
                if (bTrainM)
                {
                    sVehicles.Add("DYNASTY"); //
                    sVehicles.Add("JB7002"); //<!-- JB 700W -->
                    sVehicles.Add("NEBULA"); //
                    sVehicles.Add("RETINUE2"); //<!-- Retinue MkII -->
                    sVehicles.Add("ZION3"); //<!-- Zion Classic -->
                    sVehicles.Add("COQUETTE4"); //<!-- Coquette D10  -->
                    sVehicles.Add("TOREADOR"); //><!-- Pegassi Toreador -->sportsClassic
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //SportsClassic
            else if (iVechList == 6)
            {
                sVehicles.Add("BLISTA"); //
                sVehicles.Add("BRIOSO"); //
                sVehicles.Add("DILETTANTE"); //
                sVehicles.Add("ISSI2"); //
                sVehicles.Add("ISSI3"); //<!-- Issi Classic -->
                sVehicles.Add("PANTO"); //
                sVehicles.Add("PRAIRIE"); //
                sVehicles.Add("RHAPSODY"); //
                if (bTrainM)
                {
                    sVehicles.Add("ASBO"); //
                    sVehicles.Add("KANJO"); //<!-- Blista Kanjo -->
                    sVehicles.Add("CLUB");
                    sVehicles.Add("BRIOSO2"); //>Grotti Brioso 300
                    sVehicles.Add("WEEVIL"); //><!-- BF Weevil -->
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Compact
            else if (iVechList == 7)
            {
                sVehicles.Add("ASEA"); //
                sVehicles.Add("ASTEROPE"); //
                sVehicles.Add("COGNOSCENTI"); //
                sVehicles.Add("COGNOSCENTI2"); //<!-- Cognoscenti (Armored) -->
                sVehicles.Add("COG55"); //<!-- Cognoscenti 55 -->
                sVehicles.Add("COG552"); //<!-- Cognoscenti 55 (Armored) -->
                sVehicles.Add("EMPEROR"); //
                sVehicles.Add("EMPEROR2"); //<!-- Emperor beater variant -->
                sVehicles.Add("FUGITIVE"); //
                sVehicles.Add("GLENDALE"); //
                sVehicles.Add("INGOT"); //
                sVehicles.Add("INTRUDER"); //
                sVehicles.Add("PREMIER"); //
                sVehicles.Add("PRIMO"); //
                sVehicles.Add("PRIMO2"); //<!-- Primo Custom -->
                sVehicles.Add("REGINA"); //
                sVehicles.Add("ROMERO"); //
                sVehicles.Add("SCHAFTER2"); //
                sVehicles.Add("SCHAFTER6"); //<!-- Schafter LWB (Armored) -->
                sVehicles.Add("SCHAFTER5"); //<!-- Schafter V12 (Armored) -->
                sVehicles.Add("STAFFORD"); //
                sVehicles.Add("STANIER"); //
                sVehicles.Add("STRATUM"); //
                sVehicles.Add("STRETCH"); //
                sVehicles.Add("SUPERD"); //
                sVehicles.Add("SURGE"); //
                sVehicles.Add("TAILGATER"); //
                sVehicles.Add("WARRENER"); //
                sVehicles.Add("WASHINGTON"); //

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Sedan
            else if (iVechList == 8)
            {
                sVehicles.Add("BIFTA"); //
                sVehicles.Add("BODHI2"); //
                sVehicles.Add("BRAWLER"); //
                sVehicles.Add("TROPHYTRUCK2"); //<!-- Desert Raid -->
                sVehicles.Add("DUBSTA3"); //<!-- Dubsta 6x6 -->
                sVehicles.Add("DUNE"); //
                sVehicles.Add("DLOADER"); //
                sVehicles.Add("FREECRAWLER"); //
                sVehicles.Add("HELLION");
                sVehicles.Add("BFINJECTION"); //
                sVehicles.Add("KALAHARI"); //
                sVehicles.Add("KAMACHO"); //
                sVehicles.Add("MESA3"); //<!-- Merryweather Mesa -->
                sVehicles.Add("RANCHERXL"); //
                sVehicles.Add("REBEL2"); //
                sVehicles.Add("RIATA"); //
                sVehicles.Add("REBEL"); //<!-- Rusty Rebel -->
                sVehicles.Add("SANDKING2"); //<!-- Sandking SWB -->
                sVehicles.Add("SANDKING"); //<!-- Sandking XL -->
                sVehicles.Add("DUNE2"); //<!-- Space Docker -->
                sVehicles.Add("TROPHYTRUCK"); //
                sVehicles.Add("RALLYTRUCK"); //<!-- Dune -->
                if (bTrainM)
                {
                    sVehicles.Add("CARACARA2"); //<!-- Caracara 4x4 -->
                    sVehicles.Add("EVERON"); //
                    sVehicles.Add("OUTLAW"); //
                    sVehicles.Add("VAGRANT"); //
                    sVehicles.Add("ZHABA"); //
                    sVehicles.Add("WINKY"); //><!-- Vapid Winky -->	
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //Offroad
            else if (iVechList == 9)
            {
                sVehicles.Add("BALLER"); //
                sVehicles.Add("BALLER2"); //<!-- Baller 2nd gen variant -->
                sVehicles.Add("BALLER3"); //<!-- Baller LE -->
                sVehicles.Add("BALLER5"); //<!-- Baller LE (Armored) -->
                sVehicles.Add("BALLER4"); //<!-- Baller LE LWB -->
                sVehicles.Add("BALLER6"); //<!-- Baller LE LWB (Armored) -->
                sVehicles.Add("BJXL"); //
                sVehicles.Add("CAVALCADE"); //
                sVehicles.Add("CAVALCADE2"); //<!-- Cavalcade 2nd gen variant -->
                sVehicles.Add("CONTENDER"); //
                sVehicles.Add("DUBSTA"); //
                sVehicles.Add("DUBSTA2"); //<!-- Dubsta black variant -->
                sVehicles.Add("FQ2"); //
                sVehicles.Add("GRANGER"); //
                sVehicles.Add("GRESLEY"); //
                sVehicles.Add("HABANERO"); //
                sVehicles.Add("HUNTLEY"); //
                sVehicles.Add("LANDSTALKER"); //
                sVehicles.Add("MESA"); //
                sVehicles.Add("PATRIOT"); //
                sVehicles.Add("PATRIOT2"); //<!-- Patriot Stretch -->
                sVehicles.Add("RADI"); //
                sVehicles.Add("ROCOTO"); //
                sVehicles.Add("SEMINOLE"); //
                sVehicles.Add("SERRANO"); //
                sVehicles.Add("XLS"); //
                sVehicles.Add("XLS2"); //<!-- XLS (Armored) -->
                if (bTrainM)
                {
                    sVehicles.Add("NOVAK"); //
                    sVehicles.Add("REBLA"); //
                    sVehicles.Add("TOROS"); //
                    sVehicles.Add("LANDSTALKER2"); //
                    sVehicles.Add("SEMINOLE2"); //
                }

                int iCar = RandInt(0, sVehicles.Count - 1);
                sThisVehicle = sVehicles[iCar];
            }       //SUV
            else
            {
                int iCar = RandInt(0, sCustomCarz.Count - 1);
                sThisVehicle = sCustomCarz[iCar];
            }

            return sThisVehicle;
        }
        private void MedicAnswered(iFruitContact contact)
        {
            LogThis("MedicAnswered");
            bFunctionTime = true;
            iFunctionTime = 4;
        }
        private void WeapsAnswered(iFruitContact contact)
        {
            LogThis("WeapsAnswered");
            bFunctionTime = true;
            iFunctionTime = 5;
        }
        private void MkWepsOpt(UIMenu XMen)
        {
            LogThis("MkWepsOpt");

            var Rand_01 = new UIMenuItem(DataStore.MyLang.ContactLang[45], "");
            var Rand_02 = new UIMenuItem(DataStore.MyLang.ContactLang[46], "");

            XMen.AddItem(Rand_01);
            XMen.AddItem(Rand_02);

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    iFubCarzz = 0; 
                    iService = 3;
                    sLastVeh = "BOXVILLE5";
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Mk2 Weapons", 11, true, false);
                    //SearchVeh(0.10f, 95.00f, "BOXVILLE5", false, 3, 529, false, false);
                    YtmenuPool.CloseAllMenus();
                }
                else if (item == Rand_02)
                {
                    AddMissWeaps(Mk2WeapsMain, bWeapSwap);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void SettingsAnswered(iFruitContact contact)
        {
            LogThis("SettingsAnswered");
            bFunctionTime = true;
            iFunctionTime = 8;
        }
        private void WeaponsMenu()
        {
            LogThis("WeaponsMenu");
            
            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[43], DataStore.MyLang.ContactLang[44]);
            YtmenuPool.Add(mainMenu);
            Mk2WeapsList(mainMenu);
            YtmenuPool.RefreshIndex();
            bMenuOpen = true;
            bWepMenuX = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void Mk2WeapsList(UIMenu XMen)
        {
            LogThis("Mk2WeapsList");

            List<int> iPrice = new List<int>();
            List<string> sWeap01 = new List<string>();
            List<string> sWeap02 = new List<string>();
            sWeap01.Add("Revolver Mk2"); iPrice.Add(99000); sWeap02.Add("weapon_revolver_mk2");
            sWeap01.Add("SNS Pistol Mk2"); iPrice.Add(79575); sWeap02.Add("weapon_snspistol_mk2");
            sWeap01.Add("Pistol Mk2"); iPrice.Add(73750); sWeap02.Add("weapon_pistol_mk2");
            sWeap01.Add("SMG Mk2"); iPrice.Add(85500); sWeap02.Add("weapon_smg_mk2");
            sWeap01.Add("Pump Shotgun Mk2"); iPrice.Add(82500); sWeap02.Add("weapon_pumpshotgun_mk2");
            sWeap01.Add("Bullpup Rifle Mk2"); iPrice.Add(105750); sWeap02.Add("weapon_bullpuprifle_mk2");
            sWeap01.Add("Special Carbine Mk2"); iPrice.Add(135000); sWeap02.Add("weapon_specialcarbine_mk2");
            sWeap01.Add("Assault Rifle Mk2"); iPrice.Add(98750); sWeap02.Add("weapon_assaultrifle_mk2");
            sWeap01.Add("Carbine Rifle Mk2"); iPrice.Add(107500); sWeap02.Add("weapon_carbinerifle_mk2");
            sWeap01.Add("Combat MG Mk2"); iPrice.Add(119000); sWeap02.Add("weapon_combatmg_mk2");
            sWeap01.Add("Marksman Rifle Mk2"); iPrice.Add(14900); sWeap02.Add("weapon_marksmanrifle_mk2");
            sWeap01.Add("Heavy Sniper Mk2"); iPrice.Add(165375); sWeap02.Add("weapon_heavysniper_mk2");

            for (int i = 0; i < sWeap01.Count; i++)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeap02[i]), false))
                    iPrice[i] = 0;
                AmmoAtachLiveList(XMen, i, sWeap01[i], sWeap02[i], iPrice[i]);
            }

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (iPrice[index] < DataStore.MyDatSet.iNSPMBank)
                    GiveMk2Weap(Game.Player.Character, sWeap02[index], iPrice[index], true);
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void AmmoAtachLiveList(UIMenu XMen, int iWeap, string sWeapName, string sWeapHash, int iPrice)
        {
            LogThis("AmmoAtachLiveList, iWeap == " + iWeap + ", sWeapName == " + sWeapName + ", sWeapHash == " + sWeapHash + ", iPrice == " + iPrice);

            var Midmenu = YtmenuPool.AddSubMenu(XMen, sWeapName, DataStore.MyLang.ContactLang[15] + iPrice);

            Mk2CompListAmmo(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2CompListAttach(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2CompListLivery(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2AddAmmo(Midmenu, sWeapHash, sWeapName);
        }
        private void Mk2CompListAmmo(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            LogThis("Mk2CompListAmmo, iWeap == " + iWeap + ", sWeap == " + sWeap + ", sWeapHash == " + sWeapHash);

            List<string> sAdd01 = new List<string>();
            List<string> sAdd02 = new List<string>();
            List<int> iCost = new List<int>();
            if (iWeap == 0)
            {
                sAdd01.Add("Default Rounds"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CLIP_01"); iCost.Add(28);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CLIP_TRACER"); iCost.Add(21);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY"); iCost.Add(42);
                sAdd01.Add("Hollow Point Rounds"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT"); iCost.Add(56);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CLIP_FMJ"); iCost.Add(98);
            }       //Revolver Mk2
            else if (iWeap == 1)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_01"); iCost.Add(29);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_02"); iCost.Add(59);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_TRACER"); iCost.Add(22);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY"); iCost.Add(43);
                sAdd01.Add("Hollow Point Rounds"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT"); iCost.Add(58);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CLIP_FMJ"); iCost.Add(100);
            }       //SNS Pistol Mk2
            else if (iWeap == 2)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_01"); iCost.Add(57);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_02"); iCost.Add(87);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_TRACER"); iCost.Add(43);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_INCENDIARY"); iCost.Add(58);
                sAdd01.Add("Hollow Point Rounds"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT"); iCost.Add(77);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_PISTOL_MK2_CLIP_FMJ"); iCost.Add(134);
            }       //Pistol Mk2
            else if (iWeap == 3)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_01"); iCost.Add(113);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_02"); iCost.Add(225);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_TRACER"); iCost.Add(85);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_INCENDIARY"); iCost.Add(113);
                sAdd01.Add("Hollow Point Rounds"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT"); iCost.Add(151);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_SMG_MK2_CLIP_FMJ"); iCost.Add(264);
            }       //SMG Mk2
            else if (iWeap == 4)
            {
                sAdd01.Add("Default Shells"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_01"); iCost.Add(24);
                sAdd01.Add("Dragon's Breath Shells"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY"); iCost.Add(36);
                sAdd01.Add("Steel Buckshot Shells"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING"); iCost.Add(48);
                sAdd01.Add("Flechette Shells"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT"); iCost.Add(60);
                sAdd01.Add("Explosive Slugs"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE"); iCost.Add(600);
            }       //Pump Shotgun Mk2
            else if (iWeap == 5)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_01"); iCost.Add(108);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_02"); iCost.Add(215);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER"); iCost.Add(68);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY"); iCost.Add(90);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING"); iCost.Add(150);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ"); iCost.Add(210);
            }       //Bullpup Rifle Mk2
            else if (iWeap == 6)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_01"); iCost.Add(108);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_02"); iCost.Add(215);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER"); iCost.Add(81);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY"); iCost.Add(108);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING"); iCost.Add(180);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ"); iCost.Add(252);
            }       //Special Carbine Mk2
            else if (iWeap == 7)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_01"); iCost.Add(42);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_02"); iCost.Add(81);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER"); iCost.Add(81);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY"); iCost.Add(108);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING"); iCost.Add(180);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ"); iCost.Add(252);
            }       //Assault Rifle Mk2
            else if (iWeap == 8)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_01"); iCost.Add(40);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_02"); iCost.Add(79);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER"); iCost.Add(81);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY"); iCost.Add(108);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING"); iCost.Add(180);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ"); iCost.Add(252);
            }       //Carbine Rifle Mk2
            else if (iWeap == 9)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_01"); iCost.Add(277);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_02"); iCost.Add(514);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_TRACER"); iCost.Add(209);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY"); iCost.Add(334);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING"); iCost.Add(556);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CLIP_FMJ"); iCost.Add(779);
            }       //Combat MG Mk2
            else if (iWeap == 10)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_01"); iCost.Add(116);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_02"); iCost.Add(225);
                sAdd01.Add("Tracer Rounds"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER"); iCost.Add(87);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY"); iCost.Add(109);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING"); iCost.Add(182);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ"); iCost.Add(254);
            }       //Marksman Rifle Mk2
            else if (iWeap == 11)
            {
                sAdd01.Add("Default Clip"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_01"); iCost.Add(42);
                sAdd01.Add("Extended Clip"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_02"); iCost.Add(81);
                sAdd01.Add("Incendiary Rounds"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY"); iCost.Add(87);
                sAdd01.Add("Armor Piercing Rounds"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING"); iCost.Add(145);
                sAdd01.Add("Full Metal Jacket Rounds"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ"); iCost.Add(203);
                sAdd01.Add("Explosive Rounds"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE"); iCost.Add(1450);
            }       //Heavy Sniper Mk2

            var Lastmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[72]);

            for (int i = 0; i < sAdd01.Count; i++)
            {
                var item_ = new UIMenuItem(sAdd01[i], DataStore.MyLang.ContactLang[15] + iCost[i]);
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                {
                    item_.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[i] = 0;
                    item_.Description = DataStore.MyLang.ContactLang[15] + iCost[i];
                }
                Lastmenu.AddItem(item_);
            }
            Lastmenu.OnItemSelect += (sender, item, index) =>
            {
                if (iCost[index] < DataStore.MyDatSet.iNSPMBank)
                {
                    Mk2Addons(sWeapHash, sAdd02[index], iCost[index], true);
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[index] = 0;
                    item.Description = DataStore.MyLang.ContactLang[15] + iCost[index];

                    for (int i = 0; i < Lastmenu.MenuItems.Count; i++)
                    {
                        if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                            Lastmenu.MenuItems[i].SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void Mk2CompListAttach(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            LogThis("Mk2CompListAttach");

            List<string> sAdd01 = new List<string>();
            List<string> sAdd02 = new List<string>();
            List<int> iCost = new List<int>();
            if (iWeap == 0)
            {
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(16250);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_MK2"); iCost.Add(25450);
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_PI_FLSH"); iCost.Add(7500);
                sAdd01.Add("Compensator"); sAdd02.Add("COMPONENT_AT_PI_COMP_03"); iCost.Add(21250);
            }       //Revolver Mk2
            else if (iWeap == 1)
            {
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_PI_FLSH_03"); iCost.Add(7500);
                sAdd01.Add("Mounted Scope"); sAdd02.Add("COMPONENT_AT_PI_RAIL_02"); iCost.Add(16250);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_PI_SUPP_02"); iCost.Add(28750);
                sAdd01.Add("Compensator"); sAdd02.Add("COMPONENT_AT_PI_COMP_02"); iCost.Add(21250);
            }       //SNS Pistol Mk2
            else if (iWeap == 2)
            {
                sAdd01.Add("Mounted Scope"); sAdd02.Add("COMPONENT_AT_PI_RAIL"); iCost.Add(16250);
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_PI_FLSH_02"); iCost.Add(7500);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_PI_SUPP_02"); iCost.Add(28750);
                sAdd01.Add("Compensator"); sAdd02.Add("COMPONENT_AT_PI_COMP"); iCost.Add(21250);
            }       //Pistol Mk2
            else if (iWeap == 3)
            {
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(7500);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS_SMG"); iCost.Add(14800);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2"); iCost.Add(19950);
                sAdd01.Add("Medium Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_SMALL_SMG_MK2"); iCost.Add(24100);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_PI_SUPP"); iCost.Add(34500);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(25500);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(26755);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(28010);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(29260);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(30515);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(31770);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(33025);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_SB_BARREL_01"); iCost.Add(1000);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_SB_BARREL_02"); iCost.Add(42000);
            }       //SMG Mk2
            else if (iWeap == 4)
            {
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(29260);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_MK2"); iCost.Add(39920);
                sAdd01.Add("Medium Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_SMALL_MK2"); iCost.Add(50785);
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(10500);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_SR_SUPP_03"); iCost.Add(45860);
                sAdd01.Add("Squared Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_08"); iCost.Add(37650);
            }       //Pump Shotgun Mk2
            else if (iWeap == 5)
            {
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(10500);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(19600);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_02_MK2"); iCost.Add(23730);
                sAdd01.Add("Medium Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_SMALL_MK2"); iCost.Add(34020);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_BP_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_BP_BARREL_02"); iCost.Add(49000);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_AR_SUPP"); iCost.Add(40250);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(29750);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(31215);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(32675);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(34140);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(35600);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(37065);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(38530);
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(14080);
            }       //Bullpup Rifle Mk2
            else if (iWeap == 6)
            {
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(10500);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(19600);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_MK2"); iCost.Add(23730);
                sAdd01.Add("Large Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2"); iCost.Add(34020);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_AR_SUPP_02"); iCost.Add(40250);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(29750);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(31215);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(32675);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(34140);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(35600);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(37065);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(38530);
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(14080);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_SC_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_SC_BARREL_02"); iCost.Add(49000);
            }       //Special Carbine Mk2
            else if (iWeap == 7)
            {
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(14080);
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(10500);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(19600);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_MK2"); iCost.Add(23750);
                sAdd01.Add("Large Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2"); iCost.Add(34020);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_AR_SUPP_02"); iCost.Add(40250);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(29750);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(31215);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(32675);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(34140);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(35600);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(37065);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(38530);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_AR_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_AR_BARREL_02"); iCost.Add(49000);
            }       //Assault Rifle Mk2
            else if (iWeap == 8)
            {
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(14080);
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(10500);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(19600);
                sAdd01.Add("Small Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MACRO_MK2"); iCost.Add(23730);
                sAdd01.Add("Large Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2"); iCost.Add(34020);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_AR_SUPP"); iCost.Add(40250);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(29750);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(31215);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(32675);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(34140);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(35600);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(37065);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(38530);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_CR_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_CR_BARREL_02"); iCost.Add(49000);
            }       //Carbine Rifle Mk2
            else if (iWeap == 9)
            {
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(20180);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(26600);
                sAdd01.Add("Medium Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_SMALL_MK2"); iCost.Add(36290);
                sAdd01.Add("Large Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2"); iCost.Add(46170);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(40375);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(42360);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(44345);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(46330);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(48315);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(50305);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(52290);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_MG_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_MG_BARREL_02"); iCost.Add(66500);
            }       //Combat MG Mk2
            else if (iWeap == 10)
            {
                sAdd01.Add("Flashlight"); sAdd02.Add("COMPONENT_AT_AR_FLSH"); iCost.Add(11250);
                sAdd01.Add("Zoom Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2"); iCost.Add(0);
                sAdd01.Add("Holographic Sight"); sAdd02.Add("COMPONENT_AT_SIGHTS"); iCost.Add(11485);
                sAdd01.Add("Large Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2"); iCost.Add(17870);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_AR_SUPP"); iCost.Add(60375);
                sAdd01.Add("Flat Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_01"); iCost.Add(44620);
                sAdd01.Add("Tactical Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_02"); iCost.Add(46815);
                sAdd01.Add("Fat-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_03"); iCost.Add(49010);
                sAdd01.Add("Precision Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_04"); iCost.Add(51205);
                sAdd01.Add("Heavy Duty Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_05"); iCost.Add(53400);
                sAdd01.Add("Slanted Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_06"); iCost.Add(55595);
                sAdd01.Add("Split-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_07"); iCost.Add(57790);
                sAdd01.Add("Grip"); sAdd02.Add("COMPONENT_AT_AR_AFGRIP_02"); iCost.Add(14080);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_MRFL_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_MRFL_BARREL_02"); iCost.Add(73500);
            }       //Marksman Rifle Mk2
            else if (iWeap == 11)
            {
                sAdd01.Add("Advanced Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_MAX"); iCost.Add(0);
                sAdd01.Add("Zoom Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_LARGE_MK2"); iCost.Add(29595);
                sAdd01.Add("Night Vision Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_NV"); iCost.Add(45950);
                sAdd01.Add("Thermal Scope"); sAdd02.Add("COMPONENT_AT_SCOPE_THERMAL"); iCost.Add(69000);
                sAdd01.Add("Suppressor"); sAdd02.Add("COMPONENT_AT_SR_SUPP_03"); iCost.Add(60375);
                sAdd01.Add("Squared Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_08"); iCost.Add(45010);
                sAdd01.Add("Bell-End Muzzle Brake"); sAdd02.Add("COMPONENT_AT_MUZZLE_09"); iCost.Add(57790);
                sAdd01.Add("Default Barrel"); sAdd02.Add("COMPONENT_AT_SR_BARREL_01"); iCost.Add(0);
                sAdd01.Add("Heavy Barrel"); sAdd02.Add("COMPONENT_AT_SR_BARREL_02"); iCost.Add(69825);
            }       //Heavy Sniper Mk2

            var Lastmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[73]);

            for (int i = 0; i < sAdd01.Count; i++)
            {

                var item_ = new UIMenuItem(sAdd01[i], "NSCoin " + iCost[i]);
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                {
                    item_.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[i] = 0;
                    item_.Description = DataStore.MyLang.ContactLang[15] + iCost[i];
                }
                Lastmenu.AddItem(item_);
            }
            Lastmenu.OnItemSelect += (sender, item, index) =>
            {
                if (iCost[index] < DataStore.MyDatSet.iNSPMBank)
                {
                    Mk2Addons(sWeapHash, sAdd02[index], iCost[index], true);
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[index] = 0;
                    item.Description = DataStore.MyLang.ContactLang[15] + iCost[index];

                    for (int i = 0; i < Lastmenu.MenuItems.Count; i++)
                    {
                        if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                            Lastmenu.MenuItems[i].SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void Mk2CompListLivery(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            LogThis("Mk2CompListLivery");

            List<string> sAdd01 = new List<string>();
            List<string> sAdd02 = new List<string>();
            List<int> iCost = new List<int>();
            if (iWeap == 0)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_REVOLVER_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Revolver Mk2
            else if (iWeap == 1)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01"); iCost.Add(60000);
                sAdd01.Add("Digital Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE"); iCost.Add(43500);
                sAdd01.Add("Woodland Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE"); iCost.Add(45000);
                sAdd01.Add("Skull Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE"); iCost.Add(75000);
                sAdd01.Add("Perseus Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE"); iCost.Add(57500);
                sAdd01.Add("Leopard Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE"); iCost.Add(51500);
                sAdd01.Add("Zebra Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE"); iCost.Add(53750);
                sAdd01.Add("Geometric Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE"); iCost.Add(55000);
                sAdd01.Add("Boom! Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE"); iCost.Add(60000);
                sAdd01.Add("Patriotic Slide"); sAdd02.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE"); iCost.Add(100000);
            }       //SNS Pistol Mk2
            else if (iWeap == 2)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01"); iCost.Add(100000);
                sAdd01.Add("Digital Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_02_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Woodland Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_03_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Skull Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_04_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Sessanta Nove Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_05_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Perseus Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_06_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Leopard Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_07_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Zebra Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_08_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Geometric Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_09_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Boom! Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_10_SLIDE"); iCost.Add(40000);
                sAdd01.Add("Patriotic Slide"); sAdd02.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE"); iCost.Add(100000);
            }       //Pistol Mk2
            else if (iWeap == 3)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_08"); iCost.Add(53500);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_SMG_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //SMG Mk2
            else if (iWeap == 4)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Pump Shotgun Mk2
            else if (iWeap == 5)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Bullpup Rifle Mk2
            else if (iWeap == 6)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Special Carbine Mk2
            else if (iWeap == 7)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Assault Rifle Mk2
            else if (iWeap == 8)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Carbine Rifle Mk2
            else if (iWeap == 9)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_COMBATMG_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Combat MG Mk2
            else if (iWeap == 10)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Marksman Rifle Mk2
            else if (iWeap == 11)
            {
                sAdd01.Add("Digital Camo"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO"); iCost.Add(40000);
                sAdd01.Add("Brushstroke Camo"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_02"); iCost.Add(43500);
                sAdd01.Add("Woodland Camo"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_03"); iCost.Add(45000);
                sAdd01.Add("Skull"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_04"); iCost.Add(49750);
                sAdd01.Add("Sessanta Nove"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_05"); iCost.Add(75000);
                sAdd01.Add("Perseus"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_06"); iCost.Add(57500);
                sAdd01.Add("Leopard"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_07"); iCost.Add(51500);
                sAdd01.Add("Zebra"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_08"); iCost.Add(53750);
                sAdd01.Add("Geometric"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_09"); iCost.Add(55000);
                sAdd01.Add("Boom!"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_10"); iCost.Add(60000);
                sAdd01.Add("Patriotic"); sAdd02.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01"); iCost.Add(100000);
            }       //Heavy Sniper Mk2

            var Lastmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[74]);

            for (int i = 0; i < sAdd01.Count; i++)
            {
                var item_ = new UIMenuItem(sAdd01[i], "NSCoin " + iCost[i]);
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                {
                    item_.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[i] = 0;
                    item_.Description = DataStore.MyLang.ContactLang[15] + iCost[i];
                }
                Lastmenu.AddItem(item_);
            }
            XMen.RefreshIndex();
            Lastmenu.OnItemSelect += (sender, item, index) =>
            {
                if (iCost[index] < DataStore.MyDatSet.iNSPMBank)
                {
                    Mk2Addons(sWeapHash, sAdd02[index], iCost[index], true);
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    iCost[index] = 0;
                    item.Description = DataStore.MyLang.ContactLang[15] + iCost[index];

                    for (int i = 0; i < Lastmenu.MenuItems.Count; i++)
                    {
                        if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeapHash), Function.Call<int>(Hash.GET_HASH_KEY, sAdd02[i])))
                            Lastmenu.MenuItems[i].SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void Mk2Addons(string sWeaps, string sAddon, int iCost, bool bAdd)
        {
            LogThis("Mk2Addons");

            if (bAdd)
            {
                Ped Peddy = Game.Player.Character;
                Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeaps), Function.Call<int>(Hash.GET_HASH_KEY, sAddon));
                iCost *= -1;
                UiDisplay.YourCoinPopUp(iCost, 1, DataStore.MyLang.ContactLang[43]);
            }
            else
            {
                Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeaps), Function.Call<int>(Hash.GET_HASH_KEY, sAddon));
            }
            MyWeaponList(sWeaps, sAddon, 0, bAdd);
        }
        private void GiveMk2Weap(Ped Peddy, string sWeap, int iPrice, bool bAddToList)
        {
            LogThis("GiveMk2Weap");

            if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false))
            {
                iPrice *= -1;
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), 9999, false, true);
                UiDisplay.YourCoinPopUp(iPrice, 1, DataStore.MyLang.ContactLang[43]);
            }
            else
                Function.Call(Hash.SET_CURRENT_PED_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), true);


            if (bAddToList)
                MyWeaponList(sWeap, "", 0, true);
        }
        private void Mk2AddAmmo(UIMenu XMen, string sWeap, string WeapName)
        {
            LogThis("Mk2AddAmmo");

            var Ammosmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[47]);

            int iAmmo = MaxAmmo(sWeap, Game.Player.Character);

            var item_ = new UIMenuItem(WeapName + DataStore.MyLang.ContactLang[47], DataStore.MyLang.ContactLang[15] + iAmmo);
            Ammosmenu.AddItem(item_);

            Ammosmenu.OnItemSelect += (sender, item, index) =>
            {
                if (iAmmo < DataStore.MyDatSet.iNSPMBank)
                {
                    FillMyAmmo(sWeap, iAmmo);
                    if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap)) < iAmmo)
                        FillMyAmmo(sWeap, iAmmo);
                    item.Description = "";
                    MyWeaponList(sWeap, "", iAmmo, true);
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                    YtmenuPool.CloseAllMenus();
                }
            };
        }
        private void FillMyAmmo(string sWeap, int iAmmo)
        {
            Function.Call<bool>(Hash.SET_AMMO_IN_CLIP, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_MAX_AMMO_IN_CLIP, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false));
            Function.Call(Hash.SET_PED_AMMO, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), iAmmo);
        }
        private void MyWeaponList(string sWeapon, string sAddon, int iAmmo, bool bAdd)
        {
            bool bGotthis = false;
            int iPlayer = MyChar();
            if (sAddon == "")
            {
                for (int i = 0; i < Mk2WeapsMain.Count; i++)
                {
                    if (Mk2WeapsMain[i].Mk2Weap == sWeapon && Mk2WeapsMain[i].MyPlayer == iPlayer)
                    {
                        Mk2WeapsMain[i].MyAmmos = iAmmo;
                        bGotthis = true;
                        break;
                    }
                }

                if (!bGotthis)
                {
                    MyMk2Weaps ThisWeap = new MyMk2Weaps
                    {
                        Mk2Weap = sWeapon,
                        MyPlayer = iPlayer,
                        MyAmmos = iAmmo
                    };
                    Mk2WeapsMain.Add(ThisWeap);
                }
            }
            else
            {
                int iAm = -1;
                for (int i = 0; i < Mk2WeapsMain.Count; i++)
                {
                    if (Mk2WeapsMain[i].Mk2Weap == sWeapon && Mk2WeapsMain[i].MyPlayer == iPlayer)
                    {
                        iAm = i;
                        break;
                    }
                }
                if (iAm == -1)
                {
                    MyWeaponList(sWeapon, "", iAmmo, true);
                    MyWeaponList(sWeapon, sAddon, iAmmo, true);
                }
                else
                {
                    for (int i = 0; i < Mk2WeapsMain[iAm].Mk2Addon.Count; i++)
                    {
                        if (Mk2WeapsMain[iAm].Mk2Addon[i] == sAddon)
                        {
                            if (bAdd)
                                bGotthis = true;
                            else
                                Mk2WeapsMain[iAm].Mk2Addon.RemoveAt(i);
                        }
                    }
                    if (!bGotthis)
                        Mk2WeapsMain[iAm].Mk2Addon.Add(sAddon);
                }
            }
        }
        public int MyChar()
        {
            int iAm = 0;
            if (Game.Player.Character.Model == PedHash.Michael)
                iAm = 1;
            else if (Game.Player.Character.Model == PedHash.Franklin)
                iAm = 2;
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iAm = 3;
            return iAm;
        }
        public int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        public string GetEntName(string MyEnt)
        {
            string VehName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, Function.Call<int>(Hash.GET_HASH_KEY, MyEnt));
            if (Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, VehName))
                VehName = Function.Call<string>(Hash._GET_LABEL_TEXT, VehName);
            else
                VehName = "";

            return VehName;
        }
        private void PeggsAnswered(iFruitContact contact)
        {
            LogThis("PeggsAnswered");
            bFunctionTime = true;
            iFunctionTime = 6;
        }
        private void PeggsMenu()
        {
            LogThis("PeggsMenu");
            
            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[48], DataStore.MyLang.ContactLang[49]);
            YtmenuPool.Add(mainMenu);
            PeggesTopMenu(mainMenu);
            YtmenuPool.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void PeggesTopMenu(UIMenu XMen)
        {
            if (DataStore.MyAssets.PegsSafeHeliTest)
                PeggsSafeHeliList(XMen);
            if (DataStore.MyAssets.PegsWarHeliTest)
                PeggsArmdHeliList(XMen);
            if (DataStore.MyAssets.PegsSafePlaneTest)
                PeggsSafeAirCraftList(XMen);
            if (DataStore.MyAssets.PegsWarPlaneTest)
                PeggsArmAirCraftList(XMen);
            if (DataStore.MyAssets.PegsboatsTest)
                PeggsBoatsList(XMen);
            if (DataStore.MyAssets.PegsimortasTest)
                PeggsImpExpList(XMen);
            if (sCustomBoatsz.Count > 0 || sCustomPlanez.Count > 0 || sCustomChopperz.Count > 0)
                PeggsCustomList(XMen);
        }
        private void PeggsSafeHeliList(UIMenu XMen)
        {
            var SafeHelimenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[50]);

            List<string> sPegggisis = new List<string>
            {
                "Buzzard",
                "Jetsam Cargobob",
                "Frogger",
                "Maverick",
                "Super Volito",
                "Super Volito Carbon",
                "Swift",
                "Swift Deluxe",
                "Volatus"
            };

            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                SafeHelimenu.AddItem(item_);
            }

            SafeHelimenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(1, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsArmdHeliList(UIMenu XMen)
        {
            var ArmHelimenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[51]);

            List<string> sPegggisis = new List<string>
            {
                "Akula",
                "Annihilator",
                "Buzzard Attack Chopper",
                "Military Cargobob",
                "FH-1 Hunter",
                "Havok",
                "Savage",
                "Sea Sparrow",
                "Valkyrie"
            };

            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                ArmHelimenu.AddItem(item_);
            }

            ArmHelimenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(2, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsSafeAirCraftList(UIMenu XMen)
        {
            var SafePlanemenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[52]);

            List<string> sPegggisis = new List<string>
            {
                "Atomic Blimp",
                "Xero Blimp",
                "Nightclub Blimp",
                "Besra",
                "Alpha-Z1",
                "Cuban 800",
                "Dodo",
                "Duster",
                "Howard NX-25",
                "Luxor",
                "Luxor Deluxe",
                "Mallard",
                "Mammatus",
                "Miljet",
                "Nimbus",
                "Shamal",
                "Velum",
                "Velum 5-Seater",
                "Vestra",
                "Titan"
            };


            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                SafePlanemenu.AddItem(item_);
            }

            SafePlanemenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(3, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsArmAirCraftList(UIMenu XMen)
        {
            var ArmPlanemenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[53]);

            List<string> sPegggisis = new List<string>
            {
                "B-11 Strikeforce",
                "Hydra",
                "LF-22 Starling",
                "Mogul",
                "P-45 Nokota",
                "P-996 LAZER",
                "Pyro",
                "Rogue",
                "Seabreeze",
                "Tula",
                "Ultralight",
                "V-65 Molotok",
                "RM-10 Bombushka",
                "Volatol"
            };


            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                ArmPlanemenu.AddItem(item_);
            }

            ArmPlanemenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(4, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsBoatsList(UIMenu XMen)
        {
            var Boatsmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[54]);

            List<string> sPegggisis = new List<string>
            {
                "SeaShark",    //
                "Dinghy",    //
                "Dinghy 2-seater",    //<!-- Dinghy 2-seater variant -->
                "Jetmax",    //
                "Speeder",    //
                "Squalo",    //
                "Suntrap",    //
                "Toro",    //
                "Tropic",    //
                "Marquis",    //
                "Tug",    //
                "Submersible",    //
                "Kraken",    //<!-- Kraken -->
                "Kraken Avisa", //Kraken Avisa -Boats
                "Weaponized Dinghy", //Nagasaki Weaponized Dinghy -Boats
                "Longfin", //Shitzu Longfin -Boats
                "Kurtz 31" //Kurtz 31 Patrol Boat -Boats
            };

            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                Boatsmenu.AddItem(item_);
            }

            Boatsmenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(5, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsImpExpList(UIMenu XMen)
        {
            var ImpExmenu = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[55]);

            List<string> sPegggisis = new List<string>
            {
                "BF Ramp Buggy",    //
                "Brute Armored Boxville",    //
                "Coil Rocket Voltic",    //
                "Imponte Ruiner 2000",    //
                "Jobuilt Phantom Wedge",    //
                "Karin Technical Aqua",    //
                "MTL Wastelander",    //
                "Nagasaki Blazer Aqua"    //
            };

            for (int i = 0; i < sPegggisis.Count; i++)
            {
                var item_ = new UIMenuItem(sPegggisis[i], DataStore.MyLang.ContactLang[15] + "200");
                ImpExmenu.AddItem(item_);
            }

            ImpExmenu.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggDrop(6, index);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggsCustomList(UIMenu XMen)
        {
            var CusBoats = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[56]);

            for (int i = 0; i < sCustomBoatsz.Count; i++)
            {
                var item_ = new UIMenuItem(sCustomBoatsz[i], DataStore.MyLang.ContactLang[15] + "200");
                CusBoats.AddItem(item_);
            }

            var CusPlanez = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[57]);

            for (int i = 0; i < sCustomPlanez.Count; i++)
            {
                var item_ = new UIMenuItem(sCustomPlanez[i], DataStore.MyLang.ContactLang[15] + "200");
                CusPlanez.AddItem(item_);
            }

            var CusHeli = YtmenuPool.AddSubMenu(XMen, DataStore.MyLang.ContactLang[58]);

            for (int i = 0; i < sCustomChopperz.Count; i++)
            {
                var item_ = new UIMenuItem(sCustomChopperz[i], DataStore.MyLang.ContactLang[15] + "200");
                CusHeli.AddItem(item_);
            }

            CusBoats.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    if (Game.Player.Character.IsInWater)
                    {
                        Vector3 vAirstrip = Game.Player.Character.Position + (Game.Player.Character.ForwardVector) * 5;
                        float fPlaneHead = Game.Player.Character.Heading;

                        iService = 5;
                        sLastVeh = sCustomBoatsz[index];
                        ObjectBuild.VehicleSpawn(sLastVeh, vAirstrip, fPlaneHead, false, false, false, false, 0, 0, 5, "Pegisus", 10, false);
                        //AddVeh(sCustomBoatsz[index], vAirstrip, fPlaneHead, false, 5, 455, false);
                        UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                    }
                    else
                    {
                        UI.Notify(DataStore.MyLang.ContactLang[59]);
                    }
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };

            CusPlanez.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    PeggAirports(sCustomPlanez[index]);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };

            CusHeli.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sCustomChopperz[index];
                    SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Pegisus", 10, true, false);
                    //SearchVeh(0.10f, 95.00f, sCustomChopperz[index], false, 4, 64, false, true);
                    UiDisplay.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                YtmenuPool.CloseAllMenus();
            };
        }
        private void PeggDrop(int iList, int iDrop)
        {
            LogThis("PeggDrop");

            List<string> sVehicles = new List<string>();

            if (iList == 1)
            {
                sVehicles.Add("BUZZARD2"); //<!-- Buzzard -->
                sVehicles.Add("CARGOBOB2"); //<!-- Jetsam Cargobob -->
                sVehicles.Add("FROGGER"); //
                sVehicles.Add("MAVERICK"); //
                sVehicles.Add("SUPERVOLITO"); //
                sVehicles.Add("SUPERVOLITO2"); //<!-- SuperVolito Carbon -->
                sVehicles.Add("SWIFT"); //
                sVehicles.Add("SWIFT2"); //<!-- Swift Deluxe -->
                sVehicles.Add("VOLATUS"); //
                iService = 4;
                sLastVeh = sVehicles[iDrop];
                SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Pegisus", 10, true, false);
                //SearchVeh(0.10f, 95.00f, sVehicles[iDrop], false, 4, 64, false, true);
            }
            else if (iList == 2)
            {
                sVehicles.Add("AKULA");
                sVehicles.Add("­ANNIHL");
                sVehicles.Add("BUZZARD"); //<!-- Buzzard -->
                sVehicles.Add("CARGOBOB"); //<!-- Military Cargobob -->
                sVehicles.Add("HUNTER"); //
                sVehicles.Add("HAVOK"); //
                sVehicles.Add("SAVAGE"); //                
                sVehicles.Add("SEASPARROW"); //
                sVehicles.Add("VALKYRIE"); //
                iService = 4;
                sLastVeh = sVehicles[iDrop];
                SearchFor.SearchVeh(0.01f, 120.00f, sLastVeh, false, false, false, false, 0, 0, 5, "Pegisus", 10, true, false);
                //SearchVeh(0.10f, 95.00f, sVehicles[iDrop], false, 4, 64, false, true);
            }
            else if (iList == 3)
            {
                sVehicles.Add("BLIMP");    //<!-- Atomic Blimp -->
                sVehicles.Add("BLIMP2");    //<!-- Xero Blimp -->
                sVehicles.Add("BLIMP3");    //
                sVehicles.Add("BESRA");    //
                sVehicles.Add("ALPHAZ1");    //
                sVehicles.Add("CUBAN800");    //
                sVehicles.Add("DODO");    //
                sVehicles.Add("DUSTER");    //
                sVehicles.Add("HOWARD");    //<!-- Howard NX-25 -->
                sVehicles.Add("LUXOR");    //
                sVehicles.Add("LUXOR2");    //<!-- Luxor Deluxe -->
                sVehicles.Add("STUNT");    //<!-- Mallard -->
                sVehicles.Add("MAMMATUS");    //
                sVehicles.Add("MILJET");    //
                sVehicles.Add("NIMBUS");    //
                sVehicles.Add("SHAMAL");    //
                sVehicles.Add("VELUM");    //
                sVehicles.Add("VELUM2");    //<!-- Velum 5-Seater -->
                sVehicles.Add("VESTRA");    //
                sVehicles.Add("TITAN");    //

                PeggAirports(sVehicles[iDrop]);
            }
            else if (iList == 4)
            {
                sVehicles.Add("STRIKEFORCE");    //<!-- B-11 Strikeforce -->
                sVehicles.Add("HYDRA");    //
                sVehicles.Add("STARLING");    //<!-- LF-22 Starling -->
                sVehicles.Add("MOGUL");    //
                sVehicles.Add("NOKOTA");    //<!-- P-45 Nokota -->
                sVehicles.Add("LAZER");    //<!-- P-996 LAZER -->
                sVehicles.Add("PYRO");    //
                sVehicles.Add("ROGUE");    //
                sVehicles.Add("SEABREEZE");    //
                sVehicles.Add("TULA");    //
                sVehicles.Add("MICROLIGHT");    //<!-- Ultralight -->
                sVehicles.Add("MOLOTOK");    //<!-- V-65 Molotok -->
                sVehicles.Add("BOMBUSHKA");    //<!-- RM-10 Bombushka -->
                sVehicles.Add("VOLATOL");    //

                PeggAirports(sVehicles[iDrop]);
            }
            else if (iList == 5)
            {
                sVehicles.Add("SEASHARK");    //
                sVehicles.Add("DINGHY");    //
                sVehicles.Add("DINGHY2");    //<!-- Dinghy 2-seater variant -->
                sVehicles.Add("JETMAX");    //
                sVehicles.Add("SPEEDER");    //
                sVehicles.Add("SQUALO");    //
                sVehicles.Add("SUNTRAP");    //
                sVehicles.Add("TORO");    //
                sVehicles.Add("TROPIC");    //
                sVehicles.Add("MARQUIS");    //
                sVehicles.Add("TUG");    //
                sVehicles.Add("SUBMERSIBLE");    //
                sVehicles.Add("SUBMERSIBLE2");    //<!-- Kraken -->
                sVehicles.Add("avisa"); //Kraken Avisa -Boats
                sVehicles.Add("dinghy5"); //Nagasaki Weaponized Dinghy -Boats
                sVehicles.Add("longfin"); //Shitzu Longfin -Boats
                sVehicles.Add("patrolboat"); //Kurtz 31 Patrol Boat -Boats

                if (Game.Player.Character.IsInWater)
                {
                    bIFrutiyAdd = true;
                    Vector3 vAirstrip = Game.Player.Character.Position + (Game.Player.Character.ForwardVector) * 5;
                    float fPlaneHead = Game.Player.Character.Heading;
                    iService = 5;
                    sLastVeh = sVehicles[iDrop];
                    ObjectBuild.VehicleSpawn(sLastVeh, vAirstrip, fPlaneHead, false, false, false, false, 0, 0, 5, "Pegisus", 10, false);
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[59]);
                }
            }
            else if (iList == 6)
            {
                sVehicles.Add("DUNE4");    //
                sVehicles.Add("BOXVILLE5");    //
                sVehicles.Add("VOLTIC2");    //
                sVehicles.Add("RUINER2");    //
                sVehicles.Add("PHANTOM2");    //
                sVehicles.Add("TECHNICAL2");    //
                sVehicles.Add("WASTLNDR");    //
                sVehicles.Add("BLAZER5");    //

                iService = 4;
                SearchFor.SearchVeh(0.10f, 95.00f, sVehicles[iDrop], false, false, false, false, 0, 0, 5, "Pegisus", 10, true, false);
            }          
        }
        private void PeggAirports(string sAircraft)
        {
            LogThis("PeggAirports");

            List<Vector3> vAirStips = new List<Vector3>();
            List<float> fAir = new List<float>();
            List<float> fAirDist = new List<float>();

            vAirStips.Add(new Vector3(-906.7272f, 4820.796f, 306.5776f)); fAir.Add(267.1703f);
            vAirStips.Add(new Vector3(-1140.173f, 5389.716f, 4.901117f)); fAir.Add(312.6974f);
            vAirStips.Add(new Vector3(-923.3945f, 5576.326f, 4.37148f)); fAir.Add(127.6849f);
            vAirStips.Add(new Vector3(-923.0542f, 6162.888f, 6.044725f)); fAir.Add(31.88383f);
            vAirStips.Add(new Vector3(-590.921f, 6365.13f, 4.679955f)); fAir.Add(299.9048f);
            vAirStips.Add(new Vector3(-254.2323f, 6571.657f, 3.832674f)); fAir.Add(132.3192f);
            vAirStips.Add(new Vector3(600.0437f, 6634.574f, 13.46018f)); fAir.Add(258.6263f);
            vAirStips.Add(new Vector3(923.0565f, 6609.757f, 5.702214f)); fAir.Add(83.27197f);
            vAirStips.Add(new Vector3(1933.589f, 4713.754f, 42.33749f)); fAir.Add(297.6379f);
            vAirStips.Add(new Vector3(2874.167f, 3928.381f, 54.02859f)); fAir.Add(63.15288f);
            vAirStips.Add(new Vector3(2457.873f, 1117.116f, 80.76649f)); fAir.Add(265.2575f);
            vAirStips.Add(new Vector3(2173.284f, 2644.494f, 54.49402f)); fAir.Add(280.4862f);
            vAirStips.Add(new Vector3(2017.36f, 2729.405f, 51.34712f)); fAir.Add(0.2645806f);
            vAirStips.Add(new Vector3(1736.23f, 3261.618f, 42.48234f)); fAir.Add(106.1397f);
            vAirStips.Add(new Vector3(1086.105f, 3017.629f, 42.22773f)); fAir.Add(285.6882f);
            vAirStips.Add(new Vector3(-60.70419f, 3368.598f, 51.76259f)); fAir.Add(255.485f);
            vAirStips.Add(new Vector3(-819.7478f, 2580.281f, 77.56622f)); fAir.Add(337.8569f);
            vAirStips.Add(new Vector3(-1585.431f, 2962.705f, 34.51f)); fAir.Add(199.6444f);
            vAirStips.Add(new Vector3(-2013.2f, 2861.529f, 34.11044f)); fAir.Add(62.47633f);
            vAirStips.Add(new Vector3(-2738.26f, 2938.095f, 3.82725f)); fAir.Add(171.6526f);
            vAirStips.Add(new Vector3(-2763.089f, 2407.076f, 3.892683f)); fAir.Add(0.7815081f);
            vAirStips.Add(new Vector3(-2231.201f, 1478.06f, 312.9143f)); fAir.Add(256.8859f);
            vAirStips.Add(new Vector3(495.3068f, 737.1909f, 201.9226f)); fAir.Add(171.4047f);
            vAirStips.Add(new Vector3(1077.546f, -2637.157f, 10.16461f)); fAir.Add(253.2725f);
            vAirStips.Add(new Vector3(1488.146f, -2310.9f, 75.20724f)); fAir.Add(169.5389f);
            vAirStips.Add(new Vector3(2102.663f, -1286.447f, 172.338f)); fAir.Add(341.0411f);
            vAirStips.Add(new Vector3(-1653.35f, -2961.487f, 15.16018f)); fAir.Add(241.3029f);
            vAirStips.Add(new Vector3(-1583.563f, -2806.431f, 15.17272f)); fAir.Add(238.7381f);
            vAirStips.Add(new Vector3(-1366.345f, -2265.252f, 15.16539f)); fAir.Add(150.7039f);
            vAirStips.Add(new Vector3(-2060.022f, -529.9898f, 8.60621f)); fAir.Add(205.3437f);
            vAirStips.Add(new Vector3(-1736.404f, -795.8164f, 10.60102f)); fAir.Add(45.13831f);
            vAirStips.Add(new Vector3(-3247.287f, 1242.457f, 3.927659f)); fAir.Add(171.3576f);
            vAirStips.Add(new Vector3(-2897.66f, 1403.708f, 76.63241f)); fAir.Add(107.6411f);

            Vector3 vPos = Game.Player.Character.Position;

            for (int i = 0; i < vAirStips.Count; i++)
            {
                float fDist = vAirStips[i].DistanceTo(vPos);
                fAirDist.Add(fDist);
            }
            float fMin = fAirDist[0];
            int iAir = 0;
            for (int i = 0; i < fAirDist.Count; i++)
            {
                if (fAirDist[i] < fMin)
                { fMin = fAirDist[i]; iAir = i; }
            }
            bIFrutiyAdd = true;
            iService = 4;
            sLastVeh = sAircraft;
            ObjectBuild.VehicleSpawn(sAircraft, vAirStips[iAir], fAir[iAir], false, false, false, false, 0, 0, 0, "", 10, false);
            //AddVeh(sAircraft, vAirStips[iAir], fAir[iAir], false, 4, OhMyBlip(sAircraft, 307), false);
        }
        private void BribesAnswered(iFruitContact contact)
        {
            LogThis("BribesAnswered");
            bFunctionTime = true;
            iFunctionTime = 7;
        }
        public int RandInt(int minNumber, int maxNumber)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, minNumber, maxNumber);
        }
        private void ListBulder()
        {
            sTrainerOnly.Add("DEVESTE"); //
            sTrainerOnly.Add("EMERUS"); //
            sTrainerOnly.Add("FURIA"); //
            sTrainerOnly.Add("KRIEGER"); //
            sTrainerOnly.Add("THRAX"); //
            sTrainerOnly.Add("ZORRUSSO"); //
            sTrainerOnly.Add("TIGON");
            sTrainerOnly.Add("DRAFTER"); //<!-- 8F Drafter -->
            sTrainerOnly.Add("IMORGON"); //
            sTrainerOnly.Add("ISSI7"); //<!-- Issi Sport -->
            sTrainerOnly.Add("ITALIGTO"); //
            sTrainerOnly.Add("JUGULAR"); //
            sTrainerOnly.Add("KOMODA"); //
            sTrainerOnly.Add("LOCUST"); //
            sTrainerOnly.Add("NEO"); //
            sTrainerOnly.Add("PARAGON"); //
            sTrainerOnly.Add("PARAGON2"); //<!-- Paragon R (Armored) -->
            sTrainerOnly.Add("SCHLAGEN"); //
            sTrainerOnly.Add("SUGOI"); //
            sTrainerOnly.Add("SULTAN2"); //<!-- Sultan Classic -->
            sTrainerOnly.Add("VSTR"); //<!-- V-STR -->
            sTrainerOnly.Add("COQUETTE4"); //<!-- Coquette D10  -->
            sTrainerOnly.Add("PENUMBRA2"); //<!-- Penumbra FF   -->
            sTrainerOnly.Add("CLIQUE"); //
            sTrainerOnly.Add("DEVIANT"); //
            sTrainerOnly.Add("GAUNTLET3"); //<!-- Gauntlet Classic -->
            sTrainerOnly.Add("GAUNTLET4"); //<!-- Gauntlet Hellfire -->
            sTrainerOnly.Add("PEYOTE2"); //<!-- Peyote Gasser -->
            sTrainerOnly.Add("IMPALER"); //
            sTrainerOnly.Add("TULIP"); //
            sTrainerOnly.Add("VAMOS"); //
            sTrainerOnly.Add("DUKES3"); //
            sTrainerOnly.Add("GAUNTLET5"); //
            sTrainerOnly.Add("MANANA2"); //
            sTrainerOnly.Add("PEYOTE3"); //
            sTrainerOnly.Add("GLENDALE2"); //
            sTrainerOnly.Add("YOSEMITE3"); //
            sTrainerOnly.Add("DYNASTY"); //
            sTrainerOnly.Add("JB7002"); //<!-- JB 700W -->
            sTrainerOnly.Add("NEBULA"); //
            sTrainerOnly.Add("RETINUE2"); //<!-- Retinue MkII -->
            sTrainerOnly.Add("ZION3"); //<!-- Zion Classic -->
            sTrainerOnly.Add("COQUETTE4"); //<!-- Coquette D10  -->
            sTrainerOnly.Add("ASBO"); //
            sTrainerOnly.Add("KANJO"); //<!-- Blista Kanjo -->
            sTrainerOnly.Add("CLUB");
            sTrainerOnly.Add("CARACARA2"); //<!-- Caracara 4x4 -->
            sTrainerOnly.Add("EVERON"); //
            sTrainerOnly.Add("OUTLAW"); //
            sTrainerOnly.Add("VAGRANT"); //
            sTrainerOnly.Add("ZHABA"); //
            sTrainerOnly.Add("NOVAK"); //
            sTrainerOnly.Add("REBLA"); //
            sTrainerOnly.Add("TOROS"); //
            sTrainerOnly.Add("LANDSTALKER2"); //
            sTrainerOnly.Add("SEMINOLE2"); //
        }
        private void OnLoadUp()
        {
            LogThis("OnLoadUp");

            ListBulder();
            Fruits(0);
            Fruits(3);
            Fruits(7);
            ReadContacts();
            AddMissingCont();
            AddMissWeaps(Mk2WeapsMain, bWeapSwap);
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (bFunctionTime)
            {
                bFunctionTime = false;
                ShutThatPhone(iFunctionTime);
                iFunctionTime = 0;
            }
            else if (bMenuOpen)
            {
                if (YtmenuPool.IsAnyMenuOpen())
                    YtmenuPool.ProcessMenus();
                else
                {
                    if (bWepMenuX)
                    {
                        Fubar_Clean();
                        WriteContacts();
                    }
                    bMenuOpen = false;
                }
            }
            else if (bIFrutiyAdd)
            {
                iFruit.Update();

                if (Function.Call<bool>(Hash.IS_PLAYER_DEAD) || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                {
                    if (bFubarRide || bWeaponMan || bMeeddicc || bImports)
                    {
                        bFubarRide = false;
                        Fubar_Clean();
                    }
                    else if (DataStore.bBankTransfer)
                    {
                        DataStore.bBankTransfer = false;
                        bIFrutiyAdd = false;
                        DataStore.iCoinBats = 0;
                    }
                }
                else if (iService > 0)
                {
                    if (DataStore.SharedVeh != null)
                    {
                        if (iService == 1)
                        {
                            FubarCarX = new Vehicle(DataStore.SharedVeh.Handle);
                            FubarCarX.PrimaryColor = VehicleColor.MetallicWhite;
                            FubarCarX.SmashWindow(VehicleWindow.FrontLeftWindow);
                            FubarCarX.DirtLevel = 99.75f;
                            AddNPC(ReturnStuff.RandNPC(18), FubarCarX.Position, 0.00f, FubarCarX, iService);
                            bStopDriving = true;
                            DataStore.SharedVeh = null;
                        }//Fubar
                        else if (iService == 2)
                        {
                            FubarCarX = new Vehicle(DataStore.SharedVeh.Handle);
                            AddNPC("s_m_m_paramedic_01", FubarCarX.Position, 0.00f, FubarCarX, iService);
                            DataStore.SharedVeh = null;
                        }//Medic
                        else if (iService == 3)
                        {
                            FubarCarX = new Vehicle(DataStore.SharedVeh.Handle);
                            AddNPC("mp_m_weapexp_01", FubarCarX.Position, 0.00f, FubarCarX, iService);
                            DataStore.SharedVeh = null;
                        }//Weppons
                        else if (iService == 4)
                        {
                            FubarCarX = new Vehicle(DataStore.SharedVeh.Handle);
                            bImports = true;
                            DataStore.SharedVeh = null;
                        }//Non Boat
                        else if (iService == 5)
                        {
                            FubarCarX = new Vehicle(DataStore.SharedVeh.Handle);
                            bImports = true;
                            Function.Call(Hash.SET_BOAT_ANCHOR, FubarCarX.Handle, true);
                            DataStore.SharedVeh = null;
                        }//Boats

                        LogThis("iService == " + iService); 
                        iService = 0;
                    }
                }
                else if (bFubarRide)
                {
                    if (iFubCarzz == 0)
                    {
                        if (FUbarDrv.IsDead || Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(FubarCarX.Position) > 155.00f)
                        {
                            bFubFails = true;
                            bFubarRide = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(FubarCarX.Position) < 5.00f)
                            {
                                if (bStopDriving)
                                {
                                    bStopDriving = false;
                                    FUbarDrv.Task.DriveTo(FubarCarX, FubarCarX.Position, 3.00f, 1.00f, 536871355);
                                    FubarCarX.SoundHorn(2000);
                                }
                                ReadContacts();
                                ControlerUI(DataStore.MyLang.ContactLang[64], 5000);
                                iFubCarzz = 1;
                            }
                            else if (Game.Player.Character.Position.DistanceTo(FubarCarX.Position) < 15.00f)
                            {
                                if (bStopDriving)
                                {
                                    bStopDriving = false;
                                    FUbarDrv.Task.DriveTo(FubarCarX, FubarCarX.Position, 3.00f, 1.00f, 536871355);
                                    FubarCarX.SoundHorn(2000);
                                }
                            }
                            else if (Game.Player.Character.Position.DistanceTo(vFuDest) > 25.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                vFuDest = Game.Player.Character.Position;
                                if (FUbarDrv.IsInVehicle())
                                    FUbarDrv.Task.DriveTo(FubarCarX, vFuDest, 3.00f, 35.00f, 536871355);
                                else
                                    FUbarDrv.Task.EnterVehicle(FubarCarX, VehicleSeat.Driver, -1, 8.00f);
                            }
                        }
                    }
                    else if (iFubCarzz == 1)
                    {
                        if (!Game.Player.Character.IsInVehicle(FubarCarX))
                        {
                            if (ButtonDown(23))
                                Game.Player.Character.Task.EnterVehicle(FubarCarX, VehicleSeat.Passenger, -1, 8.00f);
                            else if (Game.Player.Character.Position.DistanceTo(FubarCarX.Position) > 150.00f || Game.Player.Character.IsInVehicle() || FUbarDrv.IsDead)
                            {
                                if (!Game.Player.Character.IsInVehicle())
                                    Game.Player.Character.Task.ClearAll();
                                bFubarRide = false;
                                Fubar_Clean();
                            }
                        }
                        else
                        {
                            if (MissionData.vFuMiss != Vector3.Zero)
                                bFuToMishTarg = true;
                            else
                            {
                                VTBTimerPool.Add(FuBar);
                                FuBar.Label = DataStore.MyLang.ContactLang[65];
                            }
                            vFuFees = FubarCarX.Position;
                            iFuFees = 5;
                            bFooWayPot = false;
                            iFubCarzz = 2;
                        }
                    }
                    else if (iFubCarzz == 2)
                    {
                        if (Game.Player.Character.IsInVehicle(FubarCarX))
                        {
                            if (bFooWayPot)
                            {
                                if (bFuToMishTarg)
                                {
                                    ControlerUI(DataStore.MyLang.ContactLang[66], 1);
                                    if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                    {
                                        bFubarRide = false;
                                        Fubar_Carzz(true);
                                    }
                                }
                                else
                                {
                                    if (!Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                                        bFooWayPot = false;
                                    else
                                    {
                                        ControlerUI(DataStore.MyLang.ContactLang[75], 1);
                                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                        {
                                            bFubarRide = false;
                                            Fubar_Carzz(false);
                                        }
                                        else if (iFuClock < Game.GameTime)
                                            Fubar_Math(true);
                                        else if (DataStore.MyDatSet.iNSPMBank < iFuFees)
                                        {
                                            FUbarDrv.Task.ClearAll();
                                            FUbarDrv.Task.ParkVehicle(FubarCarX, FubarCarX.Position, FubarCarX.Heading);
                                            Fubar_Math(false);
                                            iFuFees *= -1;
                                            UiDisplay.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[18]);
                                            iFuFees = 0;
                                            bFubarRide = false;
                                            Fubar_Clean();
                                        }

                                        VTBTimerPool.Draw();
                                    }
                                }
                            }
                            else
                            {
                                if (bFuToMishTarg)
                                {
                                    if (FUbarDrv.IsInVehicle())
                                        FUbarDrv.Task.DriveTo(FubarCarX, MissionData.vFuMiss, 3.00f, 35.00f, 536871355);
                                    bFooWayPot = true;
                                }
                                else if (!Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                                    ControlerUI(DataStore.MyLang.ContactLang[67], 1);
                                else
                                {
                                    vFuDest = World.GetWaypointPosition();
                                    if (FUbarDrv.IsInVehicle())
                                        FUbarDrv.Task.DriveTo(FubarCarX, vFuDest, 3.00f, 35.00f, 536871355);
                                    bFooWayPot = true;
                                }
                            }
                        }
                        else
                        {
                            Fubar_Math(false);
                            iFuFees *= -1;
                            UiDisplay.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[18]);
                            iFuFees = 0;
                            bFubarRide = false;
                            Fubar_Clean();
                        }
                    }
                }
                else if (bWeaponMan)
                {
                    if (iFubCarzz == 0)
                    {
                        if (Game.Player.Character.IsInVehicle() || FUbarDrv.IsDead || Game.Player.Character.Position.DistanceTo(FubarCarX.Position) > 155.00f)
                        {
                            bWeaponMan = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(FubarCarX.Position) < 15.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                FUbarDrv.Task.LeaveVehicle();
                                iFubCarzz = 1;
                                iWait4Sec = Game.GameTime + 1000;
                            }
                            else if (World.GetNextPositionOnStreet(Game.Player.Character.Position).DistanceTo(vFuDest) > 25.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                vFuDest = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                                if (FUbarDrv.IsInVehicle())
                                    FUbarDrv.Task.DriveTo(FubarCarX, vFuDest, 3.00f, 20.00f, 536871355);
                            }
                        }
                    }
                    else if (iFubCarzz == 1)
                    {
                        if (FUbarDrv.IsDead || FubarCarX.IsDead)
                        {
                            bWeaponMan = false;
                            Fubar_Clean();
                        }
                        else if (FUbarDrv.IsInVehicle())
                        {
                            if (iWait4Sec < Game.GameTime)
                            {
                                FUbarDrv.Task.ClearAll();
                                FUbarDrv.Task.LeaveVehicle();
                                iWait4Sec = Game.GameTime + 1000;
                            }
                        }
                        else
                        {
                            Vector3 Vpos = FubarCarX.Position - (FubarCarX.ForwardVector * 4.75f);
                            FUbarDrv.Task.ClearAll();
                            FUbarDrv.Task.GoTo(Vpos, true);
                            iFubCarzz = 2;
                        }
                    }
                    else if (iFubCarzz == 2)
                    {
                        Vector3 Vpos = FubarCarX.Position - (FubarCarX.ForwardVector * 4.75f);
                        if (FUbarDrv.IsDead || FubarCarX.IsDead || Game.Player.Character.Position.DistanceTo(Vpos) > 150.00f)
                        {
                            bWeaponMan = false;
                            Fubar_Clean();
                        }
                        else if (FUbarDrv.Position.DistanceTo(Vpos) < 2.50f && !FubarCarX.IsDoorOpen(VehicleDoor.BackLeftDoor))
                        {
                            FUbarDrv.Task.ClearAll();
                            FUbarDrv.Task.StandStill(-1);
                            FubarCarX.OpenDoor(VehicleDoor.BackLeftDoor, false, false);
                            FubarCarX.OpenDoor(VehicleDoor.BackRightDoor, false, false);
                        }
                        else if (Game.Player.Character.Position.DistanceTo(Vpos) < 1.50f && FubarCarX.IsDoorOpen(VehicleDoor.BackLeftDoor))
                        {
                            ControlerUI(DataStore.MyLang.ContactLang[68], 1);

                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                FUbarDrv.Task.StandStill(-1);
                                Script.Wait(1000);
                                WeaponsMenu();
                            }
                        }
                    }
                }
                else if (bMeeddicc)
                {
                    if (iFubCarzz == 0)
                    {
                        if (FUbarDrv.IsDead || Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(FubarCarX.Position) > 95.00f)
                        {
                            bMeeddicc = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(FubarCarX.Position) < 15.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                FUbarDrv.Task.LeaveVehicle();
                                iFubCarzz = 1;
                                iWait4Sec = Game.GameTime + 1000;
                            }
                            else if (World.GetNextPositionOnStreet(Game.Player.Character.Position).DistanceTo(vFuDest) > 25.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                vFuDest = World.GetNextPositionOnStreet(Game.Player.Character.Position);
                                if (FUbarDrv.IsInVehicle())
                                    FUbarDrv.Task.DriveTo(FubarCarX, vFuDest, 3.00f, 20.00f, 536871355);
                            }
                        }
                    }
                    else if (iFubCarzz == 1)
                    {
                        if (FUbarDrv.IsDead || Game.Player.Character.Position.DistanceTo(FUbarDrv.Position) > 150.00f)
                        {
                            bMeeddicc = false;
                            Fubar_Clean();
                        }
                        else if (FUbarDrv.IsInVehicle())
                        {
                            if (iWait4Sec < Game.GameTime)
                            {
                                FUbarDrv.Task.ClearAll();
                                FUbarDrv.Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
                                iWait4Sec = Game.GameTime + 4000;
                            }
                        }
                        else
                        {
                            FUbarDrv.Task.ClearAll();
                            FUbarDrv.Task.GoTo(Game.Player.Character.Position);
                            iFubCarzz = 2;
                        }
                    }
                    else if (iFubCarzz == 2)
                    {
                        Vector3 Vpos = FubarCarX.Position - (FubarCarX.ForwardVector * 3.75f);
                        if (FUbarDrv.IsDead || Game.Player.Character.Position.DistanceTo(Vpos) > 150.00f)
                        {
                            bMeeddicc = false;
                            Fubar_Clean();
                        }
                        else if (FUbarDrv.Position.DistanceTo(Game.Player.Character.Position) < 1.50f)
                        {
                            FUbarDrv.Task.PlayAnimation("amb@medic@standing@timeofdeath@idle_a", "idle_a", 8.00f, 4000, false, 1.00f);
                            Game.Player.Character.Health = Game.Player.Character.MaxHealth;
                            Script.Wait(1000);
                            bMeeddicc = false;
                            Fubar_Clean();
                        }
                    }
                }
                else if (bImports)
                {
                    if (Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(FubarCarX.Position) > 150.00f)
                    {
                        Fubar_Clean();
                        bIFrutiyAdd = false;
                    }
                }
                else if (DataStore.bBankTransfer)
                {
                    UiDisplay.BankingApp();
                }
            }
            else
                iFruit.Update();
        }
    }
}