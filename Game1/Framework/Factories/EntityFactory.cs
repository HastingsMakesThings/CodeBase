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
using Game1.Framework.Animations;

namespace Game1.Framework.Factories
{
    class EntityFactory : IEntityFactory
    {
        private ContentManager _Content;


        private int _IDCounter;
        public EntityFactory(ContentManager pContent)
        {
            _Content = pContent;

            _IDCounter = 0;
        }


        // CreateEntity generates objects of type IGameObject
        // Pass in X and Y position, Animation dictonary, Scale and its Static state
        public IGameObject CreateGameObject<T>(float pX, float pY, IDictionary<string, IAnimation> pAnim, string pStartAnim, float pScale, Boolean pStatic, bool pRigid, float pRendLayer, bool pVisibility ) where T : IGameObject, new()
        {
            try
            {
                IGameObject _GameObject = new T();

                _GameObject.Initialise(pAnim, pStartAnim, pX, pY, pScale, pStatic, pRigid, _IDCounter, pRendLayer, pVisibility);
                _IDCounter++;
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
        public IMenuItem CreateMenuItem<T>(float pX, float pY, IDictionary<string, IAnimation> pAnim, string pStartAnim, float pScale, Boolean pStatic, bool pRigid, float pRendLayer, bool pVisibility) where T : IMenuItem, new()
        {
            try
            {
                IMenuItem _MenuItem = new T();

                _MenuItem.Initialise(pAnim, pStartAnim, pX, pY, pScale, pStatic, pRigid, _IDCounter, pRendLayer, pVisibility);
                _IDCounter++;
                return _MenuItem;

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failure to create MenuItem. Error{0}", e);
            }
            return null;
        }

        // CreateEntity generates objects of type IMenuItem
        // Pass in X and Y position, Texture, Scale and its Path
        public ITextElement CreateTextElement<T>(IMenuItem pParent, string pValue, int pOffX, int pOffY) where T : ITextElement, new()
        {
            try
            {
                ITextElement _TextElement = new T();

                _TextElement.Initialise(pParent, pValue, pOffX, pOffY);
                _IDCounter++;
                return _TextElement;

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failure to create TextElement. Error{0}", e);
            }
            return null;
        }

    }
}
