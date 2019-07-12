using System;
using System.Collections.Generic;
using System.Text;

namespace StrangerThings.Game
{
    public static class FakeCache
    {
        private static Dictionary<string, Game> _games = new Dictionary<string, Game>();

        public static void Add(Game game)
        {
            _games.Add(game.Id, game);
        }

        public static Game Get(string id)
        {
            return _games[id];
        }
    }
}