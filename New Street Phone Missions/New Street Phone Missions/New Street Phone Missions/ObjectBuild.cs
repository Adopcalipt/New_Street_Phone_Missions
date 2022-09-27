using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class ObjectBuild
    {
        private static readonly List<string> MidWeapList = new List<string>
        {
            "WEAPON_advancedrifle",
            "WEAPON_assaultrifle",
            "WEAPON_assaultshotgun",
            "WEAPON_assaultsmg",
            "WEAPON_bullpuprifle",
            "WEAPON_bullpupshotgun",
            "WEAPON_carbinerifle",
            "WEAPON_combatpdw",
            "WEAPON_compactrifle",
            "WEAPON_dbshotgun",
            "WEAPON_gusenberg",
            "WEAPON_heavyshotgun",
            "WEAPON_pumpshotgun",
            "WEAPON_specialcarbine",
            "WEAPON_autoshotgun"
        };
        private static readonly List<string> SmallWeapList = new List<string>
        {
            "WEAPON_appistol",
            "WEAPON_doubleaction",
            "WEAPON_heavypistol",
            "WEAPON_machinepistol",
            "WEAPON_marksmanpistol",
            "WEAPON_microsmg",
            "WEAPON_pistol",
            "WEAPON_pistol50",
            "WEAPON_revolver",
            "WEAPON_snspistol",
            "WEAPON_vintagepistol"
        };
        private static readonly List<string> MelleWeapList = new List<string>
        {
            "WEAPON_dagger",  //0x92A27487",
            "WEAPON_bat",  //0x958A4A8F",
            "WEAPON_bottle",  //0xF9E6AA4B",
            "WEAPON_crowbar",  //0x84BD7BFD",
            "WEAPON_golfclub",  //0x440E4788",
            "WEAPON_hammer",  //0x4E875F73",
            "WEAPON_hatchet",  //0xF9DCBF2D",
            "WEAPON_knuckle",  //0xD8DF3C3C",
            "WEAPON_knife",  //0x99B507EA",
            "WEAPON_machete",  //0xDD5DF8D9",
            "WEAPON_switchblade",  //0xDFE37640",
            "WEAPON_nightstick",  //0x678B81B1",
            "WEAPON_wrench",  //0x19044EE0",
            "WEAPON_battleaxe",  //0xCD274149",
            "WEAPON_poolcue",  //0x94117305",
            "WEAPON_stone_hatchet"  //0x3813FC08"--17
        };
        private static readonly List<string> SitChair = new List<string>
        {
            "PROP_HUMAN_SEAT_CHAIR",
            "PROP_HUMAN_SEAT_CHAIR_UPRIGHT"
        };
        private static readonly List<string> SitDeck = new List<string>
        {
            "PROP_HUMAN_SEAT_DECKCHAIR",
            "PROP_HUMAN_SEAT_DECKCHAIR_DRINK"
        };
        private static readonly List<string> SitBench = new List<string>
        {
            "PROP_HUMAN_SEAT_BENCH",
            "PROP_HUMAN_SEAT_BENCH_DRINK",
            "PROP_HUMAN_SEAT_BENCH_DRINK_BEER",
            "PROP_HUMAN_SEAT_BENCH_FOOD"
        };

        private static readonly List<VehBlips> vehBlips = new List<VehBlips>
        {
            new VehBlips("BUFFALO4",825),
            new VehBlips("CHAMPION",824),
            new VehBlips("DEITY",823),
            new VehBlips("GRANGER2",821),
            new VehBlips("JUBILEE",820),
            new VehBlips("PATRIOT3",818),
            new VehBlips("CRUSADER",800),
            new VehBlips("SLAMVAN2",799),
            new VehBlips("SLAMVAN3", 799),
            new VehBlips("VALKYRIE", 759),
            new VehBlips("VALKYRIE2", 759),
            new VehBlips("SQUADDIE", 757),
            new VehBlips("ardent", 756),///Retro Sport...       
            new VehBlips("cheetah2", 756),///Retro Sport...      
            new VehBlips("infernus2", 756),///Retro Sport...      
            new VehBlips("monroe", 756),///Retro Sport...      
            new VehBlips("stromberg", 756),///Retro Sport...      
            new VehBlips("torero", 756),///Retro Sport...      
            new VehBlips("turismo2", 756),///Retro Sport...      
            new VehBlips("toreador", 756),///Retro Sport...         
            new VehBlips("PATROLBOAT",755),
            new VehBlips("DINGHY5",754),
            new VehBlips("DINGHY5",754),
            new VehBlips("seasparrow2", 753),
            new VehBlips("barracks", 750),
            new VehBlips("barracks3", 750),
            new VehBlips("verus", 749),
            new VehBlips("veto2", 748),
            new VehBlips("veto", 747),
            new VehBlips("avisa", 746),
            new VehBlips("WINKY", 745),
            new VehBlips("ZHABA", 737),
            new VehBlips("VAGRANT", 736),
            new VehBlips("OUTLAW", 735),
            new VehBlips("everon", 734),
            new VehBlips("formula",726),
            new VehBlips("formula2",726),
            new VehBlips("openwheel1",726),
            new VehBlips("openwheel2",726),
            new VehBlips("STRETCH",724),
            new VehBlips("ZR380", 669),
            new VehBlips("ZR3802", 669),
            new VehBlips("ZR3803", 669),
            new VehBlips("SLAMVAN4", 668),
            new VehBlips("SLAMVAN5", 668),
            new VehBlips("SLAMVAN6", 668),
            new VehBlips("SCARAB", 667),
            new VehBlips("SCARAB2", 667),
            new VehBlips("SCARAB3", 667),
            new VehBlips("MONSTER3", 666),
            new VehBlips("MONSTER4", 666),
            new VehBlips("MONSTER5", 666),
            new VehBlips("ISSI4", 665),
            new VehBlips("ISSI5", 665),
            new VehBlips("ISSI6", 665),
            new VehBlips("IMPERATOR", 664),
            new VehBlips("IMPERATOR2", 664),
            new VehBlips("IMPERATOR3", 664),
            new VehBlips("IMPALER2", 663),
            new VehBlips("IMPALER3", 663),
            new VehBlips("IMPALER4", 663),
            new VehBlips("DOMINATOR4", 662),
            new VehBlips("DOMINATOR5", 662),
            new VehBlips("DOMINATOR6", 662),
            new VehBlips("CERBERUS", 660),
            new VehBlips("CERBERUS2", 660),
            new VehBlips("CERBERUS3", 660),
            new VehBlips("BRUTUS", 659),
            new VehBlips("BRUTUS2", 659),
            new VehBlips("BRUTUS3", 659),
            new VehBlips("BRUISER", 658),
            new VehBlips("BRUISER2", 658),
            new VehBlips("BRUISER3", 658),
            new VehBlips("STRIKEFORCE", 640),
            new VehBlips("OPPRESSOR2", 639),
            new VehBlips("SPEEDO4", 637),
            new VehBlips("MULE4", 636),
            new VehBlips("POUNDER2", 635),
            new VehBlips("scramjet", 634),
            new VehBlips("ambulance",632),
            new VehBlips("pbus2",631),
            new VehBlips("caracara",613),
            new VehBlips("seasparrow", 612),
            new VehBlips("APC", 603),
            new VehBlips("akula", 602),
            new VehBlips("insurgent", 601),
            new VehBlips("insurgent3", 601),
            new VehBlips("volatol", 600),
            new VehBlips("alkonost", 600),
            new VehBlips("KHANJALI", 598),
            new VehBlips("DELUXO",  596),
            new VehBlips("bombushka", 585),
            new VehBlips("seabreeze", 584),
            new VehBlips("STARLING", 583),
            new VehBlips("ROGUE", 582),
            new VehBlips("PYRO", 581),
            new VehBlips("nokota", 580),
            new VehBlips("MOLOTOK", 579),
            new VehBlips("mogul", 578),
            new VehBlips("microlight", 577),
            new VehBlips("HUNTER", 576),
            new VehBlips("howard", 575),
            new VehBlips("havok", 574),
            new VehBlips("tula", 573),
            new VehBlips("alphaz1", 572),
            new VehBlips("tampa3", 562),//truureted something
            new VehBlips("DUNE3", 561),
            new VehBlips("HALFTRACK", 560),
            new VehBlips("OPPRESSOR", 559),
            //new VehBlips("", 558),//something somthing turreted
            new VehBlips("TECHNICAL2", 534),
            new VehBlips("voltic2", 533),
            new VehBlips("wastelander", 532),
            new VehBlips("DUNE4", 531),
            new VehBlips("DUNE5", 531),
            new VehBlips("RUINER2", 530),
            new VehBlips("PHANTOM2", 528),
            new VehBlips("hakuchou",522),//ModSportsBike
            new VehBlips("hakuchou2",522),//ModSportsBike
            new VehBlips("shotaro",522),//ModSportsBike
            new VehBlips("pbus",513),//BusssAny
            new VehBlips("blazer",512),//QuadAny
            new VehBlips("blazer2",512),//QuadAny
            new VehBlips("blazer3",512),//QuadAny
            new VehBlips("blazer4",512),//QuadAny
            new VehBlips("blazer5",512),//QuadAny
            new VehBlips("cargobob", 481),
            new VehBlips("cargobob2", 481),
            new VehBlips("cargobob3", 481),
            new VehBlips("cargobob4", 481),
            new VehBlips("armytanker", 479),//Trailler Box
            new VehBlips("armytrailer", 479),//Trailler Box
            new VehBlips("baletrailer", 479),//Trailler Box
            new VehBlips("boattrailer", 479),//Trailler Box
            new VehBlips("docktrailer", 479),//Trailler Box
            new VehBlips("freighttrailer", 479),//Trailler Box
            new VehBlips("graintrailer", 479),//Trailler Box
            new VehBlips("tr2", 479),//Trailler Box
            new VehBlips("tr3", 479),//Trailler Box
            new VehBlips("tr4", 479),//Trailler Box
            new VehBlips("trflat", 479),//Trailler Box
            new VehBlips("tvtrailer", 479),//Trailler Box
            new VehBlips("tanker", 479),//Trailler Box
            new VehBlips("tanker2", 479),//Trailler Box
            new VehBlips("trailerlarge", 479),//Trailler Box
            new VehBlips("trailerlogs", 479),//Trailler Box
            new VehBlips("trailersmall", 479),//Trailler Box
            new VehBlips("tanker", 479),//Trailler Box
            new VehBlips("trailers", 479),//Trailler Box
            new VehBlips("trailers2", 479),//Trailler Box
            new VehBlips("trailers3", 479),//Trailler Box
            new VehBlips("trailers4", 479),//Trailler Box
            new VehBlips("barracks2", 477),//Truck any---not intrucks
            new VehBlips("scrap", 477),//Truck any---not intrucks
            new VehBlips("towtruck", 477),//Truck any---not intrucks
            new VehBlips("rallytruck", 477),//Truck any---not intrucks
            new VehBlips("brickade", 477),//Truck any---not intrucks
            new VehBlips("firetruk",477),
            new VehBlips("seashark", 471),//Seashark
            new VehBlips("seashark2", 471),//Seashark
            new VehBlips("seashark3", 471),//Seashark
            new VehBlips("limo2", 460),
            new VehBlips("technical", 426),
            new VehBlips("technical3", 426),
            new VehBlips("RHINO", 421),
            new VehBlips("marquis",410),
            new VehBlips("avarus",348),//lost bike
            new VehBlips("chimera",348),//lost bike
            new VehBlips("cliffhanger",348),//lost bike
            new VehBlips("daemon",348),//lost bike
            new VehBlips("daemon2",348),//lost bike
            new VehBlips("gargoyle",348),//lost bike
            new VehBlips("hexer",348),//lost bike
            new VehBlips("innovation",348),//lost bike
            new VehBlips("ratbike",348),//lost bike
            new VehBlips("sanctus",348),//lost bike
            new VehBlips("wolfsbane",348),//lost bike
            new VehBlips("zombiea",348),//lost bike
            new VehBlips("zombieb",348),//lost bike
            new VehBlips("trash",318),
            new VehBlips("trash2",318),
            new VehBlips("jet",307),
            new VehBlips("luxor",307),
            new VehBlips("luxor2",307),
            new VehBlips("miljet",307),
            new VehBlips("nimbus",307),
            new VehBlips("shamal",307),
            new VehBlips("vestra",307),
            new VehBlips("velum",251),
            new VehBlips("velum2",251),
            new VehBlips("stunt",251),
            new VehBlips("mammatus",251),
            new VehBlips("duster",251),
            new VehBlips("dodo",251),
            new VehBlips("cuban800",251),
            new VehBlips("taxi",198),
            new VehBlips("dune",147),
            new VehBlips("stockade",67)
        };

        public static Ped NPCSpawn(string sPed, Vector3 vLocal, float fAce, bool bArmor, int iHeal, int iTask, int iSeat, Vehicle vMyCar, int iGun, bool bBlip, int iBlipCol, int iFree, string sName)
        {
            LoggerLight.LogThis("NPCSpawn, sPed == " + sPed + ", bArmor == " + bArmor + ", iHeal == " + iHeal + ", iTask == " + iTask + ", iSeat == " + iSeat + ", iGun == " + iGun + ", bBlip == " + bBlip + ", iFree == " + iFree + ", sName == " + sName);

            Ped BuildPed;
            bool bMale = false;

            if (sPed == "")
            {
                if (iFree == 0)
                    iFree = 1;

                if (RandomNum.FindRandom(67, 0, 20) < 10)
                {
                    sPed = "mp_m_freemode_01";
                    bMale = true;
                }
                else
                    sPed = "mp_f_freemode_01";
            }
            else if (sPed == "mp_m_freemode_01")
                bMale = true;

            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Script.Wait(1);

                BuildPed = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fAce, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (BuildPed.Exists())
                {
                    BuildPed.Accuracy = RandomNum.RandInt(DataStore.MySettings.LowerAim, DataStore.MySettings.UpperAim);
                    BuildPed.MaxHealth = iHeal;
                    BuildPed.Health = iHeal;

                    Function.Call(Hash.SET_PED_PATH_CAN_USE_CLIMBOVERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_USE_LADDERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_DROP_FROM_HEIGHT, BuildPed.Handle, true);

                    if (bArmor)
                        BuildPed.Armor = 100;

                    MissionData.PedList_01.Add(new Ped(BuildPed.Handle));

                    if (bBlip)
                        PedBlimp(BuildPed, 0.75f, false, false, iBlipCol, sName);

                    if (iGun > 0)
                        GunningIt(BuildPed, iGun);

                    if (vMyCar != null)
                    {
                        WarptoAnyVeh(vMyCar, BuildPed, iSeat);
                        NpcVehicleTasks(BuildPed, vMyCar, iTask);
                    }
                    else
                    {
                        if (iTask > 0)
                            NpcTasks(BuildPed, iTask);
                    }

                    if (iFree > 0)
                       DressinRoom.OnlinePlayers(BuildPed, bMale, iFree);
                    ObjectLog.BackUpAss("PedX-" + BuildPed.Handle);
                }
                else
                    BuildPed = null;
            }
            else
                BuildPed = null;


            return BuildPed;
        }
        private static void NpcTasks(Ped Peddy, int iTask)
        {
            LoggerLight.LogThis("NpcTasks, iTask == " + iTask);

            if (iTask == 1)
            {
                Peddy.Task.Cower(-1);
            }             //Cower
            else if (iTask == 2)
            {
                Peddy.CanBeShotInVehicle = true;
                Peddy.RelationshipGroup = DataStore.GP_Player;
                AddGroupie(Peddy);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);

            }        //BankRobbers
            else if (iTask == 3)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                TheMissions.Convicts_KrishaLine(Peddy, true);
            }        //Convicts leader
            else if (iTask == 4)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                TheMissions.Convicts_KrishaLine(Peddy, false);
            }        //Convicts
            else if (iTask == 5)
            {
                EnterPlayerVeh(Peddy, 1, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 01
            else if (iTask == 6)
            {
                EnterPlayerVeh(Peddy, 2, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 02
            else if (iTask == 7)
            {
                EnterPlayerVeh(Peddy, 3, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 03
            else if (iTask == 8)
            {
                AttackThePlayer(Peddy, true);
            }        //Fight player Guns Guns Guns
            else if (iTask == 9)
            {
                Peddy.ApplyDamage(99);
                Peddy.Health = 0;
            }        //DeadNPCs
            else if (iTask == 10)
            {
                PedScenario(Peddy, "WORLD_HUMAN_COP_IDLES", Peddy.Position, Peddy.Heading, false);
            }       //Idle Cops
            else if (iTask == 11)
            {
                ArmNpcWeapon("WEAPON_minigun", Peddy);
                Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Peddy.Handle, true, false, true, true);
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, 0, 0, 0, false);
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
            }       //Juggonorts-add acc hat to 1-
            else if (iTask == 12)
            {
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "COUGAR"));
                Peddy.Task.PlayAnimation("creatures@cat@amb@world_cat_sleeping_ground@idle_a", "idle_a", 8.0f, -1, true, 1.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Fire cat
            else if (iTask == 13)
            {
                PedScenario(Peddy, "WORLD_HUMAN_JOG_STANDING", Peddy.Position, Peddy.Heading, false);
                Function.Call(Hash.TASK_TURN_PED_TO_FACE_ENTITY, Peddy.Handle, Game.Player.Character.Handle, -1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            }       //Fire cat owner
            else if (iTask == 14)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.Task.FightAgainstHatedTargets(45.00f);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Peddy.AlwaysKeepTask = true;
            }       //Water ImportGaurds
            else if (iTask == 15)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                int iRan = RandomNum.FindRandom(97, 1, 10);
                if (iRan < 3)
                    iRan = 2;
                else if (iRan < 6)
                    iRan = 1;
                else
                    iRan = 0;
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, iRan);
            }       //Water YachtAttacks
            else if (iTask == 16)
            {
                Peddy.IsEnemy = true;
                TheMissions.Hitman_AddVisionCones(Peddy);
                Peddy.BlockPermanentEvents = true;
            }       //HitMan Mobs
            else if (iTask == 17)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
            }       //Flee & Blocking
            else if (iTask == 18)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 0);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - static
            else if (iTask == 19)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Defence
            else if (iTask == 20)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Offence
            else if (iTask == 21)
            {
                Peddy.Task.PlayAnimation("amb@world_human_stand_fishing@idle_a", "idle_b", 8.00f, -1, true, 1.00f);
                Prop FishRod = BuildProp("prop_fishing_rod_01", Peddy.Position, Vector3.Zero, true, true);
                if (FishRod != null)
                    FishRod.AttachTo(Peddy, Peddy.GetBoneIndex(Bone.SKEL_L_Hand), new Vector3(0.00f, -0.00f, 0.00f), new Vector3(-122.00f, 100.00f, 30.00f));
            }       //Water Phishing
            else if (iTask == 22)
            {
                TheMissions.BbBomb_BombAtractor(Peddy);
            }       //Bbomb Atractor
            else if (iTask == 23)
            {
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                TheMissions.Hitman_AddVisionCones(Peddy);
                EnterAnyVeh(MissionData.VehTrackin_01, Peddy, 0, 1.0f);
            }       //MoresMan
            else if (iTask == 24)
            {
                ForceAnim(Peddy, "amb@code_human_in_bus_passenger_idles@male@sit@base", "base", Peddy.Position, Peddy.Rotation);
                Function.Call(Hash.SET_PED_CAN_SWITCH_WEAPON, Peddy.Handle, true);
            }       //peds in back of plane
            else if (iTask == 25)
            {
                TheMissions.BikerRaids_BizzPedsSec(Peddy, MissionData.iMissionVar_02);
                AttackThePlayer(Peddy, true);
            }       //BikerBizSecurity
            else if (iTask == 26)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.BikerRaids_BizzPedsWork(Peddy, MissionData.iMissionVar_02, false);
            }       //BikerBizFemail
            else if (iTask == 27)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.BikerRaids_BizzPedsWork(Peddy, MissionData.iMissionVar_02, true);
            }       //BikerBizmail
            else if (iTask == 28)
            {
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "COUGAR"));
                AttackThePlayer(Peddy, false);
            }       //Big shark
            else if (iTask == 29)
            {
                PedScenario(Peddy, "WORLD_HUMAN_PARTYING", Peddy.Position, Peddy.Heading, false);
            }       //Dance
            else if (iTask == 30)
            {
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
                PedScenario(Peddy, "WORLD_HUMAN_GUARD_STAND", Peddy.Position, Peddy.Heading, false);
            }       //Club Bouncer
            else if (iTask == 31)
            {
                TheMissions.TempAgency_02_BuildCluber(Peddy);
            }       //DrinkNDance Clubber
            else if (iTask == 32)
            {
                PedScenario(Peddy, "WORLD_HUMAN_SMOKING", Peddy.Position, Peddy.Heading, false);
            }       //StandSmoke
            else if (iTask == 33)
            {
                PedScenario(Peddy, "WORLD_HUMAN_CLIPBOARD", Peddy.Position, Peddy.Heading, false);
            }       //StandClippBoard
            else if (iTask == 34)
            {
                PedScenario(Peddy, "WORLD_HUMAN_GUARD_STAND", Peddy.Position, Peddy.Heading, false);
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
            }       //standgaurds
            else if (iTask == 35)
            {
                PedScenario(Peddy, "WORLD_HUMAN_CLIPBOARD", Peddy.Position, Peddy.Heading, false);
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
            }       //ClippBoard-Mishppeds
            else if (iTask == 36)
            {
                MissionData.Npc_01 = Peddy;
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                PlayerAtackTracker();
            }       //JohnnylayerAttack
            else if (iTask == 37)
            {
                AttackThePlayer(Peddy, false);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.Follow_AddToMuilti(Peddy, "", Peddy.CurrentBlip, null);
                GunningIt(Peddy, 10);
            }       //GreenyAttack
            else if (iTask == 38)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
            }       //SniperRunner
            else if (iTask == 39)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                AddGroupie(Peddy);
                OhDoKeepUp(Peddy, MissionData.Npc_01, MissionData.fMission_01, MissionData.BeOnOff[5]);
            }       //SniperFollow
        }
        private static void NpcVehicleTasks(Ped Peddy, Vehicle Vehic, int iTask)
        {
            if (iTask == 1)
            {
                Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_CONFIG_FLAG, Peddy.Handle, 32, false);
                TheMissions.Racist_MultiPed(Peddy, Vehic);
            }       //Race Drivers
            else if (iTask == 2)
            {
                Peddy.Task.ClearAll();
                if (Peddy.IsInVehicle())
                    Peddy.Task.CruiseWithVehicle(Peddy.CurrentVehicle, 35.00f, 786603);
            }       //Drive RandDest
            else if (iTask == 3)
            {
                WarptoAnyVeh(Vehic, Peddy, 1);
                FlyNShoot(Peddy, Vehic, Game.Player.Character);
            }       //CargoBobHellepillot
            else if (iTask == 4)
            {
                Vector3 V3Me = Function.Call<Vector3>(Hash._0xCBDB9B923CACC92D, MissionData.VehTrackin_02.Handle);
                VehicleSpawn(ReturnStuff.RanVehListX(1, 1, true), V3Me, MissionData.VehTrackin_02.Heading, false, false, false, false, 7, 0, 0, "", 3, true);
            }       //Cargo add super car
            else if (iTask == 5)
            {
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
            }       //Attack Player
            else if (iTask == 6)
            {
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.BlockPermanentEvents = true;
            }       //MoneyMan Guard
            else if (iTask == 7)
            {
                Peddy.Task.ClearAll();
                Peddy.Task.Wait(-1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Wait in vehicle
            else if (iTask == 8)
            {
                Vector3 vpos = MissionData.VehTrackin_03.Position;
                vpos.Z = vpos.Z + 5.00f;
                ObjectBuild.FlyAway(Peddy, vpos, 55.00f, 5.00f);
                MissionData.BeOnOff[1] = true;
            }       //WAter CargoPilot
            else if (iTask == 9)
            {
                Vehicle VPlyTarget = null;
                Vehicle vPlane = MissionData.VehicleList_01[MissionData.VehicleList_01.Count - 1];
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                if (Game.Player.Character.IsInVehicle())
                    VPlyTarget = Game.Player.Character.CurrentVehicle;
                else
                    VPlyTarget = Game.Player.Character.LastVehicle;
                Function.Call(Hash.TASK_PLANE_MISSION, Peddy.Handle, vPlane.Handle, VPlyTarget.Handle, 0, 0, 0, 0, 6, 0.0f, 0.0f, 180.0f, 1000.0f, -5000.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                vPlane.CurrentBlip.Color = BlipColor.Red;
            }       //DogFighter
            else if (iTask == 10)
            {
                float fSpeeds = 25.00f;
                Peddy.Task.ClearAll();
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                Vector3 PlayPos = MissionData.VehTrackin_03.Position;
                Peddy.DrownsInWater = false;
                Function.Call(Hash.TASK_BOAT_MISSION, Peddy.Handle, Vehic.Handle, 0, 0, PlayPos.X, PlayPos.Y, PlayPos.Z, 4, fSpeeds, 16777216, 5.50f, 7);

                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyVehicle = Vehic;
                MyNewPed.MyName = DataStore.MyLang.Maptext[20];
                MyNewPed.MyTask_01 = 1;
                MyNewPed.MyBlip = Vehic.CurrentBlip;
                MissionData.MultiPed.Add(MyNewPed);
            }       //WAter JetskiAttacks
            else if (iTask == 11)
            {
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
                Peddy.RelationshipGroup = DataStore.GP_Player;
                Peddy.Task.DriveTo(Vehic, MissionData.vTarget_04, 3.00f, 15.00f, 536871355);
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //ValllyCass
            else if (iTask == 12)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
            }       //ValcaryPilot
            else if (iTask == 13)
            {
                Vector3 vTag = MissionData.vTarget_01;
                vTag.Z = 1005.00f;
                ImOnAPlane(Peddy, Vehic, vTag);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Pilot fly away
            else if (iTask == 14)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyTask_01 = 1;
                MissionData.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //Biker Attacks
            else if (iTask == 15)
            {
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    DriveByPed(Peddy, MissionData.Npc_01, true);
                }
                else
                    DriveByPed(Peddy, MissionData.Npc_02, false);
            }       //Attack Npc01/02
            else if (iTask == 16)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                }
                Peddy.Task.ClearAll();
                if (RandomNum.FindRandom(86, 1, 4) > 2)
                    FightingXPed(Peddy, MissionData.Npc_01);
                else
                    FightingXPed(Peddy, MissionData.Npc_02);
                Peddy.AlwaysKeepTask = true;
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyTask_01 = 1;
                MyNewPed.MyPed = Peddy;
                MissionData.MultiPed.Add(MyNewPed);
            }       //Attack Npc01/02 with MuiltiPed
            else if (iTask == 17)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                }
                AttackThePlayer(Peddy, true);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyTask_01 = 1;
                MissionData.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //Biker Attacks onfoot
            else if (iTask == 39)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                ///OnlinePlayers(Peddy, true, 0);
            }       //Drive Playerped M
            else if (iTask == 40)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                ///OnlinePlayers(Peddy, false, 0);
            }       //Drive Playerped F
        }
        public static void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.LogThis("ObjectBuild.ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnimOnceEnding(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot, float fEnder)
        {
            LoggerLight.LogThis("ObjectBuild.ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, fEnder, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnim(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.LogThis("ForceAnim, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 1, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void PedScenario(Ped Peddy, string sCenario, Vector3 Vpos, float fHead, bool bSeated)
        {
            LoggerLight.LogThis("PedScenario, sCenario == " + sCenario);

            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, Peddy.Handle, sCenario, Vpos.X, Vpos.Y, Vpos.Z, fHead, 0, bSeated, true);
        }
        private static void AddGroupie(Ped Peddy)
        {
            Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, Peddy.Handle, DataStore.iPlayerGroup);
        }
        private static void OhDoKeepUp(Ped Peddy, Ped Leader, float fSpeed, bool bClose)
        {
            float fXpos = -2.50f;
            float fYpos = 1.50f;
            if (bClose)
            {
                if (DataStore.iFolPos > 0)
                {
                    fXpos = -1.20f;
                    fYpos = -0.20f;
                    DataStore.iFolPos = 0;
                }
                else
                {
                    fXpos = 1.20f;
                    fYpos = -0.20f;
                    DataStore.iFolPos++;
                }
            }
            else
            {
                DataStore.iFolPos++;
                if (DataStore.iFolPos == 1)
                {
                    fXpos = -2.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 2)
                {
                    fXpos = -2.50f;
                    fYpos = -2.50f;
                }
                else if (DataStore.iFolPos == 3)
                {
                    fXpos = 2.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 4)
                {
                    fXpos = 1.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 5)
                {
                    fXpos = -1.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 6)
                {
                    fXpos = 2.50f;
                    fYpos = -2.50f;
                }
                else if (DataStore.iFolPos == 7)
                {
                    fXpos = -1.50f;
                    fYpos = -2.50f;
                    DataStore.iFolPos = 0;
                }
            }

            Function.Call(Hash.TASK_FOLLOW_TO_OFFSET_OF_ENTITY, Peddy.Handle, Leader.Handle, fXpos, fYpos, 0.0f, fSpeed, -1, 2.5f, true);
        }
        public static PedMultiTask AddAMultiped()
        {
            PedMultiTask MyMultiPed = new PedMultiTask
            {
                MyPed = null,
                MyVehicle = null,
                MyBlip = null,
                MyFloat_01 = 0.00f,
                MyFloat_02 = 0.00f,
                MyFloat_03 = 0.00f,
                MyTask_01 = -1,
                MyTask_02 = -1,
                MyTask_03 = -1,
                MyTimer_01 = -1,
                MyTimer_02 = -1,
                MySwitch_01 = false,
                MySwitch_02 = false,
                MySwitch_03 = false,
                MyName = "",
                MyTarget_01 = Vector3.Zero,
                MyTarget_02 = Vector3.Zero
            };

            return MyMultiPed;
        }
        public static void AttackThePlayer(Ped Pedd, bool bWeaps)
        {
            LoggerLight.LogThis("AttackThePlayer");

            Pedd.RelationshipGroup = DataStore.GP_Attack;
            Pedd.IsEnemy = true;
            Pedd.CanBeTargette﻿d﻿ = true;
            PedBlimp(Pedd, 0.75f, false, false, 59, "");
            //Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 2, false);//steal a Vehicle?
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Pedd.Task.FightAgainst(Game.Player.Character);
            Function.Call(Hash.SET_PED_PATH_CAN_USE_CLIMBOVERS, Pedd.Handle, true);
            Function.Call(Hash.SET_PED_PATH_CAN_USE_LADDERS, Pedd.Handle, true);
            Function.Call(Hash.SET_PED_PATH_CAN_DROP_FROM_HEIGHT, Pedd.Handle, true);
            Pedd.Weapons.RemoveAll();
            if (bWeaps)
            {
                ArmsRegulator(Pedd, 2);
                ArmsRegulator(Pedd, 3);
                ArmsRegulator(Pedd, 4);
                ArmsRegulator(Pedd, 5);
            }
        }
        private static void DriveByPlayer(Ped Pedd, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            Pedd.RelationshipGroup = DataStore.GP_Attack;
            Pedd.IsEnemy = true;
            Pedd.CanBeTargette﻿d﻿ = true;
            if (bDriver)
                Pedd.Task.VehicleChase(Game.Player.Character);
            else
                Pedd.Task.VehicleShootAtPed(Game.Player.Character); 
            
            ArmsRegulator(Pedd, 3);
            ArmsRegulator(Pedd, 4);
            ArmsRegulator(Pedd, 5);
        }
        private static void DriveByPed(Ped Pedd, Ped Victim, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            Pedd.CanBeTargette﻿d﻿ = true;
            if (bDriver)
                Pedd.Task.VehicleChase(Victim);
            else
                Pedd.Task.VehicleShootAtPed(Victim);
            ArmsRegulator(Pedd, 1);
            ArmsRegulator(Pedd, 2);
            ArmsRegulator(Pedd, 3);
            ArmsRegulator(Pedd, 4);
            ArmsRegulator(Pedd, 5);
        }
        public static void FightingXPed(Ped Pedd, Ped Victim)
        {
            LoggerLight.LogThis("FightingXPed");

            Pedd.Task.ClearAll();
            Function.Call(Hash._0x88E32DB8C1A4AA4B, Pedd.Handle, 10.00f);
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Function.Call(Hash.SET_PED_COMBAT_ABILITY, Pedd.Handle, 100);
            Function.Call(Hash.TASK_GO_TO_ENTITY, Pedd.Handle, Victim.Handle, -1, 1.0f, 100, 1073741824, 0);
            Function.Call(Hash.TASK_COMBAT_PED, Pedd.Handle, Victim.Handle, 0, 16);
            Pedd.BlockPermanentEvents = true;
            Pedd.AlwaysKeepTask = true;
        }
        public static void FightAbility(Ped Pedd)
        {
            Function.Call(Hash._0x88E32DB8C1A4AA4B, Pedd.Handle, 10.00f);
            //Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Function.Call(Hash.SET_PED_COMBAT_ABILITY, Pedd.Handle, 100);
        }
        public static void GunningIt(Ped Peddy, int iGun)
        {
            LoggerLight.LogThis("GunningIt, iGun == " + iGun);

            if (iGun == 1)
                ArmsRegulator(Peddy, 5);
            else if (iGun == 2)
                ArmsRegulator(Peddy, 4);
            else if (iGun == 3)
                ArmsRegulator(Peddy, 3);
            else if (iGun == 4)
                ArmsRegulator(Peddy, 3);
            else if (iGun == 5)
                ArmsRegulator(Peddy, 1);
            else if (iGun == 6)
                ArmsRegulator(Peddy, 6);
            else if (iGun == 7)
            {
                int iRanGun = RandomNum.RandInt(0, 50);
                if (iRanGun < 10)
                    ArmsRegulator(Peddy, 1);
                else if (iRanGun < 20)
                    ArmsRegulator(Peddy, 3);
                else if (iRanGun < 30)
                    ArmsRegulator(Peddy, 3);
                else if (iRanGun < 40)
                    ArmsRegulator(Peddy, 4);
                else
                    ArmsRegulator(Peddy, 5);
            }
            else if (iGun == 8)
            {
                int iRanGun = RandomNum.RandInt(0, 30);
                if (iRanGun < 25)
                    ArmsRegulator(Peddy, 3);
                else
                    ArmsRegulator(Peddy, 5);
            }
            else if (iGun == 9)
            {
                ArmsRegulator(Peddy, 4);
                ArmsRegulator(Peddy, 3);
            }
            else if (iGun == 10)
            {
                ArmNpcWeapon("WEAPON_raypistol", Peddy);
            }
            else if (iGun == 11)
            {
                ArmNpcWeapon("WEAPON_dagger", Peddy);
                ArmNpcWeapon("WEAPON_sniperrifle", Peddy);
                ArmNpcAtachment("WEAPON_sniperrifle", "COMPONENT_AT_AR_SUPP_02", Peddy);
                ArmNpcAtachment("WEAPON_sniperrifle", "COMPONENT_AT_SCOPE_MAX", Peddy);
            }
        }
        public static void ArmNpcWeapon(string sWeap, Ped Peddy)
        {
            Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), ReturnStuff.MaxAmmo(sWeap, Peddy), false, true);
        }
        private static void ArmNpcAtachment(string sWeap, string sAttach, Ped Peddy)
        {
            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_HASH_KEY, sAttach));
        }
        public static void ArmsRegulator(Ped Peddy, int iSet)
        {
            if (iSet == 1)
            {
                ArmNpcWeapon("WEAPON_rayminigun", Peddy);
                ArmNpcWeapon("WEAPON_raycarbine", Peddy);
                ArmNpcWeapon("WEAPON_raypistol", Peddy);
            }       //space
            else if (iSet == 2)
            {
                if (RandomNum.RandInt(0, 20) < 10)
                    ArmNpcWeapon("WEAPON_combatmg", Peddy);
                else
                    ArmNpcWeapon("WEAPON_minigun", Peddy);
            }       //heavy
            else if (iSet == 3)
            {
                ArmNpcWeapon(MidWeapList[RandomNum.RandInt(0, MidWeapList.Count - 1)], Peddy);
            }       //Mid
            else if (iSet == 4)
            {
                ArmNpcWeapon(SmallWeapList[RandomNum.RandInt(0, SmallWeapList.Count - 1)], Peddy);
            }       //small
            else if (iSet == 5)
            {
                ArmNpcWeapon(MelleWeapList[RandomNum.RandInt(0, MelleWeapList.Count - 1)], Peddy);
            }       //melee
            else if (iSet == 6)
            {
                ArmNpcWeapon("WEAPON_molotov", Peddy);
            }       //Molly
            Peddy.CanSwitchWeapons = true;
        }
        public static void EnterAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat, float Run)
        {
            LoggerLight.LogThis("EnterAnyVeh, iSeat == " + iSeat + ", Run == " + Run);

            if (Vhic.Exists())
            {
                Function.Call(Hash.TASK_ENTER_VEHICLE, Peddy.Handle, Vhic, -1, iSeat - 1, Run, 1, 0);
                Peddy.BlockPermanentEvents = true;
                Peddy.AlwaysKeepTask = true;
            }
        }
        public static void EnterPlayerVeh(Ped Peddy, int iSeat, float Run)
        {
            LoggerLight.LogThis("EnterPlayerVeh, iSeat == " + iSeat + ", Run == " + Run);
            if (Game.Player.Character.IsInVehicle())
            {
                Vehicle Vhick = Game.Player.Character.CurrentVehicle;
                EnterAnyVeh(Vhick, Peddy, iSeat, Run);
            }
        }
        public static void WarptoAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            LoggerLight.LogThis("WarptoAnyVeh, iSeat == " + iSeat);

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
                    GetOutofVeh(Peddy, 1);
                VehicleWarp(Vhic, Peddy, iSeat);
                Script.Wait(100);
            }

            if (bFader)
            {
                Script.Wait(500);
                Game.FadeScreenIn(1000);
            }
        }
        public static void VehicleWarp(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            Function.Call(Hash.SET_PED_INTO_VEHICLE, Peddy.Handle, Vhic.Handle, iSeat - 2);
        }
        public static void WarptoPlayerVeh(Ped Peddy, int iSeat)
        {
            LoggerLight.LogThis("WarptoPlayerVeh, iSeat == " + iSeat);

            if (Game.Player.Character.IsInVehicle())
            {
                Vehicle Vhick = Game.Player.Character.CurrentVehicle;
                while (!Peddy.IsInVehicle(Vhick))
                {
                    VehicleWarp(Vhick, Peddy, iSeat);
                    Script.Wait(500);
                }
            }
        }
        public static void FreeSeat(Vehicle Vhick, int iSeat, bool bFlee)
        {
            LoggerLight.LogThis("FreeSeat iSeat== " + iSeat + ", bFlee == " + bFlee);
            if (!Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, Vhick.Handle, iSeat - 2))
            {
                Ped Peddy = Function.Call<Ped>(Hash.GET_PED_IN_VEHICLE_SEAT, Vhick.Handle, iSeat - 2);
                FleeFromVeh(Peddy);
            }
        }
        public static void GetOutofVeh(Ped Peddy, int iExits)
        {
            bool bExited = false;
            if (Peddy.IsInVehicle())
            {
                int iTenPass = 10;
                int iLeave = 0;
                if (iExits == 1)
                    iLeave = 256;
                else if (iExits == 2)
                    iLeave = 4160;

                Vehicle PickVic = Peddy.CurrentVehicle;
                while (Peddy.IsInVehicle(PickVic) && iTenPass > 0)
                {
                    Script.Wait(100);
                    Function.Call(Hash.TASK_LEAVE_VEHICLE, Peddy.Handle, PickVic.Handle, iLeave);
                    iTenPass -= 1;
                }
                if (iTenPass > 0)
                    bExited = true;
            }
            LoggerLight.LogThis("GetOutofVeh Exit == " + bExited);
        }
        private static void FleeFromVeh(Ped Peddy)
        {
            LoggerLight.LogThis("FleeFromVeh");

            Peddy.Task.ClearAll();
            GetOutofVeh(Peddy, 2);
            Peddy.Task.FleeFrom(Game.Player.Character);
        }
        public static void FlyAway(Ped Pedd, Vector3 vHeliDest, float fSpeed, float flanding)
        {
            LoggerLight.LogThis("FlyAway");

            Vehicle vHeli = Pedd.CurrentVehicle;
            vHeli.FreezePosition = false;

            float HeliDesX = vHeliDest.X;
            float HeliDesY = vHeliDest.Y;
            float HeliDesZ = vHeliDest.Z;
            float HeliSpeed = fSpeed;
            float HeliLandArea = flanding;

            float dx = Pedd.Position.X - HeliDesX;
            float dy = Pedd.Position.Y - HeliDesY;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        public static void ImOnAPlane(Ped Pilot, Vehicle Plane, Vector3 Dest)
        {
            LoggerLight.LogThis("ImOnAPlane");

            Pilot.Task.ClearAll();
            Function.Call(Hash.TASK_PLANE_MISSION, Pilot.Handle, Plane.Handle, 0, 0, Dest.X, Dest.Y, Dest.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
        }
        public static void ShowBoating(Ped PedX, Vector3 vEctor, Vehicle Vhick, float fSpeeds, int iDrivinStyle)
        {
            LoggerLight.LogThis("ShowBoating");

            PedX.Task.ClearAll();
            Function.Call(Hash.TASK_BOAT_MISSION, PedX.Handle, Vhick.Handle, 0, 0, vEctor.X, vEctor.Y, vEctor.Z, 4, fSpeeds, iDrivinStyle, -1.0f, 7);
            Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, PedX.Handle, true);
        }
        public static void DriveToDest(Vehicle Vhickery, Vector3 TheDest, Ped Peddy, float fSpeding, int iDriveStyle)
        {
            LoggerLight.LogThis("DriveToDest");

            Peddy.Task.ClearAll();
            Peddy.Task.DriveTo(Vhickery, TheDest, 1.50f, fSpeding, iDriveStyle);
            Peddy.AlwaysKeepTask = true;
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            Peddy.AlwaysKeepTask = true;
            Peddy.BlockPermanentEvents = true;
        }
        private static void FlyNShoot(Ped Pedd, Vehicle vHeli, Ped Target)
        {
            LoggerLight.LogThis("FlyNShoot");

            float HeliSpeed = 75.00f;
            //float HeliLandArea = flanding;

            float dx = Target.Position.X - vHeli.Position.X;
            float dy = Target.Position.Y - vHeli.Position.Y;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, Target.Handle, 0, 0, 0, 9, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        private static void PlayerAtackTracker()
        {
            while (MissionData.bPlayerAtt)
            {
                if (MissionData.Npc_01 != null)
                {
                    if (TheMissions.AmIFar(MissionData.Npc_01.Position, 250f) || MissionData.Npc_01.IsDead || Game.Player.Character.IsDead)
                    {
                        MissionData.Npc_01 = null;
                        MissionData.bPlayerAtt = false;

                        for (int i = 0; i < MissionData.PedList_01.Count; i++)
                            ObjectLog.CleanUp(MissionData.PedList_01[i], false);

                        MissionData.PedList_01.Clear();
                    }
                }
                Script.Wait(1000);
            }
        }
        public static Vehicle VehicleSpawn(string sVehModel, Vector3 VecLocal, float VecHead, bool bIsInvinc, bool bFreeze, bool bRouteto, bool bFlasher, int iMod, int iExtraMod, int iBlip, string sBlip, int iVehTrack, bool bModShop)
        {
            LoggerLight.LogThis("VehicleSpawn, sVehModel == " + sVehModel + ", bIsInvinc == " + bIsInvinc + ", bFreeze == " + bFreeze + ", iMod == " + iMod + ", iExtraMod == " + iExtraMod + ", iVehTrack == " + iVehTrack + ", bModShop == " + bModShop);

            Vehicle BuildVehicle = null;

            int iVehHash = -1;

            if (sVehModel == "GetPlayersVeh")
                iVehHash = Game.Player.Character.CurrentVehicle.Model.Hash;
            else if (sVehModel == "" || !ReturnStuff.IsItARealVehicle(sVehModel))
                sVehModel = ReturnStuff.ImportsExpo_CarList(1);

            if (iVehHash == -1)
                iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehModel);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
            {
                Function.Call(Hash.REQUEST_MODEL, iVehHash);
                while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                    Script.Wait(1);

                BuildVehicle = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, VecLocal.X, VecLocal.Y, VecLocal.Z, VecHead, true, true);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);

                BuildVehicle.IsPersistent = true;
                BuildVehicle.IsInvincible = bIsInvinc;
                BuildVehicle.FreezePosition = bFreeze;
                MissionData.VehicleList_01.Add(new Vehicle(BuildVehicle.Handle));
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, BuildVehicle.Handle, 0);
                ObjectLog.BackUpAss("Vehs-" + BuildVehicle.Handle);

                if (iVehTrack > 0)
                {
                    if (iVehTrack == 1)
                        MissionData.VehTrackin_01 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 2)
                        MissionData.VehTrackin_02 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 3)
                        MissionData.VehTrackin_03 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 4)
                        MissionData.VehTrackin_04 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 5)
                        MissionData.VehTrackin_05 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 10)
                        DataStore.SharedVeh = new Vehicle(BuildVehicle.Handle);
                }
                if (iBlip > 0)
                    VehBlip(BuildVehicle, bFlasher, bRouteto, iBlip, sBlip);

                if (iMod > 0)
                    VehicleMods(BuildVehicle, iMod, iExtraMod, bModShop);
            }
            else
                BuildVehicle = null;

            if (DataStore.SharedVeh != null)
                LoggerLight.LogThis("shared vehicle == " + DataStore.SharedVeh.Handle);

            return BuildVehicle;
        }
        public static void MaxOutAllModsNoWheels(Vehicle Vehic)
        {
            LoggerLight.LogThis("MaxOutAllModsNoWheels");

            for (int i = 0; i < 50; i++)
            {
                int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i);

                if (i == 18 || i == 22 || i == 23 || i == 24)
                {

                }
                else
                {
                    iSpoilher -= 1;
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher, true);
                }
            }
            if (Vehic.ClassType != VehicleClass.Cycles || Vehic.ClassType != VehicleClass.Helicopters || Vehic.ClassType != VehicleClass.Boats || Vehic.ClassType != VehicleClass.Planes)
            {
                Vehic.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Vehic.ToggleMod(VehicleToggleMod.Turbo, true);
            }
        }
        public static void ModExtras(Vehicle Vehic, List<int> VehExtras)
        {
            LoggerLight.LogThis("ModExtras");

            for (int i = 0; i < 15; i++)
            {
                if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, Vehic.Handle, i))
                    Function.Call(Hash.SET_VEHICLE_EXTRA, Vehic.Handle, i, true);
            }

            for (int i = 0; i < VehExtras.Count; i++)
            {
                if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, Vehic.Handle, VehExtras[i]))
                    Function.Call(Hash.SET_VEHICLE_EXTRA, Vehic.Handle, VehExtras[i], false);
            }
        }
        public static void VehicleMods(Vehicle Vehic, int iMod, int iExtraMod, bool bModShop)
        {
            LoggerLight.LogThis("VehicleMods, iMod == " + iMod + ", iExtraMod == " + iExtraMod);

            List<int> MyExtras = new List<int>();

            if (iMod == 1)
            {
                if (iExtraMod > 0)
                    MyExtras.Add(iExtraMod);

                ModExtras(Vehic, MyExtras);
            }         // Extras
            else if (iMod == 2)
            {
                if (iExtraMod == 1)
                {
                    Vehic.PrimaryColor = VehicleColor.MatteWhite;
                    Vehic.SecondaryColor = VehicleColor.MatteMidnightBlue;
                }
                else if (iExtraMod == 2)
                {
                    Vehic.Livery = 6;
                }
                else if (iExtraMod == 3)
                {
                    Vehic.Livery = 9;
                    Vehic.PrimaryColor = VehicleColor.MetallicBlazeRed;
                }
                else if (iExtraMod == 4)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicBlack;
                    Vehic.SecondaryColor = VehicleColor.MetallicUltraBlue;

                }
                else if (iExtraMod == 5)
                {
                    Vehic.CurrentBlip.Color = BlipColor.Blue;
                    TheMissions.ImportsExpo_FunPlates(Vehic);
                    MissionData.iMissionSeq = 3;
                }
                else if (iExtraMod == 6)
                {
                    Vehic.CurrentBlip.Color = BlipColor.Red3;
                    NPCSpawn(ReturnStuff.RandNPC(RandomNum.RandInt(1, 35)), Vehic.Position, 0.00f, false, 120, 2, 1, Vehic, 0, false, 0, 0, "");
                    MissionData.iMissionSeq = 3;
                }
                else if (iExtraMod == 7)
                {
                    NPCSpawn("", Vehic.Position, 0.00f, false, 170, 3, 1, Vehic, 0, false, 0, 1, "");
                    Vehic.CurrentBlip.Color = BlipColor.Red;
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 1)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 5, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats = iNoSeats - 1;
                    }
                }           //heliAtt on Cargocolect
                else if (iExtraMod == 8)
                {
                    Vehic.Position = new Vector3(Vehic.Position.X, Vehic.Position.Y, Vehic.Position.Z + 50.00f);
                    NPCSpawn("", Vehic.Position, 0.00f, false, 170, 3, 0, Vehic, 0, false, 0, 1, "");
                    Vehic.CurrentBlip.Color = BlipColor.Red;
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 1)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 0, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats = iNoSeats - 1;
                    }
                }       //cargobob player pped pilot
                else if (iExtraMod == 9)
                {
                    Vehic.SetMod(VehicleMod.Roof, 1, true);
                }
                else if (iExtraMod == 10)
                {
                    Vehic.PrimaryColor = VehicleColor.MatteBlack;
                    Vehic.SecondaryColor = VehicleColor.MatteBlack;
                }
                else if (iExtraMod == 11)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.Alpha = 120;
                }
                else if (iExtraMod == 12)
                {
                    Vehic.Livery = -1;
                    Vehic.PrimaryColor = VehicleColor.MetallicBlazeRed;
                    Vehic.SecondaryColor = VehicleColor.MatteWhite;
                }
                else if (iExtraMod == 13)
                {
                    Vehic.Livery = -1;
                    Vehic.PrimaryColor = VehicleColor.MetallicDarkBlue;
                    Vehic.SecondaryColor = VehicleColor.MatteYellow;
                }
                else if (iExtraMod == 14)
                {
                    Vehic.LockStatus = VehicleLockStatus.Locked;
                    Vehic.NumberPlate = "DUPE";
                }
            }    // PaintJobs
            else if (iMod == 3)
            {
                if (iExtraMod == 1)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.SmashWindow(VehicleWindow.FrontLeftWindow);
                    Vehic.DirtLevel = 99.75f;
                    if (!MissionData.bTestRun)
                        NPCSpawn(ReturnStuff.RandNPC(18), Vehic.Position, 0.00f, false, 0, 9, 1, Vehic, 2, false, 0, 0, "");
                    Vehic.CurrentBlip.Color = BlipColor.Yellow;
                }
                else if (iExtraMod == 2)
                    Vehic.LockStatus = VehicleLockStatus.Locked;
                else if (iExtraMod == 3)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.SmashWindow(VehicleWindow.FrontLeftWindow);
                    Vehic.DirtLevel = 99.75f;
                    NPCSpawn(ReturnStuff.RandNPC(18), Vehic.Position, 0.00f, false, 150, 0, 1, Vehic, 2, false, 0, 0, "");
                    Vehic.CurrentBlip.Color = BlipColor.Yellow;
                }
                else if (iExtraMod == 4)
                {

                }
                else if (iExtraMod == 5)
                {

                }//not used
                else if (iExtraMod == 6)
                {

                }//not used
                else if (iExtraMod == 7)
                {

                }
                else if (iExtraMod == 8)
                {
                    ObjectClear.RemoveTargets();
                }

            }    // Random Mods
            else if (iMod == 4)
            {
                if (iExtraMod == 1)
                {
                    MyExtras.Add(1);
                    MyExtras.Add(2);
                    MyExtras.Add(4);
                    MyExtras.Add(5);
                    MyExtras.Add(10);
                }
                ModExtras(Vehic, MyExtras);
            }    // Trucking Sadler 
            else if (iMod == 5)
            {
                if (iExtraMod == 99)
                {
                    int iLive = RandomNum.RandInt(0, Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Vehic.Handle));

                    Function.Call(Hash.SET_VEHICLE_LIVERY, Vehic.Handle, iLive);
                }
                else
                {
                    if (iExtraMod <= Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Vehic))
                        Vehic.Livery = iExtraMod;
                }
            }    // Livery
            else if (iMod == 6)
            {
                Vehic.EngineRunning = true;
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), new Vector3(0.00f, 0.00f, 0.00f), 0.00f, false, 170, 4, 1, Vehic, 0, false, 0, 0, "");
                Function.Call(Hash._0x7BEB0C7A235F6F3B, Vehic.Handle, 0);
            }    // Add a NPCPiolot -- Job 6 area 4
            else if (iMod == 7)
            {
                TheMissions.Pilot04_ImportBob(Vehic);
            }    // Attach to cargobob -- Job 6 area 4
            else if (iMod == 8)
            {
                if (iExtraMod == 1)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 220, 14, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats -= 1;
                    }
                }       //player ed
                else if (iExtraMod == 2)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(4), Vehic.Position, Vehic.Heading, false, 150, 14, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //lost mc att 1
                else if (iExtraMod == 3)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = RandomNum.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        Ped Pedro = NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 190, 15, iNoSeats, Vehic, 2, true, 0, 0, "");
                        Pedro.RelationshipGroup = DataStore.GP_BNPCs;

                        if (iNoSeats == 1)
                            TheMissions.Follow_AddToMuilti(Pedro, "", Vehic.CurrentBlip, Vehic);
                        else
                            TheMissions.Follow_AddToMuilti(Pedro, "", null, null);

                        iNoSeats -= 1;
                    }
                }       //random add to MissionData.MultiPed list
                else if (iExtraMod == 4)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(4), Vehic.Position, Vehic.Heading, false, 150, 17, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //random
                else if (iExtraMod == 5)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = RandomNum.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 180, 14, iNoSeats, Vehic, 2, false, 1, 0, "");
                        iNoSeats -= 1;
                    }
                }       //lost mc att 2
                else if (iExtraMod == 9)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = RandomNum.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        Ped Pedro = NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 150, 5, iNoSeats, Vehic, 2, false, 0, 0, "");
                        Pedro.RelationshipGroup = DataStore.GP_BNPCs;

                        if (iNoSeats == 1)
                            TheMissions.Follow_AddToMuilti(Pedro, "", Vehic.CurrentBlip, Vehic);
                        else
                            TheMissions.Follow_AddToMuilti(Pedro, "", null, null);

                        iNoSeats -= 1;
                    }
                }       //rand add to multi 
                else
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = RandomNum.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 150, 0, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //rand

                VehicleMods(Vehic, 2, 10, false);
            }    // Player Attackers..
            else if (iMod == 9)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                if (iExtraMod > 9)
                {
                    int iExtras = 14;
                    while (iExtras > 0)
                    {
                        if (Vehic.ExtraExists(iExtras))
                            Vehic.ToggleExtra(iExtras, true);
                        iExtras = iExtras - 1;
                    }
                    Vehic.SecondaryColor = VehicleColor.BrushedBlackSteel;
                    if (iExtraMod == 10)
                        Vehic.PrimaryColor = VehicleColor.MatteDarkRed;
                    else if (iExtraMod == 11)
                        Vehic.PrimaryColor = VehicleColor.MatteYellow;
                    else if (iExtraMod == 12)
                        Vehic.PrimaryColor = VehicleColor.MatteLimeGreen;
                    else if (iExtraMod == 13)
                        Vehic.PrimaryColor = VehicleColor.MatteBlue;
                }
            }    // BoatAnchor
            else if (iMod == 10)
            {
                Vehic.MaxHealth = 3000;
                Vehic.Health = 3000;
                MissionData.Npc_01 = NPCSpawn("s_m_m_security_01", Vehic.Position, Vehic.Heading, true, 180, 6, 2, Vehic, 2, false, 0, 0, "");
            }   // Security Van
            else if (iMod == 11)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                MissionData.Npc_01 = NPCSpawn("s_m_m_scientist_01", Vehic.Position, Vehic.Heading, false, 130, 7, 2, Vehic, 0, false, 0, 0, "");
                VehicleMods(Vehic, 1, iExtraMod, false);
            }   // Water Boat -- Area 3
            else if (iMod == 12)
            {
                Vehic.MaxHealth = 4000;
                Vehic.Health = 4000;
                Vehic.EngineRunning = true;
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), new Vector3(0.00f, 0.00f, 0.00f), 0.00f, false, 140, 8, 1, Vehic, 0, false, 0, 0, "");
            }   // Water Boat -- Area 1 Cargobob
            else if (iMod == 13)
            {
                MaxOutAllModsNoWheels(Vehic);
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);
                Ped Dog = NPCSpawn(ReturnStuff.RandNPC(32), Vector3.Zero, 0.00f, false, 190, 9, 1, Vehic, 0, false, 0, 0, "");
                PedMultiTask Fighter = ObjectBuild.AddAMultiped();
                Fighter.MyPed = Dog;
                Fighter.MyVehicle = Vehic;
                Fighter.MyBlip = Vehic.CurrentBlip;
                Fighter.MyTask_01 = 1;
                MissionData.MultiPed.Add(Fighter);
            }   // Dogfighers
            else if (iMod == 14)
            {
                Vehic.Explode();
            }   // Blow up Veh
            else if (iMod == 15)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(ReturnStuff.RandNPC(33), Vehic.Position, Vehic.Heading, false, 180, 10, 1, Vehic, 2, false, 0, 0, "");
                Vehic.CurrentBlip.Color = BlipColor.Red;

            }   // Water Boat -- Area 1 Jetski Attack 
            else if (iMod == 16)
            {
                if (iExtraMod == 1)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.70f, 1.01f), new Vector3(-92.09f, 0.00f, 0.00f));
                else if (iExtraMod == 2)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.01f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 3)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.10f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 4)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.51f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 5)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(-0.40f, 0.00f, 2.70f), new Vector3(0.00f, 0.00f, -90.00f));
            }   // TruckingAttachments
            else if (iMod == 17)
            {
                Vehic.Alpha = 120;
                Function.Call(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Vehic.Handle);
            }   // BuildVeh
            else if (iMod == 18)
            {
                VehicleWarp(Vehic, Game.Player.Character, 1);
            }   // PlayerToVeh
            else if (iMod == 19)
            {
                if (RandomNum.FindRandom(91, 1, 10) < 9)
                    MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(13), Vehic.Position, Vehic.Heading, false, 180, 11, 1, Vehic, 2, false, 0, 0, "");
                else
                    MissionData.Npc_01 = NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 11, 1, Vehic, 2, false, 0, 1, "");
            }   // Casino parking
            else if (iMod == 20)
            {
                Ped TaxMan = NPCSpawn(ReturnStuff.RandNPC(iExtraMod), Vehic.Position, 0.00f, false, 120, 5, 1, Vehic, 2, false, 0, 0, "");
                PedMultiTask Taxi = ObjectBuild.AddAMultiped();
                Taxi.MyPed = TaxMan;
                Taxi.MyVehicle = Vehic;
                Taxi.MyBlip = Vehic.CurrentBlip;
                Taxi.MyTask_01 = 1;
                MissionData.MultiPed.Add(Taxi);
                VehBlip(Vehic, true, false, 1, "");
            }   // Crazy Taxies
            else if (iMod == 21)
            {
                if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                    VehicleMods(Vehic, 9, 0, false);
            }   // Raceing Carz
            else if (iMod == 22)
            {
                if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                    VehicleMods(Vehic, 9, 0, false);

                Vehic.EngineRunning = true;
                NPCSpawn(ReturnStuff.RandNPC(MissionData.iList_01[7]), Vehic.Position, 0.00f, false, 220, 1, 1, Vehic, 0, true, 3, 0, DataStore.MyLang.Maptext[109]);
            }   // Raceing Drivers
            else if (iMod == 23)
            {
                Vehic.IsVisible = false;
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                MissionData.Prop_01.AttachTo(Vehic, Vehic.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 0.00f), new Vector3(0.00f, 0.00f, -180.00f));
                MissionData.Prop_01.FreezePosition = false;
                Vehic.FreezePosition = false;
            }   // attach fake boat to barge
            else if (iMod == 24)
            {
                Vehic.Livery = 0;
                Vehic.PrimaryColor = VehicleColor.MetallicMarinerBlue;
                Vehic.SecondaryColor = VehicleColor.MetallicFrostWhite;
            }   // Heiltours
            else if (iMod == 25)
            {
                int iRando = RandomNum.RandInt(1, 10);
                NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 180, 2, 1, Vehic, 2, false, 1, 0, "");
            }   // Drive Around
            else if (iMod == 26)
            {
                Vehic.OpenDoor(VehicleDoor.Trunk, false, true);
            }   // Cargo Truck tale
            else if (iMod == 27)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
            }   // Blue Sub
            else if (iMod == 28)
            {
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), Vehic.Position, 0.00f, false, 140, 12, 1, Vehic, 0, false, 0, 0, "");
                NPCSpawn("ig_juanstrickler", Vehic.Position, 0.00f, false, 140, 12, 4, Vehic, 0, false, 0, 0, "");
            }   // thief heli
            else if (iMod == 29)
            {
                MissionData.Npc_02 = NPCSpawn(ReturnStuff.RandNPC(32), Vehic.Position, Vehic.Heading, false, 150, 7, 1, Vehic, 0, false, 0, 0, "");
            }   // BlankNpc2 Sitting In Vehicle
            else if (iMod == 30)
            {
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);

                Prop Bench1 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench1.AttachTo(Vehic, 0, new Vector3(1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));

                Prop Bench2 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench2.AttachTo(Vehic, 0, new Vector3(-1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench3 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench3.AttachTo(Vehic, 0, new Vector3(-1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench4 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench4.AttachTo(Vehic, 0, new Vector3(1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));

                NPCSpawn(ReturnStuff.RandNPC(32), Vector3.Zero, 0.00f, false, 190, 13, 1, Vehic, 0, false, 0, 0, "");
            }   // airjump plane
            else if (iMod == 31)
            {
                Vehic.LockStatus = VehicleLockStatus.Locked;
            }   // Door Lock
            else if (iMod == 32)
            {
                VehBlip(Vehic, false, false, 39, DataStore.MyLang.Maptext[21]);
                Vehic.CurrentBlip.Alpha = 100;
            }
            if (bModShop)
                ReturnStuff.MaxModsRandExtras(Vehic);
        }
        public static void GhostVehicle(Vehicle Vhick, Vector3 Vpos, float fHeads)
        {
            LoggerLight.LogThis("GhostVehicle");

            Vhick.Position = Vpos;
            Vhick.Heading = fHeads;
            int iFailed = 50;
            while (!Vhick.IsOnAllWheels && iFailed > 0)
            {
                StayOnGround(Vhick);
                Script.Wait(100);
                iFailed -= 1;
            }

            if (iFailed > 0)
            {
                Vhick.FreezePosition = true;
                Vhick.HasCollision = false;
                Vhick.Alpha = 120;
                Vhick.Heading = fHeads;
                Vhick.LockStatus = VehicleLockStatus.Locked;
            }
            else
            {
                UI.Notify("Item Failed to render intime.");
                MissionData.iMissionSeq = 45;
            }

        }
        public static void StayOnGround(Vehicle Vhick)
        {
            LoggerLight.LogThis("StayOnGround");

            Function.Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Vhick.Handle);
        }
        public static Prop BuildProp(string sProper, Vector3 Position, Vector3 Rotation, bool bFreeze, bool bSetLOD)
        {
            LoggerLight.LogThis("BuildProp, sProper == " + sProper + ", bFreeze == " + bFreeze);

            Prop BuildPop = null;

            int iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, sProper);

            if (!Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iPropHash))
            {
                LoggerLight.LogThis("BuildProp, spropMissing...");
                iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, "zprop_bin_01a_old");
            }

            Function.Call(Hash.REQUEST_MODEL, iPropHash);
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iPropHash))
                Script.Wait(1);

            int iProps = Function.Call<int>(Hash.CREATE_OBJECT, iPropHash, Position.X, Position.Y, Position.Z, false, true, false);
            BuildPop = new Prop(iProps);

            if (BuildPop.Exists())
            {
                BuildPop.Rotation = Rotation;
                BuildPop.IsPersistent = true;
                BuildPop.HasCollision = true;
                BuildPop.FreezePosition = bFreeze;

                if (bSetLOD)
                    Function.Call(Hash.SET_ENTITY_LOD_DIST, BuildPop.Handle, 1500);

                MissionData.PropList_01.Add(new Prop(BuildPop.Handle));

                ObjectLog.BackUpAss("Prop-" + BuildPop.Handle);
            }
            else
                BuildPop = null;

            Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);

            return BuildPop;
        }
        public static void BlipNames(Blip bLippy, string sTag)
        {
            LoggerLight.LogThis("BlipNames");

            Function.Call(Hash.BEGIN_TEXT_COMMAND_SET_BLIP_NAME, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, " " + sTag);
            Function.Call(Hash.END_TEXT_COMMAND_SET_BLIP_NAME, bLippy.Handle);
            Function.Call((Hash)0xF9113A30DE5C6670, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, " " + sTag);
            Function.Call((Hash)0xBC38B49BCB83BC9B, bLippy.Handle);
        }
        public static void MultiBlimbs(Vector3 Vblips, int Bsp, bool bClean, string sName)
        {
            LoggerLight.LogThis("FakeBlimbs");

            if (bClean)
            {
                for (int i = 0; i < MissionData.BlipList_01.Count; i++)
                    ObjectLog.CleanUp(MissionData.BlipList_01[i]);

                MissionData.BlipList_01.Clear();
            }
            Blip Blippy = AddBlips(Vblips);
            if (Bsp != -1)
                TaggetIcon(Blippy, Bsp);

            if (sName == "")
                Function.Call(Hash.SET_BLIP_DISPLAY, Blippy.Handle, 8);
            else
                BlipNames(Blippy, sName);

            Blippy.IsFlashing = true;
            MissionData.BlipList_01.Add(new Blip(Blippy.Handle));
        }
        public static void Groupies(bool bAdd, Ped Leader)
        {
            if (bAdd)
            {
                DataStore.iPlayerGroup = Function.Call<int>(Hash.CREATE_GROUP);
                Function.Call(Hash.SET_PED_AS_GROUP_LEADER, Leader.Handle, DataStore.iPlayerGroup);
            }
            else
            {
                Function.Call(Hash.REMOVE_GROUP, DataStore.iPlayerGroup);
            }
        }
        public static void AddDogFighters(int iFighter)
        {
            LoggerLight.LogThis("AddDogFighters, iFighter == " + iFighter);

            for (int i = 0; i < iFighter; i++)
            {
                Vector3 PlayerPozy = Game.Player.Character.Position.Around(1500.00f);
                PlayerPozy.Z = 1500.00f;
                float fRotate = Game.Player.Character.Heading;
                ObjectBuild.VehicleSpawn(ReturnStuff.RanVehListX(2, 0, false), PlayerPozy, fRotate, false, false, false, false, 13, 0, 3, DataStore.MyLang.Maptext[20], 0, false);
            }
        }
        public static void AddTarget(Vector3 Vlocal, bool bRoute, bool bPrimary, float fRadius, bool bFlasher, int iCon, string sTag)
        {
            LoggerLight.LogThis("AddTarget");

            if (bPrimary)
            {
                if (MissionData.Target_01 == null)
                {
                    if (fRadius < 2.00f)
                    {
                        MissionData.Target_01 = AddBlips(Vlocal);
                        MissionData.Target_01.IsFlashing = bFlasher;
                        if (bRoute && DataStore.MySettings.ShowRoute)
                            MissionData.Target_01.ShowRoute = true;
                        if (iCon != -1)
                            TaggetIcon(MissionData.Target_01, iCon);

                        if (sTag == "")
                            Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.Target_01.Handle, 8);
                        else
                            ObjectBuild.BlipNames(MissionData.Target_01, sTag);
                        MissionData.Target_01.Color = BlipColor.Yellow6;
                    }
                    else
                    {
                        MissionData.BackUpT = AddBlips(Vlocal);
                        MissionData.BackUpT.Color = BlipColor.Yellow;
                        if (iCon != -1)
                            TaggetIcon(MissionData.BackUpT, iCon);

                        MissionData.Target_01 = AddBlips(Vlocal, fRadius);
                        MissionData.Target_01.Color = BlipColor.Yellow;
                        MissionData.Target_01.Alpha = 85;
                        MissionData.Target_01.IsFlashing = bFlasher;
                        if (bRoute && DataStore.MySettings.ShowRoute)
                            MissionData.BackUpT.ShowRoute = true;

                        if (sTag == "")
                            Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.BackUpT.Handle, 8);
                        else
                            ObjectBuild.BlipNames(MissionData.BackUpT, sTag);
                    }
                }
            }
            else
            {
                if (MissionData.Target_02 == null)
                {
                    if (fRadius < 2.00f)
                    {
                        MissionData.Target_02 = AddBlips(Vlocal);
                        MissionData.Target_02.Color = BlipColor.Orange;
                        MissionData.Target_02.Scale = 0.5f;
                        MissionData.Target_02.IsFlashing = bFlasher;
                    }
                    else
                    {
                        MissionData.Target_02 = AddBlips(Vlocal, fRadius);
                        MissionData.Target_02.Color = BlipColor.Orange;
                        MissionData.Target_02.Alpha = 85;
                        MissionData.Target_02.IsFlashing = bFlasher;
                    }

                    if (sTag == "")
                        Function.Call(Hash.SET_BLIP_DISPLAY, MissionData.Target_02.Handle, 8);
                    else
                        ObjectBuild.BlipNames(MissionData.Target_02, sTag);
                }
            }
        }
        public static Blip AddBlips(Vector3 Vlocal)
        {
            Blip blipps = Function.Call<Blip>(Hash.ADD_BLIP_FOR_COORD, Vlocal.X, Vlocal.Y, Vlocal.Z);
            ObjectLog.BackUpAss("Blip-" + blipps.Handle);
            return blipps;
        }
        public static Blip AddBlips(Vector3 Vlocal, float fRadi)
        {
            Blip blipps = Function.Call<Blip>(Hash.ADD_BLIP_FOR_RADIUS, Vlocal.X, Vlocal.Y, Vlocal.Z, fRadi);
            ObjectLog.BackUpAss("Blip-" + blipps.Handle);
            return blipps;
        }
        public static Blip AddEntBlip(Vehicle Vic)
        {
            Blip blip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, Vic.Handle);
            ObjectLog.BackUpAss("Blip-" + blip.Handle);
            return blip;
        }
        public static Blip AddEntBlip(Ped Peddy)
        {
            Blip blip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, Peddy.Handle);
            ObjectLog.BackUpAss("Blip-" + blip.Handle);
            return blip;
        }
        public static Blip AddEntBlip(Prop Poper)
        {
            Blip blip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, Poper.Handle);
            ObjectLog.BackUpAss("Blip-" + blip.Handle);
            return blip;
        }
        public static void AppeyNess(Vector3 MyAppy)
        {
            LoggerLight.LogThis("AppeyNess, MyAppy == " + MyAppy);

            int iApt = Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, MyAppy.X, MyAppy.Y, MyAppy.Z);
            if (Function.Call<bool>(Hash.IS_VALID_INTERIOR, iApt))
            {
                if (!Function.Call<bool>(Hash.IS_INTERIOR_READY, iApt))
                {
                    Function.Call((Hash)0x2CA429C029CCF247, iApt);
                    Function.Call(Hash.SET_INTERIOR_ACTIVE, iApt, true);
                    Function.Call(Hash.DISABLE_INTERIOR, iApt, false);
                }
            }

        }
        public static void TaggetIcon(Blip bLip, int iCon)
        {
            Function.Call(Hash.SET_BLIP_SPRITE, bLip.Handle, iCon);
        }
        public static void PedSitHere(Ped Peddy, Prop Chair, int iChair)
        {
            LoggerLight.LogThis("PedSitHere, iChair == " + iChair);

            Vector3 vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.55f);

            Peddy.Position = vCharPos;
            Peddy.Heading = Chair.Heading - 180.00f;

            if (iChair == 1)
            {
                ObjectBuild.PedScenario(Peddy, SitChair[RandomNum.RandInt(0, SitChair.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 2)
            {
                vCharPos += (Chair.ForwardVector * 0.30f);
                vCharPos.Z -= 0.10f;
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_SUNLOUNGER", vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 3)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_ARMCHAIR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 4)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_BAR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 5)
                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_COMPUTER", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 6)
            {
                ObjectBuild.PedScenario(Peddy, SitDeck[RandomNum.RandInt(0, SitDeck.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 7)
            {
                ObjectBuild.PedScenario(Peddy, SitBench[RandomNum.RandInt(0, SitBench.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 8)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.70f);

                ObjectBuild.PedScenario(Peddy, SitChair[RandomNum.RandInt(0, SitChair.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 9)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.50f);

                ObjectBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_CHAIR_UPRIGHT", vCharPos, Chair.Heading - 180.00f, true);
            }

            Peddy.AlwaysKeepTask = false;
        }
        public static Blip PedBlimp(Ped pEdd, float fSize, bool bFlashin, bool bShowR, int iColour, string sName)
        {
            LoggerLight.LogThis("PedBlimp");
            Blip Blipy = null;

            if (pEdd.CurrentBlip.Exists())
                Blipy = pEdd.CurrentBlip;
            else
                Blipy = AddEntBlip(pEdd);

            if (fSize != 1.00f)
                Function.Call(Hash.SET_BLIP_SCALE, Blipy.Handle, fSize);

            if (iColour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, Blipy.Handle, iColour);

            if (bFlashin)
                Function.Call(Hash.SET_BLIP_FLASHES, Blipy.Handle, bFlashin);

            if (bShowR && DataStore.MySettings.ShowRoute)
                pEdd.CurrentBlip.ShowRoute = true;

            if (sName != "")
                BlipNames(pEdd.CurrentBlip, sName);

            ObjectLog.BackUpAss("Blip-" + Blipy.Handle);

            return Blipy;
        }
        public static Blip VehBlip(Vehicle Vhic, bool bFlashin, bool bShowR, int iColour, string sName)
        {
            LoggerLight.LogThis("VehBlip");
            Blip MyBlip = null;

            if (Vhic.CurrentBlip.Exists())
                MyBlip = Vhic.CurrentBlip;
            else
                MyBlip = AddEntBlip(Vhic);

            Function.Call(Hash.SET_BLIP_SPRITE, MyBlip.Handle, OhMyBlip(Vhic));
            if (iColour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, MyBlip.Handle, iColour);

            if (bFlashin)
                Function.Call(Hash.SET_BLIP_FLASHES, MyBlip.Handle, true);

            if (bShowR && DataStore.MySettings.ShowRoute)
                Function.Call(Hash.SET_BLIP_ROUTE, MyBlip.Handle, bShowR);

            if (sName != "")
                ObjectBuild.BlipNames(MyBlip, sName);

            return MyBlip;
        }
        public static int OhMyBlip(Vehicle MyVehic)
        {
            LoggerLight.LogThis("OhMyBlip");

            int iBeLip = 0;
            if (MyVehic != null)
            {
                int iVehHash = MyVehic.Model.GetHashCode();

                if (MyVehic.ClassType == VehicleClass.Boats)
                    iBeLip = 427;
                else if (MyVehic.ClassType == VehicleClass.Helicopters)
                    iBeLip = 64;
                else if (MyVehic.ClassType == VehicleClass.Motorcycles)
                    iBeLip = 226;
                else if (MyVehic.ClassType == VehicleClass.Planes)
                    iBeLip = 424;
                else if (MyVehic.ClassType == VehicleClass.Vans)
                    iBeLip = 616;
                else if (MyVehic.ClassType == VehicleClass.Commercial)//mule
                    iBeLip = 477;
                else if (MyVehic.ClassType == VehicleClass.Industrial)//trucks
                    iBeLip = 477;
                else if (MyVehic.ClassType == VehicleClass.Service)//buss
                    iBeLip = 513;
                else if (MyVehic.ClassType == VehicleClass.Super)
                    iBeLip = 595;
                else if (MyVehic.ClassType == VehicleClass.Sports)
                    iBeLip = 523;
                else if (MyVehic.ClassType == VehicleClass.Cycles)
                    iBeLip = 376;
                else
                    iBeLip = 225;

                for (int i = 0; i < vehBlips.Count; i++)
                {
                    if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, vehBlips[i].VehicleKey))
                        iBeLip = vehBlips[i].BlipNo;
                }
            }

            return iBeLip;
        }
        public static int MyCorona(Vector3 Vtech, float fRaid)
        {
            LoggerLight.LogThis("TheYellowCorona");

            int ThisCheck = CheckerPoint(Vtech, Vector3.Zero, 47, fRaid, 255, 255, 0, 255, 180);
            Function.Call(Hash.SET_CHECKPOINT_CYLINDER_HEIGHT, ThisCheck, fRaid / 2, fRaid / 2, fRaid);
            return ThisCheck;
        }
        public static int CheckerPoint(Vector3 vPlace, Vector3 vRota, int iType, float fSize, int red, int green, int blue, int alfa, int reserve)
        {
            int iCheck = Function.Call<int>(Hash.CREATE_CHECKPOINT, iType, vPlace.X, vPlace.Y, vPlace.Z, vRota.X, vRota.Y, vRota.Z, fSize, red, green, blue, alfa, reserve);
            ObjectLog.BackUpAss("Cora-" + iCheck);
            return iCheck;
        }
        public static void PlaySoundFrom(string sAudioBank, string sSound, string sSoundSet, Vector3 Vposy, bool bPhone)
        {
            LoggerLight.LogThis("PlaySoundFrom, bPhone == " + bPhone);

            while (!Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, sAudioBank, false))
                Script.Wait(1);
            DataStore.iSoundId = Function.Call<int>(Hash.GET_SOUND_ID);
            if (bPhone)
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, DataStore.iSoundId, sSound, Vposy.X, Vposy.Y, Vposy.Z, 0, 0, 50, 0);
            else
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, DataStore.iSoundId, sSound, Vposy.X, Vposy.Y, Vposy.Z, sSoundSet, 0, 0, 0);

            ObjectLog.BackUpAss("Soun-" + DataStore.iSoundId);
        }
    }
}
