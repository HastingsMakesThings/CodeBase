using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces;
using Game1.Framework.EntityCode.Sub_Minds;
using Game1.GameCode.States;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.NPCs
{
    //the ScaredyCat is a NPC that will flee from a trigger
    class ScaredyCat : Mover
    {
        public ScaredyCat()
        {
            //ConstructorCode

            Type = "ScaredyCat";

            //initalise mind
            _MyMind = new GenericNPC();
            _MyMind.Initalize(this);
            _MyMind.AddState<Flee>("Flee", this);

            _mMass = 5;
            _maxSpeed = 10;
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
