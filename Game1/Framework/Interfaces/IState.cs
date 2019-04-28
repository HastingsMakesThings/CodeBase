using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Interfaces
{
    interface IState
    {
        void Run(GameTime gametime);

        void NewTarget(IGameObject pTarget);

        void Initalize(IMover pMover);
    }
}
