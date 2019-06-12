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


            //Animation for the furniture
            #region Furniture sprites
            IDictionary<string, IAnimation> FurnitureAnim = new Dictionary<string, IAnimation>();
            FurnitureAnim.Add("Idle", _mAnimFac.CreatAnimation("Obstacle", 1, false, 1));
            FurnitureAnim.Add("Cabinet", _mAnimFac.CreatAnimation("cabinet", 1, false, 1));
            FurnitureAnim.Add("Glass cabinet", _mAnimFac.CreatAnimation("glass cabinet", 1, false, 1));
            FurnitureAnim.Add("Bed dirty left hor", _mAnimFac.CreatAnimation("side_left_dirty bed", 1, false, 1));
            FurnitureAnim.Add("Bed dirty right hor", _mAnimFac.CreatAnimation("side_right_dirty bed", 1, false, 1));
            FurnitureAnim.Add("Bed clean right hor", _mAnimFac.CreatAnimation("side_right_clean bed", 1, false, 1));
            FurnitureAnim.Add("Bed empty right hor", _mAnimFac.CreatAnimation("side_right_empty bed", 1, false, 1));
            FurnitureAnim.Add("Bed clean top ver", _mAnimFac.CreatAnimation("top_clean window bed", 1, false, 1));
            FurnitureAnim.Add("Bed dirty top ver", _mAnimFac.CreatAnimation("top_dirty bed", 1, false, 1));
            FurnitureAnim.Add("Bed empty top ver", _mAnimFac.CreatAnimation("top_empty bed", 1, false, 1));
            FurnitureAnim.Add("Tray angled", _mAnimFac.CreatAnimation("tray angle", 1, false, 1));
            FurnitureAnim.Add("Tray hor", _mAnimFac.CreatAnimation("tray side", 1, false, 1));
            FurnitureAnim.Add("Tray ver", _mAnimFac.CreatAnimation("tray top", 1, false, 1));
            #endregion

            IDictionary<string, IAnimation> DoctorAnim = new Dictionary<string, IAnimation>();
            IDictionary<string, IAnimation> NurseAnim = new Dictionary<string, IAnimation>();

            DoctorAnim.Add("Idle", _mAnimFac.CreatAnimation("Doctor1_Idle", 50, true, 8));

            NurseAnim.Add("Idle", _mAnimFac.CreatAnimation("Nurse4_Idle", 50, true, 8));
            IDictionary<string, IAnimation> BoxAnim = new Dictionary<string, IAnimation>();
            BoxAnim.Add("Idle", _mAnimFac.CreatAnimation("Player2", 1, false, 1));

            IDictionary<string, IAnimation> ChPatAnim = new Dictionary<string, IAnimation>();
            ChPatAnim.Add("Idle", _mAnimFac.CreatAnimation("Player3", 1, false, 1));

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

            #region Room Floors

            #region Room Collum One
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(293, 434, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(293, 1567, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            #endregion

            #region Room Collum Two
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1293, 434, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Enviroment>(1293, 1567, FloorAnim, "Room left", 1, false, false, 0.001f, true));
            #endregion

            #endregion


            

            // Placement code for walls
            #region Wall placement

            #region Room One

            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(730, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(297, 294, WallAnim, "Room left top", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(297, 850, WallAnim, "Top left", 1, false, false, 0f, true));

            #endregion

            #region Room Two

            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305, 1454, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(730, 1454, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(297, 1444, WallAnim, "Room left top", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(297, 2000, WallAnim, "Top left", 1, false, false, 0f, true));

            #endregion

            #region Room Three

            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1730, 304, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1297, 294, WallAnim, "Room left top", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1297, 850, WallAnim, "Top left", 1, false, false, 0f, true));

            #endregion

            #region Room Four

            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305, 1454, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1730, 1454, WallAnim, "Middle wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1297, 1444, WallAnim, "Room left top", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1297, 2000, WallAnim, "Top left", 1, false, false, 0f, true));

            #endregion

            #region Edge
            // Side wall placement
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(0, 0, WallAnim, "Left wall", 1, false, false, 0f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(2000, 0, WallAnim, "Left wall", 1, false, false, 0f, true));

            // Top wall placement
            for (int i = 0; i < 5; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(5 + (400 * i), 3, WallAnim, "Top right", 1, false, false, 0.01f, true));
            }

            for (int i = 0; i < 5; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(5 + (400 * i), 2270, WallAnim, "Top right", 1, false, false, 0.01f, true));
            }
            #endregion

            #endregion

            // Placement code for furniture
            #region Furniture placement
            #region Room One
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 400, FurnitureAnim, "Bed dirty left hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 550, FurnitureAnim, "Bed clean right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 700, FurnitureAnim, "Bed empty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 500, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 650, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(485, 330, FurnitureAnim, "Cabinet", 1, false, false, 0.0001f, true));
            #endregion

            #region Room Two
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 1550, FurnitureAnim, "Bed dirty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 1700, FurnitureAnim, "Bed dirty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 1850, FurnitureAnim, "Bed dirty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 1650, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(315, 1800, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(485, 1480, FurnitureAnim, "Glass cabinet", 1, false, false, 0.0001f, true));
            #endregion

            #region Room Three
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 400, FurnitureAnim, "Bed dirty left hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 550, FurnitureAnim, "Bed clean right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 700, FurnitureAnim, "Bed empty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 500, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 650, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1485, 330, FurnitureAnim, "Cabinet", 1, false, false, 0.0001f, true));
            #endregion

            #region Room Four
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 1550, FurnitureAnim, "Bed clean right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 1700, FurnitureAnim, "Bed empty right hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 1850, FurnitureAnim, "Bed dirty left hor", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 1650, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1315, 1800, FurnitureAnim, "Tray ver", 1, false, false, 0.0001f, true));
            _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1485, 1480, FurnitureAnim, "Cabinet", 1, false, false, 0.0001f, true));
            #endregion

            #endregion

            // Placement code for Props
            #region Prop placement
            #endregion

            // Placement code for Wall Colliders
            #region Collider placement
            #region Edge
            for (int i = 0; i < 34; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(-40 + (64 * i), 85, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }

            for (int i = 0; i < 34; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(-40 + (64 * i), 2300, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }

            for (int i = 0; i < 80; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(-40, 3 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }

            for (int i = 0; i < 80; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(2020, 3 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            #endregion

            #region Room One
            for (int i = 0; i < 4; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305 + (64 * i), 380, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 7; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305 + (64 * i), 950, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(675 , 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305 , 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(369, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(430, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            #endregion

            #region Room Two
            for (int i = 0; i < 4; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305 + (64 * i), 1530, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 7; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305 + (64 * i), 2100, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(675, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(305, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(369, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(430, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            #endregion

            #region Room Three
            for (int i = 0; i < 4; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305 + (64 * i), 380, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 7; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305 + (64 * i), 950, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1675, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1369, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1430, 380 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            #endregion

            #region Room Four
            for (int i = 0; i < 4; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305 + (64 * i), 1530, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 7; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305 + (64 * i), 2100, WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1675, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1305, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1369, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            for (int i = 0; i < 20; i++)
            {
                _GameList.Add(pEntityFac.CreateGameObject<Obstacle>(1430, 1530 + (30 * i), WallAnim, "Idle", 1, false, true, 0.0001f, false));
            }
            #endregion

            #endregion



            #region Player and NPC's
            _GameList.Add(pEntityFac.CreateGameObject<Player>(1000, 2000, PlayerAnim, "Idle", 0.07f, true, true, 0.1f, true));

            _GameList.Add(pEntityFac.CreateGameObject<TBPatient>(800, 2100, NurseAnim, "Idle", 0.07f, false, false, 0.01f, true));
            _GameList.Add(pEntityFac.CreateGameObject<CholeraPatient>(860, 1700, DoctorAnim, "Idle", 0.07f, false, false, 0.01f, true));
            _GameList.Add(pEntityFac.CreateGameObject<TBPatient>(900, 2100, NurseAnim, "Idle", 0.07f, false, false, 0.01f, true));
             _GameList.Add(pEntityFac.CreateGameObject<CholeraPatient>(1100, 950, DoctorAnim, "Idle", 0.07f, false, false, 0.01f, true));
            _GameList.Add(pEntityFac.CreateGameObject<TBPatient>(1200, 2000, NurseAnim, "Idle", 0.07f, false, false, 0.01f, true));

            _GameList.Add(pEntityFac.CreateGameObject<Spawner>(1000, 1800, BoxAnim, "Idle", 1, false, false, 0.001f, false));
            #endregion

            #region Triggers
            _GameList.Add(pEntityFac.CreateGameObject<PlayerTrigBox>(0, 0, WallAnim, "Idle", 2, false, false, 0.01f, false));

            _GameList.Add(pEntityFac.CreateGameObject<TBTreatmentRoom>(500, 500, BoxAnim, "Idle", 2, false, false, 0.01f, false));
            _GameList.Add(pEntityFac.CreateGameObject<ChTreatmentRoom>(1500, 500, ChPatAnim, "Idle", 2, false, false, 0.01f, false));
            #endregion

        }

        public List<IGameObject> GameList
        {
            get { return _GameList; }
        }
    }
}
