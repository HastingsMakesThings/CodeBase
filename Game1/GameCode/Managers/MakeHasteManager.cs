using Game1.Framework.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Managers
{
    //The funciton of the MakeHasetManager is a manager for the game that manages specific game content such as the beer levels, happiness/score and unqiue features
    class MakeHasteManager : IGameManager
    {
        //instance variables
        //a variable for the player token
        private IGameObject _mPLayer;
           
        
        public float CurrentScore
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Initialize(List<IGameObject> pGameList)
        {
            throw new NotImplementedException();
        }

        public void StartUp()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
