using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    interface IGameObject : IEntity
    {
        Boolean CollideT { set; }

        Boolean CollideB { set; }

        Boolean CollideL { set; }

        Boolean CollideR { set; }

        float XVelocity { get; set; }

        float YVelocity { get; set; }

        int Speed { get; set; }

        int HorDir { get; set; }

        int VerDir { get; set; }

        void Initialise(float pX, float pY, Texture2D pTexture, float pScale, Boolean pStatic);

        void playSound(string soundClip);

        float ProXAngle { get; }

        float ProYAngle { get; }

        Rectangle ProjectedX { get; }

        Rectangle ProjectedY { get; }

        Vector2[] Verts { get; }

        void CollReact(Vector2 pMTV);

    }
}
