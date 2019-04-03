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

namespace Game1.Framework.EntityCode.Sub_Entities
{
    class MenuItem : Entity, IMenuItem
    {
        protected string _Path;

        public MenuItem()
        {

        }

        public void Initialise(float pX, float pY, Texture2D pTexture, float pScale, string pPath)
        {

            _Texture = pTexture;

            _Origin = new Vector2(0, _Texture.Height);

            _Position.X = pX ;
            _Position.Y = pY ;

            _Scale = pScale;

            _Path = pPath;

            Console.WriteLine("{0} Created!", _Texture);
            Console.WriteLine("X:{0}, Y:{1}", _Position.X, _Position.Y);
            Console.WriteLine("Scale:{0}, Path:{1}", _Scale, _Path);
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
