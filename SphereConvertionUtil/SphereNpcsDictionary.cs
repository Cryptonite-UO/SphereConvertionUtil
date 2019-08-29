using System;
using System.Collections.Generic;

namespace SphereConvertionUtil
{
    public static class SphereNpcsDictionary
    {
        private static Dictionary<string, string> Npcs = new Dictionary<string, string>();

        public static Dictionary<string,string> Init()
        {
            //"ID55I, ID556D"
            Npcs.Add("c_a_black_bear", "c_bear_black");

            Npcs.Add("c_m_bear", "c_bear_brown");

            Npcs.Add("c_a_wolf_gray", "c_wolf_grey");

            Npcs.Add("c_wolf", "c_wolf_timber");

            Npcs.Add("c_a_direwolf", "c_wolf_timber");

            Npcs.Add("c_liche", "c_lich");

            Npcs.Add("c_m_liche_lord", "c_lich_lord");

            Npcs.Add("c_grim_reaper", "c_phantom");

            Npcs.Add("c_goblin", "c_goblin_gray");

            Npcs.Add("c_goblin_mage", "c_goblin_gray_mage");

            Npcs.Add("c_m_stoneharpy", "c_harpystone");

            Npcs.Add("c_m_goblin", "c_goblin_gray");

            Npcs.Add("c_m_goblin_mage", "c_goblin_gray_mage");

            Npcs.Add("c_m_lava_serpent", "c_serpent_lava");

            Npcs.Add("c_m_silver_serpent", "c_serpent_silver");

            Npcs.Add("c_m_ice_serpent", "c_serpent_ice");

            Npcs.Add("c_m_ettin_w_axe", "c_ettin");//a checker w_axe pas dans 56d

            Npcs.Add("c_ettin_w_axe", "c_ettin");//a checker w_axe pas dans 56d

            Npcs.Add("c_ophidian_archmage", "c_ophidian_archmage");

            Npcs.Add("c_sea_monster", "");//pas trouver dans 56d

            Npcs.Add("c_m_snow_daemon", "c_m_snow_daemon");//fait partie de NPCPack1.scp c_m_snow_daemon

            Npcs.Add("c_m_treant", "c_m_treant");//fait partie de treant.scp c_m_treant

            Npcs.Add("c_m_balron", "c_demon_balron");

            Npcs.Add("c_m_icefiend", "c_demon_ice");

            Npcs.Add("c_dragon_small_red", "c_dragon_red");

            Npcs.Add("c_dragon_small_black", "c_dragon_black");

            Npcs.Add("c_h_sprte_mage", "c_sprite_mage");

            Npcs.Add("c_elem_water", "c_elemental_water");

            Npcs.Add("c_m_elem_snow", "c_elemental_snow");

            Npcs.Add("c_elem_air", "c_elemental_air");

            Npcs.Add("c_m_elem_blood", "c_elemental_blood");

            Npcs.Add("c_m_elem_acid", "c_elemental_acid");

            Npcs.Add("c_elem_fire", "c_elemental_fire");

            Npcs.Add("c_m_elem_ice", "c_elemental_ice");

            Npcs.Add("c_m_elem_poison", "c_elemental_poison");

            Npcs.Add("c_elem_earth", "c_elemental_earth");

            return Npcs;
        }
    }
}
