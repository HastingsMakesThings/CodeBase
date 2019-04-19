using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Animations;

namespace Game1.Framework.Interfaces
{
    interface IEntityFactory
    {
        IGameObject CreateGameObject<T>(float pX, float pY, IDictionary<string, IAnimation> pAnim, float pScale, Boolean pState) where T : IGameObject, new();

        IMenuItem CreateMenuItem<T>(float pX, float pY, string pTexture, float pScale, string pPath) where T : IMenuItem, new();
    }
}
