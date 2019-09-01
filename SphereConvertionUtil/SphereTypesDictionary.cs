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
            Types.Add("55i", "56d");

            return Types;
        }
    }
}
