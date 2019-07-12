using System;
using System.Collections.Generic;
using System.Text;

namespace StrangerThings.Game
{
    public class PlacesRepo
    {
        public Place[] GetPlaces()
        {
            return _places;
        }

        private Place[] _places = new Place[]
            {
             new SharkShoes(),
             new DogDiy(),
             new AntArt()
            };
    }

    public class SharkShoes : Place
    {
        public SharkShoes()
        {
            Name = "Shark Shoes";
            Phrases = new[]
            {
                "The fish is hunting.",
                "Nothing is left, everything is below.",
                "Dogs are right.",
                "I can breathe underwater",
                "Stables are below"
            };
        }
    }

    public class DogDiy : Place
    {
        public DogDiy()
        {
            Name = "Dog DIY";
            Phrases = new[]
            {
                "I have a date with man's best friend.",
                "The shark is on our tail.",
                "The stairs on the right lead nowhere.",
                "Hammers, nails and timber.",
            };
        }
    }

    public class AntArt : Place
    {
        public AntArt()
        {
            Name = "Ant Art";
            Phrases = new[]
            {
                "We both start with the first.",
                "Our only neighbours are in the south.",
                "Teamwork produces the best paintings.",
                "Only one letter separates our halves.",
            };
        }
    }
}