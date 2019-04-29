using Game1.Framework.EntityCode.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.Triggers
{
    //this entity produces string if the correct entity is brought onto it
    class ScoreBox: TriggerBox 
    {
        //instance variables
        
        public ScoreBox()
        {
            //constructor code

            //set default
            _mDefault = "Ignore";
        }

        //this cycles through the triggers of this entity to determin if an event can occur
        public override string IsTrigger(string[] pTriggers)
        {
            //for each value in the _mytriggers string, the strign is coampred to the string passed in, if there is a match, that strgin is returned lettign the caller react in their own deffined way
            foreach(string tempStr in _myTriggers)
            {
                foreach(string tempTrig in pTriggers)
                {
                    if (tempStr == tempTrig)
                        return tempStr;
                }
            }
            //default is returned if no match
            return _mDefault;
        }
    }
}
