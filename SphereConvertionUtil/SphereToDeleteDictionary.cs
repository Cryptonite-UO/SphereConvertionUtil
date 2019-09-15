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

            DeleteList.Add("i_targ_peacemaking");

            DeleteList.Add("i_delai_peacemaking");

            DeleteList.Add("i_house_key");

            DeleteList.Add("i_house_open");

            DeleteList.Add("i_friends");

            DeleteList.Add("i_coown");

            DeleteList.Add("i_friends");

            DeleteList.Add("i_sheet_log");

            DeleteList.Add("i_humain_holocurst_stone");

            DeleteList.Add("i_humain_holocurst_stone");



            return DeleteList;
        }
    }
}
