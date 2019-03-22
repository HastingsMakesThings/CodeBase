using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;


namespace Game1.Framework.Managers.Collision
{
    class Region : IRegion
    {

        // floats will hold the position, width and height of the region
        protected float _X, _Y;
        protected float _Width, _Height;

        public Region(float _pX, float _pY, float _pWidth, float _pHeight)
        {
            _X = _pX;
            _Y = _pY;
            _Width = _pWidth;
            _Height = _pHeight;
           // Console.WriteLine("Left: {0}, Right: {1}, Top: {2}, Bottom: {3}", _X,_X + _Width,_Y,_Y + _Height);
        }

        public Boolean CheckBounds(float _pX, float _pY)
        {
            if ((_pX >= _X && _pX <= _X + _Width) && (_pY >= _Y && _pY <= _Y + _Height))
            {
                return true;
            }
            else { return false; }
        }

        #region Properties

        public float RegionXPos
        {
            set { _X = value; }
            get { return _X; }
        }

        public float RegionYPos
        {
            set { _Y = value; }
            get { return _Y; }
        }

        public float RegionWidth
        {
            set { _Width = value; }
            get { return _Width; }
        }

        public float RegionHeight
        {
            set { _Height = value; }
            get { return _Height; }
        }
        #endregion
    }
}
