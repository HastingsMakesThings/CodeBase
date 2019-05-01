using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Interfaces.Managers
{
    interface IRenderManager : IManager
    {
        void Draw(SpriteBatch pSprite, List<IGameObject> pEnts);

        void Draw(SpriteBatch pSprite, List<IMenuItem> pEnts);

    }
}
