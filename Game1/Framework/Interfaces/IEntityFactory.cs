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
        IGameObject CreateGameObject<T>(float pX, float pY, IDictionary<string, IAnimation> pAnim, string pStartAnim, float pScale, Boolean pStatic, bool pRigid, float pRendLayer, bool pVisibility) where T : IGameObject, new();

        IMenuItem CreateMenuItem<T>(float pX, float pY, IDictionary<string, IAnimation> pAnim, string pStartAnim, float pScale, Boolean pStatic, bool pRigid, float pRendLayer, bool pVisibility) where T : IMenuItem, new();

        ITextElement CreateTextElement<T>(IMenuItem pParent, string pValue, int pOffX, int pOffY) where T : ITextElement, new();
    }
}
