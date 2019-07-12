using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrangerThings.Game
{
    public class GameFactory
    {
        private readonly PlacesRepo _placesRepo;
        private readonly TimesRepo _timesRepo;
        private readonly GoogleTranslator.Translator _translator;

        public GameFactory(GoogleTranslator.Translator translator)
        {
            _placesRepo = new PlacesRepo();
            _timesRepo = new TimesRepo();
            _translator = translator;
        }

        public Game CreateGame()
        {
            var game = new Game();

            game.Id = Guid.NewGuid().ToString("N");
            game.Language = Languages.GetRandomLanguage();

            game.Answer = GetRandomishAnswer();
            
            game.PhrasesInEnglish = game.Answer.GetPhrases();

            game.PhrasesInLanguage = GetPhrasesInLanguage(game.PhrasesInEnglish, game.Language);

            return game;
        }

        private string[] GetPhrasesInLanguage(string[] phrasesInEnglish, string language)
        {
            var phrases = new List<string>();

            foreach (var phrase in phrasesInEnglish)
            {
                phrases.Add(_translator.TranslatePhrase(phrase, language));
            }

            return phrases.ToArray();
        }

        private Answer GetRandomishAnswer()
        {
            var place = GetRandomishPlace();
            var time = GetRandomishTime();

            return new Answer
            {
                 Place = place,
                 Time = time
            };
        }

        private Place GetRandomishPlace()
        {
            var places = _placesRepo.GetPlaces();

            var theOne = places.OrderBy(x => Guid.NewGuid()).First();

            return theOne;
        }

        private Time GetRandomishTime()
        {
            var times = _timesRepo.GetTimes();

            var theOne = times.OrderBy(x => Guid.NewGuid()).First();

            return theOne;
        }
    }
}