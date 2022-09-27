namespace New_Street_Phone_Missions.Classes
{
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
}
