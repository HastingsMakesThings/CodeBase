using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.GameCode.Minds;
using Game1.GameCode.States;

namespace Game1.GameCode.NPCs
{
    class Patient : PickupAble
    {
        // Variable to store basic info on patient
        protected string _Name;
        protected string _Gender;
        protected int _Age;
        // Variable to store the illness of patient
        protected string _Illness;
        // Variable to store the wellness raiting of the patient
        protected int _WellnessRating;

        public Patient()
        {
            // Initialise Patient
            Initialise();
            
            _MyMind = new PatientMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<Carried>("Carried", this);
            _MyMind.AddState<InActive>("InActive", this);

            // Add to list of triggers to be listend for
            _mTriggers = new string[3];
            _mTriggers[0] = "PlayerTrigger";
            _mTriggers[1] = "TreatmentSuccess";
            _mTriggers[2] = "TreatmentFailure";

            _Name = "Gerald";
            _Gender = "Male";
            _Age = 37;
            _Illness = "Gout";

        }

        public override void ActiveTrigger(string pEvent)
        {
            
            if (pEvent == "PlayerTrigger")
            {
                _MyMind.SetCondition("ByPlayer");
                Console.WriteLine("TriggerObject activated");
            }

            if (pEvent == "TreatmentSuccess")
            {
                Console.WriteLine("Success");
                _MyMind.SetCondition(pEvent);
            }

            if (pEvent == "TreatmentFailure")
            {
                Console.WriteLine("Failure");
                _MyMind.SetCondition(pEvent);
            }

        }


        #region Properties

        public string PatientName
        {
            get{ return _Name; }
        }

        public int PatientAge
        {
            get { return _Age; }
            
        }

        public string PatientGender
        {
            get { return _Gender;}
        }

        public string PatientIllness
        {
            get { return _Illness; }
        }

        public int PatientWellness
        {
            get { return _WellnessRating; }
        }

        #endregion

    }

}