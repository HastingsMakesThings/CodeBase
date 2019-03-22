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
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.EntityCode.Sub_Minds;


namespace Game1.GameCode.PlayerCode
{
    class Player : Mover
    {

        public Player()
        {
            // Initialise Type
            Type = "Player";
            // Initialise Mind
            _MyMind = new PlayerMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<_2DMove>("Mover",this);

            _mMass = 15;
            _maxSpeed = 10;
            _mFriction = -0.5f;
        }

        public override void Update()
        {

            CalculateProjectedX();
            CalculateProjectedY();




            CalculateVertexes();

            
            
        }

        public  override void CollReact(Vector2 pMTV)
        {
            this.Position = Position + pMTV;
        }
    }
}
