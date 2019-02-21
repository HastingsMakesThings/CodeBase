using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Game1.Framework.Interfaces.Managers
{
    interface ISATCollision
    {
        Vector2 TestCollisionSignle(Vector2[] shapeA, Vector2[] shapeB);
    }
}
