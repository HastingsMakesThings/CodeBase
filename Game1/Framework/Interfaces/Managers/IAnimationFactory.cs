using Game1.Framework.Animations;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Managers
{
    //The purpose of the animation factory is to create the animations that occur in each entity
    interface IAnimationFactory
    {
        //This method is for creating IAnimations

        IAnimation CreatAnimation(string pTexture, float pFrmSpeed, bool pLoop, int pCount);

        //This method initalizes the IAnimationFactory
        void Initialize(ContentManager pContent);
    }
}
