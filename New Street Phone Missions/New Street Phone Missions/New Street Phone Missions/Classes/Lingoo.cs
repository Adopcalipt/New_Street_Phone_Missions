using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class Lingoo
    {
        public List<string> Maptext { get; set; }
        public List<string> Mistext { get; set; }
        public List<string> Context { get; set; }
        public List<string> Jobtext { get; set; }
        public List<string> Othertext { get; set; }
        public List<string> ContactLang { get; set; }
        public List<string> YachtLang { get; set; }

        public Lingoo()
        {
            Maptext = new List<string>();
            Mistext = new List<string>();
            Context = new List<string>();
            Jobtext = new List<string>();
            Othertext = new List<string>();
            ContactLang = new List<string>();
            YachtLang = new List<string>();
        }
    }
}
