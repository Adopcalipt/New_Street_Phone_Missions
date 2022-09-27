using GTA.Native;
using System.IO;
using System.Linq;
using System.Collections.Generic; 

namespace New_Street_Phone_Missions
{
    public class RandomNum
    {
        private static readonly string sRanStore = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RanNums";

        public RandomNum()
        {
            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);
        }
        public static int RandInt(int iMin, int iMax)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, iMin, iMax);
        }
        public static void RandSave(string myRan, string sFile, bool bClear)
        {
            if (bClear)
            {
                using (StreamWriter tEx = File.CreateText(sFile))
                    ObjectLog.WriteObj(myRan, tEx);
            }
            else
            {
                using (StreamWriter tEx = File.AppendText(sFile))
                    ObjectLog.WriteObj(myRan, tEx);
            }
        }
        public static int FindRandom(int iRan, int iMin, int iMax)
        {
            LoggerLight.LogThis("RandomNum.FindRandom, sRan == " + iRan + ", iMin == " + iMin + ", iMax == " + iMax);

            List<int> randList = new List<int>();
            string[] sDirect = Directory.GetFiles(sRanStore);
            string sName = "";
            int iRandX;

            if (iMin == iMax)
            {
                iRandX = iMin;
            }
            else
            {
                for (int i = 0; i < sDirect.Count(); i++)
                {
                    if (sDirect[i].Contains("Rand" + iRan + ".txt"))
                    {
                        sName = sDirect[i];
                        break;
                    }
                }
                if (sName != "")
                {
                    string[] readNote = File.ReadAllLines(sName);
                    if (readNote[0] == "")
                    {
                        for (int i = iMin; i < iMax + 1; i++)
                            randList.Add(i);
                    }
                    else
                    {
                        for (int i = 0; i < readNote.Count(); i++)
                            randList.Add(ObjectLog.ReadMyInt(readNote[i]));
                    }

                    for (int i = 0; i < randList.Count; i++)
                    {
                        if (randList[i] > iMax || randList[i] < iMin)
                            randList.RemoveAt(i);
                    }

                    if (randList.Count == 0)
                    {
                        for (int i = iMin; i < iMax + 1; i++)
                            randList.Add(i);
                    }
                }
                else
                {
                    for (int i = iMin; i < iMax + 1; i++)
                        randList.Add(i);
                }

                int iRem = RandInt(0, randList.Count - 1);
                iRandX = randList[iRem];
                randList.RemoveAt(iRem);
            }

            if (randList.Count == 0)
            {
                for (int i = iMin; i < iMax + 1; i++)
                    randList.Add(i);
            }

            RandSave("" + randList[0], sRanStore + "/Rand" + iRan + ".txt", true);
            for (int i = 1; i < randList.Count; i++)
                RandSave("" + randList[i], sRanStore + "/Rand" + iRan + ".txt", false);

            return iRandX;
        }
    }
}
