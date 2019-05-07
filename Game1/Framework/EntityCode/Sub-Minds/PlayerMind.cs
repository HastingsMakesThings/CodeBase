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
using Game1.GameCode.PlayerCode;
using Game1.GameCode.NPCs;

namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind
    {
        //instance variables
        protected string _CurrentSet;

        //variable for score
        private float _PlayerScore;
        public PlayerMind()
        {
            _CurrentSet = "Tex";

            _PlayerScore = 0;
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
            base.EventData(pEvent, pTrigger);

            if (pEvent == "TreatmentSuccess" || pEvent == "TreatmentFailure")
            {
                //this adjusts the player score
                Patient tempPat = (Patient)pTrigger;
                _PlayerScore += tempPat.PatientScore;
            }
            
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
