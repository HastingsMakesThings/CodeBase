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


namespace Game1.GameCode.PlayerCode
{
    class Player : Mover
    {
      
        public Player()
        {
            // Initialise Type
            Type = "Player";
            // Initialise Mind
            _MyMind = new PlayerMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<TextureEdit>("Tex", this);
            _MyMind.AddState<_2DMove>("Mover",this);

            _currAnim = "Idle";
            _mMass = 20;
            _maxSpeed = 10;
            _mFriction = -6;

        }

        public override void Update(GameTime gameTime)
        {
            CalculateProjectedX();
            CalculateProjectedY();

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
           if(_mAnimstr != _currAnim)
            {
                _mAnim.TryGetValue(_currAnim, out _mActiveAnim);
                _mActiveAnim.Start();

                _mAnimstr = _currAnim;
            }

        }

        public override void CollReact(Vector2 pMTV)
        {
            this.Position = Position + pMTV;
        }

       
    }
}
