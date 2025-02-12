﻿using Game1.Framework.EntityCode.Sub_Entities;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.GameCode.Minds;
using Game1.GameCode.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.GameCode.Triggers
{
    //this object is the trigger box that follows the player
    class PlayerTrigBox : Mover, ITriggerArea
    {
        //instacne variables
        //protected strign array for all the triggers that the triggerbox holds
        private string[] _myTriggers;

        public PlayerTrigBox()
        {
            _MyMind = new PlayerTrigBoxMind();
            _MyMind.Initalize(this);
            _MyMind.AddState<Shadow>("Shadow", this);

            _myTriggers = new string[1];
            _myTriggers[0] = "PlayerTrigger";
        }

        public override void Update(GameTime gameTime)
        {
            CalculateVertexes();
        }

        protected override void CalculateVertexes()
        {
            _Vertexes = new Vector2[4];

            _Vertexes[0].X = this.Position.X;
            _Vertexes[0].Y = this.Position.Y ;

            _Vertexes[1].X = this.Position.X + (_textureBounds.Width * _Scale);
            _Vertexes[1].Y = this.Position.Y + (_textureBounds.Height * _Scale);

            _Vertexes[2].X = this.Position.X + (_textureBounds.Width * _Scale);
            _Vertexes[2].Y = this.Position.Y + (_textureBounds.Height * _Scale);

            _Vertexes[3].X = this.Position.X;
            _Vertexes[3].Y = this.Position.Y + (_textureBounds.Height * _Scale);
        }
        //this funciton is used to identify if any of the strings in the pTriggers is relevent to this Triger area
        public virtual string IsTrigger(string[] pTriggers)
        {
            //for each value in the _mytriggers string, the strign is coampred to the string passed in, if there is a match, that strgin is returned lettign the caller react in their own deffined way
            foreach (string tempStr in _myTriggers)
            {
                foreach (string tempTrig in pTriggers)
                {
                    if (tempStr == tempTrig)
                        return tempStr;
                }
            }
            //default is returned if no match
            return "null";
        }
    }
}
