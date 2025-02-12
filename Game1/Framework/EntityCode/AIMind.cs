﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.Framework.EntityCode
{
    abstract class AIMind : IAIMind
    {
        // Target of the current mind prefix with '_'
        protected IMover _mMover;

        protected IGameObject _pTarget;
        protected Dictionary<string, IState> States;

        //This string holds the current state of the Player Mind
        protected string _currentState;

        protected string _event;

        public virtual void Run(GameTime gametime)
        {

        }

        public virtual void EventData(string pEvent, IGameObject pTrigger)
        {
            //clears event data
            if (pEvent == _event)
                _event = "";
        }

        public abstract string CreateEvent();

        //this grabbs the 
        public virtual IGameObject EventTrigger()
        {
            _event = "";
            if (_pTarget != null)
            {
                return _pTarget;
            }

            else
                _pTarget = (IGameObject)_mMover;
            return _pTarget;
        }

        //this method allos for States to be created 
        public void AddState<T>(string pKey, IMover pMover) where T : IState, new()
        {
            try
            {
                //this creates the new state
                IState nState = new T();

                //
                nState.Initalize(pMover);

                //Sends the state a new target
               // nState.NewTarget(_pTarget);
                
                //Adds the new state to the States list
                States.Add(pKey, nState);

                //sets the current state to the state that was just added
                _currentState = pKey;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failure to create State. Error{0}", e);
            }
        }

        public virtual void Initalize(IMover _pTarget)
        {
            _mMover = _pTarget;

            States = new Dictionary<string, IState>();

            _event = "";

            
        }

        public virtual void SetCondition(string pCondition)
        {
            
        }
    }
}
