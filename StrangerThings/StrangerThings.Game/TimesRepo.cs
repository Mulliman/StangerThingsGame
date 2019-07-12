using System;
using System.Collections.Generic;
using System.Text;

namespace StrangerThings.Game
{
    public class TimesRepo
    {
        public Time[] GetTimes()
        {
            return _places;
        }

        private Time[] _places = new Time[]
            {
                new Noon(),
                new NineFortyFive(),
                new ThreeFifteen()
            };
    }

    public class Noon : Time
    {
        public Noon()
        {
            Hour = "12";
            Minutes = "00";

            Phrases = new[]
            {
                "Blue and yellow meet in the north",
                "Green and red meet in the north",
                "Everything is going up",
                "Twelve is the only number"
            };
        }
    }

    public class NineFortyFive : Time
    {
        public NineFortyFive()
        {
            Hour = "9";
            Minutes = "45";

            Phrases = new[]
            {
                "Blue and yellow meet in the west",
                "Green and red meet in the west",
                "You're all I have left.",
                "GO WEST! In the open air."
            };
        }
    }

    public class ThreeFifteen : Time
    {
        public ThreeFifteen()
        {
            Hour = "3";
            Minutes = "15";

            Phrases = new[]
            {
                "Blue and yellow meet in the east",
                "Green and red meet in the east",
                "The time is right."
            };
        }
    }
}