using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.Minds;
using Game1.GameCode.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.NPCs
{   //the purpos eof this class is to be an objct that the player can pick up
    abstract class PickupAble : Mover, ITriggerObject
    {
        //Instacne variables
        protected string[] _mTriggers;

        public PickupAble()
        {
            
        }

        public void Initialise()
        {
            //ConstructorCode

            Type = "PickupAble";

            //initalise mind
            _MyMind = new PickUpMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<Carried>("Carried", this);
            _MyMind.AddState<InActive>("InActive", this);

            _mMass = 5;
            _maxSpeed = 10;
            _mFriction = -0.5f;

            _mTriggers = new string[1];
            _mTriggers[0] = "PlayerTrigger";
        }

        public override void Update(GameTime gameTime)
        {
            CalculateVertexes();
        }

        public string[] objTriggers
        {
            get
            {
                return _mTriggers;
            }
        }

        //this holds the reaction that entities will perform when triggered
        public virtual void ActiveTrigger(string pEvent)
        {
            if (pEvent == "PlayerTrigger")
            {
                _MyMind.SetCondition("ByPlayer");
                Console.WriteLine("TriggerObject activated");
            }
               
        }

        public void AddTrigger(string pTrigger)
        {
            throw new NotImplementedException();
        }
    }
}
