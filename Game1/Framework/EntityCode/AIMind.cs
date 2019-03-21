using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.EntityCode
{
    abstract class AIMind : IAIMind
    {

        private IGameObject pTarget;
        protected Dictionary<string, IState> States;

        public void Run()
        {

        }
    }
}
