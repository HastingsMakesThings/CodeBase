using Game1.Framework.EntityCode.Sub_Minds;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.NPCs;
using Game1.GameCode.PlayerCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameCode.Minds
{
    class HastingsMind : PlayerMind
    {
        public override void EventData(string pEvent, IGameObject pTrigger)
        {

            //this should chaneg the texture sets of the player when an object is beign carried
            if (pEvent == "PickedUp")
            {
                if (pTrigger is Patient)
                {
                    Patient tempPatient = (Patient)pTrigger;
                    PatientInformation._Name = tempPatient.PatientName;
                    PatientInformation._Age = "" + tempPatient.PatientAge;
                    PatientInformation._Gender = tempPatient.PatientGender;
                }

                // Change player texture to the raised arms
                _CurrentSet = "PlayTex";
            }

            if (pEvent == "Dropped")
            {
                PatientInformation._Name = "";
                PatientInformation._Name = "";
                PatientInformation._Age = "";
                PatientInformation._Gender = "";
                // Change player texture to lowered arms
                _CurrentSet = "Tex";
            }
            base.EventData(pEvent, pTrigger);
        }
    }
}
