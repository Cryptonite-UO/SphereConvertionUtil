using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SphereConvertionUtil
{
    class Program
    {

        private static Dictionary<string, string> Houses = new Dictionary<string, string>();
        private static Dictionary<string, string> Npcs = new Dictionary<string, string>();
        private static string file = "";
        private static string dirpath = "";
        private static List<Ligne> linesTowrite = new List<Ligne>();
        private static List<SphereSaveObj> SphereObjs = new List<SphereSaveObj>();
        private static ConsoleSpiner spin = new ConsoleSpiner();
        private static string Headers = "";

        static void Main(string[] args)
        {
            //pour Google Translate
            string credential_path = @"google-api.json";

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            //Traduction(@"sphere_msgs.scp");

            InitHouse();
            InitNpcs();
            AskFilePath("sphereworld.scp");
            PhaseToObj();

            Console.WriteLine(string.Format("Nombre de maisons: {0}", SphereObjs.Where(o => o.IsHouse).Count()));

            Console.WriteLine(string.Format("Nombre d'objets : {0}", SphereObjs.Count()));

            ConvertNpcs();
            ConvertSpawn();
            ConvertHouse();
            WriteTofile("/sphereworld_new.scp", SphereObjs);

            Console.WriteLine("Terminé ;) pour sphereworld.scp");

            //SphereChars.scp TODO: lire les deux fichier dans la method 
            AskFilePath("spherechars.scp");
            SphereObjs = new List<SphereSaveObj>();
            PhaseToObj();

            Console.WriteLine(string.Format("Nombre de maisons: {0}", SphereObjs.Where(o => o.IsHouse).Count()));

            Console.WriteLine(string.Format("Nombre d'objets : {0}", SphereObjs.Count()));

            ConvertNpcs();
            ConvertSpawn();
            WriteTofile("/spherechars_new.scp", SphereObjs);

            Console.WriteLine("Terminé ;) pour spherechars.scp");

            Console.ReadLine();
        }

        private static void AskFilePath(string fileName)
        {
            Console.WriteLine($"Spécifiez le chemin complet vers le {fileName} de 55i");
            Console.Write("Chemin : ");
            file = Console.ReadLine();
        }

        //file
        private static void PhaseToObj()
        {
            bool found = false;
            dirpath = Path.GetDirectoryName(file);

            if (true)
            {
                Console.WriteLine("Le dossier de base est : " + dirpath);
            }

            Console.Write("Chargement ... ");

            int objnum = -1;
            int linecount = 0;
            foreach (string line in File.ReadAllLines(file))
            {
                if (linecount < 4)
                {
                    Headers += line + "\n";
                }

                //on spin a toutes les 1 000 lignes
                if (objnum % 10000 == 1)
                {
                    spin.Turn();
                }

                if (line.StartsWith("[EOF]", StringComparison.Ordinal))
                {
                    break;
                }

                if (line.StartsWith("[", StringComparison.Ordinal))
                {
                    found = true;
                    //creation d'object
                    var type = line.Remove(0, 1).Split(' ')[0];
                    var id = line.Remove(line.Length - 1, 1).Split(' ')[1];

                    var obj = new SphereSaveObj(type, id);

                    if (line.StartsWith("[WORLDITEM i_multi_", StringComparison.Ordinal))
                    {
                        foreach (KeyValuePair<string, string> kvp in Houses)
                        {
                            var a = line.Remove(line.Length - 1, 1).Split(' ')[1];
                            if (a == kvp.Key)
                            {
                                obj.IsHouse = true;
                            }

                        }
                    }
                    SphereObjs.Add(obj);
                    continue;
                }

                if (found && !String.IsNullOrWhiteSpace(line))
                {
                    //on traite les proprieter ici
                    string[] prop = line.Split('=');
                    try
                    {
                        var a = SphereObjs[objnum];
                        SphereObjs[objnum].Props.Add(prop);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Erreur sur la ligne " + objnum);
                        continue;
                    }
                }

                if (String.IsNullOrEmpty(line))
                {
                    found = false;
                    objnum++;
                    continue;
                }
                linecount++;
            }
        }

        private static void ConvertNpcs()
        {
            Console.Write("Correction des Npcs... ");
            foreach (SphereSaveObj obj in SphereObjs.Where(t => t.Type == "WORLDCHAR"))
            {
                spin.Turn();
                foreach (KeyValuePair<string, string> kvp in Npcs)
                {
                    if (obj.Id == kvp.Key && kvp.Value != "")
                    {
                        obj.Id = kvp.Value;
                        obj.EditedId = true;
                    }
                }
                if (!obj.EditedId)
                {
                    if (obj.Id.ToLower().Contains("c_a_"))
                    {
                        obj.Id = Regex.Replace(obj.Id, "c_a_", "c_", RegexOptions.IgnoreCase);
                    }
                    if (obj.Id.ToLower().Contains("c_h_"))
                    {
                        obj.Id = Regex.Replace(obj.Id, "c_h_", "c_", RegexOptions.IgnoreCase);
                    }
                    if (obj.Id.ToLower().Contains("c_m_"))
                    {
                        obj.Id = Regex.Replace(obj.Id, "c_m_", "c_", RegexOptions.IgnoreCase);
                    }
                }
            }
            Console.WriteLine();
        }

        private static void ConvertSpawn()
        {
            Console.Write("Correction des MORE, Npcs, Deeds et Items... ");
            foreach (SphereSaveObj obj in SphereObjs)
            {
                spin.Turn();
                int i = 0;
                foreach (string[] prop in obj.Props)
                {
                    if (prop[0] == "MORE1" || prop[0] == "MORE2")
                    {
                        foreach (KeyValuePair<string, string> kvp in Houses)
                        {
                            if (prop[1].Contains(kvp.Key) && kvp.Value != "")
                            {
                                obj.Props[i][1] = obj.Props[i][1].Replace(kvp.Key, kvp.Value);
                            }
                        }

                        foreach (KeyValuePair<string, string> kvp in Npcs)
                        {
                            if (prop[1].Contains(kvp.Key) && kvp.Value != "")
                            {
                                obj.Props[i][1] = obj.Props[i][1].Replace(kvp.Key, kvp.Value);
                                obj.EditedMore = true;
                            }
                        }
                        if (!obj.EditedMore)
                        {
                            if (prop[1].ToLower().Contains("c_a_"))
                            {
                                obj.Props[i][1] = Regex.Replace(obj.Props[i][1], "c_a_", "c_", RegexOptions.IgnoreCase);
                            }

                            if (prop[1].ToLower().Contains("c_h_"))
                            {
                                obj.Props[i][1] = Regex.Replace(obj.Props[i][1], "c_h_", "c_", RegexOptions.IgnoreCase);
                            }

                            if (prop[1].ToLower().Contains("c_m_"))
                            {
                                obj.Props[i][1] = Regex.Replace(obj.Props[i][1], "c_m_", "c_", RegexOptions.IgnoreCase);
                            }
                        }
                    }
                    i++;
                }
            }
            Console.WriteLine();
        }

        private static void ConvertHouse()
        {
            Console.Write("Correction des Maisons... ");
            foreach (SphereSaveObj obj in SphereObjs.Where(h => h.IsHouse))
            {
                spin.Turn();
                string serial = "";
                string more1 = "";
                int i = 0;

                foreach (KeyValuePair<string, string> kvp in Houses)
                {
                    if (obj.Id == kvp.Key && kvp.Value != "")
                    {
                        obj.Id = kvp.Value;
                    }
                }

                foreach (string[] prop in obj.Props)
                {
                    if (prop[0] == "SERIAL")
                    {
                        serial = obj.Props[i][1];
                    }
                    if (prop[0] == "MORE1")
                    {
                        more1 = obj.Props[i][1];
                    }
                    if (prop[0] == "REGION.TAG.SIGNP")
                    {
                        obj.Props[i][0] = "REGION.TAG.sign";
                    }
                    if (prop[0] == "REGION.TAG.SIGNP")
                    {
                        obj.Props[i][0] = "REGION.TAG.sign";
                    }
                    //REGION.EVENTS=r_house
                    if (prop[0] == "REGION.EVENTS")
                    {
                        obj.Props[i][1] = "r_houses";
                    }
                    i++;
                }

                //tout ce qui est linker a la maison
                var links = SphereObjs.Where(o => o.Props.Any(prop => prop[0] == "LINK" && prop[1] == serial)).ToList();
                var chests = links.Where(o => o.Props.Any(prop => prop[0] == "TYPE" && prop[1] == "t_secure"));
                var items = links.Where(o => !o.Id.Contains("i_door")).ToList();

                SphereSaveObj signpost = links.FirstOrDefault(o => o.Id == "i_sign_brass");

                if (signpost != null)
                {
                    int c = 0;
                    foreach (string[] prop in signpost.Props)
                    {
                        //on set sont timer a 1 mois
                        if (prop[0] == "TIMER")
                        {
                            signpost.Props[c][1] = "2600000";
                        }
                        //on set le more1 de la pancarte
                        if (prop[0] == "MORE1")
                        {
                            signpost.Props[c][1] = more1;
                        }

                        if (prop[1] == "t_sign_gump")
                        {
                            signpost.Props[c][1] = "t_script";
                        }
                        items.Remove(signpost);
                        c++;
                    }
                }

                foreach (SphereSaveObj chest in chests)
                {
                    int c = 0;
                    items.Remove(chest);
                    foreach (string[] prop in chest.Props)
                    {
                        //logic here
                        if (prop[0] == "LINK")
                        {
                            chest.Props[c][1] = "04fffffff";
                        }
                        if (prop[0] == "TYPE")
                        {
                            chest.Props[c][1] = "t_container";
                        }
                        c++;
                    }
                    string[] secure = { "EVENTS", "t_coowner" };
                    chest.Props.Add(secure);
                }

                foreach (SphereSaveObj item in items)
                {
                    int c = 0;
                    foreach (string[] prop in item.Props)
                    {
                        //logic here
                        if (prop[0] == "LINK")
                        {
                            item.Props[c][1] = "04fffffff";
                        }
                        c++;
                    }
                    string[] locked = { "EVENTS", "t_locked" };
                    item.Props.Add(locked);
                }
            }
            Console.WriteLine();
        }

        private static void Traduction(string fileToTranslate = "")
        {
            if (fileToTranslate == "")
            {
                DirectoryInfo d = new DirectoryInfo(@"/Users/jmmiljours/sphere/scripts");
                FileInfo[] Files = d.GetFiles("*.scp"); //Getting Text files
                foreach (FileInfo f in Files)
                {
                    File.Move(f.FullName, Path.ChangeExtension(f.FullName, ".org"));
                    file = f.FullName.Replace(".scp", ".org");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Fichiers en cours de traduction: {0}", file);
                    Console.ForegroundColor = ConsoleColor.White;
                    PhaseSphaereScp();
                }
            }
            else
            {
                file = fileToTranslate;

                File.Copy(file, file.Replace(".scp", ".org"), true);
                file = file.Replace(".scp", ".org");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Fichiers en cours de traduction: {0}", file);
                Console.ForegroundColor = ConsoleColor.White;
                PhaseSphaereSphereMsg();
            }
            Console.WriteLine("Dossier Terminé");
            Console.ReadLine();
        }

        private static void PhaseSphaereScp()
        {
            var newline = "";
            foreach (string line in File.ReadAllLines(file))
            {
                newline = line;

                if (line.StartsWith("NAME=", StringComparison.Ordinal))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Format("Nom original: {0}", line.Remove(0, 5)));
                    newline = string.Format("NAME={0}", Traduire(line.Remove(0, 5)));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(string.Format("Traduction : {0}", newline.Remove(0, 5)));
                    Console.ForegroundColor = ConsoleColor.White;
                }

                AddLine(newline);
            }
        }

        private static void PhaseSphaereSphereMsg()
        {
            var newline = "";
            foreach (string line in File.ReadAllLines(file))
            {
                newline = line;

                if (line.StartsWith(@"//", StringComparison.Ordinal))
                {
                    var linetoEdit = line.Split("\t");
                    if (linetoEdit.Count() > 1)
                    {
                        if (!String.IsNullOrEmpty(linetoEdit[linetoEdit.Count() - 1]))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Console.WriteLine(string.Format("Nom original: {0}", linetoEdit[linetoEdit.Count() - 1]));
                            linetoEdit[linetoEdit.Count() - 1] = Traduire(linetoEdit[linetoEdit.Count() - 1]);
                            newline = string.Join("\t", linetoEdit.Skip(0));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(newline);
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                    }
                }

                AddLine(newline);
            }
            Write();
        }


        public static void AddLine(string text, bool newline = true)
        {
            linesTowrite.Add(new Ligne(text, newline));
        }

        public static void Write()
        {
            Console.WriteLine("Écriture du nouveau fichier en cours, patienter ...");

            foreach (Ligne l in linesTowrite)
            {
                WriteTofile(l);
            }

            Console.WriteLine("Opération Terminée");

        }

        public static string Traduire(string text)
        {
            string targetLanguage = "fr";
            string sourceLanguage = "en";
            var client = Google.Cloud.Translation.V2.TranslationClient.Create();
            var response = client.TranslateText(text, targetLanguage, sourceLanguage);
            return response.TranslatedText;
        }

        public static void WriteTofile(Ligne line)
        {
            if (line.IsNewLine)
            {
                File.AppendAllText(file.Replace(".org", ".scp"), line.Text + Environment.NewLine, Encoding.GetEncoding("iso-8859-1"));
            }
            else
            {
                File.AppendAllText(file.Replace(".org", ".scp"), line.Text, Encoding.GetEncoding("iso-8859-1"));
            }
        }

        public static void WriteTofile(string fileName, List<SphereSaveObj> objs)
        {
            int objnum = 0;
            string filePath = dirpath + fileName;
            StringBuilder stringbuilder = new StringBuilder();
            Console.Write("Écriture en cours...");
            stringbuilder.Append(Headers + Environment.NewLine);
            foreach (SphereSaveObj obj in objs)
            {
                if (objnum % 10000 == 1)
                {
                    spin.Turn();
                }
                string line = string.Format("[{0} {1}]", obj.Type, obj.Id);
                stringbuilder.Append(line + Environment.NewLine);
                foreach (string[] prop in obj.Props)
                {
                    if (prop.Length == 2)
                    {
                        line = string.Format("{0}={1}", prop[0], prop[1]);
                    }
                    else
                    {
                        line = string.Format("{0}", prop[0]);
                    }
                    stringbuilder.Append(line + Environment.NewLine);
                }
                stringbuilder.Append(Environment.NewLine);
                objnum++;
            }
            stringbuilder.Append("[EOF]");
            File.WriteAllText(filePath, stringbuilder.ToString());
            Console.WriteLine();
        }

        private static void InitHouse()
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

            //0407a
            Houses.Add("i_multi_tower", "m_tower");

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
        }

        private static void InitNpcs()
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

            Npcs.Add("c_m_ophidian_archmage", "c_ophidian_archmage");

            Npcs.Add("c_sea_monster", "");//pas trouver dans 56d

            Npcs.Add("c_m_snow_daemon", "c_m_snow_daemon");//fait partie de NPCPack1.scp c_m_snow_daemon

            Npcs.Add("c_m_treant", "c_m_treant");//fait partie de treant.scp c_m_treant

            Npcs.Add("c_m_balron", "c_demon_balron");

            Npcs.Add("c_m_icefiend", "c_demon_ice");

            Npcs.Add("c_dragon_small_red", "c_dragon_red");

            Npcs.Add("c_dragon_small_black", "c_dragon_black");

            Npcs.Add("c_h_sprte_mage", "c_sprite_mage");

            Npcs.Add("c_elem_water", "c_elemental_water");

            Npcs.Add("c_elem_snow", "c_elemental_snow");

            Npcs.Add("c_elem_air", "c_elemental_air");

            Npcs.Add("c_elem_blood", "c_elemental_blood");

            Npcs.Add("c_m_elem_acid", "c_elemental_acid");

            Npcs.Add("c_elem_fire", "c_elemental_fire");

            Npcs.Add("c_elem_ice", "c_elemental_ice");

            Npcs.Add("c_m_elem_poison", "c_elemental_poison");

            Npcs.Add("c_elem_earth", "c_elemental_earth");
        }
    }

}
