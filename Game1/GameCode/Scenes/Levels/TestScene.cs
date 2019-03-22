using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1.Framework.Interfaces;
using Game1.Framework.Factories;
using Game1.Framework.EntityCode;
using Game1.GameCode.PlayerCode;
using Game1.GameCode.Obstacles;
using Game1.GameCode.NPCs;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.Scenes.Levels
{
    class TestScene
    {
        protected List<IGameObject> _GameList;

        public TestScene()
        {
            _GameList = new List<IGameObject>();
        }

        public void setup(ContentManager pContent, IEntityFactory pEntityFac)
        {
            String[] obst = new string[1];
            obst[0] = "Obstacle";

            string[] pl = new string[1];
            pl[0] = "player";

            string[] Hastings = new string[4];
            Hastings[0] = "player";
            Hastings[1] = "player1";
            Hastings[2] = "player2";
            Hastings[3] = "player3";


            for (int i = 0; i < 1; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>((64 * i) + 200, 500, obst, 1, true));
            }

            _GameList.Add(pEntityFac.CreateGameObject<Player>(300, 400, Hastings, 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<Triangle>(1100, 700, obst, 1, true));

            _GameList.Add(pEntityFac.CreateGameObject<Hunter>(200, 200, pl, 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<ScaredyCat>(600, 600, pl, 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<Buddy>(600, 400, pl, 1, false));
        }

        public List<IGameObject> GameList
        {
            get { return _GameList; }
        }
    }
}
