using New_Street_Phone_Missions.Classes;
using System;
using System.IO;
using System.Xml.Serialization;

namespace New_Street_Phone_Missions
{
    public class ReadWriteXML : DataStore
    {
        public static void SaveXmlClothDefault(ClothBank config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlClothDefault : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlCloth(ClothBankXML config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlCloth : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(ClothBankXML));
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
        public static void SaveXmlCustom(CustomVeh config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlCustom : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(CustomVeh));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlCont(XmlContacts config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlCont : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static void SaveXmlRand(RandomPlusList config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlRand : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(RandomPlusList));
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
        public static void SaveXmlMish(MissionBuilder config, string fileName)
        {
            LoggerLight.LogThis("SaveXmlMish : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(MissionBuilder));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static ClothBank LoadXmlClothDefault(string fileName)
        {
            LoggerLight.LogThis("LoadXmlClothDefault : " + fileName);

            ClothBank YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (ClothBank)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlClothDefault : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlClothDefault : Failed");
                return null;
            }
        }
        public static ClothBankXML LoadXmlCloth(string fileName)
        {
            LoggerLight.LogThis("LoadXmlCloth : " + fileName);

            ClothBankXML YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ClothBankXML));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (ClothBankXML)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlCloth : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlCloth : Failed");
                return null;
            }

        }
        public static XmlSetings LoadXmlSets(string fileName)
        {
            LoggerLight.LogThis("XmlSetings : " + fileName);

            XmlSetings YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (XmlSetings)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlSets : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlSets : Failed");
                return null;
            }
        }
        public static CustomVeh LoadXmlCustom(string fileName)
        {
            LoggerLight.LogThis("LoadXmlCustom : " + fileName);

            CustomVeh YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(CustomVeh));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (CustomVeh)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlCustom : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlCustom : Failed");
                return null;
            }
        }
        public static XmlContacts LoadXmlCont(string fileName)
        {
            LoggerLight.LogThis("LoadXmlCont : " + fileName);

            XmlContacts YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(XmlContacts));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (XmlContacts)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlCont : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlCont : Failed");
                return null;
            }
        }
        public static RandomPlusList LoadXmlRand(string fileName)
        {
            LoggerLight.LogThis("LoadXmlRand : " + fileName);

            RandomPlusList YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(RandomPlusList));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (RandomPlusList)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlRand : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlRand : Failed");
                return null;
            }
        }
        public static BlipStore LoadXmlBlip(string fileName)
        {
            LoggerLight.LogThis("LoadXmlBlip : " + fileName);

            BlipStore YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(BlipStore));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (BlipStore)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlBlip : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlBlip : Failed");
                return null;
            }
        }
        public static Lingoo LoadXmlLing(string fileName)
        {
            LoggerLight.LogThis("LoadXmlLing : " + fileName);

            Lingoo YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Lingoo));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (Lingoo)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmlLing : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmlLing : Failed");
                return null;
            }
        }
        public static MissionBuilder LoadXmMissions(string fileName)
        {
            LoggerLight.LogThis("LoadXmMissions : " + fileName);

            MissionBuilder YourBank;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(MissionBuilder));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    YourBank = (MissionBuilder)xml.Deserialize(sr);
                }
                LoggerLight.LogThis("LoadXmMissions : Worked");
                return YourBank;
            }
            catch (Exception)
            {
                LoggerLight.LogThis("LoadXmMissions : Failed");
                return null;
            }
        }
    }
}
