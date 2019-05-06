using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Framework.Managers.Collision;
using Game1.Framework.Interfaces;
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

        protected IQuadTree _QuadTree;
        protected ISATCollision _CollisionCheck;

        public CollisionManager()
        {
            _WallList = new List<IGameObject>();
            _EnemyList = new List<IGameObject>();
            _InteractableList = new List<IGameObject>();
            _QuadTree = new QuadTree();
            _CollisionCheck = new SATCollision();

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

        public void Collision(List<IGameObject> pGList)
        {

            foreach (IGameObject first in pGList)
            {
                foreach (IGameObject second in pGList)
                {
                    if (first != second)
                    {
                        Vector2 mMTV1 = _CollisionCheck.TestCollisionSignle(first.Verts, second.Verts);

                        if (mMTV1 == Vector2.Zero)
                        {
                            // Console.WriteLine("No Collision");
                        }
                        else
                        {
                            Vector2 mMTV2 = _CollisionCheck.TestCollisionSignle(second.Verts, first.Verts);

                            if (mMTV2 == Vector2.Zero)
                            {
                                // Console.WriteLine("No Collision");
                            }
                            else
                            {
                                if (Math.Abs(mMTV1.Length()) >= Math.Abs(mMTV2.Length()))
                                {
                                    //checks if the object can be passed through
                                    if(second.Rigid)
                                    first.CollReact(mMTV1);
                                   
                                }
                                else
                                {   //checks if the object can be passed through
                                    if (second.Rigid)
                                        first.CollReact(mMTV2);
                                }
                            }
                        }

                    }
                }
            }

        }




        #endregion

        public void CheckCollision()
        {
            // create list of regions for teir1 broad phase
            List<IRegion> _RegListTier1 = new List<IRegion>();
            // generate regions for tier 1 of broad phase using screen width,height and origin
            _RegListTier1 = _QuadTree.GenerateQuadrants(0, 0, 1600,900);
            // create list of gameObjects
            List<IGameObject> _FinalObjList = new List<IGameObject>();

            for (int ter1 = 0; ter1 < _RegListTier1.Count; ter1++)
            {
                
                IRegion R = _RegListTier1[ter1];
                // create list to hold game objects
                List<IGameObject> _RegObjListTier1 = new List<IGameObject>();

                foreach(IGameObject G in _GameList)
                {
                    foreach(Vector2 vert in G.Verts)
                    {
                        // check if current entity has a vertex is within bounds
                        if (R.CheckBounds(vert.X, vert.Y))
                        {
                            // if it is add it to the list
                            _RegObjListTier1.Add(G);

                            break;
                        }
                    }
                    
                }
                // check to see if the object list for teir 1 is empty
                if (_RegObjListTier1.Count > 1)
                {
                    // if not repeat the proccess
                    List<IRegion> _RegListTier2 = new List<IRegion>();
                    // use current regions values to generate the quadrants
                    _RegListTier2 = _QuadTree.GenerateQuadrants(R.RegionXPos, R.RegionYPos, R.RegionWidth, R.RegionHeight);

                    foreach (IRegion r in _RegListTier2)
                    {
                        List<IGameObject> _RegObjListTier2 = new List<IGameObject>();

                        foreach (IGameObject g in _RegObjListTier1)
                        {
                            foreach(Vector2 vert in g.Verts)
                            {
                                // check if current entity is within bounds
                                if (r.CheckBounds(vert.X, vert.Y))
                                {
                                    // if it is add it to the list
                                    _RegObjListTier2.Add(g);

                                    break;
                                }
                            }
                           
                        }

                        if (_RegObjListTier2.Count > 1)
                        {
                            _FinalObjList = _RegObjListTier2;

                            Collision(_FinalObjList);
                        }
                    }
                }
            }

           
        }

        public void GrabGameList(List<IGameObject> pGameList)
        {
            _GameList = pGameList;
        }

        public void Update(GameTime gameTime)
        {
            CheckCollision();
           // Collision(_GameList);
        }

        #region Properties
        #endregion
    }
}
