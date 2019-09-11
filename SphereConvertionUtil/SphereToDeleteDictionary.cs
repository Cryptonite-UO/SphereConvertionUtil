using System;
using System.Collections.Generic;

namespace SphereConvertionUtil
{
    public static class SphereToDeleteDictionary
    {
        private static List<String> DeleteList = new List<string>();

        public static List<string> Init()
        {
            DeleteList.Add("i_arena_random");

            DeleteList.Add("i_arena_random_2v2");
            
            DeleteList.Add("i_pierre_depecage_dragon_small_red");
                        
            DeleteList.Add("i_pierre_depecage_dragon_small_black");
            
            return DeleteList;
        }
    }
}
