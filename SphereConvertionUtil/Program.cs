﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SphereConvertionUtil
{
    class Program
    {
        private static readonly Dictionary<string, string> Houses = SphereHousesDictionary.Init();
        private static readonly Dictionary<string, string> Npcs = SphereNpcsDictionary.Init();
        private static readonly Dictionary<string, string> Items = SphereItemsDictionary.Init();
        private static readonly Dictionary<string, string> Types = SphereTypesDictionary.Init();
        private static readonly List<string> DeleteList = SphereToDeleteDictionary.Init();
        private static string file = "";
        private static string dirpath = "";
        private static readonly List<Ligne> linesTowrite = new List<Ligne>();
        private static List<SphereSaveObj> SphereObjs = new List<SphereSaveObj>();
        private static readonly ConsoleSpiner spin = new ConsoleSpiner();
        private static string Headers = "";

        private static bool ShowDupe = true;

        private static int goldAmount = 0;

        static void Main(string[] args)
        {
            //pour Google Translate
            string credential_path = @"google-api.json";

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            //Traduction(@"sphere_msgs.scp");

            AskFilePath("sphereworld.scp");
            PhaseToObj();
            Console.WriteLine(string.Format("Nombre de maisons: {0}", SphereObjs.Where(o => o.IsHouse).Count()));
            Console.WriteLine(string.Format("Nombre d'objets : {0}", SphereObjs.Count()));
            Converter();
            ConvertHouse();
            WriteTofile("/sphereworld_new.scp", SphereObjs);
            Console.WriteLine("sphereworld.scp converti.");
            //spherechars.scp
            Console.WriteLine("Ouverture de spharechars.scp");
            file = dirpath + "/spherechars.scp";
            SphereObjs = new List<SphereSaveObj>();
            PhaseToObj();
            Console.WriteLine(string.Format("Nombre d'objets : {0}", SphereObjs.Count()));
            Converter();
            WriteTofile("/spherechars_new.scp", SphereObjs);
            Console.WriteLine("spherechars.scp converti.");
            Console.WriteLine($"Quantité d'or en jeu: {goldAmount.ToString("#,##0")} !");
            Console.WriteLine("Opération terminée.");

            Console.ReadLine();
        }

        private static void AskFilePath(string fileName)
        {
            Console.WriteLine($"Spécifiez le che+min complet vers le {fileName} de 55i");
            Console.Write("Chemin : ");
            file = Console.ReadLine();
        }

        private static void PhaseToObj()
        {
            bool found = false;
            dirpath = Path.GetDirectoryName(file);//dosier de base

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

        private static void Converter()
        {
            Console.Write($"{DateTime.Now.ToString("HH:mm:ss")} : Conversion en cours... \n");

            int corection = 0;

            #region Total Gold

            var t = from obj in SphereObjs
                    where obj.Id == "i_gold"
                    select obj;

            foreach(SphereSaveObj o in t)
            {
                foreach (string[] prop in o.Props)
                {
                    if(prop[0]== "AMOUNT")
                    {
                        goldAmount += int.Parse(prop[1]);
                    }
                }
            }

            #endregion

            #region Duplicate

            if (ShowDupe)
            {
                var q = from x in SphereObjs
                        group x.Id by x.Id into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };

                foreach (var x in q)
                {
                    if (x.Count > 100)
                    {
                        Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);
                    }
                }
            }

            #endregion

            #region Objects-a-Suprimer

            foreach (string item in DeleteList)
            {
                spin.Turn();
                corection += SphereObjs.RemoveAll(x => x.Id.ToLower() == item.ToLower());
            }

            Console.WriteLine($"{ DateTime.Now.ToString("HH:mm:ss")} : Nombre d'objects suprimer: {corection}");

            corection = 0;

            #endregion

            #region Items-Optimised

            foreach (KeyValuePair<string, string> kvp in Items)
            {
                var query = from obj in SphereObjs
                        where obj.Id.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase)
                        select obj;

                foreach (SphereSaveObj o in query)
                {
                    o.Id = kvp.Value;
                    foreach (string[] prop in o.Props)
                    {
                        if (prop[0] == "DISPID")
                        {
                            prop[1] = kvp.Value;
                            corection++;
                        }
                        spin.Turn();
                    }
                }
            }

            #endregion

            #region Npcs-Optimised

            foreach (KeyValuePair<string, string> kvp in Npcs)
            {
                var query = from obj in SphereObjs
                            where obj.Id.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase)
                            select obj;

                foreach (SphereSaveObj o in query)
                {
                    o.Id = kvp.Value;
                    o.EditedId = true;
                    corection++;
                    spin.Turn();
                }
            }

            Console.WriteLine($"{ DateTime.Now.ToString("HH:mm:ss")} : Nombre de corection de ID et DISPID: {corection}");

            #endregion

            #region AllObjects-Loop

            for (int i = 0; i < SphereObjs.Count; i++)
            {
                //spin.Turn();
                double progress = (double)i / SphereObjs.Count;
                if (i % 1000 == 1)
                {
                    var txt = progress.ToString("P");
                    Console.Write(txt);
                    Console.SetCursorPosition(Console.CursorLeft - txt.Length, Console.CursorTop);
                }

                #region Rename-Npc

                if (!SphereObjs[i].EditedId)
                {
                    if (SphereObjs[i].Id.ToLower().Contains("c_a_"))
                    {
                        SphereObjs[i].Id = Regex.Replace(SphereObjs[i].Id, "c_a_", "c_", RegexOptions.IgnoreCase);
                        corection++;
                    }
                    if (SphereObjs[i].Id.ToLower().Contains("c_h_"))
                    {
                        SphereObjs[i].Id = Regex.Replace(SphereObjs[i].Id, "c_h_", "c_", RegexOptions.IgnoreCase);
                        corection++;
                    }
                    if (SphereObjs[i].Id.ToLower().Contains("c_m_"))
                    {
                        SphereObjs[i].Id = Regex.Replace(SphereObjs[i].Id, "c_m_", "c_", RegexOptions.IgnoreCase);
                        corection++;
                    }
                }

                #endregion

                #region Correction des MORE, Npcs,Types, Deeds et Items...

                int p = 0;
                foreach (string[] prop in SphereObjs[i].Props)
                {
                    //fix action 070 -> 111 merci @Jhobean
                    if (prop[0] == "ACTION")
                    {
                        if (prop[1] == "070")
                        {
                            prop[1] = "111";
                            corection++;
                        }
                    }
                    //fix archerybute2,decorative armor
                    if (prop[0] == "DISPID")
                    {
                        if (prop[1] == "i_archery_butte2")
                        {
                            prop[1] = "0100b";
                            corection++;
                        }
                        if (prop[1] == "i_decorative_armor_2")
                        {
                            prop[1] = "i_decorative_armor";
                            corection++;
                        }
                        if (prop[1] == "i_pickpocket_dip_w")
                        {
                            prop[1] = "i_pickpocket_dip";
                            corection++;
                        }
                        if (prop[1] == "i_pickpocket_dip_n")
                        {
                            prop[1] = "i_pickpocket_dip";
                            corection++;
                        }
                        if (prop[1] == "i_skeleton_hang2")
                        {
                            prop[1] = "i_skeleton_hang";
                            corection++;
                        }
                        if (prop[1] == "i_KEG_WOOD_2")
                        {
                            prop[1] = "i_KEG_WOOD";
                            corection++;
                        }
                        if (prop[1] == "i_pet_daemon")
                        {
                            prop[1] = "i_pet_demon";
                            corection++;
                        }
                        if (prop[1] == "i_decorative_armor2_2")
                        {
                            prop[1] = "i_decorative_armor2";
                            corection++;
                        }
                        if (prop[1] == "i_pet_ostard_zostrich")
                        {
                            prop[1] = "i_pet_ostard_frenzied_2";
                            corection++;
                        }
                    }

                    //fix t_deed
                    if (prop[0] == "TYPE")
                    {
                        if (prop[1] == "t_deed_locked")
                        {
                            prop[1] = "t_deed";
                            corection++;
                        }

                    }

                    if (prop[0] == "MORE1" || prop[0] == "MORE2" || prop[0] == "OBODY" || prop[0] == "TYPE")
                    {
                        foreach (KeyValuePair<string, string> kvp in Houses)
                        {
                            if (prop[1].ToLower() == kvp.Key.ToLower() && kvp.Value != "")
                            {
                                SphereObjs[i].Props[p][1] = SphereObjs[i].Props[p][1].Replace(kvp.Key, kvp.Value);
                                corection++;
                            }
                        }

                        foreach (KeyValuePair<string, string> kvp in Npcs)
                        {
                            if (prop[1].ToLower() == kvp.Key.ToLower() && kvp.Value != "")
                            {
                                SphereObjs[i].Props[p][1] = Regex.Replace(SphereObjs[i].Props[p][1], kvp.Key, kvp.Value, RegexOptions.IgnoreCase);
                                SphereObjs[i].EditedMore = true;
                                corection++;
                            }
                        }

                        foreach (KeyValuePair<string, string> kvp in Types)
                        {
                            if (prop[1].ToLower() == kvp.Key.ToLower() && kvp.Value != "")
                            {
                                SphereObjs[i].Props[p][1] = Regex.Replace(SphereObjs[i].Props[p][1], kvp.Key, kvp.Value, RegexOptions.IgnoreCase);
                                corection++;
                            }
                        }

                        if (!SphereObjs[i].EditedMore)
                        {
                            if (prop[1].ToLower().Contains("c_a_"))
                            {
                                SphereObjs[i].Props[p][1] = Regex.Replace(SphereObjs[i].Props[p][1], "c_a_", "c_", RegexOptions.IgnoreCase);
                                corection++;
                            }

                            if (prop[1].ToLower().Contains("c_h_"))
                            {
                                SphereObjs[i].Props[p][1] = Regex.Replace(SphereObjs[i].Props[p][1], "c_h_", "c_", RegexOptions.IgnoreCase);
                                corection++;
                            }

                            if (prop[1].ToLower().Contains("c_m_"))
                            {
                                SphereObjs[i].Props[p][1] = Regex.Replace(SphereObjs[i].Props[p][1], "c_m_", "c_", RegexOptions.IgnoreCase);
                                corection++;
                            }
                        }
                    }
                    p++;
                }

                #endregion

            }

            #endregion

            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} : Nombre de correction MORE1, MORE2, OBODY, TYPE, DISPID et ACTION: {corection}");
        }

        private static void ConvertHouse()
        {
            Console.Write("Correction des Maisons... ");
            int loading = 0;
            var colection = SphereObjs.Where(h => h.IsHouse);

            foreach (SphereSaveObj obj in colection)
            {
                var progress = (double)loading / colection.Count();
                if (loading % 3 == 1)
                {
                    var txt = progress.ToString("P");
                    Console.Write(txt);
                    Console.SetCursorPosition(Console.CursorLeft - txt.Length, Console.CursorTop);
                }

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
                            signpost.Props[c][1] = "t_normal";
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
                loading++;
            }
            Console.WriteLine();
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

        #region Traduction

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

        public static string Traduire(string text)
        {
            string targetLanguage = "fr";
            string sourceLanguage = "en";
            var client = Google.Cloud.Translation.V2.TranslationClient.Create();
            var response = client.TranslateText(text, targetLanguage, sourceLanguage);
            return response.TranslatedText;
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

        #endregion

    }

}
