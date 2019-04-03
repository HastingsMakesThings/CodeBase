using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Factories;
using Game1.Framework.EntityCode;
using Game1.GameCode.PlayerCode;
using Game1.GameCode.Scenes.Levels;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Managers
{
    /// <summary>
    /// EntityManager will manage the spawning of entities 
    /// Including different EntityLists
    /// </summary>
    class EntityManager : IEntityManager
    {
        // DECLARE factories prefix them with '_'
        // EntityFactory used to create entities
        IEntityFactory _EntityFac;

        //DECLARE a referance to ContentManagers prefix it with '_'
        protected ContentManager _Content;
        //DECLARE a list of type IGameObject refix it with '_'
        protected List<IGameObject> _GameList;

        public EntityManager(ContentManager pContent)
        {
            _Content = pContent;

            _EntityFac = new EntityFactory(_Content);

            _GameList = new List<IGameObject>();
            
        }

        public void LoadLevel(string pLevel)
        {
            switch (pLevel)
            {
                case "One":
                    Console.WriteLine("Main Menu Loaded!");
                    break;
                case "Two":
                    Console.WriteLine("Level Select Loaded!");
                    break;
                case "Three":
                    Console.WriteLine("Settings Loaded!");
                    break;
                default:
                    TestScene scene = new TestScene();

                    scene.setup(_Content, _EntityFac);

                    _GameList = scene.GameList;
                    break;
            }

        }

        public List<IGameObject> GameObjectList
        {
            get { return _GameList; }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGameObject g in _GameList)
            {
                g.Update(gameTime);
            }
        }

    }
}
