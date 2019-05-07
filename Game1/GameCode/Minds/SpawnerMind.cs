using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.Minds
{
    //the Purpose of the spawner mind is to create a framework for objets to be spawned in
    class SpawnerMind : AIMind
    {
        //instance variables

        public SpawnerMind()
        {
            //constructor code

            //this lets all entities that have a spawner mind know the entity has been created
            _event = "SpawnerCreated";

        }

        public override void Initalize(IMover _pTarget)
        {
            _mMover = _pTarget;

            States = new Dictionary<string, IState>();

            


        }

    

        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            if (pEvent == "SpawnerNeeded")
            {
                _event = "SpawnerActive";
            }
        }

        public override string CreateEvent()
        {
            return _event;
        }
        
    }
}
