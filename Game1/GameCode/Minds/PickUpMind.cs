﻿using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.Minds
{
    class PickUpMind : AIMind
    {
        //instance variables
        //this bool identifies if the object is within the players triggerbox
        protected bool _byPlayer;

        public PickUpMind()
        {
            _currentState = "InActive";
        }

        //this is the run method
        public override void Run(GameTime gametime)
        {
            IState temp;

            if (States.Count > 0)
            {
                States.TryGetValue(_currentState, out temp);

                temp.Run(gametime);
            }

            _byPlayer = false;
        }

        public override string CreateEvent()
        {
            return _event;
        }

        //This  handles event Data and thus adjusts the states of the mind
        public override void EventData(string pEvent, IGameObject pTrigger)
        {
            //this checks if the opbject is beign carried and drops them if thwe player presses the space button
           if(pEvent == "PlayerPickup" && _currentState == "Carried")
            {
                 if (States.ContainsKey("InActive"))
                {
                    ICarrier tempCarry = (ICarrier)pTrigger;
                    tempCarry.isCarrying = false;
                    IState tempState;
                    States.TryGetValue("InActive", out tempState);

                    tempState.NewTarget(pTrigger);
                    _currentState = "InActive";

                    _event = "Dropped";

                    //_mMover.moverAngle = _mMover.moverAngle + 80;
                    _mMover.SetRigid = true;
                }
            }
            //this checks if the player is next to the object and lets the object get 'picked up  by the player'
             else if (_byPlayer && pEvent == "PlayerPickup")
            {
                ICarrier tempCarry = (ICarrier)pTrigger;

                if(!tempCarry.isCarrying)
                {
                    if (States.ContainsKey("Carried"))
                    {
                        IState tempState;
                        States.TryGetValue("Carried", out tempState);

                        tempState.NewTarget(pTrigger);

                        _currentState = "Carried";

                        _mMover.SetRigid = false;

                        _event = "PickedUp";

                        tempCarry.isCarrying = true;

                       // _mMover.moverAngle = _mMover.moverAngle -80;
                    }
                }
                
            }

           
        }
        public override void SetCondition(string pCondition)
        {
            if(pCondition == "ByPlayer")
            _byPlayer = true;
        }

    }
}
