using System.Collections.Generic;
using New_Street_Phone_Missions.Classes;
using New_Street_Phone_Missions;
using NativeUI;
using GTA;
using GTA.Native;
using GTA.Math;
using System.IO;

namespace NSPM_Contacts
{
    public class Contacts
    {
        private static string FruitDir = "" + Directory.GetCurrentDirectory() + "/MobileNetwork";
        private static string FruitReturn01 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return01.ini";
        private static string FruitReturn02 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return02.ini";
        private static string FruitReturn03 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return03.ini";
        private static string FruitReturn04 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return04.ini";
        private static string FruitReturn05 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return05.ini";
        private static string FruitReturn06 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return06.ini";
        private static string FruitReturn07 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return07.ini";
        private static string FruitReturn08 = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Return08.ini";
        private static bool bStopDriving = false;
        private static bool bMenuOpen = false;
        private static bool bImports = false;
        private static bool bWeapSwap = false;
        private static bool bMeeddicc = false;
        private static bool bWepMenuX = false;
        private static bool bWeaponMan = false;
        private static bool bFubarRide = false;
        private static bool bFooWayPot = false;
        private static bool bIFrutiyAdd = false;
        private static bool bFuToMishTarg = false;

        private static int iFubCarzz = 0;
        private static int iFubard = 0;
        private static int iJustBribed = 0;
        private static int iFuClock = 0;
        private static int iFuFees = 0;
        private static int iWait4Sec = 0;
        private static int iService = 0;

        private static string sLastVeh = "";

        private static Vector3 vFuDest = Vector3.Zero;
        private static Vector3 vFuFees = Vector3.Zero;

        private static Ped FUbarDrv = null;

        private static List<bool> BeeEnabled = new List<bool> { false, false, false, false, false };

        //private static CustomiFruit iFruit = new CustomiFruit();

        private static TimerBarPool VTBTimerPool = new TimerBarPool();
        private static TextTimerBar FuBar = new TextTimerBar("", "");

        private static MenuPool menuPoolX = new MenuPool();

        public static void CheckPhone()
        {
            if (File.Exists(FruitReturn01))
            {
                File.Delete(FruitReturn01);
                ShutThatPhone(1);
            }
            else if (File.Exists(FruitReturn02))
            {
                File.Delete(FruitReturn02);
                ShutThatPhone(2);
            }
            else if (File.Exists(FruitReturn03))
            {
                File.Delete(FruitReturn03);
                ShutThatPhone(3);
            }
            else if (File.Exists(FruitReturn04))
            {
                File.Delete(FruitReturn04);
                ShutThatPhone(4);
            }
            else if (File.Exists(FruitReturn05))
            {
                File.Delete(FruitReturn05);
                ShutThatPhone(5);
            }
            else if (File.Exists(FruitReturn06))
            {
                File.Delete(FruitReturn06);
                ShutThatPhone(6);
            }
            else if (File.Exists(FruitReturn07))
            {
                File.Delete(FruitReturn07);
                ShutThatPhone(7);
            }
            else if (File.Exists(FruitReturn08))
            {
                File.Delete(FruitReturn08);
                ShutThatPhone(8);
            }
        }
        public static void Contacting()
        {
            if (bMenuOpen)
            {
                if (menuPoolX.IsAnyMenuOpen())
                    menuPoolX.ProcessMenus();
                else
                {
                    if (bWepMenuX)
                    {
                        Fubar_Clean();
                        ReadWriteXML.SaveXmlContacts(DataStore.MyContacts, DataStore.sNSPMCont);
                    }
                    bMenuOpen = false;
                }
            }
            else if (bIFrutiyAdd)
            {
                if (Function.Call<bool>(Hash.IS_PLAYER_DEAD) || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                {
                    if (bFubarRide || bWeaponMan || bMeeddicc || bImports)
                    {
                        bFubarRide = false;
                        Fubar_Clean();
                    }
                    else if (DataStore.BankTransfer)
                    {
                        DataStore.BankTransfer = false;
                        bIFrutiyAdd = false;
                        DataStore.iCoinBats = 0;
                    }
                }
                else if (iService > 0)
                {
                    if (DataStore.SharedVeh != null)
                    {
                        MissionData.VehicleList_01.Remove(DataStore.SharedVeh);
                        if (iService == 1)
                        {
                            DataStore.SharedVeh.SmashWindow(VehicleWindow.FrontLeftWindow);
                            DataStore.SharedVeh.DirtLevel = 99.75f;
                            AddNPC(ReturnStuff.RandNPC(18), DataStore.SharedVeh.Position, 0.00f, DataStore.SharedVeh, iService);
                            bStopDriving = true;
                        }//Fubar
                        else if (iService == 2)
                        {
                            DataStore.SharedVeh = new Vehicle(DataStore.SharedVeh.Handle);
                            AddNPC("s_m_m_paramedic_01", DataStore.SharedVeh.Position, 0.00f, DataStore.SharedVeh, iService);
                        }//Medic
                        else if (iService == 3)
                        {
                            DataStore.SharedVeh = new Vehicle(DataStore.SharedVeh.Handle);
                            AddNPC("mp_m_weapexp_01", DataStore.SharedVeh.Position, 0.00f, DataStore.SharedVeh, iService);
                        }//Weppons
                        else if (iService == 4)
                        {
                            DataStore.SharedVeh = new Vehicle(DataStore.SharedVeh.Handle);
                            bImports = true;
                        }//Non Boat
                        else if (iService == 5)
                        {
                            DataStore.SharedVeh = new Vehicle(DataStore.SharedVeh.Handle);
                            bImports = true;
                            Function.Call(Hash.SET_BOAT_ANCHOR, DataStore.SharedVeh.Handle, true);
                        }//Boats

                        Main.LogThis("iService == " + iService);
                        iService = 0;
                    }
                }
                else if (bFubarRide)
                {
                    if (iFubCarzz == 0)
                    {
                        if (FUbarDrv.IsDead || Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
                        {
                            bFubarRide = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) < 5.00f)
                            {
                                if (bStopDriving)
                                {
                                    bStopDriving = false;
                                    FUbarDrv.Task.DriveTo(DataStore.SharedVeh, DataStore.SharedVeh.Position, 3.00f, 1.00f, 536871355);
                                    DataStore.SharedVeh.SoundHorn(2000);
                                }
                                UiDisplay.ControlerUI(DataStore.MyLang.ContactLang[64], 5000);
                                iFubCarzz = 1;
                            }
                            else if (Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) < 15.00f)
                            {
                                if (bStopDriving)
                                {
                                    bStopDriving = false;
                                    FUbarDrv.Task.DriveTo(DataStore.SharedVeh, DataStore.SharedVeh.Position, 3.00f, 1.00f, 536871355);
                                    DataStore.SharedVeh.SoundHorn(2000);
                                }
                            }
                            else if (Game.Player.Character.Position.DistanceTo(vFuDest) > 25.00f)
                            {
                                FUbarDrv.Task.ClearAll();
                                vFuDest = Game.Player.Character.Position;
                                if (FUbarDrv.IsInVehicle())
                                    FUbarDrv.Task.DriveTo(DataStore.SharedVeh, vFuDest, 3.00f, 35.00f, 536871355);
                                else
                                    FUbarDrv.Task.EnterVehicle(DataStore.SharedVeh, VehicleSeat.Driver, -1, 8.00f);
                            }
                        }
                    }
                    else if (iFubCarzz == 1)
                    {
                        if (!Game.Player.Character.IsInVehicle(DataStore.SharedVeh))
                        {
                            if (ButtonDown(23))
                            {
                                Game.Player.Character.Task.EnterVehicle(DataStore.SharedVeh, VehicleSeat.Passenger, -1, 8.00f);
                                DataStore.SharedVeh.CurrentBlip.Remove();
                            }
                            else if (Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f || Game.Player.Character.IsInVehicle() || FUbarDrv.IsDead)
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
                            vFuFees = DataStore.SharedVeh.Position;
                            iFuFees = 5;
                            bFooWayPot = false;
                            iFubCarzz = 2;
                        }
                    }
                    else if (iFubCarzz == 2)
                    {
                        if (Game.Player.Character.IsInVehicle(DataStore.SharedVeh))
                        {
                            if (bFooWayPot)
                            {
                                if (bFuToMishTarg)
                                {
                                    UiDisplay.ControlerUI(DataStore.MyLang.ContactLang[66], 1);
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
                                        UiDisplay.ControlerUI(DataStore.MyLang.ContactLang[75], 1);
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
                                            FUbarDrv.Task.ParkVehicle(DataStore.SharedVeh, DataStore.SharedVeh.Position, DataStore.SharedVeh.Heading);
                                            Fubar_Math(false);
                                            iFuFees *= -1;
                                            NSBanking.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[18]);
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
                                        FUbarDrv.Task.DriveTo(DataStore.SharedVeh, MissionData.vFuMiss, 3.00f, 35.00f, 536871355);
                                    bFooWayPot = true;
                                }
                                else if (!Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
                                    UiDisplay.ControlerUI(DataStore.MyLang.ContactLang[67], 1);
                                else
                                {
                                    vFuDest = World.GetWaypointPosition();
                                    if (FUbarDrv.IsInVehicle())
                                        FUbarDrv.Task.DriveTo(DataStore.SharedVeh, vFuDest, 3.00f, 35.00f, 536871355);
                                    bFooWayPot = true;
                                }
                            }
                        }
                        else
                        {
                            Fubar_Math(false);
                            iFuFees *= -1;
                            NSBanking.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[18]);
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
                        if (Game.Player.Character.IsInVehicle() || FUbarDrv.IsDead || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
                        {
                            bWeaponMan = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) < 15.00f)
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
                                    FUbarDrv.Task.DriveTo(DataStore.SharedVeh, vFuDest, 3.00f, 20.00f, 536871355);
                            }
                        }
                    }
                    else if (iFubCarzz == 1)
                    {
                        if (FUbarDrv.IsDead || DataStore.SharedVeh.IsDead || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
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
                            Vector3 Vpos = DataStore.SharedVeh.Position - (DataStore.SharedVeh.ForwardVector * 4.75f);
                            FUbarDrv.Task.ClearAll();
                            FUbarDrv.Task.GoTo(Vpos, true);
                            iFubCarzz = 2;
                        }
                    }
                    else if (iFubCarzz == 2)
                    {
                        Vector3 Vpos = DataStore.SharedVeh.Position - (DataStore.SharedVeh.ForwardVector * 4.75f);
                        if (FUbarDrv.IsDead || DataStore.SharedVeh.IsDead || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
                        {
                            bWeaponMan = false;
                            Fubar_Clean();
                        }
                        else if (FUbarDrv.Position.DistanceTo(Vpos) < 2.50f && !DataStore.SharedVeh.IsDoorOpen(VehicleDoor.BackLeftDoor))
                        {
                            FUbarDrv.Task.ClearAll();
                            FUbarDrv.Task.StandStill(-1);
                            DataStore.SharedVeh.OpenDoor(VehicleDoor.BackLeftDoor, false, false);
                            DataStore.SharedVeh.OpenDoor(VehicleDoor.BackRightDoor, false, false);
                        }
                        else if (Game.Player.Character.Position.DistanceTo(Vpos) < 1.50f && DataStore.SharedVeh.IsDoorOpen(VehicleDoor.BackLeftDoor))
                        {
                            UiDisplay.ControlerUI(DataStore.MyLang.ContactLang[68], 1);

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
                        if (FUbarDrv.IsDead || Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
                        {
                            bMeeddicc = false;
                            Fubar_Clean();
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) < 15.00f)
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
                                    FUbarDrv.Task.DriveTo(DataStore.SharedVeh, vFuDest, 3.00f, 20.00f, 536871355);
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
                        Vector3 Vpos = DataStore.SharedVeh.Position - (DataStore.SharedVeh.ForwardVector * 3.75f);
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
                    if (Game.Player.Character.IsInVehicle() || Game.Player.Character.Position.DistanceTo(DataStore.SharedVeh.Position) > 150.00f)
                    {
                        Fubar_Clean();
                        bIFrutiyAdd = false;
                    }
                }
            }
            else
                CheckPhone();
        }
        private static void ShutThatPhone(int iFunct)
        {
            Main.LogThis("ShutThatPhone iFunct == " + iFunct);

            if (DataStore.BankTransfer)
                DataStore.BankTransfer = false;
            /*
            iFruit.Close();
            while (Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, Game.Player.Character.Handle))
                Script.Wait(1);

            
            Script.Wait(1000);
            */
            if (DataStore.SharedVeh != null)
                Fubar_Clean();


            if (iFunct == 1)
            {
                NSPMCoinAccount();
            }                                // NSBanknig
            else if (iFunct == 2)
            {
                SearchFor.ExtCarz = null;
                if (!Game.Player.Character.IsInVehicle() && Game.Player.Character.Position.DistanceTo(World.GetNextPositionOnStreet(Game.Player.Character.Position)) < 150f)
                {
                    iService = 1;
                    sLastVeh = "Dilettante";
                    VehMods Vmod = new VehMods(sLastVeh, 2, 53, false, "Fubar", false, true, 132, 132, 0, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position ,Vmod, true, true);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[0]);
                bIFrutiyAdd = true;
            }                           // Fubar
            else if (iFunct == 3)
            {
                SearchFor.ExtCarz = null;
                if (!Game.Player.Character.IsInVehicle() && Game.Player.Character.Position.DistanceTo(World.GetNextPositionOnStreet(Game.Player.Character.Position)) < 150f)
                    ImportsMenu();
                else
                    UI.Notify(DataStore.MyLang.ContactLang[1]);
            }                           // Imports
            else if (iFunct == 4)
            {
                var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[43], DataStore.MyLang.ContactLang[44]);
                menuPoolX.Add(mainMenu);
                MkWepsOpt(mainMenu);
                menuPoolX.RefreshIndex();
                bMenuOpen = true;
                mainMenu.Visible = !mainMenu.Visible;
            }                           // Mk2Weaps
            else if (iFunct == 5)
            {
                SearchFor.ExtCarz = null;
                if (!Game.Player.Character.IsInVehicle())
                {
                    // EntityBuild.PlaySoundDirect("MPCT", "MPCT_AMAA_01", "");
                    PeggsMenu();
                }
                else
                {
                    UI.Notify(DataStore.MyLang.ContactLang[1]);
                }
            }                           // Peggass
            else if (iFunct == 6)
            {
                if (iJustBribed < Game.GameTime)
                {
                    if (Game.Player.WantedLevel <= 3)
                    {
                        if (DataStore.MyDatSet.iNSPMBank > 499)
                        {
                            Game.Player.WantedLevel = 0;
                            NSBanking.YourCoinPopUp(-500, 1, DataStore.MyLang.ContactLang[62]);
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
            }                           // PoliceBribes
            else if (iFunct == 7)
            {


                SearchFor.ExtCarz = null;
                if (!Game.Player.Character.IsInVehicle() && Game.Player.Character.Position.DistanceTo(World.GetNextPositionOnStreet(Game.Player.Character.Position)) < 150f)
                {
                    if (DataStore.MyDatSet.iNSPMBank > 500)
                    {
                        NSBanking.YourCoinPopUp(-500, 1, DataStore.MyLang.ContactLang[42]);
                        iService = 2;
                        sLastVeh = "ambulance";
                        VehMods Vmod = new VehMods(sLastVeh, 2, 54, false, "Medic");
                        Vmod.VehTag = "Fubs=";
                        SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, true);
                    }
                    else
                        UI.Notify(DataStore.MyLang.ContactLang[41]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[3]);
                bIFrutiyAdd = true;
            }                           // Ambulance 
            else if (iFunct == 8)
            {
                if (DataStore.OnTheJob)
                    UI.Notify(DataStore.MyLang.ContactLang[94]);
                else
                    TheMenusLoc.SettingsMenu();
            }                           // Settings

            AddMissingCont();
        }
        private static void AddMissingCont()
        {
            Main.LogThis("AddMissingCont");

            if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, Game.Player.Character))
            {
                if (!BeeEnabled[0])
                {
                    if (DataStore.MyAssets.Fubard)
                    {
                        Fruits(1);
                        BeeEnabled[0] = true;
                    }
                }
                if (!BeeEnabled[1])
                {
                    if (DataStore.MyContacts.ImpXCars.Count > 0)
                    {
                        Fruits(2);
                        BeeEnabled[1] = true;
                    }
                }
                if (!BeeEnabled[2])
                {
                    if (DataStore.MyAssets.GotPegsus)
                    {
                        Fruits(4);
                        BeeEnabled[2] = true;
                    }
                }
                if (!BeeEnabled[3])
                {
                    if (DataStore.MyAssets.WantedBribe)
                    {
                        Fruits(5);
                        BeeEnabled[3] = true;
                    }
                }
                if (!BeeEnabled[4])
                {
                    if (DataStore.MyAssets.MeddicTest)
                    {
                        Fruits(6);
                        BeeEnabled[4] = true;
                    }
                }
            }
        }
        private static void AddMissWeaps(List<Mk2Weap> DemWeaps, bool bOldTest)
        {
            Main.LogThis("AddMissWeaps");

            try
            {
                if (DemWeaps.Count > 0)
                {
                    if (bOldTest)
                    {
                        bWeapSwap = false;
                        int iPed = MyChar();
                        for (int i = 0; i < DataStore.MyContacts.MyMk2Weaps.Count; i++)
                            DataStore.MyContacts.MyMk2Weaps[i].MyPlayer = iPed;
                        AddMissWeaps(DataStore.MyContacts.MyMk2Weaps, false);
                    }
                    else
                    {
                        int iThisChar = MyChar();
                        for (int i = 0; i < DataStore.MyContacts.MyMk2Weaps.Count; i++)
                        {
                            if (iThisChar == DataStore.MyContacts.MyMk2Weaps[i].MyPlayer)
                            {
                                Function.Call(Hash.GIVE_WEAPON_TO_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS), 9999, false, true);
                                for (int ii = 0; ii < DataStore.MyContacts.MyMk2Weaps[i].Mk2Addon.Count; ii++)
                                    Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyContacts.MyMk2Weaps[i].Mk2Addon[ii]));

                                DataStore.MyContacts.MyMk2Weaps[i].MyAmmos = ReturnStuff.MaxAmmo(DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS, Game.Player.Character);

                                FillMyAmmo(DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS, DataStore.MyContacts.MyMk2Weaps[i].MyAmmos);

                                if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS)) < ReturnStuff.MaxAmmo(DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS, Game.Player.Character))
                                {
                                    Script.Wait(500);
                                    FillMyAmmo(DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS, DataStore.MyContacts.MyMk2Weaps[i].MyAmmos);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Main.LogThis("Catch : AddMissWeaps");
            }
        }
        private static void AddNPC(string sModel, Vector3 vPos, float fHeads, Vehicle vHick, int iService)
        {
            Main.LogThis("AddNPC, sModel == " + sModel + ", iService == " + iService);
            PedFeat YoPed = new PedFeat(sModel, false, 140, 0, 1, vHick, 0, false, 0, "");
            YoPed.PedTag = "Fped=";
            FUbarDrv = EntityBuild.NPCSpawn(YoPed, vPos, fHeads);

            if (FUbarDrv.Exists())
            {
                MissionData.PedList_01.Remove(FUbarDrv);
                FUbarDrv.Accuracy = 45;
                FUbarDrv.MaxHealth = 250;
                FUbarDrv.Health = 250;
                if (vHick != null)
                    EntityBuild.WarptoAnyVeh(vHick, FUbarDrv, 1);

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
        private static bool ButtonDown(int CButt)
        {
            ButtonDisabler(CButt);
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        private static void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        private static void Fubar_Carzz(bool bMissionTarget)
        {
            Main.LogThis("Fubar_Carzz, bMissionTarget == " + bMissionTarget);

            int iFifty = 10;
            if (bMissionTarget)
            {
                if (MissionData.vFuMiss != Vector3.Zero)
                {
                    Game.FadeScreenOut(1000);
                    Script.Wait(1000);
                    DataStore.SharedVeh.Position = MissionData.vFuMiss;
                    Game.Player.Character.Task.LeaveVehicle();
                    Fubar_Math(false);
                    iFuFees *= -1;
                    NSBanking.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[14]);
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
                DataStore.SharedVeh.FreezePosition = true;
                vFuDest.Z = World.GetGroundHeight(MissionData.vFuMiss);
                DataStore.SharedVeh.Position = vFuDest;
                Script.Wait(1000);
                DataStore.SharedVeh.FreezePosition = false;
                DataStore.SharedVeh.Position = World.GetNextPositionOnStreet(vFuDest);
                while (World.GetStreetName(DataStore.SharedVeh.Position) != World.GetStreetName(vFuDest) && iFifty > 0)
                {
                    Script.Wait(100);
                    iFifty -= 1;
                    DataStore.SharedVeh.Position = World.GetNextPositionOnStreet(vFuDest);
                }
                if (iFifty < 1)
                    DataStore.SharedVeh.Position = vFuDest;
                Game.Player.Character.Task.LeaveVehicle();
                Fubar_Math(false);
                iFuFees *= -1;
                NSBanking.YourCoinPopUp(iFuFees, 1, DataStore.MyLang.ContactLang[14]);
                iFuFees = 0;
                Game.FadeScreenIn(1000);
                Fubar_Clean();
            }
        }
        private static void Fubar_Clean()
        {
            Main.LogThis("Fubar_Clean");

            if (DataStore.SharedVeh != null)
            {
                DataStore.SharedVeh.CloseDoor(VehicleDoor.BackLeftDoor, false);
                DataStore.SharedVeh.CloseDoor(VehicleDoor.BackRightDoor, false);

                if (DataStore.SharedVeh.CurrentBlip.Exists())
                    DataStore.SharedVeh.CurrentBlip.Remove();

                DataStore.SharedVeh.MarkAsNoLongerNeeded();
                DataStore.SharedVeh = null;
            }
            if (FUbarDrv != null)
            {
                FUbarDrv.MarkAsNoLongerNeeded();
                FUbarDrv = null;
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
            DataStore.SharedVeh = null;
            FUbarDrv = null;
        }
        private static void Fubar_Math(bool bTextBar)
        {
            iFuClock = Game.GameTime + 5000;
            if (iFubard > 99)
                iFuFees = 0;
            else
            {
                float fFIndFee = vFuFees.DistanceTo(DataStore.SharedVeh.Position) / 50;
                int iCost = (int)fFIndFee + 5;
                if (iCost > iFuFees)
                    iFuFees = iCost;
            }

            if (bTextBar)
                FuBar.Text = DataStore.MyLang.ContactLang[15] + iFuFees;
        }
        private static void Fruits(int iAdd)
        {
            Main.LogThis("Fruits, iAdd == " + iAdd);
            if (Directory.Exists(FruitDir))
            {
                if (iAdd == 0)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[16],
                        "ContactAddress=" + FruitReturn01,
                        "Icon=CHAR_BANK_MAZE",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone01.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[16]);
                    /*
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
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[16]);
                    */
                }
                else if (iAdd == 1)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[18],
                        "ContactAddress=" + FruitReturn02,
                        "Icon=CHAR_PROPERTY_TAXI_LOT",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone02.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[18]);
                    /*
                    iFruitContact FubarCarz = new iFruitContact(DataStore.MyLang.ContactLang[18]);
                    FubarCarz.Answered += FubarsAnswered;
                    FubarCarz.DialTimeout = 4000;
                    FubarCarz.Active = true;
                    FubarCarz.Icon = ContactIcon.Property_TaxiLot;
                    iFruit.Contacts.Add(FubarCarz);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[18]);
                    */
                }
                else if (iAdd == 2)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[19],
                        "ContactAddress=" + FruitReturn03,
                        "Icon=CHAR_CARSITE",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone03.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[19]);
                    /*
                    iFruitContact ImportantCarz = new iFruitContact(DataStore.MyLang.ContactLang[19]);
                    ImportantCarz.Answered += ImportsAnswered;
                    ImportantCarz.DialTimeout = 4000;
                    ImportantCarz.Active = true;
                    ImportantCarz.Icon = ContactIcon.LegendaryMotorsport;
                    iFruit.Contacts.Add(ImportantCarz);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[19]);
                    */
                }
                else if (iAdd == 3)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[20],
                        "ContactAddress=" + FruitReturn04,
                        "Icon=CHAR_AMMUNATION",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone04.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[20]);
                    /*
                    iFruitContact GunDelivery = new iFruitContact(DataStore.MyLang.ContactLang[20]);
                    GunDelivery.Answered += WeapsAnswered;
                    GunDelivery.DialTimeout = 4000;
                    GunDelivery.Active = true;
                    GunDelivery.Icon = ContactIcon.Ammunation;
                    iFruit.Contacts.Add(GunDelivery);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[20]);
                    */
                }
                else if (iAdd == 4)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[21],
                        "ContactAddress=" + FruitReturn05,
                        "Icon=CHAR_PEGASUS_DELIVERY",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone05.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[21]);
                    /*
                    iFruitContact Peggasis = new iFruitContact(DataStore.MyLang.ContactLang[21]);
                    Peggasis.Answered += PeggsAnswered;
                    Peggasis.DialTimeout = 4000;
                    Peggasis.Active = true;
                    Peggasis.Icon = ContactIcon.Pegasus;
                    iFruit.Contacts.Add(Peggasis);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[21]);
                    */
                }
                else if (iAdd == 5)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[22],
                        "ContactAddress=" + FruitReturn06,
                        "Icon=CHAR_MP_FIB_CONTACT",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone06.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[22]);
                    /*
                    iFruitContact Bribes = new iFruitContact(DataStore.MyLang.ContactLang[22]);
                    Bribes.Answered += BribesAnswered;
                    Bribes.DialTimeout = 4000;
                    Bribes.Active = true;
                    Bribes.Icon = ContactIcon.MP_FibContact;
                    iFruit.Contacts.Add(Bribes);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[22]);
                    */
                }
                else if (iAdd == 6)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.ContactLang[23],
                        "ContactAddress=" + FruitReturn07,
                        "Icon=CHAR_CALL911",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone07.ini", AddSetts);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[23]);
                    /*
                    iFruitContact Medic = new iFruitContact(DataStore.MyLang.ContactLang[23]);
                    Medic.Answered += MedicAnswered;
                    Medic.DialTimeout = 4000;
                    Medic.Active = true;
                    Medic.Icon = ContactIcon.Emergency;
                    iFruit.Contacts.Add(Medic);
                    UI.Notify(DataStore.MyLang.ContactLang[17] + "~b~" + DataStore.MyLang.ContactLang[23]);
                    */
                }
                else if (iAdd == 7)
                {
                    List<string> AddSetts = new List<string>
                    {
                        "[Phone]",
                        "ContactName=" + DataStore.MyLang.Othertext[67],
                        "ContactAddress=" + FruitReturn08,
                        "Icon=CHAR_LESTER_DEATHWISH",
                        "[Phone/End]"
                    };
                    EntityLog.CreateIni(FruitDir + "/NSPMPhone08.ini", AddSetts);
                    /*
                    iFruitContact MySets = new iFruitContact(DataStore.MyLang.Othertext[67]);
                    MySets.Answered += SettingsAnswered;
                    MySets.DialTimeout = 4000;
                    MySets.Active = true;
                    MySets.Icon = ContactIcon.Skull;
                    iFruit.Contacts.Add(MySets);
                    */
                }
            }
        }
        
        /*
         *  //iFruit.Update();
            if (bFunctionTime)
            {
                bFunctionTime = false;
                ShutThatPhone(iFunctionTime);
                iFunctionTime = 0;
            }
            else


        private static void NSPMCoinAnswered(iFruitContact contact)
        {
            Main.LogThis("NSPMCoinAnswered");
            bFunctionTime = true;
            iFunctionTime = 1;
        }
        private static void FubarsAnswered(iFruitContact contact)
        {
            Main.LogThis("FubarsAnswered");
            bFunctionTime = true;
            iFunctionTime = 2;
        }
        private static void ImportsAnswered(iFruitContact contact)
        {
            Main.LogThis("ImportsAnswered");
            bFunctionTime = true;
            iFunctionTime = 3;
        }
        private static void MedicAnswered(iFruitContact contact)
        {
            Main.LogThis("MedicAnswered");
            bFunctionTime = true;
            iFunctionTime = 4;
        }
        private static void WeapsAnswered(iFruitContact contact)
        {
            Main.LogThis("WeapsAnswered");
            bFunctionTime = true;
            iFunctionTime = 5;
        }
        private static void SettingsAnswered(iFruitContact contact)
        {
            Main.LogThis("SettingsAnswered");
            bFunctionTime = true;
            iFunctionTime = 8;
        }
        private static void BribesAnswered(iFruitContact contact)
        {
            Main.LogThis("BribesAnswered");
            bFunctionTime = true;
            iFunctionTime = 7;
        }
        private static void PeggsAnswered(iFruitContact contact)
        {
            Main.LogThis("PeggsAnswered");
            bFunctionTime = true;
            iFunctionTime = 6;
        }
        */
 
        private static void NSPMCoinAccount()
        {
            Main.LogThis("NSPMCoinAccount");

            if (!DataStore.MenuOpen && !DataStore.OnTheJob)
            {
                var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[15], DataStore.MyLang.ContactLang[15] + DataStore.MyLang.ContactLang[24]);
                menuPoolX.Add(mainMenu);
                NSPMCurrentAcc(mainMenu);
                NSPMLowRiskAcc(mainMenu);
                NSPMHighRiskAcc(mainMenu);
                menuPoolX.RefreshIndex();
                bMenuOpen = true;
                mainMenu.Visible = !mainMenu.Visible;
            }
            else
                UI.Notify("App Currently Not Avalable ");
        }
        private static void NSPMCurrentAcc(UIMenu XMen)
        {
            Main.LogThis("NSPMCurrentAcc");
            var CurrentAccmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[25] + DataStore.MyLang.ContactLang[24]);

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
                    menuPoolX.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.BankTransfer = true;
                    DataStore.iCoinBats = 1;
                    menuPoolX.CloseAllMenus();
                }
                else
                    menuPoolX.CloseAllMenus();
            };
        }
        private static void NSPMLowRiskAcc(UIMenu XMen)
        {
            Main.LogThis("NSPMLowRiskAcc");
            var LowAccmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[70]);

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
                    menuPoolX.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.BankTransfer = true;
                    DataStore.iCoinBats = 2;
                    menuPoolX.CloseAllMenus();
                }
                else
                    menuPoolX.CloseAllMenus();
            };
        }
        private static void NSPMHighRiskAcc(UIMenu XMen)
        {
            Main.LogThis("NSPMHighRiskAcc");
            var HighAccmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[71]);

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
                    menuPoolX.CloseAllMenus();
                }
                else if (item == item_02)
                {
                    DataStore.BankTransfer = true;
                    DataStore.iCoinBats = 3;
                    menuPoolX.CloseAllMenus();
                }
                else
                    menuPoolX.CloseAllMenus();
            };
        }
        private static void ImportsMenu()
        {
            Main.LogThis("ImportsMenu");

            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[19], DataStore.MyLang.ContactLang[30]);
            menuPoolX.Add(mainMenu);
            ImportExList(mainMenu);
            menuPoolX.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void ImportExList(UIMenu XMen)
        {
            var Submenu_01 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[31]);
            var Submenu_02 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[32]);
            var Submenu_03 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[36]);
            var Submenu_04 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[34]);
            var Submenu_05 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[33]);
            var Submenu_06 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[39]);
            var Submenu_07 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[37]);
            var Submenu_08 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[39]);
            var Submenu_09 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[35]);
            var Submenu_10 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[76]);
            var Submenu_11 = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[77]);

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
            List<string> sub_11 = new List<string>();


            for (int i = 0; i < DataStore.MyContacts.ImpXCars.Count; i++)
            {
                if (DataStore.MyContacts.ImpXCars[i].VehList == 1)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_01.AddItem(item_);
                    sub_01.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                     //Super
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 2)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_02.AddItem(item_);
                    sub_02.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Sports
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 3)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_03.AddItem(item_);
                    sub_03.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Coupe
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 4)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_04.AddItem(item_);
                    sub_04.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Muscle
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 5)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_05.AddItem(item_);
                    sub_05.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //SportsClassic
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 6)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_06.AddItem(item_);
                    sub_06.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Sedan
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 7)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_07.AddItem(item_);
                    sub_07.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //SUV
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 8)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_08.AddItem(item_);
                    sub_08.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Compact
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 9)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_09.AddItem(item_);
                    sub_09.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //OffRoad
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 10)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_10.AddItem(item_);
                    sub_10.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Benny
                else if (DataStore.MyContacts.ImpXCars[i].VehList == 11)
                {
                    var item_ = new UIMenuItem(ReturnStuff.GetEntName(DataStore.MyContacts.ImpXCars[i].VehicleS), "");
                    Submenu_11.AddItem(item_);
                    sub_11.Add(DataStore.MyContacts.ImpXCars[i].VehicleS);
                }                //Motorbike
            }

            Submenu_01.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_01[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_02.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_02[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_03.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_03[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_04.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_04[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_05.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_05[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_06.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_06[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_07.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_07[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_08.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_08[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_09.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_09[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_10.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_10[index];
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
            Submenu_11.OnItemSelect += (sender, item, index) =>
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    sLastVeh = sub_11[index]; 
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Import", false, true, ReturnStuff.FunPlates());
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void MkWepsOpt(UIMenu XMen)
        {
            Main.LogThis("MkWepsOpt");

            var Rand_01 = new UIMenuItem(DataStore.MyLang.ContactLang[45], "");
            var Rand_02 = new UIMenuItem(DataStore.MyLang.ContactLang[46], "");

            XMen.AddItem(Rand_01);
            XMen.AddItem(Rand_02);

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    SearchFor.ExtCarz = null;
                    iFubCarzz = 0;
                    iService = 3;
                    sLastVeh = "BOXVILLE5";
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Mk2 Weapons");
                    Vmod.VehTag = "Fubs=";
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, true);
                    menuPoolX.CloseAllMenus();
                    bIFrutiyAdd = true;
                }
                else if (item == Rand_02)
                {
                    AddMissWeaps(DataStore.MyContacts.MyMk2Weaps, bWeapSwap);
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void WeaponsMenu()
        {
            Main.LogThis("WeaponsMenu");

            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[43], DataStore.MyLang.ContactLang[44]);
            menuPoolX.Add(mainMenu);
            Mk2WeapsList(mainMenu);
            menuPoolX.RefreshIndex();
            bMenuOpen = true;
            bWepMenuX = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void Mk2WeapsList(UIMenu XMen)
        {
            Main.LogThis("Mk2WeapsList");

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
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void AmmoAtachLiveList(UIMenu XMen, int iWeap, string sWeapName, string sWeapHash, int iPrice)
        {
            Main.LogThis("AmmoAtachLiveList, iWeap == " + iWeap + ", sWeapName == " + sWeapName + ", sWeapHash == " + sWeapHash + ", iPrice == " + iPrice);

            var Midmenu = menuPoolX.AddSubMenu(XMen, sWeapName, DataStore.MyLang.ContactLang[15] + iPrice);

            Mk2CompListAmmo(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2CompListAttach(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2CompListLivery(Midmenu, iWeap, sWeapName, sWeapHash);
            Mk2AddAmmo(Midmenu, sWeapHash, sWeapName);
        }
        private static void Mk2CompListAmmo(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            Main.LogThis("Mk2CompListAmmo, iWeap == " + iWeap + ", sWeap == " + sWeap + ", sWeapHash == " + sWeapHash);

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

            var Lastmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[72]);

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
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void Mk2CompListAttach(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            Main.LogThis("Mk2CompListAttach");

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

            var Lastmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[73]);

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
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void Mk2CompListLivery(UIMenu XMen, int iWeap, string sWeap, string sWeapHash)
        {
            Main.LogThis("Mk2CompListLivery");

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

            var Lastmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[74]);

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
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void Mk2Addons(string sWeaps, string sAddon, int iCost, bool bAdd)
        {
            Main.LogThis("Mk2Addons");

            if (bAdd)
            {
                Ped Peddy = Game.Player.Character;
                Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeaps), Function.Call<int>(Hash.GET_HASH_KEY, sAddon));
                iCost *= -1;
                NSBanking.YourCoinPopUp(iCost, 1, DataStore.MyLang.ContactLang[43]);
            }
            else
            {
                Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sWeaps), Function.Call<int>(Hash.GET_HASH_KEY, sAddon));
            }
            MyWeaponList(sWeaps, sAddon, 0, bAdd);
        }
        private static void GiveMk2Weap(Ped Peddy, string sWeap, int iPrice, bool bAddToList)
        {
            Main.LogThis("GiveMk2Weap");

            if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false))
            {
                iPrice *= -1;
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), 9999, false, true);
                NSBanking.YourCoinPopUp(iPrice, 1, DataStore.MyLang.ContactLang[43]);
            }
            else
                Function.Call(Hash.SET_CURRENT_PED_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), true);


            if (bAddToList)
                MyWeaponList(sWeap, "", 0, true);
        }
        private static void Mk2AddAmmo(UIMenu XMen, string sWeap, string WeapName)
        {
            Main.LogThis("Mk2AddAmmo");

            var Ammosmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[47]);

            int iAmmo = ReturnStuff.MaxAmmo(sWeap, Game.Player.Character);

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
                    menuPoolX.CloseAllMenus();
                }
            };
        }
        private static void FillMyAmmo(string sWeap, int iAmmo)
        {
            Function.Call<bool>(Hash.SET_AMMO_IN_CLIP, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_MAX_AMMO_IN_CLIP, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false));
            Function.Call(Hash.SET_PED_AMMO, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), iAmmo);
        }
        private static void MyWeaponList(string sWeapon, string sAddon, int iAmmo, bool bAdd)
        {
            bool bGotthis = false;
            int iPlayer = MyChar();
            if (sAddon == "")
            {
                for (int i = 0; i < DataStore.MyContacts.MyMk2Weaps.Count; i++)
                {
                    if (DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS == sWeapon && DataStore.MyContacts.MyMk2Weaps[i].MyPlayer == iPlayer)
                    {
                        DataStore.MyContacts.MyMk2Weaps[i].MyAmmos = iAmmo;
                        bGotthis = true;
                        break;
                    }
                }

                if (!bGotthis)
                {
                    Mk2Weap ThisWeap = new Mk2Weap
                    {
                        Mk2WeapS = sWeapon,
                        MyPlayer = iPlayer,
                        MyAmmos = iAmmo
                    };
                    DataStore.MyContacts.MyMk2Weaps.Add(ThisWeap);
                }
            }
            else
            {
                int iAm = -1;
                for (int i = 0; i < DataStore.MyContacts.MyMk2Weaps.Count; i++)
                {
                    if (DataStore.MyContacts.MyMk2Weaps[i].Mk2WeapS == sWeapon && DataStore.MyContacts.MyMk2Weaps[i].MyPlayer == iPlayer)
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
                    for (int i = 0; i < DataStore.MyContacts.MyMk2Weaps[iAm].Mk2Addon.Count; i++)
                    {
                        if (DataStore.MyContacts.MyMk2Weaps[iAm].Mk2Addon[i] == sAddon)
                        {
                            if (bAdd)
                                bGotthis = true;
                            else
                                DataStore.MyContacts.MyMk2Weaps[iAm].Mk2Addon.RemoveAt(i);
                        }
                    }
                    if (!bGotthis)
                        DataStore.MyContacts.MyMk2Weaps[iAm].Mk2Addon.Add(sAddon);
                }
            }
        }
        private static int MyChar()
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
        private static void PeggsMenu()
        {
            Main.LogThis("PeggsMenu");

            var mainMenu = new UIMenu(DataStore.MyLang.ContactLang[48], DataStore.MyLang.ContactLang[49]);
            menuPoolX.Add(mainMenu);
            PeggesTopMenu(mainMenu);
            menuPoolX.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private static void PeggesTopMenu(UIMenu XMen)
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
            if (DataStore.MyCustomVeh.CustomCars.Count > 0)
                PeggsCustomList(XMen);
        }
        private static void PeggsSafeHeliList(UIMenu XMen)
        {
            var SafeHelimenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[50]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsArmdHeliList(UIMenu XMen)
        {
            var ArmHelimenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[51]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsSafeAirCraftList(UIMenu XMen)
        {
            var SafePlanemenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[52]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsArmAirCraftList(UIMenu XMen)
        {
            var ArmPlanemenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[53]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsBoatsList(UIMenu XMen)
        {
            var Boatsmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[54]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsImpExpList(UIMenu XMen)
        {
            var ImpExmenu = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[55]);

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
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            };
        }
        private static void PeggsCustomList(UIMenu XMen)
        {
            bool Super = false; 
            bool Sports = false;
            bool Coupe = false;
            bool Muscle = false;
            bool SportsClassics = false;
            bool Sedan = false;
            bool SUV = false;
            bool Compact = false;
            bool Offroad = false;
            bool MotorBike = false;
            bool Bus = false;
            bool Industrial = false;
            bool Trucks = false;
            bool Comercial = false;
            bool Armored_Vehicles = false;
            bool Weaponised_Vehicles = false;
            bool FormulaOne = false;
            bool GoCart = false;
            bool Cycles = false;
            bool Boats = false;
            bool JetSki = false;
            bool Helicopters = false;
            bool FighterHelicopters = false;
            bool Planes = false;
            bool FighterPlanes = false;
            bool TowingVehicles = false;
            bool Submarine = false;

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 1)
                    Super = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 2)
                    Sports = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 3)
                    Coupe = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 4)
                    Muscle = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 5)
                    SportsClassics = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 6)
                    Sedan = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 7)
                    SUV = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 8)
                    Compact = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 9)
                    Offroad = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 10)
                    MotorBike = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 12)
                    Bus = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 13)
                    Industrial = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 14)
                    Trucks = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 15)
                    Comercial = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 16)
                    Armored_Vehicles = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 17)
                    Weaponised_Vehicles = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 19)
                    FormulaOne = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 20)
                    GoCart = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 21)
                    Cycles = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 26)
                    Boats = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 30)
                    JetSki = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 24)
                    Helicopters = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 25)
                    FighterHelicopters = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 22)
                    Planes = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 23)
                    FighterPlanes = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 28)
                    TowingVehicles = true;
                else if (DataStore.MyCustomVeh.CustomCars[i].VehList == 29)
                    Submarine = true;
            }
            var SubHeadder = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[40]);
            if (Super)
                SuperCus(SubHeadder);
            if (Sports)
                SportsCus(SubHeadder);
            if (Coupe)
                CoupeCus(SubHeadder);
            if (Muscle)
                MuscleCus(SubHeadder);
            if (SportsClassics)
                SClassicCus(SubHeadder);
            if (Sedan)
                SedanCus(SubHeadder);
            if (SUV)
                SuvCus(SubHeadder);
            if (Compact)
                CompCus(SubHeadder);
            if (Offroad)
                OffRCus(SubHeadder);
            if (MotorBike)
                MCRCus(SubHeadder);
            if (Bus)
                BusCus(SubHeadder);
            if (Industrial)
                IndusCus(SubHeadder);
            if (Trucks)
                TrucksCus(SubHeadder);
            if (Comercial)
                 ComerCus(SubHeadder);
            if (Armored_Vehicles)
                ArmCus(SubHeadder);
            if (Weaponised_Vehicles)
                WeaponiseCus(SubHeadder);
            if (FormulaOne)
                F1Cus(SubHeadder);
            if (GoCart)
                CartCus(SubHeadder);
            if (Cycles)
                CycleCus(SubHeadder);
            if (Boats)
                BoatsCus(SubHeadder);
            if (JetSki)
                JetSCus(SubHeadder);
            if (Helicopters)
                CivHelliCus(SubHeadder);
            if (FighterHelicopters)
                MillHelliCus(SubHeadder);
            if (Planes)
                CivPlaneCus(SubHeadder);
            if (FighterPlanes)
                MillPlaneCus(SubHeadder);
            if (TowingVehicles)
                TowVehCus(SubHeadder);
            if (Submarine)
                SubmarCus(SubHeadder);
        }
        private static void SuperCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[31]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 1)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void SportsCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[32]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 2)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CoupeCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[36]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 3)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void MuscleCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[34]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 4)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void SClassicCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[33]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 5)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void SedanCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[39]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 6)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void SuvCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[37]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 7)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CompCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[38]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 8)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void OffRCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[35]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 9)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void MCRCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[77]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 10)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void BusCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[78]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 12)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void IndusCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[79]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 13)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void TrucksCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[80]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 14)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void ComerCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[81]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 15)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void ArmCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[82]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 16)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void WeaponiseCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[83]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 17)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void F1Cus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[85]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 19)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CartCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[86]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 20)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CycleCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[87]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 21)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void BoatsCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[95]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 26)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void JetSCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[92]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 30)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CivHelliCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[50]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 24)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void MillHelliCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[51]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 25)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void CivPlaneCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[52]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 22)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void MillPlaneCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[53]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 23)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void TowVehCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[90]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 28)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void SubmarCus(UIMenu XMen)
        {
            var SubVehic = menuPoolX.AddSubMenu(XMen, DataStore.MyLang.ContactLang[91]);

            for (int i = 0; i < DataStore.MyCustomVeh.CustomCars.Count; i++)
            {
                if (DataStore.MyCustomVeh.CustomCars[i].VehList == 29)
                    SubVehic.AddItem(new UIMenuItem(DataStore.MyCustomVeh.CustomCars[i].VehicleS, ""));
            }

            SubVehic.OnItemSelect += (sender, item, index) =>
            {
                AddPeggs(item.Text, 1);
            };
        }
        private static void AddPeggs(string Veh, int iType)
        {
            if (iType == 1)
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, new VehMods(Veh, 2, 28, false, "Pegisus", false, true, ReturnStuff.FunPlates()), false, true);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[19]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
            }
            else if (iType == 2)
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    if (Game.Player.Character.IsInWater)
                    {
                        Vector3 vAirstrip = Game.Player.Character.Position + (Game.Player.Character.ForwardVector) * 5;
                        float fPlaneHead = Game.Player.Character.Heading;

                        iService = 5;
                        EntityBuild.VehicleSpawn(new VehMods(Veh, 2, 28, false, "Pegisus", false, true, ReturnStuff.FunPlates()), vAirstrip, fPlaneHead);
                        NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                        bIFrutiyAdd = true;
                    }
                    else
                    {
                        UI.Notify(DataStore.MyLang.ContactLang[59]);
                    }
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
                menuPoolX.CloseAllMenus();
            }
            else if (iType == 3)
            {
                if (DataStore.MyDatSet.iNSPMBank > 200)
                {
                    iService = 4;
                    SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, new VehMods(Veh, 2, 28, false, "Pegisus", false, true, ReturnStuff.FunPlates()), false, true);
                    NSBanking.YourCoinPopUp(-200, 1, DataStore.MyLang.ContactLang[48]);
                    bIFrutiyAdd = true;
                }
                else
                    UI.Notify(DataStore.MyLang.ContactLang[41]);
            }
            else
            {
                PeggAirports(Veh);
            }
            menuPoolX.CloseAllMenus();
        }
        private static void PeggDrop(int iList, int iDrop)
        {
            Main.LogThis("PeggDrop");

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
                VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Pegisus", false, true, ReturnStuff.FunPlates());
                Vmod.VehTag = "Fubs=";
                SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false, true);
                bIFrutiyAdd = true;
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
                VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Pegisus", false, true, ReturnStuff.FunPlates());
                Vmod.VehTag = "Fubs=";
                SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false, true);
                bIFrutiyAdd = true;
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
                    VehMods Vmod = new VehMods(sLastVeh, 2, 5, false, "Pegisus");
                    Vmod.VehTag = "Fubs=";
                    EntityBuild.VehicleSpawn(Vmod, vAirstrip, fPlaneHead);
                    bIFrutiyAdd = true;
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
                VehMods Vmod = new VehMods(sVehicles[iDrop], 2, 5, false, "Pegisus", false, true, ReturnStuff.FunPlates());
                Vmod.VehTag = "Fubs=";
                SearchFor.ExtCarz = new FindVeh(0.01f, 120.00f, Game.Player.Character.Position, Vmod, false, true);
                bIFrutiyAdd = true;
            }          
        }
        private static void PeggAirports(string sAircraft)
        {
            Main.LogThis("PeggAirports");

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
            VehMods YourCraft = new VehMods(sAircraft, 2, 5, false, "Pegisus", false, true, ReturnStuff.FunPlates());
            YourCraft.VehTag = "Fubs=";
            Vehicle MeEnter = EntityBuild.VehicleSpawn(YourCraft, vAirStips[iAir], fAir[iAir]);
            EntityBuild.WarptoAnyVeh(MeEnter, Game.Player.Character, 1);
            bIFrutiyAdd = true;
        }
        public static void ContactLoadUp()
        {
            Main.LogThis("OnLoadUp");

            Fruits(0);
            Fruits(3);
            Fruits(7);
            AddMissingCont();
            AddMissWeaps(DataStore.MyContacts.MyMk2Weaps, bWeapSwap);
        }
    }
}