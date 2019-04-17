using Game1.Framework.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Animations;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Factories
{
    class AnimationFactory : IAnimationFactory
    {
        //The Purpose of the Animationfactory is to create animations 

        //Instance variables

        //Content manager that is used for animation creation 
        private ContentManager _mContentMgr;
        public AnimationFactory()
        {
            //Constructor code
        }

        //This creates the Animation and returns it to the caller
        public IAnimation CreatAnimation(string pTexture, float pFrmSpeed, bool pLoop, int pCount)
        {
            //This will create an animation
         try
            {
                Texture2D mTexture = _mContentMgr.Load<Texture2D>(pTexture);

                IAnimation mAnim = new Animation();

                mAnim.Initalize(mTexture, pFrmSpeed, pLoop, pCount);

                return mAnim;
            }
            catch(NullReferenceException e) //This catches if the content does not exist
            {
                Console.WriteLine("Failure to create Animation. Error{0}", e);
            }

            return null;
        }

        public void Initialize(ContentManager pContent)
        {
            //This sets the content manger to the contentMgr
            _mContentMgr = pContent;
        }
    }
}
