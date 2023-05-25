using GTA;
using GTA.Math;
using System.IO;
using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class MuliRace
    {
        public int Zone { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public bool Loop { get; set; }
        public bool SkipCountDown { get; set; }
        public bool MatchAngles { get; set; }
        public float CorSize { get; set; }
        public Vector3 Fubars { get; set; }
        public Vector4 Start01 { get; set; }
        public Vector4 Start02 { get; set; }
        public Vector4 Start03 { get; set; }
        public Vector4 Start04 { get; set; }
        public Vector4 PickVeh { get; set; }
        public List<RacePaths> CheckPoints { get; set; }
        public List<PropLists> PopLists { get; set; }
        public List<int> AvalableVeh { get; set; }
        public RacingLines BaseLap { get; set; }

        public MuliRace()
        {
            Zone = 0;
            Type = 0;
            Name = "";
            Loop = false;
            SkipCountDown = false;
            MatchAngles = false;
            CorSize = 1f;
            Fubars = new Vector3();
            Start01 = new Vector4();
            Start02 = new Vector4();
            Start03 = new Vector4();
            Start04 = new Vector4();
            PickVeh = new Vector4();
            CheckPoints = new List<RacePaths>();
            PopLists = new List<PropLists>();
            AvalableVeh = new List<int>();
            BaseLap = new RacingLines();
        }
        public MuliRace(int zone, int type, string name, bool loop, bool skipCountDown, bool matchAngles, float corSize, Vector3 fubars, Vector4 pickVeh, Vector4 start01, Vector4 start02, Vector4 start03, Vector4 start04, List<RacePaths> checkPoints, List<PropLists> popLists, List<int> avalableVeh, RacingLines baseLap)
        {
            Zone = zone;
            Type = type;
            Name = name;
            Loop = loop;
            SkipCountDown = skipCountDown;
            MatchAngles = matchAngles;
            CorSize = corSize;
            Fubars = fubars;
            Start01 = start01;
            Start02 = start02;
            Start03 = start03;
            Start04 = start04;
            PickVeh = pickVeh;
            CheckPoints = checkPoints;
            PopLists = popLists;
            AvalableVeh = avalableVeh;
            BaseLap = baseLap;
        }
    }
    public class RaceMeet
    {
        public int RacePosition { get; set; }
        public int RacePays { get; set; }
        public int CurrentCheck { get; set; }
        public int BestLap { get; set; }
        public int MyCorrona { get; set; }
        public int CurrentLap { get; set; }
        public int ColorCatch { get; set; }
        public int ColorTime { get; set; }
        public int LapTime { get; set; }
        public int TotalLapTime { get; set; }
        public int PickVeh { get; set; }
        public int DrivinStyle { get; }
        public int ResetBar { get; set; }
        public float CorronaSize { get; }
        public float SpawnDistance { get; }
        public float RacePointDist { get; }
        public bool DisableCapture { get; set; }
        public bool BaseLap { get; set; }
        public bool NewFastest { get; set; }
        public bool SnowIsOn { get; set; }
        public bool ClearTrafic { get; set; }
        public bool BackToZero { get; set; }
        public bool AllTheMatches { get; set; }
        public bool RaceEnd { get; set; }
        public bool StartLine { get; set; }
        public bool MatchPitch { get; set; }
        public bool SmokeOn { get; set; }
        public bool StuntRace { get; set; }
        public bool MarkTheStart { get; set; }
        public bool CycleRace { get; set; }
        public bool BoatRace { get; set; }
        public bool HelicopterRace { get; set; }
        public bool PlaneRace { get; set; }
        public RGBA Smokey { get; set; }
        public Vehicle RaceVeh { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 RaceRecVec { get; set; }
        public List<int> LapTimes { get; set; }
        public List<RacerTasks> Raciers { get; set; }
        public RacingMenu RaceSet { get; set; }
        public MuliRace YourRace { get; }
        public RacingLines BestRL { get; set; }

        private RacingLines Racist_FindLines(MuliRace thePath, RacingMenu YourPick)
        {
            LoggerLight.LogThis("Racist_FindLines thePath.Name == " + thePath.Name);
            RacingLines MyLines = null;
            if (File.Exists(DataStore.sRaceFolder + "/" + ReturnStuff.UnderScoring(thePath.Name) + "_"+ YourPick.VehClass + ".xml"))
                MyLines = ReadWriteXML.LoadRaceLines(DataStore.sRaceFolder + "/" + ReturnStuff.UnderScoring(thePath.Name) + "_" + YourPick.VehClass + ".xml");

            if (MyLines == null)
            {
                if (thePath.BaseLap.Track != thePath.Name)
                {
                    MyLines = new RacingLines(thePath.Name, YourPick.VehClass, thePath.Start02.V3);
                    MyLines.Time = 3600000;
                }
                else
                {
                    MyLines = new RacingLines(thePath.BaseLap.Track, YourPick.VehClass, thePath.BaseLap.Start);
                    MyLines.RaceLine = thePath.BaseLap.RaceLine;
                    MyLines.Time = thePath.BaseLap.Time;
                }
            }
            return MyLines;
        }
        public RaceMeet(RacingMenu yourSettings)
        {
            RaceSet = yourSettings;
            YourRace = MissionData.MyRacists[RaceSet.Race];
            BestRL = Racist_FindLines(YourRace, yourSettings);
            RacePosition = 1;
            RacePays = 0;
            CurrentCheck = 0;
            BestLap = 0;
            MyCorrona = 0;
            CurrentLap = 0;
            ColorCatch = 1;
            ColorTime = 0;
            LapTime = 0;
            TotalLapTime = 0;
            PickVeh = 0;
            ResetBar = 0;
            SpawnDistance = 5f;
            RacePointDist = 5f;
            DrivinStyle = 17039904;
            CorronaSize = YourRace.CorSize;
            DisableCapture = false;
            SnowIsOn = false;
            ClearTrafic = !yourSettings.Trafic;
            BackToZero = false;
            NewFastest = false;
            CycleRace = false;
            BoatRace = false;
            HelicopterRace = false;
            PlaneRace = false;
            RaceEnd = false;
            StartLine = false;
            MatchPitch = false;
            SmokeOn = false;
            StuntRace = false;
            BaseLap = yourSettings.BaseLap;
            AllTheMatches = true;
            MarkTheStart = true;
            Smokey = new RGBA(1);
            RaceVeh = null;
            RaceRecVec = Vector3.Zero;
            Target = YourRace.CheckPoints[0].Pos;
            LapTimes = new List<int>();
            Raciers = new List<RacerTasks>();
            if (YourRace.Type == 2)
                CycleRace = true;
            else if (YourRace.Type == 3)
            {
                SpawnDistance = 10f;
                BoatRace = true;
            }
            else if (YourRace.Type == 4)
            {
                SpawnDistance = 25f;
                HelicopterRace = true;
                RacePointDist = 45f;
            }
            else if (YourRace.Type == 5)
            {
                SpawnDistance = 30f;
                PlaneRace = true;
                RacePointDist = 50f;
            }
        }
    }
    public class RacePaths
    {
        public int Corrona { get; set; }
        public Vector3 Pos { get; set; }
        public Vector3 Rot { get; set; }

        public RacePaths()
        {
            Corrona = 0;
            Pos = new Vector3();
            Rot = new Vector3();
        }
        public RacePaths(int corrona, Vector3 pos, Vector3 rot)
        {
            Corrona = corrona;
            Pos = pos;
            Rot = rot;
        }
    }
    public class RaceRec
    {
        public float Speed { get; set; }
        public Vector3 Pos { get; set; }

        public RaceRec()
        {
            Speed = 1f;
            Pos = new Vector3();
        }
        public RaceRec(float speed, Vector3 pos)
        {
            Speed = speed;
            Pos = pos;
        }
    }
    public class RacerTasks
    {
        public int MyLap { get; set; }
        public int MyCheckPoint { get; set; }
        public int AiCheckPoint { get; set; }
        public int ReturnNo { get; set; }
        public int RaceType { get; set; }
        public bool Collide { get; set; }
        public bool BrakesOn { get; set; }
        public bool OnRoof { get; set; }
        public int BrakeTime { get; set; }
        public int CollideTime { get; set; }
        public int OnRoofTime { get; set; }
        public float TopSpeed { get; set; }
        public Vector4 ReturnTo { get; set; }
        public Vector3 Start { get; set; }
        public Vector3 CheckPoint { get; set; }
        public Vector3 RaceRecTag { get; set; }
        public Ped MyPed { get; set; }
        public Blip MyBlip { get; set; }
        public Vehicle MyVehicle { get; set; }
        public RacingLines TheRacingLine { get; set; }
        public RacingLines Racist_MakeNewPath(RacingLines OldPath, float fMaxSpeed, Vector3 vStart)
        {
            LoggerLight.LogThis("Racist_AddNewPath OldPath laps == " + OldPath.RaceLine.Count);

            RacingLines NewPath = new RacingLines(OldPath.Track, OldPath.VehClass, vStart);

            for (int i = 0; i < OldPath.RaceLine.Count; i++)
            {
                int iRando = RandomX.RandInt(1, 20);
                float fSpeed = (float)iRando / 10;

                if (iRando < 7)
                    NewPath.RaceLine.Add(new RaceRec(OldPath.RaceLine[i].Speed, OldPath.RaceLine[i].Pos.Around(0.1f)));
                else if (iRando < 10 && OldPath.RaceLine[i].Speed > 5f)
                    NewPath.RaceLine.Add(new RaceRec(OldPath.RaceLine[i].Speed - fSpeed, OldPath.RaceLine[i].Pos));
                else if (iRando < 13)
                    NewPath.RaceLine.Add(new RaceRec(OldPath.RaceLine[i].Speed + fSpeed, OldPath.RaceLine[i].Pos));
                else
                    NewPath.RaceLine.Add(new RaceRec(OldPath.RaceLine[i].Speed, OldPath.RaceLine[i].Pos));
            }
            return NewPath;
        }
        public RacerTasks(Ped myped, Vehicle myVeh, RacingLines theRacingLine, Vector3 vStart)
        {
            MyPed = myped;
            MyBlip = myped.CurrentBlip;
            MyVehicle = myVeh;
            CheckPoint = vStart;
            Start = vStart;
            RaceRecTag = theRacingLine.RaceLine[0].Pos;
            MyLap = 0;
            MyCheckPoint = 0;
            AiCheckPoint = 0;
            ReturnNo = 0;
            float speed = ReturnStuff.VehTopSpeed(myVeh);
            if (speed < 10f)
                TopSpeed = 35;
            else
                TopSpeed = speed;
            TheRacingLine = Racist_MakeNewPath(theRacingLine, TopSpeed, vStart);
            Collide = false;
            BrakesOn = false;
            OnRoof = false;
            BrakeTime = 0;
            CollideTime = 0;
            OnRoofTime = 0;
            ReturnTo = new Vector4(myVeh.Position.X, myVeh.Position.Y, myVeh.Position.Z, myVeh.Heading);
        }
    }
    public class RacingLines
    {
        public string Track { get; set; }
        public int VehClass { get; set; }
        public int Time { get; set; }
        public Vector3 Start { get; set; }
        public List<RaceRec> RaceLine { get; set; }

        public RacingLines()
        {
            Track = "";
            VehClass = 1;
            Time = Game.GameTime;
            Start = new Vector3();
            RaceLine = new List<RaceRec>();
        }
        public RacingLines(string track, int vehClass, Vector3 start)
        {
            Track = track;
            VehClass = vehClass;
            Time = Game.GameTime;
            Start = start;
            RaceLine = new List<RaceRec>();
        }
        public RacingLines(string track, int vehClass,int time, Vector3 start, List<RaceRec> raceLine)
        {
            Track = track;
            VehClass = vehClass;
            Time = time;
            Start = start;
            RaceLine = raceLine;
        }
    }
    public class RacingMenu
    {
        public int Race { get; set; }
        public int VehClass { get; set; }
        public int Time { get; set; }
        public bool Trafic { get; set; }
        public int Laps { get; set; }
        public int Anim { get; set; }
        public string Weather { get; set; }
        public bool Solo { get; set; }
        public bool PasiveMode { get; set; }
        public bool BaseLap { get; set; }

        public RacingMenu(int iRace)
        {
            Race = iRace;
            Time = 12;
            Trafic = false;
            Laps = 1;
            Weather = "Any";
            Solo = false;
            VehClass = 0;
            Anim = 0;
            PasiveMode = false;
            BaseLap = false;
        }
    }
}
