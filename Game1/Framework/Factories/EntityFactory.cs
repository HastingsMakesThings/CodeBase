using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Factories
{
    class EntityFactory : IEntityFactory
    {
        private ContentManager _Content;

        public EntityFactory(ContentManager pContent)
        {
            _Content = pContent;
        }


        // CreateEntity generates objects of type IGameObject
        // Pass in X and Y position, Texture, Scale and its Static state
        public IGameObject CreateGameObject<T>(float pX, float pY, string[] pTexture, float pScale, Boolean pStatic) where T : IGameObject, new()
        {
            try
            {
                IGameObject _GameObject = new T();

               
                

                _GameObject.Initialise(pX, pY, pScale, pStatic, pTexture.Count());

                foreach (string temptex in pTexture)
                {
                    Texture2D _Texture = _Content.Load<Texture2D>(temptex);

                    _GameObject.AddTexture(_Texture);
                }

                _GameObject.Setup();

                return _GameObject;

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failure to create GameObject. Error{0}", e);
            }
            return null;
        }

        // CreateEntity generates objects of type IMenuItem
        // Pass in X and Y position, Texture, Scale and its Path
        public IMenuItem CreateMenuItem<T>(float pX, float pY, string pTexture, float pScale, string pPath) where T : IMenuItem, new()
        {
            try
            {
                IMenuItem _MenuItem = new T();

                Texture2D _Texture = _Content.Load<Texture2D>(pTexture);

                _MenuItem.Initialise(pX, pY, _Texture, pScale, pPath);

                return _MenuItem;

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failure to create MenuItem. Error{0}", e);
            }
            return null;
        }
    }
}
