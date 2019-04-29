using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    //Ths interface is for all objects that act like a trigger rather than a colidable object
    interface ITriggerArea 
    {
        //this method allows for a trigger obbject to be given a retrun value to identify if this trigger activates an event in the TriggerObject
        string IsTrigger(string[] pTriggers);

        //this recantgle deffines what area the trigger objects effect is
        Rectangle TriggArea { get; }
    }
}
