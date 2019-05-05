using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.GameCode.States;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces;

namespace Game1.Framework.EntityCode.Sub_Entities
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

        // Player Mind prefix with '_'
        protected IAIMind _MyMind;

        //strign that represents the curent animation beign played
        protected string _currAnim;


        
        //This allows the objects mass to be obtained
        public float oMass
        {
            get
            {
                return _mMass;
            }
        }

        //This allows the objects friction to be obtained
        public float oFriction
        {
            get
            {
                return _mFriction;
            }
        }

        //This allows the objects max speed to be obtained
        public float oMaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        //This allows the objects posiotion to be obtained
        public Vector2 oPostion
        {
            get
            {
                return _Position;
            }

            set
            {
                _Position = value;
            }
        }

        //This allows the objects velocity to be obtained
        public Vector2 oVelocity
        {
            get
            {
                return _Velocity;
            }

            set
            {
                _Velocity = value;
            }
        }

        //THis allows for the facing directions of the object be retrived
        public float oVertDir
        {
            get
            {
                return _VerDir;
            }
        }

        public float oHorDir
        {
            get
            {
                return _HorDir;
            }
        }

        public IAIMind getMind
        {
            get
            {
                return _MyMind;
            }
        }

        public Vector2 oAccel
        {
            get
            {
                return _mAccel;
            }

            set
            {
                _mAccel = value;
            }
        }

        public string currentText
        {
            get
            {
                return _currAnim;
            }

            set
            {
                _currAnim = value;
            }
        }

        public bool SetRigid
        {
            set
            {
                _mRigid = value;
            }
        }
    }
}
