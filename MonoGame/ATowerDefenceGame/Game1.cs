using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ATowerDefenceGame
{
    public class Game1 : Game
    {
        public static Game1 Instance;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RasterizerState rasterizerState;

        public Game1()
        {
            Instance = this;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
            graphics.PreferredBackBufferWidth = GameSettings.BaseWidth;
            graphics.PreferredBackBufferHeight = GameSettings.BaseHeight;
            // graphics.IsFullScreen = true;
            graphics.HardwareModeSwitch = false;

            rasterizerState = new RasterizerState();
            rasterizerState.MultiSampleAntiAlias = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "A Tower Defence Game";

            base.Initialize();
        }

        protected override async void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GameContent.Init(Content, GraphicsDevice);
            GameSettings.Init(graphics);

            LevelManager.Init(graphics);
            LevelManager.LoadLevel(new BootLevel(GraphicsDevice), false);
        }

        protected override void Update(GameTime gameTime)
        {
            if (!GameContent.IsLoaded)
                return;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.Update();
            LevelManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!GameContent.IsLoaded)
            {
                GraphicsDevice.Clear(Color.DarkGreen);
                return;
            }

            GraphicsDevice.Clear(LevelManager.BackgroundColor);
            LevelManager.Draw(gameTime, spriteBatch);

            spriteBatch.Begin(
                rasterizerState: this.rasterizerState
            );
            spriteBatch.Draw(LevelManager.ScreenSpace, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), null, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
