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

namespace Game1.Framework.EntityCode.Sub_Entities
{
    class TextElement : Entity, ITextElement
    {
        // Variable to store the parent object used to help with posisitoning
        protected IMenuItem _Parent;
        // Variable to store value text element will read from
        protected string _Value;
        // Variablies tostore text element offset
        protected int _OffsetX, _OffsetY;

        public TextElement()
        {
        }

        public void Initialise(IMenuItem pParent, string pValue, int pOffX, int pOffY)
        {
            // Initialise variables
            _Parent = pParent;
            _Value = pValue;
            _OffsetX = pOffX;
            _OffsetY = pOffY;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public virtual string AdaptiveValue()
        {
            return _Value;
        }

        #region Properties

        public string getValue
        {
            get { return AdaptiveValue(); }
        }

        public IMenuItem getParent
        {
            get { return _Parent; }
        }

        public int getXOffest
        {
            get { return _OffsetX; }
        }

        public int getYOffest
        {
            get { return _OffsetY; }
        }

        #endregion

    }
}
