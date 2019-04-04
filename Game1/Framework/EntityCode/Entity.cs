using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces;


namespace Game1.Framework.EntityCode
{

    abstract class Entity : IEntity
    {
        //DECLARE a protected Vector2 that will hold the location of the Entity, call it '_Position
        protected Vector2 _Position;
        //DECLARE a protected  float for the scale of the object, call it '_Scale'
        protected float _Scale;
        // DECLARE a protected float and call it '_Angle'
        protected float _Angle;
        // DECLARE a protected Vector2 and call it '_Origin'
        protected Vector2 _Origin;
        //DECLARE a protected Texture2D that will act as the visual asset of the Entity, call it '_mTexture'
        protected Texture2D _Texture;
        // DECLARE a protected String and call it '_Type'
        protected string _Type;

        protected Vector2 _textureBounds;

        public abstract void Update(GameTime gameTime);

        protected Texture2D[] _textures;
        #region Properties

        public Rectangle Bounds
        {
            get { return new Rectangle(Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y), (int)_textureBounds.X, (int)_textureBounds.Y); }
           
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public Vector2 Origin
        {
            get { return _Origin; }
        }

        public float Angle
        {
            get { return _Angle; }
            set { _Angle = value; }
        }

        public Vector2 Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public float XPosition
        {
            get { return _Position.X; }
            set { _Position.X = value; }
        }

        public float YPosition
        {
            get { return _Position.Y; }
            set { _Position.Y = value; }
        }

        public float Scale
        {
            get { return _Scale; }
            set { _Scale = value; }
        }

        public Texture2D Texture
        {
            get { return _Texture; }
        }

        #endregion
    }
}
