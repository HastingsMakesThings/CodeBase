using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Managers;
using Game1.GameCode.States;
using Game1.Framework.EntityCode.Sub_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.GameCode.Obstacles
{
    class Obstacle : GameObject
    {

        public Obstacle()
        {
            Type = "Obstacle";
        }

        public override void Update(GameTime gameTime)
        {
            CalculateVertexes();
        }

        #region Properties
        #endregion

    }
}
