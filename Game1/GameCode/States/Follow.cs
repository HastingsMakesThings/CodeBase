using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.States
{
    class Follow : State
    {
        //the funciton of this calss is to provide a behaviour that causes objects to constantly adjuyst their position so that they foollow an object and operate twith 0 drag

        //instance variables
        //This creates a target that the object follows, call it _mTarget 
        private IGameObject _mTarget;

        public Follow()
        {
            //constructior code

        }

       

        //this method assings a new target for the IMover to move towards
        public override void NewTarget(IGameObject pTarget)
        {
            _mTarget = pTarget;


        }

        public override void Run(GameTime gametime)
        {
            //This calls the update data method, this should happen first
            UpdateData();
            if (_mMover != null && _mTarget != null)
            {
                //calls the calculate following behaviour method
                CalculateFollow();

                //Calss the Move method, this should happen last
                Move();
            }

        }

        //this method is used to calculate thedirection the objecty must travel in order to follow the target
        private void CalculateFollow()
        {
            //declare some vectors for the location of both objects

            Vector2 myPos = _mMover.oPostion;

            Vector2 targPos = _mTarget.Position;

           
            
            
                //declare a vector for the directional vector

                Vector2 newTragectory = new Vector2((targPos.X - myPos.X), (targPos.Y - myPos.Y));

            if (Math.Abs(newTragectory.Length()) >= 124)
            {
                //normalize that vector
                newTragectory.Normalize();

                //The force will be equal to the max speed multplied by the tragectory, hthis is then sent to apply force
                Vector2 tragForce = newTragectory * 10;

                //this sets the directional values to a nutral state
                _tVerDir = 0;
                _tHorDir = 0;

                //This should add values to the vertical direction 
                if (tragForce.Y > 0)
                    _tVerDir += 1;
                if (tragForce.Y < 0)
                    _tVerDir += -1;

                if (tragForce.X > 0)
                    _tHorDir += 1;
                if (tragForce.X < 0)
                    _tHorDir += -1;

                // apply the new force with the apply force method
                ApplyForce(tragForce);
            }
            }

        protected override void Move()
        {
            //Set the Acceleration of game object based on the force being applied to the target 

            _mAccel.X += _mForce.X;
            _mAccel.Y += _mForce.Y;



            _mMover.oAccel = _mAccel;
            //Addjust the veloctiy of an object by appling the acceleration


            _tVelocity.X += _mAccel.X;
            _tVelocity.Y += _mAccel.Y;


            //This capps the velocity
            if ((Math.Abs(_tVelocity.X) >= 10))
                _tVelocity.X = (10 * _tHorDir);

            if ((Math.Abs(_tVelocity.Y) >= 10))
                _tVelocity.Y = (10 * _tVerDir);

            //update the position of the Game object based on velocity
            _mMover.oPostion += _tVelocity;



            // _mMover.oPostion = _tPosition;
            //this resets the force
            _mForce = Vector2.Zero;
        } 
            



        }
    }
    
