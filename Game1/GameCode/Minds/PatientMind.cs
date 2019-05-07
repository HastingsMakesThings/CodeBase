using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.Minds
{
    class PatientMind : PickUpMind
    {
        //instance variables
        bool _NeedsSpawn;

        public PatientMind()
        {
            _NeedsSpawn = false;

          
        }
        //This  handles event Data and thus adjusts the states of the mind
        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            //cheks to be dropped
            if (pEvent == "PlayerPickup" && _currentState == "Carried")
            {
                if (States.ContainsKey("InActive"))
                {
                    IState tempState;
                    States.TryGetValue("InActive", out tempState);

                    tempState.NewTarget(pTrigger);
                    _currentState = "InActive";

                    _event = "Dropped";

                    _mMover.SetRigid = true;
                }
            }


            //this checks if the player is next to the object and lets the object get 'picked up  by the player'
            if (_byPlayer && pEvent == "PlayerPickup")
            {
                if (States.ContainsKey("Carried"))
                {
                    IState tempState;
                    States.TryGetValue("Carried", out tempState);

                    tempState.NewTarget(pTrigger);

                    _currentState = "Carried";

                    _mMover.SetRigid = false;

                    _event = "PickedUp";
                }
            }

            if(pEvent == "TreatmentSuccess")
            {
                Console.WriteLine("treatment has been sucessfull");
            }

            //this detects when a spawner is created or when the entity needs to be spawned
            if(pEvent == "SpawnerCreated" || (pEvent == "SpawnerActive" && _NeedsSpawn))
            {
                _NeedsSpawn = false;

                if (States.ContainsKey("Spawning"))
                {
                    IState tempState;
                    States.TryGetValue("Spawning", out tempState);

                    tempState.NewTarget(pTrigger);

                    _currentState = "Spawning";
                }

            }
        }

        public override void SetCondition(string pCondition)
        {
            base.SetCondition(pCondition);

            if (pCondition == "TreatmentSuccess")
            {
                _event = pCondition;
            }

            if (pCondition == "Spawned")
                _currentState = "InActive";
        }

    }
}
