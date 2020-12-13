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
            Npcs.Add("C_H_INNKEEPER_F", "C_INNKEEPER_F");
            Npcs.Add("C_H_MAGESHOP_F", "C_MAGESHOP_F");
            Npcs.Add("c_m_frost_troll", "c_frost_troll");
            Npcs.Add("C_H_BAKER_F", "C_BAKER_F");
            Npcs.Add("c_m_scorpion_thrall", "c_scorpion_thrall");
            Npcs.Add("c_m_scorpion_prince", "c_scorpion_prince");
            Npcs.Add("c_m_orc_mage", "c_orc_shaman");
            Npcs.Add("c_m_mummy", "c_mummy");
            Npcs.Add("c_m_terathan_avenger", "c_terathan_avenger");
            Npcs.Add("c_m_orc_captain", "c_orc_captain");
            Npcs.Add("c_m_elem_snow", "c_elemental_snow");
            Npcs.Add("c_m_ghoul", "c_ghoul");
            Npcs.Add("c_m_gazer_elder", "c_gazer_elder");
            Npcs.Add("c_m_scorpion_king", "c_scorpion_king");
            Npcs.Add("c_h_dreadlord_captain", "c_dreadlord_captain");
            Npcs.Add("c_h_frostelf_shaman", "c_frostelf_shaman");
            Npcs.Add("c_h_dreadlord", "c_dreadlord");
            Npcs.Add("c_h_frostelf_archer", "c_frostelf_archer");
            Npcs.Add("c_h_witch", "c_witch");
            Npcs.Add("c_h_warlock", "c_warlock");
            Npcs.Add("c_m_ogre_lord", "c_ogre_lord");
            Npcs.Add("c_m_skeleton_knight", "c_skeleton_knight");
            Npcs.Add("c_m_skeletonarcher", "c_skeletonarcher");
            Npcs.Add("c_dragon_green", "c_dragon_red");
            Npcs.Add("c_fire_ant_warrior", "c_solen_warrior");
            Npcs.Add("c_fire_ant_queen", "c_solen_queen");
            Npcs.Add("c_destroyer_gargoyle", "c_gargoyle_destroyer");
            Npcs.Add("c_horde_minion", "c_daemon_horde_minion");
            Npcs.Add("i_pet_hordedaemon", "i_pet_daemon_horde");
            Npcs.Add("c_demon_balron", "c_daemon_balron");
            Npcs.Add("c_fourarmed_daemon", "c_daemon");//????????
            Npcs.Add("c_Horde_Daemon_Large", "c_daemon_horde_large");
            Npcs.Add("c_wyvern_mutant", "c_wyvern");
            Npcs.Add("c_dragon_black", "c_dragon_blackdrake");
            Npcs.Add("c_abyss_lord", "c_abyssal_infernal");
            Npcs.Add("c_Doppelganger", "c_Doppleganger");
            Npcs.Add("c_swarm", "c_gazer_larva");
            Npcs.Add("c_demon_blackgate", "c_daemon_balron");
            Npcs.Add("c_darkelf_war_sword", "c_darkelf_fight_sword");
            Npcs.Add("c_arcane_daemon", "c_daemon_arcane");
            Npcs.Add("c_goat_mountain", "c_mountain_goat");
            Npcs.Add("c_WAITRESS", "c_waiter_f");
            Npcs.Add("c_chaos_daemon", "c_daemon_chaos");
            Npcs.Add("c_Horde_Daemon_Medium", "c_daemon_horde_large");
            Npcs.Add("c_fire_ant_worker", "c_solen_worker");
            Npcs.Add("c_lady_m", "c_lady_melisande");
            Npcs.Add("c_woodelf_ranger", "c_woodelf_archer");
            Npcs.Add("c_fire_gargoyle", "c_gargoyle_fire");
            Npcs.Add("c_multicolored_horde_minion", "c_demon_horde_colored");
            Npcs.Add("c_ice_hound", "c_hellhound");

            Npcs.Add("c_h_barbarian_warrior", "c_barbarian_warrior");


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

            Npcs.Add("c_m_stoneharpy", "c_harpy_stone");

            Npcs.Add("c_m_goblin", "c_goblin_gray");

            Npcs.Add("c_m_goblin_mage", "c_goblin_shaman");


            Npcs.Add("c_m_lava_serpent", "c_serpent_lava");

            Npcs.Add("c_m_silver_serpent", "c_serpent_silver");

            Npcs.Add("c_m_ice_serpent", "c_serpent_ice");

            Npcs.Add("c_m_ettin_w_axe", "c_ettin_w_hammer");

            Npcs.Add("c_ettin_w_axe", "c_ettin_w_hammer");

            Npcs.Add("c_ophidian_mage", "c_ophidian_archmage");

            //Npcs.Add("c_m_treant", "c_reaper_redux");//Remplacé par un nouveau

            Npcs.Add("c_m_icefiend", "c_daemon_ice");

            Npcs.Add("c_dragon_small_red", "c_dragon_red");

            Npcs.Add("c_dragon_small_black", "c_dragon_blackdrake");
		
            Npcs.Add("c_white_wyrm", "c_wyrm_white");

            Npcs.Add("c_h_sprte_mage", "c_sprite_mage");

            Npcs.Add("c_elem_water", "c_elemental_water");

            Npcs.Add("c_elem_air", "c_elemental_air");

            Npcs.Add("c_m_elem_blood", "c_elemental_blood");

            Npcs.Add("c_m_elem_acid", "c_elemental_acid");

            Npcs.Add("c_elem_fire", "c_elemental_fire");

            Npcs.Add("c_m_elem_ice", "c_elemental_ice");

            Npcs.Add("c_m_elem_poison", "c_elemental_poison");

            Npcs.Add("c_elem_earth", "c_elemental_earth");

            Npcs.Add("c_h_warrior_f", "c_guard_f");

            Npcs.Add("c_h_warrior", "c_guard");
			
            Npcs.Add("c_m_exodus", "c_exodus_overseer");
						
            Npcs.Add("c_m_dracoliche", "c_skeletal_dragon");
						
            Npcs.Add("c_h_bandit_m_crossbow", "c_bandit_m_crossbow");
						
            Npcs.Add("c_h_bandit_f_crossbow", "c_bandit_f_crossbow");
						
            Npcs.Add("c_bandit_beserk1", "c_bandit_beserk");
								
            Npcs.Add("c_bandit_beserk2", "c_bandit_beserk");
								
            Npcs.Add("c_bandit_beserk3", "c_bandit_beserk");
								
            Npcs.Add("c_bandit_beserk4", "c_bandit_beserk");
		
            Npcs.Add("c_troll_w_mace", "c_troll_w_axe");
				
            Npcs.Add("c_A_SNOW_LEOPARD", "c_leopard_snow");
								
            Npcs.Add("c_m_frostspider", "c_spider_frost");
								
            Npcs.Add("c_a_mountain_goat", "c_goat_mountain");

            Npcs.Add("c_dread_spider", "c_spider_dread");

            Npcs.Add("c_daemon_w_sword", "c_daemon_balron");//Pas trouvé avec une épé...
													
            Npcs.Add("c_m_balron", "c_daemon_balron");
													
            Npcs.Add("c_m_balrog", "c_daemon_balron"); //Pas trouvé avec une épée...

            Npcs.Add("c_m_snow_daemon", "c_demon_ice");//remplacé par un semblable
			
            Npcs.Add("c_wood_elemental", "c_treefellow");//Propice a une équivalence	
			
            Npcs.Add("C_H_BARBER", "c_hairstylist_f"); //Ya aussi le gars mais les coiffeuses c des femmes :-)
					
            Npcs.Add("C_H_FIGHT_OVERSEER", "c_exodus_overseer");
					
            Npcs.Add("C_H_EVILMAGE_F", "C_EVILMAGE");
					
            Npcs.Add("C_H_EVILMAGE", "C_EVILMAGE");	
					
            Npcs.Add("c_h_barbarian_chieftan", "c_barbarian_chieftain");
							
            Npcs.Add("C_H_PIRATE", "c_pirate_m");

            return Npcs;
        }
    }
}
