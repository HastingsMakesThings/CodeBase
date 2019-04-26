using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Animations
{
     class Animation : IAnimation
    {
        //The purpose of The Animation class is to cycle through the frames of a texture that is deffined by the less generic implementations
        #region //Instance variables
        //the texture being used as a sprite sheet
        protected Texture2D _mTexture;
        //The texture of the frame being displayed
        protected Rectangle _mActiveFrm;
        //How many frames are in  the animation
        protected int _mFrmCount;
        //The speed the animation plays
        protected float _mFrmSpeed;
        //The width and height of the frame 
        protected int _mFrmWidth;
        protected int _mFrmHeight;
        //The number of the current frame
        protected int _mCurrentFrm;
        //if the texture looping or not
        protected bool _mLooping;
        //a timer varibale for the animation loop
        protected float _mTimer;
        #endregion

        #region //Properties

        //Returns the current frame of the animation
        public Texture2D aActiveTexture
        {
            get
            {
                return _mTexture;
            }
        }

        //this returns a rectamgle that will hold the texture frame
        public Rectangle aActiveFrame
        {
             get
            {
                return _mActiveFrm;
            }
        }

        //returns the value for the currrent frame and allows it to be set
        public int aCurrentFrame
        {
            get
            {
                return _mCurrentFrm;
            }

            set
            {
                _mCurrentFrm = value;
            }
        }

        //returns the frame count
        public int aFrameCount
        {
            get
            {
               return _mFrmCount;
            }
        }

        //gets the frame speed of the animation
        public float aFrameSpeed
        {
            get
            {
                return _mFrmSpeed;
            }
        }

        //returns the height of the animation
        public int aFrameHeight
        {
            get
            {
                return _mFrmHeight;
            }
        }

        //returns the width of the animation
        public int aFrameWidth
        {
            get
            {
                return _mFrmWidth;
            }
        }

        //returns if the animation 
        public bool aIsLooping
        {
            get
            {
                return _mLooping;
            }
        }
        #endregion

        //This Initalizes the animation
        public void Initalize(Texture2D pTexture, float pFrmSpeed, bool pLoop, int pCount)
        {
            //sets the instance variables to the values of the parameters
            _mTexture = pTexture;
            _mFrmSpeed = pFrmSpeed;
            _mLooping = pLoop;
            _mFrmCount = pCount;

            //sets up t6exture height and width
            _mFrmHeight = _mTexture.Height;
            _mFrmWidth = (_mTexture.Width / _mFrmCount);

            //initalise instance variables
            _mCurrentFrm = 0;

            _mTimer = 0;

            SetFrame();
        }

        public void Play(GameTime gameTime)
        {
            //As timer increases the timer is checked a gains tthe framespedd, if the timer matches or exceeds the framespeed the frame is changed
            _mTimer += gameTime.ElapsedGameTime.Milliseconds;

            if(_mTimer >= _mFrmSpeed)
            {
                _mCurrentFrm++;

                SetFrame();

                _mTimer = 0;
            }

        }

        public void Start()
        {
            _mCurrentFrm = 0;
            _mTimer = 0;

            SetFrame();
        }

        private void SetFrame()
        {
            //this just catches if the selected frame is not on the spritesheet
            if (_mCurrentFrm >= _mFrmCount)
                _mCurrentFrm = 0;
            //creates a new rectangle that sets the bound sof the active frame
            Rectangle tempTangle = new Rectangle((_mFrmWidth * _mCurrentFrm), 0, _mFrmWidth, _mFrmHeight);

            _mActiveFrm = tempTangle;
        }
    }
}
