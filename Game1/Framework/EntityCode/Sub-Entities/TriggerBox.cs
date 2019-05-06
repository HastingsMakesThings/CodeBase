
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
    abstract class ITriggerBox : GameObject, ITriggerArea
    {
        //protected strign array for all the triggers that the triggerbox holds
        protected string[] _myTriggers;

        //protercted string that acts as the default if no trigger is met, such as if the apossing trigger object can ignore collision with this object
        protected string _mDefault;

        
        //this funciton is used to identify if any of the strings in the pTriggers is relevent to this Triger area
        public virtual string IsTrigger(string[] pTriggers)
        {
            //for each value in the _mytriggers string, the strign is coampred to the string passed in, if there is a match, that strgin is returned lettign the caller react in their own deffined way
            foreach (string tempStr in _myTriggers)
            {
                foreach (string tempTrig in pTriggers)
                {
                    if (tempStr == tempTrig)
                        return tempStr;
                }
            }
            //default is returned if no match
            return "null";
        }
    }
}
