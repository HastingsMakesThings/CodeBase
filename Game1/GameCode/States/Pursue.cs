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
    class Pursue : State
    {
        //The function of the pursue state is to seek out another object and move towards it


        //Instance Variables
        //The _mQuarry is the gameobject that the State persues out
        IGameObject _mQuarry;
        //constructor, takes in a target Mover
        public Pursue(IMover pTarget)
        {
            //sets the target Imover that this behaviour will affect
            _mTarget = pTarget;
        }

        public override void Run()
        {
            //This calls the update data method, this should happen first
            UpdateData();
            if (_mTarget != null || _mQuarry != null)
            {
                //calls the calculate pursue method
                CalculatePursue();

                //Calss the Move method, this should happen last
                Move();
            }

        }

        //this method assings a new target for the IMoer to move towards
        public void NewTarget(IGameObject pQuarry)
        {
            _mQuarry = pQuarry;
        }

        //this method is used to calculate the direction that the object should take in order to pursue the object
        private void CalculatePursue()
        {

            //declare some vectors for the location of both objects

            Vector2 myPos = _mTarget.oPostion;

            Vector2 quarPos = _mQuarry.Position;

            //declare a vector for the directional vector

            Vector2 newTragectory = new Vector2((quarPos.X - myPos.X), (quarPos.Y - myPos.Y));

            //grab the lenght of this vector so that the distance betweent the curret positions is recorded
            float TragLenth = newTragectory.Length();

            //this variable is the coefficient used to work out how much the object should adjust its ragectory in order to catch the Quarry
            float tragCoeff;
            if((TragLenth == 0)||(_tVelocity.Length() == 0 ))
            {
                tragCoeff = 0;
            }
            else
            {
                tragCoeff = TragLenth / _tVelocity.Length();
            }

            //create a vector to hold the quarry future position
            Vector2 quarFuture = new Vector2((quarPos.X + (_mQuarry.XVelocity * tragCoeff)), (quarPos.Y + (_mQuarry.YVelocity * tragCoeff)));

            //This quarry future vector is the location the quarry will be in when the IMover reaches the location
            //normalize that vector
            quarFuture.Normalize();

            //The force will be equal to the max speed multplied by the tragectory, this is then sent to apply force
            Vector2 tragForce = quarFuture * _tMaxSpeed;

            // apply the new force with the apply force method
            ApplyForce(tragForce);

        }
    }
}

