using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.States;
namespace Game1.Framework.EntityCode.Sub_Minds
{
    class PlayerMind : AIMind
    {
        // Target of the current mind prefix with '_'
        protected IMover _Target;

        protected IState _mflee;
        public PlayerMind(IMover _pTarget)
        {
            _Target = _pTarget;

            _mflee = new Flee(_Target);
        }

        public void Run()
        {
            _mflee.Run();
        }
    }
}
