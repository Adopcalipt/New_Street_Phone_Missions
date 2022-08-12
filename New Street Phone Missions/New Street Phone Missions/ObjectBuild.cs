using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class ObjectBuild
    {
        private static void RandPlayerTypes(Ped Pedx, bool bMale)
        {
            LoggerLight.LogThis("RandPlayerTypes, bMale == " + bMale);

            int shapeFirstID = 0;
            int shapeSecondID = 0;
            int shapeThirdID = 0;
            int skinFirstID = 1;
            int skinSecondID = 1;
            int skinThirdID = 1;
            int iHairStyle = 0;
            float shapeMix = 0.0f;
            float skinMix = 0.0f;
            float thirdMix = 0.0f;
            bool isParent = false;

            if (bMale)
            {
                shapeFirstID = ReturnStuff.RandInt(0, 20);
                shapeSecondID = ReturnStuff.RandInt(0, 20);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
                iHairStyle = ReturnStuff.RandInt(25, 76);
            }
            else
            {
                shapeFirstID = ReturnStuff.RandInt(21, 41);
                shapeSecondID = ReturnStuff.RandInt(21, 41);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
                iHairStyle = ReturnStuff.RandInt(25, 80);
            }

            shapeMix = ReturnStuff.RandFlow(-0.9f, 0.9f);
            skinMix = ReturnStuff.RandFlow(0.9f, 0.99f);
            thirdMix = ReturnStuff.RandFlow(-0.9f, 0.9f);

            Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Pedx.Handle, shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix, isParent);

            int iFeature = 0;

            while (iFeature < 12)
            {
                int iColour = 0;
                int iChange = ReturnStuff.RandInt(0, Function.Call<int>(Hash._GET_NUM_HEAD_OVERLAY_VALUES, iFeature));
                float fVar = ReturnStuff.RandFlow(0.45f, 0.99f);

                if (iFeature == 0)
                {
                    iChange = ReturnStuff.RandInt(0, iChange);
                }//Blemishes
                else if (iFeature == 1)
                {
                    if (bMale)
                        iChange = ReturnStuff.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Facial Hair
                else if (iFeature == 2)
                {
                    iChange = ReturnStuff.RandInt(0, iChange);
                    iColour = 1;
                }//Eyebrows
                else if (iFeature == 3)
                {
                    iChange = 255;
                }//Ageing
                else if (iFeature == 4)
                {
                    if (ReturnStuff.RandInt(0, 50) < 40)
                    {
                        iChange = ReturnStuff.RandInt(0, iChange);
                    }
                    else
                        iChange = 255;
                }//Makeup
                else if (iFeature == 5)
                {
                    if (!bMale)
                        iChange = ReturnStuff.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Blush
                else if (iFeature == 6)
                {
                    iChange = ReturnStuff.RandInt(0, iChange);
                }//Complexion
                else if (iFeature == 7)
                {
                    iChange = 255;
                }//Sun Damage
                else if (iFeature == 8)
                {
                    if (!bMale)
                        iChange = ReturnStuff.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Lipstick
                else if (iFeature == 9)
                {
                    iChange = ReturnStuff.RandInt(0, iChange);
                }//Moles/Freckles
                else if (iFeature == 10)
                {
                    if (bMale)
                        iChange = ReturnStuff.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Chest Hair
                else if (iFeature == 11)
                {
                    iChange = ReturnStuff.RandInt(0, iChange);
                }//Body Blemishes

                int AddColour = ReturnStuff.RandInt(0, 64);

                Function.Call(Hash.SET_PED_HEAD_OVERLAY, Pedx.Handle, iFeature, iChange, fVar);

                if (iColour > 0)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Pedx.Handle, iFeature, iColour, AddColour, 0);

                iFeature += 1;
            }

            int iHair = ReturnStuff.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
            int iHair2 = ReturnStuff.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));

            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, iHairStyle, 0, 2);//hair

            Function.Call(Hash._SET_PED_HAIR_COLOR, Pedx.Handle, iHair, iHair2);
        }
        private static void OnlinePlayers(Ped Pedx, bool bMale, int iPreset)
        {
            LoggerLight.LogThis("OnlinePlayers, bMale == " + bMale + ", iPreset == " + iPreset);

            if (bMale)
            {
                if (iPreset == 2)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 134, 8, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 3, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 106, 8, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 83, 8, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 274, 8, 2);//Top2
                }
                else if (iPreset == 3)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 57, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 15, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 92, ReturnStuff.RandInt(0, 19), 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 66, ReturnStuff.RandInt(0, 4), 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 53, ReturnStuff.RandInt(0, 5), 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, -1, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 228, ReturnStuff.RandInt(0, 19), 2);//Top2
                    RandPlayerTypes(Pedx, bMale);
                }
                else if (iPreset == 4)
                {
                    RandPlayerTypes(Pedx, bMale);
                    int iRan = ReturnStuff.FindRandom(66, 1, 197);
                    while (iRan == 11 || iRan == 12 || iRan == 27 || iRan == 28 || iRan == 29 || iRan == 32 || iRan == 35 || iRan == 36 || iRan == 47 || iRan == 48 || iRan == 52 || iRan == 53 || iRan == 55 || iRan == 56 || iRan == 57 || iRan == 58 || iRan == 73 || iRan == 102 || iRan == 109 || iRan == 114 || iRan == 120 || iRan == 121 || iRan == 122 || iRan == 123 || iRan == 134 || iRan == 145 || iRan == 146 || iRan == 148 || iRan == 166 || iRan == 169 || iRan == 194)
                    { iRan = ReturnStuff.FindRandom(66, 1, 197); Script.Wait(1); }
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, iRan, ReturnStuff.RandInt(0, Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Pedx.Handle, 1)), 2);//
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 0, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 135, 1, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 45, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 12, 0, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 0, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 364, 1, 2);//Top2
                }
                else
                {
                    if (DataStore.MaleCloth.Outfits.Count > 0)
                        DressinRoom.PedDresser(Pedx, DataStore.MaleCloth.Outfits[ReturnStuff.FindRandom(103, 0, DataStore.MaleCloth.Outfits.Count - 1)]);
                    else
                    {
                        int RanChar = ReturnStuff.RandInt(1, 5);
                        if (RanChar == 1)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 12, 4, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 1, 5, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 65, 3, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 22, 4, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 11, 0, 2);//Top2
                        }
                        else if (RanChar == 2)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 14, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 0, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 17, 0, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 23, 4, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 40, 1, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 26, 3, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 35, 0, 2);//Top2
                        }
                        else if (RanChar == 3)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 147, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 167, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 33, 0, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 36, 1, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 289, 0, 2);//Top2
                        }
                        else if (RanChar == 4)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 11, 4, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 19, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 88, 7, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 14, 2, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 273, 15, 2);//Top2
                        }
                        else
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 125, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 114, 6, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 78, 6, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 6, 2);//Top2
                        }
                    }
                    RandPlayerTypes(Pedx, bMale);
                }
            }
            else
            {
                if (iPreset == 2)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 134, 8, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 13, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 113, 8, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 87, 8, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, -1, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 8, 2);//Top2
                }
                else if (iPreset == 3)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 7, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 14, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 48, ReturnStuff.RandInt(0, 2), 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 60, ReturnStuff.RandInt(0, 9), 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 51, ReturnStuff.RandInt(0, 5), 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 238, ReturnStuff.RandInt(0, 19), 2);//Top2
                    RandPlayerTypes(Pedx, bMale);
                }
                else
                {
                    if (DataStore.FemaleCloth.Outfits.Count > 0)
                        DressinRoom.PedDresser(Pedx, DataStore.FemaleCloth.Outfits[ReturnStuff.FindRandom(104, 0, DataStore.FemaleCloth.Outfits.Count - 1)]);
                    else
                    {
                        int RanChar = ReturnStuff.RandInt(1, 5);
                        if (RanChar == 1)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 146, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 1, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 113, 1, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 23, 8, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 0, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 1, 2);//Top2
                        }
                        else if (RanChar == 2)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 11, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 169, 12, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 93, 4, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 3, 0, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, -1, 0, 2);//Top2
                        }
                        else if (RanChar == 3)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 13, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 98, 4, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 71, 4, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 1, 5, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 254, 4, 2);//Top2
                        }
                        else if (RanChar == 4)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 10, 1, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 15, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 9, 6, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 54, 3, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 100, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 36, 1, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 13, 5, 2);//Top2
                        }
                        else
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 2, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 11, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 75, 1, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 20, 5, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 208, 4, 2);//Top2
                        }
                    }
                    RandPlayerTypes(Pedx, bMale);
                }
            }
        }
        public static Ped NPCSpawn(string sPed, Vector3 vLocal, float fAce, bool bArmor, int iHeal, int iTask, int iSeat, Vehicle vMyCar, int iGun, bool bBlip, int iBlipCol, int iFree, string sName)
        {
            LoggerLight.LogThis("NPCSpawn, sPed == " + sPed + ", bArmor == " + bArmor + ", iHeal == " + iHeal + ", iTask == " + iTask + ", iSeat == " + iSeat + ", iGun == " + iGun + ", bBlip == " + bBlip + ", iFree == " + iFree + ", sName == " + sName);

            Ped BuildPed;
            bool bMale = false;

            if (sPed == "")
            {
                if (iFree == 0)
                    iFree = 1;

                if (ReturnStuff.FindRandom(67, 0, 20) < 10)
                {
                    sPed = "mp_m_freemode_01";
                    bMale = true;
                }
                else
                    sPed = "mp_f_freemode_01";
            }
            else if (sPed == "mp_m_freemode_01")
                bMale = true;

            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Script.Wait(1);

                BuildPed = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fAce, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (BuildPed.Exists())
                {
                    BuildPed.Accuracy = ReturnStuff.RandInt(DataStore.MySettings.LowerAim, DataStore.MySettings.UpperAim);
                    BuildPed.MaxHealth = iHeal;
                    BuildPed.Health = iHeal;

                    Function.Call(Hash.SET_PED_PATH_CAN_USE_CLIMBOVERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_USE_LADDERS, BuildPed.Handle, true);
                    Function.Call(Hash.SET_PED_PATH_CAN_DROP_FROM_HEIGHT, BuildPed.Handle, true);

                    if (bArmor)
                        BuildPed.Armor = 100;

                    MissionData.PedList_01.Add(new Ped(BuildPed.Handle));

                    ObjectHand.ReadWriteBlips(false, true, -1, -1, BuildPed.Handle, -1, -1, -1);

                    if (bBlip)
                        ReturnStuff.PedBlimp(BuildPed, 0.75f, false, false, iBlipCol, sName);

                    if (iGun > 0)
                        GunningIt(BuildPed, iGun);

                    if (vMyCar != null)
                    {
                        WarptoAnyVeh(vMyCar, BuildPed, iSeat);
                        NpcVehicleTasks(BuildPed, vMyCar, iTask);
                    }
                    else
                    {
                        if (iTask > 0)
                            NpcTasks(BuildPed, iTask);
                    }

                    if (iFree > 0)
                        OnlinePlayers(BuildPed, bMale, iFree);

                }
                else
                    BuildPed = null;
            }
            else
                BuildPed = null;

            return BuildPed;
        }
        private static void NpcTasks(Ped Peddy, int iTask)
        {
            LoggerLight.LogThis("NpcTasks, iTask == " + iTask);

            if (iTask == 1)
            {
                Peddy.Task.Cower(-1);
            }             //Cower
            else if (iTask == 2)
            {
                Peddy.CanBeShotInVehicle = true;
                Peddy.RelationshipGroup = DataStore.GP_Player;
                AddGroupie(Peddy);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);

            }        //BankRobbers
            else if (iTask == 3)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                TheMissions.Convicts_KrishaLine(Peddy, true);
            }        //Convicts leader
            else if (iTask == 4)
            {
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 3, 0, 0, 2);
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, 4, 0, 0, 2);
                TheMissions.Convicts_KrishaLine(Peddy, false);
            }        //Convicts
            else if (iTask == 5)
            {
                EnterPlayerVeh(Peddy, 1, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 01
            else if (iTask == 6)
            {
                EnterPlayerVeh(Peddy, 2, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 02
            else if (iTask == 7)
            {
                EnterPlayerVeh(Peddy, 3, ReturnStuff.RandFlow(1.00f, 2.00f));
            }        //Fubar Passenger 03
            else if (iTask == 8)
            {
                AttackThePlayer(Peddy, true);
            }        //Fight player Guns Guns Guns
            else if (iTask == 9)
            {
                Peddy.ApplyDamage(99);
                Peddy.Health = 0;
            }        //DeadNPCs
            else if (iTask == 10)
            {
                PedScenario(Peddy, "WORLD_HUMAN_COP_IDLES", Peddy.Position, Peddy.Heading, false);
            }       //Idle Cops
            else if (iTask == 11)
            {
                ArmNpcWeapon("WEAPON_minigun", Peddy);
                Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Peddy.Handle, true, false, true, true);
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, 0, 0, 0, false);
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
            }       //Juggonorts-add acc hat to 1-
            else if (iTask == 12)
            {
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "COUGAR"));
                Peddy.Task.PlayAnimation("creatures@cat@amb@world_cat_sleeping_ground@idle_a", "idle_a", 8.0f, -1, true, 1.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Fire cat
            else if (iTask == 13)
            {
                PedScenario(Peddy, "WORLD_HUMAN_JOG_STANDING", Peddy.Position, Peddy.Heading, false);
                Function.Call(Hash.TASK_TURN_PED_TO_FACE_ENTITY, Peddy.Handle, Game.Player.Character.Handle, -1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            }       //Fire cat owner
            else if (iTask == 14)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.Task.FightAgainstHatedTargets(45.00f);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Peddy.AlwaysKeepTask = true;
            }       //Water ImportGaurds
            else if (iTask == 15)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                int iRan = ReturnStuff.FindRandom(97, 1, 10);
                if (iRan < 3)
                    iRan = 2;
                else if (iRan < 6)
                    iRan = 1;
                else
                    iRan = 0;
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, iRan);
            }       //Water YachtAttacks
            else if (iTask == 16)
            {
                Peddy.IsEnemy = true;
                TheMissions.Hitman_AddVisionCones(Peddy);
                Peddy.BlockPermanentEvents = true;
            }       //HitMan Mobs
            else if (iTask == 17)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
            }       //Flee & Blocking
            else if (iTask == 18)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 0);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - static
            else if (iTask == 19)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Defence
            else if (iTask == 20)
            {
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
            }       //Combat - Offence
            else if (iTask == 21)
            {
                Peddy.Task.PlayAnimation("amb@world_human_stand_fishing@idle_a", "idle_b", 8.00f, -1, true, 1.00f);
                Prop FishRod = BuildProp("prop_fishing_rod_01", Peddy.Position, Vector3.Zero, true, true);
                if (FishRod != null)
                    FishRod.AttachTo(Peddy, Peddy.GetBoneIndex(Bone.SKEL_L_Hand), new Vector3(0.00f, -0.00f, 0.00f), new Vector3(-122.00f, 100.00f, 30.00f));
            }       //Water Phishing
            else if (iTask == 22)
            {
                TheMissions.BbBomb_BombAtractor(Peddy);
            }       //Bbomb Atractor
            else if (iTask == 23)
            {
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                TheMissions.Hitman_AddVisionCones(Peddy);
                EnterAnyVeh(MissionData.VehTrackin_01, Peddy, 0, 1.0f);
            }       //MoresMan
            else if (iTask == 24)
            {
                ForceAnim(Peddy, "amb@code_human_in_bus_passenger_idles@male@sit@base", "base", Peddy.Position, Peddy.Rotation);
                Function.Call(Hash.SET_PED_CAN_SWITCH_WEAPON, Peddy.Handle, true);
            }       //peds in back of plane
            else if (iTask == 25)
            {
                TheMissions.BikerRaids_BizzPedsSec(Peddy, MissionData.iMissionVar_02);
                AttackThePlayer(Peddy, true);
            }       //BikerBizSecurity
            else if (iTask == 26)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.BikerRaids_BizzPedsWork(Peddy, MissionData.iMissionVar_02, false);
            }       //BikerBizFemail
            else if (iTask == 27)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.BikerRaids_BizzPedsWork(Peddy, MissionData.iMissionVar_02, true);
            }       //BikerBizmail
            else if (iTask == 28)
            {
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, "COUGAR"));
                AttackThePlayer(Peddy, false);
            }       //Big shark
            else if (iTask == 29)
            {
                PedScenario(Peddy, "WORLD_HUMAN_PARTYING", Peddy.Position, Peddy.Heading, false);
            }       //Dance
            else if (iTask == 30)
            {
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
                PedScenario(Peddy, "WORLD_HUMAN_GUARD_STAND", Peddy.Position, Peddy.Heading, false);
            }       //Club Bouncer
            else if (iTask == 31)
            {
                TheMissions.TempAgency_02_BuildCluber(Peddy);
            }       //DrinkNDance Clubber
            else if (iTask == 32)
            {
                PedScenario(Peddy, "WORLD_HUMAN_SMOKING", Peddy.Position, Peddy.Heading, false);
            }       //StandSmoke
            else if (iTask == 33)
            {
                PedScenario(Peddy, "WORLD_HUMAN_CLIPBOARD", Peddy.Position, Peddy.Heading, false);
            }       //StandClippBoard
            else if (iTask == 34)
            {
                PedScenario(Peddy, "WORLD_HUMAN_GUARD_STAND", Peddy.Position, Peddy.Heading, false);
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
            }       //standgaurds
            else if (iTask == 35)
            {
                PedScenario(Peddy, "WORLD_HUMAN_CLIPBOARD", Peddy.Position, Peddy.Heading, false);
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
            }       //ClippBoard-Mishppeds
            else if (iTask == 36)
            {
                MissionData.Npc_01 = Peddy;
                AttackThePlayer(Peddy, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                PlayerAtackTracker();
            }       //JohnnylayerAttack
            else if (iTask == 37)
            {
                AttackThePlayer(Peddy, false);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 2);
                Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Peddy.Handle, false);
                TheMissions.Follow_AddToMuilti(Peddy, "", Peddy.CurrentBlip, null);
                GunningIt(Peddy, 10);
            }       //GreenyAttack
            else if (iTask == 38)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
            }       //SniperRunner
            else if (iTask == 39)
            {
                Peddy.IsEnemy = true;
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                AddGroupie(Peddy);
                OhDoKeepUp(Peddy, MissionData.Npc_01, MissionData.fMission_01, MissionData.BeOnOff[5]);
            }       //SniperFollow
        }
        private static void NpcVehicleTasks(Ped Peddy, Vehicle Vehic, int iTask)
        {
            if (iTask == 1)
            {
                Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Peddy.Handle, 1);
                Function.Call(Hash.SET_PED_CONFIG_FLAG, Peddy.Handle, 32, false);
                TheMissions.Racist_MultiPed(Peddy, Vehic);
            }       //Race Drivers
            else if (iTask == 2)
            {
                Peddy.Task.ClearAll();
                if (Peddy.IsInVehicle())
                    Peddy.Task.CruiseWithVehicle(Peddy.CurrentVehicle, 35.00f, 786603);
            }       //Drive RandDest
            else if (iTask == 3)
            {
                WarptoAnyVeh(Vehic, Peddy, 1);
                FlyNShoot(Peddy, Vehic, Game.Player.Character);
            }       //CargoBobHellepillot
            else if (iTask == 4)
            {
                Vector3 V3Me = Function.Call<Vector3>(Hash._0xCBDB9B923CACC92D, MissionData.VehTrackin_02.Handle);
                VehicleSpawn(ReturnStuff.RanVehListX(1, 1, true), V3Me, MissionData.VehTrackin_02.Heading, false, false, false, false, 7, 0, 0, "", 3, true);
            }       //Cargo add super car
            else if (iTask == 5)
            {
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
            }       //Attack Player
            else if (iTask == 6)
            {
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.BlockPermanentEvents = true;
            }       //MoneyMan Guard
            else if (iTask == 7)
            {
                Peddy.Task.ClearAll();
                Peddy.Task.Wait(-1);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Wait in vehicle
            else if (iTask == 8)
            {
                Vector3 vpos = MissionData.VehTrackin_03.Position;
                vpos.Z = vpos.Z + 5.00f;
                ObjectBuild.FlyAway(Peddy, vpos, 55.00f, 5.00f);
                MissionData.BeOnOff[1] = true;
            }       //WAter CargoPilot
            else if (iTask == 9)
            {
                Vehicle VPlyTarget = null;
                Vehicle vPlane = MissionData.VehicleList_01[MissionData.VehicleList_01.Count - 1];
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                if (Game.Player.Character.IsInVehicle())
                    VPlyTarget = Game.Player.Character.CurrentVehicle;
                else
                    VPlyTarget = Game.Player.Character.LastVehicle;
                Function.Call(Hash.TASK_PLANE_MISSION, Peddy.Handle, vPlane.Handle, VPlyTarget.Handle, 0, 0, 0, 0, 6, 0.0f, 0.0f, 180.0f, 1000.0f, -5000.0f);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                vPlane.CurrentBlip.Color = BlipColor.Red;
            }       //DogFighter
            else if (iTask == 10)
            {
                float fSpeeds = 25.00f;
                Peddy.Task.ClearAll();
                Peddy.RelationshipGroup = DataStore.GP_BNPCs;
                Vector3 PlayPos = MissionData.VehTrackin_03.Position;
                Peddy.DrownsInWater = false;
                Function.Call(Hash.TASK_BOAT_MISSION, Peddy.Handle, Vehic.Handle, 0, 0, PlayPos.X, PlayPos.Y, PlayPos.Z, 4, fSpeeds, 16777216, 5.50f, 7);

                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyVehicle = Vehic;
                MyNewPed.MyName = DataStore.MyLang.Maptext[20];
                MyNewPed.MyTask_01 = 1;
                MyNewPed.MyBlip = Vehic.CurrentBlip;
                MissionData.MultiPed.Add(MyNewPed);
            }       //WAter JetskiAttacks
            else if (iTask == 11)
            {
                MissionData.MishPed.Add(new Ped(Peddy.Handle));
                Peddy.RelationshipGroup = DataStore.GP_Player;
                Peddy.Task.DriveTo(Vehic, MissionData.vTarget_04, 3.00f, 15.00f, 536871355);
                Peddy.CanBeDraggedOutOfVehicle = false;
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //ValllyCass
            else if (iTask == 12)
            {
                Peddy.RelationshipGroup = DataStore.GP_ANPCs;
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
            }       //ValcaryPilot
            else if (iTask == 13)
            {
                Vector3 vTag = MissionData.vTarget_01;
                vTag.Z = 1005.00f;
                ImOnAPlane(Peddy, Vehic, vTag);
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
            }       //Pilot fly away
            else if (iTask == 14)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = ReturnStuff.VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                    DriveByPlayer(Peddy, true);
                }
                else
                    DriveByPlayer(Peddy, false);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyTask_01 = 1;
                MissionData.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //Biker Attacks
            else if (iTask == 15)
            {
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    DriveByPed(Peddy, MissionData.Npc_01, true);
                }
                else
                    DriveByPed(Peddy, MissionData.Npc_02, false);
            }       //Attack Npc01/02
            else if (iTask == 16)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = ReturnStuff.VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                }
                Peddy.Task.ClearAll();
                if (ReturnStuff.FindRandom(86, 1, 4) > 2)
                    FightingXPed(Peddy, MissionData.Npc_01);
                else
                    FightingXPed(Peddy, MissionData.Npc_02);
                Peddy.AlwaysKeepTask = true;
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyTask_01 = 1;
                MyNewPed.MyPed = Peddy;
                MissionData.MultiPed.Add(MyNewPed);
            }       //Attack Npc01/02 with MuiltiPed
            else if (iTask == 17)
            {
                PedMultiTask MyNewPed = ObjectBuild.AddAMultiped();
                Peddy.Task.ClearAll();
                if (Peddy.SeatIndex == VehicleSeat.Driver)
                {
                    Peddy.DrivingSpeed = 200.00f;
                    Peddy.DrivingStyle = 0;
                    MyNewPed.MyVehicle = Vehic;
                    MyNewPed.MyBlip = ReturnStuff.VehBlip(Vehic, false, false, 1, DataStore.MyLang.Maptext[106]);
                }
                AttackThePlayer(Peddy, true);
                MyNewPed.MyName = DataStore.MyLang.Maptext[106];
                MyNewPed.MyPed = Peddy;
                MyNewPed.MyTask_01 = 1;
                MissionData.MultiPed.Add(MyNewPed);
                Peddy.AlwaysKeepTask = true;
            }       //Biker Attacks onfoot
            else if (iTask == 39)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                ///OnlinePlayers(Peddy, true, 0);
            }       //Drive Playerped M
            else if (iTask == 40)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.AlwaysKeepTask = true;
                Peddy.BlockPermanentEvents = true;
                ///OnlinePlayers(Peddy, false, 0);
            }       //Drive Playerped F
        }
        public static void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.LogThis("ObjectBuild.ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnimOnceEnding(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot, float fEnder)
        {
            LoggerLight.LogThis("ObjectBuild.ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, fEnder, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnim(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.LogThis("ForceAnim, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 1, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void PedScenario(Ped Peddy, string sCenario, Vector3 Vpos, float fHead, bool bSeated)
        {
            LoggerLight.LogThis("PedScenario, sCenario == " + sCenario);

            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, Peddy.Handle, sCenario, Vpos.X, Vpos.Y, Vpos.Z, fHead, 0, bSeated, true);
        }
        private static void AddGroupie(Ped Peddy)
        {
            Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, Peddy.Handle, DataStore.iPlayerGroup);
        }
        private static void OhDoKeepUp(Ped Peddy, Ped Leader, float fSpeed, bool bClose)
        {
            float fXpos = -2.50f;
            float fYpos = 1.50f;
            if (bClose)
            {
                if (DataStore.iFolPos > 0)
                {
                    fXpos = -1.20f;
                    fYpos = -0.20f;
                    DataStore.iFolPos = 0;
                }
                else
                {
                    fXpos = 1.20f;
                    fYpos = -0.20f;
                    DataStore.iFolPos++;
                }
            }
            else
            {
                DataStore.iFolPos++;
                if (DataStore.iFolPos == 1)
                {
                    fXpos = -2.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 2)
                {
                    fXpos = -2.50f;
                    fYpos = -2.50f;
                }
                else if (DataStore.iFolPos == 3)
                {
                    fXpos = 2.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 4)
                {
                    fXpos = 1.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 5)
                {
                    fXpos = -1.50f;
                    fYpos = 0.00f;
                }
                else if (DataStore.iFolPos == 6)
                {
                    fXpos = 2.50f;
                    fYpos = -2.50f;
                }
                else if (DataStore.iFolPos == 7)
                {
                    fXpos = -1.50f;
                    fYpos = -2.50f;
                    DataStore.iFolPos = 0;
                }
            }

            Function.Call(Hash.TASK_FOLLOW_TO_OFFSET_OF_ENTITY, Peddy.Handle, Leader.Handle, fXpos, fYpos, 0.0f, fSpeed, -1, 2.5f, true);
        }
        public static PedMultiTask AddAMultiped()
        {
            PedMultiTask MyMultiPed = new PedMultiTask
            {
                MyPed = null,
                MyVehicle = null,
                MyBlip = null,
                MyFloat_01 = 0.00f,
                MyFloat_02 = 0.00f,
                MyFloat_03 = 0.00f,
                MyTask_01 = -1,
                MyTask_02 = -1,
                MyTask_03 = -1,
                MyTimer_01 = -1,
                MyTimer_02 = -1,
                MySwitch_01 = false,
                MySwitch_02 = false,
                MySwitch_03 = false,
                MyName = "",
                MyTarget_01 = Vector3.Zero,
                MyTarget_02 = Vector3.Zero
            };

            return MyMultiPed;
        }
        public static void AttackThePlayer(Ped Pedd, bool bWeaps)
        {
            LoggerLight.LogThis("AttackThePlayer");

            Pedd.RelationshipGroup = DataStore.GP_Attack;
            Pedd.IsEnemy = true;
            Pedd.CanBeTargette﻿d﻿ = true;
            ReturnStuff.PedBlimp(Pedd, 0.75f, false, false, 59, "");
            //Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 2, false);//steal a Vehicle?
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Pedd.Task.FightAgainst(Game.Player.Character);
            Function.Call(Hash.SET_PED_PATH_CAN_USE_CLIMBOVERS, Pedd.Handle, true);
            Function.Call(Hash.SET_PED_PATH_CAN_USE_LADDERS, Pedd.Handle, true);
            Function.Call(Hash.SET_PED_PATH_CAN_DROP_FROM_HEIGHT, Pedd.Handle, true);
            Pedd.Weapons.RemoveAll();
            if (bWeaps)
            {
                ArmsRegulator(Pedd, 2);
                ArmsRegulator(Pedd, 3);
                ArmsRegulator(Pedd, 4);
                ArmsRegulator(Pedd, 5);
            }
        }
        private static void DriveByPlayer(Ped Pedd, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            Pedd.RelationshipGroup = DataStore.GP_Attack;
            Pedd.IsEnemy = true;
            Pedd.CanBeTargette﻿d﻿ = true;
            if (bDriver)
                Pedd.Task.VehicleChase(Game.Player.Character);
            else
                Pedd.Task.VehicleShootAtPed(Game.Player.Character); 
            
            ArmsRegulator(Pedd, 3);
            ArmsRegulator(Pedd, 4);
            ArmsRegulator(Pedd, 5);
        }
        private static void DriveByPed(Ped Pedd, Ped Victim, bool bDriver)
        {
            LoggerLight.LogThis("DriveByPlayer");
            Pedd.CanBeTargette﻿d﻿ = true;
            if (bDriver)
                Pedd.Task.VehicleChase(Victim);
            else
                Pedd.Task.VehicleShootAtPed(Victim);
            ArmsRegulator(Pedd, 1);
            ArmsRegulator(Pedd, 2);
            ArmsRegulator(Pedd, 3);
            ArmsRegulator(Pedd, 4);
            ArmsRegulator(Pedd, 5);
        }
        public static void FightingXPed(Ped Pedd, Ped Victim)
        {
            LoggerLight.LogThis("FightingXPed");

            Pedd.Task.ClearAll();
            Function.Call(Hash._0x88E32DB8C1A4AA4B, Pedd.Handle, 10.00f);
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Function.Call(Hash.SET_PED_COMBAT_ABILITY, Pedd.Handle, 100);
            Function.Call(Hash.TASK_GO_TO_ENTITY, Pedd.Handle, Victim.Handle, -1, 1.0f, 100, 1073741824, 0);
            Function.Call(Hash.TASK_COMBAT_PED, Pedd.Handle, Victim.Handle, 0, 16);
            Pedd.BlockPermanentEvents = true;
            Pedd.AlwaysKeepTask = true;
        }
        public static void FightAbility(Ped Pedd)
        {
            Function.Call(Hash._0x88E32DB8C1A4AA4B, Pedd.Handle, 10.00f);
            //Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Pedd.Handle, 0, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 5, true);
            Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, Pedd.Handle, 46, true);
            Function.Call(Hash.SET_PED_COMBAT_ABILITY, Pedd.Handle, 100);
        }
        public static void GunningIt(Ped Peddy, int iGun)
        {
            LoggerLight.LogThis("GunningIt, iGun == " + iGun);

            if (iGun == 1)
                ArmsRegulator(Peddy, 5);
            else if (iGun == 2)
                ArmsRegulator(Peddy, 4);
            else if (iGun == 3)
                ArmsRegulator(Peddy, 3);
            else if (iGun == 4)
                ArmsRegulator(Peddy, 3);
            else if (iGun == 5)
                ArmsRegulator(Peddy, 1);
            else if (iGun == 6)
                ArmsRegulator(Peddy, 6);
            else if (iGun == 7)
            {
                int iRanGun = ReturnStuff.RandInt(0, 50);
                if (iRanGun < 10)
                    ArmsRegulator(Peddy, 1);
                else if (iRanGun < 20)
                    ArmsRegulator(Peddy, 3);
                else if (iRanGun < 30)
                    ArmsRegulator(Peddy, 3);
                else if (iRanGun < 40)
                    ArmsRegulator(Peddy, 4);
                else
                    ArmsRegulator(Peddy, 5);
            }
            else if (iGun == 8)
            {
                int iRanGun = ReturnStuff.RandInt(0, 30);
                if (iRanGun < 25)
                    ArmsRegulator(Peddy, 3);
                else
                    ArmsRegulator(Peddy, 5);
            }
            else if (iGun == 9)
            {
                ArmsRegulator(Peddy, 4);
                ArmsRegulator(Peddy, 3);
            }
            else if (iGun == 10)
            {
                ArmNpcWeapon("WEAPON_raypistol", Peddy);
            }
            else if (iGun == 11)
            {
                ArmNpcWeapon("WEAPON_dagger", Peddy);
                ArmNpcWeapon("WEAPON_sniperrifle", Peddy);
                ArmNpcAtachment("WEAPON_sniperrifle", "COMPONENT_AT_AR_SUPP_02", Peddy);
                ArmNpcAtachment("WEAPON_sniperrifle", "COMPONENT_AT_SCOPE_MAX", Peddy);
            }
        }
        public static void ArmNpcWeapon(string sWeap, Ped Peddy)
        {
            Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), ReturnStuff.MaxAmmo(sWeap, Peddy), false, true);
        }
        private static void ArmNpcAtachment(string sWeap, string sAttach, Ped Peddy)
        {
            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_HASH_KEY, sAttach));
        }
        public static void ArmsRegulator(Ped Peddy, int iSet)
        {
            if (iSet == 1)
            {
                ArmNpcWeapon("WEAPON_rayminigun", Peddy);
                ArmNpcWeapon("WEAPON_raycarbine", Peddy);
                ArmNpcWeapon("WEAPON_raypistol", Peddy);
            }       //space
            else if (iSet == 2)
            {
                if (ReturnStuff.RandInt(0, 20) < 10)
                    ArmNpcWeapon("WEAPON_combatmg", Peddy);
                else
                    ArmNpcWeapon("WEAPON_minigun", Peddy);
            }       //heavy
            else if (iSet == 3)
            {
                List<string> WeaponList = new List<string>
                {
                    "WEAPON_advancedrifle",
                    "WEAPON_assaultrifle",
                    "WEAPON_assaultshotgun",
                    "WEAPON_assaultsmg",
                    "WEAPON_bullpuprifle",
                    "WEAPON_bullpupshotgun",
                    "WEAPON_carbinerifle",
                    "WEAPON_combatpdw",
                    "WEAPON_compactrifle",
                    "WEAPON_dbshotgun",
                    "WEAPON_gusenberg",
                    "WEAPON_heavyshotgun",
                    "WEAPON_pumpshotgun",
                    "WEAPON_specialcarbine",
                    "WEAPON_autoshotgun"
                };

                ArmNpcWeapon(WeaponList[ReturnStuff.RandInt(0, WeaponList.Count - 1)], Peddy);
            }       //Mid
            else if (iSet == 4)
            {

                List<string> WeaponList = new List<string>
                {
                    "WEAPON_appistol",
                    "WEAPON_doubleaction",
                    "WEAPON_heavypistol",
                    "WEAPON_machinepistol",
                    "WEAPON_marksmanpistol",
                    "WEAPON_microsmg",
                    "WEAPON_pistol",
                    "WEAPON_pistol50",
                    "WEAPON_revolver",
                    "WEAPON_snspistol",
                    "WEAPON_vintagepistol"
                };

                ArmNpcWeapon(WeaponList[ReturnStuff.RandInt(0, WeaponList.Count - 1)], Peddy);
            }       //small
            else if (iSet == 5)
            {

                List<string> WeaponList = new List<string>
                {
                    "WEAPON_dagger",  //0x92A27487",
                    "WEAPON_bat",  //0x958A4A8F",
                    "WEAPON_bottle",  //0xF9E6AA4B",
                    "WEAPON_crowbar",  //0x84BD7BFD",
                    "WEAPON_golfclub",  //0x440E4788",
                    "WEAPON_hammer",  //0x4E875F73",
                    "WEAPON_hatchet",  //0xF9DCBF2D",
                    "WEAPON_knuckle",  //0xD8DF3C3C",
                    "WEAPON_knife",  //0x99B507EA",
                    "WEAPON_machete",  //0xDD5DF8D9",
                    "WEAPON_switchblade",  //0xDFE37640",
                    "WEAPON_nightstick",  //0x678B81B1",
                    "WEAPON_wrench",  //0x19044EE0",
                    "WEAPON_battleaxe",  //0xCD274149",
                    "WEAPON_poolcue",  //0x94117305",
                    "WEAPON_stone_hatchet"  //0x3813FC08"--17
                };

                ArmNpcWeapon(WeaponList[ReturnStuff.RandInt(0, WeaponList.Count - 1)], Peddy);
            }       //melee
            else if (iSet == 6)
            {
                ArmNpcWeapon("WEAPON_molotov", Peddy);
            }       //Molly
            Peddy.CanSwitchWeapons = true;
        }
        public static void EnterAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat, float Run)
        {
            LoggerLight.LogThis("EnterAnyVeh, iSeat == " + iSeat + ", Run == " + Run);

            if (Vhic.Exists())
            {
                Function.Call(Hash.TASK_ENTER_VEHICLE, Peddy.Handle, Vhic, -1, iSeat - 1, Run, 1, 0);
                Peddy.BlockPermanentEvents = true;
                Peddy.AlwaysKeepTask = true;
            }
        }
        public static void EnterPlayerVeh(Ped Peddy, int iSeat, float Run)
        {
            LoggerLight.LogThis("EnterPlayerVeh, iSeat == " + iSeat + ", Run == " + Run);
            if (Game.Player.Character.IsInVehicle())
            {
                Vehicle Vhick = Game.Player.Character.CurrentVehicle;
                EnterAnyVeh(Vhick, Peddy, iSeat, Run);
            }
        }
        public static void WarptoAnyVeh(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            LoggerLight.LogThis("WarptoAnyVeh, iSeat == " + iSeat);

            bool bFader = false;
            if (Peddy == Game.Player.Character)
            {
                Game.FadeScreenOut(1000);
                Script.Wait(1000);
                bFader = true;
            }

            while (!Peddy.IsInVehicle(Vhic))
            {
                if (Peddy.IsInVehicle())
                    GetOutofVeh(Peddy, 1);
                VehicleWarp(Vhic, Peddy, iSeat);
                Script.Wait(100);
            }

            if (bFader)
            {
                Script.Wait(500);
                Game.FadeScreenIn(1000);
            }
        }
        public static void VehicleWarp(Vehicle Vhic, Ped Peddy, int iSeat)
        {
            Function.Call(Hash.SET_PED_INTO_VEHICLE, Peddy.Handle, Vhic.Handle, iSeat - 2);
        }
        public static void WarptoPlayerVeh(Ped Peddy, int iSeat)
        {
            LoggerLight.LogThis("WarptoPlayerVeh, iSeat == " + iSeat);

            if (Game.Player.Character.IsInVehicle())
            {
                Vehicle Vhick = Game.Player.Character.CurrentVehicle;
                while (!Peddy.IsInVehicle(Vhick))
                {
                    VehicleWarp(Vhick, Peddy, iSeat);
                    Script.Wait(500);
                }
            }
        }
        public static void FreeSeat(Vehicle Vhick, int iSeat, bool bFlee)
        {
            LoggerLight.LogThis("FreeSeat iSeat== " + iSeat + ", bFlee == " + bFlee);
            if (!Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, Vhick.Handle, iSeat - 2))
            {
                Ped Peddy = Function.Call<Ped>(Hash.GET_PED_IN_VEHICLE_SEAT, Vhick.Handle, iSeat - 2);
                FleeFromVeh(Peddy);
            }
        }
        public static void GetOutofVeh(Ped Peddy, int iExits)
        {
            bool bExited = false;
            if (Peddy.IsInVehicle())
            {
                int iTenPass = 10;
                int iLeave = 0;
                if (iExits == 1)
                    iLeave = 256;
                else if (iExits == 2)
                    iLeave = 4160;

                Vehicle PickVic = Peddy.CurrentVehicle;
                while (Peddy.IsInVehicle(PickVic) && iTenPass > 0)
                {
                    Script.Wait(100);
                    Function.Call(Hash.TASK_LEAVE_VEHICLE, Peddy.Handle, PickVic.Handle, iLeave);
                    iTenPass -= 1;
                }
                if (iTenPass > 0)
                    bExited = true;
            }
            LoggerLight.LogThis("GetOutofVeh Exit == " + bExited);
        }
        private static void FleeFromVeh(Ped Peddy)
        {
            LoggerLight.LogThis("FleeFromVeh");

            Peddy.Task.ClearAll();
            GetOutofVeh(Peddy, 2);
            Peddy.Task.FleeFrom(Game.Player.Character);
        }
        public static void FlyAway(Ped Pedd, Vector3 vHeliDest, float fSpeed, float flanding)
        {
            LoggerLight.LogThis("FlyAway");

            Vehicle vHeli = Pedd.CurrentVehicle;
            vHeli.FreezePosition = false;

            float HeliDesX = vHeliDest.X;
            float HeliDesY = vHeliDest.Y;
            float HeliDesZ = vHeliDest.Z;
            float HeliSpeed = fSpeed;
            float HeliLandArea = flanding;

            float dx = Pedd.Position.X - HeliDesX;
            float dy = Pedd.Position.Y - HeliDesY;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        public static void ImOnAPlane(Ped Pilot, Vehicle Plane, Vector3 Dest)
        {
            LoggerLight.LogThis("ImOnAPlane");

            Pilot.Task.ClearAll();
            Function.Call(Hash.TASK_PLANE_MISSION, Pilot.Handle, Plane.Handle, 0, 0, Dest.X, Dest.Y, Dest.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
        }
        public static void ShowBoating(Ped PedX, Vector3 vEctor, Vehicle Vhick, float fSpeeds, int iDrivinStyle)
        {
            LoggerLight.LogThis("ShowBoating");

            PedX.Task.ClearAll();
            Function.Call(Hash.TASK_BOAT_MISSION, PedX.Handle, Vhick.Handle, 0, 0, vEctor.X, vEctor.Y, vEctor.Z, 4, fSpeeds, iDrivinStyle, -1.0f, 7);
            Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, PedX.Handle, true);
        }
        public static void DriveToDest(Vehicle Vhickery, Vector3 TheDest, Ped Peddy, float fSpeding, int iDriveStyle)
        {
            LoggerLight.LogThis("DriveToDest");

            Peddy.Task.ClearAll();
            Peddy.Task.DriveTo(Vhickery, TheDest, 1.50f, fSpeding, iDriveStyle);
            Peddy.AlwaysKeepTask = true;
            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
            Peddy.AlwaysKeepTask = true;
            Peddy.BlockPermanentEvents = true;
        }
        private static void FlyNShoot(Ped Pedd, Vehicle vHeli, Ped Target)
        {
            LoggerLight.LogThis("FlyNShoot");

            float HeliSpeed = 75.00f;
            //float HeliLandArea = flanding;

            float dx = Target.Position.X - vHeli.Position.X;
            float dy = Target.Position.Y - vHeli.Position.Y;
            float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
            Function.Call(Hash.TASK_HELI_MISSION, Pedd.Handle, vHeli.Handle, 0, Target.Handle, 0, 0, 0, 9, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
            Pedd.AlwaysKeepTask = true;
            Pedd.BlockPermanentEvents = true;
        }
        private static void PlayerAtackTracker()
        {
            while (MissionData.bPlayerAtt)
            {
                if (MissionData.Npc_01 != null)
                {
                    if (TheMissions.AmIFar(MissionData.Npc_01.Position, 250f) || MissionData.Npc_01.IsDead || Game.Player.Character.IsDead)
                    {
                        MissionData.Npc_01 = null;
                        MissionData.bPlayerAtt = false;
                        ObjectHand.CleanUpPeds(ObjectHand.ConvertToHandle(null, MissionData.PedList_01, null, null), true, false);
                        MissionData.PedList_01.Clear();
                    }
                }
                Script.Wait(1000);
            }
        }
        public static Vehicle VehicleSpawn(string sVehModel, Vector3 VecLocal, float VecHead, bool bIsInvinc, bool bFreeze, bool bRouteto, bool bFlasher, int iMod, int iExtraMod, int iBlip, string sBlip, int iVehTrack, bool bModShop)
        {
            LoggerLight.LogThis("VehicleSpawn, sVehModel == " + sVehModel + ", bIsInvinc == " + bIsInvinc + ", bFreeze == " + bFreeze + ", iMod == " + iMod + ", iExtraMod == " + iExtraMod + ", iVehTrack == " + iVehTrack);

            Vehicle BuildVehicle = null;

            int iVehHash = -1;

            if (sVehModel == "GetPlayersVeh")
                iVehHash = Game.Player.Character.CurrentVehicle.Model.Hash;
            else if (sVehModel == "" || !ReturnStuff.IsItARealVehicle(sVehModel))
                sVehModel = ReturnStuff.ImportsExpo_CarList(1);

            if (iVehHash == -1)
                iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehModel);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
            {
                Function.Call(Hash.REQUEST_MODEL, iVehHash);
                while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                    Script.Wait(1);

                BuildVehicle = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, VecLocal.X, VecLocal.Y, VecLocal.Z, VecHead, true, true);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);

                BuildVehicle.IsPersistent = true;
                BuildVehicle.IsInvincible = bIsInvinc;
                BuildVehicle.FreezePosition = bFreeze;
                MissionData.VehicleList_01.Add(new Vehicle(BuildVehicle.Handle));
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, BuildVehicle.Handle, 0);
                ObjectHand.ReadWriteBlips(false, true, -1, -1, -1, -1, BuildVehicle.Handle, -1);

                if (iVehTrack > 0)
                {
                    if (iVehTrack == 1)
                        MissionData.VehTrackin_01 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 2)
                        MissionData.VehTrackin_02 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 3)
                        MissionData.VehTrackin_03 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 4)
                        MissionData.VehTrackin_04 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 5)
                        MissionData.VehTrackin_05 = new Vehicle(BuildVehicle.Handle);
                    else if (iVehTrack == 10)
                        DataStore.SharedVeh = new Vehicle(BuildVehicle.Handle);
                }
                if (iBlip > 0)
                    ReturnStuff.VehBlip(BuildVehicle, bFlasher, bRouteto, iBlip, sBlip);

                VehicleMods(BuildVehicle, iMod, iExtraMod, bModShop);
            }
            else
                BuildVehicle = null;

            if (DataStore.SharedVeh != null)
                LoggerLight.LogThis("shared vehicle == " + DataStore.SharedVeh.Handle);

            return BuildVehicle;
        }
        public static void MaxOutAllModsNoWheels(Vehicle Vehic)
        {
            for (int i = 0; i < 50; i++)
            {
                int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i);

                if (i == 18 || i == 22 || i == 23 || i == 24)
                {

                }
                else
                {
                    iSpoilher -= 1;
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher, true);
                }
            }
            if (Vehic.ClassType != VehicleClass.Cycles || Vehic.ClassType != VehicleClass.Helicopters || Vehic.ClassType != VehicleClass.Boats || Vehic.ClassType != VehicleClass.Planes)
            {
                Vehic.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Vehic.ToggleMod(VehicleToggleMod.Turbo, true);
            }
        }
        public static void ModExtras(Vehicle Vehic, List<int> VehExtras)
        {
            for (int i = 0; i < 15; i++)
            {
                if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, Vehic.Handle, i))
                    Function.Call(Hash.SET_VEHICLE_EXTRA, Vehic.Handle, i, true);
            }


            for (int i = 0; i < VehExtras.Count; i++)
            {
                if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, Vehic.Handle, VehExtras[i]))
                    Function.Call(Hash.SET_VEHICLE_EXTRA, Vehic.Handle, VehExtras[i], false);
            }
        }
        public static void VehicleMods(Vehicle Vehic, int iMod, int iExtraMod, bool bModShop)
        {
            LoggerLight.LogThis("VehicleMods, iMod == " + iMod + ", iExtraMod == " + iExtraMod);

            List<int> MyExtras = new List<int>();

            if (iMod == 1)
            {
                if (iExtraMod > 0)
                    MyExtras.Add(iExtraMod);

                ModExtras(Vehic, MyExtras);
            }         // Extras
            else if (iMod == 2)
            {
                if (iExtraMod == 1)
                {
                    Vehic.PrimaryColor = VehicleColor.MatteWhite;
                    Vehic.SecondaryColor = VehicleColor.MatteMidnightBlue;
                }
                else if (iExtraMod == 2)
                {
                    Vehic.Livery = 6;
                }
                else if (iExtraMod == 3)
                {
                    Vehic.Livery = 9;
                    Vehic.PrimaryColor = VehicleColor.MetallicBlazeRed;
                }
                else if (iExtraMod == 4)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicBlack;
                    Vehic.SecondaryColor = VehicleColor.MetallicUltraBlue;

                }
                else if (iExtraMod == 5)
                {
                    Vehic.CurrentBlip.Color = BlipColor.Blue;
                    TheMissions.ImportsExpo_FunPlates(Vehic);
                    MissionData.iMissionSeq = 3;
                }
                else if (iExtraMod == 6)
                {
                    Vehic.CurrentBlip.Color = BlipColor.Red3;
                    NPCSpawn(ReturnStuff.RandNPC(ReturnStuff.RandInt(1, 35)), Vehic.Position, 0.00f, false, 120, 2, 1, Vehic, 0, false, 0, 0, "");
                    MissionData.iMissionSeq = 3;
                }
                else if (iExtraMod == 7)
                {
                    NPCSpawn("", Vehic.Position, 0.00f, false, 170, 3, 1, Vehic, 0, false, 0, 1, "");
                    Vehic.CurrentBlip.Color = BlipColor.Red;
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 1)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 5, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats = iNoSeats - 1;
                    }
                }           //heliAtt on Cargocolect
                else if (iExtraMod == 8)
                {
                    Vehic.Position = new Vector3(Vehic.Position.X, Vehic.Position.Y, Vehic.Position.Z + 50.00f);
                    NPCSpawn("", Vehic.Position, 0.00f, false, 170, 3, 0, Vehic, 0, false, 0, 1, "");
                    Vehic.CurrentBlip.Color = BlipColor.Red;
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 1)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 0, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats = iNoSeats - 1;
                    }
                }       //cargobob player pped pilot
                else if (iExtraMod == 9)
                {
                    Vehic.SetMod(VehicleMod.Roof, 1, true);
                }
                else if (iExtraMod == 10)
                {
                    Vehic.PrimaryColor = VehicleColor.MatteBlack;
                    Vehic.SecondaryColor = VehicleColor.MatteBlack;
                }
                else if (iExtraMod == 11)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.Alpha = 120;
                }
                else if (iExtraMod == 12)
                {
                    Vehic.Livery = -1;
                    Vehic.PrimaryColor = VehicleColor.MetallicBlazeRed;
                    Vehic.SecondaryColor = VehicleColor.MatteWhite;
                }
                else if (iExtraMod == 13)
                {
                    Vehic.Livery = -1;
                    Vehic.PrimaryColor = VehicleColor.MetallicDarkBlue;
                    Vehic.SecondaryColor = VehicleColor.MatteYellow;
                }
                else if (iExtraMod == 14)
                {
                    Vehic.LockStatus = VehicleLockStatus.Locked;
                    Vehic.NumberPlate = "DUPE";
                }
            }    // PaintJobs
            else if (iMod == 3)
            {
                if (iExtraMod == 1)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.SmashWindow(VehicleWindow.FrontLeftWindow);
                    Vehic.DirtLevel = 99.75f;
                    if (!MissionData.bTestRun)
                        NPCSpawn(ReturnStuff.RandNPC(18), Vehic.Position, 0.00f, false, 0, 9, 1, Vehic, 2, false, 0, 0, "");
                    Vehic.CurrentBlip.Color = BlipColor.Yellow;
                }
                else if (iExtraMod == 2)
                    Vehic.LockStatus = VehicleLockStatus.Locked;
                else if (iExtraMod == 3)
                {
                    Vehic.PrimaryColor = VehicleColor.MetallicWhite;
                    Vehic.SmashWindow(VehicleWindow.FrontLeftWindow);
                    Vehic.DirtLevel = 99.75f;
                    NPCSpawn(ReturnStuff.RandNPC(18), Vehic.Position, 0.00f, false, 150, 0, 1, Vehic, 2, false, 0, 0, "");
                    Vehic.CurrentBlip.Color = BlipColor.Yellow;
                }
                else if (iExtraMod == 4)
                {

                }
                else if (iExtraMod == 5)
                {

                }//not used
                else if (iExtraMod == 6)
                {

                }//not used
                else if (iExtraMod == 7)
                {

                }
                else if (iExtraMod == 8)
                {
                    ObjectHand.RemoveTargets();
                }

            }    // Random Mods
            else if (iMod == 4)
            {
                if (iExtraMod == 1)
                {
                    MyExtras.Add(1);
                    MyExtras.Add(2);
                    MyExtras.Add(4);
                    MyExtras.Add(5);
                    MyExtras.Add(10);
                }
                ModExtras(Vehic, MyExtras);
            }    // Trucking Sadler 
            else if (iMod == 5)
            {
                if (iExtraMod == 99)
                {
                    int iLive = ReturnStuff.RandInt(0, Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Vehic.Handle));

                    Function.Call(Hash.SET_VEHICLE_LIVERY, Vehic.Handle, iLive);
                }
                else
                {
                    if (iExtraMod <= Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Vehic))
                        Vehic.Livery = iExtraMod;
                }
            }    // Livery
            else if (iMod == 6)
            {
                Vehic.EngineRunning = true;
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), new Vector3(0.00f, 0.00f, 0.00f), 0.00f, false, 170, 4, 1, Vehic, 0, false, 0, 0, "");
                Function.Call(Hash._0x7BEB0C7A235F6F3B, Vehic.Handle, 0);
            }    // Add a NPCPiolot -- Job 6 area 4
            else if (iMod == 7)
            {
                TheMissions.Pilot04_ImportBob(Vehic);
            }    // Attach to cargobob -- Job 6 area 4
            else if (iMod == 8)
            {
                if (iExtraMod == 1)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn("", Vehic.Position, Vehic.Heading, false, 220, 14, iNoSeats, Vehic, 2, false, 0, 1, "");
                        iNoSeats -= 1;
                    }
                }       //player ed
                else if (iExtraMod == 2)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(4), Vehic.Position, Vehic.Heading, false, 150, 14, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //lost mc att 1
                else if (iExtraMod == 3)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = ReturnStuff.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        Ped Pedro = NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 190, 15, iNoSeats, Vehic, 2, true, 0, 0, "");
                        Pedro.RelationshipGroup = DataStore.GP_BNPCs;

                        if (iNoSeats == 1)
                            TheMissions.Follow_AddToMuilti(Pedro, "", Vehic.CurrentBlip, Vehic);
                        else
                            TheMissions.Follow_AddToMuilti(Pedro, "", null, null);

                        iNoSeats -= 1;
                    }
                }       //random add to MissionData.MultiPed list
                else if (iExtraMod == 4)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(4), Vehic.Position, Vehic.Heading, false, 150, 17, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //random
                else if (iExtraMod == 5)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = ReturnStuff.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 180, 14, iNoSeats, Vehic, 2, false, 1, 0, "");
                        iNoSeats -= 1;
                    }
                }       //lost mc att 2
                else if (iExtraMod == 9)
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = ReturnStuff.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        Ped Pedro = NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 150, 5, iNoSeats, Vehic, 2, false, 0, 0, "");
                        Pedro.RelationshipGroup = DataStore.GP_BNPCs;

                        if (iNoSeats == 1)
                            TheMissions.Follow_AddToMuilti(Pedro, "", Vehic.CurrentBlip, Vehic);
                        else
                            TheMissions.Follow_AddToMuilti(Pedro, "", null, null);

                        iNoSeats -= 1;
                    }
                }       //rand add to multi 
                else
                {
                    int iNoSeats = Vehic.PassengerSeats + 1;
                    int iRando = ReturnStuff.RandInt(1, 10);
                    while (iNoSeats > 0)
                    {
                        NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 150, 0, iNoSeats, Vehic, 2, false, 0, 0, "");
                        iNoSeats -= 1;
                    }
                }       //rand

                VehicleMods(Vehic, 2, 10, false);
            }    // Player Attackers..
            else if (iMod == 9)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                if (iExtraMod > 9)
                {
                    int iExtras = 14;
                    while (iExtras > 0)
                    {
                        if (Vehic.ExtraExists(iExtras))
                            Vehic.ToggleExtra(iExtras, true);
                        iExtras = iExtras - 1;
                    }
                    Vehic.SecondaryColor = VehicleColor.BrushedBlackSteel;
                    if (iExtraMod == 10)
                        Vehic.PrimaryColor = VehicleColor.MatteDarkRed;
                    else if (iExtraMod == 11)
                        Vehic.PrimaryColor = VehicleColor.MatteYellow;
                    else if (iExtraMod == 12)
                        Vehic.PrimaryColor = VehicleColor.MatteLimeGreen;
                    else if (iExtraMod == 13)
                        Vehic.PrimaryColor = VehicleColor.MatteBlue;
                }
            }    // BoatAnchor
            else if (iMod == 10)
            {
                Vehic.MaxHealth = 3000;
                Vehic.Health = 3000;
                MissionData.Npc_01 = NPCSpawn("s_m_m_security_01", Vehic.Position, Vehic.Heading, true, 180, 6, 2, Vehic, 2, false, 0, 0, "");
            }   // Security Van
            else if (iMod == 11)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                MissionData.Npc_01 = NPCSpawn("s_m_m_scientist_01", Vehic.Position, Vehic.Heading, false, 130, 7, 2, Vehic, 0, false, 0, 0, "");
                VehicleMods(Vehic, 1, iExtraMod, false);
            }   // Water Boat -- Area 3
            else if (iMod == 12)
            {
                Vehic.MaxHealth = 4000;
                Vehic.Health = 4000;
                Vehic.EngineRunning = true;
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), new Vector3(0.00f, 0.00f, 0.00f), 0.00f, false, 140, 8, 1, Vehic, 0, false, 0, 0, "");
            }   // Water Boat -- Area 1 Cargobob
            else if (iMod == 13)
            {
                MaxOutAllModsNoWheels(Vehic);
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);
                Ped Dog = NPCSpawn(ReturnStuff.RandNPC(32), Vector3.Zero, 0.00f, false, 190, 9, 1, Vehic, 0, false, 0, 0, "");
                PedMultiTask Fighter = ObjectBuild.AddAMultiped();
                Fighter.MyPed = Dog;
                Fighter.MyVehicle = Vehic;
                Fighter.MyBlip = Vehic.CurrentBlip;
                Fighter.MyTask_01 = 1;
                MissionData.MultiPed.Add(Fighter);
            }   // Dogfighers
            else if (iMod == 14)
            {
                Vehic.Explode();
            }   // Blow up Veh
            else if (iMod == 15)
            {
                Vehic.EngineRunning = true;
                NPCSpawn(ReturnStuff.RandNPC(33), Vehic.Position, Vehic.Heading, false, 180, 10, 1, Vehic, 2, false, 0, 0, "");
                Vehic.CurrentBlip.Color = BlipColor.Red;

            }   // Water Boat -- Area 1 Jetski Attack 
            else if (iMod == 16)
            {
                if (iExtraMod == 1)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.70f, 1.01f), new Vector3(-92.09f, 0.00f, 0.00f));
                else if (iExtraMod == 2)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.01f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 3)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.10f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 4)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 1.51f), new Vector3(0.00f, 0.00f, 0.00f));
                else if (iExtraMod == 5)
                    Vehic.AttachTo(MissionData.VehTrackin_02, MissionData.VehTrackin_02.GetBoneIndex("bodyshell"), new Vector3(-0.40f, 0.00f, 2.70f), new Vector3(0.00f, 0.00f, -90.00f));
            }   // TruckingAttachments
            else if (iMod == 17)
            {
                Vehic.Alpha = 120;
                Function.Call(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Vehic.Handle);
            }   // BuildVeh
            else if (iMod == 18)
            {
                VehicleWarp(Vehic, Game.Player.Character, 1);
            }   // PlayerToVeh
            else if (iMod == 19)
            {
                if (ReturnStuff.FindRandom(91, 1, 10) < 9)
                    MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(13), Vehic.Position, Vehic.Heading, false, 180, 11, 1, Vehic, 2, false, 0, 0, "");
                else
                    MissionData.Npc_01 = NPCSpawn("", Vehic.Position, Vehic.Heading, false, 180, 11, 1, Vehic, 2, false, 0, 1, "");
            }   // Casino parking
            else if (iMod == 20)
            {
                Ped TaxMan = NPCSpawn(ReturnStuff.RandNPC(iExtraMod), Vehic.Position, 0.00f, false, 120, 5, 1, Vehic, 2, false, 0, 0, "");
                PedMultiTask Taxi = ObjectBuild.AddAMultiped();
                Taxi.MyPed = TaxMan;
                Taxi.MyVehicle = Vehic;
                Taxi.MyBlip = Vehic.CurrentBlip;
                Taxi.MyTask_01 = 1;
                MissionData.MultiPed.Add(Taxi);
                ReturnStuff.VehBlip(Vehic, true, false, 1, "");
            }   // Crazy Taxies
            else if (iMod == 21)
            {
                if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                    VehicleMods(Vehic, 9, 0, false);
            }   // Raceing Carz
            else if (iMod == 22)
            {
                if (MissionData.iList_01[0] == 2 || MissionData.iList_01[0] == 6)
                    VehicleMods(Vehic, 9, 0, false);

                Vehic.EngineRunning = true;
                NPCSpawn(ReturnStuff.RandNPC(MissionData.iList_01[7]), Vehic.Position, 0.00f, false, 220, 1, 1, Vehic, 0, true, 3, 0, DataStore.MyLang.Maptext[109]);
            }   // Raceing Drivers
            else if (iMod == 23)
            {
                Vehic.IsVisible = false;
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                MissionData.Prop_01.AttachTo(Vehic, Vehic.GetBoneIndex("bodyshell"), new Vector3(0.00f, 0.00f, 0.00f), new Vector3(0.00f, 0.00f, -180.00f));
                MissionData.Prop_01.FreezePosition = false;
                Vehic.FreezePosition = false;
            }   // attach fake boat to barge
            else if (iMod == 24)
            {
                Vehic.Livery = 0;
                Vehic.PrimaryColor = VehicleColor.MetallicMarinerBlue;
                Vehic.SecondaryColor = VehicleColor.MetallicFrostWhite;
            }   // Heiltours
            else if (iMod == 25)
            {
                int iRando = ReturnStuff.RandInt(1, 10);
                NPCSpawn(ReturnStuff.RandNPC(iRando), Vehic.Position, Vehic.Heading, false, 180, 2, 1, Vehic, 2, false, 1, 0, "");
            }   // Drive Around
            else if (iMod == 26)
            {
                Vehic.OpenDoor(VehicleDoor.Trunk, false, true);
            }   // Cargo Truck tale
            else if (iMod == 27)
            {
                Function.Call(Hash.SET_BOAT_ANCHOR, Vehic.Handle, true);
                Vehic.PrimaryColor = VehicleColor.MetallicNauticalBlue;
            }   // Blue Sub
            else if (iMod == 28)
            {
                MissionData.Npc_01 = NPCSpawn(ReturnStuff.RandNPC(32), Vehic.Position, 0.00f, false, 140, 12, 1, Vehic, 0, false, 0, 0, "");
                NPCSpawn("ig_juanstrickler", Vehic.Position, 0.00f, false, 140, 12, 4, Vehic, 0, false, 0, 0, "");
            }   // thief heli
            else if (iMod == 29)
            {
                MissionData.Npc_02 = NPCSpawn(ReturnStuff.RandNPC(32), Vehic.Position, Vehic.Heading, false, 150, 7, 1, Vehic, 0, false, 0, 0, "");
            }   // BlankNpc2 Sitting In Vehicle
            else if (iMod == 30)
            {
                Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Vehic.Handle, 3);

                Prop Bench1 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench1.AttachTo(Vehic, 0, new Vector3(1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));

                Prop Bench2 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench2.AttachTo(Vehic, 0, new Vector3(-1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench3 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench3.AttachTo(Vehic, 0, new Vector3(-1.33f, -6.19f, -0.57f), new Vector3(0.04f, 0.00f, 90.00f));

                Prop Bench4 = BuildProp("prop_fib_3b_bench", Vehic.Position, Vector3.Zero, false, false);
                Bench4.AttachTo(Vehic, 0, new Vector3(1.33f, -2.70f, -0.57f), new Vector3(0.04f, 0.00f, 270.00f));

                NPCSpawn(ReturnStuff.RandNPC(32), Vector3.Zero, 0.00f, false, 190, 13, 1, Vehic, 0, false, 0, 0, "");
            }   // airjump plane
            else if (iMod == 31)
            {
                Vehic.LockStatus = VehicleLockStatus.Locked;
            }   // Door Lock
            else if (iMod == 32)
            {
                ReturnStuff.VehBlip(Vehic, false, false, 39, DataStore.MyLang.Maptext[21]);
                Vehic.CurrentBlip.Alpha = 100;
            }
            if (bModShop)
                ReturnStuff.MaxModsRandExtras(Vehic);
        }
        public static void GhostVehicle(Vehicle Vhick, Vector3 Vpos, float fHeads)
        {
            LoggerLight.LogThis("GhostVehicle");

            Vhick.Position = Vpos;
            Vhick.Heading = fHeads;
            int iFailed = 50;
            while (!Vhick.IsOnAllWheels && iFailed > 0)
            {
                StayOnGround(Vhick);
                Script.Wait(100);
                iFailed -= 1;
            }

            if (iFailed > 0)
            {
                Vhick.FreezePosition = true;
                Vhick.HasCollision = false;
                Vhick.Alpha = 120;
                Vhick.Heading = fHeads;
                Vhick.LockStatus = VehicleLockStatus.Locked;
            }
            else
            {
                UI.Notify("Item Failed to render intime.");
                MissionData.iMissionSeq = 45;
            }

        }
        public static void StayOnGround(Vehicle Vhick)
        {
            LoggerLight.LogThis("StayOnGround");

            Function.Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Vhick.Handle);
        }
        public static Prop BuildProp(string sProper, Vector3 Position, Vector3 Rotation, bool bFreeze, bool bSetLOD)
        {
            LoggerLight.LogThis("BuildProp, sProper == " + sProper + ", bFreeze == " + bFreeze);

            Prop BuildPop = null;

            int iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, sProper);

            if (!Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iPropHash))
            {
                LoggerLight.LogThis("BuildProp, spropMissing...");
                iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, "zprop_bin_01a_old");
            }

            Function.Call(Hash.REQUEST_MODEL, iPropHash);
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iPropHash))
                Script.Wait(1);

            int iProps = Function.Call<int>(Hash.CREATE_OBJECT, iPropHash, Position.X, Position.Y, Position.Z, false, true, false);
            BuildPop = new Prop(iProps);

            if (BuildPop.Exists())
            {
                BuildPop.Rotation = Rotation;
                BuildPop.IsPersistent = true;
                BuildPop.HasCollision = true;
                BuildPop.FreezePosition = bFreeze;

                if (bSetLOD)
                    Function.Call(Hash.SET_ENTITY_LOD_DIST, BuildPop.Handle, 1500);

                MissionData.PropList_01.Add(new Prop(BuildPop.Handle));

                ObjectHand.ReadWriteBlips(false, true, -1, -1, -1, BuildPop.Handle, -1, -1);
            }
            else
                BuildPop = null;

            Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);

            return BuildPop;
        }
    }
}
