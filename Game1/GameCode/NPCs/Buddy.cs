using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces;
using Game1.Framework.EntityCode.Sub_Minds;
using Game1.GameCode.States;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.NPCs
{
    class Buddy : Mover
    {

        public Buddy()
        {
            // ConstructorCode

            Type = "Buddy";

            //initalise mind
            _MyMind = new GenericNPC();
            _MyMind.Initalize(this);
            _MyMind.AddState<Follow>("Seek", this);

            _mMass = 3;
            _maxSpeed = 5;
            _mFriction = -0.5f;
        }

        public override void CollReact(Vector2 pMTV)
        {
            this.Position = Position + pMTV;
        }


        public override void Update(GameTime gameTime)
        {
            CalculateVertexes();
        }


    }
}
