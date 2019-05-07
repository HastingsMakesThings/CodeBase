using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Managers;
using Game1.GameCode.States;
using Game1.Framework.EntityCode.Sub_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.EntityCode.Sub_Minds;
using Game1.GameCode.Minds;

namespace Game1.GameCode.PlayerCode
{
    class Player : Mover, ICameraTarget, ICarrier
    {
        //instance variables
        private bool _isColliding;
        //variable for preventign tracking
        private bool _stopTrack;

        private bool Carry;
        public Player()
        {
            // Initialise Type
            Type = "Player";
            // Initialise Mind
            _MyMind = new HastingsMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<TextureEdit>("Tex", this);
            _MyMind.AddState<PlayerTexEdit>("PlayTex", this);


            _currAnim = "Idle";
            _mMass = 20;
            _maxSpeed = 10;
            _mFriction = -6;

            _isColliding = false;
            _stopTrack = false;

            Carry = false;

        }

        public override void Update(GameTime gameTime)
        {

            TextureChange();
            _mActiveAnim.Play(gameTime);
            _Texture = _mActiveAnim.aActiveTexture;
            _textureBounds = _mActiveAnim.aActiveFrame;
            CalculateVertexes();
        }

        //the funciton of this method is to change texttures based on the movment of this object
        private void TextureChange()
        {
            //if the animationstring is not the same as the current animation then the animation is changed to the new value
            if (_mAnimstr != _currAnim)
            {
                _mAnim.TryGetValue(_currAnim, out _mActiveAnim);
                _mActiveAnim.Start();

                _mAnimstr = _currAnim;
            }

        }

        public override void CollReact(Vector2 pMTV)
        {
            this.Position = Position + pMTV;

            _isColliding = true;
        }

        //this property is used  to identfiy if the camera manager needs to stop trackign for any reason
        public bool StopTrack
        {
            get { return _stopTrack; }
            set { _stopTrack = value; }
        }

        //this protertty is used by the camera manager to manage the camera position
        public Vector2 TargetPosition
        {
            get { return _Position; }
            set { _Position = value; }
        }

        //this property lets the camerra  know if the target is collidign
        public bool IsColliding
        {
            get { return _isColliding; }
            set { _isColliding = value; }
        }

        public bool isCarrying
        {
            get { return Carry; }
            set { Carry = value; }
        }
    }
}