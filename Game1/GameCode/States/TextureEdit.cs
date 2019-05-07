using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Framework.Managers;

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

           if(KeyboardManager.KeyLeft && KeyboardManager.KeyRight)
            {
                _mMover.currentText = "Idle";
            }
           else if(KeyboardManager.KeyLeft)
            {
                _mMover.currentText = "Left";
            }
           else if (KeyboardManager.KeyRight)
            {
                _mMover.currentText = "Right";
            }
           else if (KeyboardManager.KeyUp && KeyboardManager.KeyDown)
            {
                _mMover.currentText = "Idle";
            }
           else if (KeyboardManager.KeyUp)
            {
                _mMover.currentText = "Up";
            }
           else if(KeyboardManager.KeyDown)
            {
                _mMover.currentText = "Down";
            }
           else
            {
                _mMover.currentText = "Idle";
            }

        }

    }
}
