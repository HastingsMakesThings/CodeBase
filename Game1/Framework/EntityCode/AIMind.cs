using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.EntityCode
{
    abstract class AIMind : IAIMind
    {

        private IGameObject pTarget;
        protected Dictionary<string, IState> States;

        //This string holds the ucrrent state of the Player Mind
        protected string _currentState;

        protected string _event;

        public virtual void Run()
        {

        }

        public virtual void EventData(string pEvent, IGameObject pTrigger)
        {
           
        }

        public abstract string CreateEvent();


        public  IGameObject EventTrigger()
        {
            _event = "";
            if (pTarget != null)
                return pTarget;
            else
                return null;
        }
    }
}
