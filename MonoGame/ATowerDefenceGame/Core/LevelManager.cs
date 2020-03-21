using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    static class LevelManager
    {
        public static Color BackgroundColor => _currentLevel.BackgroundColor;
        public static RenderTarget2D ScreenSpace => _screens[0];

        private static RenderTarget2D[] _screens;
        private static ILevel _currentLevel;
        private static bool _levelChanging, _transition;
        private static float _alpha;
        private static GraphicsDeviceManager _graphicsDeviceManager;

        public static void Init(GraphicsDeviceManager graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;

            _screens = new RenderTarget2D[2];
            _screens[0] = new RenderTarget2D(graphicsDeviceManager.GraphicsDevice, GameSettings.BaseWidth, GameSettings.BaseHeight);
        }

        public static void LoadLevel(ILevel level, bool transition = true)
        {
            _levelChanging = true;

            _screens[1] = _screens[0];
            _screens[0] = new RenderTarget2D(_graphicsDeviceManager.GraphicsDevice, GameSettings.BaseWidth, GameSettings.BaseHeight);
            _transition = transition;
            _alpha = 1f;

            _currentLevel = level;
            _levelChanging = false;
        }

        public static void Update(GameTime gameTime)
        {
            if (_levelChanging)
                return;

            _currentLevel.Update(gameTime);
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_levelChanging)
                return;

            _graphicsDeviceManager.GraphicsDevice.SetRenderTarget(_screens[0]);
            _graphicsDeviceManager.GraphicsDevice.Clear(BackgroundColor);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _currentLevel.BeforeDraw(gameTime, spriteBatch);
            _currentLevel.Draw(gameTime, spriteBatch);

            if (_transition)
            {
                spriteBatch.Draw(_screens[1], Vector2.Zero, Color.White * _alpha);

                _alpha -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_alpha <= 0f)
                    _transition = false;
            }

            spriteBatch.End();

            _graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }
    }
}