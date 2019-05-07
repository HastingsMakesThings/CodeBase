using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Animations;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    //the funciton of this interface is to deffine objects that can carry other objects
    interface ICarrier
    {
        bool isCarrying { get; set; }
      
    }
}
