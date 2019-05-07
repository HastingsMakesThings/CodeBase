using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces
{
    interface IRegion
    {

        Boolean CheckBounds(float x, float y);

        float RegionXPos { set; get; }

        float RegionYPos { set; get; }

        float RegionWidth { set; get; }

        float RegionHeight { set; get; }

    }
}
