using GTA;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace New_Street_Phone_Missions
{
    public class ReadWriteXML : DataStore
    {
        public static void SaveXmlWards(List<ClothX> config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlClothDefault : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(List<ClothX>));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlCloths(List<ClothBank> config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlClothDefault : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(List<ClothBank>));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlSets(XmlSetings config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlSets : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlCustom(XmlCustomVeh config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlCustom : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(XmlCustomVeh));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlBlip(BlipStore config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlBlip : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(BlipStore));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlLing(Lingoo config, string fileName)
        {
            LoggerLight.LogThis("SaveXml : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(Lingoo));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlContacts(XmlContacts config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlContacts : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveRaceLines(RacingLines config, string fileName)
        {
            LoggerLight.LogThis("RacingLinesXML : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(RacingLines));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveRaces(MuliRace config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(MuliRace));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static XmlSetings LoadXmlSets(string fileName)
        {
            LoggerLight.LogThis("XmlSetings : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (XmlSetings)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new XmlSetings();
                }
            }
            else
                return new XmlSetings();
        }
        public static XmlCustomVeh LoadXmlCustom(string fileName)
        {
            LoggerLight.LogThis("LoadXmlCustom : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(XmlCustomVeh));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (XmlCustomVeh)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new XmlCustomVeh();
                }
            }
            else
                return new XmlCustomVeh();
        }
        public static BlipStore LoadXmlBlip(string fileName)
        {
            LoggerLight.LogThis("LoadXmlBlip : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(BlipStore));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (BlipStore)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new BlipStore();
                }
            }
            else
                return new BlipStore();
        }
        public static Lingoo LoadXmlLing(string fileName)
        {
            LoggerLight.LogThis("LoadXmlLing : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Lingoo));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (Lingoo)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return DataStore.LangRewite();
                }
            }
            else
                return DataStore.LangRewite();
        }
        public static List<ClothX> LoadWards(string fileName)
        {
            LoggerLight.LogThis("LoadXmlClothDefault : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<ClothX>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (List<ClothX>)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new List<ClothX>();
                }
            }
            else
                return new List<ClothX>();
        }
        public static List<ClothBank> LoadCloths(string fileName)
        {
            LoggerLight.LogThis("LoadXmlClothDefault : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<ClothBank>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (List<ClothBank>)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new List<ClothBank>();
                }
            }
            else
                return new List<ClothBank>();
        }
        public static XmlContacts LoadXmlContacts(string fileName)
        {
            LoggerLight.LogThis("LoadXmlContacts : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (XmlContacts)xml.Deserialize(sr);
                    }

                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new XmlContacts();
                }
            }
            else
                return new XmlContacts();
        }
        public static RacingLines LoadRaceLines(string fileName)
        {
            LoggerLight.LogThis("LoadRaceLines : " + fileName);
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(RacingLines));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        return (RacingLines)xml.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                    return new RacingLines();
                }
            }
            else
                return new RacingLines();
        }
        public static MuliRace LoadRaceists(string fileName)
        {
            LoggerLight.LogThis("LoadRaceists : " + fileName);
            MuliRace ThisRace = null;
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(MuliRace));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ThisRace = (MuliRace)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                }
            }

            return ThisRace;
        }
        public static List<Truckers> LoadTrucking(string fileName)
        {
            LoggerLight.LogThis("LoadTrucking : " + fileName);
            List<Truckers> ThisTruck = null;
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Truckers>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ThisTruck = (List<Truckers>)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                }
            }

            return ThisTruck;
        }
        public static List<BombSquad> LoadBombing(string fileName)
        {
            LoggerLight.LogThis("LoadBombing : " + fileName);
            List<BombSquad> ThisTruck = null;
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<BombSquad>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ThisTruck = (List<BombSquad>)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                }
            }

            return ThisTruck;
        }
        public static List<LoanSharks> LoadSharky(string fileName)
        {
            LoggerLight.LogThis("LoadSharky : " + fileName);
            List<LoanSharks> ThisTruck = null;
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<LoanSharks>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ThisTruck = (List<LoanSharks>)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                }
            }

            return ThisTruck;
        }
        public static List<FubarVectors> LoadFubies(string fileName)
        {
            LoggerLight.LogThis("LoadFubies : " + fileName);
            List<FubarVectors> ThisTruck = null;
            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<FubarVectors>));
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ThisTruck = (List<FubarVectors>)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                }
            }

            return ThisTruck;
        }
    }
}
