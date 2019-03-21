﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Interfaces.Managers
{
    interface IAIManager : IManager
    {

        void GrabAllMovers(List<IGameObject> _EntList);

         void TriggerEvent(string pEvent, IGameObject pTrigger);
    }
}
