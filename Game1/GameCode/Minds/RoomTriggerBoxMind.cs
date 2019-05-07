using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Minds
{
    class RoomTriggerBoxMind : AIMind
    {

        public RoomTriggerBoxMind()
        {
            _event = "";
        }

        public override string CreateEvent()
        {
            return _event;
        }

    }
}
