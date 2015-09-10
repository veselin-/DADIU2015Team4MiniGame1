using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core
{
    public static class Constants
    {
        public static class Tags
        {
            public static string GameMaster = "GameMaster";
        }

        public static List<List<PressType>> Combos = new List<List<PressType>>
        {
            new List<PressType> {PressType.Short, PressType.Short, PressType.Short},
            new List<PressType> {PressType.Short, PressType.Short, PressType.Long}
        };

    }
}
