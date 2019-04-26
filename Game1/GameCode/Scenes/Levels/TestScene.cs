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
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Animations;

namespace Game1.GameCode.Scenes.Levels
{
    class TestScene
    {
        protected List<IGameObject> _GameList;

        //animation factory for creating animations in the sceene
        private IAnimationFactory _mAnimFac;

        public TestScene()
        {
            _GameList = new List<IGameObject>();

            //Construct animation factory
            _mAnimFac = new AnimationFactory();
        }

        public void setup(ContentManager pContent, IEntityFactory pEntityFac)
        {
            //initalkise animation factory
            _mAnimFac.Initialize(pContent);

            //Animation for the player charcater
            IDictionary<string, IAnimation> PlayerAnim = new Dictionary<string, IAnimation>();
            PlayerAnim.Add("Idle", _mAnimFac.CreatAnimation("Hastings_Front_02", 200, true, 8));

            //Animation for the obstacles
            IDictionary<string, IAnimation> ObsAnim = new Dictionary<string, IAnimation>();
            ObsAnim.Add("Idle", _mAnimFac.CreatAnimation("Obstacle", 1, false, 1));

            for (int i = 0; i < 1; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>((64 * i) + 200, 500, ObsAnim, "Idle", 1, true));
            }

            _GameList.Add(pEntityFac.CreateGameObject<Player>(300, 400, PlayerAnim, "Idle", 0.1f, false));

            _GameList.Add(pEntityFac.CreateGameObject<Triangle>(1100, 700, ObsAnim, "Idle", 1, true));

            _GameList.Add(pEntityFac.CreateGameObject<Hunter>(200, 200, ObsAnim, "Idle", 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<ScaredyCat>(600, 600, ObsAnim, "Idle", 1, false));

            _GameList.Add(pEntityFac.CreateGameObject<Buddy>(600, 400, ObsAnim, "Idle", 1,  false));
        }

        public List<IGameObject> GameList
        {
            get { return _GameList; }
        }
    }
}
