using Microsoft.Extensions.Caching.Memory;

namespace StrangerThings.Game
{
    public class GameService
    {
        private readonly IMemoryCache _cache;
        private readonly GameFactory _gameFactory;

        public GameService(IMemoryCache cache, GameFactory gameFactory)
        {
            _cache = cache;
            _gameFactory = gameFactory;
        }

        public Game GetGameFromId(string id)
        {
            return _cache.Get<Game>(GetGameCacheId(id));
        }

        public Game CreateNewGame()
        {
            var game = _gameFactory.CreateGame();

            _cache.Set(GetGameCacheId(game), game);

            return game;
        }

        private string GetGameCacheId(Game game)
        {
            return "GameCache_" + game.Id;
        }

        private string GetGameCacheId(string id)
        {
            return "GameCache_" + id;
        }
    }
}