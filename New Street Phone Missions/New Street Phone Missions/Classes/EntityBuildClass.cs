using GTA;
using GTA.Math;
using GTA.Native;
using System.Collections.Generic;
using System.Drawing;

namespace New_Street_Phone_Missions.Classes
{
    public class Oufiter
    {
        public int Component { get; set; }
        public int Cloth { get; set; }
        public List<int> Textures { get; set; }

        public Oufiter()
        {
            Component = -1;
            Cloth = -1;
            Textures = new List<int> { -1 };
        }
        public Oufiter(int component, int cloth, List<int> textures)
        {
            Component = component;
            Cloth = cloth;
            Textures = textures;
        }
    }
    public class OufiterTop
    {
        public int Component { get; set; }
        public int Torso { get; set; }
        public int Cloth { get; set; }
        public List<int> Textures { get; set; }

        public OufiterTop()
        {
            Component = 0;
            Torso = 15;
            Cloth = -1;
            Textures = new List<int> { -1 };
        }
        public OufiterTop(int component, int torso, int cloth, List<int> textures)
        {
            Component = component;
            Torso = torso;
            Cloth = cloth;
            Textures = textures;
        }
    }
    public class AnimList
    {
        public string Name { get; set; }
        public string Libary { get; set; }
        public string Intro { get; set; }
        public string Main { get; set; }
        public string Exit { get; set; }

        public AnimList(string name, string libary, string intro, string main, string exit)
        {
            Name = name;
            Libary = libary;
            Intro = intro;
            Main = main;
            Exit = exit;
        }
    }
    public class ISeeYou
    {
        public int LosCount { get; set; }
        public int IdNum { get; set; }
        public Ped ISee { get; set; }
        public SideBar YouSee { get; set; }

        public ISeeYou(int idNum, Ped iSee, SideBar youSee)
        {
            IdNum = idNum;
            LosCount = 10;
            ISee = iSee;
            YouSee = youSee;
        }
    }
    public class Crash4Cash
    {
        public int CurrentDamage { get; set; }
        public int HealthTotal { get; set; }
        public int CashTotal { get; set; }
        public List<Vehicle> VehX { get; set; }
        public List<Ped> PedX { get; set; }

        public Crash4Cash(int healthTotal, int cashTotal, List<Vehicle> vehX, List<Ped> pedX)
        {
            CurrentDamage = 0;
            HealthTotal = healthTotal;
            CashTotal = cashTotal;
            VehX = vehX;
            PedX = pedX;
        }
    }
    public class CorronaForm
    {
        public bool RegCone { get; set; }
        public Vector3 V3Pos { get; set; }
        public Vector3 V3Rot { get; set; }
        public float Radius { get; set; }
        public RGBA CorCol { get; set; }
        public RGBA CorMidCol { get; set; }
        public int CorType { get; set; }

        public CorronaForm(Vector3 pos, bool regCone)
        {
            RegCone = regCone;
            V3Pos = pos;
            V3Rot = Vector3.Zero;
            Radius = 1.0f;
            CorCol = new RGBA(5);
            CorMidCol = new RGBA(3);
            CorType = 47;
        }
        public CorronaForm(Vector3 pos, bool regCone, float radus)
        {
            RegCone = regCone;
            V3Pos = pos;
            V3Rot = Vector3.Zero;
            Radius = radus;
            CorCol = new RGBA(5);
            CorMidCol = new RGBA(3);
            CorType = 47;
        }
        public CorronaForm(Vector3 pos, bool regCone, float radus, int corCol)
        {
            RegCone = regCone;
            V3Pos = pos;
            V3Rot = Vector3.Zero;
            Radius = radus;
            CorCol = new RGBA(corCol);
            CorMidCol = new RGBA(3);
            CorType = 47;
        }
        public CorronaForm(Vector3 pos, Vector3 rot, float radius, int corCol, int corMidCol, int corType)
        {
            RegCone = false;
            V3Pos = pos;
            V3Rot = rot;
            Radius = radius;
            CorCol = new RGBA(corCol);
            CorMidCol = new RGBA(corMidCol);
            CorType = corType;
        }
        public CorronaForm(Vector3 pos, Vector3 rot, float radius, RGBA corCol, RGBA corMidCol, int corType)
        {
            RegCone = false;
            V3Pos = pos;
            V3Rot = rot;
            Radius = radius;
            CorCol = corCol;
            CorMidCol = corMidCol;
            CorType = corType;
        }
        public CorronaForm(Vector3 pos, Vector3 rot, float radius, int corCol, int corMidCol, int corType, float raiseHight)
        {
            RegCone = false;
            pos.Z += raiseHight;
            V3Pos = pos;
            V3Rot = rot;
            Radius = radius;
            CorCol = new RGBA(corCol);
            CorMidCol = new RGBA(corMidCol);
            CorType = corType;
        }
        public CorronaForm(Vector3 pos, Vector3 rot, float radius, RGBA corCol, RGBA corMidCol, int corType, float raiseHight)
        {
            RegCone = false;
            pos.Z += raiseHight;
            V3Pos = pos;
            V3Rot = rot;
            Radius = radius;
            CorCol = corCol;
            CorMidCol = corMidCol;
            CorType = corType;
        }
    }
    public class BlipForm
    {
        public Vector3 V3local { get; set; }
        public string Blip_Tag { get; set; }
        public bool Flasher { get; set; }
        public bool Route { get; set; }
        public int Colour { get; set; }
        public int Icon { get; set; }
        public float Radius { get; set; }
        public string NameTag { get; set; }
        public CorronaForm MyCorrona { get; set; }
        public BlipForm AddDot { get; set; }

        public BlipForm(int colour, string nameTag)
        {
            V3local = new Vector3();
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = false;
            Colour = colour;
            Icon = -1;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(int colour, string nameTag, float radius)
        {
            V3local = new Vector3();
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = false;
            Colour = colour;
            Icon = -1;
            Radius = radius;
            NameTag = nameTag;
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(int colour, string nameTag, bool route)
        {
            V3local = new Vector3();
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = -1;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = true;
            Colour = 5;
            Icon = -1;
            Radius = 1.0f;
            NameTag = "";
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, float radius)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = -1;
            Radius = radius;
            NameTag = "";
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, float radius, BlipForm addDot)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = -1;
            Radius = radius;
            NameTag = "";
            MyCorrona = null;
            AddDot = addDot;
        }
        public BlipForm(Vector3 v3local, bool route, bool flash, float radius)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = flash;
            Route = route;
            Colour = 5;
            Icon = -1;
            Radius = radius;
            NameTag = "";
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, int icon, string nameTag)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = icon;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, int icon, string nameTag, string blip_tag)
        {
            V3local = v3local;
            Blip_Tag = blip_tag;
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = icon;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = null;
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, int icon, string nameTag, float corRadius)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = icon;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = new CorronaForm(v3local, true, corRadius);
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, int icon, string nameTag, float corRadius, float changeZ)
        {
            V3local = new Vector3(v3local.X, v3local.Y, v3local.Z + changeZ);
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = icon;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = new CorronaForm(V3local, true, corRadius);
            AddDot = null;
        }
        public BlipForm(Vector3 v3local, bool route, int colour, int icon, string nameTag, CorronaForm myCorrona)
        {
            V3local = v3local;
            Blip_Tag = "Blip=";
            Flasher = false;
            Route = route;
            Colour = colour;
            Icon = icon;
            Radius = 1.0f;
            NameTag = nameTag;
            MyCorrona = myCorrona;
            AddDot = null;
        }
    }
    public class ClothBank
    {
        public string Name { get; set; }
        public int ModelX { get; set; }
        public ClothX Cothing { get; set; }
        public bool Male { get; set; }
        public bool FreeMode { get; set; }
        public bool BodySuit { get; set; }
        public FaceBank MyFaces { get; set; }
        public HairSets MyHair { get; set; }
        public int HairColour { get; set; }
        public int HairStreaks { get; set; }
        public int EyeColour { get; set; }
        public TShirt MyTag { get; set; }
        public List<FreeOverLay> MyOverlay { get; set; }
        public List<Tattoo> MyTattoo { get; set; }
        public List<float> FaceScale { get; set; }
        public string PedVoice { get; set; }
        private List<FreeOverLay> BuildOverlay(bool male)
        {
            List<FreeOverLay> MyOvers = new List<FreeOverLay>();

            for (int i = 0; i < 12; i++)
            {
                int iColour = 0;
                int iChange = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HEAD_OVERLAY_VALUES, i));
                float fVar = ReturnStuff.RandFlow(0.45f, 0.99f);

                if (i == 0)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Blemishes
                else if (i == 1)
                {
                    if (male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Facial Hair
                else if (i == 2)
                {
                    iChange = RandomX.RandInt(0, iChange);
                    iColour = 1;
                }//Eyebrows
                else if (i == 3)
                {
                    iChange = 255;
                }//Ageing
                else if (i == 4)
                {
                    int iFace = RandomX.RandInt(0, 50);
                    if (iFace < 30)
                    {
                        iChange = RandomX.RandInt(0, 15);
                    }
                    else if (iFace < 45)
                    {
                        iChange = RandomX.RandInt(0, iChange);
                        fVar = ReturnStuff.RandFlow(0.85f, 0.99f);
                    }
                    else
                        iChange = 255;
                }//Makeup
                else if (i == 5)
                {
                    if (!male)
                    {
                        iChange = RandomX.RandInt(0, iChange);
                        fVar = ReturnStuff.RandFlow(0.15f, 0.39f);
                    }
                    else
                        iChange = 255;
                    iColour = 2;
                }//Blush
                else if (i == 6)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Complexion
                else if (i == 7)
                {
                    iChange = 255;
                }//Sun Damage
                else if (i == 8)
                {
                    if (!male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Lipstick
                else if (i == 9)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Moles/Freckles
                else if (i == 10)
                {
                    if (male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Chest Hair
                else if (i == 11)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Body Blemishes

                int AddColour = RandomX.RandInt(0, 64);

                MyOvers.Add(new FreeOverLay(iChange, iColour, fVar));
            }

            return MyOvers;
        }
        private HairSets AddAHair(bool male)
        {
            HairSets Barb;
            if (male)
                Barb = DataStore.MHairsets[RandomX.RandInt(24, DataStore.MHairsets.Count - 1)];
            else
                Barb = DataStore.FHairsets[RandomX.RandInt(25, DataStore.MHairsets.Count - 1)];
            return Barb;
        }
        private List<Tattoo> BuildTats(bool male)
        {
            List<Tattoo> nyOvers = new List<Tattoo>();

            if (RandomX.FindRandom("DoesTats", 0, 10) < 4)
            {
                if (male)
                {
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats01[RandomX.RandInt(0, DataStore.maleTats01.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats02[RandomX.RandInt(0, DataStore.maleTats02.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats03[RandomX.RandInt(0, DataStore.maleTats03.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats04[RandomX.RandInt(0, DataStore.maleTats04.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats05[RandomX.RandInt(0, DataStore.maleTats05.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats06[RandomX.RandInt(0, DataStore.maleTats06.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats07[RandomX.RandInt(0, DataStore.maleTats07.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.maleTats08[RandomX.RandInt(0, DataStore.maleTats08.Count - 1)]);
                }
                else
                {
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats01[RandomX.RandInt(0, DataStore.femaleTats01.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats02[RandomX.RandInt(0, DataStore.femaleTats02.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats03[RandomX.RandInt(0, DataStore.femaleTats03.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats04[RandomX.RandInt(0, DataStore.femaleTats04.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats05[RandomX.RandInt(0, DataStore.femaleTats05.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats06[RandomX.RandInt(0, DataStore.femaleTats06.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats07[RandomX.RandInt(0, DataStore.femaleTats07.Count - 1)]);
                    if (RandomX.RandInt(0, 10) < 5)
                        nyOvers.Add(DataStore.femaleTats08[RandomX.RandInt(0, DataStore.femaleTats08.Count - 1)]);
                }
            }

            return nyOvers;
        }      
        private string MaleOrFemale()
        {
            string sAm = "mp_f_freemode_01";
            if (RandomX.FindRandom("PedFeatMF", 1, 10) < 5)
                sAm = "mp_m_freemode_01";

            return sAm;
        }
        public ClothBank()
        {
            ModelX = 0;
            Cothing = new ClothX();
            FreeMode = false;
            BodySuit = false;
            MyFaces = new FaceBank(Male);
            MyHair = new HairSets();
            HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
            HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
            EyeColour = 0;
            MyTag = new TShirt();
            MyOverlay = BuildOverlay(Male);
            MyTattoo = BuildTats(Male);
            FaceScale = new List<float>();
            PedVoice = "";
        }
        public ClothBank(Ped ThisPed)
        {
            ModelX = ThisPed.Model.Hash;
            FreeMode = false;
            Name = ReturnStuff.WhatpedType();
            if (Name == "FreeFemale")
                FreeMode = true;
            else if (Name == "FreeMale")
                FreeMode = true;

            Cothing = new ClothX(Name, ThisPed);
            Male = ThisPed.Gender == Gender.Male;
            BodySuit = false;
            if (FreeMode)
            {
                MyFaces = new FaceBank(Male);
                HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                EyeColour = 0;
                MyTag = new TShirt();
                MyHair = new HairSets();
                MyOverlay = BuildOverlay(Male);
                MyTattoo = BuildTats(Male);
            }
            else
            {
                MyFaces = null;
                HairColour = 0;
                HairStreaks = 0;
                EyeColour = 0;
                MyTag = null;
                MyHair = null;
                MyOverlay = null;
                MyTattoo = null;
            }

            FaceScale = new List<float>();
            PedVoice = "";
        }
        public ClothBank(int Preset, bool freemode, string name)
        {
            if (name == "")
                name = MaleOrFemale();
            else if (name == "mp_m_freemode_01")
                Male = true;
            else if (name == "mp_f_freemode_01")
                Male = false;

            ModelX = 0;
            Cothing = new ClothX(Preset, Male);
            FreeMode = freemode;

            if (Preset == 2)
                BodySuit = true;
            else
                BodySuit = false;

            if (FreeMode)
            {
                MyFaces = new FaceBank(Male);
                HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                EyeColour = 0;
                MyTag = new TShirt();
                MyHair = AddAHair(Male);
                MyOverlay = BuildOverlay(Male);
                MyTattoo = BuildTats(Male);
            }
            else
            {
                MyFaces = null;
                HairColour = 0;
                HairStreaks = 0;
                EyeColour = 0;
                MyTag = null;
                MyHair = null;
                MyOverlay = null;
                MyTattoo = null;
            }

            FaceScale = new List<float>();
            PedVoice = "";
        }
        public ClothBank(string title, bool bodySuit, bool freeMode, bool male, ClothX cloths)
        {
            Name = title;
            ModelX = 0;
            Cothing = cloths;
            Male = male;
            FreeMode = freeMode;
            BodySuit = bodySuit;
            if (FreeMode)
            {
                MyFaces = new FaceBank(Male);
                HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                EyeColour = 0;
                MyTag = new TShirt();
                MyHair = new HairSets();
                MyOverlay = BuildOverlay(Male);
                MyTattoo = BuildTats(Male);
            }
            else
            {
                MyFaces = null;
                HairColour = 0;
                HairStreaks = 0;
                EyeColour = 0;
                MyTag = null;
                MyHair = null;
                MyOverlay = null;
                MyTattoo = null;
            }

            FaceScale = new List<float>();
            PedVoice = "";
        }
    }
    public class ClothX
    {
        public string Title { get; set; }

        public List<int> ClothA { get; set; }
        public List<int> ClothB { get; set; }

        public List<int> ExtraA { get; set; }
        public List<int> ExtraB { get; set; }

        private ClothX SavedCloths(int pedHash)
        {
            return ReturnStuff.PickAnOutfit(pedHash);
        }
        private ClothX RandomCloths()
        {
            int Torso = 15;
            int Legs = 15;
            int LegsText = 0;
            int Top = -1;
            int TopText = 0;

            int iAcc = RandomX.RandInt(0, DataStore.FeAcc.Count - 1);
            Oufiter AddAcc = DataStore.FeAcc[iAcc];
            int Acc = AddAcc.Cloth;
            int AccText = AddAcc.Textures[RandomX.RandInt(0, DataStore.FeAcc[iAcc].Textures.Count - 1)];

            int Feet = 35;
            int FeetText = 0;
            int RandNumFeet = RandomX.FindRandom("RandomCloths01", 1, 30);
            if (RandNumFeet < 15)
            {
                int iShoe = RandomX.RandInt(0, DataStore.FeShoeHigh.Count - 1);
                Oufiter NewShoes = DataStore.FeShoeHigh[iShoe];
                Feet = NewShoes.Cloth;
                FeetText = NewShoes.Textures[RandomX.RandInt(0, DataStore.FeShoeHigh[iShoe].Textures.Count - 1)];
            }
            else if (RandNumFeet < 20)
            {
                int iShoe = RandomX.RandInt(0, DataStore.FeShoeFlat.Count - 1);
                Oufiter NewShoes = DataStore.FeShoeFlat[iShoe];
                Feet = NewShoes.Cloth;
                FeetText = NewShoes.Textures[RandomX.RandInt(0, DataStore.FeShoeFlat[iShoe].Textures.Count - 1)];
            }


            int RandNum = RandomX.FindRandom("RandomCloths02", 1, 20);
            if (RandNum < 5)
            {
                int iPick = RandomX.RandInt(0, DataStore.FeTops.Count - 1);
                OufiterTop ThisSet = DataStore.FeTops[iPick];
                Torso = ThisSet.Torso;
                Top = ThisSet.Cloth;
                TopText = ThisSet.Textures[RandomX.RandInt(0, DataStore.FeTops[iPick].Textures.Count - 1)];
            }
            else if (RandNum < 10)
            {
                int iPick = RandomX.RandInt(0, DataStore.FeTrousers.Count - 1);
                Oufiter ThisSet = DataStore.FeTrousers[iPick];
                Legs = ThisSet.Cloth;
                LegsText = ThisSet.Textures[RandomX.RandInt(0, DataStore.FeTrousers[iPick].Textures.Count - 1)];
            }

            return new ClothX("MyOuts", new List<int> { 0, 0, 0, Torso, Legs, 0, Feet, Acc, -1, 0, 0, Top }, new List<int> { 0, 0, 0, 0, LegsText, 0, FeetText, AccText, 0, 0, 0, TopText }, new List<int>(), new List<int>());
        }


        public ClothX()
        {
            Title = "";
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();
        }
        public ClothX(string title, Ped ThisPed)
        {
            Title = title;
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();

            for (int i = 0; i < 12; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, ThisPed.Handle, i);
                ClothA.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, ThisPed.Handle, i);
                ClothB.Add(iTextId);
            }

            for (int i = 0; i < 8; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, ThisPed.Handle, i);
                ExtraA.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, ThisPed.Handle, i);
                ExtraB.Add(iTextId);
            }
        }
        public ClothX(int Preset, bool male)
        {
            if (male)
            {
                if (Preset == 2)
                {
                    Title = "Alien";
                    ClothA = new List<int> { 0, 134, 0, 3, 106, 0, 83, 0, -1, 0, 0, 274 };
                    ClothB = new List<int> { 0, 8, 0, 0, 8, 0, 0, 0, 0, 0, 0, 8 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();
                }
                else if (Preset == 3)
                {
                    int iBe = RandomX.RandInt(0, 9);
                    int iAm = RandomX.RandInt(35, 68);
                    Title = "Parra";
                    ClothA = new List<int> { 0, -1, iAm, 102, 59, 52, 24, 0, 15, 0, 0, 54 };
                    ClothB = new List<int> { 0, 0, 0, 0, iBe, iBe, 0, 0, 0, 0, 0, 0 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();

                }
                else if (Preset == 4)
                {
                    int iMaskPos = RandomX.FindRandom("OLPSet4af", 0, DataStore.FMMasks.Count - 1);
                    int iMask = DataStore.FMMasks[iMaskPos].Cloth;
                    int iMasktext = DataStore.FMMasks[iMaskPos].Textures[RandomX.RandInt(0, DataStore.FMMasks[iMaskPos].Textures.Count - 1)];

                    Title = "BankRobber";
                    ClothA = new List<int> { 0, iMask, -1, -1, 135, 45, 12, -1, -1, -1, -1, 364 };
                    ClothB = new List<int> { 0, iMasktext, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();

                }
                else
                {
                    ClothX YourCloth = SavedCloths(PedHash.FreemodeMale01.GetHashCode());
                    Title = YourCloth.Title;
                    ClothA = YourCloth.ClothA;
                    ClothB = YourCloth.ClothB;
                    ExtraA = YourCloth.ExtraA;
                    ExtraB = YourCloth.ExtraB;

                }
            }
            else
            {
                if (Preset == 2)
                {
                    Title = "Alien";
                    ClothA = new List<int> { 0, 134, 0, 13, 113, 0, 87, -1, -1, 0, 0, 287 };
                    ClothB = new List<int> { 0, 8, 0, 0, 8, 0, 8, 0, 0, 0, 0, 8 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();

                }
                else if (Preset == 3)
                {
                    int iBe = RandomX.RandInt(0, 9);
                    int iAm = RandomX.RandInt(37, 80);

                    Title = "Parra";
                    ClothA = new List<int> { 0, 0, iAm, 117, 61, 52, 24, 0, 3, 0, 0, 47 };
                    ClothB = new List<int> { 0, 0, 0, iBe, iBe, iBe, 0, 0, 0, 0, 0, 0 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();

                }
                else if (Preset == 4)
                {
                    int iMaskPos = RandomX.FindRandom("OLPSet4af", 0, DataStore.FFMasks.Count - 1);
                    int iMask = DataStore.FFMasks[iMaskPos].Cloth;
                    int iMasktext = DataStore.FFMasks[iMaskPos].Textures[RandomX.RandInt(0, DataStore.FFMasks[iMaskPos].Textures.Count - 1)];
                    Title = "BankRobber";
                    ClothA = new List<int> { 0, iMask, 10, 3, 39, -1, 26, -1, 14, -1, -1, 60 };
                    ClothB = new List<int> { 0, iMasktext, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2 };
                    ExtraA = new List<int>();
                    ExtraB = new List<int>();

                }
                else
                {
                    ClothX YourCloth = SavedCloths(PedHash.FreemodeFemale01.GetHashCode());
                    Title = YourCloth.Title;
                    ClothA = YourCloth.ClothA;
                    ClothB = YourCloth.ClothB;
                    ExtraA = YourCloth.ExtraA;
                    ExtraB = YourCloth.ExtraB;

                }
            }
        }
        public ClothX(string title, List<int> clothA, List<int> clothB, List<int> extraA, List<int> extraB)
        {
            Title = title;
            ClothA = clothA;
            ClothB = clothB;
            ExtraA = extraA;
            ExtraB = extraB;
        }
    }
    public class FaceBank
    {
        public int XshapeFirstID { get; set; }
        public int XshapeSecondID { get; set; }
        public int XshapeThirdID { get; set; }
        public int XskinFirstID { get; set; }
        public int XskinSecondID { get; set; }
        public int XskinThirdID { get; set; }
        public float XshapeMix { get; set; }
        public float XskinMix { get; set; }
        public float XthirdMix { get; set; }
        public int XisParent { get; set; }

        public FaceBank()
        {
            XshapeFirstID = 0;
            XshapeSecondID = 0;
            XshapeThirdID = 0;
            XskinFirstID = 0;
            XskinSecondID = 0;
            XskinThirdID = 0;
            XshapeMix = 0f;
            XskinMix = 0f;
            XthirdMix = 0f;
            XisParent = 0;
        }
        public FaceBank(bool male)
        {
            if (male)
            {
                XshapeFirstID = RandomX.RandInt(0, 20);
                XshapeSecondID = RandomX.RandInt(0, 20);
                XshapeThirdID = XshapeFirstID;
                XskinFirstID = XshapeFirstID;
                XskinSecondID = XshapeSecondID;
                XskinThirdID = XshapeThirdID;
            }
            else
            {
                XshapeFirstID = RandomX.RandInt(21, 41);
                XshapeSecondID = RandomX.RandInt(21, 41);
                XshapeThirdID = XshapeFirstID;
                XskinFirstID = XshapeFirstID;
                XskinSecondID = XshapeSecondID;
                XskinThirdID = XshapeThirdID;
            }

            XshapeMix = ReturnStuff.RandFlow(-0.9f, 0.9f);
            XskinMix = ReturnStuff.RandFlow(0.9f, 0.99f);
            XthirdMix = ReturnStuff.RandFlow(-0.9f, 0.9f);
            XisParent = 0;
        }
    }
    public class Tattoo
    {
        public string BaseName { get; set; }
        public string TatName { get; set; }
        public string Name { get; set; }

        public Tattoo()
        {
            BaseName = "";
            TatName = "";
            Name = "";
        }
        public Tattoo(string baseName, string tatName, string name)
        {
            BaseName = baseName;
            TatName = tatName;
            Name = name;
        }
    }
    public class TShirt
    {
        public string BaseName { get; set; }
        public string ShirtName { get; set; }
        public string Name { get; set; }

        public TShirt()
        {
            BaseName = "";
            ShirtName = "";
            Name = "";
        }

        public TShirt(string baseName, string shirtName, string name)
        {
            BaseName = baseName;
            ShirtName = shirtName;
            Name = name;
        }
    }
    public class HairSets
    {
        public int Comp { get; set; }
        public int Text { get; set; }
        public string HandName { get; set; }
        public string Name { get; set; }
        public int OverLib { get; set; }
        public int Over { get; set; }

        public HairSets()
        {
            Comp = 0;
            Text = 0;
            HandName = "";
            Name = "";
            OverLib = 0;
            Over = 0;
        }
        public HairSets(int comp, int text, string handName, string name, int overLib, int over)
        {
            Comp = comp;
            Text = text;
            HandName = handName;
            Name = name;
            OverLib = overLib;
            Over = over;
        }
    }
    public class FreeOverLay
    {
        public int Overlay { get; set; }
        public int OverCol { get; set; }
        public float OverOpc { get; set; }

        public FreeOverLay()
        {
            Overlay = 0;
            OverCol = 0;
            OverOpc = 0f;
        }
        public FreeOverLay(int overlay, int overCol, float overOpc)
        {
            Overlay = overlay;
            OverCol = overCol;
            OverOpc = overOpc;
        }
    }
    public class FindSeat
    {
        public float Run { get; set; }
        public int Seat { get; set; }
        public int Stage { get; set; }
        public Vehicle CarSeat { get; set; }
        public Ped ThisPed { get; set; }

        public FindSeat(int seat, Vehicle carSeat, Ped thisPed, float run)
        {
            Run = run;
            Seat = seat;
            Stage = 1;
            CarSeat = carSeat;
            ThisPed = thisPed;
        }
    }
    public class FindVeh
    {
        public float MinRadi { get; set; }
        public float MaxRadi { get; set; }
        public Vector3 Area { get; set; }
        public VehMods VehModel { get; set; }
        public bool Driver { get; set; }
        public bool Near { get; set; }

        public FindVeh(float minRadi, float maxRadi, Vector3 area, VehMods vehModel)
        {
            MinRadi = minRadi;
            MaxRadi = maxRadi;
            Area = area;
            VehModel = vehModel;
            Driver = true;
            Near = false;
        }
        public FindVeh(float minRadi, float maxRadi, Vector3 area, VehMods vehModel, bool driver)
        {
            MinRadi = minRadi;
            MaxRadi = maxRadi;
            Area= area;
            VehModel = vehModel;
            Driver = driver;
            Near = false;
        }
        public FindVeh(float minRadi, float maxRadi, Vector3 area, VehMods vehModel, bool driver, bool near)
        {
            MinRadi = minRadi;
            MaxRadi = maxRadi;
            Area = area;
            VehModel = vehModel;
            Driver = driver;
            Near = near;
        }
    }
    public class FindPed
    {
        public float MinRadi { get; set; }
        public float MaxRadi { get; set; }
        public int Count { get; set; }
        public bool OnePass { get; set; }
        public Vector3 Target { get; set; }
        public PedFeat ThisFeat { get; set; }


        public FindPed(float minRadi, float maxRadi, PedFeat thisFeat)
        {
            MinRadi = minRadi;
            MaxRadi = maxRadi;
            Count = 1;
            OnePass = true;
            Target = Vector3.Zero;
            ThisFeat = thisFeat;
        }
        public FindPed(float minRadi, float maxRadi, int count, bool onePass, Vector3 target, PedFeat thisFeat)
        {
            MinRadi = minRadi;
            MaxRadi = maxRadi;
            Count = count;
            OnePass = onePass;
            Target = target;
            ThisFeat = thisFeat;
        }
    }
    public class PedFeat
    {
        public string MyPed { get; set; }
        public string PedTag { get; set; }
        public int ImyPed { get; set; }
        public bool Armor { get; set; }
        public int Health { get; set; }
        public int Task { get; set; }
        public int MySeat { get; set; }
        public Vehicle MyVeh { get; set; }
        public int MyGun { get; set; }
        public BlipForm Blippy { get; set; }
        public ClothBank MyWard { get; set; }

        private string MaleOrFemale()
        {
            string sAm = "mp_f_freemode_01"; ;
            if (RandomX.FindRandom("PedFeatMF", 1, 10) < 5)
                sAm = "mp_m_freemode_01";     
            return sAm;
        }

        public PedFeat(bool addBlip, int blipCol, string blipName)
        {
            MyPed = MaleOrFemale();
            PedTag = "PedX=";
            ImyPed = -1;
            MyWard = new ClothBank(0, true, MyPed);
            Armor = true;
            Health = 180;
            Task = 0;
            MySeat = 0;
            MyVeh = null;
            MyGun = 0;

            if (addBlip)
                Blippy = new BlipForm(blipCol, blipName);
            else
                Blippy = null;
        }
        public PedFeat(string myPed)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = false;
            Health = 200;
            Task = 0;
            MySeat = -10;
            MyVeh = null;
            MyGun = 0;
            Blippy = null;
        }
        public PedFeat(string myPed, int task)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = false;
            Health = 200;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = 0;
            Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = 0;
            Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int myGun)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = myGun;
            Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int myGun, int preset)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(preset, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = new ClothBank(preset, false, MyPed);
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = myGun;
            Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int myGun, ClothBank ward)
        {
            MyPed = myPed;
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = myGun;
            Blippy = null;
            MyWard = ward;
        }
        public PedFeat(int iMyPed, bool armor, int health, int task, int myGun, ClothBank ward)
        {
            MyPed = "";
            PedTag = "PedX-";
            ImyPed = iMyPed;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = -10;
            MyVeh = null;
            MyGun = myGun;
            Blippy = null;
            MyWard = ward;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int seat, Vehicle myCar, int myGun)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            MyPed = myPed;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = seat;
            MyVeh = myCar;
            MyGun = myGun;
            Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int seat, Vehicle myCar, int myGun, bool addblip, int blipCol, string blipName)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(0, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = null;
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = seat;
            MyVeh = myCar;
            MyGun = myGun;
            if (addblip)
                Blippy = new BlipForm(blipCol, blipName);
            else
                Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int seat, Vehicle myCar, int myGun, bool addblip, int blipCol, string blipName, int preset)
        {
            if (myPed == "")
            {
                MyPed = MaleOrFemale();
                MyWard = new ClothBank(preset, true, MyPed);

            }
            else
            {
                MyPed = myPed;
                MyWard = new ClothBank(preset, false, MyPed);
            }
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = seat;
            MyVeh = myCar;
            MyGun = myGun;
            if (addblip)
                Blippy = new BlipForm(blipCol, blipName);
            else
                Blippy = null;
        }
        public PedFeat(string myPed, bool armor, int health, int task, int seat, Vehicle myCar, int myGun, bool addblip, int blipCol, string blipName, ClothBank myWard)
        {
            MyPed = myPed;
            PedTag = "PedX-";
            ImyPed = -1;
            Armor = armor;
            Health = health;
            Task = task;
            MySeat = seat;
            MyVeh = myCar;
            MyGun = myGun;
            if (addblip)
                Blippy = new BlipForm(blipCol, blipName);
            else
                Blippy = null;
            MyWard = myWard;
        }
    }
    public class DanceMoves
    {
        public string DanceType { get; set; }
        public string Dance { get; set; }

        public DanceMoves(string danceType, string dance)
        {
            DanceType = danceType; Dance = dance;
        }
    }
    public class MarkyMark
    {
        public MarkerType MarkType { get; set; }
        public Vector3 MarkPos { get; set; }
        public Vector3 MarkDir { get; set; }
        public Vector3 MarkRot { get; set; }
        public Vector3 MarkScale { get; set; }
        public Color MarkCol { get; set; }

        public MarkyMark(Vehicle followMe, float fHigh, Color markCol)
        {
            MarkType = MarkerType.ChevronUpx1;
            MarkPos = new Vector3(followMe.Position.X, followMe.Position.Y, followMe.Position.Z + fHigh);
            MarkDir = Vector3.Zero;
            MarkRot = new Vector3(0.00f, 180.00f, followMe.Heading);
            MarkScale = new Vector3(1.00f, 1.00f, 1.00f);
            MarkCol = markCol;
        }
        public MarkyMark(Ped followMe, float fHigh, Color markCol)
        {
            MarkType = MarkerType.ChevronUpx1;
            MarkPos = new Vector3(followMe.Position.X, followMe.Position.Y, followMe.Position.Z + fHigh);
            MarkDir = Vector3.Zero;
            MarkRot = new Vector3(0.00f, 180.00f, followMe.Heading);
            MarkScale = new Vector3(1.00f, 1.00f, 1.00f);
            MarkCol = markCol;
        }
        public MarkyMark(MarkerType markType, Vector3 markPos, Vector3 markDir, float markRot, float markScale, Color markCol)
        {
            MarkType = markType;
            MarkPos = markPos;
            MarkDir = markDir;
            MarkRot = new Vector3(0.00f, 180.00f, markRot);
            MarkScale = new Vector3(markScale, markScale, markScale);
            MarkCol = markCol;
        }
        public MarkyMark(MarkerType markType, Vector4 markPos, Vector3 markDir, float markScale, Color markCol)
        {
            MarkType = markType;
            MarkPos = markPos.V3;
            MarkDir = markDir;
            MarkRot = new Vector3(0.00f, 180.00f, markPos.R);
            MarkScale = new Vector3(markScale, markScale, markScale);
            MarkCol = markCol;
        }
    }
    public class PedMultiTask
    {
        public Ped MyPed { get; set; }
        public Vehicle MyVehicle { get; set; }
        public Blip MyBlip { get; set; }
        public int RaceLineInt { get; set; }
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

        public List<Vector3> MyVectorList { get; set; }

        public ISeeYou MySpots { get; set; }

        public PedMultiTask(Ped myped, Vehicle myVeh, int blipColour)
        {
            MyPed = myped;
            MyVehicle = myVeh;
            MyBlip = myped.CurrentBlip;
            RaceLineInt = 0;
            MyTask_01 = blipColour;
            MyTask_02 = -1;
            MyTask_03 = -1;
            MyTimer_01 = -1;
            MyTimer_02 = -1;
            MyFloat_01 = 0f;
            MyFloat_02 = 0f;
            MyFloat_03 = 0f;
            MySwitch_01 = false;
            MySwitch_02 = false;
            MySwitch_03 = false;
            MyName = "";

            MyTarget_01 = Vector3.Zero;
            MyTarget_02 = Vector3.Zero;
            MyVectorList = new List<Vector3>();
            MySpots = null;
        }
        public PedMultiTask(Ped myped, bool mySwitch_01)
        {
            MyPed = myped;
            MyVehicle = null;
            MyBlip = myped.CurrentBlip;
            RaceLineInt = 0;
            MyTask_01 = 0;
            MyTask_02 = -1;
            MyTask_03 = -1;
            MyTimer_01 = -1;
            MyTimer_02 = -1;
            MyFloat_01 = 0f;
            MyFloat_02 = 0f;
            MyFloat_03 = 0f;
            MySwitch_01 = mySwitch_01;
            MySwitch_02 = false;
            MySwitch_03 = false;
            MyName = "";

            MyTarget_01 = Vector3.Zero;
            MyTarget_02 = Vector3.Zero;
            MyVectorList = new List<Vector3>();
            MySpots = null;
        }
    }
    public class PropLists
    {
        public string Prop { get; set; }
        public Vector3 Pos { get; set; }
        public Vector3 Rot { get; set; }

        public PropLists()
        {
            Prop = "";
            Pos = new Vector3();
            Rot = new Vector3();
        }
        public PropLists(string prop, Vector3 pos, Vector3 rot)
        {
            Prop = prop;
            Pos = pos;
            Rot = rot;
        }
    }
    public class VehBlips
    {
        public string VehicleKey;
        public int BlipNo;

        public VehBlips()
        {
            VehicleKey = ""; BlipNo = 0;
        }
        public VehBlips(string vehicle, int blipNo)
        {
            VehicleKey = vehicle; BlipNo = blipNo;
        }
    }
    public class VehCol
    {
        public int Col01;
        public int Col02;

        public VehCol()
        {
            Col01 = 0;
            Col02 = 0;
        }
        public VehCol(int col01, int col02)
        {
            Col01 = col01;
            Col02 = col02;
        }
    }
    public class VehMods
    {
        public string MyVehicle { get; set; }
        public string VehTag { get; set; }
        public int Task { get; set; }
        public int Paint1 { get; set; }
        public int Paint2 { get; set; }
        public int Livery { get; set; }
        public string NumberPlate { get; set; }
        public VehNeons Neons { get; set; }
        public int ModelHash { get; set; }
        public BlipForm Blippy { get; set; }
        public bool Frozen { get; set; }
        public bool RemoveExtras { get; set; }
        public List<int> MyVehMods { get; set; }
        public List<int> MyVehExtras { get; set; }

        private List<string> AddToBen()
        {
            List<string> BenPlus = ReturnStuff.BennysVeh;

            BenPlus.Add("FORMULA");
            BenPlus.Add("FORMULA2");
            BenPlus.Add("OPENWHEEL1");
            BenPlus.Add("OPENWHEEL2");

            return BenPlus;
        }
        public VehMods(Vehicle cloneVeh, int functions)
        {
            int iLv = Function.Call<int>(Hash.GET_VEHICLE_LIVERY, cloneVeh.Handle);
            if (iLv == -1)
                iLv = -10;
            VehCol MyCol = ReturnStuff.VehColorCatch(cloneVeh);
            MyVehicle = "GetPlayersVeh";
            VehTag = "Vehs=";
            Task = functions;
            Paint1 = MyCol.Col01;
            Paint2 = MyCol.Col02;
            Livery = iLv;
            NumberPlate = Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, cloneVeh.Handle);
            Neons = ColectNeons(cloneVeh);
            ModelHash = cloneVeh.Model.Hash;
            Blippy = null;
            Frozen = false;
            RemoveExtras = false;
            MyVehMods = ColectMods(cloneVeh);
            MyVehExtras = ColectExtras(cloneVeh);
        }
        public VehMods(string myVehicle)
        {
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = 0;
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            NumberPlate = "";
            Neons = new VehNeons();
            ModelHash = -1;
            Blippy = null;
            Frozen = false;
            RemoveExtras = false;
            MyVehMods = new List<int>();
            MyVehExtras = new List<int>(); 
        }
        public VehMods(string myVehicle, int functions)
        {
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            NumberPlate = "";
            Neons = new VehNeons();
            ModelHash = -1;
            Blippy = null;
            Frozen = false;
            RemoveExtras = false;
            MyVehMods = new List<int>();
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, bool frozen)
        {
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            NumberPlate = "";
            Neons = new VehNeons();
            ModelHash = -1;
            Blippy = null;
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = new List<int>();
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, bool frozen, bool addMods, string numberPlate)
        {
            List<int> myVehMods = new List<int>();
            VehTag = "Vehs-";
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            Neons = new VehNeons();
            if (addMods)
            {
                bool bBennys = false;
                List<string> Benney = AddToBen();
                for (int i = 0; i < Benney.Count; i++)
                {
                    if (Function.Call<int>(Hash.GET_HASH_KEY, myVehicle) == Function.Call<int>(Hash.GET_HASH_KEY, Benney[i]))
                    {
                        myVehMods = VehModBennys(-1, -1, -1);
                        bBennys = true;
                        break;
                    }
                }
                if (!bBennys)
                    myVehMods = VehMod(-1, -1, -1);

                Paint1 = myVehMods[66];
                Paint2 = myVehMods[67];
                Livery = myVehMods[48];

                Neons = RandomNeon();
            }
            MyVehicle = myVehicle;
            Task = functions;
            NumberPlate = numberPlate;
            ModelHash = -1;
            Blippy = null;
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = myVehMods;
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName)
        {
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            NumberPlate = "";
            Neons = new VehNeons();
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = false;
            RemoveExtras = false;
            MyVehMods = new List<int>();
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName, bool frozen)
        {
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            NumberPlate = "";
            Neons = new VehNeons();
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = new List<int>();
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName, bool frozen, bool addMods, string numberPlate)
        {
            List<int> myVehMods = new List<int>();

            Paint1 = -10;
            Paint2 = -10;
            Livery = -10;
            Neons = new VehNeons();
            if (addMods)
            {
                bool bBennys = false;
                List<string> Benney = AddToBen();
                for (int i = 0; i < Benney.Count; i++)
                {
                    if (Function.Call<int>(Hash.GET_HASH_KEY, myVehicle) == Function.Call<int>(Hash.GET_HASH_KEY, Benney[i]))
                    {
                        myVehMods = VehModBennys(-1, -1, -1);
                        bBennys = true;
                        break;
                    }
                }
                if (!bBennys)
                    myVehMods = VehMod(-1, -1, -1);

                Paint1 = myVehMods[66];
                Paint2 = myVehMods[67];
                Livery = myVehMods[48];

                Neons = RandomNeon();
            }
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            NumberPlate = numberPlate;
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = myVehMods;
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName, bool frozen, bool addMods, int paint1, int paint2, int livery, string numberPlate)
        {
            LoggerLight.LogThis("VehMods myVehicle ==" + myVehicle);
            List<int> myVehMods = new List<int>();

            Neons = new VehNeons();
            if (addMods)
            {
                bool bBennys = false;
                List<string> Benney = AddToBen();
                for (int i = 0; i < Benney.Count; i++)
                {
                    if (Function.Call<int>(Hash.GET_HASH_KEY, myVehicle) == Function.Call<int>(Hash.GET_HASH_KEY, Benney[i]))
                    {
                        myVehMods = VehModBennys(paint1, paint2, livery);
                        bBennys = true;
                        break;
                    }
                }
                if (!bBennys)
                    myVehMods = VehMod(paint1, paint2, livery);

                Neons = RandomNeon();
            }
            else
                myVehMods = ReturnStuff.VehPaint(paint1, paint2, livery);

            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Paint1 = paint1;
            Paint2 = paint2;
            Livery = livery;
            Task = functions;
            NumberPlate = numberPlate; ;
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = myVehMods;
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName, bool frozen, bool addMods, int paint1, int paint2, int livery, bool removeExtras, string numberPlate)
        {
            LoggerLight.LogThis("VehMods myVehicle ==" + myVehicle);
            List<int> myVehMods = new List<int>();

            Neons = new VehNeons();
            if (addMods)
            {
                bool bBennys = false;
                List<string> Benney = AddToBen();
                for (int i = 0; i < Benney.Count; i++)
                {
                    if (Function.Call<int>(Hash.GET_HASH_KEY, myVehicle) == Function.Call<int>(Hash.GET_HASH_KEY, Benney[i]))
                    {
                        myVehMods = VehModBennys(paint1, paint2, livery);
                        bBennys = true;
                        break;
                    }
                }
                if (!bBennys)
                    myVehMods = VehMod(paint1, paint2, livery);

                Neons = RandomNeon();
            }
            else
                myVehMods = ReturnStuff.VehPaint(paint1, paint2, livery);

            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Paint1 = paint1;
            Paint2 = paint2;
            Livery = livery;
            Task = functions;
            NumberPlate = numberPlate;
            RemoveExtras = removeExtras; 
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = frozen;
            MyVehMods = myVehMods;
            MyVehExtras = new List<int>();
        }
        public VehMods(string myVehicle, int functions, int blipCol, bool route, string mapName, bool frozen, List<int> myMods, List<int> myVehExtras, string numberPlate)
        {
            Neons = RandomNeon();
            MyVehicle = myVehicle;
            VehTag = "Vehs-";
            Task = functions;
            NumberPlate = numberPlate;
            ModelHash = -1;
            if (blipCol == -1)
                Blippy = null;
            else
                Blippy = new BlipForm(blipCol, mapName, route);
            Frozen = frozen;
            RemoveExtras = false;
            MyVehMods = myMods;
            MyVehExtras = myVehExtras;
        }
        private List<int> VehModBennys(int paint1, int paint2, int livery)
        {
            List<int> MyMods = new List<int>
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 3, 2, 2, -1, 3, 4, -10, 0, -10, -10, -10, 0, -1, -10, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -10, livery, -10, -10, -10, -10, -1, -10, -1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, paint1, paint2
            };
            return MyMods;
        }
        private List<int> VehMod(int paint1, int paint2, int livery)
        {
            List<int> MyMods = new List<int>
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 3, 2, 2, -1, 3, 4, -10, 0, -10, -10, -10, 0, -1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, livery, -10, -10, -10, -10, -1, -10, -1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, paint1, paint2
            };
            return MyMods;
        }
        private List<int> ColectMods(Vehicle thisVeh)
        {
            List<int> MyMods = new List<int>();
            for (int i = 0; i < 68; i++)
            {
                MyMods.Add(Function.Call<int>(Hash.GET_VEHICLE_MOD, thisVeh.Handle, i));
            }
            return MyMods; ;
        }
        private List<int> ColectExtras(Vehicle thisVeh)
        {
            List<int> MyExt = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, thisVeh.Handle, i))
                    MyExt.Add(i);
            }
            return MyExt; ;
        }
        private VehNeons ColectNeons(Vehicle thisVeh)
        {
            VehNeons thisNeon = new VehNeons();

            if (Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, thisVeh.Handle, 0))//Left
                thisNeon.Left = true;

            if (Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, thisVeh.Handle, 1))//Right
                thisNeon.Right = true;

            if (Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, thisVeh.Handle, 2))//Front
                thisNeon.Front = true;

            if (Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, thisVeh.Handle, 3))//Back
                thisNeon.Rear = true;

            if (thisNeon.Left || thisNeon.Right || thisNeon.Front || thisNeon.Rear)
            {
                thisNeon.Enable = true;
                thisNeon.RGBA = ReturnStuff.VehNeonCatch(thisVeh);
            }

            return thisNeon;
        }
        private VehNeons RandomNeon()
        {
            VehNeons thisNeon = new VehNeons();

            int iNeo = RandomX.FindRandom("VehMods01", 1, 10);
            if (iNeo == 1)
            {
                thisNeon.Enable = true;
                thisNeon.Left = true;
                thisNeon.Right = true;
                thisNeon.RGBA = new RGBA(RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), 255);
            }
            else if (iNeo == 2)
            {
                thisNeon.Enable = true;
                thisNeon.Front = true;
                thisNeon.Rear = true;
                thisNeon.RGBA = new RGBA(RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), 255);
            }
            else if (iNeo == 3)
            {
                thisNeon.Enable = true;
                thisNeon.Left = true;
                thisNeon.Right = true;
                thisNeon.Front = true;
                thisNeon.Rear = true;
                thisNeon.RGBA = new RGBA(RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), RandomX.RandInt(0, 255), 255);
            }

            return thisNeon;
        }
    }
    public class VehNeons
    {
        public bool Enable;
        public bool Front;
        public bool Rear;
        public bool Left;
        public bool Right;
        public RGBA RGBA;

        public VehNeons()
        {
            Enable = false;
            Front = false;
            Rear = false;
            Left = false;
            Right = false;
            RGBA = new RGBA();
        }
    }
    public struct RGBA
    {
        public int R;
        public int G;
        public int B;
        public int A;

        public RGBA(int Preset)
        {
            if (Preset == 1)
            {
                R = 224;
                G = 58;
                B = 58;
            }//red
            else if (Preset == 2)
            {
                R = 121;
                G = 205;
                B = 121;
            }//green
            else if (Preset == 3)
            {
                R = 101;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 4)
            {
                R = 241;
                G = 241;
                B = 241;
            }//Grey
            else if (Preset == 5)
            {
                R = 240;
                G = 203;
                B = 88;
            }//yelllow
            else if (Preset == 6)
            {
                R = 198;
                G = 88;
                B = 88;
            }//moave
            else if (Preset == 7)
            {
                R = 161;
                G = 117;
                B = 180;
            }//purple
            else if (Preset == 8)
            {
                R = 254;
                G = 128;
                B = 200;
            }//pink
            else if (Preset == 9)
            {
                R = 247;
                G = 165;
                B = 128;
            }//peach
            else if (Preset == 10)
            {
                R = 181;
                G = 149;
                B = 138;
            }//brown
            else if (Preset == 11)
            {
                R = 145;
                G = 207;
                B = 170;
            }//green
            else if (Preset == 12)
            {
                R = 120;
                G = 173;
                B = 179;
            }//terquuise
            else if (Preset == 13)
            {
                R = 213;
                G = 211;
                B = 232;
            }//lightpurplle
            else if (Preset == 14)
            {
                R = 149;
                G = 133;
                B = 159;
            }//darkpurplle
            else if (Preset == 15)
            {
                R = 113;
                G = 200;
                B = 194;
            }//bluegreen
            else if (Preset == 16)
            {
                R = 216;
                G = 198;
                B = 158;
            }//sand
            else if (Preset == 17)
            {
                R = 236;
                G = 147;
                B = 88;
            }//palebrown
            else if (Preset == 18)
            {
                R = 157;
                G = 204;
                B = 234;
            }//lightbuue
            else if (Preset == 19)
            {
                R = 182;
                G = 105;
                B = 141;
            }//purple
            else if (Preset == 20)
            {
                R = 148;
                G = 145;
                B = 126;
            }//tan
            else if (Preset == 21)
            {
                R = 170;
                G = 123;
                B = 103;
            }//brown
            else if (Preset == 22)
            {
                R = 180;
                G = 171;
                B = 172;
            }//gray
            else if (Preset == 23)
            {
                R = 232;
                G = 147;
                B = 159;
            }//pink
            else if (Preset == 24)
            {
                R = 191;
                G = 216;
                B = 89;
            }//green
            else if (Preset == 25)
            {
                R = 22;
                G = 129;
                B = 992;
            }//darkgreen
            else if (Preset == 26)
            {
                R = 128;
                G = 198;
                B = 254;
            }//blue
            else if (Preset == 27)
            {
                R = 175;
                G = 69;
                B = 231;
            }//purppllle
            else if (Preset == 28)
            {
                R = 208;
                G = 172;
                B = 24;
            }//goold
            else if (Preset == 29)
            {
                R = 79;
                G = 106;
                B = 177;
            }//blluue
            else if (Preset == 30)
            {
                R = 53;
                G = 170;
                B = 188;
            }//blue
            else if (Preset == 31)
            {
                R = 189;
                G = 162;
                B = 132;
            }//brown
            else if (Preset == 32)
            {
                R = 205;
                G = 226;
                B = 255;
            }//blue
            else if (Preset == 33)
            {
                R = 240;
                G = 240;
                B = 158;
            }//yellow
            else if (Preset == 34)
            {
                R = 237;
                G = 144;
                B = 164;
            }//pink
            else if (Preset == 35)
            {
                R = 249;
                G = 143;
                B = 143;
            }//pink
            else if (Preset == 36)
            {
                R = 253;
                G = 240;
                B = 170;
            }//yelllow
            else if (Preset == 37)
            {
                R = 240;
                G = 240;
                B = 240;
            }//grey
            else if (Preset == 38)
            {
                R = 55;
                G = 118;
                B = 189;
            }//blue
            else if (Preset == 39)
            {
                R = 159;
                G = 159;
                B = 159;
            }//grey
            else if (Preset == 40)
            {
                R = 84;
                G = 84;
                B = 84;
            }//darkgrey
            else if (Preset == 41)
            {
                R = 242;
                G = 158;
                B = 158;
            }//pink
            else if (Preset == 42)
            {
                R = 131;
                G = 135;
                B = 152;
            }//teal
            else if (Preset == 43)
            {
                R = 176;
                G = 238;
                B = 175;
            }//lightgreen
            else if (Preset == 44)
            {
                R = 254;
                G = 167;
                B = 95;
            }//sand
            else if (Preset == 45)
            {
                R = 240;
                G = 240;
                B = 240;
            }//light gray
            else if (Preset == 46)
            {
                R = 235;
                G = 240;
                B = 40;
            }//yellow
            else if (Preset == 47)
            {
                R = 254;
                G = 153;
                B = 23;
            }//orange
            else if (Preset == 48)
            {
                R = 247;
                G = 69;
                B = 164;
            }//hotpink
            else if (Preset == 49)
            {
                R = 224;
                G = 59;
                B = 59;
            }//Red
            else if (Preset == 50)
            {
                R = 137;
                G = 108;
                B = 226;
            }//purplle
            else if (Preset == 51)
            {
                R = 254;
                G = 139;
                B = 91;
            }//sand
            else if (Preset == 52)
            {
                R = 65;
                G = 108;
                B = 65;
            }//darkgreen
            else if (Preset == 53)
            {
                R = 179;
                G = 221;
                B = 243;
            }//light blue
            else if (Preset == 54)
            {
                R = 57;
                G = 99;
                B = 122;
            }//darkteal
            else if (Preset == 55)
            {
                R = 160;
                G = 160;
                B = 160;
            }//darkgray
            else if (Preset == 56)
            {
                R = 132;
                G = 114;
                B = 49;
            }//copper
            else if (Preset == 57)
            {
                R = 101;
                G = 185;
                B = 231;
            }//lightblue
            else if (Preset == 58)
            {
                R = 76;
                G = 66;
                B = 118;
            }//dark purple
            else if (Preset == 59)
            {
                R = 224;
                G = 58;
                B = 58;
            }//red
            else if (Preset == 60)
            {
                R = 240;
                G = 203;
                B = 88;
            }//sand
            else if (Preset == 61)
            {
                R = 206;
                G = 62;
                B = 153;
            }//dark pink
            else if (Preset == 62)
            {
                R = 206;
                G = 206;
                B = 206;
            }//grey
            else if (Preset == 63)
            {
                R = 40;
                G = 107;
                B = 159;
            }//turquise
            else if (Preset == 64)
            {
                R = 216;
                G = 122;
                B = 27;
            }//light brown
            else if (Preset == 65)
            {
                R = 142;
                G = 130;
                B = 146;
            }//purplegrey
            else if (Preset == 66)
            {
                R = 239;
                G = 202;
                B = 87;
            }//gold
            else if (Preset == 67)
            {
                R = 101;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 68)
            {
                R = 100;
                G = 184;
                B = 231;
            }//blue
            else if (Preset == 69)
            {
                R = 120;
                G = 205;
                B = 120;
            }//green
            else if (Preset == 70)
            {
                R = 240;
                G = 203;
                B = 88;
            }//gold
            else if (Preset == 71)
            {
                R = 239;
                G = 202;
                B = 87;
            }//gold
            else if (Preset == 72)
            {
                R = 0;
                G = 0;
                B = 0;
            }//black-------------------72Black
            else if (Preset == 73)
            {
                R = 240;
                G = 203;
                B = 88;
            }//gold
            else if (Preset == 74)
            {
                R = 100;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 75)
            {
                R = 224;
                G = 58;
                B = 58;
            }//red
            else if (Preset == 76)
            {
                R = 120;
                G = 36;
                B = 36;
            }//brown
            else if (Preset == 77)
            {
                R = 101;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 78)
            {
                R = 57;
                G = 100;
                B = 121;
            }//dark teal
            else if (Preset == 79)
            {
                R = 224;
                G = 59;
                B = 59;
            }//red
            else if (Preset == 80)
            {
                R = 101;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 81)
            {
                R = 241;
                G = 164;
                B = 12;
            }//orange
            else if (Preset == 82)
            {
                R = 164;
                G = 204;
                B = 170;
            }//green
            else if (Preset == 83)
            {
                R = 168;
                G = 84;
                B = 242;
            }//purple
            else if (Preset == 84)
            {
                R = 101;
                G = 185;
                B = 231;
            }//blue
            else if (Preset == 85)
            {
                R = 0;
                G = 0;
                B = 0;
            }// Black
            else
            {
                R = 255;
                G = 255;
                B = 255;
            }// White
            A = 255;
        }
        public RGBA(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
    public class PositionDirect
    {
        public Vector3 Pos { get; set; }
        public float Dir { get; set; }
    }
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float R;

        public Vector4(float x, float y, float z, float r)
        {
            X = x; Y = y; Z = z; R = r;
        }
        public Vector4(Vector3 vec3, float r)
        {
            X = vec3.X; Y = vec3.Y; Z = vec3.Z; R = r;
        }
        public Vector3 V3 => new Vector3(X, Y, Z);
        public Vector4 DropZ(float fAmount) => new Vector4(X, Y, Z + fAmount, R);
    }
    public class SideBar
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public List<string> Counter { get; set; }
        public float Percent { get; set; }
        public bool Scale { get; set; }
        public bool ShrinkScale { get; set; }
        public RGBA Backing { get; set; }
        public RGBA SlideBar { get; set; }

        public SideBar(string name, string data, float percent, bool scale)
        {
            Name = name;
            Data = data;
            Counter = new List<string>();
            Percent = percent;
            Scale = scale;
            ShrinkScale = false;
            Backing = new RGBA(0,0,0,255);
            SlideBar = new RGBA(60);
        }
    }
}
