using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Animations;

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

        void Initialise(IDictionary<string, IAnimation> pAnim ,string pStartAnim, float pX, float pY, float pScale, bool pStatic, bool pRigid, int ID, float pRednLayer, bool pVisibility);
    
        void playSound(string soundClip);

        float ProXAngle { get; }

        float ProYAngle { get; }

        Rectangle ProjectedX { get; }

        Rectangle ProjectedY { get; }

        Vector2[] Verts { get; }

        void CollReact(Vector2 pMTV);

        bool Rigid { get; }

        float lowestPoint { get; }

        float RenderLayer { get; }

        bool Visible { get; }


    }
}
