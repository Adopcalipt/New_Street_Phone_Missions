using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using NSPMSettings.Classes;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace NSPMSettings
{
    public partial class Form1 : Form
    {
        private int _lastFormSize;
        private readonly string sNSPMSet = "" + Directory.GetCurrentDirectory() + "/Settings.Xml";
        private readonly string sNSPMAddonCarz = "" + Directory.GetCurrentDirectory() + "/NSPMAddonCarz.Xml";
        private XmlSetings MySettings = new XmlSetings();
        private CustomVeh MyCusVEh = new CustomVeh();

        public class CustomVeh
        {
            public List<string> MyCarz { get; set; }
            public List<string> MyPlanez { get; set; }
            public List<string> MyBoatz { get; set; }
            public List<string> MyChopperz { get; set; }

            public CustomVeh()
            {
                MyCarz = new List<string>();
                MyPlanez = new List<string>();
                MyBoatz = new List<string>();
                MyChopperz = new List<string>();
            }
        }
        public void SaveCustomVeh(CustomVeh config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(CustomVeh));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public CustomVeh LoadCustomVeh(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(CustomVeh));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (CustomVeh)xml.Deserialize(sr);
            }
        }
        private void AddToVehList(string sVeh)
        {
            if (File.Exists(sNSPMAddonCarz))
                MyCusVEh = LoadCustomVeh(sNSPMAddonCarz);

            MyCusVEh.MyCarz.Add(sVeh);

            SaveCustomVeh(MyCusVEh, sNSPMAddonCarz);
        }
        public void SaveXmlSettings(XmlSetings config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public XmlSetings LoadXmlSetting(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (XmlSetings)xml.Deserialize(sr);
            }
        }
        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }
        private void ResizeAlize(object sender, EventArgs e)
        {
            if (GetFormArea(this.Size) > _lastFormSize + 100 || GetFormArea(this.Size) < _lastFormSize - 100)
            {
                Control control = (Control)sender;
                float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;
                ResizeFont(this.Controls, scaleFactor);
                _lastFormSize = GetFormArea(control.Size);
            }
        }
        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    if (true)
                    {
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            this.Resize += new EventHandler(ResizeAlize);
            _lastFormSize = GetFormArea(this.Size);

            ReadXmlSet();
        }
        public string LangText(int iText)
        {
            if (iText < 1 || iText > 13)
                iText = 0;
            List<string> Lang = new List<string>
            {
                "Auto Select",//0
                "English",//1
                "中國人",
                "中国人",
                "français",
                "Deutsch",
                "Italiano",
                "日本",
                "한국어",
                "Mexicano--Desaparecido",
                "Polski",
                "português",
                "русский",
                "Español"
            };

            return Lang[iText];
        }
        public void ReadXmlSet()
        {
            if (File.Exists(sNSPMSet))
                MySettings = LoadXmlSetting(sNSPMSet);
            else
            {
                MySettings = DefaultSet();
            }
            LoadForms();
        }
        public XmlSetings DefaultSet()
        {
            XmlSetings NewSet = new XmlSetings
            {
                Truckin = true,
                Getaway = true,
                Packages = true,
                Convicts = true,
                FUber = true,
                Pilot = true,
                Amulance = true,
                Follow = true,
                LSFD = true,
                Johnny = true,
                Raceist = true,
                BBBomb = true,
                Sailor = true,
                Gruppe6 = true,
                Assassination = true,
                ImportantEx = true,
                DebtCollect = true,
                MCBusiness = true,
                BayLift = true,
                Sharks = true,
                HappyShopper = true,
                MoresMute = true,
                TempJob = true,
                ParaDisplay = true,
                Deliverwho = true,

                ShowRoute = true,
                EnemyStrength = true,
                FastTraveltoStart = false,
                Subtitles = true,
                PhoneCone = true,
                PhoneAudio = true,
                BulderOnly = false,
                MenyooAppFixer = false,
                StartOnYAcht = false,

                LowerAim = 25,
                UpperAim = 75,

                AssZone01 = 0,
                AssZone02 = 0,
                AssZone03 = 0,
                AssZone04 = 0,
                AssZone05 = 0,
                AssZone06 = 0,
                AssZone07 = 0,

                SPDelayTime = 4000,
                YachtPrice = 6000000,
                ModVersion = 0,
                PhoneAnim = true,
                PreLoadOnline = true,
                LangSupport = 0,
                WhyNotSubscribe = 0
            };

            return NewSet;
        }
        public void LoadForms()
        {
            decimal Yp = 0;
            if (MySettings.YachtPrice <= 100000000 || MySettings.YachtPrice >= 0)
                Yp = MySettings.YachtPrice;
            else
                MySettings.YachtPrice = 0;

            decimal Ls = -1;
            if (MySettings.LangSupport <= 13 || MySettings.LangSupport >= -1)
                Ls = MySettings.LangSupport;
            else
                MySettings.LangSupport = -1;

            checkBox1.Checked = MySettings.ShowRoute;
            checkBox2.Checked = MySettings.Subtitles;
            checkBox3.Checked = MySettings.PhoneCone;
            checkBox4.Checked = MySettings.PhoneAudio;
            checkBox5.Checked = MySettings.PhoneAnim;
            checkBox6.Checked = MySettings.MenyooAppFixer;
            checkBox7.Checked = MySettings.EnemyStrength;
            checkBox8.Checked = MySettings.FastTraveltoStart;
            checkBox9.Checked = MySettings.BulderOnly;
            checkBox10.Checked = MySettings.PreLoadOnline;

            numericUpDown1.Value = Yp;
            numericUpDown2.Value = Ls;

            textBox1.Text = LangText(MySettings.LangSupport);

            checkBox11.Checked = MySettings.Truckin;
            checkBox12.Checked = MySettings.Getaway;
            checkBox13.Checked = MySettings.Packages;
            checkBox14.Checked = MySettings.Convicts;
            checkBox15.Checked = MySettings.FUber;
            checkBox16.Checked = MySettings.Pilot;
            checkBox17.Checked = MySettings.Amulance;
            checkBox18.Checked = MySettings.Follow;
            checkBox19.Checked = MySettings.LSFD;
            checkBox20.Checked = MySettings.Johnny;
            checkBox21.Checked = MySettings.Raceist;
            checkBox22.Checked = MySettings.BBBomb;
            checkBox35.Checked = MySettings.Assassination;
            checkBox23.Checked = MySettings.Gruppe6;
            checkBox24.Checked = MySettings.Sailor;
            checkBox25.Checked = MySettings.ImportantEx;
            checkBox26.Checked = MySettings.DebtCollect;
            checkBox27.Checked = MySettings.MCBusiness;
            checkBox28.Checked = MySettings.BayLift;
            checkBox29.Checked = MySettings.Sharks;
            checkBox30.Checked = MySettings.HappyShopper;
            checkBox31.Checked = MySettings.MoresMute;
            checkBox32.Checked = MySettings.TempJob;
            checkBox33.Checked = MySettings.ParaDisplay;
            checkBox34.Checked = MySettings.Deliverwho;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.ShowRoute = checkBox1.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Subtitles = checkBox2.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.PhoneCone = checkBox3.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.PhoneAudio = checkBox4.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.PhoneAnim = checkBox5.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.MenyooAppFixer = checkBox6.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.EnemyStrength = checkBox7.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.FastTraveltoStart = checkBox8.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.BulderOnly = checkBox9.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.PreLoadOnline = checkBox10.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MySettings.YachtPrice = (int)numericUpDown1.Value;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            MySettings.LangSupport = (int)numericUpDown2.Value;
            textBox1.Text = LangText(MySettings.LangSupport);
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Truckin = checkBox11.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Getaway = checkBox12.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Packages = checkBox13.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Convicts = checkBox14.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.FUber = checkBox15.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Pilot = checkBox16.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Amulance = checkBox17.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Follow = checkBox18.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.LSFD = checkBox19.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Johnny = checkBox20.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Raceist = checkBox21.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.BBBomb = checkBox22.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Assassination = checkBox35.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Gruppe6 = checkBox23.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Sailor = checkBox24.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.ImportantEx = checkBox25.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.DebtCollect = checkBox26.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.MCBusiness = checkBox27.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.BayLift = checkBox28.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Sharks = checkBox29.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.HappyShopper = checkBox30.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.MoresMute = checkBox31.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.TempJob = checkBox32.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.ParaDisplay = checkBox33.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Deliverwho = checkBox34.Checked;
            SaveXmlSettings(MySettings, sNSPMSet);
        }
        public string HoverText(int iText)
        {
            if (iText < 1 || iText > 12)
                iText = 0;
            List<string> Lang = new List<string>
            {
                "",//0
                "Missions use the ingame gps system.",//1
                "Lowers the amount of damage enemys make to the player.",
                "Move the player to the mission start.",
                "Have mission requirements displayed by message or by banner",
                "Add Blip and marker to the current street phone.",
                "Audible phone ring to the current street phone.",
                "The price for the yacht in NSCoins, set from 0 to 10,000,000",
                "Have the player, play an animation on phone answer.",
                "Pre-Load DLC Maps, this updates the map to an online version on load.",
                "Loads apartments that would be missing if using menyoo and Pre-Load MP",
                "Select own built missions for trucking, packages, convicts, johnny, racist, explosive device, assassination and sharks",
                "Select a pre-set language or translate any language Xml to your native language and select that.",
            };

            return Lang[iText];
        }
        private void label2_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(1);
        }
        private void label3_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(2);
        }
        private void label4_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(3);
        }
        private void label5_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(4);
        }
        private void label6_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(5);
        }
        private void label7_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(6);
        }
        private void label8_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(7);
        }
        private void label9_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(8);
        }
        private void label10_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(9);
        }
        private void label11_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(10);
        }
        private void label12_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(11);
        }
        private void label38_hover(object sender, EventArgs e)
        {
            textBox2.Text = HoverText(12);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();
            testDialog.ShowDialog(this);

            while (!testDialog.bisReady)
            { }

            if (testDialog.sNamed != "")
                AddToVehList(testDialog.sNamed);
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Truckin = checkBox36.Checked;
            checkBox11.Checked = checkBox36.Checked;

            MySettings.Getaway = checkBox36.Checked;
            checkBox12.Checked = checkBox36.Checked;

            MySettings.Packages = checkBox36.Checked;
            checkBox13.Checked = checkBox36.Checked;

            MySettings.Convicts = checkBox36.Checked;
            checkBox14.Checked = checkBox36.Checked;

            MySettings.FUber = checkBox36.Checked;
            checkBox15.Checked = checkBox36.Checked;

            MySettings.Pilot = checkBox36.Checked;
            checkBox16.Checked = checkBox36.Checked;

            MySettings.Amulance = checkBox36.Checked;
            checkBox17.Checked = checkBox36.Checked;

            MySettings.Follow = checkBox36.Checked;
            checkBox18.Checked = checkBox36.Checked;

            MySettings.LSFD = checkBox36.Checked;
            checkBox19.Checked = checkBox36.Checked;

            MySettings.Johnny = checkBox36.Checked;
            checkBox20.Checked = checkBox36.Checked;

            MySettings.Raceist = checkBox36.Checked;
            checkBox21.Checked = checkBox36.Checked;

            MySettings.BBBomb = checkBox36.Checked;
            checkBox22.Checked = checkBox36.Checked;

            MySettings.Assassination = checkBox36.Checked;
            checkBox35.Checked = checkBox36.Checked;

            MySettings.Gruppe6 = checkBox36.Checked;
            checkBox23.Checked = checkBox36.Checked;

            MySettings.Sailor = checkBox36.Checked;
            checkBox24.Checked = checkBox36.Checked;

            MySettings.ImportantEx = checkBox36.Checked;
            checkBox25.Checked = checkBox36.Checked;

            MySettings.DebtCollect = checkBox36.Checked;
            checkBox26.Checked = checkBox36.Checked;

            MySettings.MCBusiness = checkBox36.Checked;
            checkBox27.Checked = checkBox36.Checked;

            MySettings.BayLift = checkBox36.Checked;
            checkBox28.Checked = checkBox36.Checked;

            MySettings.Sharks = checkBox36.Checked;
            checkBox29.Checked = checkBox36.Checked;

            MySettings.HappyShopper = checkBox36.Checked;
            checkBox30.Checked = checkBox36.Checked;

            MySettings.MoresMute = checkBox36.Checked;
            checkBox31.Checked = checkBox36.Checked;

            MySettings.TempJob = checkBox36.Checked;
            checkBox32.Checked = checkBox36.Checked;

            MySettings.ParaDisplay = checkBox36.Checked;
            checkBox33.Checked = checkBox36.Checked;


            MySettings.Deliverwho = checkBox36.Checked;
            checkBox34.Checked = checkBox36.Checked;

            SaveXmlSettings(MySettings, sNSPMSet);
        }
    }
}
