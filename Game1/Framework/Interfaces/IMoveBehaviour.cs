using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Game1.Framework.Interfaces
{
    interface IMoveBehaviour : IState
    {
        Vector2 Act();
    }
}
