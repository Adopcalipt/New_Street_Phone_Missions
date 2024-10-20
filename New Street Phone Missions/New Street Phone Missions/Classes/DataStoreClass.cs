using GTA.Math;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class XmlSetings
    {
        public bool Truckin { get; set; }
        public bool Getaway { get; set; }
        public bool Packages { get; set; }
        public bool Convicts { get; set; }
        public bool FUber { get; set; }
        public bool Pilot { get; set; }
        public bool Amulance { get; set; }
        public bool Follow { get; set; }
        public bool LSFD { get; set; }
        public bool Johnny { get; set; }
        public bool Raceist { get; set; }
        public bool BBBomb { get; set; }
        public bool Assassination { get; set; }
        public bool Sniper { get; set; }
        public bool Gruppe6 { get; set; }
        public bool Sailor { get; set; }
        public bool ImportantEx { get; set; }
        public bool DebtCollect { get; set; }
        public bool MCBusiness { get; set; }
        public bool BayLift { get; set; }
        public bool Sharks { get; set; }
        public bool HappyShopper { get; set; }
        public bool MoresMute { get; set; }
        public bool TempJob { get; set; }
        public bool ParaDisplay { get; set; }
        public bool Deliverwho { get; set; }
        public bool Thief { get; set; }

        public bool Debug { get; set; }
        public bool Auto_Outfit { get; set; }
        public bool ShowRoute { get; set; }
        public bool Subtitles { get; set; }
        public bool PhoneCone { get; set; }
        public bool PhoneAnim { set; get; }
        public bool PhoneAudio { get; set; }
        public bool AchiveMents { get; set; }
        public bool StartOnYAcht { set; get; }
        public bool EnemyStrength { get; set; }
        public bool PreLoadOnline { set; get; }
        public bool FastTraveltoStart { get; set; }

        public int YachtPrice { get; set; }
        public int LangSupport { set; get; }

        public int LowerAim { get; set; }
        public int UpperAim { get; set; }

        public int ModVersion { get; set; }
        public int SPDelayTime { get; set; }
        public int YachtRadio { get; set; }

        public List<Vector3> PhoneBlock { get; set; }

        public XmlSetings()
        {
            Truckin = true;
            Getaway = true;
            Packages = true;
            Convicts = true;
            FUber = true;
            Pilot = true;
            Amulance = true;
            Follow = true;
            LSFD = true;
            Johnny = true;
            Raceist = true;
            BBBomb = true;
            Assassination = true;
            Sniper = true;
            Gruppe6 = true;
            Sailor = true;
            ImportantEx = true;
            DebtCollect = true;
            MCBusiness = true;
            BayLift = true;
            Sharks = true;
            HappyShopper = true;
            MoresMute = true;
            TempJob = true;
            ParaDisplay = true;
            Deliverwho = true;
            Thief = true;

            Debug = false;
            Auto_Outfit = true;
            ShowRoute = true;
            Subtitles = true;
            PhoneCone = true;
            PhoneAnim = true;
            PhoneAudio = true;
            AchiveMents = true;
            StartOnYAcht = false;
            EnemyStrength = true;
            PreLoadOnline = true;
            FastTraveltoStart = false;

            YachtPrice = 6000000;
            LangSupport = 0;

            LowerAim = 45;
            UpperAim = 75;

            ModVersion = 401;
            SPDelayTime = 2000;

            YachtRadio = 30;

            PhoneBlock = new List<Vector3>();
        }
    }
    public class XmlCustomVeh
    {
        public List<ImportExVeh> CustomCars { get; set; }

        public XmlCustomVeh()
        {
            CustomCars = new List<ImportExVeh>();
        }
    }
    public class ImportExVeh
    {
        public int VehList { get; set; }
        public string VehicleS { get; set; }

        public ImportExVeh()
        {
            VehList = 0;
            VehicleS = "";
        }
        public ImportExVeh(int vehList, string vehicleS)
        {
            VehList = vehList;
            VehicleS = vehicleS;
        }
    }
    public class XmlContacts
    {
        public List<ImportExVeh> ImpXCars { get; set; }
        public List<Mk2Weap> MyMk2Weaps { get; set; }

        public XmlContacts()
        {
            MyMk2Weaps = new List<Mk2Weap>();
            ImpXCars = new List<ImportExVeh>();
        }
    }
    public class RandX
    {
        public int Low;
        public int High;
        public List<int> RandNumbers { get; set; }
        int GetHighLow(List<int> NewList, bool High)
        {
            int iAM = 0;
            if (NewList.Count > 0)
            {
                if (High)
                    iAM = NewList[NewList.Count -1];
                else
                    iAM = NewList[0];
            }
            return iAM;
        }
        List<int> BuildList(int low, int high)
        {
            List<int> output = new List<int>();

            for (int i = low; i < high + 1; i++)
                output.Add(i);

            return output;
        }
        public RandX(int low, int high)
        {
            RandNumbers = BuildList(low, high);
            Low = low;
            High = high;
        }
        public RandX(List<int> NewList)
        {
            RandNumbers = NewList;
            Low = GetHighLow(NewList, false);
            High = GetHighLow(NewList, true);
        }
        public RandX()
        {
            RandNumbers = new List<int>();
            Low = 0;
            High = 0;
        }
    }
    public class Lingoo
    {
        public List<string> Maptext { get; set; }
        public List<string> Mistext { get; set; }
        public List<string> Context { get; set; }
        public List<string> Jobtext { get; set; }
        public List<string> Othertext { get; set; }
        public List<string> ContactLang { get; set; }
        public List<string> YachtLang { get; set; }

        public Lingoo()
        {
            Maptext = new List<string>();
            Mistext = new List<string>();
            Context = new List<string>();
            Jobtext = new List<string>();
            Othertext = new List<string>();
            ContactLang = new List<string>();
            YachtLang = new List<string>();
        }
        public Lingoo(List<string> maptext, List<string> mistext, List<string> context, List<string> jobtext, List<string> othertext, List<string> contactLang, List<string> yachtLang)
        {
            Maptext = maptext;
            Mistext = mistext;
            Context = context;
            Jobtext = jobtext;
            Othertext = othertext;
            ContactLang = contactLang;
            YachtLang = yachtLang;
        }
    }
    public class BlipStore
    {
        public List<int> MyBlips { get; set; }
        public List<int> MyCorrona { get; set; }
        public List<int> MyPeds { get; set; }
        public List<int> MyProps { get; set; }
        public List<int> MyVehcs { get; set; }
        public int MySound { get; set; }
        
        public BlipStore()
        {
            MyBlips = new List<int>();
            MyCorrona = new List<int>();
            MyPeds = new List<int>();
            MyProps = new List<int>();
            MyVehcs = new List<int>();
            MySound = -1;
        }
    }
    public class DatFile
    {
        public int iOwnaYacht { get; set; }             //0
        public int iGotPegsus { get; set; }             //1
        public int iPegsSafeHeliTest { get; set; }      //2
        public int iPegsWarHeliTest { get; set; }       //3
        public int iPegsSafePlaneTest { get; set; }     //4
        public int iPegsWarPlaneTest { get; set; }      //5
        public int iPegsboatsTest { get; set; }         //6
        public int iPegsimortasTest { get; set; }       //7
        public int iMeddicTest { get; set; }            //8
        public int iNSPMBank { get; set; }              //9
        public int iNSPMCLowRisk { get; set; }          //10
        public int iNSPMCHighRisk { get; set; }         //11
        public int iWantedBribe { get; set; }           //12
        public int iFubard { get; set; }                //13
        public int iTrinket { get; set; }               //14

        public int DAssZone01 { get; set; }
        public int DAssZone02 { get; set; }
        public int DAssZone03 { get; set; }
        public int DAssZone04 { get; set; }
        public int DAssZone05 { get; set; }
        public int DAssZone06 { get; set; }
        public int DAssZone07 { get; set; }

        public DatFile()
        {
            iOwnaYacht = 0;
            iGotPegsus = 0;
            iPegsSafeHeliTest = 0;
            iPegsWarHeliTest = 0;
            iPegsSafePlaneTest = 0;
            iPegsWarPlaneTest = 0;
            iPegsboatsTest = 0;
            iPegsimortasTest = 0;
            iMeddicTest = 0;
            iNSPMBank = 1000;
            iNSPMCLowRisk = 100;
            iNSPMCHighRisk = 100;
            iWantedBribe = 0;
            iFubard = 0;
            iTrinket = 0;

            DAssZone01 = 1;
            DAssZone02 = 1;
            DAssZone03 = 1;
            DAssZone04 = 1;
            DAssZone05 = 1;
            DAssZone06 = 1;
            DAssZone07 = 1;
        }
    }
    public class Mk2Weap
    {
        public int MyPlayer { get; set; }
        public int MyAmmos { get; set; }
        public string Mk2WeapS { get; set; }
        public List<string> Mk2Addon { get; set; }

        public Mk2Weap()
        {
            MyPlayer = 0;
            MyAmmos = 0;
            Mk2WeapS = "";
            Mk2Addon = new List<string>();
        }
    }
    public class PlayerAssets
    {
        public bool OwnaYacht { get; set; }             //0
        public bool GotPegsus { get; set; }             //1
        public bool PegsSafeHeliTest { get; set; }      //2
        public bool PegsWarHeliTest { get; set; }       //3
        public bool PegsSafePlaneTest { get; set; }     //4
        public bool PegsWarPlaneTest { get; set; }      //5
        public bool PegsboatsTest { get; set; }         //6
        public bool PegsimortasTest { get; set; }       //7
        public bool MeddicTest { get; set; }            //8
        public bool WantedBribe { get; set; }           //12
        public bool Fubard { get; set; }                //13

        public PlayerAssets()
        {
            OwnaYacht = false;
            GotPegsus = false;
            PegsSafeHeliTest = false;
            PegsWarHeliTest = false;
            PegsSafePlaneTest = false;
            PegsWarPlaneTest = false;
            PegsboatsTest = false;
            PegsimortasTest = false;
            MeddicTest = false;
            WantedBribe = false;
            Fubard = false;
        }
    }
    public class PlayerWeaps
    {
        public string MyWeap { get; set; }
        public List<string> MyAttachList { get; set; }
        public int MyAmmo { get; set; }

        public PlayerWeaps()
        {
            MyAttachList = new List<string>();
        }
    }
}
