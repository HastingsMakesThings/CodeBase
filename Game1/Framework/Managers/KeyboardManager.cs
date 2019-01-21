using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Game1.Framework.Interfaces.Managers;

namespace Game1.Framework.Managers
{
    class KeyboardManager : IKeyboardManager
    {
        // Initialise keys below prefix them with '_'
        // KeyRight used to check if 'D' or 'Right' is pressed
        public static Boolean KeyRight;
        // KeyRight used to check if 'A' or 'Left' is pressed
        public static Boolean KeyLeft;
        // KeyRight used to check if 'W' or 'Up' is pressed
        public static Boolean KeyUp;
        // KeyRight used to check if 'S' or 'Down' is pressed
        public static Boolean KeyDown;
        // KeyJump used to check if 'Space' is pressed
        public static Boolean KeyJump;

        // DECLARE KeyboardState prefix with '_'
        KeyboardState _State = Keyboard.GetState();

        public KeyboardManager()
        {
            KeyRight = false;
            KeyLeft = false;
            KeyUp = false;
            KeyDown = false;
            KeyJump = false;
        }

        public void CheckInput()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                KeyUp = true;
            }
            else
            {
                KeyUp = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                KeyLeft = true;
            }
            else
            {
                KeyLeft = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                KeyDown = true;
            }
            else
            {
                KeyDown = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                KeyRight = true;
            }
            else
            {
                KeyRight = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                KeyJump = true;
            }
            else
            {
                KeyJump = false;
            }
        }

        public void Update()
        {
            CheckInput();
        }

    }
}
