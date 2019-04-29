using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Interfaces.Managers
{
    //the purpose of the game manager is to manage factors relevent to the game such as scores
    interface IGameManager : IManager
    {
        //this property shows the current score in the game
        float CurrentScore { get; }

        //this method initalizes the game manager
        void Initialize(List<IGameObject> pGameList);

        //this method is used to start up the game,
        void StartUp();
    }
}
