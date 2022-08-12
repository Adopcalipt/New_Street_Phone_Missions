namespace New_Street_Phone_Missions.Classes
{
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
        }
    }
}
