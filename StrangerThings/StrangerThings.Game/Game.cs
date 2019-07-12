using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrangerThings.Game
{
    public class Game
    {
        public string Id { get; set; }

        public string[] PhrasesInEnglish { get; set; }

        public string[] PhrasesInLanguage { get; set; }

        public string Language { get; set; }

        public Answer Answer { get; set; }
    }

    public class Answer
    {
        public Time Time { get; set; }

        public Place Place { get; set; }

        public string[] GetPhrases()
        {
            // Get 2 for the place and one for the time.
            return Place.Get2RandomPhrases().Union(new[] { Time.GetRandomPhrase() }).OrderBy(x => Guid.NewGuid()).ToArray();
        }
    }

    public class Time : HasPhrases
    {
        public string Hour { get; set; }

        public string Minutes { get; set; }
        
        public override string ToString()
        {
            return $"{Hour}{Minutes}";
        }
    }

    public class Place : HasPhrases
    {
        public string Name { get; set; }        
    }

    public class HasPhrases
    {
        public string[] Phrases { get; set; }

        public string GetRandomPhrase()
        {
            return Phrases.OrderBy(x => Guid.NewGuid()).First();
        }

        public string[] Get2RandomPhrases()
        {
            return Phrases.OrderBy(x => Guid.NewGuid()).Take(2).ToArray();
        }
    }
}