using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.IO;

namespace New_Street_Phone_Missions
{
    public class RWDatFile 
    {
        public static void SaveDat(int iChanges, int iChange)
        {
            LoggerLight.LogThis("SaveDat, iChanges == " + iChanges + ",iChange == " + iChange);
            List<int> iData = new List<int>();

            if (File.Exists(DataStore.sNSPMDatafile))
            {
                using (FileStream fs = File.Open(DataStore.sNSPMDatafile, FileMode.Open))
                {
                    try
                    {
                        using (BinaryReader r = new BinaryReader(fs))
                        {
                            iData.Add(r.ReadInt32());       //0
                            iData.Add(r.ReadInt32());       //1
                            iData.Add(r.ReadInt32());       //2
                            iData.Add(r.ReadInt32());       //3
                            iData.Add(r.ReadInt32());       //4
                            iData.Add(r.ReadInt32());       //5
                            iData.Add(r.ReadInt32());       //6
                            iData.Add(r.ReadInt32());       //7
                            iData.Add(r.ReadInt32());       //8
                            iData.Add(r.ReadInt32());       //9
                            iData.Add(r.ReadInt32());       //10
                            iData.Add(r.ReadInt32());       //11
                            iData.Add(r.ReadInt32());       //12
                            iData.Add(r.ReadInt32());       //13
                        }
                    }
                    catch
                    {
                        for (int i = 0; i < 14; i++)
                            iData.Add(0);
                    }
                }

                if (iChanges != -1)
                    iData[iChanges] = iChange;
                using (FileStream fs = File.Open(DataStore.sNSPMDatafile, FileMode.Create))
                {
                    using (BinaryWriter w = new BinaryWriter(fs))
                    {
                        for (int i = 0; i < iData.Count; i++)
                            w.Write(iData[i]);
                    }
                }
            }
            else
            {
                using (FileStream fs = File.Open(DataStore.sNSPMDatafile, FileMode.Create))
                {
                    using (BinaryWriter w = new BinaryWriter(fs))
                    {
                        w.Write(DataStore.MyDatSet.iOwnaYacht);            //0
                        w.Write(DataStore.MyDatSet.iGotPegsus);            //1
                        w.Write(DataStore.MyDatSet.iPegsSafeHeliTest);     //2
                        w.Write(DataStore.MyDatSet.iPegsWarHeliTest);      //3
                        w.Write(DataStore.MyDatSet.iPegsSafePlaneTest);    //4
                        w.Write(DataStore.MyDatSet.iPegsWarPlaneTest);     //5
                        w.Write(DataStore.MyDatSet.iPegsboatsTest);        //6
                        w.Write(DataStore.MyDatSet.iPegsimortasTest);      //7
                        w.Write(DataStore.MyDatSet.iMeddicTest);           //8
                        w.Write(DataStore.MyDatSet.iNSPMBank);             //9
                        w.Write(DataStore.MyDatSet.iNSPMCLowRisk);         //10
                        w.Write(DataStore.MyDatSet.iNSPMCHighRisk);        //11
                        w.Write(DataStore.MyDatSet.iWantedBribe);          //12
                        w.Write(DataStore.MyDatSet.iFubard);               //13
                    }
                }
            }
        }
        public static DatFile LoadDat()
        {
            LoggerLight.LogThis("LoadDat");

            DatFile DamDat = new DatFile();

            if (File.Exists(DataStore.sNSPMDatafile))
            {
                try
                {
                    using (FileStream fs = File.Open(DataStore.sNSPMDatafile, FileMode.Open))
                    {
                        using (BinaryReader r = new BinaryReader(fs))
                        {
                            DamDat.iOwnaYacht = r.ReadInt32();            //0
                            DamDat.iGotPegsus = r.ReadInt32();            //1
                            DamDat.iPegsSafeHeliTest = r.ReadInt32();     //2
                            DamDat.iPegsWarHeliTest = r.ReadInt32();      //3
                            DamDat.iPegsSafePlaneTest = r.ReadInt32();    //4
                            DamDat.iPegsWarPlaneTest = r.ReadInt32();     //5
                            DamDat.iPegsboatsTest = r.ReadInt32();        //6
                            DamDat.iPegsimortasTest = r.ReadInt32();      //7
                            DamDat.iMeddicTest = r.ReadInt32();           //8
                            DamDat.iNSPMBank = r.ReadInt32();             //9
                            DamDat.iNSPMCLowRisk = r.ReadInt32();         //10
                            DamDat.iNSPMCHighRisk = r.ReadInt32();        //11
                            DamDat.iWantedBribe = r.ReadInt32();          //12
                            DamDat.iFubard = r.ReadInt32();               //13
                        }
                    }
                }
                catch
                {
                    DamDat.iOwnaYacht = 0;            //0
                    DamDat.iGotPegsus = 0;            //1
                    DamDat.iPegsSafeHeliTest = 0;     //2
                    DamDat.iPegsWarHeliTest = 0;      //3
                    DamDat.iPegsSafePlaneTest = 0;     //4
                    DamDat.iPegsWarPlaneTest = 0;     //5
                    DamDat.iPegsboatsTest = 0;        //6
                    DamDat.iPegsimortasTest = 0;      //7
                    DamDat.iMeddicTest = 0;           //8
                    DamDat.iNSPMBank = 0;             //9
                    DamDat.iNSPMCLowRisk = 0;         //10
                    DamDat.iNSPMCHighRisk = 0;        //11
                    DamDat.iWantedBribe = 0;          //12
                    DamDat.iFubard = 0;               //13
                }
            }
            else
            {
                DamDat.iOwnaYacht = 0;            //0
                DamDat.iGotPegsus = 0;            //1
                DamDat.iPegsSafeHeliTest = 0;     //2
                DamDat.iPegsWarHeliTest = 0;      //3
                DamDat.iPegsSafePlaneTest =0;     //4
                DamDat.iPegsWarPlaneTest = 0;     //5
                DamDat.iPegsboatsTest = 0;        //6
                DamDat.iPegsimortasTest = 0;      //7
                DamDat.iMeddicTest = 0;           //8
                DamDat.iNSPMBank = 0;             //9
                DamDat.iNSPMCLowRisk = 0;         //10
                DamDat.iNSPMCHighRisk = 0;        //11
                DamDat.iWantedBribe = 0;          //12
                DamDat.iFubard = 0;               //13
            }
            
            return DamDat;
        }
    }
}
