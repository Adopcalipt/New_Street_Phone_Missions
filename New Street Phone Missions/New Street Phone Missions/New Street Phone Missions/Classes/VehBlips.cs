namespace New_Street_Phone_Missions.Classes
{
    public struct VehBlips
    {
        public string VehicleKey;
        public int BlipNo;

        public VehBlips(string vehicle, int blipNo)
        {
            VehicleKey = vehicle; BlipNo = blipNo;
        }
    }
}
