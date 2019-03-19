using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Behaviours
{
    class MoveHorizontal : IMoveBehaviour
    {
        IGameObject _mTarget;
        public MoveHorizontal(IGameObject pTarget)
        {
            _mTarget = pTarget;
        }
        public Vector2 Act()
        {
            Vector2 mForce = new Vector2(0, 0);

            mForce.X = _mTarget.HorDir * _mTarget.Speed;

            return mForce;
        }

        public void Run()
        {
            
        }
    }
}
