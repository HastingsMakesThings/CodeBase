using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.Minds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Triggers
{
    class TBTreatmentRoom :Room
    {
        private string[] _myTriggers;

        public TBTreatmentRoom()
        {
            _MyMind = new RoomTriggerBoxMind();
            _MyMind.Initalize(this);

            _myTriggers = new string[1];
            _myTriggers[0] = "TBSuccess";


        }


        public override void Update(GameTime gameTime)
        {
            CalculateVertexes();
        }

        //this funciton is used to identify if any of the strings in the pTriggers is relevent to this Triger area
        public override string IsTrigger(string[] pTriggers)
        {
            //for each value in the _mytriggers string, the strign is coampred to the string passed in, if there is a match, that strgin is returned lettign the caller react in their own deffined way
            foreach (string tempStr in _myTriggers)
            {
                foreach (string tempTrig in pTriggers)
                {
                    if (tempStr == tempTrig)
                        return tempStr;
                }
            }
            //default is returned if no match
            return "null";
        }
    }
}
