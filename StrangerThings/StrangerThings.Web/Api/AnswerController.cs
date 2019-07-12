using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StrangerThings.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        [HttpGet("{id}/{place}/{time}")]
        public AnswerResult Get(string id, string place, string time)
        {
            var cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCacheOptions());
            var gameFactory = new StrangerThings.Game.GameFactory(new GoogleTranslator.Translator(@"D:\Development\Redweb\StrangerThings\StrangerThings\StrangerThings.Web\strangerthings.json"));

            var gameService = new StrangerThings.Game.GameService(cache, gameFactory);

            var game = gameService.GetGameFromId(id);

            var result = new AnswerResult();

            result.LocationCorrect = game.Answer.Place.Name == place;
            result.TimeCorrect = game.Answer.Time.ToString() == time;

            result.Answer = $"{game.Answer.Place.Name} at {game.Answer.Time.ToString()}";

            return result;
        }
    }

    public class AnswerResult
    {
        public bool LocationCorrect { get; set; }

        public bool TimeCorrect { get; set; }

        public string Answer { get; set; }
    }
}