using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces;

namespace Game1.Framework.EntityCode.Sub_Minds
{
    class GenericNPC : AIMind
    {
        public override void Run()
        {
            IState temp;

            if (States.Count > 0)
            {
                States.TryGetValue(_currentState, out temp);

                temp.Run();
            }
        }
        //this method is used to asses if the mind is creating an event
        public override string CreateEvent()
        {
            return _event;
        }

        //This  handles event Data and thus adjusts the states of the Generic NPCMind 
        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            //If this event is called  then anything with a flee key will have its behaviou adjusted
            if(pEvent == "Flee from Me")
            {
                if(States.ContainsKey("Flee"))
                {
                    IState tempState;
                    States.TryGetValue("Flee", out tempState);

                    tempState.NewTarget(pTrigger);
                }
            }

            //If this event is called  then anything with a flee key will have its behaviou adjusted
            if (pEvent == "Seek Me")
            {
                if (States.ContainsKey("Seek"))
                {
                    IState tempState;
                    States.TryGetValue("Seek", out tempState);

                    tempState.NewTarget(pTrigger);
                }
            }

            //If this event is called  then anything with a flee key will have its behaviou adjusted
            if (pEvent == "Pursue Me")
            {
                if (States.ContainsKey("Pursue"))
                {
                    IState tempState;
                    States.TryGetValue("Pursue", out tempState);

                    tempState.NewTarget(pTrigger);
                }
            }
        }
    }
}
