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

       
        public virtual void Move(Vector2 pForce)
        {
            //Set the Acceleration of game object based on the force being applied to the gameobject
            _mAccel.X = pForce.X / _mMass;
            _mAccel.Y = pForce.Y / _mMass;

            //Addjust the veloctiy of an object by appling the acceleration

            _Velocity.X = _Velocity.X + _mAccel.X;
            _Velocity.Y = _Velocity.Y + _mAccel.Y;

            //update the position of the Game object based on velocity
            _Position.X = _Position.X + _Velocity.X;
            _Position.Y = _Position.Y + _Velocity.Y;

        }
    }
}
