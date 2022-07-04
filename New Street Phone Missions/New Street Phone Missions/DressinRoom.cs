using GTA;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class DressinRoom 
    {
        public static void LoadPlayerOut()
        {
            LoggerLight.LogThis("LoadPlayerOut");

            string sDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe";
            if (Directory.Exists(sDir))
            {
                string sFreeM = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml";
                string sFreeF = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml";

                if (File.Exists(sFreeF))
                    DataStore.FemaleCloth = ReadWriteXML.LoadXmlCloth(sFreeF);

                if (File.Exists(sFreeM))
                    DataStore.MaleCloth = ReadWriteXML.LoadXmlCloth(sFreeM);
            }
        }
        public static int DoesThisExist(string sPed, string sTitle)
        {
            string sOutDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe";

            int iFind = -1;
            if (File.Exists(sOutDir + "/" + sPed + ".Xml"))
            {
                ClothBankXML MyWardrobe = ReadWriteXML.LoadXmlCloth(sOutDir + "/" + sPed + ".Xml");

                for (int i = 0; i < MyWardrobe.Outfits.Count(); i++)
                {
                    if (MyWardrobe.Outfits[i].Title == sTitle)
                    {
                        iFind = i;
                    }
                }
            }

            return iFind;
        }
        public static void UpdateOldXMLs()
        {
            LoggerLight.LogThis("UpdateOldXMLs");

            string sOldDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit";

            if (Directory.Exists(sOldDir))
            {
                ClothBankXML Franklin = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Franklin.Xml");
                ClothBankXML Michael = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Michael.Xml");
                ClothBankXML Trevor = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Trevor.Xml");
                ClothBankXML FreemodeFemale = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml");
                ClothBankXML FreemodeMale = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml");

                string[] sWrite = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit");
                for (int i = 0; i < sWrite.Count(); i++)
                {
                    if (File.Exists(sWrite[i]))
                    {
                        ClothBank NewBank = ReadWriteXML.LoadXmlClothDefault(sWrite[i]);

                        if (sWrite[i].Contains("_"))
                        {
                            string sting = sWrite[i];
                            int iNum = sting.LastIndexOf("_") + 1;
                            sting = sting.Substring(iNum);
                            NewBank.Title = sting.Substring(0, sting.Count() - 4);

                            if (sWrite[i].Contains("Franklin"))
                            {
                                int iAm = DoesThisExist("Franklin", NewBank.Title);
                                if (iAm == -1)
                                    Franklin.Outfits.Add(NewBank);
                                else
                                    Franklin.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("Michael"))
                            {
                                int iAm = DoesThisExist("Michael", NewBank.Title);
                                if (iAm == -1)
                                    Michael.Outfits.Add(NewBank);
                                else
                                    Michael.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("Trevor"))
                            {
                                int iAm = DoesThisExist("Trevor", NewBank.Title);
                                if (iAm == -1)
                                    Trevor.Outfits.Add(NewBank);
                                else
                                    Trevor.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("FreeFemale"))
                            {
                                int iAm = DoesThisExist("FreemodeFemale", NewBank.Title);
                                if (iAm == -1)
                                    FreemodeFemale.Outfits.Add(NewBank);
                                else
                                    FreemodeFemale.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("FreeMale"))
                            {
                                int iAm = DoesThisExist("FreemodeMale", NewBank.Title);
                                if (iAm == -1)
                                    FreemodeMale.Outfits.Add(NewBank);
                                else
                                    FreemodeMale.Outfits[iAm] = NewBank;
                            }
                        }
                        File.Delete(sWrite[i]);
                    }
                }
                ReadWriteXML.SaveXmlCloth(Franklin, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Franklin.Xml");
                ReadWriteXML.SaveXmlCloth(Michael, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Michael.Xml");
                ReadWriteXML.SaveXmlCloth(Trevor, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Trevor.Xml");
                ReadWriteXML.SaveXmlCloth(FreemodeFemale, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml");
                ReadWriteXML.SaveXmlCloth(FreemodeMale, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml");
                Directory.Delete(sOldDir);
            }

            LoadPlayerOut();
        }
        public static void WardrobeScan(int iOutfit)
        {
            LoggerLight.LogThis("WardrobeScan, iOutfit == " + iOutfit);

            ClothBank ThisOut = new ClothBank();

            int iPed = 0;

            if (Game.Player.Character.Model == PedHash.Franklin)
                iPed = 1;
            else if (Game.Player.Character.Model == PedHash.Michael)
                iPed = 2;
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iPed = 3;
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
                iPed = 4;
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
                iPed = 5;
            else
                iPed = 99;
            if (iPed == 99)
            {
                if (iOutfit == 2)
                {
                    TheMissions.Deliverwho_Backpack(iPed);
                }
            }
            else
            {
                Ped Peddy = Game.Player.Character;

                int iCloth = 0;
                while (iCloth < 12)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Peddy.Handle, iCloth);
                    ThisOut.ClothA.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Peddy.Handle, iCloth);
                    ThisOut.ClothB.Add(iTextId);
                    iCloth = iCloth + 1;
                }
                int iExtra = 0;
                while (iExtra < 5)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Peddy.Handle, iExtra);
                    ThisOut.ExtraA.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Peddy.Handle, iExtra);
                    ThisOut.ExtraB.Add(iTextId);
                    iExtra = iExtra + 1;
                }

                if (iOutfit == 1)
                {
                    ReadWriteXML.SaveXmlClothDefault(ThisOut, DataStore.sDefaulted);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
                    TheMissions.TempAgency_04_Discises(iPed);
                }
                else if (iOutfit == 2)
                {
                    ReadWriteXML.SaveXmlClothDefault(ThisOut, DataStore.sDefaulted);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
                    TheMissions.Deliverwho_Backpack(iPed);
                }
            }
        }
    }
}
