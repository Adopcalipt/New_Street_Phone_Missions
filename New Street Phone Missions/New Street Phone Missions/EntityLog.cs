using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class EntityLog
    {
        private static readonly string sAssSave = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/MyEntitys.txt";
        public static List<string> FileOutPut(string file)
        {
            //LoggerLight.LogThis("FileOutPut == " + file);
            List<string> HoldMy = new List<string>();
            if (File.Exists(file))
            {
                try
                {
                    string[] readNote = File.ReadAllLines(file);
                    if (readNote != null)
                    {
                        for (int i = 0; i < readNote.Count(); i++)
                            HoldMy.Add(readNote[i]);
                    }
                }
                catch (Exception ex)
                {
                    //LoggerLight.LogThis("FileOutPut Fail");
                }
            }

            return HoldMy;
        }
        public static int StringToInt(string s)
        {
            int intOut = -1;
            int index = s.IndexOf('=');
            if (index != -1)
            {
                string result = s.Substring(index + 1);
                // result will contain "value"
                if (int.TryParse(result, out intOut))
                {
                    // Conversion succeeded, 'number' contains the integer value
                }
                else
                {
                    intOut = 0;
                }
            }
            return intOut;
        }
        public static float StringToFloat(string s)
        {
            float intOut = -1.0f;
            int index = s.IndexOf('=');
            if (index != -1)
            {
                string result = s.Substring(index + 1);
                // result will contain "value"
                if (float.TryParse(result, out intOut))
                {
                    // Conversion succeeded, 'number' contains the integer value
                }
                else
                {
                    intOut = 0.0f;
                }
            }
            return intOut;
        }
        public static string BoolToString(bool b)
        {
            if (b)
                return "true";
            else
                return "false";
        }
        public static bool StringToBool(string s)
        {
            if (s.Contains("True") || s.Contains("true") || s.Contains("TRUE"))
                return true;
            else
                return false;
        }
        public static void Settings_Out()
        {
            List<string> Settings_Out = new List<string>
            {
                "[Missions]",
                "Truckin=" + BoolToString(DataStore.MySettings.Truckin),
                "Getaway=" + BoolToString(DataStore.MySettings.Getaway),
                "Packages=" + BoolToString(DataStore.MySettings.Packages),
                "Convicts=" + BoolToString(DataStore.MySettings.Convicts),
                "FUber=" + BoolToString(DataStore.MySettings.FUber),
                "Pilot=" + BoolToString(DataStore.MySettings.Pilot),
                "Amulance=" + BoolToString(DataStore.MySettings.Amulance),
                "Follow=" + BoolToString(DataStore.MySettings.Follow),
                "LSFD=" + BoolToString(DataStore.MySettings.LSFD),
                "Johnny=" + BoolToString(DataStore.MySettings.Johnny),
                "Raceist=" + BoolToString(DataStore.MySettings.Raceist),
                "BBBomb=" + BoolToString(DataStore.MySettings.BBBomb),
                "Assassination=" + BoolToString(DataStore.MySettings.Assassination),
                "Sniper=" + BoolToString(DataStore.MySettings.Sniper),
                "Gruppe6=" + BoolToString(DataStore.MySettings.Gruppe6),
                "Sailor=" + BoolToString(DataStore.MySettings.Sailor),
                "ImportantEx=" + BoolToString(DataStore.MySettings.ImportantEx),
                "DebtCollect=" + BoolToString(DataStore.MySettings.DebtCollect),
                "MCBusiness=" + BoolToString(DataStore.MySettings.MCBusiness),
                "BayLift=" + BoolToString(DataStore.MySettings.BayLift),
                "Sharks=" + BoolToString(DataStore.MySettings.Sharks),
                "HappyShopper=" + BoolToString(DataStore.MySettings.HappyShopper),
                "MoresMute=" + BoolToString(DataStore.MySettings.MoresMute),
                "TempJob=" + BoolToString(DataStore.MySettings.TempJob),
                "ParaDisplay=" + BoolToString(DataStore.MySettings.ParaDisplay),
                "Deliverwho=" + BoolToString(DataStore.MySettings.Deliverwho),
                "Thief=" + BoolToString(DataStore.MySettings.Thief),

                "[Config]",
                "Debug=" + BoolToString(DataStore.MySettings.Debug),
                "Auto_Outfit=" + BoolToString(DataStore.MySettings.Auto_Outfit),
                "ShowRoute=" + BoolToString(DataStore.MySettings.ShowRoute),
                "Subtitles=" + BoolToString(DataStore.MySettings.Subtitles),
                "PhoneCone=" + BoolToString(DataStore.MySettings.PhoneCone),
                "PhoneAnim=" + BoolToString(DataStore.MySettings.PhoneAnim),
                "PhoneAudio=" + BoolToString(DataStore.MySettings.PhoneAudio),
                "AchiveMents=" + BoolToString(DataStore.MySettings.AchiveMents),
                "StartOnYAcht=" + BoolToString(DataStore.MySettings.StartOnYAcht),
                "EnemyStrength=" + BoolToString(DataStore.MySettings.EnemyStrength),
                "PreLoadOnline=" + BoolToString(DataStore.MySettings.PreLoadOnline),
                "FastTraveltoStart=" + BoolToString(DataStore.MySettings.FastTraveltoStart),

                "YachtPrice=" + DataStore.MySettings.YachtPrice,
                "LangSupport=" + DataStore.MySettings.LangSupport,

                "LowerAim=" + DataStore.MySettings.LowerAim,
                "UpperAim=" + DataStore.MySettings.UpperAim,

                "SPDelayTime=" + DataStore.MySettings.SPDelayTime,
                "YachtRadio=" + DataStore.MySettings.YachtRadio
        };
            for (int i = 0; i < DataStore.MySettings.PhoneBlock.Count; i ++)
            {
                Settings_Out.Add("[Phone Block]");
                Settings_Out.Add("PhoneX=" + DataStore.MySettings.PhoneBlock[i].X);
                Settings_Out.Add("PhoneY=" + DataStore.MySettings.PhoneBlock[i].Y);
                Settings_Out.Add("PhoneZ=" + DataStore.MySettings.PhoneBlock[i].Z);
            }
            CreateIni(DataStore.sNSPMiniSet, Settings_Out);
        }
        public static XmlSetings LoadXmlSettings(string file)
        {
            XmlSetings MyOut = new XmlSetings();

            List<string> readNote = FileOutPut(file);

            for (int i = 0; i < readNote.Count; i++)
            {
                string line = readNote[i];
                if (line.Contains("Truckin"))
                    MyOut.Truckin = StringToBool(line);
                else if (line.Contains("Getaway"))
                    MyOut.Getaway = StringToBool(line);
                else if (line.Contains("Packages"))
                    MyOut.Packages = StringToBool(line);
                else if (line.Contains("Convicts"))
                    MyOut.Convicts = StringToBool(line);
                else if (line.Contains("FUber"))
                    MyOut.FUber = StringToBool(line);
                else if (line.Contains("Pilot"))
                    MyOut.Pilot = StringToBool(line);
                else if (line.Contains("Amulance"))
                    MyOut.Amulance = StringToBool(line);
                else if (line.Contains("Follow"))
                    MyOut.Follow = StringToBool(line);
                else if (line.Contains("LSFD"))
                    MyOut.LSFD = StringToBool(line);
                else if (line.Contains("Johnny"))
                    MyOut.Johnny = StringToBool(line);
                else if (line.Contains("Raceist"))
                    MyOut.Raceist = StringToBool(line);
                else if (line.Contains("BBBomb"))
                    MyOut.BBBomb = StringToBool(line);
                else if (line.Contains("Assassination"))
                    MyOut.Assassination = StringToBool(line);
                else if (line.Contains("Sniper"))
                    MyOut.Sniper = StringToBool(line);
                else if (line.Contains("Gruppe6"))
                    MyOut.Gruppe6 = StringToBool(line);
                else if (line.Contains("Sailor"))
                    MyOut.Sailor = StringToBool(line);
                else if (line.Contains("ImportantEx"))
                    MyOut.ImportantEx = StringToBool(line);
                else if (line.Contains("DebtCollect"))
                    MyOut.DebtCollect = StringToBool(line);
                else if (line.Contains("MCBusiness"))
                    MyOut.MCBusiness = StringToBool(line);
                else if (line.Contains("BayLift"))
                    MyOut.BayLift = StringToBool(line);
                else if (line.Contains("Sharks"))
                    MyOut.Sharks = StringToBool(line);
                else if (line.Contains("HappyShopper"))
                    MyOut.HappyShopper = StringToBool(line);
                else if (line.Contains("MoresMute"))
                    MyOut.MoresMute = StringToBool(line);
                else if (line.Contains("TempJob"))
                    MyOut.TempJob = StringToBool(line);
                else if (line.Contains("ParaDisplay"))
                    MyOut.ParaDisplay = StringToBool(line);
                else if (line.Contains("Deliverwho"))
                    MyOut.Deliverwho = StringToBool(line);
                else if (line.Contains("Thief"))
                    MyOut.Thief = StringToBool(line);
                else if (line.Contains("Debug"))
                    MyOut.Debug = StringToBool(line);
                else if (line.Contains("ShowRoute"))
                    MyOut.ShowRoute = StringToBool(line);
                else if (line.Contains("Subtitles"))
                    MyOut.Subtitles = StringToBool(line);
                else if (line.Contains("PhoneCone"))
                    MyOut.PhoneCone = StringToBool(line);
                else if (line.Contains("PhoneAnim"))
                    MyOut.PhoneAnim = StringToBool(line);
                else if (line.Contains("PhoneAudio"))
                    MyOut.PhoneAudio = StringToBool(line);
                else if (line.Contains("AchiveMents"))
                    MyOut.AchiveMents = StringToBool(line);
                else if (line.Contains("StartOnYAcht"))
                    MyOut.StartOnYAcht = StringToBool(line);
                else if (line.Contains("EnemyStrength"))
                    MyOut.EnemyStrength = StringToBool(line);
                else if (line.Contains("PreLoadOnline"))
                    MyOut.PreLoadOnline = StringToBool(line);
                else if (line.Contains("FastTraveltoStart"))
                    MyOut.FastTraveltoStart = StringToBool(line);
            }

            return MyOut;
        }
        public static XmlSetings LoadIniSettings()
        {
            XmlSetings MyOut = new XmlSetings();

            List<string> readNote = FileOutPut(DataStore.sNSPMiniSet);

            for (int i = 0; i < readNote.Count; i++)
            {
                string line = readNote[i];
                if (line.Contains("[Phone Block]"))
                    MyOut.PhoneBlock.Add(new Vector3(StringToFloat(readNote[i + 1]), StringToFloat(readNote[i + 2]), StringToFloat(readNote[i + 3])));
                else if (line.Contains("Truckin="))
                    MyOut.Truckin = StringToBool(line);
                else if (line.Contains("Getaway="))
                    MyOut.Getaway = StringToBool(line);
                else if (line.Contains("Packages="))
                    MyOut.Packages = StringToBool(line);
                else if (line.Contains("Convicts="))
                    MyOut.Convicts = StringToBool(line);
                else if (line.Contains("FUber="))
                    MyOut.FUber = StringToBool(line);
                else if (line.Contains("Pilot="))
                    MyOut.Pilot = StringToBool(line);
                else if (line.Contains("Amulance="))
                    MyOut.Amulance = StringToBool(line);
                else if (line.Contains("Follow="))
                    MyOut.Follow = StringToBool(line);
                else if (line.Contains("LSFD="))
                    MyOut.LSFD = StringToBool(line);
                else if (line.Contains("Johnny="))
                    MyOut.Johnny = StringToBool(line);
                else if (line.Contains("Raceist="))
                    MyOut.Raceist = StringToBool(line);
                else if (line.Contains("BBBomb="))
                    MyOut.BBBomb = StringToBool(line);
                else if (line.Contains("Assassination="))
                    MyOut.Assassination = StringToBool(line);
                else if (line.Contains("Sniper="))
                    MyOut.Sniper = StringToBool(line);
                else if (line.Contains("Gruppe6="))
                    MyOut.Gruppe6 = StringToBool(line);
                else if (line.Contains("Sailor="))
                    MyOut.Sailor = StringToBool(line);
                else if (line.Contains("ImportantEx="))
                    MyOut.ImportantEx = StringToBool(line);
                else if (line.Contains("DebtCollect="))
                    MyOut.DebtCollect = StringToBool(line);
                else if (line.Contains("MCBusiness="))
                    MyOut.MCBusiness = StringToBool(line);
                else if (line.Contains("BayLift="))
                    MyOut.BayLift = StringToBool(line);
                else if (line.Contains("Sharks="))
                    MyOut.Sharks = StringToBool(line);
                else if (line.Contains("HappyShopper="))
                    MyOut.HappyShopper = StringToBool(line);
                else if (line.Contains("MoresMute="))
                    MyOut.MoresMute = StringToBool(line);
                else if (line.Contains("TempJob="))
                    MyOut.TempJob = StringToBool(line);
                else if (line.Contains("ParaDisplay="))
                    MyOut.ParaDisplay = StringToBool(line);
                else if (line.Contains("Deliverwho="))
                    MyOut.Deliverwho = StringToBool(line);
                else if (line.Contains("Thief="))
                    MyOut.Thief = StringToBool(line);
                else if (line.Contains("Debug="))
                    MyOut.Debug = StringToBool(line);
                else if (line.Contains("Auto_Outfit="))
                    MyOut.Auto_Outfit = StringToBool(line);
                else if (line.Contains("ShowRoute="))
                    MyOut.ShowRoute = StringToBool(line);
                else if (line.Contains("Subtitles="))
                    MyOut.Subtitles = StringToBool(line);
                else if (line.Contains("PhoneCone="))
                    MyOut.PhoneCone = StringToBool(line);
                else if (line.Contains("PhoneAnim="))
                    MyOut.PhoneAnim = StringToBool(line);
                else if (line.Contains("PhoneAudio="))
                    MyOut.PhoneAudio = StringToBool(line);
                else if (line.Contains("AchiveMents="))
                    MyOut.AchiveMents = StringToBool(line);
                else if (line.Contains("StartOnYAcht="))
                    MyOut.StartOnYAcht = StringToBool(line);
                else if (line.Contains("EnemyStrength="))
                    MyOut.EnemyStrength = StringToBool(line);
                else if (line.Contains("PreLoadOnline="))
                    MyOut.PreLoadOnline = StringToBool(line);
                else if (line.Contains("FastTraveltoStart="))
                    MyOut.FastTraveltoStart = StringToBool(line);
                else if (line.Contains("YachtPrice="))
                    MyOut.YachtPrice = StringToInt(line);
                else if (line.Contains("LangSupport="))
                    MyOut.LangSupport = StringToInt(line);
                else if (line.Contains("LowerAim="))
                    MyOut.LowerAim = StringToInt(line);
                else if (line.Contains("UpperAim="))
                    MyOut.UpperAim = StringToInt(line);
                else if (line.Contains("SPDelayTime="))
                    MyOut.SPDelayTime = StringToInt(line);
                else if (line.Contains("YachtRadio="))
                    MyOut.YachtRadio = StringToInt(line);
            }
            return MyOut;
        }
        public static int ReadMyInt(string sTing)
        {
            LoggerLight.LogThis("IniSettings.ReadMyInt == " + sTing);
            int iNum = 0;
            int iTimes = 0;
            for (int i = sTing.Length - 1; i > -1; i--)
            {
                int iAdd = 0;
                string sComp = sTing.Substring(i, 1);

                if (sComp == "1")
                    iAdd = 1;
                else if (sComp == "2")
                    iAdd = 2;
                else if (sComp == "3")
                    iAdd = 3;
                else if (sComp == "4")
                    iAdd = 4;
                else if (sComp == "5")
                    iAdd = 5;
                else if (sComp == "6")
                    iAdd = 6;
                else if (sComp == "7")
                    iAdd = 7;
                else if (sComp == "8")
                    iAdd = 8;
                else if (sComp == "9")
                    iAdd = 9;

                if (iTimes == 0)
                {
                    iNum = iAdd;
                    iTimes = 1;
                }
                else
                    iNum += iAdd * iTimes;
                iTimes *= 10;
            }
            return iNum;
        }
        public static ClothX LoadIniOutfit(string sFile)
        {
            LoggerLight.LogThis("LoadIniOutfit == " + sFile);
            string Cloths = "";

            List<int> ClothA = new List<int>();
            List<int> ClothB = new List<int>();
            List<int> ExtraA = new List<int>();
            List<int> ExtraB = new List<int>();

            int intList = 0;
            List<string> readNote = FileOutPut(sFile);

            for (int i = 0; i < readNote.Count; i++)
            {
                string line = readNote[i];
                if (line.Contains("Title"))
                {
                    Cloths = line;
                }
                else if (line.Contains("[ClothA]"))
                {
                    intList = 1;
                }
                else if (line.Contains("[ClothB]"))
                {
                    intList = 2;
                }
                else if (line.Contains("[ExtraA]"))
                {
                    intList = 3;
                }
                else if (line.Contains("[ExtraB]"))
                {
                    intList = 4;
                }
                else if (line.Contains("[FreeOverLay]"))
                {
                    intList = 5;
                }
                else if (line.Contains("[Tattoo]"))
                {
                    intList = 6;
                }
                else if (intList == 1)
                {
                    ClothA.Add(EntityLog.ReadMyInt(line));
                }
                else if (intList == 2)
                {
                    int iSpot = EntityLog.ReadMyInt(line);
                    if (iSpot < 0)
                        iSpot = 0;
                    ClothB.Add(iSpot);
                }
                else if (intList == 3)
                {
                    ExtraA.Add(EntityLog.ReadMyInt(line));
                }
                else if (intList == 4)
                {
                    int iSpot = EntityLog.ReadMyInt(line);
                    if (iSpot < 0)
                        iSpot = 0;
                    ExtraB.Add(iSpot);
                }
            }

            return new ClothX(Cloths, ClothA, ClothB, ExtraA, ExtraB);
        }
        public static void WriteObj(string sLogs, TextWriter tEx)
        {
            try
            {
                tEx.WriteLine(sLogs);
            }
            catch
            {

            }
        }
        public static void BackUpAss(string myAss)
        {
            using (StreamWriter tEx = File.AppendText(sAssSave))
                WriteObj(myAss, tEx);
        }
        public static void CleanAss()
        {
            using (StreamWriter tEx = File.CreateText(sAssSave))
                WriteObj("ObjectStore", tEx);
        }
        public static void ClearThis()
        {
            LoggerLight.LogThis("ClearThis.HasFile");

            List<Prop> prop = new List<Prop>();
            List<Ped> peds = new List<Ped>();
            List<Blip> blips = new List<Blip>();
            List<Vehicle> vehicles = new List<Vehicle>();
            List<int> coronas = new List<int>();
            List<int> sound = new List<int>();
            List<int> fire = new List<int>();
            int iCams = -1;

            List<string> readNote = FileOutPut(sAssSave);

            for (int i = 0; i < readNote.Count; i++)
            {
                if (readNote[i].Contains("Prop"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    prop.Add(new Prop(MyHand));
                }
                else if (readNote[i].Contains("PedX") || readNote[i].Contains("Fped"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    peds.Add(new Ped(MyHand));
                }
                else if (readNote[i].Contains("Vehs") || readNote[i].Contains("Fubs"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    vehicles.Add(new Vehicle(MyHand));
                }
                else if (readNote[i].Contains("Blip") || readNote[i].Contains("Xmar"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    blips.Add(new Blip(MyHand));
                }
                else if (readNote[i].Contains("Cora"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    coronas.Add(MyHand);
                }
                else if (readNote[i].Contains("Soun"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    sound.Add(MyHand);
                }
                else if (readNote[i].Contains("Fire"))
                {
                    readNote[i].Remove(4);
                    int MyHand = ReadMyInt(readNote[i]);
                    fire.Add(MyHand);
                }
                else if (readNote[i].Contains("CamX"))
                {
                    readNote[i].Remove(4);
                    iCams = ReadMyInt(readNote[i]);
                }
            }

            for (int i = 0; i < vehicles.Count; i++)
                CleanUp(vehicles[i], true);

            for (int i = 0; i < peds.Count; i++)
                CleanUp(peds[i], true);

            for (int i = 0; i < prop.Count; i++)
                CleanUp(prop[i], true);

            for (int i = 0; i < blips.Count; i++)
                CleanUp(blips[i]);

            for (int i = 0; i < coronas.Count; i++)
                CleanUp(coronas[i], -1, -1);

            for (int i = 0; i < sound.Count; i++)
                CleanUp(-1, sound[i], -1);

            for (int i = 0; i < fire.Count; i++)
                CleanUp(-1, -1, fire[i]);

            if (iCams != -1)
            {
                MissionData.cCams = new Camera(iCams);
                EntityClear.CleanCams();
            }
            CleanAss();
        }
        public static void CleanUp(Vehicle Vhick, bool bDelete)
        {
            try
            {
                if (Vhick != null)
                {
                    if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, Vhick.Handle))
                    {
                        if (Vhick.CurrentBlip.Exists())
                            Vhick.CurrentBlip.Remove();

                        if (bDelete)
                            Vhick.Delete();
                        else
                            Vhick.MarkAsNoLongerNeeded();

                    }
                }
            }
            catch
            {
                LoggerLight.LogThis("Failed CleanUp, Vhick == " + Vhick.Handle);
            }
        }
        public static void CleanUp(Ped Peddy, bool bDelete)
        {
            try
            {
                if (Peddy != null)
                {
                    if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, Peddy.Handle))
                    {
                        if (Peddy.CurrentBlip.Exists())
                            Peddy.CurrentBlip.Remove();

                        if (bDelete)
                            Peddy.Delete();
                        else
                            Peddy.MarkAsNoLongerNeeded();
                    }
                }
            }
            catch
            {
                LoggerLight.LogThis("Failed CleanUp, Peddy == " + Peddy.Handle);
            }
        }
        public static void CleanUp(Prop Proper, bool bDelete)
        {
            try
            {
                if (Proper != null)
                {
                    if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, Proper.Handle))
                    {
                        if (Proper.IsAttached())
                            Proper.Detach();

                        if (bDelete)
                            Proper.Delete();
                        else
                            Proper.MarkAsNoLongerNeeded();
                    }
                }
            }
            catch
            {
                LoggerLight.LogThis("Failed CleanUp, Proper == " + Proper.Handle);
            }
        }
        public static void CleanUp(Blip Blippy)
        {
            try
            {
                if (Blippy != null)
                {
                    if (Function.Call<bool>(Hash.DOES_BLIP_EXIST, Blippy.Handle))
                        Blippy.Remove();
                }
            }
            catch
            {
                LoggerLight.LogThis("Failed CleanUp, Blips == " + Blippy.Handle);
            }
        }
        public static void CleanUp(int Corrona, int Sounds, int Fires)
        {
            try
            {
                if (Corrona != -1)
                {
                    Function.Call(Hash.DELETE_CHECKPOINT, Corrona);
                }
                else if (Sounds != -1)
                {
                    Function.Call(Hash.STOP_SOUND, Sounds);
                    Function.Call(Hash.RELEASE_SOUND_ID, Sounds);
                }
                else if (Fires != -1)
                {
                    Function.Call(Hash.REMOVE_SCRIPT_FIRE, Fires);
                }
            }
            catch
            {
                LoggerLight.LogThis("Failed CleanUp, Corrona == " + Corrona + " , Sounds == " + Sounds + " , Fires == " + Fires);
            }
        }
        public static void CreateIni(string sFile, List<string> contance)
        {
            using (StreamWriter tEx = File.CreateText(sFile))
            {
                for (int i = 0; i < contance.Count; i++)
                    WriteObj(contance[i], tEx);
            }
        }
        public static void WriteClothIni(string sFile, ClothX clothfile)
        {
            List<string> MyClothPack = new List<string>
            {
                "[ClothX]",
                "Title=" + clothfile.Title,
                "[ClothA]"
            };
            for (int i = 0; i < clothfile.ClothA.Count; i++)
                MyClothPack.Add("ClothA=" + clothfile.ClothA[i]);

            MyClothPack.Add("[ClothB]");
            for (int i = 0; i < clothfile.ClothB.Count; i++)
                MyClothPack.Add("ClothB=" + clothfile.ClothB[i]);

            MyClothPack.Add("[ExtraA]");
            for (int i = 0; i < clothfile.ExtraA.Count; i++)
                MyClothPack.Add("ExtraA=" + clothfile.ExtraA[i]);

            MyClothPack.Add("[ExtraB]");
            for (int i = 0; i < clothfile.ExtraB.Count; i++)
                MyClothPack.Add("ExtraB=" + clothfile.ExtraB[i]);
            CreateIni(sFile, MyClothPack);
        }
        public static void PlayZeroTargets(Ped PedTarg, Vector3 VecTarg, bool bFlyBy, bool bRamming)
        {
            if (DataStore.ByPassPlayZ)
            {
                if (PedTarg != null)
                {
                    string outPut = "Ped=" + PedTarg.Handle;
                    if (bRamming)
                        outPut = "RamYou=" + PedTarg.Handle;

                    CreateIni(DataStore.sPlayZeroLoc, new List<string> { outPut });
                }
                else
                {
                    string outPut1 = "[Vectors]";

                    if (bFlyBy)
                        outPut1 = "[FlyBy]";
                    string outPut2 = "XLoc=" + VecTarg.X;
                    string outPut3 = "YLoc=" + VecTarg.Y;
                    string outPut4 = "ZLoc=" + VecTarg.Z;

                    CreateIni(DataStore.sPlayZeroLoc, new List<string> { outPut1, outPut2, outPut3, outPut4 });
                }
            }
        }
    }
}