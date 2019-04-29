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
    class Seek : State
    {
        //The function of the Seek state is to seek out another object and move towards it


        //Instance Variables
        //The _mTelos is the gameobject that the State seeks out
        IGameObject _mTelos;
        //constructor, takes in a target Mover
        public Seek( )
        {
           
        }

        public override void Run(GameTime gametime)
        {
            //This calls the update data method, this should happen first
            UpdateData();
            if(_mMover != null&& _mTelos != null)
            {
                //calls the calculate seek method
                CalculateSeek();

                //Calss the Move method, this should happen last
                Move();
            }
            
        }

        //this method assings a new target for the IMoer to move towards
        public override void NewTarget(IGameObject pTelos)
        {
            _mTelos = pTelos;
        }

        //this method is used to calculate the direction that the object should take in order to seek the object
        private void CalculateSeek()
        {
            
            //declare some vectors for the location of both objects

            Vector2 myPos = _mMover.oPostion;

            Vector2 telPos = _mTelos.Position;

            //declare a vector for the directional vector

            Vector2 newTragectory = new Vector2((telPos.X - myPos.X), (telPos.Y - myPos.Y));

            //normalize that vector
            newTragectory.Normalize();

            //The force will be equal to the max speed multplied by the tragectory, hthis is then sent to apply force
            Vector2 tragForce = newTragectory * _tMaxSpeed;

            //this sets the directional values to a nutral state
            _tVerDir = 0;
            _tHorDir = 0;

            //This should add values to the vertical direction so that if one key is pressed it moves in that direction, if both are pressed, no additional movment
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
}
