using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces
{
    interface IQuadTree
    {
        List<IRegion> GenerateQuadrants(float xPos, float yPos, float width, float height);

    }
}
