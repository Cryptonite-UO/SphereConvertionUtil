using System;
using System.Collections;
using System.Collections.Generic;

namespace SphereConvertionUtil
{
    public static class SphereItemsDictionary
    {
        private static Dictionary<string, string> Items = new Dictionary<string, string>();

        public static Dictionary<string, string> Init()
        {
            Items.Add("i_wall_carving_stone_2", "i_wall_carving_3");

            Items.Add("i_muffins", "i_muffin");

            Items.Add("i_pie_baked", "i_pie_sweet_potato");

            Items.Add("i_pie_unbaked", "i_pie_sweet_potato_raw");

            Items.Add("i_pet_ostard_zostrich", "i_pet_ostard_frenzied_2");

            Items.Add("i_jars", "i_jar_honey");

            Items.Add("i_BRUSH_HORSE_4", "i_brush_horse_2");

            Items.Add("i_deed_ship_dragon_long_N", "i_deed_large_dragon_ship_N");

            Items.Add("i_mt_ostard_zostrich", "i_mt_ostard_frenzied");

            Items.Add("i_deed_ship_small_N", "i_deed_small_ship_n");

            Items.Add("i_largereg_bag", "i_bag");

            Items.Add("I_SEW_BARB", "i_sewing_kit");

            Items.Add("i_demi_elfe_stone", "i_stone_race_demielfe");

            Items.Add("i_decorative_armor_2", "0151c");

            return Items;
        }
    }
}
