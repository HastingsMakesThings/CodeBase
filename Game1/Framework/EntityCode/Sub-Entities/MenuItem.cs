using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Animations;

namespace Game1.Framework.EntityCode.Sub_Entities
{
    class MenuItem : Entity, IMenuItem
    {


        //Holds a library of animations
        protected IDictionary<string, IAnimation> _mAnim;

        //declares if the objecft collides with other objects
        protected bool _mRigid;

        //declares which layer the sprite gets rendered to
        protected float _mRenderLayer;

        protected bool _mVisibility;

        //a value for the active animation string
        protected string _mAnimstr;

        //a value for the active animation
        protected IAnimation _mActiveAnim;

        protected Boolean _Static;

        public MenuItem()
        {

        }

        public void Initialise(IDictionary<string, IAnimation> pAnim, string pStartAnim, float pX, float pY, float pScale, bool pStatic, bool pRigid, int pID, float pRednLayer, bool pVisible)
        {
            //sets up ID
            _mID = pID;
            //sets up th animation
            _mAnim = pAnim;

            //sets the active animation stign to the provided string
            _mAnimstr = pStartAnim;

            //this grabs the animation from the animation list
            _mAnim.TryGetValue(_mAnimstr, out _mActiveAnim);

            //this starts the animation in motion
            _mActiveAnim.Start();

            //finds the animation frame that shoudl be played first
            _Texture = _mActiveAnim.aActiveTexture;
            _textureBounds = _mActiveAnim.aActiveFrame;

            _mRenderLayer = pRednLayer;

            _mVisibility = pVisible;

            _Position.X = pX /*- ((_Texture.Width / 2) * pScale)*/;
            _Position.Y = pY /*- ((_Texture.Height / 2) * pScale)*/;

            _Scale = pScale;

            _Static = pStatic;

            _mRigid = pRigid;

        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
