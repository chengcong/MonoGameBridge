using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace ATowerDefenceGame
{
    class MenuLevel : ILevel
    {
        private const string TitleText = "A Tower Defence Game";
        private readonly Vector2 _titlePosition;

        public MenuLevel()
        {
            BackgroundColor = Color.Black;
            GameSettings.SetCursor(CursorType.Pointer);

            var measurements = GameContent.Font.TitleFont.MeasureString(TitleText);
            _titlePosition = new Vector2((GameSettings.BaseWidth - measurements.X) / 2f, 40f);

            var playbutton = new MenuButton("Play", new Vector2(GameSettings.BaseWidth / 2f, 400f));
            playbutton.Activated += (sender, e) => LevelManager.LoadLevel(new GameLevel());
            Objects.Add(playbutton);

            var fullscreenbutton = new MenuButton("Fullscreen: off", new Vector2(GameSettings.BaseWidth / 4f, 500f), false);
            fullscreenbutton.Activated += delegate
            {
                var fullscreen = !GameSettings.GDManager.IsFullScreen;

                fullscreenbutton.Text = "Fullscreen: " + (fullscreen ? "on" : "off");
                GameSettings.GDManager.IsFullScreen = fullscreen;
                GameSettings.GDManager.ApplyChanges();
            };
            Objects.Add(fullscreenbutton);

            var quitbutton = new MenuButton("Quit", new Vector2(GameSettings.BaseWidth * 3f / 4f, 500f), false);
            quitbutton.Activated += (sender, e) => Game1.Instance.Exit();
            Objects.Add(quitbutton);
        }

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameContent.Font.TitleFont, TitleText, _titlePosition, Color.White);

            base.Draw(gameTime, spriteBatch);
        }
    }
}