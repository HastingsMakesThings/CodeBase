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

        public override void Run()
        {
            CheckTextures();
        }

        private void CheckTextures()
        {
            Vector2 tempPos = _tPosition;
            UpdateData();

            Vector2 currentPos = _mMover.oPostion;

            Vector2 Change = tempPos - currentPos;

           

        }

    }
}
