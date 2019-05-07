using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.States
{
    //the funciton of this method is to follow the target like a shadow
    class Shadow : State
    {
        //instance variables
        //This creates a target that the object follows, call it _mTarget 
        private IGameObject _mTarget;

        public Shadow()
        {

        }

        //this method assings a new target for the IMover to move towards
        public override void NewTarget(IGameObject pTarget)
        {
            _mTarget = pTarget;

        }

        public override void Run(GameTime gametime)
        {
            //This calls the update data method, this should happen first
            UpdateData();
            if (_mMover != null && _mTarget != null)
            {
                //calls the calculate following behaviour method
                UpdateData();

                UpdateData();
                Vector2 offset = new Vector2(-((_mTarget.Bounds.Width * _mTarget.Scale )* 0.5f), ((_mTarget.Bounds.Height * _mTarget.Scale )* 0.5f));

                _mMover.oPostion = (_mTarget.Position + offset);
            }

        }


    }
}
