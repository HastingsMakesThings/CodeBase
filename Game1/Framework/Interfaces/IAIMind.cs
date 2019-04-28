using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces.Managers;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Interfaces
{
    //This provides an interface for AI Minds which will hold all the behaviours that an entiy has
    interface IAIMind
    {
        //This run method is used to activate the run method
        void Run(GameTime gametime);

        //this method is used to gain any vital information from the AIManager
        void EventData(string pEvent, IGameObject pTrigger);

        //this lets the AiMind create an event for the manager to acces and publicise 
        String CreateEvent();

        //this allows the Mind to return the game object its attached to in order to allow it t be publicised
        IGameObject EventTrigger();

        //This allows states to be added
        void AddState<T>(String pKey, IMover pMover) where T : IState, new();

        void Initalize(IMover _pTarget);
    }
}
