﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Microsoft.Xna.Framework;

namespace Game1.Framework.EntityCode.Sub_Minds
{
    class EnemyMind : AIMind
    {
        public override string CreateEvent()
        {
            return "no";
        }

        public override void Run(GameTime gametime)
        {

        }

    }
}
