using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.Behaviours
{
    class HorizontalMovement : IBehaviour
    {
        protected IGameObject _Target;

        public HorizontalMovement(IGameObject pEntity)
        {
            _Target = pEntity;
        }

        public void Run()
        {
            _Target.XVelocity = _Target.Speed * _Target.HorDir;
            _Target.XPosition += _Target.XVelocity;
        }
    }
}
