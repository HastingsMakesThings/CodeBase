using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Game1.Framework.Interfaces.Managers;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Managers
{
    class SoundManager : ISoundManager
    {
        protected ContentManager _Content;
        protected SoundEffect _LClickSound;
        protected SoundEffect _RClickSound;

        public SoundManager(ContentManager pContent)
        {
            _Content = pContent;

            // Load two sound clips into project and set the file location/name in the quotation marks
            // Upon running the game left and right click should play the sound
            _LClickSound = _Content.Load<SoundEffect>("OH");
            _RClickSound = _Content.Load<SoundEffect>("EH");
        }

        public void PlaySounds()
        {
            if (MouseManager._ClickedL)
            {
                _LClickSound.Play();
            }

            if (MouseManager._ClickedR)
            {
                _RClickSound.Play();
            }
        }

        public void Update(GameTime gameTime)
        {
            PlaySounds();
        }
    }
}
