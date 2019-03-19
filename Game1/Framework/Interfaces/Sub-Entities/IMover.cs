using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    //This interface is unqiue to all objects that have moment behaviours
    interface IMover
    {
        void Move();

        void ApplyForce(Vector2 pForce);
    }
}
