using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Managers
{
    //the purpose of the camera manager is to move objcets around the scene that are not static rto give the appearance of a camera 
    interface ICamearaManager : IManager
    {
        //this is used to garab all the entities in the game list that are likely to need to move
         void GrabGameList(List<IGameObject> pGameList);
    }
}
