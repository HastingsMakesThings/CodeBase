using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Managers;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernal : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Octin_vintage;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static bool _Focused;

        // DECLARE list of type IManager prefix with '_'
        private List<IManager> _MList;

        // DECLARE managers prefix them with '_'
        // _SceneMgr will be used to manage scenes
        ISceneManager _SceneMgr;
        // _EntityMgr will be used to manage entities
        IEntityManager _EntityMgr;
        // _RenderMgr will be used to draw scene and entities
        IRenderManager _RenderMgr;
        // _KeyBMgr will be used to manage inputs from the keyboard
        IKeyboardManager _KeyBMgr;
        // _MouseMgr will be used to manage input from the mouse
        IMouseManager _MouseMgr;
        // _CollisionMgr will be used to manage collision
        ICollisionManager _CollisionMgr;
        // _AIMgr will be used to handle the AI
        IAIManager _AIMgr;
        // _SoundMgr will be used to handle the sound
        ISoundManager _SoundMgr;

        public Kernal()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.GraphicsProfile = GraphicsProfile.HiDef;

            // Define resolution
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            

            // Allow mouse to be seen 
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Set screen width and height
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            // Initialise manager list
            _MList = new List<IManager>();

            // Initialise managers
            _SceneMgr = new SceneManager(Content);
            _RenderMgr = new RenderManager(Content);
            _EntityMgr = new EntityManager(Content);
            _KeyBMgr = new KeyboardManager();
            _MouseMgr = new MouseManager();
            _SoundMgr = new SoundManager(Content);
            _CollisionMgr = new CollisionManager();
            _AIMgr = new AIManager();

            // Add managers to _MList
            _MList.Add(_SceneMgr);
            _MList.Add(_EntityMgr);
            _MList.Add(_KeyBMgr);
            _MList.Add(_MouseMgr);
            _MList.Add(_SoundMgr);
            _MList.Add(_AIMgr);
            _MList.Add(_CollisionMgr);
           

            // _RenderMgr doesnt get added as its called from within the draw method
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Octin_vintage = Content.Load<SpriteFont>("Octin_Vintage");
            _EntityMgr.LoadLevel("Test");
            _SceneMgr.LoadScene("Test");
            _CollisionMgr.GrabGameList(_EntityMgr.GameObjectList);
            _AIMgr.GrabAllMovers(_EntityMgr.GameObjectList);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _Focused = IsActive;

            foreach (IManager m in _MList)
            {
                m.Update(gameTime);
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // DRAW GameObjectList
            _RenderMgr.Draw(spriteBatch, _EntityMgr.GameObjectList);
            // DRAW SceneList
            _RenderMgr.Draw(spriteBatch, _SceneMgr.SceneList);
            // DRAW TextList
            _RenderMgr.Draw(spriteBatch, Octin_vintage, _SceneMgr.TextList);

            base.Draw(gameTime);
        }
    }
}
