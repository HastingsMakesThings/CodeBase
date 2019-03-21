﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.EntityCode.Sub_Entities;


namespace Game1.Framework.Managers
{
    class AIManager : IAIManager
    {
        // List to hold all minds prefix with '_'
        protected List<IAIMind> _MindList;

        public AIManager()
        {
            _MindList = new List<IAIMind>();
        }

        public void GrabAllMovers(List<IGameObject> _EntList)
        {

            foreach (IGameObject current in _EntList) if (current is IMover)
            {
                    IMover tempMover = (IMover)current;
                    _MindList.Add(tempMover.getMind);
                    Console.WriteLine("Current Mind Count:{0} ", _MindList.Count);
            }
        }

        public void Update()
        {
            foreach (IAIMind m in _MindList)
            {
                m.Run();
            }
        }

    }
}
