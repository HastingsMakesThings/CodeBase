using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.States;
namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind
    {
        // Target of the current mind prefix with '_'
        protected IMover _Target;

        //This string holds the ucrrent state of the Player Mind
        protected string _currentState;

        protected string _event;
        public PlayerMind(IMover _pTarget)
        {
            _Target = _pTarget;

            States = new Dictionary<string, IState>();
            States.Add("Flee", new Flee(_Target));

            _currentState = "Flee";

            _event = "";
        }

        public override void Run()
        {
            IState temp;
            States.TryGetValue(_currentState, out temp);

            temp.Run();

        }

        public override void EventData(string pEvent, IGameObject pTrigger)
        {
           if(pEvent == "Flee")
            {
                IState temp;
                States.TryGetValue(pEvent, out temp);

                temp.NewTarget(pTrigger);
            }
        }

        //THis method is used to asses if the mind is creating an event
        public override String CreateEvent()
        {
            return  _event;
        }
    }
}
