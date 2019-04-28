using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Interfaces.Sub_Entities
{
    //This interface is unqiue to all objects that have moment behaviours
    interface IMover
    {
      //Decllare some getors and setters

        //This allows the objects mass to be obtained
        float oMass { get; }

        //This allows the objects friction to be obtained
        float oFriction { get; }

        //This allows the objects max speed to be obtained
        float oMaxSpeed { get; }

        //This allows the objects position to be obtained
        Vector2 oPostion { get; set; }

        //This allows the objects current velocity to be obtained
        Vector2 oVelocity { get; set; }

        //This allows the facing directions of the entity to be obtained
        float oVertDir { get; }

        //And Staring Kristian Nairn as..
        float oHorDir { get; }

        Vector2 oAccel { get; set; }

        IAIMind getMind { get; }

        string currentText { get; set; }
    }
}
