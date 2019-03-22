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
namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind
    {
        

       
        public PlayerMind()
        {
            
        }

        

        public override void Run()
        {
            IState temp;
            
            if(States.Count > 0)
            {
                States.TryGetValue(_currentState, out temp);

                temp.Run();
            }

            if (KeyboardManager.oneKey)
                _event = "Flee from Me";
            if (KeyboardManager.twoKey)
                _event = "Seek Me";
            if (KeyboardManager.threeKey)
                _event = "Pursue Me";
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

        public override void Initalize(IMover _pTarget)
        {
            _mMover = _pTarget;

            States = new Dictionary<string, IState>();

            _event = "";

            this._pTarget = (IGameObject)_pTarget;


        }
    }
}
