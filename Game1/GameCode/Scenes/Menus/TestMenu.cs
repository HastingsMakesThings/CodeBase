using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1.Framework.Interfaces;
using Game1.Framework.Factories;
using Game1.Framework.EntityCode;
using Game1.GameCode.UI;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Animations;

namespace Game1.GameCode.Scenes.Menus
{
    class TestMenu
    {

        protected List<IMenuItem> _MenuList;

        protected List<ITextElement> _TextList;

        //animation factory for creating animations in the scene
        private IAnimationFactory _mAnimFac;

        public TestMenu()
        {
            _MenuList = new List<IMenuItem>();

            _TextList = new List<ITextElement>();

            _mAnimFac = new AnimationFactory();
        }

        public void setup(ContentManager pContent, IEntityFactory pEntityFac)
        {
            //initalise animation factory
            _mAnimFac.Initialize(pContent);

            IDictionary<string, IAnimation> ClipboardAnim = new Dictionary<string, IAnimation>();
            ClipboardAnim.Add("Idle", _mAnimFac.CreatAnimation("Clipboard_sprite", 100, false, 1));

            // Create the clipboard
            IMenuItem PatientClipboard = pEntityFac.CreateMenuItem<Clipboard>(1080, 100, ClipboardAnim, "Idle", 1f, false, true, 0.01f, true);
            _MenuList.Add(PatientClipboard);
            // Cast Clipboard as type Clipboard
            Clipboard tempBoard = (Clipboard)PatientClipboard;
            // Clipboard patient name text
            _TextList.Add(pEntityFac.CreateTextElement<Text>(PatientClipboard, "" + tempBoard.getName, 285, 175));
            // Clipboard patient age text
            _TextList.Add(pEntityFac.CreateTextElement<Text>(PatientClipboard, "", 285, 275));
            // Clipboard patient Gender text
            _TextList.Add(pEntityFac.CreateTextElement<Text>(PatientClipboard, "Male", 285, 375));

        }

        public List<IMenuItem> MenuList
        {
            get { return _MenuList; }
        }

        public List<ITextElement> TextList
        {
            get { return _TextList; }
        }
    }
}
