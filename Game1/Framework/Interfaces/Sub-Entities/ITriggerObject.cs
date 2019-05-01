using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Sub_Entities
{   
    //this interface is for all objects that act as an object that triggers events
    interface ITriggerObject 
    {
        //this string array holds the trigger areas that effect thsi object
        string[] objTriggers { get; }

        //this method is called if the object is activated by a trigger, the method is sent with a string to detemrine what effect the trigger has on the object
        void ActiveTrigger(string pEvent);

        void AddTrigger(string pTrigger);
    }
}
