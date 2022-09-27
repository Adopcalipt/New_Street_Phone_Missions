using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace New_Street_Phone_Missions
{
    public class DataStore 
    {
        public static bool bLookingForPB { get; set; }
        public static bool bSubscribeNag { get; set; }
        public static bool bOnlineStuffLoaded { get; set; }
        public static bool bTrainM { get; set; }
        public static bool bMenuOpen { get; set; }
        public static bool bOnCayoLand { get; set; }
        public static bool bOptionsMen { get; set; }
        public static bool bBankTransfer { get; set; }
        public static bool bBuildMode { get; set; }
        public static bool bNotPause { get; set; }

        public static readonly int iProcessForYacht = System.Environment.ProcessorCount* 15;
        public static readonly int iProcessForPegs = System.Environment.ProcessorCount* 17;
        public static readonly int iPegsSafeHeli = System.Environment.ProcessorCount* 7;
        public static readonly int iPegsWarHeli = System.Environment.ProcessorCount* 4;
        public static readonly int iPegsSafePlane = System.Environment.ProcessorCount* 13;
        public static readonly int iPegsWarPlane = System.Environment.ProcessorCount* 9;
        public static readonly int iPegsboats = System.Environment.ProcessorCount* 3;
        public static readonly int iPegsimortas = System.Environment.ProcessorCount* 11;
        public static readonly int iMeddicc = System.Environment.ProcessorCount* 18;

        public static byte iCoinBats { get; set; }
        public static byte iLookForPB { get; set; }
        public static byte iBuildingUp { get; set; }
        public static byte iFolPos { get; set; }

        public static int iSoundId { get; set; }
        public static int iPlayerGroup { get; set; }
        public static int GP_Player { get; set; }
        public static readonly int GP_ANPCs = World.AddRelationshipGroup("GroupA");
        public static readonly int GP_BNPCs = World.AddRelationshipGroup("GroupB");
        public static readonly int GP_Attack = World.AddRelationshipGroup("AttackNPCs");
        public static readonly int GP_Mental = World.AddRelationshipGroup("MentalNPCs");

        public static readonly string sVersion = "3.81";
        public static readonly string sDefaulted = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/DefaultOut.Xml";
        public static readonly string sNSPMSet = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings.Xml";
        public static readonly string sNEW_SPM_XML = "" + Directory.GetCurrentDirectory() + "/Scripts/NEW_SPM_XML.Xml";
        public static readonly string sOLD_SPM_XML = "" + Directory.GetCurrentDirectory() + "/Scripts/OLD_SPM_XML.Xml";
        public static readonly string sNSPMLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language";
        public static readonly string sNSPMAddonCarz = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMAddonCarz.Xml";
        public static readonly string sNSPMCont = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMContact.Xml";
        public static readonly string sNSPMYacht = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM_Yacht.dll";
        public static readonly string sNSPMRandNum = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Rando.Xml";

        public static Vector3 vPhoneCorona { get; set; }

        public static Vehicle SharedVeh { get; set; }

        public static XmlSetings MySettings { get; set; }
        public static CustomVeh MyCusVeh { get; set; }
        public static Lingoo MyLang { get; set; }
        public static ClothBankXML MaleCloth { get; set; }
        public static ClothBankXML FemaleCloth { get; set; }

        public static DatFile MyDatSet { get; set; }

        public static PlayerAssets MyAssets { get; set; }

        public static List<string> LangXLists = new List<string>
        {
            "LangReader",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/English.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Chinese.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/ChineseS.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/French.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/German.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Italian.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Japanese.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Korean.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Spanish.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Polish.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Portuguese.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Russian.Xml",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Spanish.Xml"
        };

        public static List<Vector3> vOldPhoneBoxList { get; set; }

        public static List<MyMk2Weaps> Mk2WeapsMain { get; set; }
        public static List<PlayerWeaps> PlayerWeapXList { get; set; }

        public static System.Media.SoundPlayer Hare { get; set; }
        public static System.Media.SoundPlayer Chatter { get; set; }
        public static System.Media.SoundPlayer Drilar { get; set; }
        public static System.Media.SoundPlayer CashTil { get; set; }
        public static System.Media.SoundPlayer LiftDoor { get; set; }

        public static bool bHasLoaded { get; set; }

        public static void DataStoreLoad()
        {
            ObjectLog.ClearThis();
            DelOldLog();

            bOptionsMen = false;
            bLookingForPB = false;
            bSubscribeNag = false;
            bOnlineStuffLoaded = false;
            bTrainM = false;
            bOnCayoLand = false;
            bMenuOpen = false;
            bBankTransfer = false;
            bBuildMode = false;
            bNotPause = false;

            iCoinBats = 0;
            iLookForPB = 0;
            iBuildingUp = 0;
            iFolPos = 0;
            iSoundId = 0;

            iPlayerGroup = 0;
            GP_Player = Game.Player.Character.RelationshipGroup;

            vPhoneCorona = Vector3.Zero;
            SharedVeh = null;

            MySettings = XmlSetReturn();
            MyLang = LingoReturns();
            MyDatSet = NSBanking.LoadDat();
            MyAssets = SetMyAss();
            MyCusVeh = FindCustomCarz();

            Hare = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Hare_Krishna_Chant.wav");
            Chatter = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/PhoneTalk.wav");
            Drilar = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/edrill.wav");
            CashTil = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Till.wav");
            LiftDoor = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/LiftDoor.wav");

            Hare.Load();
            Chatter.Load();
            Drilar.Load();
            CashTil.Load();
            LiftDoor.Load();

            vOldPhoneBoxList = PhoneOff();

            MaleCloth = new ClothBankXML();
            FemaleCloth = new ClothBankXML();

            Mk2WeapsMain = new List<MyMk2Weaps>();
            PlayerWeapXList = new List<PlayerWeaps>();

            OnLoadup();
            MissionData.MissionDataLoad();
            NSBanking.SaveDat(-1, 0);
            bHasLoaded = true;
        }
        private static void DelOldLog()
        {
            string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/BeeLog.txt";
            try
            {
                if (File.Exists(sBeeLogs))
                    File.Delete(sBeeLogs);
                LoggerLight.LogThis("DelOldLog");
            }
            catch
            {
                LoggerLight.LogThis("DelOldLog failed");
            }
        }
        private static void OnLoadup()
        {
            LoggerLight.LogThis("OnLoadup " + sVersion);

            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, false);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, GP_Player, GP_ANPCs);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, GP_ANPCs, GP_Player);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Attack, GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Player, GP_Attack);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Player, GP_Mental);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Mental, GP_Player);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_BNPCs, GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Player, GP_BNPCs);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_Mental, GP_Mental);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_ANPCs, GP_BNPCs);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, GP_BNPCs, GP_ANPCs);

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/Menyoo.asi") && MySettings.PreLoadOnline)
                MySettings.MenyooAppFixer = true;
            else
                MySettings.MenyooAppFixer = false;

            if (MySettings.YachtPrice < 0)
                MySettings.YachtPrice = 0;

            if (MySettings.PreLoadOnline)
                LoadOnlineIps(true);

            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
            UI.Notify("New Street Phone Missions " + sVersion + " by ~b~Adopocalipt ~w~Loaded.");

            bLookingForPB = true;

            DressinRoom.UpdateOldXMLs();

            bHasLoaded = true;
        }
        private static Lingoo LingoReturns()
        {
            LoggerLight.LogThis(LangXLists[0]);

            Lingoo ThisLang = new Lingoo();

            if (MySettings.LangSupport < 1)
            {
                if (Directory.Exists(sNSPMLanguage))
                {
                    if (Game.Language == Language.American)
                    {
                        if (File.Exists(LangXLists[1]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[1]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 1;
                        }
                    }
                    else if (Game.Language == Language.Chinese)
                    {
                        if (File.Exists(LangXLists[2]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[2]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 2;
                        }
                    }
                    else if (Game.Language == Language.ChineseSimplified)
                    {
                        if (File.Exists(LangXLists[3]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[3]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 3;
                        }
                    }
                    else if (Game.Language == Language.French)
                    {
                        if (File.Exists(LangXLists[4]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[4]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 4;
                        }
                    }
                    else if (Game.Language == Language.German)
                    {
                        if (File.Exists(LangXLists[5]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[5]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 5;
                        }
                    }
                    else if (Game.Language == Language.Italian)
                    {
                        if (File.Exists(LangXLists[6]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[6]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 6;
                        }
                    }
                    else if (Game.Language == Language.Japanese)
                    {
                        if (File.Exists(LangXLists[7]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[7]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 7;
                        }
                    }
                    else if (Game.Language == Language.Korean)
                    {
                        if (File.Exists(LangXLists[8]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[8]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 8;
                        }
                    }
                    else if (Game.Language == Language.Mexican)
                    {
                        if (File.Exists(LangXLists[9]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[9]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 9;
                        }
                    }
                    else if (Game.Language == Language.Polish)
                    {
                        if (File.Exists(LangXLists[10]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[10]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 10;
                        }
                    }
                    else if (Game.Language == Language.Portuguese)
                    {
                        if (File.Exists(LangXLists[11]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[11]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 11;
                        }
                    }
                    else if (Game.Language == Language.Russian)
                    {
                        if (File.Exists(LangXLists[12]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[12]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 12;
                        }
                    }
                    else if (Game.Language == Language.Spanish)
                    {
                        if (File.Exists(LangXLists[13]))
                        {
                            ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[13]);
                            if (ThisLang != null)
                                MySettings.LangSupport = 13;
                        }
                    }
                }
            }
            else
            {
                if (Directory.Exists(sNSPMLanguage))
                {
                    if (File.Exists(LangXLists[MySettings.LangSupport]))
                    {
                        ThisLang = ReadWriteXML.LoadXmlLing(LangXLists[MySettings.LangSupport]);
                    }
                }
            }

            if (ThisLang.Jobtext.Count() < 10)
                ThisLang = LangRewite();

            return ThisLang;
        }
        private static Lingoo LangRewite()
        {
            LoggerLight.LogThis("LangRewite");

            Lingoo ThisLang = new Lingoo();

            List<string> sContext = new List<string>();
            List<string> sJobtext = new List<string>();
            List<string> sMaptext = new List<string>();
            List<string> sMistext = new List<string>();
            List<string> sOthertext = new List<string>();
            List<string> sYachtLang = new List<string>();
            List<string> sContactLang = new List<string>();

            sMaptext.Clear();
            sMaptext.Add("Boat Delivery");                          //0
            sMaptext.Add("Delivery Truck");                         //1
            sMaptext.Add("Delivery Trailer");                       //2
            sMaptext.Add("Delivery Vehicle");                       //3
            sMaptext.Add("Prison Bus");                             //4
            sMaptext.Add("Helicopter");                             //5
            sMaptext.Add("Plane");                                  //6
            sMaptext.Add("Ambulance");                              //7
            sMaptext.Add("Fire Truck");                             //8
            sMaptext.Add("Player Vehicle");                         //9
            sMaptext.Add("Tug");                                    //10
            sMaptext.Add("Slam Van");                               //11
            sMaptext.Add("Fork Lift");                              //12
            sMaptext.Add("Submarine");                               //13
            sMaptext.Add("Target Vehicle");                         //14
            sMaptext.Add("Customers Vehicle");                      //15
            sMaptext.Add("Fubar");                                  //16
            sMaptext.Add("Boat");                                   //17
            sMaptext.Add("Blazer Aqua");                            //18
            sMaptext.Add("Stromberg");                              //19
            sMaptext.Add("Enemy");                                  //20
            sMaptext.Add("Vehicle Drop");                           //21
            sMaptext.Add("Builder Vehicle");                        //22
            sMaptext.Add("Pickup");                                 //23
            sMaptext.Add("Angry Taxi");                             //24
            sMaptext.Add("Party Bus");                              //25
            sMaptext.Add("Search Area");                            //26
            sMaptext.Add("Race Meet");                            	//27
            sMaptext.Add("Cocaine Lockup");                         //28
            sMaptext.Add("Counterfeit Cash Factory");            	//29
            sMaptext.Add("Document Forgery Office");             	//30
            sMaptext.Add("Weed Farm");            	                //31
            sMaptext.Add("Meth Lab");                            	//32
            sMaptext.Add("Bunker");                            		//33
            sMaptext.Add("Warehouse");                            	//34
            sMaptext.Add("Bolingbroke Penitentiary");              	//35
            sMaptext.Add("Checkpoint");                            	//36
            sMaptext.Add("Patient");                            	//37
            sMaptext.Add("Export Barge");                           //38
            sMaptext.Add("Delivery Target");                     	//39
            sMaptext.Add("Bank");                            		//40
            sMaptext.Add("Escape Point");                        	//41
            sMaptext.Add("Destination");                           	//42
            sMaptext.Add("Depot");                            		//43
            sMaptext.Add("Convict Parade");                     	//44
            sMaptext.Add("Fubar Customer");                        	//45
            sMaptext.Add("Fubar Destination");                   	//46
            sMaptext.Add("Roof Ladder");                            //47
            sMaptext.Add("CEO");                            		//48
            sMaptext.Add("Office");                            		//49
            sMaptext.Add("Sandy Shores Airfield");                 	//50
            sMaptext.Add("Grapeseed Airfield");                   	//51
            sMaptext.Add("Noose HQ");         		             	//52
            sMaptext.Add("Beauty Spot");                            //53
            sMaptext.Add("Jetsam Office");                          //54
            sMaptext.Add("Cat Owner");                            	//55
            sMaptext.Add("Escape Area");                            //56
            sMaptext.Add("Police Station");                      	//57
            sMaptext.Add("Business");                            	//58
            sMaptext.Add("Security  Depot");                        //59
            sMaptext.Add("Dock");                            		//60
            sMaptext.Add("Boat Yard");                            	//61
            sMaptext.Add("Apartment");                            	//62
            sMaptext.Add("Payment Case");                       	//63
            sMaptext.Add("Exit");                            		//64
            sMaptext.Add("Club House");                             //65
            sMaptext.Add("Van Keys");                            	//66
            sMaptext.Add("Bomb Shop");                            	//67
            sMaptext.Add("Targets Parking Spot");               	//68
            sMaptext.Add("Shops Takings");                          //69
            sMaptext.Add("Bar");                                    //70
            sMaptext.Add("Service Area");                           //71
            sMaptext.Add("Dance Floor");                            //72
            sMaptext.Add("Night Club");                             //73
            sMaptext.Add("Till");                                   //74
            sMaptext.Add("Customer");                               //75
            sMaptext.Add("Dump");                               	//76
            sMaptext.Add("Dozer");                               	//77
            sMaptext.Add("Pirates");                               	//78
            sMaptext.Add("Hangar");                               	//79
            sMaptext.Add("Casino");                               	//80
            sMaptext.Add("Uniform");                               	//81
            sMaptext.Add("Weapons");                               	//82
            sMaptext.Add("Lift");                               	//83
            sMaptext.Add("Valet Stand");                          	//84
            sMaptext.Add("Parking Garage");                       	//85
            sMaptext.Add("Facility");                               //86
            sMaptext.Add("Secret Underground Layer");             	//87
            sMaptext.Add("LS Car Meet");                          	//88
            sMaptext.Add("Toolbox");                               	//89
            sMaptext.Add("Wrench");                               	//90
            sMaptext.Add("Bag");                               		//91
            sMaptext.Add("Crate");                               	//92
            sMaptext.Add("Suitcase");                               //93
            sMaptext.Add("Toxic Soup");                           	//94
            sMaptext.Add("Foreman");                               	//95
            sMaptext.Add("Technician");                            	//96
            sMaptext.Add("Scientist");                           	//97
            sMaptext.Add("Empty Barrel");                         	//98
            sMaptext.Add("Glowing Sludge");                       	//99
            sMaptext.Add("Bio Haz Barrel");                       	//100
            sMaptext.Add("Remote Controller");                 		//101
            sMaptext.Add("Test tubes");                          	//102
            sMaptext.Add("Smoke Machine");                        	//103
            sMaptext.Add("Tourist");                               	//104
            sMaptext.Add("Target");                               	//105
            sMaptext.Add("Bikers");                               	//106
            sMaptext.Add("Cat");                             		//107
            sMaptext.Add("Convict");                               	//108
            sMaptext.Add("Raceist");                               	//109
            sMaptext.Add("Exporter");                               //110
            sMaptext.Add("Pirate");                               	//111
            sMaptext.Add("Worker");                               	//112
            sMaptext.Add("Player");                               	//113
            sMaptext.Add("Shark");                               	//114
            sMaptext.Add("Bogdan");                               	//115
            sMaptext.Add("Fire");                               	//116
            sMaptext.Add("Race");                               	//117
            sMaptext.Add("Sea Sparrow");                           	//118
            sMaptext.Add("Jetmax");                               	//119
            sMaptext.Add("Technical Aqua");                      	//120
            sMaptext.Add("Deliverwho");                           	//121
            sMaptext.Add("Drop Zone");                           	//122
            sMaptext.Add("");                               //123
            sMaptext.Add("");                               //124
            sMaptext.Add("");                               //125
            sMaptext.Add("");                               //126
            sMaptext.Add("");                               //127
            sMaptext.Add("");                               //128
            sMaptext.Add("");                               //129
            sMaptext.Add("");                               //130

            sMistext.Clear();
            sMistext.Add("Goto the ~y~Truck~w~.");                                                                      //0
            sMistext.Add("Enter the ~b~Truck~w~.");                                                                     //1
            sMistext.Add("Attach the ~y~Trailer~w~ to the ~b~Truck~w~.");                                               //2
            sMistext.Add("Deliver the ~b~Trailer~w~ to ");                												//3
            sMistext.Add("Find a ~b~Car~w~ or ~b~Van~w~ with four or more seats.");                                     //4
            sMistext.Add("Wait outside of the ~y~Bank~w~.");                                                            //5
            sMistext.Add("Goto the ~y~Bank~w~.");                                                                       //6
            sMistext.Add("Lose the ~r~Cops~w~.");                                                                       //7
            sMistext.Add("Deliver the ~b~Bank Robbers~w~ to their ~y~Escape Point~w~.");                                //8
            sMistext.Add("~r~Burn ~w~the~b~ Getaway Vehicle~w~.");                                                      //9
            sMistext.Add("Goto the ~y~Delivery Vehicle~w~.");                                                           //10
            sMistext.Add("Get on the ~b~Delivery Vehicle~w~.");                                                         //11
            sMistext.Add("Enter the ~b~Delivery Vehicle~w~.");                                                          //12
            sMistext.Add("Deliver the ~b~Package~w~ to the ~y~Target~w~.");                                             //13
            sMistext.Add("Return the ~b~Delivery Vehicle~w~ to the ~y~Depot~w~.");                                   	//14
            sMistext.Add("Get on the ~b~Prison Bus~w~.");                                                            	//15
            sMistext.Add("You can find the ~r~Convicts~w~ parading near ");												//16
            sMistext.Add("Deliver the ~r~Convicts~w~ to ~y~Bolingbroke Penitentiary~w~.");                              //17
            sMistext.Add("Enter the '~b~Fubar Dilettante~w~'.");                                                        //18
            sMistext.Add("There is a ~b~Customer~w~ at ");                												//19
            sMistext.Add("Press your ~b~Horn~w~. To attract their attention.");                                         //20
            sMistext.Add("Can you take me to ");                          												//21
            sMistext.Add("Can you take us to ");                          												//22
            sMistext.Add("Goto the ~y~Stunt Plane~w~'.");                                                               //23
            sMistext.Add("Enter the ~b~Stunt Plane~w~.");                                                               //24
            sMistext.Add("Fly through the ~y~Coronas~w~, bonuses for flying inverted and full bank.");                  //25
            sMistext.Add("Goto the ~b~Helicopter~w~.");                                                                 //26
            sMistext.Add("Enter the ~b~Helicopter~w~.");                                                                //27
            sMistext.Add("Goto the ~b~CEO~w~ near ");                     												//28
            sMistext.Add("Deliver the ~b~CEO~w~ to their ~y~Office~w~.");                                               //29
            sMistext.Add("Looks like this ~r~CEO~w~ is a psycho, better get out of there...");							//30
            sMistext.Add("Goto the ~b~B-11 Strikeforce~w~ at ~y~Fort Zancudo~w~.");                                     //31
            sMistext.Add("Enter the ~b~B-11 Strikeforce~w~.");                                                          //32
            sMistext.Add("Deliver the ~b~B-11 Strikeforce~w~ to '~y~Sandy Shores~w~' airfield.");                       //33
            sMistext.Add("Change of plan, avoid being ~r~Shot down~w~ while we find an alternative ~y~airfield~w~.");   //34
            sMistext.Add("Deliver the ~b~B-11 Strikeforce~w~ to '~y~Grapeseed~w~' airfield.");                          //35
            sMistext.Add("Goto the ~b~Buzzard~w~ parked on the ~y~Noose HQ~w~.");                                       //36
            sMistext.Add("Enter the ~b~Buzzard~w~.");                                                                   //37
            sMistext.Add("The ~b~CEO~w~ is in a ~r~Cargobob~w~ above the ~y~Target~w~.");                               //38
            sMistext.Add("The ~b~CEO~w~ is ~g~Above~w~ you.");                                                          //39
            sMistext.Add("The ~b~CEO~w~ is ~o~Below~w~ you.");                                                          //40
            sMistext.Add("Goto the ~b~Duster~w~ parked at ~y~Grapeseed~w~ airfield.");                                  //41
            sMistext.Add("Enter the ~b~Duster~w~.");                                                                    //42
            sMistext.Add("You are loaded up with ~r~Monsanto's~w~ finest, watch out for the ~g~environmentalists~w~."); //43
            sMistext.Add("Fly from the ~y~Yellow~w~ to the ~o~Orange~w~ target.");                                      //44
            sMistext.Add("Goto the ~b~Helicopter~w~ at the ~y~Jetsam Office~w~.");                                      //45
            sMistext.Add("Enter the ~b~Helicopter~w~.");                                                                //46
            sMistext.Add("Fly to the ~y~Beauty Spot~w~.");                                                            	//47
            sMistext.Add("Gently land in the ~y~Corona~w~.");                                                           //48
            sMistext.Add("Wait while your passengers take ~r~Selfies~w~.");                                             //49
            sMistext.Add("Return to the ~y~Jetsam Office~w~.");                                                         //50
            sMistext.Add("Goto the ~y~Prison Bus~w~.");                       											//51
            sMistext.Add("Goto the ~b~Ambulance~w~ by ");                       										//52
            sMistext.Add("Goto the ~r~Patient~w~ on ");					                                                //53
            sMistext.Add("Exit the ~b~Ambulance~w~.");                       											//54
            sMistext.Add("Goto the ~y~Patient~w~.");                       												//55
            sMistext.Add("Goto the ~y~Hospital~w~ before the time runs out.");                       					//56
            sMistext.Add("Enter the ~b~Ambulance~w~.");                       											//57
            sMistext.Add("Goto the ~y~Hospital~w~.");                       											//58
            sMistext.Add("The ~b~target~w~ was last spotted around ");       											//59
            sMistext.Add("Follow that ~b~Target Vehicle~w~. Don't get too close or too far.");							//60
            sMistext.Add("Eliminate the ~r~Targets~w~, before they can get to the police station.");					//61
            sMistext.Add("Eliminate the ~r~Targets~w~.");																//62
            sMistext.Add("Take the ~b~Targets Vehicle~w~.");															//63
            sMistext.Add("Deliver the ~b~Vehicle~w~ to the ~y~Destination~w~.");										//64
            sMistext.Add("Protect the ~b~Targets~w~.");																	//65
            sMistext.Add("Oh.. That wasn't supposed to happen...");														//66
            sMistext.Add("Goto the ~b~ Fire Engine ~w~ by ");															//67
            sMistext.Add("There is a ~b~Vehicle~w~ on fire at ");														//68
            sMistext.Add("There is a ~b~Building~w~ on fire at ");														//69
            sMistext.Add("There is a ~b~Waste Bin~w~ on fire at ");													    //70
            sMistext.Add("There is a ~b~Cat~w~ on fire at... No Sorry just a rescue cat at ");							//71
            sMistext.Add("There is a ~r~MadLad~w~ starting fires near ");												//72
            sMistext.Add("Spray the ~r~Fire~w~ with the ~b~Fire Engines~w~ hose.");										//73
            sMistext.Add("The ~r~Cat~w~ is ~g~Above~w~ you.");															//74
            sMistext.Add("The ~r~Cat~w~ is ~o~Below~w~ you.");															//75
            sMistext.Add("Return to the ~b~Fire Engine~w~.");															//76
            sMistext.Add("Deliver the ~b~Cat~w~ to its owner.");														//77
            sMistext.Add("Exit the ~b~Fire Engine~w~.");																//78
            sMistext.Add("Stop that ~r~MadLad~w~.");																	//79
            sMistext.Add("The ~r~Player's Vehicle~w~ is parked on ");													//80
            sMistext.Add("Enter the ~b~Vehicle~w~.");																	//81
            sMistext.Add("Deliver the ~b~Vehicle~w~ to ");																//82
            sMistext.Add("Exit the ~b~Vehicle~w~ and leave the ~o~Area~w~ before the ~r~Player~w~ arrives.");			//83
            sMistext.Add("Enter the provided ~b~Vehicle~w~. Or use your own ~b~Vehicle~w~.");							//84
            sMistext.Add("Goto the ~y~Start Line~w~.");																	//85
            sMistext.Add("Your ~b~Vehicle~w~ is in the wrong class for this race type.");								//86
            sMistext.Add("Find the '~b~Explosive Device~w~' near ");													//87
            sMistext.Add("Look for the '~b~Explosive Device~w~'.");														//88
            sMistext.Add("Deliver the '~b~Explosive Device~w~' to the nearby '~y~Police Station~w~'.");					//89
            sMistext.Add("Goto the ~y~Target Destination~w~.");															//90
            sMistext.Add("Eliminate the '~p~Marked Target~w~', silently with a '~r~Melee~w~' weapon.");					//91
            sMistext.Add("Goto the ~y~Security Depot~w~.");																//92
            sMistext.Add("Goto the ~y~Business~w~.");																	//93
            sMistext.Add("Enter the ~b~Security Truck~w~.");																//94
            sMistext.Add("Exit the ~b~Security Truck~w~.");																//95
            sMistext.Add("The ~b~Shops Takings~w~ are at the back of the store~w~.");									//96
            sMistext.Add("Return the ~b~Shops Takings~w~ to the ~y~Security Depot~w~.");									//97
            sMistext.Add("Goto the ~y~East Docks~w~.");																	//98
            sMistext.Add("Enter the ~b~Tug Boat~w~.");																	//99
            sMistext.Add("Goto the ~y~Export Barge~w~.");																//100
            sMistext.Add("Maneuverer the ~b~Tug Boat~w~ to attach the ~r~Tug Hook~w~ to the ~y~Barge~w~.");				//101
            sMistext.Add("Deliver the ~b~Barge~w~ to the ~y~Target Destination~w~.");									//102
            sMistext.Add("Protect the ~b~Car Collection~w~.");															//103
            sMistext.Add("STOP THAT ~r~CARGOBOB~w~, from stealing the cars.");											//104
            sMistext.Add("Select one of the three ~b~Vehicles~w~ to get to the ~y~Yacht~w~.");							//105
            sMistext.Add("Enter the ~b~Sea Sparrow~w~.");																//106
            sMistext.Add("Enter the ~b~Jetmax~w~.");																	//107
            sMistext.Add("Enter the ~b~Technical Aqua~w~.");															//108
            sMistext.Add("Goto the ~y~Yacht~w~.");																		//109
            sMistext.Add("Eliminate the ~r~Pirates~w~.");																//110
            sMistext.Add("Goto the ~y~White Water Activity Center~w~.");												//111
            sMistext.Add("Enter the ~b~Boat~w~.");																		//112
            sMistext.Add("Hold the boat in position while the ~b~Signal Scanner~w~ reads the signal");					//113
            sMistext.Add("Goto the ~y~Phishing Signal~w~ location.");													//114
            sMistext.Add("Deliver the ~b~Boat~w~ to the ~y~Dock~w~.");													//115
            sMistext.Add("Goto the ~b~Blazer Aqua~w~ parked in the ~y~Storm Drains~w~.");								//116
            sMistext.Add("Get on the ~b~Blazer Aqua~w~.");																//117
            sMistext.Add("Collect the ~g~Rubbish~w~.");																	//118
            sMistext.Add("Goto the '~y~Galilee Boatyard~w~'.");															//119
            sMistext.Add("Pick a ~b~Boat~w~ to deliver.");																//120
            sMistext.Add("Deliver the ~b~Boat~w~ to the ~y~Target Destination~w~.");									//121
            sMistext.Add("Goto the ~y~Stromberg~w~.");																	//122
            sMistext.Add("Goto ~y~Paleto Cove~w~.");																	//123
            sMistext.Add("Enter the ~b~Stromberg~w~.");																	//124
            sMistext.Add("Goto the ~y~Submarine~w~.");																	//125
            sMistext.Add("Goto the ~y~control room~w~.");																//126
            sMistext.Add("Interrogate the ~b~contact~w~.");																//127
            sMistext.Add("Find the contact.");																			//128
            sMistext.Add("Plug Cliffie into the ~g~console~w~.");														//129
            sMistext.Add("Kill ~r~Bogdam~w~ before he starts talking rubbish for half an hour.");						//130
            sMistext.Add("Escape from the ~b~Submarine~w~.");															//131
            sMistext.Add("Drive around till your ~r~Radar~w~ detects the ~b~Vehicle~w~ we require.");					//132
            sMistext.Add("Take that ~b~Vehicle~w~.");																	//133
            sMistext.Add("Deliver the ~b~Vehicle~w~ to the ~y~Export Barge~w~.");										//134
            sMistext.Add("Release the ~b~Vehicle~w~ over the ~y~Export Barge~w~.");										//135
            sMistext.Add("Enter the ~b~Vehicle~w~.");																	//136
            sMistext.Add("Goto the ~y~Apartment~w~.");																	//137
            sMistext.Add("Collect the ~b~Payment Case~w~.");															//138
            sMistext.Add("Deliver the ~b~Payment Case~w~ to the ~y~Bank~w~.");											//139
            sMistext.Add("Goto this rival ~y~MC Business");																//140
            sMistext.Add("Aim your ~r~Weapon~w~ at the workers to make them walk to the ~y~Exit~w~.");					//141
            sMistext.Add("Exit the ~y~MC Business~w~.");																//142
            sMistext.Add("Enter the ~b~Party Bus~w~.");																	//143
            sMistext.Add("Deliver the ~r~Workers~w~ to the ~y~Club House~w~.");											//144
            sMistext.Add("Eliminate the ~r~Bikers~w~.");																//145
            sMistext.Add("Find the ~r~Keys~w~ to the ~b~Slamvan~w~.");													//146
            sMistext.Add("Collect the ~y~Keys~w~.");																	//147
            sMistext.Add("Enter the ~b~Slamvan~w~.");																	//148
            sMistext.Add("Deliver the ~r~Slamvan~w~ to the ~y~Club House~w~.");											//149
            sMistext.Add("Goto the ");																					//150
            sMistext.Add("Enter the ~b~forklift~w~.");																	//151
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Golden Egg~w~.");									//152
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Yetti Hide~w~.");									//153
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Golden Minigun~w~.");								//154
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Film Real~w~.");										//155
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Watch~w~.");											//156
            sMistext.Add("Use the ~r~forklift~w~ to collect the ~b~Large Diamond~w~.");									//157
            sMistext.Add("Deliver the ~b~Golden Egg~w~ to the ~y~pickup truck~w~.");									//158
            sMistext.Add("Deliver the ~b~Yetti Hide~w~ to the ~y~pickup truck~w~.");									//159
            sMistext.Add("Deliver the ~b~Golden Minigun~w~ to the ~y~pickup truck~w~.");								//160
            sMistext.Add("Deliver the ~b~Film Real~w~ to the ~y~pickup truck~w~.");										//161
            sMistext.Add("Deliver the ~b~Watch~w~ to the ~y~pickup truck~w~.");											//162
            sMistext.Add("Deliver the ~b~Large Diamond~w~ to the ~y~pickup truck~w~.");									//163
            sMistext.Add("Enter the ~b~Sandking~w~.");																	//164
            sMistext.Add("Deliver the ~b~Golden Egg~w~ to the ~y~Buyer~w~.");											//165
            sMistext.Add("Deliver the ~b~Yetti Hide~w~ to the ~y~Buyer~w~.");											//166
            sMistext.Add("Deliver the ~b~Golden Minigun~w~ to the ~y~Buyer~w~.");										//167
            sMistext.Add("Deliver the ~b~Film Real~w~ to the ~y~Buyer~w~.");											//168
            sMistext.Add("Deliver the ~b~Watch~w~ to the ~y~Buyer~w~.");												//169
            sMistext.Add("Deliver the ~b~Large Diamond~w~ to the ~y~Buyer~w~.");											//170
            sMistext.Add("Enter the ~b~Submarine~w~.");																	//171
            sMistext.Add("Detonate the bait when the ~r~Sharks~w~ are feeding.");										//172
            sMistext.Add("Drop the bait bomb to attract the ~r~Sharks~w~.");											//173
            sMistext.Add("Find the missing '~y~Partier~w~'. Don't let them spot you following.");						//174
            sMistext.Add("Follow that ~b~Partier~w~ and keep out of their vision cone.");								//175
            sMistext.Add("The ~b~Thief~w~ was spotted by ~y~Main Docks~w~.");											//176
            sMistext.Add("The ~b~Thief~w~ was spotted by ~y~North Docks~w~.");											//177
            sMistext.Add("The ~b~Thief~w~ was spotted by ~y~Airstrip~w~.");											//178
            sMistext.Add("Goto this ~y~Business~w~.");																	//179
            sMistext.Add("Use this ~r~Bat~w~ to damage goods in his shop");												//180
            sMistext.Add("Goto the ~y~Targets Vehicle~w~");																//181
            sMistext.Add("Drive the ~b~Targets Vehicle~w~ to the ~y~Bomb Garage~w~");									//182
            sMistext.Add("Return the ~b~Vehicle~w~ to the ~y~Target~w~. Careful not to set off the bomb");				//183
            sMistext.Add("Hide somewhere so that the ~r~Target~w~ does not spot you.");									//184
            sMistext.Add("Goto the ~y~LS Car Meet~w~.");																//185
            sMistext.Add("Pick any ~b~Compact Vehicle~w~ to enter.");													//186
            sMistext.Add("Get the ~y~Ball~w~ into the ~b~Blue~w~ goal.");												//187
            sMistext.Add("Get The ~y~Ball~w~ into the ~r~Red~w~ goal.");												//188
            sMistext.Add("Enter the ~b~Fire Engine~w~.");						                                        //189
            sMistext.Add("Hey thanks for not destroying my cargo.. Here i got a 'Pac Standard' if your interested?");	//190
            sMistext.Add("Total Packages delivered : ");	                                                            //191
            sMistext.Add("Fubar multi ride bonus = $");			                                                        //192
            sMistext.Add("Your Time : ");						                                                        //193
            sMistext.Add("Interceptors shot down, ");			                                                        //194
            sMistext.Add("Glyphosate Remaining ");			                                                            //195
            sMistext.Add("Lbs");					                                                                    //196
            sMistext.Add(", Patients recovered");			                                                            //197
            sMistext.Add("Goto the ~y~Nightclub~w~.");																	//198
            sMistext.Add("Goto the ~y~Balcony Bar~w~.");																//199
            sMistext.Add("Serve the ~y~Customers~w~.");															        //200
            sMistext.Add("Put the money in the ~y~till~w~.");														    //201
            sMistext.Add("Get to ~y~Fort Zancudo~w~.");	                                    							//202
            sMistext.Add("Goto the ~y~Hangar~w~ roof.");																//203
            sMistext.Add("Enter the ~b~Dozer~w~.");																		//204
            sMistext.Add("Use the ~b~Dozer~w~ to load the ~r~Dupes~w~ into the ~y~Dump~w~.");							//205
            sMistext.Add("Enter the ~b~Dump~w~.");																		//206
            sMistext.Add("Drive the ~b~Dump~w~ to the ~y~Destination~w~.");												//207
            sMistext.Add("Goto the ~y~Casino~w~.");																		//208
            sMistext.Add("Remove your ~b~Weapons~w~ before entering the ~y~Security Gate~w~.");							//209
            sMistext.Add("Go and collect your ~b~Uniform~w~.");															//210
            sMistext.Add("Goto the casino ~y~Main Entrance~w~.");														//211
            sMistext.Add("Stand at the ~b~Lectern~w~ and wait for a customer to arrive.");								//212
            sMistext.Add("Enter the customers ~b~Vehicle~w~.");															//213
            sMistext.Add("Deliver the ~b~Vehicle~w~ to the ~y~Parking Garage~w~.");										//214
            sMistext.Add("Return to the ~y~Lectern~w~.");																//215
            sMistext.Add("Collect the customers ~b~Vehicle~w~ from the ~y~Parking Garage~w~.");						//216
            sMistext.Add("Deliver the ~b~Vehicle~w~ to the casino ~y~Main Entrance~w~.");								//217
            sMistext.Add("Exit the customers ~b~Vehicle~w~.");															//218
            sMistext.Add("Goto the ~y~Secret Underground Layer~w~.");													//219
            sMistext.Add("The ~b~Foreman~w~ needs help.");																//220
            sMistext.Add("The ~b~Technician~w~ needs help.");															//221
            sMistext.Add("The ~b~Scientist~w~ needs help.");															//222
            sMistext.Add("~r~Players~w~ are attacking the ~b~Secret Underground Layer~w~. Stop them.");					//223
            sMistext.Add("Collect the ");																				//224
            sMistext.Add("Return to the ~b~Foreman~w~.");																//225
            sMistext.Add("Return to the ~b~Technician~w~.");															//226
            sMistext.Add("Return to the ~b~Scientist~w~.");															//227
            sMistext.Add("The ~y~Secret Underground Layer~w~ is under attack.");										//228
            sMistext.Add("Goto the ~y~Deliverwho~w~ restaurant.");														//229
            sMistext.Add("Take the ~b~Deliverwho order~w~ to the ~y~Customer~w~.");										//230
            sMistext.Add("Return your ~y~Uniform~w~.");																	//231
            sMistext.Add("Collect your ~y~Weapons~w~.");																//232
            sMistext.Add("Exit the ~y~Building~w~.");																	//233
            sMistext.Add("Exit the ~b~Plane~w~ somewhere over the ~y~Drop Zone~w~.");									//234
            sMistext.Add("Make your way to the center of the ~y~Drop Zone~w~.");										//235
            sMistext.Add("You are outside of the ~y~Drop Zone~w~.");													//236
            sMistext.Add("Goto the ~y~Facility~w~.");										                            //237
            sMistext.Add("Get to the ~y~Vantage Point~w~.");										//238
            sMistext.Add("Collect the ~y~Sniper Rifle~w~.");										//239
            sMistext.Add("Eliminate the ~y~Target~w~.");										//240
            sMistext.Add("");										//241
            sMistext.Add("");										//242
            sMistext.Add("");										//243

            sContext.Clear();
            sContext.Add("Use the ~INPUT_DETONATE~ for Down and ~INPUT_CONTEXT~ for Up, Builder Mission = ");								//0
            sContext.Add(" ~INPUT_SPRINT~ Play Mission ~INPUT_JUMP~ Reject Mission ~n~ ~INPUT_DETONATE~ Options");							//1
            sContext.Add(" ~INPUT_SPRINT~ Continue Mission ~INPUT_JUMP~ End Mission");														//2
            sContext.Add("How many laps? Use the ~INPUT_DETONATE~ for less and ~INPUT_CONTEXT~ for more. Laps = ");							//3
            sContext.Add(", is the asking price. Did you want to Purchase this yacht? ~INPUT_SPRINT~ for Yes, ~INPUT_JUMP~ for No");		//4
            sContext.Add("Race type?, ~INPUT_DETONATE~ to change, ~INPUT_SPRINT~ to continue. Race type = ");								//5
            sContext.Add("Time trial");																										//6
            sContext.Add("Race");																											//7
            sContext.Add("Would you like to start the game on the yacht? ~INPUT_SPRINT~ for yes, ~INPUT_JUMP~ for No");						//8
            sContext.Add(" ~INPUT_DETONATE~ Options");																						//9
            sContext.Add("Open your map and place a waypoint for fast travel");																//10
            sContext.Add("Open your map and place a waypoint for fast travel, press ~INPUT_JUMP~ to go back");								//11
            sContext.Add("Enter the Vehicle");																								//12
            sContext.Add("Exit the vehicle");																								//13
            sContext.Add("Hold ~INPUT_CONTEXT~ to detach the trailer or ~n~Press ~INPUT_VEH_EXIT~ to exit the truck");						//14
            sContext.Add("Press ~INPUT_VEH_HORN~ to alert the convicts");																	//15
            sContext.Add("Press ~INPUT_VEH_HORN~ to alert the customer");																	//16
            sContext.Add("Press ~INPUT_VEH_HORN~ to alert the patient");																	//17
            sContext.Add("Hold ~INPUT_AIM~ to spray the fire");																				//18
            sContext.Add("Hold ~INPUT_AIM~ and press ~INPUT_Attack~ to perform a stealth kill");											//19
            sContext.Add("Tap ~INPUT_Duck~ to enter stealth mode");																			//20
            sContext.Add("Hold ~INPUT_CONTEXT~ to switch into submersible mode");															//21
            sContext.Add("Aim at the contact to obtain the information from them");															//22
            sContext.Add("Hold ~INPUT_AIM~ to aim your weapon at the workers");																//23
            sContext.Add("Hold ~INPUT_CONTEXT~, if the forklift gets stuck.");																//24
            sContext.Add("Hold ~INPUT_CONTEXT~ to explode the shark bait.");																//25
            sContext.Add("Press ~INPUT_CONTEXT~ to drop the shark bait.");																	//26
            sContext.Add("Press ~INPUT_ENTER~ to enter the helicopter");																	//27
            sContext.Add("Hold ~INPUT_CONTEXT~, if the dozer gets stuck.");																	//28
            sContext.Add("Hold ~INPUT_CONTEXT~ to jump from the plane.");																	//29
            sContext.Add("~n~ ~INPUT_JUMP~ to exit. ~INPUT_DETONATE~/~INPUT_CONTEXT~, to Deduct/Add.");										//30
            sContext.Add("Press ~INPUT_VEH_EXIT~ to reset to last checkpoint.");                                                            //31
            sContext.Add("Press ~INPUT_CONTEXT~ to go prone.");           //32
            sContext.Add(" , Press ~INPUT_CONTEXT~ to change.");           //33
            sContext.Add("Press ~INPUT_CONTEXT~ to stand up.");           //34
            sContext.Add("");           //35
            sContext.Add("");           //36

            sJobtext.Clear();
            sJobtext.Add("Trucking");                                                          	                    		//0
            sJobtext.Add("Getaway Driver");                                                                         		//1
            sJobtext.Add("Packages");                                                                               		//2
            sJobtext.Add("Convicts");                                                                               		//3
            sJobtext.Add("Fubar");                                                                                  		//4
            sJobtext.Add("Pilot");                                                                                  		//5
            sJobtext.Add("Ambulance");                                                                              		//6
            sJobtext.Add("Follow");                                                                                 		//7
            sJobtext.Add("LSFD");                                                                                   		//8
            sJobtext.Add("Johnny");                                                                                 		//9
            sJobtext.Add("Racist");                                                                                 		//10
            sJobtext.Add("Explosive Device");                                                                       		//11
            sJobtext.Add("Assassination");                                                                          		//12
            sJobtext.Add("Gruppe 6");                                                                              		 	//13
            sJobtext.Add("Sailor");                                                                                			//14
            sJobtext.Add("Important Exports");                                                                      		//15
            sJobtext.Add("Debt Collect");                                                                           		//16
            sJobtext.Add("MC Business");                                                                            		//17
            sJobtext.Add("Bay Lift");                                                                               		//18
            sJobtext.Add("Sharks");                                                                                 		//19
            sJobtext.Add("Happy Shopper");                                                                          		//20
            sJobtext.Add("Mores Mute");                                                                             		//21
            sJobtext.Add("Agency");                                                                            				//22
            sJobtext.Add("Free Fall");                                                                              		//23
            sJobtext.Add("Deliverwho");                                                                             		//24
            sJobtext.Add("Red Nut Air Race");                                                                     			//25
            sJobtext.Add("Pegasus");                                                                          				//26
            sJobtext.Add("Brrrrrrrrt");                                                                       				//27
            sJobtext.Add("Import Export");                                                                         			//28
            sJobtext.Add("Crop Dusting");                                                                          			//29
            sJobtext.Add("Heil Tours");                                                                            			//30
            sJobtext.Add("Argey Bargey");                                                                         			//31
            sJobtext.Add("Piracy");                                                                                 		//32
            sJobtext.Add("Phishing");                                                                              			//33
            sJobtext.Add("Litter Bugs");                                                                          			//34
            sJobtext.Add("Boat Yard");                                                                            			//35
            sJobtext.Add("Bogdam");                                                                                 		//36
            sJobtext.Add("Carball");                                                                               			//37
            sJobtext.Add("Clubbing");                                                                              			//38
            sJobtext.Add("Dupe Detection");                                                                        			//39
            sJobtext.Add("Valet");   		                                                                    			//40
            sJobtext.Add("Facility Bikes");                                                                    				//41
            sJobtext.Add("Underground Layer");                                                                     			//42
            sJobtext.Add("Thief");                                                                                 			//43
            sJobtext.Add("Mr Pavel has requested that these ~b~Packages~w~ be left around the island..");					//44
            sJobtext.Add("One of the partiers has been seen snooping around i need you to ~b~Follow~w~ them.");				//45
            sJobtext.Add("Join the Monty Cayo Perro Rally you old '~b~Racist~w~'.");                                		//46
            sJobtext.Add("Some of my Dj's have been caught playing 'Rick Astley' you must ~b~Assassinate~w~ them.");		//47
            sJobtext.Add("There is a ~b~thief~w~ on the island, help us stop them.");  		                 				//48
            sJobtext.Add("Hello, Do you have the 'LS ~b~Trucking~w~ permit'?.. that's ok none of our drivers have..");		//49
            sJobtext.Add("Hi, our ~b~Getaway Driver~w~ has got away... Can you find a four seater car? Quickly...");		//50
            sJobtext.Add("Shopping was so last century. Now everyone wants their ~b~Packages~w~ delivered..");				//51
            sJobtext.Add("Hey, there are a group of day release ~b~Convicts~w~ nearby, can you take them back to prison?");	//52
            sJobtext.Add("Unlicensed with a barely legal vehicle... Welcome to '~b~Fubar~w~'. It's 'NOT' a taxi service..");//53
            sJobtext.Add("The 'Red Nut Air Race' is about to start and we are missing a ~b~Stunt Pilot~w~.");              	//54
            sJobtext.Add("Our regular ~b~Helicopter Pilot~w~ has been put into quarantine, can you fly our helicopter?"); 	//55
            sJobtext.Add("I've got a free pass to 'Fort Zancudo' for any ~b~Pilot~w~ willing to collect our Brrrt.");     	//56
            sJobtext.Add("Some CEO wannabe is collecting cars with a cargobob. Destroy that ~b~Pilot~w~ and his cargo."); 	//57
            sJobtext.Add("Howdy, ~b~Pilot~w~ got enough glyphosate to give every citizen of Los Santos Non-Hodgkin lymphoma.");//58
            sJobtext.Add("'Higgins Heli Tours' needs ~b~Pilots~w~. Uniform not required...");     							//59
            sJobtext.Add("'Los Santos' is a dangerous place. Can you help? Join the '~b~Los Santos Ambulance Service~w~'.");//60
            sJobtext.Add("Hello, can you ~b~Follow~w~ someone for us?");    												//61
            sJobtext.Add("'~b~LSFD~w~'. Wants you to fulfill that burning desire.. Join today");           					//62
            sJobtext.Add("It's '~b~Johnny on the Spot~w~' . Can you deliver a players vehicle for me?");     	       		//63
            sJobtext.Add("Hello, we are looking for a '~b~Racist~w~'. Are you a '~b~Racist~w~'?");  						//64
            sJobtext.Add("There is an '~b~Explosive Device~w~' hidden in a secret area... Did you want to know more?");  	//65
            sJobtext.Add("Greetings, They're certain targets that need '~b~Assassination~w~'. Could you help?");  			//66
            sJobtext.Add("Congratulations your application to '~b~Gruppe 6 security~w~' has been approved.");  	          	//67
            sJobtext.Add("Ahoy ~b~Sailor~w~. We have a barge full of cars to deliver, if you are interested?");        		//68
            sJobtext.Add("Ahoy ~b~Sailor~w~. Your yacht is over run with pirates..Can you put an end to them salty sea dogs?");//69
            sJobtext.Add("Ahoy ~b~Sailor~w~. My yacht is over run with pirates.. Can you put an end to them salty sea dogs?");//70
            sJobtext.Add("Ahoy ~b~Sailor~w~. There is something fishy going on in 'Lago Zancudo'...");   	     			//71
            sJobtext.Add("Ahoy ~b~Sailor~w~. The 'Los Santos' storm drain is over run with rubbish... Can you clean it up?");//72
            sJobtext.Add("Ahoy ~b~Sailor~w~. We got some boats that need delivery, come to the 'Galilee boat yard'.");    	//73
            sJobtext.Add("Ahoy ~b~Sailor~w~. There are rumors of a Russian sub in the bay, can you check it out?");   	  	//74
            sJobtext.Add("There are some ~b~Important Exports~w~. That need to be found.. Are you interested?");         	//75
            sJobtext.Add("Good day. I need someone to '~b~Debt Collect~w~' for us. You'll get 10%.");            	      	//76
            sJobtext.Add("There is a rival '~b~MC Business~w~' operating on our turf. Can you put a stop to them?");       	//77
            sJobtext.Add("Hello there is a CEO with a large debt to us. Can you '~b~Bay Lift~w~' a certain special item.");	//78
            sJobtext.Add("A shiver of '~b~Sharks~w~' are terrorizing the swimmers of 'Los Santos'. Can you help?");      	//79
            sJobtext.Add("We need some protection money collected, can you be a ~b~Happy Shopper~w~ and go collect?");		//80
            sJobtext.Add("A representative of ~b~Mores mutual~w~, is investigating a claim i have.. Borrow his car.");		//81
            sJobtext.Add("It's a game of two halves on a level playing ~b~Agency~w~ said your a team player, interested?");	//82
            sJobtext.Add("I've just opened a new club. and need help you were recommended by the ~b~Agency~w~...");         	//83
            sJobtext.Add("Hi it's 'Take 2'. We have some ~b~Agency~w~ work, removing a dupe collection from an exploiter.");//84
            sJobtext.Add("Hello it's the Diamond Resort, The ~b~Agency~w~ said you maybe interested in some work?");			//85
            sJobtext.Add("Hey we've smuggled some BMX's into a facility, ~b~Agency~w~ recommended you as a racist.");		//86
            sJobtext.Add("Hi we have just opened a secret underground lab if you are interested in some ~b~Agency~w~ work.");//87
            sJobtext.Add("This state has gone in to ~b~Free Fall~w~ are you ready to take a jump.");                     	//88
            sJobtext.Add("No one wants to eat out anymore.. So we must ~b~Deliverwho~w~ the restaurant to them.");			//89
            sJobtext.Add("You have no mission types selected.");                                                          	//90
            sJobtext.Add("Sniper");                                                                                               //91
            sJobtext.Add("");                                                                                               //92
            sJobtext.Add("");                                                                                               //93
            sJobtext.Add("");                                                                                               //94
            sJobtext.Add("");                                                                                               //95
            sJobtext.Add("");                                                                                               //96
            sJobtext.Add("");                                                                                               //97
            sJobtext.Add("");                                                                                               //98
            sJobtext.Add("");                                                                                               //99
            sJobtext.Add("");                                                                                               //100


            sOthertext.Clear();
            sOthertext.Add("GOODS VALUE");         		                            //0
            sOthertext.Add("TIME REMAINING");         		                        //1
            sOthertext.Add("TAKE");         			                            //2
            sOthertext.Add("PACKAGES");         		                            //3
            sOthertext.Add("FUBAR EARNINGS");         		                        //4
            sOthertext.Add("GLYPHOSATE REMAINING");         	                    //5
            sOthertext.Add("LOCATIONS");         		                            //6
            sOthertext.Add("GOONS REMAINING");         		                        //7
            sOthertext.Add("MALPRACTICE SUIT");         	                        //8
            sOthertext.Add("FIRE DAMAGE");         		                            //9
            sOthertext.Add("REPAIR COST");         		                            //10
            sOthertext.Add("POSITION");         		                            //11
            sOthertext.Add("CURRENT LAP");         		                            //12
            sOthertext.Add("DISTANCE");         		                            //13
            sOthertext.Add("WORLD RECORD");         		                        //14
            sOthertext.Add("TIME");         			                            //15
            sOthertext.Add("THE BOMB WILL EXPLODE IN :"); 	                        //16
            sOthertext.Add("SPOOK METER");         		                            //17
            sOthertext.Add("TRACKING SIGNAL");         		                        //18
            sOthertext.Add("RUBBISH REMAINING");         	                        //19
            sOthertext.Add("The Main Docks");         		                        //20
            sOthertext.Add("The North Docks");         		                        //21
            sOthertext.Add("The Airstrip");         					            //22
            sOthertext.Add("I've got a saw throat and an odd taste in my mouth.");	//23
            sOthertext.Add("Cough..");         						                //24
            sOthertext.Add("Brains... Hmmm Brains...");         			        //25
            sOthertext.Add("Help I've been attacked by a lunatic.");         		//26
            sOthertext.Add("It's nothing really just a scratch.");         		    //27
            sOthertext.Add("Oww Ouch Ooo Eee");         				            //28
            sOthertext.Add("I think I've broken my coccyx.");         			    //29
            sOthertext.Add("Not much just severe lacerations and some internal bleeding.");//30
            sOthertext.Add("I'm melting.");         					            //31
            sOthertext.Add("It burns aggg.");         					            //32
            sOthertext.Add("Is it me or is it rather hot?");         			    //33
            sOthertext.Add("I've sustained second degree burns to my ...");       	//34
            sOthertext.Add("Ooo Hot Hot oo Oww.");         				            //35
            sOthertext.Add("*-Blur-* Burp...");         				            //36
            sOthertext.Add("OOo my stomach.");         				            //37
            sOthertext.Add("I don't feel too well.");         				        //38
            sOthertext.Add("I've filled my pants.");         				        //39
            sOthertext.Add("I think I've got Norovirus.");         			        //40
            sOthertext.Add("Can you look at my rash?");         			        //41
            sOthertext.Add("Hello can i get your autograph?");         			    //42
            sOthertext.Add("Where's that other medic the one they usually send?"); 	//43
            sOthertext.Add("Your so tall and handsome.");         			        //44
            sOthertext.Add("Oh what happened to your uniform? I want a real medic.");//45
            sOthertext.Add("Diagnosis");         					                //46
            sOthertext.Add("Triage your patient");         				            //47
            sOthertext.Add("Inject your patient with hydroxychloroquine");       	//48
            sOthertext.Add("Apply dressing to the burns");         			        //49
            sOthertext.Add("Give the patient an alcaselza suppository");         	//50
            sOthertext.Add("Dismiss your patient");         				        //51
            sOthertext.Add("Your best lap : ");         					        //52
            sOthertext.Add("Money Earned $");         						        //53
            sOthertext.Add("Mission Passed");         						        //54
            sOthertext.Add("Mission Failed");         						        //55
            sOthertext.Add("Select an option");         					        //56
            sOthertext.Add("Custom Vehicle");         						        //57
            sOthertext.Add("Custom Car");         						            //58
            sOthertext.Add("Custom Plane");         						        //59
            sOthertext.Add("Custom Boat");         						            //60
            sOthertext.Add("Custom Helicopter");         					        //61
            sOthertext.Add("Add Custom Car");         						        //62
            sOthertext.Add("Add Custom Plane");         					        //63
            sOthertext.Add("Add Custom Boat");         						        //64
            sOthertext.Add("Add Custom Helicopter");         				        //65
            sOthertext.Add("Select Available Missions");        			        //66
            sOthertext.Add("Select Settings");         						        //67
            sOthertext.Add("Show Route");           						        //68
            sOthertext.Add("Toggle GPS to target.");           				        //69
            sOthertext.Add("Subtitles");           						            //70
            sOthertext.Add("Toggle Subtitle/Notify Ui.");           			    //71
            sOthertext.Add("Phone Cone");           						        //72
            sOthertext.Add("Toggle the blip and cone for street phones.");          //73
            sOthertext.Add("Enemy Strength");           					        //74
            sOthertext.Add("Reduce the damage enemies inflict.");           		//75
            sOthertext.Add("Fast Travel");           						        //76
            sOthertext.Add("Be moved to the start location/vehicle for mission.");  //77
            sOthertext.Add("Toggle Phone Audio");         					        //78
            sOthertext.Add("Toggles the street phone audio ring.");         		//79
            sOthertext.Add("Block This Phone");         					        //80
            sOthertext.Add("Add this phone to a list of blocked phones.");         	//81
            sOthertext.Add("Builder Missions Select");         					    //82
            sOthertext.Add("Select Builder missions on job launch.");         		//83
            sOthertext.Add("Phone Animation");         						        //84
            sOthertext.Add("Phone pickup animation.");         					    //85
            sOthertext.Add("Load On Yacht");         						        //86
            sOthertext.Add("Start your game on the yacht.");         			    //87
            sOthertext.Add("Yacht Price :");         						        //88
            sOthertext.Add("Set the purchase price of the yacht.");         		//89
            sOthertext.Add("Online Maps");         						            //90
            sOthertext.Add("Disable PreLoad of 'Online Maps'");         		    //91
            sOthertext.Add("Build Menu");         						            //92
            sOthertext.Add("Select an option.");         					        //93
            sOthertext.Add("Save Mission");         						        //94
            sOthertext.Add("Discard Mission");         						        //95
            sOthertext.Add("Re-Test Mission");         						        //96
            sOthertext.Add("Previous trailer");         					        //97
            sOthertext.Add("Next trailer");         						        //98
            sOthertext.Add("Previous livery");         						        //99
            sOthertext.Add("Next livery");         						            //100
            sOthertext.Add("Select Trailer");         						        //101
            sOthertext.Add("Back");         								        //102
            sOthertext.Add("Heading '-'");         							        //103
            sOthertext.Add("Heading '+'");         							        //104
            sOthertext.Add("Left");         								        //105
            sOthertext.Add("Right");         								        //106
            sOthertext.Add("Forward");         								        //107
            sOthertext.Add("Backward");         							        //108
            sOthertext.Add("Select Position");         							    //109
            sOthertext.Add("Place vehicle here");         						    //110
            sOthertext.Add("Test Mission");         							    //111
            sOthertext.Add("Add another end location");         			        //112
            sOthertext.Add("Previous");         							        //113
            sOthertext.Add("Next");         								        //114
            sOthertext.Add("Select Vehicle");         							    //115
            sOthertext.Add("Add Delivery Point");         						    //116
            sOthertext.Add("Finish and Test");         							    //117
            sOthertext.Add("Add March Point");         							    //118
            sOthertext.Add("Set Fubar Park Position");         				        //119
            sOthertext.Add("Set Fubar Ped Spawn Position");         			    //120
            sOthertext.Add("Make another fubar drop");         						//121
            sOthertext.Add("Add ped position");         						    //122
            sOthertext.Add("Set shark spawn position");         			        //123
            sOthertext.Add("Make start point and test");         			        //124
            sOthertext.Add("Previous Class");         							    //125
            sOthertext.Add("Next Class");         							        //126
            sOthertext.Add("Add Vehicle to race list");         			        //127
            sOthertext.Add("Continue");         							        //128
            sOthertext.Add("Set players race vehicle drop point");         		    //129
            sOthertext.Add("Set start line furthest left position");         		//130
            sOthertext.Add("Race start Position ");         				        //131
            sOthertext.Add("Add race target");         							    //132
            sOthertext.Add("Remove last bomb");                                     //133
            sOthertext.Add("Add bomb location");         						    //134
            sOthertext.Add("Add Boss location and heading");         			    //135
            sOthertext.Add("Add Goon location and heading");         			    //136
            sOthertext.Add("Add goon walk path");         						    //137
            sOthertext.Add("Make next path");         							    //138
            sOthertext.Add("Make start point and test");         			        //139
            sOthertext.Add("Your NSCoins acc has gone up ");         			    //140
            sOthertext.Add("Your low risk acc has gone up ");         			    //141
            sOthertext.Add("Your high risk acc has gone up ");         			    //142
            sOthertext.Add("Your NSCoins acc has gone down ");         			    //143
            sOthertext.Add("Your low risk acc has gone down ");         		    //144
            sOthertext.Add("Your high risk acc has gone down ");         		    //145
            sOthertext.Add("balance; ");         							        //146
            sOthertext.Add("Too close to start");                                   //147
            sOthertext.Add("INTIMIDATION");         		                        //148
            sOthertext.Add("VEHICLE DAMAGE");         		                        //149
            sOthertext.Add("RED'S/BLUE'S");         		                        //150
            sOthertext.Add("TIME");         		                                //151
            sOthertext.Add("TIPS : ");         		                            	//152
            sOthertext.Add("BAR AGGRESSION");         		    					//153
            sOthertext.Add("STUNT BONUS");         		    						//154
            sOthertext.Add("ZONE RESIZE IN:");         		                        //155
            sOthertext.Add("PLAYERS REMAINING");         		                    //156
            sOthertext.Add("Have considered checking out and subscribing to the mod authors Youtube channel ~r~www.youtube.com/channel/UC66Rwd48-5wlObM9pDo15tg~w~.");         		    //157
            sOthertext.Add("");         		    //158
            sOthertext.Add("");         		    //159
            sOthertext.Add("");                     //160

            sContactLang.Clear();
            sContactLang.Add("All our Fubar drivers are busy please try again later...");               //0
            sContactLang.Add("Your vehicle can't be delivered at this time...");                        //1
            sContactLang.Add("There are no weapons dealers in your area.");                             //2
            sContactLang.Add("A Medic can not be dispatched at this time...");                          //3
            sContactLang.Add("Import Export Refund");                                                   //4
            sContactLang.Add("Medical Refund");                                                         //5
            sContactLang.Add("Pegasus Refund");                                                         //6
            sContactLang.Add("Your NSCoins acc has gone Up");                                           //7
            sContactLang.Add("Your low risk acc has gone Up");                                          //8
            sContactLang.Add("Your high risk acc has gone Up");                                         //9
            sContactLang.Add("Your NSCoins acc has gone down");                                         //10
            sContactLang.Add("Your low risk acc has gone down");                                        //11
            sContactLang.Add("Your high risk acc has gone down");                                       //12
            sContactLang.Add("balance; ");                                                              //13
            sContactLang.Add("Fubar Carz");                                                             //14
            sContactLang.Add("NSCoin ");                                                                //15
            sContactLang.Add("NSPM Bank");                                                              //16
            sContactLang.Add("New contact added :");                                                    //17
            sContactLang.Add("Fubar Cars");                                                             //18
            sContactLang.Add("Import/Export Cars");                                                     //19
            sContactLang.Add("Mk2 Weapons Man");                                                        //20
            sContactLang.Add("Pegasus Travel");                                                         //21
            sContactLang.Add("Police Bribes");                                                          //22
            sContactLang.Add("Medicare");                                                               //23
            sContactLang.Add("Account");                                                                //24
            sContactLang.Add("Current ");                                                               //25
            sContactLang.Add("Get an account statement");                                               //26
            sContactLang.Add("Bank Transfer");                                                          //27
            sContactLang.Add("Logout");                                                                 //28
            sContactLang.Add("Current Acc: ");                                                          //29
            sContactLang.Add("Import List");                                                            //30
            sContactLang.Add("Super");                                                                  //31
            sContactLang.Add("Sports");                                                                 //32
            sContactLang.Add("Sports Classics");                                                        //33
            sContactLang.Add("Mussel");                                                                 //34
            sContactLang.Add("Offroad");                                                                //35
            sContactLang.Add("Coupe");                                                                  //36
            sContactLang.Add("SUV");                                                                    //37
            sContactLang.Add("Compacts");                                                               //38
            sContactLang.Add("Sedans");                                                                 //39
            sContactLang.Add("Custom Car");                                                             //40
            sContactLang.Add("Insufficient Funds");                                                     //41
            sContactLang.Add("Medical");                                                                //42
            sContactLang.Add("Mk2 Weapons");                                                            //43
            sContactLang.Add("Weapon List");                                                            //44
            sContactLang.Add("Request Weapons Man");                                                    //45
            sContactLang.Add("Return Missing Weapons");                                                 //46
            sContactLang.Add("Refill Ammo");                                                            //47
            sContactLang.Add("Pegasus");                                                                //48
            sContactLang.Add("Pegasus Lifestyle");                                                      //49
            sContactLang.Add("Civilian Helicopters");                                                   //50
            sContactLang.Add("Military Helicopters");                                                   //51
            sContactLang.Add("Civilian Planes");                                                        //52
            sContactLang.Add("Military Planes");                                                        //53
            sContactLang.Add("Boats");                                                                  //54
            sContactLang.Add("Special Vehicles");                                                       //55
            sContactLang.Add("Custom Boat");                                                            //56
            sContactLang.Add("Custom Plane");                                                           //57
            sContactLang.Add("Custom Heli");                                                            //58
            sContactLang.Add("you need to be in the water.");                                           //59
            sContactLang.Add("Your next bribe can be taken in : ");                                     //60
            sContactLang.Add("Your wanted level is above 3 stars");                                     //61
            sContactLang.Add("Police Bribes");                                                          //62
            sContactLang.Add("DLC Spawn Error please update trainer mod");                              //63
            sContactLang.Add("Press ~INPUT_ENTER~ to enter the fubar ride");                            //64
            sContactLang.Add("Fubar Fair : ");                                                          //65
            sContactLang.Add("Go to mission target. ~INPUT_DETONATE~");                                 //66
            sContactLang.Add("Set your map waypoint to your destination");                              //67
            sContactLang.Add("press ~INPUT_DETONATE~ to purchase Mk2 Weapons");                         //68
            sContactLang.Add("~n~ ~INPUT_JUMP~ to exit. ~INPUT_DETONATE~/~INPUT_CONTEXT~, to Deduct/Add.");//69
            sContactLang.Add("Low Risk");                                                               //70
            sContactLang.Add("High Risk");                                                              //71
            sContactLang.Add("Ammo Type");                                                              //72
            sContactLang.Add("Attachments");                                                            //73
            sContactLang.Add("Livery");                                                                 //74
            sContactLang.Add("Go to waypoint target. ~INPUT_DETONATE~");                                //75
            sContactLang.Add("");                                                        //76
            sContactLang.Add("");                                                        //77
            sContactLang.Add("");                                                        //78
            sContactLang.Add("");                                                        //79
            sContactLang.Add("");                                                        //80

            sYachtLang.Clear();
            sYachtLang.Add("Invalid Model. Only available for Franklin, Michael, Trevor, FreemodeMale01 and FreemodeFemale01.");    //0
            sYachtLang.Add("Outfit");                                                                                               //1
            sYachtLang.Add("Save Current Outfit");                                                                                  //2
            sYachtLang.Add("Add Current Outfit");                                                                                   //3
            sYachtLang.Add("No Outfits to transfer");                                                                               //4
            sYachtLang.Add("Press ~INPUT_DETONATE~ to exit.");                             //5
            sYachtLang.Add("Press ~INPUT_DETONATE~ to remove scuba gear.");                             //6
            sYachtLang.Add("Press ~INPUT_DETONATE~ for scuba gear.");                             //7
            sYachtLang.Add("Press ~INPUT_DETONATE~ to sleep.");                             //8
            sYachtLang.Add("Press ~INPUT_DETONATE~ to stand up.");                             //9
            sYachtLang.Add("Press ~INPUT_DETONATE~ to stand here.");                             //10
            sYachtLang.Add("Press ~INPUT_DETONATE~ to Sit.");                             //11
            sYachtLang.Add("Press ~INPUT_DETONATE~ for wardrobe.");                             //12
            sYachtLang.Add("Press ~INPUT_DETONATE~ to play the piano.");                             //13
            sYachtLang.Add("Press ~INPUT_DETONATE~ to drink.");                             //14
            sYachtLang.Add("Fast Travel?, ~INPUT_DETONATE~, ~INPUT_CONTEXT~ to change, ~INPUT_SPRINT~ to continue.");                             //15
            sYachtLang.Add("Current destination is ");                             //16
            sYachtLang.Add("~INPUT_DETONATE~ to Dance, ~INPUT_CONTEXT~ to stop");                                                    //17
            sYachtLang.Add("");                             //18
            sYachtLang.Add("");                             //19

            ThisLang.Maptext = sMaptext;
            ThisLang.Mistext = sMistext;
            ThisLang.Context = sContext;
            ThisLang.Jobtext = sJobtext;
            ThisLang.Othertext = sOthertext;
            ThisLang.ContactLang = sContactLang;
            ThisLang.YachtLang = sYachtLang;

            return ThisLang;
        }
        private static XmlSetings XmlSetReturn()
        {
            LoggerLight.LogThis("XmlSetReturn");

            XmlSetings NewSet;

            if (File.Exists(sNSPMSet))
                NewSet = ReadWriteXML.LoadXmlSets(sNSPMSet);
            else
            {
                NewSet = new XmlSetings
                {
                    Truckin = true,
                    Getaway = true,
                    Packages = true,
                    Convicts = true,
                    FUber = true,
                    Pilot = true,
                    Amulance = true,
                    Follow = true,
                    LSFD = true,
                    Johnny = true,
                    Raceist = true,
                    BBBomb = true,
                    Sailor = true,
                    Gruppe6 = true,
                    Assassination = true,
                    ImportantEx = true,
                    DebtCollect = true,
                    MCBusiness = true,
                    BayLift = true,
                    Sharks = true,
                    HappyShopper = true,
                    MoresMute = true,
                    TempJob = true,
                    ParaDisplay = true,
                    Deliverwho = true,

                    ShowRoute = true,
                    EnemyStrength = true,
                    FastTraveltoStart = false,
                    Subtitles = true,
                    PhoneCone = true,
                    PhoneAudio = true,
                    BulderOnly = false,
                    MenyooAppFixer = false,

                    LowerAim = 25,
                    UpperAim = 75,

                    AssZone01 = 0,
                    AssZone02 = 0,
                    AssZone03 = 0,
                    AssZone04 = 0,
                    AssZone05 = 0,
                    AssZone06 = 0,
                    AssZone07 = 0,

                    SPDelayTime = 4000,
                    YachtPrice = 6000000,
                    ModVersion = 0,
                    PhoneAnim = true,
                    PreLoadOnline = true,
                    LangSupport = 0,
                    WhyNotSubscribe = 0
                };
            }


            if (NewSet.ModVersion != 37000)
            {
                NewSet.ModVersion = 37000;
                ReadWriteXML.SaveXmlSets(NewSet, sNSPMSet);
            }

            return NewSet;
        }
        private static PlayerAssets SetMyAss()
        {
            LoggerLight.LogThis("SetMyAss");

            PlayerAssets PlayAss = new PlayerAssets();

            if (MyDatSet.iOwnaYacht == iProcessForYacht)
                PlayAss.OwnaYacht = true;

            if (MyDatSet.iGotPegsus == iProcessForPegs)
                PlayAss.GotPegsus = true;

            if (MyDatSet.iPegsSafeHeliTest == iPegsSafeHeli)
                PlayAss.PegsSafeHeliTest = true;

            if (MyDatSet.iPegsWarHeliTest == iPegsWarHeli)
                PlayAss.PegsWarHeliTest = true;

            if (MyDatSet.iPegsSafePlaneTest == iPegsSafePlane)
                PlayAss.PegsSafePlaneTest = true;

            if (MyDatSet.iPegsWarPlaneTest == iPegsWarPlane)
                PlayAss.PegsWarPlaneTest = true;

            if (MyDatSet.iPegsboatsTest == iPegsboats)
                PlayAss.PegsboatsTest = true;

            if (MyDatSet.iPegsimortasTest == iPegsimortas)
                PlayAss.PegsimortasTest = true;

            if (MyDatSet.iMeddicTest == iMeddicc)
                PlayAss.MeddicTest = true;

            if (MyDatSet.iWantedBribe > 0)
                PlayAss.WantedBribe = true;

            if (MyDatSet.iFubard > 0)
                PlayAss.Fubard = true;

            return PlayAss;
        }
        private static List<Vector3> PhoneOff()
        {
            LoggerLight.LogThis("PhoneOff");

            List<Vector3> Phoney = new List<Vector3>();

            Phoney.Add(new Vector3(214.317078f, -921.2575f, 29.6920071f));
            Phoney.Add(new Vector3(-41.1469345f, -1730.33057f, 28.2996063f));
            Phoney.Add(new Vector3(1769.25232f, 3337.95117f, 40.433075f));
            Phoney.Add(new Vector3(1876.836f, 2701.69775f, 44.8391724f));
            Phoney.Add(new Vector3(1584.86682f, 6451.15332f, 24.317152f));

            return Phoney;
        }
        private static CustomVeh FindCustomCarz()
        {
            LoggerLight.LogThis("FindCustomCarz");

            CustomVeh Carzz = new CustomVeh();

            if (File.Exists(DataStore.sNSPMAddonCarz))
            {
                Carzz = ReadWriteXML.LoadXmlCustom(DataStore.sNSPMAddonCarz);

                for (int i = 0; i < Carzz.MyCarz.Count; i++)
                {
                    if (!ReturnStuff.IsItARealVehicle(Carzz.MyCarz[i]))
                        Carzz.MyCarz.RemoveAt(i);
                    else
                    {
                        int iAmVeh = ReturnStuff.WhatVehicleAreYou(Carzz.MyCarz[i]);

                        if (iAmVeh == 0)
                            Carzz.MyCarz.RemoveAt(i);
                        else if (iAmVeh == 1)
                        {

                        }
                        else if (iAmVeh == 2)
                        {
                            Carzz.MyPlanez.Add(Carzz.MyCarz[i]);
                            Carzz.MyCarz.RemoveAt(i);
                        }
                        else if (iAmVeh == 3)
                        {
                            Carzz.MyBoatz.Add(Carzz.MyCarz[i]);
                            Carzz.MyCarz.RemoveAt(i);
                        }
                        else if (iAmVeh == 4)
                        {
                            Carzz.MyChopperz.Add(Carzz.MyCarz[i]);
                            Carzz.MyCarz.RemoveAt(i);
                        }
                    }
                }

                for (int i = 0; i < Carzz.MyPlanez.Count; i++)
                {
                    if (!ReturnStuff.IsItARealVehicle(Carzz.MyPlanez[i]))
                        Carzz.MyPlanez.RemoveAt(i);
                    else
                    {
                        int iAmVeh = ReturnStuff.WhatVehicleAreYou(Carzz.MyPlanez[i]);

                        if (iAmVeh == 0)
                            Carzz.MyPlanez.RemoveAt(i);
                        else if (iAmVeh == 1)
                        {
                            Carzz.MyCarz.Add(Carzz.MyPlanez[i]);
                            Carzz.MyPlanez.RemoveAt(i);
                        }
                        else if (iAmVeh == 2)
                        {

                        }
                        else if (iAmVeh == 3)
                        {
                            Carzz.MyBoatz.Add(Carzz.MyPlanez[i]);
                            Carzz.MyPlanez.RemoveAt(i);
                        }
                        else if (iAmVeh == 4)
                        {
                            Carzz.MyChopperz.Add(Carzz.MyPlanez[i]);
                            Carzz.MyPlanez.RemoveAt(i);
                        }
                    }

                }

                for (int i = 0; i < Carzz.MyBoatz.Count; i++)
                {
                    if (!ReturnStuff.IsItARealVehicle(Carzz.MyBoatz[i]))
                        Carzz.MyBoatz.RemoveAt(i);
                    else
                    {
                        int iAmVeh = ReturnStuff.WhatVehicleAreYou(Carzz.MyBoatz[i]);

                        if (iAmVeh == 0)
                            Carzz.MyBoatz.RemoveAt(i);
                        else if (iAmVeh == 1)
                        {
                            Carzz.MyCarz.Add(Carzz.MyBoatz[i]);
                            Carzz.MyBoatz.RemoveAt(i);
                        }
                        else if (iAmVeh == 2)
                        {
                            Carzz.MyPlanez.Add(Carzz.MyBoatz[i]);
                            Carzz.MyBoatz.RemoveAt(i);
                        }
                        else if (iAmVeh == 3)
                        {

                        }
                        else if (iAmVeh == 4)
                        {
                            Carzz.MyChopperz.Add(Carzz.MyBoatz[i]);
                            Carzz.MyBoatz.RemoveAt(i);
                        }
                    }
                }

                for (int i = 0; i < Carzz.MyChopperz.Count; i++)
                {
                    if (!ReturnStuff.IsItARealVehicle(Carzz.MyChopperz[i]))
                        Carzz.MyChopperz.RemoveAt(i);
                    else
                    {
                        int iAmVeh = ReturnStuff.WhatVehicleAreYou(Carzz.MyChopperz[i]);

                        if (iAmVeh == 0)
                            Carzz.MyChopperz.RemoveAt(i);
                        else if (iAmVeh == 1)
                        {
                            Carzz.MyCarz.Add(Carzz.MyChopperz[i]);
                            Carzz.MyChopperz.RemoveAt(i);
                        }
                        else if (iAmVeh == 2)
                        {
                            Carzz.MyPlanez.Add(Carzz.MyChopperz[i]);
                            Carzz.MyChopperz.RemoveAt(i);
                        }
                        else if (iAmVeh == 3)
                        {
                            Carzz.MyBoatz.Add(Carzz.MyChopperz[i]);
                            Carzz.MyChopperz.RemoveAt(i);
                        }
                        else if (iAmVeh == 4)
                        {

                        }
                    }
                }
            }

            return Carzz;
        }
        public static void LoadOnlineIps(bool bAdd)
        {
            LoggerLight.LogThis("LoadOnlineIps, bAdd == " + bAdd);

            List<string> sAddIpl = new List<string>
            {
                "vw_casino_billboard_lod",
                "vw_casino_billboard_lod(1)",
                "vw_casino_billboard",
                "hei_dlc_windows_casino_lod",
                "hei_dlc_windows_casino",
                "hei_dlc_casino_door_lod",
                "hei_dlc_casino_door",
                "hei_dlc_casino_aircon_lod",
                "hei_dlc_casino_aircon",

                "hei_dlc_vw_roofdoors_locked",
                "vw_ch3_additions",
                "vw_ch3_additions_long_0",
                "vw_ch3_additions_strm_0",
                "vw_dlc_casino_door",
                "vw_dlc_casino_door_lod"
            };

            if (bAdd)
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call(Hash._LOAD_MP_DLC_MAPS);

                Function.Call((Hash)0x9BAE5AD2508DF078, false);

                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
                }

                DataStore.bOnlineStuffLoaded = true;
            }
            else
            {
                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REMOVE_IPL, sAddIpl[i]);
                }


                Function.Call(Hash._ENABLE_MP_DLC_MAPS, false);
                Function.Call(Hash._UNLOAD_MP_DLC_MAPS);

                DataStore.bOnlineStuffLoaded = false;
            }
        }
    }
}
