using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.States
{
    //This state is isued when an object is being craried
    class Carried :State
    {
        //instacne variables
        //This creates a target that the object is carried by, call it _mTarget 
        private IGameObject _mTarget;

        public Carried()
        {
            //constructor code
        }

        //this method assings a new target for the IMover to move towards
        public override void NewTarget(IGameObject pTarget)
        {
            //makes sure the target is only carrying one object
            _mTarget = pTarget;

        }

        public override void Run(GameTime gametime)
        {
            //This calls the update data method, this should happen first
            UpdateData();
            if (_mMover != null && _mTarget != null)
            {
               
                UpdateData();
                Vector2 offset = new Vector2(0, (_mTarget.Texture.Height* _mTarget.Scale) - 10);

                _mMover.oPostion = (_mTarget.Position - offset);
            }

        }




    }
}
