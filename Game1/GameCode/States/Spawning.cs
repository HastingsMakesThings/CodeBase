using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Managers;
using Microsoft.Xna.Framework;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.GameCode.States
{
    //the funnction fo this method is to provide a Behaviour for spawngin Enities to specified areas
    class Spawning : State
    {
        //instance variables
        //needs a timmer variable that will hold a random time
        float _myTimer;

        //sets an obnject that counts up based on gametime
        float _mCounter;
        //sets a value for the position they wait in when off screen
        Vector2 _mWaitingPosition;

        //IGameObject
        IGameObject _mSpawner;

        //this position sets the Spawner position
        Vector2 _mSpawnPos;
        public Spawning()
        {
            _myTimer = 0;
            _mCounter = 0;
        }

        public override void NewTarget(IGameObject pTarget)
        {
            _mSpawner = pTarget;

            Random tempRandom = new Random();

            _myTimer = tempRandom.Next(((int)Math.Sqrt(3 * _mMover.MoverID)), (50));

            _mCounter = 0;

            _mMover.oPostion = _mWaitingPosition;


        }

        //this is used to set the waiting position of all entities
        public override void Initalize(IMover pMover)
        {
            _mMover = pMover;

            //updates data
            UpdateData();

            _mWaitingPosition = new Vector2(-2000, -20000);



        }
        public override void Run(GameTime gametime)
        {
            //checks that the mover is not null
            if((_mMover != null)&&_myTimer != 0)
            {
                _mCounter += (float)gametime.ElapsedGameTime.TotalSeconds;
                if(_mCounter >= _myTimer)
                {
                    Console.WriteLine("Time to spawn");

                    Vector2 spawn = _mSpawner.Position;
                    Random tempRandom = new Random();

                    spawn.X += tempRandom.Next(-200, 200);
                    spawn.Y += tempRandom.Next(-200, 200);
                    _mMover.oPostion = spawn;

                    _mCounter = 0;
                    _mMover.getMind.SetCondition("Spawned");
                }
            }
        }

    }
}
