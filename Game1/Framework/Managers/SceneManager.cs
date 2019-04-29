using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Managers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Factories;
using Game1.GameCode.Scenes.Menus;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Managers
{
    /// <summary>
    /// SceneManager will be used to manage what scenes are currently being drawn
    /// I.E. Menu, Levels and UI.
    /// </summary>
    class SceneManager : ISceneManager
    {
        
        // DECLARE factories prefix them with '_'
        // EntityFactory used to create entities
        IEntityFactory _EntityFac;

        //DECLARE a referance to ContentManagers prefix it with '_'
        protected ContentManager _Content;

        protected List<IMenuItem> _SceneList;


        public SceneManager(ContentManager pContent)
        {
            _Content = pContent;

            _SceneList = new List<IMenuItem>();

            _EntityFac = new EntityFactory(_Content);
        }

        public void LoadScene(string pScene)
        {
            _SceneList.Clear();
            switch (pScene)
            {
                case "Main":
                    Console.WriteLine("Main Menu Loaded!");
                    break;
                case "LevelSelect":
                    Console.WriteLine("Level Select Loaded!");
                    break;
                case "Settings":
                    Console.WriteLine("Settings Loaded!");
                    break;
                default:
                    TestMenu menu = new TestMenu();

                    menu.setup(_Content, _EntityFac);

                    _SceneList = menu.MenuList;
                    break;
            }
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (IMenuItem s in _SceneList)
            {
                s.Update(gameTime);
            }
        }

        //this method is used to remove an entity from the sceene list
        public void RemoveEntity(int entID)
        {
            throw new NotImplementedException();
        }

        //this method is used to add an entity to the scene list
        public void AddEntity(IEntity pNewEnt)
        {
            throw new NotImplementedException();
        }

        #region Properties

        public List<IMenuItem> SceneList
        {
            get { return _SceneList; }
        }

        #endregion

    }
}
