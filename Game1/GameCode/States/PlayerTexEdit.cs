using Game1.Framework.Managers;
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
            if (KeyboardManager.KeyLeft && KeyboardManager.KeyRight)
            {
                _mMover.currentText = "Idle_H";
            }
            else if (KeyboardManager.KeyLeft)
            {
                _mMover.currentText = "Left_H";
            }
            else if (KeyboardManager.KeyRight)
            {
                _mMover.currentText = "Right_H";
            }
            else if (KeyboardManager.KeyUp && KeyboardManager.KeyDown)
            {
                _mMover.currentText = "Idle_H";
            }
            else if (KeyboardManager.KeyUp)
            {
                _mMover.currentText = "Up_H";
            }
            else if (KeyboardManager.KeyDown)
            {
                _mMover.currentText = "Down_H";
            }
            else
            {
                _mMover.currentText = "Idle_H";
            }

        }
    }
}
