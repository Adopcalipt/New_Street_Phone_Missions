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
            RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml", iMin, iMax);

            if (THisNum.RandNumbers.Count == 0)
                THisNum = new RandX(iMin, iMax);

            MyNums = THisNum.RandNumbers;

            return MyNums;
        }
        public static void ReWiteXml(string id, List<int> MyNums)
        {
            RandX MyRando = new RandX(MyNums);
            SaveXmlRand(MyRando, sRanStore + "/" + id + ".xml");
        }
        public static int RandInt(int iMin, int iMax)
        {
            int iRet = iMin;
            if (iMin != iMax)
                iRet = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, iMin, iMax);
            return iRet;
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

            int iRandX;

            RandX THisNum = null;

            if (iMin == iMax)
                iRandX = iMin;
            else
            {
                if (File.Exists(sRanStore + "/" + id + ".xml"))
                {
                    THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml", iMin, iMax);

                    if (THisNum.RandNumbers.Count > 0)
                    {
                        if (THisNum.RandNumbers[0] < iMin)
                            THisNum = new RandX(iMin, iMax);
                        else if (THisNum.RandNumbers.Count > 1)
                        {
                            if (THisNum.RandNumbers[THisNum.RandNumbers.Count - 1] > iMax)
                                THisNum = new RandX(iMin, iMax);
                        }
                    }
                    else
                        THisNum = new RandX(iMin, iMax);
                }
                else
                    THisNum = new RandX(iMin, iMax);



                int iRem = RandInt(0, THisNum.RandNumbers.Count - 1);
                iRandX = THisNum.RandNumbers[iRem];
                THisNum.RandNumbers.RemoveAt(iRem);

                SaveXmlRand(THisNum, sRanStore + "/" + id + ".xml");
            }
            return iRandX;
        }
        public static int FindRandomList(string id, List<int> MyNums)
        {
            LoggerLight.LogThis("FindRandomList, id == " + id);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);

            int iRandX;
            RandX THisNum = null;

            if (File.Exists(sRanStore + "/" + id + ".xml"))
            {
                THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml", -17, 33);
                if (THisNum.Low == -17 && THisNum.High == 33)
                    THisNum = new RandX(MyNums);
                else
                {
                    if (THisNum.RandNumbers.Count > 0)
                    {
                        for (int i = 0; i < THisNum.RandNumbers.Count; i++)
                        {
                            if (MyNums.Contains(THisNum.RandNumbers[i]))
                            {

                            }
                            else
                            {
                                THisNum = new RandX(MyNums);
                                break;
                            }
                        }
                    }
                    else
                        THisNum = new RandX(MyNums);
                }
            }
            else
                THisNum = new RandX(MyNums);

            int iRem = RandInt(0, THisNum.RandNumbers.Count - 1);
            iRandX = THisNum.RandNumbers[iRem];
            THisNum.RandNumbers.RemoveAt(iRem);

            SaveXmlRand(THisNum, sRanStore + "/" + id + ".xml");
            return iRandX;
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
        private static RandX LoadXmlRand(string fileName, int low, int high)
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
                return new RandX(low, high);
            }
        }
    }
}
