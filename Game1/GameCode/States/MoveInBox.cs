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

        //this rectangle deffines the boundign box of the object
        Rectangle _myBoundign;

        //bool 
        bool hasSetup;
        public MoveInBox()
        {
            hasSetup = false;
        }

        public override void Initalize(IMover pMover)
        {
            //this initalizes the mover
            _mMover = pMover;

        }

        private void Setup()
        {
            hasSetup = true;
            //this grabs the texture values from the  object that are important for creating the region
            IGameObject tempObj = (IGameObject)_mMover;

            Rectangle TempTangle = new Rectangle((int)tempObj.XPosition, (int)tempObj.XPosition, (int)(tempObj.Bounds.Width * tempObj.Scale), (int)(tempObj.Bounds.Height * tempObj.Scale));

            //this creates a region 3 times the size of the object
            _myRegion = new Rectangle((TempTangle.X - TempTangle.Width), (TempTangle.Y - TempTangle.Height), TempTangle.Width * 1, TempTangle.Height * 1);

            Vector2[] tempVerts = tempObj.Verts;

            _myBoundign = new Rectangle((int)(tempVerts[0].X), (int)tempVerts[0].Y, (int)(tempVerts[1].X - tempVerts[0].Y), (int)(tempVerts[2].Y - tempVerts[0].Y));
        }
        public override void Run(GameTime gametime)
        {
            if (!hasSetup)
                Setup();
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

        //the purpose of this bool is to chek if the entity has moved outside the box
        private bool CheckInBox()
        {
            bool tempBool = false;

            Vector2 Offset = new Vector2();
            //grabs the center point of the box and the bounding of the object
            Vector2 centerBound = new Vector2();
            centerBound.X = _myBoundign.Center.X;
            centerBound.Y = _myBoundign.Center.Y;

            Vector2 centerBox = new Vector2();
            centerBox.X = _myRegion.Center.X;
            centerBox.Y = _myRegion.Center.Y;

            //this calculates the difference
            Vector2 Difference = new Vector2(centerBox.X - centerBound.X, centerBox.Y - centerBound.Y);

            //calculates if the object is outside the box on the x axis
            if(Math.Abs(Difference.X) > (centerBox.X +(_myRegion.Width * 0.5)))
            {
                //the object is out the box
                tempBool = true;
                if (Difference.X < 0)
                {
                    //Calculate and move the object to a better postion
                    Offset.X = ((centerBox.X - (float)(_myRegion.Width) - centerBound.X));
                }
                else
                {
                    //Calculate and move the object to a better postion
                    Offset.X = ((centerBox.X + (float)(_myRegion.Width) - centerBound.X));
                }
                
            }

            //calculates if the object is outside the box on the x axis
            if (Math.Abs(Difference.Y) > (centerBox.Y +(_myRegion.Height * 0.5)))
            {
                //the object is out the box
                tempBool = true;

                //Calculate and move the object to a better postion
                Offset.Y = centerBox.Y - centerBound.Y;
                Console.WriteLine("Out of Box");
            }

            _mMover.oPostion += Offset;

            return tempBool;

        }
        protected override void Move()
        {

            if(!CheckInBox())
            {
                //Set the Acceleration of game object based on the force being applied to the target gameobject if it does not equal zero
                if (_mForce.X != 0)
                    _mAccel.X += _mForce.X / _tMass;
                else
                    _mAccel.X = 0;

                if (_mForce.Y != 0)
                    _mAccel.Y += _mForce.Y / _tMass;
                else
                    _mAccel.Y = 0;


                _mMover.oAccel = _mAccel;
                //Addjust the veloctiy of an object by appling the acceleration


                _tVelocity.X += _mAccel.X;
                _tVelocity.Y += _mAccel.Y;

                _tVelocity -= _mDrag;
                //This capps the velocity
                if ((Math.Abs(_tVelocity.X) >= _tMaxSpeed))
                    _tVelocity.X = (_tMaxSpeed * _tHorDir);

                if ((Math.Abs(_tVelocity.Y) >= _tMaxSpeed))
                    _tVelocity.Y = (_tMaxSpeed * _tVerDir);

                //update the position of the Game object based on velocity
                _mMover.oPostion += _tVelocity;

               

                // _mMover.oPostion = _tPosition;
                //this resets the force
                _mForce = Vector2.Zero;

            }

            Vector2 TempPos = _mMover.oPostion;

            _myBoundign.X = (int)TempPos.X;
            _myBoundign.Y = (int)TempPos.Y;


        }
    }
}
