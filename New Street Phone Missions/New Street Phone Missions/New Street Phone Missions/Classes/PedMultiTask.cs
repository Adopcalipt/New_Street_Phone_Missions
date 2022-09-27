using GTA;
using GTA.Math;

namespace New_Street_Phone_Missions.Classes
{
    public class PedMultiTask
    {
        public Ped MyPed { get; set; }
        public Vehicle MyVehicle { get; set; }
        public Blip MyBlip { get; set; }
        public int MyTask_01 { get; set; }
        public int MyTask_02 { get; set; }
        public int MyTask_03 { get; set; }
        public int MyTimer_01 { get; set; }
        public int MyTimer_02 { get; set; }
        public float MyFloat_01 { get; set; }
        public float MyFloat_02 { get; set; }
        public float MyFloat_03 { get; set; }
        public bool MySwitch_01 { get; set; }
        public bool MySwitch_02 { get; set; }
        public bool MySwitch_03 { get; set; }
        public string MyName { get; set; }

        public Vector3 MyTarget_01 { get; set; }
        public Vector3 MyTarget_02 { get; set; }
    }
}
