using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    interface ITextElement : IEntity
    {
        void Initialise(IMenuItem pParent, string pValue, int pOffX, int pOffY);

        string getValue { get; }

        IMenuItem getParent { get; }

        int getXOffest { get; }

        int getYOffest { get; }
    }
}
