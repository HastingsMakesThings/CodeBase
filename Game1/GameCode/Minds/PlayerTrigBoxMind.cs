using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Minds
{
    class PlayerTrigBoxMind : AIMind
    {
        //instacne variables

        public PlayerTrigBoxMind()
        {
            _event = "";
        } 
        public override string CreateEvent()
        {
            return _event;
        }

        public override void Run(GameTime gametime)
        {
            IState temp;

            if (States.Count > 0)
            {
                States.TryGetValue(_currentState, out temp);

                temp.Run(gametime);
            }
        }

        public override void EventData(string pEvent, IGameObject pTrigger)
        {
          if(pEvent == "PlayerCreated")
                if (States.ContainsKey("Shadow"))
                {
                    IState tempState;
                    States.TryGetValue("Shadow", out tempState);

                    tempState.NewTarget(pTrigger);
                }

            base.EventData(pEvent, pTrigger);
        }
    }
}
