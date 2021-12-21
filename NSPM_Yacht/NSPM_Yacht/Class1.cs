using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;
using NativeUI;
using GTA;
using GTA.Native;
using GTA.Math;

namespace NSPM_Yacht
{
    public class Main : Script
    {
        private bool bYachtStart = true;
        private bool bLogFiles = true;
        private bool bASleap = false;
        private bool bDrinks = false;
        private bool bDrinkig = false;
        private bool bPianoSt = false;
        private bool bShowerON = false;
        private bool bSwimSuit = false;
        private bool bWetness = false;
        private bool bMenuOpen = false;
        private bool bScubaGOn = false;
        private bool bYachIsOn = false;
        private bool bLoadUpOnYacht = false;
        private bool bBacktoBase = false;
        private bool bYachtLoaded = false;
        private bool bYachtOwner = false;
        private bool bYachtParty = false;
        private bool bDrunkMove = false;

        private int iMyBed = 0;
        private int iAmHash = 0;
        private int iDoors = 0;
        private int iKeepDance = 0;
        private int iJacuzSit = 0;
        private int iWait4Sec = 0;
        private int iYachtFast = 0;
        private int iYachtDrink = 0;
        private int iSlowDown = 0;

        private int iLangSupport = 0;

        private readonly int iProcessForYacht = System.Environment.ProcessorCount * 15;

        private string sCurrentCharXML = "";
        private readonly string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/ShipsLog.txt";
        private readonly string sBoatLaunch = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/BooatLaunch.txt";
        private readonly string sNSPMDatafile = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/NSPMData.NSPM";
        private readonly string sNSPMLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language";

        private Vector3 vYachtBedPos = Vector3.Zero;
        private Vector3 vYachtBedRot = Vector3.Zero;
        private Vector3 vYachtBlip = new Vector3(-2062.635f, -1025.35f, 14.90f);

        private Ped Npc_01 = null;
        private Ped Npc_02 = null;
        private Vehicle SHowBoat = null;
        private Blip YachtBlip = null;
        private Camera cCams = null;

        private Lingoo MyLang = new Lingoo();

        private List<int> iList_01 = new List<int>();

        private List<bool> bOnList = new List<bool>();

        private List<float> fList_01 = new List<float>();
        private List<float> fYachtDoorList = new List<float>();

        private List<string> sWardrobe = new List<string>();
        private List<string> sDestList = new List<string>();
        private List<string> sYachtLang = new List<string>();


        private List<Ped> YachtPeds = new List<Ped>();
        private List<Ped> DancingPed = new List<Ped>();

        private List<Prop> YachtSit = new List<Prop>();
        private List<Prop> YachtSleap = new List<Prop>();
        private List<Prop> YachtSlCam = new List<Prop>();
        private List<Prop> PropList_01 = new List<Prop>();

        private List<Vector3> vYachtTrigList = new List<Vector3>();
        private List<Vector3> vYachtDoorList = new List<Vector3>();
        private List<Vector3> vRandomDestList = new List<Vector3>();
        private List<Vector3> VectorList_01 = new List<Vector3>();

        private List<Vehicle> VehicleList_01 = new List<Vehicle>();

        private MenuPool YtmenuPool;

        private System.Media.SoundPlayer DipDar = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/dipdar.wav");

        public Main()
        {
            Tick += onTick;
            Interval = 1;
        }
        public int ReadNSMPDat()
        {
            int iYacht = 0;
            if (File.Exists(sNSPMDatafile))
                iYacht = OpenNSPMFile();

            return iYacht;
        }
        public int OpenNSPMFile()
        {
            List<int> iData = new List<int>();
            int iYacht = 0;
            unsafe
            {
                using (FileStream fs = File.Open(sNSPMDatafile, FileMode.Open))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                        iData.Add(r.ReadInt32());
                    }
                }
            }
            iYacht = iData[0];
            int iYstart = iData[iData.Count - 1];
            iLangSupport = iData[iData.Count - 2];

            if (iYstart > 0)
                bLoadUpOnYacht = true;

            return iYacht;
        }
        private void AddLang()
        {
            sYachtLang.Clear();
            sYachtLang.Add("Invalid Model. Only available for Franklin, Michael, Trevor, FreemodeMale01 and FreemodeFemale01.");    //0
            sYachtLang.Add("Outfit");                                                                                               //1
            sYachtLang.Add("Save Current Outfit");                                                                                  //2
            sYachtLang.Add("Add Current Outfit");                                                                                   //3
            sYachtLang.Add("No Outfits to transfer");                                                                               //4
            sYachtLang.Add("Press ~INPUT_DETONATE~ to exit.");                                                                      //5
            sYachtLang.Add("Press ~INPUT_DETONATE~ to remove scuba gear.");                                                         //6
            sYachtLang.Add("Press ~INPUT_DETONATE~ for scuba gear.");                                                               //7
            sYachtLang.Add("Press ~INPUT_DETONATE~ to sleep.");                                                                     //8
            sYachtLang.Add("Press ~INPUT_DETONATE~ to stand up.");                                                                  //9
            sYachtLang.Add("Press ~INPUT_DETONATE~ to stand here.");                                                                //10
            sYachtLang.Add("Press ~INPUT_DETONATE~ to Sit.");                                                                       //11
            sYachtLang.Add("Press ~INPUT_DETONATE~ for wardrobe.");                                                                 //12
            sYachtLang.Add("Press ~INPUT_DETONATE~ to play the piano.");                                                            //13
            sYachtLang.Add("Press ~INPUT_DETONATE~ to drink.");                                                                     //14
            sYachtLang.Add("Fast Travel?, ~INPUT_DETONATE~, ~INPUT_CONTEXT~ to change, ~INPUT_SPRINT~ to continue.");               //15
            sYachtLang.Add("Current destination is ");                                                                              //16
            sYachtLang.Add("");                             //17
            sYachtLang.Add("");                             //18
            sYachtLang.Add("");                             //19
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
        }
        public Lingoo LoadlangSetting(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Lingoo));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (Lingoo)xml.Deserialize(sr);
            }
        }
        private void LangReader()
        {
            bool bNoLAng = true;

            if (Directory.Exists(sNSPMLanguage))
            {
                if (iLangSupport == 1)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/English.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/English.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 2)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Chinese.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Chinese.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 3)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/ChineseS.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/ChineseS.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 4)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/French.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/French.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 5)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/German.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/German.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 6)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Italian.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Italian.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 7)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Japanese.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Japanese.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 8)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Korean.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Korean.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 9)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Mexican.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Mexican.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 10)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Polish.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Polish.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 11)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Portuguese.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Portuguese.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 12)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Russian.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Russian.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 13)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Spanish.Xml"))
                    {
                        MyLang = LoadlangSetting("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Language/Spanish.Xml");
                        sYachtLang = MyLang.YachtLang;
                        bNoLAng = false;
                    }
                }
            }

            if (bNoLAng)
                AddLang();
        }
        private void LogThis(string sLog)
        {
            if (bLogFiles)
            {
                using (StreamWriter tEx = File.AppendText(sBeeLogs))
                    BeeLog(sLog, tEx);
            }
        }
        private void BeeLog(string sLogs, TextWriter tEx)
        {
            tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLogs}");
        }
        private void CleanUp()
        {
            for (int i = 0; i < YachtPeds.Count; i++)
                YachtPeds[i].MarkAsNoLongerNeeded();

            for (int i = 0; i < VehicleList_01.Count; i++)
                VehicleList_01[i].MarkAsNoLongerNeeded();

            for (int i = 0; i < PropList_01.Count; i++)
                PropList_01[i].MarkAsNoLongerNeeded();

            YachtPeds.Clear();
            DancingPed.Clear();
            VehicleList_01.Clear();
            PropList_01.Clear();
            SHowBoat = null;
        }
        private void AddHeistYacht()
        {
            LogThis("AddHeistYacht");

            if (!bYachtLoaded)
            {
                List<string> sAddIpl = new List<string>();

                sAddIpl.Add("hei_yacht_heist_Lounge");
                sAddIpl.Add("hei_yacht_heist_LODLights");
                sAddIpl.Add("hei_yacht_heist_enginrm");
                sAddIpl.Add("hei_yacht_heist_DistantLights");
                sAddIpl.Add("hei_yacht_heist_Bridge");
                sAddIpl.Add("hei_yacht_heist_Bedrm");
                sAddIpl.Add("hei_yacht_heist_Bar");
                sAddIpl.Add("hei_yacht_heist");

                for (int i = 0; i < sAddIpl.Count; i++)
                {
                    if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                        Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
                }
                bYachtLoaded = true;
            }
        }
        public int RandInt(int minNumber, int maxNumber)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, minNumber, maxNumber);
        }
        public bool bOnOff(int iBon)
        {
            bool bMe = false;
            if (iBon > bOnList.Count - 1)
            {
                for (int i = 0; i < iBon + 1; i++)
                    bOnList.Add(false);
            }
            bMe = bOnList[iBon];
            bOnList[iBon] = !bOnList[iBon];

            return bMe;
        }
        private void StickySubTitle(string sTing)
        {
            Function.Call(Hash.SET_TEXT_FONT, 0);
            Function.Call(Hash.SET_TEXT_SCALE, 0.55f, 0.55f);
            Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);//white
            Function.Call(Hash.SET_TEXT_CENTRE, true); //
            Function.Call(Hash.SET_TEXT_DROPSHADOW, 4, 0, 0, 0, 0);//Dunknow--changed last 255 to 0
            Function.Call(Hash._SET_TEXT_ENTRY, "TWOSTRINGS");//
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sTing);
            Function.Call(Hash._DRAW_TEXT, 0.5f, 0.9f);

            //SET_TEXT_FONT
            //FontChaletLondon = 0,
            //FontHouseScript = 1,
            //FontMonospace = 2,
            //FontWingDings = 3,
            //FontChaletComprimeCologne = 4,
            //FontPricedown = 7
        }
        private void ControlerUI(string sText, int iDuration)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sText);
            Function.Call(Hash._0x238FFE5C7B0498A6, false, false, false, iDuration);
        }
        private void ForceAnim(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LogThis("ForceAnim, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 1, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        private void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LogThis("ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        private void ForceAnimOnceEnding(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot, float fEnder)
        {
            LogThis("ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, fEnder, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        private void PedScenario(Ped Peddy, string sCenario, Vector3 Vpos, float fHead, bool bSeated)
        {
            LogThis("PedScenario, sCenario == " + sCenario);

            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, Peddy.Handle, sCenario, Vpos.X, Vpos.Y, Vpos.Z, fHead, 0, bSeated, true);
        }
        private void PedSitHere(Ped Peddy, Prop Chair, int iChair)
        {
            LogThis("PedSitHere, iChair == " + iChair);

            Vector3 vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.55f);

            Peddy.Position = vCharPos;
            Peddy.Heading = Chair.Heading - 180.00f;

            if (iChair == 1)
            {
                List<string> SitVArs = new List<string>();

                SitVArs.Add("PROP_HUMAN_SEAT_CHAIR");
                SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_UPRIGHT");

                PedScenario(Peddy, SitVArs[RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 2)
            {
                vCharPos += (Chair.ForwardVector * 0.30f);
                vCharPos.Z -= 0.10f;
                PedScenario(Peddy, "PROP_HUMAN_SEAT_SUNLOUNGER", vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 3)
                PedScenario(Peddy, "PROP_HUMAN_SEAT_ARMCHAIR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 4)
                PedScenario(Peddy, "PROP_HUMAN_SEAT_BAR", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 5)
                PedScenario(Peddy, "PROP_HUMAN_SEAT_COMPUTER", vCharPos, Chair.Heading - 180.00f, true);
            else if (iChair == 6)
            {
                List<string> SitVArs = new List<string>();

                SitVArs.Add("PROP_HUMAN_SEAT_DECKCHAIR");
                SitVArs.Add("PROP_HUMAN_SEAT_DECKCHAIR_DRINK");

                PedScenario(Peddy, SitVArs[RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 7)
            {
                List<string> SitVArs = new List<string>();

                SitVArs.Add("PROP_HUMAN_SEAT_BENCH");
                SitVArs.Add("PROP_HUMAN_SEAT_BENCH_DRINK");
                SitVArs.Add("PROP_HUMAN_SEAT_BENCH_DRINK_BEER");
                SitVArs.Add("PROP_HUMAN_SEAT_BENCH_FOOD");

                PedScenario(Peddy, SitVArs[RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 8)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.70f);

                List<string> SitVArs = new List<string>();

                SitVArs.Add("PROP_HUMAN_SEAT_CHAIR");
                SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_UPRIGHT");

                PedScenario(Peddy, SitVArs[RandInt(0, SitVArs.Count - 1)], vCharPos, Chair.Heading - 180.00f, true);
            }
            else if (iChair == 9)
            {
                vCharPos = new Vector3(Chair.Position.X, Chair.Position.Y, Chair.Position.Z + 0.50f);

                PedScenario(Peddy, "PROP_HUMAN_SEAT_CHAIR_UPRIGHT", vCharPos, Chair.Heading - 180.00f, true);
            }

            Peddy.AlwaysKeepTask = false;
        }
        public List<string> DanceList(bool bMale, int iSpeed)
        {

            LogThis("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);

            List<string> sDancing = new List<string>();
            List<string> Dance = new List<string>(); List<string> DanceVar = new List<string>();

            if (bMale)
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^5");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^6");
                }

                if (Dance.Count > 0)
                {
                    int iRand = RandInt(0, Dance.Count - 1);
                    sDancing.Add(Dance[iRand]);
                    sDancing.Add(DanceVar[iRand]);
                }
                else
                {
                    sDancing.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity");
                    sDancing.Add("li_dance_facedj_17_v2_male^6");
                }
            }
            else
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^6");
                }

                if (Dance.Count > 0)
                {
                    int iRand = RandInt(0, Dance.Count - 1);
                    sDancing.Add(Dance[iRand]);
                    sDancing.Add(DanceVar[iRand]);
                }
                else
                {
                    sDancing.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity");
                    sDancing.Add("li_dance_facedj_17_v2_female^6");
                }
            }

            return sDancing;
        }
        private void SlowFastTravel(Vector3 VDest, float fHedd)
        {
            LogThis("SlowFastTravel");

            if (fHedd == 0.00f)
                fHedd = (int)RandInt(0, 360);
            Game.FadeScreenOut(1000);
            Script.Wait(1000);
            Game.Player.Character.Position = VDest;
            Game.Player.Character.Heading = fHedd;
            Script.Wait(2000);
            Game.FadeScreenIn(1000);
        }
        private void DrunkMoves()
        {
            LogThis("DrunkMoves");

            bDrunkMove = false;
            int iTenPass = 10;
            while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk") || iTenPass > 0)
            {
                iTenPass -= 1;
                Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@moderatedrunk");
                Script.Wait(100);
            }
            if (Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk"))
            {
                bDrunkMove = true;
                Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character.Handle, "move_m@drunk@moderatedrunk", 1.00f);
            }

            //Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, ped.Handle, "MOVE_M@DRUNK@VERYDRUNK", 0x3E800000);
        }
        private void TimeCycFade()
        {
            LogThis("TimeCycFade");

            bDrinkig = false;
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.80f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.70f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.60f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.50f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.40f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.30f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.20f);
            Script.Wait(1000);
            Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, 0.10f);
            Script.Wait(1000);
            Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
            if (bDrunkMove)
            {
                bDrunkMove = false;
                Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.00f);
            }

        }
        private void CleanCams()
        {
            LogThis("CleanCams");

            if (cCams != null)
            {
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 0, 1, 0, 0, 0);
                cCams.Destroy();
                Function.Call(Hash.DISPLAY_RADAR, true);
                cCams = null;
            }
        }
        public class ClothBank
        {
            public int Char { get; set; }

            public List<int> ClothA { get; set; }
            public List<int> ClothB { get; set; }

            public List<int> ExtraA { get; set; }
            public List<int> ExtraB { get; set; }

            public ClothBank()
            {
                ClothA = new List<int>();
                ClothB = new List<int>();
                ExtraA = new List<int>();
                ExtraB = new List<int>();
            }
        }
        public void SaveOutfitMain(ClothBank config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public ClothBank LoadOutfit(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (ClothBank)xml.Deserialize(sr);
            }
        }
        private void WriteMyWard(int iChar, bool bDefault, List<int> iWard01, List<int> iWard02, List<int> iWardEx01, List<int> iWardEx02)
        {
            LogThis("WriteMyWard, iChar == " + iChar);

            string sNamez = "";
            if (iChar == 1)
                sNamez = "Franklin";
            else if (iChar == 2)
                sNamez = "Michael";
            else if (iChar == 3)
                sNamez = "Trevor";
            else if (iChar == 4)
                sNamez = "FreeFemale";
            else if (iChar == 5)
                sNamez = "FreeMale";
            else
                sNamez = "null";
            if (bDefault)
                WriteWardXML("DefaultOut", iWard01, iWard02, iWardEx01, iWardEx02, iChar);
            else
            {
                string sFileName = Game.GetUserInput(255);

                if (sFileName != "")
                    WriteWardXML(sNamez + "_" + sFileName, iWard01, iWard02, iWardEx01, iWardEx02, iChar);
            }
        }
        private void WriteWardXML(string sWardx, List<int> iWardX01, List<int> iWardX02, List<int> iWardXEX01, List<int> iWardXEX02, int iChar)
        {
            LogThis("WriteWardXML, sWardx == " + sWardx + ", iChar == " + iChar);

            ClothBank Cbank = new ClothBank();

            Cbank.Char = iChar;

            Cbank.ClothA = iWardX01;
            Cbank.ClothB = iWardX02;

            Cbank.ExtraA = iWardXEX01;
            Cbank.ExtraB = iWardXEX02;

            SaveOutfitMain(Cbank, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/" + sWardx + ".Xml");
        }
        private void LauchWardrobe()
        {
            LogThis("LauchWardrobe");

            Ped Peddy = Game.Player.Character;
            if (Peddy.Model == PedHash.Franklin)
                sCurrentCharXML = "Franklin";
            else if (Peddy.Model == PedHash.Michael)
                sCurrentCharXML = "Michael";
            else if (Peddy.Model == PedHash.Trevor)
                sCurrentCharXML = "Trevor";
            else if (Peddy.Model == PedHash.FreemodeFemale01)
                sCurrentCharXML = "FreeFemale";
            else if (Peddy.Model == PedHash.FreemodeMale01)
                sCurrentCharXML = "FreeMale";
            else
                sCurrentCharXML = "null";
            if (sCurrentCharXML == "null")
            {
                UI.Notify(sYachtLang[0]);
                Peddy.FreezePosition = false;
                Function.Call(Hash.DISPLAY_RADAR, true);
                bMenuOpen = false;
            }
            else
            {
                sWardrobe.Clear();
                string[] sWrite = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/");
                for (int i = 0; i < sWrite.Count(); i++)
                {
                    string sting = sWrite[i];
                    if (sting.Contains(sCurrentCharXML))
                        sWardrobe.Add(sting);
                }
                WardrobeScan(11);
                WardMenuMain();
            }

        }
        private void WardOutPut(string sTing, Ped Peddy)
        {
            LogThis("WardOutPut, sTing == " + sTing);

            List<int> iWardrobe01 = new List<int>();
            List<int> iWardrobe02 = new List<int>();
            List<int> iWardrobe01Extra = new List<int>();
            List<int> iWardrobe02Extra = new List<int>();

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/" + sTing))
            {
                ClothBank Cloths = LoadOutfit("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/" + sTing);

                iWardrobe01 = Cloths.ClothA;
                iWardrobe02 = Cloths.ClothB;

                iWardrobe01Extra = Cloths.ExtraA;
                iWardrobe02Extra = Cloths.ExtraB;

                XmlPedDresser(Peddy, Cloths.Char, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
            }
        }
        private void WardMenuMain()
        {
            LogThis("WardMenuMain");

            YtmenuPool = new MenuPool();
            var mainMenu = new UIMenu("", "...");
            var banner = new Sprite("shopui_title_highendfashion", "shopui_title_highendfashion", new Point(0, 0), new Size(0, 0));
            mainMenu.SetBannerType(banner);
            YtmenuPool.Add(mainMenu);
            WardMenu(mainMenu); //Here we add the  Sub Menus
            MakeMenuForXMl(mainMenu);
            YtmenuPool.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void MakeMenuForXMl(UIMenu XMen)
        {
            List<dynamic> dCloths = new List<dynamic>();

            dCloths.Add("DefaultOut.XML");

            int iFindOut = sWardrobe.Count;
            while (iFindOut > 0)
            {
                iFindOut = iFindOut - 1;
                string sting = sWardrobe[iFindOut];
                int iNum = sting.LastIndexOf("/") + 1;
                dCloths.Add(sting.Substring(iNum));
            }
            //dCloths.Add(0xF00D);// Dynamic!

            var newitem = new UIMenuListItem(sYachtLang[1], dCloths, 0);
            XMen.AddItem(newitem);
            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    string sOuter = item.Items[index].ToString();
                    WardOutPut(sOuter, Game.Player.Character);
                }
            };
        }
        private void WardMenu(UIMenu XMen)
        {
            var playermodelmenu = YtmenuPool.AddSubMenu(XMen, sYachtLang[3]);
            for (int i = 0; i < 1; i++) ;
            var captureWardrobe = new UIMenuItem(sYachtLang[2], "");
            playermodelmenu.AddItem(captureWardrobe);
            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == captureWardrobe)
                    WardrobeScan(10);
            };
        }
        private void WardrobeScan(int iOutfit)
        {
            LogThis("WardrobeScan, iOutfit == " + iOutfit);

            List<int> iWardrobe01 = new List<int>();
            List<int> iWardrobe02 = new List<int>();
            List<int> iWardrobe01Extra = new List<int>();
            List<int> iWardrobe02Extra = new List<int>();

            iAmHash = Game.Player.Character.Model.Hash;

            int iPed = 0;
            if (Game.Player.Character.Model == PedHash.Franklin)
                iPed = 1;
            else if (Game.Player.Character.Model == PedHash.Michael)
                iPed = 2;
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iPed = 3;
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
                iPed = 4;
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
                iPed = 5;
            else
                iPed = 99;
            if (iPed == 99)
                UI.Notify(sYachtLang[0]);
            else
            {
                Ped Peddy = Game.Player.Character;

                int iCloth = 0;
                while (iCloth < 12)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Peddy, iCloth);
                    iWardrobe01.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Peddy, iCloth);
                    iWardrobe02.Add(iTextId);
                    iCloth = iCloth + 1;
                }
                int iExtra = 0;
                while (iExtra < 5)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Peddy, iExtra);
                    iWardrobe01Extra.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Peddy, iExtra);
                    iWardrobe02Extra.Add(iTextId);
                    iExtra = iExtra + 1;
                }

                if (iOutfit == 1)
                {
                    WriteMyWard(iPed, true, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
                    YachtStuff_YachtScuba(iPed);
                }
                else if (iOutfit == 2)
                {
                    WriteMyWard(iPed, true, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
                    YachtStuff_YachtSwim(iPed);
                }
                else if (iOutfit == 3)
                {
                    WriteMyWard(iPed, true, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
                    YachtStuff_YachtSwim(iPed);
                }
                else if (iOutfit == 10)
                    WriteMyWard(iPed, false, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
                else if (iOutfit == 11)
                    WriteMyWard(iPed, true, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);
            }
        }
        private void ReWrightWard()
        {
            LogThis("ReWrightWard");

            if (Directory.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Ward/"))
            {
                sWardrobe.Clear();
                string[] sWrite = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Ward/");

                if (sWrite.Count() > 0)
                {
                    for (int i = 0; i < sWrite.Count(); i++)
                    {
                        string sting = sWrite[i];

                        int iNum = sting.LastIndexOf("/") + 1;
                        sWardrobe.Add(sting.Substring(iNum));
                    }
                    for (int i = 0; i < sWardrobe.Count; i++)
                    {
                        if (sWardrobe[i].Contains("Franklin"))
                            ReReWrite(sWardrobe[i], 1);
                        else if (sWardrobe[i].Contains("Michael"))
                            ReReWrite(sWardrobe[i], 2);
                        else if (sWardrobe[i].Contains("Trevor"))
                            ReReWrite(sWardrobe[i], 3);
                        else if (sWardrobe[i].Contains("FreeFemale"))
                            ReReWrite(sWardrobe[i], 4);
                        else if (sWardrobe[i].Contains("FreeMale"))
                            ReReWrite(sWardrobe[i], 5);
                    }
                    for (int i = 0; i < sWardrobe.Count; i++)
                        File.Delete("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Ward/" + sWardrobe[i]);
                }
                else
                    UI.Notify(sYachtLang[4]);
            }
        }
        private void ReReWrite(string sDir, int iChar)
        {
            LogThis("ReReWrite");

            List<int> iWardrobe01 = new List<int>();
            List<int> iWardrobe02 = new List<int>();
            List<int> iWardrobe01Extra = new List<int>();
            List<int> iWardrobe02Extra = new List<int>();

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Ward/" + sDir))
            {
                ClothBank Cloths = LoadOutfit("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Ward/" + sDir);
                WriteWardXML(sDir, iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra, iChar);
            }
        }
        private void XmlPedDresser(Ped Peddy, int iPed, List<int> iWard01, List<int> iWard02, List<int> iWardEx01, List<int> iWardEx02)
        {
            LogThis("XmlPedDresser, iPed == " + iPed);

            if (iPed == 1 && Peddy.Model != PedHash.Franklin)
                UI.Notify(sYachtLang[0]);
            else if (iPed == 2 && Peddy.Model != PedHash.Michael)
                UI.Notify(sYachtLang[0]);
            else if (iPed == 3 && Peddy.Model != PedHash.Trevor)
                UI.Notify(sYachtLang[0]);
            else if (iPed == 4 && Peddy.Model != PedHash.FreemodeFemale01)
                UI.Notify(sYachtLang[0]);
            else if (iPed == 5 && Peddy.Model != PedHash.FreemodeMale01)
                UI.Notify(sYachtLang[0]);
            else
            {
                Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy);
                for (int i = 0; i < iWard01.Count; i++)
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, i, iWard01[i], iWard02[i], 2);

                for (int i = 0; i < iWardEx01.Count; i++)
                    Function.Call(Hash.SET_PED_PROP_INDEX, Peddy, i, iWardEx01[i], iWardEx02[i], false);
            }
        }
        private void ClearPedProps(int iPed, Ped Peddy)
        {
            Function.Call(Hash.CLEAR_PED_PROP, Peddy, 0);    //0 Helmets, hats, earphones, masks
            Function.Call(Hash.CLEAR_PED_PROP, Peddy, 1);    //1 Glasses
            Function.Call(Hash.CLEAR_PED_PROP, Peddy, 2);    //2 Ear accessories
            Function.Call(Hash.CLEAR_PED_PROP, Peddy, 3);    //3 Bangles
            Function.Call(Hash.CLEAR_PED_PROP, Peddy, 4);    //4 Watch
        }
        public Prop BuildProp(string sProper, Vector3 Position, Vector3 Rotation, bool bFreeze, bool bSetLOD)
        {
            LogThis("BuildProp, sProper == " + sProper + ", bFreeze == " + bFreeze);

            Prop BuildPop = null;

            int iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, sProper);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iPropHash))
            {
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

                    PropList_01.Add(new Prop(BuildPop.Handle));
                }
                else
                    BuildPop = null;

                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);
            }
            else
                BuildPop = null;

            return BuildPop;
        }
        public bool PropExists(Prop[] Proplist, int iPos)
        {
            bool bExist = false;

            if (iPos < Proplist.Count())
            {
                unsafe
                {
                    if (Proplist[iPos].Exists())
                        bExist = true;
                }
            }

            return bExist;
        }
        public string RandomNPC()
        {
            string sPed = "";

            List<string> sPeds = new List<string>();
            sPeds.Add("a_f_m_beach_01");    //"Beach Female" />
            sPeds.Add("A_F_Y_Beach_02");
            sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
            sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
            sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
            sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
            sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
            sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
            sPeds.Add("a_m_m_malibu_01");    //"Malibu Male" />
            sPeds.Add("a_m_y_sunbathe_01");    //"Sunbather Male" />
            sPeds.Add("a_m_y_hippy_01");    //"Hippie Male" />
            sPeds.Add("a_f_y_hippie_01");    //"Hippie Female" />
            sPeds.Add("a_m_y_beachvesp_01");    //"Vespucci Beach Male" />
            sPeds.Add("a_m_y_beachvesp_02");    //"Vespucci Beach Male 2" />
            sPeds.Add("u_m_y_party_01");    //"Partygoer" />

            sPed = sPeds[RandInt(0, sPeds.Count - 1)];

            return sPed;
        }
        public Ped NPCSpawn(string sPed, Vector3 vLocal, float fAce, int iTask)
        {
            LogThis("NPCSpawn, sPed == " + sPed + ", iTask == " + iTask);

            Ped BuildPed = null;

            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Wait(1);

                BuildPed = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fAce, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (BuildPed.Exists())
                {
                    BuildPed.Accuracy = 25;
                    BuildPed.MaxHealth = 250;
                    BuildPed.Health = 250;

                    YachtPeds.Add(new Ped(BuildPed.Handle));

                    if (iTask == 1)
                    {
                        BuildPed.CanBeTargette﻿d﻿ = false;
                        BuildPed.AlwaysKeepTask = true;
                        BuildPed.IsInvincible = true;
                        BuildPed.Task.PlayAnimation("anim@mini@yacht@bar@drink@idle_a", "idle_a", 1.00f, -1, true, 1.00f);
                        BuildPed.Task.AchieveHeading(-139.3908f);
                    }
                    else if (iTask == 2)
                    {
                        BuildPed.CanBeTargette﻿d﻿ = false;
                        BuildPed.AlwaysKeepTask = true;
                        BuildPed.IsInvincible = true;
                        ForceAnim(BuildPed, "anim@amb@yacht@captain@", "idle", new Vector3(-2085.821f, -1017.94f, 12.7819f), new Vector3(0.00f, 0.00f, 73.96f));
                    }
                    else if (iTask == 3)
                    {
                        PedScenario(BuildPed, "WORLD_HUMAN_PARTYING", BuildPed.Position, BuildPed.Heading, false);
                    }
                    else if (iTask == 4)
                    {
                        WarptoAnyVeh(SHowBoat, BuildPed, 1, false);
                        ShowBoating(BuildPed, VectorList_01[1], SHowBoat, 25.00f, 4194304);
                        YachtStuff_BoatToShore();
                    }
                }
                else
                    BuildPed = null;
            }
            else
                BuildPed = null;

            return BuildPed;
        }
        public Vehicle VehicleSpawn(string sVehModel, Vector3 VecLocal, float VecHead, bool bFreeze, int itask)
        {
            LogThis("VehicleSpawn, sVehModel == " + sVehModel + ", bFreeze == " + bFreeze);

            Vehicle BuildVehicle = null;

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehModel);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
            {
                Function.Call(Hash.REQUEST_MODEL, iVehHash);
                while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                    Wait(1);

                BuildVehicle = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, VecLocal.X, VecLocal.Y, VecLocal.Z, VecHead, true, true);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);
            }
            else
                BuildVehicle = null;

            if (BuildVehicle.Exists())
            {
                BuildVehicle.IsPersistent = true;
                BuildVehicle.FreezePosition = bFreeze;


                VehicleList_01.Add(new Vehicle(BuildVehicle.Handle));

                if (itask == 1)
                    Function.Call(Hash.SET_BOAT_ANCHOR, BuildVehicle, true);
                else if (itask == 2)
                {
                    SHowBoat = BuildVehicle;
                    BuildVehicle.PrimaryColor = VehicleColor.MatteBlack;
                    NPCSpawn("mp_m_boatstaff_01", BuildVehicle.Position, BuildVehicle.Heading, 4);
                }
            }
            else
                BuildVehicle = null;

            return BuildVehicle;
        }
        private void ShowBoating(Ped PedX, Vector3 vEctor, Vehicle Vhick, float fSpeeds, int iDrivinStyle)
        {
            LogThis("ShowBoating");

            PedX.Task.ClearAll();
            Function.Call(Hash.TASK_BOAT_MISSION, PedX, Vhick, 0, 0, vEctor.X, vEctor.Y, vEctor.Z, 4, fSpeeds, iDrivinStyle, -1.0f, 7);
            Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, PedX.Handle, true);
        }
        private void WarptoAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat, bool bFightPlayer)
        {
            LogThis("WarptoAnyVeh, iSeat == " + iSeat + ", bFightPlayer == " + bFightPlayer);

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
                    Peddy.Task.EnterVehicle();
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
        private void YachtStuff_StartOnYacht()
        {
            LogThis("YachtStuff_StartOnYacht");

            Ped Peddy = Game.Player.Character;

            int iStart = RandInt(1, 5);
            if (iStart == 1)
            {
                Peddy.Position = new Vector3(-2022.449f, -1031.614f, 2.561438f);
                Peddy.Task.PlayAnimation("anim@mp_yacht@shower@female@", "shower_idle_a", 1.00f, -1, AnimationFlags.CancelableWithMovement);
            }
            else if (iStart == 2)
            {
                Peddy.Position = new Vector3(-2026.442f, -1043.872f, 2.561439f);
                Peddy.Task.PlayAnimation("anim@mp_yacht@shower@female@", "shower_idle_a", 1.00f, -1, AnimationFlags.CancelableWithMovement);
            }
            else if (iStart == 3)
            {
                bASleap = true;
                iMyBed = 0;
                YachtStuff_BedTime(YachtSleap[iMyBed]);
            }
            else if (iStart == 4)
            {
                bASleap = true;
                iMyBed = 1;
                YachtStuff_BedTime(YachtSleap[iMyBed]);
            }
            else
            {
                bASleap = true;
                iMyBed = 2;
                YachtStuff_BedTime(YachtSleap[iMyBed]);
            }

            Game.FadeScreenIn(1000);
        }
        private void YachtStuff_TheBlip(bool bOn)
        {
            LogThis("YachtStuff_TheBlip, bOn == " + bOn);

            if (bOn)
            {
                if (YachtBlip == null)
                {
                    YachtBlip = World.CreateBlip(vYachtBlip);
                    YachtBlip.Sprite = BlipSprite.Yacht;
                    YachtBlip.IsShortRange = true;
                }
            }
            else
            {
                if (YachtBlip != null)
                {
                    YachtBlip.Remove();
                    YachtBlip = null;
                }
            }
        }
        private void YachtStuff_OntheYacht()
        {
            Ped Peddy = Game.Player.Character;
            Vector3 PlayPos = Peddy.Position;

            if (bASleap)
            {
                ControlerUI(sYachtLang[5], 1);
                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                {
                    ForceAnimOnce(Peddy, "savebighouse@", "f_getout_l_bighouse", Peddy.Position + (Peddy.RightVector * 0.60f), Peddy.Rotation);
                    Script.Wait(1000);
                    Peddy.Detach();
                    if (iMyBed == 0)
                    {
                        Peddy.Position = new Vector3(-2071.628f, -1020.615f, 5.880583f);
                        Peddy.Heading = 346.8368f;
                    }
                    else if (iMyBed == 1)
                    {
                        Peddy.Position = new Vector3(-2090.004f, -1013.44f, 5.874646f);
                        Peddy.Heading = 188.6417f;
                    }
                    else if (iMyBed == 2)
                    {
                        Peddy.Position = new Vector3(-2097.656f, -1013.154f, 5.882348f);
                        Peddy.Heading = 181.7787f;
                    }

                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(1);

                    CleanCams();
                    Peddy.FreezePosition = false;
                    Peddy.HasCollision = true;
                    bASleap = false;
                    iMyBed = 0;
                }
                else if (Peddy.Position.DistanceTo(YachtSleap[iMyBed].Position) > 2.00f)
                    YachtStuff_BedTime(YachtSleap[iMyBed]);
                else if (Peddy.Health < Peddy.MaxHealth && iWait4Sec < Game.GameTime)
                {
                    Peddy.Health = Peddy.Health + 1;
                    iWait4Sec = Game.GameTime + 500;
                }
                else
                {
                    if (iAmHash != 0)
                    {
                        if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Game.Player.Character, 134))
                            YachtStuff_BedTime(YachtSleap[iMyBed]);
                    }
                }
            }
            else if (bPianoSt)
            {
                ControlerUI(sYachtLang[5], 1);
                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                {
                    bPianoSt = false;
                    YachtStuff_Pianist(false);
                }
            }
            else
            {
                if (PlayPos.DistanceTo(vYachtTrigList[0]) < 2.50f || PlayPos.DistanceTo(vYachtTrigList[1]) < 2.50f)
                {
                    if (bScubaGOn)
                    {
                        ControlerUI(sYachtLang[6], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            WardOutPut("DefaultOut.XML", Peddy);
                            bScubaGOn = false;
                        }
                    }
                    else
                    {
                        ControlerUI(sYachtLang[7], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            WardrobeScan(1);
                            bScubaGOn = true;
                        }
                    }
                }           //DiveWardrobe01/DiveWardrobe02
                else if (PlayPos.DistanceTo(vYachtTrigList[2]) < 2.50f)
                {
                    if (PlayPos.DistanceTo(vYachtTrigList[2]) < 1.25f && !bSwimSuit)
                    {
                        WardrobeScan(3);
                        bSwimSuit = true;
                    }
                    else
                    {
                        if (Game.Player.Character.Model != iAmHash)
                            bSwimSuit = false;
                    }
                    if (!bShowerON)
                    {
                        Vector3 Shower01 = new Vector3(-2026.023f, -1044.079f, 3.3116f);
                        Vector3 ShowerRoto01 = new Vector3(125f, 0.00f, -106.4265f);
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_mp_house"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_mp_house");
                            int iSpray = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, "ent_amb_shower", Shower01.X, Shower01.Y, Shower01.Z, ShowerRoto01.X, ShowerRoto01.Y, ShowerRoto01.Z, 1.00f, true, true, true, false);
                            iList_01.Add(iSpray);
                            int iSpray2 = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, "ent_amb_shower_steam", Shower01.X, Shower01.Y, Shower01.Z - 1.00f, 0.00f, 0.00f, 0.00f, 1.00f, true, true, true, false);
                            iList_01.Add(iSpray2);
                            bShowerON = true;
                        }
                        else
                        {
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_mp_house");
                        }
                    }
                }           //Shower01
                else if (PlayPos.DistanceTo(vYachtTrigList[3]) < 2.50f)
                {
                    if (PlayPos.DistanceTo(vYachtTrigList[3]) < 1.25f && !bSwimSuit)
                    {
                        WardrobeScan(3);
                        bSwimSuit = true;
                    }
                    else
                    {
                        if (Game.Player.Character.Model != iAmHash)
                            bSwimSuit = false;
                    }
                    if (!bShowerON)
                    {
                        Vector3 Shower01 = new Vector3(-2021.994f, -1031.659f, 3.3116f);
                        Vector3 ShowerRoto01 = new Vector3(125f, 0.00f, -106.4265f);
                        if (Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, "scr_mp_house"))
                        {
                            Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_mp_house");
                            int iSpray = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, "ent_amb_shower", Shower01.X, Shower01.Y, Shower01.Z, ShowerRoto01.X, ShowerRoto01.Y, ShowerRoto01.Z, 1.00f, true, true, true, false);
                            iList_01.Add(iSpray);
                            int iSpray2 = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, "ent_amb_shower_steam", Shower01.X, Shower01.Y, Shower01.Z - 1.00f, 0.00f, 0.00f, 0.00f, 1.00f, true, true, true, false);
                            iList_01.Add(iSpray2);
                            bShowerON = true;
                        }
                        else
                        {
                            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_mp_house");
                        }
                    }
                }           //Shower02
                else if (PlayPos.DistanceTo(vYachtTrigList[4]) < 1.00f)
                {
                    if (!bASleap)
                    {
                        ControlerUI(sYachtLang[8], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            iMyBed = 0;
                            YachtStuff_BedTime(YachtSleap[iMyBed]);
                        }
                    }
                }           //Bed01
                else if (PlayPos.DistanceTo(vYachtTrigList[5]) < 1.00f)
                {
                    if (!bASleap)
                    {
                        ControlerUI(sYachtLang[8], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            iMyBed = 1;
                            YachtStuff_BedTime(YachtSleap[iMyBed]);
                        }
                    }
                }           //Bed02
                else if (PlayPos.DistanceTo(vYachtTrigList[6]) < 1.00f)
                {
                    if (!bASleap)
                    {
                        ControlerUI(sYachtLang[8], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            iMyBed = 2;
                            YachtStuff_BedTime(YachtSleap[iMyBed]);
                        }
                    }
                }           //Bed03  
                else if (PlayPos.DistanceTo(vYachtTrigList[7]) < 4.00f && PlayPos.Z > 3.00f)
                {
                    if (!bWetness)
                    {
                        if (PlayPos.DistanceTo(vYachtTrigList[7]) < 1.50f)
                        {
                            bWetness = true;
                            Function.Call(Hash.SET_PED_WETNESS_HEIGHT, Peddy, 0.85f);
                            Function.Call(Hash.SET_PED_WETNESS_ENABLED_THIS_FRAME, Peddy);
                        }
                    }
                    if (!bSwimSuit)
                    {
                        WardrobeScan(2);
                        bSwimSuit = true;
                    }
                    else
                    {
                        if (Game.Player.Character.Model != iAmHash)
                            bSwimSuit = false;
                        else if (iJacuzSit == 1)
                        {
                            ControlerUI(sYachtLang[5], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (Peddy.Gender == Gender.Female)
                                    YachtStuff_JackStand(1, false);
                                else
                                    YachtStuff_JackStand(1, true);
                            }
                            else
                            {
                                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                                {
                                    if (Peddy.Gender == Gender.Female)
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "base", PlayPos, Peddy.Rotation);
                                        bBacktoBase = !bBacktoBase;
                                    }
                                    else
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnim(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnim(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnim(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnim(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                        }
                                        else
                                            ForceAnim(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "base", PlayPos, Peddy.Rotation);
                                        bBacktoBase = !bBacktoBase;
                                    }
                                }
                            }
                        }
                        else if (iJacuzSit == 2)
                        {
                            ControlerUI(sYachtLang[9], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (Peddy.Gender == Gender.Female)
                                    YachtStuff_JackStand(2, false);
                                else
                                    YachtStuff_JackStand(2, true);
                            }
                            else
                            {
                                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                                {
                                    if (Peddy.Gender == Gender.Female)
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                    else
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                }
                            }
                        }
                        else if (iJacuzSit == 22)
                        {
                            ControlerUI(sYachtLang[9], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (Peddy.Gender == Gender.Female)
                                    YachtStuff_JackStand(2, false);
                                else
                                    YachtStuff_JackStand(2, true);
                            }
                            else
                            {
                                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                                {
                                    if (Peddy.Gender == Gender.Female)
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                    else
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                }
                            }
                        }
                        else if (iJacuzSit == 3)
                        {
                            ControlerUI(sYachtLang[9], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (Peddy.Gender == Gender.Female)
                                    YachtStuff_JackStand(3, false);
                                else
                                    YachtStuff_JackStand(3, true);
                            }
                            else
                            {
                                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                                {
                                    if (Peddy.Gender == Gender.Female)
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                    else
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base", PlayPos, Peddy.Rotation);
                                    }
                                }
                            }
                        }
                        else if (iJacuzSit == 33)
                        {
                            ControlerUI(sYachtLang[9], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                if (Peddy.Gender == Gender.Female)
                                    YachtStuff_JackStand(3, false);
                                else
                                    YachtStuff_JackStand(3, true);
                            }
                            else
                            {
                                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                                {
                                    if (Peddy.Gender == Gender.Female)
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", PlayPos, Peddy.Rotation);
                                    }
                                    else
                                    {
                                        if (!bBacktoBase)
                                        {
                                            int iDell = RandInt(0, 4);
                                            if (iDell == 0)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_a", PlayPos, Peddy.Rotation);
                                            else if (iDell == 1)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_b", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_c", PlayPos, Peddy.Rotation);
                                            else if (iDell == 2)
                                                ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "idle_d", PlayPos, Peddy.Rotation);
                                            bBacktoBase = !bBacktoBase;
                                        }
                                        else
                                            ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base", PlayPos, Peddy.Rotation);
                                    }
                                }
                            }
                        }
                        else if (PlayPos.DistanceTo(vYachtTrigList[12]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[10], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 1;
                                    bBacktoBase = false;
                                    YachtStuff_JackSit(iJacuzSit, vYachtTrigList[12], null, -170.23f);
                                }
                            }
                        }
                        else if (PlayPos.DistanceTo(vYachtTrigList[13]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[10], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 1;
                                    bBacktoBase = false;
                                    YachtStuff_JackSit(iJacuzSit, vYachtTrigList[13], null, -46.56f);
                                }
                            }
                        }
                        else if (PlayPos.DistanceTo(vYachtTrigList[14]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[11], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 2;
                                    bBacktoBase = false;
                                    Vector3 vSit = YachtSit[1].Position - (YachtSit[1].ForwardVector * 1.00f);
                                    YachtStuff_JackSit(iJacuzSit, vSit, YachtSit[1], 95.17f);
                                }
                            }
                        }       //Ysit_1
                        else if (PlayPos.DistanceTo(vYachtTrigList[15]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[11], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 3;
                                    bBacktoBase = false;
                                    Vector3 vSit = YachtSit[3].Position - (YachtSit[3].ForwardVector * 1.00f);
                                    YachtStuff_JackSit(iJacuzSit, vSit, YachtSit[3], -5.24f);
                                }
                            }
                        }       //Ysit_3
                        else if (PlayPos.DistanceTo(vYachtTrigList[16]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[11], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 33;
                                    bBacktoBase = false;
                                    Vector3 vSit = YachtSit[2].Position - (YachtSit[2].ForwardVector * 1.00f);
                                    YachtStuff_JackSit(iJacuzSit, vSit, YachtSit[2], 49.75f);
                                }
                            }
                        }       //Ysit_2
                        else if (PlayPos.DistanceTo(vYachtTrigList[17]) < 1.00f)
                        {
                            if (iJacuzSit == 0)
                            {
                                ControlerUI(sYachtLang[11], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    iJacuzSit = 22;
                                    bBacktoBase = false;
                                    Vector3 vSit = YachtSit[0].Position - (YachtSit[0].ForwardVector * 1.00f);
                                    YachtStuff_JackSit(iJacuzSit, vSit, YachtSit[0], 136.23f);
                                }
                            }
                        }       //Ysit_0
                    }

                }           //Jacuzy
                else if (PlayPos.DistanceTo(vYachtTrigList[8]) < 1.00f || PlayPos.DistanceTo(vYachtTrigList[9]) < 1.00f || PlayPos.DistanceTo(vYachtTrigList[10]) < 1.00f)
                {
                    if (!bMenuOpen)
                    {
                        ControlerUI(sYachtLang[12], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            Function.Call(Hash.DISPLAY_RADAR, false);
                            Game.Player.Character.FreezePosition = true;
                            Game.Player.Character.Heading = 45.00f;
                            LauchWardrobe();
                        }
                    }
                }           //Wardrobes
                else if (PlayPos.DistanceTo(vYachtTrigList[11]) < 1.00f)
                {
                    if (!bPianoSt)
                    {
                        ControlerUI(sYachtLang[13], 1);
                        if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                        {
                            bPianoSt = true;
                            YachtStuff_Pianist(true);
                        }
                    }

                }           //Piano
                else if (PlayPos.DistanceTo(vYachtTrigList[19]) < 0.75f)
                {
                    if (PropList_01.Count > 0)
                    {
                        if (!bDrinks)
                        {
                            ControlerUI(sYachtLang[14], 1);
                            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                            {
                                Peddy.FreezePosition = true;
                                Peddy.HasCollision = false;
                                Npc_01.FreezePosition = true;
                                Npc_01.HasCollision = false;
                                bDrinks = true;
                                YachtStuff_YachtDrink();
                            }
                        }
                    }
                }           //BarDrink
                else if (PlayPos.DistanceTo(vYachtTrigList[20]) < 1.50f)
                {
                    ControlerUI(sYachtLang[15], 1);
                    StickySubTitle(sYachtLang[16] + "~y~" + sDestList[iYachtFast] + "~w~.");
                    if (Game.IsControlJustPressed(2, GTA.Control.Sprint))
                        YachtStuff_FastTravel(iYachtFast);
                    else if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                    {
                        if (iYachtFast > 0)
                            iYachtFast = iYachtFast - 1;
                        else
                            iYachtFast = 11;
                    }
                    else if (Game.IsControlJustPressed(2, GTA.Control.Context))
                    {
                        if (iYachtFast < 11)
                            iYachtFast = iYachtFast + 1;
                        else
                            iYachtFast = 0;
                    }
                }           //Telepost Capitan
                else
                {
                    if (bShowerON)
                    {
                        YachtStuff_ShowerOff();
                        bShowerON = false;
                    }
                    else if (bSwimSuit)
                    {
                        WardOutPut("DefaultOut.XML", Peddy);
                        bSwimSuit = false;
                        bWetness = false;
                    }
                    else
                    {
                        for (int i = 0; i < vYachtDoorList.Count; i++)
                        {
                            Vector3 ThisDoor = vYachtDoorList[i];
                            ThisDoor.Z = ThisDoor.Z - 1.00f;
                            //World.DrawMarker(MarkerType.VerticalCylinder, ThisDoor, Vector3.Zero, Vector3.Zero, new Vector3(0.10f, 0.10f, 0.50f), Color.WhiteSmoke);
                            if (PlayPos.DistanceTo(ThisDoor) < 1.50f)
                            {
                                ControlerUI(sYachtLang[5], 1);
                                if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
                                {
                                    Game.FadeScreenOut(1000);
                                    iDoors = iDoors + 1;
                                    if (iDoors > RandInt(25, 50))
                                    {
                                        SlowFastTravel(vRandomDestList[RandInt(0, vRandomDestList.Count - 1)], 0.00f);
                                        iDoors = 0;
                                    }
                                    else
                                    {
                                        int iDoor = RandInt(0, vYachtDoorList.Count - 1);
                                        while (iDoor == i)
                                        {
                                            iDoor = RandInt(0, vYachtDoorList.Count - 1);
                                            Script.Wait(100);
                                        }
                                        SlowFastTravel(vYachtDoorList[iDoor], fYachtDoorList[iDoor]);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (bYachtParty)
            {
                if (iKeepDance < Game.GameTime)
                    YachtStuff_DancePedDance();
            }
        }
        private void YachtStuff_YachtProps()
        {
            Vector3 Vpos = new Vector3(-2095.017f, -1016.652f, 9.0689f);
            Vector3 Vrot = new Vector3(0.00f, 0.00f, 82.53f);
            BuildProp("prop_bottle_macbeth", Vpos, Vrot, false, false);

            Vpos = new Vector3(-2094.737f, -1016.39f, 9.0965f);
            Vrot = new Vector3(0.00f, 0.00f, 130.60f);
            BuildProp("prop_drink_whisky", Vpos, Vrot, false, false);

            Vpos = new Vector3(-2023.91577f, -1038.049f, 4.73967075f);
            Vrot = new Vector3(0.00f, 0.00f, -96.4467087f);
            BuildProp("apa_mp_apa_yacht_jacuzzi_ripple1", Vpos, Vrot, true, false);

            Vpos = new Vector3(-2050.051f, -1028.00f, 8.007f);
            Vrot = new Vector3(0.00f, 0.00f, -65.65f);
            BuildProp("v_res_fh_benchshort", Vpos, Vrot, true, false);

            Vpos = new Vector3(-2022.31128f, -1036.34998f, 4.70065117f);
            Vrot = new Vector3(0.00f, 0.00f, -43.7661629f);
            Prop pChair = BuildProp("bkr_prop_clubhouse_chair_03", Vpos, Vrot, true, false);
            YachtSit.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2024.10022f, -1040.25232f, 4.7080965f);
            Vrot = new Vector3(0.00f, 0.00f, 174.759735f);
            pChair = BuildProp("bkr_prop_clubhouse_chair_03", Vpos, Vrot, true, false);
            YachtSit.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2021.71082f, -1037.71057f, 4.70063496f);
            Vrot = new Vector3(0.00f, 0.00f, -84.8238678f);
            pChair = BuildProp("bkr_prop_clubhouse_chair_03", Vpos, Vrot, true, false);
            YachtSit.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2022.29175f, -1039.49048f, 4.70464563f);
            Vrot = new Vector3(0.00f, 0.00f, -130.24353f);
            pChair = BuildProp("bkr_prop_clubhouse_chair_03", Vpos, Vrot, true, false);
            YachtSit.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2071.655f, -1021.949f, 4.92f);
            Vrot = new Vector3(0.00f, 0.00f, -18.00f);
            pChair = BuildProp("bkr_prop_biker_campbed_01", Vpos, Vrot, true, false);
            YachtSleap.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2089.50f, -1012.338f, 5.02f);
            Vrot = new Vector3(0.00f, 0.00f, 160.00f);
            pChair = BuildProp("bkr_prop_biker_campbed_01", Vpos, Vrot, true, false);
            YachtSleap.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2097.328f, -1011.636f, 5.02f);
            Vrot = new Vector3(0.00f, 0.00f, 160.00f);
            pChair = BuildProp("bkr_prop_biker_campbed_01", Vpos, Vrot, true, false);
            YachtSleap.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2075.263f, -1018.314f, 6.60f);
            Vrot = new Vector3(7.00f, 0.00f, 40.1383f);
            pChair = BuildProp("ch_prop_ch_camera_01", Vpos, Vrot, true, false);
            YachtSlCam.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2085.863f, -1010.814f, 6.60f);
            Vrot = new Vector3(9.00f, 0.00f, -79.86f);
            pChair = BuildProp("ch_prop_ch_camera_01", Vpos, Vrot, true, false);

            YachtSlCam.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;

            Vpos = new Vector3(-2092.863f, -1010.814f, 6.60f);
            Vrot = new Vector3(7.00f, 0.00f, -81.86f);
            pChair = BuildProp("ch_prop_ch_camera_01", Vpos, Vrot, true, false);
            YachtSlCam.Add(new Prop(pChair.Handle));
            pChair.IsVisible = false;
        }
        private void YachtStuff_YachtOwnerShip()
        {
            LogThis("YachtStuff_YachtOwnerShip");

            YachtStuff_TheBlip(false);

            Vector3 Vpos = new Vector3(-2095.131f, -1016.018f, 9.0805f);
            float fHead = -139.3908f;
            Npc_01 = NPCSpawn("mp_f_boatstaff_01", Vpos, fHead, 1);

            Vpos = new Vector3(-2085.108f, -1017.974f, 12.7819f);
            Npc_02 = NPCSpawn("mp_m_boatstaff_01", Vpos, fHead, 2);

            Vpos = new Vector3(-2022.369f, -1048.594f, 0.00f);
            fHead = 84.67f;
            VehicleSpawn("DINGHY4", Vpos, fHead, false, 1);

            Vpos = new Vector3(-2016.061f, -1029.461f, 0.00f);
            fHead = 58.67f;
            VehicleSpawn("TORO2", Vpos, fHead, false, 1);

            Vpos = new Vector3(-2012.37549f, -1034.19446f, 0.00f);
            fHead = -59.9995079f;
            VehicleSpawn("SEASHARK3", Vpos, fHead, false, 1);

            Vpos = new Vector3(-2016.42212f, -1047.59546f, 0.00f);
            fHead = -135.900574f;
            VehicleSpawn("SEASHARK3", Vpos, fHead, false, 1);

            Vpos = new Vector3(-2043.76f, -1031.577f, 11.66f);
            fHead = 71.4947052f;
            VehicleSpawn("SUPERVOLITO", Vpos, fHead, false, 0);

            YachtStuff_YachtProps();
        }
        private void YachtStuff_FastTravel(int iDesin)
        {

            LogThis("YachtStuff_FastTravel, iDesin == " + iDesin);

            VectorList_01.Clear();
            float fHeads = 0.00f;
            Game.FadeScreenOut(500);
            Script.Wait(500);
            if (iDesin == 0)
            {
                VectorList_01.Add(new Vector3(-499.3371f, 6916.317f, 0.3944707f));//BoatSpawn
                VectorList_01.Add(new Vector3(-130.3926f, 6721.384f, 0.1196628f));//BoatDes
                VectorList_01.Add(new Vector3(-88.1898f, 6707.3398f, 1.1492f));//Phonebox
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -143.4888f));//Phone Rota
                fHeads = 270.6326f;
            }           // 0 Paleto Bay");
            else if (iDesin == 1)
            {
                VectorList_01.Add(new Vector3(-1594.42f, 5429.262f, 1.06f));
                VectorList_01.Add(new Vector3(-1602.861f, 5267.00f, 0.20f));
                VectorList_01.Add(new Vector3(-1612.628f, 5262.2293f, 2.8357f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, 24.3751f));
                fHeads = 190.5146f;
            }           // 1 North Chumash");
            else if (iDesin == 2)
            {
                VectorList_01.Add(new Vector3(-3412.128f, 2566.43f, 2.06f));
                VectorList_01.Add(new Vector3(-2092.328f, 2606.613f, 0.12f));
                VectorList_01.Add(new Vector3(-2081.86f, 2616.8691f, 1.9556f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -69.4728f));
                fHeads = 262.0154f;
            }           // 2 Lago Zancuda");
            else if (iDesin == 3)
            {
                VectorList_01.Add(new Vector3(-3628.237f, 538.8174f, 0.199f));
                VectorList_01.Add(new Vector3(-3425.647f, 945.775f, 0.69f));
                VectorList_01.Add(new Vector3(-3424.023f, 955.5846f, 7.0283f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -0.0394f));
                fHeads = 337.3226f;
            }           // 3 Chumash");
            else if (iDesin == 4)
            {
                VectorList_01.Add(new Vector3(-2900.015f, -569.5109f, 0.185f));
                VectorList_01.Add(new Vector3(-3049.102f, -4.854892f, 0.722f));
                VectorList_01.Add(new Vector3(-3038.71f, 22.5648f, 5.7096f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -25.905f));
                fHeads = 20.24796f;
            }           // 4 Pacific Bluffs");
            else if (iDesin == 5)
            {
                VectorList_01.Add(new Vector3(-222.6438f, -3752.753f, 0.0314f));
                VectorList_01.Add(new Vector3(66.860f, -2769.287f, 1.44f));
                VectorList_01.Add(new Vector3(62.7995f, -2759.156f, 4.9212f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -90.1372f));
                fHeads = 1.71135f;
            }           // 5 Elysian Island");
            else if (iDesin == 6)
            {
                VectorList_01.Add(new Vector3(1738.537f, -3129.696f, 0.83f));
                VectorList_01.Add(new Vector3(895.8905f, -2644.206f, -1.014f));
                VectorList_01.Add(new Vector3(893.1291f, -2629.654f, 1.959f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -16.5193f));
                fHeads = 52.103f;
            }           // 6 Terminal");
            else if (iDesin == 7)
            {
                VectorList_01.Add(new Vector3(3413.212f, -1098.86f, 0.719f));
                VectorList_01.Add(new Vector3(2852.93f, -727.5198f, 0.426f));
                VectorList_01.Add(new Vector3(2818.7285f, -741.573f, 1.1738f));
                VectorList_01.Add(new Vector3(0.3663f, 0.341f, 81.4615f));
                fHeads = 51.97708f;
            }           // 7 Palomino");
            else if (iDesin == 8)
            {
                VectorList_01.Add(new Vector3(3624.943f, 1232.093f, 0.169f));
                VectorList_01.Add(new Vector3(2899.158f, 1779.543f, 0.442f));
                VectorList_01.Add(new Vector3(2878.2939f, 1787.7893f, 3.00f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -1.4055f));
                fHeads = 54.0335f;
            }           // 8 Palmer-Taylor");
            else if (iDesin == 9)
            {
                VectorList_01.Add(new Vector3(4480.12f, 4358.129f, 0.26f));
                VectorList_01.Add(new Vector3(3846.771f, 4451.328f, 0.164f));
                VectorList_01.Add(new Vector3(3829.1572f, 4465.0527f, 1.6065f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, 0.6556f));
                fHeads = 0.00f;
            }           // 9 San Chianski");
            else if (iDesin == 10)
            {
                VectorList_01.Add(new Vector3(3714.063f, 5297.999f, 0.142f));
                VectorList_01.Add(new Vector3(3418.38f, 5188.487f, 0.833f));
                VectorList_01.Add(new Vector3(3429.895f, 5178.62f, 6.282f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, -163.3262f));
                fHeads = 107.8634f;
            }           // 10 El Gordo");
            else
            {
                VectorList_01.Add(new Vector3(1529.896f, 7233.025f, 1.667f));
                VectorList_01.Add(new Vector3(1504.303f, 6647.771f, 0.413f));
                VectorList_01.Add(new Vector3(1521.023f, 6632.814f, 1.4227f));
                VectorList_01.Add(new Vector3(0.00f, 0.00f, 0.00f));
                fHeads = 172.111f;
            }           // 11 Procopio Beach");
            BuildProp("prop_phonebox_04", VectorList_01[2], VectorList_01[3], true, true);

            VehicleSpawn("DINGHY", VectorList_01[0], fHeads, false, 2);
        }
        private void YachtStuff_BoatToShore()
        {
            LogThis("YachtStuff_BoatToShore");

            WarptoAnyVeh(SHowBoat, Game.Player.Character, 2, false);

            while (Game.Player.Character.IsInVehicle(SHowBoat))
                Script.Wait(500);
            YachtStuff_YachtRmovals();
        }
        private void YachtStuff_YachtScuba(int iped)
        {
            LogThis("YachtStuff_YachtScuba, iped == " + iped);

            Ped Peddy = Game.Player.Character;

            if (iped == 1)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 0, 0, 0, 2);     //0 Head
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 1, 0, 0, 2);     //1 mask
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 2, -1, 0, 2);    //2 hair
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 3, 0, 2);     //3 Torso
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 3, 0, 2);     //4 Legs
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 4, 0, 2);     //5 Hands
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 2, 0, 2);     //6 shoes
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 8, 0, 2);     //8 AccTop
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 4, 0, 2);     //9 Armor
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 0, 0, 2);    //11 Top2

                ClearPedProps(iped, Peddy);
            }       //Franklin
            else if (iped == 2)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 0, 0, 0, 2);     //0 Head
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 1, 0, 0, 2);     //1 mask
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 2, -1, 0, 2);    //2 hair
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 3, 0, 2);     //3 Torso
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 3, 0, 2);     //4 Legs
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 6, 0, 2);     //5 Hands
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 3, 0, 2);     //6 shoes
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 21, 0, 2);    //8 AccTop
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 7, 0, 2);     //9 Armor
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 0, 0, 2);    //11 Top2

                ClearPedProps(iped, Peddy);
            }       //Michael
            else if (iped == 3)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 0, 0, 0, 2);     //0 Head
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 1, 0, 0, 2);     //1 mask
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 2, -1, 0, 2);    //2 hair
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 6, 0, 2);     //3 Torso
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 6, 0, 2);     //4 Legs
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 3, 0, 2);     //5 Hands
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 2, 0, 2);     //6 shoes
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 15, 0, 2);    //8 AccTop
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, -1, 0, 2);    //9 Armor
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, -1, 0, 2);   //11 Top2

                ClearPedProps(iped, Peddy);
            }       //Trevor
            else if (iped == 4)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 0, 0, 0, 2);     //0 Head
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 1, 122, 0, 2);     //1 mask
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 2, -1, 0, 2);    //2 hair
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 169, 10, 2);     //3 Torso
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 97, 11, 2);     //4 Legs
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 70, 5, 2);     //6 shoes
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 187, 1, 2);     //8 AccTop
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 251, 11, 2);    //11 Top2

                ClearPedProps(iped, Peddy);
            }       //MpFemale--not done
            else if (iped == 5)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 0, 0, 0, 2);     //0 Head
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 1, 122, 0, 2);     //1 mask
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 2, -1, 0, 2);    //2 hair
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 138, 10, 2);     //3 Torso
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 94, 4, 2);     //4 Legs
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 67, 11, 2);     //6 shoes
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 151, 1, 2);     //8 AccTop
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 243, 11, 2);    //11 Top2

                ClearPedProps(iped, Peddy);
            }       //MpMale
            bScubaGOn = true;
        }
        private void YachtStuff_YachtSwim(int iped)
        {
            LogThis("YachtStuff_YachtSwim, iped == " + iped);

            Ped Peddy = Game.Player.Character;
            if (iped == 1)
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/Franklin_Swim.xml"))
                    WardOutPut("Franklin_Swim.xml", Peddy);
                else
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 26, 0, 2);     //3 Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 18, 0, 2);     //4 Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 15, 0, 2);     //6 shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 0, 0, 2);     //8 AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 0, 0, 2);    //11 Top2
                }
            }       //Franklin
            else if (iped == 2)
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/Michael_Swim.xml"))
                    WardOutPut("Michael_Swim.xml", Peddy);
                else
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 26, 0, 2);     //3 Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 18, 4, 2);     //4 Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 1, 0, 2);     //6 shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 0, 0, 2);     //8 AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 0, 0, 2);    //11 Top2
                }
            }       //Michael
            else if (iped == 3)
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/Trevor_Swim.xml"))
                    WardOutPut("Trevor_Swim.xml", Peddy);
                else
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 16, 0, 2);     //3 Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 26, 0, 2);     //4 Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, -1, 0, 2);     //6 shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, 0, 0, 2);     //8 AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 0, 0, 2);    //11 Top2
                }
            }       //Trevor
            else if (iped == 4)
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/FreeFemale_Swim.xml"))
                    WardOutPut("FreeFemale_Swim.xml", Peddy);
                else
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 15, 0, 2);     //3 Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 17, 9, 2);     //4 Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 16, 3, 2);     //6 shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, -1, 0, 2);     //8 AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, 18, 11, 2);    //11 Top2
                }
            }       //MpFemale
            else if (iped == 5)
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit/FreeMale_Swim.xml"))
                    WardOutPut("FreeMale_Swim.xml", Peddy);
                else
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 3, 15, 0, 2);     //3 Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 4, 18, 8, 2);     //4 Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 5, 0, 0, 2);     //5 Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 6, 5, 3, 2);     //6 shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 7, 0, 0, 2);     //7 Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 8, -1, 0, 2);     //8 AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 9, 0, 0, 2);     //9 Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 10, 0, 0, 2);    //10 Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, 11, -1, 0, 2);    //11 Top2
                }
            }       //MpMale

            Peddy.ClearBloodDamage();
        }
        private void YachtStuff_ShowerOff()
        {
            LogThis("YachtStuff_ShowerOff");

            for (int i = 0; i < iList_01.Count; i++)
                Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, iList_01[i], true);

            iList_01.Clear();
        }
        private void YachtStuff_YachtDrink()
        {
            LogThis("YachtStuff_YachtDrink");

            VectorList_01.Clear();
            fList_01.Clear();

            Prop Glass = PropList_01[1];
            Prop Bottle = PropList_01[0];

            Function.Call(Hash.DISPLAY_RADAR, false);

            Npc_01.Task.ClearAllImmediately();
            Game.Player.Character.Task.ClearAllImmediately();

            Glass.HasCollision = false;
            Bottle.HasCollision = false;

            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Glass.Handle, Npc_01.Handle, 42, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);
            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Bottle.Handle, Npc_01.Handle, 66, 0.00f, 0.00f, -0.10f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);

            Vector3 VMaidP = vYachtTrigList[18];
            Vector3 VMaidR = new Vector3(0.00f, 0.00f, 220.00f);

            Vector3 VPEddP = vYachtTrigList[19];
            Vector3 VPEddR = new Vector3(0.00f, 0.00f, 40.00f);

            if (iYachtDrink == 0)
            {
                Vector3 Campo = new Vector3(-2097.152f, -1019.854f, 9.7706f);
                Vector3 Camro = new Vector3(0.00f, 0.00f, 311.713f);
                cCams = World.CreateCamera(Campo, Camro, 50.00f);
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 1, 1, cCams.Handle, 0, 0);

                ForceAnimOnce(Npc_01, "anim@mini@yacht@bar@drink@one", "one_bartender", VMaidP, VMaidR);
                ForceAnimOnce(Game.Player.Character, "anim@mini@yacht@bar@drink@one", "one_player", VPEddP, VPEddR);

                Script.Wait(1000);
                while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Npc_01, 134))
                    Script.Wait(100);

                Game.Player.Character.Task.ClearAllImmediately();
                ForceAnim(Npc_01, "anim@mini@yacht@bar@drink@idle_a", "idle_a", Npc_01.Position, Npc_01.Rotation);
                Glass.HasCollision = true;
                Bottle.HasCollision = true;
                Glass.Detach();
                Bottle.Detach();
                Bottle.Position = new Vector3(-2095.017f, -1016.652f, 9.0689f);
                Glass.Position = new Vector3(-2094.737f, -1016.39f, 9.0965f);
                Game.Player.Character.FreezePosition = false;
                Game.Player.Character.HasCollision = true;
                CleanCams();
                Npc_01.FreezePosition = false;
                Npc_01.HasCollision = true;
                if (!bYachtParty)
                    YachtStuff_YachtParty();
                iYachtDrink += 1;
                bDrinks = false;

                Script.Wait(2000);
                YachtStuff_DancePedDance();
            }
            else if (iYachtDrink == 1)
            {
                Vector3 Campo = new Vector3(-2085.524f, -1012.565f, 9.7706f);
                Vector3 Camro = new Vector3(0.00f, 0.00f, 106.5425f);
                cCams = World.CreateCamera(Campo, Camro, 50.00f);
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 1, 1, cCams.Handle, 0, 0);

                ForceAnimOnce(Npc_01, "anim@mini@yacht@bar@drink@two", "two_bartender", VMaidP, VMaidR);
                ForceAnimOnce(Game.Player.Character, "anim@mini@yacht@bar@drink@two", "two_player", VPEddP, VPEddR);

                Script.Wait(1000);
                while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Npc_01, 134))
                    Script.Wait(100);

                Game.Player.Character.Task.ClearAllImmediately();
                ForceAnim(Npc_01, "anim@mini@yacht@bar@drink@idle_a", "idle_a", Npc_01.Position, Npc_01.Rotation);
                Glass.HasCollision = true;
                Bottle.HasCollision = true;
                Glass.Detach();
                Bottle.Detach();
                Bottle.Position = new Vector3(-2095.017f, -1016.652f, 9.0689f);
                Glass.Position = new Vector3(-2094.737f, -1016.39f, 9.0965f);
                CleanCams();
                Game.Player.Character.FreezePosition = false;
                Game.Player.Character.HasCollision = true;
                Npc_01.FreezePosition = false;
                Npc_01.HasCollision = true;
                bDrinkig = true;
                Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "Drunk");
                DrunkMoves();

                iYachtDrink += 1;
                bDrinks = false;
            }
            else
            {
                Vector3 Campo = new Vector3(-2088.358f, -1021.988f, 9.7706f);
                Vector3 Camro = new Vector3(0.00f, 0.00f, 40.24986f);
                cCams = World.CreateCamera(Campo, Camro, 50.00f);
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 1, 1, cCams.Handle, 0, 0);

                ForceAnimOnce(Npc_01, "anim@mini@yacht@bar@drink@three", "three_bartender", VMaidP, VMaidR);
                ForceAnimOnce(Game.Player.Character, "anim@mini@yacht@bar@drink@three", "three_player", VPEddP, VPEddR);

                Script.Wait(1000);
                while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Npc_01, 134))
                    Script.Wait(100);
                Game.FadeScreenOut(1000);
                Script.Wait(1000);

                Game.Player.Character.Task.ClearAllImmediately();
                ForceAnim(Npc_01, "anim@mini@yacht@bar@drink@idle_a", "idle_a", Npc_01.Position, Npc_01.Rotation);
                Glass.HasCollision = true;
                Bottle.HasCollision = true;
                Glass.Detach();
                Bottle.Detach();
                Bottle.Position = new Vector3(-2095.017f, -1016.652f, 9.0689f);
                Glass.Position = new Vector3(-2094.737f, -1016.39f, 9.0965f);
                CleanCams();
                Game.Player.Character.FreezePosition = false;
                Game.Player.Character.HasCollision = true;
                Npc_01.FreezePosition = false;
                Npc_01.HasCollision = true;

                if (bOnOff(1))
                {
                    VectorList_01.Add(new Vector3(-1612.182f, -1090.286f, 13.01287f)); fList_01.Add(228.086f);
                    VectorList_01.Add(new Vector3(-469.543f, -293.4074f, 42.21681f)); fList_01.Add(19.75726f);
                    VectorList_01.Add(new Vector3(-117.917f, -443.1541f, 35.90757f)); fList_01.Add(201.0832f);
                    VectorList_01.Add(new Vector3(-181.4628f, -630.9092f, 48.96748f)); fList_01.Add(64.58707f);
                    VectorList_01.Add(new Vector3(222.1761f, -959.4706f, 29.27803f)); fList_01.Add(323.3547f);
                    VectorList_01.Add(new Vector3(-385.0554f, -1887.786f, 29.94583f)); fList_01.Add(210.4333f);
                    VectorList_01.Add(new Vector3(-1201.949f, -1794.424f, 3.90786f)); fList_01.Add(49.55961f);
                    VectorList_01.Add(new Vector3(-471.416f, 1105.912f, 327.1167f)); fList_01.Add(103.245f);
                    VectorList_01.Add(new Vector3(-683.8403f, 5841.721f, 17.27512f)); fList_01.Add(39.61398f);
                    VectorList_01.Add(new Vector3(-1861.247f, 2071.181f, 140.9823f)); fList_01.Add(19.14237f);
                    VectorList_01.Add(new Vector3(-1248.798f, -158.9396f, 40.40816f)); fList_01.Add(153.0433f);
                    VectorList_01.Add(new Vector3(-604.6938f, 112.1578f, 68.13498f)); fList_01.Add(227.9515f);
                    VectorList_01.Add(new Vector3(209.702f, 47.96529f, 83.81937f)); fList_01.Add(247.4784f);
                    VectorList_01.Add(new Vector3(1007.89f, 139.731f, 84.9901f)); fList_01.Add(206.5416f);

                    int iPosy = RandInt(0, VectorList_01.Count - 1);
                    Vector3 Vspot = VectorList_01[iPosy];
                    Vector3 VRota = new Vector3(0.00f, 0.00f, fList_01[iPosy]);
                    Game.Player.Character.Position = Vspot;

                    ForceAnim(Game.Player.Character, "switch@trevor@puking_into_fountain", "trev_fountain_puke_loop", Vspot, VRota);
                    Script.Wait(1000);
                    Game.FadeScreenIn(2000);
                    while (Game.IsScreenFadingIn)
                        Script.Wait(100);
                    Script.Wait(2000);
                    ForceAnimOnce(Game.Player.Character, "switch@trevor@puking_into_fountain", "trev_fountain_puke_exit", Vspot, VRota);
                }
                else
                {
                    VectorList_01.Add(new Vector3(-1474.212f, 163.0681f, 55.76753f)); fList_01.Add(203.1384f);
                    VectorList_01.Add(new Vector3(683.9828f, 579.5739f, 130.4613f)); fList_01.Add(260.3782f);
                    VectorList_01.Add(new Vector3(455.0457f, 5572.154f, 781.1837f)); fList_01.Add(189.677f);
                    VectorList_01.Add(new Vector3(-1890.564f, 2085.58f, 140.9958f)); fList_01.Add(182.6543f);
                    VectorList_01.Add(new Vector3(-2182.649f, 238.1252f, 184.6018f)); fList_01.Add(110.7141f);
                    VectorList_01.Add(new Vector3(-3418.307f, 953.5591f, 8.346685f)); fList_01.Add(281.9393f);

                    int iPosy = RandInt(0, VectorList_01.Count - 1);
                    Vector3 Vspot = VectorList_01[iPosy];
                    Vector3 VRota = new Vector3(0.00f, 0.00f, fList_01[iPosy]);
                    Game.Player.Character.Position = Vspot;

                    ForceAnimOnce(Game.Player.Character, "missfam5_blackout", "pass_out", Vspot, VRota);
                    Game.FadeScreenIn(1000);
                    Script.Wait(1000);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Game.Player.Character, 134))
                        Script.Wait(1);
                    ForceAnimOnce(Game.Player.Character, "missfam5_blackout", "vomit", Game.Player.Character.Position, Game.Player.Character.Rotation);
                    Script.Wait(1000);
                }

                while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Game.Player.Character, 134))
                    Script.Wait(100);
                Game.Player.Character.Task.ClearAllImmediately();
                TimeCycFade();

                iYachtDrink += 1;
                bDrinks = false;
            }
        }
        private void YachtStuff_Pianist(bool bOn)
        {
            LogThis("YachtStuff_Pianist, bOn == " + bOn);

            if (bOn)
            {
                Game.Player.Character.FreezePosition = true;
                Game.Player.Character.HasCollision = false;
                Vector3 Vpos = new Vector3(-2049.95f, -1028.088f, 8.9625f);
                Vector3 Vrot = new Vector3(0.00f, 0.00f, -47.0688f);
                Game.Player.Character.Position = Vpos;
                Game.Player.Character.Rotation = Vrot;
                ForceAnim(Game.Player.Character, "mp_safehousevagos@boss", "vagos_boss_keyboard_base", Vpos, Vrot);
                Script.Wait(500);
                DipDar.PlayLooping();
            }
            else
            {
                DipDar.Stop();
                Game.Player.Character.Task.ClearAnimation("mp_safehousevagos@boss", "vagos_boss_keyboard_base");
                Game.Player.Character.FreezePosition = false;
                Game.Player.Character.HasCollision = true;
            }
        }
        private void YachtStuff_JackStand(int iStandard, bool bMale)
        {
            LogThis("YachtStuff_JackStand, iStandard == " + iStandard + ", bMale == " + bMale);

            Ped Peddy = Game.Player.Character;
            Vector3 Vpos = Peddy.Position + (Peddy.ForwardVector * 0.30f);
            Vector3 Vrot = Peddy.Rotation;
            Peddy.Detach();
            if (iStandard == 1)
            {
                if (bMale)
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "exit", Peddy.Position, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
                else
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "exit", Peddy.Position, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
            }
            else if (iStandard == 2)
            {
                if (bMale)
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "exit", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
                else
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "exit", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
            }
            else if (iStandard == 3)
            {
                if (bMale)
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "exit", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
                else
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "exit", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    iJacuzSit = 0;
                    Peddy.Task.ClearAllImmediately();
                }
            }
        }
        private void YachtStuff_JackSit(int iPose, Vector3 vInSitU, Prop pChair, float fAngle)
        {
            LogThis("YachtStuff_JackSit, iPose == " + iPose);

            Ped Peddy = Game.Player.Character;
            Vector3 TheCenter = new Vector3(-2023.765f, -1038.013f, 6.70f);
            Peddy.Task.GoTo(vInSitU, true, 1000);
            Script.Wait(1000);
            Function.Call(Hash.TASK_TURN_PED_TO_FACE_COORD, Peddy.Handle, TheCenter.X, TheCenter.Y, TheCenter.Z, 1000);
            Script.Wait(1000);
            Vector3 Vpos = Peddy.Position;
            Vector3 Vrot = new Vector3(0.00f, 0.00f, fAngle);

            if (Peddy.Gender == Gender.Male)
            {
                if (iPose == 1)
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@male@variation_01@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //Stand
                else if (iPose == 2 || iPose == 22)
                {
                    if (pChair != null)
                        Game.Player.Character.AttachTo(pChair, 0, new Vector3(0.00f, 0.00f, 0.50f), new Vector3(0.00f, 0.00f, -180.00f));
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //Sitouter
                else if (iPose == 3 || iPose == 33)
                {
                    if (pChair != null)
                        Game.Player.Character.AttachTo(pChair, 0, new Vector3(0.00f, 0.00f, 0.50f), new Vector3(0.00f, 0.00f, -180.00f));
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //SiInner
            }
            else
            {
                if (iPose == 1)
                {
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@standing@female@variation_01@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //Stand
                else if (iPose == 2 || iPose == 22)
                {
                    if (pChair != null)
                        Game.Player.Character.AttachTo(pChair, 0, new Vector3(0.00f, 0.00f, 0.50f), new Vector3(0.00f, 0.00f, -180.00f));
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //Sitouter
                else if (iPose == 3 || iPose == 33)
                {
                    if (pChair != null)
                        Game.Player.Character.AttachTo(pChair, 0, new Vector3(0.00f, 0.00f, 0.50f), new Vector3(0.00f, 0.00f, -180.00f));
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "enter", Vpos, Vrot);
                    Script.Wait(100);
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Peddy, 134))
                        Script.Wait(100);
                    ForceAnimOnce(Peddy, "anim@amb@yacht@jacuzzi@seated@female@variation_01@", "base", Vpos, Vrot);
                    Script.Wait(100);
                }       //SiInner
            }
        }
        private void YachtStuff_BedTime(Prop PBed)
        {
            LogThis("YachtStuff_BedTime");

            Game.FadeScreenOut(1);
            iAmHash = Game.Player.Character.Model.Hash;

            Vector3 VOffPos = new Vector3(0.00f, 0.00f, 1.10f);
            Vector3 VOffRot = new Vector3(0.00f, 0.00f, 90.00f);

            Game.Player.Character.AttachTo(PBed, 0, VOffPos, VOffRot);

            Vector3 Campo = YachtSlCam[iMyBed].Position;
            Vector3 Camro = new Vector3(YachtSlCam[iMyBed].Rotation.X, YachtSlCam[iMyBed].Rotation.Y, YachtSlCam[iMyBed].Rotation.Z - 180.00f); ;

            CleanCams();

            Function.Call(Hash.DISPLAY_RADAR, false);

            cCams = World.CreateCamera(Campo, Camro, 50.00f);
            Function.Call(Hash.RENDER_SCRIPT_CAMS, 1, 1, cCams.Handle, 0, 0);

            ForceAnim(Game.Player.Character, "anim@mp_bedmid@right_var_04", "f_sleep_r_loop_bighouse", Game.Player.Character.Position, Game.Player.Character.Rotation);
            Game.FadeScreenIn(1000);
            Script.Wait(1000);
            if (bDrinkig)
            {
                Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
                bDrinkig = false;
                Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.00f);
                iYachtDrink = 0;
            }
            bASleap = true;
        }
        private void YachtStuff_YachtParty()
        {
            LogThis("YachtStuff_YachtParty");

            Prop[] Pops = World.GetNearbyProps(vYachtBlip, 75.00f);

            DancingPed.Clear();

            for (int i = 0; i < Pops.Count(); i++)
            {
                if (PropExists(Pops, i))
                {
                    Ped Psit = null;

                    if (Pops[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, "hei_prop_yah_seat_02") || Pops[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, "hei_prop_yah_seat_03"))
                    {
                        if (RandInt(0, 20) < 10)
                        {
                            Psit = NPCSpawn(RandomNPC(), Pops[i].Position, Pops[i].Heading - 180f, 0);
                            PedSitHere(Psit, Pops[i], 1);
                        }
                    }
                    else if (Pops[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, "hei_prop_yah_lounger"))
                    {
                        if (RandInt(0, 20) < 10)
                        {
                            Psit = NPCSpawn(RandomNPC(), Pops[i].Position, Pops[i].Heading - 180f, 0);
                            PedSitHere(Psit, Pops[i], 2);
                        }
                    }
                    else if (Pops[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, "hei_prop_yah_seat_01"))
                    {
                        if (RandInt(0, 20) < 10)
                        {
                            Psit = NPCSpawn(RandomNPC(), Pops[i].Position, Pops[i].Heading - 180f, 0);
                            PedSitHere(Psit, Pops[i], 8);
                        }
                    }
                }

            }

            List<Vector3> Pos_01 = new List<Vector3>();

            Pos_01.Add(new Vector3(-2041.087f, -1032.308f, 11.98071f));
            Pos_01.Add(new Vector3(-2101.375f, -1012.525f, 8.969614f));
            Pos_01.Add(new Vector3(-2118.985f, -1006.77f, 7.920915f));
            Pos_01.Add(new Vector3(-2088.573f, -1016.668f, 8.971194f));
            Pos_01.Add(new Vector3(-2031.578f, -1040.083f, 5.882085f));
            Pos_01.Add(new Vector3(-2029.057f, -1032.141f, 5.88269f));
            Pos_01.Add(new Vector3(-2046.618f, -1030.548f, 11.98071f));
            Pos_01.Add(new Vector3(-2059.485f, -1026.207f, 11.90751f));
            Pos_01.Add(new Vector3(-2067.97f, -1023.662f, 11.90972f));
            Pos_01.Add(new Vector3(-2039.228f, -1033.173f, 8.971494f));

            for (int i = 1; i < Pos_01.Count; i++)
            {
                if (i < 6)
                {
                    int iRanPeds = RandInt(2, 3);
                    for (int ii = 0; ii < iRanPeds; ii++)
                    {
                        Vector3 VPedPos = Pos_01[i].Around(2.50f);
                        VPedPos.Z = Pos_01[i].Z;
                        NPCSpawn(RandomNPC(), VPedPos, RandInt(0, 360), 3);
                    }
                }
                else
                {
                    Ped DancinF = null;
                    if (i == Pos_01.Count - 1)
                    {
                        for (int ii = 0; ii < 9; ii++)
                        {
                            Vector3 VPedPos = Pos_01[i].Around(3.55f);
                            VPedPos.Z = Pos_01[i].Z;

                            DancinF = NPCSpawn(RandomNPC(), VPedPos, RandInt(0, 360), 0);
                            DancingPed.Add(new Ped(DancinF.Handle));
                        }
                        Ped DJ = NPCSpawn("ig_djsolmike", Pos_01[0], 243.1566f, 0);
                        DancingPed.Add(new Ped(DJ.Handle));
                    }
                    else
                    {
                        int iRanPeds = RandInt(4, 9);
                        for (int ii = 0; ii < iRanPeds; ii++)
                        {
                            Vector3 VPedPos = Pos_01[i].Around(3.75f);
                            VPedPos.Z = Pos_01[i].Z;

                            DancinF = NPCSpawn(RandomNPC(), VPedPos, RandInt(0, 360), 0);
                            DancingPed.Add(new Ped(DancinF.Handle));
                        }
                    }
                }
            }

            if (VehicleList_01.Count > 0)
            {
                VehicleList_01[VehicleList_01.Count - 1].Delete();
                VehicleList_01.RemoveAt(VehicleList_01.Count - 1);
            }

            List<Vector3> Pos_02 = new List<Vector3>();
            List<Vector3> Pos_03 = new List<Vector3>();

            Pos_02.Add(new Vector3(-2040.42346f, -1030.69165f, 10.9861012f));
            Pos_03.Add(new Vector3(0.00f, 0.00f, 101.32431f));
            Pos_02.Add(new Vector3(-2041.55701f, -1034.10632f, 10.9861012f));
            Pos_03.Add(new Vector3(0.00f, 0.00f, 41.9800873f));
            Pos_02.Add(new Vector3(-2041.55701f, -1034.10632f, 12.2861061f));
            Pos_03.Add(new Vector3(0.00f, 0.00f, 43.9800797f));
            Pos_02.Add(new Vector3(-2040.42346f, -1030.69165f, 12.2861023f));
            Pos_03.Add(new Vector3(0.00f, 0.00f, 99.4242706f));

            for (int i = 0; i < Pos_02.Count; i++)
                BuildProp("stt_prop_speakerstack_01a", Pos_02[i], Pos_03[i], true, false);

            BuildProp("ba_prop_battle_dj_stand", new Vector3(-2039.91492f, -1032.71106f, 10.9857159f), new Vector3(0.00f, 0.00f, 71.5197449f), true, false);

            YachtStuff_DanceFloor(true);
            bYachtParty = true;
        }
        private void YachtStuff_DancePedDance()
        {
            iKeepDance = Game.GameTime + 10000;
            List<string> DancinFool = new List<string>();

            for (int i = 0; i < DancingPed.Count; i++)
            {
                bool bMale = false;
                int iRan = RandInt(1, 3);

                if (!Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, DancingPed[i], 134))
                {
                    DancingPed[i].Task.ClearAll();
                    DancinFool.Clear();

                    if (DancingPed[i].Gender == Gender.Male)
                        bMale = true;

                    DancinFool = DanceList(bMale, iRan);

                    ForceAnim(DancingPed[i], DancinFool[0], DancinFool[1], DancingPed[i].Position, DancingPed[i].Rotation);
                }

            }
        }
        private void YachtStuff_DanceFloor(bool bOn)
        {
            LogThis("YachtStuff_DanceFloor, bOn == " + bOn);

            if (bOn)
            {
                Prop Prps = BuildProp("prop_boombox_01", new Vector3(-2039.91492f, -1032.71106f, 9.50f), new Vector3(0.00f, 0.00f, 71.5197449f), true, true);
                while (Prps == null)
                    Prps = BuildProp("prop_boombox_01", new Vector3(-2039.91492f, -1032.71106f, 9.50f), new Vector3(0.00f, 0.00f, 71.5197449f), true, true);
                Prps.IsVisible = false;
                Prps.HasCollision = false;
                Function.Call((Hash)0x651D3228960D08AF, "SE_DLC_BTL_Yacht_Exterior_01", Prps);

                Prop Prps2 = BuildProp("prop_boombox_01", new Vector3(-2069.29f, -1023.21f, 11.91014f), new Vector3(0.00f, 0.00f, 248.9541f), true, true);
                while (Prps2 == null)
                    Prps2 = BuildProp("prop_boombox_01", new Vector3(-2069.29f, -1023.21f, 11.91014f), new Vector3(0.00f, 0.00f, 248.9541f), true, true);
                Prps2.IsVisible = false;
                Prps2.HasCollision = false;
                Function.Call((Hash)0x651D3228960D08AF, "SE_DLC_APT_Yacht_Bar", Prps2);

                Function.Call(Hash.SET_EMITTER_RADIO_STATION, "SE_DLC_BTL_Yacht_Exterior_01", Function.Call<string>(Hash.GET_RADIO_STATION_NAME, 29));
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_BTL_Yacht_Exterior_01", true);

                Function.Call(Hash.SET_EMITTER_RADIO_STATION, "SE_DLC_APT_Yacht_Bar", Function.Call<string>(Hash.GET_RADIO_STATION_NAME, 29));
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Yacht_Bar", true);
            }
            else
            {
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_BTL_Yacht_Exterior_01", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Yacht_Bar", false);
            }
        }
        private void YachtStuff_YachtRmovals()
        {
            LogThis("YachtStuff_YachtRmovals");

            YachtStuff_DanceFloor(false);
            CleanUp();
            bYachtParty = false;
            YachtSit.Clear();
            YachtStuff_TheBlip(true);
            if (bDrinkig)
                TimeCycFade();
            iYachtDrink = 0;
        }
        private void YouHaveAYacht()
        {
            LangReader();
            bYachtOwner = true;
            YachtStuff_TheBlip(true);
            AddHeistYacht();
            if (bLoadUpOnYacht)
            {
                Game.FadeScreenOut(1);
                Game.Player.Character.Position = vYachtBlip;
                YachtStuff_YachtOwnerShip();
                bYachIsOn = true;
                YachtStuff_StartOnYacht();
            }
        }
        private void OnLoadup()
        {
            LogThis("OnLoadup");

            if (File.Exists(sBeeLogs))
                File.Delete(sBeeLogs);

            vYachtTrigList.Add(new Vector3(-2030.604f, -1041.843f, 2.566333f));     //0
            vYachtTrigList.Add(new Vector3(-2027.406f, -1031.263f, 2.566305f));     //1
            vYachtTrigList.Add(new Vector3(-2026.023f, -1044.079f, 3.5016f));       //2
            vYachtTrigList.Add(new Vector3(-2021.994f, -1031.659f, 3.5016f));       //3
            vYachtTrigList.Add(new Vector3(-2073.849f, -1021.678f, 5.884126f));     //4
            vYachtTrigList.Add(new Vector3(-2089.88f, -1013.522f, 5.884132f));      //5
            vYachtTrigList.Add(new Vector3(-2097.821f, -1013.057f, 5.88435f));      //6
            vYachtTrigList.Add(new Vector3(-2022.674f, -1038.524f, 5.580638f));     //7
            vYachtTrigList.Add(new Vector3(-2093.406f, -1013.812f, 5.884346f));     //8
            vYachtTrigList.Add(new Vector3(-2092.738f, -1012.015f, 5.884349f));     //9
            vYachtTrigList.Add(new Vector3(-2086.886f, -1013.086f, 5.884132f));     //10
            vYachtTrigList.Add(new Vector3(-2050.074f, -1028.000f, 8.971491f));     //11
            vYachtTrigList.Add(new Vector3(-2024.45f, -1035.888f, 5.57f));       //12-stand
            vYachtTrigList.Add(new Vector3(-2025.457f, -1039.567f, 5.57f));     //13-stand
            vYachtTrigList.Add(new Vector3(-2024.319f, -1040.304f, 5.57f));     //14-out
            vYachtTrigList.Add(new Vector3(-2022.741f, -1039.947f, 5.57f));     //15-in
            vYachtTrigList.Add(new Vector3(-2021.812f, -1037.576f, 5.57f));     //16-in
            vYachtTrigList.Add(new Vector3(-2022.5f, -1036.011f, 5.57f));        //17-out
            vYachtTrigList.Add(new Vector3(-2095.131f, -1016.018f, 9.0805f));       //18-BarMaid
            vYachtTrigList.Add(new Vector3(-2094.076f, -1017.452f, 9.0805f));       //19-BarDrink
            vYachtTrigList.Add(new Vector3(-2085.821f, -1017.94f, 12.7819f));       //20-capitan

            vYachtDoorList.Add(new Vector3(-2056.808f, -1031.276f, 8.97149f)); fYachtDoorList.Add(251.6967f);
            vYachtDoorList.Add(new Vector3(-2071.112f, -1028.82f, 5.882073f)); fYachtDoorList.Add(166.458f);
            vYachtDoorList.Add(new Vector3(-2076.274f, -1024.964f, 5.884129f)); fYachtDoorList.Add(62.59665f);
            vYachtDoorList.Add(new Vector3(-2070.088f, -1018.865f, 5.884129f)); fYachtDoorList.Add(79.79578f);
            vYachtDoorList.Add(new Vector3(-2078.324f, -1013.596f, 5.882021f)); fYachtDoorList.Add(255.3005f);
            vYachtDoorList.Add(new Vector3(-2067.564f, -1017.044f, 5.882022f)); fYachtDoorList.Add(338.0218f);
            vYachtDoorList.Add(new Vector3(-2036.542f, -1033.837f, 5.882352f)); fYachtDoorList.Add(235.3591f);
            vYachtDoorList.Add(new Vector3(-2071.008f, -1018.602f, 3.051447f)); fYachtDoorList.Add(241.4973f);

            sDestList.Add("Paleto Bay");
            sDestList.Add("North Chumash");
            sDestList.Add("Lago Zancuda");
            sDestList.Add("Chumash");
            sDestList.Add("Pacific Bluffs");
            sDestList.Add("Elysian Island");
            sDestList.Add("Terminal");
            sDestList.Add("Palomino");
            sDestList.Add("Palmer-Taylor");
            sDestList.Add("San Chianski");
            sDestList.Add("El Gordo");
            sDestList.Add("Procopio Beach");

            DipDar.Load();

            if (ReadNSMPDat() == iProcessForYacht)
                YouHaveAYacht();
        }
        private void onTick(object sender, EventArgs e)
        {
            if (bYachtStart)
            {
                if (!Game.IsLoading)
                {
                    bYachtStart = false;
                    OnLoadup();
                }
            }
            else if (bYachtOwner)
            {
                if (bYachIsOn)
                {
                    if (!bYachtLoaded)
                        AddHeistYacht();
                    else if (bMenuOpen)
                    {
                        if (YtmenuPool.IsAnyMenuOpen())
                            YtmenuPool.ProcessMenus();
                        else
                        {
                            Game.Player.Character.FreezePosition = false;
                            Function.Call(Hash.DISPLAY_RADAR, true);
                            bMenuOpen = false;
                        }
                    }
                    else if(Game.Player.Character.Position.DistanceTo(vYachtBlip) > 275.00f)
                    {
                        if (!bASleap)
                        {
                            YachtStuff_YachtRmovals();
                            bYachIsOn = false;
                        }
                    }
                    else
                        YachtStuff_OntheYacht();
                }
                else
                {
                    if (iSlowDown < Game.GameTime)
                    {
                        iSlowDown = Game.GameTime + 1000;
                        if (Game.Player.Character.Position.DistanceTo(vYachtBlip) < 225.00f)
                        {
                            YachtStuff_YachtOwnerShip();
                            bYachIsOn = true;
                        }
                        else if (ReadNSMPDat() != iProcessForYacht)
                        {
                            bYachtOwner = false;
                            YachtStuff_TheBlip(false);
                        }
                    }
                }
            }
            else
            {
                if (iSlowDown < Game.GameTime)
                {
                    iSlowDown = Game.GameTime + 1000;
                    if (File.Exists(sBoatLaunch))
                    {
                        File.Delete(sBoatLaunch);
                        YouHaveAYacht();
                    }
                }
            }
        }
    }
}