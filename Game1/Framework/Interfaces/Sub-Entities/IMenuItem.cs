using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    interface IMenuItem : IEntity
    {
        void Initialise(float pX, float pY, Texture2D pTexture, float pScale, string pPath);
    }
}
