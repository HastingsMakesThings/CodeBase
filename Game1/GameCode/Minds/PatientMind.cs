using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.GameCode.NPCs;

namespace Game1.GameCode.Minds
{
    class PatientMind : PickUpMind
    {
        //instance variables
        bool _NeedsSpawn;

        //variable for score
        protected float _myScore;

        //varibale for score cap
        protected float _scoreCap;
        public PatientMind()
        {
            _NeedsSpawn = false;

            _scoreCap = -30;
            _myScore = 30;
        }

        public override void Run(GameTime gametime)
        {
            base.Run(gametime);

            //this checks if the patient is in a waitign state
            if((_currentState =="InActive")||(_currentState == "Carried"))
            {
                //thios adjust the score
                _myScore -= (float)gametime.ElapsedGameTime.TotalSeconds;
            }

            if (_NeedsSpawn)
            {
                 _event = "SpawnerNeeded";
            }
        }
        //This  handles event Data and thus adjusts the states of the mind
        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            base.EventData(pEvent, pTrigger);
            ////cheks to be dropped
            //if (pEvent == "PlayerPickup" && _currentState == "Carried")
            //{
            //    if (States.ContainsKey("InActive"))
            //    {
            //        IState tempState;
            //        States.TryGetValue("InActive", out tempState);

            //        tempState.NewTarget(pTrigger);
            //        _currentState = "InActive";

            //        _event = "Dropped";

            //        _mMover.SetRigid = true;
            //    }
            //}


            ////this checks if the player is next to the object and lets the object get 'picked up  by the player'
            //if (_byPlayer && pEvent == "PlayerPickup")
            //{
            //    if (States.ContainsKey("Carried"))
            //    {
            //        IState tempState;
            //        States.TryGetValue("Carried", out tempState);

            //        tempState.NewTarget(pTrigger);

            //        _currentState = "Carried";

            //        _mMover.SetRigid = false;

            //        _event = "PickedUp";
            //    }
            //}

            if(pEvent == "TreatmentSuccess")
            {
                Console.WriteLine("treatment has been sucessfull");
            }

            //this detects when a spawner is created or when the entity needs to be spawned
            if(pEvent == "SpawnerActive" && _NeedsSpawn)
            {
                _NeedsSpawn = false;

                if (States.ContainsKey("Spawning"))
                {
                    IState tempState;
                    States.TryGetValue("Spawning", out tempState);

                    tempState.NewTarget(pTrigger);

                    _currentState = "Spawning";

                    _event = "Dropped";
                }

            }


        }

        public override void SetCondition(string pCondition)
        {
            base.SetCondition(pCondition);

            if (pCondition == "TreatmentSuccess")
            {
                if(!_NeedsSpawn)
                {
                    _event = pCondition;

                    SetScore();

                    _NeedsSpawn = true;
                }

            }

            if (pCondition == "Spawned")
            {
                _currentState = "InActive";
                _myScore = Math.Abs(_scoreCap);

            }

            if (pCondition == "TreatmentFailure")
            {
                if (!_NeedsSpawn)
                {
                    _event = pCondition;

                    _myScore = -Math.Abs(_scoreCap);
                    _myScore -= 10;
                    SetScore();

                    _NeedsSpawn = true;
                }
            }

        }

        //thgis sets the patients score
        private void SetScore()
        {
            Patient tempPatient = (Patient)_mMover;

            tempPatient.PatientScore = _myScore;
        }

    }
}
