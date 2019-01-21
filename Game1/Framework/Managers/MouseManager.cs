using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Framework.Interfaces.Managers;


namespace Game1.Framework.Managers
{
    class MouseManager : IMouseManager, IManager
    {
        public static float _X;
        public static float _Y;

        public static Boolean _ClickedL = false;

        public static Boolean _ClickedR = false;


        public MouseManager()
        {

        }

        public void CheckClicked()
        {
                // Check if Left mouse button released
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _ClickedL = true;
                }
                else
                {
                    _ClickedL = false;
                }
                // Check if right mouse button released
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    _ClickedR = true;
                }
                else
                {
                    _ClickedR = false;
                }
                            
        }

        public void Update()
        {
            // Check if game is focused
            if (Kernal._Focused)
            {
                CheckClicked();

                _X = Mouse.GetState().X;
                _Y = Mouse.GetState().Y;
            }
            
        }

        #region Properties

        #endregion

    }
}
