using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.States
{
    //this texture edit behavioru is specific to th eplayer character who has a greater range of textures
    class PlayerTexEdit : TextureEdit
    {
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

            if (Change.X > 0)
            {
                _mMover.currentText = "Left_H";
            }

            if (Change.X < 0)
            {
                _mMover.currentText = "Right_H";
            }

            if (Change.Y > 0)
            {
                _mMover.currentText = "Up_H";
            }

            if (Change.Y < 0)
            {
                _mMover.currentText = "Down_H";
            }

            if (Change.Y == 0 && Change.X == 0)
            {
                _mMover.currentText = "Idle_H";
            }

        }
    }
}
