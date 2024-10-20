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
        public static bool GotNoFunk { get; set; }
        public static bool OnTheJob { get; set; }
        public static bool Logging { get; set; }
        public static bool LookingForPB { get; set; }
        public static bool OnlineStuffLoaded { get; set; }
        public static bool MenuOpen { get; set; }
        public static bool OnCayoLand { get; set; }
        public static bool OptionsMen { get; set; }
        public static bool BankTransfer { get; set; }
        public static bool OldYacht { get; set; }
        public static bool YachtLoaded { get; set; }
        public static bool CorectDiagnose { get; set; }
        public static bool ByPassPlayZ { get; set; }

        public static readonly int iProcessForYacht = System.Environment.ProcessorCount * 15;
        public static readonly int iProcessForPegs = System.Environment.ProcessorCount * 17;
        public static readonly int iPegsSafeHeli = System.Environment.ProcessorCount * 7;
        public static readonly int iPegsWarHeli = System.Environment.ProcessorCount * 4;
        public static readonly int iPegsSafePlane = System.Environment.ProcessorCount * 13;
        public static readonly int iPegsWarPlane = System.Environment.ProcessorCount * 9;
        public static readonly int iPegsboats = System.Environment.ProcessorCount * 3;
        public static readonly int iPegsimortas = System.Environment.ProcessorCount * 11;
        public static readonly int iMeddicc = System.Environment.ProcessorCount * 18;

        public static int iCoinBats { get; set; }
        public static int iLookForPB { get; set; }
        public static int iBuildingUp { get; set; }
        public static int iFolPos { get; set; }
        public static int iDisplayAch { get; set; }
        public static int iRaceSym { get; set; }
        public static int iSoundId { get; set; }
        public static int iPlayerGroup { get; set; }
        public static int GP_Player { get; set; }

        public static int GP_ANPCs = AddRelationshipGroup("GroupA");
        public static int GP_BNPCs = AddRelationshipGroup("GroupB");
        public static int GP_Attack = AddRelationshipGroup("AttackNPCs");
        public static int GP_Mental = AddRelationshipGroup("MentalNPCs");

        public static readonly string sVersion = "4.51";
        public static readonly string sPlayZeroLoc = "" + Directory.GetCurrentDirectory() + "/PlayerZero/ZeroLoc.ini";
        public static readonly string sDefaulted = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/DefaultOut.Xml";
        public static readonly string sNSPMSet = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/Settings.Xml";
        public static readonly string sNSPMiniSet = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/Settings.ini";
        public static readonly string sNEW_SPM_XML = "" + Directory.GetCurrentDirectory() + "/Scripts/NEW_SPM_XML.Xml";
        public static readonly string sOLD_SPM_XML = "" + Directory.GetCurrentDirectory() + "/Scripts/OLD_SPM_XML.Xml";
        public static readonly string sNSPMLangOut = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/TestBuild.Xml";
        public static readonly string sNSPMAddonCarz = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/NSPMAddonCarz.Xml";
        public static readonly string sNSPMCont = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/NSPMContact.Xml";
        public static readonly string sNSPMYacht = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM_Contacts.dll";
        public static readonly string sNSPMRandNum = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Rando.Xml";
        public static readonly string sExMissions = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Missions/";
        public static readonly string sExMissionsRace = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Missions/Racist/";
        public static readonly string sExMissionsBomb = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Missions/Bomb/";
        public static readonly string sExMissionsShark = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Missions/Shark/";
        public static readonly string sExMissionsTruck = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Missions/Truck/";
        public static readonly string sNSPMLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/";
        public static readonly string sRaceFolder = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RaceLines/";
        public static readonly string sRandomNum = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RanNums/";
        public static readonly string sSettingFold = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/";
        public static readonly string sPlayZeroBy = "" + Directory.GetCurrentDirectory() + "/PlayerZero/DisablePZ.txt";
        public static readonly string sPlayZeroFind = "" + Directory.GetCurrentDirectory() + "/PlayerZero++.asi";
        public static readonly string sFunkFind = "" + Directory.GetCurrentDirectory() + "/V_Functions.asi";
        public static readonly string sRaceSnowOn = "" + Directory.GetCurrentDirectory() + "/AddSnow.sn";
        public static readonly string sRaceSnowOff = "" + Directory.GetCurrentDirectory() + "/RemoveSnow.sn";
        public static readonly string sAdd_Mp_IPL = "" + Directory.GetCurrentDirectory() + "/AddMP_IPL.txt";
        public static readonly string sRemove_Mp_IPL = "" + Directory.GetCurrentDirectory() + "/RemoveMP_IPL.txt";

        public static List<string> NSPMAuto = new List<string>
        {
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestMedic.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestFire.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestValey.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestDelivery.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestGroupS.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestSharks.txt"
        };

        public static Vector3 vPhoneCorona { get; set; }

        public static Vehicle SharedVeh { get; set; }

        public static XmlSetings MySettings { get; set; }
        public static XmlContacts MyContacts { get; set; }
        public static Lingoo MyLang { get; set; }

        public static DatFile MyDatSet { get; set; }

        public static AchieveAbleGoals MyAchivments { get; set; }

        public static PlayerAssets MyAssets { get; set; }

        public static XmlCustomVeh MyCustomVeh { get; set; }

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

        public static List<PlayerWeaps> PlayerWeapXList { get; set; }

        public static System.Media.SoundPlayer Hare { get; set; }
        public static System.Media.SoundPlayer Chatter { get; set; }
        public static System.Media.SoundPlayer Drilar { get; set; }
        public static System.Media.SoundPlayer CashTil { get; set; }
        public static System.Media.SoundPlayer LiftDoor { get; set; }

        public static bool bHasLoaded { get; set; }

        private static readonly List<string> sMaptext = new List<string>
        {
            "Boat Delivery",                          //0
            "Delivery Truck",                         //1
            "Delivery Trailer",                       //2
            "Delivery Vehicle",                       //3
            "Prison Bus",                             //4
            "Helicopter",                             //5
            "Plane",                                  //6
            "Ambulance",                              //7
            "Fire Truck",                             //8
            "Player Vehicle",                         //9
            "Tug",                                    //10
            "Slam Van",                               //11
            "Fork Lift",                              //12
            "Submarine",                              //13
            "Target Vehicle",                         //14
            "Customers Vehicle",                      //15
            "Fubar",                                  //16
            "Boat",                                   //17
            "Blazer Aqua",                            //18
            "Stromberg",                              //19
            "Enemy",                                  //20
            "Vehicle Drop",                           //21
            "Builder Vehicle",                        //22
            "Pickup",                                 //23
            "Angry Taxi",                             //24
            "Party Bus",                              //25
            "Search Area",                            //26
            "Race Meet",                                //27
            "Cocaine Lock-up",                           //28
            "Counterfeit Cash Factory",                 //29
            "Document Forgery Office",                  //30
            "Weed Farm",                                //31
            "Meth Lab",                                 //32
            "Bunker",                                   //33
            "Warehouse",                                //34
            "Bolingbroke Penitentiary",                 //35
            "Checkpoint",                               //36
            "Patient",                          //37
            "Export Barge",                     //38
            "Delivery Target",                  //39
            "Bank",                             //40
            "Escape Point",                     //41
            "Destination",                      //42
            "Depot",                            //43
            "Convict Parade",                   //44
            "Fubar Customer",                   //45
            "Fubar Destination",                //46
            "Roof Ladder",                      //47
            "CEO",                              //48
            "Office",                           //49
            "Sandy Shores Airfield",            //50
            "Grapeseed Airfield",               //51
            "Noose HQ",                         //52
            "Beauty Spot",                      //53
            "Jetsam Office",                    //54
            "Cat Owner",                        //55
            "Escape Area",                      //56
            "Police Station",                   //57
            "Business",                         //58
            "Security  Depot",                  //59
            "Dock",                             //60
            "Boat Yard",                        //61
            "Apartment",                        //62
            "Payment Case",                     //63
            "Exit",                             //64
            "Club House",                       //65
            "Van Keys",                         //66
            "Bomb Shop",                        //67
            "Targets Parking Spot",             //68
            "Shops Takings",                    //69
            "Bar",                              //70
            "Service Area",                     //71
            "Dance Floor",                      //72
            "Night Club",                       //73
            "Till",                             //74
            "Customer",                         //75
            "Dump",                             //76
            "Dozer",                            //77
            "Pirates",                          //78
            "Hangar",                           //79
            "Casino",                           //80
            "Uniform",                          //81
            "Weapons",                          //82
            "Lift",                             //83
            "Valet Stand",                      //84
            "Parking Garage",                   //85
            "Facility",                         //86
            "Secret Underground Layer",         //87
            "LS Car Meet",                      //88
            "Toolbox",                          //89
            "Wrench",                           //90
            "Bag",                              //91
            "Crate",                            //92
            "Suitcase",                         //93
            "Toxic Soup",                       //94
            "Foreman",                          //95
            "Technician",                       //96
            "Scientist",                        //97
            "Empty Barrel",                     //98
            "Glowing Sludge",                   //99
            "Bio Haz Barrel",                   //100
            "Remote Controller",                //101
            "Test tubes",                       //102
            "Smoke Machine",                    //103
            "Tourist",                          //104
            "Target",                           //105
            "Bikers",                           //106
            "Cat",                              //107
            "Convict",                          //108
            "Raceist",                          //109
            "Exporter",                         //110
            "Pirate",                           //111
            "Worker",                           //112
            "Player",                           //113
            "Shark",                            //114
            "Bogdan",                           //115
            "Fire",                             //116
            "Race",                             //117
            "Sea Sparrow",                      //118
            "Jetmax",                           //119
            "Technical Aqua",                   //120
            "Deliverwho",                       //121
            "Drop Zone",                        //122
            "",                                 //123
            "",                                 //124
            "",                                 //125
            "",                                 //126
            "",                                 //127
            "",                                 //128
            "",                                 //129
            ""                                  //130
        };
        private static readonly List<string> sMistext = new List<string>
        {
            "Go to the ~y~Truck~w~.",                                                                      //0
            "Enter the ~b~Truck~w~.",                                                                     //1
            "Attach the ~y~Trailer~w~ to the ~b~Truck~w~.",                                               //2
            "Deliver the ~b~Trailer~w~ to ",                												//3
            "Find a ~b~Car~w~ or ~b~Van~w~ with four or more seats.",                                     //4
            "Wait outside of the ~y~Bank~w~.",                                                            //5
            "Go to the ~y~Bank~w~.",                                                                       //6
            "Lose the ~r~Cops~w~.",                                                                       //7
            "Deliver the ~b~Bank Robbers~w~ to their ~y~Escape Point~w~.",                                //8
            "~r~Burn ~w~the~b~ Getaway Vehicle~w~.",                                                      //9
            "Go to the ~y~Delivery Vehicle~w~.",                                                           //10
            "Get on the ~b~Delivery Vehicle~w~.",                                                         //11
            "Enter the ~b~Delivery Vehicle~w~.",                                                          //12
            "Deliver the ~b~Package~w~ to the ~y~Target~w~.",                                             //13
            "Return the ~b~Delivery Vehicle~w~ to the ~y~Depot~w~.",                                   	//14
            "Get on the ~b~Prison Bus~w~.",                                                            	//15
            "You can find the ~r~Convicts~w~ parading near ",												//16
            "Deliver the ~r~Convicts~w~ to ~y~Bolingbroke Penitentiary~w~.",                              //17
            "Enter the '~b~Fubar Dilettante~w~'.",                                                        //18
            "There is a ~b~Customer~w~ at ",                												//19
            "Press your ~b~Horn~w~. To attract their attention.",                                         //20
            "Can you take me to ",                          												//21
            "Can you take us to ",                          												//22
            "Go to the ~y~Stunt Plane~w~'.",                                                               //23
            "Enter the ~b~Stunt Plane~w~.",                                                               //24
            "Fly through the ~y~Coronas~w~, bonuses for flying inverted and full bank.",                  //25
            "Go to the ~b~Helicopter~w~.",                                                                 //26
            "Enter the ~b~Helicopter~w~.",                                                                //27
            "Go to the ~b~CEO~w~ near ",                     												//28
            "Deliver the ~b~CEO~w~ to their ~y~Office~w~.",                                               //29
            "Looks like this ~r~CEO~w~ is a psycho, better get out of there...",							//30
            "Go to the ~b~B-11 Strikeforce~w~ at ~y~Fort Zancudo~w~.",                                     //31
            "Enter the ~b~B-11 Strikeforce~w~.",                                                          //32
            "Deliver the ~b~B-11 Strikeforce~w~ to '~y~Sandy Shores~w~' airfield.",                       //33
            "Change of plan, avoid being ~r~Shot down~w~ while we find an alternative ~y~airfield~w~.",   //34
            "Deliver the ~b~B-11 Strikeforce~w~ to '~y~Grapeseed~w~' airfield.",                          //35
            "Go to the ~b~Buzzard~w~ parked on the ~y~Noose HQ~w~.",                                       //36
            "Enter the ~b~Buzzard~w~.",                                                                   //37
            "The ~b~CEO~w~ is in a ~r~Cargobob~w~ above the ~y~Target~w~.",                               //38
            "The ~b~CEO~w~ is ~g~Above~w~ you.",                                                          //39
            "The ~b~CEO~w~ is ~o~Below~w~ you.",                                                          //40
            "Go to the ~b~Duster~w~ parked at ~y~Grapeseed~w~ airfield.",                                  //41
            "Enter the ~b~Duster~w~.",                                                                    //42
            "You are loaded up with ~r~Monsanto's~w~ finest, watch out for the ~g~environmentalists~w~.", //43
            "Fly from the ~y~Yellow~w~ to the ~o~Orange~w~ target.",                                      //44
            "Go to the ~b~Helicopter~w~ at the ~y~Jetsam Office~w~.",                                      //45
            "Enter the ~b~Helicopter~w~.",                                                                //46
            "Fly to the ~y~Beauty Spot~w~.",                                                            	//47
            "Gently land in the ~y~Corona~w~.",                                                           //48
            "Wait while your passengers take ~r~Selfies~w~.",                                             //49
            "Return to the ~y~Jetsam Office~w~.",                                                         //50
            "Go to the ~y~Prison Bus~w~.",                       											//51
            "Go to the ~b~Ambulance~w~ by ",                       										//52
            "Go to the ~r~Patient~w~ on ",					                                                //53
            "Exit the ~b~Ambulance~w~.",                       											//54
            "Go to the ~y~Patient~w~.",                       												//55
            "Go to the ~y~Hospital~w~ before the time runs out.",                       					//56
            "Enter the ~b~Ambulance~w~.",                       											//57
            "Go to the ~y~Hospital~w~.",                       											//58
            "The ~b~target~w~ was last spotted around ",       											//59
            "Follow that ~b~Target Vehicle~w~. Don't get too close or too far.",							//60
            "Eliminate the ~r~Targets~w~, before they can get to the police station.",					//61
            "Eliminate the ~r~Targets~w~.",																//62
            "Take the ~b~Targets Vehicle~w~.",															//63
            "Deliver the ~b~Vehicle~w~ to the ~y~Destination~w~.",										//64
            "Protect the ~b~Targets~w~.",																	//65
            "Oh.. That wasn't supposed to happen...",														//66
            "Go to the ~b~ Fire Engine ~w~ by ",															//67
            "There is a ~b~Vehicle~w~ on fire at ",														//68
            "There is a ~b~Building~w~ on fire at ",														//69
            "There is a ~b~Waste Bin~w~ on fire at ",													    //70
            "There is a ~b~Cat~w~ on fire at... No Sorry just a rescue cat at ",							//71
            "There is a ~r~MadLad~w~ starting fires near ",												//72
            "Spray the ~r~Fire~w~ with the ~b~Fire Engines~w~ hose.",										//73
            "The ~r~Cat~w~ is ~g~Above~w~ you.",															//74
            "The ~r~Cat~w~ is ~o~Below~w~ you.",															//75
            "Return to the ~b~Fire Engine~w~.",															//76
            "Deliver the ~b~Cat~w~ to its owner.",														//77
            "Exit the ~b~Fire Engine~w~.",																//78
            "Stop that ~r~MadLad~w~.",																	//79
            "The ~b~Player's Vehicle~w~ is parked on ",													//80
            "Enter the ~b~Vehicle~w~.",																	//81
            "Deliver the ~b~Vehicle~w~ to ",																//82
            "Exit the ~b~Vehicle~w~ and leave the ~o~Area~w~ before the ~r~Player~w~ arrives.",			//83
            "Enter the provided ~b~Vehicle~w~.",							                            //84
            "Go to the ~y~Start Line~w~.",																	//85
            "Your ~b~Vehicle~w~ is in the wrong class for this race type.",								//86
            "Find the '~b~Explosive Device~w~' near ",													//87
            "Look for the '~b~Explosive Device~w~'.",														//88
            "Deliver the '~b~Explosive Device~w~' to the nearby '~y~Police Station~w~'.",					//89
            "Go to the ~y~Target Destination~w~.",															//90
            "Eliminate the '~p~Marked Target~w~', silently with a '~r~Melee~w~' weapon.",					//91
            "Go to the ~y~Security Depot~w~.",																//92
            "Go to the ~y~Business~w~.",																	//93
            "Enter the ~b~Security Truck~w~.",															//94
            "Exit the ~b~Security Truck~w~.",																//95
            "The ~b~Shops Takings~w~ are in the store~w~.",									            //96
            "Return the ~b~Shops Takings~w~ to the ~y~Security Depot~w~.",								//97
            "Go to the ~y~East Docks~w~.",																	//98
            "Enter the ~b~Tug Boat~w~.",																	//99
            "Go to the ~y~Export Barge~w~.",																//100
            "Manoeuvre the ~b~Tug Boat~w~ to attach the ~r~Tug Hook~w~ to the ~y~Barge~w~.",				//101
            "Deliver the ~b~Barge~w~ to the ~y~Target Destination~w~.",									//102
            "Protect the ~b~Car Collection~w~.",															//103
            "STOP THAT ~r~CARGOBOB~w~, from stealing the cars.",											//104
            "Select one of the three ~b~Vehicles~w~ to get to the ~y~Yacht~w~.",							//105
            "Enter the ~b~Sea Sparrow~w~.",																//106
            "Enter the ~b~Jetmax~w~.",																	//107
            "Enter the ~b~Technical Aqua~w~.",															//108
            "Go to the ~y~Yacht~w~.",																		//109
            "Eliminate the ~r~Pirates~w~.",																//110
            "Go to the ~y~White Water Activity Centre~w~.",												//111
            "Enter the ~b~Boat~w~.",																		//112
            "Hold the boat in position while the ~b~Signal Scanner~w~ reads the signal",					//113
            "Go to the ~y~Phishing Signal~w~ location.",													//114
            "Deliver the ~b~Boat~w~ to the ~y~Dock~w~.",													//115
            "Go to the ~b~Blazer Aqua~w~ parked in the ~y~Storm Drains~w~.",								//116
            "Get on the ~b~Blazer Aqua~w~.",																//117
            "Collect the ~g~Rubbish~w~.",																	//118
            "Go to the '~y~Galilee Boatyard~w~'.",															//119
            "Pick a ~b~Boat~w~ to deliver.",																//120
            "Deliver the ~b~Boat~w~ to the ~y~Target Destination~w~.",									//121
            "Go to the ~y~Stromberg~w~.",																	//122
            "Go to ~y~Paleto Cove~w~.",																	//123
            "Enter the ~b~Stromberg~w~.",																	//124
            "Go to the ~y~Submarine~w~.",																	//125
            "Go to the ~y~control room~w~.",																//126
            "Interrogate the ~b~contact~w~.",																//127
            "Find the contact.",																			//128
            "Plug Cliffie into the ~g~console~w~.",														//129
            "Kill ~r~Bogdam~w~ before he starts talking rubbish for half an hour.",						//130
            "Escape from the ~b~Submarine~w~.",															//131
            "Drive around till your ~r~Radar~w~ detects the ~b~Vehicle~w~ we require.",					//132
            "Take that ~b~Vehicle~w~.",																	//133
            "Deliver the ~b~Vehicle~w~ to the ~y~Export Barge~w~.",										//134
            "Release the ~b~Vehicle~w~ over the ~y~Export Barge~w~.",										//135
            "Enter the ~b~Vehicle~w~.",																	//136
            "Go to the ~y~Apartment~w~.",																	//137
            "Collect the ~b~Payment Case~w~.",															//138
            "Deliver the ~b~Payment Case~w~ to the ~y~Bank~w~.",											//139
            "Go to this rival ~y~MC Business",																//140
            "Aim your ~r~Weapon~w~ at the workers to make them walk to the ~y~Exit~w~.",					//141
            "Exit the ~y~MC Business~w~.",																//142
            "Enter the ~b~Party Bus~w~.",																	//143
            "Deliver the ~r~Workers~w~ to ~y~",											//144
            "Eliminate the ~r~Bikers~w~.",																//145
            "Find the ~r~Keys~w~ to the ~b~Slamvan~w~.",													//146
            "Collect the ~y~Keys~w~.",																	//147
            "Enter the ~b~Slamvan~w~.",																	//148
            "Deliver the ~r~Slamvan~w~ to ~y~",											//149
            "Go to the ",																					//150
            "Enter the ~b~forklift~w~.",																	//151
            "Use the ~r~forklift~w~ to collect the ~b~Golden Egg~w~.",									//152
            "Use the ~r~forklift~w~ to collect the ~b~Yeti Hide~w~.",									//153
            "Use the ~r~forklift~w~ to collect the ~b~Golden Mini-gun~w~.",								//154
            "Use the ~r~forklift~w~ to collect the ~b~Film Real~w~.",										//155
            "Use the ~r~forklift~w~ to collect the ~b~Watch~w~.",											//156
            "Use the ~r~forklift~w~ to collect the ~b~Large Diamond~w~.",									//157
            "Deliver the ~b~Golden Egg~w~ to the ~y~pickup truck~w~.",									//158
            "Deliver the ~b~Yeti Hide~w~ to the ~y~pickup truck~w~.",									//159
            "Deliver the ~b~Golden Mini-gun~w~ to the ~y~pickup truck~w~.",								//160
            "Deliver the ~b~Film Real~w~ to the ~y~pickup truck~w~.",										//161
            "Deliver the ~b~Watch~w~ to the ~y~pickup truck~w~.",											//162
            "Deliver the ~b~Large Diamond~w~ to the ~y~pickup truck~w~.",									//163
            "Enter the ~b~Sandking~w~.",																	//164
            "Deliver the ~b~Golden Egg~w~ to the ~y~Buyer~w~.",											//165
            "Deliver the ~b~Yeti Hide~w~ to the ~y~Buyer~w~.",											//166
            "Deliver the ~b~Golden Mini-gun~w~ to the ~y~Buyer~w~.",										//167
            "Deliver the ~b~Film Real~w~ to the ~y~Buyer~w~.",											//168
            "Deliver the ~b~Watch~w~ to the ~y~Buyer~w~.",												//169
            "Deliver the ~b~Large Diamond~w~ to the ~y~Buyer~w~.",										//170
            "Enter the ~b~Submarine~w~.",																	//171
            "Detonate the bait when the ~r~Sharks~w~ are feeding.",										//172
            "Drop the bait bomb to attract the ~r~Sharks~w~.",											//173
            "Find the missing '~y~Partier~w~'. Don't let them spot you following.",						//174
            "Follow that ~b~Partier~w~ and keep out of their vision cone.",								//175
            "The ~b~Thief~w~ was spotted by ~y~Main Docks~w~.",											//176
            "The ~b~Thief~w~ was spotted by ~y~North Docks~w~.",											//177
            "The ~b~Thief~w~ was spotted by ~y~Airstrip~w~.",											    //178
            "Go to this ~y~Business~w~.",																	//179
            "Use this ~r~Bat~w~ to damage goods in his shop",												//180
            "Go to the ~y~Targets Vehicle~w~",																//181
            "Drive the ~b~Targets Vehicle~w~ to the ~y~Bomb Garage~w~",									//182
            "Return the ~b~Vehicle~w~ to the ~y~Target~w~. Careful not to set off the bomb",				//183
            "Hide somewhere so that the ~r~Target~w~ does not spot you.",									//184
            "Go to the ~y~LS Car Meet~w~.",																//185
            "Pick any ~b~Compact Vehicle~w~ to enter.",													//186
            "Get the ~y~Ball~w~ into the ~b~Blue~w~ goal.",												//187
            "Get The ~y~Ball~w~ into the ~r~Red~w~ goal.",												//188
            "Enter the ~b~Fire Engine~w~.",						                                        //189
            "Hey thanks for not destroying my cargo.. Here I got a 'Pac Standard' if your interested?",	//190
            "Packages Delivered",	                                                                            //191
            "Fubar multi ride bonus = $",			                                                        //192
            "Your Time : ",						                                                        //193
            "Interceptors shot down, ",			                                                        //194
            "Glyphosate Remaining ",			                                                            //195
            "Lbs",					                                                                    //196
            ", Patients recovered",			                                                            //197
            "Go to the ~y~Nightclub~w~.",																	//198
            "Go to the ~y~Balcony Bar~w~.",																//199
            "Serve the ~y~Customers~w~.",															        //200
            "Put the money in the ~y~till~w~.",														    //201
            "Get to ~y~Fort Zancudo~w~.",	                                    							//202
            "Go to the ~y~Hangar~w~ roof.",																//203
            "Enter the ~b~Dozer~w~.",																		//204
            "Use the ~b~Dozer~w~ to load the ~r~Dupes~w~ into the ~y~Dump~w~.",							//205
            "Enter the ~b~Dump~w~.",																		//206
            "Drive the ~b~Dump~w~ to the ~y~Destination~w~.",												//207
            "Go to the ~y~Casino~w~.",																		//208
            "Remove your ~b~Weapons~w~ before entering the ~y~Security Gate~w~.",							//209
            "Go and collect your ~b~Uniform~w~.",															//210
            "Go to the casino ~y~Main Entrance~w~.",														//211
            "Stand at the ~b~Lectern~w~ and wait for a customer to arrive.",								//212
            "Enter the customers ~b~Vehicle~w~.",															//213
            "Deliver the ~b~Vehicle~w~ to the ~y~Parking Garage~w~.",										//214
            "Return to the ~y~Lectern~w~.",																//215
            "Collect the customers ~b~Vehicle~w~ from the ~y~Parking Garage~w~.",						    //216
            "Deliver the ~b~Vehicle~w~ to the casino ~y~Main Entrance~w~.",								//217
            "Exit the customers ~b~Vehicle~w~.",															//218
            "Go to the ~y~Secret Underground Layer~w~.",													//219
            "The ~b~Foreman~w~ needs help.",																//220
            "The ~b~Technician~w~ needs help.",															//221
            "The ~b~Scientist~w~ needs help.",															//222
            "~r~Players~w~ are attacking the ~b~Secret Underground Layer~w~. Stop them.",					//223
            "Collect the ",																				//224
            "Return to the ~b~Foreman~w~.",																//225
            "Return to the ~b~Technician~w~.",															//226
            "Return to the ~b~Scientist~w~.",															    //227
            "The ~y~Secret Underground Layer~w~ is under attack.",										//228
            "Go to the ~y~Deliverwho~w~ restaurant.",														//229
            "Take the ~b~Deliverwho order~w~ to the ~y~Customer~w~.",										//230
            "Return your ~y~Uniform~w~.",																	//231
            "Collect your ~y~Weapons~w~.",																//232
            "Exit the ~y~Building~w~.",																	//233
            "Exit the ~b~Plane~w~ somewhere over the ~y~Drop Zone~w~.",									//234
            "Make your way to the centre of the ~y~Drop Zone~w~.",										//235
            "You are outside of the ~y~Drop Zone~w~.",													//236
            "Go to the ~y~Facility~w~.",										                            //237
            "Get to the ~y~Vantage Point~w~.",										                    //238
            "Collect the ~y~Sniper Rifle~w~.",										                    //239
            "Eliminate the ~y~Target~w~.",										                        //240
            "Put out the fire",										                            //241
            "Follow that ~b~Car~w~...",										                        //242
            "Stop here please",										                        //243
            "RE-SPAWNING",										//244
            "~INPUT_DETONATE~ to bump the tow hitch.",										//245
            "",										//246
            "",										//247
            "",										//248
            "",										//249
            ""										//250
        };
        private static readonly List<string> sContext = new List<string> 
        {
            "Use the ~INPUT_DETONATE~ for Down and ~INPUT_CONTEXT~ for Up",								//0
            " ~INPUT_SPRINT~ Play Mission ~INPUT_JUMP~ Reject Mission ~n~ ~INPUT_DETONATE~ Options",							//1
            " ~INPUT_SPRINT~ Continue Mission ~INPUT_JUMP~ End Mission",														//2
            "How many laps? Use the ~INPUT_DETONATE~ for less and ~INPUT_CONTEXT~ for more. Laps = ",							//3
            ", is the asking price. Did you want to Purchase this yacht? ~INPUT_SPRINT~ for Yes, ~INPUT_JUMP~ for No",		//4
            "Race type?, ~INPUT_DETONATE~ to change, ~INPUT_SPRINT~ to continue. Race type = ",								//5
            "Time trial",																										//6
            "Race",																											//7
            "Would you like to start the game on the yacht? ~INPUT_SPRINT~ for yes, ~INPUT_JUMP~ for No",						//8
            " ~INPUT_DETONATE~ Options",																						//9
            "Open your map and place a waypoint for fast travel",																//10
            "Open your map and place a waypoint for fast travel, press ~INPUT_JUMP~ to go back",								//11
            "Enter the Vehicle",																								//12
            "Exit the vehicle",																								//13
            "Hold ~INPUT_CONTEXT~ to detach the trailer or ~n~Press ~INPUT_VEH_EXIT~ to exit the truck",						//14
            "Press ~INPUT_VEH_HORN~ to alert the convicts",																	//15
            "Press ~INPUT_VEH_HORN~ to alert the customer",																	//16
            "Press ~INPUT_VEH_HORN~ to alert the patient",																	//17
            "Hold ~INPUT_AIM~ to spray the fire",																				//18
            "Hold ~INPUT_AIM~ and press ~INPUT_Attack~ to perform a stealth kill",											//19
            "Tap ~INPUT_Duck~ to enter stealth mode",																			//20
            "Hold ~INPUT_CONTEXT~ to switch into submersible mode",															//21
            "Aim at the contact to obtain the information from them",															//22
            "Hold ~INPUT_AIM~ to aim your weapon at the workers",																//23
            "Hold ~INPUT_CONTEXT~, if the forklift gets stuck.",																//24
            "Hold ~INPUT_CONTEXT~ to explode the shark bait.",																//25
            "Press ~INPUT_CONTEXT~ to drop the shark bait.",																	//26
            "Press ~INPUT_ENTER~ to enter the helicopter",																	//27
            "Hold ~INPUT_CONTEXT~, if the dozer gets stuck.",																	//28
            "Hold ~INPUT_CONTEXT~ to jump from the plane.",																	//29
            "~n~ ~INPUT_JUMP~ to exit. ~INPUT_DETONATE~/~INPUT_CONTEXT~, to Deduct/Add.",										//30
            "Press ~INPUT_VEH_EXIT~ to reset to last checkpoint.",                                                            //31
            "Press ~INPUT_CONTEXT~ to go prone.",                                                                             //32
            " , Press ~INPUT_CONTEXT~ to change.",                                                                            //33
            "Press ~INPUT_CONTEXT~ to stand up.",                                                                             //34
            " ~INPUT_SPRINT~ To answer the phone",           //35-
            "Celebration",           //36
            "Non-Contact",           //37
            "Weather",           //38
            "Laps",           //39
            "Traffic",           //40
            "Time of Day",           //41
            "Vehicle Class",           //42
            "",           //43
            "",           //44
            "",           //45
            "",           //46
            "",           //47
            "",           //48
            "",           //49
            "",           //50
        };
        private static readonly List<string> sJobtext = new List<string> 
        {
            "Trucks",                                                          	                    		//0
            "Getaway Driver",                                                                         		//1
            "Packages",                                                                               		//2
            "Convicts",                                                                               		//3
            "Fubar",                                                                                  		//4
            "Pilot",                                                                                  		//5
            "Ambulance",                                                                              		//6
            "Follow",                                                                                 		//7
            "LSFD",                                                                                   		//8
            "Johnny",                                                                                 		//9
            "Racist",                                                                                 		//10
            "Explosive Device",                                                                       		//11
            "Assassination",                                                                          		//12
            "Gruppe 6",                                                                              		 	//13
            "Sailor",                                                                                			//14
            "Important Exports",                                                                      		//15
            "Debt Collect",                                                                           		//16
            "MC Business",                                                                            		//17
            "Bay Lift",                                                                               		//18
            "Sharks",                                                                                 		//19
            "Happy Shopper",                                                                          		//20
            "Mores Mute",                                                                             		//21
            "Agency",                                                                            				//22
            "Free Fall",                                                                              		//23
            "Deliverwho",                                                                             		//24
            "Red Nut Air Race",                                                                     			//25
            "Pegasus",                                                                          				//26
            "Brrrrrrrrt",                                                                       				//27
            "Import Export",                                                                         			//28
            "Crop Dusting",                                                                          			//29
            "Heil Tours",                                                                            			//30
            "Argey Bargey",                                                                         			//31
            "Piracy",                                                                                 		//32
            "Phishing",                                                                              			//33
            "Litter Bugs",                                                                          			//34
            "Boat Yard",                                                                            			//35
            "Bogdam",                                                                                 		//36
            "Carball",                                                                               			//37
            "Clubbing",                                                                              			//38
            "Dupe Detection",                                                                        			//39
            "Valet",   		                                                                    			//40
            "Facility Bikes",                                                                    				//41
            "Underground Layer",                                                                     			//42
            "Thief",                                                                                 			//43
            "Mr Pavel has requested that these ~b~Packages~w~ be left around the island..",					//44
            "One of the partiers has been seen snooping around I need you to ~b~Follow~w~ them.",				//45
            "Join the Monty Cayo Perro Rally you old '~b~Racist~w~'.",                                		//46
            "Some of my DJ's have been caught playing 'Rick Astley' you must ~b~Assassinate~w~ them.",		//47
            "There is a ~b~thief~w~ on the island, help us stop them.",  		                 				//48
            "Hello, Do you have the 'LS ~b~Truckers~w~ permit'?.. that's ok none of our drivers have..",	//49
            "Hi, our ~b~Getaway Driver~w~ has got away... Can you find a four seater car? Quickly...",		//50
            "Shopping was so last century. Now everyone wants their ~b~Packages~w~ delivered..",				//51
            "Hey, there are a group of day release ~b~Convicts~w~ nearby, can you take them back to prison?",	//52
            "Unlicensed with a barely legal vehicle... Welcome to '~b~Fubar~w~'. It's 'NOT' a taxi service..",//53
            "The 'Red Nut Air Race' is about to start and we are missing a ~b~Stunt Pilot~w~.",              	//54
            "Our regular ~b~Helicopter Pilot~w~ has been put into quarantine, can you fly our helicopter?", 	//55
            "I've got a free pass to 'Fort Zancudo' for any ~b~Pilot~w~ willing to collect our Brrrt.",     	//56
            "Some CEO wannabe is collecting cars with a cargobob. Destroy that ~b~Pilot~w~ and his cargo.", 	//57
            "Howdy, ~b~Pilot~w~ got enough glyphosate to give every citizen of Los Santos Non-Hodgkin lymphoma.",//58
            "'Higgins Heli Tours' needs ~b~Pilots~w~. Uniform not required...",     							//59
            "'Los Santos' is a dangerous place. Can you help? Join the '~b~Los Santos Ambulance Service~w~'.",//60
            "Hello, can you ~b~Follow~w~ someone for us?",    												//61
            "'~b~LSFD~w~'. Wants you to fulfil that burning desire.. Join today",           					//62
            "It's '~b~Johnny on the Spot~w~' . Can you deliver a players vehicle for me?",     	       		//63
            "Hello, we are looking for a '~b~Racist~w~'. Are you a '~b~Racist~w~'?",  						//64
            "There is an '~b~Explosive Device~w~' hidden in a secret area... Did you want to know more?",  	//65
            "Greetings, They're certain targets that need '~b~Assassination~w~'. Could you help?",  			//66
            "Congratulations your application to '~b~Gruppe 6 security~w~' has been approved.",  	          	//67
            "Ahoy ~b~Sailor~w~. We have a barge full of cars to deliver, if you are interested?",        		//68
            "Ahoy ~b~Sailor~w~. Your yacht is over run with pirates..Can you put an end to them salty sea dogs?",//69
            "Ahoy ~b~Sailor~w~. My yacht is over run with pirates.. Can you put an end to them salty sea dogs?",//70
            "Ahoy ~b~Sailor~w~. There is something fishy going on in 'Lago Zancudo'...",   	     			//71
            "Ahoy ~b~Sailor~w~. The 'Los Santos' storm drain is over run with rubbish... Can you clean it up?",//72
            "Ahoy ~b~Sailor~w~. We got some boats that need delivery, come to the 'Galilee boat yard'.",    	//73
            "Ahoy ~b~Sailor~w~. There are rumours of a Russian sub in the bay, can you check it out?",   	  	//74
            "There are some ~b~Important Exports~w~. That need to be found.. Are you interested?",         	//75
            "Good day. I need someone to '~b~Debt Collect~w~' for us. You'll get 10%.",            	      	//76
            "There is a rival '~b~MC Business~w~' operating on our turf. Can you put a stop to them?",       	//77
            "Hello there is a CEO with a large debt to us. Can you '~b~Bay Lift~w~' a certain special item.",	//78
            "A shiver of '~b~Sharks~w~' are terrorizing the swimmers of 'Los Santos'. Can you help?",      	//79
            "We need some protection money collected, can you be a ~b~Happy Shopper~w~ and go collect?",		//80
            "A representative of ~b~Mores mutual~w~, is investigating a claim I have.. Borrow his car.",		//81
            "It's a game of two halves on a level playing ~b~Agency~w~ said your a team player, interested?",	//82
            "I've just opened a new club. and need help you were recommended by the ~b~Agency~w~...",         //83
            "Hi it's 'Take 2'. We have some ~b~Agency~w~ work, removing a dupe collection from an exploiter.",//84
            "Hello it's the Diamond Resort, The ~b~Agency~w~ said you maybe interested in some work?",		//85
            "Hey we've smuggled some BMX's into a facility, ~b~Agency~w~ recommended you as a racist.",		//86
            "Hi we have just opened a secret underground lab if you are interested in some ~b~Agency~w~ work.",//87
            "This state has gone in to ~b~Free Fall~w~ are you ready to take a jump.",                     	//88
            "No one wants to eat out any more.. So we must ~b~Deliverwho~w~ the restaurant to them.",			//89
            "You have no mission types selected.",                                                          	//90
            "Sniper",                                                                                      //91-New
            "I hope you have a head for heights as we need someone with ~b~Sniper~w~ skills.",              //92
            "Select All",                                                                                   //93
            "OUT OF VEHICLE",                                                                               //94--New
            "TOTAL EARNINGS",                                            //95
            "You are missing V_Functions.asi. please download this from here : https://www.gta5-mods.com/scripts/new-street-phone-missions",                                            //96
            "",                                            //97
            "",                                            //98
            "",                                            //99
            "",                                            //100
        };
        private static readonly List<string> sOthertext = new List<string> 
        {
            "GOODS VALUE",         		                            //0
            "TIME REMAINING",         		                        //1
            "TAKE",         			                            //2
            "PACKAGES",         		                            //3
            "FUBAR EARNINGS",         		                        //4
            "GLYPHOSATE REMAINING",         	                    //5
            "LOCATIONS",         		                            //6
            "GOONS REMAINING",         		                        //7
            "MALPRACTICE SUIT",         	                        //8
            "FIRE DAMAGE",         		                            //9
            "REPAIR COST",         		                            //10
            "POSITION",         		                            //11
            "CURRENT LAP",         		                            //12
            "DISTANCE",         		                            //13
            "WORLD RECORD",         		                        //14
            "TIME",         			                            //15
            "THE BOMB WILL EXPLODE IN :", 	                        //16
            "SPOOK METER",         		                            //17
            "TRACKING SIGNAL",         		                        //18
            "RUBBISH REMAINING",         	                        //19
            "The Main Docks",         		                        //20
            "The North Docks",         		                        //21
            "The Airstrip",         					            //22
            "I've got a saw throat and an odd taste in my mouth.",	//23
            "Cough..",         						                //24
            "Brains... Hmmm Brains...",         			        //25
            "Help I've been attacked by a lunatic.",         		//26
            "It's nothing really just a scratch.",         		    //27
            "Oww Ouch Ooo Eee",         				            //28
            "I think I've broken my coccyx.",         			    //29
            "Not much just severe lacerations and some internal bleeding.",//30
            "I'm melting.",         					            //31
            "It burns aggg.",         					            //32
            "Is it me or is it rather hot?",         			    //33
            "I've sustained second degree burns to my ...",       	//34
            "Ooo Hot Hot oo Oww.",         				            //35
            "*-Blur-* Burp...",         				            //36
            "OOo my stomach.",         				                //37
            "I don't feel too well.",         				        //38
            "I've filled my pants.",         				        //39
            "I think I've got Norovirus.",         			        //40
            "Can you look at my rash?",         			        //41
            "Hello can I get your autograph?",         			    //42
            "Where's that other medic the one they usually send?", 	//43
            "Your so tall and handsome.",         			        //44
            "Oh what happened to your uniform? I want a real medic.",//45
            "Diagnosis",         					                //46
            "Triage your patient",         				            //47
            "Inject your patient with hydroxychloroquine",       	//48
            "Apply dressing to the burns",         			        //49
            "Give the patient an alcaselza suppository",         	//50
            "Dismiss your patient",         				        //51
            "Your best lap : ",         					        //52
            "Money Earned",         						        //53---Edited
            "Mission Passed",         						        //54
            "Mission Failed",         						        //55
            "Select an option",         					        //56
            "Custom Vehicle",         						        //57
            "Custom Car",         						            //58
            "Custom Plane",         						        //59
            "Custom Boat",         						            //60
            "Custom Helicopter",         					        //61
            "Add Custom Car",         						        //62
            "Add Custom Plane",         					        //63
            "Add Custom Boat",         						        //64
            "Add Custom Helicopter",         				        //65
            "Select Available Missions",        			        //66
            "Select Settings",         						        //67
            "Show Route",           						        //68
            "Toggle GPS to target.",           				        //69
            "Subtitles",           						            //70
            "Toggle Subtitle/Notify UI.",           			    //71
            "Phone Cone",           						        //72
            "Toggle the blip and cone for street phones.",          //73
            "Enemy Strength",           					        //74
            "Reduce the damage enemies inflict.",           		//75
            "Fast Travel",           						        //76
            "Be moved to the start location/vehicle for mission.",  //77
            "Toggle Phone Audio",         					        //78
            "Toggles the street phone audio ring.",         		//79
            "Block This Phone",         					        //80
            "Add this phone to a list of blocked phones.",         	//81
            "Show Achievements",         					        //82---Edd
            "Include the achievement screen on finish.",         	//83---Edd
            "Phone Animation",         						        //84
            "Phone pickup animation.",         					    //85
            "Load On Yacht",         						        //86
            "Start your game on the yacht.",         			    //87
            "Yacht Price :",         						        //88
            "Set the purchase price of the yacht.",         		//89
            "Online Maps",         						            //90
            "Disable Pre Load of 'Online Maps'",         		    //91
            "Build Menu",         						            //92
            "Select an option.",         					        //93
            "Save Mission",         						        //94
            "Discard Mission",         						        //95
            "Re-Test Mission",         						        //96
            "Previous trailer",         					        //97
            "Next trailer",         						        //98
            "Previous livery",         						        //99
            "Next livery",         						            //100
            "Select Trailer",         						        //101
            "Back",         								        //102
            "Heading '-'",         							        //103
            "Heading '+'",         							        //104
            "Left",         								        //105
            "Right",         								        //106
            "Forward",         								        //107
            "Backward",         							        //108
            "Select Position",         							    //109
            "Place vehicle here",         						    //110
            "Test Mission",         							    //111
            "Add another end location",         			        //112
            "Previous",         							        //113
            "Next",         								        //114
            "Select Vehicle",         							    //115
            "Add Delivery Point",         						    //116
            "Finish and Test",         							    //117
            "Add March Point",         							    //118
            "Set Fubar Park Position",         				        //119
            "Set Fubar Ped Spawn Position",         			    //120
            "Make another fubar drop",         						//121
            "Add ped position",         						    //122
            "Set shark spawn position",         			        //123
            "Make start point and test",         			        //124
            "Previous Class",         							    //125
            "Next Class",         							        //126
            "Add Vehicle to race list",         			        //127
            "Continue",         							        //128
            "Set players race vehicle drop point",         		    //129
            "Set start line furthest left position",         		//130
            "Race start Position ",         				        //131
            "Add race target",         							    //132
            "Remove last bomb",                                     //133
            "Add bomb location",         						    //134
            "Add Boss location and heading",         			    //135
            "Add Goon location and heading",         			    //136
            "Add goon walk path",         						    //137
            "Make next path",         							    //138
            "Make start point and test",         			        //139
            "Your NSCoins acc has gone up ",         			    //140
            "Your low risk acc has gone up ",         			    //141
            "Your high risk acc has gone up ",         			    //142
            "Your NSCoins acc has gone down ",         			    //143
            "Your low risk acc has gone down ",         		    //144
            "Your high risk acc has gone down ",         		    //145
            "balance; ",         							        //146
            "Too close to start",                                   //147
            "INTIMIDATION",         		                        //148
            "VEHICLE DAMAGE",         		                        //149
            "RED'S/BLUE'S",         		                        //150
            "TIME",         		                                //151
            "TIPS : ",         		                            	//152
            "BAR AGGRESSION",         		    					//153
            "STUNT BONUS",         		    						//154
            "ZONE RESIZE IN:",         		                        //155
            "PLAYERS REMAINING",         		                    //156
            "Have considered checking out and subscribing",//157
            "Morning",                                              //158--new stuff
            "Midday",                                               //159
            "Noon",                                                 //160
            "Evening",                                              //161
            "Off",                                                  //162
            "On",                                                   //163
            "Gold Award",                                           //164
            "Silver Award",                                         //165
            "Bronze Award",                                         //166      
            "Going the distance",                                   //167
            "-Cover 100miles.",                                      //168
            "Kept your load",                                       //169
            "-No Detachments.",                                      //170
            "Broken in Transit",                                    //171
            "-Lose half your earnings.",                             //172
            "Down on the farm",                                     //173
            "-Do a farm delivery.",                                  //174
            "Perfect Parking ",                                     //175
            "-Get max parking reward.",                              //176
            "Picky Driver",                                         //177
            "-change vehicle mid getaway.",                          //178
            "Where's My Money",                                      //179
            "-Lose over half the takings.",                          //180
            "Flight to Safety",                                      //181
            "-Unlock the pacific standard bank.",                    //182
            "Gone in Sixty Seconds",                                //183
            "- Evade the cops in less that 60 seconds.",             //184
            "Please sign here",                                     //185
            "- Complete a Post Op delivery mission.",                //186
            "We Aim Not To Lose it",                                //187
            "- Complete a Go Postal delivery mission.",              //188
            "Big Pharma",                                           //189
            "- Complete a Deludamol delivery mission.",              //190
            "Lost in The Bin",                                      //191
            "- Complete a Lost delivery mission.",                   //192
            "Chicken Run",                                          //193
            "- Complete a poultry delivery mission.",                //194
            "Paperboy",                                             //195
            "- Complete a newspaper round.",                         //196
            "Pavals Placements ",                                   //197
            "- Deliver the goods on Cayo Piero.",                    //198
            "Package Delivered",                                    //199
            "- Deliver All the packages.",                           //200
            "Fast Track",                                           //201
            "- Finnish with over a minute to spare.",               //202
            "Goranga",                                              //203
            "- A little bit of GTA Nostalgia.",                       //204
            "Dig That Chanting Thing",                              //205
            "- Listen to the prisoners chant for 3 minutes.",       //206
            "Don't Stop For Coffee",                                 //207
            "- Hit that horn in under a second.",                   //208
            "Follow That Car",                                      //209
            "- Follow the marked car.",                             //210
            "Airport Run",                                          //211
            "- Every drivers favourite job.",                       //212
            "Big Yellow Taxi",                                      //213
            "- Survive a taxi attack.",                             //214
            "Tap the Mats",                                         //215
            "- Give back a clean dilettante.",                      //216
            "Perfect Run",                                          //217
            "- Get all the angle bonuses.",                         //218
            "It's the Player Base",                                 //219
            "- Survive a player attack.",                          //220
            "Chocks Away",                                          //221
            "- Shoot down at least 10 dog fighters.",               //222
            "Friendly Lobby",                                          //223
            "- Don't be a toxic player.",    //224
            "Hey Farmer Farmer",                                    //225
            "- Finish with 100lb of glyphosate.",                    //226
            "Like and Subscribe",                                   //227
            "- Don't slam the landings.",                            //228
            "Win Some Lose Some",                                   //229
            "- Fail to save the patients.",                          //230
            "Open The Windows",                                     //231
            "- Have a Norovirus patient sit in the front.",          //232
            "Ls In Lock-down",                                       //233
            "- Instigate a corona virus outbreak.",                  //234
            "Home Visits",                                          //235
            "- Go to houses, caravans, clubs and arcades.",          //236
            "Read the Book",                                        //237
            "- Correctly diagnose 25 patents.",                       //238
            "Whispering Grass",                                     //239
            "- Stop the informants before they go to the cops.",    //240
            "Kaboom",                                               //241
            "- Confirm that the vehicle was completely destroyed.",   //242
            "A Blaze of Glory",                                     //243
            "- Defeat the angry mob.",                              //244
            "One Previous Owner",                                   //245
            "- Liberate the targets vehicle.",                       //246
            "Knight In A Chrome Automobile",                         //247
            "- Help the target escape in there helicopter.",         //248
            "Out of this World",                                    //249
            "- Witness an alien abduction.",                         //250
            "Fire Place",                                           //251
            "- Put out house fires.",                                //252
            "Burning Rubber",                                       //253
            "- Put out vehicle fires.",                              //254
            "Save the Pussy",                                       //255
            "- Rescue Cats.",                                        //256
            "Fire Starter",                                         //257
            "- Clean up after a Molotov party.",                     //258
            "Flamin Rubbish",                                      //259
            "- Put out bin fires.",                                  //260
            "It Was Like That When I Got It",                       //261
            "- Deliver a damaged vehicle.",                          //262
            "This Ones A Keeper",                                  //263
            "- Drive the vehicle away.",                            //264
            "Just Got a Few Errands",                                  //265
            "- take your time delivering the players vehicle.",   //266
            "I Taw I Taw A PuddyTat",                                  //267
            "- Defend yourself from a player attack.",              //268
            "Riding Through the Snow",                                  //269
            "- Win a snow race.",                                  //270
            "Water Sports",                                         //271
            "- Win a boat race in the rain.",                        //272
            "Full Contact",                                  //273
            "- Win a road race with traffic on.",                    //274
            "Come Fly With Me",                                  //275
            "- Win a plane race.",                                  //276
            "What Competition?",                                  //277
            "- Eliminate the competition.",                    //278
            "Its Here",                                  //279
            "- Find the bomb in under ten seconds.",                 //280
            "On the Button",                                  //281
            "- Collect the bomb with 1 second on the countdown.",    //282
            "Surgical Precision",                                  //283
            "- Kill only the target.",                                  //284
            "Bring Everybody",                                  //285
            "- Kill all the goons.",                                  //286
            "Hold My Beer",                                  //287
            "- Complete in under a minute.",                    //288
            "Hunter",                                  //289
            "- Only use melee weapons.",                            //290
            "Lie Flat",                                  //291
            "- Hit the target while prone.",                                  //292
            "Drivin Miss Daisy",                                  //293
            "- Hit the target while they are in a vehicle.",        //294
            "Fire at Will",                                  //295
            "- Hit the wrong target.",                                  //296
            "Double Cross",                                  //297
            "- Recover the van from your thieving assistant.",  //298
            "Trumpton Riots",                                  //299
            "- Escape the angry mob.",                                  //300
            "Tank Up",                                  //301
            "- Evade the tanks.",                                  //302
            "Hey that's Mine",                                  //303
            "- Recover the security van before it explodes.",  //304
            "While I'm Here",                                  //305
            "- Purchase an item from the shop your delivering to.", //306
            "You Shale Not Pass",                      //307
            "- Gun down five or more jet ski attackers.",    //308
            "And All Who Sail In Her",                          //309
            "- Purchase the yacht.",                             //310
            "In The Drink",                                  //311
            "- Knock a fisherman into the water.",                                  //312
            "Single Use Plastics",                                  //313
            "- collect all 50 items o rubbish.",                                  //314
            "Dry Docking",                                  //315
            "- Use the cargobob to deliver the boat.",                                  //316
            "Elite Challenges",                                  //317
            "- Complete in under 15 minutes",                                  //318
            "Got to Get Them All",                                  //319
            "- Collect every available vehicle.",                                  //320
            "I Just Want Your Vehicle",                                  //321
            "- Take a vehicle without damaging the driver.",            //322
            "Not a Scratch",                                  //323
            "- Deliver a vehicle without damaging it.",                                  //324
            "Above And Beyond",                                  //325
            "- Use the cargobob to deliver a vehicle.",                                  //326
            "The Pacifist",                                  //327
            "- Complete with no deaths.",                                  //328
            "Blunt Force",                                  //329
            "- Only use melee weapons.",                                  //330
            "The Wheels on the Bus",                                  //331
            "- Deliver the party bus to the clubhouse.",                                  //332
            "Slam Dunk",                                  //333
            "- Deliver the slamvan to the club house.",                                  //334
            "Easy Riders",                                  //335
            "- Eliminate at least 20 riders.",                                  //336
            "Shark Cards",                                  //337
            "- Complete in under 5 minutes.",                                  //338
            "Das Boot",                                 //339
            "- Blow up your own sub.",                                  //340
            "Supermarket Sweep",                                  //341
            "- Take less than a minute to intimidate the shop keeper.",                                  //342
            "I Just Wanted Sprunk",                                  //343
            "- Buy a can of sprunk.",                                  //344
            "Kick The Habit",                                  //345
            "- Destroy the cigarettes and alcohol.",                                  //346
            "Parking Fine",                                  //347
            "- Align perfectly with the ghost car.",                                  //348
            "Careless Driver",                                  //349
            "- Deliver the vehicle with over 90% damage.",                                  //350
            "All Warehouses Great and Small",                                  //351
            "- Raid every type of warehouse/bunker.",                                  //352
            "Access Denied",                                  //353
            "- Defeat the retaliatory player attack.",                                  //354
            "OOO Shiny",                                  //355
            "- Collect all 6 items of cargo.",                                  //356
            "Back of the Net",                                  //357
            "- Win a carball match.",                                  //358
            "Up-setter",                                  //359
            "- Intentional ignore a waiting customer.",                                  //360
            "Not a Dupe",                                  //361
            "- Deliver at least half the dupes.",                                  //362
            "Once Round the Clock",                                  //363
            "- Drive the customers vehicle around the block.",                                  //364
            "Stunt Bonus",                                  //365
            "- Gain over $5000 in stunt bonuses",                                  //366
            "Juggernaut",                                  //367
            "- Eliminate the players before they split up.",                                  //368
            "Buddy Up",                                  //369
            "- Land your parachute next to another player.",                                  //370
            "Bury the Hatchet",                                  //371
            "- Use the 'Stone Hatchet' weapon.",                                  //372
            "Anyone For Golf?",                                  //373
            "- Use the 'Golf Club' weapon.",                                  //374
            "Home Run",                                  //375
            "- Use the 'Baseball Bat' weapon.",                                  //376
            "Knify Spoony",                                  //377
            "- Use the 'Switchblade' weapon.",                                  //378
            "The 24 hour Session",                                  //379
            "- Deliver for 24 in game hours.",                                  //380
            "On Your Bike",                                  //381
            "- Deliver using a cycle.",                                  //382
            "Fubar Eats",                                  //383
            "- Deliver by a fubar lyft.",                                  //384
            "Distance Travelled",                                  //385
            "Parking Bonus",                                  //386
            "Pacifism",                                  //387
            "-Don't fire the gun.. At all.",                                  //388
            "Your Gonna Have to Walk",                                  //389
            "-Destroy the players getaway vehicle.",                                  //390
            "Debug Mode",                                  //391
            "Save Debug Logs.",                                  //392
            "Auto-Uniforms",                                  //393
            "Allow the game to change the players outfit.",                                  //394
            "",                                  //395
            "",                                  //396
            "",                                  //397
            "",                                  //398
            "",                                  //399
            ""                                  //400
        };
        private static readonly List<string> sContactLang = new List<string>
        {
            "All our Fubar drivers are busy please try again later...",               //0
            "Your vehicle can't be delivered at this time...",                        //1
            "There are no weapons dealers in your area.",                             //2
            "A Medic can not be dispatched at this time...",                          //3
            "Import Export Refund",                                                   //4
            "Medical Refund",                                                         //5
            "Pegasus Refund",                                                         //6
            "Your NSCoins acc has gone Up",                                           //7
            "Your low risk acc has gone Up",                                          //8
            "Your high risk acc has gone Up",                                         //9
            "Your NSCoins acc has gone down",                                         //10
            "Your low risk acc has gone down",                                        //11
            "Your high risk acc has gone down",                                       //12
            "balance; ",                                                              //13
            "Fubar Carz",                                                             //14
            "NSCoin ",                                                                //15
            "NSPM Bank",                                                              //16
            "New contact added :",                                                    //17
            "Fubar Cars",                                                             //18
            "Import/Export Cars",                                                     //19
            "Mk2 Weapons Man",                                                        //20
            "Pegasus Travel",                                                         //21
            "Police Bribes",                                                          //22
            "Medicare",                                                               //23
            "Account",                                                                //24
            "Current ",                                                               //25
            "Get an account statement",                                               //26
            "Bank Transfer",                                                          //27
            "Logout",                                                                 //28
            "Current Acc: ",                                                          //29
            "Import List",                                                            //30
            "Super",                                                                  //31
            "Sports",                                                                 //32
            "Sports Classics",                                                        //33
            "Muscle",                                                                 //34
            "Off-road",                                                                //35
            "Coupé",                                                                  //36
            "SUV",                                                                    //37
            "Compacts",                                                               //38
            "Sedans",                                                                 //39
            "Custom Car",                                                             //40
            "Insufficient Funds",                                                     //41
            "Medical",                                                                //42
            "Mk2 Weapons",                                                            //43
            "Weapon List",                                                            //44
            "Request Weapons Man",                                                    //45
            "Return Missing Weapons",                                                 //46
            "Refill Ammo",                                                            //47
            "Pegasus",                                                                //48
            "Pegasus Lifestyle",                                                      //49
            "Civilian Helicopters",                                                   //50
            "Military Helicopters",                                                   //51
            "Civilian Planes",                                                        //52
            "Military Planes",                                                        //53
            "Boats",                                                                  //54
            "Special Vehicles",                                                       //55
            "Custom Boat",                                                            //56
            "Custom Plane",                                                           //57
            "Custom Heli",                                                            //58
            "you need to be in the water.",                                           //59
            "Your next bribe can be taken in : ",                                     //60
            "Your wanted level is above 3 stars",                                     //61
            "Police Bribes",                                                          //62
            "DLC Spawn Error please update trainer mod",                              //63
            "Press ~INPUT_ENTER~ to enter the fubar ride",                            //64
            "Fubar Fair : ",                                                          //65
            "Go to mission target. ~INPUT_DETONATE~",                                 //66
            "Set your map waypoint to your destination",                              //67
            "press ~INPUT_DETONATE~ to purchase Mk2 Weapons",                         //68
            "~n~ ~INPUT_JUMP~ to exit. ~INPUT_DETONATE~/~INPUT_CONTEXT~, to Deduct/Add.",//69
            "Low Risk",                                                               //70
            "High Risk",                                                              //71
            "Ammo Type",                                                              //72
            "Attachments",                                                            //73
            "Livery",                                                                 //74
            "Go to waypoint target. ~INPUT_DETONATE~",                                //75
            "Benny's",                                                        //76--new
            "Motorbike",                                                        //77--new
            "Bus",                                                        //78
            "Industrial",                                                        //79
            "Trucks",                                                       //80
            "Commercial",                                                      //81
            "Armoured",                                                       //82
            "Weaponised",                                                       //83
            "Area Wars",                                                       //84
            "Open-wheel(F1)",                                                       //85
            "Go-carts",                                                       //86
            "Cycles",                                                       //87
            "Amphibious",                                                       //88
            "Add ",                                                       //89
            "Towing Vehicles",          //90
            "Submarine",          //91
            "Jet-ski",          //92
            "Custom Vehicles",          //93
            "Not available in a mission",          //94
            "Boats",          //95
            "",          //96
            "",          //97
            "",          //98
            "",          //99
            ""          //100
        };
        private static readonly List<string> sYachtLang = new List<string>
        {
            "Invalid Model. Only available for Franklin, Michael, Trevor, FreemodeMale01 and FreemodeFemale01.",    //0
            "Outfit",                                                                                               //1
            "Save Current Outfit",                                                                                  //2
            "Add Current Outfit",                                                                                   //3
            "No Outfits to transfer",                                                                               //4
            "Press ~INPUT_DETONATE~ to exit.",                                                                      //5
            "Press ~INPUT_DETONATE~ to remove scuba gear.",                                                         //6
            "Press ~INPUT_DETONATE~ for scuba gear.",                                                               //7
            "Press ~INPUT_DETONATE~ to sleep.",                                                                     //8
            "Press ~INPUT_DETONATE~ to stand up.",                                                                  //9
            "Press ~INPUT_DETONATE~ to stand here.",                                                                //10
            "Press ~INPUT_DETONATE~ to Sit.",                                                                       //11
            "Press ~INPUT_DETONATE~ for wardrobe.",                                                                 //12
            "Press ~INPUT_DETONATE~ to play the piano.",                                                            //13
            "Press ~INPUT_DETONATE~ to drink.",                                                                     //14
            "Fast Travel?, ~INPUT_DETONATE~, ~INPUT_CONTEXT~ to change, ~INPUT_SPRINT~ to continue.",               //15
            "Current destination is ",                                                                              //16
            "~INPUT_DETONATE~ to Dance, ~INPUT_CONTEXT~ to stop",                                                   //17
            "",                             //18
            ""                             //19
        };

        public static readonly List<Oufiter> FFMasks = new List<Oufiter>
        {
            new Oufiter(1,1, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,2, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,3, new List<int>{ 0 }),
            new Oufiter(1,4, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,5, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,6, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,7, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,8, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,9, new List<int>{ 0 }),
            new Oufiter(1,10, new List<int>{ 0 }),
            new Oufiter(1,13, new List<int>{ 0 }),
            new Oufiter(1,14, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,15, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,16, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new Oufiter(1,17, new List<int>{ 0, 1 }),
            new Oufiter(1,18, new List<int>{ 0, 1 }),
            new Oufiter(1,19, new List<int>{ 0, 1 }),
            new Oufiter(1,20, new List<int>{ 0, 1 }),
            new Oufiter(1,21, new List<int>{ 0, 1 }),
            new Oufiter(1,22, new List<int>{ 0, 1 }),
            new Oufiter(1,23, new List<int>{ 0, 1 }),
            new Oufiter(1,24, new List<int>{ 0, 1 }),
            new Oufiter(1,25, new List<int>{ 0, 1 }),
            new Oufiter(1,26, new List<int>{ 0, 1 }),
            new Oufiter(1,29, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(1,30, new List<int>{ 0 }),
            new Oufiter(1,31, new List<int>{ 0 }),
            new Oufiter(1,32, new List<int>{ 0 }),
            new Oufiter(1,33, new List<int>{ 0 }),
            new Oufiter(1,34, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,35, new List<int>{ 0 }),
            new Oufiter(1,37, new List<int>{ 0 }),
            new Oufiter(1,39, new List<int>{ 0, 1 }),
            new Oufiter(1,40, new List<int>{ 0, 1 }),
            new Oufiter(1,41, new List<int>{ 0, 1 }),
            new Oufiter(1,42, new List<int>{ 0, 1 }),
            new Oufiter(1,43, new List<int>{ 0 }),
            new Oufiter(1,44, new List<int>{ 0 }),
            new Oufiter(1,45, new List<int>{ 0 }),
            new Oufiter(1,46, new List<int>{ 0 }),
            new Oufiter(1,47, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,48, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,49, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,50, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(1,54, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(1,58, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(1,59, new List<int>{ 0 }),
            new Oufiter(1,60, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,61, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,62, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,63, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,64, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,65, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,66, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,67, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,68, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,69, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,70, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,71, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,72, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,74, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,75, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,76, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,77, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,78, new List<int>{ 0, 1 }),
            new Oufiter(1,79, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,80, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,82, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,83, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,84, new List<int>{ 0 }),
            new Oufiter(1,85, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,86, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,87, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,88, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,91, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(1,92, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,93, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,94, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,95, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(1,96, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,97, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,98, new List<int>{ 0 }),
            new Oufiter(1,99, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,100, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,103, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,105, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(1,106, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,108, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(1,110, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,117, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new Oufiter(1,119, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new Oufiter(1,124, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(1,125, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,127, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,128, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,131, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,133, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }),
            new Oufiter(1,136, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,137, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(1,138, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,140, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,141, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,142, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,143, new List<int>{ 0 }),
            new Oufiter(1,144, new List<int>{ 0 }),
            new Oufiter(1,147, new List<int>{ 0 }),
            new Oufiter(1,149, new List<int>{ 0 }),
            new Oufiter(1,150, new List<int>{ 0 }),
            new Oufiter(1,151, new List<int>{ 0 }),
            new Oufiter(1,152, new List<int>{ 0 }),
            new Oufiter(1,153, new List<int>{ 0 }),
            new Oufiter(1,154, new List<int>{ 0 }),
            new Oufiter(1,155, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,156, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,157, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,158, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,159, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,160, new List<int>{ 0 }),
            new Oufiter(1,161, new List<int>{ 0 }),
            new Oufiter(1,162, new List<int>{ 0 }),
            new Oufiter(1,163, new List<int>{ 0 }),
            new Oufiter(1,164, new List<int>{ 0 }),
            new Oufiter(1,165, new List<int>{ 0 }),
            new Oufiter(1,168, new List<int>{ 0 }),
            new Oufiter(1,171, new List<int>{ 0 }),
            new Oufiter(1,172, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,173, new List<int>{ 0 }),
            new Oufiter(1,177, new List<int>{ 0 }),
            new Oufiter(1,179, new List<int>{ 7, 6, 5, 4, 3, 2, 1, 0 }),
            new Oufiter(1,180, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }),
            new Oufiter(1,181, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,182, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,183, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,184, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,188, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,191, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,192, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,193, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,194, new List<int>{ 0 }),
            new Oufiter(1,196, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,197, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,198, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,199, new List<int>{ 0 }),
            new Oufiter(1,200, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,202, new List<int>{ 0 }),
            new Oufiter(1,203, new List<int>{ 0 }),
            new Oufiter(1,204, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,205, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,206, new List<int>{ 0 }),
            new Oufiter(1,207, new List<int>{ 0 }),
            new Oufiter(1,208, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,209, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,215, new List<int>{ 0, 2, 1 }),
            new Oufiter(1,216, new List<int>{ 0 }),
            new Oufiter(1,219, new List<int>{ 0 }),
            new Oufiter(1,220, new List<int>{ 0, 1 }),
            new Oufiter(1,221, new List<int>{ 0 })
        }; 
        public static readonly List<Oufiter> FMMasks = new List<Oufiter>
        {
            new Oufiter(1,1, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,2, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,3, new List<int>{ 0 }),
            new Oufiter(1,4, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,5, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,6, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,7, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,8, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,9, new List<int>{ 0 }),
            new Oufiter(1,10, new List<int>{ 0 }),
            new Oufiter(1,13, new List<int>{ 0 }),
            new Oufiter(1,14, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,15, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,16, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new Oufiter(1,17, new List<int>{ 0, 1 }),
            new Oufiter(1,18, new List<int>{ 0, 1 }),
            new Oufiter(1,19, new List<int>{ 0, 1 }),
            new Oufiter(1,20, new List<int>{ 0, 1 }),
            new Oufiter(1,21, new List<int>{ 0, 1 }),
            new Oufiter(1,22, new List<int>{ 0, 1 }),
            new Oufiter(1,23, new List<int>{ 0, 1 }),
            new Oufiter(1,24, new List<int>{ 0, 1 }),
            new Oufiter(1,25, new List<int>{ 0, 1 }),
            new Oufiter(1,26, new List<int>{ 0, 1 }),
            new Oufiter(1,29, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(1,30, new List<int>{ 0 }),
            new Oufiter(1,31, new List<int>{ 0 }),
            new Oufiter(1,32, new List<int>{ 0 }),
            new Oufiter(1,33, new List<int>{ 0 }),
            new Oufiter(1,34, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,37, new List<int>{ 0 }),
            new Oufiter(1,39, new List<int>{ 0, 1 }),
            new Oufiter(1,40, new List<int>{ 0, 1 }),
            new Oufiter(1,41, new List<int>{ 0, 1 }),
            new Oufiter(1,42, new List<int>{ 0, 1 }),
            new Oufiter(1,43, new List<int>{ 0 }),
            new Oufiter(1,44, new List<int>{ 0 }),
            new Oufiter(1,45, new List<int>{ 0 }),
            new Oufiter(1,49, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,50, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(1,54, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(1,58, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(1,59, new List<int>{ 0 }),
            new Oufiter(1,60, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,61, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,62, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,63, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,64, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,65, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,66, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,67, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,68, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,69, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,70, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,71, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,72, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,74, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,75, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,76, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,77, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,78, new List<int>{ 0, 1 }),
            new Oufiter(1,79, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,80, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,81, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,82, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,83, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,84, new List<int>{ 0 }),
            new Oufiter(1,85, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,86, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,87, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,88, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,91, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(1,92, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,93, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,94, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,95, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(1,96, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,97, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,98, new List<int>{ 0 }),
            new Oufiter(1,99, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,100, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(1,103, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 22, 24, 25 }),
            new Oufiter(1,104, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,105, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(1,106, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,108, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(1,110, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,112, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 22, 23, 24, 25 }),
            new Oufiter(1,115, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25 }),
            new Oufiter(1,117, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new Oufiter(1,118, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,119, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new Oufiter(1,124, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23 }),
            new Oufiter(1,125, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,126, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new Oufiter(1,127, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,128, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15 }),
            new Oufiter(1,129, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new Oufiter(1,130, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 }),
            new Oufiter(1,131, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,133, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }),
            new Oufiter(1,135, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(1,136, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,137, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(1,138, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,139, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,140, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,141, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,142, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,143, new List<int>{ 0 }),
            new Oufiter(1,144, new List<int>{ 0 }),
            new Oufiter(1,147, new List<int>{ 0 }),
            new Oufiter(1,149, new List<int>{ 0 }),
            new Oufiter(1,150, new List<int>{ 0 }),
            new Oufiter(1,151, new List<int>{ 0 }),
            new Oufiter(1,152, new List<int>{ 0 }),
            new Oufiter(1,153, new List<int>{ 0 }),
            new Oufiter(1,154, new List<int>{ 0 }),
            new Oufiter(1,155, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,156, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,157, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,158, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,159, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,160, new List<int>{ 0 }),
            new Oufiter(1,161, new List<int>{ 0 }),
            new Oufiter(1,162, new List<int>{ 0 }),
            new Oufiter(1,163, new List<int>{ 0 }),
            new Oufiter(1,164, new List<int>{ 0 }),
            new Oufiter(1,165, new List<int>{ 0 }),
            new Oufiter(1,167, new List<int>{ 0 }),
            new Oufiter(1,168, new List<int>{ 0 }),
            new Oufiter(1,171, new List<int>{ 0 }),
            new Oufiter(1,172, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,173, new List<int>{ 0 }),
            new Oufiter(1,174, new List<int>{ 0 }),
            new Oufiter(1,176, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,177, new List<int>{ 0 }),
            new Oufiter(1,178, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new Oufiter(1,179, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(1,180, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }),
            new Oufiter(1,181, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,182, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,183, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(1,184, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,188, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(1,190, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,191, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,192, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,193, new List<int>{ 0 }),
            new Oufiter(1,196, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,197, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,198, new List<int>{ 0 }),
            new Oufiter(1,199, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,201, new List<int>{ 0 }),
            new Oufiter(1,202, new List<int>{ 0 }),
            new Oufiter(1,203, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(1,204, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,205, new List<int>{ 0 }),
            new Oufiter(1,206, new List<int>{ 0 }),
            new Oufiter(1,207, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,208, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(1,214, new List<int>{ 0, 1, 2 }),
            new Oufiter(1,215, new List<int>{ 0 }),
            new Oufiter(1,218, new List<int>{ 0 }),
            new Oufiter(1,219, new List<int>{ 0, 1 }),
            new Oufiter(1,220, new List<int>{ 0 })
        };

        public static readonly List<Oufiter> FeAcc = new List<Oufiter>
        {
            new Oufiter(7,1, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(7,2, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(7,3, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(7,4, new List<int>{ 2, 3 }),
            new Oufiter(7,5, new List<int>{ 4, 5 }),
            new Oufiter(7,6, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(7,7, new List<int>{ 0, 1 }),
            new Oufiter(7,9, new List<int>{ 0 }),
            new Oufiter(7,10, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,11, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,12, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,13, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(7,14, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,15, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,17, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,18, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,23, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,25, new List<int>{ 0 }),
            new Oufiter(7,29, new List<int>{ 0, 1 }),
            new Oufiter(7,30, new List<int>{ 0, 1 }),
            new Oufiter(7,31, new List<int>{ 0 }),
            new Oufiter(7,32, new List<int>{ 0, 1 }),
            new Oufiter(7,33, new List<int>{ 0, 1 }),
            new Oufiter(7,34, new List<int>{ 0, 1 }),
            new Oufiter(7,35, new List<int>{ 0, 1 }),
            new Oufiter(7,36, new List<int>{ 0, 1 }),
            new Oufiter(7,37, new List<int>{ 0, 1 }),
            new Oufiter(7,38, new List<int>{ 0 }),
            new Oufiter(7,39, new List<int>{ 0, 1 }),
            new Oufiter(7,40, new List<int>{ 0, 1 }),
            new Oufiter(7,41, new List<int>{ 0, 1 }),
            new Oufiter(7,42, new List<int>{ 0, 1 }),
            new Oufiter(7,53, new List<int>{ 0, 1 }),
            new Oufiter(7,54, new List<int>{ 0, 1 }),
            new Oufiter(7,55, new List<int>{ 0, 1 }),
            new Oufiter(7,56, new List<int>{ 0, 1 }),
            new Oufiter(7,57, new List<int>{ 0, 1 }),
            new Oufiter(7,58, new List<int>{ 0, 1 }),
            new Oufiter(7,59, new List<int>{ 0, 1 }),
            new Oufiter(7,60, new List<int>{ 0, 1 }),
            new Oufiter(7,61, new List<int>{ 0, 1 }),
            new Oufiter(7,62, new List<int>{ 0, 1 }),
            new Oufiter(7,64, new List<int>{ 0, 1 }),
            new Oufiter(7,65, new List<int>{ 0, 1 }),
            new Oufiter(7,66, new List<int>{ 0, 1 }),
            new Oufiter(7,67, new List<int>{ 0, 1 }),
            new Oufiter(7,68, new List<int>{ 0, 1 }),
            new Oufiter(7,69, new List<int>{ 0, 1 }),
            new Oufiter(7,70, new List<int>{ 0, 1 }),
            new Oufiter(7,71, new List<int>{ 0, 1 }),
            new Oufiter(7,72, new List<int>{ 0, 1 }),
            new Oufiter(7,73, new List<int>{ 0, 1 }),
            new Oufiter(7,81, new List<int>{ 0, 1 }),
            new Oufiter(7,82, new List<int>{ 0, 1 }),
            new Oufiter(7,83, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,84, new List<int>{ 0 }),
            new Oufiter(7,85, new List<int>{ 0 }),
            new Oufiter(7,89, new List<int>{ 0, 1 }),
            new Oufiter(7,90, new List<int>{ 0, 1 }),
            new Oufiter(7,91, new List<int>{ 0, 1 }),
            new Oufiter(7,92, new List<int>{ 0, 1 }),
            new Oufiter(7,93, new List<int>{ 0, 1 }),
            new Oufiter(7,94, new List<int>{ 0, 1 }),
            new Oufiter(7,96, new List<int>{ 0 }),
            new Oufiter(7,97, new List<int>{ 0 }),
            new Oufiter(7,98, new List<int>{ 0 }),
            new Oufiter(7,99, new List<int>{ 0 }),
            new Oufiter(7,100, new List<int>{ 0 }),
            new Oufiter(7,101, new List<int>{ 0 }),
            new Oufiter(7,103, new List<int>{ 0 }),
            new Oufiter(7,104, new List<int>{ 0 }),
            new Oufiter(7,105, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,106, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,107, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,108, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,109, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,110, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(7,111, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,112, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,113, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,114, new List<int>{ 0, 1, 2 }),
            new Oufiter(7,120, new List<int>{ 0 }),
            new Oufiter(7,123, new List<int>{ 0 }),
            new Oufiter(7,124, new List<int>{ 0 }),
            new Oufiter(7,125, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(7,126, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(7,127, new List<int>{ 0 }),
            new Oufiter(7,128, new List<int>{ 0 }),
            new Oufiter(7,129, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,130, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,131, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,132, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,133, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,134, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(7,135, new List<int>{ 0, 1 })
        };
        public static readonly List<Oufiter> FeShoeFlat = new List<Oufiter>
        {
            new Oufiter(6,1, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,2, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,3, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15 }),
            new Oufiter(6,4, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,5, new List<int>{ 0, 1, 2, 10, 13 }),
            new Oufiter(6,9, new List<int>{ 1, 2, 3, 11, 12 }),
            new Oufiter(6,10, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,11, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,13, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,15, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,16, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,17, new List<int>{ 0 }),
            new Oufiter(6,21, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(6,24, new List<int>{ 0 }),
            new Oufiter(6,25, new List<int>{ 0 }),
            new Oufiter(6,26, new List<int>{ 0 }),
            new Oufiter(6,27, new List<int>{ 0 }),
            new Oufiter(6,28, new List<int>{ 0 }),
            new Oufiter(6,29, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,31, new List<int>{ 0 }),
            new Oufiter(6,32, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(6,33, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,35, new List<int>{ 0 }),
            new Oufiter(6,36, new List<int>{ 0, 1 }),
            new Oufiter(6,37, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,38, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(6,39, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(6,45, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(6,46, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(6,47, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new Oufiter(6,48, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,49, new List<int>{ 0, 1 }),
            new Oufiter(6,50, new List<int>{ 0, 1 }),
            new Oufiter(6,51, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(6,52, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(6,53, new List<int>{ 0, 1 }),
            new Oufiter(6,54, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(6,55, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new Oufiter(6,56, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,57, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,58, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(6,59, new List<int>{ 0, 1 }),
            new Oufiter(6,60, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,61, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,62, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,63, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,64, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,65, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,66, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,67, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,68, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new Oufiter(6,69, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new Oufiter(6,71, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,72, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,73, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,74, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,75, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,76, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 25 }),
            new Oufiter(6,78, new List<int>{ 0, 1 }),
            new Oufiter(6,79, new List<int>{ 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,80, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,81, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,82, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,83, new List<int>{ 0, 1 }),
            new Oufiter(6,84, new List<int>{ 0, 1 }),
            new Oufiter(6,85, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,86, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,87, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19 }),
            new Oufiter(6,88, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,89, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,90, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,91, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new Oufiter(6,92, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,93, new List<int>{ 0 }),
            new Oufiter(6,94, new List<int>{ 0 }),
            new Oufiter(6,95, new List<int>{ 0 }),
            new Oufiter(6,96, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 12, 14 }),
            new Oufiter(6,97, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new Oufiter(6,98, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,99, new List<int>{ 0 }),
            new Oufiter(6,100, new List<int>{ 0 }),
            new Oufiter(6,101, new List<int>{ 0 }),
            new Oufiter(6,102, new List<int>{ 0 }),
            new Oufiter(6,103, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(6,104, new List<int>{ 0, 1 }),
            new Oufiter(6,105, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,107, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,108, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,109, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,110, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new Oufiter(6,111, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new Oufiter(6,112, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new Oufiter(6,113, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new Oufiter(6,115, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,116, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,117, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new Oufiter(6,118, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,119, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,120, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,121, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 23, 25 }),
            new Oufiter(6,122, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,123, new List<int>{ 0 }),
            new Oufiter(6,124, new List<int>{ 0 }),
            new Oufiter(6,125, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,126, new List<int>{ 0, 1 }),
            new Oufiter(6,127, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(6,128, new List<int>{ 0, 1 }),
            new Oufiter(6,129, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,130, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,131, new List<int>{ 0 })
        };
        public static readonly List<Oufiter> FeShoeHigh = new List<Oufiter>
        {
            new Oufiter(6,0, new List<int>{ 0, 1, 2, 3, 4 }),
            new Oufiter(6,6, new List<int>{ 0, 1, 2, 3 }),
            new Oufiter(6,7, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,8, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,14, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,19, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,20, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,22, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new Oufiter(6,23, new List<int>{ 0, 1, 2 }),
            new Oufiter(6,30, new List<int>{ 0 }),
            new Oufiter(6,42, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new Oufiter(6,43, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,44, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new Oufiter(6,77, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 })
        };
        public static readonly List<Oufiter> FeTrousers = new List<Oufiter>
        {
            new Oufiter(4,0, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,1, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,2, new List<int>{ 0, 1, 2}),
            new Oufiter(4,3, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,4, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,5, new List<int>{ 8, 14, 15}),
            new Oufiter(4,6, new List<int>{ 0, 1, 2}),
            new Oufiter(4,7, new List<int>{ 0, 1, 2}),
            new Oufiter(4,8, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15}),
            new Oufiter(4,9, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,10, new List<int>{ 0, 1, 2}),
            new Oufiter(4,11, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,12, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,14, new List<int>{ 0, 1, 8, 9}),
            new Oufiter(4,15, new List<int>{ 0}),
            new Oufiter(4,16, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,17, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,18, new List<int>{ 0, 1}),
            new Oufiter(4,19, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,20, new List<int>{ 0, 1, 2}),
            new Oufiter(4,22, new List<int>{ 0, 1, 2}),
            new Oufiter(4,23, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}),
            new Oufiter(4,24, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}),
            new Oufiter(4,25, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}),
            new Oufiter(4,26, new List<int>{ 0}),
            new Oufiter(4,27, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,28, new List<int>{ 0}),
            new Oufiter(4,30, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,31, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,34, new List<int>{ 0}),
            new Oufiter(4,36, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,37, new List<int>{ 0, 1, 2, 3, 4, 5, 6}),
            new Oufiter(4,41, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,43, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,44, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,45, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,47, new List<int>{ 0, 1, 2, 3, 4, 5, 6}),
            new Oufiter(4,48, new List<int>{ 0, 1}),
            new Oufiter(4,49, new List<int>{ 0, 1}),
            new Oufiter(4,50, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,51, new List<int>{ 0, 1, 2, 3, 4}),
            new Oufiter(4,52, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,53, new List<int>{ 0}),
            new Oufiter(4,54, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,55, new List<int>{ 0}),
            new Oufiter(4,56, new List<int>{ 0, 1, 2, 3, 4, 5}),
            new Oufiter(4,58, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,60, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,62, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,63, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,64, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,66, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}),
            new Oufiter(4,67, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}),
            new Oufiter(4,71, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17}),
            new Oufiter(4,73, new List<int>{ 0, 1, 2, 3, 4, 5}),
            new Oufiter(4,74, new List<int>{ 0, 1, 2, 3, 4, 5}),
            new Oufiter(4,75, new List<int>{ 0, 1, 2}),
            new Oufiter(4,76, new List<int>{ 0, 1, 2}),
            new Oufiter(4,77, new List<int>{ 0, 1, 2}),
            new Oufiter(4,78, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,80, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7}),
            new Oufiter(4,81, new List<int>{ 0, 1, 2}),
            new Oufiter(4,82, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7}),
            new Oufiter(4,83, new List<int>{ 0, 1, 2}),
            new Oufiter(4,84, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}),
            new Oufiter(4,85, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,87, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,88, new List<int>{ 0, 1, 2}),
            new Oufiter(4,89, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23}),
            new Oufiter(4,91, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23}),
            new Oufiter(4,92, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,93, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}),
            new Oufiter(4,97, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,98, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,99, new List<int>{ 0, 1}),
            new Oufiter(4,101, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,102, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}),
            new Oufiter(4,104, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}),
            new Oufiter(4,106, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7}),
            new Oufiter(4,107, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,108, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,109, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17}),
            new Oufiter(4,110, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17}),
            new Oufiter(4,111, new List<int>{ 0}),
            new Oufiter(4,112, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}),
            new Oufiter(4,113, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19}),
            new Oufiter(4,123, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}),
            new Oufiter(4,124, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,126, new List<int>{ 0, 1}),
            new Oufiter(4,128, new List<int>{ 0}),
            new Oufiter(4,130, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19}),
            new Oufiter(4,133, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19, 20, 21, 22, 23, 24}),
            new Oufiter(4,134, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,135, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7}),
            new Oufiter(4,137, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
            new Oufiter(4,138, new List<int>{ 0}),
            new Oufiter(4,139, new List<int>{ 0, 1, 2, 3}),
            new Oufiter(4,140, new List<int>{ 0}),
            new Oufiter(4,143, new List<int>{ 0, 1}),
            new Oufiter(4,145, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,146, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,147, new List<int>{ 0, 1, 2}),
            new Oufiter(4,148, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,149, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21}),
            new Oufiter(4,150, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,152, new List<int>{ 0, 1}),
            new Oufiter(4,154, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,155, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 11, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,156, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}),
            new Oufiter(4,159, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,160, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}),
            new Oufiter(4,161, new List<int>{ 0, 1}),
            new Oufiter(4,162, new List<int>{ 0}),
            new Oufiter(4,163, new List<int>{ 0}),
            new Oufiter(4,166, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 }),
            new Oufiter(4,167, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new Oufiter(4,168, new List<int>{ 0, 1, 2, 3})
        };
        public static readonly List<OufiterTop> FeTops = new List<OufiterTop>
        {
            new OufiterTop(11,0,0, new List<int>{ 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,5,1, new List<int>{ 0, 5, 6, 9, 11, 14 }),
            new OufiterTop(11,2,2, new List<int>{ 0 }),
            new OufiterTop(11,3,3, new List<int>{ 0 }),
            new OufiterTop(11,4,4, new List<int>{ 13 }),
            new OufiterTop(11,4,5, new List<int>{ 0 }),
            new OufiterTop(11,5,6, new List<int>{ 0 }),
            new OufiterTop(11,5,7, new List<int>{ 0 }),
            new OufiterTop(11,5,8, new List<int>{ 0, 12 }),
            new OufiterTop(11,0,9, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new OufiterTop(11,5,10, new List<int>{ 0, 13, 15 }),
            new OufiterTop(11,4,11, new List<int>{ 0, 10, 11, 15 }),
            new OufiterTop(11,15,12, new List<int>{ 7, 8, 9 }),
            new OufiterTop(11,15,13, new List<int>{ 0, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,0,14, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 12, 14, 15 }),
            new OufiterTop(11,15,15, new List<int>{ 0, 3, 10, 11 }),
            new OufiterTop(11,15,16, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,0,17, new List<int>{ 0 }),
            new OufiterTop(11,15,18, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,0,19, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,5,20, new List<int>{ 0, 1 }),
            new OufiterTop(11,15,21, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,22, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,0,23, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,5,24, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,5,25, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,12,26, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }),
            new OufiterTop(11,2,30, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,5,31, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,4,32, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,4,33, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new OufiterTop(11,5,34, new List<int>{ 0 }),
            new OufiterTop(11,5,35, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,4,36, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,4,37, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,2,38, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,0,39, new List<int>{ 0 }),
            new OufiterTop(11,2,40, new List<int>{ 0, 1 }),
            new OufiterTop(11,3,42, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,3,43, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,3,44, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,3,45, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,14,49, new List<int>{ 0, 1 }),
            new OufiterTop(11,14,50, new List<int>{ 0 }),
            new OufiterTop(11,15,51, new List<int>{ 0 }),
            new OufiterTop(11,15,52, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,53, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,0,54, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,0,55, new List<int>{ 0 }),
            new OufiterTop(11,6,57, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new OufiterTop(11,6,58, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new OufiterTop(11,0,62, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,0,63, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,6,64, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,65, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,6,66, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,2,67, new List<int>{ 0 }),
            new OufiterTop(11,14,68, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }),
            new OufiterTop(11,1,69, new List<int>{ 0 }),
            new OufiterTop(11,1,70, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,1,71, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,1,72, new List<int>{ 0 }),
            new OufiterTop(11,15,74, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,2,76, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,2,77, new List<int>{ 0 }),
            new OufiterTop(11,2,78, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,2,79, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,2,80, new List<int>{ 0 }),
            new OufiterTop(11,2,81, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,1,83, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,0,84, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,2,87, new List<int>{ 0 }),
            new OufiterTop(11,0,88, new List<int>{ 0, 1 }),
            new OufiterTop(11,6,90, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,91, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,92, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,93, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,94, new List<int>{ 0 }),
            new OufiterTop(11,6,95, new List<int>{ 0 }),
            new OufiterTop(11,0,96, new List<int>{ 0 }),
            new OufiterTop(11,6,97, new List<int>{ 0 }),
            new OufiterTop(11,6,98, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,99, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,15,101, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,3,102, new List<int>{ 0 }),
            new OufiterTop(11,6,104, new List<int>{ 0 }),
            new OufiterTop(11,15,105, new List<int>{ 0 }),
            new OufiterTop(11,6,106, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,107, new List<int>{ 0 }),
            new OufiterTop(11,6,108, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,6,109, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,6,110, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,15,111, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,15,112, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,113, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,114, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,115, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,116, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,118, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,2,119, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,6,120, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }),
            new OufiterTop(11,6,121, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }),
            new OufiterTop(11,3,122, new List<int>{ 0 }),
            new OufiterTop(11,3,123, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,14,125, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,126, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,14,127, new List<int>{ 0 }),
            new OufiterTop(11,14,128, new List<int>{ 0 }),
            new OufiterTop(11,14,131, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,14,132, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,6,133, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,3,135, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,6,137, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new OufiterTop(11,6,138, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,6,139, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,3,140, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,141, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,14,142, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,12,143, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,3,145, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,7,146, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,0,147, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,6,148, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,3,149, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,3,150, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,2,151, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,7,152, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,153, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,154, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,155, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,156, new List<int>{ 0, 1 }),
            new OufiterTop(11,15,157, new List<int>{ 0, 1 }),
            new OufiterTop(11,15,158, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,159, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,160, new List<int>{ 0 }),
            new OufiterTop(11,9,161, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,0,162, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,15,163, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,164, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,15,166, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,167, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,168, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,169, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,170, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,171, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,3,172, new List<int>{ 0, 1 }),
            new OufiterTop(11,15,173, new List<int>{ 0 }),
            new OufiterTop(11,15,174, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,175, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,178, new List<int>{ 0 }),
            new OufiterTop(11,0,180, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,15,181, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,15,182, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,183, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,3,184, new List<int>{ 0, 1 }),
            new OufiterTop(11,6,185, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,6,186, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,187, new List<int>{ 0, 1, 2, 3 }),
            new OufiterTop(11,6,189, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }),
            new OufiterTop(11,6,190, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,6,191, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,0,192, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,193, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,194, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,4,195, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19, 18, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,196, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,0,197, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,0,198, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,0,199, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,0,200, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,0,201, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,3,202, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,-1,203, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,204, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,14,205, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,206, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }),
            new OufiterTop(11,4,207, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,4,209, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }),
            new OufiterTop(11,4,210, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,4,211, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,0,212, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,5,216, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,11,217, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,9,218, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,219, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,220, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,221, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,222, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,223, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,225, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,15,229, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,14,230, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,11,233, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,6,234, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,14,236, new List<int>{ 0 }),
            new OufiterTop(11,14,239, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,15,240, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,15,242, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,15,243, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,245, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,15,247, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,5,248, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,14,249, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,14,251, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,7,252, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 13, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,253, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,-1,254, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,16,255, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,9,256, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,257, new List<int>{ 0, 1 }),
            new OufiterTop(11,0,259, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,262, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new OufiterTop(11,0,264, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,265, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,6,266, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,6,267, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new OufiterTop(11,0,268, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,269, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,5,270, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,0,271, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15 }),
            new OufiterTop(11,6,273, new List<int>{ 0, 1, 2, 4, 3, 5, 6, 7, 8, 9, 11, 10, 12, 13, 14, 15 }),
            new OufiterTop(11,6,275, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new OufiterTop(11,6,276, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,277, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,6,278, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,15,279, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,14,280, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new OufiterTop(11,15,283, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,15,284, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,14,285, new List<int>{ 0 }),
            new OufiterTop(11,14,286, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }),
            new OufiterTop(11,-1,287, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }),
            new OufiterTop(11,14,288, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,14,289, new List<int>{ 0, 1, 2, 3, 4, 5, 7, 8, 9, 11 }),
            new OufiterTop(11,14,292, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new OufiterTop(11,14,294, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,14,300, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,14,301, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,11,302, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,11,303, new List<int>{ 0 }),
            new OufiterTop(11,5,304, new List<int>{ 0 }),
            new OufiterTop(11,6,305, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,6,306, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,6,307, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,308, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,309, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new OufiterTop(11,0,310, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,311, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,314, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,315, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,0,316, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,318, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }),
            new OufiterTop(11,0,319, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,6,320, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,15,321, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new OufiterTop(11,11,322, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,11,323, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,324, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new OufiterTop(11,3,325, new List<int>{ 0, 1 }),
            new OufiterTop(11,3,326, new List<int>{ 0, 1 }),
            new OufiterTop(11,11,334, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new OufiterTop(11,14,335, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,14,337, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }),
            new OufiterTop(11,14,338, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,5,339, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,5,340, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,5,341, new List<int>{ 0 }),
            new OufiterTop(11,5,343, new List<int>{ 0 }),
            new OufiterTop(11,5,347, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,0,349, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }),
            new OufiterTop(11,6,353, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,6,354, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }),
            new OufiterTop(11,6,355, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,6,356, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,9,359, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,0,360, new List<int>{ 0, 1, 2, 3, 4, 5, 6 }),
            new OufiterTop(11,15,364, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,365, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,368, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,369, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,14,370, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,373, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,14,376, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,377, new List<int>{ 0, 1, 2, 3, 4, 5 }),
            new OufiterTop(11,15,379, new List<int>{ 0 }),
            new OufiterTop(11,15,381, new List<int>{ 0 }),
            new OufiterTop(11,15,384, new List<int>{ 1 }),
            new OufiterTop(11,15,385, new List<int>{ 1 }),
            new OufiterTop(11,15,386, new List<int>{ 7 }),
            new OufiterTop(11,11,388, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,11,389, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,11,390, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
            new OufiterTop(11,-1,391, new List<int>{ 0, 1 }),
            new OufiterTop(11,2,392, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new OufiterTop(11,2,394, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,14,395, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
            new OufiterTop(11,14,396, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
            new OufiterTop(11,14,397, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,6,399, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }),
            new OufiterTop(11,0,400, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 }),
            new OufiterTop(11,6,403, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,4,404, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,4,405, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }),
            new OufiterTop(11,0,406, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,411, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,6,412, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,0,413, new List<int>{ 0, 1, 2, 3, 4 }),
            new OufiterTop(11,12,416, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,12,417, new List<int>{ 0 }),
            new OufiterTop(11,12,418, new List<int>{ 0 }),
            new OufiterTop(11,12,419, new List<int>{ 0 }),
            new OufiterTop(11,12,420, new List<int>{ 0 }),
            new OufiterTop(11,12,422, new List<int>{ 0 }),
            new OufiterTop(11,12,423, new List<int>{ 0 }),
            new OufiterTop(11,12,424, new List<int>{ 0 }),
            new OufiterTop(11,12,425, new List<int>{ 0 }),
            new OufiterTop(11,12,426, new List<int>{ 0 }),
            new OufiterTop(11,15,428, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,15,429, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,430, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }),
            new OufiterTop(11,14,431, new List<int>{ 0 }),
            new OufiterTop(11,15,433, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,434, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }),
            new OufiterTop(11,15,435, new List<int>{ 0 }),
            new OufiterTop(11,12,438, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,12,439, new List<int>{ 0 }),
            new OufiterTop(11,15,451, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,452, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }),
            new OufiterTop(11,15,456, new List<int>{ 0, 1 }),
            new OufiterTop(11,15,458, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,459, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }),
            new OufiterTop(11,7,460, new List<int>{ 0 }),
            new OufiterTop(11,6,461, new List<int>{ 0 }),
            new OufiterTop(11,6,466, new List<int>{ 0 }),
            new OufiterTop(11,0,470, new List<int>{ 0 }),
            new OufiterTop(11,14,471, new List<int>{ 0 }),
            new OufiterTop(11,15,473, new List<int>{ 0 }),
            new OufiterTop(11,15,474, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,475, new List<int>{ 0, 1, 2 }),
            new OufiterTop(11,15,480, new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }),
            new OufiterTop(11,15,481, new List<int>{ 0 })
        };

        public static readonly List<Tattoo> maleTats01 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_M", Name = "Painted Micro SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_M", Name = "Weapon King" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_M", Name = "Sniff Sniff" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_M", Name = "Charm Pattern" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_M", Name = "Witch & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_M", Name = "Pumpkin Bug" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_M", Name = "Sinner" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_M", Name = "Gray Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_M", Name = "Hood Heart" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_M", Name = "Los Santos Tag" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_M", Name = "Blessed Boombox" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_M", Name = "Chamberlain Hills" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_M", Name = "Smoking Barrels" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_M", Name = "Dollar Guns Crossed" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_M", Name = "Skull Surfer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_M", Name = "Speaker Tower" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_M", Name = "Record Shot" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_M", Name = "Record Head" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_M", Name = "Tropical Sorcerer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_M", Name = "Rose Panther" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_M", Name = "Paradise Ukulele" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_M", Name = "Paradise Nap" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_M", Name = "Wild Dancers" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_M", Name = "Space Rangers" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_M", Name = "Robot Bubblegum" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_M", Name = "LS Shield" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_M", Name = "Howitzer" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_M", Name = "Bananas Gone Bad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_M", Name = "Epsilon" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_M", Name = "Mount Chiliad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_M", Name = "Bigfoot" },//

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_M", Name = "Play Your Ace" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_M", Name = "The Table" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_M", Name = "Show Your Hand" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_M", Name = "Roll the Dice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_M", Name = "The Jolly Joker" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_M", Name = "Life's a Gamble" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_M", Name = "Photo Finish" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_M", Name = "Till Death Do Us Part" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_M", Name = "Snake Eyes" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_M", Name = "777" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_M", Name = "Wheel of Suits" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_M", Name = "Jackpot" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_M", Name = "Molon Labe" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_M", Name = "Dragon Slayer" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_M", Name = "Spartan and Horse" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_M", Name = "Spartan and Lion" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_M", Name = "Odin and Raven" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_M", Name = "Samurai Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_M", Name = "Weathered Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_M", Name = "Spartan Shield" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_M", Name = "Norse Rune" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_M", Name = "Ghost Dragon" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_M", Name = "Kabuto" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_M", Name = "Claimed By The Beast" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_M", Name = "Pirate Captain" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_M", Name = "X Marks The Spot" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_M", Name = "Finders Keepers" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_M", Name = "Framed Tall Ship" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_M", Name = "Skull Compass" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_M", Name = "Torn Wings" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_M", Name = "Tall Ship Conflict" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_M", Name = "Never Surrender" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_M", Name = "Give Nothing Back" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_M", Name = "Eagle Eyes" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_M", Name = "Parachute Belle" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_M", Name = "Balloon Pioneer" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_M", Name = "Winged Bombshell" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_M", Name = "Pilot Skull" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_M", Name = "Explosive Heart" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_M", Name = "Pistol Wings" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_M", Name = "Dual Wield Skull" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_M", Name = "Backstabber" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_M", Name = "Wolf Insignia" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_M", Name = "Butterfly Knife" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_M", Name = "Crossed Weapons" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_M", Name = "Bullet Proof" },//

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_M", Name = "Talk Shit Get Hit" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_M", Name = "Take the Wheel" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_M", Name = "Serpents of Destruction" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_M", Name = "Tuned to Death" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_M", Name = "Power Plant" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_M", Name = "Block Back" },//

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_M", Name = "Ride Forever" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_M", Name = "Brothers For Life" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_M", Name = "Flaming Reaper" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_M", Name = "Clawed Beast" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_M", Name = "R.I.P. My Brothers" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_M", Name = "Freedom Wheels" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_M", Name = "Chopper Freedom" },//

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_M", Name = "Racing Doll" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_M", Name = "Full Throttle" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_M", Name = "Brapp" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_M", Name = "Monkey Chopper" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_M", Name = "Big Grills" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_M", Name = "Feather Road Kill" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_M", Name = "Man's Ruin" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_M", Name = "Majestic Finish" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_M", Name = "Winged Wheel" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_M", Name = "Road Kill" },//

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_M", Name = "Reign Over" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_M", Name = "Dead Pretty" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_M", Name = "Love the Game" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_M", Name = "SA Assault" },//

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_M", Name = "Sad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_M", Name = "Love is Blind" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_M", Name = "Bad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_M", Name = "Amazon" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_M", Name = "Geometric Design" },//   
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_M", Name = "Cloaked Angel" },//  
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_024_M", Name = "Feather Mural" },//    
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_006_M", Name = "Adorned Wolf" },//   

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_015", Name = "Japanese Warrior" },//  
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_011", Name = "Roaring Tiger" },//      
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_006", Name = "Carp Shaded" },//   
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_005", Name = "Carp Outline" },//   

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_046", Name = "Triangles" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_041", Name = "Tooth" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_032", Name = "Paper Plane" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_031", Name = "Skateboard" },//   
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_030", Name = "Shark Fin" },//
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_025", Name = "Watch Your Step" },//  
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_024", Name = "Pyamid" },//   
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_012", Name = "Antlers" },//  
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_011", Name = "Infinity" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_000", Name = "Crossed Arrows" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Back_000", Name = "Makin' Paper" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Back_000", Name = "Ship Arms" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_045", Name = "Skulls and Rose" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_030", Name = "Lucky Celtic Dogs" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_020", Name = "Dragon" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_019", Name = "The Wages of Sin" },//Survival Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_016", Name = "Evil Clown" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_013", Name = "Eagle and Serpent" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_011", Name = "LS Script" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_009", Name = "Skull on the Cross" },//

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_019", Name = "Clown Dual Wield Dollars" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_018", Name = "Clown Dual Wield" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_017", Name = "Clown and Gun" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_016", Name = "Clown" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_014", Name = "Trust No One" },//Car Bomb Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_008", Name = "Los Santos Customs" },//Mod a Car Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_005", Name = "Angel" },//Win Every Game Mode Award
          //Unknowen
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_046", Name = "Zip?" },//Zip???
            new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_M", Name = "Unknowen" }//
        };
        public static readonly List<Tattoo> maleTats02 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_M", Name = "Bullet Mouth" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_M", Name = "Smoking Barrel" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_M", Name = "Carved Pumpkin" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_M", Name = "Branched Werewolf" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_M", Name = "Winged Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_M", Name = "Shrieking Dragon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_M", Name = "Swords & City" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_M", Name = "All From The Same Tree" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_M", Name = "King of the Jungle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_M", Name = "Night Owl" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_M", Name = "Techno Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_M", Name = "Paradise Sirens" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_M", Name = "LS Panic" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_M", Name = "LS City" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_M", Name = "Dignity" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_M", Name = "Davis" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_M", Name = "Blood Money" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_M", Name = "Royal Flush" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_M", Name = "In the Pocket" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_M", Name = "Spartan Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_M", Name = "Medusa's Gaze" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_M", Name = "Strike Force" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_M", Name = "Native Warrior" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_M", Name = "Thor - Goblin" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_M", Name = "Dead Tales" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_M", Name = "Lost At Sea" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_M", Name = "No Honor" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_M", Name = "Bless The Dead" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_M", Name = "Turbulence" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_M", Name = "Micro SMG Chain" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_M", Name = "Crowned Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_M", Name = "Dog Tags" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_M", Name = "Dollar Daggers" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_M", Name = "We Are The Mods!" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_M", Name = "Faggio" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_M", Name = "Reaper Vulture" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_M", Name = "Unforgiven" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_M", Name = "No Regrets" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_M", Name = "Brotherhood of Bikes" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_M", Name = "Western Eagle" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_M", Name = "Bone Wrench" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_M", Name = "American Dream" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_M", Name = "Western MC" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_M", Name = "Gruesome Talons" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_M", Name = "Skeletal Chopper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_M", Name = "Demon Crossbones" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_M", Name = "Made In America" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_M", Name = "Both Barrels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_M", Name = "Demon Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_M", Name = "Ram Skull" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_M", Name = "Sugar Skull Trucker" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_M", Name = "Punk Road Hog" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_M", Name = "Engine Heart" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_M", Name = "Vintage Bully" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_M", Name = "Wheels of Death" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_M", Name = "Death Behind" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_M", Name = "Royal Kiss" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_M", Name = "Royal Takeover" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_M", Name = "Love Gamble" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_M", Name = "Holy Mary" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_M", Name = "King Fight" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_M", Name = "Cobra Dawn" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_M", Name = "Reaper Sway" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_M", Name = "Geometric Galaxy" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_M", Name = "The Howler" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_M", Name = "Smoking Sisters" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_M", Name = "Ancient Queen" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_M", Name = "Flying Eye" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_M", Name = "Eye of the Griffin" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_019", Name = "Royal Dagger Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_018", Name = "Royal Dagger Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_017", Name = "Loose Lips Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_016", Name = "Loose Lips Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_009", Name = "Time To Die" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_047", Name = "Cassette" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_033", Name = "Stag" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_013", Name = "Boombox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_002", Name = "Chemistry" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_001", Name = "$$$" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_000", Name = "Rich" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_001", Name = "Tribal Shark" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_000", Name = "Tribal Hammerhead" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_044", Name = "Stone Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_034", Name = "Flaming Shamrock" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_025", Name = "LS Bold" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_024", Name = "Flaming Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_010", Name = "LS Flames" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_013", Name = "Seven Deadly Sins" },//Kill 1000 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_012", Name = "Embellished Scroll" },//Kill 500 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_011", Name = "Blank Scroll" },////Kill 100 Players Award?
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_003", Name = "Blackjack" }
        };
        public static readonly List<Tattoo> maleTats03 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_M", Name = "Concealed" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_M", Name = "Cursed Saki" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_M", Name = "Smouldering Bat & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_M", Name = "Blaine County" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_M", Name = "Angry Possum" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_M", Name = "Floral Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_M", Name = "Beatbox Silhouette" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_M", Name = "Davis Flames" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_M", Name = "Radio Tape" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_M", Name = "Skeleton Breeze" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_M", Name = "LadyBug" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_M", Name = "Fatal Incursion" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_M", Name = "Gambling Royalty" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_M", Name = "Cash Mouth" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_M", Name = "Rose and Aces" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_M", Name = "Skull of Suits" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_M", Name = "Spartan Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_M", Name = "Jolly Roger" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_M", Name = "See You In Hell" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_M", Name = "Dead Lies" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_M", Name = "Bombs Away" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_M", Name = "Win Some Lose Some" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_M", Name = "Cash Money" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_M", Name = "Biker Mount" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_M", Name = "Gas Guzzler" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_M", Name = "Gear Head" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_M", Name = "Skull Of Taurus" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_M", Name = "Web Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_M", Name = "Bat Cat of Spades" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_M", Name = "Punk Biker" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_M", Name = "Two Face" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_M", Name = "Lady Liberty" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_M", Name = "Gun Mic" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_M", Name = "Abstract Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_028", Name = "Executioner" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_013", Name = "Lizard" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_035", Name = "Sewn Heart" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_029", Name = "Sad" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_006", Name = "Feather Birds" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Stomach_000", Name = "Refined Hustler" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_001", Name = "Wheel" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_000", Name = "Swordfish" },


            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_036", Name = "Way of the Gun" },//500 Pistol kills Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_029", Name = "Trinity Knot" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_012", Name = "Los Santos Bills" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_004", Name = "Faith" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_004", Name = "Hustler" },//Make 50000 from betting Award
        };
        public static readonly List<Tattoo> maleTats04 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_M", Name = "Live Fast Mono" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_M", Name = "Live Fast Color" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_M", Name = "Branched Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_M", Name = "Scythed Corpse" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_M", Name = "Scythed Corpse & Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_M", Name = "Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_M", Name = "Pierced Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_M", Name = "Lip Drip" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_M", Name = "Skin Mask" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_M", Name = "Webbed Scythe" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_M", Name = "Oni Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_M", Name = "Bat Wings" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_M", Name = "Bright Diamond" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_M", Name = "Hustle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_M", Name = "Black Widow" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_M", Name = "Clubs" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_M", Name = "Diamonds" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_M", Name = "Hearts" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_M", Name = "Thong's Sword" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_M", Name = "Wanted" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_M", Name = "UFO" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_M", Name = "Teddy Bear" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_M", Name = "Stitches" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_M", Name = "Space Monkey" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_M", Name = "Sleepy" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_M", Name = "On/Off" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_M", Name = "LS Wings" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_M", Name = "LS Star" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_M", Name = "Razor Pop" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_M", Name = "Lipstick Kiss" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_M", Name = "Green Leaf" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_M", Name = "Knifed" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_M", Name = "Ice Cream" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_M", Name = "Two Horns" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_M", Name = "Crowned" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_M", Name = "Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_M", Name = "Bandage" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_M", Name = "Assault Rifle" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_M", Name = "Animal" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_M", Name = "Ace of Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_M", Name = "Five Stars" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_M", Name = "Thief" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_M", Name = "Sinner" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_M", Name = "Lock and Load" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_M", Name = "Western Stylized" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_M", Name = "FTW" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_M", Name = "Morbid Arachnid" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_M", Name = "Flaming Quad" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_M", Name = "Bat Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_M", Name = "Toxic Spider" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_M", Name = "Scorpion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_M", Name = "Stunt Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_029", Name = "Beautiful Death" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_025", Name = "Snake Head Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_024", Name = "Snake Head Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_007", Name = "Los Muertos" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_021", Name = "Geo Fox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_005", Name = "Beautiful Eye" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_003", Name = "$100" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_002", Name = "Script Dollar Sign" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_001", Name = "Bold Dollar Sign" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_000", Name = "Cash is King" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_002", Name = "Shark" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_001", Name = "Surfs Up" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_000", Name = "Little Fish" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_001", Name = "Surf LS" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_000", Name = "Pirate Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_000", Name = "Skull" }
        };
        public static readonly List<Tattoo> maleTats05 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_M", Name = "Bigness Chimp" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_M", Name = "Up-n-Atomizer Design" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_M", Name = "Rocket Launcher Girl" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_M", Name = "Laser Eyes Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_M", Name = "Classic Vampire" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_M", Name = "Demon Drummer" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_M", Name = "Skeleton Shot" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_M", Name = "Music Is The Remedy" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_M", Name = "Serpent Mic" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_M", Name = "Weed Knuckles" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_M", Name = "Scratch Panther" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_M", Name = "Mighty Thog" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_M", Name = "Tiger Heart" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_M", Name = "Banknote Rose" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_M", Name = "Can't Win Them All" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_M", Name = "Vice" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_M", Name = "Get Lucky" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_M", Name = "Suits" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_M", Name = "Cerberus" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_M", Name = "Winged Serpent" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_M", Name = "Katana" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_M", Name = "Spartan Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_M", Name = "Tiger and Mask" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_M", Name = "Viking Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_M", Name = "Mermaid's Curse" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_M", Name = "Horrors Of The Deep" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_M", Name = "Honor" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_M", Name = "Toxic Trails" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_M", Name = "Serpent Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_M", Name = "Praying Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_M", Name = "Blood Money" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_M", Name = "Spiked Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_M", Name = "Bandolier" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_M", Name = "Sidearm" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_M", Name = "Scarlett" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_M", Name = "Piston Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_M", Name = "Poison Scorpion" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_M", Name = "Muffler Helmet" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_M", Name = "Ride Hard Die Fast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_M", Name = "Chain Fist" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_M", Name = "Good Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_M", Name = "Live to Ride" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_M", Name = "Cranial Rose" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_M", Name = "Macabre Tree" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_M", Name = "Urban Stunter" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_M", Name = "Engine Arm" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_M", Name = "Kaboom" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_M", Name = "Stuntman's End" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_M", Name = "Tanked" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_M", Name = "Piston Head" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_M", Name = "Moonlight Ride" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_M", Name = "Big Cat" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_M", Name = "8 Eyed Skull" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_M", Name = "My Crazy Life" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_M", Name = "Skeleton Party" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_M", Name = "Love Hustle" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_M", Name = "City Sorrow" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_M", Name = "Los Santos Life" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_M", Name = "No Evil" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_M", Name = "Python Skull" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_M", Name = "Divine Goddess" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_M", Name = "Egyptian Mural" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_M", Name = "Fatal Dagger" },


            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_M", Name = "Gabriel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_M", Name = "Archangel and Mary" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_M", Name = "Floral Symmetry" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_021", Name = "Time's Up Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_020", Name = "Time's Up Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_012", Name = "8 Ball Skull" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_010", Name = "Electric Snake" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_000", Name = "Skull Rider" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_048", Name = "Peace" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_043", Name = "Triangle White" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_039", Name = "Sleeve" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_037", Name = "Sunrise" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_034", Name = "Stop" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_028", Name = "Thorny Rose" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_027", Name = "Padlock" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_026", Name = "Pizza" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_016", Name = "Lightning Bolt" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_015", Name = "Mustache" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_007", Name = "Bricks" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_003", Name = "Diamond Sparkle" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_001", Name = "All-Seeing Eye" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_000", Name = "$100 Bill" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_000", Name = "Tiki Tower" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_001", Name = "Mermaid L.S." },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_041", Name = "Dope Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_031", Name = "Lady M" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_015", Name = "Zodiac Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_006", Name = "Oriental Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_005", Name = "Serpents" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_015", Name = "Racing Brunette" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_007", Name = "Racing Blonde" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_001", Name = "Burning Heart" },//50 Death Match Award
                                                                                                                                          //not on list
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_M", Name = "Geometric Design" }
        };
        public static readonly List<Tattoo> maleTats06 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_M", Name = "Nothing Mini About It" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_M", Name = "Snake Revolver" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_M", Name = "Weapon Sleeve" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_M", Name = "Centipede" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_M", Name = "Fleshy Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_M", Name = "Armored Arm" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_M", Name = "Demon Smile" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_M", Name = "Angel & Devil" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_M", Name = "Death Is Certain" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_M", Name = "Hood Skeleton" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_M", Name = "Peacock" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_M", Name = "Ballas 4 Life" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_M", Name = "Ascension" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_M", Name = "Zombie Rhymes" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_M", Name = "Dog Fist" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_M", Name = "K.U.L.T.99.1 FM" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_M", Name = "Octopus Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_M", Name = "Shark Water" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_M", Name = "Still Slipping" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_M", Name = "Soulwax" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_M", Name = "Smiley Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_M", Name = "Skeleton DJ" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_M", Name = "Music Locker" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_M", Name = "LSUR" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_M", Name = "Lighthouse" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_M", Name = "Jellyfish Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_M", Name = "Tropical Dude" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_M", Name = "Headphone Splat" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_M", Name = "LS Monogram" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_M", Name = "Skull and Aces" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_M", Name = "Queen of Roses" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_M", Name = "The Gambler's Life" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_M", Name = "Lady Luck" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_M", Name = "Spartan Mural" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_M", Name = "Samurai Tallship" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_M", Name = "Muscle Tear" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_M", Name = "Feather Sleeve" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_M", Name = "Celtic Band" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_M", Name = "Tiger Headdress" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_M", Name = "Medusa" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_M", Name = "Stylized Kraken" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_M", Name = "Mutiny" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_M", Name = "Crackshot" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_M", Name = "Combat Reaper" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_M", Name = "Have a Nice Day" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_M", Name = "Grenade" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_M", Name = "Drive Forever" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_M", Name = "Engulfed Block" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_M", Name = "Dialed In" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_M", Name = "Mechanical Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_M", Name = "Mum" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_M", Name = "These Colors Don't Run" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_M", Name = "Snake Bike" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_M", Name = "Skull Chain" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_M", Name = "Grim Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_M", Name = "Eagle Emblem" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_M", Name = "Lady Mortality" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_M", Name = "Swooping Eagle" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_M", Name = "Seductive Mechanic" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_M", Name = "One Down Five Up" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_M", Name = "Biker Stallion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_M", Name = "Coffin Racer" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_M", Name = "Grave Vulture" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_M", Name = "Arachnid of Death" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_M", Name = "Poison Wrench" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_M", Name = "Black Tears" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_M", Name = "Loving Los Muertos" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_M", Name = "Lady Vamp" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_M", Name = "Seductress" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_M", Name = "Floral Print" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_M", Name = "Heavenly Deity" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_M", Name = "Intrometric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_M", Name = "Geisha Bloom" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_M", Name = "Mermaid Harpist" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_M", Name = "Floral Raven" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_027", Name = "Fuck Luck Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_026", Name = "Fuck Luck Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_023", Name = "You're Next Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_022", Name = "You're Next Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_008", Name = "Death Before Dishonor" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_004", Name = "Snake Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_003", Name = "Snake Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_045", Name = "Mesh Band" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_044", Name = "Triangle Black" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_036", Name = "Shapes" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_023", Name = "Smiley" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_022", Name = "Pencil" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_020", Name = "Geo Pattern" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_018", Name = "Origami" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_017", Name = "Eye Triangle" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_014", Name = "Spray Can" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_010", Name = "Horseshoe" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_008", Name = "Cube" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_004", Name = "Bone" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_001", Name = "Single Arrow" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_001", Name = "Green" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_000", Name = "Dollar Skull" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_001", Name = "Vespucci Beauty" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_000", Name = "Tribal Sun" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_047", Name = "Lion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_038", Name = "Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_028", Name = "Mermaid" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_027", Name = "Virgin Mary" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_018", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_014", Name = "Flower Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_003", Name = "Dragons and Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_001", Name = "Dragons" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_000", Name = "Brotherhood" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_010", Name = "Ride or Die" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_002", Name = "Grim Reaper Smoking Gun" },
                    //Not In List
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_M", Name = "Geometric Design" }
        };
        public static readonly List<Tattoo> maleTats07 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_M", Name = "Cobra Biker" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_M", Name = "Minimal SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_M", Name = "Minimal Advanced Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_M", Name = "Minimal Sniper Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_M", Name = "Many-eyed Goat" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_M", Name = "Mobster Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_M", Name = "Wounded Head" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_M", Name = "Stabbed Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_M", Name = "Tiger Blade" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_M", Name = "LS Smoking Cartridges" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_M", Name = "Trust" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_M", Name = "Soundwaves" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_M", Name = "Skull Waters" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_M", Name = "Glow Princess" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_M", Name = "Pineapple Skull" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_M", Name = "Tropical Serpent" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_M", Name = "Love Fist" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_M", Name = "8-Ball Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_M", Name = "One-armed Bandit" },//

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_M", Name = "Rose Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_M", Name = "Death Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_M", Name = "Stylized Tiger" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_M", Name = "Patriot Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_M", Name = "Laughing Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_M", Name = "Bone Cruiser" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_M", Name = "Ride Free" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_M", Name = "Scorched Soul" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_M", Name = "Engulfed Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_M", Name = "Bad Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_M", Name = "Ride or Die" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_M", Name = "Rose Tribute" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_M", Name = "Stunt Jesus" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_M", Name = "Quad Goblin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_M", Name = "Golden Cobra" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_M", Name = "Dirt Track Hero" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_M", Name = "Dagger Devil" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_M", Name = "Death Us Do Part" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_M", Name = "Presidents" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_M", Name = "LS Serpent" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_M", Name = "Cross of Roses" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_M", Name = "Serpent of Death" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_002", Name = "Spider Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_001", Name = "Spider Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_040", Name = "Black Anchor" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_019", Name = "Charm" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_009", Name = "Squares" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Lleg_000", Name = "Tribal Star" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_032", Name = "Faith" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_037", Name = "Grim Reaper" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_035", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_033", Name = "Chinese Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_026", Name = "Smoking Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_023", Name = "Hottie" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_021", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_008", Name = "Dragon Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_002", Name = "Melting Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_009", Name = "Dragon and Dagger" },
        };
        public static readonly List<Tattoo> maleTats08 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_M", Name = "Skull Grenade" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_M", Name = "Three-eyed Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_M", Name = "Smoldering Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_M", Name = "Gold Gun" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_M", Name = "Blue Serpent" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_M", Name = "Night Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_M", Name = "Bandana Knife" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_M", Name = "Graffiti Skull" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_M", Name = "Skullphones" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_M", Name = "Kifflom" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_M", Name = "Cash is King" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_M", Name = "Homeward Bound" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_M", Name = "Pistol Ace" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_M", Name = "Restless Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_M", Name = "Combat Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_M", Name = "STFU" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_M", Name = "American Made" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_M", Name = "Dusk Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_M", Name = "Western Insignia" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_M", Name = "Dragon's Fury" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_M", Name = "Brake Knife" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_M", Name = "Severed Hand" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_M", Name = "Wheelie Mouse" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_M", Name = "Speed Freak" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_M", Name = "Piston Angel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_M", Name = "Praying Gloves" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_M", Name = "Demon Spark Plug" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_M", Name = "San Andreas Prayer" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_M", Name = "Dance of Hearts" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_M", Name = "Ink Me" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_M", Name = "Starmetric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_M", Name = "Elaborate Los Muertos" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_014", Name = "Floral Dagger" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_042", Name = "Sparkplug" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_038", Name = "Grub" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Rleg_000", Name = "Tribal Tiki Tower" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_043", Name = "Indian Ram" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_042", Name = "Flaming Scorpion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_040", Name = "Flaming Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_039", Name = "Broken Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_022", Name = "Fiery Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_017", Name = "Tribal" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_007", Name = "The Warrior" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_006", Name = "Skull and Sword" }
        };

        public static readonly List<Tattoo> femaleTats01 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_F", Name = "Painted Micro SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_F", Name = "Weapon King" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_F", Name = "Sniff Sniff" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_F", Name = "Charm Pattern" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_F", Name = "Witch & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_F", Name = "Pumpkin Bug" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_F", Name = "Sinner" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_F", Name = "Gray Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_F", Name = "Hood Heart" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_F", Name = "Los Santos Tag" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_F", Name = "Blessed Boombox" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_F", Name = "Chamberlain Hills" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_F", Name = "Smoking Barrels" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_F", Name = "Dollar Guns Crossed" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_F", Name = "Skull Surfer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_F", Name = "Speaker Tower" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_F", Name = "Record Shot" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_F", Name = "Record Head" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_F", Name = "Tropical Sorcerer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_F", Name = "Rose Panther" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_F", Name = "Paradise Ukulele" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_F", Name = "Paradise Nap" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_F", Name = "Wild Dancers" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_F", Name = "Space Rangers" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_F", Name = "Robot Bubblegum" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_F", Name = "LS Shield" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_F", Name = "Howitzer" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_F", Name = "Bananas Gone Bad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_F", Name = "Epsilon" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_F", Name = "Mount Chiliad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_F", Name = "Bigfoot" },//

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_F", Name = "Play Your Ace" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_F", Name = "The Table" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_F", Name = "Show Your Hand" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_F", Name = "Roll the Dice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_F", Name = "The Jolly Joker" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_F", Name = "Life's a Gamble" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_F", Name = "Photo Finish" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_F", Name = "Till Death Do Us Part" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_F", Name = "Snake Eyes" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_F", Name = "777" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_F", Name = "Wheel of Suits" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_F", Name = "Jackpot" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_F", Name = "Molon Labe" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_F", Name = "Dragon Slayer" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_F", Name = "Spartan and Horse" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_F", Name = "Spartan and Lion" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_F", Name = "Odin and Raven" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_F", Name = "Samurai Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_F", Name = "Weathered Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_F", Name = "Spartan Shield" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_F", Name = "Norse Rune" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_F", Name = "Ghost Dragon" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_F", Name = "Kabuto" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_F", Name = "Claimed By The Beast" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_F", Name = "Pirate Captain" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_F", Name = "X Marks The Spot" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_F", Name = "Finders Keepers" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_F", Name = "Framed Tall Ship" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_F", Name = "Skull Compass" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_F", Name = "Torn Wings" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_F", Name = "Tall Ship Conflict" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_F", Name = "Never Surrender" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_F", Name = "Give Nothing Back" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_F", Name = "Eagle Eyes" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_F", Name = "Parachute Belle" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_F", Name = "Balloon Pioneer" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_F", Name = "Winged Bombshell" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_F", Name = "Pilot Skull" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_F", Name = "Explosive Heart" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_F", Name = "Pistol Wings" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_F", Name = "Dual Wield Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_F", Name = "Backstabber" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_F", Name = "Wolf Insignia" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_F", Name = "Butterfly Knife" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_F", Name = "Crossed Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_F", Name = "Bullet Proof" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_F", Name = "Talk Shit Get Hit" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_F", Name = "Take the Wheel" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_F", Name = "Serpents of Destruction" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_F", Name = "Tuned to Death" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_F", Name = "Power Plant" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_F", Name = "Block Back" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_F", Name = "Ride Forever" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_F", Name = "Brothers For Life" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_F", Name = "Flaming Reaper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_F", Name = "Clawed Beast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_F", Name = "R.I.P. My Brothers" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_F", Name = "Freedom Wheels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_F", Name = "Chopper Freedom" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_F", Name = "Racing Doll" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_F", Name = "Full Throttle" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_F", Name = "Brapp" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_F", Name = "Monkey Chopper" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_F", Name = "Big Grills" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_F", Name = "Feather Road Kill" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_F", Name = "Man's Ruin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_F", Name = "Majestic Finish" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_F", Name = "Winged Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_F", Name = "Road Kill" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_F", Name = "Reign Over" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_F", Name = "Dead Pretty" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_F", Name = "Love the Game" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_F", Name = "SA Assault" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_F", Name = "Sad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_F", Name = "Love is Blind" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_F", Name = "Bad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_F", Name = "Amazon" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_F", Name = "Geometric Design" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_F", Name = "Cloaked Angel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_024_F", Name = "Feather Mural" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_006_F", Name = "Adorned Wolf" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_015", Name = "Japanese Warrior" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_011", Name = "Roaring Tiger" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_006", Name = "Carp Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_005", Name = "Carp Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_046", Name = "Triangles" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_041", Name = "Tooth" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_032", Name = "Paper Plane" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_031", Name = "Skateboard" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_030", Name = "Shark Fin" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_025", Name = "Watch Your Step" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_024", Name = "Pyamid" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_012", Name = "Antlers" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_011", Name = "Infinity" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_000", Name = "Crossed Arrows" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_001", Name = "Gold Digger" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_000", Name = "Respect" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_000", Name = "Sea Horses" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_002", Name = "Shrimp" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_001", Name = "Catfish" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_000", Name = "Rock Solid" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_001", Name = "Hibiscus Flower Duo" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_045", Name = "Skulls and Rose" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_030", Name = "Lucky Celtic Dogs" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_020", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_019", Name = "The Wages of Sin" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_016", Name = "Evil Clown" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_013", Name = "Eagle and Serpent" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_011", Name = "LS Script" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_009", Name = "Skull on the Cross" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_019", Name = "Clown Dual Wield Dollars" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_018", Name = "Clown Dual Wield" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_017", Name = "Clown and Gun" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_016", Name = "Clown" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_014", Name = "Trust No One" },//Car Bomb Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_008", Name = "Los Santos Customs" },//Mod a Car Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_005", Name = "Angel" },//Win Every Game Mode Award
                                                                                                                              //Not In List
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_046", Name = "Zip?" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" },
            new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_F", Name = "???" }
        };
        public static readonly List<Tattoo> femaleTats02 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_F", Name = "Bullet Mouth" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_F", Name = "Smoking Barrel" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_F", Name = "Carved Pumpkin" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_F", Name = "Branched Werewolf" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_F", Name = "Winged Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_F", Name = "Shrieking Dragon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_F", Name = "Swords & City" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_F", Name = "All From The Same Tree" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_F", Name = "King of the Jungle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_F", Name = "Night Owl" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_F", Name = "Techno Glitch" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_F", Name = "Paradise Sirens" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_F", Name = "LS Panic" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_F", Name = "LS City" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_F", Name = "Dignity" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_F", Name = "Davis" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_F", Name = "Blood Money" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_F", Name = "Royal Flush" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_F", Name = "In the Pocket" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_F", Name = "Spartan Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_F", Name = "Medusa's Gaze" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_F", Name = "Strike Force" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_F", Name = "Native Warrior" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_F", Name = "Thor - Goblin" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_F", Name = "Dead Tales" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_F", Name = "Lost At Sea" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_F", Name = "No Honor" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_F", Name = "Bless The Dead" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_F", Name = "Turbulence" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_F", Name = "Micro SMG Chain" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_F", Name = "Crowned Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_F", Name = "Dog Tags" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_F", Name = "Dollar Daggers" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_F", Name = "We Are The Mods!" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_F", Name = "Faggio" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_F", Name = "Reaper Vulture" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_F", Name = "Unforgiven" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_F", Name = "No Regrets" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_F", Name = "Brotherhood of Bikes" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_F", Name = "Western Eagle" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_F", Name = "Bone Wrench" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_F", Name = "American Dream" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_F", Name = "Western MC" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_F", Name = "Gruesome Talons" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_F", Name = "Skeletal Chopper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_F", Name = "Demon Crossbones" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_F", Name = "Made In America" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_F", Name = "Both Barrels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_F", Name = "Demon Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_F", Name = "Ram Skull" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_F", Name = "Sugar Skull Trucker" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_F", Name = "Punk Road Hog" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_F", Name = "Engine Heart" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_F", Name = "Vintage Bully" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_F", Name = "Wheels of Death" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_F", Name = "Death Behind" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_F", Name = "Royal Kiss" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_F", Name = "Royal Takeover" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_F", Name = "Love Gamble" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_F", Name = "Holy Mary" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_F", Name = "King Fight" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_F", Name = "Cobra Dawn" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_F", Name = "Reaper Sway" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_F", Name = "Geometric Galaxy" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_F", Name = "The Howler" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_F", Name = "Smoking Sisters" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_F", Name = "Ancient Queen" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_F", Name = "Flying Eye" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_F", Name = "Eye of the Griffin" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_019", Name = "Royal Dagger Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_018", Name = "Royal Dagger Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_017", Name = "Loose Lips Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_016", Name = "Loose Lips Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_009", Name = "Time To Die" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_047", Name = "Cassette" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_033", Name = "Stag" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_013", Name = "Boombox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_002", Name = "Chemistry" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_002", Name = "Love Money" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_001", Name = "Makin' Money" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_000", Name = "High Roller" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_001", Name = "Anchor" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_000", Name = "Anchor" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_002", Name = "Los Santos Wreath" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_044", Name = "Stone Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_034", Name = "Flaming Shamrock" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_025", Name = "LS Bold" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_024", Name = "Flaming Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_010", Name = "LS Flames" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_013", Name = "Seven Deadly Sins" },//Kill 1000 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_012", Name = "Embellished Scroll" },//Kill 500 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_011", Name = "Blank Scroll" },////Kill 100 Players Award?
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_003", Name = "Blackjack" }
        };
        public static readonly List<Tattoo> femaleTats03 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_F", Name = "Concealed" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_F", Name = "Cursed Saki" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_F", Name = "Smouldering Bat & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_F", Name = "Blaine County" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_F", Name = "Angry Possum" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_F", Name = "Floral Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_F", Name = "Beatbox Silhouette" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_F", Name = "Davis Flames" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_F", Name = "Radio Tape" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_F", Name = "Skeleton Breeze" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_F", Name = "LadyBug" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_F", Name = "Fatal Incursion" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_F", Name = "Gambling Royalty" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_F", Name = "Cash Mouth" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_F", Name = "Rose and Aces" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_F", Name = "Skull of Suits" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_F", Name = "Spartan Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_F", Name = "Jolly Roger" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_F", Name = "See You In Hell" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_F", Name = "Dead Lies" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_F", Name = "Bombs Away" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_F", Name = "Win Some Lose Some" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_F", Name = "Cash Money" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_F", Name = "Biker Mount" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_F", Name = "Gas Guzzler" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_F", Name = "Gear Head" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_F", Name = "Skull Of Taurus" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_F", Name = "Web Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_F", Name = "Bat Cat of Spades" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_F", Name = "Punk Biker" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_F", Name = "Two Face" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_F", Name = "Lady Liberty" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_F", Name = "Gun Mic" },//

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_F", Name = "Abstract Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_028", Name = "Executioner" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_013", Name = "Lizard" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_035", Name = "Sewn Heart" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_029", Name = "Sad" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_002", Name = "Money Bag" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_001", Name = "Santo Capra Logo" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_000", Name = "Diamond Back" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_000", Name = "Swallow" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_002", Name = "Dolphin" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_001", Name = "Hibiscus Flower" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RSide_000", Name = "Love Dagger" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_036", Name = "Way of the Gun" },//500 Pistol kills Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_029", Name = "Trinity Knot" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_012", Name = "Los Santos Bills" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_004", Name = "Faith" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_004", Name = "Hustler" }
        };
        public static readonly List<Tattoo> femaleTats04 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_F", Name = "Live Fast Mono" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_F", Name = "Live Fast Color" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_F", Name = "Branched Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_F", Name = "Scythed Corpse" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_F", Name = "Scythed Corpse & Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_F", Name = "Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_F", Name = "Pierced Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_F", Name = "Lip Drip" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_F", Name = "Skin Mask" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_F", Name = "Webbed Scythe" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_F", Name = "Oni Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_F", Name = "Bat Wings" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_F", Name = "Bright Diamond" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_F", Name = "Hustle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_F", Name = "Black Widow" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_F", Name = "Clubs" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_F", Name = "Diamonds" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_F", Name = "Hearts" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_F", Name = "Thong's Sword" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_F", Name = "Wanted" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_F", Name = "UFO" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_F", Name = "Teddy Bear" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_F", Name = "Stitches" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_F", Name = "Space Monkey" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_F", Name = "Sleepy" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_F", Name = "On/Off" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_F", Name = "LS Wings" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_F", Name = "LS Star" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_F", Name = "Razor Pop" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_F", Name = "Lipstick Kiss" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_F", Name = "Green Leaf" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_F", Name = "Knifed" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_F", Name = "Ice Cream" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_F", Name = "Two Horns" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_F", Name = "Crowned" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_F", Name = "Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_F", Name = "Bandage" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_F", Name = "Assault Rifle" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_F", Name = "Animal" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_F", Name = "Ace of Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_F", Name = "Five Stars" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_F", Name = "Thief" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_F", Name = "Sinner" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_F", Name = "Lock and Load" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_F", Name = "Western Stylized" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_F", Name = "FTW" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_F", Name = "Morbid Arachnid" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_F", Name = "Flaming Quad" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_F", Name = "Bat Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_F", Name = "Toxic Spider" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_F", Name = "Scorpion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_F", Name = "Stunt Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_029", Name = "Beautiful Death" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_025", Name = "Snake Head Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_024", Name = "Snake Head Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_007", Name = "Los Muertos" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_021", Name = "Geo Fox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_005", Name = "Beautiful Eye" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_001", Name = "Money Rose" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_000", Name = "Val-de-Grace Logo" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Tribal Butterfly" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Little Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_000", Name = "Skull" }
        };
        public static readonly List<Tattoo> femaleTats05 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_F", Name = "Bigness Chimp" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_F", Name = "Up-n-Atomizer Design" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_F", Name = "Rocket Launcher Girl" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_F", Name = "Laser Eyes Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_F", Name = "Classic Vampire" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_F", Name = "Demon Drummer" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_F", Name = "Skeleton Shot" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_F", Name = "Music Is The Remedy" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_F", Name = "Serpent Mic" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_F", Name = "Weed Knuckles" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_F", Name = "Scratch Panther" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_F", Name = "Mighty Thog" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_F", Name = "Tiger Heart" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_F", Name = "Banknote Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_F", Name = "Can't Win Them All" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_F", Name = "Vice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_F", Name = "Get Lucky" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_F", Name = "Suits" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_F", Name = "Cerberus" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_F", Name = "Winged Serpent" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_F", Name = "Katana" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_F", Name = "Spartan Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_F", Name = "Tiger and Mask" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_F", Name = "Viking Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_F", Name = "Mermaid's Curse" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_F", Name = "Horrors Of The Deep" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_F", Name = "Honor" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_F", Name = "Toxic Trails" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_F", Name = "Serpent Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_F", Name = "Praying Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_F", Name = "Blood Money" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_F", Name = "Spiked Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_F", Name = "Bandolier" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_F", Name = "Sidearm" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_F", Name = "Scarlett" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_F", Name = "Piston Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_F", Name = "Poison Scorpion" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_F", Name = "Muffler Helmet" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_F", Name = "Ride Hard Die Fast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_F", Name = "Chain Fist" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_F", Name = "Good Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_F", Name = "Live to Ride" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_F", Name = "Cranial Rose" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_F", Name = "Macabre Tree" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_F", Name = "Urban Stunter" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_F", Name = "Engine Arm" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_F", Name = "Kaboom" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_F", Name = "Stuntman's End" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_F", Name = "Tanked" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_F", Name = "Piston Head" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_F", Name = "Moonlight Ride" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_F", Name = "Big Cat" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_F", Name = "8 Eyed Skull" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_F", Name = "My Crazy Life" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_F", Name = "Skeleton Party" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_F", Name = "Love Hustle" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_F", Name = "City Sorrow" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_F", Name = "Los Santos Life" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_F", Name = "No Evil" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_F", Name = "Python Skull" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_F", Name = "Divine Goddess" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_F", Name = "Egyptian Mural" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_F", Name = "Fatal Dagger" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_F", Name = "Gabriel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_F", Name = "Archangel and Mary" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_F", Name = "Floral Symmetry" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_021", Name = "Time's Up Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_020", Name = "Time's Up Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_012", Name = "8 Ball Skull" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_010", Name = "Electric Snake" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_000", Name = "Skull Rider" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_048", Name = "Peace" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_043", Name = "Triangle White" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_039", Name = "Sleeve" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_037", Name = "Sunrise" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_034", Name = "Stop" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_028", Name = "Thorny Rose" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_027", Name = "Padlock" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_026", Name = "Pizza" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_016", Name = "Lightning Bolt" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_015", Name = "Mustache" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_007", Name = "Bricks" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_003", Name = "Diamond Sparkle" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LArm_000", Name = "Greed is Good" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_001", Name = "Parrot" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_000", Name = "Tribal Flower" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_041", Name = "Dope Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_031", Name = "Lady M" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_015", Name = "Zodiac Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_006", Name = "Oriental Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_005", Name = "Serpents" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_015", Name = "Racing Brunette" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_007", Name = "Racing Blonde" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_001", Name = "Burning Heart" },//50 Death Match Award
                                                                                                                                      //not on list
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_F", Name = "Geometric Design" }
        };
        public static readonly List<Tattoo> femaleTats06 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_F", Name = "Nothing Mini About It" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_F", Name = "Snake Revolver" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_F", Name = "Weapon Sleeve" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_F", Name = "Centipede" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_F", Name = "Fleshy Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_F", Name = "Armored Arm" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_F", Name = "Demon Smile" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_F", Name = "Angel & Devil" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_F", Name = "Death Is Certain" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_F", Name = "Hood Skeleton" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_F", Name = "Peacock" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_F", Name = "Ballas 4 Life" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_F", Name = "Ascension" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_F", Name = "Zombie Rhymes" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_F", Name = "Dog Fist" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_F", Name = "K.U.L.T.99.1 FM" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_F", Name = "Octopus Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_F", Name = "Shark Water" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_F", Name = "Still Slipping" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_F", Name = "Soulwax" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_F", Name = "Smiley Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_F", Name = "Skeleton DJ" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_F", Name = "Music Locker" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_F", Name = "LSUR" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_F", Name = "Lighthouse" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_F", Name = "Jellyfish Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_F", Name = "Tropical Dude" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_F", Name = "Headphone Splat" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_F", Name = "LS Monogram" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_F", Name = "Skull and Aces" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_F", Name = "Queen of Roses" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_F", Name = "The Gambler's Life" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_F", Name = "Lady Luck" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_F", Name = "Spartan Mural" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_F", Name = "Samurai Tallship" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_F", Name = "Muscle Tear" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_F", Name = "Feather Sleeve" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_F", Name = "Celtic Band" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_F", Name = "Tiger Headdress" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_F", Name = "Medusa" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_F", Name = "Stylized Kraken" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_F", Name = "Mutiny" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_F", Name = "Crackshot" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_F", Name = "Combat Reaper" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_F", Name = "Have a Nice Day" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_F", Name = "Grenade" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_F", Name = "Drive Forever" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_F", Name = "Engulfed Block" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_F", Name = "Dialed In" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_F", Name = "Mechanical Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_F", Name = "Mum" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_F", Name = "These Colors Don't Run" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_F", Name = "Snake Bike" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_F", Name = "Skull Chain" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_F", Name = "Grim Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_F", Name = "Eagle Emblem" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_F", Name = "Lady Mortality" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_F", Name = "Swooping Eagle" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_F", Name = "Seductive Mechanic" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_F", Name = "One Down Five Up" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_F", Name = "Biker Stallion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_F", Name = "Coffin Racer" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_F", Name = "Grave Vulture" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_F", Name = "Arachnid of Death" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_F", Name = "Poison Wrench" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_F", Name = "Black Tears" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_F", Name = "Loving Los Muertos" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_F", Name = "Lady Vamp" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_F", Name = "Seductress" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_F", Name = "Floral Print" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_F", Name = "Heavenly Deity" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_F", Name = "Intrometric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_F", Name = "Geisha Bloom" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_F", Name = "Mermaid Harpist" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_F", Name = "Floral Raven" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_027", Name = "Fuck Luck Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_026", Name = "Fuck Luck Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_023", Name = "You're Next Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_022", Name = "You're Next Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_008", Name = "Death Before Dishonor" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_004", Name = "Snake Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_003", Name = "Snake Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_045", Name = "Mesh Band" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_044", Name = "Triangle Black" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_036", Name = "Shapes" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_023", Name = "Smiley" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_022", Name = "Pencil" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_020", Name = "Geo Pattern" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_018", Name = "Origami" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_017", Name = "Eye Triangle" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_014", Name = "Spray Can" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_010", Name = "Horseshoe" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_008", Name = "Cube" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_004", Name = "Bone" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_001", Name = "Single Arrow" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RArm_000", Name = "Dollar Sign" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RArm_001", Name = "Tribal Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_047", Name = "Lion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_038", Name = "Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_028", Name = "Mermaid" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_027", Name = "Virgin Mary" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_018", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_014", Name = "Flower Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_003", Name = "Dragons and Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_001", Name = "Dragons" },
                //TatThis.Addnew Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_000", Name = "Brotherhood" } ,-empty load?

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_010", Name = "Ride or Die" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_002", Name = "Grim Reaper Smoking Gun" },//Clear 5 Gang Atacks in a Day Award
                                                                                                                                                //Not In List
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_F", Name = "Geometric Design" }
        };
        public static readonly List<Tattoo> femaleTats07 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_F", Name = "Cobra Biker" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_F", Name = "Minimal SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_F", Name = "Minimal Advanced Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_F", Name = "Minimal Sniper Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_F", Name = "Many-eyed Goat" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_F", Name = "Mobster Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_F", Name = "Wounded Head" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_F", Name = "Stabbed Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_F", Name = "Tiger Blade" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_F", Name = "LS Smoking Cartridges" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_F", Name = "Trust" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_F", Name = "Soundwaves" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_F", Name = "Skull Waters" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_F", Name = "Glow Princess" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_F", Name = "Pineapple Skull" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_F", Name = "Tropical Serpent" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_F", Name = "Love Fist" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_F", Name = "8-Ball Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_F", Name = "One-armed Bandit" },//

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_F", Name = "Rose Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_F", Name = "Death Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_F", Name = "Stylized Tiger" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_F", Name = "Patriot Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_F", Name = "Laughing Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_F", Name = "Bone Cruiser" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_F", Name = "Ride Free" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_F", Name = "Scorched Soul" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_F", Name = "Engulfed Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_F", Name = "Bad Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_F", Name = "Ride or Die" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_F", Name = "Rose Tribute" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_F", Name = "Stunt Jesus" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_F", Name = "Quad Goblin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_F", Name = "Golden Cobra" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_F", Name = "Dirt Track Hero" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_F", Name = "Dagger Devil" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_F", Name = "Death Us Do Part" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_F", Name = "Presidents" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_F", Name = "LS Serpent" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_F", Name = "Cross of Roses" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_F", Name = "Serpent of Death" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_002", Name = "Spider Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_001", Name = "Spider Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_040", Name = "Black Anchor" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_019", Name = "Charm" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_009", Name = "Squares" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LLeg_000", Name = "Single" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_032", Name = "Faith" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_037", Name = "Grim Reaper" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_035", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_033", Name = "Chinese Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_026", Name = "Smoking Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_023", Name = "Hottie" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_021", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_008", Name = "Dragon Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_002", Name = "Melting Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_009", Name = "Dragon and Dagger" }
        };
        public static readonly List<Tattoo> femaleTats08 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_F", Name = "Skull Grenade" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_F", Name = "Three-eyed Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_F", Name = "Smoldering Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_F", Name = "Gold Gun" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_F", Name = "Blue Serpent" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_F", Name = "Night Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_F", Name = "Bandana Knife" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_F", Name = "Graffiti Skull" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_F", Name = "Skullphones" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_F", Name = "Kifflom" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_F", Name = "Cash is King" },//

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_F", Name = "Homeward Bound" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_F", Name = "Pistol Ace" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_F", Name = "Restless Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_F", Name = "Combat Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_F", Name = "STFU" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_F", Name = "American Made" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_F", Name = "Dusk Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_F", Name = "Western Insignia" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_F", Name = "Dragon's Fury" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_F", Name = "Brake Knife" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_F", Name = "Severed Hand" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_F", Name = "Wheelie Mouse" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_F", Name = "Speed Freak" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_F", Name = "Piston Angel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_F", Name = "Praying Gloves" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_F", Name = "Demon Spark Plug" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_F", Name = "San Andreas Prayer" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_F", Name = "Dance of Hearts" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_F", Name = "Ink Me" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_F", Name = "Starmetric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_F", Name = "Elaborate Los Muertos" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_014", Name = "Floral Dagger" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_042", Name = "Sparkplug" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_038", Name = "Grub" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RLeg_000", Name = "Diamond Crown" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RLeg_000", Name = "School of Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_043", Name = "Indian Ram" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_042", Name = "Flaming Scorpion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_040", Name = "Flaming Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_039", Name = "Broken Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_022", Name = "Fiery Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_017", Name = "Tribal" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_007", Name = "The Warrior" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_006", Name = "Skull and Sword" }
        };

        public static readonly List<HairSets> MHairsets = new List<HairSets>
        {
            new HairSets(0, 0, "H_FMM_0_0", "Close Shave", -1, -1),
            new HairSets(1, 0, "H_FMM_1_0", "Buzzcut Dark Brown", -1, -1),
            new HairSets(1, 1, "H_FMM_1_1", "Buzzcut Light Brown", -1, -1),
            new HairSets(1, 2, "H_FMM_1_2", "Buzzcut Auburn", -1, -1),
            new HairSets(1, 3, "H_FMM_1_3", "Buzzcut Blond", -1, -1),
            new HairSets(1, 4, "H_FMM_1_4", "Buzzcut Black", -1, -1),
            new HairSets(2, 0, "H_FMM_2_0", "Faux Hawk Dark Brown", -1, -1),
            new HairSets(2, 1, "H_FMM_2_1", "Faux Hawk Light Brown", -1, -1),
            new HairSets(2, 2, "H_FMM_2_2", "Faux Hawk Auburn", -1, -1),
            new HairSets(2, 3, "H_FMM_2_3", "Faux Hawk Blond", -1, -1),
            new HairSets(2, 4, "H_FMM_2_4", "Faux Hawk Black", -1, -1),
            new HairSets(2, 5, "H_FMM_2_5", "Faux Hawk Purple", -1, -1),
            new HairSets(3, 0, "H_FMM_3_0", "Hipster Shaved Dark Brown", -1, -1),
            new HairSets(3, 1, "H_FMM_3_1", "Hipster Shaved Light Brown", -1, -1),
            new HairSets(3, 2, "H_FMM_3_2", "Hipster Shaved Auburn", -1, -1),
            new HairSets(3, 3, "H_FMM_3_3", "Hipster Shaved Blond", -1, -1),
            new HairSets(3, 4, "H_FMM_3_4", "Hipster Shaved Black", -1, -1),
            new HairSets(3, 5, "H_FMM_3_5", "Hipster Shaved Red", -1, -1),
            new HairSets(4, 0, "H_FMM_4_0", "Side Parting Spiked Dark Brown", -1, -1),
            new HairSets(4, 1, "H_FMM_4_1", "Side Parting Spiked Light Brown", -1, -1),
            new HairSets(4, 2, "H_FMM_4_2", "Side Parting Spiked Auburn", -1, -1),
            new HairSets(4, 3, "H_FMM_4_3", "Side Parting Spiked Blond", -1, -1),
            new HairSets(4, 4, "H_FMM_4_4", "Side Parting Spiked Black", -1, -1),
            new HairSets(4, 6, "H_FMM_4_6", "Side Parting Spiked Blue", -1, -1),
            new HairSets(5, 0, "H_FMM_5_0", "Shorter Cut Dark Brown", -1, -1),
            new HairSets(5, 1, "H_FMM_5_1", "Shorter Cut Light Brown", -1, -1),
            new HairSets(5, 2, "H_FMM_5_2", "Shorter Cut Auburn", -1, -1),
            new HairSets(5, 3, "H_FMM_5_3", "Shorter Cut Blond", -1, -1),
            new HairSets(5, 4, "H_FMM_5_4", "Shorter Cut Black", -1, -1),
            new HairSets(5, 5, "H_FMM_5_5", "Shorter Cut Green", -1, -1),
            new HairSets(6, 0, "H_FMM_6_0", "Biker Dark Brown", -1, -1),
            new HairSets(6, 1, "H_FMM_6_1", "Biker Light Brown", -1, -1),
            new HairSets(6, 2, "H_FMM_6_2", "Biker Auburn", -1, -1),
            new HairSets(6, 3, "H_FMM_6_3", "Biker Blond", -1, -1),
            new HairSets(6, 4, "H_FMM_6_4", "Biker Black", -1, -1),
            new HairSets(6, 5, "H_FMM_6_5", "Biker Purple Fade", -1, -1),
            new HairSets(7, 0, "H_FMM_7_0", "Ponytail Dark Brown", -1, -1),
            new HairSets(7, 1, "H_FMM_7_1", "Ponytail Light Brown", -1, -1),
            new HairSets(7, 2, "H_FMM_7_2", "Ponytail Auburn", -1, -1),
            new HairSets(7, 3, "H_FMM_7_3", "Ponytail Blond", -1, -1),
            new HairSets(7, 4, "H_FMM_7_4", "Ponytail Black", -1, -1),
            new HairSets(7, 6, "H_FMM_7_6", "Ponytail Purple", -1, -1),
            new HairSets(8, 0, "H_FMM_8_0", "Cornrows Dark Brown", -1, -1),
            new HairSets(8, 1, "H_FMM_8_1", "Cornrows Light Brown", -1, -1),
            new HairSets(8, 2, "H_FMM_8_2", "Cornrows Auburn", -1, -1),
            new HairSets(8, 3, "H_FMM_8_3", "Cornrows Blond", -1, -1),
            new HairSets(8, 4, "H_FMM_8_4", "Cornrows Black", -1, -1),
            new HairSets(9, 0, "H_FMM_9_0", "Slicked Dark Brown", -1, -1),
            new HairSets(9, 1, "H_FMM_9_1", "Slicked Light Brown", -1, -1),
            new HairSets(9, 2, "H_FMM_9_2", "Slicked Auburn", -1, -1),
            new HairSets(9, 3, "H_FMM_9_3", "Slicked Blond", -1, -1),
            new HairSets(9, 4, "H_FMM_9_4", "Slicked Black", -1, -1),
            new HairSets(9, 6, "H_FMM_9_6", "Slicked Red", -1, -1),
            new HairSets(10, 0, "H_FMM_10_0", "Short Brushed Dark Brown", -1, -1),
            new HairSets(10, 1, "H_FMM_10_1", "Short Brushed Light Brown", -1, -1),
            new HairSets(10, 2, "H_FMM_10_2", "Short Brushed Auburn", -1, -1),
            new HairSets(10, 3, "H_FMM_10_3", "Short Brushed Blond", -1, -1),
            new HairSets(10, 4, "H_FMM_10_4", "Short Brushed Black", -1, -1),
            new HairSets(11, 0, "H_FMM_11_0", "Spikey Dark Brown", -1, -1),
            new HairSets(11, 1, "H_FMM_11_1", "Spikey Light Brown", -1, -1),
            new HairSets(11, 2, "H_FMM_11_2", "Spikey Auburn", -1, -1),
            new HairSets(11, 3, "H_FMM_11_3", "Spikey Blond", -1, -1),
            new HairSets(11, 4, "H_FMM_11_4", "Spikey Black", -1, -1),
            new HairSets(11, 5, "H_FMM_11_5", "Spikey Blue", -1, -1),
            new HairSets(12, 0, "H_FMM_12_0", "Caesar Dark Brown", -1, -1),
            new HairSets(12, 1, "H_FMM_12_1", "Caesar Light Brown", -1, -1),
            new HairSets(12, 2, "H_FMM_12_2", "Caesar Auburn", -1, -1),
            new HairSets(12, 3, "H_FMM_12_3", "Caesar Blond", -1, -1),
            new HairSets(12, 4, "H_FMM_12_4", "Caesar Black", -1, -1),
            new HairSets(13, 0, "H_FMM_13_0", "Chopped Dark Brown", -1, -1),
            new HairSets(13, 1, "H_FMM_13_1", "Chopped Light Brown", -1, -1),
            new HairSets(13, 2, "H_FMM_13_2", "Chopped Auburn", -1, -1),
            new HairSets(13, 3, "H_FMM_13_3", "Chopped Blond", -1, -1),
            new HairSets(13, 4, "H_FMM_13_4", "Chopped Black", -1, -1),
            new HairSets(13, 5, "H_FMM_13_5", "Chopped Green", -1, -1),
            new HairSets(14, 0, "H_FMM_14_0", "Dreads Dark Brown", -1, -1),
            new HairSets(14, 1, "H_FMM_14_1", "Dreads Light Brown", -1, -1),
            new HairSets(14, 2, "H_FMM_14_2", "Dreads Auburn", -1, -1),
            new HairSets(14, 3, "H_FMM_14_3", "Dreads Blond", -1, -1),
            new HairSets(14, 4, "H_FMM_14_4", "Dreads Black", -1, -1),
            new HairSets(15, 0, "H_FMM_15_0", "Long Hair Dark Brown", -1, -1),
            new HairSets(15, 1, "H_FMM_15_1", "Long Hair Light Brown", -1, -1),
            new HairSets(15, 2, "H_FMM_15_2", "Long Hair Auburn", -1, -1),
            new HairSets(15, 3, "H_FMM_15_3", "Long Hair Blond", -1, -1),
            new HairSets(15, 4, "H_FMM_15_4", "Long Hair Black", -1, -1),
            new HairSets(15, 5, "H_FMM_15_5", "Long Hair Purple Fade", -1, -1),
            new HairSets(16, 0, "CLO_BBM_H_00", "Shaggy Curls Dark Brown", -1, -1),
            new HairSets(16, 1, "CLO_BBM_H_01", "Shaggy Curls Light Brown", -1, -1),
            new HairSets(16, 2, "CLO_BBM_H_02", "Shaggy Curls Auburn", -1, -1),
            new HairSets(16, 3, "CLO_BBM_H_03", "Shaggy Curls Blonde", -1, -1),
            new HairSets(16, 4, "CLO_BBM_H_04", "Shaggy Curls Black", -1, -1),
            new HairSets(17, 0, "CLO_BBM_H_05", "Surfer Dude Dark Brown", -1, -1),
            new HairSets(17, 1, "CLO_BBM_H_06", "Surfer Dude Light Brown", -1, -1),
            new HairSets(17, 2, "CLO_BBM_H_07", "Surfer Dude Auburn", -1, -1),
            new HairSets(17, 3, "CLO_BBM_H_08", "Surfer Dude Blonde", -1, -1),
            new HairSets(17, 4, "CLO_BBM_H_09", "Surfer Dude Black", -1, -1),
            new HairSets(18, 0, "CLO_BUS_H_0_0", "Short Side Part Dark Brown", -2086773, 224730392),
            new HairSets(18, 1, "CLO_BUS_H_0_1", "Short Side Part Light Brown", -2086773, 1988816738),
            new HairSets(18, 2, "CLO_BUS_H_0_2", "Short Side Part Auburn", -2086773, 736778786),
            new HairSets(18, 3, "CLO_BUS_H_0_3", "Short Side Part Blonde", -2086773, 439629494),
            new HairSets(18, 4, "CLO_BUS_H_0_4", "Short Side Part Black", -2086773, 1048444745),
            new HairSets(19, 0, "CLO_BUS_H_1_0", "High Slicked Sides Dark Brown", -2086773, 2140603469),
            new HairSets(19, 1, "CLO_BUS_H_1_1", "High Slicked Sides Light Brown", -2086773, -681528353),
            new HairSets(19, 2, "CLO_BUS_H_1_2", "High Slicked Sides Auburn", -2086773, 1006238992),
            new HairSets(19, 3, "CLO_BUS_H_1_3", "High Slicked Sides Blonde", -2086773, 214245031),
            new HairSets(19, 4, "CLO_BUS_H_1_4", "High Slicked Sides Black", -2086773, 689952604),
            new HairSets(20, 0, "CLO_HP_HR_0_0", "Long Slicked Dark Brown", -1398869298, 965649655),
            new HairSets(20, 1, "CLO_HP_HR_0_1", "Long Slicked Light Brown", -1398869298, 718800778),
            new HairSets(20, 2, "CLO_HP_HR_0_2", "Long Slicked Auburn", -1398869298, 1959959422),
            new HairSets(20, 3, "CLO_HP_HR_0_3", "Long Slicked Blonde", -1398869298, 1200177388),
            new HairSets(20, 4, "CLO_HP_HR_0_4", "Long Slicked Black", -1398869298, -1874439579),
            new HairSets(21, 0, "CLO_HP_HR_1_0", "Hipster Youth Dark Brown", -1398869298, -1679505893),
            new HairSets(21, 1, "CLO_HP_HR_1_1", "Hipster Youth Blonde", -1398869298, -1976229188),
            new HairSets(21, 2, "CLO_HP_HR_1_2", "Hipster Youth Auburn", -1398869298, 2037875009),
            new HairSets(21, 3, "CLO_HP_HR_1_3", "Hipster Youth Light Brown", -1398869298, -235146664),
            new HairSets(21, 4, "CLO_HP_HR_1_4", "Hipster Youth Black", -1398869298, -441853516),
            new HairSets(22, 0, "CLO_IND_H_0_0", "Mullet Dark Brown", -1, -1),
            new HairSets(22, 1, "CLO_IND_H_0_1", "Mullet Light Brown", -1, -1),
            new HairSets(22, 2, "CLO_IND_H_0_2", "Mullet Auburn", -1, -1),
            new HairSets(22, 3, "CLO_IND_H_0_3", "Mullet Blonde", -1, -1),
            new HairSets(22, 4, "CLO_IND_H_0_4", "Mullet Black", -1, -1),
            new HairSets(24, 0, "CLO_S1M_H_0_0", "Classic Cornrows", 62137527, 534771589),
            new HairSets(25, 0, "CLO_S1M_H_1_0", "Palm Cornrows", 62137527, -1340139519),
            new HairSets(26, 0, "CLO_S1M_H_2_0", "Lightning Cornrows", 62137527, -849980761),
            new HairSets(27, 0, "CLO_S1M_H_3_0", "Whipped Cornrows", 62137527, -551553478),
            new HairSets(28, 0, "CLO_S2M_H_0_0", "Zig Zag Cornrows", 1529191571, -1431204514),
            new HairSets(29, 0, "CLO_S2M_H_1_0", "Snail Cornrows", 1529191571, -1133334304),
            new HairSets(30, 0, "CLO_S2M_H_2_0", "Hightop", 1529191571, -1809784771),
            new HairSets(31, 0, "CLO_BIM_H_0_0", "Loose Swept Back", -240234547, 1431846777),
            new HairSets(32, 0, "CLO_BIM_H_1_0", "Undercut Swept Back", -240234547, -460168116),
            new HairSets(33, 0, "CLO_BIM_H_2_0", "Undercut Swept Side", -240234547, -311245907),
            new HairSets(34, 0, "CLO_BIM_H_3_0", "Spiked Mohawk", -240234547, -942031335),
            new HairSets(35, 0, "CLO_BIM_H_4_0", "Mod", -240234547, -644503216),
            new HairSets(36, 0, "CLO_BIM_H_5_0", "Layered Mod", -240234547, 211198653),
            new HairSets(37, 0, "CC_M_HS_1", "Buzzcut", 598190139, 739308497),
            new HairSets(38, 0, "CC_M_HS_2", "Faux Hawk", 598190139, 495343292),
            new HairSets(39, 0, "CC_M_HS_3", "Hipster", 598190139, -1686711653),
            new HairSets(40, 0, "CC_M_HS_4", "Side Parting", 598190139, 1187457341),
            new HairSets(41, 0, "CC_M_HS_5", "Shorter Cut", 598190139, 956403122),
            new HairSets(42, 0, "CC_M_HS_6", "Biker", 598190139, 1647042566),
            new HairSets(43, 0, "CC_M_HS_7", "Ponytail", 598190139, -461478743),
            new HairSets(44, 0, "CC_M_HS_8", "Cornrows", 598190139, -1883325653),
            new HairSets(45, 0, "CC_M_HS_9", "Slicked", 598190139, -2114248796),
            new HairSets(46, 0, "CC_M_HS_10", "Short Brushed", 598190139, 314228205),
            new HairSets(47, 0, "CC_M_HS_11", "Spikey", 598190139, 1503775674),
            new HairSets(48, 0, "CC_M_HS_12", "Caesar", 598190139, 1862399610),
            new HairSets(49, 0, "CC_M_HS_13", "Chopped", 598190139, 708472048),
            new HairSets(50, 0, "CC_M_HS_14", "Dreads", 598190139, -1207367545),
            new HairSets(51, 0, "CC_M_HS_15", "Long Hair", 598190139, 111650251),
            new HairSets(52, 0, "CLO_BBM_H_00", "Shaggy Curls Dark Brown", -1, -1),
            new HairSets(53, 0, "CLO_BBM_H_05", "Surfer Dude Dark Brown", -1, -1),
            new HairSets(54, 0, "CLO_BUS_H_0_0", "Short Side Part Dark Brown", -2086773, 224730392),
            new HairSets(55, 0, "CLO_BUS_H_1_0", "High Slicked Sides Dark Brown", -2086773, 2140603469),
            new HairSets(56, 0, "CLO_HP_HR_0_0", "Long Slicked Dark Brown", -1398869298, 965649655),
            new HairSets(57, 0, "CLO_HP_HR_1_0", "Hipster Youth Dark Brown", -1398869298, -1679505893),
            new HairSets(58, 0, "CLO_IND_H_0_0", "Mullet Dark Brown", -1, -1),
            new HairSets(59, 0, "CLO_S1M_H_0_0", "Classic Cornrows", 62137527, 534771589),
            new HairSets(60, 0, "CLO_S1M_H_1_0", "Palm Cornrows", 62137527, -1340139519),
            new HairSets(61, 0, "CLO_S1M_H_2_0", "Lightning Cornrows", 62137527, -849980761),
            new HairSets(62, 0, "CLO_S1M_H_3_0", "Whipped Cornrows", 62137527, -551553478),
            new HairSets(63, 0, "CLO_S2M_H_0_0", "Zig Zag Cornrows", 1529191571, -1431204514),
            new HairSets(64, 0, "CLO_S2M_H_1_0", "Snail Cornrows", 1529191571, -1133334304),
            new HairSets(65, 0, "CLO_S2M_H_2_0", "Hightop", 1529191571, -1809784771),
            new HairSets(66, 0, "CLO_BIM_H_0_0", "Loose Swept Back", -240234547, 1431846777),
            new HairSets(67, 0, "CLO_BIM_H_1_0", "Undercut Swept Back", -240234547, -460168116),
            new HairSets(68, 0, "CLO_BIM_H_2_0", "Undercut Swept Side", -240234547, -311245907),
            new HairSets(69, 0, "CLO_BIM_H_3_0", "Spiked Mohawk", -240234547, -942031335),
            new HairSets(70, 0, "CLO_BIM_H_4_0", "Mod", -240234547, -644503216),
            new HairSets(71, 0, "CLO_BIM_H_5_0", "Layered Mod", -240234547, 211198653),
            new HairSets(72, 0, "CLO_GRM_H_0_0", "Flattop", 1616273011, -1119221482),
            new HairSets(73, 0, "CLO_GRM_H_1_0", "Military Buzzcut", 1616273011, -1642199958),
            new HairSets(74, 0, "CLO_VWM_H_0_0", "Impotent Rage", 1347816957, -599666460),
            new HairSets(75, 0, "CLO_TRM_H_0_0", "Afro Faded", -1970774728, -416636904),
            new HairSets(76, 0, "CLO_FXM_H_0_0", "Top Knot", 601646824, 1334100948),
            new HairSets(77, 0, "CLO_SBM_H_0_0", "Two Block", 987639353, -1927370417),
            new HairSets(78, 0, "CLO_SBM_H_1_0", "Shaggy Mullet", 987639353, -1088161005)
        };
        public static readonly List<HairSets> FHairsets = new List<HairSets>
        {
            new HairSets(0, 0, "H_FMF_0_0","Close Shave", -1, -1),
            new HairSets(1, 0, "H_FMF_1_0","Short Chestnut", -1, -1),
            new HairSets(1, 1, "H_FMF_1_1","Short Blonde", -1, -1),
            new HairSets(1, 2, "H_FMF_1_2","Short Auburn", -1, -1),
            new HairSets(1, 3, "H_FMF_1_3","Short Black", -1, -1),
            new HairSets(1, 4, "H_FMF_1_4","Short Brown", -1, -1),
            new HairSets(1, 5, "H_FMF_1_5","Short Purple", -1, -1),

            new HairSets(2, 0, "H_FMF_2_0","Layered Bob Chestnut", -1, -1),
            new HairSets(2, 1, "H_FMF_2_1","Layered Bob Blonde", -1, -1),
            new HairSets(2, 2, "H_FMF_2_2","Layered Bob Auburn", -1, -1),
            new HairSets(2, 3, "H_FMF_2_3","Layered Bob Black", -1, -1),
            new HairSets(2, 4, "H_FMF_2_4","Layered Bob Brown", -1, -1),
            new HairSets(2, 5, "H_FMF_2_5","Layered Bob Green", -1, -1),

            new HairSets(3, 0, "H_FMF_3_0","Pigtails Chestnut", -1, -1),
            new HairSets(3, 1, "H_FMF_3_1","Pigtails Blonde", -1, -1),
            new HairSets(3, 2, "H_FMF_3_2","Pigtails Auburn", -1, -1),
            new HairSets(3, 3, "H_FMF_3_3","Pigtails Black", -1, -1),
            new HairSets(3, 4, "H_FMF_3_4","Pigtails Brown", -1, -1),

            new HairSets(4, 0, "H_FMF_4_0","Ponytail Chestnut", -1, -1),
            new HairSets(4, 1, "H_FMF_4_1","Ponytail Blonde", -1, -1),
            new HairSets(4, 2, "H_FMF_4_2","Ponytail Auburn", -1, -1),
            new HairSets(4, 3, "H_FMF_4_3","Ponytail Black", -1, -1),
            new HairSets(4, 4, "H_FMF_4_4","Ponytail Brown", -1, -1),
            new HairSets(4, 5, "H_FMF_4_5","Ponytail Blue", -1, -1),

            new HairSets(5, 0, "H_FMF_5_0","Braided Mohawk Chestnut", -1, -1),
            new HairSets(5, 1, "H_FMF_5_1","Braided Mohawk Blonde", -1, -1),
            new HairSets(5, 2, "H_FMF_5_2","Braided Mohawk Auburn", -1, -1),
            new HairSets(5, 3, "H_FMF_5_3","Braided Mohawk Black", -1, -1),
            new HairSets(5, 4, "H_FMF_5_4","Braided Mohawk Brown", -1, -1),
            new HairSets(5, 5, "H_FMF_5_5","Braided Mohawk Pink", -1, -1),

            new HairSets(6, 0, "H_FMF_6_0","Braids Chestnut", -1, -1),
            new HairSets(6, 1, "H_FMF_6_1","Braids Blonde", -1, -1),
            new HairSets(6, 2, "H_FMF_6_2","Braids Auburn", -1, -1),
            new HairSets(6, 3, "H_FMF_6_3","Braids Black", -1, -1),
            new HairSets(6, 4, "H_FMF_6_4","Braids Brown", -1, -1),

            new HairSets(7, 0, "H_FMF_7_0","Bob Chestnut", -1, -1),
            //new HairSets(7, 1, "H_FMF_7_1","Bob Blonde", -1, -1),
            //new HairSets(7, 2, "H_FMF_7_2","Bob Auburn", -1, -1),
            //new HairSets(7, 3, "H_FMF_7_3","Bob Black", -1, -1),
            //new HairSets(7, 4, "H_FMF_7_4","Bob Brown", -1, -1),
            //new HairSets(7, 5, "H_FMF_7_5","Bob Purple Fade", -1, -1),

            new HairSets(8, 0, "H_FMF_8_0","Faux Hawk Chestnut", -1, -1),
            new HairSets(8, 1, "H_FMF_8_1","Faux Hawk Blonde", -1, -1),
            new HairSets(8, 2, "H_FMF_8_2","Faux Hawk Auburn", -1, -1),
            new HairSets(8, 3, "H_FMF_8_3","Faux Hawk Black", -1, -1),
            new HairSets(8, 4, "H_FMF_8_4","Faux Hawk Brown", -1, -1),
            new HairSets(8, 5, "H_FMF_8_5","Faux Hawk Pink", -1, -1),

            new HairSets(9, 0, "H_FMF_9_0","French Twist Chestnut", -1, -1),
            new HairSets(9, 1, "H_FMF_9_1","French Twist Blonde", -1, -1),
            new HairSets(9, 2, "H_FMF_9_2","French Twist Auburn", -1, -1),
            new HairSets(9, 3, "H_FMF_9_3","French Twist Black", -1, -1),
            new HairSets(9, 4, "H_FMF_9_4","French Twist Brown", -1, -1),

            new HairSets(10, 0, "H_FMF_10_0","Long Bob Chestnut", -1, -1),
            new HairSets(10, 1, "H_FMF_10_1","Long Bob Blonde", -1, -1),
            new HairSets(10, 2, "H_FMF_10_2","Long Bob Auburn", -1, -1),
            new HairSets(10, 3, "H_FMF_10_3","Long Bob Black", -1, -1),
            new HairSets(10, 4, "H_FMF_10_4","Long Bob Brown", -1, -1),
            new HairSets(10, 6, "H_FMF_10_6","Long Bob Purple Fade", -1, -1),

            new HairSets(11, 0, "H_FMF_11_0","Loose Tied Chestnut", -1, -1),
            new HairSets(11, 1, "H_FMF_11_1","Loose Tied Blonde", -1, -1),
            new HairSets(11, 2, "H_FMF_11_2","Loose Tied Auburn", -1, -1),
            new HairSets(11, 3, "H_FMF_11_3","Loose Tied Black", -1, -1),
            new HairSets(11, 4, "H_FMF_11_4","Loose Tied Brown", -1, -1),
            new HairSets(11, 6, "H_FMF_11_6","Loose Tied Green", -1, -1),

            new HairSets(12, 0, "H_FMF_12_0","Pixie Chestnut", -1, -1),
            new HairSets(12, 1, "H_FMF_12_1","Pixie Blonde", -1, -1),
            new HairSets(12, 2, "H_FMF_12_2","Pixie Auburn", -1, -1),
            new HairSets(12, 3, "H_FMF_12_3","Pixie Black", -1, -1),
            new HairSets(12, 4, "H_FMF_12_4","Pixie Brown", -1, -1),
            new HairSets(12, 5, "H_FMF_12_5","Pixie Blue", -1, -1),

            new HairSets(13, 0, "H_FMF_13_0","Shaved Bangs Chestnut", -1, -1),
            new HairSets(13, 1, "H_FMF_13_1","Shaved Bangs Blonde", -1, -1),
            new HairSets(13, 2, "H_FMF_13_2","Shaved Bangs Auburn", -1, -1),
            new HairSets(13, 3, "H_FMF_13_3","Shaved Bangs Black", -1, -1),
            new HairSets(13, 4, "H_FMF_13_4","Shaved Bangs Brown", -1, -1),
            new HairSets(13, 5, "H_FMF_13_5","Shaved Bangs Blue Fade", -1, -1),

            new HairSets(14, 0, "H_FMF_14_0","Top Knot Chestnut", -1, -1),
            new HairSets(14, 1, "H_FMF_14_1","Top Knot Blonde", -1, -1),
            new HairSets(14, 2, "H_FMF_14_2","Top Knot Auburn", -1, -1),
            new HairSets(14, 3, "H_FMF_14_3","Top Knot Black", -1, -1),
            new HairSets(14, 4, "H_FMF_14_4","Top Knot Brown", -1, -1),

            new HairSets(15, 0, "H_FMF_15_0","Wavy Bob Chestnut", -1, -1),
            new HairSets(15, 1, "H_FMF_15_1","Wavy Bob Blonde", -1, -1),
            new HairSets(15, 2, "H_FMF_15_2","Wavy Bob Auburn", -1, -1),
            new HairSets(15, 3, "H_FMF_15_3","Wavy Bob Black", -1, -1),
            new HairSets(15, 4, "H_FMF_15_4","Wavy Bob Brown", -1, -1),
            new HairSets(15, 6, "H_FMF_15_6","Wavy Bob Red Fade", -1, -1),

            new HairSets(16, 0, "CLO_BBF_H_00","Pin Up Girl Chestnut", -1, -1),
            new HairSets(16, 1, "CLO_BBF_H_01","Pin Up Girl Blonde", -1, -1),
            new HairSets(16, 2, "CLO_BBF_H_02","Pin Up Girl Auburn", -1, -1),
            new HairSets(16, 3, "CLO_BBF_H_03","Pin Up Girl Black", -1, -1),
            new HairSets(16, 4, "CLO_BBF_H_04","Pin Up Girl Brown", -1, -1),

            new HairSets(17, 0, "CLO_BBF_H_05","Messy Bun Chestnut", -1398869298, -811206225),
            new HairSets(17, 1, "CLO_BBF_H_06","Messy Bun Blonde", -1398869298, -1586815686),
            new HairSets(17, 2, "CLO_BBF_H_07","Messy Bun Auburn", -1398869298, -1423429452),
            new HairSets(17, 3, "CLO_BBF_H_08","Messy Bun Black", -1398869298, -1697869815),
            new HairSets(17, 4, "CLO_BBF_H_09","Messy Bun Brown", -1398869298, -1470846183),

            new HairSets(18, 0, "CLO_VALF_H_0_0","Flapper Bob Chestnut", -1, -1),
            new HairSets(18, 1, "CLO_VALF_H_0_1","Flapper Bob Blonde", -1, -1),
            new HairSets(18, 2, "CLO_VALF_H_0_2","Flapper Bob Auburn", -1, -1),
            new HairSets(18, 3, "CLO_VALF_H_0_3","Flapper Bob Black", -1, -1),
            new HairSets(18, 4, "CLO_VALF_H_0_4","Flapper Bob Brown", -1, -1),
            new HairSets(18, 5, "CLO_VALF_H_0_5","Flapper Bob Blue", -1, -1),

            new HairSets(19, 0, "CLO_BUS_F_H_0_0","Tight Bun Black", -2086773, -1816086813),
            new HairSets(19, 1, "CLO_BUS_F_H_0_1","Tight Bun Brown", -2086773, -2113006722),
            new HairSets(19, 2, "CLO_BUS_F_H_0_2","Tight Bun Auburn", -2086773, -1398740829),
            new HairSets(19, 3, "CLO_BUS_F_H_0_3","Tight Bun Chestnut", -2086773, -131530830),
            new HairSets(19, 4, "CLO_BUS_F_H_0_4","Tight Bun Blonde", -2086773, -1101886458),

            new HairSets(20, 0, "CLO_BUS_F_H_1_0","Twisted Bob Chestnut", -1398869298, 558694786),
            new HairSets(20, 1, "CLO_BUS_F_H_1_1","Twisted Bob Black", -1398869298, 569279177),
            new HairSets(20, 2, "CLO_BUS_F_H_1_2","Twisted Bob Auburn", -1398869298, 544309199),
            new HairSets(20, 3, "CLO_BUS_F_H_1_3","Twisted Bob Brown", -1398869298, 1190448341),
            new HairSets(20, 4, "CLO_BUS_F_H_1_4","Twisted Bob Blonde", -1398869298, 885139568),

            new HairSets(21, 0, "CLO_HP_F_HR_0_0","Big Bangs Chestnut", -1, -1),
            new HairSets(21, 1, "CLO_HP_F_HR_0_1","Big Bangs Blonde", -1, -1),
            new HairSets(21, 2, "CLO_HP_F_HR_0_2","Big Bangs Auburn", -1, -1),
            new HairSets(21, 3, "CLO_HP_F_HR_0_3","Big Bangs Black", -1, -1),
            new HairSets(21, 4, "CLO_HP_F_HR_0_4","Big Bangs Brown", -1, -1),

            new HairSets(22, 0, "CLO_HP_F_HR_1_0","Braided Top Knot Chestnut", -1398869298, -1845683606),
            new HairSets(22, 1, "CLO_HP_F_HR_1_1","Braided Top Knot Blonde", -1398869298, -1555317497),
            new HairSets(22, 2, "CLO_HP_F_HR_1_2","Braided Top Knot Auburn", -1398869298, 1704673699),
            new HairSets(22, 3, "CLO_HP_F_HR_1_3","Braided Top Knot Black", -1398869298, 1993401358),
            new HairSets(22, 4, "CLO_HP_F_HR_1_4","Braided Top Knot Brown", -1398869298, 1227065524),

            new HairSets(23, 0, "CLO_INDF_H_0_0","Mullet Chestnut", -1, -1),
            new HairSets(23, 1, "CLO_INDF_H_0_1","Mullet Blonde", -1, -1),
            new HairSets(23, 2, "CLO_INDF_H_0_2","Mullet Auburn", -1, -1),
            new HairSets(23, 3, "CLO_INDF_H_0_3","Mullet Black", -1, -1),
            new HairSets(23, 4, "CLO_INDF_H_0_4","Mullet Brown", -1, -1),

            new HairSets(25, 0, "CLO_S1F_H_0_0","Pinched Cornrows", 62137527, -1325458477),
            new HairSets(26, 0, "CLO_S1F_H_1_0","Leaf Cornrows", 62137527, -566725051),
            new HairSets(27, 0, "CLO_S1F_H_2_0","Zig Zag Cornrows", 62137527, -787850263),
            new HairSets(28, 0, "CLO_S1F_H_3_0","Pigtail Bangs", 1529191571, 2039295216),
            new HairSets(29, 0, "CLO_S2F_H_0_0","Wave Braids", 1529191571, 2039295216),
            new HairSets(30, 0, "CLO_S2F_H_1_0","Coil Braids", 1529191571, 1800147054),
            new HairSets(31, 0, "CLO_S2F_H_2_0","Rolled Quiff", 1529191571, -2019505897),
            new HairSets(32, 0, "CLO_BIF_H_0_0","Loose Swept Back", -240234547, -328340062),
            new HairSets(33, 0, "CLO_BIF_H_1_0","Undercut Swept Back", -240234547, 1657725123),
            new HairSets(34, 0, "CLO_BIF_H_2_0","Undercut Swept Side", -240234547, -1517964336),
            new HairSets(35, 0, "CLO_BIF_H_3_0","Spiked Mohawk", -240234547, 1677522529),
            new HairSets(36, 0, "CLO_BIF_H_4_0","Bandana and Braid", 598190139, -1362677538),
            new HairSets(37, 0, "CLO_BIF_H_6_0","Skinbyrd", -240234547, 1841934566),
            new HairSets(38, 0, "CLO_BIF_H_5_0","Layered Mod", -240234547, 1742494019),
            new HairSets(39, 0, "CC_F_HS_1","Short", 598190139, 104062694),
            new HairSets(40, 0, "CC_F_HS_2","Layered Bob", 598190139, 869579299),
            new HairSets(41, 0, "CC_F_HS_3","Pigtails", 598190139, 1201332655),
            new HairSets(42, 0, "CC_F_HS_4","Ponytail", 598190139, 1028967715),
            new HairSets(43, 0, "CC_F_HS_5","Braided Mohawk", 598190139, -1651634800),
            new HairSets(44, 0, "CC_F_HS_6","Braids", 598190139, -892278763),
            new HairSets(45, 0, "CC_F_HS_7","Bob", 598190139, -1032005779),
            new HairSets(46, 0, "CC_F_HS_8","Faux Hawk", 598190139, -255675400),
            new HairSets(47, 0, "CC_F_HS_9","French Twist", 598190139, 1890137027),
            new HairSets(48, 0, "CC_F_HS_10","Long Bob", 598190139, -406805808),
            new HairSets(49, 0, "CC_F_HS_11","Loose Tied", 598190139, -592540500),
            new HairSets(50, 0, "CC_F_HS_12","Pixie", 598190139, 205417419),
            new HairSets(51, 0, "CC_F_HS_13","Shaved Bangs", 598190139, -2127276619),
            new HairSets(52, 0, "CC_F_HS_14","Top Knot", 598190139, -1362677538),
            new HairSets(53, 0, "CC_F_HS_15","Wavy Bob", 598190139, -1549722990),
            new HairSets(54, 0, "CLO_BBF_H_05","Messy Bun Chestnut", -1398869298, -811206225),
            new HairSets(55, 0, "CLO_BBF_H_00","Pin Up Girl Chestnut", -1, -1),
            new HairSets(56, 0, "CLO_BUS_F_H_0_0","Tight Bun Black", -2086773, -1816086813),
            new HairSets(57, 0, "CLO_BUS_F_H_1_0","Twisted Bob Chestnut", -1398869298, 558694786),
            new HairSets(58, 0, "CLO_VALF_H_0_0","Flapper Bob Chestnut", -1, -1),
            new HairSets(59, 0, "CLO_HP_F_HR_0_0","Big Bangs Chestnut", -1, -1),
            new HairSets(60, 0, "CLO_HP_F_HR_1_0","Braided Top Knot Chestnut", -1398869298, -1845683606),
            new HairSets(61, 0, "CLO_INDF_H_0_0","Mullet Chestnut", -1, -1),
            new HairSets(62, 0, "CLO_S1F_H_0_0","Pinched Cornrows", 62137527, -1325458477),
            new HairSets(63, 0, "CLO_S1F_H_1_0","Leaf Cornrows", 62137527, -566725051),
            new HairSets(64, 0, "CLO_S1F_H_2_0","Zig Zag Cornrows", 62137527, -787850263),
            new HairSets(65, 0, "CLO_S1F_H_3_0","Pigtail Bangs", 1529191571, 2039295216),
            new HairSets(66, 0, "CLO_S2F_H_0_0","Wave Braids", 1529191571, 2039295216),
            new HairSets(67, 0, "CLO_S2F_H_1_0","Coil Braids", 1529191571, 1800147054),
            new HairSets(68, 0, "CLO_S2F_H_2_0","Rolled Quiff", 1529191571, -2019505897),
            new HairSets(69, 0, "CLO_BIF_H_0_0","Loose Swept Back", -240234547, -328340062),
            new HairSets(70, 0, "CLO_BIF_H_1_0","Undercut Swept Back", -240234547, 1657725123),
            new HairSets(71, 0, "CLO_BIF_H_2_0","Undercut Swept Side", -240234547, -1517964336),
            new HairSets(72, 0, "CLO_BIF_H_3_0","Spiked Mohawk", -240234547, 1677522529),
            new HairSets(73, 0, "CLO_BIF_H_4_0","Bandana and Braid", 598190139, -1362677538),
            new HairSets(74, 0, "CLO_BIF_H_5_0","Layered Mod", -240234547, 1742494019),
            new HairSets(75, 0, "CLO_BIF_H_6_0","Skinbyrd", -240234547, 1841934566),
            new HairSets(76, 0, "CLO_GRF_H_0_0","Neat Bun", 1616273011, 687338866),
            new HairSets(77, 0, "CLO_GRF_H_1_0","Short Bob", 1616273011, 1827923343),
            new HairSets(78, 0, "CLO_VWF_H_0_0","Impotent Rage", 1347816957, 987747946),
            new HairSets(79, 0, "CLO_TRF_H_0_0","Afro", -1970774728, -2025496493),
            new HairSets(80, 0, "CLO_FXF_H_0_0","Pixie Wavy", 601646824, -974054285),
            new HairSets(81, 0, "CLO_SBF_H_0_0","Short Tucked Bob", 987639353, -606892013),
            new HairSets(82, 0, "CLO_SBF_H_1_0","Shaggy Mullet", 987639353, -1514684318),
            new HairSets(83, 0, "CLO_X6F_H_0_0","Buzzcut", 1841427399, 606012624)
        };

        public static readonly List<ClothX> RandOutM = new List<ClothX>
        {
            new ClothX("M_Highclass_0", new List<int> { 0, 0, -1, 4, 20, 0, 40, 11, 35, 0, 0, 27 }, new List<int> { 0, 0, 0, 0, 2, 0, 9, 2, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Highclass_1", new List<int> { 0, 0, -1, 6, 83, 0, 29, 89, 15, 0, 0, 190 }, new List<int> { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 96, -1, -1, -1, -1 }, new List<int> { 6, -1, -1, -1, -1 }),
            new ClothX("M_Highclass_2", new List<int> { 0, 0, -1, 4, 63, 0, 2, 0, 15, 0, 0, 139 }, new List<int> { 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 3 }, new List<int> { -1, 3, -1, -1, -1 }, new List<int> { -1, 9, -1, -1, -1 }),
            new ClothX("M_Highclass_3", new List<int> { 0, 0, -1, 4, 60, 0, 36, 0, 72, 0, 0, 108 }, new List<int> { 0, 0, 0, 0, 2, 0, 3, 0, 3, 0, 0, 4 }, new List<int> { -1, 13, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
            new ClothX("M_Highclass_4", new List<int> { 0, 0, -1, 12, 24, 0, 18, 29, 31, 0, 0, 29 }, new List<int> { 0, 0, 0, 0, 5, 0, 0, 2, 0, 0, 0, 5 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Highclass_5", new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 }, new List<int> { 0, 0, 0, 0, 4, 0, 4, 1, 0, 0, 0, 4 }, new List<int> { 64, -1, -1, -1, -1 }, new List<int> { 4, -1, -1, -1, -1 }),
            new ClothX("M_Highclass_6", new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 }, new List<int> { 0, 0, 0, 0, 1, 0, 1, 2, 4, 0, 0, 1 }, new List<int> { 64, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("M_Highclass_7", new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 }, new List<int> { 0, 0, 0, 0, 11, 0, 11, 1, 4, 0, 0, 11 }, new List<int> { 64, -1, -1, -1, -1 }, new List<int> { 11, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_0", new List<int> { 0, 0, -1, 8, 4, 0, 4, 0, 15, 0, 0, 38 }, new List<int> { 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_1", new List<int> { 0, 0, -1, 0, 0, 0, 1, 17, 15, 0, 0, 33 }, new List<int> { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_2", new List<int> { 0, 0, -1, 12, 1, 0, 1, 0, 15, 0, 0, 41 }, new List<int> { 0, 0, 0, 0, 14, 0, 4, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_3", new List<int> { 0, 0, -1, 0, 0, 0, 0, 0, 15, 0, 0, 1 }, new List<int> { 0, 0, 0, 0, 2, 0, 10, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_4", new List<int> { 0, 0, -1, 0, 1, 0, 1, 0, 15, 0, 0, 22 }, new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Midclass_5", new List<int> { 0, 0, -1, 0, 0, 0, 2, 0, 15, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, 0, -1, -1 }, new List<int> { -1, -1, 0, -1, -1 }),
            new ClothX("M_Midclass_6", new List<int> { 0, 0, -1, 0, 43, 0, 57, 51, 81, 0, 0, 170 }, new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 2, 0, 0, 3 }, new List<int> { -1, 18, -1, -1, -1 }, new List<int> { -1, 3, -1, -1, -1 }),
            new ClothX("M_Buisness_0", new List<int> { 0, 0, -1, 4, 13, 0, 10, 115, 10, 0, 0, 28 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, new List<int> { -1, 17, -1, -1, -1 }, new List<int> { -1, 6, -1, -1, -1 }),
            new ClothX("M_Buisness_1", new List<int> { 0, 0, -1, 4, 37, 0, 20, 38, 10, 0, 0, 142 }, new List<int> { 0, 0, 0, 0, 2, 0, 5, 6, 2, 0, 0, 2 }, new List<int> { 29, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_2", new List<int> { 0, 0, -1, 4, 37, 0, 15, 28, 31, 0, 0, 140 }, new List<int> { 0, 0, 0, 0, 0, 0, 10, 1, 0, 0, 0, 2 }, new List<int> { -1, 17, -1, -1, -1 }, new List<int> { -1, 5, -1, -1, -1 }),
            new ClothX("M_Buisness_3", new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 }, new List<int> { 0, 0, 0, 0, 2, 0, 2, 15, 0, 0, 0, 7 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_4", new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 }, new List<int> { 0, 0, 0, 0, 3, 0, 7, 14, 0, 0, 0, 8 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_5", new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 }, new List<int> { 0, 0, 0, 0, 1, 0, 6, 13, 0, 0, 0, 13 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_6", new List<int> { 0, 0, -1, 4, 60, 0, 23, 10, 10, 0, 0, 72 }, new List<int> { 0, 0, 0, 0, 7, 0, 2, 2, 7, 0, 0, 2 }, new List<int> { 29, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_7", new List<int> { 0, 0, -1, 4, 10, 0, 23, 21, 31, 0, 0, 106 }, new List<int> { 0, 0, 0, 0, 0, 0, 3, 12, 3, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Buisness_8", new List<int> { 0, 0, -1, 4, 10, 0, 10, 38, 10, 0, 0, 4 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 6, 4, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Epslon_0", new List<int> { 0, 0, 0, 8, 104, 0, 20, 129, 15, 0, 0, 272 }, new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Jogger_0", new List<int> { 0, 0, -1, 0, 18, 0, 9, 0, 15, 0, 0, 39 }, new List<int> { 0, 0, 0, 0, 1, 0, 7, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Jogger_1", new List<int> { 0, 0, -1, 0, 5, 0, 2, 0, 15, 0, 0, 1 }, new List<int> { 0, 0, 0, 0, 6, 0, 6, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Jogger_2", new List<int> { 0, 0, -1, 0, 6, 0, 9, 0, 15, 0, 0, 9 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Jogger_3", new List<int> { 0, 0, -1, 1, 3, 0, 7, 0, 41, 0, 0, 7 }, new List<int> { 0, 0, 0, 0, 4, 0, 15, 0, 3, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Jogger_4", new List<int> { 0, 0, -1, 8, 14, 0, 2, 0, 15, 0, 0, 38 }, new List<int> { 0, 0, 0, 0, 1, 0, 13, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Services_0", new List<int> { 0, 0, -1, 0, 35, 0, 25, 0, 58, 0, 0, 55 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Services_1", new List<int> { 0, 0, -1, 0, 35, 0, 25, 0, 58, 0, 0, 55 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 46, 1, -1, -1, -1 }, new List<int> { 0, 1, -1, -1, -1 }),
             new ClothX("M_Services_10", new List<int> { 0, 0, 0, 1, 37, 0, 21, 38, 13, 54, 0, 59 }, new List<int> { 0, 0, 0, 0, 2, 0, 2, 15, 0, 0, 0, 2 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_Services_11", new List<int> { 0, 0, 0, 4, 10, 0, 20, 38, 10, 53, 0, 28 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { -1, 8, -1, -1, -1 }, new List<int> { -1, 5, -1, -1, -1 }),
             new ClothX("M_Services_12", new List<int> { 0, 0, 0, 12, 28, 0, 10, 37, 11, 53, 0, 4 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0 }, new List<int> { -1, 8, -1, -1, -1 }, new List<int> { -1, 6, -1, -1, -1 }),
             new ClothX("M_Services_13", new List<int> { 0, 0, 0, 4, 25, 0, 21, 21, 10, 55, 0, 23 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 11, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_Services_2", new List<int> { 0, 0, -1, 85, 96, 0, 51, 127, 15, 0, 58, 250 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, new List<int> { 122, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Services_3", new List<int> { 0, 0, -1, 85, 96, 0, 51, 127, 15, 0, 58, 250 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 }, new List<int> { 122, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("M_Services_4", new List<int> { 0, 0, -1, 90, 96, 0, 51, 126, 15, 0, 57, 249 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 122, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Services_5", new List<int> { 0, 0, -1, 90, 96, 0, 51, 126, 15, 0, 57, 249 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 122, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("M_Services_6", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 137, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Services_7", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 138, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Services_8", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 138, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_Services_9", new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 137, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_0", new List<int> { 0, 0, 0, 184, 22, 0, 36, 0, 15, 0, 0, 355 }, new List<int> { 0, 0, 0, 0, 8, 0, 2, 0, 0, 0, 0, 17 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_1", new List<int> { 0, 0, 0, 11, 6, 0, 9, 0, 15, 0, 0, 354 }, new List<int> { 0, 0, 0, 0, 1, 0, 13, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_2", new List<int> { 0, 0, 0, 184, 0, 0, 1, 0, 141, 0, 0, 355 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_3", new List<int> { 0, 0, 0, 11, 12, 0, 5, 0, 15, 0, 0, 354 }, new List<int> { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 14 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_4", new List<int> { 0, 0, 0, 4, 87, 0, 60, 148, 170, 0, 0, 221 }, new List<int> { 0, 0, 0, 0, 6, 0, 0, 1, 6, 0, 0, 6 }, new List<int> { 150, -1, -1, -1, -1 }, new List<int> { 14, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_5", new List<int> { 0, 0, 0, 4, 87, 0, 60, 147, 170, 0, 0, 221 }, new List<int> { 0, 0, 0, 0, 8, 0, 0, 1, 5, 0, 0, 8 }, new List<int> { 107, -1, -1, -1, -1 }, new List<int> { 8, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_6", new List<int> { 0, 0, 0, 4, 87, 0, 96, 148, 170, 0, 0, 220 }, new List<int> { 0, 0, 0, 0, 15, 0, 0, 11, 9, 0, 0, 15 }, new List<int> { 104, -1, -1, -1, -1 }, new List<int> { 15, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_7", new List<int> { 0, 0, 0, 4, 87, 0, 96, 146, 170, 0, 0, 220 }, new List<int> { 0, 0, 0, 0, 16, 0, 0, 4, 8, 0, 0, 16 }, new List<int> { 105, -1, -1, -1, -1 }, new List<int> { 16, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_8", new List<int> { 0, 0, 0, 11, 9, 0, 73, 0, 15, 0, 0, 222 }, new List<int> { 0, 0, 0, 0, 7, 0, 6, 0, 0, 0, 0, 23 }, new List<int> { 142, -1, -1, -1, -1 }, new List<int> { 19, -1, -1, -1, -1 }),
            new ClothX("M_CayoPerico_9", new List<int> { 0, 0, 0, 0, 0, 0, 59, 0, 171, 0, 0, 325 }, new List<int> { 0, 0, 0, 0, 6, 0, 23, 0, 14, 0, 0, 12 }, new List<int> { 106, -1, -1, -1, -1 }, new List<int> { 23, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_10", new List<int> { 0, 0, 0, 0, 122, 0, 54, 0, 171, 0, 0, 208 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 18 }, new List<int> { 60, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_11", new List<int> { 0, 0, 0, 11, 122, 0, 71, 0, 15, 0, 0, 222 }, new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 24 }, new List<int> { 107, -1, -1, -1, -1 }, new List<int> { 24, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_12", new List<int> { 0, 0, 0, 5, 86, 0, 61, 0, 15, 0, 0, 237 }, new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_13", new List<int> { 0, 0, 0, 15, 86, 0, 73, 0, 15, 0, 0, 15 }, new List<int> { 0, 0, 0, 0, 17, 0, 6, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_14", new List<int> { 0, 0, 0, 15, 124, 0, 71, 0, 171, 0, 0, 15 }, new List<int> { 0, 0, 0, 0, 19, 0, 1, 0, 8, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_15", new List<int> { 0, 0, 0, 2, 124, 0, 97, 0, 171, 0, 0, 238 }, new List<int> { 0, 0, 0, 0, 16, 0, 0, 0, 2, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_16", new List<int> { 0, 185, 0, 174, 98, 0, 71, 0, 15, 0, 0, 253 }, new List<int> { 0, 8, 0, 0, 1, 0, 4, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_17", new List<int> { 0, 52, 0, 174, 124, 0, 25, 0, 15, 0, 0, 336 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 }, new List<int> { 147, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_18", new List<int> { 0, 132, 0, 174, 125, 0, 73, 0, 15, 0, 0, 251 }, new List<int> { 0, 8, 0, 0, 1, 0, 0, 0, 0, 0, 0, 25 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_19", new List<int> { 0, 185, 0, 174, 130, 0, 96, 0, 15, 0, 0, 328 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_20", new List<int> { 0, 0, 0, 12, 0, 0, 10, 0, 11, 0, 0, 338 }, new List<int> { 0, 0, 0, 0, 1, 0, 12, 0, 7, 0, 0, 3 }, new List<int> { -1, 5, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("M_CayoPerico_21", new List<int> { 0, 0, 0, 184, 1, 0, 4, 0, 141, 0, 0, 346 }, new List<int> { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 24 }, new List<int> { -1, 7, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("M_CayoPerico_22", new List<int> { 0, 0, 0, 12, 22, 0, 1, 0, 15, 0, 0, 12 }, new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_23", new List<int> { 0, 0, 0, 184, 0, 0, 12, 0, 23, 0, 0, 346 }, new List<int> { 0, 0, 0, 0, 12, 0, 6, 0, 1, 0, 0, 20 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_24", new List<int> { 0, 0, 0, 0, 4, 0, 4, 0, 172, 0, 0, 9 }, new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 12, 0, 0, 14 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_25", new List<int> { 0, 186, 0, 0, 118, 0, 94, 0, 172, 0, 0, 9 }, new List<int> { 0, 2, 0, 0, 0, 0, 1, 0, 1, 0, 0, 2 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_26", new List<int> { 0, 0, 0, 4, 117, 0, 75, 0, 172, 0, 0, 305 }, new List<int> { 0, 0, 0, 0, 9, 0, 21, 0, 2, 0, 0, 23 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("M_CayoPerico_27", new List<int> { 0, 101, 0, 0, 117, 0, 31, 0, 172, 0, 0, 73 }, new List<int> { 0, 11, 0, 0, 10, 0, 4, 0, 19, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 })
        };
        public static readonly List<ClothX> RandOutF = new List<ClothX>
        {
            new ClothX("F_Highclass_3", new List<int> { 0, 0, -1, 36, 41, 0, 29, 0, 67, 0, 0, 107 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0 }, new List<int> { -1, 10, -1, -1, -1 }, new List<int> { -1, 1, -1, -1, -1 }),
            new ClothX("F_Highclass_4", new List<int> { 0, 0, -1, 7, 27, 0, 11, 0, 39, 0, 0, 66 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Highclass_5", new List<int> { 0, 0, -1, 3, 43, 0, 4, 84, 65, 0, 0, 100 }, new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }, new List<int> { 55, -1, -1, -1, -1 }, new List<int> { 24, -1, -1, -1, -1 }),
            new ClothX("F_Highclass_6", new List<int> { 0, 0, -1, 3, 64, 0, 6, 23, 41, 0, 0, 58 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Highclass_7", new List<int> { 0, 0, -1, 0, 85, 0, 31, 67, 3, 0, 0, 192 }, new List<int> { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 95, -1, 13, -1, -1 }, new List<int> { 6, -1, 0, -1, -1 }),
            new ClothX("F_Highclass_8", new List<int> { 0, 0, -1, 3, 50, 0, 37, 0, 66, 0, 0, 104 }, new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 5, 0, 0, 0 }, new List<int> { -1, 2, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
            new ClothX("F_Highclass_9", new List<int> { 0, 0, -1, 7, 0, 0, 3, 85, 55, 0, 0, 66 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 }, new List<int> { 58, -1, -1, -1, -1 }, new List<int> { 2, -1, -1, -1, -1 }),
             new ClothX("F_Highclass_10", new List<int> { 0, 0, -1, 36, 37, 0, 29, 0, 39, 0, 0, 65 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Highclass_11", new List<int> { 0, 0, -1, 3, 63, 0, 41, 0, 76, 0, 0, 99 }, new List<int> { 0, 0, 0, 0, 2, 0, 2, 0, 3, 0, 0, 2 }, new List<int> { -1, 2, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("F_Highclass_12", new List<int> { 0, 0, -1, 3, 37, 0, 0, 21, 38, 0, 0, 57 }, new List<int> { 0, 0, 0, 0, 5, 0, 2, 0, 2, 0, 0, 5 }, new List<int> { -1, -1, 15, -1, -1 }, new List<int> { -1, -1, 0, -1, -1 }),
             new ClothX("F_Highclass_13", new List<int> { 0, 0, -1, 3, 41, 0, 39, 0, 14, 0, 0, 136 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 }, new List<int> { -1, 4, -1, -1, -1 }, new List<int> { -1, 1, -1, -1, -1 }),
             new ClothX("F_Highclass_14", new List<int> { 40, 0, -1, 3, 27, 0, 7, 0, 3, 0, 0, 98 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 }, new List<int> { -1, 7, -1, -1, -1 }, new List<int> { -1, 2, -1, -1, -1 }),
             new ClothX("F_Highclass_15", new List<int> { 0, 0, -1, 11, 21, 0, 0, 54, 3, 0, 0, 115 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 2 }, new List<int> { 54, -1, -1, -1, -1 }, new List<int> { 7, -1, -1, -1, -1 }),
             new ClothX("F_Highclass_16", new List<int> { 40, 0, -1, 3, 54, 0, 4, 0, 39, 0, 0, 92 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, 11, -1, -1, -1 }, new List<int> { -1, 7, -1, -1, -1 }),
             new ClothX("F_Highclass_17", new List<int> { 0, 0, -1, 3, 54, 0, 8, 0, 44, 0, 0, 66 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 2 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_0", new List<int> { 0, 0, -1, 2, 2, 0, 2, 5, 3, 0, 0, 2 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 4, 0, 0, 0, 6 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_1", new List<int> { 0, 0, -1, 0, 16, 0, 2, 2, 3, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 4, 0, 5, 1, 0, 0, 0, 11 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_2", new List<int> { 0, 0, -1, 9, 4, 0, 13, 1, 3, 0, 0, 9 }, new List<int> { 0, 0, 0, 0, 9, 0, 12, 2, 0, 0, 0, 9 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_3", new List<int> { 0, 0, -1, 3, 2, 0, 16, 2, 3, 0, 0, 3 }, new List<int> { 0, 0, 0, 0, 0, 0, 6, 1, 0, 0, 0, 11 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_4", new List<int> { 0, 0, -1, 2, 3, 0, 16, 1, 3, 0, 0, 2 }, new List<int> { 0, 0, 0, 0, 7, 0, 11, 0, 0, 0, 0, 15 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_5", new List<int> { 0, 0, -1, 3, 3, 0, 16, 1, 3, 0, 0, 3 }, new List<int> { 0, 0, 0, 0, 11, 0, 1, 3, 0, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Midclass_6", new List<int> { 0, 0, -1, 2, 0, 0, 10, 0, 2, 0, 0, 2 }, new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, 0, -1, -1 }, new List<int> { -1, -1, 0, -1, -1 }),
            new ClothX("F_Buisness_0", new List<int> { 0, 0, -1, 3, 41, 0, 29, 20, 39, 0, 0, 97 }, new List<int> { 0, 0, 0, 0, 2, 0, 2, 5, 4, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_1", new List<int> { 0, 0, -1, 7, 54, 0, 0, 22, 38, 0, 0, 139 }, new List<int> { 0, 0, 0, 0, 2, 0, 1, 6, 2, 0, 0, 2 }, new List<int> { 28, -1, -1, -1, -1 }, new List<int> { 4, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_2", new List<int> { 0, 0, -1, 3, 37, 0, 29, 22, 38, 0, 0, 7 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 6, 4, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_3", new List<int> { 0, 0, -1, 1, 64, 0, 29, 0, 13, 0, 0, 137 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 7 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_4", new List<int> { 0, 0, -1, 1, 50, 0, 29, 0, 13, 0, 0, 137 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 10, 0, 0, 8 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_5", new List<int> { 0, 0, -1, 1, 64, 0, 29, 0, 13, 0, 0, 137 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 15, 0, 0, 13 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Buisness_6", new List<int> { 40, 0, -1, 3, 54, 0, 1, 0, 39, 0, 0, 92 }, new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 5, 0, 0, 1 }, new List<int> { -1, 11, -1, -1, -1 }, new List<int> { -1, 2, -1, -1, -1 }),
            new ClothX("F_Buisness_7", new List<int> { 0, 0, -1, 3, 37, 0, 0, 22, 38, 0, 0, 64 }, new List<int> { 0, 0, 0, 0, 2, 0, 3, 0, 3, 0, 0, 2 }, new List<int> { 28, -1, 15, -1, -1 }, new List<int> { 3, -1, 0, -1, -1 }),
            new ClothX("F_Buisness_8", new List<int> { 0, 0, -1, 3, 37, 0, 6, 22, 38, 0, 0, 64 }, new List<int> { 0, 0, 0, 0, 6, 0, 0, 12, 0, 0, 0, 0 }, new List<int> { 28, -1, 15, -1, -1 }, new List<int> { 3, -1, 0, -1, -1 }),
            new ClothX("F_Buisness_9", new List<int> { 0, 0, -1, 3, 37, 0, 20, 22, 38, 0, 0, 64 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 7, 0, 0, 1 }, new List<int> { 28, -1, 15, -1, -1 }, new List<int> { 3, -1, 0, -1, -1 }),
             new ClothX("F_Buisness_10", new List<int> { 40, 0, -1, 6, 8, 0, 8, 0, 22, 0, 0, 58 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_11", new List<int> { 40, 0, -1, 6, 37, 0, 0, 0, 22, 0, 0, 57 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 8 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_12", new List<int> { 40, 0, -1, 1, 27, 0, 7, 21, 38, 0, 0, 6 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_13", new List<int> { 40, 0, -1, 7, 41, 0, 27, 0, 13, 0, 0, 7 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_14", new List<int> { 0, 0, -1, 6, 36, 0, 20, 6, 13, 0, 0, 25 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_15", new List<int> { 0, 0, -1, 6, 6, 0, 13, 6, 25, 0, 0, 7 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Buisness_16", new List<int> { 0, 0, -1, 0, 7, 0, 19, 1, 24, 0, 0, 28 }, new List<int> { 0, 0, 0, 0, 2, 0, 9, 1, 3, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Epslon_1", new List<int> { 21, 0, 0, 3, 111, 0, 29, 99, 6, 0, 0, 285 }, new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_0", new List<int> { 0, 0, -1, 14, 14, 0, 3, 3, 3, 0, 0, 14 }, new List<int> { 0, 0, 0, 0, 8, 0, 1, 5, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_1", new List<int> { 0, 0, -1, 14, 2, 0, 10, 0, 3, 0, 0, 14 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 7 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_2", new List<int> { 0, 0, -1, 7, 14, 0, 11, 2, 15, 0, 0, 10 }, new List<int> { 0, 0, 0, 0, 9, 0, 0, 4, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_3", new List<int> { 0, 0, -1, 11, 2, 0, 10, 3, 3, 0, 0, 11 }, new List<int> { 0, 0, 0, 0, 2, 0, 2, 3, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_4", new List<int> { 0, 0, -1, 14, 12, 0, 10, 3, 3, 0, 0, 14 }, new List<int> { 0, 0, 0, 0, 8, 0, 3, 4, 0, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_5", new List<int> { 0, 0, -1, 7, 2, 0, 11, 0, 16, 0, 0, 10 }, new List<int> { 0, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 7 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_6", new List<int> { 0, 0, -1, 7, 10, 0, 1, 1, 5, 0, 0, 10 }, new List<int> { 0, 0, 0, 0, 2, 0, 13, 1, 0, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Jogger_7", new List<int> { 0, 0, -1, 14, 12, 0, 4, 0, 3, 0, 0, 14 }, new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Services_0", new List<int> { 0, 0, -1, 14, 34, 0, 25, 0, 35, 0, 0, 48 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Services_1", new List<int> { 0, 0, -1, 14, 34, 0, 25, 0, 35, 0, 0, 48 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 45, 0, -1, -1, -1 }, new List<int> { 0, 0, -1, -1, -1 }),
             new ClothX("F_Services_10", new List<int> { 21, 0, 0, 9, 6, 0, 29, 0, 3, 55, 0, 9 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4 }, new List<int> { -1, 11, -1, -1, -1 }, new List<int> { -1, 3, -1, -1, -1 }),
             new ClothX("F_Services_11", new List<int> { 21, 0, 0, 1, 6, 0, 29, 0, 69, 54, 0, 6 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4 }, new List<int> { -1, 11, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("F_Services_12", new List<int> { 21, 0, 0, 3, 7, 0, 13, 0, 39, 53, 0, 57 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_Services_13", new List<int> { 21, 0, 0, 3, 37, 0, 13, 0, 39, 53, 0, 57 }, new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_Services_2", new List<int> { 0, 0, -1, 109, 99, 0, 52, 97, 3, 0, 66, 258 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 121, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_Services_3", new List<int> { 0, 0, -1, 109, 99, 0, 52, 97, 3, 0, 66, 258 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 121, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("F_Services_4", new List<int> { 0, 0, -1, 105, 99, 0, 52, 96, 3, 0, 65, 257 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 121, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_Services_5", new List<int> { 0, 0, -1, 105, 99, 0, 52, 96, 3, 0, 65, 257 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 121, -1, -1, -1, -1 }, new List<int> { 1, -1, -1, -1, -1 }),
            new ClothX("F_Services_6", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 136, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_Services_7", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { 137, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_Services_8", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 137, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_Services_9", new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { 136, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_0", new List<int> { 21, 0, 0, 229, 50, 0, 37, 0, 5, 0, 0, 373 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 17 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_1", new List<int> { 21, 0, 0, 9, 14, 0, 4, 0, 14, 0, 0, 372 }, new List<int> { 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_2", new List<int> { 21, 0, 0, 229, 0, 0, 1, 0, 204, 0, 0, 373 }, new List<int> { 0, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_3", new List<int> { 21, 0, 0, 9, 14, 0, 5, 0, 14, 0, 0, 372 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_4", new List<int> { 21, 0, 0, 3, 90, 0, 63, 117, 207, 0, 0, 231 }, new List<int> { 0, 0, 0, 0, 6, 0, 0, 1, 6, 0, 0, 6 }, new List<int> { 149, -1, -1, -1, -1 }, new List<int> { 14, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_5", new List<int> { 21, 0, 0, 3, 90, 0, 63, 116, 207, 0, 0, 231 }, new List<int> { 0, 0, 0, 0, 8, 0, 0, 1, 5, 0, 0, 8 }, new List<int> { 106, -1, -1, -1, -1 }, new List<int> { 8, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_6", new List<int> { 21, 0, 0, 3, 90, 0, 100, 117, 207, 0, 0, 230 }, new List<int> { 0, 0, 0, 0, 15, 0, 0, 11, 9, 0, 0, 15 }, new List<int> { 103, -1, -1, -1, -1 }, new List<int> { 15, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_7", new List<int> { 21, 0, 0, 3, 90, 0, 100, 115, 207, 0, 0, 230 }, new List<int> { 0, 0, 0, 0, 16, 0, 0, 4, 8, 0, 0, 16 }, new List<int> { 104, -1, -1, -1, -1 }, new List<int> { 16, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_8", new List<int> { 21, 0, 0, 9, 45, 0, 76, 0, 14, 0, 0, 232 }, new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 0, 0, 0, 23 }, new List<int> { 141, -1, -1, -1, -1 }, new List<int> { 19, -1, -1, -1, -1 }),
            new ClothX("F_CayoPerico_9", new List<int> { 21, 0, 0, 14, 1, 0, 62, 0, 208, 0, 0, 337 }, new List<int> { 0, 0, 0, 0, 3, 0, 23, 0, 14, 0, 0, 12 }, new List<int> { 105, -1, -1, -1, -1 }, new List<int> { 23, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_10", new List<int> { 21, 0, 0, 14, 128, 0, 55, 0, 208, 0, 0, 212 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 18 }, new List<int> { 60, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_11", new List<int> { 21, 0, 0, 9, 128, 0, 74, 0, 14, 0, 0, 232 }, new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 24 }, new List<int> { 106, -1, -1, -1, -1 }, new List<int> { 24, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_12", new List<int> { 21, 0, 0, 4, 89, 0, 64, 0, 3, 0, 0, 247 }, new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_13", new List<int> { 21, 0, 0, 4, 89, 0, 76, 0, 3, 0, 0, 5 }, new List<int> { 0, 0, 0, 0, 17, 0, 23, 0, 0, 0, 0, 7 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_14", new List<int> { 21, 0, 0, 15, 130, 0, 25, 0, 208, 0, 0, 15 }, new List<int> { 0, 0, 0, 0, 19, 0, 0, 0, 8, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_15", new List<int> { 21, 0, 0, 12, 130, 0, 101, 0, 208, 0, 0, 118 }, new List<int> { 0, 0, 0, 0, 16, 0, 0, 0, 2, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_16", new List<int> { 21, 185, 0, 215, 101, 0, 74, 0, 14, 0, 0, 261 }, new List<int> { 0, 8, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_17", new List<int> { 21, 52, 0, 215, 130, 0, 64, 0, 14, 0, 0, 351 }, new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 }, new List<int> { 146, -1, -1, -1, -1 }, new List<int> { 0, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_18", new List<int> { 21, 132, 0, 219, 131, 0, 76, 0, 14, 0, 0, 259 }, new List<int> { 0, 8, 0, 0, 1, 0, 0, 0, 0, 0, 0, 25 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_19", new List<int> { 21, 185, 0, 215, 136, 0, 100, 0, 14, 0, 0, 343 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_20", new List<int> { 21, 0, 0, 3, 0, 0, 9, 0, 39, 0, 0, 353 }, new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 7, 0, 0, 3 }, new List<int> { -1, 11, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("F_CayoPerico_21", new List<int> { 21, 0, 0, 229, 1, 0, 3, 0, 204, 0, 0, 364 }, new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 24 }, new List<int> { -1, 2, -1, -1, -1 }, new List<int> { -1, 0, -1, -1, -1 }),
             new ClothX("F_CayoPerico_22", new List<int> { 21, 0, 0, 9, 23, 0, 1, 0, 3, 0, 0, 9 }, new List<int> { 0, 0, 0, 0, 5, 0, 1, 0, 0, 0, 0, 1 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_23", new List<int> { 21, 0, 0, 229, 4, 0, 13, 0, 4, 0, 0, 364 }, new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 20 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_24", new List<int> { 21, 0, 0, 14, 0, 0, 3, 0, 209, 0, 0, 14 }, new List<int> { 0, 0, 0, 0, 1, 0, 2, 0, 12, 0, 0, 4 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_25", new List<int> { 21, 186, 0, 14, 124, 0, 97, 0, 209, 0, 0, 14 }, new List<int> { 0, 2, 0, 0, 0, 0, 1, 0, 1, 0, 0, 3 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_26", new List<int> { 21, 0, 0, 3, 123, 0, 79, 0, 209, 0, 0, 316 }, new List<int> { 0, 0, 0, 0, 9, 0, 21, 0, 2, 0, 0, 23 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 }),
             new ClothX("F_CayoPerico_27", new List<int> { 21, 101, 0, 14, 123, 0, 32, 0, 209, 0, 0, 68 }, new List<int> { 0, 11, 0, 0, 10, 0, 4, 0, 19, 0, 0, 10 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 })
        };

        public static List<string> BoolSwitch;
        public static List<string> RaceWeatherList;
        public static List<string> RaceTimeList;
        public static List<string> RaceClassList;

        public static int AddRelationshipGroup(string Group)
        {
            //Function.Call<int>(Hash.ADD_RELATIONSHIP_GROUP,)   
            return World.AddRelationshipGroup(Group);
        }
        private static void FixTheOutfits()
        {
            string sWardFold = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/";

            if (Directory.Exists(sWardFold))
            {
                string MainFolder = "" + Directory.GetCurrentDirectory() + "/Outfits";

                if (!Directory.Exists(MainFolder))
                    Directory.CreateDirectory(MainFolder);

                string[] MyXmls = Directory.GetFiles(sWardFold);

                for (int i = 0; i < MyXmls.Count(); i++)
                {
                    if (MyXmls[i].Contains(".Xml"))
                    {
                        if (MyXmls[i].Contains("DefaultOut"))
                            File.Delete(MyXmls[i]);
                        else
                        {
                            string sFold = "";
                            if (MyXmls[i].Contains("FreemodeFemale") || MyXmls[i].Contains("FreeFemale"))
                                sFold = "Female";
                            else if (MyXmls[i].Contains("FreemodeMale") || MyXmls[i].Contains("FreeMale"))
                                sFold = "Male";
                            else
                            {
                                string sName = Path.GetFileName(MyXmls[i]);
                                sFold = sName.Substring(0, sName.Length - 4);
                            }

                            string OutFolder = "" + Directory.GetCurrentDirectory() + "/Outfits/" + sFold;

                            if (!Directory.Exists(OutFolder))
                                Directory.CreateDirectory(OutFolder);

                            List<ClothX> outPut = ReadWriteXML.LoadWards(MyXmls[i]);

                            for (int j = 0; j < outPut.Count; j++)
                                EntityLog.WriteClothIni(OutFolder + "/" + outPut[j].Title + ".ini", outPut[j]);

                            File.Delete(MyXmls[i]);
                        }
                    }
                }
            }
        }
        private static void FolderCheck()
        {
            //if (!Directory.Exists(sWardFold))
            //    Directory.CreateDirectory(sWardFold);

            if (!Directory.Exists(sSettingFold))
                Directory.CreateDirectory(sSettingFold);

            if (!Directory.Exists(sRandomNum))
                Directory.CreateDirectory(sRandomNum);

            if (!Directory.Exists(sRaceFolder))
                Directory.CreateDirectory(sRaceFolder);

            if (!Directory.Exists(sNSPMLanguage))
                Directory.CreateDirectory(sNSPMLanguage);

            if (!Directory.Exists(sExMissions))
                Directory.CreateDirectory(sExMissions);

            if (!Directory.Exists(sExMissionsBomb))
                Directory.CreateDirectory(sExMissionsBomb);

            if (!Directory.Exists(sExMissionsRace))
                Directory.CreateDirectory(sExMissionsRace);

            if (!Directory.Exists(sExMissionsShark))
                Directory.CreateDirectory(sExMissionsShark);

            if (!Directory.Exists(sExMissionsTruck))
                Directory.CreateDirectory(sExMissionsTruck);
        }
        public static void DataStoreLoad()
        {
            LoggerLight.LogThis("DataStoreLoad");

            FolderCheck();
            EntityLog.ClearThis();

            FixTheOutfits();

            OnTheJob = false;
            OptionsMen = false;
            LookingForPB = false;
            OnlineStuffLoaded = false;
            OnCayoLand = false;
            MenuOpen = false;
            BankTransfer = false;
            OldYacht = false;

            iCoinBats = 0;
            iLookForPB = 0;
            iBuildingUp = 0;
            iFolPos = 0;
            iSoundId = 0;
            iDisplayAch = 0;
            iRaceSym = -1;

            iPlayerGroup = 0;
            GP_Player = Game.Player.Character.RelationshipGroup;

            vPhoneCorona = Vector3.Zero;
            SharedVeh = null;

            if (File.Exists(sNSPMSet))
            {
                MySettings = EntityLog.LoadXmlSettings(sNSPMSet);
                EntityLog.Settings_Out();
                File.Delete(sNSPMSet);
            }
            else if (File.Exists(sNSPMiniSet))
                MySettings = EntityLog.LoadIniSettings();
            else
            {
                MySettings = new XmlSetings();
                EntityLog.Settings_Out();
            }
            MyLang = LingoReturns();
            MyDatSet = NSBanking.LoadDat();
            MyAchivments = NSBanking.LoadGooals();
            MyAssets = SetMyAss();
            MyCustomVeh = ReadWriteXML.LoadXmlCustom(sNSPMAddonCarz);
            UpdateCustomCars();
            LangForMenus();
            Hare = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Audio/Hare_Krishna_Chant.wav");
            Chatter = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Audio/PhoneTalk.wav");
            Drilar = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Audio/edrill.wav");
            CashTil = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Audio/Till.wav");
            LiftDoor = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Audio/LiftDoor.wav");

            Logging = MySettings.Debug;

            Hare.Load();
            Chatter.Load();
            Drilar.Load();
            CashTil.Load();
            LiftDoor.Load();
            LoadInExMissions();

            vOldPhoneBoxList = PhoneOff();

            if (!Directory.Exists(sRaceFolder))
                Directory.CreateDirectory(sRaceFolder);

            MyContacts = ReadWriteXML.LoadXmlContacts(sNSPMCont);
            PlayerWeapXList = new List<PlayerWeaps>();

            OnLoadup();
            bHasLoaded = true;
            //ReadWriteXML.SaveXmlLing(MyLang, sNSPMLangOut); //Language Output.Xml
        }
        private static void LoadInExMissions()
        {
            LoggerLight.LogThis("LoadInExMissions");
            if (Directory.Exists(sExMissionsRace))
            {
                string[] MyFiles = Directory.GetFiles(sExMissionsRace);
                for (int i = 0; i < MyFiles.Count(); i++)
                {
                    MuliRace ThisRace = ReadWriteXML.LoadRaceists(MyFiles[i]);

                    if (ThisRace != null)
                        MissionData.MyRacists.Add(ThisRace);
                }
            }

            if (Directory.Exists(sExMissionsBomb))
            {
                string[] MyFiles = Directory.GetFiles(sExMissionsBomb);
                for (int i = 0; i < MyFiles.Count(); i++)
                {
                    List<BombSquad> Bomber = ReadWriteXML.LoadBombing(MyFiles[i]);
                    if (Bomber != null)
                    {
                        for (int ii = 0; ii < Bomber.Count; ii++)
                        {
                            if (Bomber[ii].Zone == 1)
                                MissionData.BsArea01.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 2)
                                MissionData.BsArea02.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 3)
                                MissionData.BsArea03.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 4)
                                MissionData.BsArea04.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 5)
                                MissionData.BsArea05.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 6)
                                MissionData.BsArea06.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 7)
                                MissionData.BsArea07.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 8)
                                MissionData.BsArea08.Add(Bomber[ii]);
                            else if (Bomber[ii].Zone == 9)
                                MissionData.BsArea09.Add(Bomber[ii]);
                        }
                    }
                }
            }

            if (Directory.Exists(sExMissionsShark))
            {
                string[] MyFiles = Directory.GetFiles(sExMissionsShark);
                for (int i = 0; i < MyFiles.Count(); i++)
                {
                    List<LoanSharks> Sharky = ReadWriteXML.LoadSharky(MyFiles[i]);
                    if (Sharky != null)
                    {
                        for (int ii = 0; ii < Sharky.Count; ii++)
                        {
                            if (Sharky[ii].Zone == 1)
                                MissionData.Sharky01.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 2)
                                MissionData.Sharky02.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 3)
                                MissionData.Sharky03.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 4)
                                MissionData.Sharky04.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 5)
                                MissionData.Sharky05.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 6)
                                MissionData.Sharky06.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 7)
                                MissionData.Sharky07.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 8)
                                MissionData.Sharky08.Add(Sharky[ii]);
                            else if (Sharky[ii].Zone == 9)
                                MissionData.Sharky09.Add(Sharky[ii]);
                        }
                    }
                }
            }

            if (Directory.Exists(sExMissionsTruck))
            {
                string[] MyFiles = Directory.GetFiles(sExMissionsTruck);
                for (int i = 0; i < MyFiles.Count(); i++)
                {
                    List<Truckers> MotherTrucker = ReadWriteXML.LoadTrucking(MyFiles[i]);
                    if (MotherTrucker != null)
                    {
                        for (int ii = 0; ii < MotherTrucker.Count; ii++)
                        {
                            if (MotherTrucker[ii].Area == 1)
                                MissionData.TruckStop01.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 2)
                                MissionData.TruckStop02.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 3)
                                MissionData.TruckStop03.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 4)
                                MissionData.TruckStop04.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 5)
                                MissionData.TruckStop05.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 6)
                                MissionData.TruckStop06.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 7)
                                MissionData.TruckStop07.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 8)
                                MissionData.TruckStop08.Add(MotherTrucker[ii]);
                            else if (MotherTrucker[ii].Area == 9)
                                MissionData.TruckStop09.Add(MotherTrucker[ii]);
                        }
                    }
                }
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

            ByPassPlayZ = File.Exists(sPlayZeroFind);

            if (MySettings.YachtPrice < 0)
                MySettings.YachtPrice = 0;

            if (MySettings.PreLoadOnline)
                LoadOnlineIps(true);

            Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, true);
            UI.Notify("New Street Phone Missions " + sVersion + " by ~b~Adopocalipt ~w~Loaded.");

            if (File.Exists(sFunkFind))
                GotNoFunk = false;
            else
                GotNoFunk = true;

            LookingForPB = true;

            EntityClear.PassiveVeh = new List<Vehicle>();
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
        public static Lingoo LangRewite()
        {
            LoggerLight.LogThis("LangRewite");

            Lingoo ThisLang = new Lingoo(sMaptext, sMistext, sContext, sJobtext, sOthertext, sContactLang, sYachtLang);

            return ThisLang;
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
        public static void UpdateCustomCars()
        {
            for (int x = 0; x < MyCustomVeh.CustomCars.Count; x++)
            {
                int iAm = MyCustomVeh.CustomCars[x].VehList;
                string Vic = MyCustomVeh.CustomCars[x].VehicleS;
                bool bAdd = true;

                if (iAm == 1)
                {
                    for (int i = 0; i < ReturnStuff.SuperList.Count; i++)
                    {
                        if (ReturnStuff.SuperList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SuperList.Add(Vic);
                }
                else if (iAm == 2)
                {
                    for (int i = 0; i < ReturnStuff.SportList.Count; i++)
                    {
                        if (ReturnStuff.SportList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SportList.Add(Vic);
                }
                else if (iAm == 3)
                {
                    for (int i = 0; i < ReturnStuff.CoupeList.Count; i++)
                    {
                        if (ReturnStuff.CoupeList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.CoupeList.Add(Vic);
                }
                else if (iAm == 4)
                {
                    for (int i = 0; i < ReturnStuff.MuscleList.Count; i++)
                    {
                        if (ReturnStuff.MuscleList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.MuscleList.Add(Vic);
                }
                else if (iAm == 5)
                {
                    for (int i = 0; i < ReturnStuff.SportClassList.Count; i++)
                    {
                        if (ReturnStuff.SportClassList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SportClassList.Add(Vic);
                }
                else if (iAm == 6)
                {
                    for (int i = 0; i < ReturnStuff.SedanList.Count; i++)
                    {
                        if (ReturnStuff.SedanList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SedanList.Add(Vic);
                }
                else if (iAm == 7)
                {
                    for (int i = 0; i < ReturnStuff.SUVList.Count; i++)
                    {
                        if (ReturnStuff.SUVList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SUVList.Add(Vic);
                }
                else if (iAm == 8)
                {
                    for (int i = 0; i < ReturnStuff.CompactList.Count; i++)
                    {
                        if (ReturnStuff.CompactList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.CompactList.Add(Vic);
                }
                else if (iAm == 9)
                {
                    for (int i = 0; i < ReturnStuff.OffRoadList.Count; i++)
                    {
                        if (ReturnStuff.OffRoadList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.OffRoadList.Add(Vic);
                }
                else if (iAm == 10)
                {
                    for (int i = 0; i < ReturnStuff.MotorBikeList.Count; i++)
                    {
                        if (ReturnStuff.MotorBikeList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.MotorBikeList.Add(Vic);
                }
                else if (iAm == 11)
                {
                    for (int i = 0; i < ReturnStuff.BennysVeh.Count; i++)
                    {
                        if (ReturnStuff.BennysVeh[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.BennysVeh.Add(Vic);
                }
                else if (iAm == 12)
                {
                    for (int i = 0; i < ReturnStuff.BusList.Count; i++)
                    {
                        if (ReturnStuff.BusList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.BusList.Add(Vic);
                }
                else if (iAm == 13)
                {
                    for (int i = 0; i < ReturnStuff.IndustrialList.Count; i++)
                    {
                        if (ReturnStuff.IndustrialList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.IndustrialList.Add(Vic);
                }
                else if (iAm == 14)
                {
                    for (int i = 0; i < ReturnStuff.TruckList.Count; i++)
                    {
                        if (ReturnStuff.TruckList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.TruckList.Add(Vic);
                }
                else if (iAm == 15)
                {
                    for (int i = 0; i < ReturnStuff.ComercialList.Count; i++)
                    {
                        if (ReturnStuff.ComercialList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.ComercialList.Add(Vic);
                }
                else if (iAm == 16)
                {
                    for (int i = 0; i < ReturnStuff.ArmoredList.Count; i++)
                    {
                        if (ReturnStuff.ArmoredList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.ArmoredList.Add(Vic);
                }
                else if (iAm == 17)
                {
                    for (int i = 0; i < ReturnStuff.WeaponisedList.Count; i++)
                    {
                        if (ReturnStuff.WeaponisedList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.WeaponisedList.Add(Vic);
                }
                else if (iAm == 19)
                {
                    for (int i = 0; i < ReturnStuff.OpenWheelList.Count; i++)
                    {
                        if (ReturnStuff.OpenWheelList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.OpenWheelList.Add(Vic);
                }
                else if (iAm == 20)
                {
                    for (int i = 0; i < ReturnStuff.CartList.Count; i++)
                    {
                        if (ReturnStuff.CartList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.CartList.Add(Vic);
                }
                else if (iAm == 21)
                {
                    for (int i = 0; i < ReturnStuff.CycleList.Count; i++)
                    {
                        if (ReturnStuff.CycleList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.CycleList.Add(Vic);
                }
                else if (iAm == 22)
                {
                    for (int i = 0; i < ReturnStuff.PlaneComList.Count; i++)
                    {
                        if (ReturnStuff.PlaneComList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.PlaneComList.Add(Vic);
                }
                else if (iAm == 23)
                {
                    for (int i = 0; i < ReturnStuff.PlaneFightList.Count; i++)
                    {
                        if (ReturnStuff.PlaneFightList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.PlaneFightList.Add(Vic);
                }
                else if (iAm == 24)
                {
                    for (int i = 0; i < ReturnStuff.HeliComList.Count; i++)
                    {
                        if (ReturnStuff.HeliComList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.HeliComList.Add(Vic);
                }
                else if (iAm == 25)
                {
                    for (int i = 0; i < ReturnStuff.HeliFightList.Count; i++)
                    {
                        if (ReturnStuff.HeliFightList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.HeliFightList.Add(Vic);
                }
                else if (iAm == 26)
                {
                    for (int i = 0; i < ReturnStuff.BoatList.Count; i++)
                    {
                        if (ReturnStuff.BoatList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.BoatList.Add(Vic);
                }
                else if (iAm == 27)
                {
                    for (int i = 0; i < ReturnStuff.FloatersList.Count; i++)
                    {
                        if (ReturnStuff.FloatersList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.FloatersList.Add(Vic);
                }
                else if (iAm == 28)
                {
                    for (int i = 0; i < ReturnStuff.TowingList.Count; i++)
                    {
                        if (ReturnStuff.TowingList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.TowingList.Add(Vic);
                }
                else if (iAm == 29)
                {
                    for (int i = 0; i < ReturnStuff.SubList.Count; i++)
                    {
                        if (ReturnStuff.SubList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.SubList.Add(Vic);
                }
                else if (iAm == 30)
                {
                    for (int i = 0; i < ReturnStuff.JetSkiList.Count; i++)
                    {
                        if (ReturnStuff.JetSkiList[i] == Vic)
                            bAdd = false;
                    }
                    if (bAdd)
                        ReturnStuff.JetSkiList.Add(Vic);
                }
            }
        }
        public static void LoadOnlineIps(bool bAdd)
        {
            LoggerLight.LogThis("LoadOnlineIps, bAdd == " + bAdd);

            List<string> sAddIpl = new List<string>
            {
                "xm_bunkerentrance_door",
                "xm_hatch_01_cutscene",
                "xm_hatch_02_cutscene",
                "xm_hatch_03_cutscene",
                "xm_hatch_04_cutscene",
                "xm_hatch_06_cutscene",
                "xm_hatch_07_cutscene",
                "xm_hatch_08_cutscene",
                "xm_hatch_09_cutscene",
                "xm_hatch_10_cutscene",
                "xm_hatch_closed",
                "xm_hatches_terrain",
                "xm_hatches_terrain_lod",
                "xm_mpchristmasadditions",
                "xm_siloentranceclosed_x17",

                "gr_case10_bunkerclosed",
                "gr_case9_bunkerclosed",
                "gr_case3_bunkerclosed",
                "gr_case0_bunkerclosed",
                "gr_case1_bunkerclosed",
                "gr_case2_bunkerclosed",
                "gr_case5_bunkerclosed",
                "gr_case7_bunkerclosed",
                "gr_case11_bunkerclosed",
                "gr_case6_bunkerclosed",
                "gr_case4_bunkerclosed",

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
                "vw_dlc_casino_door_lod",

                "ba_barriers_case1",
                "ba_barriers_case2",
                "ba_barriers_case3",
                "ba_barriers_case4",
                "ba_barriers_case5",
                "ba_barriers_case6",
                "ba_barriers_case7",
                "ba_barriers_case8",
                "ba_barriers_case9",
                "bkr_bi_hw1_13_int"
            };

            if (bAdd)
            {
                /*
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call(Hash._LOAD_MP_DLC_MAPS);

                Function.Call((Hash)0x9BAE5AD2508DF078, false);

                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
                }
                */
                EntityLog.CreateIni(DataStore.sAdd_Mp_IPL, new List<string> { "IplsAGoGo" });
                OnlineStuffLoaded = true;
            }
            else
            {
                /*
                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REMOVE_IPL, sAddIpl[i]);
                }


                Function.Call(Hash._ENABLE_MP_DLC_MAPS, false);
                Function.Call(Hash._UNLOAD_MP_DLC_MAPS);
                */
                EntityLog.CreateIni(DataStore.sRemove_Mp_IPL, new List<string> { "IplsAGoGo" });
                OnlineStuffLoaded = false;
            }
        }
        public static void AddHeistYacht(bool bAdd)
        {
            LoggerLight.LogThis("AddHeistYacht");

            if (!OnlineStuffLoaded)
                LoadOnlineIps(true);

            List<string> sAddIpl = new List<string>
            {
                "hei_yacht_heist_Lounge",
                "hei_yacht_heist_LODLights",
                "hei_yacht_heist_enginrm",
                "hei_yacht_heist_DistantLights",
                "hei_yacht_heist_Bridge",
                "hei_yacht_heist_Bedrm",
                "hei_yacht_heist_Bar",
                "hei_yacht_heist"
            };

            if (bAdd)
            {
                if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, "smboat"))
                {
                    Function.Call(Hash.REMOVE_IPL, "smboat");
                    OldYacht = true;
                }
                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
                }
                YachtLoaded = true;
            }
            else
            {
                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REMOVE_IPL, sAddIpl[i]);
                }
                if (OldYacht)
                {
                    if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, "smboat"))
                        Function.Call(Hash.REQUEST_IPL, "smboat");
                }
                YachtLoaded = false;
            }
        }
        public static void LangForMenus()
        {
            RaceClassList = new List<string>
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
            RaceTimeList = new List<string>
            {
                DataStore.MyLang.Othertext[158],
                DataStore.MyLang.Othertext[159],
                DataStore.MyLang.Othertext[160],
                DataStore.MyLang.Othertext[161]
            };
            RaceWeatherList = new List<string>
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
            BoolSwitch = new List<string>
            {
                DataStore.MyLang.Othertext[162],
                DataStore.MyLang.Othertext[163]
            };
        }
    }
}
