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

            Items.Add("i_jars", "i_jar_honey");

            Items.Add("i_BRUSH_HORSE_4", "i_brush_horse_2");

            Items.Add("i_deed_ship_small_N", "i_deed_small_ship_n");

            Items.Add("i_largereg_bag", "i_bag");

            Items.Add("I_SEW_BARB", "i_sewing_kit");

            ////////Pierre de race/////
            Items.Add("i_demi_elfe_stone", "i_stone_race_demielfe");
            Items.Add("i_humain_akaran_stone", "i_stone_race_humain");
            Items.Add("i_haut_elfe_stone", "i_stone_race_elfe");
            Items.Add("i_nains_montagnes_stone", "i_stone_race_nain");
            Items.Add("i_gnomes_bois_stone", "i_stone_race_gnome");
            /////////// FIN///////////
            
            Items.Add("i_decorative_armor_2", "i_decorative_armor"); //Bizarre marche pas

            Items.Add("i_bookcase_peter", "i_bookcase_ruined");

            Items.Add("i_bench_woodworker_end", "i_bench_woodworker");
            
            Items.Add("i_chair_wood_bamboo", "i_chair_wood_2");
                                    
            Items.Add("i_death_robe", "i_deathshroud_craft"); // ROBE que je crois inutile mais au cas que qqn en avait une
                                                
            Items.Add("i_bottles_wine", "i_bottle_wine");
                                                
            Items.Add("i_CARDS_PLAYING", "i_cards");
                                                            
            Items.Add("i_elven_male_shirt", "i_elven_shirt");
                                                
            Items.Add("i_elven_male_shirt2", "i_elven_shirt");
                                                            
            Items.Add("i_deed_ship_medium_N", "i_deed_medium_ship_n");
                                                
            Items.Add("i_deed_ship_dragon_small_N", "i_deed_small_dragon_ship_n");
                                                            
            Items.Add("i_deed_ship_dragon_medium_N", "i_deed_medium_dragon_ship_n");
            
            Items.Add("i_deed_ship_dragon_long_N", "i_deed_large_dragon_ship_N");
                                                            
            Items.Add("i_deed_ship_long_N", "i_deed_large_ship_n");
                                                            
            Items.Add("i_bench_wood_smooth_end", "i_bench_wood_smooth");
            Items.Add("i_bench_wood_smooth_ext", "i_bench_wood_smooth");//Flip pour différente partie
            Items.Add("i_table_wood_smooth_narrow_ext", "i_table_wood_smooth_narrow_end");//Flip pour différente partie
            Items.Add("i_table_wood_solid_custom_corner_ns", "i_table_wood_solid_narrow_end");//Flip pour différente partie
            Items.Add("i_table_wood_solid_custom_corner_ew", "i_table_wood_solid_narrow_end");//Flip pour différente partie
                                                                        
            Items.Add("i_pet_daemon", "i_pet_demon");
                                                                                                                                                            
            Items.Add("i_pegbaord", "i_pegboard");
                                                                                                
            Items.Add("i_table_runner_snowflake", "i_table_runner_red");
                                                                                                
            Items.Add("i_table_runner_plaid_blue", "i_table_runner_blue");
                                                                                                            
            Items.Add("i_fish_cooked", "i_fish_cooked_headless");
                                                                                                                                                                                                            
            Items.Add("i_bed_21", "0a7a");//Flip pour différente partie
            Items.Add("i_bed_20", "0a7a");//Flip pour différente partie
            Items.Add("i_bed_2", "i_bed_1");//Flip pour différente partie
            Items.Add("i_bed_5", "i_bed_6");//Flip pour différente partie
            Items.Add("i_bed_25", "0a80");//Flip pour différente partie
            Items.Add("i_bed_24", "0a80");//Flip pour différente partie
            Items.Add("i_bed_26", "0a80");//Flip pour différente partie
            Items.Add("i_bed_27", "0a80");//Flip pour différente partie
                                                                                                                        
            Items.Add("i_tapestry_5_w", "i_tapestry_5_n");//Flip pour différente partie
                                                                                                                                    
            Items.Add("i_tapestry_7_w", "i_tapestry_7_n");//Flip pour différente partie
                                                                                                                                    
            Items.Add("i_pet_ostard_zostrich", "i_pet_ostard_frenzied");
            
            Items.Add("i_mt_ostard_zostrich", "i_mt_ostard_frenzied");
                                                                                                                                                
            Items.Add("i_deed_house_patio_marble", "i_deed_marble_house_with_patio");
                                                                                                                                                            
            Items.Add("i_deed_cabin_log_2story", "i_deed_two_story_log_cabin");
                                                                                                                                                            
            Items.Add("i_deed_house_patio_sand", "i_deed_sandstone_house_with_patio");
                                                                                                                                                            
            Items.Add("i_deed_villa_2story", "i_deed_two_story_villa");  
            
            Items.Add("i_deed_shop_stone_small", "i_deed_small_stone_workshop");
                                                                                                                                                            
            Items.Add("i_deed_tower_wizard", "i_deed_small_stone_tower");
                                                                                                                                                            
            Items.Add("i_deed_shop_marble_small", "i_deed_small_marble_workshop");
                                                                                                                                                            
            Items.Add("i_deed_house_wheat_cottage", "i_deed_thatched_roof_cottage"); // PAS TROUVÉ le vrai équivalent..  Mis qqch de semblable
            
            Items.Add("i_deed_shop_blacksmithy_large", "i_deed_large_house_with_patio");
                                                                                                                                                                        
            Items.Add("i_deed_keep", "i_deed_small_stone_keep");
                                                                                                                                                                        
            Items.Add("i_deed_house_stone_plaster_2story", "i_deed_two_story_stone_and_plaster_house");
                                                                                                                                                                        
            Items.Add("i_deed_house_wood_plaster_2story", "i_deed_two_story_wood_and_plaster_house");
                                                                                                                                                                        
            Items.Add("i_deed_house_3room", "i_deed_brick_house");
                                                                                                                                                                        
            Items.Add("i_deed_tent_green", "i_deed_green_tent");      
            
            Items.Add("i_deed_tent_blue", "i_deed_blue_tent");
                                                                                                                                                                        
            Items.Add("i_deed_House_wood_thatched_small", "i_deed_thatched_roof_cottage");
                                                                                                                                                                        
            Items.Add("i_deed_House_wood_plaster_small", "i_deed_wood_and_plaster_house");
                                                                                                                                                                        
            Items.Add("i_deed_House_stone_wood_small", "i_deed_wooden_house");
                                                                                                                                                                                                  
            Items.Add("i_deed_House_stone_brick_small", "i_deed_small_brick_house");
                                                                                                                                                                        
            Items.Add("i_deed_House_stone_small", "i_deed_field_stone_house");
                                                                                                                                                                        
            Items.Add("i_deed_house_stone_plaster_small", "i_deed_stone_and_plaster_house");
                                                                                                                                                                                    
            Items.Add("i_decorative_shield_12_sword_over_nw", "i_decorative_shield_and_sword_1");
                                                                                                                                                                                                
            Items.Add("i_treas_map_rolled_1", "i_ttm_l1_2"); // remplacé par une carte au trésor normal
            
            /////////////////////////////////////FORGE//////////////////////////////////
            Items.Add("i_forge_2_part_2_of_3_w", "i_forge_large");         
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_w", "i_forge_large_bellows");                                                                                                                                                                                                
            Items.Add("i_forge_2_part_3_of_3_w_2", "01983");  // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_s", "01995"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_s", "01997"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_s", "0199A"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_w_2", "0197F"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_e", "0199e"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_w", "01982"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_w_3", "0197b"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_e_4", "019a2"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_e_4", "019a6"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_e", "019a2"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_n", "0198a"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_n", "0198e"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_n", "01986"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_w_2", "i_forge_large_bellows"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_w_4", "01983"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_n_4", "0198e"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_2_of_3_s_4", "01996"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_s_3", "0199a"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_s_4", "01995"); // Ajout au defname marche pas
            Items.Add("i_forge_2_part_3_of_3_s_4", "0199a"); // Ajout au defname marche pas
            Items.Add("i_FORGE_BELLOWS_2_part_1_of_3_e_3", "0199e"); // Ajout au defname marche pas
            ////////////////////////////////FIN FORGE//////////////////////////////////              

            return Items;
        }
    }
}
