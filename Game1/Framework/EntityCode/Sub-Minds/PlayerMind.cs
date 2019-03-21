using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind, IAIMind
    {
        // Target of the current mind prefix with '_'
        protected IMover _Target;

        public PlayerMind(IMover _pTarget)
        {
            _Target = _pTarget;
        }

        public void Run()
        {
            _Target.oPostion.X += 5;
        }
    }
}
