using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.Behaviours
{
    class VerticalMovement : IBehaviour
    {
        protected IGameObject _Target;

        public VerticalMovement(IGameObject pEntity)
        {
            _Target = pEntity;
        }

        public void Run()
        {
            _Target.YVelocity = _Target.Speed * _Target.VerDir;
            _Target.YPosition += _Target.YVelocity;
        }
    }
}

