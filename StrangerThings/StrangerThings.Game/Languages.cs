using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrangerThings.Game
{
    public class Languages
    {
        public static string GetRandomLanguage()
        {
            return supportedLangs.OrderBy(x => Guid.NewGuid()).First();
        }

        private static string[] supportedLangs = new []{
            French,
            Spanish,
            Italian,
            Dutch,
            German,
            Russian
            };

        public const string French = "fr";
        public const string Spanish = "es";
        public const string Italian = "it";
        public const string Dutch = "nl";
        public const string German = "de";
        public const string Russian = "ru";
    }
}