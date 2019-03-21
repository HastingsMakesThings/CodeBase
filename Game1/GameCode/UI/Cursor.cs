using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces;
using Game1.Framework.Managers;
using Game1.GameCode.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.GameCode.UI
{
    class Cursor : MenuItem
    {

        public Cursor()
        {
        }

        public override void Update()
        {
            _Position.X = MouseManager._X;
            _Position.Y = MouseManager._Y;
          

            if (MouseManager._ClickedL)
            {
                _Scale = 2;
            }
            else if (MouseManager._ClickedR)
            {
                _Scale = 0.5f;
            }
            else
            {
                _Scale = 1;
            }
        }
    }
}
