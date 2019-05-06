using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Animations;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    interface IMenuItem : IEntity
    {
        void Initialise(IDictionary<string, IAnimation> pAnim, string pStartAnim, float pX, float pY, float pScale, bool pStatic, bool pRigid, int ID, float pRednLayer, bool pVisibility);
    }
}
