using System;
using System.Collections.Generic;

namespace SphereConvertionUtil
{
    public static class SphereHousesDictionary
    {
        private static Dictionary<string, string> Houses = new Dictionary<string, string>();

        public static Dictionary<string, string> Init()
        {
            Houses.Add("i_terrain_10x16", "");

            Houses.Add("i_terrain_8x16", "");

            Houses.Add("i_terrain_16x12", "");

            Houses.Add("i_terrain_24x17", "");

            Houses.Add("i_terrain_20x20", "");

            Houses.Add("i_terrain_31x31", "");

            Houses.Add("i_terrain_24x24", "");

            Houses.Add("i_terrain_11x11", "");

            Houses.Add("i_terrain_14x14", "");

            Houses.Add("i_terrain_7x7", "");

            //04064
            Houses.Add("i_multi_house_stone_plaster_small", "m_stone_and_plaster_house");

            //04066
            Houses.Add("i_multi_house_stone_small", "m_field_stone_house");

            //04068
            Houses.Add("i_multi_house_stone_brick_small", "m_small_brick_house");

            //0406a
            Houses.Add("i_multi_house_stone_wood_small", "m_wooden_house");

            //0406c
            Houses.Add("i_multi_house_wood_plaster_small", "m_wood_and_plaster_house");

            //0406e
            Houses.Add("i_multi_house_wood_thatched_small", "m_thatched_roof_cottage");

            //04070
            Houses.Add("i_multi_tent_blue", "");

            //04072
            Houses.Add("i_multi_tent_green", "");

            //04074
            Houses.Add("i_multi_house_3room", "m_brick_house");

            //04076
            Houses.Add("i_multi_house_wood_plaster_2story", "m_two_story_wood_and_plaster_house");

            //04078
            Houses.Add("i_multi_house_stone_plaster_2story", "m_two_story_stone_and_plaster_house");

            //0407c
            Houses.Add("i_multi_keep", "m_small_stone_keep");

            //0407e
            Houses.Add("i_multi_castle", "m_castle");

            //04087
            Houses.Add("i_multi_shop_blacksmithy_large_2", "m_large_house_with_patio");

            //0408c
            Houses.Add("i_multi_shop_blacksmithy_large", "m_large_house_with_patio");

            //04096
            Houses.Add("i_multi_house_patio_marble", "m_marble_house_with_patio");

            //04098
            Houses.Add("i_multi_tower_wizard", "m_small_stone_tower");

            //0407a
            Houses.Add("i_multi_tower", "m_tower");

            //0409a
            Houses.Add("i_multi_cabin_log_2story", "m_two_story_log_cabin");

            //0409c
            Houses.Add("i_multi_house_patio_sand", "m_sandstone_house_with_patio");

            //0409e
            Houses.Add("i_multi_villa_2story", "m_two_story_villa");

            //040a0
            Houses.Add("i_multi_shop_stone_small", "m_small_stone_workshop");

            //040a2
            Houses.Add("i_multi_shop_marble_small", "m_small_marble_workshop");
            
            //04BB8
            //Houses.Add("i_multi_house_wheat_cottage", "?????"); //BESOIN DE TROUVER L'ÉQUIVALENT

            return Houses;
        }
    }
}
