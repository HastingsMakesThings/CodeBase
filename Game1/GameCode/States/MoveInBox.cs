using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Managers;
using Microsoft.Xna.Framework;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.States
{
    //the funnction fo this method is to provide a _mover a small box thge can move in but not outside of
    class MoveInBox : State
    {
        //instance variables
        //this rectangle deffines where the object can go
        Rectangle _myRegion;
        public MoveInBox()
        {

        }

        public virtual void Initalize(IMover pMover)
        {
            _mMover = pMover;

            IGameObject tempObj = (IGameObject)_mMover;


        }

        public override void Run(GameTime gametime)
        {
            //checks that the mover is not null
            if(_mMover != null)
            {
                //updates data
                UpdateData();

                //performs calculation
                CalculateMove();

                //Moves mover
                Move();
            }
        }

        //this method will be used to calculate the movment of the object
        private void CalculateMove()
        {
            //this sets the directional values to a nutral state
            _tVerDir = 0;
            _tHorDir = 0;

            //This should add values to the vertical direction so that if one key is pressed it moves in that direction, if both are pressed, no additional movment
            if (KeyboardManager.KeyUp)
                _tVerDir += -1;
            if (KeyboardManager.KeyDown)
                _tVerDir += 1;

            if (KeyboardManager.KeyLeft)
                _tHorDir += -1;
            if (KeyboardManager.KeyRight)
                _tHorDir += 1;

            //this creates a force vector to apply to the Mover to get it to move
            Vector2 tForceVec = new Vector2((_tMaxSpeed * _tHorDir), (_tMaxSpeed * _tVerDir));

            ApplyForce(tForceVec);
        }
    }
}
