using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class EntityBuild
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

        public static int MyNumber { get; set; }
        public static Ped NPCSpawn(PedFeat MyPedBuild, Vector3 postion, float facing)
        {
            LoggerLight.LogThis("NPCSpawn");
            Script.Wait(100);
            Ped BuildPed;

            Model model =  MyPedBuild.MyPed;
            model.Request(500);    // Check if the model is valid

            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Script.Wait(1);

                BuildPed = Function.Call<Ped>(Hash.CREATE_PED, 4, model, postion.X, postion.Y, postion.Z, facing, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (BuildPed.Exists())
                {
                    EntityLog.BackUpAss(MyPedBuild.PedTag + BuildPed.Handle);
                    Function.Call(Hash.SET_PED_ACCURACY, BuildPed.Handle, RandomX.RandInt(DataStore.MySettings.LowerAim, DataStore.MySettings.UpperAim));
                    Function.Call(Hash.SET_ENTITY_HEALTH, BuildPed, MyPedBuild.Health);
                    Function.Call(Hash.SET_ENTITY_MAX_HEALTH, BuildPed, MyPedBuild.Health);
                    BuildPed.Weapons.RemoveAll();

                    Function.Call(Hash.SET_PED_PATH_CAN_USE_CLIMBOVERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_USE_LADDERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_DROP_FROM_HEIGHT, BuildPed.Handle, true);

                    if (MyPedBuild.Armor)
                        BuildPed.Armor = 100;

                    MissionData.PedList_01.Add(new Ped(BuildPed.Handle));

                    if (MyPedBuild.Blippy != null)
                        PedBlimp(MyPedBuild.Blippy, BuildPed);

                    if (MyPedBuild.MyGun > 0)
                        GunningIt(BuildPed, MyPedBuild.MyGun);

                    if (MyPedBuild.MyVeh != null)
                    {
                        if (Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, MyPedBuild.MyVeh, MyPedBuild.MySeat - 2))
                        {
                            WarptoAnyVeh(MyPedBuild.MyVeh, BuildPed, MyPedBuild.MySeat);
                            NpcVehicleTasks(BuildPed, MyPedBuild.MyVeh, MyPedBuild.Task);
                        }
                    }
                    else
                    {
                        if (MyPedBuild.Task > 0)
                            NpcTasks(BuildPed, MyPedBuild.Task);
                    }

                    if (MyPedBuild.MyWard != null)
                    {
                        PedDresser(BuildPed, MyPedBuild.MyWard);

                        if (MyPedBuild.MyWard.FreeMode)
                        {
                            if (!MyPedBuild.MyWard.BodySuit)
                                PlayerFaces(BuildPed, MyPedBuild.MyWard);
                        }
                    }
                }
                else
                    BuildPed = null;
            }
            else
                BuildPed = null;

            if (BuildPed == null)
            {
                MyPedBuild.MyPed = "a_m_o_tramp_01";
                BuildPed = NPCSpawn(MyPedBuild, postion, facing);
            }
            return BuildPed;
        }
        public static Ped NPCSpawn(PedFeat MyPedBuild, Vector4 postion)
        {
            LoggerLight.LogThis("NPCSpawn");

            return NPCSpawn(MyPedBuild, new Vector3(postion.X, postion.Y, postion.Z), postion.R);
        }
        public static void NpcTasks(Ped Peddy, int iTask)
        {
            LoggerLight.LogThis("NpcTasks, iTask == " + iTask);


            if (iTask == 1)
            {
                Peddy.Task.Cower(-1);
            }             //Cower
            else if (iTask == 2)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.BlockPermanentEvents = true;
            }        //Flee & Blocking
            else if (iTask == 3)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                NSPM.Convicts_KrishaLine(Peddy, true);
            }        //Convicts leader
            else if (iTask == 4)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                NSPM.Convicts_KrishaLine(Peddy, false);
            }        //Convicts
            else if (iTask == 5)
            {
                if (Game.Player.Character.IsInVehicle())
                    SearchFor.BackSeat.Add(new FindSeat(2, Game.Player.Character.CurrentVehicle, Peddy, 1.3f));
            }        //Fubar Passenger 01
            else if (iTask == 6)
            {
                if (Game.Player.Character.IsInVehicle())
                    SearchFor.BackSeat.Add(new FindSeat(3, Game.Player.Character.CurrentVehicle, Peddy, 1.3f));
            }        //Fubar Passenger 02
            else if (iTask == 7)
            {
                if (Game.Player.Character.IsInVehicle())
                    SearchFor.BackSeat.Add(new FindSeat(4, Game.Player.Character.CurrentVehicle, Peddy, 1.3f));
            }        //Fubar Passenger 03
            else if (iTask == 8)
            {
                Peddy.Task.PlayAnimation("combat@damage@writhe", "writhe_loop", 8.0f, -1, true, 1.0f);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                Peddy.ApplyDamage(50);
            }        //Ambulance VicTim
            else if (iTask == 9)
            {
                EntityBuild.AttackThePlayer(Peddy, false, true, false);
            }        //Fight player Guns Guns GunsNoBlips
            else if (iTask == 10)
            {
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "COUGAR"));
                Peddy.Task.PlayAnimation("creatures@cat@amb@world_cat_sleeping_ground@idle_a", "idle_a", 8.0f, -1, true, 1.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //fireCat
            else if (iTask == 11)
            {
                PedScenario(Peddy, "WORLD_HUMAN_JOG_STANDING", Peddy.Position, Peddy.Heading, false);
                Function.Call(Hash.TASK_TURN_PED_TO_FACE_ENTITY, Peddy.Handle, Game.Player.Character.Handle, -1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            }       //Fire cat owner
            else if (iTask == 12)
            {
                NSPM.BbBomb_BombAtractor(Peddy);
            }       //Bbomb Atractor
            else if (iTask == 13)
            {
                PedScenario(Peddy, "WORLD_HUMAN_COP_IDLES", Peddy.Position, Peddy.Heading, false);
            }       //Idle Cops
            else if (iTask == 14)
            {
                NSPM.Hitman_AddVisionCones(Peddy);
                Peddy.BlockPermanentEvents = true;
            }       //HitMan Mobs
            else if (iTask == 15)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                Peddy.BlockPermanentEvents = true;
            }       //SniperRunner
            else if (iTask == 16)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                NSPM.Sniper_FollowBoss(Peddy);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, false);
            }       //SniperFollow
            else if (iTask == 17)
            {
                AttackThePlayer(Peddy, false, true, true);
            }       //Fight player Guns Guns Guns with Blips
            else if (iTask == 18)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.Task.FightAgainstHatedTargets(45.00f);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Peddy.AlwaysKeepTask = true;
            }       //Water ImportGaurds
            else if (iTask == 19)
            {
                int iFight = RandomX.FindRandom("RanFight", 1, 50);
                if (iFight < 30)
                    iFight = 1;
                else
                    iFight = 2;

                AttackThePlayer(Peddy, false, true, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, iFight);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Attacks Rand-StatOffDeff
            else if (iTask == 20)
            {
                Peddy.Task.PlayAnimation("amb@world_human_stand_fishing@idle_a", "idle_b", 8.00f, -1, true, 1.00f);
                Prop FishRod = BuildProp("prop_fishing_rod_01", Peddy.Position, Vector3.Zero, true, true);
                if (FishRod != null)
                    FishRod.AttachTo(Peddy, Peddy.GetBoneIndex(Bone.SKEL_L_Hand), new Vector3(0.00f, -0.00f, 0.00f), new Vector3(-122.00f, 100.00f, 30.00f));
            }       //Water Phishing
            else if (iTask == 21)
            {
                AttackThePlayer(Peddy, false, true, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 0);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - static
            else if (iTask == 22)
            {
                AttackThePlayer(Peddy, false, true, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Defence
            else if (iTask == 23)
            {
                AttackThePlayer(Peddy, false, true, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Offence
            else if (iTask == 24)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                //Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //BikerBiz
            else if (iTask == 25)
            {
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                NSPM.Hitman_AddVisionCones(Peddy);
            }       //MoresMan
            else if (iTask == 26)
            {
                PedScenario(Peddy, "WORLD_HUMAN_PARTYING", Peddy.Position, Peddy.Heading, false);
            }       //Dance
            else if (iTask == 27)
            {
                PedScenario(Peddy, "WORLD_HUMAN_GUARD_STAND", Peddy.Position, Peddy.Heading, false);
            }       //Club Bouncer
            else if (iTask == 28)
            {
                NSPM.TempAgency_02_BuildCluber(Peddy);
            }       //DrinkNDance Clubber
            else if (iTask == 29)
            {
                ForceAnim(Peddy, "amb@code_human_in_bus_passenger_idles@male@sit@base", "base", Peddy.Position, Peddy.Rotation);
                Function.Call(Hash.SET_PED_CAN_SWITCH_WEAPON, Peddy.Handle, true);
            }       //peds in back of plane
            else if (iTask == 30)
            {
                PedScenario(Peddy, "WORLD_HUMAN_CLIPBOARD", Peddy.Position, Peddy.Heading, false);
            }       //StandClippBoard
            else if (iTask == 31)
            {
                PedScenario(Peddy, "WORLD_HUMAN_SMOKING", Peddy.Position, Peddy.Heading, false);
            }       //StandSmoke
            else if (iTask == 32)
            {
                ArmNpcWeapon("WEAPON_minigun", Peddy);
                Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Peddy.Handle, true, false, true, true);
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, 0, 0, 0, false);
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
            }       //Juggonorts-add acc hat to 1-
            else if (iTask == 33)
            {
                NSPM.Johnny_AddPlayer(Peddy);
            }       //JohnnyAtt
            else if (iTask == 34)
            {
                AttackThePlayer(Peddy, false, false, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //GreenAttacks
        }
        public static void NpcVehicleTasks(Ped Peddy, Vehicle Vehic, int iTask)
        {
            LoggerLight.LogThis("NpcVehicleTasks, iTask == " + iTask);

            if (iTask == 1)
            {
                Peddy.BlockPermanentEvents = true;
                Peddy.AlwaysKeepTask = true;
                Function.Call(Hash.SET_DRIVER_ABILITY, Peddy.Handle, 1f);
                Function.Call(Hash.SET_DRIVER_AGGRESSIVENESS, Peddy.Handle, 100f);
                Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_CONFIG_FLAG, Peddy.Handle, 32, false);
                NSPM.Racist_MultiPed(Peddy, Vehic, MyNumber);
                MyNumber++;
            }            //Race Drivers
            else if (iTask == 2)
            {
                Peddy.Task.ClearAll();
                Peddy.Task.CruiseWithVehicle(Vehic, 35.00f, 262972);
            }       //Drive RandDest
            else if (iTask == 3)
            {
                Function.Call(Hash.SET_ENTITY_HEALTH, Peddy, 0);
            }       //Dead Ped
            else if (iTask == 4)
            {
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Peddy.Handle, 46, true);
                FlyPlane(Peddy, Vehic, Game.Player.Character.Position, Game.Player.Character);
            }       //DogFighter
            else if (iTask == 5)
            {
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 75.00f;
                    Peddy.DrivingStyle = 0;
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
            }       //Attack Player
            else if (iTask == 6)
            {
                PedMultiTask MyNewPed = new PedMultiTask(Peddy, Vehic, 1);
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyBlip = VehBlip(new BlipForm(1, DataStore.MyLang.Maptext[106]), Vehic);
                    NSPM.Follow_AttackBGroup(Peddy, true);
                }
                else
                    NSPM.Follow_AttackBGroup(Peddy, false);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                NSPM.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //GroupBFollowAttackGroupA
            else if (iTask == 7)
            {
                PedMultiTask MyNewPed = new PedMultiTask(Peddy, Vehic, 1);
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyBlip = VehBlip(new BlipForm(1, DataStore.MyLang.Maptext[106]), Vehic);
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                NSPM.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //Vehiclle Attacks full car
            else if (iTask == 8)
            {
                Peddy.Task.ClearAll();
                Peddy.Task.Wait(-1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Wait in vehicle
            else if (iTask == 9)
            {
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.BlockPermanentEvents = true;
            }       //MoneyMan Guard
            else if (iTask == 10)
            {
                float fSpeeds = 25.00f;
                Peddy.Task.ClearAll();
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                Vector3 PlayPos = Game.Player.Character.Position;
                Peddy.DrownsInWater = false;
                Function.Call(Hash.TASK_BOAT_MISSION, Peddy.Handle, Vehic.Handle, 0, 0, PlayPos.X, PlayPos.Y, PlayPos.Z, 4, fSpeeds, 16777216, 5.50f, 7);

                PedMultiTask MyNewPed = new PedMultiTask(Peddy, Vehic, 1);
                MyNewPed.MyName = DataStore.MyLang.Maptext[20];
                MyNewPed.MyBlip = Vehic.CurrentBlip;
                NSPM.MultiPed.Add(MyNewPed);
            }      //WAter JetskiAttacks
            else if (iTask == 11)
            {
                WarptoAnyVeh(Vehic, Peddy, 1);
                FlyNShoot(Peddy, Vehic, Game.Player.Character);
            }      //HeliAtackPilot
            else if (iTask == 12)
            {
                Peddy.RelationshipGroup = DataStore.GP_Player;
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }      //Caisno Customers
            else if (iTask == 13)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
            }       //ValcaryPilot
            else if (iTask == 14)
            {
                NSPM.ImportsExpo_Driver(Peddy);
                Peddy.Task.ClearAll();
                FubarVectors GoHere = MissionData.PickUpApartmentBlocks(RandomX.RandInt(1, 6), 7, false);
                Peddy.Task.ParkVehicle(Vehic, GoHere.ParkHere.V3, GoHere.ParkHere.R);
                Peddy.DrivingSpeed = 35.0f;
                Peddy.DrivingStyle = DrivingStyle.Rushed;
                    //(Vehic, 35.00f, 262972);
            }       //ImportDriver
            else if (iTask == 15)
            {
                Peddy.Task.ClearAll();
                FubarVectors GoHere = MissionData.PickUpApartmentBlocks(RandomX.RandInt(1, 6), 7, false);
                Peddy.Task.ParkVehicle(Vehic, GoHere.ParkHere.V3, GoHere.ParkHere.R);
                Peddy.DrivingSpeed = 35.0f;
                Peddy.DrivingStyle = DrivingStyle.Rushed;
            }       //FollowDriver
        }
        public static void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.LogThis("EntityBuild.ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName)
        {
            LoggerLight.LogThis("EntityBuild.ForceAnimOnce, sAnimName == " + sAnimName);
            Vector3 AnPos = peddy.Position;
            Vector3 AnRot = peddy.Rotation;
            ForceAnimOnce(peddy, sAnimDict, sAnimName, AnPos, AnRot);
        }
        public static void ForceAnimOnceEnding(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot, float fEnder)
        {
            LoggerLight.LogThis("EntityBuild.ForceAnimOnce, sAnimName == " + sAnimName);

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
        public static void AddGroupie(Ped Peddy)
        {
            Peddy.CanBeShotInVehicle = true;
            Peddy.RelationshipGroup = DataStore.GP_Player;
            Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, Peddy.Handle, DataStore.iPlayerGroup);
        }
        public static void OhDoKeepUp(Ped Peddy, Ped Leader, float fSpeed, bool bClose)
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
        public static void PedDresser(Ped Peddy, ClothBank MyCloth)
        {
            PedDresser(Peddy, MyCloth.Cothing);
        }
        public static void PedDresser(Ped Peddy, ClothX MyCloth)
        {
            LoggerLight.LogThis("PedDresser");

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy.Handle);

            for (int i = 0; i < MyCloth.ClothA.Count; i++)
            {
                if (MyCloth.ClothA[i] != -10)
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, i, MyCloth.ClothA[i], MyCloth.ClothB[i], 2);
            }
            for (int i = 0; i < MyCloth.ExtraA.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, i, MyCloth.ExtraA[i], MyCloth.ExtraB[i], false);
        }
        public static void PedDresser(Ped Peddy, ClothX MyCloth, List<int> LeaveOut)
        {
            LoggerLight.LogThis("PedDresser");

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy.Handle);

            for (int i = 0; i < MyCloth.ClothA.Count; i++)
            {
                if (!LeaveOut.Contains(i) || MyCloth.ClothA[i] != -10)
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, i, MyCloth.ClothA[i], MyCloth.ClothB[i], 2);
            }

            for (int i = 0; i < MyCloth.ExtraA.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, i, MyCloth.ExtraA[i], MyCloth.ExtraB[i], false);
        }
        private static void PlayerFaces(Ped Pedx, ClothBank MyCloth)
        {
            LoggerLight.LogThis("PlayerFaces");

            Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Pedx.Handle, MyCloth.MyFaces.XshapeFirstID, MyCloth.MyFaces.XshapeSecondID, MyCloth.MyFaces.XshapeThirdID, MyCloth.MyFaces.XskinFirstID, MyCloth.MyFaces.XskinSecondID, MyCloth.MyFaces.XskinThirdID, MyCloth.MyFaces.XshapeMix, MyCloth.MyFaces.XskinMix, MyCloth.MyFaces.XthirdMix, MyCloth.MyFaces.XisParent);


            for (int i = 0; i < MyCloth.MyOverlay.Count; i++)
            {
                Function.Call(Hash.SET_PED_HEAD_OVERLAY, Pedx.Handle, i, MyCloth.MyOverlay[i].Overlay, MyCloth.MyOverlay[i].OverOpc);

                if (MyCloth.MyOverlay[i].OverCol > 0)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Pedx.Handle, i, RandomX.RandInt(0, 64), MyCloth.MyOverlay[i].OverCol, 0);
            }

            if (MyCloth.MyHair.Name != "")
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, MyCloth.MyHair.Comp, MyCloth.MyHair.Text, 2);
                Function.Call(Hash._SET_PED_DECORATION, Pedx.Handle, MyCloth.MyHair.OverLib, MyCloth.MyHair.Over);
            }

            Function.Call(Hash._SET_PED_HAIR_COLOR, Pedx.Handle, MyCloth.HairColour, MyCloth.HairStreaks);

            for (int i = 0; i < MyCloth.MyTattoo.Count; i++)
                Function.Call(Hash._SET_PED_DECORATION, Pedx.Handle, Function.Call<int>(Hash.GET_HASH_KEY, MyCloth.MyTattoo[i].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, MyCloth.MyTattoo[i].TatName));

        }
        public static void PlayerEnemy(Ped Pedd, bool VehicleCombat)
        {
            LoggerLight.LogThis("PlayerEnemy");

            Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Pedd, DataStore.GP_Attack);
            //Pedd.RelationshipGroup = DataStore.GP_Attack;
            Function.Call(Hash.SET_PED_AS_ENEMY, Pedd, true);
            //Pedd.IsEnemy = true;
            //Pedd.CanBeTargette﻿d﻿ = true;
            //Game.Player.Character.CanBeTargetted = true;
            if (VehicleCombat)
            {
                // Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 1442, true);
            }
            else
                Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            //Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 2, false);//steal a Vehicle?
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Function.Call((Hash)0xF166E48407BAC484, Pedd, Game.Player.Character, 0, 16);
            //Pedd.Task.FightAgainst(Game.Player.Character);

        }
        public static void AttackThePlayer(Ped Pedd, bool InVehicle, bool bWeaps, bool bLippy)
        {
            LoggerLight.LogThis("AttackThePlayer");

            PlayerEnemy(Pedd, InVehicle);
            if (bLippy)
                PedBlimp(new BlipForm(1, "", 0.75f), Pedd);

            if (bWeaps)
            {
                ArmsRegulator(Pedd, 2);
                ArmsRegulator(Pedd, 3);
                ArmsRegulator(Pedd, 4);
                ArmsRegulator(Pedd, 5);
            }
        }
        public static void WalkThisWay(Ped Peddy, Vector3 VSpot, float fSpeed)
        {
            Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, Peddy.Handle, VSpot.X, VSpot.Y, VSpot.Z, fSpeed, -1, 0f, false, 0f);
        }
        private static void DriveByPlayer(Ped Pedd, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            PlayerEnemy(Pedd, true);
            if (bDriver)
                Pedd.Task.VehicleChase(Game.Player.Character);
            else
                Pedd.Task.VehicleShootAtPed(Game.Player.Character); 
            
            ArmsRegulator(Pedd, 3);
            ArmsRegulator(Pedd, 4);
            ArmsRegulator(Pedd, 5);
        }
        public static void DriveByPed(Ped Pedd, Ped Victim, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            Pedd.CanBeTargette﻿d﻿ = true;
            if (bDriver)
            {
                Pedd.Task.VehicleChase(Victim);
                Pedd.AlwaysKeepTask = true;
                Pedd.BlockPermanentEvents = true;
            }
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
                int iRanGun = RandomX.RandInt(0, 50);
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
                int iRanGun = RandomX.RandInt(0, 30);
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
                if (RandomX.RandInt(0, 20) < 10)
                    ArmNpcWeapon("WEAPON_combatmg", Peddy);
                else
                    ArmNpcWeapon("WEAPON_minigun", Peddy);
            }       //heavy
            else if (iSet == 3)
            {
                ArmNpcWeapon(MidWeapList[RandomX.RandInt(0, MidWeapList.Count - 1)], Peddy);
            }       //Mid
            else if (iSet == 4)
            {
                ArmNpcWeapon(SmallWeapList[RandomX.RandInt(0, SmallWeapList.Count - 1)], Peddy);
            }       //small
            else if (iSet == 5)
            {
                ArmNpcWeapon(MelleWeapList[RandomX.RandInt(0, MelleWeapList.Count - 1)], Peddy);
            }       //melee
            else if (iSet == 6)
            {
                ArmNpcWeapon("WEAPON_molotov", Peddy);
            }       //Molly
            else if (iSet == 7)
            {
                ArmNpcWeapon("WEAPON_FIREEXTINGUISHER", Peddy);
                Function.Call(Hash.SET_PED_INFINITE_AMMO, Peddy.Handle, true, Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_FIREEXTINGUISHER"));
            }       //extingrish
            Peddy.CanSwitchWeapons = true;
        }
        public static void EnterAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat, float Run)
        {
            LoggerLight.LogThis("EnterAnyVeh, iSeat == " + iSeat + ", Run == " + Run);

            if (Vhic.Exists())
            {
                Function.Call(Hash.TASK_ENTER_VEHICLE, Peddy.Handle, Vhic.Handle, -1, iSeat - 2, Run, 1, 0);
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

            int iFail = 10;
            bool bFader = false;

            if (Peddy.IsInVehicle() && Peddy.CurrentVehicle.Handle != Vhic.Handle)
                GetOutofVeh(Peddy, 1);

            if (Peddy == Game.Player.Character)
            {
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                bFader = true;
            }

            while (!Peddy.IsInVehicle(Vhic) && iFail > 0)
            {
                VehicleWarp(Vhic, Peddy, iSeat);
                Script.Wait(100);
                iFail--;
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
        public static void FleeFromVeh(Ped Peddy)
        {
            LoggerLight.LogThis("FleeFromVeh");

            Peddy.Task.ClearAll();
            GetOutofVeh(Peddy, 2);
            Peddy.Task.FleeFrom(Game.Player.Character);
        }
        public static void PedSitHere(Ped Peddy, Prop Chair, int iChair)
        {
            LoggerLight.LogThis("PedSitHere, iChair == " + iChair);

            Vector3 vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.55f);

            Peddy.Position = vCharPos;
            Peddy.Heading = Chair.Heading - 180.00f;

            if (iChair == 1)
            {
                EntityBuild.PedScenario(Peddy, SitChair[RandomX.RandInt(0, SitChair.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 2)
            {
                vCharPos += (Chair.ForwardVector * 0.30f);
                vCharPos.Z -= 0.10f;
                EntityBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_SUNLOUNGER", vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 3)
                EntityBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_ARMCHAIR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 4)
                EntityBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_BAR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 5)
                EntityBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_COMPUTER", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 6)
            {
                EntityBuild.PedScenario(Peddy, SitDeck[RandomX.RandInt(0, SitDeck.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 7)
            {
                EntityBuild.PedScenario(Peddy, SitBench[RandomX.RandInt(0, SitBench.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 8)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.70f);

                EntityBuild.PedScenario(Peddy, SitChair[RandomX.RandInt(0, SitChair.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 9)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.50f);

                EntityBuild.PedScenario(Peddy, "PROP_HUMAN_SEAT_CHAIR_UPRIGHT", vCharPos, Chair.Heading - 180.00f, true);
            }

            Peddy.AlwaysKeepTask = false;
        }
        public static void LandNearHeli(Ped Peddy, Vehicle vHick, Vector3 vTarget)
        {
            float HeliDesX = vTarget.X;
            float HeliDesY = vTarget.Y;
            float HeliDesZ = vTarget.Z;
            float HeliSpeed = 35f;
            float HeliLandArea = 10f;

            float dx = vHick.Position.X - HeliDesX;
            float dy = vHick.Position.Y - HeliDesY;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;

            Function.Call(Hash.TASK_HELI_MISSION, Peddy.Handle, vHick.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 20, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);

            Function.Call(Hash.SET_PED_FIRING_PATTERN, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "FIRING_PATTERN_BURST_FIRE_HELI"));
            Peddy.AlwaysKeepTask = true;
            Peddy.BlockPermanentEvents = true;
        }
        public static void LandNearPlane(Ped Peddy, Vehicle vHick, Vector3 vStart, Vector3 vFinish)
        {
            Function.Call(Hash.TASK_PLANE_LAND, Peddy.Handle, vHick.Handle, vStart.X, vStart.Y, vStart.Z, vFinish.X, vFinish.Y, vFinish.Z);
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
        }
        public static void FlyHeli(Ped Pedd, Vehicle Vhick, Vector3 vHeliDest, float fSpeed, float flanding)
        {
            LoggerLight.LogThis("PedActions.FlyHeli");

            Function.Call(Hash.FREEZE_ENTITY_POSITION, Vhick, false);

            float HeliDesX = vHeliDest.X;
            float HeliDesY = vHeliDest.Y;
            float HeliDesZ = vHeliDest.Z;
            float HeliSpeed = fSpeed;
            float HeliLandArea = flanding;

            float dx = Pedd.Position.X - HeliDesX;
            float dy = Pedd.Position.Y - HeliDesY;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;

            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, Vhick.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 9, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);
            Function.Call(Hash.SET_PED_FIRING_PATTERN, Pedd.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "FIRING_PATTERN_BURST_FIRE_HELI"));
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        public static void FlyPlane(Ped Pedd, Vehicle Vhick, Vector3 vPlaneDest, Ped AttackPLayer)
        {
            LoggerLight.LogThis("PedActions.FlyPlane");

            float dx = Vhick.Position.X - vPlaneDest.X;
            float dy = Vhick.Position.Y - vPlaneDest.Y;
            float fAngle = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;//Vector3.Angle(Vhick.Position, vPlaneDest);
            if (AttackPLayer != null)
            {
                Function.Call(Hash.SET_PED_ACCURACY, Pedd.Handle, 95);
                Function.Call(Hash.SET_CURRENT_PED_VEHICLE_WEAPON, Pedd.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "VEHICLE_WEAPON_PLANE_ROCKET"));
                if (AttackPLayer.IsInVehicle())
                    Function.Call(Hash.TASK_PLANE_MISSION, Pedd.Handle, Vhick.Handle, AttackPLayer.CurrentVehicle.Handle, 0, 0, 0, 0, 6, 0.0f, 0.0f, 180.0f, 1000.0f, -5000.0f);
                else
                    Function.Call(Hash.TASK_PLANE_MISSION, Pedd.Handle, Vhick.Handle, 0, AttackPLayer.Handle, 0, 0, 0, 6, 0.0f, 0.0f, 0.0f, 1000.0f, -5000.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
                Pedd.BlockPermanentEvents = false;
            }
            else
                Function.Call(Hash.TASK_PLANE_MISSION, Pedd.Handle, Vhick.Handle, 0, 0, vPlaneDest.X, vPlaneDest.Y, vPlaneDest.Z, 4, 100f, 0f, fAngle, 5000f, -100f);
        }
        public static void FlyHeli(Ped Pedd, Vector3 vHeliDest, float fSpeed, float flanding)
        {
            LoggerLight.LogThis("FlyAway");

            Vehicle vHeli = Pedd.CurrentVehicle;
            Function.Call(Hash.FREEZE_ENTITY_POSITION, vHeli, false);

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
        public static void ResetVehPos(Vehicle Vhick, Vector3 Pos, float Heads)
        {
            ResetVehPos(Vhick, new Vector4(Pos.X, Pos.Y, Pos.Z, Heads));
        }
        public static void ResetVehPos(Vehicle Vhick, Vector4 Pos)
        {
            LoggerLight.LogThis("ResetVehPos");

            Vhick.Position = Pos.V3;
            Vhick.Rotation = new Vector3(0.00f, 0.00f, Pos.R);
            Script.Wait(1000);
            Function.Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Vhick.Handle);
        }
        public static void ShowBoating(Ped PedX, Vector3 vEctor, Vehicle Vhick, float fSpeeds, int iDrivinStyle)
        {
            LoggerLight.LogThis("ShowBoating");

            PedX.Task.ClearAll();
            Function.Call(Hash.TASK_BOAT_MISSION, PedX.Handle, Vhick.Handle, 0, 0, vEctor.X, vEctor.Y, vEctor.Z, 4, fSpeeds, iDrivinStyle, -1.0f, 7);
            Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, PedX.Handle, true);
        }
        public static void ShowBoating(Ped PedX, Vector4 vEctor, Vehicle Vhick, float fSpeeds, int iDrivinStyle)
        {
            ShowBoating(PedX, new Vector3(vEctor.X, vEctor.Y, vEctor.Z), Vhick, fSpeeds, iDrivinStyle);
        }
        public static void DriveToDest(Vehicle Vhickery, Vector3 TheDest, Ped Peddy, float fSpeding, int iDriveStyle)
        {
            Peddy.Task.ClearAll();
            Peddy.Task.DriveTo(Vhickery, TheDest, 1.50f, fSpeding, iDriveStyle);
            Peddy.AlwaysKeepTask = true;
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            Peddy.AlwaysKeepTask = true;
            Peddy.BlockPermanentEvents = true;
        }
        public static void DriveToDest(Vehicle Vhickery, Vector4 TheDest, Ped Peddy, float fSpeding, int iDriveStyle)
        {
            DriveToDest(Vhickery, new Vector3(TheDest.X, TheDest.Y, TheDest.Z), Peddy, fSpeding, iDriveStyle);
        }
        public static void FlyNShoot(Ped Pedd, Vehicle vHeli, Ped Target)
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
        public static void MoveThatCar(Vector3 VPos)
        {
            LoggerLight.LogThis("MoveThatCarV3");

            List<Vehicle> carsy = SearchFor.GetLocalVeh(VPos, 30.00f);

            for (int i = 0; i < carsy.Count; i++)
            {
                Vehicle car = carsy[i];
                if (car.Exists())
                {
                    if (!car.IsPersistent && !car.EngineRunning)
                    {
                        if (car.ClassType == VehicleClass.Industrial)
                            car.Delete();
                        else
                        {
                            car.IsPersistent = true;
                            MissionData.VehicleList_01.Add(new Vehicle(car.Handle));
                            EntityBuild.NPCSpawn(new PedFeat(ReturnStuff.RandNPC(1), true, 150, 2, 1, car, 0), new Vector4(car.Position.X, car.Position.Y, car.Position.Z, car.Heading));
                        }
                    }
                }
            }
        }
        public static void MoveThatCar(Vector4 VPos)
        {
            LoggerLight.LogThis("MoveThatCarV4");
            MoveThatCar(new Vector3(VPos.X, VPos.Y, VPos.Z));
        }
        public static void FlyToRightHere(Ped Pedd, Vehicle vHeli, Vector3 vHeliDest, float fSpeed, float fheader)
        {
            LoggerLight.LogThis("FlyToRightHere");

            float HeliDesX = vHeliDest.X;
            float HeliDesY = vHeliDest.Y;
            float HeliDesZ = vHeliDest.Z;
            float HeliSpeed = fSpeed;
            float HeliDirect = fheader;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        public static void FlyToRightHere(Ped Pedd, Vehicle vHeli, Vector4 vHeliDest, float fSpeed)
        {
            FlyToRightHere(Pedd, vHeli, new Vector3(vHeliDest.X, vHeliDest.Y, vHeliDest.Z), fSpeed, vHeliDest.R);
        }
        public static int DogFighterTracking()
        {
            MissionData.iTracking = Game.GameTime + 1000;
            int iKill = 0;
            for (int i = 0; i < NSPM.MultiPed.Count; i++)
            {
                if (!NSPM.MultiPed[i].MyPed.IsInVehicle() || NSPM.MultiPed[i].MyPed.IsDead || NSPM.MultiPed[i].MyVehicle.IsDead || NSPM.MultiPed[i].MyVehicle.IsOnFire)
                {
                    if (NSPM.MultiPed[i].MyBlip.Exists())
                        NSPM.MultiPed[i].MyBlip.Remove();
                    NSPM.MultiPed[i].MyVehicle.Explode();
                    MissionData.VehicleList_01.Remove(NSPM.MultiPed[i].MyVehicle);
                    NSPM.MultiPed[i].MyVehicle.MarkAsNoLongerNeeded();
                    MissionData.PedList_01.Remove(NSPM.MultiPed[i].MyPed);
                    NSPM.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                    NSPM.MultiPed.RemoveAt(i);
                    iKill++;
                }
            }

            if (NSPM.MultiPed.Count < 5)
                AddDogFighters(1);

            return iKill;
        }
        public static Vehicle VehicleSpawn(VehMods VehModel, Vector3 VecLocal, float VecHead)
        {
            LoggerLight.LogThis("VehicleSpawn == " + VehModel.MyVehicle);
            Script.Wait(100);

            Vehicle BuildVehicle = null;
            int iVehHash = VehModel.ModelHash;
            if (VehModel != null)
            {
                if (VehModel.MyVehicle == "GetPlayersVeh")
                    iVehHash = Game.Player.Character.CurrentVehicle.Model.Hash;
                else if (VehModel.MyVehicle == "")
                    VehModel.MyVehicle = "ASEA";

                if (iVehHash == -1)
                    iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, VehModel.MyVehicle);

                LoggerLight.LogThis("VehicleSpawn, iVehHash == " + iVehHash);

                if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash))
                {
                    Function.Call(Hash.REQUEST_MODEL, iVehHash);
                    while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                        Script.Wait(1);

                    BuildVehicle = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, VecLocal.X, VecLocal.Y, VecLocal.Z, VecHead, true, true);
                    Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);
                    if (BuildVehicle != null)
                    {
                        EntityLog.BackUpAss(VehModel.VehTag + BuildVehicle.Handle);

                        BuildVehicle.IsPersistent = true;
                        Function.Call(Hash.FREEZE_ENTITY_POSITION, BuildVehicle, VehModel.Frozen);

                        if (VehModel.NumberPlate != "")
                            SetPlate(BuildVehicle, VehModel.NumberPlate);

                        if (VehModel.Neons.Enable)
                            AddNeons(BuildVehicle, VehModel.Neons);

                        if (VehModel.Blippy != null)
                            VehBlip(VehModel.Blippy, BuildVehicle);

                        if (VehModel.RemoveExtras)
                            ModExtras(BuildVehicle, new List<int>());

                        if (VehModel.MyVehMods.Count > 0)
                            MakeModsNotWar(BuildVehicle, VehModel.MyVehMods);

                        if (VehModel.MyVehExtras.Count > 0)
                            ModExtras(BuildVehicle, VehModel.MyVehExtras);

                        if (VehModel.Task > 0)
                            VehicleTasks(BuildVehicle, VehModel.Task);

                        MissionData.VehicleList_01.Add(new Vehicle(BuildVehicle.Handle));
                    }
                }
                else
                {
                    VehModel.MyVehicle = "ASEA";
                    BuildVehicle = VehicleSpawn(VehModel, VecLocal, VecHead);
                }
            }

            return BuildVehicle;
        }
        public static Vehicle VehicleSpawn(VehMods VehModel, Vector4 VecLocal)
        {
            return VehicleSpawn(VehModel, new Vector3(VecLocal.X, VecLocal.Y, VecLocal.Z), VecLocal.R);
        }
        private static void SetPlate(Vehicle vHick, string sText)
        {
            Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, vHick.Handle, sText);
        }
        public static void MakeModsNotWar(Vehicle Vehic, List<int> MyMods)
        {
            LoggerLight.LogThis("MakeModsNotWar");

            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Vehic.Handle, 0);

            for (int i = 0; i < MyMods.Count; i++)
            {
                if (MyMods[i] == -10)
                {

                }
                else if (i == 48)
                {
                    if (MyMods[i] == -1)
                    {
                        int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i) - 1;
                        if (iSpoilher < 1)
                            iSpoilher = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Vehic.Handle) - 1;
                        MyMods[i] = RandomX.RandInt(0, iSpoilher);
                    }
                    Function.Call(Hash.SET_VEHICLE_LIVERY, Vehic.Handle,MyMods[i]);
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, MyMods[i], true);
                }
                else if (i == 66)
                {
                    if (MyMods[i] == -1)
                    {
                        int iCheckHere = RandomX.RandInt(0, 159);
                        MyMods[i] = iCheckHere;
                    }
                }
                else if (i == 67)
                {
                    if (MyMods[i] == -1)
                    {
                        int iCheckHere = RandomX.RandInt(0, 159);
                        Function.Call(Hash.SET_VEHICLE_COLOURS, Vehic.Handle, MyMods[i-1], iCheckHere);
                    }
                    else
                        Function.Call(Hash.SET_VEHICLE_COLOURS, Vehic.Handle, MyMods[i-1], MyMods[i]);
                }
                else if (MyMods[i] == -1)
                {
                    int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i) - 1;
                    int iCheckHere = RandomX.RandInt(0, iSpoilher);
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iCheckHere, true);
                }
                else
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, MyMods[i], true);
            }
        }
        public static void AddNeons(Vehicle Vehic, VehNeons myNeons)
        {
            LoggerLight.LogThis("AddNeons");
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, Vehic, 0, myNeons.Left);
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, Vehic, 1, myNeons.Right);
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, Vehic, 2, myNeons.Front);
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, Vehic, 3, myNeons.Rear);
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHTS_COLOUR, Vehic, myNeons.RGBA.R, myNeons.RGBA.G, myNeons.RGBA.B);
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
        public static void VehicleTasks(Vehicle Vehic, int iMod)
        {
            LoggerLight.LogThis("VehicleMods, iMod == " + iMod);

            List<int> MyExtras = new List<int>();

            if (iMod == 1)
                MissionData.MishVeh = Vehic;
            else if (iMod == 2)
                DataStore.SharedVeh = Vehic;
            else if (iMod == 3)
            {
                Vehic.DirtLevel = 12f;
                NSPM.Fubar_SpawnInCar(Vehic);
            }       // Fubar Car
            else if (iMod == 4)
            {
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);
                Ped Dog = NPCSpawn(new PedFeat(ReturnStuff.RandNPC(43), false, 200, 4, 1, Vehic, 0), Vector3.Zero, 0.00f);
                PedMultiTask Fighter = new PedMultiTask(Dog, Vehic, 1);
                NSPM.MultiPed.Add(Fighter);
            }       // Dogfighers
            else if (iMod == 5)
            {
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(1), true, 150, 2, 1, Vehic, 0), new Vector4(Vehic.Position.X, Vehic.Position.Y, Vehic.Position.Z, Vehic.Heading));
                MissionData.MishVeh = Vehic;
            }       // Add Driver Random Dest-MishVic
            else if (iMod == 6)
            {
                Vehic.EngineRunning = true;
                Vector3 V3Me = Function.Call<Vector3>(Hash._0xCBDB9B923CACC92D, Vehic.Handle);
                Function.Call(Hash._0x7BEB0C7A235F6F3B, Vehic.Handle, 0);
            }       // Lower hook cargobob
            else if (iMod == 7)
            {
                Vehic.LockStatus = VehicleLockStatus.Locked;
            }       // LockTheDoors
            else if (iMod == 8)
            {
                int iNoSeats = Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Vehic) + 1;
                int iRando = RandomX.RandInt(1, 10);
                while (iNoSeats > 0)
                {
                    NPCSpawn(new PedFeat(ReturnStuff.RandNPC(iRando), false, 180, 7, iNoSeats, Vehic, 2, false, 1, ""), Vehic.Position, Vehic.Heading);
                    iNoSeats --;
                    Script.Wait(1);
                }
            }       // rando att fill seats+Add to Mulltiped
            else if (iMod == 9)
            {
                int iNoSeats = Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Vehic) + 1;
                int iRando = RandomX.RandInt(1, 10);
                while (iNoSeats > 0)
                {
                    NPCSpawn(new PedFeat(ReturnStuff.RandNPC(iRando), false, 180, 6, iNoSeats, Vehic, 2, false, 1, ""), Vehic.Position, Vehic.Heading);
                    iNoSeats --;
                    Script.Wait(1);
                }
            }       // Groupb attack + fill seats Add to Mulltiped
            else if (iMod == 10)
            {
                Vehic.Explode();
            }       // ExplodeVeh
            else if (iMod == 11)
            {
                NSPM.Fire_FlaminPed(Vehic);
            }       // FireFlaminPed(5)
            else if (iMod == 12)
            {
                Ped TaxMan = NPCSpawn(new PedFeat(ReturnStuff.RandNPC(14), false, 120, 5, 1, Vehic, 2, false, 0, ""), Vehic.Position, 0.00f);
                VehBlip(new BlipForm(1, "Angry Taxi"), Vehic);
                PedMultiTask Taxi = new PedMultiTask(TaxMan, Vehic, 1);
                Taxi.MyBlip = Vehic.CurrentBlip;
                NSPM.MultiPed.Add(Taxi);
            }       // Crazy Taxies
            else if (iMod == 13)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(44), false, 220, 1, 1, Vehic, 0, true, 3, DataStore.MyLang.Maptext[109]), Vehic.Position, 0.00f);
            }       // Raceing Drivers
            else if (iMod == 14)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(33), false, 180, 10, 1, Vehic, 2, false, 0, ""), Vehic.Position, Vehic.Heading);

            }       // Water Boat -- Area 1 Jetski Attack 
            else if (iMod == 15)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
            }       // Boat Anckor
            else if (iMod == 16)
            {
                int iNoSeats = Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Vehic) + 1;
                while (iNoSeats > 0)
                {
                    NPCSpawn(new PedFeat(ReturnStuff.RandNPC(4), false, 150, 7, iNoSeats, Vehic, 2, false, 0, ""), Vehic.Position, Vehic.Heading);
                    iNoSeats --;
                    Script.Wait(1);
                }
            }       // LostMcAttack
            else if (iMod == 17)
            {
                NPCSpawn(new PedFeat("", false, 170, 11, 1, Vehic, 0, false, 0, ""), Vehic.Position, 0.00f);
                int iNoSeats = Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Vehic) + 1;
                while (iNoSeats > 1)
                {
                    NPCSpawn(new PedFeat("", false, 180, 7, iNoSeats, Vehic, 2, false, 0, ""), Vehic.Position, Vehic.Heading);
                    iNoSeats --;
                    Script.Wait(1);
                }
            }       // Helli Att
            else if (iMod == 18)
            {
                GhostVehicle(Vehic, Vehic.Position, Vehic.Heading);
            }       // Ghost car
            else if (iMod == 19)
            {
                Function.Call(Hash.FREEZE_ENTITY_POSITION, Vehic, true);
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);

                Prop Bench1 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench1.AttachTo(Vehic, 0, new Vector3(1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));

                Prop Bench2 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench2.AttachTo(Vehic, 0, new Vector3(-1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench3 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench3.AttachTo(Vehic, 0, new Vector3(-1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench4 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench4.AttachTo(Vehic, 0, new Vector3(1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));
            }       // Para Plane
            else if (iMod == 20)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(45), false, 220, 1, 1, Vehic, 0, true, 3, DataStore.MyLang.Maptext[109]), Vehic.Position, 0.00f);
            }       // Raceing cycle
            else if (iMod == 21)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(46), false, 220, 1, 1, Vehic, 0, true, 3, DataStore.MyLang.Maptext[109]), Vehic.Position, 0.00f);
                Function.Call(Hash.FREEZE_ENTITY_POSITION, Vehic, false);
                Vehic.IsDriveable = false;
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
            }       // Raceing Boat
            else if (iMod == 22)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(47), false, 220, 1, 1, Vehic, 0, true, 3, DataStore.MyLang.Maptext[109]), Vehic.Position, 0.00f);
            }       // Raceing Heli
            else if (iMod == 23)
            {
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);
                Ped Pilot = NPCSpawn(new PedFeat(ReturnStuff.RandNPC(43), false, 220, 1, 1, Vehic, 0, true, 3, DataStore.MyLang.Maptext[109]), Vehic.Position, 0.00f);
                Vector3 VTarg = Vehic.Position + (Vehic.ForwardVector * 500);
                Vehic.Position = Vehic.Position - (Vehic.ForwardVector * 350);
                Vehic.IsDriveable = true;
                Vehic.EngineRunning = true;
                EntityBuild.FlyPlane(Pilot, Vehic, VTarg, null);
                Function.Call(Hash.FREEZE_ENTITY_POSITION, Vehic, false);
                Vehic.Speed = 35f;
            }       // Raceing plane
            else if (iMod == 24)
            {
                NSPM.Fubar_FollowCar(Vehic);
            }       // FubarFollower
            else if (iMod == 25)
            {
                NPCSpawn(new PedFeat(ReturnStuff.RandNPC(1), true, 150, 14, 1, Vehic, 0), new Vector4(Vehic.Position.X, Vehic.Position.Y, Vehic.Position.Z, Vehic.Heading));
                MissionData.MishVeh = Vehic;
            }       // ImportExportCar
            else if (iMod == 26)
            {
                if (RandomX.RandInt(1, 10) > 5)
                    Vehic.OpenDoor(VehicleDoor.Hood, false, true);
            }       // Debt Rand open Hood
            else if (iMod == 27)
            {
                VehBlip(new BlipForm(39, ""), Vehic);
                Vehic.CurrentBlip.Alpha = 120;
            }       // Gray Blip
        }
        public static void GhostVehicle(Vehicle Vhick, Vector3 Vpos, float fHeads)
        {
            GhostVehicle(Vhick, new Vector4(Vpos.X, Vpos.Y, Vpos.Z, fHeads));
        }
        public static void GhostVehicle(Vehicle Vhick, Vector4 Vpos)
        {
            LoggerLight.LogThis("GhostVehicle");

            int iFailed = 50;
            while (!Vhick.IsOnAllWheels && iFailed > 0)
            {
                ResetVehPos(Vhick, Vpos);
                Script.Wait(100);
                iFailed -= 1;
            }

            if (iFailed > 0)
            {
                Function.Call(Hash.FREEZE_ENTITY_POSITION, Vhick, true);
                Vhick.HasCollision = false;
                Vhick.Alpha = 120;
                Vhick.Heading = Vpos.R;
                Vhick.LockStatus = VehicleLockStatus.Locked;
            }
            else
            {
                LoggerLight.LogThis("GhostVehicle Failled...");
                NSPM.JobSeq = 45;
            }
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

            int iProps = Function.Call<int>(Hash.CREATE_OBJECT, iPropHash, Position.X, Position.Y, Position.Z, false, true, true);
            BuildPop = new Prop(iProps);

            if (BuildPop.Exists())
            {
                EntityLog.BackUpAss("Prop-" + BuildPop.Handle);
                BuildPop.Rotation = Rotation;
                BuildPop.IsPersistent = true;
                BuildPop.HasCollision = true;
                Function.Call(Hash.FREEZE_ENTITY_POSITION, BuildPop, bFreeze);

                if (bSetLOD)
                    Function.Call(Hash.SET_ENTITY_LOD_DIST, BuildPop.Handle, 1500);

                MissionData.PropList_01.Add(new Prop(BuildPop.Handle));
            }
            else
                BuildPop = null;

            Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);

            return BuildPop;
        }
        public static Prop BuildProp(string sProper, Vector4 Position, bool bFreeze, bool bSetLOD)
        {
            return BuildProp(sProper, new Vector3(Position.X, Position.Y, Position.Z), new Vector3(0f, 0f, Position.R), bFreeze, bSetLOD);
        }
        public static Prop BuildProp(PropLists Pops, bool bFreeze, bool bSetLOD)
        {
            return BuildProp(Pops.Prop, new Vector3(Pops.Pos.X, Pops.Pos.Y, Pops.Pos.Z), new Vector3(Pops.Rot.X, Pops.Rot.Y, Pops.Rot.Z), bFreeze, bSetLOD);
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
                string sFighter = ReturnStuff.AddRandomVeh(23);

                if (sFighter == "MOLOTOK" || sFighter == "PYRO" || sFighter == "STARLING")
                {
                    List<int> Rockets = new List<int>{ -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, 1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10 };
                    VehicleSpawn(new VehMods(sFighter, 4, 1, false, DataStore.MyLang.Maptext[20], false, Rockets, new List<int>(), "Planes"), PlayerPozy, fRotate);
                }
                else if (sFighter == "ROGUE")
                {
                    List<int> Rockets = new List<int> { -10, -10, -10, -10, -10, 1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10 };
                    VehicleSpawn(new VehMods(sFighter, 4, 1, false, DataStore.MyLang.Maptext[20], false, Rockets, new List<int>(), "Planes"), PlayerPozy, fRotate);
                }
                else
                    VehicleSpawn(new VehMods(sFighter, 4, 1, false, DataStore.MyLang.Maptext[20]), PlayerPozy, fRotate);
            }
        }
        public static void AddTarget(BlipForm thisTarget)
        {
            LoggerLight.LogThis("AddTarget");

            MissionData.Target_01 = AddBlips(thisTarget);
        }
        public static Blip AddBlips(BlipForm thisBlip)
        {
            Blip blipps = null;

            if (thisBlip.Radius > 1f)
            {
                blipps = Function.Call<Blip>(Hash.ADD_BLIP_FOR_RADIUS, thisBlip.V3local.X, thisBlip.V3local.Y, thisBlip.V3local.Z, thisBlip.Radius);
                Function.Call(Hash.SET_BLIP_ALPHA, blipps.Handle, 120);
            }
            else
            {
                blipps = Function.Call<Blip>(Hash.ADD_BLIP_FOR_COORD, thisBlip.V3local.X, thisBlip.V3local.Y, thisBlip.V3local.Z);
            }

            if (thisBlip.Radius < 1f)
                Function.Call(Hash.SET_BLIP_SCALE, blipps.Handle, thisBlip.Radius);

            if (thisBlip.Icon != -1)
                TaggetIcon(blipps, thisBlip.Icon);

            if (thisBlip.Colour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, blipps.Handle, thisBlip.Colour);

            if (thisBlip.Flasher)
                Function.Call(Hash.SET_BLIP_FLASHES, blipps.Handle, thisBlip.Flasher);

            if (thisBlip.Route && DataStore.MySettings.ShowRoute)
                Function.Call(Hash.SET_BLIP_ROUTE, blipps.Handle, thisBlip.Route);

            if (thisBlip.NameTag == "")
                Function.Call(Hash.SET_BLIP_DISPLAY, blipps.Handle, 8);
            else
                BlipNames(blipps, thisBlip.NameTag);

            if (thisBlip.MyCorrona != null)
            {
                if (thisBlip.MyCorrona.RegCone)
                    MyCorona(thisBlip.MyCorrona, true);
                else
                    CheckerPoint(thisBlip.MyCorrona, true);
            }

            if (thisBlip.AddDot != null)
                AddBlips(thisBlip.AddDot);

            MissionData.BlipList_01.Add(new Blip(blipps.Handle));
            EntityLog.BackUpAss(thisBlip.Blip_Tag + blipps.Handle);
            return blipps;
        }
        public static Blip PedBlimp(BlipForm thisBlip, Ped peddy)
        {
            LoggerLight.LogThis("PedBlimp");
            Blip Blipy = null;

            if (peddy.CurrentBlip.Exists())
                Blipy = peddy.CurrentBlip;
            else
                Blipy = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, peddy.Handle);

            Function.Call(Hash.SET_BLIP_SCALE, Blipy.Handle, 0.75f);

            if (thisBlip.Colour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, Blipy.Handle, thisBlip.Colour);

            if (thisBlip.Flasher)
                Function.Call(Hash.SET_BLIP_FLASHES, Blipy.Handle, thisBlip.Flasher);

            if (thisBlip.Route && DataStore.MySettings.ShowRoute)
                Blipy.ShowRoute = true;

            if (thisBlip.NameTag != "")
                BlipNames(Blipy, thisBlip.NameTag);

            return Blipy;
        }
        public static Blip VehBlip(BlipForm thisBlip, Vehicle vhick)
        {
            LoggerLight.LogThis("VehBlip");
            Blip MyBlip = null;

            if (Function.Call<bool>(Hash.DOES_BLIP_EXIST, vhick.CurrentBlip))
                MyBlip = vhick.CurrentBlip;
            else
                MyBlip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_ENTITY, vhick.Handle);

            Function.Call(Hash.SET_BLIP_SPRITE, MyBlip.Handle, ReturnStuff.OhMyBlip(vhick));

            if (thisBlip.Colour != -1)
                Function.Call(Hash.SET_BLIP_COLOUR, MyBlip.Handle, thisBlip.Colour);

            if (thisBlip.Flasher)
                Function.Call(Hash.SET_BLIP_FLASHES, MyBlip.Handle, thisBlip.Flasher);

            if (thisBlip.Route && DataStore.MySettings.ShowRoute)
                Function.Call(Hash.SET_BLIP_ROUTE, MyBlip.Handle, thisBlip.Route);

            if (thisBlip.NameTag != "")
                BlipNames(MyBlip, thisBlip.NameTag);

            return MyBlip;
        }
        public static void TaggetIcon(Blip bLip, int iCon)
        {
            Function.Call(Hash.SET_BLIP_SPRITE, bLip.Handle, iCon);
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
        public static void StopHere(Vehicle Vic)
        {
            LoggerLight.LogThis("StopHere");

            while (Vic.IsInAir)
                Script.Wait(10);
            Function.Call(Hash.FREEZE_ENTITY_POSITION, Vic, true);
            Script.Wait(1000);
            Function.Call(Hash.FREEZE_ENTITY_POSITION, Vic, false);
        }
        public static int MyCorona(CorronaForm cform, bool AddToList)
        {
            LoggerLight.LogThis("MyCorona");

            int ThisCheck = CheckerPoint(cform, AddToList);
            Function.Call(Hash.SET_CHECKPOINT_CYLINDER_HEIGHT, ThisCheck, cform.Radius / 2, cform.Radius / 2, cform.Radius);
            return ThisCheck;
        }
        public static int CheckerPoint(CorronaForm cform, bool AddToList)
        {
            int iCheck = Function.Call<int>(Hash.CREATE_CHECKPOINT, cform.CorType, cform.V3Pos.X, cform.V3Pos.Y, cform.V3Pos.Z, cform.V3Rot.X, cform.V3Rot.Y, cform.V3Rot.Z, cform.Radius, cform.CorCol.R, cform.CorCol.G, cform.CorCol.B, cform.CorCol.A, 0);
            Function.Call(Hash._SET_CHECKPOINT_ICON_RGBA, iCheck, cform.CorMidCol.R, cform.CorMidCol.G, cform.CorMidCol.B, cform.CorMidCol.A);
            MissionData.iCoronaList.Add(iCheck);
            EntityLog.BackUpAss("Cora-" + iCheck);
            return iCheck;
        }
        public static int PlaySoundFrom(string sAudioBank, string sSound, string sSoundSet, Vector3 Vposy, bool bPhone)
        {
            LoggerLight.LogThis("PlaySoundFrom, bPhone == " + bPhone);

            int iSoundId = Function.Call<int>(Hash.GET_SOUND_ID);
            Function.Call(Hash.RELEASE_SOUND_ID, iSoundId);

            while (!Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, sAudioBank, false))
                Script.Wait(1);
            if (bPhone)
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, iSoundId, sSound, Vposy.X, Vposy.Y, Vposy.Z, 0, 0, 50, 0);
            else
                Function.Call(Hash.PLAY_SOUND_FROM_COORD, iSoundId, sSound, Vposy.X, Vposy.Y, Vposy.Z, sSoundSet, 0, 0, 0);
            //Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, sAudioBank);
            return iSoundId;
        }
        public static void PlaySoundDirect(string sAudioBank, string sSound, string sSoundSet)
        {
            DataStore.iSoundId = Function.Call<int>(Hash.GET_SOUND_ID);
            Function.Call(Hash.RELEASE_SOUND_ID, DataStore.iSoundId);
            while (!Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, sAudioBank, false))
                Script.Wait(1);
            Function.Call(Hash.PLAY_SOUND_FRONTEND, DataStore.iSoundId, sSound, sSoundSet, 0);

            //Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, sAudioBank);
        }
        public static void SetWeather(string weather)
        {
            LoggerLight.LogThis("SetWeather typpe == " + weather);

            Function.Call(Hash.SET_WEATHER_TYPE_NOW_PERSIST, weather);
        }
        public static void ClearWeather()
        {
            Function.Call(Hash.CLEAR_WEATHER_TYPE_PERSIST);
        }
    }
}
