using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Managers;
using Game1.GameCode.Behaviours;
using Game1.Framework.EntityCode.Sub_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.GameCode.Obstacles
{
    class Triangle : GameObject
    {

        public Triangle()
        {
            Type = "Obstacle";
        }

        public override void Update()
        {
            CalculateVertexes();
        }

        protected override void CalculateVertexes()
        {
            _Vertexes = new Vector2[3];

            _Vertexes[0] = this.Position;



            _Vertexes[1].X = this.Position.X + _Texture.Width;
            _Vertexes[1].Y = this.Position.Y + _Texture.Height;

            _Vertexes[2].X = this.Position.X;
            _Vertexes[2].Y = this.Position.Y + _Texture.Height;
        }

        #region Properties
        #endregion

    }
}
