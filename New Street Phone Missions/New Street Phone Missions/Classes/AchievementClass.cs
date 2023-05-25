using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class AchItem
    {
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string Value { get; set; }
        public int TickBox { get; set; }

        public AchItem(string name, string desciption,string value, int tickBox)
        {
            Name = name;
            Descrition = desciption;
            Value = value;
            TickBox = tickBox;
        }
    }
    public class AchList
    {
        public string Mission { get; set; }
        public int Medal { get; set; }
        public int Percent { get; set; }
        public int Cash { get; set; }
        public bool Goranga { get; set; }
        public List<AchItem> MyAch { get; set; }

        public AchList(int iMission)
        {
            Mission = DataStore.MyLang.Jobtext[iMission];
            MyAch = new List<AchItem>();
            Medal = 0;
            Percent = 0;
            Goranga = false;
        }
    }
    public class AchieveAbleGoals
    {
        public int Trucking_MilesDriven { get; set; }       //Total miles driven.
        public int Trucking_KeptYourLoad { get; set; }      //NoDetaches
        public int Trucking_FarmYardHand { get; set; }      //TracktorMish
        public int Trucking_PerfectParking { get; set; }    //GetMax Parkin bounus
        public int Getaway_PickyDriver { get; set; }        //Change vehicles mid drive
        public int Getaway_PennyLess { get; set; }          //LostAll the money
        public int Getaway_FlighttoSaftey { get; set; }     //the seceret mission
        public int Getaway_GoneInSixtySeconds { get; set; } //llose the coops in 600sec maby make easyer?
        public int Packages_PavelsPlacements { get; set; }  //Area7
        public int Packages_PaperBoy { get; set; }          //Area6
        public int Packages_ChickenRun { get; set; }        //Area5
        public int Packages_LostinTheBin { get; set; }      //Area4
        public int Packages_BigParma { get; set; }          //Area3
        public int Packages_WeAimNottoLoseit { get; set; }  //Area2
        public int Packages_CanYouSignHere { get; set; }    //Area1
        public int Convicts_Goranga { get; set; }           //Damage all prisoners
        public int Convicts_DigThatChantingThing { get; set; }//listen to 3 mins of chanting
        public int Convicts_DontStopForCoffiee { get; set; }//press horn in less than a second
        public int Fubar_FollowThatCar { get; set; }        //maby add a follow option and multi drop also.
        public int Fubar_BigYellowTaxi { get; set; }        //Taxi Attackes
        public int Fubar_AirportRun { get; set; }           //Goto or from the airport
        public int Fubar_TapTheMats { get; set; }           //Veh Damage
        public int Planes01_AllTheAngles { get; set; }      //Gett High score.
        public int Planes02_ItsThePlayerBase { get; set; }  //GetAttackedByPlayer
        public int Planes03_KeptItTogether { get; set; }    //bert damage
        public int Planes04_AllYouNeedIsHommingMissiles { get; set; }//Unlock hidden getawau mish
        public int Planes05_HeyFarmerFarmer { get; set; }   //spair chems
        public int Planes06_LikeAndSubscribe { get; set; }  //veh damage low
        public int Ambulance_WinSomeLoseSome { get; set; }  //Fail due to neglegence
        public int Ambulance_OpenTheWindows { get; set; }   //have a diarea patent sit next to you
        public int Ambulance_LsInLockdown { get; set; }     //CovedOutBreak
        public int Ambulance_HomeVisits { get; set; }       //Going to houses or traillrers-or thats a nice pad when visited playerhouses?or for arcade/nightcllub
        public int Ambulance_ReadTheBook { get; set; }      //Correct diagnosis
        public int Follow_WisperingGrass { get; set; }      //copchaseEnd
        public int Follow_AndKaboom { get; set; }           //blow veh ending
        public int Follow_InABlaseOfGlory { get; set; }     //AmbushEnd
        public int Follow_OnePreviousOwner { get; set; }    //takecarend
        public int Follow_KightInShiningAuto { get; set; }  //ProtectEnd
        public int Follow_OutOfThisWorld { get; set; }      //UfoEnd
        public int Fire_FirePlace { get; set; }             //HouseFires
        public int Fire_BurningRubber { get; set; }         //car fire
        public int Fire_SaveThePussy { get; set; }          //save cat
        public int Fire_TheFireStarter { get; set; }        //Madman
        public int Fire_BinAndGone { get; set; }            //wastebins
        public int Johnny_ItWasLikeThatWhenIGotIt { get; set; }//VehDamage
        public int Johnny_ITawITawThePlayerCreapinUp { get; set; }//SurviveplayerAttack
        public int Johnny_ThisOnesAkeeper { get; set; }     //KeepplayersCar
        public int Johnny_AFewErrendsToRunirst { get; set; }//take more than 5mins to deliver the car
        public int Racist_RidingThroughTheSnow { get; set; }//Have a snow race
        public int Racist_WaterSports { get; set; }         //do a boat race in the rain
        public int Racist_FullContact { get; set; }         //Road race contact on with traffic
        public int Racist_ComeFlyWithMe { get; set; }       //Win A flight race.
        public int Racist_CyclePath { get; set; }           //knock a cyclest off there cycle
        public int Bbomb_SoThereItIs { get; set; }          //find the bbomb in under 10sec
        public int Bbomb_OnlyTheDoors { get; set; }         //find the bbomb with with 1 sec to spair
        public int Hitman_SurgicalPresion { get; set; }     //Only kill the target
        public int Hitman_BringEveryBody { get; set; }      //kill everyone
        public int Hitman_HoldMyBeer { get; set; }          //Complete in under a minite
        public int Hitman_Hunter { get; set; }              //use only mellee weapons
        public int Sniper_LieFlat { get; set; }             //use prone postion to get the shot
        public int Sniper_DrivinMissDasy { get; set; }      //shoot the target n a car.
        public int Sniper_FireAtWill { get; set; }          //shoot the wrong guy
        public int MoneyMAn_DoubbleCross { get; set; }      //Get van back from partner.
        public int MoneyMAn_AngreyMob { get; set; }         //Excape the angery mob
        public int MoneyMAn_Tanks { get; set; }             //Excape the tank.
        public int MoneyMAn_ThatsMine { get; set; }         //Recover the security van before it blows up.
        public int MoneyMAn_WhileImHere { get; set; }       //Buy SomeThing from the shop.
        public int Water01_AndThePointWas { get; set; }     //Dunk know
        public int Water02_PricyPiracy { get; set; }        //Alter the buy price of the yacht.
        public int Water03_PhishinTrip { get; set; }        //Knock a fisherman into the drink.
        public int Water04_SingleUsePlastics { get; set; }  //dunkknow
        public int Water05_DryDocking { get; set; }         //Use the cargobob to deliver boat
        public int Water06_SubCub { get; set; }             //Complete in under 15mins
        public int ImportExport_GotToGetThemAll { get; set; }//Collect All the Cars
        public int ImportExport_IJustWantYourCar { get; set; }//dont kill any one
        public int ImportExport_GetAGoodPrice { get; set; } //no damage
        public int ImportExport_AboveAndBeond { get; set; } //use cargobob
        public int DebtCollect_IjustWantTheCase { get; set; }//no deaths
        public int DebtCollect_TheEnforcer { get; set; }    //all melle kills
        public int BikerRaids_TheWheelsOnTheBus { get; set; }//Deliver the bus to the clubhouse
        public int BikerRaids_ButItsNotABike { get; set; }  //Deliver the slamvan to the clubhouse
        public int BikerRaids_DukeItOut { get; set; }       //Kill 20+ Bikers
        public int CargoCollect_BigAndSmalll { get; set; }  //Collect from all sizes of warehouse and bunker.
        public int CargoCollect_NoYouCantHaveItBack { get; set; }//Dispatch you persuers
        public int CargoCollect_CollectAlTheGoods { get; set; }//Get 1+ each pallet.
        public int DeepDown_SharkCards { get; set; }        //Clear them in under 5mins
        public int DeepDown_DasBoot { get; set; }           //Blow your self up.
        public int HappyShopper_SuperMarketSweep { get; set; }//Do in under 5mins.
        public int HappyShopper_IJustWantedSprunk { get; set; }//Buy a can of sprunk
        public int HappyShopper_IsABadHabit { get; set; }   //SmashCiggeretsand alchole
        public int MoresMuted_PerfectParking { get; set; }   //max parking set
        public int MoresMuted_NotAScratch { get; set; }     //no damage
        public int Temp01_OwnGoal { get; set; }             //score an own goal
        public int Temp02_Upsetter { get; set; }            //dont serve a customer
        public int Temp03_NotADupe { get; set; }            //max car sales
        public int Temp04_MilesOnTheClock { get; set; }     //drive customes car around for a bit.
        public int Temp05_GettingAir { get; set; }          //get over $5000 in air time
        public int Temp06_StopTheClock { get; set; }        //Eliminater players in under 30sec
        public int ParaDisplay_HeyBuddy { get; set; }       //Land parashoot next a player
        public int ParaDisplay_BuryTheHatchet { get; set; } //Use the hachet
        public int ParaDisplay_AnyOneForGolf { get; set; }  //Use the golf club
        public int ParaDisplay_HomeRun { get; set; }        //Use the baseball bat
        public int ParaDisplay_KnifySpoony { get; set; }    //Use the flick knife
        public int DeliverWho_The24HourSession { get; set; }//deliver for 24 in game hours
        public int DeliverWho_OnYourBike { get; set; }      //deliver on a bike
        public int DeliverWho_RideShare { get; set; }       //deliver in a fubar taxi
        public int CayoThief_ImAPasafisit { get; set; }      //dont shoot the gun
        public int CayoThief_YourGonaHaveToWalk { get; set; }//shoot the getaway vehicle

        public int CargoTrackingWhSm { get; set; }
        public int CargoTrackingWhMd { get; set; }
        public int CargoTrackingWhLg { get; set; }
        public int CargoTrackingWhBu { get; set; }

        public int CargoTrackingPl01 { get; set; }
        public int CargoTrackingPl02 { get; set; }
        public int CargoTrackingPl03 { get; set; }
        public int CargoTrackingPl04 { get; set; }
        public int CargoTrackingPl05 { get; set; }
        public int CargoTrackingPl06 { get; set; }

        public AchieveAbleGoals()
        {
            Trucking_MilesDriven = 0;       //Total miles driven.
            Trucking_KeptYourLoad = 0;      //NoDetaches
            Trucking_FarmYardHand = 0;      //TracktorMish
            Trucking_PerfectParking = 0;    //GetMax Parkin bounus
            Getaway_PickyDriver = 0;        //Change vehcles mid way
            Getaway_PennyLess = 0;          //LostAll the money
            Getaway_FlighttoSaftey = 0;     //the seceret mission
            Getaway_GoneInSixtySeconds = 0; //done in under 5mins?
            Packages_PavelsPlacements = 0;
            Packages_PaperBoy = 0;          //Area6
            Packages_ChickenRun = 0;        //Area5
            Packages_LostinTheBin = 0;      //Area4
            Packages_BigParma = 0;          //Area3
            Packages_WeAimNottoLoseit = 0;  //Area2
            Packages_CanYouSignHere = 0;    //Area1
            Convicts_Goranga = 0;           //Damage all prisoners
            Convicts_DigThatChantingThing = 0;//listen to 3 mins of chanting
            Convicts_DontStopForCoffiee = 0;//press horn in less than a second
            Fubar_FollowThatCar = 0;        //maby add a follow option and multi drop also.
            Fubar_BigYellowTaxi = 0;        //Taxi Attackes
            Fubar_AirportRun = 0;           //Goto or from the airport
            Fubar_TapTheMats = 0;           //Veh Damage
            Planes01_AllTheAngles = 0;      //Gett High score.
            Planes02_ItsThePlayerBase = 0;  //GetAttackedByPlayer
            Planes03_KeptItTogether = 0;    //bert damage
            Planes04_AllYouNeedIsHommingMissiles = 0;//Unlock hidden getawau mish
            Planes05_HeyFarmerFarmer = 0;   //spair chems
            Planes06_LikeAndSubscribe = 0;  //veh damage low
            Ambulance_WinSomeLoseSome = 0;  //Fail due to neglegence
            Ambulance_OpenTheWindows = 0;   //have a diarea patent sit next to you
            Ambulance_LsInLockdown = 0;     //CovedOutBreak
            Ambulance_HomeVisits = 0;       //Going to houses or traillrers-or thats a nice pad when visited playerhouses?or for arcade/nightcllub
            Ambulance_ReadTheBook = 0;      //Correct diagnosis
            Follow_OutOfThisWorld = 0;      //UfoEnd
            Follow_InABlaseOfGlory = 0;     //AmbushEnd
            Follow_OnePreviousOwner = 0;    //takecarend
            Follow_WisperingGrass = 0;      //copchaseEnd
            Follow_KightInShiningAuto = 0;  //ProtectEnd
            Fire_FirePlace = 0;             //HouseFires
            Fire_BurningRubber = 0;         //car fire
            Fire_SaveThePussy = 0;          //save cat
            Fire_TheFireStarter = 0;        //Madman
            Fire_BinAndGone = 0;            //wastebins
            Johnny_ItWasLikeThatWhenIGotIt = 0;//VehDamage
            Johnny_ITawITawThePlayerCreapinUp = 0;//SurviveplayerAttack
            Johnny_ThisOnesAkeeper = 0;     //KeepplayersCar
            Johnny_AFewErrendsToRunirst = 0;//take more than 5mins to deliver the car
            Racist_RidingThroughTheSnow = 0;//Have a snow race
            Racist_WaterSports = 0;         //do a boat race in the rain
            Racist_FullContact = 0;         //Road race contact on with traffic
            Racist_ComeFlyWithMe = 0;       //Win A flight race.
            Racist_CyclePath = 0;           //knock a cyclest off there cycle
            Bbomb_SoThereItIs = 0;          //find the bbomb in under 10sec
            Bbomb_OnlyTheDoors = 0;         //find the bbomb with with 1 sec to spair
            Hitman_SurgicalPresion = 0;     //Only kill the target
            Hitman_BringEveryBody = 0;      //kill everyone
            Hitman_HoldMyBeer = 0;          //Complete in under a minite
            Hitman_Hunter = 0;              //use only mellee weapons
            Sniper_LieFlat = 0;             //use prone postion to get the shot
            Sniper_DrivinMissDasy = 0;      //shoot the target n a car.
            Sniper_FireAtWill = 0;          //shoot the wrong guy
            MoneyMAn_DoubbleCross = 0;      //Get van back from partner.
            MoneyMAn_AngreyMob = 0;         //Excape the angery mob
            MoneyMAn_Tanks = 0;             //Excape the tank.
            MoneyMAn_ThatsMine = 0;         //Recover the security van before it blows up.
            MoneyMAn_WhileImHere = 0;       //Buy SomeThing from the shop.
            Water01_AndThePointWas = 0;     //Dunk know
            Water02_PricyPiracy = 0;        //Alter the buy price of the yacht.
            Water03_PhishinTrip = 0;        //Knock a fisherman into the drink.
            Water04_SingleUsePlastics = 0;  //dunkknow
            Water05_DryDocking = 0;         //Use the cargobob to deliver boat
            Water06_SubCub = 0;             //Kill all the sailors
            ImportExport_GotToGetThemAll = 0;//Collect All the Cars
            ImportExport_IJustWantYourCar = 0;//dont kill any one
            ImportExport_GetAGoodPrice = 0; //no damage
            ImportExport_AboveAndBeond = 0; //cargobob
            DebtCollect_IjustWantTheCase = 0;//no deaths
            DebtCollect_TheEnforcer = 0;    //all melle kills
            BikerRaids_TheWheelsOnTheBus = 0;//Deliver the bus to the clubhouse
            BikerRaids_ButItsNotABike = 0;  //Deliver the slamvan to the clubhouse
            BikerRaids_DukeItOut = 0;       //Kill 20+ Bikers
            CargoCollect_BigAndSmalll = 0;  //Collect from all sizes of warehouse and bunker.
            CargoCollect_NoYouCantHaveItBack = 0;//Dispatch you persuers
            CargoCollect_CollectAlTheGoods = 0;//Get 1+ each pallet.
            DeepDown_SharkCards = 0;        //Clear them in under 5mins
            DeepDown_DasBoot = 0;           //Blow your self up.
            HappyShopper_SuperMarketSweep = 0;//Do in under 5mins.
            HappyShopper_IJustWantedSprunk = 0;//Buy a can of sprunk
            HappyShopper_IsABadHabit = 0;   //SmashCiggeretsand alchole
            MoresMuted_PerfectParking = 0;   //max parking set
            MoresMuted_NotAScratch = 0;     //no damage
            Temp01_OwnGoal = 0;             //score an own goal
            Temp02_Upsetter = 0;            //dont serve a customer
            Temp03_NotADupe = 0;            //max car sales
            Temp04_MilesOnTheClock = 0;     //drive customes car around for a bit.
            Temp05_GettingAir = 0;          //get over $5000 in air time
            Temp06_StopTheClock = 0;        //Eliminater players in under 30sec
            ParaDisplay_HeyBuddy = 0;       //Land parashoot next a player
            ParaDisplay_BuryTheHatchet = 0; //Use the hachet
            ParaDisplay_AnyOneForGolf = 0;  //Use the golf club
            ParaDisplay_HomeRun = 0;        //Use the baseball bat
            ParaDisplay_KnifySpoony = 0;    //Use the flick knife
            DeliverWho_The24HourSession = 0;//deliver for 24 in game hours
            DeliverWho_OnYourBike = 0;      //deliver on a bike
            DeliverWho_RideShare = 0;       //deliver in a fubar taxi
            CayoThief_ImAPasafisit = 0;
            CayoThief_YourGonaHaveToWalk = 0;

            CargoTrackingWhSm = 0;
            CargoTrackingWhMd = 0;
            CargoTrackingWhLg = 0;
            CargoTrackingWhBu = 0;

            CargoTrackingPl01 = 0;
            CargoTrackingPl02 = 0;
            CargoTrackingPl03 = 0;
            CargoTrackingPl04 = 0;
            CargoTrackingPl05 = 0;
            CargoTrackingPl06 = 0;
        }
    }
}
