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

        public static Boolean oneKey;
        public static Boolean twoKey;
        public static Boolean threeKey;
        // DECLARE KeyboardState prefix with '_'
        KeyboardState _State = Keyboard.GetState();


      
        public KeyboardManager()
        {
            KeyRight = false;
            KeyLeft = false;
            KeyUp = false;
            KeyDown = false;
            KeyJump = false;

            oneKey = false;
        }

        public void CheckInput()
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.W) || currentState.IsKeyDown(Keys.Up))
            {
                KeyUp = true;
            }
            else
            {
                KeyUp = false;
            }

            if (currentState.IsKeyDown(Keys.A) || currentState.IsKeyDown(Keys.Left))
            {
                KeyLeft = true;
            }
            else
            {
                KeyLeft = false;
            }

            if (currentState.IsKeyDown(Keys.S) || currentState.IsKeyDown(Keys.Down))
            {
                KeyDown = true;
            }
            else
            {
                KeyDown = false;
            }

            if (currentState.IsKeyDown(Keys.D) || currentState.IsKeyDown(Keys.Right))
            {
                KeyRight = true;
            }
            else
            {
                KeyRight = false;
            }

            if (currentState.IsKeyDown(Keys.Space))
            {
                KeyJump = true;
            }
            else
            {
                KeyJump = false;
            }

            if(currentState.IsKeyDown(Keys.D1))
            {
                oneKey = true;
            }
            else
            {
                oneKey = false;
            }

            if (currentState.IsKeyDown(Keys.D2))
            {
                twoKey = true;
            }
            else
            {
                twoKey = false;
            }

            if (currentState.IsKeyDown(Keys.D3))
            {
                threeKey = true;
            }
            else
            {
                threeKey = false;
            }
        }

        public void Update()
        {
            CheckInput();
        }

      
    }
}
