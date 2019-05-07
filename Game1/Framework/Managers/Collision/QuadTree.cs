using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Managers.Collision;

namespace Game1.Framework.Managers.Collision
{
    class QuadTree : IQuadTree
    {
       // protected List<IRegion> _RegList;

        public QuadTree()
        {
           // _RegList = new List<IRegion>();
        }

        public List<IRegion> GenerateQuadrants(float xPos, float yPos, float width, float height)
        {
            List<IRegion> _RegList = new List<IRegion>();

            float hWidth = width * 0.5f;
            float hHeight = height * 0.5f;

            for (int i = 0; i < 2; i++)
            {
                for (int ii = 0; ii < 2; ii++)
                {
                    float X = xPos + (hWidth * ii);
                    float Y = yPos + (hHeight * i);

                    IRegion tempReg = new Region(X, Y, hWidth, hHeight);

                    _RegList.Add(tempReg);
                }
            }

            return _RegList;
        }

    }
}
