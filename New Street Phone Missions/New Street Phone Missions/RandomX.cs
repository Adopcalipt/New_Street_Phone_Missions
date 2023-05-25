using GTA;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace New_Street_Phone_Missions
{
    public class RandomX
    {
        private static readonly string sRanStore = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RanNums";

        public static List<int> ReturnRandList(string id, int iMin, int iMax)
        {
            LoggerLight.LogThis("ReturnRandList, id == " + id);

            List<int> MyNums = new List<int>();
            RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml");

            if (THisNum.RandNumbers.Count == 0)
                THisNum.RandNumbers = NewList(iMin, iMax);

            MyNums = THisNum.RandNumbers;

            return MyNums;
        }
        public static void ReWiteXml(string id, List<int> MyNums)
        {
            RandX MyNumbers = new RandX();
            MyNumbers.RandNumbers = MyNums;
            SaveXmlRand(MyNumbers, sRanStore + "/" + id + ".xml");
        }
        public static int RandInt(int iMin, int iMax)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, iMin, iMax);
        }
        public static float RandFloat(float fMin, float fMax)
        {
            return Function.Call<int>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);
        }
        public static int FindRandom(string id, int iMin, int iMax)
        {
            LoggerLight.LogThis("FindRandom, id == " + id + ", iMin == " + iMin + ", iMax == " + iMax);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);

            List<int> MyNums = new List<int>();

            int iRandX;

            if (iMin == iMax)
                iRandX = iMin;
            else
            {
                if (File.Exists(sRanStore + "/" + id + ".xml"))
                {
                    RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml");

                    bool newList = false;
                    for (int i = 0; i < THisNum.RandNumbers.Count; i++)
                    {
                        if (THisNum.RandNumbers[i] > iMax)
                        {
                            newList = true;
                            break;
                        }
                        else if (THisNum.RandNumbers[i] < iMin)
                        {
                            newList = true;
                            break;
                        }
                    }

                    if (THisNum.RandNumbers.Count > 0 && !newList)
                        MyNums = THisNum.RandNumbers;
                    else
                        MyNums = NewList(iMin, iMax);
                }
                else
                    MyNums = NewList(iMin, iMax);

                int iRem = RandInt(0, MyNums.Count - 1);
                iRandX = MyNums[iRem];
                MyNums.RemoveAt(iRem);

                ReWiteXml(id, MyNums);
            }
            return iRandX;
        }
        public static int FindRandomList(string id, List<int> MyNums)
        {
            LoggerLight.LogThis("FindRandomList, id == " + id);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);

            int iRandX;

            if (File.Exists(sRanStore + "/" + id + ".xml"))
            {
                bool newList = false;
                RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml");

                for (int i = 0; i < THisNum.RandNumbers.Count; i++)
                {
                    if (MyNums.Contains(THisNum.RandNumbers[i]))
                    {

                    }
                    else
                    {
                        newList = true;
                        break;
                    }
                }

                if (THisNum.RandNumbers.Count > 0 && !newList)
                    MyNums = THisNum.RandNumbers;
            }

            int iRem = RandInt(0, MyNums.Count - 1);
            iRandX = MyNums[iRem];
            MyNums.RemoveAt(iRem);

            ReWiteXml(id, MyNums);
            return iRandX;
        }
        private static List<int> NewList(int iMin, int iMax)
        {
            LoggerLight.LogThis("NewList, iMin == " + iMin + ", iMax == " + iMax);
            List<int> MyNums = new List<int>();
            for (int i = iMin; i < iMax + 1; i++)
                MyNums.Add(i);
            return MyNums;
        }
        private static void SaveXmlRand(RandX config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlRand : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(RandX));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        private static RandX LoadXmlRand(string fileName)
        {
            LoggerLight.LogThis("LoadXmlRand : " + fileName);

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(RandX));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (RandX)xml.Deserialize(sr);
                }
            }
            catch
            {
                LoggerLight.LogThis("Catch ; Corupt File ; ~r~" + fileName);
                return new RandX();
            }
        }
    }
}
