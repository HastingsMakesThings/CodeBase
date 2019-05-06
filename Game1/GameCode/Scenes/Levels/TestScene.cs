using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1.Framework.Interfaces;
using Game1.Framework.Factories;
using Game1.Framework.EntityCode;
using Game1.GameCode.PlayerCode;
using Game1.GameCode.Obstacles;
using Game1.GameCode.NPCs;
using Game1.Framework.Interfaces.Sub_Entities;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Animations;
using Game1.Framework.Interfaces.Scenes;
using Game1.GameCode.Triggers;

namespace Game1.GameCode.Scenes.Levels
{
    class TestScene: IScene
    {
        protected List<IGameObject> _GameList;

        //animation factory for creating animations in the sceene
        private IAnimationFactory _mAnimFac;

        public TestScene()
        {
            _GameList = new List<IGameObject>();

            //Construct animation factory
            _mAnimFac = new AnimationFactory();
        }

        public void setup(ContentManager pContent, IEntityFactory pEntityFac)
        {
            //initalkise animation factory
            _mAnimFac.Initialize(pContent);

            // Animation for the player
            #region Player sprites
            //Animation for the player character
            #region Lowered arm sprites
            IDictionary<string, IAnimation> PlayerAnim = new Dictionary<string, IAnimation>();
            PlayerAnim.Add("Idle", _mAnimFac.CreatAnimation("SpriteSheetC.H.", 50, false, 5));
            PlayerAnim.Add("Down", _mAnimFac.CreatAnimation("Hastings_Front_02", 100, true, 8));
            PlayerAnim.Add("Up", _mAnimFac.CreatAnimation("Hastings_Back_02", 100, true, 8));
            PlayerAnim.Add("Right", _mAnimFac.CreatAnimation("Hastings_Right_02", 100, true, 8));
            PlayerAnim.Add("Left", _mAnimFac.CreatAnimation("Hastings_Left_02", 100, true, 8));
            #endregion
            //Animation for the player character with arms raised
            #region Raised arm sprites
            PlayerAnim.Add("Idle_H", _mAnimFac.CreatAnimation("SpriteSheet_Front_ArmsRaised01", 50, false, 8));
            PlayerAnim.Add("Down_H", _mAnimFac.CreatAnimation("SpriteSheet_Front_ArmsRaised01", 100, true, 8));
            PlayerAnim.Add("Up_H", _mAnimFac.CreatAnimation("SpriteSheet_Back_ArmsRaised01", 100, true, 8));
            PlayerAnim.Add("Right_H", _mAnimFac.CreatAnimation("SpriteSheet_Right_ArmsRaised01", 100, true, 8));
            PlayerAnim.Add("Left_H", _mAnimFac.CreatAnimation("SpriteSheet_Left_ArmsRaised01", 100, true, 8));
            #endregion
            #endregion

            //Animation for the walls
            #region Wall sprites

            IDictionary<string, IAnimation> WallAnim = new Dictionary<string, IAnimation>();
            WallAnim.Add("Idle", _mAnimFac.CreatAnimation("Obstacle", 1, false, 1));
            WallAnim.Add("Corridor room left", _mAnimFac.CreatAnimation("corridor room_left", 1, false, 1));
            WallAnim.Add("Corridor room right", _mAnimFac.CreatAnimation("corridor room_right", 1, false, 1));
            WallAnim.Add("Room left top", _mAnimFac.CreatAnimation("room_left top", 1, false, 1));
            WallAnim.Add("Room right top", _mAnimFac.CreatAnimation("room_right top", 1, false, 1));
            WallAnim.Add("Picture wall", _mAnimFac.CreatAnimation("picture wall", 1, false, 1));
            WallAnim.Add("Top left", _mAnimFac.CreatAnimation("top left", 1, false, 1));
            WallAnim.Add("Top middle", _mAnimFac.CreatAnimation("top middle", 1, false, 1));
            WallAnim.Add("Top right", _mAnimFac.CreatAnimation("top right", 1, false, 1));
            WallAnim.Add("Left wall", _mAnimFac.CreatAnimation("left wall", 1, false, 1));
            WallAnim.Add("Middle wall", _mAnimFac.CreatAnimation("middle wall", 1, false, 1));
            WallAnim.Add("Right wall", _mAnimFac.CreatAnimation("right wall", 1, false, 1));
            #endregion

            //Animation for the floors
            #region Floor sprites
            IDictionary<string, IAnimation> FloorAnim = new Dictionary<string, IAnimation>();
            FloorAnim.Add("Idle", _mAnimFac.CreatAnimation("Obstacle", 1, false, 1));
            FloorAnim.Add("Corridor H", _mAnimFac.CreatAnimation("corridor_H", 1, false, 1));
            FloorAnim.Add("Corridor V", _mAnimFac.CreatAnimation("corridor_V", 1, false, 1));
            FloorAnim.Add("Office floor", _mAnimFac.CreatAnimation("office floor", 1, false, 1));
            FloorAnim.Add("Room left", _mAnimFac.CreatAnimation("room_left", 1, false, 1));
            FloorAnim.Add("Room right", _mAnimFac.CreatAnimation("room_right", 1, false, 1));
            FloorAnim.Add("Top left", _mAnimFac.CreatAnimation("top_left room", 1, false, 1));
            FloorAnim.Add("Top right", _mAnimFac.CreatAnimation("top_right room", 1, false, 1));
            #endregion

            IDictionary<string, IAnimation> BoxAnim = new Dictionary<string, IAnimation>();
            BoxAnim.Add("Idle", _mAnimFac.CreatAnimation("Player2", 1, false, 1));

              _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(875, 1140, FloorAnim, "Office floor", 1, false, false, 1, true));

            #region Vertical Corridors
            #region Corridor V Collum One
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(5, 145, FloorAnim, "Corridor V", 1, false, false, 0.0001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(5, 837, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(5, 1278, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
              _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(5, 1718, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            #endregion

            #region Corridor V Collum Two
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(725, 145, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(725, 837, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(725, 1278, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(725, 1718, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            #endregion

            #region Corridor V Collum Three
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1005, 145, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1005, 837, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1005, 1278, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
              _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1005, 1718, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            #endregion

            #region Corridor V Collum Four
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1725, 145, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1725, 837, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1725, 1278, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1725, 1718, FloorAnim, "Corridor V", 1, false, false, 0.001f, true));
            #endregion

            #endregion

            #region Horizontal Corridors
            #region Corridor H Collum One
                _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(10, 150, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
               _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(10, 995, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
                _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(10, 1283, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
               _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(10, 2130, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
            #endregion

            #region Corridor H Collum One
                  _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(810, 150, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
                 _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(810, 995, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
                _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(810, 1283, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
               _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(810, 2130, FloorAnim, "Corridor H", 1, false, false, 0.001f, true));
            #endregion
            #endregion

            #region Rooms

            #region Room Collum One
              _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(293, 434, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(293, 1567, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            #endregion

            #region Room Collum Two
              _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1293, 434, FloorAnim, "Room left", 1, false, false, 0.001f, true));
             _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1293, 1567, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            #endregion

            #endregion



            //_GameList.Add(pEntityFac.CreateGameObject<Obstacle>(0, 0, WallAnim, "Left wall", 1, false, false, 0f, true));
            //_GameList.Add(pEntityFac.CreateGameObject<Obstacle>(300, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            //_GameList.Add(pEntityFac.CreateGameObject<Obstacle>(745, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            //_GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305, 294, WallAnim, "Room left top", 1, false, false, 0f, true));
            //_GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305, 850, WallAnim, "Room left top", 1, false, false, 0f, true));

            //for (int i = 0; i < 5; i++)
            //{
            //    _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(5 + (400 * i), 3, WallAnim, "Top right", 1, false, false, 0.01f, true));
            //}





            #region Player and NPC's
            _GameList.Add(pEntityFac.CreateGameObject<Player>(800, 600, PlayerAnim, "Idle", 0.07f, true, true, 0.1f, true));

            _GameList.Add(pEntityFac.CreateGameObject<Patient>(1000, 200, BoxAnim, "Idle", 1, false, true, 0.01f, true));
            #endregion

            #region Triggers
            _GameList.Add(pEntityFac.CreateGameObject<PlayerTrigBox>(0, 0, WallAnim, "Idle", 2, false, false, 0.01f, false));

            _GameList.Add(pEntityFac.CreateGameObject<Room>(0, 0, WallAnim, "Idle", 2, false, false, 0.01f, false));
            #endregion

        }

        public List<IGameObject> GameList
        {
            get { return _GameList; }
        }
    }
}
