using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.Obstacles;

namespace Game1.Framework.Managers
{
    class CollisionManager : ICollisionManager
    {
        // DECLARE lists of type IGameObject, prefix them with '_'
        // _GameList holds everything within the level
        protected List<IGameObject> _GameList;
        // _WallList holds all walls within the level
        protected List<IGameObject> _WallList;
        // _EnemyList holds all Enemies within the level
        protected List<IGameObject> _EnemyList;
        // _InteractableList holds all projectiles and pickups in the level
        protected List<IGameObject> _InteractableList;
        // DECLARE a variable of type IGameObject to hold the player
        protected IGameObject _Player;

        public CollisionManager()
        {
            _WallList = new List<IGameObject>();
            _EnemyList = new List<IGameObject>();
            _InteractableList = new List<IGameObject>();
        }

        #region RangeChecking

        public Vector2 DistanceBetween(IGameObject first, IGameObject second)
        {
            int p1X = Convert.ToInt32(first.Bounds.Center.X);
            int p1Y = Convert.ToInt32(first.Bounds.Center.Y);

            int p2X = Convert.ToInt32(second.Bounds.Center.X);
            int p2Y = Convert.ToInt32(second.Bounds.Center.Y);

            Vector2 v1 = new Vector2(p1X, p1Y);
            Vector2 v2 = new Vector2(p2X, p2Y);

            float m1 = v1.X - v2.X;
            float m2 = v1.Y - v2.Y;

            float c1 = (float)Math.Abs(Math.Sqrt(m1 * m1));
            float c2 = (float)Math.Abs(Math.Sqrt(m2 * m2));

            Vector2 dV = new Vector2(c1,c2); ;

            return dV;
        }

        public int ProjectedXImpulse(IGameObject first, IGameObject second)
        {
            int _LRange = Convert.ToInt32(second.ProjectedX.Left - first.ProjectedX.Right);
            int _RRange = Convert.ToInt32(first.ProjectedX.Left - second.ProjectedX.Right);

            int _Distance;

            if (_LRange < -(second.ProjectedX.Width) * 0.5 && _RRange > -second.ProjectedX.Width && _RRange < 0)
            {
                _Distance = _RRange;

                return _Distance;
            }
            else if (_RRange < -second.ProjectedX.Width && _LRange > -second.ProjectedX.Width && _LRange < 0)
            {
                _Distance = _LRange * -1;

                return _Distance;
            }

            return 0;

        }

        public int ProjectedYImpulse(IGameObject first, IGameObject second)
        {
            int _TRange = Convert.ToInt32(first.ProjectedY.Bottom - second.ProjectedY.Top) * -1;
            int _BRange = Convert.ToInt32(second.ProjectedY.Bottom - first.ProjectedY.Top) * -1;

            int _Distance;

            if (_BRange < -(second.ProjectedY.Height) * 0.5 && _TRange > -second.ProjectedY.Height)
            {
                _Distance = _TRange * -1;
                return _Distance;
            }
            else if (_TRange < -second.ProjectedY.Height / 2 && _BRange > -second.ProjectedY.Height)
            {
                _Distance = _BRange;
                return _Distance;
            }

            return 0;

        }

        #endregion

        #region Collision

        public void Collision()
        {
            foreach (IGameObject first in _GameList)
            {
                foreach (IGameObject second in _GameList)
                {
                    if ((first != second && second.Type != "Obstacle") && (DistanceBetween(first,second).X < 128 && DistanceBetween(first, second).Y < 128))
                    {
                        
                        
                    }
                }
            }
        }

        #endregion

        public void CheckCollision()
        {
            Collision();
        }

        public void GrabGameList(List<IGameObject> pGameList)
        {
            _GameList = pGameList;
        }

        public void Update()
        {
            CheckCollision();
            
        }

        #region Properties
        #endregion
    }
}
