using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Game1.GameCode.States
{
    class TextureEdit : State
    {
        //the purpose of this state is to chaneg the texture of the player character based on player input

        public TextureEdit()
        {

        }

        public override void Run(GameTime gametime)
        {
            CheckTextures();
        }

        private void CheckTextures()
        {
            Vector2 tempPos = _tPosition;
            UpdateData();

            Vector2 currentPos = _mMover.oPostion;

            Vector2 Change = tempPos - currentPos;

           if(Change.X > 0)
            {
                _mMover.currentText = "Left";
            }

            if (Change.X < 0)
            {
                _mMover.currentText = "Right";
            }

            if (Change.Y > 0)
            {
                _mMover.currentText = "Up";
            }

            if (Change.Y < 0)
            {
                _mMover.currentText = "Down";
            }

            if(Change.Y == 0 && Change.X ==0)
            {
                _mMover.currentText = "Idle";
            }

        }

    }
}
