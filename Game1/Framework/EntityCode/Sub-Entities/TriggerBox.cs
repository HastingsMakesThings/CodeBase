
using Game1.Framework.Interfaces.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Framework.EntityCode.Sub_Entities
{
    //the funciton of this entity is to act as a trigger area in that sets of 
    abstract class TriggerBox : GameObject, ITriggerArea
    {
        //protected strign array for all the triggers that the triggerbox holds
        protected string[] _myTriggers;

        //protercted string that acts as the default if no trigger is met, such as if the apossing trigger object can ignore collision with this object
        protected string _mDefault;
        //this funciton is used to identify if any of the strings in the pTriggers is relevent to this Triger area
        public virtual string IsTrigger(string[] pTriggers)
        {
            throw new NotImplementedException();
        }
    }
}
