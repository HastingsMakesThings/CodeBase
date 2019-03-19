using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.GameCode.Behaviours;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces.Sub_Entities;
namespace Game1.GameCode.Movers
{
    abstract class Mover : GameObject, IMover
    {
        //realistic movment code

        //DECLAREsome physics instance variables

        //Value for the mass of the Gameobject 
        protected float _mMass;

        //a value for the acceleration
        protected Vector2 _mAccel = new Vector2(0, 0);

        //a value for the  friction of the gameobject
        protected float _mFriction;

        //declare a value for force affecting an object
        protected Vector2 _mForce;

        //THis sets a max speed
        protected float _maxSpeed;

        public virtual void Move()
        {
            //Set the Acceleration of game object based on the force being applied to the gameobject if it does not equal zero
            if (_mForce.X != 0)
                _mAccel.X = _mForce.X / _mMass;
            else
                _mAccel.X = 0;

            if (_mForce.Y != 0)
                _mAccel.Y = _mForce.Y / _mMass;
            else
                _mAccel.Y = 0;

            //Addjust the veloctiy of an object by appling the acceleration

            _Velocity.X += _mAccel.X;
            _Velocity.Y += _mAccel.Y;

            //This capps the velocity
            if ((Math.Abs(_Velocity.X) >= _maxSpeed))
                _Velocity.X = _maxSpeed * _HorDir;

            if ((Math.Abs(_Velocity.Y) >= _maxSpeed))
                _Velocity.Y = _maxSpeed * _VerDir;
            
            //update the position of the Game object based on velocity
            _Position.X +=  _Velocity.X;
            _Position.Y +=  _Velocity.Y;

            //this resets the force
            _mForce = Vector2.Zero;

        }

        public void ApplyForce(Vector2 pForce)
        {
            //this applies a force to the _mForce vector;
            _mForce.X += pForce.X;

            _mForce.Y += pForce.Y;
        }
    }
}
