using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode;

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

        //Deffine an array to hold all of the vertex of the object
        protected Vector2[] _Vertexes;

        protected Boolean _Static;

        protected Boolean _CollideT;

        protected Boolean _CollideB;

        protected Boolean _CollideL;

        protected Boolean _CollideR;

        public GameObject()
        {

        }

        public void Initialise(float pX, float pY, Texture2D pTexture, float pScale, Boolean pStatic)
        {
            _Texture = pTexture;

            _Origin = new Vector2(0, _Texture.Height);

            _Position.X = pX /*- ((_Texture.Width / 2) * pScale)*/;
            _Position.Y = pY /*- ((_Texture.Height / 2) * pScale)*/;

            _Scale = pScale;

            _Static = pStatic;

            if (Type != "Obstacle")
            {
                Console.WriteLine("{0} Created!", _Texture);
                Console.WriteLine("X:{0}, Y:{1}", _Position.X, _Position.Y);
                Console.WriteLine("Scale:{0}, Static:{1}", _Scale, _Static);
            }

            // Run this once so objects get their starting axies projected
            // if an object is static then there is no need to run this more than once
            // if an object is not static then run the methods below in that objects update method
            CalculateProjectedX();
            CalculateProjectedY();

            //Calls the calculate vertexes method
            CalculateVertexes();
        }

        public void CalculateProjectedX()
        {
            Vector2 start = new Vector2();
            Vector2 end = new Vector2();

            start.X = Position.X;
            start.Y = 4;

            end.X = Position.X + Texture.Width;
            end.Y = 4;

            Vector2 edge = end - start;

            _ProXAngle = (float)Math.Atan2(edge.Y, edge.X);

            _ProjectedX = new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), 1);
        }

        public void CalculateProjectedY()
        {
            Vector2 start = new Vector2();
            Vector2 end = new Vector2();

            start.X = 4;
            start.Y = Position.Y;

            end.X = 4;
            end.Y = Position.Y - Texture.Height;

            Vector2 edge = end - start;

            _ProYAngle = (float)Math.Atan2(edge.X, edge.Y);

            _ProjectedY = new Rectangle((int)start.X, (int)start.Y, 1, (int)edge.Length());
        }

        //This Declares a method that will calculate the location of the vertexes of each object dependant on their position 
        protected virtual void CalculateVertexes()
        {
            _Vertexes = new Vector2[4];

            _Vertexes[0] = this.Position;

            _Vertexes[1].X = this.Position.X + _Texture.Width;
            _Vertexes[1].Y = this.Position.Y;

            _Vertexes[2].X = this.Position.X + _Texture.Width;
            _Vertexes[2].Y = this.Position.Y + _Texture.Height;

            _Vertexes[3].X = this.Position.X;
            _Vertexes[3].Y = this.Position.Y + _Texture.Height;

        }

        public override void Update()
        {
            
        }

        public virtual void CollReact(Vector2 pMTV)
        {

        }
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


        #endregion
    }
}
