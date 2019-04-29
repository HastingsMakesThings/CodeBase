using Game1.Framework.Interfaces.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.EntityCode.Sub_Entities
{
    //The funciton of this abstract is to providde a framework for objects that react to triggers on collision
    abstract class TriggerObject : ITriggerObject
    {
        //Instacne variables
        protected string[] _mTriggers;

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
            throw new NotImplementedException();
        }
    }
}
