using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.States
{
    abstract class State : IState
    {


        //realistic movment code

        //DECLAREsome physics instance variables 

        //a value for the acceleration
        protected Vector2 _mAccel = new Vector2(0, 0);

        //declare a value for force affecting an object
        protected Vector2 _mForce;

        //declare a target IMover, an entity that will eb affected by states
        protected IMover _mTarget;

        //Declare some instance variables that protatain to the target

        //declare a mass for the target
        protected float _tMass;

        //Declare a velocity for the target
        protected Vector2 _tVelocity;

        //Declare a maxspeed for the target
        protected float _tMaxSpeed;

        //position of the target
        protected Vector2 _tPosition;

        //Declare variables for the facign directions
        protected float _tVerDir;
        protected float _tHorDir;

        //variable for friction
        protected float _tFriction;

        public virtual void Run()
        {

        }

        protected virtual void UpdateData()
        {
            //This method retrieves all the data from the target so that it can be used in th upcoming calculations

            _tMass = _mTarget.oMass;

            _tVelocity = _mTarget.oVelocity;

            _tMaxSpeed = _mTarget.oMaxSpeed;

            _tPosition = _mTarget.oPostion;

            _tVerDir = _mTarget.oVertDir;

            _tHorDir = _mTarget.oHorDir;

            _tFriction = _mTarget.oFriction;
        }
        protected virtual void Move()
        {
            
            //Set the Acceleration of game object based on the force being applied to the target gameobject if it does not equal zero
            if (_mForce.X != 0)
                _mAccel.X = _mForce.X / _tMass;
            else
                _mAccel.X = 0;

            if (_mForce.Y != 0)
                _mAccel.Y = _mForce.Y / _tMass;
            else
                _mAccel.Y = 0;

            //Addjust the veloctiy of an object by appling the acceleration

            _tVelocity.X += _mAccel.X - _tFriction;
            _tVelocity.Y += _mAccel.Y - _tFriction;

            //This capps the velocity
            if ((Math.Abs(_tVelocity.X) >= _tMaxSpeed))
                _tVelocity.X = (_tMaxSpeed - _tFriction) * _tHorDir;

            if ((Math.Abs(_tVelocity.Y) >= _tMaxSpeed))
                _tVelocity.Y = (_tMaxSpeed - _tFriction) * _tHorDir;

            //update the position of the Game object based on velocity
            _tPosition.X += _tVelocity.X;
            _tPosition.Y += _tVelocity.Y;

            //this resets the force
            _mForce = Vector2.Zero;

        }

        protected void ApplyForce(Vector2 pForce)
        {
            //this applies a force to the _mForce vector;
            _mForce.X += pForce.X;

            _mForce.Y += pForce.Y;
        }

        public virtual void NewTarget(IGameObject pTarget)
        {
           
        }
    }
}

