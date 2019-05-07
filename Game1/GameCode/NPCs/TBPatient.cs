﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.GameCode.Minds;
using Game1.GameCode.States;

namespace Game1.GameCode.NPCs
{
    class TBPatient : Patient
    {
        bool hasSetup;

        public TBPatient()
        {
            // Initialise Patient
            Initialise();
            
            _MyMind = new PatientMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<Carried>("Carried", this);
            _MyMind.AddState<InActive>("InActive", this);
            _MyMind.AddState<Spawning>("Spawning", this);

            // Add to list of triggers to be listend for
            _mTriggers = new string[3];
            _mTriggers[0] = "PlayerTrigger";
            _mTriggers[1] = "TBSuccess";
            _mTriggers[2] = "TBFailure";

            _Name = "Woozie Suizie";
            _Gender = "Female";
            _Age = 37;
            _Illness = "Terburculosis";

        }
        private void Setup()
        {

        }

        public override void ActiveTrigger(string pEvent)
        {
            
            if (pEvent == "PlayerTrigger")
            {
                _MyMind.SetCondition("ByPlayer");
                
            }

            if (pEvent == "TBSuccess")
            {
                _MyMind.SetCondition("TreatmentSuccess");
            }

            if (pEvent == "TBFailure")
            {
               
                _MyMind.SetCondition("TreatmentFailure");
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