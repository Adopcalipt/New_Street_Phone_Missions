using GTA;
using GTA.Native;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public class ObjectLog
    {
        private static readonly string sAssSave = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/MyAssets.txt";

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
            if (File.Exists(sAssSave))
            {
                LoggerLight.LogThis("ClearThis.HasFile");

                List<Prop> prop = new List<Prop>();
                List<Ped> peds = new List<Ped>();
                List<Blip> blips = new List<Blip>();
                List<Vehicle> vehicles = new List<Vehicle>();
                List<int> coronas = new List<int>();
                List<int> sound = new List<int>();
                List<int> fire = new List<int>();

                string[] readNote = File.ReadAllLines(sAssSave);

                for (int i = 0; i < readNote.Count(); i++)
                {
                    if (readNote[i].Contains("Prop-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        prop.Add(new Prop(MyHand));
                    }
                    else if (readNote[i].Contains("PedX-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        peds.Add(new Ped(MyHand));
                    }
                    else if (readNote[i].Contains("Vehs-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        vehicles.Add(new Vehicle(MyHand));
                    }
                    else if (readNote[i].Contains("Blip-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        blips.Add(new Blip(MyHand));
                    }
                    else if (readNote[i].Contains("Cora-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        coronas.Add(MyHand);
                    }
                    else if (readNote[i].Contains("Soun-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        sound.Add(MyHand);
                    }
                    else if (readNote[i].Contains("Fire-"))
                    {
                        readNote[i].Remove(4);
                        int MyHand = ReadMyInt(readNote[i]);
                        fire.Add(MyHand);
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

                CleanAss();
            }
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
    }
}