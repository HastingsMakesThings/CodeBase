using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.States;
using Game1.Framework.Managers;
using Microsoft.Xna.Framework;

namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind
    {
        //instance variables
        string _CurrentSet;


        public PlayerMind()
        {
            _CurrentSet = "Tex";
        }



        public override void Run(GameTime gametime)
        {
            _event = "";
            IState temp;

            if(States.Count > 0)
            {
                States.TryGetValue(_currentState, out temp);

                temp.Run(gametime);

                States.TryGetValue(_CurrentSet, out temp);
                temp.Run(gametime);
            }

            if (KeyboardManager.oneKey)
                _event = "Flee from Me";
            if (KeyboardManager.twoKey)
                _event = "Seek Me";
            if (KeyboardManager.threeKey)
                _event = "Pursue Me";
            if(KeyboardManager.KeyJump)
            {
                _event = "PlayerPickup";
            }

        }

        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            //this should chaneg the texture sets of the player when an object is beign carried
          if(pEvent == "PickedUp")
            {
                _CurrentSet = "PlayTex";
            }

            if (pEvent == "Dropped")
            {
                _CurrentSet = "Tex";
            }
            base.EventData(pEvent, pTrigger);
        }

        //THis method is used to asses if the mind is creating an event
        public override String CreateEvent()
        {
            return  _event;
        }

        public override void Initalize(IMover _pTarget)
        {
            _mMover = _pTarget;

            States = new Dictionary<string, IState>();

            _event = "PlayerCreated";

            this._pTarget = (IGameObject)_pTarget;


        }
    }
}
