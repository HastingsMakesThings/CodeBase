using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.EntityCode;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Managers;
using Game1.GameCode.Behaviours;
using Game1.Framework.EntityCode.Sub_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.GameCode.Movers;
using Game1.Framework.EntityCode.Sub_Minds;

namespace Game1.GameCode.PlayerCode
{
    class Player : Mover, IMover
    {
        // List of type IBehaviour prefix with '_'
        protected List<IState> _BList;
        // Horizontal behaviour prefix with '_'
        protected IState _HorMove;
        // Vertical behaviour prefix with '_'
        protected IState _VerMove;



        public Player()
        {
            // Initialise Type
            Type = "Player";
            // Initialise Mind
            _MyMind = new PlayerMind(this);
            // Initialise _BList
            _BList = new List<IState>();
            // Initialise behaviours
            _HorMove = new MoveHorizontal(this);
            _VerMove = new MoveVertical(this);
            
            // Add behaviours into _BList
            _BList.Add(_HorMove);
            _BList.Add(_VerMove);

            _mMass = 20;
            _maxSpeed = 10;
            _mFriction = -0.5f;
        }

        public override void Update()
        {

            CalculateProjectedX();
            CalculateProjectedY();

            if (_CollideT)
                _VerDir = Convert.ToInt32(KeyboardManager.KeyDown);
            else if (_CollideB)
                _VerDir = Convert.ToInt32(KeyboardManager.KeyUp) * -1;
            else
                _VerDir = Convert.ToInt32(KeyboardManager.KeyDown) - Convert.ToInt32(KeyboardManager.KeyUp);

            if (_CollideL)
                _HorDir = Convert.ToInt32(KeyboardManager.KeyRight);
            else if (_CollideR)
                _HorDir = Convert.ToInt32(KeyboardManager.KeyLeft) * -1;
            else
                _HorDir = Convert.ToInt32(KeyboardManager.KeyRight) - Convert.ToInt32(KeyboardManager.KeyLeft);

            foreach (IState b in _BList)
            { 
                b.Run();
            }
            
            CalculateVertexes();
        }

        public  override void CollReact(Vector2 pMTV)
        {
            this.Position = Position + pMTV;
        }

        #region Properties


        #endregion

    }
}
