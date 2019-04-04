using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Interfaces
{
    interface IEntity
    {
        void Update(GameTime gameTime);

        Vector2 Origin { get; }

        Vector2 Position { get; set; }

        string Type { get; set; }

        float Angle { get; set; }

        float XPosition { get; set; }

        float YPosition { get; set; }

        float Scale { get; set; }

        Texture2D Texture { get; }

        Rectangle Bounds { get; }



    }
}
