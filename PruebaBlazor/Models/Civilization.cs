using System.Collections.Generic;

namespace PruebaBlazor.Models
{
    public class Civilitations
    {
        public List<Civilization> civilizations { get; set; }
        public Civilitations()
        {
            civilizations = new List<Civilization>();
        }
    }
    public class Civilization
    {
        public int id { get; set; }
        public string name { get; set; }
        public string expansion { get; set; }
        public string army_type { get; set; }
        public string[] unique_unit { get; set; }
        public string[] unique_tech { get; set; }
        public string team_bonus { get; set; }
        public string[] civilization_bonus { get; set; }
    }

}
