using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StrangerThings.Web.Pages
{
    public class IndexModel : PageModel
    {
        public Game.Game Game { get; set; }

        public void OnGet()
        {
            var cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCacheOptions());
            var gameFactory = new StrangerThings.Game.GameFactory(new GoogleTranslator.Translator(@"D:\Development\Redweb\StrangerThings\StrangerThings\StrangerThings.Web\strangerthings.json"));

            var gameService = new StrangerThings.Game.GameService(cache, gameFactory);

            var game = gameService.CreateNewGame();

            Game = game;
        }
    }
}