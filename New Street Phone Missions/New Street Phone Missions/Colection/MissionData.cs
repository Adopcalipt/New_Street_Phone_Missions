using GTA;
using GTA.Math;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class MissionData 
    {
        public static bool bFloater { get; set; }
        public static bool bPlayerAtt { get; set; }
        public static bool bTestRun { get; set; }
        public static bool bJobLoaded { get; set; }
        public static bool bOnTheJob { get; set; }
        public static bool bMoreFubar { get; set; }
        public static bool bAmberAntz { get; set; }
        public static bool bCovidInf { get; set; }
        public static bool bCutingCul { get; set; }
        public static bool bYachtLoaded { get; set; }
        public static bool bDeliverWowRep { get; set; }
        public static bool bIsVehPers { get; set; }
        public static bool bOldYacht { get; set; }
        public static bool bPedCanFly { get; set; }
        public static bool bReFire { get; set; }
        public static bool bSoloRace { get; set; }
        public static bool bPacBouns { get; set; }
        public static bool bPickUpHangUp { get; set; }
        public static bool bDontPull { get; set; }
        public static bool bSnipers { get; set; }
        public static bool bGOURANGA { get; set; }

        public static byte iLocationX { get; set; }

        public static int iMissionVar_01 { get; set; }
        public static int iMissionVar_02 { get; set; }
        public static int iMissionVar_03 { get; set; }
        public static int iMissionVar_04 { get; set; }
        public static int iMissionSeq { get; set; }
        public static int iCashBouns { get; set; }
        public static int iFindingTime { get; set; }
        public static int iTracking { get; set; }
        public static int iUltPed01 { get; set; }
        public static int iJobType { get; set; }
        public static int iTestKit { get; set; }
        public static int iCashReward { get; set; }
        public static int iCrash4Cash { get; set; }
        public static int iCurrentLap { get; set; }
        public static int iMobStarz { get; set; }
        public static int iWait4Sec { get; set; }
        public static int iAngerTax { get; set; }
        public static int iRacingStyle { get; set; }
        public static int iAmbushCount { get; set; }
        public static int iCanDrive { get; set; }
        public static int iFuClock { get; set; }
        public static int iGotYourVan { get; set; }
        public static int iMishText { get; set; }
        public static int iBuildMode { get; set; }
        public static int iKeepDance { get; set; }
        public static int iParcelCost { get; set; }
        public static int iTotalLap { get; set; }
        public static int iMishAltT { get; set; }
        public static int iRepMisssion { get; set; }

        public static float fphdirect { get; set; }
        public static float fGetDir { get; set; }
        public static float fMaxSpeed { get; set; }
        public static float fCorSize { get; set; }
        public static float fCoronaHight { get; set; }
        public static float fCoronaDirHt { get; set; }
        public static float fVehicleDamage { get; set; }
        public static float fCheckDist { get; set; }
        public static float fMission_01 { get; set; }
        public static float fMission_02 { get; set; }
        public static float fMission_03 { get; set; }

        public static string sCargFix { get; set; }
        public static string sHospFix { get; set; }
        public static string sFireFix { get; set; }
        public static string sVehType { get; set; }
        public static string sMissionVar_01 { get; set; }
        public static string sMissionVar_02 { get; set; }

        public static Ped Npc_01 { get; set; }
        public static Ped Npc_02 { get; set; }
        public static Ped Npc_03 { get; set; }

        public static Prop Prop_01 { get; set; }
        public static Prop Prop_02 { get; set; }
        public static Prop Prop_03 { get; set; }

        public static Vehicle VehTrackin_01 { get; set; }
        public static Vehicle VehTrackin_02 { get; set; }
        public static Vehicle VehTrackin_03 { get; set; }
        public static Vehicle VehTrackin_04 { get; set; }
        public static Vehicle VehTrackin_05 { get; set; }

        public static Pickup Pick_01 { get; set; }

        public static Blip BackUpT { get; set; }
        public static Blip Target_01 { get; set; }
        public static Blip Target_02 { get; set; }

        public static Camera cCams { get; set; }

        public static Vector3 vLanLoc { get; set; }
        public static Vector3 vFuMiss { get; set; }
        public static Vector3 vGetaway { get; set; }
        public static Vector3 vTarget_01 { get; set; }
        public static Vector3 vTarget_02 { get; set; }
        public static Vector3 vTarget_03 { get; set; }
        public static Vector3 vTarget_04 { get; set; }
        public static Vector3 vTarget_05 { get; set; }
        public static Vector3 vTarget_06 { get; set; }
        public static Vector3 vTarget_07 { get; set; }
        public static Vector3 vTarget_08 { get; set; }
        public static Vector3 vTarget_09 { get; set; }
        public static Vector3 vTarget_10 { get; set; }

        public static Vector4 v4Targ_01 { get; set; }
        public static Vector4 v4Targ_02 { get; set; }

        public static Crash4Cash Crash4s { get; set; }

        public static List<bool> BeOff { get; set; }
        public static List<bool> BeOnOff { get; set; }

        public static List<int> iMissionList { get; set; }
        public static List<int> iCoronaList { get; set; }
        public static List<int> iDeliverList { get; set; }
        public static List<int> iFireList { get; set; }
        public static List<int> iTime_01 { get; set; }
        public static List<int> iImpExpList { get; set; }

        public static List<int> iList_01 { get; set; }
        public static List<int> iList_02 { get; set; }

        public static List<float> fList_01 { get; set; }
        public static List<float> fList_02 { get; set; }
        public static List<float> fList_03 { get; set; }

        public static List<string> sList_01 { get; set; }
        public static List<string> sList_02 { get; set; }
        public static List<string> sCayoPacks { get; set; }
        public static List<string> sImpExpVeh { get; set; }

        public static List<Vector3> VectorList_01 { get; set; }
        public static List<Vector3> VectorList_02 { get; set; }
        public static List<Vector3> VectorList_03 { get; set; }
        public static List<Vector3> VectorList_04 { get; set; }
        public static List<Vector3> VectorList_05 { get; set; }

        public static List<Blip> BlipList_01 { get; set; }
        public static List<Ped> PedList_01 { get; set; }
        public static List<Prop> PropList_01 { get; set; }
        public static List<Pickup> PickList_01 { get; set; }
        public static List<Vehicle> VehicleList_01 { get; set; }

        public static List<Vehicle> MishVic { get; set; }
        public static List<Ped> MishPed { get; set; }

        public static List<PedMultiTask> MultiPed { get; set; }

        public static MissionBuilder MyMissions { get; set; }

        public static PropLists PopLists { get; set; }

        public static void MissionDataLoad()
        {
            bFloater = false;
            bPlayerAtt = false;
            bTestRun = false;
            bJobLoaded = false;
            bOnTheJob = false;
            bMoreFubar = false;
            bAmberAntz = false;
            bCovidInf = false;
            bCutingCul = false;
            bYachtLoaded = false;
            bDeliverWowRep = false;
            bIsVehPers = false;
            bOldYacht = false;
            bPedCanFly = false;
            bReFire = false;
            bSoloRace = false;
            bPacBouns = false;
            bPickUpHangUp = false;
            bDontPull = false;
            bSnipers = false;
            bGOURANGA = false;

            iLocationX = 0;
            iMissionVar_01 = 0;
            iMissionVar_02 = 0;
            iMissionVar_03 = 0;
            iMissionVar_04 = 0;
            iMissionSeq = 0;
            iFindingTime = 0;
            iTracking = 0;
            iCashBouns = 0;
            iUltPed01 = 0;
            iJobType = 0; 
            iTestKit = 0;
            iCashReward = 0;
            iCrash4Cash = 0;
            iCurrentLap = 1;
            iMobStarz = 0;
            iWait4Sec = 0;
            iAngerTax = 0;
            iRacingStyle = 0;
            iAmbushCount = 0;
            iCanDrive = 0;
            iFuClock = 0;
            iGotYourVan = 0;
            iMishText = -1;
            iBuildMode = 0;
            iKeepDance = 0;
            iParcelCost = 0;
            iTotalLap = 0; 
            iMishAltT = -1;
            iRepMisssion = 0;

            fphdirect = 0.00f;
            fGetDir = 0.00f;
            fMaxSpeed = 35.00f;
            fCorSize = 5.00f;
            fCoronaHight = 0.00f;
            fCoronaDirHt = 0.00f;
            fVehicleDamage = 0.00f;
            fCheckDist = 10.00f;
            fMission_01 = 0.00f;
            fMission_02 = 0.00f;
            fMission_03 = 0.00f;

            sCargFix = "";
            sHospFix = "";
            sFireFix = "";
            sVehType = "Adder";
            sMissionVar_01 = "empty";
            sMissionVar_02 = "empty";

            Npc_01 = null;
            Npc_02 = null;
            Npc_03 = null;

            Prop_01 = null;
            Prop_02 = null;
            Prop_03 = null;

            Pick_01 = null;

            VehTrackin_01 = null;
            VehTrackin_02 = null;
            VehTrackin_03 = null;
            VehTrackin_04 = null;
            VehTrackin_05 = null;

            BackUpT = null;
            Target_01 = null;
            Target_02 = null;
            cCams = null;

            PopLists = new PropLists();

            vLanLoc = Vector3.Zero;
            vFuMiss = Vector3.Zero;
            vGetaway = Vector3.Zero;
            vTarget_01 = Vector3.Zero;
            vTarget_02 = Vector3.Zero;
            vTarget_03 = Vector3.Zero;
            vTarget_04 = Vector3.Zero;
            vTarget_05 = Vector3.Zero;
            vTarget_06 = Vector3.Zero;
            vTarget_07 = Vector3.Zero;
            vTarget_08 = Vector3.Zero;
            vTarget_09 = Vector3.Zero;
            vTarget_10 = Vector3.Zero;

            v4Targ_01 = new Vector4();
            v4Targ_02 = new Vector4();
            Crash4s = null;

            BeOff = new List<bool>();
            BeOnOff = new List<bool>();
            iMissionList = new List<int>();
            iCoronaList = new List<int>();
            iDeliverList = new List<int>();
            iFireList = new List<int>();
            iList_01 = new List<int>();
            iList_02 = new List<int>();
            iTime_01 = new List<int>();
            iImpExpList = new List<int>();
            fList_01 = new List<float>();
            fList_02 = new List<float>();
            fList_03 = new List<float>();
            sCayoPacks = new List<string>();
            sList_01 = new List<string>();
            sList_02 = new List<string>();
            sImpExpVeh = new List<string>();
            VectorList_01 = new List<Vector3>();
            VectorList_02 = new List<Vector3>();
            VectorList_03 = new List<Vector3>();
            VectorList_04 = new List<Vector3>();
            VectorList_05 = new List<Vector3>();
            BlipList_01 = new List<Blip>();
            PedList_01 = new List<Ped>();
            MishPed = new List<Ped>();
            PropList_01 = new List<Prop>();
            PickList_01 = new List<Pickup>();
            VehicleList_01 = new List<Vehicle>();
            MishVic = new List<Vehicle>();
            MultiPed = new List<PedMultiTask>();
            MyMissions = new MissionBuilder();

            for (int i = 0; i < 20; i++)
                BeOff.Add(true);           
        }
    }
}
