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
            Items.Add("55I", "56D");
            return Items;
        }
    }
}
