using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Framework.Animations
{
    //IAnimation is an interface for animation of entities
    //The Function of each animation is to convert a selection of sprites on a sprite sheet into a single texture in time with the entity
    //Each animation will pertain for one animaion effect, so one animation will contain all the frames for a move left animation so each entity will have many animations depending on their needs
    interface IAnimation
    {
        //This int represents the current frame in the animation
        int aCurrentFrame { get; set; }

        //THis holds the number of frames the animaion has
        int aFrameCount { get; }

        //This gets the width and height of the frame
        int aFrameHeight { get; }
        int aFrameWidth { get; }

        //This holds the speed at wich the animation is played
        float aFrameSpeed { get; }

        //this lets the system know if the annimation loops
        bool aIsLooping { get; }

        //this returns the texture that will be displayed in the draw method
        Texture2D aActiveTexture { get; }

        //this returns a rectamgle that will hold the texture frame
        Rectangle aActiveFrame { get; }

        //this starts the animation playing
        void Start();

        //this sets the Animation up with a texture to use
        void Initalize(Texture2D pTexture, float pFrmSpeed, bool pLoop, int pCount);

        //this sets the animation to play
        void Play(GameTime gametime);
    }
}
