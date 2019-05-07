using Game1.Framework.EntityCode.Sub_Entities;
using Game1.GameCode.PlayerCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.UI
{
    class TextAge : TextElement
    {
        public override string AdaptiveValue()
        {
            return PatientInformation._Age;
        }

    }
}
