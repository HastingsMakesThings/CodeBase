using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Animation
{
    abstract class Animation : IAnimation
    {
        //The purpose of The Animation class is to cycle through the frames of a texture that is deffined by the less generic implementations
        #region //Instance variables
        //the texture being used as a sprite sheet
        protected Texture2D _mTexture;
        //The texture of the frame being displayed
        protected Texture2D _mTextureFrm;
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
        #endregion

        #region //Properties

        //Returns the current frame of the animation
        public Texture2D aActiveTexture
        {
            get
            {
                throw new NotImplementedException();
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

        public int aFrameHeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int aFrameWidth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool aIsLooping
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        public void Initalize(Texture2D pTexture, float pFrmSpeed, bool pLoop)
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
