using System.Collections.Generic;

namespace New_Street_Phone_Missions.Classes
{
    public class ClothBank
    {
        public string Title { get; set; }

        public List<int> ClothA { get; set; }
        public List<int> ClothB { get; set; }

        public List<int> ExtraA { get; set; }
        public List<int> ExtraB { get; set; }

        public ClothBank()
        {
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();
        }
    }
}
