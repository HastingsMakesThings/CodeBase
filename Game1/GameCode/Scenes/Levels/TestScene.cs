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


            for (int i = 0; i < 1; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>((64 * i) + 800, 500, "Obstacle", 1, true));
            }

            _GameList.Add(pEntityFac.CreateGameObject<Player>(800, 400, "Player", 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<Triangle>(800, 700, "Obstacle", 1, true));
        }

        public List<IGameObject> GameList
        {
            get { return _GameList; }
        }
    }
}
