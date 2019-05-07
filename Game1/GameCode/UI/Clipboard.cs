using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces;
using Game1.Framework.Managers;
using Game1.GameCode.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.GameCode.PlayerCode;

namespace Game1.GameCode.UI
{
    class Clipboard : MenuItem
    {
        public string testName;


        public override void Update(GameTime gameTime)
        {
            testName = PatientInformation._Name;
        }

        #region Properties

        public string getName
        {
            get { return testName; }
        }

        #endregion

    }
}
