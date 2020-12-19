using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Library
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors { get; set; } = new List<string>();
        public Badge() { }
        public Badge (int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID; // will == dictionary key value (int badgeID)
            ListOfDoors = listOfDoors;
        }

    }
}
