using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Scenes
{
    //the purpose of IScene is to provide an interface for sceenes that load in game content
    interface IScene
    {
        void setup(ContentManager pContent, IEntityFactory pEntityFac);

        List<IGameObject> GameList { get; }
    }
}
