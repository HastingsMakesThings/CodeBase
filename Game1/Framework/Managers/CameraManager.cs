using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.PlayerCode;

namespace Game1.Framework.Managers
{
    //the funciton of this manager is to move objects around the screen to give the appearance of a camera
    class CamearaManager : ICamearaManager
    {
        //instance variables
        private IList<IGameObject> _mGameList;

        //Caamera speed
        private float _mCameraSpeed;

        //vector for movemt
        Vector2 _mCamMove;

        //postion fo Tragte
        Vector2 _TargetPosition;

        //this holds an object for the target
        private ICameraTarget _mTarget;

        public CamearaManager(float pSpeed)
        {
            _mCameraSpeed = pSpeed;
        }

        public void GrabGameList(List<IGameObject> pGameList)
        {
            //this method sets the _game  list to the inputed game list

            _mGameList =  pGameList;

            //this grabs the player
            foreach (IGameObject g in _mGameList)
            {
               if(g is ICameraTarget)
                {
                    _mTarget = (ICameraTarget)g;

                    _TargetPosition = new Vector2(500, 600);
                    break;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if(!_mTarget.IsColliding || !_mTarget.StopTrack)
            {
                //this cycles around the update loop andmoves objects if they are not static
                CalculateMove();
                foreach (IGameObject g in _mGameList)
                {
                    if (!g.Static)
                    {
                        g.Position += _mCamMove;
                    }
                }
            }

            _mTarget.IsColliding = false;
        }

        private void CalculateMove()
        {
            _mCamMove = new Vector2();

            //this adds values to the _cam move vector that corrsipond with the direciton the keys are beign pressd
            if (KeyboardManager.KeyLeft)
                _mCamMove.X += 1;
            if (KeyboardManager.KeyRight)
                _mCamMove.X -= 1;
            if (KeyboardManager.KeyUp)
                _mCamMove.Y += 1;
            if (KeyboardManager.KeyDown)
                _mCamMove.Y -= 1;

            //this normalizes the cam move so it has a length of one
            if(_mCamMove != Vector2.Zero)
            _mCamMove.Normalize();

            //this extends the magnitued of the the vector by the quantity of the cam speed
            _mCamMove = _mCamMove * _mCameraSpeed;

            //this changes the position of the target if the targets position has changed
            if(!_mTarget.StopTrack &&(_mTarget.TargetPosition != _TargetPosition))
            {
                _mCamMove +=  _TargetPosition - _mTarget.TargetPosition;

                _mTarget.TargetPosition = _TargetPosition;
            }
        }
    }
}
