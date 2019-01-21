using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Interfaces.Managers
{
    interface IEntityManager : IManager
    {

        void LoadLevel(string pLevel);

        List<IGameObject> GameObjectList { get; }

    }
}
