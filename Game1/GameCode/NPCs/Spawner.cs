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
using Game1.GameCode.Minds;

namespace Game1.GameCode.Obstacles
{
    class Spawner : Mover
    {

        public Spawner()
        {
            Type = "Spawner";

            //initalise mind
            _MyMind = new SpawnerMind();
            _MyMind.Initalize(this);
            

            _mMass = 5;
            _maxSpeed = 10;
            _mFriction = -0.5f;
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        #region Properties
        #endregion

    }
}
