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

            DeleteList.Add("i_humain_naurul_stone");
            
            DeleteList.Add("i_elfebois_stone");
                        
            DeleteList.Add("i_elfe_sauvage_stone");
                        
            DeleteList.Add("i_elfe_noir_stone");
                        
            DeleteList.Add("i_nains_terres_stone");
                                    
            DeleteList.Add("i_nains_gris_stone");
                                                
            DeleteList.Add("i_nains_profondeurs_stone");
                                                
            DeleteList.Add("i_orc_stone");
                                                
            DeleteList.Add("i_demi_orc_stone");

            DeleteList.Add("i_lancerhache_memory");

            DeleteList.Add("i_mem_appel");

            DeleteList.Add("i_mana_timer");
            
            DeleteList.Add("c_npc_quete12_b"); //Ancien NPC requis avec brain beggar
            
            DeleteList.Add("i_mem_pv_bandit1"); //ajouter mais juste 1 bandit maintenant
                        
            DeleteList.Add("i_mem_pv_bandit2"); //ajouter mais juste 1 bandit maintenant
                        
            DeleteList.Add("i_mem_pv_bandit3"); //ajouter mais juste 1 bandit maintenant
                        
            DeleteList.Add("i_mem_pv_bandit4"); //ajouter mais juste 1 bandit maintenant
            return DeleteList;
        }
    }
}
