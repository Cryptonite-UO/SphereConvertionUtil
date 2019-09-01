using System;
using System.Collections.Generic;

namespace SphereConvertionUtil
{
    public static class SphereTypesDictionary
    {
        private static Dictionary<string, string> Types = new Dictionary<string, string>();

        public static Dictionary<string,string> Init()
        {
            //"ID55I, ID556D"
            Types.Add("T_L1MAP", "t_map");

            Types.Add("T_L2MAP", "t_map");

            Types.Add("T_L3MAP", "t_map");

            Types.Add("T_L4MAP", "t_map");

            Types.Add("T_L5MAP", "t_map");

            return Types;
        }
    }
}
