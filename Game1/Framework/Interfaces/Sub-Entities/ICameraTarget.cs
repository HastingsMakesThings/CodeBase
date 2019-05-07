using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Animations;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    //the funciton of this interface is to deffine the values of a target for the ICameraManager
    interface ICameraTarget 
    {
       //Boolean to say when to let the camera manager know when to move objects
       bool StopTrack { get; set; }

       //this variableois used to reset the camera iof the tracked object changes poition
       Vector2 TargetPosition { get; set; }

        //this boolean deffines when the target is collidign and could be moved by the terrain and needs to be moved back
        bool IsColliding { get; set; }
    }
}
