using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.States
{
    class Flee : State
    {
        //THe function of the flee state is to cause the IMover to move away from a game Object

        //instance vairbales
        //the pariah is the GameObject that the IMover is attempting to flee from
        IGameObject _mPariah;

        //constructor tages the target Imover
        public Flee(IMover pTarget)
        {
            _mTarget = pTarget;
        }

        public override void Run()
        {
            //This calls the update data method, this should happen first
            UpdateData();

            if (_mTarget != null && _mPariah != null)
            {
                //calls the calculate flee method
                CalculateFlee();

                //Calss the Move method, this should happen last
                Move();
            }
        }

        //sets a new game object to be fled from
        public void NewTarget(IGameObject pPariah)
        {
            _mPariah = pPariah;
        }
        private void CalculateFlee()
        {
            //declare some vectors for the location of both objects

            Vector2 myPos = _mTarget.oPostion;

            Vector2 parPos = _mPariah.Position;

            //declare a vector for the directional vector

            Vector2 newTragectory = new Vector2((myPos.X - parPos.X), (myPos.Y - parPos.Y));

            //normalize that vector
            newTragectory.Normalize();

            //The force will be equal to the max speed multplied by the tragectory, hthis is then sent to apply force
            Vector2 tragForce = newTragectory * _tMaxSpeed;

            // apply the new force with the apply force method
            ApplyForce(tragForce);

        }
    }
}
