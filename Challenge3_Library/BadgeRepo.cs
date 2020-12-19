using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Library
{
    public class BadgeRepo
    {
        // FIELD to use in CRUD methods 
        private Dictionary<int, Badge> _dictionaryOfBadges = new Dictionary<int, Badge>();

        //CRUD
        //Create new badge and add to dictionary with badgeID as key
        public void AddBadgeToDictionary(int badgeID, Badge badge)
        {
            _dictionaryOfBadges.Add(badgeID, badge);
        }

        //Read (returns dictionary of keys (ids) w/ values (badges with id number and door list)
        public Dictionary<int, Badge> ShowAllBadges()
        {
            return _dictionaryOfBadges;
        }

        //Update 
            // No functionality needed (updating doors will be done in UI by adding/deleting list entries with list.add/.delete/.clear, 
            //      and no requirement to modify badge numbers

        //Delete
            // No functionality needed - only doors deleted, not badge 
            // Single door = list.Remove(door);
            // All doors = list.Clear();

        //Helper Methods
            //Get Badge by Key  
                // to find entry in dictionary.ContainsKey() in UI, returns bool
            //Get list entry
                // to find list item use list.Contains()




    }
}