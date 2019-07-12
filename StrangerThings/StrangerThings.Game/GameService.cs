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
            return FakeCache.Get(id);
        }

        public Game CreateNewGame()
        {
            var game = _gameFactory.CreateGame();

            FakeCache.Add(game);

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