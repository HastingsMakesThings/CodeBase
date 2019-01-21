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

namespace Game1.GameCode.Scenes.Menus
{
    class TestMenu
    {

        protected List<IMenuItem> _MenuList;

        public TestMenu()
        {
            _MenuList = new List<IMenuItem>();
        }

        public void setup(ContentManager pContent, IEntityFactory pEntityFac)
        {
            _MenuList.Add(pEntityFac.CreateMenuItem<Cursor>(100,100,"Cursor",1,"None"));
        }

        public List<IMenuItem> MenuList
        {
            get { return _MenuList; }
        }
    }
}
