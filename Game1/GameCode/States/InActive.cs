using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.States
{
    //this method is a devault state that translates to no movment
    class InActive : State
    {
        //insnstance variables

        public InActive()
        {
            //constructor code
        }
        public override void NewTarget(IGameObject pTarget)
        {
            UpdateData();

            Vector2 offset = new Vector2(0, (pTarget.Bounds.Height * pTarget.Scale));
            _mMover.oPostion = pTarget.Position + offset;
         
        }
    }
}
