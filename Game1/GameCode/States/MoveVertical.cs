using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.States
{
    class MoveVertical : State
    {
        IGameObject _mTarget;
        public MoveVertical(IGameObject pTarget)
        {
            _mTarget = pTarget;
        }
        public Vector2 Act()
        {
            Vector2 mForce = new Vector2(0, 0);

            mForce.Y = _mTarget.VerDir * _mTarget.Speed;

            return mForce;
        }

        public void Run()
        {

        }
    }
}
