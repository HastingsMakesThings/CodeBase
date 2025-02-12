﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode;
using Game1.Framework.Animations;

namespace Game1.Framework.EntityCode.Sub_Entities
{
    abstract class GameObject : Entity, IGameObject
    {
        // DECLARE a Vector2 to hold velocity prefix with '_'
        protected Vector2 _Velocity = new Vector2(0, 0);
        // DECALTE int to hold speed prefix with '_'
        protected int _Speed = 5;
        // Horizontal Direction prefix with '_'
        protected int _HorDir;
        // Vertical Direction prefix with '_'
        protected int _VerDir;
        // Projected X angle prefix with '_'
        protected float _ProXAngle;
        // Projected Y angle prefix with '_'
        protected float _ProYAngle;
        // Rectangle for Projected X prefix with '_'
        protected Rectangle _ProjectedX;
        // Rectangle for Projected Y prefix with '_'
        protected Rectangle _ProjectedY;

        //a value for the active animation string
        protected string _mAnimstr;

        //a value for the active animation
        protected IAnimation _mActiveAnim;

        //Deffine an array to hold all of the vertex of the object
        protected Vector2[] _Vertexes;

        protected Boolean _Static;

        protected Boolean _CollideT;

        protected Boolean _CollideB;

        protected Boolean _CollideL;

        protected Boolean _CollideR;

        //Holds a library of animations
        protected IDictionary<string, IAnimation> _mAnim;

        //declares if the objecft collides with other objects
        protected bool _mRigid;

        //declares which layer the sprite gets rendered to
        protected float _mRenderLayer;

        protected bool _mVisibility;

        public GameObject()
        {

        }

        //This Declares a method that will calculate the location of the vertexes of each object dependant on their position
        protected virtual void CalculateVertexes()
        {

            _Vertexes = new Vector2[4];

            _Vertexes[0].X = this.Position.X;
            _Vertexes[0].Y = this.Position.Y + (_textureBounds.Height * (_Scale * 0.75f));
            //
            _Vertexes[1].X = this.Position.X + (_textureBounds.Width * _Scale);
            _Vertexes[1].Y = this.Position.Y + (_textureBounds.Height * (_Scale * 0.75f));

            _Vertexes[2].X = this.Position.X + (_textureBounds.Width * _Scale);
            _Vertexes[2].Y = this.Position.Y + (_textureBounds.Height * _Scale);

            _Vertexes[3].X = this.Position.X;
            _Vertexes[3].Y = this.Position.Y + (_textureBounds.Height * _Scale);


        }

        public void playSound(string soundClip)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public virtual void CollReact(Vector2 pMTV)
        {

        }

      

        public void Initialise(IDictionary<string, IAnimation> pAnim,string pStartAnim, float pX, float pY, float pScale, bool pStatic, bool pRigid, int pID, float pRednLayer, bool pVisible)
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

            _mRigid = pRigid;

            //Calls the calculate vertexes method
            CalculateVertexes();
        }

        //The purpose of this method is to move the game object in a realistic manner

        #region Properties

        public float ProXAngle
        {
            get { return _ProXAngle; }
        }

        public float ProYAngle
        {
            get { return _ProYAngle; }
        }

        public Rectangle ProjectedX
        {
            get { return _ProjectedX; }
        }

        public Rectangle ProjectedY
        {
            get { return _ProjectedY; }
        }

        public Boolean CollideT
        {
            set { _CollideT = value; }
        }

        public Boolean CollideB
        {
            set { _CollideB = value; }
        }

        public Boolean CollideL
        {
            set { _CollideL = value; }
        }

        public Boolean CollideR
        {
            set { _CollideR = value; }
        }

        public float XVelocity
        {
            get { return _Velocity.X; }
            set { _Velocity.X = value; }
        }

        public float YVelocity
        {
            get { return _Velocity.Y; }
            set { _Velocity.Y = value; }
        }

        public int Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }

        public int HorDir
        {
            get { return _HorDir; }
            set { _HorDir = value; }
        }

        public int VerDir
        {
            get { return _VerDir; }
            set { _VerDir = value; }
        }

        //This public accessor allows for obbjects to retrive the vertex list from an object
        public Vector2[] Verts
        {
            get { return _Vertexes; }
        }

        public bool Rigid
        {
            get { return _mRigid; }
        }

        public float lowestPoint
        {
            get
            {
               return Position.Y + (_textureBounds.Height * _Scale);
            }
        }

        public float RenderLayer
        {
            get
            {
                return _mRenderLayer;
            }
        }

        public bool Visible
        {
            get
            {
                return _mVisibility;
            }
        }

        public bool Static
        {
            get { return _Static; }
        }

        #endregion
    }
}
